using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Entities;

namespace BookShop.BLL
{
    public class SachBLL
    {
        /// <summary>
        /// Lấy sách trong CSDL
        /// </summary>
        /// <returns></returns>
        public static List<SACH> getSach()
        {
            DBConnection db = new DBConnection();
            var ret = db.SACHes.Where(n => n.ISDELETE != true).ToList();
            return ret;
        }
        /// <summary>
        /// Lấy Sach theo id sách
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SACH getSachID(int id)
        {
            DBConnection db = new DBConnection();
            SACH sach = db.SACHes.Find(id);
            return sach;
        }
        public static int getID(string ten)
        {
            var db = new DBConnection();
            var sach = db.SACHes.Where(n=>n.TEN==ten).Single();
            return int.Parse(sach.ID.ToString());
        }

        public static int getSlSach(int maSach)
        {
            var db = new DBConnection();
            var sach = db.SACHes.Where(n => n.ID == maSach).Single();
            return int.Parse(sach.SOLUONG.ToString());
        }
    }
}
