using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BLL_NhanVien
    {
        DAL_NhanVien dal_NV = new DAL_NhanVien();
      
        public bool ThemNhanVien(string maNV, string tenNV, string gioiTinh, DateTime ngaySinh, string SDT, float luong, string diaChi)
        {
            return dal_NV.ThemNhanVien(maNV, tenNV, gioiTinh, ngaySinh, SDT, luong, diaChi);
        }

        public bool XoaNhanVien(string maNV)
        {
            return dal_NV.XoaNhanVien(maNV);
        }

        public bool SuaThongTinNhanVien(string maNV, string tenNV, string gioiTinh, DateTime ngaySinh, string SDT, float luong, string diaChi)
        {
            return dal_NV.SuaThongTinNhanVien(maNV, tenNV, gioiTinh, ngaySinh, SDT, luong, diaChi);
        }

        public List<NhanVien> View()
        {
            return dal_NV.HienThiDanhSachNhanVien();
        }
    }
}
