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
        private int k = 0;

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
            neuron = new Perceptron(images);
           
                neuron.Learn();
            
            resultClass.Text = "Learnt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> result = new List<double>();
            result = neuron.ClassifyImage(new Bitmap(checkImage.Image));
            resultClass.Text = (k+1).ToString();
            k++;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                checkImage.Image = Image.FromFile(openFileDialog1.FileName);
        }
    }
}
