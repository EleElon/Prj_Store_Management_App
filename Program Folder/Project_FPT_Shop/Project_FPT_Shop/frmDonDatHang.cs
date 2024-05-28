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
using System.Web;
using System.Windows.Forms;

namespace Project_FPT_Shop
{
    public partial class frmDonDatHang : Form
    {
        private BLL_DonHang bll = new BLL_DonHang();
        private BLL_Cbb cbbs = new BLL_Cbb();
        private DonHang dto = new DonHang();
        public frmDonDatHang()
        {
            InitializeComponent();
            LoadToComboBoxes();
            DataComboBox();
        }

        private void DataComboBox()
        {
            cboTTDH.Items.Add("Da Giao Hang");
            cboTTDH.Items.Add("Dang Xu Ly");

            cboPTTT.Items.Add("Thanh Toan Khi Nhan Duoc Hang");
            cboPTTT.Items.Add("Thanh Toan Qua The");
            cboPTTT.Items.Add("Thanh Toan Bang Tien Mat");
        }
        private void LoadToComboBoxes()
        {
            List<NhanVien> nvItem = cbbs.LoadNV();
            cboMaNV.DataSource = nvItem;
            cboMaNV.DisplayMember = "tenNV";
            cboMaNV.ValueMember = "maNV";

            List<SanPham> spItem = cbbs.LoadSanPham();
            cboMaSP.DataSource = spItem;
            cboMaSP.DisplayMember = "tenSP";
            cboMaSP.ValueMember = "maSP";

            List<ChiNhanh> cnItem = cbbs.LoadChiNhanh();
            cboMaChiNhanh.DataSource = cnItem;
            cboMaChiNhanh.DisplayMember = "tenChiNhanh";
            cboMaChiNhanh.ValueMember = "maChiNhanh";

            cboMaSP.SelectedIndexChanged += cboMaSP_SelectedIndexChanged;
        }


        public void LoadView()
        {
            //bll.View();
            dgvDSDH.DataSource = bll.View();
            // Thiết lập giá trị mặc định cho cboTTDH và cboPTTT (nếu cần)
            if (cboTTDH.Items.Count > 0)
            {
                cboTTDH.SelectedIndex = 0; // Chọn giá trị đầu tiên trong danh sách
            }
            if (cboPTTT.Items.Count > 0)
            {
                cboPTTT.SelectedIndex = 0; // Chọn giá trị đầu tiên trong danh sách
            }
        }

        private void dgvDSDH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDSDH.Rows[e.RowIndex];

            // Hiển thị thông tin của dòng được chọn lên các TextBox tương ứng
            txtMaDH.Text = row.Cells[0].Value.ToString();
            txtMaKH.Text = row.Cells[1].Value.ToString();
            dtpNgayMua.Value = Convert.ToDateTime(row.Cells[2].Value);
            txtDonGia.Text = row.Cells[3].Value.ToString();
            txtGiaTungSP.Text = row.Cells[8].Value.ToString();
            cboTTDH.Text = row.Cells[4].Value.ToString();
            cboPTTT.Text = row.Cells[5].Value.ToString();
            //cboMaSP.Text = row.Cells[6].Value.ToString();
            string maSPp = row.Cells[6].Value.ToString();
            foreach (SanPham maSP in cboMaSP.Items)
            {
                if (maSP.maSP == maSPp)
                {
                    cboMaSP.SelectedItem = maSP;
                    break;
                }
            }
            txtSoLuong.Text = row.Cells[7].Value.ToString();
            txtGiamGia.Text = row.Cells[9].Value.ToString();
            //cboMaChiNhanh.Text = row.Cells[9].Value.ToString();
            string maCNn = row.Cells[10].Value.ToString();
            foreach (ChiNhanh CN in cboMaChiNhanh.Items)
            {
                if (CN.maChiNhanh == maCNn)
                {
                    cboMaChiNhanh.SelectedItem = CN;
                    break;
                }
            }
            //cboMaNV.Text = row.Cells[10].Value.ToString(); 
            string maNVv = row.Cells[11].Value.ToString();
            foreach (NhanVien NV in cboMaNV.Items)
            {
                if (NV.maNV == maNVv)
                {
                    cboMaNV.SelectedItem = NV;
                    break;
                }
            }
        }

