using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroNets
{
    public class Perceptron
    {
        private List<List<int>> xInput;
        private List<List<double>> wFirstLayer;
        private List<double> firstLayerInput;
        private List<double> firstLayerOutput;
        private List<double> firstLayerErrorInput;
        private List<double> firstLayerErrorOutput;
        private List<double> wSecondLayer;
        private List<double> secondLayerInput;
        private List<double> secondLayerErrorInput;
        private List<double> secondLayerErrorOutput;
        private double resultInput;
        private double rError;
        private int sLength;
        private int aLength;
        private List<int> M;
        private List<int> checkImage;
        private const double nu = 0.1;
        private int k = 0;
        private double tau = 0.0000001;
        

        private void GetFirstLayerOutput()
        {
            firstLayerInput = new List<double>();
            firstLayerOutput = new List<double>();
            for (int i = 0; i < aLength; i++)
            {
                double sum = 0;
                for (int j = 0; j < sLength; j++)
                {
                    sum += xInput[k][j] * wFirstLayer[i][j];
                }
                firstLayerInput.Add(sum);
                sum = 1 / (1 + Math.Exp(-1 * sum));
                firstLayerOutput.Add(sum);
            }
        }

        private void GetSecondLayerOutput()
        {
            double sum = 0;
            for (int j = 0; j < firstLayerOutput.Count; j++)
            {
                sum += firstLayerOutput[j] * wSecondLayer[j];
            }
            sum = 1 / (1 + Math.Exp(-1 * sum));
            resultInput = sum;
        }

        private void GetRError()
        {
            rError = M[k] * (1 - M[k]) * (M[k] * resultInput);
        }

        private void GetSecondLayerErrorInput()
        {
            firstLayerErrorInput = new List<double>();
            for (int j = 0; j < wSecondLayer.Count; j++)
            {
                firstLayerErrorInput.Add(rError * wSecondLayer[j]);
            }
        }

        private void GetFirstLayerErrorOutput()
        {
            firstLayerErrorOutput = new List<double>();
            for(int i=0; i<firstLayerOutput.Count; i++)
            {
                firstLayerErrorOutput.Add(firstLayerOutput[i]*(1- firstLayerOutput[i])*firstLayerErrorInput[i]);
            }
        }

        private void CorrectSecondLayerWeight()
        {
            for(int i=0; i<wSecondLayer.Count; i++)
            {
                wSecondLayer[i] = wSecondLayer[i] + nu * rError * firstLayerOutput[i];
            }
        }

        private void CorrectFirstLayerWeight()
        {
            for(int i=0; i<wFirstLayer.Count; i++)
            {
                for(int j=0; j<wFirstLayer[i].Count; j++)
                {
                    wFirstLayer[i][j] = wFirstLayer[i][j] + nu * firstLayerErrorOutput[i] * xInput[k][j];
                }
            }
        }

        public double ClassifyImage(Bitmap image)
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
            List<double> resultList = new List<double>();
            for(int i=0; i<wFirstLayer.Count; i++)
            {
                double sum = 0;
                for(int j=0; j< wFirstLayer[i].Count; j++)
                {
                    sum += checkImage[j] * wFirstLayer[i][j];
                }
                resultList.Add(sum);
            }
            for (int i = 0; i < resultList.Count; i++)
            {
                resultList[i]=1 / (1 + Math.Exp(-1 * resultList[i]));
            }
            double result = 0;
            double sum1 = 0;
            for (int i = 0; i < resultList.Count; i++)
            {
                sum1 += resultList[i] * wSecondLayer[i];
            }
            result = 1 / (1 + Math.Exp(-1 * sum1*tau));

            return result;
        }

        public void Learn()
        {
            for(int i=0;i<100; i++)
            {
                for(k=0;k<xInput.Count; k++)
                {
                    GetFirstLayerOutput();
                    GetSecondLayerOutput();
                    GetRError();
                    GetSecondLayerErrorInput();
                    GetFirstLayerErrorOutput();
                    CorrectFirstLayerWeight();
                    CorrectSecondLayerWeight();
                }
            }
        }

        public Perceptron(List<Bitmap> inputImage, List<int> neededValue)
        {
            xInput = new List<List<int>>();
            wFirstLayer = new List<List<double>>();
            wSecondLayer = new List<double>();
            firstLayerInput = new List<double>();
            secondLayerInput = new List<double>();
            firstLayerOutput = new List<double>();
            //sign = new List<int>();
            M = new List<int>();
            Random rnd = new Random();
            sLength = inputImage[0].Width * inputImage[0].Height;
            aLength = sLength / 2 + sLength / 100;
            for (int i = 0; i < aLength; i++)
            {
                List<double> temp = new List<double>();
                //sign.Add(1);
                for (int j = 0; j < sLength; j++)
                {
                    temp.Add(rnd.NextDouble() * 1.0 - 0.5);
                }
                wFirstLayer.Add(temp);
            }            
            for (int k = 0; k < aLength; k++)
            {
                wSecondLayer.Add(rnd.NextDouble() * 1.0 - 0.5);
            }
            M.AddRange(neededValue);
            foreach(Bitmap item in inputImage)
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
