using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System;

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

        public static void SortContours(VectorOfVectorOfPoint contours)
        {

        }
    }
}
