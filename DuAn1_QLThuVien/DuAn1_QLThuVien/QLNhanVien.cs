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
using System.Globalization;

namespace QLThuVien
{
    public partial class QLNhanVien : Form
    {
        List<NhanVien> dsNhanVien;
        SqlDataAdapter sda;
        DataSet ds = new DataSet();
        public QLNhanVien()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            String conn = @"Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True";
            String query = "select * from NhanVien";

            sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds, "NhanVien");
            dtgvQLNhanVien.DataSource = ds.Tables["NhanVien"];
            //btCapNhatNV.Enabled = false;
            //btXoaNV.Enabled = false;
        }

        private void dtgvQLNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = dtgvQLNhanVien.CurrentRow.Index;

                txtMaNV.Text = dtgvQLNhanVien.Rows[i].Cells[0].Value.ToString();
                txtTenDN.Text = dtgvQLNhanVien.Rows[i].Cells[1].Value.ToString();
                txtHoTenNV.Text = dtgvQLNhanVien.Rows[i].Cells[2].Value.ToString();
                cbbxGioiTinh.Text = dtgvQLNhanVien.Rows[i].Cells[3].Value.ToString();
                txtNgaySinhNV.Text = dtgvQLNhanVien.Rows[i].Cells[4].Value.ToString();
                txtSoDT.Text = dtgvQLNhanVien.Rows[i].Cells[5].Value.ToString();
                txtEmailNV.Text = dtgvQLNhanVien.Rows[i].Cells[6].Value.ToString();
                
                txtNgayVaoLam.Text = dtgvQLNhanVien.Rows[i].Cells[8].Value.ToString();
                txtGhiChuNV.Text = dtgvQLNhanVien.Rows[i].Cells[9].Value.ToString();

                var image = dtgvQLNhanVien.Rows[i].Cells[7].Value.ToString();
                ptbAnhNV.Image = Image.FromFile(@"" + image);
                ptbAnhNV.SizeMode = PictureBoxSizeMode.StretchImage;
                ptbAnhNV.Tag = image;
                
                
                btThemNV.Enabled = false;
                txtMaNV.ReadOnly = true;
                btCapNhatNV.Enabled = true;
                btXoaNV.Enabled = true;
            }
            catch (Exception)
            {

                return;
            }
        }

        private void CapNhapDTGVNV()
        {
            try
            {
                dsNhanVien = DBHandler.getListNhanVien();
                dtgvQLNhanVien.Rows.Clear();
                dsNhanVien.ForEach(row => dtgvQLNhanVien.Rows.Add(
                        row.MaNV,
                        row.TenDangNhap,
                        row.TenNV,
                        row.GioiTinh,
                        row.NgaySinh,
                        row.SDT,
                        row.Email,
                        row.HinhAnh.ToString(),
                        row.NgayVaoLam,
                        row.GhiChu
                ));
                dtgvQLNhanVien.Update();
            }
            catch (Exception)
            {

                return;
            }
        }
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu tc = new TrangChu("");
            this.Hide();
            tc.ShowDialog();
            this.Close();
        }
        
        private void btReset_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtTenDN.Text = "";
            txtHoTenNV.Text = "";
            cbbxGioiTinh.Text = "";
            txtNgaySinhNV.Text = "";
            txtEmailNV.Text = "";
            txtSoDT.Text = "";
            ptbAnhNV.Image = null;
            txtNgayVaoLam.Text = "";
            txtGhiChuNV.Text = "";
            txtTimKiemNV.Text = "";

            btThemNV.Enabled = true;
            txtMaNV.ReadOnly = false;
            btCapNhatNV.Enabled = false;
            btXoaNV.Enabled = false;
        }

        private void btThemNV_Click(object sender, EventArgs e)
        {
                if (txtMaNV.Text == "" && txtTenDN.Text == "" && txtHoTenNV.Text == "" && cbbxGioiTinh.Text == "" && txtNgaySinhNV.Text == ""
                && txtSoDT.Text == "" && txtEmailNV.Text == "" && ptbAnhNV.Image == null && txtNgayVaoLam.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                    return;
                }
                else if (DBHandler.IsEmail(txtEmailNV.Text.Trim()) != true)
                {
                    MessageBox.Show("Email không hợp lệ, vui lòng nhập lại!", "Thông báo");
                    return;
                }
                else if (txtSoDT.Text.Length > 10)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ, vui lòng nhập lại!", "Thông báo");
                    return;
                }

                DataRow data = ds.Tables["NhanVien"].NewRow();
                data["MaNV"] = txtMaNV.Text;
                data["TenDangNhap"] = txtTenDN.Text;
                data["TenNV"] = txtHoTenNV.Text;
                data["GioiTinh"] = cbbxGioiTinh.SelectedItem;
                data["NgaySinh"] = txtNgaySinhNV.Text;
                data["SDT"] = txtSoDT.Text;
                data["Email"] = txtEmailNV.Text;
                data["HinhAnh"] = ptbAnhNV.Tag.ToString();
                data["NgayVaoLam"] = txtNgayVaoLam.Text;
                data["GhiChu"] = txtGhiChuNV.Text;

                ds.Tables["NhanVien"].Rows.Add(data);
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                sda.Update(ds.Tables["NhanVien"]);
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo");
                this.CapNhapDTGVNV();
        }

        private void btCapNhatNV_Click(object sender, EventArgs e)
        {
                if (txtMaNV.Text == "" && txtTenDN.Text == "" && txtHoTenNV.Text == "" && cbbxGioiTinh.Text == "" && txtNgaySinhNV.Text == ""
                    && txtSoDT.Text == "" && txtEmailNV.Text == "" && ptbAnhNV.Image == null && txtNgayVaoLam.Text == "")
                {
                    MessageBox.Show("Vui lòng cập nhật đầy đủ thông tin!", "Thông báo");
                    return;
                }
                if (DBHandler.IsEmail(txtEmailNV.Text.Trim()) != true)
                {
                    MessageBox.Show("Email không hợp lệ, vui lòng cập nhập lại!", "Thông báo");
                    return;
                }

                QLNhanVien nv = new QLNhanVien();
                int i = dtgvQLNhanVien.CurrentRow.Index;
                DataRow row = ds.Tables["NhanVien"].Rows[i];
                row.BeginEdit();
                row["MaNV"] = txtMaNV.Text;
                row["TenDangNhap"] = txtTenDN.Text;
                row["TenNV"] = txtHoTenNV.Text;
                row["GioiTinh"] = cbbxGioiTinh.SelectedItem;
                row["NgaySinh"] = txtNgaySinhNV.Text;
                row["SDT"] = txtSoDT.Text;
                row["Email"] = txtEmailNV.Text;
                row["HinhAnh"] = ptbAnhNV.Tag.ToString();
                row["NgayVaoLam"] = txtNgayVaoLam.Text;
                row["GhiChu"] = txtGhiChuNV.Text;

                row.EndEdit();
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                sda.Update(ds.Tables["NhanVien"]);
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                this.CapNhapDTGVNV();
        }

        private void btXoaNV_Click(object sender, EventArgs e)
        {
            DialogResult xoa = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo);
            if (xoa == DialogResult.Yes)
            {
                DataRow[] found = ds.Tables["NhanVien"].Select("MaNV = '" + txtMaNV.Text + "'");
                if (found.Length > 0)
                {
                    int index = ds.Tables["NhanVien"].Rows.IndexOf(found[0]);
                    ds.Tables["NhanVien"].Rows[index].Delete();
                }
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                sda.Update(ds.Tables["NhanVien"]);
                MessageBox.Show("Xóa thông tin thành công!", "Thông báo");
                this.CapNhapDTGVNV();

                txtMaNV.Text = "";
                txtTenDN.Text = "";
                txtHoTenNV.Text = "";
                cbbxGioiTinh.Text = "";
                txtNgaySinhNV.Text = "";
                txtSoDT.Text = "";
                txtEmailNV.Text = "";
                ptbAnhNV.Image = null;
                txtNgayVaoLam.Text = "";
                txtGhiChuNV.Text = "";

            }
        }

        private void btTimKiemNV_Click(object sender, EventArgs e)
        {
            string ht = string.Format(@"exec TimKiemNV '{0}'", txtTimKiemNV.Text);
            SqlConnection myConn = new SqlConnection(@"Data Source=DESKTOP-NBH;Initial Catalog=QLThuVien;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(ht);
            myConn.Open();
            cmd.Connection = myConn;
            SqlDataReader dtr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dtr);
            dtgvQLNhanVien.DataSource = dt;
            myConn.Close();
        }

        private void ptbAnhNV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                ptbAnhNV.Image = Image.FromFile(file);
                ptbAnhNV.SizeMode = PictureBoxSizeMode.StretchImage;
                ptbAnhNV.Tag = file;
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
            if (close == DialogResult.Yes)
            {
                Close();
            }
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
            QLThongKe tk = new QLThongKe();
            this.Hide();
            tk.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TrangChu tc = new TrangChu("");
            this.Hide();
            tc.ShowDialog();
            this.Close();
        }

        private void đăngKíThẻHộiViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
