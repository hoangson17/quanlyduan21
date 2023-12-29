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
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        Modify modify;
        khachhang1 khachHang;
        private void KhachHang_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                guna2DataGridView1.DataSource = modify.getAllKhachhang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button_them_Click(object sender, EventArgs e)
        {
            string queryCountId = "SELECT COUNT(*) FROM KHACHHANG WHERE MaKH = @MaKH";
            string makh = DataProvider.Instance.GenerateId(queryCountId, "KH");
            string tenkh = this.guna2TextBox_tenkh.Text;
            string diachi = this.guna2TextBox_diachi.Text;
            string sdt = this.guna2TextBox_sdt.Text;
            string ghichu = this.guna2TextBox5.Text;
            khachHang = new khachhang1(makh,tenkh,diachi,sdt,ghichu);
            if (modify.insertKhachhang(khachHang))
            {
                guna2DataGridView1.DataSource = modify.getAllKhachhang();
            }
            else
            {
                MessageBox.Show("Lỗi " + "không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private void guna2Button_sua_Click(object sender, EventArgs e)
        {
            string makh = this.guna2TextBox_makh.Text;
            string tenkh = this.guna2TextBox_tenkh.Text;
            string diachi = this.guna2TextBox_diachi.Text;
            string sdt = this.guna2TextBox_sdt.Text;
            string ghichu = this.guna2TextBox5.Text;
            khachHang = new khachhang1(makh, tenkh, diachi, sdt, ghichu);
            if (modify.updateKhachhang(khachHang))
            {
                guna2DataGridView1.DataSource = modify.getAllKhachhang();
            }
            else
            {
                MessageBox.Show("Lỗi " + "không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/
    

        private void guna2Button_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (guna2DataGridView1.SelectedRows.Count > 0)
                {
                    // Lấy giá trị của cột đầu tiên (giả sử đó là cột ID) từ dòng được chọn
                    string id = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                    // Xác nhận xóa bằng MessageBox trước khi tiến hành xóa
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa hóa đơn có số : {id} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Thực hiện xóa và kiểm tra kết quả
                        if (modify.deleteKhachhang(id))
                        {
                            guna2DataGridView1.DataSource = modify.getAllKhachhang();
                            MessageBox.Show("Xóa khách hang thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không xóa được khách hàng. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
