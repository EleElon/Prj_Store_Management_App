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
    public partial class frmDangNhap : Form
    {
        BLL_DangNhap bllDangNhap = new BLL_DangNhap();

        public frmDangNhap()
        {
            InitializeComponent();
            txtMatKhau.PasswordChar = '*';

            //txtTenDangNhap.KeyDown += new KeyEventHandler(txtTenDangNhap_KeyDown);
            //txtMatKhau.KeyDown += new KeyEventHandler(txtMatKhau_KeyDown);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTenDangNhap.Text.Trim()))
            {
                MessageBox.Show("vui lòng nhập user name");
                txtTenDangNhap.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtMatKhau.Text.Trim()))
            {
                MessageBox.Show("vui lòng nhập password");
                txtMatKhau.Focus();
                return;
            }
            string taiKhoan = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;

            // Kiểm tra đăng nhập
            bool ketQuaDangNhap = bllDangNhap.KiemTraDangNhap(taiKhoan, matKhau);

            // Hiển thị kết quả
            if (ketQuaDangNhap)
            {
                // Đăng nhập thành công, chuyển hướng đến form chính của ứng dụng
                frmMain mainForm = new frmMain();
                mainForm.Show();
                this.Hide(); // Ẩn form đăng nhập
            }
            else
            {
                // Đăng nhập không thành công, hiển thị thông báo lỗi
                MessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra lại tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;

            bool result = bllDangNhap.themUser(taiKhoan, matKhau);

            if (result)
            {
                MessageBox.Show("dang ki tai khoan thanh cong", "thong bao");
            }
            else
            {
                MessageBox.Show("dang ki tai khoan khong thanh cong", "thong bao");
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnDangNhap_Click(sender, e);
            //}
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
