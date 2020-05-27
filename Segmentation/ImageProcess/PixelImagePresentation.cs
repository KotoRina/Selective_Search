using System;
using System.Drawing;
using System.Threading.Tasks;

namespace ImageProcess
{
    public class PixelImagePresentation
    {
        public Pixel[,] PixelMatrix { get; set; }
        public string Path { get; set; }

        public PixelImagePresentation()
        {
        }

        public PixelImagePresentation( Bitmap image)
        {
            PixelMatrix = GetMatrixFromBitmap(image);
        }

        public PixelImagePresentation(string path)
        {
            Path = path;

            Bitmap image = new Bitmap(path);
            PixelMatrix = GetMatrixFromBitmap(image);
        }

        public Pixel[,] GetMatrixFromBitmap(Bitmap image)
        {
            long height = image.Height;
            long width = image.Width;

            Pixel[,] result = new Pixel[height , width]; //матрица для записи результата
            for(int i = 0; i < height; i++)
            {
                for(int l = 0; l < width; l++)
                {
                    Color colorPixel = image.GetPixel(i,l);
                    Pixel pixel = new Pixel()
                    {
                        R = colorPixel.R,
                        G = colorPixel.G,
                        B = colorPixel.B,
                        A = colorPixel.A,
                        
                        X = i,
                        Y = l
                    };

                    result[i, l] = pixel;
                }
            }

            return result;
        }
    }
}
