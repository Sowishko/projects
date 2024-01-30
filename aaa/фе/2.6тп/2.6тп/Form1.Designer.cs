namespace _2._6тп
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
            this.CreateCh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReStr = new System.Windows.Forms.TextBox();
            this.ImStr = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StatusRe = new System.Windows.Forms.TextBox();
            this.StatusIm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ReInc = new System.Windows.Forms.TextBox();
            this.ImInc = new System.Windows.Forms.TextBox();
            this.IncI = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ReDec = new System.Windows.Forms.TextBox();
            this.ImDec = new System.Windows.Forms.TextBox();
            this.DecI = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ReYm = new System.Windows.Forms.TextBox();
            this.ImYm = new System.Windows.Forms.TextBox();
            this.Yi = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateCh
            // 
            this.CreateCh.Location = new System.Drawing.Point(195, 73);
            this.CreateCh.Name = "CreateCh";
            this.CreateCh.Size = new System.Drawing.Size(75, 23);
            this.CreateCh.TabIndex = 0;
            this.CreateCh.Text = "Ввод";
            this.CreateCh.UseVisualStyleBackColor = true;
            this.CreateCh.Click += new System.EventHandler(this.CreateCh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Мнимая часть числа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Действительная часть числа";
            // 
            // ReStr
            // 
            this.ReStr.Location = new System.Drawing.Point(170, 19);
            this.ReStr.Name = "ReStr";
            this.ReStr.Size = new System.Drawing.Size(100, 20);
            this.ReStr.TabIndex = 3;
            // 
            // ImStr
            // 
            this.ImStr.Location = new System.Drawing.Point(170, 47);
            this.ImStr.Name = "ImStr";
            this.ImStr.Size = new System.Drawing.Size(100, 20);
            this.ImStr.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReStr);
            this.groupBox1.Controls.Add(this.ImStr);
            this.groupBox1.Controls.Add(this.CreateCh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 104);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Создание числа";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StatusRe);
            this.groupBox2.Controls.Add(this.StatusIm);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(294, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 76);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Состояние числа";
            // 
            // StatusRe
            // 
            this.StatusRe.Location = new System.Drawing.Point(170, 19);
            this.StatusRe.Name = "StatusRe";
            this.StatusRe.Size = new System.Drawing.Size(100, 20);
            this.StatusRe.TabIndex = 3;
            // 
            // StatusIm
            // 
            this.StatusIm.Location = new System.Drawing.Point(170, 47);
            this.StatusIm.Name = "StatusIm";
            this.StatusIm.Size = new System.Drawing.Size(100, 20);
            this.StatusIm.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Мнимая часть числа";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Действительная часть числа";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ReInc);
            this.groupBox3.Controls.Add(this.ImInc);
            this.groupBox3.Controls.Add(this.IncI);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 104);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Сложение";
            // 
            // ReInc
            // 
            this.ReInc.Location = new System.Drawing.Point(170, 19);
            this.ReInc.Name = "ReInc";
            this.ReInc.Size = new System.Drawing.Size(100, 20);
            this.ReInc.TabIndex = 3;
            // 
            // ImInc
            // 
            this.ImInc.Location = new System.Drawing.Point(170, 47);
            this.ImInc.Name = "ImInc";
            this.ImInc.Size = new System.Drawing.Size(100, 20);
            this.ImInc.TabIndex = 4;
            // 
            // IncI
            // 
            this.IncI.Location = new System.Drawing.Point(195, 73);
            this.IncI.Name = "IncI";
            this.IncI.Size = new System.Drawing.Size(75, 23);
            this.IncI.TabIndex = 0;
            this.IncI.Text = "Ввод";
            this.IncI.UseVisualStyleBackColor = true;
            this.IncI.Click += new System.EventHandler(this.IncI_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Мнимая часть числа";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Действительная часть числа";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ReDec);
            this.groupBox4.Controls.Add(this.ImDec);
            this.groupBox4.Controls.Add(this.DecI);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(12, 232);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(276, 104);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Вычитание";
            // 
            // ReDec
            // 
            this.ReDec.Location = new System.Drawing.Point(170, 19);
            this.ReDec.Name = "ReDec";
            this.ReDec.Size = new System.Drawing.Size(100, 20);
            this.ReDec.TabIndex = 3;
            // 
            // ImDec
            // 
            this.ImDec.Location = new System.Drawing.Point(170, 47);
            this.ImDec.Name = "ImDec";
            this.ImDec.Size = new System.Drawing.Size(100, 20);
            this.ImDec.TabIndex = 4;
            // 
            // DecI
            // 
            this.DecI.Location = new System.Drawing.Point(195, 73);
            this.DecI.Name = "DecI";
            this.DecI.Size = new System.Drawing.Size(75, 23);
            this.DecI.TabIndex = 0;
            this.DecI.Text = "Ввод";
            this.DecI.UseVisualStyleBackColor = true;
            this.DecI.Click += new System.EventHandler(this.DecI_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Мнимая часть числа";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Действительная часть числа";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ReYm);
            this.groupBox5.Controls.Add(this.ImYm);
            this.groupBox5.Controls.Add(this.Yi);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(294, 232);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(276, 104);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Умножение";
            // 
            // ReYm
            // 
            this.ReYm.Location = new System.Drawing.Point(170, 19);
            this.ReYm.Name = "ReYm";
            this.ReYm.Size = new System.Drawing.Size(100, 20);
            this.ReYm.TabIndex = 3;
            // 
            // ImYm
            // 
            this.ImYm.Location = new System.Drawing.Point(170, 47);
            this.ImYm.Name = "ImYm";
            this.ImYm.Size = new System.Drawing.Size(100, 20);
            this.ImYm.TabIndex = 4;
            // 
            // Yi
            // 
            this.Yi.Location = new System.Drawing.Point(195, 73);
            this.Yi.Name = "Yi";
            this.Yi.Size = new System.Drawing.Size(75, 23);
            this.Yi.TabIndex = 0;
            this.Yi.Text = "Ввод";
            this.Yi.UseVisualStyleBackColor = true;
            this.Yi.Click += new System.EventHandler(this.Yi_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Мнимая часть числа";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Действительная часть числа";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 347);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateCh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ReStr;
        private System.Windows.Forms.TextBox ImStr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox StatusRe;
        private System.Windows.Forms.TextBox StatusIm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox ReInc;
        private System.Windows.Forms.TextBox ImInc;
        private System.Windows.Forms.Button IncI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox ReDec;
        private System.Windows.Forms.TextBox ImDec;
        private System.Windows.Forms.Button DecI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox ReYm;
        private System.Windows.Forms.TextBox ImYm;
        private System.Windows.Forms.Button Yi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

