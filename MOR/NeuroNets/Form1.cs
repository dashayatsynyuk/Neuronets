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
        private Perceptron neuron;

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
            //images.Add(new Bitmap(third.Image));
            //images.Add(new Bitmap(fourth.Image));
            //images.Add(new Bitmap(fifth.Image));
            //images.Add(new Bitmap(sixth.Image));
            values.Add(1);
            values.Add(1);
            //values.Add(1);
            //values.Add(-1);
            //values.Add(-1);
            //values.Add(-1);
            neuron = new Perceptron(images, values);
           
                neuron.Learn();
            
            resultClass.Text = "Learnt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> result = new List<double>();
            result.Add(neuron.ClassifyImage(new Bitmap(first.Image)));
            result.Add(neuron.ClassifyImage(new Bitmap(second.Image)));
            result.Add(neuron.ClassifyImage(new Bitmap(fourth.Image)));
            result.Add(neuron.ClassifyImage(new Bitmap(fifth.Image)));
            double porog = 0;
            foreach (double item in result)
            {
                porog += item;
            }
            porog /= 4;
            resultClass.Text = neuron.ClassifyImage(new Bitmap(checkImage.Image)) >= porog ? "second" : "first";
            //resultClass.Text = neuron.ClassifyImage(new Bitmap(checkImage.Image)).ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                checkImage.Image = Image.FromFile(openFileDialog1.FileName);
        }
    }
}
