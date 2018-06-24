namespace NeuroNets
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLearning = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.checkImage = new System.Windows.Forms.PictureBox();
            this.outputImage = new System.Windows.Forms.PictureBox();
            this.firstLearn = new System.Windows.Forms.PictureBox();
            this.secondLearn = new System.Windows.Forms.PictureBox();
            this.thirdLearn = new System.Windows.Forms.PictureBox();
            this.fourthLearn = new System.Windows.Forms.PictureBox();
            this.fifthLearn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.checkImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstLearn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondLearn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdLearn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourthLearn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fifthLearn)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLearning
            // 
            this.btnLearning.Location = new System.Drawing.Point(187, 21);
            this.btnLearning.Margin = new System.Windows.Forms.Padding(2);
            this.btnLearning.Name = "btnLearning";
            this.btnLearning.Size = new System.Drawing.Size(70, 21);
            this.btnLearning.TabIndex = 6;
            this.btnLearning.Text = "Обучить";
            this.btnLearning.UseVisualStyleBackColor = true;
            this.btnLearning.Click += new System.EventHandler(this.btnLearning_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 20);
            this.button1.TabIndex = 11;
            this.button1.Text = "Выбрать файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // checkImage
            // 
            this.checkImage.Image = ((System.Drawing.Image)(resources.GetObject("checkImage.Image")));
            this.checkImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("checkImage.InitialImage")));
            this.checkImage.Location = new System.Drawing.Point(121, 22);
            this.checkImage.Margin = new System.Windows.Forms.Padding(2);
            this.checkImage.Name = "checkImage";
            this.checkImage.Size = new System.Drawing.Size(10, 10);
            this.checkImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.checkImage.TabIndex = 12;
            this.checkImage.TabStop = false;
            // 
            // outputImage
            // 
            this.outputImage.Image = ((System.Drawing.Image)(resources.GetObject("outputImage.Image")));
            this.outputImage.Location = new System.Drawing.Point(292, 22);
            this.outputImage.Margin = new System.Windows.Forms.Padding(2);
            this.outputImage.Name = "outputImage";
            this.outputImage.Size = new System.Drawing.Size(50, 50);
            this.outputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.outputImage.TabIndex = 13;
            this.outputImage.TabStop = false;
            // 
            // firstLearn
            // 
            this.firstLearn.Image = ((System.Drawing.Image)(resources.GetObject("firstLearn.Image")));
            this.firstLearn.Location = new System.Drawing.Point(11, 124);
            this.firstLearn.Margin = new System.Windows.Forms.Padding(2);
            this.firstLearn.Name = "firstLearn";
            this.firstLearn.Size = new System.Drawing.Size(10, 10);
            this.firstLearn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.firstLearn.TabIndex = 15;
            this.firstLearn.TabStop = false;
            // 
            // secondLearn
            // 
            this.secondLearn.Image = ((System.Drawing.Image)(resources.GetObject("secondLearn.Image")));
            this.secondLearn.Location = new System.Drawing.Point(81, 124);
            this.secondLearn.Margin = new System.Windows.Forms.Padding(2);
            this.secondLearn.Name = "secondLearn";
            this.secondLearn.Size = new System.Drawing.Size(10, 10);
            this.secondLearn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.secondLearn.TabIndex = 16;
            this.secondLearn.TabStop = false;
            // 
            // thirdLearn
            // 
            this.thirdLearn.Image = ((System.Drawing.Image)(resources.GetObject("thirdLearn.Image")));
            this.thirdLearn.Location = new System.Drawing.Point(151, 124);
            this.thirdLearn.Margin = new System.Windows.Forms.Padding(2);
            this.thirdLearn.Name = "thirdLearn";
            this.thirdLearn.Size = new System.Drawing.Size(10, 10);
            this.thirdLearn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.thirdLearn.TabIndex = 17;
            this.thirdLearn.TabStop = false;
            // 
            // fourthLearn
            // 
            this.fourthLearn.Image = ((System.Drawing.Image)(resources.GetObject("fourthLearn.Image")));
            this.fourthLearn.Location = new System.Drawing.Point(221, 124);
            this.fourthLearn.Margin = new System.Windows.Forms.Padding(2);
            this.fourthLearn.Name = "fourthLearn";
            this.fourthLearn.Size = new System.Drawing.Size(10, 10);
            this.fourthLearn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.fourthLearn.TabIndex = 18;
            this.fourthLearn.TabStop = false;
            // 
            // fifthLearn
            // 
            this.fifthLearn.Image = ((System.Drawing.Image)(resources.GetObject("fifthLearn.Image")));
            this.fifthLearn.Location = new System.Drawing.Point(292, 124);
            this.fifthLearn.Margin = new System.Windows.Forms.Padding(2);
            this.fifthLearn.Name = "fifthLearn";
            this.fifthLearn.Size = new System.Drawing.Size(10, 10);
            this.fifthLearn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.fifthLearn.TabIndex = 19;
            this.fifthLearn.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 196);
            this.Controls.Add(this.fifthLearn);
            this.Controls.Add(this.fourthLearn);
            this.Controls.Add(this.thirdLearn);
            this.Controls.Add(this.secondLearn);
            this.Controls.Add(this.firstLearn);
            this.Controls.Add(this.outputImage);
            this.Controls.Add(this.checkImage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLearning);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.checkImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstLearn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondLearn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdLearn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourthLearn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fifthLearn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLearning;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        protected System.Windows.Forms.PictureBox checkImage;
        protected System.Windows.Forms.PictureBox outputImage;
        protected System.Windows.Forms.PictureBox firstLearn;
        protected System.Windows.Forms.PictureBox secondLearn;
        protected System.Windows.Forms.PictureBox thirdLearn;
        protected System.Windows.Forms.PictureBox fourthLearn;
        protected System.Windows.Forms.PictureBox fifthLearn;
    }
}

