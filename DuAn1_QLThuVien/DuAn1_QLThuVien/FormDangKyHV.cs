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
    public partial class FormDangKyHV : Form
    {
        public FormDangKyHV()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bnt_Thoat_Click(object sender, EventArgs e)
        {
            TrangChu tn = new TrangChu();
            this.Hide();
            tn.ShowDialog();
            this.Close();
        }
    }
}
