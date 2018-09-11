using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPP_DATA;
using System.Data;

namespace DAL_GPP.DanhMuc
{
    public class DAL_DANHMUC_KH
    {
        private string table = "KHACHHANG";
        public bool InsertCommand(DataRow rw)
        {
            try
            {
                KetNoiData.InsertCommand(table,
                    "IDKHACHHANG", SqlDbType.Int, rw["IDKHACHHANG"],
                    "MAKHACHHANG", SqlDbType.NVarChar, rw["MAKHACHHANG"],
                    "TENKH", SqlDbType.NVarChar, rw["TENKH"],
                    "NGAYSINHKH", SqlDbType.NVarChar, rw["NGAYSINHKH"],
                    "DIACHIKH", SqlDbType.NVarChar, rw["DIACHIKH"],
                    "DIENTHOAIKH", SqlDbType.NVarChar, rw["DIENTHOAIKH"],
                    "QUAN", SqlDbType.NVarChar, rw["QUAN"],
                    "TINH", SqlDbType.NVarChar, rw["TINH"],
                    "GioiTinh", SqlDbType.NVarChar, rw["GioiTinh"]
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
                   "IDKHACHHANG", SqlDbType.Int, rw["IDKHACHHANG"],
                    "MAKHACHHANG", SqlDbType.NVarChar, rw["MAKHACHHANG"],
                    "TENKH", SqlDbType.NVarChar, rw["TENKH"],
                    "NGAYSINHKH", SqlDbType.NVarChar, rw["NGAYSINHKH"],
                    "DIACHIKH", SqlDbType.NVarChar, rw["DIACHIKH"],
                    "DIENTHOAIKH", SqlDbType.NVarChar, rw["DIENTHOAIKH"],
                    "QUAN", SqlDbType.NVarChar, rw["QUAN"],
                    "TINH", SqlDbType.NVarChar, rw["TINH"],
                    "GioiTinh", SqlDbType.NVarChar, rw["GioiTinh"]
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
                string str = string.Format("Delete {0} where IDKHACHHANG = {1}", table, id);
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
