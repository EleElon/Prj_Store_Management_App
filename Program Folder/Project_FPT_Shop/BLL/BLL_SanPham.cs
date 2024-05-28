using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_SanPham
    {
        private DAL_SanPham dal = new DAL_SanPham();
        public bool themSanPham(SanPham sp) { return dal.themSanPham(sp); }
        public bool xoaSanPham(SanPham sp) { return dal.xoaSanPham(sp); }
        public bool suaSanPham(SanPham sp) { return dal.suaSanPham(sp); }
        public List<SanPham> View(DataGridView data)
        {
            return dal.View(data);
        }
    }
}
