using DuAn1;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn1_QLThuVien
{
    public partial class QLNguoiDoc : Form
    {
        public QLNguoiDoc()
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
        private void QLnguoiTraSach_Click(Object sender, EventArgs e)
        {
            QLNguoiTraSach qLNguoiTra = new QLNguoiTraSach();
            this.Hide();
            qLNguoiTra.ShowDialog();
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
        private void QLNguoiDoc_Click(object sender, EventArgs e)
        {
            QLNguoiDoc qLNguoiDoc = new QLNguoiDoc();
            this.Hide();
            qLNguoiDoc.ShowDialog();
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
        private void QLNguoiDoc_Load(object sender, EventArgs e)
        {
            Load_tblGridView();
            Load_MaND();
            Load_MaNV();

            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void Load_tblGridView()
        {
            string connString = @"Data Source = DESKTOP-DPRU2H9; Initial Catalog = QLThuVien; Integrated security = SSPI";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM NguoiDoc";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataGridView1.Rows.Clear();
                        while (dataReader.Read())
                        {
                            dataGridView1.Rows.Add(dataReader[0], dataReader[1], dataReader[2].ToString().Split(' ')[0],
                                dataReader[3], dataReader[4], dataReader[5]);
                        }
                    }
                    conn.Close();

                }
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DESKTOP-DPRU2H9; Initial Catalog = QLThuVien; Integrated security = SSPI";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM NguoiDoc WHERE MaND = @MaND";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@MaND", txtTimKiem.Text.Trim());
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataGridView1.Rows.Clear();
                        while (dataReader.Read())
                        {
                            dataGridView1.Rows.Add(dataReader[0], dataReader[1], dataReader[2].ToString().Split(' ')[0],
                               dataReader[3], dataReader[4], dataReader[5]);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"KHông tìm thấy MaND = {txtTimKiem.Text.Trim()}", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string query = "SELECT * FROM NguoiDoc WHERE MaND = @MaND";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@MaND", txtTimKiem.Text.Trim());
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataGridView1.Rows.Clear();
                        while (dataReader.Read())
                        {
                            dataGridView1.Rows.Add(dataReader[0], dataReader[1], dataReader[2].ToString().Split(' ')[0],
                               dataReader[3], dataReader[4], dataReader[5]);
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
        public bool IsPhoneNumberValid(string phoneNumber)
        {
            string pattern = @"^\d{10,}$"; // Số điện thoại có ít nhất 10 chữ số
            return Regex.IsMatch(phoneNumber, pattern);
        }
        public bool IsValidEmail(string email)
        {
            // Kiểm tra email có phù hợp với định dạng không
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Match match = Regex.Match(email, pattern);

            // Trả về true nếu email hợp lệ, ngược lại trả về false
            return match.Success;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DESKTOP-DPRU2H9; Initial Catalog = QLThuVien; Integrated security = SSPI";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string check_MaND_Query = "SELECT COUNT(*) FROM NguoiDoc WHERE MaND = @MaND";
                string check_MaNV_Query = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
                using (SqlCommand check_MaND_Command = new SqlCommand(check_MaND_Query, conn))
                {
                    using (SqlCommand check_MaNV_Command = new SqlCommand(check_MaNV_Query, conn))
                    {
                        check_MaND_Command.Parameters.AddWithValue("@MaND", cbbMaND.Text.Trim());
                        check_MaNV_Command.Parameters.AddWithValue("@MaNV", cbbMaNV.Text.Trim());

                        int count = (int)check_MaND_Command.ExecuteScalar();

                        int count2 = (int)check_MaNV_Command.ExecuteScalar();

                        if (cbbMaND.Text.Trim() == string.Empty || txtSDT.Text.Trim() == string.Empty || txtTenND.Text.Trim() == string.Empty || dtpNgaySinh.Text.Trim() == string.Empty || txtEmail.Text.Trim() == string.Empty || cbbMaNV.Text == string.Empty)
                        {
                            MessageBox.Show("Vui lòng không để trống các thông tin!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (count > 0)
                        {
                            MessageBox.Show($"Mã người đọc: {cbbMaND.Text} đã tồn tại! \n Vui lòng Nhập Mã sách khác", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (count2 == 0)
                        {
                            MessageBox.Show($"Người tạo: {cbbMaNV.Text} không tồn tại!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            string insertQuery = "INSERT INTO NguoiDoc (MaND, TenND, NgaySinh, SDT, Email, MaNV) " +
                                                         " VALUES (@MaND, @TenND, @NgaySinh, @SDT, @Email, @MaNV)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, conn))
                            {
                                string ngaySinh = dtpNgaySinh.Text.Trim();
                                DateTime ngSinh;

                                string dienThoai = txtSDT.Text.Trim();

                                string email = txtEmail.Text.Trim();

                                if (IsPhoneNumberValid(dienThoai))
                                {
                                    insertCommand.Parameters.AddWithValue("@SDT", dienThoai);
                                }
                                else
                                {
                                    MessageBox.Show("Định dạng Số điện thoại không hợp lệ. \nVui lòng nhập lại đúng định dạng \n(09********)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (DateTime.TryParseExact(ngaySinh, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngSinh))
                                {
                                    insertCommand.Parameters.AddWithValue("@NgaySinh", ngSinh);
                                }
                                else
                                {
                                    MessageBox.Show("Định dạng ngày tháng không hợp lệ. \nVui lòng nhập lại đúng định dạng \nNăm/tháng/ngày (dd/MM/yyyy)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                if (IsValidEmail(email))
                                {
                                    insertCommand.Parameters.AddWithValue("@Email", email);
                                }
                                else
                                {
                                    MessageBox.Show("Định dạng Email không hợp lệ. \nVui lòng nhập đúng định dạng\n(example@gmail.com)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                insertCommand.Parameters.AddWithValue("@MaND", cbbMaND.Text.Trim());
                                insertCommand.Parameters.AddWithValue("@TenND", txtTenND.Text.Trim());
                                insertCommand.Parameters.AddWithValue("@MaNV", cbbMaNV.Text.Trim());
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DESKTOP-DPRU2H9; Initial Catalog = QLThuVien; Integrated security = SSPI";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string check_MaND_Query = "SELECT COUNT(*) FROM NguoiDoc WHERE MaND = @MaND";
                string check_MaNV_Query = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
                using (SqlCommand check_MaND_Command = new SqlCommand(check_MaND_Query, conn))
                {
                    using (SqlCommand check_MaNV_Command = new SqlCommand(check_MaNV_Query, conn))
                    {
                        check_MaND_Command.Parameters.AddWithValue("@MaND", cbbMaND.Text.Trim());
                        check_MaNV_Command.Parameters.AddWithValue("@MaNV", cbbMaNV.Text.Trim());

                        int count = (int)check_MaND_Command.ExecuteScalar();

                        int count2 = (int)check_MaNV_Command.ExecuteScalar();


                        if (count == 0)
                        {
                            MessageBox.Show($"Mã người đọc: {cbbMaND.Text} không tồn tại! \n Vui lòng Nhập Mã người đọc khác", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (count2 == 0)
                        {
                            MessageBox.Show($"Người tạo: {cbbMaNV.Text} không tồn tại! \n Vui lòng Nhập Mã người tạo khác", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (cbbMaND.Text.Trim() == string.Empty || txtSDT.Text.Trim() == string.Empty || txtTenND.Text.Trim() == string.Empty || dtpNgaySinh.Text.Trim() == string.Empty || txtEmail.Text.Trim() == string.Empty || cbbMaNV.Text == string.Empty)
                        {
                            MessageBox.Show("Vui lòng không để trống các thông tin!", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            string updateQuery = "UPDATE NguoiDoc SET TenND = @TenND, NgaySinh = @NgaySinh, SDT = @SDT, Email = @Email, MaNV = @MaNV WHERE MaND = @MaND ";

                            using (SqlCommand insertCommand = new SqlCommand(updateQuery, conn))
                            {
                                string ngaySinh = dtpNgaySinh.Text.Trim();
                                DateTime ngSinh;

                                string dienThoai = txtSDT.Text.Trim();

                                string email = txtEmail.Text.Trim();

                                if (IsPhoneNumberValid(dienThoai))
                                {
                                    insertCommand.Parameters.AddWithValue("@SDT", dienThoai);
                                }
                                else
                                {
                                    MessageBox.Show("Định dạng Số điện thoại không hợp lệ. \nVui lòng nhập lại đúng định dạng \n(09********)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (DateTime.TryParseExact(ngaySinh, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngSinh))
                                {
                                    insertCommand.Parameters.AddWithValue("@NgaySinh", ngSinh);
                                }
                                else
                                {
                                    MessageBox.Show("Định dạng ngày tháng không hợp lệ. \nVui lòng nhập lại đúng định dạng \nNăm/tháng/ngày (dd/MM/yyyy)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                if (IsValidEmail(email))
                                {
                                    insertCommand.Parameters.AddWithValue("@Email", email);
                                }
                                else
                                {
                                    MessageBox.Show("Định dạng Email không hợp lệ. \nVui lòng nhập đúng định dạng\n(example@gmail.com)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                insertCommand.Parameters.AddWithValue("@MaND", cbbMaND.Text.Trim());
                                insertCommand.Parameters.AddWithValue("@TenND", txtTenND.Text.Trim());
                                insertCommand.Parameters.AddWithValue("@MaNV", cbbMaNV.Text.Trim());

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


        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa Mã sách = {cbbMaND.Text.Trim()}?", "Xác nhận?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                string idToDelete = cbbMaND.Text.Trim();
                XoaMaND(idToDelete);
            }

        }
        private void XoaMaND(string idToDelete)
        {
            string connString = @"Data Source = DESKTOP-DPRU2H9; Initial Catalog = QLThuVien; Integrated security = SSPI";
            string deleteQuery = "DELETE FROM NguoiDoc WHERE MaND = @MaND";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(deleteQuery, conn))
                {
                    command.Parameters.AddWithValue("@MaND", idToDelete);
                    command.ExecuteNonQuery();
                    MessageBox.Show($"Xóa thành công");
                    Load_tblGridView();
                    conn.Close();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Load_tblGridView();
            cbbMaND.Text = string.Empty;
            cbbMaNV.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtTenND.Text = string.Empty;
            txtTimKiem.Text = string.Empty;
            dtpNgaySinh.Text = string.Empty;

            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnCapNhat.Enabled = false;
            cbbMaND.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Enabled = false;
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;
            cbbMaND.Enabled = false;

            try
            {
                int currentRowIndex = dataGridView1.CurrentRow.Index;
                cbbMaND.Text = dataGridView1.Rows[currentRowIndex].Cells[0].Value.ToString();
                txtTenND.Text = dataGridView1.Rows[currentRowIndex].Cells[1].Value.ToString();
                dtpNgaySinh.Text = dataGridView1.Rows[currentRowIndex].Cells[2].Value.ToString();
                txtSDT.Text = dataGridView1.Rows[currentRowIndex].Cells[3].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[currentRowIndex].Cells[4].Value.ToString();
                cbbMaNV.Text = dataGridView1.Rows[currentRowIndex].Cells[5].Value.ToString();
            }
            catch (Exception)
            {
                return;
            }
        }
        private void Load_MaND()
        {
            string connectionString = @"Data Source = DESKTOP-DPRU2H9; Initial Catalog = QLThuVien; Integrated security = SSPI";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DanhSach_MaND", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cbbMaND.Items.Add(reader["MaND"].ToString());
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
        private void Load_MaNV()
        {
            string connectionString = @"Data Source = DESKTOP-DPRU2H9; Initial Catalog = QLThuVien; Integrated security = SSPI";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DanhSach_MaNV", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cbbMaNV.Items.Add(reader["MaNV"].ToString());
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
    }
}
