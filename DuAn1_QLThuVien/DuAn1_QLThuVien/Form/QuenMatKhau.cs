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
using System.Data.SqlClient;

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
            try
            {
                if (txtTaiKhoan.Text == "" || txtEmail.Text == "" || txtMatKhauMoi.Text =="" ||txtXacNhanMatKhau.Text =="" || txtNhanMa.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu đầy đủ!","Thông báo");
                    return;
                }
                if(txtMatKhauMoi.Text != txtXacNhanMatKhau.Text)
                {
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu!", "Thông báo");
                    return;
                }
                
                string ht = string.Format(@"exec quenmk '{0}', '{1}'", txtTaiKhoan.Text,DBHandler.toMD5(txtMatKhauMoi.Text));
                SqlConnection myConn = new SqlConnection(@"Data Source=.;Initial Catalog=QLThuVien;Integrated security=SSPI");
                SqlCommand cmd = new SqlCommand(ht);
                myConn.Open();
                cmd.Connection = myConn;
                SqlDataReader dtr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dtr);
                myConn.Close();
                MessageBox.Show("Mật khẩu đã được cập nhật", "Thông báo");
                txtTaiKhoan.Text = "";
                txtEmail.Text = "";
                txtMatKhauMoi.Text = "";
                txtXacNhanMatKhau.Text = "";
                txtNhanMa.Text = "";
            }
            catch
            {

            }
        }
        private void txtNhanMa_Click(object sender, EventArgs e)
        {
            var fromAddress = new MailAddress("chuonggo51@gmail.com", "Anh Chuong Dep Trai");
            var toAddress = new MailAddress(txtEmail.Text, "To Nguoi dung");

            const string fromPassword = "jxsd rirs mzlz nnoq";
            StringBuilder auto = new StringBuilder();
            const string subject = "Mã xác nhận của bạn là: ";
            Random rd = new Random();

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = rd.NextString(8),
            })
            {
                smtp.Send(message);
            }
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
            if (txtEmail.Text.Trim() == "")
            {
                btnNhanMa.Enabled = false;
                txtNhanMa.Enabled = false;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() != "")
            {
                btnNhanMa.Enabled = true;
                txtNhanMa.Enabled = true;
                btnNhanMa.BackColor = Color.White;
                btnNhanMa.ForeColor = Color.DodgerBlue;
            }
            else
            {
                btnNhanMa.Enabled = false;
                txtNhanMa.Enabled = false;
            }
        }
    }
}
