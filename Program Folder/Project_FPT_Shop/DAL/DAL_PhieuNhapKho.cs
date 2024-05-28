using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PhieuNhapKho
    {
        FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();

        public bool themPhieuNhapKho(PhieuNhapKho dto)
        {
            PhieuNhapKho pnk = new PhieuNhapKho();
            pnk.maPNK = dto.maPNK;
            pnk.tenSP = dto.tenSP;
            pnk.ngayNhap = dto.ngayNhap;
            pnk.tongDonGia = dto.tongDonGia;
            pnk.soLuong = dto.soLuong;
            pnk.maNV = dto.maNV;
            db.PhieuNhapKhos.InsertOnSubmit(pnk);
            db.SubmitChanges();
            return true;
        }
        public bool xoaPhieuNhapKho(string maPNK)
        {
            PhieuNhapKho pnk = db.PhieuNhapKhos.FirstOrDefault(p => p.maPNK == maPNK);
            if (pnk != null)
            {
                db.PhieuNhapKhos.DeleteOnSubmit(pnk);
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool suaPhieuNhapKho(PhieuNhapKho dto)
        {
            PhieuNhapKho pnk = db.PhieuNhapKhos.Where(p => p.maPNK == dto.maPNK).SingleOrDefault();
            pnk.tenSP = dto.tenSP;
            pnk.ngayNhap = dto.ngayNhap;
            pnk.tongDonGia = dto.tongDonGia;
            pnk.soLuong = dto.soLuong;
            pnk.maNV = dto.maNV;
            db.SubmitChanges();
            return true;
        }
        public List<PhieuNhapKho> View()
        {
            return db.PhieuNhapKhos.ToList();
        }

        public List<NhanVien> LoadNV()
        {
            using (var db = new FPT_Shop_Real_dbDataContext())
            {
                var nhanVienData = db.NhanViens
                    .Select(el => new
                    {
                        el.maNV,
                        el.tenNV,
                        el.gioiTinh,
                        el.ngaySinh,
                        el.SDT,
                        el.luong,
                        el.diaChi
                    })
                    .AsEnumerable()
                    .Select(el => new NhanVien
                    {
                        maNV = el.maNV,
                        tenNV = el.tenNV,
                        gioiTinh = el.gioiTinh,
                        ngaySinh = el.ngaySinh,
                        SDT = el.SDT,
                        luong = el.luong,
                        diaChi = el.diaChi
                    })
                    .ToList();
                return nhanVienData;
            }
        }
    }
}
