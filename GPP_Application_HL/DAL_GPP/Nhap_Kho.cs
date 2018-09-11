using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GPP_DATA;
namespace DAL_GPP
{
    public class Nhap_Kho
    {
        //Constructor 
        public Nhap_Kho()
        {
           KetNoiData.ConnectData();
        }
        public DataSet ConnectData(DateTime tu_ngay,DateTime den_ngay,object soid = null)
        {
            if (soid == null)
                soid = DBNull.Value;
            DataSet ds = new DataSet();
            string sql = "sp_kho_LayDuLieu_NhapKho_Xml";
            ds = KetNoiData.ExecuteToDataSet(sql, CommandType.StoredProcedure
                , "@soid", SqlDbType.Int, soid
                , "@tungay", SqlDbType.DateTime, tu_ngay
                , "@denngay", SqlDbType.DateTime, den_ngay);

            ds.Tables[0].TableName = "g";
            ds.Tables[1].TableName = "ct";

            //Relationship
            DataColumn[] parentColumns = { ds.Tables["g"].Columns["IDHDN"] };
            DataColumn[] childColumns = { ds.Tables["ct"].Columns["IDHDN"] };
            ds.Relations.Add("R_ct", parentColumns, childColumns);
            return ds;
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <returns></returns>
        public DataTable InsertData(object soid, object xml_g, object xml_ct, int rowcount_ct)
        {
            DataSet ds = KetNoiData.ExecuteToDataSet("sp_kho_Insert_NhapKho_Xml", CommandType.StoredProcedure
                                        , "@soid", SqlDbType.Int, soid
                                        , "@XmlData_g", SqlDbType.NVarChar, xml_g.ToString()
                                        , "@XmlData_ct", SqlDbType.NVarChar, xml_ct.ToString()
                                        , "@rowcount_g", SqlDbType.Int, 1
                                        , "@rowcount_ct", SqlDbType.Int, rowcount_ct
                                        );
            return ds.Tables[0];
        }

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <returns></returns>
        public DataTable UpdateData(object soid, object xml_g, object xml_ct)
        {
            DataSet ds = KetNoiData.ExecuteToDataSet("sp_kho_Update_NhapKho_Xml", CommandType.StoredProcedure
                                      , "@soid", SqlDbType.Int, soid
                                      , "@XmlData_g", SqlDbType.NVarChar, xml_g.ToString()
                                      , "@XmlData_ct", SqlDbType.NVarChar, xml_ct.ToString()
                                      );
            return ds.Tables[0];

        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <returns></returns>
        public DataTable DeleteData(object soid)
        {
            DataSet ds = KetNoiData.ExecuteToDataSet("sp_kho_Xoa_NhapKho_Xml", CommandType.StoredProcedure
                               , "@soid", SqlDbType.VarChar, soid
                               );
            return ds.Tables[0];
        }
    }
}
