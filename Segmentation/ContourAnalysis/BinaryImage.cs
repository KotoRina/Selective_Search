using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace ContourAnalysis
{
    public class BinaryImage
    {
        public Mat Image { get; set; }
        
        public BinaryImage()
        {
        }

        public BinaryImage(string path)
        {
            Mat matrix = new Mat(path);
            Image = ConvetrImageToBinary(matrix);
        }

        public BinaryImage(Mat image)
        {
            Image = ConvetrImageToBinary(image);
        }

        public Mat ConvetrImageToBinary(Mat image)
        {
            Mat result = image;
            
            CvInvoke.CvtColor(result, result, ColorConversion.Bgr2Gray); //Преобразование в серый
            CvInvoke.Threshold(result, result, 200, 255, ThresholdType.Binary); //Преобразовние в бинарное

            return result;
        }
    }
}
