using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn1_QLThuVien
{
    public static class DBHandler
    {
        public static String Login(String User, String PassWord)
        {
            using (QLThuVienEntities pe = new QLThuVienEntities())
            {
                TaiKhoan found = pe.TaiKhoans.FirstOrDefault(row => row.TenDangNhap.Equals(User));
                if (found != null && found.MatKhau.Equals(PassWord))
                {
                    return found.VaiTro;
                }
                return null;
            }
        }
        public static List<NhanVien> getlistNhanVien()
        {
            List<NhanVien> dsSanPham = new List<NhanVien>();
            using (QLThuVienEntities csharpDB = new QLThuVienEntities())
            {
                dsSanPham = csharpDB.NhanViens.ToList();
            }
            return dsSanPham;
        }

    }
}
