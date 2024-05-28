using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BLL_LoaiSP
    {
        DAL_LoaiSP dal_LoaiSP = new DAL_LoaiSP();
        public bool ThemLoaiSP(string maLoai, string tenLoai, string moTa)
        {
            return dal_LoaiSP.ThemLoaiSP(maLoai, tenLoai, moTa);
        }

        public bool XoaLoaiSP(string maLoai)
        {
            return dal_LoaiSP.XoaLoaiSP(maLoai);
        }

        public bool SuaThongTinLoaiSP(string maLoai, string tenLoai, string moTa)
        {
            return dal_LoaiSP.SuaThongTinLoaiSP(maLoai, tenLoai, moTa);
        }
        public List<LoaiSP> View()
        {
            return dal_LoaiSP.HienThiDSSP();
        }

    }
}
