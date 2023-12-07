using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using QLThuVien;
using DuAn1;

namespace DuAn1_QLThuVien
{
    public partial class QLNguoiTraSach : Form
    {
        public QLNguoiTraSach(String User)
        {
            InitializeComponent();
            label2.Text = User;
            load_dtgvQLTraSach();

        }
        private void QL_NguoiTraSach_Load(object sender, EventArgs e)
        {
            load_dtgvQLTraSach();
            load_MaND();
        }
        public void load_MaND()
        {
            string connectionString = @"Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DanhSach_MaND", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cbQLTSMaNguoiDoc.Items.Add(reader["MaND"].ToString());
                }

                reader.Close();
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                connection.Close();
            }
        }
        private void load_dtgvQLTraSach()
        {
            string connString = @"Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM PhieuTra";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    dtgvQLTraSach.Rows.Clear();
                    while (dataReader.Read()) 
                    {
                        dtgvQLTraSach.Rows.Add(
                            dataReader[0], dataReader[1], dataReader[2], dataReader[3], dataReader[4].ToString().Split(' ')[0],
                            dataReader[5].ToString().Split(' ')[0], dataReader[6], dataReader[7], dataReader[8]
                        );
                    }
                    conn.Close();
                }
            }
        }

        private void dtgvQLTraSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currenRowIndex = dtgvQLTraSach.CurrentRow.Index;
            try
            {
                lblQLTSMaPhieuTra.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[0].Value.ToString();
                txtQLTSMaPhieuMuon.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[1].Value.ToString();
                cbQLTSMaNguoiDoc.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[2].Value.ToString();
                txtQLTSSLMuon.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[3].Value.ToString();
                dtpQLTSNgayHenTra.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[4].Value.ToString();
                dtpQLTSNgayTra.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[5].Value.ToString();
                txtQLTSPhiTra.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[6].Value.ToString();
                lblTinhTrangTraSach.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[7].Value.ToString();
                txtQLTSSoGioTra.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[8].Value.ToString();
            }
            catch
            {
                return;
            }
        }


        private void TrangChuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu trang = new TrangChu(label2.Text);
            this.Hide();
            trang.ShowDialog();
            this.Close();
        }

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            this.Hide();
            dangNhap.ShowDialog();
            this.Close();
        }

        private void DoiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            this.Hide();
            dmk.ShowDialog();
            this.Close();
        }

        private void ThoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void QuanLyNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNhanVien nv = new QLNhanVien(label2.Text);
            this.Hide();
            nv.ShowDialog();
            this.Close();
        }

        private void QuanLyKhoSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLSach sach = new QLSach(label2.Text);
            this.Hide();
            sach.ShowDialog();
            this.Close();
        }

        private void QuanLyNMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QL_NguoiMuonSach nguoiMuonSach = new QL_NguoiMuonSach(label2.Text);
            this.Hide();
            nguoiMuonSach.ShowDialog();
            this.Close();
        }

        private void QuanLyNTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNguoiTraSach qLNguoiTraSach = new QLNguoiTraSach(label2.Text);
            this.Hide();
            qLNguoiTraSach.ShowDialog();
            this.Close();
        }

        private void QuanLyTHVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLTheHoiVien qLTheHoiVien = new QLTheHoiVien(label2.Text);
            this.Hide();
            qLTheHoiVien.ShowDialog();
            this.Close();
        }

        private void ThongKeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLThongKe qLThongKe = new QLThongKe(label2.Text);
            this.Hide();
            qLThongKe.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu(label2.Text);
            this.Hide();
            trangChu.ShowDialog();
            this.Close();
        }
        private void xoaMaPhieuTra(string maPTToDelete)
        {
            string connString = @"Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True";
            string deleteQuery = "DELETE FROM PhieuTra WHERE MaPhieuTra = @MaPhieuTra";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(deleteQuery, conn))
                {
                    command.Parameters.AddWithValue("@MaPhieuTra", maPTToDelete);
                    command.ExecuteNonQuery();
                    MessageBox.Show($"Xóa thành công!");
                    load_dtgvQLTraSach();
                    conn.Close();
                }
            }
        }

        private void btnQLTSMoi_Click_1(object sender, EventArgs e)
        {
            load_dtgvQLTraSach();
            cbQLTSMaNguoiDoc.Text = string.Empty;
            txtQLTSMaPhieuMuon.Text = string.Empty;
            lblQLTSMaPhieuTra.Text = string.Empty;
            txtQLTSSLMuon.Text = string.Empty;
            dtpQLTSNgayHenTra.Text = string.Empty;
            dtpQLTSNgayTra.Text = string.Empty;
            txtQLTSPhiTra.Text = string.Empty;
            txtQLTSSoGioTra.Text = string.Empty;
            lblTinhTrangTraSach.Text = string.Empty;
        }

        private void btnQLTSTraSach_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string check_PhieuMuon_Query = "SELECT COUNT(*) FROM PhieuMuon WHERE MaPhieuMuon = @MaPhieuMuon";
                string check_MaND_Query = "SELECT COUNT(*) FROM NguoiDoc WHERE MaND = @MaND";

                using (SqlCommand check_PhieuMuon_Command = new SqlCommand(check_PhieuMuon_Query, conn))
                {
                    using (SqlCommand check_MaND_Command = new SqlCommand(check_MaND_Query, conn))
                    {
                        check_PhieuMuon_Command.Parameters.AddWithValue("@MaPhieuMuon", txtQLTSMaPhieuMuon.Text.Trim());
                        check_MaND_Command.Parameters.AddWithValue("MaND", cbQLTSMaNguoiDoc.Text.Trim());

                        int count = (int)check_PhieuMuon_Command.ExecuteScalar();
                        int count2 = (int)check_MaND_Command.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show($"MaPhieuMuon: {txtQLTSMaPhieuMuon.Text} không tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (count2 == 0)
                        {
                            MessageBox.Show($"Mã người đọc: {cbQLTSMaNguoiDoc.Text} không tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (cbQLTSMaNguoiDoc.Text.Trim() == string.Empty || txtQLTSMaPhieuMuon.Text.Trim() == string.Empty || txtQLTSSLMuon.Text.Trim() == string.Empty || dtpQLTSNgayHenTra.Text.Trim() == string.Empty || dtpQLTSNgayTra.Text.Trim() == string.Empty || txtQLTSPhiTra.Text.Trim() == string.Empty || txtQLTSSoGioTra.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Vui lòng không để trống các thông tin!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            string insertQuery = "INSERT INTO PhieuTra(MaND, MaPhieuMuon, SoLuong, NgayHenTra, NgayTra, PhiTra, SoGio, TinhTrang) " +
                                                     " VALUES (@MaND, @MaPhieuMuon, @SoLuong, @NgayHenTra, @NgayTra, @PhiTra, @SoGio, @TinhTrang)";

                            string ngayHenTra = dtpQLTSNgayHenTra.Text.Trim();
                            DateTime ngHT;
                            string ngayTra = dtpQLTSNgayTra.Text.Trim();
                            DateTime ngTra;
                            string SoLuongMuon = txtQLTSSLMuon.Text.Trim();
                            float number;

                            using (SqlCommand command = new SqlCommand(insertQuery, conn))
                            {
                                if (DateTime.TryParseExact(ngayHenTra, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngHT))
                                {
                                    command.Parameters.AddWithValue("@NgayHenTra", ngHT);
                                }
                                else
                                {
                                    MessageBox.Show("Định dạng ngày tháng không hợp lệ. \nVui lòng nhập lại đúng định dạng \nNăm/tháng/ngày (dd/MM/yyyy)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (DateTime.TryParseExact(ngayTra, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngTra))
                                {
                                    command.Parameters.AddWithValue("@NgayTra", ngTra);
                                }
                                else
                                {
                                    MessageBox.Show("Định dạng ngày tháng không hợp lệ. \nVui lòng nhập lại đúng định dạng \nNăm/tháng/ngày (dd/MM/yyyy)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (ngTra <= ngHT)
                                {
                                    lblTinhTrangTraSach.Text = "Đúng hạn";
                                }
                                else
                                {
                                    lblTinhTrangTraSach.Text = "Quá hạn";
                                }
                                if (!float.TryParse(SoLuongMuon, out number) || number <= 0)
                                {
                                    MessageBox.Show("Vui lòng nhập số lượng mượn bằng số! \nSố không được dưới 0", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@MaND", cbQLTSMaNguoiDoc.Text.Trim());
                                    command.Parameters.AddWithValue("@MaPhieuMuon", txtQLTSMaPhieuMuon.Text.Trim());
                                    command.Parameters.AddWithValue("@SoLuong", txtQLTSSLMuon.Text.Trim());
                                    //command.Parameters.AddWithValue("@NgayHenTra", .Text.Trim());
                                    //command.Parameters.AddWithValue("@NgayTra", .Text.Trim());
                                    command.Parameters.AddWithValue("@PhiTra", txtQLTSPhiTra.Text.Trim());
                                    command.Parameters.AddWithValue("@SoGio", txtQLTSSoGioTra.Text.Trim());
                                    command.Parameters.AddWithValue("@TinhTrang", lblTinhTrangTraSach.Text.Trim());
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Trả sách thành công!");
                                    load_dtgvQLTraSach();
                                    conn.Close();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnQLTSCapNhat_Click_1(object sender, EventArgs e)
        {
            string connString = @"Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string check_PhieuMuon_Query = "SELECT COUNT(*) FROM PhieuMuon WHERE MaPhieuMuon = @MaPhieuMuon";
                string check_MaND_Query = "SELECT COUNT(*) FROM NguoiDoc WHERE MaND = @MaND";

                using (SqlCommand check_PhieuMuon_Command = new SqlCommand(check_PhieuMuon_Query, conn))
                {
                    using (SqlCommand check_MaND_Command = new SqlCommand(check_MaND_Query, conn))
                    {
                        check_PhieuMuon_Command.Parameters.AddWithValue("@MaPhieuMuon", txtQLTSMaPhieuMuon.Text.Trim());
                        check_MaND_Command.Parameters.AddWithValue("MaND", cbQLTSMaNguoiDoc.Text.Trim());

                        int count = (int)check_PhieuMuon_Command.ExecuteScalar();
                        int count2 = (int)check_MaND_Command.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show($"MaPhieuMuon: {txtQLTSMaPhieuMuon.Text} không tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        if (count2 == 0)
                        {
                            MessageBox.Show($"Mã người đọc: {cbQLTSMaNguoiDoc.Text} không tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        if (cbQLTSMaNguoiDoc.Text.Trim() == string.Empty || txtQLTSMaPhieuMuon.Text.Trim() == string.Empty || txtQLTSSLMuon.Text.Trim() == string.Empty || dtpQLTSNgayHenTra.Text.Trim() == string.Empty || dtpQLTSNgayTra.Text.Trim() == string.Empty || txtQLTSPhiTra.Text.Trim() == string.Empty || txtQLTSSoGioTra.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Vui lòng không để trống các thông tin!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            string UpDateQuery = "UPDATE PhieuTra SET MaND = @MaND, MaPhieuMuon = @MaPhieuMuon, SoLuong = @SoLuong, NgayHenTra = @NgayHenTra, NgayTra = @NgayTra, PhiTra = @PhiTra, SoGio = @SoGio WHERE MaPhieuTra = @MaPhieuTra";

                            string ngayHenTra = dtpQLTSNgayHenTra.Text.Trim();
                            DateTime ngHT;
                            string ngayTra = dtpQLTSNgayTra.Text.Trim();
                            DateTime ngTra;
                            string SoLuongMuon = txtQLTSSLMuon.Text.Trim();
                            float number;

                            using (SqlCommand command = new SqlCommand(UpDateQuery, conn))
                            {
                                if (DateTime.TryParseExact(ngayHenTra, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngHT))
                                {
                                    command.Parameters.AddWithValue("@NgayHenTra", ngHT);
                                }
                                else
                                {
                                    MessageBox.Show("Định dạng ngày tháng không hợp lệ. \nVui lòng nhập lại đúng định dạng \nNăm/tháng/ngày (dd/MM/yyyy)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (DateTime.TryParseExact(ngayTra, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngTra))
                                {
                                    command.Parameters.AddWithValue("@NgayTra", ngTra);
                                }
                                else
                                {
                                    MessageBox.Show("Định dạng ngày tháng không hợp lệ. \nVui lòng nhập lại đúng định dạng \nNăm/tháng/ngày (dd/MM/yyyy)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (!float.TryParse(SoLuongMuon, out number) || number <= 0)
                                {
                                    MessageBox.Show("Vui lòng nhập số lượng mượn bằng số! \nSố không được dưới 0", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@MaND", cbQLTSMaNguoiDoc.Text.Trim());
                                    command.Parameters.AddWithValue("@MaPhieuMuon", txtQLTSMaPhieuMuon.Text.Trim());
                                    command.Parameters.AddWithValue("@MaPhieuTra", lblQLTSMaPhieuTra.Text.Trim());
                                    command.Parameters.AddWithValue("@SoLuong", txtQLTSSLMuon.Text.Trim());
                                    command.Parameters.AddWithValue("@PhiTra", txtQLTSPhiTra.Text.Trim());
                                    command.Parameters.AddWithValue("@SoGio", txtQLTSSoGioTra.Text.Trim());
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Cập nhật Thành Công");
                                    load_dtgvQLTraSach();
                                    conn.Close();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnQLTSXoa_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa Mã phiếu trả = {lblQLTSMaPhieuTra.Text.Trim()} ?", "Xác nhận?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                string maPTToDelete = lblQLTSMaPhieuTra.Text.Trim();
                xoaMaPhieuTra(maPTToDelete);
            }
        }
    }
}
