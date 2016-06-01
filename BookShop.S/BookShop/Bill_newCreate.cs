using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShop.BLL;
using BookShop.Entities;

namespace BookShop
{
    public partial class Bill_newCreate : Form
    {
        public Bill_newCreate()
        {
            InitializeComponent();
        }

        private void Bill_newCreate_Load(object sender, EventArgs e)
        {

        }

        private void btn_billCreate_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();
            if (MessageBox.Show("Bạn có muốn thêm?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int tsl = 0;
                int idpn = int.Parse(txt_billID.Text);
                int nxb = int.Parse(txt_nxbID.Text);
                BillBLL.createLstbill(idpn,nxb,tsl);
                this.Hide();
            }
        }


    }
}
