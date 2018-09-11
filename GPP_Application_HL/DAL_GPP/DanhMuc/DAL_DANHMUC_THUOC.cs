using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPP_DATA;
using System.Data;

namespace DAL_GPP.DanhMuc
{
    public class DAL_DANHMUC_THUOC
    {
        private string table = "THUOC";
        public bool InsertCommand(DataRow rw)
        {
            try
            {
                KetNoiData.InsertCommand(table,
                    "IDTHUOC", SqlDbType.Int, rw["IDTHUOC"],
                    "IDLOAITHUOC", SqlDbType.Int, rw["IDLOAITHUOC"],
                    "IDSANPHAM", SqlDbType.Int, rw["IDSANPHAM"],
                    "IDDVT", SqlDbType.Int, rw["IDDVT"],
                    "MATHUOC", SqlDbType.NVarChar, rw["MATHUOC"],
                    "TENTHUOC", SqlDbType.NVarChar, rw["TENTHUOC"],
                    "NHIETDOBQ", SqlDbType.NVarChar, rw["NHIETDOBQ"],
                    "TRANHAM", SqlDbType.Int, rw["TRANHAM"],
                    "TRANHANHSANG", SqlDbType.Int, rw["TRANHANHSANG"],
                    "TRANHNHIETDO", SqlDbType.Int, rw["TRANHNHIETDO"],
                    "TRANHDONG", SqlDbType.Int, rw["TRANHDONG"],
                    "idnsx", SqlDbType.Int, rw["idnsx"],
                    "GhiChu", SqlDbType.NVarChar, rw["GhiChu"],
                    "ViTriThuoc", SqlDbType.NVarChar, rw["ViTriThuoc"],
                    "Dongia", SqlDbType.NVarChar, rw["Dongia"]
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
                    "IDTHUOC", SqlDbType.Int, rw["IDTHUOC"],
                    "IDLOAITHUOC", SqlDbType.Int, rw["IDLOAITHUOC"],
                    "IDSANPHAM", SqlDbType.Int, rw["IDSANPHAM"],
                    "IDDVT", SqlDbType.Int, rw["IDDVT"],
                    "MATHUOC", SqlDbType.NVarChar, rw["MATHUOC"],
                    "TENTHUOC", SqlDbType.NVarChar, rw["TENTHUOC"],
                    "NHIETDOBQ", SqlDbType.NVarChar, rw["NHIETDOBQ"],
                    "TRANHAM", SqlDbType.Int, rw["TRANHAM"],
                    "TRANHANHSANG", SqlDbType.Int, rw["TRANHANHSANG"],
                    "TRANHNHIETDO", SqlDbType.Int, rw["TRANHNHIETDO"],
                    "TRANHDONG", SqlDbType.Int, rw["TRANHDONG"],
                    "idnsx", SqlDbType.Int, rw["idnsx"],
                    "GhiChu", SqlDbType.NVarChar, rw["GhiChu"],
                    "ViTriThuoc", SqlDbType.NVarChar, rw["ViTriThuoc"],
                    "Dongia", SqlDbType.NVarChar, rw["Dongia"]
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
                string str = string.Format("Delete {0} where IDTHUOC = {1}", table, id);
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
