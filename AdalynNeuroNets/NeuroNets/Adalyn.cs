using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroNets
{
    public class Adalyn
    {
        private List<List<double>> xInput;
        private List<double> w;
        private List<double> wPrev;
        private List<double> M;
        private List<double> checkImage;
        private const double alpha = 0.0000001;
        private const double epsilon = 0.01;

        public void CorrectWeight()
        {
            double uin = 0;
            wPrev = new List<double>(w);
            for (int j = 0; j < M.Count; j++)
            {
                uin = 0;
                for (int i = 0; i < xInput[j].Count; i++)
                {
                    uin+=w[i]*xInput[j][i];
                }
                double diff = M[j] - uin;
                for (int i = 0; i < xInput[j].Count; i++)
                {
                    w[i] += alpha*diff*xInput[j][i];
                }
            }
        }

        public bool CheckAdalyn()
        {
            double sum = 0;

            for (int i = 0; i < w.Count; i++)
            {
                double diff = Math.Abs(w[i] - wPrev[i]);
                sum += diff*diff;
            }
            if (sum <= epsilon)
            {
                return true;
            }
            return false;
        }
       
        public double ClassifyImage(Bitmap image)
        {
            checkImage = new List<double>();
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
            double result = w[0];
            for (int i = 1; i < checkImage.Count; i++)
            {
                result += checkImage[i] * w[i];
            }
            if (result > 0)
            {
                result = 1;
            }
            else if (result <= 0)
            {
                result = -1;
            }
            return result;
        }

        public void Learn()
        {
            CorrectWeight();
            while (!CheckAdalyn())
            {
                CorrectWeight();
            }
        }

        public Adalyn(List<Bitmap> inputImage)
        {
            xInput = new List<List<double>>();
            w = new List<double>();
            M = new List<double>();
            Random rnd = new Random();
            w.Add(rnd.NextDouble()*2.0-1.0);
            for(int i=0; i<inputImage[0].Width; i++)
            {
                for(int j=0; j< inputImage[0].Height; j++)
                {
                    w.Add(rnd.NextDouble() * 2.0 - 1.0);
                }
            }
            for(int i=0; i<inputImage.Count; i++)
            {
                M.Add(-1);
            }
            M[1] = 1;
            foreach(Bitmap item in inputImage)
            {
                List<double> temp = new List<double>();
                temp.Add(1);
                for(int i=0; i<item.Width; i++)
                {
                    for(int j=0; j<item.Height; j++)
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
        }
    }
}
