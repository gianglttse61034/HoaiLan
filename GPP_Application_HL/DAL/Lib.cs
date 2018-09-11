using System;
using System.Data;
using System.Data.SqlClient;
using Ets.Data;

namespace DAL
{
    public static class Lib
    {
        public static SqlHelper SqlHelper = new SqlHelper();

        #region Kiểm tra khóa khi thêm(kiểm tra giá trị trùng)

        /// <summary>
        /// Kiểm tra khóa trùng
        /// Nếu khóa trùng trả về Bảng có giá trị
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="keyColumn">Tên trường làm khóa("ma_tk")</param>
        /// <param name="newValue"></param>
        /// <param name="oldValue"></param>
        /// <returns>Trả về bảng chứa giá trị</returns>
        public static DataTable IsExistKey(string tableName, string keyColumn, string newValue, object oldValue)
        {
            string sql = "select * from " + tableName
                         + " WHERE " + keyColumn + " = @new_value AND @new_value <> @old_value";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text,
                                              "@new_value", SqlDbType.NChar, newValue,
                                              "@old_value", SqlDbType.NChar, oldValue);
        }

        #endregion Kiểm tra khóa khi thêm(kiểm tra giá trị trùng)

        #region Kiểm tra khóa có tồn tại không(KeyIsExist)

