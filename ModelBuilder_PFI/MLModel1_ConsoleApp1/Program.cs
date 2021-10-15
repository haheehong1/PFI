﻿
// This file was auto-generated by ML.NET Model Builder. 

using System;

namespace MLModel1_ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
            {
                WindowNumber = 3F,
                WindowAreaSum = 10.08F,
                Z1PtsCountRatio = 0.122356F,
                Z2PtCountRatio = 0.2478097F,
                Z3PtsCountRatio = 0.3149171F,
                Z4PtsCountRatio = 0.3149171F,
                BuildingPtsCountRatio = 0.7369796F,
                EquipmentPtsCountRatio = 0F,
                TreePtsCountRatio = 0.05598835F,
                PavementPtsCountRatio = 0F,
                GrassPtsCountRatio = 0F,
                WaterPtsCountRatio = 0F,
                DynamicPtsRatio = 0F,
                SkyPtsCountRatio = 0.2070321F,
                ElementNumber = 3F,
                FloorHeights = 15.01853F,
                BuildingClosestDist = 6.775525F,
                EquipmentClosestDist = 50000F,
                TreeClosestDist = 98.28208F,
                GrassClosestDist = 50000F,
                WaterClosestDist = 50000F,
                DynamicClosestDist = 50000F,
                SkyCondition = 1F,
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = MLModel1.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual OverallRating with predicted OverallRating from sample data...\n\n");


            Console.WriteLine($"WindowNumber: {3F}");
            Console.WriteLine($"WindowAreaSum: {10.08F}");
            Console.WriteLine($"Z1PtsCountRatio: {0.122356F}");
            Console.WriteLine($"Z2PtCountRatio: {0.2478097F}");
            Console.WriteLine($"Z3PtsCountRatio: {0.3149171F}");
            Console.WriteLine($"Z4PtsCountRatio: {0.3149171F}");
            Console.WriteLine($"BuildingPtsCountRatio: {0.7369796F}");
            Console.WriteLine($"EquipmentPtsCountRatio: {0F}");
            Console.WriteLine($"TreePtsCountRatio: {0.05598835F}");
            Console.WriteLine($"PavementPtsCountRatio: {0F}");
            Console.WriteLine($"GrassPtsCountRatio: {0F}");
            Console.WriteLine($"WaterPtsCountRatio: {0F}");
            Console.WriteLine($"DynamicPtsRatio: {0F}");
            Console.WriteLine($"SkyPtsCountRatio: {0.2070321F}");
            Console.WriteLine($"ElementNumber: {3F}");
            Console.WriteLine($"FloorHeights: {15.01853F}");
            Console.WriteLine($"BuildingClosestDist: {6.775525F}");
            Console.WriteLine($"EquipmentClosestDist: {50000F}");
            Console.WriteLine($"TreeClosestDist: {98.28208F}");
            Console.WriteLine($"GrassClosestDist: {50000F}");
            Console.WriteLine($"WaterClosestDist: {50000F}");
            Console.WriteLine($"DynamicClosestDist: {50000F}");
            Console.WriteLine($"SkyCondition: {1F}");
            Console.WriteLine($"OverallRating: {1.125F}");


            Console.WriteLine($"\n\nPredicted OverallRating: {predictionResult.Score}\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}
