using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Entities;
using System.Windows.Forms;

namespace BookShop.BLL
{
    public class ChiTietHDBLL
    {
        /// <summary>
        /// Sửa số lượng trong hóa đơn
        /// </summary>
        /// <param name="mahd"></param>
        /// <param name="sach"></param>
        /// <param name="sl"></param>
        public static void edit(int mahd, int sach, int sl)
        {
            DBConnection db = new DBConnection();
            CHITIETHOADON cthd = db.CHITIETHOADONs.Find(mahd, sach);
            cthd.SOLUONG = sl;
            db.SaveChanges();

        }

        /// <summary>
        /// Lấy chi tiết hóa đơn theo mã hóa đơn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataGridView getCTHDByID(int id)
        {
            DBConnection db = new DBConnection();
            var item = db.CHITIETHOADONs.
                Join(db.SACHes, cthd => cthd.ID_SACH, sach => sach.ID, (cthd, sach) => new
                {
                    cthd.ID_HD,
                    cthd.ID_SACH,
                    cthd.SACH.TEN,
                    cthd.GIA,
                    cthd.SOLUONG,
                    cthd.PTKM,
                }).
                Where(n=> n.ID_HD == id).ToList();
            var dat = new DataGridView();
            dat.DataSource = item;
            return dat;
        }

        public static bool Is_CTHD(int maHD, int idSach)
        {
            var db = new DBConnection();
            var item = db.CHITIETHOADONs.Where(n => n.ID_SACH == idSach && n.ID_HD == maHD).SingleOrDefault();
            if (item == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Xoa sach trong Hóa đơn
        /// </summary>
        /// <param name="maHD"></param>
        /// <param name="maSach"></param>
        public static void deleteCTHD(int maHD, int maSach)
        {
            DBConnection db = new DBConnection();
            var item = db.CHITIETHOADONs.Find(maHD, maSach);
            db.CHITIETHOADONs.Remove(item);
            db.SaveChanges();
        }
    }
}
