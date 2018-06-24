using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroNets
{
    public class Neuron
    {
        private List<List<int>> xInput;
        private List<int> w;
        private List<int> M;
        private List<int> checkImage;
        private double porog;
        private const double tau=100;
        private bool binary = false;

        public void CorrectWeightBipolar()
        {
            for (int j = 0; j < M.Count; j++)
            {
                for (int i = 0; i < xInput[j].Count; i++)
                {
                    w[i] = w[i] + xInput[j][i] * M[j];
                }
            }
        }

        public void CorrectWeightBinary()
        {
            int deltaW = 0;
            for (int j = 0; j < M.Count; j++)
            {
                for (int i = 0; i < xInput[j].Count; i++)
                {
                    if (xInput[j][i] == 1 && M[j] == 1)
                    {
                        deltaW = 1;
                    }
                    else if (xInput[j][i] == 0)
                    {
                        deltaW = 0;
                    }
                    else if (xInput[j][i] != 0 && M[j] == 0)
                    {
                        deltaW = -1;
                    }
                    w[i] = w[i] + deltaW;
                }
            }
        }

        public bool CheckNeuron()
        {
            porog = 0;
            int result = 0;
            for (int j = 0; j < M.Count; j++)
            {
                for (int i = 1; i < xInput[j].Count; i++)
                {
                    result += xInput[j][i] * w[i];
                    result += w[0];
                }
                porog += result;
                if (result > 0)
                {
                    result = 1;
                }
                else if (result <= 0)
                {
                    if (binary)
                    {
                        result = 0;
                    }
                    else
                    {
                        result = -1;
                    }
                }
                if (result != M[j])
                {
                    return false;
                }
            }
            porog /= M.Count;
            return true;
        }

        public bool CheckNeuronSigma()
        {
            porog = 0;
            List<double> result = new List<double>();
            for (int j = 0; j < M.Count; j++)
            {
                result.Add(0);
                for (int i = 1; i < xInput[j].Count; i++)
                {
                    result[j] += xInput[j][i] * w[i];
                }
                result[j] += w[0];
            }
            for (int j = 0; j < M.Count; j++)
            {
                if (binary)
                {
                    result[j] = 1 / (1 + Math.Exp((-1) * tau * result[j]));
                }
                else
                {
                    result[j] = Math.Tanh(result[j] / tau);
                }
                porog += result[j];
            }
            porog /= M.Count;
            int k = 0;
            foreach (double item in result)
            {
                if (item != M[k])
                {
                    return false;
                }
                k++;
            }
            return true;
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
                        if (binary)
                        {
                            checkImage.Add(0);
                        }
                        else
                        {
                            checkImage.Add(-1);
                        }
                    }
                }
            }
            int result = w[0];
            for (int i = 1; i < checkImage.Count; i++)
            {
                result += checkImage[i] * w[i];
            }
            if (result > porog)
            {
                result = 1;
            }
            else if (result <= porog)
            {
                if (binary)
                {
                    result = 0;
                }
                else
                {
                    result = -1;
                }
            }
            return result;
        }

        public double ClassifyImageSigma(Bitmap image)
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
                        if (binary)
                        {
                            checkImage.Add(0);
                        }
                        else
                        {
                            checkImage.Add(-1);
                        }
                    }
                }
            }
            double result = w[0];
            for (int i = 1; i < checkImage.Count; i++)
            {
                result += checkImage[i] * w[i];
            }

            if (binary)
            {
                result = 1 / (1 + Math.Exp((-1) * tau * result));
            }
            else
            {
                result = Math.Tanh(result / tau);
            }
            return result;
        }

        public void LearnBinary()
        {
            CorrectWeightBinary();
            while (!CheckNeuronSigma())
            {
                CorrectWeightBinary();
            }
        }

        public void LearnBipolar()
        {
            CorrectWeightBipolar();
            while (!CheckNeuronSigma())
            {
                CorrectWeightBipolar();
            }
        }

        public Neuron(List<Bitmap> inputImage, int index)
        {
            xInput = new List<List<int>>();
            w = new List<int>();
            M = new List<int>();
            w.Add(0);
            for(int i=0; i<inputImage[0].Width; i++)
            {
                for(int j=0; j< inputImage[0].Height; j++)
                {
                    w.Add(0);
                }
            }
            for(int i=0; i<inputImage.Count; i++)
            {
                M.Add(-1);
            }
            M[index] = 1;
            foreach(Bitmap item in inputImage)
            {
                List<int> temp = new List<int>();
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
                            if (binary)
                            {
                                temp.Add(0);
                            }
                            else
                            {
                                temp.Add(-1);
                            }
                        }
                    }
                }
                xInput.Add(temp);
            }
        }
    }
}
