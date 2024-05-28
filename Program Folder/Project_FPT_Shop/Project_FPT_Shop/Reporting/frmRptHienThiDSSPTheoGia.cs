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
    public partial class frmRptHienThiDSSPTheoGia : Form
    {
        BLL_Cbb cbb = new BLL_Cbb();
        FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlConnection con;
        public frmRptHienThiDSSPTheoGia()
        {
            InitializeComponent();
            cmd = new SqlCommand();
            con = new SqlConnection("Data Source=LAPTOP-1CIU4QVU;Initial Catalog=FPTShop;Integrated Security=True;");
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("DanhSachSanPhamTheoGia", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "DanhSachSanPhamTheoGia";

            // Thêm các tham số cho stored procedure
            da.SelectCommand.Parameters.AddWithValue("@GiaMin", Convert.ToDouble(txtGiaMin.Text));
            da.SelectCommand.Parameters.AddWithValue("@GiaMax", Convert.ToDouble(txtGiaMax.Text));

            // Tạo DataTable để chứa dữ liệu
            DataTable dt = new DataTable();

            // Đổ dữ liệu từ SqlDataAdapter vào DataTable
            da.Fill(dt);

            // Hiển thị dữ liệu trên DataGridView hoặc ListView, ListBox, ...
            // Ví dụ: Hiển thị trên DataGridView
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load("D:\\Projects Code\\Project_FPT_Shop\\Project_FPT_Shop\\Reporting\\rptHienThiDSSPTheoGia.rpt");

            // Thiết lập dữ liệu cho báo cáo
            reportDocument.SetDataSource(dt);
            this.Hide();

            // Tạo một form mới để hiển thị báo cáo
            frmRptHienThiDSSPTheoGia f = new frmRptHienThiDSSPTheoGia();
            //f.FormClosed += (sender, args) => this.Close();
            f.crystalReportViewer1.ReportSource = reportDocument;
            f.ShowDialog();
        }
        private void frmRptHienThiDSSPTheoGia_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
