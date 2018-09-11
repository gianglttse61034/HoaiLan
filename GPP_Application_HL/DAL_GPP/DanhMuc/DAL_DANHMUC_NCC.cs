using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPP_DATA;
using System.Data;

namespace DAL_GPP.DanhMuc
{
    public class DAL_DANHMUC_NCC
    {
        private string table = "NCC";
        public bool InsertCommand(DataRow rw)
        {
            try
            {
                KetNoiData.InsertCommand(table,
                     "IDNCC", SqlDbType.Int, rw["IDNCC"],
                    "TENNCC", SqlDbType.NVarChar, rw["TENNCC"],
                    "DIACHINCC", SqlDbType.NVarChar, rw["DIACHINCC"],
                    "DIENTHOAINCC", SqlDbType.NVarChar, rw["DIENTHOAINCC"],
                    "SoDKDK", SqlDbType.NVarChar, rw["SoDKDK"],
                    "FAX", SqlDbType.NVarChar, rw["FAX"],
                    "GHICHU", SqlDbType.NVarChar, rw["GHICHU"]
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
                    "IDNCC", SqlDbType.Int, rw["IDNCC"],
                    "TENNCC", SqlDbType.NVarChar, rw["TENNCC"],
                    "DIACHINCC", SqlDbType.NVarChar, rw["DIACHINCC"],
                    "DIENTHOAINCC", SqlDbType.NVarChar, rw["DIENTHOAINCC"],
                    "SoDKDK", SqlDbType.NVarChar, rw["SoDKDK"],
                    "FAX", SqlDbType.NVarChar, rw["FAX"],
                    "GHICHU", SqlDbType.NVarChar, rw["GHICHU"]
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
                string str = string.Format("Delete {0} where IDNCC = {1}", table, id);
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
