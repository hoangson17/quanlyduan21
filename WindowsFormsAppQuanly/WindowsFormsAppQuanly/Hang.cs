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
    public partial class Hang : Form
    {
        public Hang()
        {
            InitializeComponent();
        }
        Modify modify;
        hang1 hang;
        private void Hang_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                guna2DataGridView1.DataSource = modify.getAllHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button_them_Click(object sender, EventArgs e)
        {
            string queryCountId = "SELECT COUNT(*) FROM MATHANG WHERE MaMH = @MaMH";
            string mahang = DataProvider.Instance.GenerateId(queryCountId, "MH"); ;
            string tenhang = this.guna2TextBox_tenhang.Text;
            string mau = this.guna2TextBox_mau.Text;
            string size = this.guna2ComboBox1.Text;
            string hsx = this.guna2TextBox_hsx.Text;

            // Chuyển đổi kiểu dữ liệu từ chuỗi sang số nguyên
            if (int.TryParse(this.guna2TextBox_soluong.Text, out int soluong) && int.TryParse(this.guna2TextBox_dongia.Text, out int dongia))
            {
                hang = new hang1(mahang, tenhang, mau, size, hsx, soluong, dongia);
                if (modify.insertHang(hang))
                {
                    guna2DataGridView1.DataSource = modify.getAllHang();
                }
                else
                {
                    MessageBox.Show("Lỗi không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Số lượng và đơn giá phải là số nguyên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private void guna2Button_sua_Click(object sender, EventArgs e)
        {
            
            string tenhang = this.guna2TextBox_tenhang.Text;
            string mau = this.guna2TextBox_mau.Text;
            string size = this.guna2TextBox_masize.Text;
            string hsx = this.guna2TextBox_hsx.Text;

            // Chuyển đổi kiểu dữ liệu từ chuỗi sang số nguyên
            if (int.TryParse(this.guna2TextBox_soluong.Text, out int soluong) && int.TryParse(this.guna2TextBox_dongia.Text, out int dongia))
            {
                hang = new hang1(mahang, tenhang, mau, size, hsx, soluong, dongia);
                if (modify.updateHang(hang))
                {
                    guna2DataGridView1.DataSource = modify.getAllHang();
                }
                else
                {
                    MessageBox.Show("Lỗi không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Số lượng và đơn giá phải là số nguyên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (modify.deleteHang(id))
                        {
                            guna2DataGridView1.DataSource = modify.getAllHang();
                            MessageBox.Show("Xóa hóa mặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không xóa được mặt hàng. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một mặt hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
