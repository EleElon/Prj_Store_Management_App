using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_User
    {
        FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();

        public bool ThemUser(string taiKhoan, string matKhau)
        {
            try
            {
                if (db.DangNhaps.Any(lg => lg.TaiKhoan == taiKhoan))
                {
                    return false;
                }

                DangNhap dn = new DangNhap();
                dn.TaiKhoan = taiKhoan;
                dn.MatKhau = matKhau;

                db.DangNhaps.InsertOnSubmit(dn);
                db.SubmitChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool xoaUser(string taiKhoan)
        {
            try
            {
                DangNhap dn = db.DangNhaps.FirstOrDefault(a => a.TaiKhoan == taiKhoan);

                if (dn != null)
                {
                    db.DangNhaps.DeleteOnSubmit(dn);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool suaUser(string taiKhoan, string matKhau)
        {
            try
            {
                DangNhap dn = db.DangNhaps.FirstOrDefault(a => a.TaiKhoan == taiKhoan);

                if (dn != null)
                {
                    dn.TaiKhoan = taiKhoan;
                    dn.MatKhau = matKhau;

                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<DangNhap> View()
        {
            return db.DangNhaps.ToList();
        }
    }
}
