using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class BLL_DonHang
    {
        public static BLL_DonHang instance;

        public static BLL_DonHang Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BLL_DonHang();
                }
                return instance;
            }


        }
        public BLL_DonHang() { }


        private DAL_DonHang dal = new DAL_DonHang();
        public bool themDonHang(DonHang dh) { return dal.themDonHang(dh); }
        //public bool xoaDonHang(DonHang dh) { return dal.xoaDonHang(dh); }
        public bool xoaDonHang(string maDonHang) { return dal.xoaDonHang(maDonHang); }
        //public bool suaDonHang(string maDH, string maKH, DateTime ngayMua, string TTDH, string PTTT, string maSP, string maNV, string maCN,float tongHD, float giaTungSP, int phantramGiamGia, int soLuong) { return dal.suaDonHang(maDH,maKH,ngayMua,TTDH,PTTT,maSP,maNV,maCN,tongHD,giaTungSP,phantramGiamGia, soLuong); }

        public void SuaDonHang(TextBox madh, TextBox makh, DateTimePicker ngaymua, TextBox tongdonhang, ComboBox ttdh, ComboBox pttt, ComboBox masp, TextBox soluong, TextBox giatungsp, TextBox phantramgiam, ComboBox machinhanh, ComboBox manv)
        {
            DonHang hd = new DonHang
            {
                maDonHang = madh.Text,
                maKH = makh.Text,
                ngayMua = DateTime.Parse(ngaymua.Text),
                tongDonHang = float.Parse(tongdonhang.Text),
                tinhTrangDatHang = ttdh.SelectedItem.ToString(),
                phuongThucThanhToan = pttt.SelectedItem.ToString(),
                maSP = masp.SelectedValue.ToString(),
                soLuong = int.Parse(soluong.Text),
                giaTungSP = float.Parse(giatungsp.Text),
                phanTramGiamGia = int.Parse(phantramgiam.Text),
                maChiNhanh = machinhanh.SelectedValue.ToString(),
                maNV = manv.SelectedValue.ToString(),

            };
            DAL_DonHang.Instance.Sua(hd);
        }
        public List<DonHang> View()
        {
            return dal.View();
        }
    }
}
