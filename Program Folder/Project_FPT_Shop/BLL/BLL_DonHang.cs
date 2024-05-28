using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_DonHang
    {
        private DAL_DonHang dal = new DAL_DonHang();
        public bool themDonHang(DonHang dh) { return dal.themDonHang(dh); }
        public bool xoaDonHang(DonHang dh) { return dal.xoaDonHang(dh); }
        public bool suaDonHang(DonHang dh) { return dal.suaDonHang(dh); }
        public List<DonHang> View()
        {
            return dal.View();
        }
    }
}
