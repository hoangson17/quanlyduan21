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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private Form currenFormChild;

        private void OpenChildForm(Form childForm)
        {
            if(currenFormChild != null)
            {
                currenFormChild.Close();
            }
            currenFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(currenFormChild);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaoCao());
            label1.Text = guna2Button1.Text;
        }
        private void guna2Button2_HangHoa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Hang());
            label1.Text = guna2Button2_HangHoa.Text;
        }
       private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HoaDon());
            label1.Text = guna2Button3.Text;
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhanVien());
            label1.Text = guna2Button4.Text;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHang());
            label1.Text = guna2Button5.Text;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhaCC());
            label1.Text = guna2Button6.Text;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhapHang());
            label1.Text = guna2Button8.Text;
        }


        private void panel_Top_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            TimKiem timkiem = new TimKiem();
            timkiem.ShowDialog();
        }
    }
}
