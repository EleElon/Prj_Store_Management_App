using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_KhachHang
    {
        private DAL_KhachHang dal_KH = new DAL_KhachHang();
        public bool ThemKhachHang(string maKH, string tenKH, string gioiTinh, string diaChi, string SDT)
        {
            return dal_KH.themKhachHang(maKH, tenKH,gioiTinh, diaChi, SDT);
        }
        public bool XoaKhachHang(string maKH)
        {

            return dal_KH.XoaKhachHang(maKH);
        }
        public bool SuaThongTinKhachHang(string maKH, string tenKHMoi, string gioiTinhMoi, string diaChiMoi, string SDTMoi)
        {
         
                // Gọi phương thức sửa thông tin khách hàng từ đối tượng DAL_KhachHang
                return dal_KH.SuaThongTinKhachHang(maKH, tenKHMoi, gioiTinhMoi, diaChiMoi, SDTMoi);         
        }
        public List<KhachHang> View()
        {
            return dal_KH.View();
        }
    }
}
