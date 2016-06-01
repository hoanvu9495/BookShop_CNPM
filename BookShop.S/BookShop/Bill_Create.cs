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
    public partial class Bill_Create : Form
    {
        public Bill_Create()
        {
            InitializeComponent();
        }

        private void btn_createBill_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();
            if (MessageBox.Show("Bạn có muốn thêm?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int idpn = int.Parse(txt_billID.Text);
                int ids = int.Parse(txt_bookID.Text);
                int? sl = int.Parse(txt_slBill.Text);
                var book = (from a in db.SACHes where a.ID == ids select a).SingleOrDefault();
                int? tien = int.Parse(book.GIANHAP.ToString()) * sl;
                int? idnv = int.Parse(txt_idNV.Text);
                DateTime? ngay = DateTime.Parse(txt_time.Text);
                BillBLL.insertBill(idpn, ids, sl, tien, ngay, idnv);
                this.Hide();
            }
            
        }
    }
}
