using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppQuanly
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_TenTaiKhoan.Text = Properties.Settings.Default.Taikhoan;
            textBox_MatKhau.Text = Properties.Settings.Default.Matkhau;
            if (Properties.Settings.Default.Taikhoan != "")
            {
                checkBox1.Checked = true;
            }
        }

        private void button_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel_DangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dangki = new DangKy();
            dangki.ShowDialog();
            
        }

        private void linkLabel_QuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau quenMatKhau = new QuenMatKhau();
            quenMatKhau.ShowDialog();
            
        }
        Modify modify= new Modify();
        private void button_DangNhap_Click(object sender, EventArgs e)
        {
            string tentk=textBox_TenTaiKhoan.Text;
            string matkhau=textBox_MatKhau.Text;
            if(tentk.Trim() == "") { MessageBox.Show("Vui lòng nhập tài khoản !!"); }
            else if (matkhau.Trim() == "") { MessageBox.Show("Vui lòng nhập mật khẩu !!"); }
            else
            {
                string query = "Select * from NHANVIEN where Taikhoan = '" + tentk+ "' and Matkhau = '" + matkhau+"'";
                if (modify.TaiKhoans(query).Count != 0)
                {
                    MessageBox.Show("Đăng nhập thành công !","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Home home = new Home();
                    home.ShowDialog();
                  
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox_TenTaiKhoan.Text != "" && textBox_MatKhau.Text != "")
            {
                if (checkBox1.Checked == true)
                {
                    string tentk = textBox_TenTaiKhoan.Text;
                    string matkhau = textBox_MatKhau.Text;
                    Properties.Settings.Default.Taikhoan = tentk;
                    Properties.Settings.Default.Matkhau = matkhau;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Reset();
                }
            }
        }

        private void textBox_TenTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox_MatKhau.PasswordChar = '\0';
            }
            else
            {
                textBox_MatKhau.PasswordChar = '*';
            }
        }
    }
}
