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
            this.first = new System.Windows.Forms.PictureBox();
            this.third = new System.Windows.Forms.PictureBox();
            this.btnLearning = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.second = new System.Windows.Forms.PictureBox();
            this.resultClass = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.checkImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.first)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.third)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.second)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkImage)).BeginInit();
            this.SuspendLayout();
            // 
            // first
            // 
            this.first.Image = ((System.Drawing.Image)(resources.GetObject("first.Image")));
            this.first.Location = new System.Drawing.Point(25, 32);
            this.first.Margin = new System.Windows.Forms.Padding(2);
            this.first.Name = "first";
            this.first.Size = new System.Drawing.Size(50, 50);
            this.first.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.first.TabIndex = 1;
            this.first.TabStop = false;
            // 
            // third
            // 
            this.third.Image = ((System.Drawing.Image)(resources.GetObject("third.Image")));
            this.third.Location = new System.Drawing.Point(256, 32);
            this.third.Margin = new System.Windows.Forms.Padding(2);
            this.third.Name = "third";
            this.third.Size = new System.Drawing.Size(50, 50);
            this.third.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.third.TabIndex = 3;
            this.third.TabStop = false;
            // 
            // btnLearning
            // 
            this.btnLearning.Location = new System.Drawing.Point(148, 177);
            this.btnLearning.Margin = new System.Windows.Forms.Padding(2);
            this.btnLearning.Name = "btnLearning";
            this.btnLearning.Size = new System.Drawing.Size(70, 21);
            this.btnLearning.TabIndex = 6;
            this.btnLearning.Text = "Обучить";
            this.btnLearning.UseVisualStyleBackColor = true;
            this.btnLearning.Click += new System.EventHandler(this.btnLearning_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(235, 177);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(70, 21);
            this.btnCheck.TabIndex = 8;
            this.btnCheck.Text = "Проверить";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.button1_Click);
            // 
            // second
            // 
            this.second.Image = ((System.Drawing.Image)(resources.GetObject("second.Image")));
            this.second.Location = new System.Drawing.Point(148, 32);
            this.second.Margin = new System.Windows.Forms.Padding(2);
            this.second.Name = "second";
            this.second.Size = new System.Drawing.Size(50, 50);
            this.second.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.second.TabIndex = 9;
            this.second.TabStop = false;
            // 
            // resultClass
            // 
            this.resultClass.Location = new System.Drawing.Point(235, 136);
            this.resultClass.Margin = new System.Windows.Forms.Padding(2);
            this.resultClass.Name = "resultClass";
            this.resultClass.Size = new System.Drawing.Size(71, 20);
            this.resultClass.TabIndex = 10;
            this.resultClass.Text = "undefined";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 136);
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
            this.checkImage.Location = new System.Drawing.Point(148, 106);
            this.checkImage.Margin = new System.Windows.Forms.Padding(2);
            this.checkImage.Name = "checkImage";
            this.checkImage.Size = new System.Drawing.Size(50, 50);
            this.checkImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.checkImage.TabIndex = 12;
            this.checkImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 237);
            this.Controls.Add(this.checkImage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultClass);
            this.Controls.Add(this.second);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnLearning);
            this.Controls.Add(this.third);
            this.Controls.Add(this.first);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.first)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.third)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.second)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.PictureBox first;
        protected System.Windows.Forms.PictureBox third;
        private System.Windows.Forms.Button btnLearning;
        private System.Windows.Forms.Button btnCheck;
        protected System.Windows.Forms.PictureBox second;
        private System.Windows.Forms.TextBox resultClass;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        protected System.Windows.Forms.PictureBox checkImage;
    }
}

