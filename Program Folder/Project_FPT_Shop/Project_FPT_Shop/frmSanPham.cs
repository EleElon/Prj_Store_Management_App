    using BLL;
using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_FPT_Shop
{
    public partial class frmSanPham : Form
    {
        private BLL_SanPham bll = new BLL_SanPham();
        private BLL_Cbb th = new BLL_Cbb();
        private SanPham dto = new SanPham();
        public frmSanPham()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            List<ThuongHieu> item = th.LoadTH();
            cboMaThuongHieu.DataSource = item;
            cboMaThuongHieu.DisplayMember = "tenThuongHieu";
            cboMaThuongHieu.ValueMember = "maThuongHieu";

            List<LoaiSP> spItem = th.LoadLoaiSP();
            cboMaLoaiSP.DataSource = spItem;
            cboMaLoaiSP.DisplayMember = "tenLoai";
            cboMaLoaiSP.ValueMember = "maLoai";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BLL_SanPham.Instance.LoadDgvLenForm(txtMaSP, txtTenSP, txtMoTa, txtGia, cboMaThuongHieu, cboMaLoaiSP, txtSoLuong, dtpNgayNhap, ptbHinhAnh, /*txtHinhAnh,*/ dgvDSSP);
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text != "" && txtTenSP.Text != "" && txtMoTa.Text != "" && txtHinhAnh.Text != "" && cboMaThuongHieu.Text != "" && cboMaLoaiSP.Text != "" && txtSoLuong.Text != "" && dtpNgayNhap.Text != "" && txtGia.Text != "")
            {
                BLL_SanPham.Instance.Sua(txtMaSP, txtTenSP, txtMoTa, txtGia, cboMaThuongHieu, cboMaLoaiSP, txtSoLuong, dtpNgayNhap, txtHinhAnh);
                LoadViewSua();
                MessageBox.Show("sua san pham thanh cong", "thong bao");
                //dgvDSSP.Refresh();
            }
            else
            {
                MessageBox.Show("vui long chon doi tuong de sua", "thong bao");
            }
        }
        public void LayHinhAnhBangMaSP()
        {
            BLL_SanPham.Instance.LayHinhAnhBangMaSP(txtMaSP);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text != "" && txtTenSP.Text != "" && txtMoTa.Text != "" && txtHinhAnh.Text != "" && cboMaThuongHieu.Text != "" && cboMaLoaiSP.Text != "" && txtSoLuong.Text != "" && dtpNgayNhap.Text != "" && txtGia.Text != "")
            {
                BLL_SanPham.Instance.themSanPham(txtMaSP, txtTenSP, txtMoTa, txtGia, cboMaThuongHieu, cboMaLoaiSP, txtSoLuong, dtpNgayNhap, txtHinhAnh);
                LoadViewSua();
                MessageBox.Show("them san pham thanh cong", "thong bao");
            }
            else
            {
                MessageBox.Show("vui long nhap thong tin", "thong bao");
            }
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            //LoadView();
            this.FormBorderStyle = FormBorderStyle.None;
            LoadViewSua();
        }
        public void LoadView()
        {
            //bll.View();
            dgvDSSP.DataSource = bll.View();
        }
        public void LoadViewSua()
        {
            BLL_SanPham.Instance.HienThi(dgvDSSP);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text != "" && txtTenSP.Text != "" && txtMoTa.Text != "" && txtHinhAnh.Text != "" && cboMaThuongHieu.Text != "" && cboMaLoaiSP.Text != "" && txtSoLuong.Text != "" && dtpNgayNhap.Text != "")
            {
                BLL_SanPham.Instance.xoaSanPham(txtMaSP);
                LoadViewSua();
                MessageBox.Show("xoa san pham thanh cong", "thong bao");
            }
            else
            {
                MessageBox.Show("vui long chon mot doi tuong de xoa", "thong bao");
            }
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png)|*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the image location and display it in PictureBox
                ptbHinhAnh.ImageLocation = openFileDialog.FileName;
                txtHinhAnh.Text = openFileDialog.FileName;

                // Get the selected file name and destination path
                string selectedFileName = Path.GetFileName(openFileDialog.FileName);
                string destinationPath = Path.Combine(Application.StartupPath, "Image", selectedFileName);

                try
                {
                    // Copy the selected file to the "hinhanh" folder
                    File.Copy(openFileDialog.FileName, destinationPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi sao chép hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
