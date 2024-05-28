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
    public partial class frmChiNhanh : Form
    {
        public frmChiNhanh()
        {
            InitializeComponent();
        }
        BLL_ChiNhanh bll_ChiNhanh = new BLL_ChiNhanh();
        private void ClearTextBoxes()
        {
            txtMaCN.Text = "";
            txtTenCN.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }
        private void LoadView()
        {
            dataGridChiNhanh.DataSource = bll_ChiNhanh.View();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maChiNhanh = txtMaCN.Text;
            string tenChiNhanh = txtTenCN.Text;
            string diaChi = txtDiaChi.Text;
            string SDT = txtSDT.Text;

            bool result = bll_ChiNhanh.ThemChiNhanh(maChiNhanh, tenChiNhanh, diaChi, SDT);

            if (result)
            {
                MessageBox.Show("Thêm chi nhánh thành công!");
                ClearTextBoxes();
                LoadView();
            }
            else
            {
                MessageBox.Show("Thêm chi nhánh không thành công!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maChiNhanh = txtMaCN.Text;

            bool result = bll_ChiNhanh.XoaChiNhanh(maChiNhanh);

            if (result)
            {
                MessageBox.Show("Xóa chi nhánh thành công!");
                ClearTextBoxes();
                LoadView();
            }
            else
            {
                MessageBox.Show("Xóa chi nhánh không thành công!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maChiNhanh = txtMaCN.Text;
            string tenChiNhanh = txtTenCN.Text;
            string diaChi = txtDiaChi.Text;
            string SDT = txtSDT.Text;

            bool result = bll_ChiNhanh.SuaThongTinChiNhanh(maChiNhanh, tenChiNhanh, diaChi, SDT);

            if (result)
            {
                MessageBox.Show("Sửa thông tin chi nhánh thành công!");
                ClearTextBoxes();
                LoadView();
            }
            else
            {
                MessageBox.Show("Sửa thông tin chi nhánh không thành công!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmChiNhanh_Load(object sender, EventArgs e)
        {
            //dataGridChiNhanh.DataSource = bll_ChiNhanh.View();
            this.FormBorderStyle = FormBorderStyle.None;
            LoadView();
        }

        private void dataGridDSCN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridChiNhanh.Rows[e.RowIndex];

            // Hiển thị thông tin của dòng được chọn lên các TextBox tương ứng
            txtMaCN.Text = row.Cells[0].Value.ToString();
            txtTenCN.Text = row.Cells[1].Value.ToString();
            txtDiaChi.Text = row.Cells[2].Value.ToString();
            txtSDT.Text = row.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

