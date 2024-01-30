namespace Расчетка
{
    partial class ListWagon
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btWg = new System.Windows.Forms.Button();
            this.lbWgType = new System.Windows.Forms.Label();
            this.lbWgPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbWgInfo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbWgMesta = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbWgNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btWg
            // 
            this.btWg.BackColor = System.Drawing.SystemColors.Highlight;
            this.btWg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btWg.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btWg.FlatAppearance.BorderSize = 3;
            this.btWg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btWg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btWg.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btWg.Location = new System.Drawing.Point(9, 120);
            this.btWg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btWg.Name = "btWg";
            this.btWg.Size = new System.Drawing.Size(260, 30);
            this.btWg.TabIndex = 27;
            this.btWg.Text = "Перейти к вводу данных";
            this.btWg.UseVisualStyleBackColor = false;
            // 
            // lbWgType
            // 
            this.lbWgType.AutoEllipsis = true;
            this.lbWgType.AutoSize = true;
            this.lbWgType.Font = new System.Drawing.Font("MT Extra", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbWgType.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbWgType.Location = new System.Drawing.Point(40, 9);
            this.lbWgType.Name = "lbWgType";
            this.lbWgType.Size = new System.Drawing.Size(94, 22);
            this.lbWgType.TabIndex = 30;
            this.lbWgType.Text = "Сидячий";
            // 
            // lbWgPrice
            // 
            this.lbWgPrice.AutoEllipsis = true;
            this.lbWgPrice.Font = new System.Drawing.Font("MT Extra", 13.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbWgPrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbWgPrice.Location = new System.Drawing.Point(190, 9);
            this.lbWgPrice.Name = "lbWgPrice";
            this.lbWgPrice.Size = new System.Drawing.Size(50, 21);
            this.lbWgPrice.TabIndex = 31;
            this.lbWgPrice.Text = "9000";
            this.lbWgPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MT Extra", 13.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(235, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 21);
            this.label3.TabIndex = 32;
            this.label3.Text = "RUB";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 52);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersWidth = 21;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(260, 61);
            this.dataGridView1.TabIndex = 33;
            // 
            // lbWgInfo
            // 
            this.lbWgInfo.AutoEllipsis = true;
            this.lbWgInfo.AutoSize = true;
            this.lbWgInfo.Font = new System.Drawing.Font("MT Extra", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbWgInfo.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbWgInfo.Location = new System.Drawing.Point(5, 33);
            this.lbWgInfo.Name = "lbWgInfo";
            this.lbWgInfo.Size = new System.Drawing.Size(286, 16);
            this.lbWgInfo.TabIndex = 34;
            this.lbWgInfo.Text = "Мужское/женское купе, провоз животных";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(110, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "-- мест";
            // 
            // lbWgMesta
            // 
            this.lbWgMesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbWgMesta.Location = new System.Drawing.Point(152, 12);
            this.lbWgMesta.Name = "lbWgMesta";
            this.lbWgMesta.Size = new System.Drawing.Size(25, 13);
            this.lbWgMesta.TabIndex = 36;
            this.lbWgMesta.Text = "100";
            this.lbWgMesta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(180, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "--";
            // 
            // lbWgNum
            // 
            this.lbWgNum.AutoEllipsis = true;
            this.lbWgNum.AutoSize = true;
            this.lbWgNum.Font = new System.Drawing.Font("MT Extra", 13.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbWgNum.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbWgNum.Location = new System.Drawing.Point(3, 10);
            this.lbWgNum.Name = "lbWgNum";
            this.lbWgNum.Size = new System.Drawing.Size(50, 21);
            this.lbWgNum.TabIndex = 38;
            this.lbWgNum.Text = "№10";
            // 
            // ListWagon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbWgNum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbWgMesta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbWgInfo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbWgPrice);
            this.Controls.Add(this.lbWgType);
            this.Controls.Add(this.btWg);
            this.Name = "ListWagon";
            this.Size = new System.Drawing.Size(280, 158);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btWg;
        private System.Windows.Forms.Label lbWgType;
        private System.Windows.Forms.Label lbWgPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbWgInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbWgMesta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbWgNum;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}
