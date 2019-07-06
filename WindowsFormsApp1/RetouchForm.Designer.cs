namespace WindowsFormsApp1
{
   partial class RetouchForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summa ry>
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
            this.LoadImg_btn = new System.Windows.Forms.Button();
            this.BlackWhite_btn = new System.Windows.Forms.Button();
            this.LoadImg_box = new System.Windows.Forms.PictureBox();
            this.CannyMethod_btn = new System.Windows.Forms.Button();
            this.SobelMethod_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ConvertImg_box = new System.Windows.Forms.PictureBox();
            this.ClearLoadBox_btn = new System.Windows.Forms.Button();
            this.ClearConvBox_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LoadImg_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConvertImg_box)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadImg_btn
            // 
            this.LoadImg_btn.Location = new System.Drawing.Point(12, 12);
            this.LoadImg_btn.Name = "LoadImg_btn";
            this.LoadImg_btn.Size = new System.Drawing.Size(75, 23);
            this.LoadImg_btn.TabIndex = 0;
            this.LoadImg_btn.Text = "Load Image";
            this.LoadImg_btn.UseVisualStyleBackColor = true;
            this.LoadImg_btn.Click += new System.EventHandler(this.LoadImg_btn_Click);
            // 
            // BlackWhite_btn
            // 
            this.BlackWhite_btn.Location = new System.Drawing.Point(93, 12);
            this.BlackWhite_btn.Name = "BlackWhite_btn";
            this.BlackWhite_btn.Size = new System.Drawing.Size(75, 23);
            this.BlackWhite_btn.TabIndex = 2;
            this.BlackWhite_btn.Text = "B\\W";
            this.BlackWhite_btn.UseVisualStyleBackColor = true;
            this.BlackWhite_btn.Click += new System.EventHandler(this.BlackWhite_btn_Click);
            // 
            // LoadImg_box
            // 
            this.LoadImg_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoadImg_box.Location = new System.Drawing.Point(189, 49);
            this.LoadImg_box.Name = "LoadImg_box";
            this.LoadImg_box.Size = new System.Drawing.Size(330, 300);
            this.LoadImg_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadImg_box.TabIndex = 0;
            this.LoadImg_box.TabStop = false;
            // 
            // CannyMethod_btn
            // 
            this.CannyMethod_btn.Location = new System.Drawing.Point(28, 49);
            this.CannyMethod_btn.Name = "CannyMethod_btn";
            this.CannyMethod_btn.Size = new System.Drawing.Size(75, 23);
            this.CannyMethod_btn.TabIndex = 4;
            this.CannyMethod_btn.Text = "Canny";
            this.CannyMethod_btn.UseVisualStyleBackColor = true;
            this.CannyMethod_btn.Click += new System.EventHandler(this.CannyMethod_btn_Click);
            // 
            // SobelMethod_btn
            // 
            this.SobelMethod_btn.Location = new System.Drawing.Point(28, 78);
            this.SobelMethod_btn.Name = "SobelMethod_btn";
            this.SobelMethod_btn.Size = new System.Drawing.Size(75, 23);
            this.SobelMethod_btn.TabIndex = 5;
            this.SobelMethod_btn.Text = "Sobel";
            this.SobelMethod_btn.UseVisualStyleBackColor = true;
            this.SobelMethod_btn.Click += new System.EventHandler(this.SobelMethod_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "0";
            // 
            // ConvertImg_box
            // 
            this.ConvertImg_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConvertImg_box.Location = new System.Drawing.Point(525, 49);
            this.ConvertImg_box.Name = "ConvertImg_box";
            this.ConvertImg_box.Size = new System.Drawing.Size(330, 300);
            this.ConvertImg_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ConvertImg_box.TabIndex = 18;
            this.ConvertImg_box.TabStop = false;
            // 
            // ClearLoadBox_btn
            // 
            this.ClearLoadBox_btn.Location = new System.Drawing.Point(444, 20);
            this.ClearLoadBox_btn.Name = "ClearLoadBox_btn";
            this.ClearLoadBox_btn.Size = new System.Drawing.Size(75, 23);
            this.ClearLoadBox_btn.TabIndex = 19;
            this.ClearLoadBox_btn.Text = "Очистить";
            this.ClearLoadBox_btn.UseVisualStyleBackColor = true;
            this.ClearLoadBox_btn.Click += new System.EventHandler(this.ClearLoadBox_btn_Click);
            // 
            // ClearConvBox_btn
            // 
            this.ClearConvBox_btn.Location = new System.Drawing.Point(781, 20);
            this.ClearConvBox_btn.Name = "ClearConvBox_btn";
            this.ClearConvBox_btn.Size = new System.Drawing.Size(75, 23);
            this.ClearConvBox_btn.TabIndex = 20;
            this.ClearConvBox_btn.Text = "Очистить ";
            this.ClearConvBox_btn.UseVisualStyleBackColor = true;
            this.ClearConvBox_btn.Click += new System.EventHandler(this.ClearConvBox_btn_Click);
            // 
            // RetouchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(868, 741);
            this.Controls.Add(this.ClearConvBox_btn);
            this.Controls.Add(this.ClearLoadBox_btn);
            this.Controls.Add(this.ConvertImg_box);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SobelMethod_btn);
            this.Controls.Add(this.CannyMethod_btn);
            this.Controls.Add(this.LoadImg_box);
            this.Controls.Add(this.BlackWhite_btn);
            this.Controls.Add(this.LoadImg_btn);
            this.Name = "RetouchForm";
            this.Text = "Arboretum";
            ((System.ComponentModel.ISupportInitialize)(this.LoadImg_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConvertImg_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadImg_btn;
        private System.Windows.Forms.Button BlackWhite_btn;
        public System.Windows.Forms.PictureBox LoadImg_box;
        private System.Windows.Forms.Button CannyMethod_btn;
        private System.Windows.Forms.Button SobelMethod_btn;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.PictureBox ConvertImg_box;
        private System.Windows.Forms.Button ClearLoadBox_btn;
        private System.Windows.Forms.Button ClearConvBox_btn;
    }
}

