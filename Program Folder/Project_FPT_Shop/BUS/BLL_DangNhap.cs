using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BLL_DangNhap
    {
        DAL_DangNhap dalDangNhap = new DAL_DangNhap();
        DAL_User user = new DAL_User();
        public bool KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            // Gọi phương thức KiemTraDangNhap từ lớp DAL_DangNhap
            return dalDangNhap.KiemTraDangNhap(taiKhoan, matKhau);
        }
        public bool themUser(string taiKhoan, string matKhau)
        {
            return user.ThemUser(taiKhoan, matKhau);
        }
        public bool xoaUser(string taiKhoan) {
            return user.xoaUser(taiKhoan);
        }
        public bool suaUser(string taiKhoan, string matKhau)
        {
            return user.suaUser(taiKhoan, matKhau);
        }
    }
}
