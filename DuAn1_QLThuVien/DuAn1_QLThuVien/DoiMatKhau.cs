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
                    MessageBox.Show("Vui long nhap day du thong tin", "Thong bao");
                    return;
                }
                if(txt_MatKhauMoi.Text != txt_XacNhanMatKhau.Text)
                {
                    MessageBox.Show("Vui long xac nhan mat khau moi", "Thong bao");
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
                MessageBox.Show("Mat khau da duoc cap nhat","Thong bao");
            }
            catch
            {

            }
            
        }
    }
}
