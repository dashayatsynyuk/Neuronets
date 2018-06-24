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
        private List<List<double>> wSecondLayer;
        private List<double> secondLayerInput;
        private List<double> secondLayerOutput;
        private List<double> secondLayerErrorInput;
        private List<double> secondLayerErrorOutput;
        private List<List<double>> wThirdLayer;
        private List<double> thirdLayerInput;
        private List<double> thirdLayerErrorInput;
        private List<double> thirdLayerErrorOutput;
        private List<double> resultInput;
        private List<double> resultOutput;
        private List<double> rError;
        private int sLength;
        private int aLength;
        private List<double> M;
        private List<int> checkImage;
        private const double nu = 0.1;
        private int k = 0;
        private double tau = 1000;
        

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
            secondLayerInput = new List<double>();
            secondLayerOutput = new List<double>();
            for (int i = 0; i < aLength; i++)
            {
                double sum = 0;

                for (int j = 0; j < aLength; j++)
                {
                    sum += firstLayerOutput[j] * wSecondLayer[j][i];
                }
                secondLayerInput.Add(sum);
                sum = 1 / (1 + Math.Exp(-1 * sum));
                secondLayerOutput.Add(sum);
            }
        }

        private void GetThirdLayerOutput()
        {
            resultInput = new List<double>();
            resultOutput = new List<double>();
            for(int i=0; i<xInput.Count; i++)
            {
                double sum = 0;
                for(int j=0; j<aLength; j++)
                {
                    sum += secondLayerOutput[j] * wThirdLayer[j][i];
                }
                resultInput.Add(sum);
                sum = 1 / (1 + Math.Exp(-1 * sum));
                resultOutput.Add(sum);
            }
        }

        private void GetRError()
        {
            rError = new List<double>();
            for(int i=0; i<resultOutput.Count; i++)
            {
                rError.Add(M[i] * (1 - M[i]) * (M[i] - resultOutput[i]));
            }
        }

        private void GetThirdLayerErrorInput()
        {
            secondLayerErrorInput = new List<double>();
            for (int i = 0; i < wThirdLayer.Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < wThirdLayer[i].Count; j++)
                {
                    sum += rError[j] * wSecondLayer[i][j];
                }
                secondLayerErrorInput.Add(sum);
            }
        }

        private void GetThirdLayerErrorOutput()
        {
            secondLayerErrorOutput = new List<double>();
            for (int i = 0; i < secondLayerOutput.Count; i++)
            {
                secondLayerErrorOutput.Add(secondLayerOutput[i] * (1 - secondLayerOutput[i]) * secondLayerErrorInput[i]);
            }
        }

        private void GetSecondLayerErrorInput()
        {
            firstLayerErrorInput = new List<double>();
            for (int i = 0; i < wSecondLayer.Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < wSecondLayer[i].Count; j++)
                {
                    sum += secondLayerErrorOutput[j] * wSecondLayer[i][j];
                }
                firstLayerErrorInput.Add(sum);
            }
        }

        private void GetSecondLayerErrorOutput()
        {
            firstLayerErrorOutput = new List<double>();
            for(int i=0; i<firstLayerOutput.Count; i++)
            {
                firstLayerErrorOutput.Add(firstLayerOutput[i]*(1- firstLayerOutput[i])*firstLayerErrorInput[i]);
            }
        }

        private void CorrectThirdLayerWeight()
        {
            for (int i = 0; i < wThirdLayer.Count; i++)
            {
                for (int j = 0; j < wThirdLayer[i].Count; j++)
                {
                    wThirdLayer[i][j] = wThirdLayer[i][j] + nu * rError[j] * resultInput[j];
                }
            }
        }

        private void CorrectSecondLayerWeight()
        {
            for(int i=0; i<wSecondLayer.Count; i++)
            {
                for (int j = 0; j < wSecondLayer[i].Count; j++)
                {
                    wSecondLayer[i][j] = wSecondLayer[i][j] + nu * secondLayerErrorOutput[j] * secondLayerInput[j];
                }
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

        public List<double> ClassifyImage(Bitmap image)
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
            List<double> resultFirstList = new List<double>();
            for(int i=0; i<wFirstLayer[0].Count; i++)
            {
                double sum = 0;
                for(int j=0; j< wFirstLayer.Count; j++)
                {
                    sum += checkImage[j] * wFirstLayer[j][i];
                }
                resultFirstList.Add(sum);
            }
            for (int i = 0; i < resultFirstList.Count; i++)
            {
                resultFirstList[i] = 1 / (1 + Math.Exp(-1 * resultFirstList[i]));
            }
            List<double> resultSecondList = new List<double>();
            for (int i = 0; i < wSecondLayer[0].Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < wSecondLayer.Count; j++)
                {
                    sum += resultFirstList[j] * wSecondLayer[j][i];
                }
                resultSecondList.Add(sum);
            }
            for (int i = 0; i < resultSecondList.Count; i++)
            {
                resultSecondList[i] = 1 / (1 + Math.Exp(-1 * resultSecondList[i]));
            }
            List<double> result = new List<double>();
            for (int i = 0; i < wThirdLayer[0].Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < wThirdLayer.Count; j++)
                {
                    sum += resultSecondList[j] * wSecondLayer[j][i];
                }
                result.Add(sum);
            }
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = 1 / (1 + Math.Exp(-1 * resultSecondList[i]));
            }
            return result;
        }

        public void Learn()
        {
            for(int i=0;i<80; i++)
            {
                for(k=0;k<xInput.Count; k++)
                {
                    GetFirstLayerOutput();
                    GetSecondLayerOutput();
                    GetThirdLayerOutput();
                    GetRError();
                    GetThirdLayerErrorInput();
                    GetThirdLayerErrorOutput();
                    GetSecondLayerErrorInput();
                    GetSecondLayerErrorOutput();
                    CorrectFirstLayerWeight();
                    CorrectSecondLayerWeight();
                    CorrectThirdLayerWeight();
                }
            }
        }

        public Perceptron(List<Bitmap> inputImage)
        {
            M = new List<double>();
            xInput = new List<List<int>>();
            wFirstLayer = new List<List<double>>();
            wSecondLayer = new List<List<double>>();
            wThirdLayer = new List<List<double>>();
            M.Add(0);
            M.Add(0.25);
            M.Add(0.5);
            M.Add(0.75);
            M.Add(1);
            Random rnd = new Random();
            sLength = inputImage[0].Width * inputImage[0].Height;
            aLength = sLength / 2 + sLength / 100;
            for (int i = 0; i < aLength; i++)
            {
                List<double> temp = new List<double>();
                for (int j = 0; j < sLength; j++)
                {
                    temp.Add(rnd.NextDouble() * 1.0 - 0.5);
                }
                wFirstLayer.Add(temp);
            }
            for (int i = 0; i < aLength; i++)
            {
                List<double> temp = new List<double>();
                for (int j = 0; j < aLength; j++)
                {
                    temp.Add(rnd.NextDouble() * 1.0 - 0.5);
                }
                wSecondLayer.Add(temp);
            }
            for (int i = 0; i < aLength; i++)
            {
                List<double> temp = new List<double>();
                for (int j = 0; j < inputImage.Count; j++)
                {
                    temp.Add(rnd.NextDouble() * 1.0 - 0.5);
                }
                wThirdLayer.Add(temp);
            }
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
