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
        public QLThongKe()
        {
            InitializeComponent();
        }

        public void ThongKeSach1Thang()
        {
            DataTable dt = new DataTable();
            SqlConnection myConn = new SqlConnection(@"Data Source=.;Initial Catalog=QLThuVien;Integrated security=SSPI");
            myConn.Open();

            SqlCommand myCmd = new SqlCommand("ThongKe1thangSach", myConn);
            myCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            myConn.Close();
        }
        private void quảnLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void QLThongKe_Load(object sender, EventArgs e)
        {
            ThongKeSach1Thang();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            dataGridView4.DataSource = dt;
            myConn.Close();
        }
    }
}
