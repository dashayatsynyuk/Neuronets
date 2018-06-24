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
        private List<List<double>> firstLayerInput;
        private List<double> wSecondLayer;
        private List<double> secondLayerInput;
        private int sLength;
        private int aLength;
        private List<int> M;
        private List<int> checkImage;
        private double porog;
        private double porog2;
        private const double tau=100;
        private List<List<double>> activeNeurons;
        private double min = double.MaxValue;
        private double max = double.MinValue;
        private List<int> sign;
        private const double delta = 0.1;

        private bool GetFirstLayerInput()
        {
            activeNeurons = new List<List<double>>();
            for (int k = 0; k < xInput.Count; k++)
            {
                List<double> temp = new List<double>();
                List<double> init = new List<double>();
                for (int i=0; i<aLength; i++)
                {
                    double sum = 0;
                    for(int j=0;j<sLength; j++)
                    {
                        sum += xInput[k][j] * wFirstLayer[i][j];
                    }
                    if(sum<min)
                    {
                        min = sum;
                    }
                    if(sum>max)
                    {
                        max = sum;
                    }
                    temp.Add(sum);
                    init.Add(0);
                }
                firstLayerInput.Add(temp);
                activeNeurons.Add(init);
            }
            
            porog = (min+max)/2;
            //bool found = false;
            //for(porog=min; porog<=max; porog+=0.1)
            //{
            //    bool cross = false;
                for (int i=0; i<firstLayerInput.Count; i++)
                {
                    for(int j=0; j<firstLayerInput[i].Count; j++)
                    {
                        if(firstLayerInput[i][j]>=porog)
                        {
                            activeNeurons[i][j] = 1;
                        }
                        else
                        {
                            activeNeurons[i][j] = 0;
                        }
                    }
                }

            //    double half = activeNeurons.Count / 2;
            //    int count = 0;

            //    for (int i=0;i<activeNeurons[0].Count; i++)
            //    {
            //        double sumFirst = 0;
            //        double sumSecond = 0;
            //        for(int j=0; j<activeNeurons.Count;j++)
            //        {
            //            if(j<half)
            //            {
            //                sumFirst += activeNeurons[j][i];
            //            }
            //            else
            //            {
            //                sumSecond += activeNeurons[j][i];
            //            }
            //        }
            //        if((sumFirst!=half && sumSecond!=0) || (sumSecond != half && sumFirst != 0))
            //        {
            //            cross = true;
            //            break;
            //        }
            //        if(cross)
            //        {
            //            break;
            //        }
            //        count++;
            //    }
            //    if(count==activeNeurons[0].Count && cross)
            //    {
            //        found = true;
            //        break;
            //    }

            //}
            //if(!found)
            //{
            //    return false;
            //}
            return true;
        }

        private bool GetSecondLayerInput()
        {
            bool result = true;
            List<double> resultInput = new List<double>(); 
            for (int i = 0; i < activeNeurons.Count; i++)
            {
                double sum = 0;
                for(int j=0; j< activeNeurons[i].Count; j++)
                {
                    sum += activeNeurons[i][j] * wSecondLayer[j];
                }
                resultInput.Add(sum);
            }
            double sumRes = 0;
            for (int i = 0; i < resultInput.Count; i++)
            {
                sumRes += resultInput[i];
            }
            porog2 = sumRes / activeNeurons.Count;
            for (int i = 0; i < resultInput.Count; i++)
            {
                if(resultInput[i]>=porog2)
                {
                    resultInput[i] = 1;
                }
                else
                {
                    resultInput[i] = -1;
                }
                sign[i]= (M[i] - resultInput[i]) > 0 ? 1 : -1;
                if (resultInput[i]!=M[i])
                {
                    result=false;
                }
            }
            return result;
        }

        private void CorrectWeightGamma()
        {
            List<int> nActive = new List<int>();
            for (int i = 0; i < activeNeurons.Count; i++)
            {
                int n = 0;
                for (int j = 0; j < activeNeurons[i].Count; j++)
                {
                    if(activeNeurons[i][j]==1)
                    {
                        n++;
                    }
                }
                nActive.Add(n);
            }
            for(int i=0; i<activeNeurons.Count; i++)
            {
                for(int j=0; j<wSecondLayer.Count; j++)
                {
                    if (activeNeurons[i][j] == 1)
                    {
                        wSecondLayer[j] += sign[i]*(delta - nActive[i] * delta / activeNeurons.Count);
                    }
                    else
                    {
                        wSecondLayer[j] +=sign[i]*( nActive[i] * delta / activeNeurons.Count)*(-1);
                    }
                }
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
            for(int i=0; i<resultList.Count; i++)
            {
                if(resultList[i]>=porog)
                {
                    resultList[i] = 1;
                }
                else
                {
                    resultList[i] = 0;
                }
            }
            int result = 0;
            double sum1 = 0;
            for(int i=0; i<resultList.Count; i++)
            {
                sum1 += resultList[i] * wSecondLayer[i];
            }
            if(sum1>=porog2)
            {
                result = 1;
            }
            else
            {
                result = -1;
            }
            return result;
        }

        public void Learn()
        {
            if (GetFirstLayerInput())
            {
                while (!GetSecondLayerInput())
                {
                    CorrectWeightGamma();
                }
            }
        }

        public Perceptron(List<Bitmap> inputImage, List<int> neededValue)
        {
            xInput = new List<List<int>>();
            wFirstLayer = new List<List<double>>();
            wSecondLayer = new List<double>();
            firstLayerInput = new List<List<double>>();
            secondLayerInput = new List<double>();
            sign = new List<int>();
            M = new List<int>();
            Random rnd = new Random();
            sLength = inputImage[0].Width * inputImage[0].Height;
            aLength = sLength / 2 + sLength / 100;
            for (int i = 0; i < aLength; i++)
            {
                List<double> temp = new List<double>();
                sign.Add(1);
                for (int j = 0; j < sLength; j++)
                {
                    temp.Add(rnd.NextDouble());
                }
                wFirstLayer.Add(temp);
            }            
            for (int k = 0; k < aLength; k++)
            {
                wSecondLayer.Add(rnd.NextDouble());
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
