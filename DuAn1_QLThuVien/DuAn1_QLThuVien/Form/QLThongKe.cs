using DuAn1;
using DuAn1_QLThuVien;
using QLThuVien;
using System;
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
    public partial class QLThongKe : Form
    {
        public QLThongKe(String User)
        {
            InitializeComponent();
            label3.Text = User;
        }
        
        public void ThongKeSach1Thang()
        {
            DataTable dt = new DataTable();
            SqlConnection myConn = new SqlConnection(@"Data Source=.;Initial Catalog=QLThuVien;Integrated security=SSPI");
            myConn.Open();

            SqlCommand myCmd = new SqlCommand("tksach1thang", myConn);
            myCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            dtgSach1Thang.DataSource = dt;
            myConn.Close();
        }
        public void DoanhThu()
        {
            DataTable dt = new DataTable();
            SqlConnection myConn = new SqlConnection(@"Data Source=.;Initial Catalog=QLThuVien;Integrated security=SSPI");
            myConn.Open();

            SqlCommand myCmd = new SqlCommand("Danhthu", myConn);
            myCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            dtgDoanhThu.DataSource = dt;
            myConn.Close();
        }
        private void quảnLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu tn = new TrangChu(label3.Text);
            this.Hide();
            tn.ShowDialog();
            this.Close();
        }

        private void cbx_SachChoMuon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ht = string.Format(@"exec ThongKe1thangSach'{0}'", cbx_SachChoMuon.SelectedItem);
            SqlConnection myConn = new SqlConnection(@"Data Source=.;Initial Catalog=QLThuVien;Integrated security=SSPI");
            SqlCommand cmd = new SqlCommand(ht);
            myConn.Open();
            cmd.Connection = myConn;
            SqlDataReader dtr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dtr);
            dtgSach1Thang.DataSource = dt;
            myConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThongKeSach1Thang();
            cbx_SachChoMuon.Text = "";
        }

        private void QLThongKe_Load(object sender, EventArgs e)
        {
            ThongKeSach1Thang();
            DoanhThu();
        }

        private void cbxDoanhthu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ht = string.Format(@"exec Danhthu1thang'{0}'", cbxDoanhthu.SelectedItem);
            SqlConnection myConn = new SqlConnection(@"Data Source=.;Initial Catalog=QLThuVien;Integrated security=SSPI");
            SqlCommand cmd = new SqlCommand(ht);
            myConn.Open();
            cmd.Connection = myConn;
            SqlDataReader dtr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dtr);
            dtgDoanhThu.DataSource = dt;
            myConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoanhThu();
            cbxDoanhthu.Text = "";
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            this.Hide();
            dn.ShowDialog();
            this.Close();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            this.Hide();
            dmk.ShowDialog();
            this.Close();
        }

        private void kếtThúcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quảnLToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            QLNhanVien qlnv = new QLNhanVien(label3.Text);
            this.Hide();
            qlnv.ShowDialog();
            this.Close();
        }

        private void quảnLýNgườiMượnSáchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QL_NguoiMuonSach qlnms = new QL_NguoiMuonSach(label3.Text);
            this.Hide();
            qlnms.ShowDialog();
            this.Close();
        }

        private void quảnLýNgườiMượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLSach qls = new QLSach(label3.Text);
            this.Hide();
            qls.ShowDialog();
            this.Close();
        }

        private void quảnLýThẻHộiViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLTheHoiVien qlthv = new QLTheHoiVien(label3.Text);
            this.Hide();
            qlthv.ShowDialog();
            this.Close();
        }

        private void đăngKíThẻHộiViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLTheHoiVien qlthv = new QLTheHoiVien(label3.Text);
            this.Hide();
            qlthv.ShowDialog();
            this.Close();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLThongKe qltk = new QLThongKe(label3.Text);
            this.Hide();
            qltk.ShowDialog();
            this.Close();
        }

        private void quảnLýNgườiTrảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNguoiTraSach qlnts = new QLNguoiTraSach(label3.Text);
            this.Hide();
            qlnts.ShowDialog();
            this.Close();
        }
    }
}
