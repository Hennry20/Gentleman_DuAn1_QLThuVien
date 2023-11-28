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
    public partial class DangKy : Form
    {
        SqlDataAdapter sda;
        DataSet ds = new DataSet();
        public DangKy()
        {
            InitializeComponent();
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            String conn = @"Data Source=.;Initial Catalog=QLThuVien;Integrated security=SSPI";
            String query = "SELECT * from TaiKhoan";
            sda = new SqlDataAdapter(query, conn);
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            using(QLThuVienEntities ql = new QLThuVienEntities())
            {
                TaiKhoan tk = new TaiKhoan();
                tk.TenDangNhap = txt_TaiKhoan.Text;
                tk.MatKhau = txt_MatKhau.Text;
            }
            //MessageBox.Show("Đã thêm thành công!", "Thông báo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult quit = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (quit == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
