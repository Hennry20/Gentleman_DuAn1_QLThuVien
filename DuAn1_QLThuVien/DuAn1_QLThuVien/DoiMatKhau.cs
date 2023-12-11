using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net;
using DuAn1;

namespace DuAn1_QLThuVien
{
    public partial class DoiMatKhau : Form
    {

        public DoiMatKhau(String USer)
        {
            InitializeComponent();
            label5.Text = USer;
        }

        private void button2_Click(object sender, EventArgs e)
        {
                TrangChu dn = new TrangChu(label5.Text);
                this.Hide();
                dn.ShowDialog();
                this.Close();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if(txt_TaiKhoan.Text == "" || txt_MatKhauCu.Text == ""|| txt_MatKhauMoi.Text ==""||txt_XacNhanMatKhau.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                    return;
                }
                if(txt_MatKhauMoi.Text != txt_XacNhanMatKhau.Text)
                {
                    MessageBox.Show("Vui lòng xác nhận mật khẩu mới", "Thông báo");
                    return;
                }
                string ht = string.Format(@"exec doimatkhau '{0}', '{1}','{2}'", txt_TaiKhoan.Text, DBHandler.toMD5(txt_MatKhauCu.Text), DBHandler.toMD5(txt_MatKhauMoi.Text));
                SqlConnection myConn = new SqlConnection(@"Data Source=DESKTOP-NBH;Initial Catalog=QLThuVien;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(ht);
                myConn.Open();
                cmd.Connection = myConn;
                SqlDataReader dtr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dtr);
                myConn.Close();
                MessageBox.Show("Mật khẩu đã được cập nhật","Thông báo");
                txt_TaiKhoan.Text = "";
                txt_MatKhauCu.Text = "";
                txt_MatKhauMoi.Text = "";
                txt_XacNhanMatKhau.Text = "";
            }
            catch
            {

            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txt_MatKhauCu.PasswordChar = '\0';
                txt_MatKhauMoi.PasswordChar = '\0';
                txt_XacNhanMatKhau.PasswordChar = '\0';
            }
            else
            {
                txt_MatKhauCu.PasswordChar = '*';
                txt_MatKhauMoi.PasswordChar = '*';
                txt_XacNhanMatKhau.PasswordChar = '*';
            }
        }
    }
}
