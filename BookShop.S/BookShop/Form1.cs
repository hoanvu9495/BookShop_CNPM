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
    public partial class Form1 : Form
    {
        //id row đang chọn bảng BOOK
        public int indexRowSach;
        int indexrowTacgia;
        int indexrowhdnhap;
        int indexrowsachnhap;
        string biasach;
        OpenFileDialog ofd = new OpenFileDialog();
        public Form1()
        { 
            InitializeComponent();
            loadBill();
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    tcl_Home.SelectedTab = tpe_Home;
        //    tcl_Home.TabPages.Remove(tpe_Login);
        //    //tcl_Home.TabPages.Add(tpe_Function);
        //    tcl_Home.TabPages.Insert(1, tpe_Function);
        //}



        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var item = Account.Login(txt_UserName.Text, txt_Password.Text);
            if (item == null)
            {
                lbl_Alert.Visible = true;
            }
            else
            {
                tcl_Home.TabPages.Insert(1, tpe_Function);
                tcl_Home.TabPages.Remove(tpe_Login);
                tcl_Home.SelectedTab = tpe_Function;
            }
        }
        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {
            lbl_Alert.Visible = false;
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            lbl_Alert.Visible = false;
        }

        /// <summary>
        /// load dữ liệu
        /// </summary>
        public void loadBook()
        {
            txt_BookID.Text = BookBLL.loadID().ToString();
            dgv_Book.DataSource = BookBLL.getAllBook().DataSource;
            cbx_themes.DataSource = BookBLL.getChudeCBX();
            cbx_themes.ValueMember = "ID";
            cbx_themes.DisplayMember = "TEN";
            cbx_nxb.DataSource = BookBLL.getNxbCBX();
            cbx_nxb.ValueMember = "ID";
            cbx_nxb.DisplayMember = "TEN";
        }
        /// <summary>
        /// Doubleclickcell hiển thị thông tin tương ứng 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Book_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRowSach=e.RowIndex;
            txt_BookID.Text = dgv_Book.Rows[indexRowSach].Cells[0].Value.ToString();
            cbx_nxb.SelectedValue = dgv_Book.Rows[indexRowSach].Cells[6].Value;
            cbx_themes.SelectedValue = dgv_Book.Rows[indexRowSach].Cells[5].Value;
            txt_BookName.Text = dgv_Book.Rows[indexRowSach].Cells[1].Value.ToString();
            txt_BookPriceout.Text = dgv_Book.Rows[indexRowSach].Cells[2].Value.ToString();
            txt_BookPricein.Text = dgv_Book.Rows[indexRowSach].Cells[3].Value.ToString();
            txt_BookMT.Text = dgv_Book.Rows[indexRowSach].Cells[4].Value.ToString();
            txt_BookSl.Text = dgv_Book.Rows[indexRowSach].Cells[8].Value.ToString();
            txt_BookK.Text = dgv_Book.Rows[indexRowSach].Cells[9].Value.ToString();
            txt_soTrang.Text = dgv_Book.Rows[indexRowSach].Cells[10].Value.ToString();
            picBox_Bookimage.Image = Image.FromFile(dgv_Book.Rows[indexRowSach].Cells[7].Value.ToString());
            dgv_TG.DataSource = BookBLL.getTggrid(int.Parse(txt_BookID.Text)).DataSource;
            dgv_TG.Columns[0].Visible = false;
            dgv_TG.Columns[4].Visible = false;
            dgv_TG.Columns[5].Visible = false;
            dgv_TG.Columns[6].Visible = false;
        }
        private void tpe_Book_Click(object sender, EventArgs e)
        {
            dgv_Book.DataSource = BookBLL.getAllBook().DataSource;
            
        }
        /// <summary>
        /// Load dữ liệu lên datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_loaddataBook_Click(object sender, EventArgs e)
        {
            loadBook();
            dgv_Book.Columns[12].Visible = false;
            dgv_Book.Columns[13].Visible = false;
            dgv_Book.Columns[14].Visible = false;
            dgv_Book.Columns[15].Visible = false;
            dgv_Book.Columns[16].Visible = false;
            dgv_Book.Columns[17].Visible = false;
            MessageBox.Show("Load thành công!", "", MessageBoxButtons.OK);
        }
        /// <summary>
        /// Chọn ảnh cho sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_openPicture_Click(object sender, EventArgs e)
        {
            ofd.Title = "Open Image";
            ofd.InitialDirectory = @"F:\image";
            ofd.Filter = "Image|*.jpg;*.jpeg;*.png";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                picBox_Bookimage.Image = Image.FromFile(ofd.FileName);
            }
            biasach = ofd.FileName;
        }
        /// <summary>
        /// Tạo 1 cuốn sách mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CreateBook_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_BookID.Text);
            int prin = int.Parse(txt_BookPricein.Text);
            int prout = int.Parse(txt_BookPriceout.Text);
            int cd = int.Parse(cbx_themes.SelectedValue.ToString());
            int nxb = int.Parse(cbx_nxb.SelectedValue.ToString());
            int sl = int.Parse(txt_BookSl.Text);
            int st = int.Parse(txt_soTrang.Text);
            BookBLL.insertBook(id, txt_BookName.Text, prout, prin, txt_BookMT.Text, cd, nxb, biasach, sl, txt_BookK.Text, st);
            dgv_Book.DataSource = BookBLL.getAllBook().DataSource;
            MessageBox.Show("Thêm thành công!", "", MessageBoxButtons.OK);
        }
        /// <summary>
        /// Sửa thông tin 1 cuốn sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_updateBook_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_BookID.Text);
            int prin = int.Parse(txt_BookPricein.Text);
            int prout = int.Parse(txt_BookPriceout.Text);
            int cd = int.Parse(cbx_themes.SelectedValue.ToString());
            int nxb = int.Parse(cbx_nxb.SelectedValue.ToString());
            int sl = int.Parse(txt_BookSl.Text);
            int st = int.Parse(txt_soTrang.Text);
            BookBLL.updateBook(id,txt_BookName.Text, prout, prin, txt_BookMT.Text, cd, nxb, biasach, sl, txt_BookK.Text, st);
            dgv_Book.DataSource = BookBLL.getAllBook().DataSource;
            MessageBox.Show("Sửa thành công!", "", MessageBoxButtons.OK);
        }


        /// <summary>
        /// Load thông tin tác giả
        /// </summary>
        public void loadAuthor()
        {
            txt_AuthorID.Text = AuthorBLL.loadID().ToString();
            dgv_Author.DataSource = AuthorBLL.getAllAuthor().DataSource;
            
        }
        /// <summary>
        /// load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_loadAuthor_Click(object sender, EventArgs e)
        {
            loadAuthor();
            MessageBox.Show("Load thành công!", "", MessageBoxButtons.OK);
        }
        /// <summary>
        /// Đưa thông tin tác giả lên datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Author_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indexrowTacgia = e.RowIndex;
            txt_AuthorID.Text = dgv_Author.Rows[indexrowTacgia].Cells[0].Value.ToString();
            txt_AuthorName.Text = dgv_Author.Rows[indexrowTacgia].Cells[1].Value.ToString();
            txt_AuthorDC.Text = dgv_Author.Rows[indexrowTacgia].Cells[2].Value.ToString();
            txt_AuthorPhone.Text = dgv_Author.Rows[indexrowTacgia].Cells[3].Value.ToString();
        }
        /// <summary>
        /// Cập nhật thông tin tác giả
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {
            AuthorBLL.updateAuthor(int.Parse(txt_AuthorID.Text), txt_AuthorName.Text, txt_AuthorPhone.Text, txt_AuthorDC.Text);
            dgv_Author.DataSource = AuthorBLL.getAllAuthor().DataSource;
            MessageBox.Show("Sửa thành công!", "", MessageBoxButtons.OK);
        }
        /// <summary>
        /// Xóa 1 tác giả
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Xóa?","Question",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                AuthorBLL.deleteAuthor(int.Parse(txt_AuthorID.Text));
                dgv_Author.DataSource = AuthorBLL.getAllAuthor().DataSource;
            }
            else
            {
                this.Activate();
            }
        }
        /// <summary>
        /// Thêm mới 1 tác giả
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AuthorInsert_Click(object sender, EventArgs e)
        {
            int _ID = int.Parse(txt_AuthorID.Text);
            AuthorBLL.createAuthor(_ID, txt_AuthorName.Text, txt_AuthorPhone.Text, txt_AuthorDC.Text);
            dgv_Author.DataSource = AuthorBLL.getAllAuthor().DataSource;
            MessageBox.Show("Thêm thành công!", "", MessageBoxButtons.OK);
        }
        /// <summary>
        /// ngưng bán 1 cuốn sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_stopBook_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_BookID.Text);
            int prin = int.Parse(txt_BookPricein.Text);
            int prout = int.Parse(txt_BookPriceout.Text);
            int cd = int.Parse(cbx_themes.SelectedValue.ToString());
            int nxb = int.Parse(cbx_nxb.SelectedValue.ToString());
            int sl = int.Parse(txt_BookSl.Text);
            int st = int.Parse(txt_soTrang.Text);
            BookBLL.stopBook(id, txt_BookName.Text, prout, prin, txt_BookMT.Text, cd, nxb, biasach, sl, txt_BookK.Text, st);
            dgv_Book.DataSource = BookBLL.getAllBook().DataSource;
        }
        /// <summary>
        /// tìm kiếm 1 cuốn sách nào đó theo thông tin sẵn có
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_bookSearch_Click(object sender, EventArgs e)
        {
            dgv_Book.DataSource = BookBLL.searchBook(txt_bookSearch.Text).DataSource;
        }
        /// <summary>
        /// Tìm kiếm tác giả
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AuthorSearch_Click(object sender, EventArgs e)
        {
            dgv_Book.DataSource = AuthorBLL.searchAuthor(txt_AuthorSearch.Text).DataSource;
        }


        //-------------------------------------------------Hóa đơn nhập---------------------------------
        /// <summary>
        /// tải dữ liệu hóa đơn
        /// </summary>
        public void loadBill()
        {

            dgv_Bill.DataSource = BillBLL.getAllBill().DataSource;
            dgv_bBook.DataSource = BookBLL.getAllBook().DataSource;
            dgv_lstBill.DataSource = BillBLL.getAllB().DataSource;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void dgv_bBook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        /// <summary>
        /// hiển thị dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Bill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indexrowhdnhap = e.RowIndex;
            int id = int.Parse(dgv_Bill.Rows[indexrowhdnhap].Cells[1].Value.ToString()) - 1;
            txt_billID.Text = dgv_Bill.Rows[indexrowhdnhap].Cells[0].Value.ToString();
            txt_billNV.Text = dgv_Bill.Rows[indexrowhdnhap].Cells[5].Value.ToString();
            lb_billDate.Text = dgv_Bill.Rows[indexrowhdnhap].Cells[4].Value.ToString();
            txt_billslBook.Text = dgv_Bill.Rows[indexrowhdnhap].Cells[2].Value.ToString();
            lb_billNameb.Text = dgv_bBook.Rows[id].Cells[1].Value.ToString();
            txt_giaNhap.Text = dgv_bBook.Rows[id].Cells[3].Value.ToString();
            lb_billMoney.Text = dgv_Bill.Rows[indexrowhdnhap].Cells[3].Value.ToString() + "  VND";
        }
        /// <summary>
        /// tạo mới dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_billCreate_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Thêm mới chọn 'Yes' \n Sử dụng hóa đơn cũ chọn 'No' ","Thông báo",MessageBoxButtons.YesNo)==DialogResult.No)
            {
                Bill_Create bill = new Bill_Create();
                bill.Show();
            }
            else
            {
                Bill_newCreate nb = new Bill_newCreate();
                nb.Show();
            }
        }

        private void btn_billLoad_Click(object sender, EventArgs e)
        {
            loadBill();
        }

        private void btn_billUpdate_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Tìm kiếm dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_billSearch_TextChanged(object sender, EventArgs e)
        {
            var db = new DBConnection();   
            if (txt_billSearch.Text != "")
            {
                var lstindex = db.CHITIETPHIEUNHAPs.Where(n => n.ISDELETE == false).ToList().FindAll(x => x.ID_PN == int.Parse(txt_billSearch.Text));
                dgv_Bill.DataSource = lstindex;
            }
            else
            {
                dgv_Bill.DataSource = BillBLL.getAllBill().DataSource;
            }
        }

        private void txt_searchBook_TextChanged(object sender, EventArgs e)
        {
            var db = new DBConnection();
            if (txt_searchBook.Text != "")
            {
                var lstindex = db.SACHes.Where(n => n.ISDELETE == false).ToList().FindAll(x => x.TEN.Contains(txt_searchBook.Text));
                dgv_bBook.DataSource = lstindex;
            }
            else
            {
                dgv_bBook.DataSource = BookBLL.getAllBook().DataSource;
            }
        }

    }
}
