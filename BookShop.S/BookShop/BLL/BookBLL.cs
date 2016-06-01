using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShop.DAL;
using BookShop.Entities;

namespace BookShop.BLL
{
    class BookBLL
    {
        /// <summary>
        /// Connection global
        /// </summary>
        DBConnection db;
        public BookBLL()
        {
            db = new DBConnection();
        }
        /// <summary>
        /// Đưa danh sách những cuốn sách lên view
        /// </summary>
        /// <returns>datagridview</returns>
        public static DataGridView getAllBook()
        {
            return BookDataAccess.getBookDAL();
        }
        /// <summary>
        /// lấy ID sách mới
        /// </summary>
        /// <returns>int</returns>
        public static int loadID()
        {
            var db = new DBConnection();
            var item = db.SACHes.OrderByDescending(n => n.ID).Take(1).SingleOrDefault();
            if (item == null)
            {
                return 1;
            }
            return ++item.ID;
        }
        /// <summary>
        /// lấy đữ liệu chủ đề đổ vào combobox
        /// </summary>
        /// <returns>list<chude></returns>
        public static List<CHUDE> getChudeCBX()
        {
            var db = new DBConnection();
            var lstcd = db.CHUDEs.Where(n => n.ISDELETE != true).ToList();
            return lstcd;
        }
        /// <summary>
        /// lấy đữ liệu nhà xuất bản đổ vào combobox
        /// </summary>
        /// <returns>list</returns>
        public static List<NHAXUATBAN> getNxbCBX()
        {
            var db = new DBConnection();
            var lstcd = db.NHAXUATBANs.Where(n => n.ISDELETE != true).ToList();
            return lstcd;
        }
        /// <summary>
        /// lấy tác giả
        /// </summary>
        /// <returns></returns>
        public static DataGridView getTggrid(int id)
        {
            var db = new DBConnection();
            var data = new DataGridView();
            var lsttg = db.VIETSACHes.Where(n => n.ISDELETE != true && n.ID_SACH==id).ToList();
            data.DataSource = lsttg;
            return data;
        }
        /// <summary>
        /// Sửa thông tin 1 cuốn sách
        /// </summary>
        /// <param name="id">mã sách</param>
        /// <param name="name">tên sách</param>
        /// <param name="price_Out">giá bán</param>
        /// <param name="price_In">giá nhập</param>
        /// <param name="mota">nô tả</param>
        /// <param name="id_Chude">mã chủ đề</param>
        /// <param name="id_Nxb">mã nhà xuất bản</param>
        /// <param name="soluong">số lượng</param>
        /// <param name="kho">khổ</param>
        /// <param name="sotrang">số trang</param>
        public static void updateBook(int id,string name, int price_Out, int price_In, string mota, int id_Chude, int id_Nxb, string bia, int soluong, string kho, int sotrang)
        {
            DBConnection db = new DBConnection();
            SACH sa = new SACH();
            sa.ID = id;
            sa.TEN = name.Trim();
            sa.GIABAN = price_Out;
            sa.GIANHAP = price_In;
            sa.MOTA = mota;
            sa.ID_CHUDE = id_Chude;
            sa.ID_NXB = id_Nxb;
            sa.BIA = bia;
            sa.SOLUONG = soluong;
            sa.KHO = kho;
            sa.SOTRANG = sotrang;
            sa.ISDELETE = false;
            db.SACHes.Attach(sa);
            var entry = db.Entry(sa);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
        /// <summary>
        /// Tạo mới 1 cuốn sách
        /// </summary>
        /// <param name="id">mã sách</param>
        /// <param name="name">tên sách</param>
        /// <param name="price_Out">giá bán</param>
        /// <param name="price_In">giá nhập</param>
        /// <param name="mota">nô tả</param>
        /// <param name="id_Chude">mã chủ đề</param>
        /// <param name="id_Nxb">mã nhà xuất bản</param>
        /// <param name="soluong">số lượng</param>
        /// <param name="kho">khổ</param>
        /// <param name="sotrang">số trang</param>
        public static void insertBook(int id, string name, int price_Out, int price_In, string mota, int id_Chude, int id_Nxb, string bia, int soluong, string kho, int sotrang)
        {
            DBConnection db = new DBConnection();
            SACH sa = new SACH();
            sa.ID = id;
            sa.TEN = name.Trim();
            sa.GIABAN = price_Out;
            sa.GIANHAP = price_In;
            sa.MOTA = mota;
            sa.ID_CHUDE = id_Chude;
            sa.ID_NXB = id_Nxb;
            sa.BIA = bia;
            sa.SOLUONG = soluong;
            sa.KHO = kho;
            sa.SOTRANG = sotrang;
            sa.ISDELETE = false;
            db.SACHes.Attach(sa);
            db.SACHes.Add(sa);
            db.SaveChanges();
        }
        /// <summary>
        /// Tìm kiếm 1 cuốn sách
        /// </summary>
        /// <param name="name"></param>
        /// <returns>datagridview</returns>
        public static DataGridView searchBook(string name)
        {
            DBConnection db = new DBConnection();
            DataGridView data = new DataGridView();
            var item = db.SACHes.Where(x => x.ISDELETE == false).ToList().FindAll(x=> x.TEN==name);
            data.DataSource = item;
            return data;
        }
        /// <summary>
        /// Dừng bán sách
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price_Out"></param>
        /// <param name="price_In"></param>
        /// <param name="mota"></param>
        /// <param name="id_Chude"></param>
        /// <param name="id_Nxb"></param>
        /// <param name="bia"></param>
        /// <param name="soluong"></param>
        /// <param name="kho"></param>
        /// <param name="sotrang"></param>
        public static void stopBook(int id, string name, int price_Out, int price_In, string mota, int id_Chude, int id_Nxb, string bia, int soluong, string kho, int sotrang)
        {
            DBConnection db = new DBConnection();
            SACH sa = new SACH();
            sa.ID = id;
            sa.TEN = name.Trim();
            sa.GIABAN = price_Out;
            sa.GIANHAP = price_In;
            sa.MOTA = mota;
            sa.ID_CHUDE = id_Chude;
            sa.ID_NXB = id_Nxb;
            sa.BIA = bia;
            sa.SOLUONG = soluong;
            sa.KHO = kho;
            sa.SOTRANG = sotrang;
            sa.ISDELETE = true;
            db.SACHes.Attach(sa);
            var entry = db.Entry(sa);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
