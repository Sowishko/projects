namespace _2._7тп
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Wst = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.IzgMet = new System.Windows.Forms.Button();
            this.ObrMet = new System.Windows.Forms.Button();
            this.KoLW = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BeginPr = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.KoLW);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BeginPr);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(799, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Предприятие";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Wst);
            this.groupBox3.Location = new System.Drawing.Point(573, 23);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(218, 50);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Неиспользованных деталей";
            // 
            // Wst
            // 
            this.Wst.Location = new System.Drawing.Point(9, 18);
            this.Wst.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Wst.Name = "Wst";
            this.Wst.ReadOnly = true;
            this.Wst.Size = new System.Drawing.Size(169, 22);
            this.Wst.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(455, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.IzgMet);
            this.groupBox2.Controls.Add(this.ObrMet);
            this.groupBox2.Location = new System.Drawing.Point(8, 58);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(439, 69);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Работа";
            // 
            // IzgMet
            // 
            this.IzgMet.Location = new System.Drawing.Point(179, 23);
            this.IzgMet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IzgMet.Name = "IzgMet";
            this.IzgMet.Size = new System.Drawing.Size(240, 28);
            this.IzgMet.TabIndex = 1;
            this.IzgMet.Text = "Изготовить механизм";
            this.IzgMet.UseVisualStyleBackColor = true;
            this.IzgMet.Click += new System.EventHandler(this.IzgMet_Click);
            // 
            // ObrMet
            // 
            this.ObrMet.Location = new System.Drawing.Point(8, 23);
            this.ObrMet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObrMet.Name = "ObrMet";
            this.ObrMet.Size = new System.Drawing.Size(163, 28);
            this.ObrMet.TabIndex = 0;
            this.ObrMet.Text = "Изготовить узел";
            this.ObrMet.UseVisualStyleBackColor = true;
            this.ObrMet.Click += new System.EventHandler(this.ObrMet_Click);
            // 
            // KoLW
            // 
            this.KoLW.Location = new System.Drawing.Point(205, 26);
            this.KoLW.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KoLW.Name = "KoLW";
            this.KoLW.Size = new System.Drawing.Size(132, 22);
            this.KoLW.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Сколько изготовим деталей?";
            // 
            // BeginPr
            // 
            this.BeginPr.Location = new System.Drawing.Point(347, 23);
            this.BeginPr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BeginPr.Name = "BeginPr";
            this.BeginPr.Size = new System.Drawing.Size(100, 28);
            this.BeginPr.TabIndex = 0;
            this.BeginPr.Text = "Изготовить";
            this.BeginPr.UseVisualStyleBackColor = true;
            this.BeginPr.Click += new System.EventHandler(this.BeginPr_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 170);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox KoLW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BeginPr;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button IzgMet;
        private System.Windows.Forms.Button ObrMet;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Wst;
    }
}

