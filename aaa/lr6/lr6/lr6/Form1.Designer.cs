namespace lr6
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.num1 = new System.Windows.Forms.TextBox();
            this.den1 = new System.Windows.Forms.TextBox();
            this.num2 = new System.Windows.Forms.TextBox();
            this.den2 = new System.Windows.Forms.TextBox();
            this.btnSub = new System.Windows.Forms.Button();
            this.btnMul = new System.Windows.Forms.Button();
            this.btnDiv = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.den3 = new System.Windows.Forms.TextBox();
            this.num3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(53, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(20, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // num1
            // 
            this.num1.Location = new System.Drawing.Point(12, 12);
            this.num1.Multiline = true;
            this.num1.Name = "num1";
            this.num1.Size = new System.Drawing.Size(32, 27);
            this.num1.TabIndex = 3;
            this.num1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num1.TextChanged += new System.EventHandler(this.textBoxChanged);
            // 
            // den1
            // 
            this.den1.Location = new System.Drawing.Point(12, 45);
            this.den1.Multiline = true;
            this.den1.Name = "den1";
            this.den1.Size = new System.Drawing.Size(32, 27);
            this.den1.TabIndex = 4;
            this.den1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.den1.TextChanged += new System.EventHandler(this.textBoxChanged);
            // 
            // num2
            // 
            this.num2.Location = new System.Drawing.Point(105, 12);
            this.num2.Multiline = true;
            this.num2.Name = "num2";
            this.num2.Size = new System.Drawing.Size(32, 27);
            this.num2.TabIndex = 5;
            this.num2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num2.TextChanged += new System.EventHandler(this.textBoxChanged);
            // 
            // den2
            // 
            this.den2.Location = new System.Drawing.Point(105, 45);
            this.den2.Multiline = true;
            this.den2.Name = "den2";
            this.den2.Size = new System.Drawing.Size(32, 27);
            this.den2.TabIndex = 6;
            this.den2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.den2.TextChanged += new System.EventHandler(this.textBoxChanged);
            // 
            // btnSub
            // 
            this.btnSub.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSub.Location = new System.Drawing.Point(78, 16);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(20, 23);
            this.btnSub.TabIndex = 7;
            this.btnSub.Text = "-";
            this.btnSub.UseVisualStyleBackColor = true;
            this.btnSub.Click += new System.EventHandler(this.btnSub_Click);
            // 
            // btnMul
            // 
            this.btnMul.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMul.Location = new System.Drawing.Point(53, 45);
            this.btnMul.Name = "btnMul";
            this.btnMul.Size = new System.Drawing.Size(20, 23);
            this.btnMul.TabIndex = 8;
            this.btnMul.Text = "*";
            this.btnMul.UseVisualStyleBackColor = true;
            this.btnMul.Click += new System.EventHandler(this.btnMul_Click);
            // 
            // btnDiv
            // 
            this.btnDiv.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDiv.Location = new System.Drawing.Point(78, 45);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(20, 23);
            this.btnDiv.TabIndex = 9;
            this.btnDiv.Text = "/";
            this.btnDiv.UseVisualStyleBackColor = true;
            this.btnDiv.Click += new System.EventHandler(this.btnDiv_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "=";
            // 
            // den3
            // 
            this.den3.Location = new System.Drawing.Point(173, 45);
            this.den3.Multiline = true;
            this.den3.Name = "den3";
            this.den3.ReadOnly = true;
            this.den3.Size = new System.Drawing.Size(32, 27);
            this.den3.TabIndex = 13;
            this.den3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // num3
            // 
            this.num3.Location = new System.Drawing.Point(173, 12);
            this.num3.Multiline = true;
            this.num3.Name = "num3";
            this.num3.ReadOnly = true;
            this.num3.Size = new System.Drawing.Size(32, 27);
            this.num3.TabIndex = 12;
            this.num3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 78);
            this.Controls.Add(this.den3);
            this.Controls.Add(this.num3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDiv);
            this.Controls.Add(this.btnMul);
            this.Controls.Add(this.btnSub);
            this.Controls.Add(this.den2);
            this.Controls.Add(this.num2);
            this.Controls.Add(this.den1);
            this.Controls.Add(this.num1);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox num1;
        private System.Windows.Forms.TextBox den1;
        private System.Windows.Forms.TextBox num2;
        private System.Windows.Forms.TextBox den2;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.Button btnMul;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox den3;
        private System.Windows.Forms.TextBox num3;
    }
}

