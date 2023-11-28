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

namespace DuAn1_QLThuVien
{
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult quit = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (quit == DialogResult.Yes)
            {
                DangNhap dn = new DangNhap();
                this.Hide();
                dn.ShowDialog();
                this.Close();
            }
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
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi nhập liệu",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                if(txt_MatKhauMoi.Text != txt_XacNhanMatKhau.Text)
                {
                    MessageBox.Show("Mật khẩu không trùng khớp", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Mật khẩu hoặc tài khoản không chính xác", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string ht = string.Format(@"exec doimatkhau '{0}', '{1}','{2}'", txt_TaiKhoan.Text, txt_MatKhauCu.Text, txt_MatKhauMoi.Text);
                SqlConnection myConn = new SqlConnection(@"Data Source=.;Initial Catalog=QLThuVien;Integrated security=SSPI");
                SqlCommand cmd = new SqlCommand(ht);
                myConn.Open();
                cmd.Connection = myConn;
                SqlDataReader dtr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dtr);
                myConn.Close();
                MessageBox.Show("Mật khẩu đã được cập nhật","Thông báo");
            }
            catch
            {

            }
            
        }

        private void cbk_HienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbk_HienThiMK.Checked == true)
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