        private void btnThemDDH_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text != "" && txtMaKH.Text != "" && dtpNgayMua.Text != "" && cboTTDH.Text != "" && cboPTTT.Text != "" && cboMaSP.Text != "" && txtSoLuong.Text != "" && txtDonGia.Text != "" && txtGiaTungSP.Text != "" && cboMaChiNhanh.Text != "" && cboMaNV.Text != "" && txtGiamGia.Text != "")
            {
                dto.maDonHang = txtMaDH.Text;
                dto.maKH = txtMaKH.Text;
                dto.ngayMua = DateTime.Parse(dtpNgayMua.Text);
                //dto.tinhTrangDatHang = cboTTDH.SelectedValue.ToString();
                //dto.phuongThucThanhToan = cboPTTT.SelectedValue.ToString();
                if (cboTTDH.SelectedItem != null)
                {
                    dto.tinhTrangDatHang = cboTTDH.SelectedItem.ToString();
                }

                if (cboPTTT.SelectedItem != null)
                {
                    dto.phuongThucThanhToan = cboPTTT.SelectedItem.ToString();
                }
                dto.maSP = cboMaSP.SelectedValue.ToString();
                dto.soLuong = int.Parse(txtSoLuong.Text);
                dto.tongDonHang = float.Parse(txtDonGia.Text);
                dto.giaTungSP = float.Parse(txtGiaTungSP.Text);
                dto.phanTramGiamGia = int.Parse(txtGiamGia.Text);
                dto.maChiNhanh = cboMaChiNhanh.SelectedValue.ToString();
                dto.maNV = cboMaNV.SelectedValue.ToString();
                if (bll.themDonHang(dto))
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

        private void btnXoaDDH_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text != "" && txtMaKH.Text != "" && dtpNgayMua.Text != "" && cboTTDH.Text != "" && cboPTTT.Text != "" && cboMaSP.Text != "" && txtSoLuong.Text != "" && txtDonGia.Text != "" && txtGiaTungSP.Text != "" && cboMaChiNhanh.Text != "" && cboMaNV.Text != "" && txtGiamGia.Text != "")
            {
                //if (bll.xoaDonHang(dto))
                //{
                //    MessageBox.Show("xoa thanh cong", "thong bao");
                //    LoadView();
                //}
                //else
                //{
                //    return;
                //}

                string maDHang = txtMaDH.Text;
                bool result = bll.xoaDonHang(maDHang);

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

        private void btnSuaDDH_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text != "" && txtMaKH.Text != "" && dtpNgayMua.Text != "" && cboTTDH.Text != "" && cboPTTT.Text != "" && cboMaSP.Text != "" && txtSoLuong.Text != "" && txtDonGia.Text != "" && txtGiaTungSP.Text != "" && cboMaChiNhanh.Text != "" && cboMaNV.Text != "" && txtGiamGia.Text != "")
            {
                

                BLL_DonHang.Instance.SuaDonHang(txtMaDH, txtMaKH, dtpNgayMua, txtDonGia, cboTTDH, cboPTTT, cboMaSP, txtSoLuong, txtGiaTungSP, txtGiamGia, cboMaChiNhanh, cboMaNV);
              //  LoadView();
                MessageBox.Show("sua don hang thanh cong", "thong bao");
                dgvDSDH.DataSource = bll.View();
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

        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            LoadView();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void txtGiaTungSP_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn một mã sản phẩm chưa
            if (cboMaSP.SelectedItem != null)
            {
                // Lấy mã sản phẩm được chọn
                string maSPChon = cboMaSP.SelectedValue.ToString();

                // Tìm giá sản phẩm tương ứng với mã sản phẩm
                foreach (SanPham sp in cboMaSP.Items)
                {
                    if (sp.maSP == maSPChon)
                    {
                        // Gán giá sản phẩm vào TextBox giá từng sản phẩm
                        txtGiaTungSP.Text = sp.Gia.ToString();
                        break;
                    }
                }
            }
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }
        private void CalculateTotalPrice()
        {
            if (float.TryParse(txtSoLuong.Text, out float soLuong) && float.TryParse(txtGiaTungSP.Text, out float giaTungSP) && float.TryParse(txtGiamGia.Text, out float phanTramGiamGia))
            {
                float giaSauGiamGia = (giaTungSP * ((100 - phanTramGiamGia) / 100)) * soLuong;
                //txtDonGia.Text = giaSauGiamGia.ToString();

                // Định dạng số để hiển thị đúng trong TextBox
                txtDonGia.Text = giaSauGiamGia.ToString("N0"); // "N0" để hiển thị số nguyên, không có dấu phẩy

            }
        }
    }
}
