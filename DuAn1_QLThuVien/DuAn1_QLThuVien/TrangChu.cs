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
        public TrangChu(String User)
        {
            InitializeComponent();
            label1.Text = User;
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
            QLSach sach = new QLSach(label1.Text);
            this.Hide();
            sach.ShowDialog();
            this.Close();
        }
        private void QlNhanVien_Click(object sender, EventArgs e)
        {
            QLNhanVien nv = new QLNhanVien(label1.Text);
            this.Hide();
            nv.ShowDialog();
            this.Close();
        }

        private void DoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau(label1.Text);
            this.Hide();
            dmk.ShowDialog();
            this.Close();
        }
        private void QLnguoiMuonSach_Click(Object sender, EventArgs e)
        {
            QL_NguoiMuonSach nguoiMuonSach = new QL_NguoiMuonSach(label1.Text);
            this.Hide();
            nguoiMuonSach.ShowDialog();
            this.Close();         
        }
        private void QLTHongke_Click(object sender, EventArgs e)
        {
            QLThongKe qLThongKe = new QLThongKe(label1.Text);
            this.Hide();
            qLThongKe.ShowDialog();
            this.Close();
        }
        private void QLnguoiTraSach_Click(Object sender, EventArgs e)
        {
            QLNguoiTraSach qLNguoiTra = new QLNguoiTraSach(label1.Text);
            this.Hide();
            qLNguoiTra.ShowDialog();
            this.Close();

        }
        private void QLTHV_Click(object sender, EventArgs e)
        {
            QLTheHoiVien theHoiVien = new QLTheHoiVien(label1.Text);
            this.Hide();
            theHoiVien.ShowDialog();
            this.Close();
        }
        private void QLNguoiDoc_Click(object sender, EventArgs e)
        {
            QLNguoiDoc qLNguoiDoc = new QLNguoiDoc(label1.Text);
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
            else
            {

            }
        }  
    }
}
