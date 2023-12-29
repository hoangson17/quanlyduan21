using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsAppQuanly
{
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
            label3.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        Modify modify = new Modify();
        Random random = new Random();
        int otp;
        private void button1_Click(object sender, EventArgs e)
        {   
            if(otp.ToString().Equals(textBox2.Text))
            {
                MessageBox.Show("Xác Minh Thành Công");
                string email = textBox1.Text;
                string query = "Select * from NHANVIEN where Email = '" + email + "'";
                if (modify.TaiKhoans(query).Count != 0){
                   label3.ForeColor = Color.Black;
                   label3.Text = "Mật Khẩu  : " + modify.TaiKhoans(query)[0].MatKhau;
                }
            }
            else
            {
                MessageBox.Show("OTP Không chính xác !!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void QuenMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btn_otp_Click(object sender, EventArgs e)
        {   //tạo mã radom 6 chữ số
            try
            {
                // Tạo một OTP ngẫu nhiên có 6 chữ số
                otp = random.Next(100000, 1000000);

                // Thiết lập email
                var fromAddress = new MailAddress("demodoan638@gmail.com");
                var toAddress = new MailAddress(textBox1.Text);
                const string frompass = "rcsw vpod vtjn uhbr";
                const string subject = "Mã OTP";
                string body = otp.ToString();

                // Thiết lập SMTP
                var smtp = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, frompass),
                    Timeout = 5000 // Điều chỉnh thời gian chờ theo nhu cầu
                };

                // Gửi email
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                // Cung cấp phản hồi cho người dùng
                MessageBox.Show("Mã OTP đã được gửi qua email");
            }
            catch (Exception ex)
            {
                // Ghi log về ngoại lệ cụ thể để hỗ trợ gỡ lỗi
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
    }
}
