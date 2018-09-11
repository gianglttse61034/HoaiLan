
using System;
using System.Data;
using System.Data.SqlClient;

using DAL;
using Ets.Data; 

namespace BLL
{
    public class BllLib
    {
        /// <summary>
        /// Kiểm tra khóa trùng
        /// Nếu khóa trùng trả về True ngược lại trả về False
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="keyColumn">Tên trường làm khóa("ma_tk")</param>
        /// <param name="newValue">Giá trị mới("111")</param>
        /// <param name="oldValue">Giá trị cũ("112")</param>
        /// <returns>Trùng?True:false</returns>
        public static bool IsExistKey(string tableName, string keyColumn, string newValue, object oldValue)
        {
            if (Lib.IsExistKey(tableName, keyColumn, newValue, oldValue).Rows.Count > 0)
                return true;
            return false;
        }

        #region Kiểm tra khóa có tồn tại không(KeyIsExist)

        /// <summary>
        /// Check a key is exist in table.        
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="pars">Sql parameter: "Name", SqlDbType, value ("id", SqlDbType.int, 1 [, ...])).Notice: Name not have "@"</param>
        /// <returns>Is Exist?True:False</returns>
        public static bool KeyIsExist(string tableName, params object[] pars)
        {
            return Lib.KeyIsExist(tableName, pars);
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
            return Lib.ExecuteDataTable(sql, commandType, pars);
        }

        /// <summary>
        /// Execute a SQL and return a DataSet
        /// </summary>
        /// <param name="sql">sql string</param>
        /// <param name="commandType"></param>
        /// <param name="pars">Sql parameter: "@Name", SqlDbType, Value ("@id",SqlDbType.int, 1 [, ...])</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(string sql, CommandType commandType, params object[] pars)
        {
            return Lib.ExecuteDataSet(sql, commandType, pars);
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
            return Lib.ExecuteDataTable(con, sql, commandType, pars);
        }

        public static DataSet ExecuteDataSet(SqlConnection con, string sql, CommandType commandType,
                                                 params object[] pars)
        {
            return Lib.ExecuteDataSet(con, sql, commandType, pars);
        }

        #endregion Lấy DataTable

        public static decimal GetValue(string soTK, string loaiTK, DateTime tuNgay, DateTime denNgay)
        {
            return Lib.GetLuongChiPhi(soTK, loaiTK, tuNgay, denNgay);
        }
        public bool CheckKeyForDelete(string nameTable, string nameColumn, string value)
        {
            return new SqlHelper().CheckKeyForDelete(nameTable, nameColumn, value);
        }
    /// <summary>
    /// Chỉ dùng cho vidipha
    /// order by theo solo và tô màu nếu còn <=1 năm hạn dùng
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
        public static DataTable HieuChinhLookupSolo(DataTable dt,DateTime ngayct)
        {
            dt.Columns.Add("nhom", typeof(Boolean));
            dt.Columns.Add("solo2", typeof(string));
            foreach (DataRow r in dt.Rows)
            {
                string s;
                try
                {
                    s = r["handung"] == null? "": r["handung"].ToString();
                    DateTime date1 = new DateTime(2000 + int.Parse(s.Substring(4, 2)), int.Parse(s.Substring(2, 2)), int.Parse(s.Substring(0, 2)));
                    if (((TimeSpan)(date1.Date - ngayct.Date)).TotalDays < 365)
                        r["nhom"] = true;
                }
                catch { }
                try
                {
                    s = r["solo"] == null ? "" : r["solo"].ToString();
                    r["solo2"] =  "20" + s.Substring(4, 2) + s.Substring(2, 2) + s.Substring(0, 2);
                }
                catch { }
            }
            dt.DefaultView.Sort = "solo2";
            return dt.DefaultView.ToTable();
        }
        public static String GetTempTableName()
        {
            return SqlHelper.GetTempTableName();
        }
        public static SqlConnection GetConnection()
        {
            return new SqlHelper().GetConnection();
        }
        public static void ExecuteNonQuery(
        string sql,
        CommandType commandType,
        params object[] pars)
        {
            new SqlHelper().ExecuteNonQuery(sql, commandType, pars);
        }

