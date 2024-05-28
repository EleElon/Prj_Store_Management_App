using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DangNhap
    {
        FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();
        public bool KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            // Sử dụng LINQ để kiểm tra tài khoản và mật khẩu trong cơ sở dữ liệu
            var result = db.DangNhaps.Where(item => item.TaiKhoan == taiKhoan && item.MatKhau == matKhau).FirstOrDefault();

            // Nếu result không null, tức là tìm thấy tài khoản và mật khẩu trong cơ sở dữ liệu
            // Trả về true, ngược lại trả về false
            return result != null;
        }
    }
}
