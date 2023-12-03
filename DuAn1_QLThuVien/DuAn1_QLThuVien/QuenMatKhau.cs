using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace DuAn1_QLThuVien
{
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
        }
        string[] str2 = new string[30];
        private void btnXacNhan_Click(object sender, EventArgs e)
        {

        }

        private void txtNhanMa_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage("chuongg51@gmail.com", txtEmail.Text, "Ma Xac Nhan", "Hello");
            mail.IsBodyHtml = true;
            //gửi tin nhắn
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Host = "smtp.gmail.com";
            //ta không dùng cái mặc định đâu, mà sẽ dùng cái của riêng mình
            client.UseDefaultCredentials = false;
            client.Port = 587; //vì sử dụng Gmail nên mình dùng port 587
                               // thêm vào credential vì SMTP server cần nó để biết được email + password của email đó mà bạn đang dùng
            client.Credentials = new System.Net.NetworkCredential(txtEmail.Text, "0147896325");
            client.EnableSsl = true; //vì ta cần thiết lập kết nối SSL với SMTP server nên cần gán nó bằng true
            client.Send(mail);

            //var fromAddress = new MailAddress("chuonggo51@gmail.com", "From Name");
            //var toAddress = new MailAddress("sieuthantuong133@gmail.com", "To Name");

            //const string fromPassword = "0147896325";
            //const string subject = "Subject";
            //const string body = "Body";

            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            //};
            //using (var message = new MailMessage(fromAddress, toAddress)
            //{
            //    Subject = subject,
            //    Body = body
            //})
            //{
            //    smtp.Send(message);
            //}
            MessageBox.Show("Đã gửi tin nhắn thành công!", "Thành Công", MessageBoxButtons.OK);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtMatKhauMoi.PasswordChar = '\0';
                txtXacNhanMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhauMoi.PasswordChar = '*';
                txtXacNhanMatKhau.PasswordChar = '*';
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            this.Hide();
            dn.ShowDialog();
            this.Close();
        }

        private void QuenMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
