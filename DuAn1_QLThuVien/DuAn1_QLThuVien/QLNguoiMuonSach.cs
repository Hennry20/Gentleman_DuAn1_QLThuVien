using DuAn1_QLThuVien;
using QLThuVien;
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

namespace DuAn1
{
    public partial class QL_NguoiMuonSach : Form
    {
        public QL_NguoiMuonSach()
        {
            InitializeComponent();

            load_dtgvQLMuonSach();

            load_dtgvQLTraSach();
        }
        private void QL_NguoiMuonSach_Load(object sender, EventArgs e)
        {
            load_dtgvQLMuonSach();
            load_MaND();
            load_MaSach();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi trang này?", "Lỗi khi thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void lblQLMSTenTacGia_Click(object sender, EventArgs e)
        {

        }

        private void QL_NguoiMuonSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dl = MessageBox.Show("Bạn có muốn đóng phần mềm không?", "Lưu ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dl == DialogResult.No)
            //    e.Cancel = true;
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu trang = new TrangChu();
            this.Hide();
            trang.ShowDialog();
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap form1 = new DangNhap();
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            this.Hide();
            dmk.ShowDialog();
            this.Close();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNhanVien nv = new QLNhanVien();
            this.Hide();
            nv.ShowDialog();
            this.Close();
        }

        private void quảnLýKhoSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLSach sach = new QLSach();
            this.Hide();
            sach.ShowDialog();
            this.Close();
        }

        private void quảnLýNgườiMượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QL_NguoiMuonSach nguoiMuonSach = new QL_NguoiMuonSach();
            this.Hide();
            nguoiMuonSach.ShowDialog();
            this.Close();
        }

