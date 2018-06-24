using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroNets
{
    public class Hemming
    {
        private List<List<int>> xInput;
        private List<List<double>> w;
        private List<int> M;
        private double sdvig;
        private const double k = 0.0001;
        private const double un = 1 / k;
        private List<int> checkImage;
        private double porog;
        private const double tau=100;
        private bool binary = false;
        private double epsilon = 0.2;
        private List<double> inputZ;
        private List<double> outputZ;
        private List<double> outputA;

        private void GetInputZ()
        {
            for(int i=0; i<w.Count; i++)
            {
                double sum = sdvig;
                for (int j=0; j<w[i].Count; j++)
                {
                    sum += checkImage[j] * w[i][j];
                }
                inputZ.Add(sum);
            }
        }

        private void GetOutputZ()
        {
            for (int i = 0; i <inputZ.Count; i++)
            {
                if(inputZ[i]<=0)
                {
                    outputZ.Add(0);
                }
                else if(inputZ[i]>0 && inputZ[i] <= un)
                {
                    outputZ.Add(k * inputZ[i]);
                }
                else if(inputZ[i] > un)
                {
                    outputZ.Add(un);
                }
            }
        }

        public int MaxNet()
        {
            GetInputZ();
            GetOutputZ();
            int count = 0;
            int index = 0;
            outputA = new List<double>();
            outputA.AddRange(outputZ);
            while (count < outputZ.Count - 1)
            {
                count = 0;
                for (int i = 0; i < outputZ.Count; i++)
                {
                    double ui = 0;
                    double sum = 0;
                    for (int j = 0; j < outputZ.Count; j++)
                    {
                        if (i != j)
                        {
                            sum += outputZ[j];
                        }
                        else
                        {
                            ui = outputZ[j];
                        }
                    }
                    double g = ui - epsilon * sum;
                    if (g > 0)
                    {
                        outputA[i]=g;
                        index = i;
                    }
                    else if (g <= 0)
                    {
                        outputA[i]=0;
                        count++;
                    }
                }
                outputZ=new List<double>();
                outputZ.AddRange(outputA);
            }
            return index;
        }

        public Hemming(List<Bitmap> inputImage, Bitmap image)
        {
            inputZ = new List<double>();
            outputZ = new List<double>();
            outputA = new List<double>();
            w = new List<List<double>>();
            M = new List<int>();
            sdvig = (inputImage[0].Width * inputImage[0].Height) / 2;
            foreach(Bitmap item in inputImage)
            {
                List<double> tempweight = new List<double>();
                for(int i=0; i<item.Width; i++)
                {
                    for(int j=0; j<item.Height; j++)
                    {
                        if (item.GetPixel(i, j).B == Color.Black.B && item.GetPixel(i, j).R == Color.Black.R && item.GetPixel(i, j).G == Color.Black.G)
                        {
                            double weight =(double) 1 / 2;
                            tempweight.Add(weight);
                        }
                        else
                        {
                            double weight = (double)(-1) / 2;
                            tempweight.Add(weight);
                        }
                    }
                }
                w.Add(tempweight);
            }
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
                        checkImage.Add(-1);
                    }
                }
            }
        }
    }
}
