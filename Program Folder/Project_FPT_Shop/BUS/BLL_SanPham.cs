using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
namespace BLL
{
    public class BLL_SanPham
    {
        public static BLL_SanPham instance;

        public static BLL_SanPham Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BLL_SanPham();
                }
                return instance;
            }


        }
        public BLL_SanPham() { }
       

        private DAL_SanPham dal = new DAL_SanPham();

        public bool themSanPham(TextBox masp, TextBox tensp, TextBox mota, TextBox gia, ComboBox mathuonghieu, ComboBox maloai, TextBox soluongtrongkho, DateTimePicker ngaynhap, TextBox anh)
        {
            try
            {
                // Gọi phương thức thêm sản phẩm từ DAL_SanPham
                dal.themSanPham(masp, tensp, mota, gia, mathuonghieu, maloai, soluongtrongkho, ngaynhap, anh);
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
                return false;
            }
        }


        //public bool xoaSanPham(string maSP) { return dal.xoa(maSP); }

        public void xoaSanPham(TextBox masp) { DAL_SanPham.Instance.xoa(masp.Text); }

        //public bool suaSanPham(SanPham sp) { return dal.suaSanPham(sp); }
        public void Sua(TextBox masp, TextBox tensp, TextBox mota, TextBox gia, ComboBox mathuonghieu, ComboBox maloai, TextBox soluongtrongkho, DateTimePicker ngaynhap, TextBox anh)
        {
            if (!string.IsNullOrEmpty(anh.Text))
            {
                string[] cattenanh = anh.Text.Split('\\');
                int lastIndex = cattenanh.Length - 1;
                string tenanh = cattenanh[lastIndex];
                string duongdan = Path.Combine(Application.StartupPath, "Image");
                string duongdanmoi = duongdan + "\\" + tenanh;
                SanPham sp = new SanPham
                {
                    maSP = masp.Text,
                    tenSP = tensp.Text,
                    moTa = mota.Text,
                    Gia = float.Parse(gia.Text),
                    maThuongHieu = mathuonghieu.SelectedValue.ToString(),
                    maLoai = maloai.SelectedValue.ToString(),
                    soLuongTrongKho = int.Parse(soluongtrongkho.Text),
                    NgayNhap = DateTime.Parse(ngaynhap.Text),
                    Anh = duongdanmoi,
                };
                DAL_SanPham.Instance.suaSanPham(sp);
            }
            else
            {
                SanPham sp = new SanPham
                {
                    maSP = masp.Text,
                    tenSP = tensp.Text,
                    moTa = mota.Text,
                    Gia = float.Parse(gia.Text),
                    maThuongHieu = mathuonghieu.SelectedValue.ToString(),
                    maLoai = maloai.SelectedValue.ToString(),
                    soLuongTrongKho = int.Parse(soluongtrongkho.Text),
                    NgayNhap = DateTime.Parse(ngaynhap.Text),
                    Anh = LayHinhAnhBangMaSP(masp),

                };
                DAL_SanPham.Instance.suaSanPham(sp);
            }
        }

        public string LayHinhAnhBangMaSP(TextBox masp)
        {
            return DAL_SanPham.Instance.LayAnhBangMaSp(masp);
        }
        public List<SanPham> View()
        {
            return dal.View();
        }

        public void HienThi(DataGridView data)
        {
            var dt = DAL_SanPham.Instance.Display().Select(t =>
            {
                var HinhAnh = Image.FromFile(t.Anh);

                return new
                {
                    t.maSP,
                    t.tenSP,
                    t.moTa,
                    t.Gia,
                    t.maThuongHieu,
                    t.maLoai,
                    t.soLuongTrongKho,
                    t.NgayNhap,
                    HinhAnh

                };
            }).ToList();
            data.DataSource = dt;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)data.Columns[8];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        public void LoadDgvLenForm(TextBox masp, TextBox tensp, TextBox mota, TextBox gia, ComboBox mathuonghieu, ComboBox maloai, TextBox soluongtrongkho, DateTimePicker ngaynhap, PictureBox anh,/* TextBox txtanh,*/ DataGridView data)
        {
            DAL_SanPham.Instance.LoadDgvLenForm(masp, tensp, mota, gia, mathuonghieu, maloai, soluongtrongkho, ngaynhap, anh,/* txtanh,*/ data);
        }
    }
}
