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
    public partial class ChiTietNH : Form
    {
        public string SoPN { get; set; }

        public ChiTietNH()
        {
            InitializeComponent();
        }
        Modify modify;
        chitietnh1 chiTietnh;
        private void ChiTietNH_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                data.DataSource = modify.getAllChitietnh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            addDataSource();
            tbx_SoPN.Text = this.SoPN;
            AddDataCbx();
        }
        private void AddDataCbx()
        {
            string query = "SELECT * FROM MATHANG ";
            cbx_MaMatHang.DataSource = DataProvider.Instance.ExcuteQuery(query);
            cbx_MaMatHang.DisplayMember = "MaMH";
            cbx_MaMatHang.SelectedIndex = -1;
        }
        private void addDataSource()
        {
            string query = "select * from CHITIETNHAPHANG where SoPN = @SoPN ";
            object[] Parameter = new object[] { this.SoPN};
            data.DataSource = DataProvider.Instance.ExcuteQuery(query, Parameter);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string queryCountId = "SELECT COUNT(*) FROM CHITIETNHAPHANG WHERE MaCTNH = @MaCTNH";
            string maCTNH = DataProvider.Instance.GenerateId(queryCountId, "CTNH");
            string mamh = cbx_MaMatHang.Text;
            int soluongnhap, gianhap, tongtien;

            if (int.TryParse(this.guna2TextBox2.Text, out soluongnhap) &&
                int.TryParse(this.guna2TextBox3.Text, out gianhap))
            {
                try
                {
                    string sopn = this.tbx_SoPN.Text;
                    tongtien = soluongnhap * gianhap;
                    //chiTietnh = new chitietnh1(mamh, soluongnhap, gianhap, tongtien, sopn);
                    string query = "INSERT INTO CHITIETNHAPHANG(MaCTNH, MaMH,Soluongnhap,Gianhap,Tongtien,SoPN) VALUES (@MaCTNH,@MaMH, @Soluongnhap, @Gianhap,@Tongtien,@SoPN)";
                    object[] parameter = new object[] { maCTNH, mamh, soluongnhap, gianhap, tongtien, sopn };
                    DataProvider.Instance.ExcuteNonQuery(query, parameter);

                    addDataSource();
                }
                catch 
                {
                    MessageBox.Show("Mã hàng này đã được thêm ");
                }

            }
            else
            {
                MessageBox.Show("Lỗi " + "Nhập số nguyên cho Số lượng bán, Đơn giá ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private void guna2Button2_Click(object sender, EventArgs e)
        {
            string mamh = this.cbx_MaMatHang.Text;
            int soluongnhap, gianhap, tongtien;

            if (int.TryParse(this.guna2TextBox2.Text, out soluongnhap) &&
                int.TryParse(this.guna2TextBox3.Text, out gianhap))
            {
                string sopn = this.tbx_SoPN.Text;
                tongtien = soluongnhap * gianhap;
                chiTietnh = new chitietnh1(mamh, soluongnhap, gianhap, tongtien, sopn);

                if (modify.updateChitietnh(chiTietnh))
                {
                    data.DataSource = modify.getAllChitietnh();
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
        }*/

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (data.SelectedRows.Count > 0)
                {
                    // Lấy giá trị của cột đầu tiên (giả sử đó là cột ID) từ dòng được chọn
                    string id = data.SelectedRows[0].Cells[0].Value.ToString();

                    // Xác nhận xóa bằng MessageBox trước khi tiến hành xóa
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa phiếu có số : {id} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Thực hiện xóa và kiểm tra kết quả
                        if (modify.deleteChitietpn(id))
                        {
                            object[] parameter = new object[] { id };
                            string query = "DELETE FROM CHITIETNHAPHANG WHERE MaCTNH = @MaCTNH";
                            DataProvider.Instance.ExcuteNonQuery(query, parameter);
                            addDataSource();
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
