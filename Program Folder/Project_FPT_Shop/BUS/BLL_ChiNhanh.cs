using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BLL_ChiNhanh
    {
        DAL_ChiNhanh dal_ChiNhanh = new DAL_ChiNhanh();
        public bool ThemChiNhanh(string maChiNhanh, string tenChiNhanh, string diaChi, string SDT)
        {
            return dal_ChiNhanh.ThemChiNhanh(maChiNhanh, tenChiNhanh, diaChi, SDT);
        }

        public bool XoaChiNhanh(string maChiNhanh)
        {
            return dal_ChiNhanh.XoaChiNhanh(maChiNhanh);
        }

        public bool SuaThongTinChiNhanh(string maChiNhanh, string tenChiNhanhMoi, string diaChiMoi, string SDTMoi)
        {
            return dal_ChiNhanh.SuaThongTinChiNhanh(maChiNhanh, tenChiNhanhMoi, diaChiMoi, SDTMoi);
        }

        public List<ChiNhanh> View()
        {
            return dal_ChiNhanh.View();
        }
    }
}
