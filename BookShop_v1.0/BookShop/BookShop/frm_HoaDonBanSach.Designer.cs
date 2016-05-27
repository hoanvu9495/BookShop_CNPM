namespace BookShop
{
    partial class frm_HoaDonBanSach
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BOOKSHOPDataSet1 = new BookShop.BOOKSHOPDataSet1();
            this.VWHoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VWHoaDonTableAdapter = new BookShop.BOOKSHOPDataSet1TableAdapters.VWHoaDonTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BOOKSHOPDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VWHoaDonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetHoaDOn";
            reportDataSource1.Value = this.VWHoaDonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BookShop.Report5.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(722, 378);
            this.reportViewer1.TabIndex = 0;
            // 
            // BOOKSHOPDataSet1
            // 
            this.BOOKSHOPDataSet1.DataSetName = "BOOKSHOPDataSet1";
            this.BOOKSHOPDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VWHoaDonBindingSource
            // 
            this.VWHoaDonBindingSource.DataMember = "VWHoaDon";
            this.VWHoaDonBindingSource.DataSource = this.BOOKSHOPDataSet1;
            // 
            // VWHoaDonTableAdapter
            // 
            this.VWHoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // frm_HoaDonBanSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 378);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frm_HoaDonBanSach";
            this.Text = "frm_HoaDonBanSach";
            this.Load += new System.EventHandler(this.frm_HoaDonBanSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BOOKSHOPDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VWHoaDonBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource VWHoaDonBindingSource;
        private BOOKSHOPDataSet1 BOOKSHOPDataSet1;
        private BOOKSHOPDataSet1TableAdapters.VWHoaDonTableAdapter VWHoaDonTableAdapter;
    }
}