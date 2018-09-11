using System.Data;

namespace DAL
{
    public class DalGridHelper
    {
        public DataTable LayDMLoaiNV(string maLoainx, string loaict)
        {
            const string sql = "select distinct ma_loainv, ten_loainv,tkno,tkco " +
                               "From dm_loainx " +
                               "Where loaict = @loaict AND ma_loainx = @ma_loainx";
            return Lib.SqlHelper.ExecuteDataTable(sql, CommandType.Text,
                                                  "@ma_loainx", SqlDbType.NChar, maLoainx,
                                                  "@loaict", SqlDbType.NChar, loaict
                );
        }
    }
}