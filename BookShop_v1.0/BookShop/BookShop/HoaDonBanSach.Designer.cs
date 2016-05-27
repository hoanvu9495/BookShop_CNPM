namespace BookShop
{
    partial class HoaDonBanSach
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
            this.rpv_HoaDonBanSach = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpv_HoaDonBanSach
            // 
            this.rpv_HoaDonBanSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpv_HoaDonBanSach.Location = new System.Drawing.Point(0, 0);
            this.rpv_HoaDonBanSach.Name = "rpv_HoaDonBanSach";
            this.rpv_HoaDonBanSach.Size = new System.Drawing.Size(632, 468);
            this.rpv_HoaDonBanSach.TabIndex = 0;
            // 
            // HoaDonBanSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 468);
            this.Controls.Add(this.rpv_HoaDonBanSach);
            this.Name = "HoaDonBanSach";
            this.Text = "HoaDonBanSach";
            this.Load += new System.EventHandler(this.HoaDonBanSach_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpv_HoaDonBanSach;
    }
}