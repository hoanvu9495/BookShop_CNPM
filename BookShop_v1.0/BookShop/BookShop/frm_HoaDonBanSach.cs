using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace BookShop
{
    public partial class frm_HoaDonBanSach : Form
    {
        public frm_HoaDonBanSach()
        {
            InitializeComponent();
        }

        private void frm_HoaDonBanSach_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'BOOKSHOPDataSet1.VWHoaDo-n' table. You can move, or remove it, as needed.

                this.VWHoaDonTableAdapter.Fill(this.BOOKSHOPDataSet1.VWHoaDon);


                this.reportViewer1.RefreshReport();
            if (this.DialogResult == DialogResult.Cancel)
            {
                MessageBox.Show("CL");
            }

        }
    }
}
