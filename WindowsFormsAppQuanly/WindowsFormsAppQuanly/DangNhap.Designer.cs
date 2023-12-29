namespace WindowsFormsAppQuanly
{
    partial class DangNhap
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
            this.components = new System.ComponentModel.Container();
            this.textBox_TenTaiKhoan = new System.Windows.Forms.TextBox();
            this.textBox_MatKhau = new System.Windows.Forms.TextBox();
            this.button_DangNhap = new System.Windows.Forms.Button();
            this.button_Thoat = new System.Windows.Forms.Button();
            this.linkLabel_DangKy = new System.Windows.Forms.LinkLabel();
            this.linkLabel_QuenMatKhau = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_TenTaiKhoan
            // 
            this.textBox_TenTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_TenTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TenTaiKhoan.Location = new System.Drawing.Point(144, 320);
            this.textBox_TenTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_TenTaiKhoan.Name = "textBox_TenTaiKhoan";
            this.textBox_TenTaiKhoan.Size = new System.Drawing.Size(256, 20);
            this.textBox_TenTaiKhoan.TabIndex = 3;
            this.textBox_TenTaiKhoan.TextChanged += new System.EventHandler(this.textBox_TenTaiKhoan_TextChanged);
            // 
            // textBox_MatKhau
            // 
            this.textBox_MatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_MatKhau.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MatKhau.Location = new System.Drawing.Point(144, 380);
            this.textBox_MatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_MatKhau.Name = "textBox_MatKhau";
            this.textBox_MatKhau.PasswordChar = '*';
            this.textBox_MatKhau.Size = new System.Drawing.Size(256, 19);
            this.textBox_MatKhau.TabIndex = 4;
            // 
            // button_DangNhap
            // 
            this.button_DangNhap.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DangNhap.Location = new System.Drawing.Point(78, 520);
            this.button_DangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.button_DangNhap.Name = "button_DangNhap";
            this.button_DangNhap.Size = new System.Drawing.Size(322, 36);
            this.button_DangNhap.TabIndex = 5;
            this.button_DangNhap.Text = "Đăng Nhập";
            this.button_DangNhap.UseVisualStyleBackColor = true;
            this.button_DangNhap.Click += new System.EventHandler(this.button_DangNhap_Click);
            // 
            // button_Thoat
            // 
            this.button_Thoat.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Thoat.Location = new System.Drawing.Point(77, 578);
            this.button_Thoat.Margin = new System.Windows.Forms.Padding(4);
            this.button_Thoat.Name = "button_Thoat";
            this.button_Thoat.Size = new System.Drawing.Size(323, 36);
            this.button_Thoat.TabIndex = 6;
            this.button_Thoat.Text = "Thoát";
            this.button_Thoat.UseVisualStyleBackColor = true;
            this.button_Thoat.Click += new System.EventHandler(this.button_Thoat_Click);
            // 
            // linkLabel_DangKy
            // 
            this.linkLabel_DangKy.AutoSize = true;
            this.linkLabel_DangKy.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_DangKy.LinkColor = System.Drawing.Color.Black;
            this.linkLabel_DangKy.Location = new System.Drawing.Point(74, 486);
            this.linkLabel_DangKy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel_DangKy.Name = "linkLabel_DangKy";
            this.linkLabel_DangKy.Size = new System.Drawing.Size(68, 19);
            this.linkLabel_DangKy.TabIndex = 7;
            this.linkLabel_DangKy.TabStop = true;
            this.linkLabel_DangKy.Text = "Đăng Ký";
            this.linkLabel_DangKy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_DangKy_LinkClicked);
            // 
            // linkLabel_QuenMatKhau
            // 
            this.linkLabel_QuenMatKhau.AutoSize = true;
            this.linkLabel_QuenMatKhau.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_QuenMatKhau.LinkColor = System.Drawing.Color.Black;
            this.linkLabel_QuenMatKhau.Location = new System.Drawing.Point(285, 486);
            this.linkLabel_QuenMatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel_QuenMatKhau.Name = "linkLabel_QuenMatKhau";
            this.linkLabel_QuenMatKhau.Size = new System.Drawing.Size(115, 19);
            this.linkLabel_QuenMatKhau.TabIndex = 8;
            this.linkLabel_QuenMatKhau.TabStop = true;
            this.linkLabel_QuenMatKhau.Text = "Quên Mật Khẩu";
            this.linkLabel_QuenMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_QuenMatKhau_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(143, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 38);
            this.label3.TabIndex = 9;
            this.label3.Text = "Đăng Nhập";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WindowsFormsAppQuanly.Properties.Resources.khoa;
            this.pictureBox3.Location = new System.Drawing.Point(82, 374);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsAppQuanly.Properties.Resources.user;
            this.pictureBox2.Location = new System.Drawing.Point(82, 314);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsAppQuanly.Properties.Resources.pngwing_com;
            this.pictureBox1.Location = new System.Drawing.Point(144, 116);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 163);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(85, 346);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 2);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(85, 406);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 2);
            this.panel2.TabIndex = 15;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(415, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 16;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(85, 436);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(107, 19);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Lưu Mật Khẩu";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(289, 436);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(111, 19);
            this.checkBox2.TabIndex = 18;
            this.checkBox2.Text = "Hiện Mật Khẩu";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(472, 651);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel_QuenMatKhau);
            this.Controls.Add(this.linkLabel_DangKy);
            this.Controls.Add(this.button_Thoat);
            this.Controls.Add(this.button_DangNhap);
            this.Controls.Add(this.textBox_MatKhau);
            this.Controls.Add(this.textBox_TenTaiKhoan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_TenTaiKhoan;
        private System.Windows.Forms.TextBox textBox_MatKhau;
        private System.Windows.Forms.Button button_DangNhap;
        private System.Windows.Forms.Button button_Thoat;
        private System.Windows.Forms.LinkLabel linkLabel_DangKy;
        private System.Windows.Forms.LinkLabel linkLabel_QuenMatKhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

