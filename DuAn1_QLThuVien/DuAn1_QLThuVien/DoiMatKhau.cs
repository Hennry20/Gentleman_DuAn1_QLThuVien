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
using System.Security.Cryptography;
using System.Net;

namespace DuAn1_QLThuVien
{
    public partial class DoiMatKhau : Form
    {

        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult quit = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (quit == DialogResult.Yes)
            {
                DangNhap dn = new DangNhap();
                this.Hide();
                dn.ShowDialog();
                this.Close();
            }
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }
        public static string toMD5(string pass)
        {
            MD5CryptoServiceProvider myMD5 = new MD5CryptoServiceProvider();
            byte[] myPass = System.Text.Encoding.UTF8.GetBytes(pass);
            myPass = myMD5.ComputeHash(myPass);

            StringBuilder s = new StringBuilder();
            foreach (byte p in myPass)
            {
                s.Append(p.ToString("x").ToLower());
            }
            return s.ToString();
        }
        
        //public static string Decrypt(string toDecrypt)
        //{
        //    bool useHashing = true;
        //    byte[] keyArray;
        //    byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

        //    if (useHashing)
        //    {
        //        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        //        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        //    }
        //    else
        //        keyArray = UTF8Encoding.UTF8.GetBytes(key);

        //    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        //    tdes.Key = keyArray;
        //    tdes.Mode = CipherMode.ECB;
        //    tdes.Padding = PaddingMode.PKCS7;

        //    ICryptoTransform cTransform = tdes.CreateDecryptor();
        //    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        //    return UTF8Encoding.UTF8.GetString(resultArray);
        //}
        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if(txt_TaiKhoan.Text == "" || txt_MatKhauCu.Text == ""|| txt_MatKhauMoi.Text ==""||txt_XacNhanMatKhau.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                    return;
                }
                if(txt_MatKhauMoi.Text != txt_XacNhanMatKhau.Text)
                {
                    MessageBox.Show("Vui lòng xác nhận mật khẩu mới", "Thông báo");
                    return;
                }
                string ht = string.Format(@"exec doimatkhau '{0}', '{1}','{2}'", txt_TaiKhoan.Text, txt_MatKhauCu.Text, txt_MatKhauMoi.Text = toMD5("huhuhullk22drdxd"));
                SqlConnection myConn = new SqlConnection(@"Data Source=.;Initial Catalog=QLThuVien;Integrated security=SSPI");
                SqlCommand cmd = new SqlCommand(ht);
                myConn.Open();
                cmd.Connection = myConn;
                SqlDataReader dtr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dtr);
                myConn.Close();
                MessageBox.Show("Mật khẩu đã được cập nhật","Thông báo");
                txt_TaiKhoan.Text = "";
                txt_MatKhauCu.Text = "";
                txt_MatKhauMoi.Text = "";
                txt_XacNhanMatKhau.Text = "";
            }
            catch
            {

            }
            
        }
    }
}
