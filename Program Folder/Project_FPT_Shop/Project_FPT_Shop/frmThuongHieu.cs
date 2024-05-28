using BLL;
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
    public partial class frmThuongHieu : Form
    {
        private BLL_ThuongHieu bll = new BLL_ThuongHieu();
        private ThuongHieu dto = new ThuongHieu();
        public frmThuongHieu()
        {
            InitializeComponent();
            LoadView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaTH.Text != "" && txtTenThuongHieu.Text != "" && txtQuocGia.Text != "")
            {
                dto.maThuongHieu = txtMaTH.Text;
                dto.tenThuongHieu = txtTenThuongHieu.Text;
                dto.quocGia = txtQuocGia.Text;
                if (bll.themThuongHieu(dto))
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



        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaTH.Text != "" && txtTenThuongHieu.Text != "" && txtQuocGia.Text != "")
            {
                string maTH = txtMaTH.Text;
                bool result = bll.xoaThuongHieu(maTH);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaTH.Text != "" && txtTenThuongHieu.Text != "" && txtQuocGia.Text != "")
            {
                dto.maThuongHieu = txtMaTH.Text;
                dto.tenThuongHieu = txtTenThuongHieu.Text;
                dto.quocGia = txtQuocGia.Text;

                if (bll.suaThuongHieu(dto))
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

        private void dgvThuongHieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvThuongHieu.Rows[e.RowIndex];

            // Hiển thị thông tin của dòng được chọn lên các TextBox tương ứng
            txtMaTH.Text = row.Cells[0].Value.ToString();
            txtTenThuongHieu.Text = row.Cells[1].Value.ToString();
            txtQuocGia.Text = row.Cells[2].Value.ToString();
        }

        private void frmThuongHieu_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            LoadView();
        }

        public void LoadView()
        {
            //bll.View(dgvThuongHieu);
            dgvThuongHieu.DataSource = bll.View();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {

        }
    }
}
