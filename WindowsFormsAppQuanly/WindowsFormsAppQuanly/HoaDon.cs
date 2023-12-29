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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }
        Modify modify;
        hoadon1 hoaDon;
        private void HoaDon_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                guna2DataGridView1.DataSource = modify.getAllHoadon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AddDataCbx_NV();
            AddDataCbx_MKH();
        }

        private void AddDataCbx_NV()
        {
            string query = "SELECT * FROM NHANVIEN ";
            cbx_NV.DataSource = DataProvider.Instance.ExcuteQuery(query);
            cbx_NV.DisplayMember = "MaNV";
            cbx_NV.SelectedIndex = -1;
        }

        private void AddDataCbx_MKH()
        {
            string query = "SELECT * FROM KHACHHANG ";
            cbx_mkh.DataSource = DataProvider.Instance.ExcuteQuery(query);
            cbx_mkh.DisplayMember = "MaKH";
            cbx_mkh.SelectedIndex = -1;
        }

        private void guna2Button_them_Click(object sender, EventArgs e)
        {
            string queryCountId = "SELECT COUNT(*) FROM HOADON WHERE SoHD = @SoHD";           
            string sohd = DataProvider.Instance.GenerateId(queryCountId, "HD");
            DateTime ngayban = this.guna2DateTimePicker_ngayban.Value;
            string httt = this.cbx_httt.Text;
            string manv = this.cbx_NV.Text;
            string makh = this.cbx_mkh.Text;
            hoaDon = new hoadon1(sohd,ngayban,httt,manv,makh);
            if (modify.insertHoadon(hoaDon))
            {
                guna2DataGridView1.DataSource = modify.getAllHoadon();
            }
            else
            {
                MessageBox.Show("Lỗi " + "không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                        if (modify.deleteHoadon(id))
                        {
                            guna2DataGridView1.DataSource = modify.getAllHoadon();
                            MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không xóa được hóa đơn. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private void guna2Button_sua_Click(object sender, EventArgs e)
        {
            string sohd = this.guna2TextBox_sohd.Text;
            DateTime ngayban = this.guna2DateTimePicker_ngayban.Value;
            string httt = this.guna2TextBox_httt.Text;
            string manv = this.guna2TextBox_mnv.Text;
            string makh = this.guna2TextBox_mkh.Text;
            hoaDon = new hoadon1(sohd, ngayban, httt, manv, makh);
            if (modify.updateHoadon(hoaDon))
            {
                guna2DataGridView1.DataSource = modify.getAllHoadon();
            }
            else
            {
                MessageBox.Show("Lỗi " + "không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = guna2DataGridView1.SelectedRows[0];
            string Selected_SoHD = row.Cells[0].Value.ToString();

            ChiTietHD chiTietHD = new ChiTietHD()
            {
                SoHD = Selected_SoHD
            };
            chiTietHD.ShowDialog();
        }
    }
}
