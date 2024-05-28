using BUS;
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
    public partial class frmNhanVien : Form
    {
        BLL_NhanVien bll_NV = new BLL_NhanVien();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;
            string gioiTinh = radNam.Checked ? "Nam" : "Nu";
            DateTime ngaySinh = dtpNgaySinh.Value;
            string sdt= txtSDT.Text;
            float luong = float.Parse(txtLuong.Text);
            string diaChi = txtDiaChi.Text;

            bool result = bll_NV.ThemNhanVien(maNV, tenNV, gioiTinh, ngaySinh, sdt, luong, diaChi);
            if (result)
            {
                MessageBox.Show("Thêm nhân viên thành công.");
                LoadView();
                //ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên không thành công. Nhân viên đã tồn tại.");
            }
        }

        private void dateTimePikerNgayDiLam_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            bool result = bll_NV.XoaNhanVien(maNV);
            if (result)
            {
                MessageBox.Show("Xóa nhân viên thành công.");
                LoadView();
                //ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Xóa nhân viên không thành công. Không tìm thấy nhân viên.");
            }
        }
        private void ClearTextBoxes()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtLuong.Text = "";
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;
            string gioiTinh = radNam.Checked ? "Nam" : "Nu";
            DateTime ngaySinh = dtpNgaySinh.Value;
            string sdt = txtSDT.Text;
            float luong = float.Parse(txtLuong.Text);
            string diaChi = txtDiaChi.Text;

            bool result = bll_NV.SuaThongTinNhanVien(maNV, tenNV, gioiTinh, ngaySinh, sdt, luong, diaChi);
            if (result)
            {
                MessageBox.Show("Sửa thông tin nhân viên thành công.");
                LoadView();
                //ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Sửa thông tin nhân viên không thành công. Không tìm thấy nhân viên.");
            }
        }

        private void dataGridVNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridVNhanVien.Rows[e.RowIndex];

            // Hiển thị thông tin của dòng được chọn lên các TextBox tương ứng
            txtMaNV.Text = row.Cells[0].Value.ToString();
            txtTenNV.Text = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value.ToString() == "Nam")
            {
                radNam.Checked = true;
                radNu.Checked = false;
            }
            else
            {
                radNam.Checked = false;
                radNu.Checked = true;
            }
            dtpNgaySinh.Value = Convert.ToDateTime(row.Cells[3].Value);
            txtSDT.Text = row.Cells[4].Value.ToString();
            txtLuong.Text = row.Cells[5].Value.ToString(); // Cột 5
            txtDiaChi.Text = row.Cells[6].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
           
                this.Close();
         
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            LoadView();
        }

        public void LoadView()
        {
            dataGridVNhanVien.DataSource = bll_NV.View();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
