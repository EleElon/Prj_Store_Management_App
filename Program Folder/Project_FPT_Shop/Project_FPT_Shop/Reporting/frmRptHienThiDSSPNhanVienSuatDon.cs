using BUS;
using CrystalDecisions.CrystalReports.Engine;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_FPT_Shop.Reporting
{
    public partial class frmRptHienThiDSSPNhanVienSuatDon : Form
    {
        BLL_Cbb cbb = new BLL_Cbb();
        FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();
        SqlDataAdapter da;
        SqlCommand cmd;
        public frmRptHienThiDSSPNhanVienSuatDon()
        {
            InitializeComponent();
            LoadComboBox();
            cmd = new SqlCommand();
        }
        private void LoadComboBox()
        {
            List<NhanVien> spItem = cbb.LoadNV();
            if (spItem != null && spItem.Count > 0)
            {
                cboNV.DataSource = spItem;
                cboNV.DisplayMember = "tenNV";
                cboNV.ValueMember = "maNV";
            }
        }
        private void frmRptHienThiDSSPNhanVienSuatDon_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private void cboNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNV.SelectedValue != null)
            {
                string maNV = cboNV.SelectedValue.ToString();

                cmd.Connection = new SqlConnection("Data Source=LAPTOP-1CIU4QVU;Initial Catalog=FPTShop;Integrated Security=True;");

                // Khởi tạo đối tượng SqlCommand và SqlDataAdapter
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachSanPhamDaBan";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                SqlDataAdapter da = new SqlDataAdapter(cmd); // Khởi tạo SqlDataAdapter

                // Thực hiện truy vấn và điền dữ liệu vào DataTable
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Tạo một đối tượng ReportDocument
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load("D:\\Projects Code\\Project_FPT_Shop\\Project_FPT_Shop\\Reporting\\rptHienThiDSSPNhanVienSuatDon.rpt");

                // Thiết lập dữ liệu cho báo cáo
                reportDocument.SetDataSource(dt);
                this.Hide();

                // Tạo một form mới để hiển thị báo cáo
                frmRptHienThiDSSPNhanVienSuatDon f = new frmRptHienThiDSSPNhanVienSuatDon();
                //f.FormClosed += (sender, args) => this.Close();
                f.crystalReportViewer1.ReportSource = reportDocument;
                f.ShowDialog();
            }
        }

        private void rptHienThiDSSPNhanVienSuatDon1_InitReport(object sender, EventArgs e)
        {

        }
    }
}
