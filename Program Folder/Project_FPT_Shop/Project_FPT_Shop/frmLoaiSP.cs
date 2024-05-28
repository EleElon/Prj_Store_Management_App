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
    public partial class frmLoaiSP : Form
    {
        BLL_LoaiSP bll_LoaiSP = new BLL_LoaiSP();
        public frmLoaiSP()
        {
            InitializeComponent();
        }

        private void frmLoaiSP_Load(object sender, EventArgs e)
        {
            //dataGridDSML.DataSource = bll_LoaiSP.View();
            this.FormBorderStyle = FormBorderStyle.None;
            LoadView();
        }
        private void LoadView()
        {
            dataGridDSML.DataSource = bll_LoaiSP.View();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maLoai = txtMaLoai.Text;
            string tenLoai = txtTenLoai.Text;
            string moTa = txtMoTa.Text;

            bool result = bll_LoaiSP.ThemLoaiSP(maLoai, tenLoai, moTa);
            if (result)
            {
                MessageBox.Show("Thêm loại sản phẩm thành công.");
                // Sau khi thêm thành công, làm mới danh sách loại sản phẩm
                // và làm sạch các ô textbox để chuẩn bị cho việc thêm loại sản phẩm mới.

                ClearTextBoxes();
                LoadView();
            }
            else
            {
                MessageBox.Show("Thêm loại sản phẩm không thành công. Loại sản phẩm đã tồn tại.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maLoai = txtMaLoai.Text;

            bool result = bll_LoaiSP.XoaLoaiSP(maLoai);
            if (result)
            {
                MessageBox.Show("Xóa loại sản phẩm thành công.");
                // Sau khi xóa thành công, làm mới danh sách loại sản phẩm
                // và làm sạch các ô textbox để chuẩn bị cho việc xóa loại sản phẩm khác.

                ClearTextBoxes();
                LoadView();
            }
            else
            {
                MessageBox.Show("Xóa loại sản phẩm không thành công. Không tìm thấy loại sản phẩm.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maLoai = txtMaLoai.Text;
            string tenLoai = txtTenLoai.Text;
            string moTa = txtMoTa.Text;

            bool result = bll_LoaiSP.SuaThongTinLoaiSP(maLoai, tenLoai, moTa);
            if (result)
            {
                MessageBox.Show("Sửa thông tin loại sản phẩm thành công.");
                // Sau khi sửa thành công, làm mới danh sách loại sản phẩm
                // và làm sạch các ô textbox để chuẩn bị cho việc sửa loại sản phẩm khác.

                ClearTextBoxes();
                LoadView();
            }
            else
            {
                MessageBox.Show("Sửa thông tin loại sản phẩm không thành công. Không tìm thấy loại sản phẩm.");
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
        private void ClearTextBoxes()
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            txtMoTa.Text = "";
        }

        private void dataGridDSML_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridDSML.Rows[e.RowIndex];

            txtMaLoai.Text = row.Cells[0].Value.ToString();
            txtTenLoai.Text = row.Cells[1].Value.ToString();
            txtMoTa.Text = row.Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
