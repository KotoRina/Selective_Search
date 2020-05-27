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

namespace Segmentation
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @"C:\Selective_Search\Assets\input_1.jpg";

            //Bitmap input = new Bitmap(inputPath);

            Mat matrix = new Mat(inputPath);
            Mat matInput = new Mat(inputPath);

            CvInvoke.CvtColor(matrix, matrix, ColorConversion.Bgr2Gray);
            matrix.Save(@"C:\Selective_Search\Assets\output.jpg");

            CvInvoke.Threshold(matrix, matrix, 200, 255, ThresholdType.Binary);
            matrix.Save(@"C:\Selective_Search\Assets\outputBinary.jpg");

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(matrix, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

            List<Rectangle> recContours = new List<Rectangle>();
            VectorOfVectorOfPoint contoursResult = new VectorOfVectorOfPoint();
            for(int i = 0; i < contours.Size; i++)
            {
                if(contours[i].Size > 4)
                {
                    contoursResult.Push(contours[i]);
                    
                    recContours.Add(CvInvoke.BoundingRectangle(contours[i]));
                }
            }

            //CvInvoke.DrawContours(matInput, contoursResult, 2, new MCvScalar(0,200,0));
            //matInput.Save(@"C:\Selective_Search\Assets\outputConture.jpg");

            foreach(var rectangle in recContours)
            {
                CvInvoke.Rectangle(matInput, rectangle, new MCvScalar(0,200,0));
            }

            matInput.Save(@"C:\Selective_Search\Assets\outputConture.jpg");

            Console.WriteLine("1");
        }
    }
}
