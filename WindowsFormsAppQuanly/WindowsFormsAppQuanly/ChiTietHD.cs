using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppQuanly
{
    public partial class ChiTietHD : Form
    {
        public string SoHD { get; set; }
        public ChiTietHD()
        {
            InitializeComponent();
        }
        Modify modify;
        chitiethd1 chiTiethd;

        private void ChiTietHD_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                guna2DataGridView1.DataSource = modify.getAllChitiethd();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            tbx_SoHD.Text = this.SoHD;
            AddDataCbx();
            CalculateTotalAmount();
            UpdateTotalAmountLabel();
            addDataSource();
        }

        private decimal CalculateTotalAmount()
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Lấy giá trị từ cột có index tương ứng
                    decimal tongtien;
                    if (decimal.TryParse(row.Cells["Tongtien"].Value.ToString(), out tongtien))
                    {
                        totalAmount += tongtien;
                    }
                }
            }

            return totalAmount;
        }

        private void UpdateTotalAmountLabel()
        {
            decimal totalAmount = CalculateTotalAmount();
            label1.Text = $"Tổng tiền: {totalAmount.ToString("C")}";
        }


        private void addDataSource()
        {
            string query = "select * from CHITIETHOADON where SoHD = @SoHD ";
            object[] Parameter = new object[] { this.SoHD };
            guna2DataGridView1.DataSource = DataProvider.Instance.ExcuteQuery(query, Parameter);
        }

        private void AddDataCbx()
        {
            string query = "SELECT * FROM MATHANG ";
            cbx_MaMatHang.DataSource = DataProvider.Instance.ExcuteQuery(query);
            cbx_MaMatHang.DisplayMember = "MaMH";
            cbx_MaMatHang.SelectedIndex = -1;
        }

        private void guna2Button_them_Click(object sender, EventArgs e)
        {
            string queryCountId = "SELECT COUNT(*) FROM CHITIETHOADON WHERE MaCTHD = @MaCTHD";
            string maCTHD = DataProvider.Instance.GenerateId(queryCountId, "CTHD");
            string mamh = this.cbx_MaMatHang.Text;
            int soluongban, dongia, tongtien;

            if (int.TryParse(this.guna2TextBox2.Text, out soluongban) &&
                int.TryParse(this.guna2TextBox4.Text, out dongia))
            {
                try
                {
                    tongtien = soluongban * dongia;
                    string mahd = this.tbx_SoHD.Text;
                    //chiTiethd = new chitiethd1( mamh, soluongban, dongia, tongtien, mahd);
                    //chiTietnh = new chitietnh1(mamh, soluongnhap, gianhap, tongtien, sopn);
                    string query = "INSERT INTO CHITIETHOADON( MaCTHD,MaMH,Soluongban,Dongia,Tongtien,SoHD) VALUES (@MaCTHD,@MaMH, @Soluongban, @Dongia,@Tongtien,@SoHD)";
                    object[] parameter = new object[] { maCTHD,mamh, soluongban, dongia, tongtien, mahd };
                    DataProvider.Instance.ExcuteNonQuery(query, parameter);
                    UpdateTotalAmountLabel();
                    addDataSource();
                }
                catch {
                    MessageBox.Show("Mã hàng này đã có");
                }
            }
            else
            {
                MessageBox.Show("Lỗi " + "Nhập số nguyên cho Số lượng bán, Đơn giá ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /*private void guna2Button_sua_Click(object sender, EventArgs e)
        {
            string mamh = this.cbx_MaMatHang.Text;
            int soluongban = int.Parse(this.guna2TextBox2.Text);
            int dongia = int.Parse(this.guna2TextBox4.Text);
            int tongtien = soluongban*dongia;
            string mahd = this.tbx_SoHD.Text;
            chiTiethd = new chitiethd1(mamh, soluongban, dongia, tongtien, mahd);

            if (modify.updateChitiethd(chiTiethd))
            {
                guna2DataGridView1.DataSource = modify.getAllChitiethd();
            }
            else
            {
                MessageBox.Show("Lỗi " + "không cập nhật được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (modify.deleteChitiethd(id))
                        {
                            guna2DataGridView1.DataSource = modify.getAllChitiethd();
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {            
            MessageBox.Show("Thanh Toán Thành Công ");
            Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            BaoCao baoCao = new BaoCao();   
            baoCao.ShowDialog();
        }
    }
}
