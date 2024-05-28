using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BLL_Cbb
    {
        private DAL_SanPham dal_sp = new DAL_SanPham();
        private DAL_PhieuNhapKho dal_pnk = new DAL_PhieuNhapKho();
        private DAL_DonHang dal_sp_nv_cn_kh = new DAL_DonHang();

        public List<ThuongHieu> LoadTH()
        {
            return dal_sp.LoadTH();
        }

        public List<NhanVien> LoadNV()
        {
            return dal_pnk.LoadNV();
        }

        public List<SanPham> LoadSanPham()
        {
            return dal_sp_nv_cn_kh.LoadSP();
        }

        public List<ChiNhanh> LoadChiNhanh()
        {
            return dal_sp_nv_cn_kh.LoadCN();
        }

        public List<LoaiSP> LoadLoaiSP()
        {
            return dal_sp.LoadLoaiSP();
        }

        public List<KhachHang> LoadKH()
        {
            return dal_sp_nv_cn_kh.LoadKH();
        }
    }
}
