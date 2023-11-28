using DuAn1_QLThuVien;
using QLThuVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn1
{
    public partial class QLSach : Form
    {
        public QLSach()
        {
            InitializeComponent();
        }
        private void TrangChu_Click(object sender, EventArgs e)
        {
            TrangChu trang = new TrangChu();
            this.Hide();
            trang.ShowDialog();
            this.Close();

        }
        private void DangXuat_Click(object sender, EventArgs e)
        {
            DangNhap form1 = new DangNhap();
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }
        private void QLKhoSach_Click(object sender, EventArgs e)
        {
            QLSach sach = new QLSach();
            this.Hide();
            sach.ShowDialog();
            this.Close();
        }
        private void QlNhanVien_Click(object sender, EventArgs e)
        {
            QLNhanVien nv = new QLNhanVien();
            this.Hide();
            nv.ShowDialog();
            this.Close();
        }

        private void DoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            this.Hide();
            dmk.ShowDialog();
            this.Close();
        }
        private void QLnguoiMuonSach_Click(Object sender, EventArgs e)
        {
            QL_NguoiMuonSach nguoiMuonSach = new QL_NguoiMuonSach();
            this.Hide();
            nguoiMuonSach.ShowDialog();
            this.Close();
        }
        private void QLTHongke_Click(object sender, EventArgs e)
        {
            QLThongKe qLThongKe = new QLThongKe();
            this.Hide();
            qLThongKe.ShowDialog();
            this.Close();
        }
         
        private void QLTHV_Click(object sender, EventArgs e)
        {
            QLTheHoiVien qLTheHoiVien = new QLTheHoiVien();
            this.Hide();
            qLTheHoiVien.ShowDialog();
            this.Close();
        }
        private void Thoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Load_tblGridView()
        {
            string connString = @"Data Source = DESKTOP-DPRU2H9; Initial Catalog = QLThuVien; Integrated security = SSPI";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM Sach";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataGridView1.Rows.Clear();
                        while (dataReader.Read())
                        {
                            dataGridView1.Rows.Add(dataReader[0], dataReader[1], dataReader[2],
                                dataReader[3], dataReader[4], dataReader[5], dataReader[6], dataReader[7]);
                        }
                    }
                    conn.Close();

                }

            }
        }
        private void tblGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentRow.Index;
            cbbMaSach.Text = dataGridView1.Rows[currentRowIndex].Cells[0].Value.ToString();
            txtTenSach.Text = dataGridView1.Rows[currentRowIndex].Cells[1].Value.ToString();
            txtLoaiSach.Text = dataGridView1.Rows[currentRowIndex].Cells[2].Value.ToString();
            txtTacGia.Text = dataGridView1.Rows[currentRowIndex].Cells[3].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[currentRowIndex].Cells[4].Value.ToString();

            txtGiaMuon.Text = dataGridView1.Rows[currentRowIndex].Cells[5].Value.ToString();
            CbbMaV.Text = dataGridView1.Rows[currentRowIndex].Cells[7].Value.ToString();
            

        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DESKTOP-DPRU2H9; Initial Catalog = QLThuVien; Integrated security = SSPI";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM Sach WHERE MaSach = @MaSach";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@MaSach", txtTimKiem.Text.Trim());
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataGridView1.Rows.Clear();
                        while (dataReader.Read())
                        {
                            dataGridView1.Rows.Add(dataReader[0], dataReader[1], dataReader[2],
                               dataReader[3], dataReader[4], dataReader[5], dataReader[6], dataReader[7]);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"KHông tìm thấy MaSach = {txtTimKiem.Text.Trim()}", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conn.Close();
                }

            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string connString = @"Data Source = DESKTOP-DPRU2H9; Initial Catalog = QLThuVien; Integrated security = SSPI";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM Sach WHERE MaSach = @MaSach";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@MaSach", txtTimKiem.Text.Trim());
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataGridView1.Rows.Clear();
                        while (dataReader.Read())
                        {
                            dataGridView1.Rows.Add(dataReader[0], dataReader[1], dataReader[2],
                               dataReader[3], dataReader[4], dataReader[5], dataReader[6], dataReader[7]);
                        }
                    }
                    else if (txtTimKiem.Text.Trim() == string.Empty)
                    {
                        Load_tblGridView();
                    }
                    conn.Close();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DESKTOP-DPRU2H9; Initial Catalog = QLThuVien; Integrated security = SSPI";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string check_MaThe_Query = "SELECT COUNT(*) FROM TheHoiVien WHERE MaThe = @MaThe";
                string check_MaND_Query = "SELECT COUNT(*) FROM NguoiDoc WHERE MaND = @MaND";
                using (SqlCommand check_MaThe_Command = new SqlCommand(check_MaThe_Query, conn))
                {
                    using (SqlCommand check_MaND_Command = new SqlCommand(check_MaND_Query, conn))
                    {
                        check_MaThe_Command.Parameters.AddWithValue("@MaSach", cbbMaSach.Text.Trim());
                        check_MaND_Command.Parameters.AddWithValue("@MaNV", CbbMaV.Text.Trim());

                        int count = (int)check_MaThe_Command.ExecuteScalar();
                        int count2 = (int)check_MaND_Command.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show($"Mã sách: {cbbMaSach.Text} đã tồn tại! \n Vui lòng Nhập Mã sách khác", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (count2 == 0)
                        {
                            MessageBox.Show($"Người tạo: {CbbMaV.Text} không tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (txtLoaiSach .Text.Trim() == string.Empty || txtTenSach.Text.Trim() == string.Empty || txtTacGia.Text.Trim() == string.Empty || txtSoLuong.Text.Trim() == string.Empty || txtGiaMuon.Text.Trim() == string.Empty || PbHinh.Image == null)
                        {
                            MessageBox.Show("Vui lòng không để trống các thông tin!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            string insertQuery = "INSERT INTO TheHoiVien (MaSach, TenSach, LoaiSach, TenTacGia, HinhAnh, SoLuongTrongKho, GiaMuon, MaNV) " +
                                                     " VALUES (@MaSach, @TenSach, @LoaiSach, @TenTacGia, @HinhAnh, @SoLuongTrongKho, @GiaMuon, @MaNV)";                        
                            string Soluong = txtSoLuong.Text.Trim();
                            int number;
                            string Giamuon = txtGiaMuon.Text.Trim();
                            float number2;

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, conn))
                            {                        
                                if (!int.TryParse(Soluong, out number) || number < 0)
                                {
                                    MessageBox.Show("Vui lòng Nhập Số lượng bằng số! \n Số không được dưới 0", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                if (!float.TryParse(Giamuon, out number2) || number < 0)
                                {
                                    MessageBox.Show("Vui lòng Nhập Giá mượn bằng số! \n Số không được dưới 0", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    insertCommand.Parameters.AddWithValue("@MaSach", cbbMaSach.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@TenSach", txtTenSach.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@LoaiSach", txtLoaiSach.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@TenTacGia", txtTacGia.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@HinhAnh", );
                                    insertCommand.Parameters.AddWithValue("@SoLuongTrongKho", txtSoLuong.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@GiaMuon", txtGiaMuon.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@MaNV", CbbMaV.Text.Trim());
                                    insertCommand.ExecuteNonQuery();
                                    MessageBox.Show("Đang ký Thành Công");
                                    Load_tblGridView();

                                    conn.Close();
                                }

                            }
                        }
                    }

                }
            }
        }
        private void PbHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                PbHinh.Image = Image.FromFile(file);
                PbHinh.SizeMode = PictureBoxSizeMode.StretchImage;
                PbHinh.Tag = file;
            }
        }
    }
}
