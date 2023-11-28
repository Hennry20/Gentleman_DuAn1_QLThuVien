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
<<<<<<< HEAD
        List<NhanVien> dsNhanVien;
        SqlDataAdapter sda;
        DataSet ds = new DataSet();
        String imagePath;
=======
        DataSet ds = new DataSet();
        SqlDataAdapter sda;
>>>>>>> parent of ca8bd31 (Sua Form DangNhap)
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
<<<<<<< HEAD
            btCapNhatNV.Enabled = false;
            btXoaNV.Enabled = false;
=======
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

>>>>>>> parent of ca8bd31 (Sua Form DangNhap)
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
            txtGhiChuNV.Text = dtgvQLNhanVien.Rows[i].Cells[8].Value.ToString();
<<<<<<< HEAD

            //int selectRowIndex = dtgvQLNhanVien.SelectedCells[6].RowIndex;
            //NhanVien nv = dsNhanVien[selectRowIndex];
            //if (!String.IsNullOrEmpty(selectRowIndex.ToString()))
            //{
            //    ptbAnhNV.Image = Image.FromFile(@"" + selectRowIndex.ToString());
            //}
            //else
            //{
            //    ptbAnhNV.Image = null;
            //}

            btThemNV.Enabled = false;
            txtMaNV.ReadOnly = true;
            btCapNhatNV.Enabled = true;
            btXoaNV.Enabled = true;
=======
>>>>>>> parent of ca8bd31 (Sua Form DangNhap)
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
                if (txtMaNV.Text == "" || txtHoTenNV.Text == "" || cbbxGioiTinh.Text == ""
                    || txtNgaySinhNV.Text == "" && txtSoDT.Text == "" || txtEmailNV.Text == ""
                    || txtNgayVaoLam.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                    return;
                }
                if (DBHandler.IsEmail(txtEmailNV.Text.Trim()) != true)
                {
                    MessageBox.Show("Email không hợp lệ, vui lòng nhập lại!", "Thông báo");
                    return;
                }
                if (txtSoDT.Text.Length > 10)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ, vui lòng nhập lại!", "Thông báo");
                    return;
                }
                DataRow data = ds.Tables["NhanVien"].NewRow();
                data["MaNV"] = txtMaNV.Text;
                data["TenNV"] = txtHoTenNV.Text;
                data["GioiTinh"] = cbbxGioiTinh.SelectedItem;
                data["NgaySinh"] = txtNgaySinhNV.Text;
                data["SDT"] = txtSoDT.Text;
                data["Email"] = txtEmailNV.Text;
                data["HinhAnh"] = ptbAnhNV.Image;
                data["NgayVaoLam"] = txtNgayVaoLam.Text;
                data["GhiChu"] = txtGhiChuNV.Text;

                ds.Tables["NhanVien"].Rows.Add(data);
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                sda.Update(ds.Tables["NhanVien"]);
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo");
            }
            catch (Exception)
            {
                
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            this.Hide();
            dmk.ShowDialog();
            this.Close();
        }
<<<<<<< HEAD

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
            TrangChu tc = new TrangChu();
            this.Hide();
            tc.ShowDialog();
            this.Close();
        }

        private void đăngKíThẻHộiViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btCapNhatNV_Click(object sender, EventArgs e)
        {
            QLNhanVien nv = new QLNhanVien();
            int i = dtgvQLNhanVien.CurrentRow.Index;
            DataRow row = ds.Tables["NhanVien"].Rows[i];
            row.BeginEdit();
            row["MaNV"] = txtMaNV.Text;
            row["TenNV"] = txtHoTenNV.Text;
            row["GioiTinh"] = cbbxGioiTinh.SelectedItem;
            row["NgaySinh"] = txtNgaySinhNV.Text;
            row["SDT"] = txtSoDT.Text;
            row["Email"] = txtEmailNV.Text;
            //row["HinhAnh"] = ptbAnhNV.Image;
            row["NgayVaoLam"] = txtNgayVaoLam.Text;
            row["GhiChu"] = txtGhiChuNV.Text;

            if (txtMaNV.Text == "" || txtHoTenNV.Text == "" || cbbxGioiTinh.Text == ""
                || txtNgaySinhNV.Text == "" && txtSoDT.Text == "" || txtEmailNV.Text == ""
                || txtNgayVaoLam.Text == "")
            {
                MessageBox.Show("Vui lòng cập nhật đầy đủ thông tin!", "Thông báo");
                return;
            }
            if (DBHandler.IsEmail(txtEmailNV.Text.Trim()) != true)
            {
                MessageBox.Show("Email không hợp lệ, vui lòng cập nhập lại!", "Thông báo");
                return;
            }

            row.EndEdit();
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.Update(ds.Tables["NhanVien"]);
            MessageBox.Show("Cập nhật thành công!", "Thông báo");
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

                txtMaNV.Text = "";
                txtHoTenNV.Text = "";
                cbbxGioiTinh.Text = "";
                txtNgaySinhNV.Text = "";
                txtEmailNV.Text = "";
                txtSoDT.Text = "";
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
            openFileDialog.InitialDirectory = "D:\\";
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                ptbAnhNV.Image = Image.FromFile(@"" + imagePath);
            }
        }
=======
>>>>>>> parent of ca8bd31 (Sua Form DangNhap)
    }
}
