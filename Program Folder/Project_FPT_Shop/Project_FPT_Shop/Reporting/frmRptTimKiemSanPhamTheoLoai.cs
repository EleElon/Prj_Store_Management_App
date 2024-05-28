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
using BLL;
using BUS;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;

namespace Project_FPT_Shop.Reporting
{
    public partial class frmRptTimKiemSanPhamTheoLoai : Form
    {
        BLL_Cbb cbb = new BLL_Cbb();
        FPT_Shop_Real_dbDataContext db = new FPT_Shop_Real_dbDataContext();
        SqlDataAdapter da;
        SqlCommand cmd;
        public frmRptTimKiemSanPhamTheoLoai()
        {
            InitializeComponent();
            LoadComboBox();
            cmd = new SqlCommand();
        }
        private void LoadComboBox()
        {
            List<LoaiSP> spItem = cbb.LoadLoaiSP();
            if (spItem != null && spItem.Count > 0)
            {
                cboMaLoai.DataSource = spItem;
                cboMaLoai.DisplayMember = "tenLoai";
                cboMaLoai.ValueMember = "maLoai";
            }
        }

        private void cboMaLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaLoai.SelectedValue != null)
            {
                string maLoai = cboMaLoai.SelectedValue.ToString();

                cmd.Connection = new SqlConnection("Data Source=LAPTOP-1CIU4QVU;Initial Catalog=FPTShop;Integrated Security=True;");

                // Khởi tạo đối tượng SqlCommand và SqlDataAdapter
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TimKiemSanPhamTheoLoai";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MaLoai", maLoai);

                SqlDataAdapter da = new SqlDataAdapter(cmd); // Khởi tạo SqlDataAdapter

                // Thực hiện truy vấn và điền dữ liệu vào DataTable
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Tạo một đối tượng ReportDocument
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load("D:\\Projects Code\\Project_FPT_Shop\\Project_FPT_Shop\\Reporting\\rptDSSPTheoLoai.rpt");

                // Thiết lập dữ liệu cho báo cáo
                reportDocument.SetDataSource(dt);
                this.Hide();

                // Tạo một form mới để hiển thị báo cáo
                frmRptTimKiemSanPhamTheoLoai f = new frmRptTimKiemSanPhamTheoLoai();
                //f.FormClosed += (sender, args) => this.Close();
                f.rptTimKiemSPTheoLoai.ReportSource = reportDocument;
                f.ShowDialog();
            }
           
        }
        private void frmRptTimKiemSanPhamTheoLoai_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
