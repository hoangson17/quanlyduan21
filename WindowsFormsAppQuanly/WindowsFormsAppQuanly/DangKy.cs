using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsAppQuanly
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }
        public bool CheckAdmin(string ad)//check hoten
        {
            return Regex.IsMatch(ad, @"^[a-zA-Z0-9À-ỹ ]{5,24}$");
        }

        public bool CheckMa(string ma)//check manv
        {
            return Regex.IsMatch(ma, "^[a-zA-Z0-9]{3,24}$");
        }

        public bool CheckAccount(string ac)//check mat khau va ten tai khoan
        {
            return Regex.IsMatch(ac,"^[a-zA-Z0-9]{6,24}$");
        }
        public bool CheckEmail(string em)//check Email
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");
        }
        Modify modify=new Modify();
        private void button_DangKy_Click(object sender, EventArgs e)
        {
            string query_CountID = "SELECT COUNT(*) FROM NHANVIEN WHERE MaNV = @MaNV";
            string manv = DataProvider.Instance.GenerateId(query_CountID, "NV");
            string hoten = textBox_HoTen.Text;
            string tentk = textBox_TenTaiKhoan.Text;
            string matkhau = textBox_MatKhau.Text;
            string xnmatkhau = textBox_XNMatKhau.Text;
            string email = textBox_Email.Text;
            if (!CheckMa(manv)) { MessageBox.Show("Vui lòng nhập mã nhân viên dài 3-24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường !"); return; }
            if (!CheckAdmin(hoten)) { MessageBox.Show("Vui lòng nhập tên dài 10-24 ký tự, với các ký tự chữ hoa và chữ thường !"); return; }
            if (!CheckAccount(tentk)) {MessageBox.Show("Vui lòng nhập tên tài khoản dài 6-24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường !");return;}
            if (!CheckAccount(matkhau)) { MessageBox.Show("Vui lòng nhập mật khẩu dài 6-24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường !"); return; }
            if(xnmatkhau != matkhau) { MessageBox.Show("Vui lòng xác nhận mật khẩu chính xác !!");return; }
            if (!CheckEmail(email)) { MessageBox.Show("Vui lòng nhập đúng định dạng Email !!");return; }
            if (modify.TaiKhoans("Select * from NHANVIEN where Email = '" + email + "' ").Count !=0)
            {
                MessageBox.Show("Email này đã được đăng ký vui lòng sử dụng Email khác !!!");
                return;
            }
            try {
                string query = "INSERT INTO NHANVIEN(MaNV,TenNV,Email,Taikhoan,Matkhau) VALUES (@MaNV, @TenNV, @Email, @Taikhoan, @Matkhau)";
                object[] parameter = new object[] { manv, hoten , email , tentk , matkhau };
                DataProvider.Instance.ExcuteNonQuery(query, parameter);
                MessageBox.Show("Đăng kí thành công !!! ");
                button_Thoat_Click(sender, e);

            }
            catch 
            {
                MessageBox.Show("Tài khoản đã được đăng kí !!! ");
            }

        }


        private void button_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DangKy_Load(object sender, EventArgs e)
        {

        }
    }
}
