namespace WindowsFormsApp5
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
            this.ilPanel1 = new ILNumerics.Drawing.Panel();
            this.Info = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.epsBox = new System.Windows.Forms.TextBox();
            this.y2Box = new System.Windows.Forms.TextBox();
            this.x2Box = new System.Windows.Forms.TextBox();
            this.y1Box = new System.Windows.Forms.TextBox();
            this.x1Box = new System.Windows.Forms.TextBox();
            this.y0Box = new System.Windows.Forms.TextBox();
            this.x0Box = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ilPanel1
            // 
            this.ilPanel1.Editor = null;
            this.ilPanel1.Location = new System.Drawing.Point(8, 8);
            this.ilPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ilPanel1.Name = "ilPanel1";
            this.ilPanel1.Rectangle = ((System.Drawing.RectangleF)(resources.GetObject("ilPanel1.Rectangle")));
            this.ilPanel1.RendererType = ILNumerics.Drawing.RendererTypes.OpenGL;
            this.ilPanel1.ShowUIControls = false;
            this.ilPanel1.Size = new System.Drawing.Size(346, 431);
            this.ilPanel1.TabIndex = 1;
            this.ilPanel1.Timeout = ((uint)(0u));
            // 
            // Info
            // 
            this.Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Info.FormattingEnabled = true;
            this.Info.Location = new System.Drawing.Point(372, 268);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(178, 173);
            this.Info.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(413, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 29);
            this.button1.TabIndex = 24;
            this.button1.Text = "Вычислить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(387, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "eps";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(392, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "y2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(392, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "x2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "y1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "x1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "y0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "x0";
            // 
            // epsBox
            // 
            this.epsBox.Location = new System.Drawing.Point(413, 208);
            this.epsBox.Name = "epsBox";
            this.epsBox.Size = new System.Drawing.Size(121, 20);
            this.epsBox.TabIndex = 23;
            this.epsBox.Text = "0,001";
            // 
            // y2Box
            // 
            this.y2Box.Location = new System.Drawing.Point(413, 182);
            this.y2Box.Name = "y2Box";
            this.y2Box.Size = new System.Drawing.Size(121, 20);
            this.y2Box.TabIndex = 22;
            this.y2Box.Text = "3";
            // 
            // x2Box
            // 
            this.x2Box.Location = new System.Drawing.Point(413, 156);
            this.x2Box.Name = "x2Box";
            this.x2Box.Size = new System.Drawing.Size(121, 20);
            this.x2Box.TabIndex = 21;
            this.x2Box.Text = "0";
            // 
            // y1Box
            // 
            this.y1Box.Location = new System.Drawing.Point(413, 130);
            this.y1Box.Name = "y1Box";
            this.y1Box.Size = new System.Drawing.Size(121, 20);
            this.y1Box.TabIndex = 20;
            this.y1Box.Text = "2";
            // 
            // x1Box
            // 
            this.x1Box.Location = new System.Drawing.Point(413, 104);
            this.x1Box.Name = "x1Box";
            this.x1Box.Size = new System.Drawing.Size(121, 20);
            this.x1Box.TabIndex = 19;
            this.x1Box.Text = "2";
            // 
            // y0Box
            // 
            this.y0Box.Location = new System.Drawing.Point(413, 78);
            this.y0Box.Name = "y0Box";
            this.y0Box.Size = new System.Drawing.Size(121, 20);
            this.y0Box.TabIndex = 11;
            this.y0Box.Text = "2";
            // 
            // x0Box
            // 
            this.x0Box.Location = new System.Drawing.Point(413, 52);
            this.x0Box.Name = "x0Box";
            this.x0Box.Size = new System.Drawing.Size(121, 20);
            this.x0Box.TabIndex = 10;
            this.x0Box.Text = "-2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(391, 23);
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
            this.ClientSize = new System.Drawing.Size(574, 450);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.epsBox);
            this.Controls.Add(this.y2Box);
            this.Controls.Add(this.x2Box);
            this.Controls.Add(this.y1Box);
            this.Controls.Add(this.x1Box);
            this.Controls.Add(this.y0Box);
            this.Controls.Add(this.x0Box);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ilPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ILNumerics.Drawing.Panel ilPanel1;
        private System.Windows.Forms.ListBox Info;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox epsBox;
        private System.Windows.Forms.TextBox y2Box;
        private System.Windows.Forms.TextBox x2Box;
        private System.Windows.Forms.TextBox y1Box;
        private System.Windows.Forms.TextBox x1Box;
        private System.Windows.Forms.TextBox y0Box;
        private System.Windows.Forms.TextBox x0Box;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

