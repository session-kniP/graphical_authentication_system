namespace ESignature
{
    partial class ESignature
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
            this.btn_clear = new System.Windows.Forms.Button();
            this.pic_esign = new System.Windows.Forms.PictureBox();
            this.btn_cmp = new System.Windows.Forms.Button();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.btn_reg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_esign)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(87, 197);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 48);
            this.btn_clear.TabIndex = 1;
            this.btn_clear.Text = "Цлеар";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // pic_esign
            // 
            this.pic_esign.BackColor = System.Drawing.Color.White;
            this.pic_esign.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pic_esign.Location = new System.Drawing.Point(168, 12);
            this.pic_esign.Name = "pic_esign";
            this.pic_esign.Size = new System.Drawing.Size(273, 233);
            this.pic_esign.TabIndex = 2;
            this.pic_esign.TabStop = false;
            this.pic_esign.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pic_esign.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pic_esign.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // btn_cmp
            // 
            this.btn_cmp.Location = new System.Drawing.Point(9, 38);
            this.btn_cmp.Name = "btn_cmp";
            this.btn_cmp.Size = new System.Drawing.Size(153, 50);
            this.btn_cmp.TabIndex = 3;
            this.btn_cmp.Text = "Авторизоваться";
            this.btn_cmp.UseVisualStyleBackColor = true;
            this.btn_cmp.Click += new System.EventHandler(this.btn_cmp_Click);
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(9, 12);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(153, 20);
            this.tb_name.TabIndex = 4;
            // 
            // btn_reg
            // 
            this.btn_reg.Location = new System.Drawing.Point(9, 144);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.Size = new System.Drawing.Size(153, 47);
            this.btn_reg.TabIndex = 5;
            this.btn_reg.Text = "Замутить нового";
            this.btn_reg.UseVisualStyleBackColor = true;
            this.btn_reg.Click += new System.EventHandler(this.btn_reg_Click);
            // 
            // ESignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(452, 260);
            this.Controls.Add(this.btn_reg);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.btn_cmp);
            this.Controls.Add(this.pic_esign);
            this.Controls.Add(this.btn_clear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ESignature";
            this.Text = "Какая-то мутная фигня";
            ((System.ComponentModel.ISupportInitialize)(this.pic_esign)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.PictureBox pic_esign;
        private System.Windows.Forms.Button btn_cmp;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Button btn_reg;
    }
}

