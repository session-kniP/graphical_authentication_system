namespace ESignature
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pic_esign = new System.Windows.Forms.PictureBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btn_tyk = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_esign)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_esign
            // 
            this.pic_esign.BackColor = System.Drawing.Color.White;
            this.pic_esign.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pic_esign.Location = new System.Drawing.Point(178, 12);
            this.pic_esign.Name = "pic_esign";
            this.pic_esign.Size = new System.Drawing.Size(273, 233);
            this.pic_esign.TabIndex = 3;
            this.pic_esign.TabStop = false;
            this.pic_esign.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_esign_MouseDown);
            this.pic_esign.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_esign_MouseMove);
            this.pic_esign.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_esign_MouseUp);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(13, 13);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(149, 20);
            this.txt_name.TabIndex = 4;
            // 
            // btn_tyk
            // 
            this.btn_tyk.Location = new System.Drawing.Point(87, 98);
            this.btn_tyk.Name = "btn_tyk";
            this.btn_tyk.Size = new System.Drawing.Size(75, 23);
            this.btn_tyk.TabIndex = 5;
            this.btn_tyk.Text = "Тык";
            this.btn_tyk.UseVisualStyleBackColor = true;
            this.btn_tyk.Click += new System.EventHandler(this.btn_tyk_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(87, 219);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 6;
            this.btn_clear.Text = "ЦЛЕАР";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 254);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_tyk);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.pic_esign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Регистрация";
            ((System.ComponentModel.ISupportInitialize)(this.pic_esign)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_esign;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btn_tyk;
        private System.Windows.Forms.Button btn_clear;
    }
}