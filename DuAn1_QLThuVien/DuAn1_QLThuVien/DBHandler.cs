using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DuAn1_QLThuVien
{
    class DBHandler
    {
        public static String Login(String User, String PassWord)
        {
            using (QLThuVienEntities2 pe = new QLThuVienEntities2())
            {
                TaiKhoan found = pe.TaiKhoans.FirstOrDefault(row => row.TenDangNhap.Equals(User));
                if (found != null && found.MatKhau.Equals(PassWord))
                {
                    return found.VaiTro;
                }
                return null;
            }
        }

        public static List<NhanVien> getListNhanVien()
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();
            using (QLThuVienEntities2 abc = new QLThuVienEntities2())
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
