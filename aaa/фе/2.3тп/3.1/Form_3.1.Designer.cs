namespace _3._1
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
            this.ChooseFile1 = new System.Windows.Forms.Button();
            this.NalText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RezText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RezText2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ChooseFile2 = new System.Windows.Forms.Button();
            this.NalText2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RezText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ChooseFile1);
            this.groupBox1.Controls.Add(this.NalText);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 294);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Задание №1";
            // 
            // ChooseFile1
            // 
            this.ChooseFile1.Location = new System.Drawing.Point(220, 12);
            this.ChooseFile1.Name = "ChooseFile1";
            this.ChooseFile1.Size = new System.Drawing.Size(75, 23);
            this.ChooseFile1.TabIndex = 3;
            this.ChooseFile1.Text = "Файл";
            this.ChooseFile1.UseVisualStyleBackColor = true;
            this.ChooseFile1.Click += new System.EventHandler(this.ChooseFile1_Click);
            // 
            // NalText
            // 
            this.NalText.Location = new System.Drawing.Point(6, 41);
            this.NalText.Multiline = true;
            this.NalText.Name = "NalText";
            this.NalText.Size = new System.Drawing.Size(289, 110);
            this.NalText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Исходный текст";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Изменённый текст";
            // 
            // RezText
            // 
            this.RezText.Location = new System.Drawing.Point(6, 171);
            this.RezText.Multiline = true;
            this.RezText.Name = "RezText";
            this.RezText.Size = new System.Drawing.Size(289, 110);
            this.RezText.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.RezText2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ChooseFile2);
            this.groupBox2.Controls.Add(this.NalText2);
            this.groupBox2.Location = new System.Drawing.Point(319, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 294);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Задание №2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Изменённый текст";
            // 
            // RezText2
            // 
            this.RezText2.Location = new System.Drawing.Point(6, 171);
            this.RezText2.Multiline = true;
            this.RezText2.Name = "RezText2";
            this.RezText2.Size = new System.Drawing.Size(289, 110);
            this.RezText2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Исходный текст";
            // 
            // ChooseFile2
            // 
            this.ChooseFile2.Location = new System.Drawing.Point(220, 12);
            this.ChooseFile2.Name = "ChooseFile2";
            this.ChooseFile2.Size = new System.Drawing.Size(75, 23);
            this.ChooseFile2.TabIndex = 3;
            this.ChooseFile2.Text = "Файл";
            this.ChooseFile2.UseVisualStyleBackColor = true;
            this.ChooseFile2.Click += new System.EventHandler(this.ChooseFile2_Click);
            // 
            // NalText2
            // 
            this.NalText2.Location = new System.Drawing.Point(6, 41);
            this.NalText2.Multiline = true;
            this.NalText2.Name = "NalText2";
            this.NalText2.Size = new System.Drawing.Size(289, 110);
            this.NalText2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 314);
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
        private System.Windows.Forms.Button ChooseFile1;
        private System.Windows.Forms.TextBox NalText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RezText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RezText2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ChooseFile2;
        private System.Windows.Forms.TextBox NalText2;
    }
}

