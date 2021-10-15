using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace _0728OverallRating
{
    public class Features
    {
        
        [LoadColumn(0)]
        public float WindowNumber { get; set; }

        [LoadColumn(1)]
        public float WindowAreaSum { get; set; }
        
        /*[LoadColumn(2)]
        public float WindowAreaAvg { get; set; }

        [LoadColumn(3)]
        public float DistanceToWindowSum { get; set; }

        [LoadColumn(4)]
        public float DistanceToWindowAvg { get; set; }

        [LoadColumn(5)]
        public float ViewVectorandWindowCenterAngleAvg { get; set; }

        [LoadColumn(6)]
        public float RoomWidth { get; set; }

        [LoadColumn(7)]
        public float RoomHeight { get; set; }

        [LoadColumn(8)]
        public float RoomDepth { get; set; }

        [LoadColumn(9)]
        public float RoomVolume { get; set; }

        [LoadColumn(10)]
        public float WholeRoomVolume { get; set; }

        [LoadColumn(11)]
        public float WindowToWallRatio { get; set; }

        [LoadColumn(12)]
        public float VWindowDispersion { get; set; }

        [LoadColumn(13)]
        public float HWindowDispersion { get; set; }

        [LoadColumn(14)]
        public float WindowLengthSum { get; set; }
        */
        //[LoadColumn(15)]
        //public float WindowLengthAvg { get; set; }
        /*
        [LoadColumn(16)]
        public float WindowHeightSum { get; set; }
        */
        //[LoadColumn(17)]
        //public float WindowHeightAvg { get; set; }
        /*
        [LoadColumn(18)]
        public float AspectRatioAvg { get; set; }

        [LoadColumn(19)]
        public float WindowHorizontalAngleSum { get; set; }

        [LoadColumn(20)]
        public float WindowHorizontalAngleAvg { get; set; }

        [LoadColumn(21)]
        public float WindowVerticalAngleSum { get; set; }

        [LoadColumn(22)]
        public float WindowVerticalAngleAvg { get; set; }

        [LoadColumn(23)]
        public float HViewAngle { get; set; }

        [LoadColumn(24)]
        public float VViewAngle { get; set; }

        [LoadColumn(25)]
        public float Z1PtsCount { get; set; }

        [LoadColumn(26)]
        public float Z2PtsCount { get; set; }

        [LoadColumn(27)]
        public float Z2PtsCountZ1PtsCount { get; set; }

        [LoadColumn(28)]
        public float Z3PtsCount { get; set; }

        [LoadColumn(29)]
        public float Z4PtsCount { get; set; }
        */
        [LoadColumn(30)]
        public float Z1PtsCountRatio { get; set; }

        [LoadColumn(31)]
        public float Z2PtCountRatio { get; set; }

        /*[LoadColumn(32)]
        public float Z2PtsCountZ1PtsCountRatio { get; set; }
        */
        [LoadColumn(33)]
        public float Z3PtsCountRatio { get; set; }

        [LoadColumn(34)]
        public float Z4PtsCountRatio { get; set; }

        /*[LoadColumn(35)]
        public float BuildingPtsCount { get; set; }

        [LoadColumn(36)]
        public float EquipmentPtsCount { get; set; }

        [LoadColumn(37)]
        public float TreePtsCount { get; set; }

        [LoadColumn(38)]
        public float PavementPtsCount { get; set; }

        [LoadColumn(39)]
        public float GrassPtsCount { get; set; }

        [LoadColumn(40)]
        public float WaterPtsCount { get; set; }

        [LoadColumn(41)]
        public float DynamicPtsCount { get; set; }

        [LoadColumn(42)]
        public float TreePtsCountGrassPtsCount { get; set; }

        [LoadColumn(43)]
        public float SkyPtsCount { get; set; }
        */
        [LoadColumn(44)]
        public float BuildingPtsCountRatio { get; set; }

        [LoadColumn(45)]
        public float EquipmentPtsCountRatio { get; set; }

        [LoadColumn(46)]
        public float TreePtsCountRatio { get; set; }

        [LoadColumn(47)]
        public float PavementPtsCountRatio { get; set; }

        [LoadColumn(48)]
        public float GrassPtsCountRatio { get; set; }

        [LoadColumn(49)]
        public float WaterPtsCountRatio { get; set; }

        [LoadColumn(50)]
        public float DynamicPtsRatio { get; set; }

        //[LoadColumn(51)]
        //public float TreePtsCountGrassPtsCountRatio { get; set; }
        
        [LoadColumn(52)]
        public float SkyPtsCountRatio { get; set; }
        
        
        /*[LoadColumn(53)]
        public float BuildingIsClosest { get; set; }

        [LoadColumn(54)]
        public float EquipmentIsClosest { get; set; }

        [LoadColumn(55)]
        public float TreeIsClosest { get; set; }

        [LoadColumn(56)]
        public float DynamicIsClosest { get; set; }
        */
        /*[LoadColumn(57)]
        public float SkyIsClosest { get; set; }
        
        [LoadColumn(58)]
        public float ClosestObjectDist { get; set; }
        */
        [LoadColumn(59)]
        public float ElementNumber { get; set; }

        [LoadColumn(60)]
        public float FloorHeights { get; set; }

        [LoadColumn(61)]
        public float BuildingClosestDist { get; set; }

        [LoadColumn(62)]
        public float EquipmentClosestDist { get; set; }

        [LoadColumn(63)]
        public float TreeClosestDist { get; set; }

        [LoadColumn(64)]
        public float GrassClosestDist { get; set; }

        [LoadColumn(65)]
        public float WaterClosestDist { get; set; }

        /*[LoadColumn(66)]
        public float NatureClosestDist { get; set; }
        */
        [LoadColumn(67)]
        public float DynamicClosestDist { get; set; }

        /*[LoadColumn(68)]
        public float SkyClosestDist { get; set; }
        */
        [LoadColumn(69)]
        public float SkyCondition { get; set; }

        //[LoadColumn(69)]
        //public string ID { get; set; }

        //[LoadColumn(70)]
        //[ColumnName("Label")]
        //public float ViewContentS { get; set; }

        //[LoadColumn(71)]

        //public float ViewAccessS { get; set; }

        //[LoadColumn(72)]
        //public float PrivacyS { get; set; }

        [LoadColumn(73)]
        [ColumnName("Label")]
        public float OverallRatingS { get; set; }


    }

    public class ViewAccessPrediction
    {
        [ColumnName("Score")]
        public float OverallRatingB { get; set; }
    }
}
