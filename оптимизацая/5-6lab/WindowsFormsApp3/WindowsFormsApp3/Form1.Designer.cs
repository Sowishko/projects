namespace WindowsFormsApp3
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
            this.panel1 = new ILNumerics.Drawing.Panel();
            this.Info = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.epsBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.alphaBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deltaBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.y0Box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.x0Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Editor = null;
            this.panel1.Location = new System.Drawing.Point(11, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Rectangle = ((System.Drawing.RectangleF)(resources.GetObject("panel1.Rectangle")));
            this.panel1.RendererType = ILNumerics.Drawing.RendererTypes.OpenGL;
            this.panel1.ShowUIControls = false;
            this.panel1.Size = new System.Drawing.Size(359, 391);
            this.panel1.TabIndex = 0;
            this.panel1.Timeout = ((uint)(0u));
            // 
            // Info
            // 
            this.Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Info.FormattingEnabled = true;
            this.Info.Location = new System.Drawing.Point(419, 201);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(149, 199);
            this.Info.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(463, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Вычислить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // epsBox
            // 
            this.epsBox.Location = new System.Drawing.Point(452, 146);
            this.epsBox.Name = "epsBox";
            this.epsBox.Size = new System.Drawing.Size(100, 20);
            this.epsBox.TabIndex = 18;
            this.epsBox.Text = "0,001";
            this.epsBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eps_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "eps";
            // 
            // alphaBox
            // 
            this.alphaBox.Location = new System.Drawing.Point(452, 120);
            this.alphaBox.Name = "alphaBox";
            this.alphaBox.Size = new System.Drawing.Size(100, 20);
            this.alphaBox.TabIndex = 17;
            this.alphaBox.Text = "10";
            this.alphaBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eps_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "alpha";
            // 
            // deltaBox
            // 
            this.deltaBox.Location = new System.Drawing.Point(452, 94);
            this.deltaBox.Name = "deltaBox";
            this.deltaBox.Size = new System.Drawing.Size(100, 20);
            this.deltaBox.TabIndex = 16;
            this.deltaBox.Text = "2";
            this.deltaBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eps_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "delta";
            // 
            // y0Box
            // 
            this.y0Box.Location = new System.Drawing.Point(452, 68);
            this.y0Box.Name = "y0Box";
            this.y0Box.Size = new System.Drawing.Size(100, 20);
            this.y0Box.TabIndex = 13;
            this.y0Box.Text = "0";
            this.y0Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eps_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "y0";
            // 
            // x0Box
            // 
            this.x0Box.Location = new System.Drawing.Point(452, 42);
            this.x0Box.Name = "x0Box";
            this.x0Box.Size = new System.Drawing.Size(100, 20);
            this.x0Box.TabIndex = 8;
            this.x0Box.Text = "0";
            this.x0Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eps_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "x0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp3.Properties.Resources._3;
            this.pictureBox1.Location = new System.Drawing.Point(425, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 425);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.epsBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.alphaBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.deltaBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.y0Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.x0Box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eps_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ILNumerics.Drawing.Panel panel1;
        private System.Windows.Forms.ListBox Info;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox epsBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox alphaBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox deltaBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox y0Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox x0Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

