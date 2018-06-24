using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroNets
{
    public partial class Form1 : Form
    {
        private List<Neuron> neuronList;

        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            Close();
        }

        private void btnLearning_Click(object sender, EventArgs e)
        {
            List<Bitmap> images = new List<Bitmap>();
            List<int> values = new List<int>();
            images.Add(new Bitmap(first.Image));
            images.Add(new Bitmap(second.Image));
            images.Add(new Bitmap(third.Image));
            images.Add(new Bitmap(fourth.Image));
            images.Add(new Bitmap(fifth.Image));
            neuronList = new List<Neuron>();
            Neuron neuron = new Neuron(images, 0);
            neuronList.Add(neuron);
            neuron = new Neuron(images, 1);
            neuronList.Add(neuron);
            neuron = new Neuron(images, 2);
            neuronList.Add(neuron);
            neuron = new Neuron(images, 3);
            neuronList.Add(neuron);
            neuron = new Neuron(images, 4);
            neuronList.Add(neuron);
            foreach (Neuron item in neuronList)
            {
                item.LearnBipolar();
            }
            //neuron.LearnBinary();
            resultClass.Text = "Learnt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = 1;
            foreach (Neuron neuron in neuronList)
            {
                double result = neuron.ClassifyImageSigma(new Bitmap(checkImage.Image));
                if (result == 1)
                {
                    resultClass.Text = k.ToString();
                }
                k++;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                checkImage.Image = Image.FromFile(openFileDialog1.FileName);
        }
    }
}
