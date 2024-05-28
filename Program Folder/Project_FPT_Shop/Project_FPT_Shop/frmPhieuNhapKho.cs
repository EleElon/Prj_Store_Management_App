using BLL;
using BUS;
using DAL;
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
    public partial class frmPhieuNhapKho : Form
    {
        private BLL_PhieuNhapKho bll = new BLL_PhieuNhapKho();
        private BLL_Cbb nv = new BLL_Cbb();
        private PhieuNhapKho dto = new PhieuNhapKho();
        public frmPhieuNhapKho()
        {
            InitializeComponent();
            LoadToComboBox();
        }

        private void LoadToComboBox()
        {
            // sửa lại thành loadNV khi có DLL_NhanVien
            List<NhanVien> item = nv.LoadNV();
            cboMaNV.DataSource = item;
            cboMaNV.DisplayMember = "tenNV";
            cboMaNV.ValueMember = "maNV";
        }
        public void LoadView()
        {
            //bll.View();
            dgvPNK.DataSource = bll.View();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text != "" && txtTenSP.Text != "" && dtpNgayNhap.Text != "" && txtTongTien.Text != "" && txtSoLuong.Text != "" && cboMaNV.Text != "")
            {
                dto.maPNK = txtMaPhieu.Text;
                dto.tenSP = txtTenSP.Text;
                dto.ngayNhap = DateTime.Parse(dtpNgayNhap.Text);
                dto.tongDonGia = float.Parse(txtTongTien.Text);
                dto.soLuong = int.Parse(txtSoLuong.Text);
                dto.maNV = cboMaNV.SelectedValue.ToString();
                if (bll.themPhieuNhapKho(dto))
                {
                    MessageBox.Show("them thanh cong", "thong bao");
                    LoadView();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("vui long nhap thong tin", "thong bao");
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text != "" && txtTenSP.Text != "" && dtpNgayNhap.Text != "" && txtTongTien.Text != "" && txtSoLuong.Text != "" && cboMaNV.Text != "")
            {
                string maPNK = txtMaPhieu.Text;

                bool result = bll.xoaPhieuNhapKho(maPNK);

                if (result)
                {
                    MessageBox.Show("xoa thanh cong", "thong bao");
                    LoadView();
                }
                else
                {
                    MessageBox.Show("xoa khong thanh cong", "thong bao");
                }
            }
            else
            {
                MessageBox.Show("vui long chon mot doi tuong de xoa", "thong bao");
            }
        }

        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text != "" && txtTenSP.Text != "" && dtpNgayNhap.Text != "" && txtTongTien.Text != "" && txtSoLuong.Text != "" && cboMaNV.Text != "")
            {
                dto.maPNK = txtMaPhieu.Text;
                dto.tenSP = txtTenSP.Text;
                dto.ngayNhap = DateTime.Parse(dtpNgayNhap.Text);
                dto.tongDonGia = float.Parse(txtTongTien.Text);
                dto.soLuong = int.Parse(txtSoLuong.Text);
                dto.maNV = cboMaNV.SelectedValue.ToString();
                if (bll.suaPhieuNhapKho(dto))
                {
                    MessageBox.Show("sua thanh cong", "thong bao");
                    LoadView();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("vui long chon mot doi tuong de sua", "thong bao");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPNK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvPNK.Rows[e.RowIndex];

            // Hiển thị thông tin của dòng được chọn lên các TextBox tương ứng
            txtMaPhieu.Text = row.Cells[0].Value.ToString();
            txtTenSP.Text = row.Cells[1].Value.ToString();
            dtpNgayNhap.Value = Convert.ToDateTime(row.Cells[2].Value);
            txtTongTien.Text = row.Cells[3].Value.ToString();
            txtSoLuong.Text = row.Cells[4].Value.ToString();

            //cboMaNV.Text = row.Cells[5].Value.ToString();

            string maNVn = row.Cells[5].Value.ToString();
            foreach (NhanVien NV in cboMaNV.Items)
            {
                if (NV.maNV == maNVn)
                {
                    cboMaNV.SelectedItem = NV;
                    break;
                }
            }
        }

        private void frmPhieuNhapKho_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            LoadView();
        }
    }
}
