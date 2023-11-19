using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn1_QLThuVien
{
    public partial class ManHinhCho : Form
    {
        public ManHinhCho()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Increment(2);
            if (progressBar1.Value == 100) 
            {
                timer1.Enabled = false;
                DangNhap lg = new DangNhap();
                this.Hide();
                lg.ShowDialog();
                this.Close();
            }
        }
    }
}
