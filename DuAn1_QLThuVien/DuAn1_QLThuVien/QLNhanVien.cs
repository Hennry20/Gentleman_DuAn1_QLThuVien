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

namespace QLThuVien
{
    public partial class QLNhanVien : Form
    {
        SqlDataAdapter sda;
        DataSet ds = new DataSet();
        public QLNhanVien()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            String conn = @"Data Source=DESKTOP-NBH;Initial Catalog=QLThuVien;Integrated Security=True";
            String query = "select * from NhanVien";

            sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds, "NhanVien");
            dtgvQLNhanVien.DataSource = ds.Tables["NhanVien"];
            btCapNhatNV.Enabled = false;
            btXoaNV.Enabled = false;
        }

        private void dtgvQLNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvQLNhanVien.CurrentRow.Index;

            txtMaNV.Text = dtgvQLNhanVien.Rows[i].Cells[0].Value.ToString();
            txtHoTenNV.Text = dtgvQLNhanVien.Rows[i].Cells[1].Value.ToString();
            cbbxGioiTinh.Text = dtgvQLNhanVien.Rows[i].Cells[2].Value.ToString();
            txtNgaySinhNV.Text = dtgvQLNhanVien.Rows[i].Cells[3].Value.ToString();
            txtSoDT.Text = dtgvQLNhanVien.Rows[i].Cells[4].Value.ToString();
            txtEmailNV.Text = dtgvQLNhanVien.Rows[i].Cells[5].Value.ToString();

            txtGhiChuNV.Text = dtgvQLNhanVien.Rows[i].Cells[7].Value.ToString();

            var img = dtgvQLNhanVien.Rows[e.RowIndex].Cells[HinhAnh.Index].Value.ToString();
            fileChooser.Image = Image.FromFile(@"" + img);
            fileChooser.SizeMode = PictureBoxSizeMode.StretchImage;
            fileChooser.Tag = img;

            btThemNV.Enabled = false;
            txtMaNV.ReadOnly = true;
            btCapNhatNV.Enabled = true;
            btXoaNV.Enabled = true;
        }
    }
}
