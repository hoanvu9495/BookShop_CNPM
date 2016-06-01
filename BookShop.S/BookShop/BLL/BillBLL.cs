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
    public class BillBLL
    {
        /// <summary>
        /// Connection global
        /// </summary>
        DBConnection db;
        public BillBLL()
        {
            db = new DBConnection();
        }
        /// <summary>
        /// Đưa danh sách chi tiết phiếu nhập lên view
        /// </summary>
        /// <returns>datagridview</returns>
        public static DataGridView getAllBill()
        {
            return BillDataAccess.getBillDAL();
        }
        /// <summary>
        /// Đưa danh sánh phiếu nhập lên view
        /// </summary>
        /// <returns>datagridview</returns>
        public static DataGridView getAllB()
        {
            var db = new DBConnection();
            var data = new DataGridView();
            var item = db.PHIEUNHAPs.Where(n => n.ISDELETE == false).ToList();
            data.DataSource = item;
            return data;
        }
        /// <summary>
        /// them phieu nhap
        /// </summary>
        /// <param name="idpn">mã phiếu</param>
        /// <param name="idnxb">mã nhà xuất bản</param>
        /// <param name="tsl">tổng số lượng</param>
        public static void createLstbill(int idpn,int idnxb,int tsl)
        {
            DBConnection db = new DBConnection();
            PHIEUNHAP pn = new PHIEUNHAP();
            pn.ID = idpn;
            pn.ID_NXB = idnxb;
            pn.SOLUONG = tsl;
            pn.ISDELETE = false;
            db.PHIEUNHAPs.Attach(pn);
            db.PHIEUNHAPs.Add(pn);
            db.SaveChanges();
        }
        /// <summary>
        /// thêm mới hóa đơn
        /// </summary>
        /// <param name="idPn">mã phiếu</param>
        /// <param name="idS">mã sách</param>
        /// <param name="sl">số lượng sách</param>
        /// <param name="tien">tổng tiền</param>
        /// <param name="ngay">ngày nhập</param>
        /// <param name="idNV">mã nhân viên</param>
        public static void insertBill(int idPn, int idS, int? sl, int? tien, DateTime? ngay, int? idNV)
        {
            DBConnection db = new DBConnection();
            CHITIETPHIEUNHAP pn = new CHITIETPHIEUNHAP();
            pn.ID_PN = idPn;
            pn.ID_SACH = idS;
            pn.SOLUONG = sl;      
            pn.THANHTIEN = tien;
            pn.NGAYNHAP = ngay;
            pn.ID_NV = idNV;
            pn.ISDELETE = false;
            db.CHITIETPHIEUNHAPs.Attach(pn);
            db.CHITIETPHIEUNHAPs.Add(pn);
            var book = (from a in db.SACHes where a.ID == idS select a).SingleOrDefault();
            var bill = (from a in db.PHIEUNHAPs where a.ID == idPn select a).SingleOrDefault();
            book.SOLUONG += sl;
            bill.SOLUONG += sl;
            db.SaveChanges();
        }
        /// <summary>
        /// sửa hóa đơn
        /// </summary>
        /// <param name="idPn">mã phiếu</param>
        /// <param name="idS">mã sách</param>
        /// <param name="sl">số lượng sách</param>
        /// <param name="tien">tổng tiền</param>
        /// <param name="ngay">ngày nhập</param>
        /// <param name="idNV">mã nhân viên</param>
        public static void updateBill(int idPn, int idS, int sl, int tien, DateTime ngay, int idNV)
        {
            DBConnection db = new DBConnection();
            CHITIETPHIEUNHAP pn = new CHITIETPHIEUNHAP();
            pn.ID_PN = idPn;
            pn.ID_SACH = idS;
            pn.SOLUONG = sl;
            pn.THANHTIEN = tien;
            pn.NGAYNHAP = ngay;
            pn.ID_NV = idNV;
            pn.ISDELETE = false;
            db.CHITIETPHIEUNHAPs.Attach(pn);
            var entry = db.Entry(pn);
            entry.State = EntityState.Modified;
            var book = (from a in db.SACHes where a.ID == idS select a).SingleOrDefault();
            var bill = (from a in db.PHIEUNHAPs where a.ID == idPn select a).SingleOrDefault();
            book.SOLUONG += sl;
            bill.SOLUONG += sl;
            db.SaveChanges();
        }
   }
}
