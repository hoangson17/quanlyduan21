using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsAppQuanly
{
    public partial class TimKiem : Form
    {
        public TimKiem()
        {
            InitializeComponent();
        }

        //Tạo kết nối với cơ sở dữ liệu
        public SqlConnection cn = new SqlConnection();
        public void Ketnoi()
        {
            try
            {
                if (cn.State == 0)
                {
                    cn.ConnectionString = "Data Source=DESKTOP-S7AOFL6\\SQLEXPRESS;Initial Catalog=QLCH;Integrated Security=True";
                    cn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Ngatketnoi()
        {
            if (cn.State != 0)
            {
                cn.Close();
            }
        }

        //Phương thức truy vấn để xem dữ liệu
        public DataTable XemDL(string sql)
        {
            Ketnoi();

            SqlDataAdapter adap = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            return dt;

            Ngatketnoi();
        }

        //Phương thức truy vấn dữ liệu: Insert, Update, Delete
        public SqlCommand ThucThiDl(string sql)
        {
            Ketnoi();

            SqlCommand cm = new SqlCommand(sql, cn);
            cm.ExecuteNonQuery();

            return cm;

            Ngatketnoi();
        }



        private void TimKiem_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.Text = "Nhân Viên";
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(guna2ComboBox1.Text == "Nhân Viên")
            {
                dataGridView1.DataSource = XemDL("select * from NHANVIEN where MaNV like '%"+guna2TextBox1.Text.Trim()+"%'");
            }
            if (guna2ComboBox1.Text == "Khách Hàng")
            {
                dataGridView1.DataSource = XemDL("select * from KHACHHANG where MaKH like '%" + guna2TextBox1.Text.Trim() + "%'");
            }
            if (guna2ComboBox1.Text == "Hàng Hóa")
            {
                dataGridView1.DataSource = XemDL("select * from MATHANG where MaMH like '%" + guna2TextBox1.Text.Trim() + "%'");
            }
            if (guna2ComboBox1.Text == "Hóa Đơn")
            {
                dataGridView1.DataSource = XemDL("select * from HOADON where SoHD like '%" + guna2TextBox1.Text.Trim() + "%'");
            }
            if (guna2ComboBox1.Text == "Chi Tiết Hóa Đơn")
            {
                dataGridView1.DataSource = XemDL("select * from CHITIETHOADON where MaMH like '%" + guna2TextBox1.Text.Trim() + "%'");
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
