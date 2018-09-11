using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GPP_DATA;

namespace DAL_GPP
{
   public  class DAL_TimKiem
    {
        /// <summary>
        /// Loại = 0: Solo
        /// Loại = 1: Thuốc
        /// </summary>
        /// <param name="soid"></param>
        /// <param name="loai"></param>
        /// <returns></returns>
        public DataSet ConnectData(string soid,int loai)
        {
            DataSet ds = new DataSet();
            string sql = string.Empty;
            if (loai == 0)
            {
                sql = "sp_XN_TimKiem_TheoIDTHUOC";
                ds = KetNoiData.ExecuteToDataSet(sql, CommandType.StoredProcedure
                , "@idThuoc", SqlDbType.Int, Convert.ToInt32(soid)
                );

                ds.Tables[0].TableName = "g";
                ds.Tables[1].TableName = "ct";

                //Relationship
                DataColumn[] parentColumns = { ds.Tables["g"].Columns["IDHDN"], ds.Tables["g"].Columns["SOLO"] };
                DataColumn[] childColumns = { ds.Tables["ct"].Columns["IDHDN"], ds.Tables["ct"].Columns["SOLO"] };
                ds.Relations.Add("R_ct", parentColumns, childColumns);
                return ds;
            }
            else
                if(loai==1)
            {
                sql = "sp_XN_TimKiem_TheoLo";
                ds = KetNoiData.ExecuteToDataSet(sql, CommandType.StoredProcedure
                , "@solo", SqlDbType.NVarChar, soid.ToString()
                );

                ds.Tables[0].TableName = "g";
                ds.Tables[1].TableName = "ct";

                //Relationship
                DataColumn[] parentColumns = { ds.Tables["g"].Columns["IDTHUOC"] };
                DataColumn[] childColumns = { ds.Tables["ct"].Columns["IDTHUOC"] };
                ds.Relations.Add("R_ct", parentColumns, childColumns);
                return ds;
            }
            return null;
        }
    }
}
