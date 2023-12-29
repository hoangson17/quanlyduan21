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

    public partial class NhapHang : Form
    {

        public NhapHang()
        {
            InitializeComponent();
        }
        Modify modify;
        nhaphang1 nhapHang;
        private void NhapHang_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                guna2DataGridView1.DataSource = modify.getAllNhaphang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AddDataCbx_mnv();
            AddDataCbx_mncc();

        }

        private void AddDataCbx_mnv()
        {
            string query = "SELECT * FROM NHANVIEN ";
            cbx_mnv.DataSource = DataProvider.Instance.ExcuteQuery(query);
            cbx_mnv.DisplayMember = "MaNV";
            cbx_mnv.SelectedIndex = -1;
        }

        private void AddDataCbx_mncc()
        {
            string query = "SELECT * FROM NHACUNGCAP ";
            cbx_mncc.DataSource = DataProvider.Instance.ExcuteQuery(query);
            cbx_mncc.DisplayMember = "MaNCC";
            cbx_mncc.SelectedIndex = -1;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string queryCountId = "SELECT COUNT(*) FROM NHAPHANG WHERE SoPN = @SoPN";
            string sopn = DataProvider.Instance.GenerateId(queryCountId, "PN");
            DateTime ngayban = this.guna2DateTimePicker_ngay.Value;
            string httt = this.cbx_httt.Text;
            string manv = this.cbx_mnv.Text;
            string mancc = this.cbx_mncc.Text;
            nhapHang = new nhaphang1(sopn, ngayban, httt, manv, mancc);
            if (modify.insertNhaphang(nhapHang))
            {
                guna2DataGridView1.DataSource = modify.getAllNhaphang();
            }
            else
            {
                MessageBox.Show("Lỗi " + "không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private void guna2Button2_Click(object sender, EventArgs e)
        {
            string sopn = this.guna2TextBox_sopn.Text;
            DateTime ngayban = this.guna2DateTimePicker_ngay.Value;
            string httt = this.guna2TextBox_httt.Text;
            string manv = this.guna2TextBox_mnv.Text;
            string mancc = this.guna2TextBox_mncc.Text;
            nhapHang = new nhaphang1(sopn, ngayban, httt, manv, mancc);
            if (modify.updateNhaphang(nhapHang))
            {
                guna2DataGridView1.DataSource = modify.getAllNhaphang();
            }
            else
            {
                MessageBox.Show("Lỗi " + "không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

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
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa phiếu nhập có số : {id} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Thực hiện xóa và kiểm tra kết quả
                        if (modify.deleteNhaphang(id))
                        {
                            guna2DataGridView1.DataSource = modify.getAllNhaphang();
                            MessageBox.Show("Xóa hóa phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không xóa được phiếu nhập. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một phiếu nhập để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = guna2DataGridView1.SelectedRows[0];
            string Selected_SoPN = row.Cells[0].Value.ToString();
            
            ChiTietNH chiTietNH = new ChiTietNH()
            {
                SoPN = Selected_SoPN
            };
            chiTietNH.ShowDialog();
            
        }
    }
}
