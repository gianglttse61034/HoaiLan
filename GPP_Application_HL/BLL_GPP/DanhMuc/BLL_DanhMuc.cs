using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GPP_DATA;
namespace BLL_GPP.DanhMuc
{
    public class BLL_DanhMuc
    {
        #region Khai báo biến toàn cục
        GPP_DATA.KetNoiData data = new GPP_DATA.KetNoiData();
        #endregion
        public DataTable DanhMuc_Thuoc()
        {
            string str_sql = "Select * from THUOC order by TENTHUOC";
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(str_sql);
        }
        public DataTable DanhMuc_VTYT()
        {
            string str_sql = "Select * from VTYT";
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(str_sql);
        }
        public DataTable DanhMuc_NSX()
        {
            string str_sql = "Select * from NSX";
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(str_sql);
        }
        public DataTable DanhMuc_NCC()
        {
            string str_sql = "Select * from NCC";
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(str_sql);
        }
        public DataTable DanhMuc_LOAITHUOC()
        {
            string str_sql = "Select * from LOAITHUOC";
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(str_sql);
        }
        public DataTable DanhMuc_LOAISP()
        {
            string str_sql = "Select * from LOAISP";
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(str_sql);
        }
        public DataTable DanhMuc_HOATCHAT()
        {
            string str_sql = "Select * from HOATCHAT";
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(str_sql);
        }
        public DataTable DanhMuc_KHACHHANG()
        {
            string str_sql = "Select * from KHACHHANG";
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(str_sql);
        }
        public DataTable DanhMuc_DVT()
        {
            string str_sql = "Select * from DVT";
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(str_sql);
        }
        public DataTable DanhMuc_DUOCSI()
        {
            string str_sql = "Select * from DUOCSI";
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(str_sql);
        }
        public DataTable DanhMuc_CTHCTHUOC()
        {
            string str_sql = "Select * from CTHC_THUOC";
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(str_sql);
        }
        public DataTable DanhMuc_BENH()
        {
            string str_sql = "Select * from BENH";
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(str_sql);
        }
        public DataTable DanhMuc_BACSI()
        {
            string str_sql = "Select * from BACSI";
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(str_sql);
        }
        public DataTable DanhMuc_LyDo()
        {
            string str_sql = "Select * from lydo";
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(str_sql);
        }
        public DataTable DanhMuc_TOPID(string key, string table)
        {
            string sql = string.Format("Select top 1 {0} as maxid from {1} order by {0} desc",key,table);
            KetNoiData.ConnectData();
            return KetNoiData.ExecuteToDataTable(sql);
        }
        public DataTable LaySoTon(object id)
        {
            string store = string.Format("sp_kho_LayTon_SoLo_Xml");
            KetNoiData.ConnectData();

            return KetNoiData.ExecuteToDataSet(store, CommandType.StoredProcedure, "@idThuoc", SqlDbType.Int, id).Tables[0];
        }
        /// <summary>
        ///  đếm từ 1.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public int LaySoMaxHD(string table)
        {
            string sql = string.Format("select  count(*) as maxid from {0} where Year(NGAYXUAT) = Year(GETDATE()) and Month(NGAYXUAT) = MONTH(GETDATE())",table);
            KetNoiData.ConnectData();
            DataTable dt = KetNoiData.ExecuteToDataTable(sql);
            return Convert.ToInt32(dt.Rows[0]["maxid"]);
        }
        
    }
}
