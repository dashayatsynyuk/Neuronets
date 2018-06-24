using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroNets
{
    public partial class Form1 : Form
    {
        private Hopfild neuron;

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
            images.Add(new Bitmap(firstLearn.Image));
            images.Add(new Bitmap(secondLearn.Image));
            images.Add(new Bitmap(thirdLearn.Image));
            images.Add(new Bitmap(fourthLearn.Image));
            images.Add(new Bitmap(fifthLearn.Image));
            neuron = new Hopfild(images, new Bitmap(checkImage.Image));
            outputImage.Image=neuron.Learn();
            outputImage.Image.Save("J:\\7 семестр\\Нейронные сети\\Нейросети_буквы\\Output.png", ImageFormat.Png);
        }

        private void button1_Click(object sender, EventArgs e)
        {            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                checkImage.Image = Image.FromFile(openFileDialog1.FileName);
                outputImage.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
