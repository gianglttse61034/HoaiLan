using System;
using System.Data;

using DAL;

namespace BLL
{
    public class BllClsNguonDuLieu
    {
        #region Khai báo biến

        private readonly DalClsNguonDuLieu m_Dal;
        private readonly DateTime m_TuNgay;
        private DateTime m_DenNgay;

        #endregion Khai báo biến

        #region Khởi tạo(Constructor)

        public BllClsNguonDuLieu(DateTime tungay, DateTime denngay)
        {
            m_TuNgay = tungay;
            m_DenNgay = denngay;
            m_Dal = new DalClsNguonDuLieu();
        }

        #endregion Khởi tạo(Constructor)

        #region Kiểm tra ngày chứng từ

        /// <summary>
        /// Kiểm tra xem ngày chứng từ này có bị khóa không
        /// </summary>
        /// <param name="loaict">Loại chứng từ cần kiểm tra</param>
        /// <param name="ngay">Ngày cần kiểm tra</param>
        /// <returns>True: Khoa : Không khóa;</returns>
        private bool KiemTra(string loaict, DateTime ngay)
        {
            DataTable dt = m_Dal.LayNguonDuLieu(ngay);
            if (dt.Rows.Count == 0) return false;
            String nguondulieu = dt.Rows[0]["nguondulieu"].ToString();
            if (nguondulieu.Contains(loaict.Replace("'", ""))) return true;
            return false;
        }

        #endregion Kiểm tra ngày chứng từ

        /// <summary>
        /// Cho biết dữ liệu của khoảng thời gian này đã khóa hay chưa?
        /// </summary>
        /// <value>True: Đã khóa : Chưa khóa;</value>
        public bool DaKhoa(string loaict)
        {
            //Nếu có 1 tháng nào đó chưa khóa thì trả về false.
            DateTime ngay = m_TuNgay;
            while (ngay.Date.CompareTo(m_DenNgay.AddMonths(1).Date) < 0)
            {
                if (ngay.Date.CompareTo(m_DenNgay) > 0)
                    ngay = m_DenNgay;

                if (!KiemTra(loaict, ngay))
                    return false;
                ngay = ngay.AddMonths(1);
            }
            return true;
        }
    }
}