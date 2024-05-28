using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_PhieuNhapKho
    {
        private DAL_PhieuNhapKho dal = new DAL_PhieuNhapKho();
        public bool themPhieuNhapKho(PhieuNhapKho pnk) { return dal.themPhieuNhapKho(pnk); }
        public bool xoaPhieuNhapKho(string maPNK) { return dal.xoaPhieuNhapKho(maPNK); }
        public bool suaPhieuNhapKho(PhieuNhapKho pnk) { return dal.suaPhieuNhapKho(pnk); }
        public List<PhieuNhapKho> View()
        {
            return dal.View();
        }
    }
}
