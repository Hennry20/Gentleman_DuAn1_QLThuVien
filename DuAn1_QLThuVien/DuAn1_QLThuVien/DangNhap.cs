using DuAn1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn1_QLThuVien
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Username))
            {
                txt_Username.Text = Properties.Settings.Default.Username;
                txt_Password.Text = Properties.Settings.Default.Password;
                ckb_GhiNhoDangNhap.Checked = true;
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_Username.Text)
               || String.IsNullOrWhiteSpace(txt_Username.Text)
               || String.IsNullOrEmpty(txt_Username.Text)
               || String.IsNullOrWhiteSpace(txt_Password.Text))
            {
                //MessageBox.Show(
                //    "Vui lòng nhập đủ tài khoản và mật khẩu",
                //    "Lỗi nhập liệu",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Error);
                label4.Visible = true;
                label4.Text = "Vui lòng nhập đầy đủ thông tin";
                label4.ForeColor = Color.Red;
            }
            else
            {
                label4.Visible = false;
                String Vaitro = DBHandler.Login(txt_Username.Text, txt_Password.Text);
                if (!String.IsNullOrEmpty(Vaitro))
                {
                    if (ckb_GhiNhoDangNhap.Checked == true)
                    {
                        Properties.Settings.Default.Username = txt_Username.Text;
                        Properties.Settings.Default.Password = txt_Password.Text;
                    }
                    else
                    {
                        Properties.Settings.Default.Username = "";
                        Properties.Settings.Default.Password = "";
                    }

                    if (Vaitro.Equals("Admin"))
                    {
                        this.Hide();
                        TrangChu tc = new TrangChu();
                        tc.ShowDialog();
                        this.Close();

                    }
                    if (Vaitro.Equals("NhanVien"))
                    {
                        this.Hide();
                        DoiMatKhau form = new DoiMatKhau();
                        form.ShowDialog();
                        this.Close();
                    }
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.Hide();
            //DangKy dk = new DangKy();
            //dk.ShowDialog();
            //this.Close();
        }

        private void ptb_ShowMK_Click(object sender, EventArgs e)
        {
            ptb_ShowMK.ImageLocation = "eyes2.png";
            if (ptb_ShowMK.ImageLocation == "eyes2.png")
            {
                txt_Password.PasswordChar = '*';
            }
            else
            {
                ptb_ShowMK.ImageLocation = "eyes2.png";
                txt_Password.PasswordChar = '\0';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            this.Hide();
            dmk.ShowDialog();
            this.Close();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult quit = MessageBox.Show("Bạn có muốn thoát?", "Thoát",MessageBoxButtons.YesNo);
            if(quit == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
