using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class HoaDonBanSach : Form
    {
        public HoaDonBanSach()
        {
            InitializeComponent();
        }

        private void HoaDonBanSach_Load(object sender, EventArgs e)
        {

            this.rpv_HoaDonBanSach.RefreshReport();
        }
    }
}
