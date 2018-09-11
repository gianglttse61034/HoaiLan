using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPP_DATA;
using System.Data;

namespace DAL_GPP.DanhMuc
{
    public class DAL_DANHMUC_DVT
    {
        private string table = "DVT";
        public bool InsertCommand(DataRow rw)
        {
            try
            {
                KetNoiData.InsertCommand(table,
                    "IDDVT", SqlDbType.Int, rw["IDDVT"],
                    "TENDVT", SqlDbType.NVarChar, rw["TENDVT"]
                    );
                return true;
            }
            catch (Exception  e)
            {
                return false;
                throw e;
            }
        }

        //Mặc định key nằm ở vi trí đầu
        public bool UpdateCommand(DataRow rw)
        {
            try
            {
                KetNoiData.UpdateCommand(table,
                    "IDDVT", SqlDbType.Int, rw["IDDVT"],
                    "TENDVT", SqlDbType.NVarChar, rw["TENDVT"]
                    );
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

        public bool DeleteCommand(int id)
        {
            try
            {
                string str = string.Format("Delete {0} where IDDVT = {1}", table, id);
                KetNoiData.ExecuteNonQuery(str);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

    }
}
