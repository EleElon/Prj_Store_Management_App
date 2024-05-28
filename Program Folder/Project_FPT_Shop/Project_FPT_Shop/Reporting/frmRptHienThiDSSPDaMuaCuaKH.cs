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
    public partial class frmRptHienThiDSSPDaMuaCuaKH : Form
    {
        BLL_Cbb cbb = new BLL_Cbb();
        FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();
        SqlDataAdapter da;
        SqlCommand cmd;

        public frmRptHienThiDSSPDaMuaCuaKH()
        {
            InitializeComponent();
            LoadComboBox();
            cmd = new SqlCommand();
        }
        private void LoadComboBox()
        {
            List<KhachHang> spItem = cbb.LoadKH();
            if (spItem != null && spItem.Count > 0)
            {
                cboKH.DataSource = spItem;
                cboKH.DisplayMember = "tenKH";
                cboKH.ValueMember = "maKH";
            }
        }
        private void frmRptHienThiDSSPDaMuaCuaKH_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
        }
      
        private void cboKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKH.SelectedValue != null)
            {
                string maKH = cboKH.SelectedValue.ToString();

                cmd.Connection = new SqlConnection("Data Source=LAPTOP-1CIU4QVU;Initial Catalog=FPTShop;Integrated Security=True;");

                // Khởi tạo đối tượng SqlCommand và SqlDataAdapter
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachSanPhamDaMua";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                SqlDataAdapter da = new SqlDataAdapter(cmd); // Khởi tạo SqlDataAdapter

                // Thực hiện truy vấn và điền dữ liệu vào DataTable
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Tạo một đối tượng ReportDocument
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load("D:\\Projects Code\\Project_FPT_Shop\\Project_FPT_Shop\\Reporting\\rptHienThiDSSPDaMuaCuaKH.rpt");

                // Thiết lập dữ liệu cho báo cáo
                reportDocument.SetDataSource(dt);
                this.Hide();

                // Tạo một form mới để hiển thị báo cáo
                frmRptHienThiDSSPDaMuaCuaKH f = new frmRptHienThiDSSPDaMuaCuaKH();
                //f.FormClosed += (sender, args) => this.Close();
                f.crystalReportViewer1.ReportSource = reportDocument;
                f.ShowDialog();
            }
        }
    }
}
