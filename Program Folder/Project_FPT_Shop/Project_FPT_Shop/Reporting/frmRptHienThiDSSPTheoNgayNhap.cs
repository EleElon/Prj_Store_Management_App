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
    public partial class frmRptHienThiDSSPTheoNgayNhap : Form
    {
        BLL_Cbb cbb = new BLL_Cbb();
        FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlConnection con;
        public frmRptHienThiDSSPTheoNgayNhap()
        {
            InitializeComponent();
            cmd = new SqlCommand();
            con = new SqlConnection("Data Source=LAPTOP-1CIU4QVU;Initial Catalog=FPTShop;Integrated Security=True;");
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("DanhSachSanPhamTheoNgayNhap", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "DanhSachSanPhamTheoGia";

            // Convert giá trị từ DateTimePicker sang kiểu DateTime
            DateTime ngayBatDau = dtpNgayDau.Value;
            DateTime ngayKetThuc = dtpNgayCuoi.Value;

            // Sử dụng giá trị đã convert trong câu truy vấn
            da.SelectCommand.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
            da.SelectCommand.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);


            // Thêm các tham số cho stored procedure
            //da.SelectCommand.Parameters.AddWithValue("@NgayBatDau", Convert.ToDateTime(dtpNgayDau.Text));
            //da.SelectCommand.Parameters.AddWithValue("@NgayKetThuc", Convert.ToDateTime(dtpNgayCuoi.Text));

            // Tạo DataTable để chứa dữ liệu
            DataTable dt = new DataTable();

            // Đổ dữ liệu từ SqlDataAdapter vào DataTable
            da.Fill(dt);

            // Hiển thị dữ liệu trên DataGridView hoặc ListView, ListBox, ...
            // Ví dụ: Hiển thị trên DataGridView
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load("D:\\Projects Code\\Project_FPT_Shop\\Project_FPT_Shop\\Reporting\\rptHienThiDSSPTheoNgayNhap.rpt");

            // Thiết lập dữ liệu cho báo cáo
            reportDocument.SetDataSource(dt);
            this.Hide();

            // Tạo một form mới để hiển thị báo cáo
            frmRptHienThiDSSPTheoNgayNhap f = new frmRptHienThiDSSPTheoNgayNhap();
            //f.FormClosed += (sender, args) => this.Close();
            f.crystalReportViewer1.ReportSource = reportDocument;
            f.ShowDialog();
        }

        private void frmRptHienThiDSSPTheoNgayNhap_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
