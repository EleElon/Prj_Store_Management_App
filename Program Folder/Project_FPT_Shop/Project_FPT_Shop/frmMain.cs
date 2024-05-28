using Project_FPT_Shop.Reporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_FPT_Shop
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void OpenChildFormInPanel(Form childForm, Panel panel)
        {
            panel.Controls.Clear(); // Xóa tất cả các điều khiển con trong Panel
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnMain.Controls.Add(childForm);
            pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void hệThôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmDonDatHang donHang = new frmDonDatHang();
            label1.Text = "Danh Sách Đơn Hàng";
            donHang.TopLevel = false;
            donHang.Dock = DockStyle.Fill;
            pnMain.Controls.Add(donHang);
            donHang.Show();
        }

        private void pnMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuKhachHang_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmKhachHang khachHang = new frmKhachHang();
            label1.Text = "Danh Sách Khách Hàng";
            khachHang.TopLevel = false;
            khachHang.Dock = DockStyle.Fill;
            pnMain.Controls.Add(khachHang);
            khachHang.Show();
        }

        private void MenuThuongHieu_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmThuongHieu thuongHieu = new frmThuongHieu();
            label1.Text = "Danh Sách Thương Hiệu";
            thuongHieu.TopLevel = false;
            thuongHieu.Dock = DockStyle.Fill;
            pnMain.Controls.Add(thuongHieu);
            thuongHieu.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmSanPham sanPham = new frmSanPham();
            label1.Text = "Danh Sách Sản Phẩm";
            sanPham.TopLevel = false;
            sanPham.Dock = DockStyle.Fill;
            pnMain.Controls.Add(sanPham);
            sanPham.Show();
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmLoaiSP loaiSP = new frmLoaiSP();
            label1.Text = "Danh Sách Loại Sản Phẩm";
            loaiSP.TopLevel = false;
            loaiSP.Dock = DockStyle.Fill;
            pnMain.Controls.Add(loaiSP);
            loaiSP.Show(); ;
        }

        private void nhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmNhanVien nhanVien = new frmNhanVien();
            label1.Text = "Danh Sách Nhân Viên";
            nhanVien.TopLevel = false;
            nhanVien.Dock = DockStyle.Fill;
            pnMain.Controls.Add(nhanVien);
            nhanVien.Show();
        }

        private void phiếuNhậpKhoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmPhieuNhapKho phieuNhapKho = new frmPhieuNhapKho();
            label1.Text = "Danh Sách Phiếu Nhập Kho";
            phieuNhapKho.TopLevel = false;
            phieuNhapKho.Dock = DockStyle.Fill;
            pnMain.Controls.Add(phieuNhapKho);
            phieuNhapKho.Show();
        }

        private void dSDHTheoGiáTrịToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmRptHienThiDSDHTheoTongDonHang rptHienThiDSDH = new frmRptHienThiDSDHTheoTongDonHang();
            //rptHienThiDSDH.TopLevel = false;
            //rptHienThiDSDH.Dock = DockStyle.Fill;
            //pnMain.Controls.Add(rptHienThiDSDH);
            //rptHienThiDSDH.Show();
            OpenChildFormInPanel(rptHienThiDSDH, pnMain);
            label1.Text = "FPT-Shop Report";
        }

        private void dSSPĐãMuaCủaKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmRptHienThiDSSPDaMuaCuaKH rptHienThiDSSP = new frmRptHienThiDSSPDaMuaCuaKH();
            //rptHienThiDSSP.TopLevel = false;
            //rptHienThiDSSP.Dock = DockStyle.Fill;
            //pnMain.Controls.Add(rptHienThiDSSP);
            //rptHienThiDSSP.Show();
            OpenChildFormInPanel(rptHienThiDSSP, pnMain);
            label1.Text = "FPT-Shop Report";
        }

        private void dSSPCủaNhânViênXuấtĐơnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmRptHienThiDSSPNhanVienSuatDon rptHienThiDSSP = new frmRptHienThiDSSPNhanVienSuatDon();
            //rptHienThiDSSP.TopLevel = false;
            //rptHienThiDSSP.Dock = DockStyle.Fill;
            //pnMain.Controls.Add(rptHienThiDSSP);
            //rptHienThiDSSP.Show();
            OpenChildFormInPanel(rptHienThiDSSP, pnMain);
            label1.Text = "FPT-Shop Report";
        }

        private void dSSPNhậpKhoCủaNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmRptHienThiDSSPNhapKhoTheoNhanVien rptHienThiDSSP = new frmRptHienThiDSSPNhapKhoTheoNhanVien();
            //rptHienThiDSSP.TopLevel = false;
            //rptHienThiDSSP.Dock = DockStyle.Fill;
            //pnMain.Controls.Add(rptHienThiDSSP);
            //rptHienThiDSSP.Show();
            OpenChildFormInPanel(rptHienThiDSSP, pnMain);
            label1.Text = "FPT-Shop Report";
        }

        private void dSSPTheoGiáToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmRptHienThiDSSPTheoGia rptHienThiDSSP = new frmRptHienThiDSSPTheoGia();
            //rptHienThiDSSP.TopLevel = false;
            //rptHienThiDSSP.Dock = DockStyle.Fill;
            //pnMain.Controls.Add(rptHienThiDSSP);
            //rptHienThiDSSP.Show();
            OpenChildFormInPanel(rptHienThiDSSP, pnMain);
            label1.Text = "FPT-Shop Report";
        }

        private void dSSPTheoNgàyNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmRptHienThiDSSPTheoNgayNhap rptHienThiDSSP = new frmRptHienThiDSSPTheoNgayNhap();
            //rptHienThiDSSP.TopLevel = false;
            //rptHienThiDSSP.Dock = DockStyle.Fill;
            //pnMain.Controls.Add(rptHienThiDSSP);
            //rptHienThiDSSP.Show();
            OpenChildFormInPanel(rptHienThiDSSP, pnMain);
            label1.Text = "FPT-Shop Report";
        }

        private void dSTHTheoQuốcGiaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmRptHienThiDSTHTheoQuocGia rptHienThiDSTH = new frmRptHienThiDSTHTheoQuocGia();
            //rptHienThiDSTH.TopLevel = false;
            //rptHienThiDSTH.Dock = DockStyle.Fill;
            //pnMain.Controls.Add(rptHienThiDSTH);
            //rptHienThiDSTH.Show();
            OpenChildFormInPanel(rptHienThiDSTH, pnMain);
            label1.Text = "FPT-Shop Report";
        }

        private void dSSPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmRptTimKiemSanPhamTheoLoai rptTimKiemSanPham = new frmRptTimKiemSanPhamTheoLoai();
            //rptTimKiemSanPham.TopLevel = false;
            //rptTimKiemSanPham.Dock = DockStyle.Fill;
            //pnMain.Controls.Add(rptTimKiemSanPham);
            //rptTimKiemSanPham.Show();
            OpenChildFormInPanel(rptTimKiemSanPham, pnMain);
            label1.Text = "FPT-Shop Report";
        }

        

        private void btnSanPham_Click_1(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmSanPham sanPham = new frmSanPham();
            label1.Text = "Danh Sách Sản Phẩm";
            sanPham.TopLevel = false;
            sanPham.Dock = DockStyle.Fill;
            pnMain.Controls.Add(sanPham);
            sanPham.Show();
        }

        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmLoaiSP loaiSP = new frmLoaiSP();
            label1.Text = "Danh Sách Loại Sản Phẩm";
            loaiSP.TopLevel = false;
            loaiSP.Dock = DockStyle.Fill;
            pnMain.Controls.Add(loaiSP);
            loaiSP.Show(); ;
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmNhanVien nhanVien = new frmNhanVien();
            label1.Text = "Danh Sách Nhân Viên";
            nhanVien.TopLevel = false;
            nhanVien.Dock = DockStyle.Fill;
            pnMain.Controls.Add(nhanVien);
            nhanVien.Show();
        }

        private void btnPNK_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmPhieuNhapKho phieuNhapKho = new frmPhieuNhapKho();
            label1.Text = "Danh Sách Phiếu Nhập Kho";
            phieuNhapKho.TopLevel = false;
            phieuNhapKho.Dock = DockStyle.Fill;
            pnMain.Controls.Add(phieuNhapKho);
            phieuNhapKho.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void MenuChiNhanh_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmChiNhanh Cn = new frmChiNhanh();
            label1.Text = "Danh Sách Chi Nhánh";
            Cn.TopLevel = false;
            Cn.Dock = DockStyle.Fill;
            pnMain.Controls.Add(Cn);
            Cn.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDangNhap fr = new frmDangNhap();
            fr.ShowDialog();
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmDonDatHang ddh = new frmDonDatHang();
            label1.Text = "Danh Sách Đơn Đặt Hàng";
            ddh.TopLevel = false;
            ddh.Dock = DockStyle.Fill;
            pnMain.Controls.Add(ddh);
            ddh.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmKhachHang kh = new frmKhachHang();
            label1.Text = "Danh Sách Khách Hàng";
            kh.TopLevel = false;
            kh.Dock = DockStyle.Fill;
            pnMain.Controls.Add(kh);
            kh.Show();
        }

        private void btnThuongHieu_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmThuongHieu th = new frmThuongHieu();
            label1.Text = "Danh Sách Thương Hiệu";
            th.TopLevel = false;
            th.Dock = DockStyle.Fill;
            pnMain.Controls.Add(th);
            th.Show();
        }

        private void btnChiNhanh_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmChiNhanh nc = new frmChiNhanh();
            label1.Text = "Danh Sách Chi Nhánh";
            nc.TopLevel = false;
            nc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(nc);
            nc.Show();
        }
    }
}
