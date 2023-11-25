using System;
using DuAn1;
using DuAn1_QLThuVien;
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

            btThemNV.Enabled = false;
            txtMaNV.ReadOnly = true;
            btCapNhatNV.Enabled = true;
            btXoaNV.Enabled = true;
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu tc = new TrangChu();
            this.Hide();
            tc.ShowDialog();
            this.Close();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtHoTenNV.Text = "";
            cbbxGioiTinh.Text = "";
            txtNgaySinhNV.Text = "";
            txtEmailNV.Text = "";
            txtSoDT.Text = "";
            txtNgayVaoLam.Text = "";
            txtGhiChuNV.Text = "";

            btThemNV.Enabled = true;
            txtMaNV.ReadOnly = false;
            btCapNhatNV.Enabled = false;
            btXoaNV.Enabled = false;
        }

        private void btThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.Text != "" && txtHoTenNV.Text != "" && cbbxGioiTinh.Text == ""
                    && txtNgaySinhNV.Text != "" && txtSoDT.Text != "" && txtEmailNV.Text != ""
                    && txtNgayVaoLam.Text != "" && txtGhiChuNV.Text != "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thêm thất bại");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            this.Hide();
            dmk.ShowDialog();
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            this.Hide();
            dn.ShowDialog();
            this.Close();
        }

        private void kếtThúcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult close = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thoát ứng dụng", MessageBoxButtons.YesNo);
        }

        private void quảnLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNhanVien qlnv = new QLNhanVien();
            this.Hide();
            qlnv.ShowDialog();
            this.Close();
        }

        private void quảnLýNgườiMượnSáchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QL_NguoiMuonSach nms = new QL_NguoiMuonSach();
            this.Hide();
            nms.ShowDialog();
            this.Close();
        }

        private void quảnLýNgườiMượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLSach qls = new QLSach();
            this.Hide();
            qls.ShowDialog();
            this.Close();
        }

        private void quảnLýThẻHộiViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLTheHoiVien thv = new QLTheHoiVien();
            this.Hide();
            thv.ShowDialog();
            this.Close();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