        /// <summary>
        /// Check a key is exist in table.        
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="pars">Sql parameter: "Name", SqlDbType, value ("id", SqlDbType.int, 1 [, ...])).Notice: Name not have "@"</param>
        /// <returns>Is Exist?True:False</returns>
        public static bool KeyIsExist(string tableName, params object[] pars)
        {
            if (SqlHelper.KeyIsExist(tableName, pars))
                return true;
            return false;
        }

        #endregion Kiểm tra khóa có tồn tại không(KeyIsExist)

        #region Lấy DataTable

        /// <summary>
        /// Execute a SQL and return a Datatable
        /// </summary>
        /// <param name="sql">sql string</param>
        /// <param name="commandType"></param>
        /// <param name="pars">Sql parameter: "@Name", SqlDbType, Value ("@id",SqlDbType.int, 1 [, ...])</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string sql, CommandType commandType, params object[] pars)
        {
            return SqlHelper.ExecuteDataTable(sql, commandType, pars);
        }

        public static DataSet ExecuteDataSet(string sql, CommandType commandType, params object[] pars)
        {
            return SqlHelper.ExecuteDataSet(sql, commandType, pars);
        }

        #endregion Lấy DataTable

        #region Lấy DataTable có truyền kết nối(ConnectionString)

        /// <summary>
        /// Execute a SQL and return a Datatable có truyền 1 kết nối(ConnectionString)
        /// </summary>
        /// <param name="con">ConnectionString</param>
        /// <param name="sql">sql string</param>
        /// <param name="commandType"></param>
        /// <param name="pars">Sql parameter: "@Name", SqlDbType, Value ("@id",SqlDbType.int, 1 [, ...])</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(SqlConnection con, string sql, CommandType commandType,
                                                 params object[] pars)
        {
            return SqlHelper.ExecuteDataTable(con, sql, commandType, pars);
        }

        public static DataSet ExecuteDataSet(SqlConnection con, string sql, CommandType commandType,
                                                 params object[] pars)
        {
            return SqlHelper.ExecuteDataSet(con, sql, commandType, pars);
        }

        #endregion Lấy DataTable

        public static decimal GetLuongChiPhi(string soTK, string loaiTK, DateTime tuNgay, DateTime denNgay)
        {
            String[] mDsBang = new String[]
                                   {
                                       "tc_pttmg", "tc_pttmct",
                                       "tc_pctmg", "tc_pctmct",
                                       "tc_ptnhg", "tc_ptnhct",
                                       "tc_pcnhg", "tc_pcnhct",
                                       "tc_tttug", "tc_tttuct",
                                       "tc_tvaydhg", "tc_tvaydhct",
                                       "tc_vaydhg", "tc_vaydhct",
                                       "tc_tvaynhg", "tc_tvaynhct",
                                       "tc_vaynhg", "tc_vaynhct",
                                       "vt_pnvtg", "vt_pnvtct",
                                       "vt_pxvtg", "vt_pxvtct",
                                       "bb_pnbbg", "bb_pnbbct",
                                       "bb_pxbbg", "bb_pxbbct",
                                       "nl_pnnlg", "nl_pnnlct",
                                       "nl_pxnlg", "nl_pxnlct",
                                       "vl_pnvlg", "vl_pnvlct",
                                       "vl_pxvlg", "vl_pxvlct",
                                       "tp_pntpg", "tp_pntpct",
                                       "tp_pxtpg", "tp_pxtpct",
                                       "sp_hh_pxhhg", "sp_hh_pxhhct",
                                       "sp_hh_pnhhg", "sp_hh_pnhhct",
                                       "sp_hh_hdhhg", "sp_hh_hdhhct",
                                       "th_hddvg", "th_hddvct",
                                       "th_ctgsphaithug", "th_ctgsphaithuct",
                                       "th_ctgsphaitrag", "th_ctgsphaitract",
                                       "th_ctgsphaitrakhacg", "th_ctgsphaitrakhacct",
                                       "th_ctgsnoibog", "th_ctgsnoiboct",
                                       "th_pktg", "th_pktct"
                                   };
            string sql = "";
            for (int i = 0; i < mDsBang.Length; i += 2)
            {
                sql +=
                    String.Format(
                        @" Union all 
                          select ct.sotien from {0} as g,{1} as ct 
                          where left({2},len(@sotk)) = @sotk and g.soid = ct.soid and dbo.ngay(ngayct) between dbo.ngay(@tungay) and dbo.ngay(@denngay) ",
                        mDsBang[i], mDsBang[i + 1], loaiTK);
            }
            sql = sql.Substring(10);
            sql = String.Format("Select sum(sotien) from ({0}) as T", sql);
            decimal result;
            decimal.TryParse(SqlHelper.ExecuteDataValue(sql, CommandType.Text,
                                                        "@soTK", SqlDbType.NChar, soTK,
                                                        "@tungay", SqlDbType.DateTime, tuNgay,
                                                        "@denngay", SqlDbType.DateTime, denNgay).ToString(), out result);
            return result;
        }
        public static string LayChuoiDK(String maNsd)
        {
            return string.Format(" AND (((case when ISNULL(nguoitao,'') = '' then '{0}' else nguoitao end) = '{0}' or CHARINDEX(nguoitao, '{1}') >= 1) or '{1}' like '%**%' )", maNsd, LayThongTinUyQuyen(maNsd));
        }

        /// <summary>
        /// tạo chuỗi điều kiện theo danh sách kho được cấp quyền truy cập
        /// ** là tất cả kho
        /// </summary>
        /// <param name="maNsd"></param>
        /// <returns></returns>
        public static string LayChuoiDKKho(String maNsd)
        {
            return string.Format(" ((CHARINDEX(rtrim(ma_kho), '{0}') >= 1) or '{0}' like '%**%' )",  LayThongTinDsKho(maNsd));
        }
        public static string LayThongTinUyQuyen(string maNsd)
        {
            DataTable dt = ExecuteDataTable("select uyquyen from ht_dm_nsd where ma_nsd = @ma_nsd", CommandType.Text,
                "@ma_nsd", SqlDbType.NChar, maNsd);
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0] == null ? string.Empty : dt.Rows[0][0].ToString();
            return string.Empty;
        }

        /// <summary>
        /// lấy danh sách kho được phân quyền cho người sử dụng
        /// </summary>
        /// <param name="maNsd"></param>
        /// <returns></returns>
        public static string LayThongTinDsKho(string maNsd)
        {
            DataTable dt = ExecuteDataTable("select dsKho from ht_dm_nsd where ma_nsd = @ma_nsd", CommandType.Text,
                "@ma_nsd", SqlDbType.NChar, maNsd);
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0] == null ? string.Empty : dt.Rows[0][0].ToString();
            return string.Empty;
        }
        
    }
}