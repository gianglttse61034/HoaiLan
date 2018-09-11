using System;
using System.Data;

namespace BLL
{
   public class BllLookup
    {
       readonly String m_Sql;
       readonly object[] m_SqlPars;
       public BllLookup(string sql, object[] sqlPars)
       {
           m_Sql = sql;
           m_SqlPars = sqlPars;
       }
       /* ==================================================================================================== */
       public DataTable ReLoadData()
       {
           return m_SqlPars != null ? DAL.Lib.SqlHelper.ExecuteDataTable(m_Sql, CommandType.Text, m_SqlPars) : DAL.Lib.SqlHelper.ExecuteDataTable(m_Sql, CommandType.Text);
       }
    }
}
