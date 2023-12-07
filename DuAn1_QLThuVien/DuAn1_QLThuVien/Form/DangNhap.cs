using DuAn1;
using DuAn1_QLThuVien;
using QLThuVien;
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
            this.KeyPreview = true;
            this.KeyDown += btn_Login_KeyDown;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_Username.Text)
               || String.IsNullOrWhiteSpace(txt_Username.Text)
               || String.IsNullOrEmpty(txt_Username.Text)
               || String.IsNullOrWhiteSpace(txt_Password.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đủ tài khoản và mật khẩu",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                String Vaitro = DBHandler.Login(txt_Username.Text, DBHandler.toMD5(txt_Password.Text));
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
                    using (QLThuVienEntities3 qal = new QLThuVienEntities3())
                    {
                        if (Vaitro.Equals("vaitro1") || Vaitro.Equals("Admin"))
                        {
                            this.Hide();
                            TrangChu ct = new TrangChu(txt_Username.Text);
                            ct.ShowDialog();
                            this.Close();
                        }
                        if (Vaitro.Equals("vaitro2") || Vaitro.Equals("Nhân viên"))
                        {
                            this.Hide();
                            TrangChu form = new TrangChu(txt_Username.Text);
                            form.ShowDialog();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(
                    "Tài khoản hoặc mật khẩu không chính xác",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            TrangChu tn = new TrangChu(txt_Username.Text);
            QLSach ql = new QLSach(txt_Username.Text);
            QL_NguoiMuonSach qlnms = new QL_NguoiMuonSach(txt_Username.Text);
            QLNguoiTraSach qlnts = new QLNguoiTraSach(txt_Username.Text);
            QLTheHoiVien qlthv = new QLTheHoiVien(txt_Username.Text);
            QLThongKe qltk = new QLThongKe(txt_Username.Text);
            QLNhanVien qlnv = new QLNhanVien(txt_Username.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau qmk = new QuenMatKhau();
            this.Hide();
            qmk.ShowDialog();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txt_Password.PasswordChar = '\0';
            }
            else
            {
                txt_Password.PasswordChar = '*';
            }
        }

        private void btn_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(sender, e);
            }
        }
    }
}
