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
        Adalyn adalyn;

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
            adalyn = new Adalyn(images);
            adalyn.Learn();
            resultClass.Text = "Learnt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double result = adalyn.ClassifyImage(new Bitmap(checkImage.Image));
            resultClass.Text = result.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                checkImage.Image = Image.FromFile(openFileDialog1.FileName);
        }
    }
}