        /// <summary>
        /// kiểm tra tablename với nhiều khóa
        /// </summary>
        /// <param name="isAdnew">1: thêm mới, 0: sửa</param>
        /// <param name="tablename">tablename</param>
        /// <param name="pars">danh sách khóa của table (field, value_new, value_old)</param>
        /// <returns></returns>
        public static bool CheckExistKeys(bool isAddnew, string tablename, params object[] pars)
        {
            string sql = string.Empty;
            for (int i = 0; i < pars.Length; i += 3)
            {
                if (isAddnew)//thêm mới thì chỉ kiểm tra giá trị mới
                {
                    if (sql == string.Empty)
                        sql = string.Format("{0} = N'{1}' ", pars[i], pars[i + 1]);
                    else
                        sql = string.Format("{0} and {1} = N'{2}' ", sql, pars[i], pars[i + 1]);
                }
                else//trường hợp sửa thì kiểm tra giá trị cũ và giá trị mới lun
                {
                    //trường hợp chỉ có 1 key
                    if (pars.Length <= 3)
                        sql = string.Format("{0} = N'{1}' AND N'{1}' <> N'{2}'", pars[i], pars[i + 1], pars[i + 2]);
                    else//trường hợp có nhiều hơn 1 key
                    {
                        if (sql == string.Empty)
                            sql = string.Format("{0} = N'{1}'  ", pars[i], pars[i + 1]);
                        else
                            sql = string.Format("{0} and {1} = N'{2}' AND N'{2}' <> N'{3}'", sql, pars[i], pars[i + 1], pars[i + 2]);
                    }
                }
            }
            sql = string.Format("select * from {0} where {1} ", tablename, sql);
            DataTable dt = ExecuteDataTable(sql, CommandType.Text);
            //khóa đã tồn tại
            if (dt != null && dt.Rows.Count > 0)
                return true;
            //khóa không tồn tại
            return false;
        }

        /// <summary>
        /// kiểm tra giá trị đã được sử dụng ở table chỉ định hay chưa
        /// </summary>
        /// <param name="value">giá trị của field</param>
        /// <param name="datatype">loại dữ liệu của field</param>
        /// <param name="pars">danh sách các table cần kiểm tra theo cấu trúc: (tablename, columnname)</param>
        /// <returns>true: đang sử dụng, false: chưa sử dụng, có thể xóa được</returns>
        public static string CheckUsingKey(object value, SqlDbType datatype, params object[] pars)
        {
            string sql = string.Empty, str_result = string.Empty;
            for (int i = 0; i < pars.Length; i+=2)
            {
                if (datatype == SqlDbType.NVarChar || datatype == SqlDbType.DateTime)
                {
                    //if (i > 0) sql = string.Format("union \n {0}", sql);
                    if (sql == string.Empty)
                        sql = string.Format(@"select * from (select top 1 '{0}' as tablename, {1} as col from {0} 
where isnull({1},'')=N'{2}' or (isnull({1},'')<>N'{2}') and isnull({1},'') like N'%{2}%' ) as t1
inner join dm_table as t2 on t1.tablename=t2.table_name", pars[i], pars[i + 1], value);
                    else
                        sql = string.Format(@"{0}  union select * from (select top 1 '{1}' as tablename, {2} as col from {1} 
where isnull({2},'')=N'{3}' or (isnull({2},'')<>N'{3}') and isnull({2},'') like N'%{3}%' ) as t1
inner join dm_table as t2 on t1.tablename=t2.table_name", sql, pars[i], pars[i + 1], value);
                }
                else if (datatype == SqlDbType.Decimal || datatype == SqlDbType.Int)
                {
                    //if (i > 0) sql = string.Format("union \n {0}", sql);
                    if (sql == string.Empty)
                        sql = string.Format(@"select * from (select top 1 '{0}' as tablename, {1} as col from {0} where {1}={2}) as t1
inner join dm_table as t2 on t1.tablename=t2.table_name", pars[i], pars[i + 1], value);
                    else
                        sql = string.Format(@"{0} union select * from (select top 1 '{1}' as tablename, {2} as col from {1} where {2}={3}) as t1
inner join dm_table as t2 on t1.tablename=t2.table_name", sql, pars[i], pars[i + 1], value);
                }
            }

            DataTable dt = ExecuteDataTable(sql, CommandType.Text);
            //khóa đã sử dụng
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str_result = string.Format("{0}, {1}", str_result, row["table_caption"]);
                }
            }
            //danh sách table sử dụng
            return str_result;
        }

    }
}