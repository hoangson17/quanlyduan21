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
    public partial class ChiTietTH : Form
    {
        public ChiTietTH()
        {
            InitializeComponent();
        }
        Modify modify;
        chitietth1 chiTietth;
        private void ChiTietTH_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                guna2DataGridView1.DataSource = modify.getAllChitietth();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string mamh = this.guna2TextBox1.Text;
            int soluongtra, dongia, tongtientra;

            if (int.TryParse(this.guna2TextBox2.Text, out soluongtra) &&
                int.TryParse(this.guna2TextBox4.Text, out dongia) &&
                int.TryParse(this.guna2TextBox3.Text, out tongtientra))
            {
                string sopt = this.guna2TextBox5.Text;
                chiTietth = new chitietth1(mamh,soluongtra,dongia,tongtientra,sopt);

                if (modify.insertChitietth(chiTietth))
                {
                    guna2DataGridView1.DataSource = modify.getAllChitietth();
                }
                else
                {
                    MessageBox.Show("Lỗi " + "không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lỗi " + "Nhập số nguyên cho Số lượng bán, Đơn giá và Tổng tiền", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string mamh = this.guna2TextBox1.Text;
            int soluongtra, dongia, tongtientra;

            if (int.TryParse(this.guna2TextBox2.Text, out soluongtra) &&
                int.TryParse(this.guna2TextBox4.Text, out dongia) &&
                int.TryParse(this.guna2TextBox3.Text, out tongtientra))
            {
                string sopt = this.guna2TextBox5.Text;
                chiTietth = new chitietth1(mamh, soluongtra, dongia, tongtientra, sopt);

                if (modify.updateChitietth(chiTietth))
                {
                    guna2DataGridView1.DataSource = modify.getAllChitietth();
                }
                else
                {
                    MessageBox.Show("Lỗi " + "không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lỗi " + "Nhập số nguyên cho Số lượng bán, Đơn giá và Tổng tiền", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
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
                        if (modify.deleteChitietth(id))
                        {
                            guna2DataGridView1.DataSource = modify.getAllChitietth();
                            MessageBox.Show("Xóa  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không xóa được . Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
