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
    public partial class QLNhanVien : Form
    {
        DataSet ds = new DataSet();
        SqlDataAdapter sda;
        public QLNhanVien()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            String conn = @"Data Source=.;Initial Catalog=QlThuVien;Integrated security=SSPI";
            String query = "SELECT * from NhanVien";

            sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds, "NhanVien");
            dtgvQLNhanVien.DataSource = ds.Tables["NhanVien"];
        }

    }
}
