using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class BLL_ThuongHieu
    {
        private DAL_ThuongHieu dal = new DAL_ThuongHieu();
        public bool themThuongHieu(ThuongHieu th) { return dal.themThuongHieu(th); }
        public bool xoaThuongHieu(string maTH) { return dal.xoaThuongHieu(maTH); }
        public bool suaThuongHieu(/*string ma,*/ThuongHieu th) { return dal.suaThuongHieu(/*ma,*/th); }
        
        public List<ThuongHieu> View()
        {
            return dal.View();
        }
    }
}
