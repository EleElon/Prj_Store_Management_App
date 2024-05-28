using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ThuongHieu
    {
        private DAL_ThuongHieu dal = new DAL_ThuongHieu();
        public bool themThuongHieu(ThuongHieu th) { return dal.themThuongHieu(th); }
        public bool xoaThuongHieu(ThuongHieu th) { return dal.xoaThuongHieu(th); }
        public bool suaThuongHieu(ThuongHieu th) { return dal.suaThuongHieu(th); }
        public List<ThuongHieu> View()
        {
            return dal.View();
        }
    }
}
