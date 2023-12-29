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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }
        Modify modify;
        nhanvien1 nhanVien;
        private void NhanVien_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                guna2DataGridView1.DataSource = modify.getAllNhanvien();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi"+ex.Message,"Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Them_Click(object sender, EventArgs e)
        {
            string queryCountId = "SELECT COUNT(*) FROM NHANVIEN WHERE MaNV = @MaNV";
            string manv = DataProvider.Instance.GenerateId(queryCountId, "NV");
            string tennv = this.guna2TextBox2_Hoten.Text;
            DateTime ngaysinh = this.guna2DateTimePicker_ngaysinh.Value;
            string diachi = this.guna2TextBox5_Diachi.Text;
            string sdt = this.guna2TextBox4_Sodt.Text;
            string chucvu = this.guna2TextBox6_Chucvu.Text;
            string email = this.guna2TextBox8_Email.Text;
            string taikhoan = this.guna2TextBox7_Taikhoan.Text;
            string matkhau = this.guna2TextBox_matkhau.Text;
            nhanVien = new nhanvien1(manv,tennv,ngaysinh,diachi,sdt,chucvu,email,taikhoan,matkhau);
            if (modify.insert(nhanVien))
            {
                guna2DataGridView1.DataSource = modify.getAllNhanvien();
            }
            else
            {
                MessageBox.Show("Lỗi " + "không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    

        }

        /*private void guna2Button_sua_Click(object sender, EventArgs e)
        {
            string manv = this.guna2TextBox1_Manv.Text;
            string tennv = this.guna2TextBox2_Hoten.Text;
            DateTime ngaysinh = this.guna2DateTimePicker_ngaysinh.Value;
            string diachi = this.guna2TextBox5_Diachi.Text;
            string sdt = this.guna2TextBox4_Sodt.Text;
            string chucvu = this.guna2TextBox6_Chucvu.Text;
            string email = this.guna2TextBox8_Email.Text;
            string taikhoan = this.guna2TextBox7_Taikhoan.Text;
            string matkhau = this.guna2TextBox_matkhau.Text;
            nhanVien = new nhanvien1(manv, tennv, ngaysinh, diachi, sdt, chucvu, email, taikhoan, matkhau);
            if (modify.update(nhanVien))
            {
                guna2DataGridView1.DataSource = modify.getAllNhanvien();
            }
            else
            {
                MessageBox.Show("Lỗi " + "không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }*/

        private void guna2Button2_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (guna2DataGridView1.SelectedRows.Count > 0)
                {
                    // Lấy giá trị của cột đầu tiên (giả sử đó là cột ID) từ dòng được chọn
                    string id = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                    // Xác nhận xóa bằng MessageBox trước khi tiến hành xóa
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên có ID: {id} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Thực hiện xóa và kiểm tra kết quả
                        if (modify.delete(id))
                        {
                            guna2DataGridView1.DataSource = modify.getAllNhanvien();
                            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không xóa được nhân viên. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
