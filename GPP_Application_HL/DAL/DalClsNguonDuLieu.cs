using System;
using System.Data;

namespace DAL
{
    public class DalClsNguonDuLieu
    {
        #region Lấy nguồn dữ liệu

        /// <summary>
        /// Lấy nguồn dữ liệu
        /// </summary>
        /// <param name="ngay">Ngày để lấy năm tháng</param>
        /// <returns>Bảng các nguồn dữ liệu</returns>
        public DataTable LayNguonDuLieu(DateTime ngay)
        {
            const string sql = "SELECT * FROM ht_khdl WHERE namthang = Convert(Char(6),@ngay,112)";
            return Lib.SqlHelper.ExecuteDataTable(sql, CommandType.Text,
                                                  "@ngay", SqlDbType.DateTime, ngay);
        }

        #endregion Lấy nguồn dữ liệu
    }
}