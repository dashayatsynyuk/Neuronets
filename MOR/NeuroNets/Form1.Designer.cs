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
            this.fifth = new System.Windows.Forms.PictureBox();
            this.first = new System.Windows.Forms.PictureBox();
            this.fourth = new System.Windows.Forms.PictureBox();
            this.btnLearning = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.second = new System.Windows.Forms.PictureBox();
            this.resultClass = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.checkImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fifth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.first)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.second)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkImage)).BeginInit();
            this.SuspendLayout();
            // 
            // fifth
            // 
            this.fifth.Image = ((System.Drawing.Image)(resources.GetObject("fifth.Image")));
            this.fifth.Location = new System.Drawing.Point(349, 32);
            this.fifth.Margin = new System.Windows.Forms.Padding(2);
            this.fifth.Name = "fifth";
            this.fifth.Size = new System.Drawing.Size(50, 50);
            this.fifth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.fifth.TabIndex = 0;
            this.fifth.TabStop = false;
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
            // fourth
            // 
            this.fourth.Image = ((System.Drawing.Image)(resources.GetObject("fourth.Image")));
            this.fourth.Location = new System.Drawing.Point(256, 32);
            this.fourth.Margin = new System.Windows.Forms.Padding(2);
            this.fourth.Name = "fourth";
            this.fourth.Size = new System.Drawing.Size(50, 50);
            this.fourth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.fourth.TabIndex = 3;
            this.fourth.TabStop = false;
            // 
            // btnLearning
            // 
            this.btnLearning.Location = new System.Drawing.Point(236, 204);
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
            this.btnCheck.Location = new System.Drawing.Point(333, 204);
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
            this.resultClass.Location = new System.Drawing.Point(332, 170);
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
            this.button1.Location = new System.Drawing.Point(150, 169);
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
            this.checkImage.Location = new System.Drawing.Point(256, 139);
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
            this.ClientSize = new System.Drawing.Size(422, 252);
            this.Controls.Add(this.checkImage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultClass);
            this.Controls.Add(this.second);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnLearning);
            this.Controls.Add(this.fourth);
            this.Controls.Add(this.first);
            this.Controls.Add(this.fifth);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fifth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.first)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.second)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.PictureBox fifth;
        protected System.Windows.Forms.PictureBox first;
        protected System.Windows.Forms.PictureBox fourth;
        private System.Windows.Forms.Button btnLearning;
        private System.Windows.Forms.Button btnCheck;
        protected System.Windows.Forms.PictureBox second;
        private System.Windows.Forms.TextBox resultClass;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        protected System.Windows.Forms.PictureBox checkImage;
    }
}

