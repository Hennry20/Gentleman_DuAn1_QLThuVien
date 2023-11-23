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

namespace DuAn1
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }


        private void TrangChu_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Tick += new EventHandler(timer1_Tick);

            timer2.Start();
            timer2.Tick += new EventHandler(timer2_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Lbl_Time.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            Lbl_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
            else
            {

            }
        }  
    }
}
