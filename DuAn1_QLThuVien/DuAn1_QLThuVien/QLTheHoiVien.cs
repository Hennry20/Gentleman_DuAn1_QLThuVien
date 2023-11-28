using DuAn1;
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

namespace DuAn1_QLThuVien
{
    public partial class QLTheHoiVien : Form
    {
        public QLTheHoiVien()
        {
            InitializeComponent();
        }
        private void QLTheHoiVien_Load(object sender, EventArgs e)
        {
            Load_tblGridView();
            Load_MaThe();
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
        private void DKHV_Click(object sender, EventArgs e)
        {
            FormDangKyHV formDangKyHV = new FormDangKyHV();
            this.Hide();
            formDangKyHV.ShowDialog();
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
                string query = "SELECT * FROM TheHoiVien";
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
                                dataReader[3], dataReader[4].ToString().Split(' ')[0], dataReader[5].ToString().Split(' ')[0], dataReader[6]);
                        }
                    }
                    conn.Close();

                }

            }
        }
        private void tblGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentRow.Index;
            CbbMaThe.Text = dataGridView1.Rows[currentRowIndex].Cells[0].Value.ToString();
            txtManguoidoc.Text = dataGridView1.Rows[currentRowIndex].Cells[1].Value.ToString();
            txtTenHoiVien.Text = dataGridView1.Rows[currentRowIndex].Cells[2].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[currentRowIndex].Cells[3].Value.ToString();
            dtpNgayDangky.Text = dataGridView1.Rows[currentRowIndex].Cells[4].Value.ToString();
            dtpNgayHetHan.Text = dataGridView1.Rows[currentRowIndex].Cells[5].Value.ToString();
            txtDiemHoiVien.Text = dataGridView1.Rows[currentRowIndex].Cells[6].Value.ToString();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DESKTOP-DPRU2H9; Initial Catalog = QLThuVien; Integrated security = SSPI";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM TheHoiVien WHERE MaThe = @MaThe";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@MaThe", txtTimKiem.Text.Trim());
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataGridView1.Rows.Clear();
                        while (dataReader.Read())
                        {
                            dataGridView1.Rows.Add(dataReader[0], dataReader[1], dataReader[2],
                               dataReader[3], dataReader[4], dataReader[5], dataReader[6]);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"KHông tìm thấy MaThe = {txtTimKiem.Text.Trim()}", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string query = "SELECT * FROM TheHoiVien WHERE MaThe = @MaThe";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@MaThe", txtTimKiem.Text.Trim());
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataGridView1.Rows.Clear();
                        while (dataReader.Read())
                        {
                            dataGridView1.Rows.Add(dataReader[0], dataReader[1], dataReader[2],
                               dataReader[3], dataReader[4], dataReader[5], dataReader[6]);
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

        private void btnCapNhat_Click(object sender, EventArgs e)
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
                        check_MaThe_Command.Parameters.AddWithValue("@MaThe", CbbMaThe.Text.Trim());
                        check_MaND_Command.Parameters.AddWithValue("@MaND", txtManguoidoc.Text.Trim());

                        int count = (int)check_MaThe_Command.ExecuteScalar();
                        int count2 = (int)check_MaND_Command.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show($"Mã thẻ: {CbbMaThe.Text} không tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (count2 == 0)
                        {
                            MessageBox.Show($"Mã người đọc: {txtManguoidoc.Text} không tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (txtManguoidoc.Text.Trim() == string.Empty || txtTenHoiVien.Text.Trim() == string.Empty || txtDiaChi.Text.Trim() == string.Empty || dtpNgayDangky.Text.Trim() == string.Empty || dtpNgayHetHan.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Vui lòng không để trống các thông tin!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            string UpDateQuery = "UPDATE TheHoiVien SET MaND = @MaND, TenHoiVien = @TenHoiVien, DiaChi = @DiaChi, NgayDangKi = @NgayDangKi, NgayHetHan = @NgayHetHan, DiemHoiVien = @DiemHoiVien WHERE MaThe = @MaThe";

                            string ngayDangKy = dtpNgayDangky.Text.Trim();
                            DateTime ngayDK;
                            string ngayHetHan = dtpNgayHetHan.Text.Trim();
                            DateTime ngayHH;
                            string DiemHV = txtDiemHoiVien.Text.Trim();
                            float number;

                            using (SqlCommand insertCommand = new SqlCommand(UpDateQuery, conn))
                            {
                                if (DateTime.TryParseExact(ngayDangKy, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayDK))
                                {
                                    insertCommand.Parameters.AddWithValue("@NgayDangKi", ngayDK);
                                }
                                else
                                {
                                    MessageBox.Show("Định dạng ngày tháng không hợp lệ. \nVui lòng nhập lại đúng định dạng \nNăm/tháng/ngày (dd/MM/yyyy)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (DateTime.TryParseExact(ngayHetHan, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayHH))
                                {
                                    insertCommand.Parameters.AddWithValue("@NgayHetHan", ngayHH);
                                }
                                else
                                {
                                    MessageBox.Show("Định dạng ngày tháng không hợp lệ. \nVui lòng nhập lại đúng định dạng \nNăm/tháng/ngày (dd/MM/yyyy)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (!float.TryParse(DiemHV, out number) || number < 0)
                                {
                                    MessageBox.Show("Vui lòng Nhập Điểm hội viên bằng số! \n Số không được dưới 0", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    insertCommand.Parameters.AddWithValue("@MaThe", CbbMaThe.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@MaND", txtManguoidoc.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@TenHoiVien", txtTenHoiVien.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@DiemHoiVien", txtDiemHoiVien.Text.Trim());
                                    insertCommand.ExecuteNonQuery();
                                    MessageBox.Show("Cập nhật Thành Công");
                                    Load_tblGridView();

                                    conn.Close();
                                }
                            }
                        }

                    }
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
                        check_MaThe_Command.Parameters.AddWithValue("@MaThe", CbbMaThe.Text.Trim());
                        check_MaND_Command.Parameters.AddWithValue("@MaND", txtManguoidoc.Text.Trim());

                        int count = (int)check_MaThe_Command.ExecuteScalar();
                        int count2 = (int)check_MaND_Command.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show($"Mã thẻ: {CbbMaThe.Text} đã tồn tại! \n Vui lòng Nhập Mã thẻ khác", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (count2 == 0)
                        {
                            MessageBox.Show($"Mã người đọc: {txtManguoidoc.Text} không tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (txtManguoidoc.Text.Trim() == string.Empty || txtTenHoiVien.Text.Trim() == string.Empty || txtDiaChi.Text.Trim() == string.Empty || dtpNgayDangky.Text.Trim() == string.Empty || dtpNgayHetHan.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Vui lòng không để trống các thông tin!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            string insertQuery = "INSERT INTO TheHoiVien (MaThe, MaND, TenHoiVien, DiaChi, NgayDangKi, NgayHetHan, DiemHoiVien) " +
                                                     " VALUES (@MaThe, @MaND, @TenHoiVien, @DiaChi, @NgayDangKi, @NgayHetHan, @DiemHoiVien)";

                            string ngayDangKy = dtpNgayDangky.Text.Trim();
                            DateTime ngayDK;
                            string ngayHetHan = dtpNgayHetHan.Text.Trim();
                            DateTime ngayHH;
                            string DiemHV = txtDiemHoiVien.Text.Trim();
                            float number;

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, conn))
                            {
                                if (DateTime.TryParseExact(ngayDangKy, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayDK))
                                {
                                    insertCommand.Parameters.AddWithValue("@NgayDangKi", ngayDK);
                                }
                                else
                                {
                                    MessageBox.Show("Định dạng ngày tháng không hợp lệ. \nVui lòng nhập lại đúng định dạng \nNăm/tháng/ngày (dd/MM/yyyy)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (DateTime.TryParseExact(ngayHetHan, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayHH))
                                {
                                    insertCommand.Parameters.AddWithValue("@NgayHetHan", ngayHH);
                                }
                                else
                                {
                                    MessageBox.Show("Định dạng ngày tháng không hợp lệ. \nVui lòng nhập lại đúng định dạng \nNăm/tháng/ngày (dd/MM/yyyy)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (!float.TryParse(DiemHV, out number) || number < 0)
                                {
                                    MessageBox.Show("Vui lòng Nhập Điểm hội viên bằng số! \n Số không được dưới 0", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                else
                                {
                                    insertCommand.Parameters.AddWithValue("@MaThe", CbbMaThe.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@MaND", txtManguoidoc.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@TenHoiVien", txtTenHoiVien.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@DiemHoiVien", txtDiemHoiVien.Text.Trim());
                                    insertCommand.ExecuteNonQuery();
                                    MessageBox.Show("Thêm Thành Công");
                                    Load_tblGridView();

                                    conn.Close();
                                }

                            }
                        }
                    }

                }
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
                Load_tblGridView();
                CbbMaThe.Text = string.Empty;
                txtManguoidoc.Text = string.Empty;
                txtTenHoiVien.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                dtpNgayDangky.Text = string.Empty;
                dtpNgayHetHan.Text = string.Empty;
                txtDiemHoiVien.Text = string.Empty;
                txtTimKiem.Text = string.Empty;
        }
        private void Load_MaThe()
        {
            string connectionString = @"Data Source = DESKTOP-DPRU2H9; Initial Catalog = QLThuVien; Integrated security = SSPI";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DanhSach_MaThe", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CbbMaThe.Items.Add(reader["MaThe"].ToString());
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

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
