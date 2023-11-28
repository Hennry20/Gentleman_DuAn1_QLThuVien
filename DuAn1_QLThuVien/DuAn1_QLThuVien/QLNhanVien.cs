using DuAn1;
using DuAn1_QLThuVien;
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
        DataSet ds = new DataSet();
        SqlDataAdapter sda;
        public QLNhanVien()
        {
            InitializeComponent();
        }
        
        

        private void Form1_Load(object sender, EventArgs e)
        {
            String conn = @"Data Source=.;Initial Catalog=QlThuVien;Integrated security=SSPI";
            String query = "SELECT * from NhanVien";

            sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds, "NhanVien");
            dtgvQLNhanVien.DataSource = ds.Tables["NhanVien"];
        }

        private void btThemNV_Click(object sender, EventArgs e)
        {
            DataRow data = ds.Tables["NhanVien"].NewRow();
            data["MaNV"] = txtMaNV.Text;
            data["TenNV"] = txtHoTenNV.Text;
            data["GioiTinh"] = cbbxGioiTinh.Text;
            data["NgaySinh"] = txtNgaySinhNV.Text;
            data["SDT"] = txtSoDT.Text;
            data["Email"] = txtEmailNV.Text;
            data["NgayVaoLam"] = txtNgayVaoLam.Text;
            ds.Tables["NhanVien"].Rows.Add(data);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.Update(ds.Tables["NhanVien"]);
            MessageBox.Show("Đã thêm thành công!", "Thông báo");
        }

        private void btCapNhatNV_Click(object sender, EventArgs e)
        {
            int i = dtgvQLNhanVien.CurrentRow.Index;
            DataRow row = ds.Tables["NhanVien"].Rows[i];
            row.BeginEdit();
            row["TenNV"] = txtHoTenNV.Text;
            row["GioiTinh"] = cbbxGioiTinh.SelectedItem;
            
            row.EndEdit();

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
            txtNgayVaoLam.Text = dtgvQLNhanVien.Rows[i].Cells[7].Value.ToString();
            txtGhiChuNV.Text = dtgvQLNhanVien.Rows[i].Cells[8].Value.ToString();
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu tc = new TrangChu("");
            this.Hide();
            tc.ShowDialog();
            this.Close();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            this.Hide();
            dmk.ShowDialog();
            this.Close();
        }
    }
}
