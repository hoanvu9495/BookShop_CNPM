using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.DAL;
using System.Windows.Forms;
using BookShop.Entities;

namespace BookShop.BLL
{
    public class HoaDonBLL
    {

        /// <summary>
        /// Lấy mã hóa đơn cho hóa đơn mới
        /// </summary>
        /// <returns></returns>
        public static int getMaHD()
        {

            try
            {
                DBConnection db = new DBConnection();
                var item = db.HOADONs.OrderByDescending(n => n.ID).Take(1).SingleOrDefault();
                if (item == null)
                {
                    return 1;
                }
                return ++item.ID;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Không lấy được dữ liệu");
            }
            return 0;
        }
        /// <summary>
        /// Lấy tất cả hóa đơn trong CSDL
        /// </summary>
        /// <returns></returns>
        public static DataGridView getAllHD()
        {
            DBConnection db = new DBConnection();
            var item = db.HOADONs.Join(db.NHANVIENs, hd => hd.ID_NV, nv => nv.ID, (hd, nv) => new { hd.ID, hd.ID_NV, hd.NGAY, hd.NHANVIEN.TEN, hd.SOLUONG, hd.THANHTIEN }).ToList();
            var data = new DataGridView();
            data.DataSource = item;
            return data;
        }
        /// <summary>
        /// Tính tổng tiền hóa đơn
        /// </summary>
        /// <param name="listCTHD"></param>
        /// <returns></returns>
        public static int tongTienHD(List<CHITIETHOADON> listCTHD)
        {
            int tong = 0;
            if (listCTHD != null)
            {
                foreach (var item in listCTHD)
                {
                    tong += (item.PTKM == 0) ? int.Parse((item.GIA * item.SOLUONG).ToString()) : int.Parse((item.GIA * item.SOLUONG * (1 - item.PTKM / 100)).ToString());
                }
            }

            return tong;
        }
        /// <summary>
        /// Tạo mới 1 hóa đơn
        /// </summary>
        /// <param name="maHD"></param>
        /// <param name="idNV"></param>
        /// <param name="tongTien"></param>
        /// <param name="sl"></param>
        /// <param name="ng"></param>
        /// <param name="lst"></param>
        public static void creatHD(string maHD, int idNV, string tongTien, int sl, DateTime ng, List<CHITIETHOADON> lst)
        {
            if (lst != null)
            {
                var db = new DBConnection();
                var hd = new HOADON();
                hd.ID = int.Parse(maHD);
                hd.ID_NV = idNV;
                hd.THANHTIEN = int.Parse(tongTien);
                hd.NGAY = ng;
                hd.SOLUONG = sl;
                hd.ISDELETE = false;
                if (db.HOADONs.Find(int.Parse(maHD)) == null)
                {
                    db.HOADONs.Add(hd);
                    db.SaveChanges();
                }

                db.CHITIETHOADONs.AddRange(lst);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Có lỗi, không thêm được dữ liệu");
            }
        }
        /// <summary>
        /// Xóa một hóa đơn
        /// </summary>
        /// <param name="id"></param>
        public static void deleteHD(int id)
        {
            var db = new DBConnection();
            var item = db.HOADONs.Find(id);
            if (item == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn này");
            }
            else
            {
                item.ISDELETE = true;
                db.SaveChanges();
            }
        }

    }
}
