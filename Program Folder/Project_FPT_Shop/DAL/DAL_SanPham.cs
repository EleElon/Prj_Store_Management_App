using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;



namespace DAL
{
    public class DAL_SanPham
    {
        private static DAL_SanPham instance;

        public static DAL_SanPham Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_SanPham();
                }
                return instance;
            }


        }
        public DAL_SanPham() { }

        public FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();

        //public static object Instance { get; set; }

        public void themSanPham(TextBox masp, TextBox tensp, TextBox mota, TextBox gia, ComboBox mathuonghieu, ComboBox maloai, TextBox soluongtrongkho, DateTimePicker ngaynhap, TextBox anh)
        {
            string[] cattenanh = anh.Text.Split('\\');
            int lastIndex = cattenanh.Length - 1;
            string tenanh = cattenanh[lastIndex];
            string duongdan = Path.Combine(System.Windows.Forms.Application.StartupPath, "Image");
            string duongdanmoi = duongdan + "\\" + tenanh;

            SanPham sp = new SanPham();
            sp.maSP = masp.Text;
            sp.tenSP = tensp.Text;
            sp.moTa = mota.Text;
            sp.Gia = float.Parse(gia.Text);
            sp.maThuongHieu = mathuonghieu.SelectedValue.ToString().Trim();
            sp.maLoai = maloai.SelectedValue.ToString().Trim();
            sp.soLuongTrongKho = int.Parse(soluongtrongkho.Text);
            sp.NgayNhap = DateTime.Parse(ngaynhap.Text);
            sp.Anh = duongdanmoi;

            db.SanPhams.InsertOnSubmit(sp);
            db.SubmitChanges();
        }

       


        public void xoa(string maSP)
        {

            var sp = db.SanPhams.FirstOrDefault(p => p.maSP == maSP);


            if (sp != null)
            {
                db.SanPhams.DeleteOnSubmit(sp);
                db.SubmitChanges();
                
            }
        }

        public bool suaSanPham(SanPham dTO)
        {
            
            using (FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext())
            {
                var spupdate = db.SanPhams.FirstOrDefault(a => a.maSP == dTO.maSP);
                if (spupdate != null)
                {
                    spupdate.maSP = dTO.maSP;
                    spupdate.tenSP = dTO.tenSP;
                    spupdate.moTa = dTO.moTa;
                    spupdate.Gia = dTO.Gia;
                    spupdate.maThuongHieu = dTO.maThuongHieu;
                    spupdate.maLoai = dTO.maLoai;
                    spupdate.soLuongTrongKho = dTO.soLuongTrongKho;
                    spupdate.NgayNhap = dTO.NgayNhap;
                    spupdate.Anh = dTO.Anh;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
        public string LayAnhBangMaSp(TextBox masp)
        {
            using (FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext())
            {
                var sanpham = db.SanPhams.SingleOrDefault(sp => sp.maSP == masp.Text);
                return sanpham.Anh;
            }
        }

        public void LoadDgvLenForm(TextBox masp, TextBox tensp, TextBox mota, TextBox gia, ComboBox mathuonghieu, ComboBox maloai, TextBox soluongtrongkho, DateTimePicker ngaynhap, PictureBox ptbanh,/* TextBox txtanh,*/ DataGridView data)
        {
            using (FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext())
            {
                if (data.SelectedCells.Count > 0)
                {
                    var rowIndex = data.SelectedCells[0].RowIndex;
                    var row = data.Rows[rowIndex];
                    masp.Text = row.Cells[0].Value.ToString().Trim();
                    tensp.Text = row.Cells[1].Value.ToString().Trim();
                    mota.Text = row.Cells[2].Value.ToString().Trim();
                    gia.Text = row.Cells[3].Value.ToString().Trim();

                    var thuonghieu = (from h in db.ThuongHieus
                                      where h.maThuongHieu == row.Cells[4].Value.ToString().Trim()
                                      select h.tenThuongHieu).FirstOrDefault();
                    mathuonghieu.Text = thuonghieu/*.ToString()*/;

                    var loai = (from l in db.LoaiSPs
                                where l.maLoai == row.Cells[5].Value.ToString().Trim()
                                select l.tenLoai).FirstOrDefault();
                    maloai.Text = loai/*.ToString()*/;

                    soluongtrongkho.Text = row.Cells[6].Value.ToString().Trim();

                    var ngayNhapValue = row.Cells[7].Value;
                    if (ngayNhapValue != null && ngayNhapValue.ToString() != "")
                    {
                        ngaynhap.Text = Convert.ToDateTime(ngayNhapValue).ToString("yyyy-MM-dd");
                    }

                    var anh = row.Cells[8].Value as Image;
                    ptbanh.Image = anh;
                }
            }
        }
        public List<SanPham> View()
        {
            return db.SanPhams.ToList();
           
        }
        public List<SanPham> Display()
        {
            List<SanPham> sp = new List<SanPham>();

            using (FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext())
            {
                var sanPhamsFromDB = (from sp1 in db.SanPhams
                                      select new
                                      {
                                          sp1.maSP,
                                          sp1.tenSP,
                                          sp1.moTa,
                                          sp1.Gia,
                                          sp1.maThuongHieu,
                                          sp1.maLoai,
                                          sp1.soLuongTrongKho,
                                          sp1.NgayNhap,
                                          sp1.Anh

                                      }).ToList();

                foreach (var item in sanPhamsFromDB)
                {
                    SanPham sanPham = new SanPham();
                    sanPham.maSP = item.maSP;
                    sanPham.tenSP = item.tenSP;
                    sanPham.moTa = item.moTa;
                    sanPham.Gia = item.Gia;
                    sanPham.maThuongHieu = item.maThuongHieu;
                    sanPham.maLoai = item.maLoai;
                    sanPham.soLuongTrongKho = item.soLuongTrongKho;
                    sanPham.NgayNhap = item.NgayNhap;
                    sanPham.Anh = item.Anh;

                    sp.Add(sanPham);
                }
            }
            return sp;
        }

        public List<ThuongHieu> LoadTH()
        {
            using (var db = new FPT_Shop_Real_dbDataContext())
            {
                var thuongHieuData = db.ThuongHieus
                                        .Select(el => new
                                        {
                                            el.maThuongHieu,
                                            el.tenThuongHieu,
                                            el.quocGia
                                        })
                                        .AsEnumerable()
                                        .Select(el => new ThuongHieu
                                        {
                                            maThuongHieu = el.maThuongHieu,
                                            tenThuongHieu = el.tenThuongHieu,
                                            quocGia = el.quocGia
                                        })
                                        .ToList();

                return thuongHieuData;
            }
        }
        public List<LoaiSP> LoadLoaiSP()
        {
            using (var db = new FPT_Shop_Real_dbDataContext())
            {
                var loaiSPData = db.LoaiSPs
                                        .Select(el => new
                                        {
                                            el.maLoai,
                                            el.tenLoai,
                                            el.moTa
                                        })
                                        .AsEnumerable()
                                        .Select(el => new LoaiSP
                                        {
                                            maLoai = el.maLoai,
                                            tenLoai = el.tenLoai,
                                            moTa = el.moTa
                                        })
                                        .ToList();

                return loaiSPData;
            }
        }
    }
}
