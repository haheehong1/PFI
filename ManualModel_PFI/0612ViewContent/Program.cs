using System;
using System.IO;
using Microsoft.ML;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Trainers.LightGbm;
using Microsoft.ML.Trainers.FastTree;
using _0728OverallRating;

namespace _0728OverallRating
{
    class Program
    {
        static readonly string _trainDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "07_Train0817.CSV");
        static readonly string _testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "07_Test0817.CSV");
        static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");
        private static MLContext mlContext = new MLContext(seed: 1);
        //private static ISingleFeaturePredictionTransformer<object> pfiModel;
        //private static IDataView preprocessedTrainData;
        private static string[] columnNames;
        private static IDataView dataView;
        private static IDataView testDataView;

        static void Main(string[] args)
        {
            
            //creat training data 
            dataView = mlContext.Data.LoadFromTextFile<Features>(_trainDataPath, hasHeader: true, separatorChar: ',');
            //creat test data
            testDataView = mlContext.Data.LoadFromTextFile<Features>(_testDataPath, hasHeader: true, separatorChar: ',');

            columnNames =
                dataView.Schema
                .Select(column => column.Name)
                .Where(colName => colName != "Label").ToArray();

            IEstimator<ITransformer> dataPrepEstimator =
                mlContext.Transforms.Concatenate("Features", columnNames)
                    .Append(mlContext.Transforms.NormalizeMinMax("Features"));

            var model = Train(mlContext, dataView, dataPrepEstimator);

            mlContext.Model.Save(model, dataView.Schema, _modelPath);
            var mlModel2 = mlContext.Model.Load(_modelPath, out var _);
            var predictor = ((TransformerChain<ITransformer>)mlModel2).Last();

            Evaluate(mlContext, testDataView, dataPrepEstimator, model);
            CalculatePFI(mlContext, model.Transform(testDataView), (ISingleFeaturePredictionTransformer<object>) predictor);
            


        }

        public static ITransformer Train(MLContext mlContext, IDataView dataView, IEstimator<ITransformer> dataPrepEstimator)
        {
            //IDataView dataView = mlContext.Data.LoadFromTextFile<Features>(dataPath, hasHeader: true, separatorChar: ',');
            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label2", inputColumnName: "Label")

                    //.Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "VendorIdEncoded", inputColumnName: "VendorId"))
                    //.Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "RateCodeEncoded", inputColumnName: "RateCode"))
                    //.Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "PaymentTypeEncoded", inputColumnName: "PaymentType"))

                    .Append(mlContext.Transforms.Concatenate("Features",
                "WindowNumber",
                "WindowAreaSum",
                "Z1PtsCountRatio",
                "Z2PtCountRatio",
                "Z3PtsCountRatio",
                "Z4PtsCountRatio",
                "BuildingPtsCountRatio",
                "EquipmentPtsCountRatio",
                "TreePtsCountRatio",
                "PavementPtsCountRatio",
                "GrassPtsCountRatio",
                "WaterPtsCountRatio",
                "DynamicPtsRatio",
                "SkyPtsCountRatio",
                "ElementNumber",
                "FloorHeights",
                "BuildingClosestDist",
                "EquipmentClosestDist",
                "TreeClosestDist",
                "GrassClosestDist",
                "WaterClosestDist",
                //"NatureClosestDist",
                "DynamicClosestDist",
                //"SkyClosestDist",
                "SkyCondition"
                ))
                    .Append(mlContext.Regression.Trainers.FastForest(new FastForestRegressionTrainer.Options() { NumberOfTrees = 4, FeatureFraction = 0.815220129448517F, LabelColumnName = @"Label2", FeatureColumnName = @"Features" }));

            var model = pipeline.Fit(dataView);
            var transformedData = model.Transform(dataView);


            ITransformer dataPrepTransformer = dataPrepEstimator.Fit(dataView);

            return model;

        }

        public static void CalculatePFI(MLContext mLContext, IDataView preprocessedTrainData, ISingleFeaturePredictionTransformer<object> model)
        {
            VBuffer<ReadOnlyMemory<char>> nameBuffer = default;
            preprocessedTrainData.Schema["Features"].Annotations.GetValue("SlotNames", ref nameBuffer);
            var featureColumnNames = nameBuffer.DenseValues().ToList();

            ImmutableArray<RegressionMetricsStatistics> permutationFeatureImportance =
                mlContext
                .Regression
                .PermutationFeatureImportance(model, preprocessedTrainData, permutationCount: 10, labelColumnName: "Label2");

            var featureImportanceMetrics = 
                permutationFeatureImportance
                .Select((metric, index) => new { index, metric.RSquared })
                .OrderByDescending(myFeatures => Math.Abs(myFeatures.RSquared.Mean));

            Console.WriteLine("Feature\tPFI");
            foreach(var feature in featureImportanceMetrics)
            {
                Console.WriteLine($"{featureColumnNames[feature.index],-20}|\t{feature.RSquared.Mean:F6}");

            }
        }

        private static void Evaluate(MLContext mlContext, IDataView testDataView, IEstimator<ITransformer> trainingPipeLine, ITransformer model)
        {
            
            var predictions = model.Transform(testDataView);

            var metrics = mlContext.Regression.Evaluate(predictions, "Label2", "Score");

            //ImmutableArray<RegressionMetricsStatistics> permutationFeatureImportance = mlContext.Regression.PermutationFeatureImportance(model, dataView, permutationCount: 3);

            Console.WriteLine();
            Console.WriteLine($"****************************************************************");
            Console.WriteLine($"*         Model quality metrics evaluation                      ");
            Console.WriteLine($"*---------------------------------------------------------------");

            Console.WriteLine($"*         RSquared Score:             {metrics.RSquared:0.##}");
            Console.WriteLine($"*         Root Mean Squared Error:    {metrics.RootMeanSquaredError:#.##}");


        }



    }
}
