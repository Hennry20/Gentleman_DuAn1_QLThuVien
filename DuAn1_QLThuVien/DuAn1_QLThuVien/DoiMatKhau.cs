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
                this.Close();
            }
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            //SqlConnection myConn = new SqlConnection(@"Data Source=.;Initial Catalog=QLThuVien;Integrated security=SSPI");
            //SqlCommand cmd = new SqlCommand();
            //myConn.Open();
            //cmd.Connection = myConn;
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            //string ht = string.Format(@"exec doimatkhau '{0}', '{1}'", txt_TaiKhoan.Text, txt_MatKhauCu.Text);
            //SqlConnection myConn = new SqlConnection(@"Data Source=.;Initial Catalog=QLThuVien;Integrated security=SSPI");
            //SqlCommand cmd = new SqlCommand(ht);
            //myConn.Open();
            //cmd.Connection = myConn;
            //SqlDataReader dtr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dtr);
            //myConn.Close();
        }
    }
}
