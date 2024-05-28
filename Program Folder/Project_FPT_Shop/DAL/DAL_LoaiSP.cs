using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_LoaiSP
    {
        private FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();

        public bool ThemLoaiSP(string maLoai, string tenLoai, string moTa)
        {
            try
            {
                if (db.LoaiSPs.Any(ls => ls.maLoai == maLoai))
                {
                    return false;
                }

                LoaiSP loaiSP = new LoaiSP
                {
                    maLoai = maLoai,
                    tenLoai = tenLoai,
                    moTa = moTa
                };

                db.LoaiSPs.InsertOnSubmit(loaiSP);
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaLoaiSP(string maLoai)
        {
            try
            {
                LoaiSP loaiSP = db.LoaiSPs.FirstOrDefault(ls => ls.maLoai == maLoai);
                if (loaiSP != null)
                {
                    db.LoaiSPs.DeleteOnSubmit(loaiSP);
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

        public bool SuaThongTinLoaiSP(string maLoai, string tenLoai, string moTa)
        {
            try
            {
                LoaiSP loaiSP = db.LoaiSPs.FirstOrDefault(ls => ls.maLoai == maLoai);
                if (loaiSP != null)
                {
                    loaiSP.tenLoai = tenLoai;
                    loaiSP.moTa = moTa;

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
        public List<LoaiSP> HienThiDSSP()
        {
            return db.LoaiSPs.ToList();
        }
    }
}
