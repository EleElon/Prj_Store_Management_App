using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhanVien
    {
        private FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();

        public bool ThemNhanVien(string maNV, string tenNV, string gioiTinh, DateTime ngaySinh, string SDT, float luong, string diaChi)
        {
            try
            {
                if (db.NhanViens.Any(nv => nv.maNV == maNV))
                {
                    return false;
                }

                NhanVien nhanVien = new NhanVien
                {
                    maNV = maNV,
                    tenNV = tenNV,
                    gioiTinh = gioiTinh,
                    ngaySinh = ngaySinh,
                    SDT = SDT,
                    luong = luong,
                    diaChi = diaChi
                };

                db.NhanViens.InsertOnSubmit(nhanVien);
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaNhanVien(string maNV)
        {
            try
            {
                NhanVien nhanVien = db.NhanViens.FirstOrDefault(nv => nv.maNV == maNV);
                if (nhanVien != null)
                {
                    db.NhanViens.DeleteOnSubmit(nhanVien);
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

        public bool SuaThongTinNhanVien(string maNV, string tenNV, string gioiTinh, DateTime ngaySinh, string SDT, float luong, string diaChi)
        {
            try
            {
                NhanVien nhanVien = db.NhanViens.FirstOrDefault(nv => nv.maNV == maNV);
                if (nhanVien != null)
                {
                    nhanVien.tenNV = tenNV;
                    nhanVien.gioiTinh = gioiTinh;
                    nhanVien.ngaySinh = ngaySinh;
                    nhanVien.SDT = SDT;
                    nhanVien.luong = luong;
                    nhanVien.diaChi = diaChi;

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

        public List<NhanVien> HienThiDanhSachNhanVien()
        {
           
                return db.NhanViens.ToList();
           
        }
    }
}