        private void quảnLýThẻHộiViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLTheHoiVien qLTheHoiVien = new QLTheHoiVien();
            this.Hide();
            qLTheHoiVien.ShowDialog();
            this.Close();
        }
        private void đăngKýHộiViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLTheHoiVien qLTheHoiVien = new QLTheHoiVien();
            this.Hide();
            qLTheHoiVien.ShowDialog();
            this.Close();
        }
        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLThongKe qLThongKe = new QLThongKe();
            this.Hide();
            qLThongKe.ShowDialog();
            this.Close();
        }
        private void load_dtgvQLMuonSach()
        {
            string connString = @"Data Source=DESKTOP-NBH;Initial Catalog=QLThuVien;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM PhieuMuon";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dtgvQLMuonSach.Rows.Clear();
                        while (dataReader.Read())
                        {
                            dtgvQLMuonSach.Rows.Add(dataReader[0], dataReader[1], dataReader[2],
                                dataReader[3], dataReader[4], dataReader[5], dataReader[6], dataReader[7].ToString().Split(' ')[0], dataReader[8].ToString().Split(' ')[0]);
                        }
                    }
                    conn.Close();
                }
            }
        }

        private void dtgvQLMuonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dtgvQLMuonSach.CurrentRow.Index;
            txtQLMSMaPhieuMuon.Text = dtgvQLMuonSach.Rows[currentRowIndex].Cells[0].Value.ToString();
            cbQLMSMaNguoiDoc.Text = dtgvQLMuonSach.Rows[currentRowIndex].Cells[1].Value.ToString();
            txtTenNguoiDoc.Text = dtgvQLMuonSach.Rows[currentRowIndex].Cells[2].Value.ToString();
            cbQLMSMaSach2.Text = dtgvQLMuonSach.Rows[currentRowIndex].Cells[3].Value.ToString();
            txtQLMSSoLuong.Text = dtgvQLMuonSach.Rows[currentRowIndex].Cells[4].Value.ToString();
            dtpQLMSNgayMuon.Text = dtgvQLMuonSach.Rows[currentRowIndex].Cells[5].Value.ToString();
            dtpQLMSNgayHenTra.Text = dtgvQLMuonSach.Rows[currentRowIndex].Cells[6].Value.ToString();
            txtQLMSTienCoc.Text = dtgvQLMuonSach.Rows[currentRowIndex].Cells[7].Value.ToString();
            txtQLMSSoGioMuon.Text = dtgvQLMuonSach.Rows[currentRowIndex].Cells[8].Value.ToString();
        }
        public void load_MaND()
        {
            string connectionString = @"Data Source=HUYNHQUYTRUONG;Initial Catalog=QLThuVien;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DanhSach_MaND", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cbQLMSMaNguoiDoc.Items.Add(reader["MaND"].ToString());
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
            string connString = @"Data Source=DESKTOP-NBH;Initial Catalog=QLThuVien;Integrated Security=True";
            using(SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM PhieuTra";
                using(SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dtgvQLTraSach.Rows.Clear();
                        if (dataReader.Read())
                        {
                            dtgvQLTraSach.Rows.Add(dataReader[0], dataReader[1], dataReader[2], dataReader[3], dataReader[4], dataReader[5].ToString().Split(' ')[0],
                                dataReader[6], dataReader[7], dataReader[8]);
                        }
                    }
                    conn.Close();
                }
            }
        }

        private void dtgvQLTraSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currenRowIndex = dtgvQLTraSach.CurrentRow.Index;
            txtQLTSMaPhieuTra.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[0].Value.ToString();
            txtQLTSMaPhieuMuon.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[1].Value.ToString();
            cbQLTSMaNguoiDoc.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[2].Value.ToString();
            txtQLTSTenNguoiDoc.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[3].Value.ToString();
            txtQLTSSLMuon.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[4].Value.ToString();
            dtpQLTSNgayTra.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[5].Value.ToString();
            txtQLTSPhiTra.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[6].Value.ToString();
            txtQLTSTinhTrang.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[7].Value.ToString();
            txtQLTSSoGioTra.Text = dtgvQLTraSach.Rows[currenRowIndex].Cells[8].Value.ToString();
        }
        public void load_MaSach()
        {
            string connectionString = @"Data Source=DESKTOP-NBH;Initial Catalog=QLThuVien;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DanhSach_MaSach", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cbQLMSMaSach2.Items.Add(reader["MaSach"].ToString());
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
        

        private void cbQLMSMaSach1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            load_dtgvQLMuonSach();
            txtQLMSMaPhieuMuon.Text = string.Empty;
            cbQLMSMaNguoiDoc.Text = string.Empty;
            txtTenNguoiDoc.Text = string.Empty;
            cbQLMSMaSach2.Text = string.Empty;
            txtQLMSSoLuong.Text = string.Empty;
            dtpQLMSNgayMuon.Text = string.Empty;
            dtpQLMSNgayHenTra.Text = string.Empty;
            txtQLMSTienCoc.Text = string.Empty;
            txtQLMSSoGioMuon.Text = string.Empty;
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi trang này?", "Lỗi khi thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                TrangChu trangChu = new TrangChu();
                this.Hide();
                trangChu.ShowDialog();
                this.Close();
            }
            
        }

        private void btnChoMuon_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=DESKTOP-NBH;Initial Catalog=QLThuVien;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string check_PhieuMuon_Query = "SELECT COUNT(*) FROM PhieuMuon WHERE MaPhieuMuon = @MaPhieuMuon";
                string check_MaND_Query = "SELECT COUNT(*) FROM NguoiDoc WHERE MaND = @MaND";

                using (SqlCommand check_PhieuMuon_Command = new SqlCommand(check_PhieuMuon_Query, conn))
                {
                    using (SqlCommand check_MaND_Command = new SqlCommand(check_MaND_Query, conn))
                    {
                        check_PhieuMuon_Command.Parameters.AddWithValue("@MaPhieuMuon", txtQLMSMaPhieuMuon.Text.Trim());
                        check_MaND_Command.Parameters.AddWithValue("@MaND", cbQLMSMaNguoiDoc.Text.Trim());

                        int count = (int)check_PhieuMuon_Command.ExecuteScalar();
                        int count2 = (int)check_MaND_Command.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show($"Mã phiếu mượn: {txtQLMSMaPhieuMuon.Text} đã tồn tại! \n Vui lòng Nhập Mã thẻ khác", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (count2 == 0)
                        {
                            MessageBox.Show($"Mã người đọc: {cbQLMSMaNguoiDoc.Text} không tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (cbQLMSMaNguoiDoc.Text.Trim() == string.Empty || txtTenNguoiDoc.Text.Trim() == string.Empty || cbQLMSMaSach2.Text.Trim() == string.Empty || txtQLMSSoLuong.Text.Trim() == string.Empty || dtpQLMSNgayMuon.Text.Trim() == string.Empty || dtpQLMSNgayHenTra.Text.Trim() == string.Empty || txtQLMSTienCoc.Text.Trim() == string.Empty || txtQLMSSoGioMuon.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Vui lòng không để trống các thông tin!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            string insertQuery = "INSERT INTO PhieuMuon (MaND, TenND, MaSach, SoLuong, NgayMuon, NgayTra, TienCoc, SoGio) " +
                                                     " VALUES (@MaND, @TenND, @MaSach, @SoLuong, @NgayMuon, @NgayTra, @TienCoc, @SoGio)";

                            string ngayMuon = dtpQLMSNgayMuon.Text.Trim();
                            DateTime ngMuon;
                            string ngayTra = dtpQLMSNgayHenTra.Text.Trim();
                            DateTime ngTra;
                            string SoLuongMuon = txtQLMSSoGioMuon.Text.Trim();
                            float number;

                            using (SqlCommand command = new SqlCommand(insertQuery, conn))
                            {
                                if (DateTime.TryParseExact(ngayMuon, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngMuon))
                                {
                                    command.Parameters.AddWithValue("@NgayMuon", ngMuon);
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
                                if (!float.TryParse(SoLuongMuon, out number) || number < 0)
                                {
                                    MessageBox.Show("Vui lòng nhập số lượng mượn bằng số! \n Số không được dưới 0", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                else
                                {
                                    ///command.Parameters.AddWithValue("@MaPhieuMuon", txtQLMSMaPhieuMuon.Text.Trim());
                                    command.Parameters.AddWithValue("@MaND", cbQLMSMaNguoiDoc.Text.Trim());
                                    command.Parameters.AddWithValue("@TenND", txtTenNguoiDoc.Text.Trim());
                                    command.Parameters.AddWithValue("@MaSach", cbQLMSMaSach2.Text.Trim());
                                    command.Parameters.AddWithValue("@SoLuong", txtQLMSSoLuong.Text.Trim());
                                    command.Parameters.AddWithValue("@TienCoc", txtQLMSTienCoc.Text.Trim());
                                    command.Parameters.AddWithValue("@SoGio", txtQLMSSoGioMuon.Text.Trim());
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Cho mượn thành công!");
                                    load_dtgvQLMuonSach();

                                    conn.Close();
                                }

                            }
                        }
                    }
                }
            }
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            load_dtgvQLTraSach();
            txtQLTSMaPhieuTra.Text = string.Empty;
            txtQLTSMaPhieuMuon.Text = string.Empty;
            cbQLTSMaNguoiDoc.Text = string.Empty;
            txtQLTSTenNguoiDoc.Text = string.Empty;
            txtQLTSSLMuon.Text = string.Empty;
            dtpQLTSNgayTra.Text = string.Empty;
            txtQLTSPhiTra.Text = string.Empty;
            txtQLTSTinhTrang.Text = string.Empty;
            txtQLTSSoGioTra.Text = string.Empty;
        }

        
    }
}
