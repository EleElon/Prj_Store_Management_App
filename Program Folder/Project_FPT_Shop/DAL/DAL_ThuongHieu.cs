using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThuongHieu
    {
        private FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();

        private static DAL_ThuongHieu instance;

        public static DAL_ThuongHieu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_ThuongHieu();
                }
                return instance;
            }


        }
        public DAL_ThuongHieu() { }

        public bool themThuongHieu(ThuongHieu dto)
        {
            ThuongHieu TH = new ThuongHieu();
            TH.maThuongHieu = dto.maThuongHieu;
            TH.tenThuongHieu = dto.tenThuongHieu;
            TH.quocGia = dto.quocGia;
            db.ThuongHieus.InsertOnSubmit(TH);
            db.SubmitChanges();
            return true;
        }
        public bool xoaThuongHieu(string maTH)
        {
            ThuongHieu Th = db.ThuongHieus.FirstOrDefault(p => p.maThuongHieu == maTH);
            if (Th != null)
            {
                db.ThuongHieus.DeleteOnSubmit(Th);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool suaThuongHieu(ThuongHieu dto)
        {
            // Tìm thương hiệu cần cập nhật dựa trên mã
            ThuongHieu th = db.ThuongHieus.Where(p => p.maThuongHieu == dto.maThuongHieu).SingleOrDefault();

            // Kiểm tra xem th có null hay không
            if (th != null)
            {
                // Cập nhật thông tin thương hiệu
                th.tenThuongHieu = dto.tenThuongHieu;
                th.quocGia = dto.quocGia;

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();

                return true;
            }
            else
            {
                // Đối tượng không tồn tại, không có gì để cập nhật
                return false;
            }
        }

        
        public List<ThuongHieu> View()
        {
            return db.ThuongHieus.ToList();
        }
    }
}
