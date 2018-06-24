using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroNets
{
    public class Kohonen
    {
        private List<List<int>> xInput;
        private List<List<double>> w;
        private List<List<double>> wPrev;
        private double alpha = 0.1;
        private List<int> checkImage;
        private List<double> distance;
        private int index = 0;
        private int indexWiner;
        private double epsilon=0.0005;

        private void GetDistance()
        {
            distance = new List<double>();
            for (int i = 0; i < w.Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < w[i].Count; j++)
                {
                    sum += Math.Pow(w[i][j] - xInput[index][j],2);
                }
                distance.Add(sum);
            }
        }

        private void GetWinner()
        {
            double max = Double.MinValue;
            for (int i = 0; i < distance.Count; i++)
            {
                if (distance[i] > max)
                {
                    max = distance[i];
                    indexWiner = i;
                }
            }
        }

        private void CorrectWeight()
        {
            for(int i=0; i<w[indexWiner].Count; i++)
            {
                w[indexWiner][i] = w[indexWiner][i] + alpha * (xInput[index][i]- w[indexWiner][i]);
            }
        }

        private void ModifyAlpha()
        {
            alpha = alpha * 0.9;
        }

        private bool CheckNeuron()
        {
            for(int i=0; i<w.Count; i++)
            {
                for(int j=0; j<w[i].Count; j++)
                {
                    if(Math.Abs(w[i][j]-wPrev[i][j])>epsilon)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Learn()
        {
            for (int i = 0; i < xInput.Count; i++)
            {
                GetDistance();
                GetWinner();
                CorrectWeight();
                index=i;
            }
            ModifyAlpha();
            while(!CheckNeuron())
            {
                wPrev = new List<List<double>>();
                for (int i = 0; i < w.Count; i++)
                {
                    List<double> temp = new List<double>();
                    for (int j = 0; j < w[i].Count; j++)
                    {
                        temp.Add(w[i][j]);
                    }
                    wPrev.Add(temp);
                }
                //index = 0;
                for (int i = 0; i < xInput.Count; i++)
                {
                    GetDistance();
                    GetWinner();
                    CorrectWeight();
                    index=i;
                }
                ModifyAlpha();
            }
        }

        public int ClassifyImage(Bitmap image)
        {
            checkImage = new List<int>();
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
                        checkImage.Add(0);
                    }
                }
            }

            distance = new List<double>();
            for (int i = 0; i < w.Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < w[i].Count; j++)
                {
                    sum += Math.Pow(w[i][j] - checkImage[j], 2);
                }
                distance.Add(sum);
            }

            double max = Double.MinValue;
            for (int i = 0; i < distance.Count; i++)
            {
                if (distance[i] > max)
                {
                    max = distance[i];
                    indexWiner = i;
                }
            }
            return indexWiner+1;
        }

        public Kohonen(List<Bitmap> inputImage, int neededClasses)
        {
            xInput = new List<List<int>>();
            w = new List<List<double>>();
            wPrev = new List<List<double>>();
            Random rnd = new Random();
            for (int k = 0; k < neededClasses; k++)
            {
                List<double> temp = new List<double>();
                List<double> temp2 = new List<double>();
                for (int i = 0; i < inputImage[0].Width; i++)
                {
                    for (int j = 0; j < inputImage[0].Height; j++)
                    {
                        double t = rnd.NextDouble();
                        temp.Add(t);
                        temp2.Add(t); 
                    }
                }
                w.Add(temp);
                wPrev.Add(temp2);
            }
            foreach (Bitmap item in inputImage)
            {
                List<int> temp = new List<int>();
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
                            temp.Add(0);
                        }
                    }
                }
                xInput.Add(temp);
            }
        }
    }
}
