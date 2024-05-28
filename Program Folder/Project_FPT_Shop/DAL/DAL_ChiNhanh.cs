using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ChiNhanh
    {
        FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();
        public bool ThemChiNhanh(string maChiNhanh, string tenChiNhanh, string diaChi, string SDT)
        {
            try
            {
                if (db.ChiNhanhs.Any(cn => cn.maChiNhanh == maChiNhanh))
                {
                    return false;
                }

                ChiNhanh chiNhanh = new ChiNhanh();
                chiNhanh.maChiNhanh = maChiNhanh;
                chiNhanh.tenChiNhanh = tenChiNhanh;
                chiNhanh.diaChi = diaChi;
                chiNhanh.SDT = SDT;

                db.ChiNhanhs.InsertOnSubmit(chiNhanh);
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaChiNhanh(string maChiNhanh)
        {
            try
            {
                ChiNhanh chiNhanh = db.ChiNhanhs.FirstOrDefault(cn => cn.maChiNhanh == maChiNhanh);

                if (chiNhanh != null)
                {
                    db.ChiNhanhs.DeleteOnSubmit(chiNhanh);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SuaThongTinChiNhanh(string maChiNhanh, string tenChiNhanhMoi, string diaChiMoi, string SDTMoi)
        {
            try
            {
                ChiNhanh chiNhanh = db.ChiNhanhs.FirstOrDefault(cn => cn.maChiNhanh == maChiNhanh);

                if (chiNhanh != null)
                {
                    chiNhanh.tenChiNhanh = tenChiNhanhMoi;
                    chiNhanh.diaChi = diaChiMoi;
                    chiNhanh.SDT = SDTMoi;

                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ChiNhanh> View()
        {
            try
            {
                return db.ChiNhanhs.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
