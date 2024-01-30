namespace _2._5тп
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NameT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SecondNameT = new System.Windows.Forms.TextBox();
            this.B1 = new System.Windows.Forms.Button();
            this.RezT = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TB = new System.Windows.Forms.TextBox();
            this.B2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Smax = new System.Windows.Forms.TextBox();
            this.Smin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RezT);
            this.groupBox1.Controls.Add(this.B1);
            this.groupBox1.Controls.Add(this.SecondNameT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NameT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 317);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Задание №1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя";
            // 
            // NameT
            // 
            this.NameT.Location = new System.Drawing.Point(68, 17);
            this.NameT.Name = "NameT";
            this.NameT.Size = new System.Drawing.Size(115, 20);
            this.NameT.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Фамилия";
            // 
            // SecondNameT
            // 
            this.SecondNameT.Location = new System.Drawing.Point(68, 46);
            this.SecondNameT.Name = "SecondNameT";
            this.SecondNameT.Size = new System.Drawing.Size(115, 20);
            this.SecondNameT.TabIndex = 3;
            // 
            // B1
            // 
            this.B1.Location = new System.Drawing.Point(107, 73);
            this.B1.Name = "B1";
            this.B1.Size = new System.Drawing.Size(75, 23);
            this.B1.TabIndex = 4;
            this.B1.Text = "Добавить";
            this.B1.UseVisualStyleBackColor = true;
            this.B1.Click += new System.EventHandler(this.B1_Click);
            // 
            // RezT
            // 
            this.RezT.Location = new System.Drawing.Point(6, 114);
            this.RezT.Multiline = true;
            this.RezT.Name = "RezT";
            this.RezT.ReadOnly = true;
            this.RezT.Size = new System.Drawing.Size(182, 197);
            this.RezT.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Smin);
            this.groupBox2.Controls.Add(this.Smax);
            this.groupBox2.Controls.Add(this.TB);
            this.groupBox2.Controls.Add(this.B2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(212, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 219);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Задание №2";
            // 
            // TB
            // 
            this.TB.Location = new System.Drawing.Point(6, 44);
            this.TB.Multiline = true;
            this.TB.Name = "TB";
            this.TB.ReadOnly = true;
            this.TB.Size = new System.Drawing.Size(182, 119);
            this.TB.TabIndex = 5;
            // 
            // B2
            // 
            this.B2.Location = new System.Drawing.Point(113, 15);
            this.B2.Name = "B2";
            this.B2.Size = new System.Drawing.Size(75, 23);
            this.B2.TabIndex = 4;
            this.B2.Text = "Файл";
            this.B2.UseVisualStyleBackColor = true;
            this.B2.Click += new System.EventHandler(this.B2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Короткое";
            // 
            // Smax
            // 
            this.Smax.Location = new System.Drawing.Point(68, 169);
            this.Smax.Multiline = true;
            this.Smax.Name = "Smax";
            this.Smax.ReadOnly = true;
            this.Smax.Size = new System.Drawing.Size(120, 18);
            this.Smax.TabIndex = 6;
            // 
            // Smin
            // 
            this.Smin.Location = new System.Drawing.Point(68, 193);
            this.Smin.Multiline = true;
            this.Smin.Name = "Smin";
            this.Smin.ReadOnly = true;
            this.Smin.Size = new System.Drawing.Size(120, 18);
            this.Smin.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Длинное";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 339);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button B1;
        private System.Windows.Forms.TextBox SecondNameT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RezT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Smin;
        private System.Windows.Forms.TextBox Smax;
        private System.Windows.Forms.TextBox TB;
        private System.Windows.Forms.Button B2;
        private System.Windows.Forms.Label label4;
    }
}

