using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BookShop.BLL;
using BookShop.Entities;
using BookShop.DAL;

namespace BookShop
{
    public partial class Form1 : Form
    {
        private NHANVIEN _session;
        private int _idSelected;
        private int _seletedRow;

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'BOOKSHOPDataSet1.VWTHONGTINKM' table. You can move, or remove it, as needed.
            try
            {
                this.VWTHONGTINKMTableAdapter.Fill(this.BOOKSHOPDataSet1.VWTHONGTINKM);
            }
            catch (Exception)
            {
                
              
            }
            
            // TODO: This line of code loads data into the 'BOOKSHOPDataSet1.SACH' table. You can move, or remove it, as needed.
            this.SACHTableAdapter.Fill(this.BOOKSHOPDataSet1.SACH);
            // TODO: This line of code loads data into the 'BOOKSHOPDataSet1.NHAXUATBAN' table. You can move, or remove it, as needed.
            this.NHAXUATBANTableAdapter.Fill(this.BOOKSHOPDataSet1.NHAXUATBAN);
            // TODO: This line of code loads data into the 'BOOKSHOPDataSet.TACGIA' table. You can move, or remove it, as needed.
            this.TACGIATableAdapter.Fill(this.BOOKSHOPDataSet.TACGIA);
            // TODO: This line of code loads data into the 'BOOKSHOPDataSetShowKM.CHITIETKM' table. You can move, or remove it, as needed.


            tcl_Home.TabPages.Remove(tpe_Function);
            tcl_Function.TabPages.Remove(tpe_Account);
            tcl_Home.SelectedTab = tpe_Home;
            tcl_Function.TabPages.Remove(tpe_Account2);

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer4.RefreshReport();
        }



        /// <summary>
        /// TODO: Select TabPage to Load Table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Selected TabPage </param>
        private void tcl_Function_TabIndexChanged(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.TabIndex)
            {
                case 0:
                    {
                        loadHD();
                        break;
                    }
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        TabPageAccountLoad();
                        btn_UpdateAccount.Enabled = false;
                        break;
                    }
                case 4:
                    {
                        loadAuthor();
                        break;
                    }
                case 6:
                    {
                        loadKM();
                        break;
                    }
                case 7:
                    {
                        loadDataChuDe();
                        break;
                    }
                case 8:
                    {
                        TabPagePublisherLoad();
                        break;
                    }
                case 9:
                    {
                        loadBook();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }

        /// <summary>
        /// TODO: Set Column STT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Account_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv_Account.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        /// <summary>
        /// TODO: Show detail Account information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_AccountCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dgv_Account.Rows[e.RowIndex].Cells[1].Value;
            var account = Account.GetItem(Int32.Parse(id.ToString()));
            txt_FullNameAccount.Text = account.TEN.Trim();
            txt_UserNameAccount.Text = account.TENDANGNHAP.Trim();
            txt_PasswordAccount.Text = account.MATKHAU.Trim();
            if (account.NGAYSINH != null) dtp_Birthday.Value = account.NGAYSINH.Value;
            txt_PhoneNumber.Text = account.SDT.Trim();
            if (account.ID_QUYEN != null) cbx_Access.SelectedIndex = account.ID_QUYEN.Value - 1;

            lbl_StatusAccount.Text = account.ISDELETE == false ? "Đang hoạt động" : "Đã xóa";

            lbl_StatusAccount.Visible = true;
            lbl_StatusAccountLb.Visible = true;
            btn_AddAccount.Visible = false;
            btn_NewAccount.Visible = true;
            btn_DeleteAccount.Enabled = true;
            btn_UpdateAccount.Enabled = false;

