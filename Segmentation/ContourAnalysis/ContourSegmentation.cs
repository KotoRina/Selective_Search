using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ContourAnalysis
{
    public class ContourSegmentation
    {
        public static VectorOfVectorOfPoint GetAllContours(Mat matrix)
        {
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(matrix, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

            return contours;
        }

        public static VectorOfVectorOfPoint SortContours(VectorOfVectorOfPoint contours)
        {
            VectorOfVectorOfPoint contoursResult = new VectorOfVectorOfPoint();
            for (int i = 0; i < contours.Size; i++)
            {
                if (contours[i].Size > 4)
                {
                    contoursResult.Push(contours[i]);
                }
            }

            return contoursResult;
        }

        public static List<Rectangle> GetRectangle(VectorOfVectorOfPoint contours)
        {
            List<Rectangle> Box = new List<Rectangle>();
            for (int i = 0; i < contours.Size; i++)
            {
                //TODO: сортировка по площади
                Box.Add(CvInvoke.BoundingRectangle(contours[i]));
            }

            return Box;
        }

        public static void DelineationOfRectangles(Mat matrix, List<Rectangle> Box, string pathSave = "")
        {
            foreach (var rectangle in Box)
            {
                CvInvoke.Rectangle(matrix, rectangle, new MCvScalar(0, 200, 0));
            }

            if(pathSave != "")
            {
                matrix.Save(pathSave);
            }
        }
    }
}
