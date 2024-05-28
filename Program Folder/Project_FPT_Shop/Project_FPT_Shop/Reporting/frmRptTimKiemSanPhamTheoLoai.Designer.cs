namespace Project_FPT_Shop.Reporting
{
    partial class frmRptTimKiemSanPhamTheoLoai
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboMaLoai = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rptTimKiemSPTheoLoai = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptDSSPTheoLoai1 = new Project_FPT_Shop.Reporting.rptDSSPTheoLoai();
            this.SuspendLayout();
            // 
            // cboMaLoai
            // 
            this.cboMaLoai.FormattingEnabled = true;
            this.cboMaLoai.ItemHeight = 13;
            this.cboMaLoai.Location = new System.Drawing.Point(156, 22);
            this.cboMaLoai.Name = "cboMaLoai";
            this.cboMaLoai.Size = new System.Drawing.Size(105, 21);
            this.cboMaLoai.TabIndex = 1;
            this.cboMaLoai.SelectedIndexChanged += new System.EventHandler(this.cboMaLoai_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loại SP";
            // 
            // rptTimKiemSPTheoLoai
            // 
            this.rptTimKiemSPTheoLoai.ActiveViewIndex = 0;
            this.rptTimKiemSPTheoLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rptTimKiemSPTheoLoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptTimKiemSPTheoLoai.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptTimKiemSPTheoLoai.Location = new System.Drawing.Point(0, 63);
            this.rptTimKiemSPTheoLoai.Name = "rptTimKiemSPTheoLoai";
            this.rptTimKiemSPTheoLoai.ReportSource = this.rptDSSPTheoLoai1;
            this.rptTimKiemSPTheoLoai.Size = new System.Drawing.Size(800, 387);
            this.rptTimKiemSPTheoLoai.TabIndex = 0;
            // 
            // frmRptTimKiemSanPhamTheoLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMaLoai);
            this.Controls.Add(this.rptTimKiemSPTheoLoai);
            this.Name = "frmRptTimKiemSanPhamTheoLoai";
            this.Text = "frmRptTimKiemSanPhamTheoLoai";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptTimKiemSPTheoLoai;
        private System.Windows.Forms.ComboBox cboMaLoai;
        private System.Windows.Forms.Label label1;
        private rptDSSPTheoLoai rptDSSPTheoLoai1;
    }
}