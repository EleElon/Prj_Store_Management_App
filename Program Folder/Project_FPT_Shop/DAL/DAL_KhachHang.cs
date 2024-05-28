using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhachHang
    {
        private FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();
        public List<KhachHang> View()
        {
           return db.KhachHangs.ToList();
        }
        public bool themKhachHang(string maKH, string tenKH, string gioiTinh, string diaChi, string SDT)
        {
            try
            {
                // Kiểm tra xem khách hàng đã tồn tại trong cơ sở dữ liệu chưa
                if (db.KhachHangs.Any(kh => kh.maKH == maKH))
                {
                    // Nếu khách hàng đã tồn tại, trả về false để chỉ ra rằng thêm không thành công
                    return false;
                }
              
                // Tạo một đối tượng mới của KhachHang và gán giá trị cho các thuộc tính
                KhachHang khachHang = new KhachHang();
                khachHang.maKH = maKH;
                khachHang.tenKH = tenKH;
                khachHang.gioiTinh = gioiTinh;
                khachHang.diaChi = diaChi;
                khachHang.SDT = SDT;

                // Thêm khách hàng vào cơ sở dữ liệu và lưu các thay đổi
                db.KhachHangs.InsertOnSubmit(khachHang);
                db.SubmitChanges();

                // Trả về true để chỉ ra rằng thêm thành công
                return true;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }
        public bool XoaKhachHang(string maKH)
        {
            try
            {
                // Tìm kiếm khách hàng cần xóa trong cơ sở dữ liệu
                KhachHang khachHang = db.KhachHangs.FirstOrDefault(kh => kh.maKH == maKH);

                // Kiểm tra xem khách hàng có tồn tại không
                if (khachHang != null)
                {
                    // Nếu khách hàng tồn tại, xóa khách hàng và lưu các thay đổi vào cơ sở dữ liệu
                    db.KhachHangs.DeleteOnSubmit(khachHang);
                    db.SubmitChanges();
                    return true; // Trả về true để chỉ ra rằng xóa thành công
                }
                else
                {
                    // Nếu không tìm thấy khách hàng, trả về false để chỉ ra rằng xóa không thành công
                    return false;
                }
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }
        public bool SuaThongTinKhachHang(string maKH, string tenKHMoi, string gioiTinhMoi, string diaChiMoi, string SDTMoi)
        {
            try
            {
                KhachHang khachHang = db.KhachHangs.FirstOrDefault(kh => kh.maKH == maKH);

                if (khachHang != null)
                {
                    khachHang.tenKH = tenKHMoi;
                    khachHang.gioiTinh = gioiTinhMoi;
                    khachHang.diaChi = diaChiMoi;
                    khachHang.SDT = SDTMoi;

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

    }
}
