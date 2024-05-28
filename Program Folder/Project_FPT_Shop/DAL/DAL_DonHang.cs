using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DonHang
    {
        private static DAL_DonHang instance;

        public static DAL_DonHang Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_DonHang();
                }
                return instance;
            }


        }
        public DAL_DonHang() { }


        private FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();
        public bool themDonHang(DonHang dto)
        {
            DonHang dh = new DonHang();
            dh.maDonHang = dto.maDonHang;
            dh.maKH = dto.maKH;
            dh.ngayMua = dto.ngayMua;
            dh.tinhTrangDatHang = dto.tinhTrangDatHang;
            dh.phuongThucThanhToan = dto.phuongThucThanhToan;
            dh.maSP = dto.maSP;
            dh.maNV = dto.maNV;
            dh.maChiNhanh = dto.maChiNhanh;
            dh.tongDonHang = dto.tongDonHang;
            dh.giaTungSP = dto.giaTungSP;
            dh.phanTramGiamGia = dto.phanTramGiamGia;
            dh.soLuong = dto.soLuong;
            db.DonHangs.InsertOnSubmit(dh);
            db.SubmitChanges();
            return true;
        }
        public bool xoaDonHang(string dto)
        {
            DonHang dh = db.DonHangs.FirstOrDefault(p => p.maDonHang == dto);
            if (dh != null)
            {
                db.DonHangs.DeleteOnSubmit(dh);
                db.SubmitChanges();
                return true;
            }
            else
            {
                // Xử lý khi không tìm thấy đối tượng cần xóa
                return false;
            }
        }
        public bool suaDonHang(string maDH, string maKH, DateTime ngayMua, string TTDH, string PTTT, string maSP, string maNV, string maCN, float tongDH, float giaTungSP, int phanTramGiamGia, int soLuong)
        {
            var dh = db.DonHangs.FirstOrDefault(p => p.maDonHang == maDH);
            if (dh != null)
            {
                dh.maKH = maKH;
                dh.ngayMua = ngayMua;
                dh.tinhTrangDatHang = TTDH;
                dh.phuongThucThanhToan = PTTT;
                dh.maSP = maSP;
                dh.maNV = maNV;
                dh.maChiNhanh = maCN;
                dh.tongDonHang = tongDH;
                dh.giaTungSP = giaTungSP;
                dh.phanTramGiamGia = phanTramGiamGia;
                dh.soLuong = soLuong;
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Sua(DonHang mahd)
        {
            using (FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext())
            {
                var spupdate = db.DonHangs.SingleOrDefault(a => a.maDonHang == mahd.maDonHang);
                if (spupdate != null)
                {
                    spupdate.maDonHang = mahd.maDonHang;
                    spupdate.maKH = mahd.maKH;
                    spupdate.ngayMua = mahd.ngayMua;
                    spupdate.tongDonHang = mahd.tongDonHang;
                    spupdate.tinhTrangDatHang = mahd.tinhTrangDatHang;
                    spupdate.phuongThucThanhToan = mahd.phuongThucThanhToan;
                    spupdate.maSP = mahd.maSP;
                    spupdate.soLuong = mahd.soLuong;
                    spupdate.giaTungSP = mahd.giaTungSP;
                    spupdate.phanTramGiamGia = mahd.phanTramGiamGia;
                    spupdate.maChiNhanh = mahd.maChiNhanh;
                    spupdate.maNV = mahd.maNV;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
        public List<DonHang> View()
        {
            return db.DonHangs.ToList();
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
        public List<SanPham> LoadSP()
        {
            using (var db = new FPT_Shop_Real_dbDataContext())
            {
                var sanPhamData = db.SanPhams
                                        .Select(el => new
                                        {
                                            el.maSP,
                                            el.tenSP,
                                            el.moTa,
                                            el.Gia,
                                            el.maThuongHieu,
                                            el.maLoai,
                                            el.soLuongTrongKho,
                                            el.NgayNhap,
                                            el.Anh
                                        })
                                        .AsEnumerable()
                                        .Select(el => new SanPham
                                        {
                                            maSP = el.maSP,
                                            tenSP = el.tenSP,
                                            moTa = el.moTa,
                                            Gia = el.Gia,
                                            maThuongHieu = el.maThuongHieu,
                                            maLoai = el.maLoai,
                                            soLuongTrongKho = el.soLuongTrongKho,
                                            NgayNhap = el.NgayNhap,
                                            Anh = el.Anh
                                        })
                                        .ToList();

                return sanPhamData;
            }
        }
        public List<ChiNhanh> LoadCN()
        {
            using (var db = new FPT_Shop_Real_dbDataContext())
            {
                var chiNhanhData = db.ChiNhanhs
                                        .Select(el => new
                                        {
                                            el.maChiNhanh,
                                            el.tenChiNhanh,
                                            el.diaChi,
                                            el.SDT
                                        })
                                        .AsEnumerable()
                                        .Select(el => new ChiNhanh
                                        {
                                            maChiNhanh = el.maChiNhanh,
                                            tenChiNhanh = el.tenChiNhanh,
                                            diaChi = el.diaChi,
                                            SDT = el.SDT
                                        })
                                        .ToList();

                return chiNhanhData;
            }
        }

        public List<KhachHang> LoadKH()
        {
            using (var db = new FPT_Shop_Real_dbDataContext())
            {
                var KHdata = db.KhachHangs
                                        .Select(el => new
                                        {
                                            el.maKH,
                                            el.tenKH,
                                            el.gioiTinh,
                                            el.diaChi,
                                            el.SDT
                                        })
                                        .AsEnumerable()
                                        .Select(el => new KhachHang
                                        {
                                            maKH = el.maKH,
                                            tenKH = el.tenKH,
                                            gioiTinh = el.gioiTinh,
                                            diaChi = el.diaChi,
                                            SDT = el.SDT
                                        })
                                        .ToList();

                return KHdata;
            }
        }
    }
}