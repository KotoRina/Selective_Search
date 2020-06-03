using System;
//using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Cvb;
using Emgu.Util.TypeEnum;
using Emgu.CV.ML;
using Emgu.CV.Util;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using ContourAnalysis;

namespace Segmentation
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @"C:\Selective_Search_1\Assets\Input\input_1.jpg";
            string outputPath = @"C:\Selective_Search_1\Assets\Output\outputConture.jpg";
            
            Mat matInput = new Mat(inputPath);

            BinaryImage matrix = new BinaryImage(inputPath);
            VectorOfVectorOfPoint contour = ContourSegmentation.GetAllContours(matrix.Image);
            contour = ContourSegmentation.SortContours(contour);
            List<Rectangle> Box = ContourSegmentation.GetRectangle(contour);
            ContourSegmentation.DelineationOfRectangles(matInput, Box, outputPath);


            Console.WriteLine("Done");
        }
    }
}
