using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroNets
{
    public class Hopfild
    {
        private List<List<int>> xInput;
        private List<List<int>> w;
        private List<int> checkImage;
        private List<int> teta;
        private int height;
        private int width;

        private void GetWeight()
        {
            for (int k = 0; k < xInput.Count; k++)
            {
                for (int i = 0; i < xInput[k].Count; i++)
                {
                    for (int j = 0; j < xInput[k].Count; j++)
                    {
                        if (i != j)
                        {
                            w[i][j] += xInput[k][i] * xInput[k][j];
                        }
                    }
                }
            }
        }

        private void GetInput()
        {
            teta = new List<int>();
            for (int i = 0; i < w.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < w[i].Count; j++)
                {
                    sum += checkImage[j] * w[i][j];
                }
                teta.Add(sum);
            }
        }

        private void GetOutput()
        {
            for (int i = 0; i < teta.Count; i++)
            {
                if (teta[i] > 0)
                {
                    teta[i] = 1;
                }
                else if (teta[i] == 0)
                {
                    int f = checkImage[i];
                    teta[i] = f;
                }
                else
                {
                    teta[i] = -1;
                }
            }
        }

        private bool CheckOutput()
        {
            for (int i = 0; i < teta.Count; i++)
            {
                if (checkImage[i] != teta[i])
                {
                    for (int j = 0; j < teta.Count; j++)
                    {
                        int f = teta[j];
                        checkImage[j] = f;
                    }
                    return false;
                }
            }
            return true;
        }

        public Bitmap Learn()
        {
            int k = 1;
            GetWeight();
            GetInput();
            GetOutput();
            while (!CheckOutput())
            {
                GetInput();
                GetOutput();
                k++;
            }
            Bitmap outputImage = new Bitmap(width, height);
            for (int i = 0; i < outputImage.Width; i++)
            {
                for (int j = 0; j < outputImage.Height; j++)
                {
                    if (teta[i*height+j] == 1)
                    {
                        outputImage.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        outputImage.SetPixel(i, j, Color.White);
                    }
                }
            }
            return outputImage;
        }

        public Hopfild(List<Bitmap> inputImage, Bitmap image)
        {
            w = new List<List<int>>();
            height = image.Height;
            width = image.Width;
            //for (int k = 0; k < image.Width * image.Height; k++)
            //{
            for (int i = 0; i < image.Width*image.Height; i++)
            {
                List<int> temp = new List<int>();
                for (int j = 0; j < image.Width * image.Height; j++)
                {
                    temp.Add(0);
                }
                w.Add(temp);
            }
                
            //}
            xInput = new List<List<int>>();
            checkImage = new List<int>();
            foreach (Bitmap item in inputImage)
            {
                List<int> temp = new List<int>();
                for (int i = 0; i < item.Width; i++)
                {
                    for (int j = 0; j < item.Height; j++)
                    {
                        if (item.GetPixel(i, j).B == Color.Black.B && item.GetPixel(i, j).R == Color.Black.R && item.GetPixel(i, j).G == Color.Black.G)
                        {
                            temp.Add(1);
                        }
                        else
                        {
                            temp.Add(-1);
                        }
                    }
                }
                xInput.Add(temp);
            }
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    if (image.GetPixel(i, j).B == Color.Black.B && image.GetPixel(i, j).R == Color.Black.R && image.GetPixel(i, j).G == Color.Black.G)
                    {
                        checkImage.Add(1);
                    }
                    else
                    {
                        checkImage.Add(-1);
                    }
                }
            }
        }
    }
}
