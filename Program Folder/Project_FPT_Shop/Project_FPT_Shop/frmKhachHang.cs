using BLL;
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
    public partial class frmKhachHang : Form
    {
        BLL_KhachHang bll_khachHang = new BLL_KhachHang();
        public frmKhachHang()
        {
            InitializeComponent();
        }



        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dataGridKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridKhachHang.DataSource = bll_khachHang.View();
            LoadView();
        }
        private void LoadView()
        {
            dataGridKhachHang.DataSource = bll_khachHang.View();
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text;
            string tenKH = txtTenKH.Text;
            string gioiTinh = radNam.Checked ? "Nam" : "Nu";
            string diaChi = txtDiaChi.Text;
            string SDT = txtSDT.Text;

            try
            {
                // Gọi phương thức sửa thông tin khách hàng từ BLL
                bool result = bll_khachHang.SuaThongTinKhachHang(maKH, tenKH, gioiTinh, diaChi, SDT);

                if (result)
                {
                    MessageBox.Show("Sửa thông tin khách hàng thành công!");
                    LoadView();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng cần sửa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void btnThemKH_Click_1(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text;
            string tenKH = txtTenKH.Text;
            string gioiTinh = radNam.Checked ? "Nam" : "Nu";
            string diaChi = txtDiaChi.Text;
            string SDT = txtSDT.Text;
            bool ketQua = bll_khachHang.ThemKhachHang(maKH, tenKH, gioiTinh, diaChi, SDT);

            if (ketQua)
            {
                MessageBox.Show("Thêm khách hàng thành công!");
                //dataGridKhachHang.DataSource = bll_khachHang.View();
                LoadView();
            }
            else if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin");
            }
            else
            {
                MessageBox.Show("Không thể thêm khách hàng. Khách hàng có thể đã tồn tại!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int iDong = e.RowIndex - 1;
            DataGridViewRow row = dataGridKhachHang.Rows[e.RowIndex];

            // Hiển thị thông tin của dòng được chọn lên các TextBox tương ứng
            txtMaKH.Text = row.Cells[0].Value.ToString();
            txtTenKH.Text = row.Cells[1].Value.ToString();
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
            txtDiaChi.Text = row.Cells[3].Value.ToString();
            txtSDT.Text = row.Cells[4].Value.ToString();
        }

        private void frmKhachHang_Load_1(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            dataGridKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridKhachHang.DataSource = bll_khachHang.View();
            LoadView();
        }

        private void btnXoaKH_Click_1(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text;
            bool ketQua = bll_khachHang.XoaKhachHang(maKH);
            if (ketQua)
            {
                MessageBox.Show("Xóa khách hàng thành công!");
                //dataGridKhachHang.DataSource = bll_khachHang.View();
                LoadView();
            }
            else
            {
                MessageBox.Show("Không thể xóa khách hàng. Vui lòng kiểm tra lại thông tin!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

           
                this.Close();
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
