using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DuAn1_QLThuVien
{
    public static class DBHandler
    {
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
        public static String Login(String User, String PassWord)
        {
            using (QLThuVienEntities3 pe = new QLThuVienEntities3())
            {
                TaiKhoan found = pe.TaiKhoans.FirstOrDefault(row => row.TenDangNhap.Equals(User));
                if (found != null && found.MatKhau.Equals(PassWord))
                {
                    return found.VaiTro;
                }
                return null;
            }
        }
            public static string NextString(this Random random, int length)
            {
                const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";

                IEnumerable<string> string_Enumerable = Enumerable.Repeat(chars, length);
                char[] arr = string_Enumerable.Select(s => s[random.Next(s.Length)]).ToArray();

                return new string(arr);
            }
        
        
        public static List<Sach> getListSach()
        {
            List<Sach> dscd = new List<Sach>();
            using (QLThuVienEntities3 abc = new QLThuVienEntities3())
            {
                dscd = abc.Saches.ToList();
            }
            return dscd;
        }

        public static List<PhieuMuon> getPhieuMuon()
        {
            List<PhieuMuon> pm = new List<PhieuMuon>();
            using (QLThuVienEntities3 abc = new QLThuVienEntities3())
            {
                pm = abc.PhieuMuons.ToList();
            }
            return pm;
        }

        public static List<NguoiDoc> getNguoiDoc()
        {
            List<NguoiDoc> pm = new List<NguoiDoc>();
            using (QLThuVienEntities3 abc = new QLThuVienEntities3())
            {
                pm = abc.NguoiDocs.ToList();
            }
            return pm;
        }
        public static List<NhanVien> getListNhanVien()
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();
            using (QLThuVienEntities3 abc = new QLThuVienEntities3())
            {
                dsNhanVien = abc.NhanViens.ToList();
            }
            return dsNhanVien;
        }
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
        public static bool IsNumber(string val)
        {
            if (val != "")
                return Regex.IsMatch(val, @"^[0-9]\d*\.?[0]*$");
            else return true;
        }
    }
}
