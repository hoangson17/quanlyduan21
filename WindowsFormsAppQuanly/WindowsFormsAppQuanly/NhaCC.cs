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
    public partial class NhaCC : Form
    {
        public NhaCC()
        {
            InitializeComponent();
        }
        Modify modify;
        nhacc1 nhaCc;

        private void NhaCC_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                guna2DataGridView1.DataSource = modify.getAllNhacc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button_them_Click(object sender, EventArgs e)
        {
            string queryCountId = "SELECT COUNT(*) FROM NHACUNGCAP WHERE MaNCC = @MaNCC";
            string mancc = DataProvider.Instance.GenerateId(queryCountId, "NCC");
            string tenncc = this.guna2TextBox_tenncc.Text;
            string diachi = this.guna2TextBox_dcncc.Text;
            string sdt = this.guna2TextBox_sdt.Text;
            string ghichu = this.guna2TextBox_ghichu.Text;
            nhaCc = new nhacc1(mancc, tenncc, diachi, sdt, ghichu);
            if (modify.insertNhacc(nhaCc))
            {
                guna2DataGridView1.DataSource = modify.getAllNhacc();
            }
            else
            {
                MessageBox.Show("Lỗi " + "không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private void guna2Button_sua_Click(object sender, EventArgs e)
        {
            string mancc = this.guna2TextBox_mancc.Text;
            string tenncc = this.guna2TextBox_tenncc.Text;
            string diachi = this.guna2TextBox_dcncc.Text;
            string sdt = this.guna2TextBox_sdt.Text;
            string ghichu = this.guna2TextBox_ghichu.Text;
            nhaCc = new nhacc1(mancc, tenncc, diachi, sdt, ghichu);
            if (modify.updateNhacc(nhaCc))
            {
                guna2DataGridView1.DataSource = modify.getAllNhacc();
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
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa nhà cung cấp có số : {id} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Thực hiện xóa và kiểm tra kết quả
                        if (modify.deleteNhacc(id))
                        {
                            guna2DataGridView1.DataSource = modify.getAllNhacc();
                            MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không xóa được nhà cung cấp. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhà cung cấp để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