            _idSelected = Int32.Parse(dgv_Account.Rows[e.RowIndex].Cells[1].Value.ToString());
            _seletedRow = e.RowIndex;
        }

        /// <summary>
        /// TODO: Check btn_Login Click. If Login is accept then Show tpe_Account. tpe_sale in tcl_Function selected.
        /// </summary>
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
                lbl_Username.Text = item.TEN;
                flp_StatusUser.Visible = true;
                _session = item;
                if (item.ID_QUYEN != 1) return;
                tcl_Function.TabPages.Insert(2, tpe_Account);
                tcl_Function.SelectedTab = tpe_Sale;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {
            lbl_Alert.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            lbl_Alert.Visible = false;
        }

        /// <summary>
        /// TODO: 
        /// </summary>
        private void btn_Logout_Click(object sender, EventArgs e)
        {
            tcl_Home.TabPages.Remove(tpe_Function);
            tcl_Home.TabPages.Add(tpe_Login);

            tcl_Function.TabPages.Remove(tpe_Account);
            tcl_Function.TabPages.Remove(tpe_Account2);
            flp_StatusUser.Visible = false;
        }

        /// <summary>
        /// TODO: Reset Input text and set button btn_AddAccount is visible, set button btn_NewAccount is non visible
        /// </summary>
        private void btn_NewAccount_Click(object sender, EventArgs e)
        {
            txt_UserNameAccount.Text = "";
            txt_RepasswordAccount.Text = "";
            txt_FullNameAccount.Text = "";
            txt_PasswordAccount.Text = "";
            txt_PhoneNumber.Text = "";

            cbx_Access.SelectedIndex = 0;

            dtp_Birthday.Value = new DateTime(1980, 1, 1);

            btn_NewAccount.Visible = false;
            btn_AddAccount.Visible = true;

            btn_UpdateAccount.Enabled = false;
            btn_DeleteAccount.Enabled = false;
        }

        /// <summary>
        /// TODO: Show infor detail of user login
        /// </summary>
        private void lbl_Username_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var existed = false;
            foreach (var item in tcl_Function.TabPages.Cast<object>().Where(item => item == tpe_Account2))
            {
                existed = true;
            }
            if (!existed) tcl_Function.TabPages.Add(tpe_Account2);
            tcl_Home.SelectedTab = tpe_Function;
            tcl_Function.SelectedTab = tpe_Account2;

            txt_UsernameAccountDetail.Text = _session.TENDANGNHAP.Trim();
            txt_PasswordAccountDetail.Text = _session.MATKHAU.Trim();
            txt_FullNameAccountDetail.Text = _session.TEN.Trim();
            txt_PhoneAcocuntDetail.Text = _session.SDT.Trim();
            if (_session.NGAYSINH != null) dtp_BirthdayAccountDetail.Value = _session.NGAYSINH.Value;
            txt_AccessAcountDetail.Text = _session.ID_QUYEN == 1 ? "Admin" : "Nhân viên";

            btn_EditAccountDetail.Enabled = false;
        }

        /// <summary>
        /// TODO: Get infor user input, send to Insert() function in class Account
        /// </summary>
        private void btn_AddAccount_Click(object sender, EventArgs e)
        {
            var account = new NHANVIEN
            {
                TENDANGNHAP = txt_UserNameAccount.Text,
                MATKHAU = txt_PasswordAccount.Text,
                TEN = txt_FullNameAccount.Text,
                SDT = txt_PhoneNumber.Text,
                NGAYSINH = dtp_Birthday.Value,
                ID_QUYEN = cbx_Access.SelectedIndex + 1,
                ISDELETE = false
            };

            Account.Insert(account, txt_RepasswordAccount.Text);
            TabPageAccountLoad();
        }

        /// <summary>
        /// TODO: Set property ISDELETE = true
        /// </summary>
        private void btn_DeleteAccount_Click(object sender, EventArgs e)
        {
            Account.Delete(_idSelected);
            TabPageAccountLoad();

        }

        /// <summary>
        /// TODO: Change infor account
        /// </summary>
        private void btn_UpdateAccount_Click(object sender, EventArgs e)
        {
            var item = new NHANVIEN
            {
                ID = _idSelected,
                TEN = txt_FullNameAccount.Text,
                TENDANGNHAP = txt_UserNameAccount.Text,
                MATKHAU = txt_PasswordAccount.Text,
                NGAYSINH = dtp_Birthday.Value,
                ID_QUYEN = cbx_Access.SelectedIndex + 1,
                SDT = txt_PhoneNumber.Text
            };

            Account.Update(item, txt_RepasswordAccount.Text);
            TabPageAccountLoad();
            dgv_Account.Rows[_seletedRow].Selected = true;
        }


        /// <summary>
        /// TODO: Load Account Table
        /// </summary>
        public void TabPageAccountLoad()
        {
            dgv_Account.DataSource = null;
            var data = Account.GetTable();
            dgv_Account.DataSource = data.DataSource;
            dgv_Account.Columns[1].Visible = false;
            dgv_Account.Columns[3].Visible = false;
            dgv_Account.Columns[6].Visible = false;
            dgv_Account.Columns[9].Visible = false;

            cbx_Access.SelectedIndex = 0;

            var col = dgv_Account.Columns["TEN"];
            if (col != null)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void Account_TextChanged(object sender, EventArgs e)
        {
            btn_UpdateAccount.Enabled = true;
        }

        /// <summary>
        /// TODO: Update infor user login. Input Receive from tpe_Account2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditAccountDetail_Click(object sender, EventArgs e)
        {

            var item = new NHANVIEN
            {
                ID = _session.ID,
                TEN = txt_FullNameAccountDetail.Text,
                TENDANGNHAP = txt_UsernameAccountDetail.Text,
                MATKHAU = txt_PasswordAccountDetail.Text,
                NGAYSINH = dtp_BirthdayAccountDetail.Value,
                ID_QUYEN = _session.ID_QUYEN,
                SDT = txt_PhoneAcocuntDetail.Text
            };
            if (!Account.Update(item, txt_PasswordAccountDetail.Text)) return;

            _session = Account.GetItem(_session.ID);
            var existed = false;
            foreach (var a in tcl_Function.TabPages.Cast<object>().Where(i => i == tpe_Account2))
            {
                existed = true;
            }
            if (!existed) tcl_Function.TabPages.Add(tpe_Account2);
            tcl_Home.SelectedTab = tpe_Function;
            tcl_Function.SelectedTab = tpe_Account2;

            txt_UsernameAccountDetail.Text = _session.TENDANGNHAP.Trim();
            txt_PasswordAccountDetail.Text = _session.MATKHAU.Trim();
            txt_FullNameAccountDetail.Text = _session.TEN.Trim();
            txt_PhoneAcocuntDetail.Text = _session.SDT.Trim();
            if (_session.NGAYSINH != null) dtp_BirthdayAccountDetail.Value = _session.NGAYSINH.Value;
            txt_AccessAcountDetail.Text = _session.ID_QUYEN == 1 ? "Admin" : "Nhân viên";
        }

        private void txt_UsernameAccountDetail_TextChanged(object sender, EventArgs e)
        {
            btn_EditAccountDetail.Enabled = true;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        //__________________Hoan_________


        private void tpe_sale_Click(object sender, EventArgs e)
        {
            //dgv_AllHD.DataSource = HoaDonBLL.getAllSach().DataSource;
            dtp_NgayHD.Value = DateTime.Now;
            //txt_MaHD.Text = HoaDonBLL.getMaHD().ToString();
        }

        private void btn_ThemChuDe_Click(object sender, EventArgs e)
        {
            ChuDeBLL cd = new ChuDeBLL();
            if (cd.add(txt_MaChuDe.Text, txt_TenChuDe.Text))
            {
                MessageBox.Show("Thêm thành công");
                loadDataChuDe();
            }
            else
            {
                MessageBox.Show("Không thêm được");
            }

        }

        //Load dataGridView dgv_AllChuDe
        private void loadDataChuDe()
        {
            dgv_AllChuDe.DataSource = ChuDeBLL.getChuDe().DataSource;
            txt_MaChuDe.Text = ChuDeBLL.getMa().ToString();
            txt_TenChuDe.ResetText();
            ckbx_ChuDe.ResetText();
        }
        /// <summary>
        /// sự kiện khi tabPage được gọi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tpe_ChuDe_Paint(object sender, PaintEventArgs e)
        {
            loadDataChuDe();
        }


        /// <summary>
        /// thay đổi chủ đề
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SuaChuDe_Click(object sender, EventArgs e)
        {
            int ma = int.Parse(txt_MaChuDe.Text);
            bool check = ckbx_ChuDe.Checked;
            ChuDeBLL.edit(ma, txt_TenChuDe.Text, check);
            loadDataChuDe();
            btn_ThemChuDe.Enabled = false;
            btn_SuaChuDe.Enabled = false;
            btn_XoaChuDe.Enabled = false;
        }
        /// <summary>
        /// Hiển thị thông tin chủ đề lên textBox để chỉnh sửa, double click vào row cần sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        int rowCurent = 0;
        private void dgv_AllChuDe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            rowCurent = e.RowIndex;

            if (rowCurent >= 1 && rowCurent <= dgv_AllChuDe.RowCount)
            {
                txt_MaChuDe.Text = dgv_AllChuDe.Rows[rowCurent].Cells[0].Value.ToString();
                txt_TenChuDe.Text = dgv_AllChuDe.Rows[rowCurent].Cells[1].Value.ToString();
                ckbx_ChuDe.Checked = Convert.ToBoolean(dgv_AllChuDe.Rows[rowCurent].Cells[2].Value.ToString());
                btn_ThemChuDe.Enabled = false;
                btn_SuaChuDe.Enabled = true;
                btn_XoaChuDe.Enabled = true;
            }

        }
        /// <summary>
        /// nút "tất cả" hiển thị tất cả chủ đề
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AllChuDe_Click(object sender, EventArgs e)
        {
            loadDataChuDe();
            btn_ThemChuDe.Enabled = true;
            btn_SuaChuDe.Enabled = false;
            btn_XoaChuDe.Enabled = false;
        }
        /// <summary>
        /// trả về ID chủ đề tiếp theo để thêm mới, các textBox khác để trống để thêm mới chủ đề
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ResetChuDe_Click(object sender, EventArgs e)
        {
            loadDataChuDe();
            btn_SuaChuDe.Enabled = false;
            btn_ThemChuDe.Enabled = true;
            btn_ResetChuDe.Enabled = false;
        }

        private void btn_XoaChuDe_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_MaChuDe.Text.ToString());
            if (MessageBox.Show("Bạn muốn xóa bản ghi này", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    ChuDeBLL.delete(id);

                }
                catch (Exception)
                {
                    MessageBox.Show("Không xóa được");
                }

            }
            btn_XoaChuDe.Enabled = false;
            loadDataChuDe();

        }


        //Khuyến mại
        private void btn_AllKM_Click(object sender, EventArgs e)
        {
            loadKM();
        }

        public void loadKM()
        {
            cbx_SachKM.DataSource = KhuyenMaiBLL.getAllTenSach().DataSource;
            cbx_SachKM.ValueMember = "ID";
            cbx_SachKM.DisplayMember = "TEN";
            txt_MaKM.Text = KhuyenMaiBLL.getMaKM().ToString();
            dgv_AllKM.DataSource = KhuyenMaiBLL.getAllKM().DataSource;
            dgv_CTKM.DataSource = null;
        }
        private void tcl_Home_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //List chi tiết khuyến mại chờ
        public List<CHITIETKM> listCTKM = new List<CHITIETKM>();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                KHUYENMAI km = new KHUYENMAI();
                km.ID = int.Parse(txt_MaKM.Text);
                km.NGAYBATDAU = dtp_NgBatDauKM.Value;
                km.NGAYKETTHUC = dtp_NgKetThucKM.Value;
                km.ISDELETE = false;
                km.TENKM = txt_TenKM.Text;
                KhuyenMaiBLL newKM = new KhuyenMaiBLL();
                newKM.add(km);
                ChiTietKMBLL newCtkm = new ChiTietKMBLL();
                newCtkm.add(listCTKM);
                MessageBox.Show("Cập nhật thành công");
                txt_TenKM.ResetText();
                dtp_NgBatDauKM.ResetText();
                dtp_NgKetThucKM.ResetText();
                dgv_AllKM.DataSource = null;
                loadKM();
            }
            catch (Exception)
            {

                MessageBox.Show("Không thêm được");
            }

        }
        /// <summary>
        /// Thêm sách khuyến mại vào listCTKM chờ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ThemSachKM_Click(object sender, EventArgs e)
        {
            CHITIETKM ctkm = new CHITIETKM();
            ctkm.ID_SACH = int.Parse(cbx_SachKM.SelectedValue.ToString());
            ctkm.PTKM = Int32.Parse(txt_PtKM.Text.ToString());
            ctkm.ID_KM = int.Parse(txt_MaKM.Text);
            ctkm.ISDELETE = false;
            listCTKM.Add(ctkm);
            txt_PtKM.ResetText();
            cbx_SachKM.ResetText();
            txt_TenKM.Enabled = false;
            dgv_CTKM.DataSource = null;
            dgv_CTKM.DataSource = listCTKM;

        }
        //Mã khuyến mại khi double Click vào dgv_AllKM
        public int Makm;
        public void loadCTKM()
        {
            dgv_CTKM.DataSource = null;
            dgv_CTKM.DataSource = ChiTietKMBLL.getCTKM(Makm).DataSource;
            dgv_CTKM.Columns[1].Visible = false;
            dgv_CTKM.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgv_AllSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int id = int.Parse(dgv_AllKM.Rows[e.RowIndex].Cells[0].Value.ToString());
            Makm = id;
            txt_MaKM.Text = id.ToString();
            txt_TenKM.Text = dgv_AllKM.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtp_NgBatDauKM.Value = DateTime.Parse(dgv_AllKM.Rows[e.RowIndex].Cells[2].Value.ToString());
            dtp_NgKetThucKM.Value = DateTime.Parse(dgv_AllKM.Rows[e.RowIndex].Cells[3].Value.ToString());
            loadCTKM();
            btn_ThemSachKM.Enabled = false;

        }
        /// <summary>
        /// Xóa các textBox thêm mới
        /// Cài lại dgv_CTKM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_NhapLaiCTKM_Click(object sender, EventArgs e)
        {
            txt_MaKM.Text = KhuyenMaiBLL.getMaKM().ToString();
            txt_TenKM.ResetText();
            dtp_NgBatDauKM.ResetText();
            dtp_NgKetThucKM.ResetText();
            dgv_CTKM.DataSource = null;
            btn_XoaCTKM.Enabled = false;
        }
        //Chỉ số dòng đang chọn trong dgv_CTKM
        public int indexRowCTKM;
        /// <summary>
        /// Sự kiện khi nháy double vào row trong CTKM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_CTKM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indexRowCTKM = e.RowIndex;
            }

            cbx_SachKM.SelectedValue = dgv_CTKM.Rows[indexRowCTKM].Cells[1].Value;
            txt_PtKM.Text = dgv_CTKM.Rows[indexRowCTKM].Cells[3].Value.ToString();
        }
        /// <summary>
        /// Sửa phần trăm khuyến mại cho sách trong khuyến mại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            btn_ThemSachKM.Enabled = false;
            ChiTietKMBLL ctkm = new ChiTietKMBLL();
            int makm = int.Parse(txt_MaKM.Text);
            int maSach = int.Parse(dgv_CTKM.Rows[indexRowCTKM].Cells[1].Value.ToString());
            int pTKM = int.Parse(txt_PtKM.Text.ToString());
            ctkm.editCTKM(makm, maSach, pTKM);
            loadCTKM();
        }

        /// <summary>
        /// Xóa khuyến mại sách trong chi tiết hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_XoaCTKM_Click(object sender, EventArgs e)
        {
            ChiTietKMBLL ctkm = new ChiTietKMBLL();
            int maSach = int.Parse(dgv_CTKM.Rows[indexRowCTKM].Cells["ID_Sach"].Value.ToString());
            ctkm.deleteCTKM(Makm, maSach);
            loadCTKM();
        }
        /// <summary>
        /// Xóa khuyến mại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_XoaKM_Click(object sender, EventArgs e)
        {
            KhuyenMaiBLL km = new KhuyenMaiBLL();
            km.deleteKM(Makm);
            loadKM();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            HoaDonBLL.deleteHD(int.Parse(txt_MaHD.Text));
            loadCTHD();
            loadHD();
        }
        /// <summary>
        /// Sửa thông tin chi tiết hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            int mahd = int.Parse(txt_MaHD.Text);
            int maSach = int.Parse(cbx_Sach.SelectedValue.ToString());
            int sl = int.Parse(txt_SLSach.Text);
            if (listCTHD.Count() == 0)
            {

                ChiTietHDBLL.edit(mahd, maSach, sl);
            }
            else
            {
                //var item = (from a in listCTHD where a.ID_SACH == maSach select a).SingleOrDefault();

                listCTHD.Where(n => n.ID_SACH == maSach).SingleOrDefault().SOLUONG = sl;


            }
            loadCTHD();
        }
        public int MaHD;
        /// <summary>
        /// load chi tiết hóa đơn
        /// </summary>
        public void loadCTHD()
        {
            if (listCTHD.Count() != 0)
            {
                dgv_CTHD.DataSource = null;
                dgv_CTHD.DataSource = listCTHD;
                txt_TongTienHD.Text = HoaDonBLL.tongTienHD(listCTHD).ToString();
            }
            else
            {

                dgv_CTHD.DataSource = null;
                dgv_CTHD.DataSource = ChiTietHDBLL.getCTHDByID(MaHD).DataSource;
                txt_TongTienHD.Text = dgv_AllHD.Rows[indexRowAllHD].Cells[5].Value.ToString();
            }

        }
        /// <summary>
        /// Load thông tin liên quan đến hóa đơn lên tabpage
        /// </summary>
        public void loadHD()
        {
            //Đổ dữ liệu lên combobox
            cbx_Sach.DataSource = SachBLL.getSach();
            cbx_Sach.DisplayMember = "TEN";
            cbx_Sach.ValueMember = "ID";
            dgv_AllHD.DataSource = HoaDonBLL.getAllHD().DataSource;
            dgv_AllHD.Columns[1].Visible = false;
            dgv_AllHD.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_AllHD.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgv_AllHD.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            txt_MaHD.Text = HoaDonBLL.getMaHD().ToString();
            btn_SuaCTHD.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_SuaCTHD.Enabled = false;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_all_Click(object sender, EventArgs e)
        {
            loadHD();
        }

        //List chi tiêt hóa đơn chờ cập nhật
        List<CHITIETHOADON> listCTHD = new List<CHITIETHOADON>();
        /// <summary>
        /// Thêm sách vào hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ThemSachHD_Click(object sender, EventArgs e)
        {
            int sl;
            if (txt_SLSach.Text.Count() > 0 && int.TryParse(txt_SLSach.Text, out sl))
            {
                if (listCTHD.Where(n => n.ID_SACH == int.Parse(cbx_Sach.SelectedValue.ToString())).SingleOrDefault() == null && !ChiTietHDBLL.Is_CTHD(MaHD, int.Parse(cbx_Sach.SelectedValue.ToString())))
                {
                    CHITIETHOADON cthd = new CHITIETHOADON();
                    cthd.ID_HD = int.Parse(txt_MaHD.Text);
                    cthd.ID_SACH = int.Parse(cbx_Sach.SelectedValue.ToString());
                    cthd.SOLUONG = int.Parse(txt_SLSach.Text);
                    cthd.GIA = SachBLL.getSachID(int.Parse(cbx_Sach.SelectedValue.ToString())).GIABAN;
                    cthd.PTKM = ChiTietKMBLL.getPTKMIDSach(int.Parse(cbx_Sach.SelectedValue.ToString()));
                    cthd.ISDELETE = false;
                    listCTHD.Add(cthd);
                    txt_SLSach.ResetText();
                    cbx_Sach.ResetText();
                    loadCTHD();
                }
                else
                {
                    MessageBox.Show("Cuốn sách này đã có trong hóa đơn");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Có lỗi , tại trường số lượng");
            }


        }

        //Mã rows dgv_CTHD đang chọn
        public int indexRowCTHD;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_CTHD_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            indexRowCTHD = e.RowIndex;
            cbx_Sach.SelectedValue = int.Parse(dgv_CTHD.Rows[indexRowCTHD].Cells[1].Value.ToString());
            txt_SLSach.Text = dgv_CTHD.Rows[indexRowCTHD].Cells[5].Value.ToString();
            btn_ThemSachHD.Enabled = false;
            btn_SuaCTHD.Enabled = true;
            btn_XoaCTHD.Enabled = true;
            loadCTHD();
        }

        private void btn_XoaCTHD_Click(object sender, EventArgs e)
        {
            int maSach = int.Parse(dgv_CTHD.Rows[indexRowCTHD].Cells[1].Value.ToString());
            if (listCTHD.Count() != 0)
            {
                var item = listCTHD.Where(n => n.ID_SACH == maSach).SingleOrDefault();
                listCTHD.Remove(item);
            }
            else
            {
                ChiTietHDBLL.deleteCTHD(MaHD, maSach);
            }
            loadCTHD();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            cbx_Sach.ResetText();
            txt_SLSach.ResetText();
            btn_SuaCTHD.Enabled = false;
            btn_ThemSachHD.Enabled = true;
            listCTHD.Clear();
            dgv_CTHD.DataSource = null;
            txt_TongTienHD.Text = "0";
        }

        private void btn_TimChuDe_Click(object sender, EventArgs e)
        {

        }

        int indexRowAllHD;
        /// <summary>
        /// double click vào datagridview allHD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_AllHD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRowAllHD = e.RowIndex;
            txt_MaHD.Text = dgv_AllHD.Rows[indexRowAllHD].Cells[0].Value.ToString();
            var nv = AccountDataAccess.GetItem(int.Parse(dgv_AllHD.Rows[indexRowAllHD].Cells[1].Value.ToString()));
            txt_NhanVien.Text = nv.TEN;
            MaHD = int.Parse(dgv_AllHD.Rows[indexRowAllHD].Cells[0].Value.ToString());
            loadCTHD();
            btn_Xoa.Enabled = true;

        }

        /// <summary>
        /// THêm mới 1 hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ThemSach_Click(object sender, EventArgs e)
        {
            int idNV = _session.ID;
            int sl = int.Parse(listCTHD.Select(n => n.SOLUONG).Sum().ToString());
            string tongtien = txt_TongTienHD.Text;
            HoaDonBLL.creatHD(txt_MaHD.Text, idNV, tongtien, sl, dtp_NgayHD.Value, listCTHD);
            loadHD();
            listCTHD.Clear();
            loadCTKM();

        }
        //================================== PUBLISHER ===============================================

        public void TabPagePublisherLoad()
        {
            dgv_Publisher.DataSource = null;
            var data = Publisher.GetTable();

            dgv_Publisher.DataSource = data.DataSource;
            dgv_Publisher.Columns[7].Visible = false;
            dgv_Publisher.Columns[8].Visible = false;
            dgv_Publisher.Columns[9].Visible = false;
            dgv_Publisher.Columns[1].Visible = false;

            btn_AddNewPublisher.Visible = true;
            btn_DeletePublisher.Enabled = false;
            btn_UpdatePublisher.Enabled = false;
            cbx_StatusPublisher.SelectedIndex = 0;
            cbx_StatusPublisher.Enabled = false;

            dgv_Publisher.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgv_Publisher_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv_Publisher.Rows[e.RowIndex].Cells["STT_P"].Value = e.RowIndex + 1;
        }

        private void btn_CreateNewPublisher_Click(object sender, EventArgs e)
        {
            txt_PublisherName.Text = "";
            txt_PublisherAddress.Text = "";
            txt_PublisherPhone.Text = "";
            txt_PublisherFax.Text = "";
            rtb_PublisherIntroduce.Text = "";

            btn_CreateNewPublisher.Visible = false;
            btn_AddNewPublisher.Visible = true;
            btn_UpdatePublisher.Enabled = false;
            btn_DeletePublisher.Enabled = false;

            cbx_StatusPublisher.SelectedItem = 0;
            cbx_StatusPublisher.Enabled = false;
        }

        private void btn_AddNewPublisher_Click(object sender, EventArgs e)
        {
            var item = new NHAXUATBAN
            {
                TEN = txt_PublisherName.Text.Trim(),
                DIACHI = txt_PublisherAddress.Text.Trim(),
                SDT = txt_PublisherPhone.Text.Trim(),
                FAX = txt_PublisherFax.Text.Trim(),
                GIOITHIEU = rtb_PublisherIntroduce.Text.Trim()
            };

            if (Publisher.Insert(item))
            {
                TabPagePublisherLoad();
            }
            else
            {
                MessageBox.Show(@"Không thể insert dữ liệu!");
            }
        }

        private void btn_UpdatePublisher_Click(object sender, EventArgs e)
        {
            var item = new NHAXUATBAN
            {
                TEN = txt_PublisherName.Text.Trim(),
                DIACHI = txt_PublisherAddress.Text.Trim(),
                SDT = txt_PublisherPhone.Text.Trim(),
                FAX = txt_PublisherFax.Text.Trim(),
                GIOITHIEU = rtb_PublisherIntroduce.Text.Trim(),
                ISDELETE = cbx_StatusPublisher.SelectedIndex.ToString().Equals("1")
            };

            if (!Publisher.Update(item, _idSelected)) return;
            TabPagePublisherLoad();
            dgv_Publisher.Rows[_seletedRow].Selected = true;
            btn_CreateNewPublisher.PerformClick();
        }

        private void btn_DeletePublisher_Click(object sender, EventArgs e)
        {
            if (Publisher.Delete(_idSelected))
            {
                TabPagePublisherLoad();
            }
        }

        private void txt_PublisherName_TextChanged(object sender, EventArgs e)
        {
            if (!btn_AddNewPublisher.Visible) btn_UpdatePublisher.Enabled = true;
        }

        private void dgv_Publisher_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dgv_Publisher.Rows[e.RowIndex].Cells[1].Value;
            var item = Publisher.GetItem(Int32.Parse(id.ToString()));

            txt_PublisherName.Text = item.TEN.Trim();
            txt_PublisherAddress.Text = item.DIACHI.Trim();
            txt_PublisherPhone.Text = item.SDT.Trim();
            txt_PublisherFax.Text = item.FAX.Trim();
            rtb_PublisherIntroduce.Text = item.GIOITHIEU.Trim();

            cbx_StatusPublisher.Enabled = true;
            if (item.ISDELETE == false)
            {
                lbl_StatusPublisher.ForeColor = Color.Green;
                cbx_StatusPublisher.ForeColor = Color.Green;
                cbx_StatusPublisher.SelectedIndex = 0;
            }
            else
            {
                lbl_StatusPublisher.ForeColor = Color.Red;
                cbx_StatusPublisher.ForeColor = Color.Red;
                cbx_StatusPublisher.SelectedIndex = 1;
            }

            btn_AddNewPublisher.Visible = false;
            btn_CreateNewPublisher.Visible = true;
            btn_DeletePublisher.Enabled = true;
            btn_UpdatePublisher.Enabled = false;

            _idSelected = item.ID;
            _seletedRow = e.RowIndex;
        }

        private void cbx_StatusPublisher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_StatusPublisher.SelectedIndex == 0)
            {
                lbl_StatusPublisher.ForeColor = Color.Green;
                cbx_StatusPublisher.ForeColor = Color.Green;
            }
            else
            {
                lbl_StatusPublisher.ForeColor = Color.Red;
                cbx_StatusPublisher.ForeColor = Color.Red;
            }
            if (!btn_AddNewPublisher.Visible) btn_UpdatePublisher.Enabled = true;
        }
        /////////////////////////////////Sơn?????????????????????////
        //id row đang chọn bảng BOOK
        public int indexRowSach;
        int indexrowTacgia;
        int indexrowhdnhap;
        string biasach;
        OpenFileDialog ofd = new OpenFileDialog();
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
            indexRowSach = e.RowIndex;
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
        }
        /// <summary>
        /// lấy dữ liệu từ datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        }
        /// <summary>
        /// Chọn ảnh cho sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_openPicture_Click(object sender, EventArgs e)
        {
            ofd.Title = "Open Image";
            ofd.InitialDirectory = @"F:\hinh anh";
            ofd.Filter = "Image|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
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
            BookBLL.updateBook(id, txt_BookName.Text, prout, prin, txt_BookMT.Text, cd, nxb, biasach, sl, txt_BookK.Text, st);
            dgv_Book.DataSource = BookBLL.getAllBook().DataSource;
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
        }
        /// <summary>
        /// Xóa 1 tác giả
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            dgv_Author.DataSource = AuthorBLL.searchAuthor(txt_AuthorSearch.Text).DataSource;
        }

        /// <summary>
        /// Load thông tin tác giả
        /// </summary>
        public void loadbill()
        {
            txt_billID.Text = BillBLL.loadID().ToString();
            dgv_Bill.DataSource = BillBLL.getAllBill().DataSource;
            cbx_billNXB.DataSource = BillBLL.getNxbCBX();
            cbx_billNXB.ValueMember = "ID";
            cbx_billNXB.DisplayMember = "TEN";
        }
        /// <summary>
        /// load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_loadBill_Click(object sender, EventArgs e)
        {
            loadbill();
        }
        /// <summary>
        /// Đưa thông tin phiếu nhập lên datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Bill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indexrowhdnhap = e.RowIndex;
            txt_billID.Text = dgv_Bill.Rows[indexrowhdnhap].Cells[0].Value.ToString();
            cbx_billNXB.SelectedValue = dgv_Bill.Rows[indexrowhdnhap].Cells[1].Value;
            date_Bill.Text = dgv_Bill.Rows[indexrowhdnhap].Cells[2].Value.ToString();
            txt_billSl.Text = dgv_Bill.Rows[indexrowhdnhap].Cells[3].Value.ToString();
            txt_billBook.Text = dgv_Bill.Rows[indexrowhdnhap].Cells[4].Value.ToString();
            txt_billSLS.Text = dgv_Bill.Rows[indexrowhdnhap].Cells[5].Value.ToString();
        }
        /// <summary>
        /// Cập nhật thông tin phiếu nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_billUpdate_Click(object sender, EventArgs e)
        {
            int id_nxb = int.Parse(cbx_billNXB.SelectedValue.ToString());
            DateTime ngay = DateTime.Parse(date_Bill.Text);
            BillBLL.updateBill(int.Parse(txt_billID.Text), id_nxb, ngay, int.Parse(txt_billSl.Text), txt_billBook.Text, txt_billSLS.Text);
            dgv_Bill.DataSource = BillBLL.getAllBill().DataSource;
        }
        /// <summary>
        /// Xóa 1 phiếu nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_billDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BillBLL.deleteBill(int.Parse(txt_billID.Text));
                dgv_Bill.DataSource = BillBLL.getAllBill().DataSource;
            }
            else
            {
                this.Activate();
            }
        }
        /// <summary>
        /// Thêm mới 1 phiếu nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_billCreate_Click(object sender, EventArgs e)
        {
            int _ID = int.Parse(txt_billID.Text);
            BillBLL.createBill(_ID, int.Parse(cbx_billNXB.SelectedValue.ToString()), DateTime.Parse(date_Bill.Text), int.Parse(txt_billSl.Text), txt_billBook.Text, txt_billSLS.Text);
            dgv_Bill.DataSource = BillBLL.getAllBill().DataSource;
        }

        /// <summary>
        /// tìm kiếm 1 phiếu nhập nào đó theo thông tin sẵn có
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_billSearch_Click(object sender, EventArgs e)
        {
            dgv_Bill.DataSource = BillBLL.searchBill(int.Parse(txt_billID.Text)).DataSource;
        }

        private void tpe_Sach_Click(object sender, EventArgs e)
        {

        }









    }
}
