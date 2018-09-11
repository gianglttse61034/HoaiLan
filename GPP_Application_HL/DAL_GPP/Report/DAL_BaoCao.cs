using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GPP_DATA;

namespace DAL_GPP.Report
{
    public class DAL_BaoCao
    {
        public DataTable ConnectDATA_BaoCaoThuoc_CanDate(int soThang)
        {
            string str = "sp_kho_BaoCaoTon_TheoThuoc_SoLo_Xml";

            try
            {
                DataTable dt = KetNoiData.ExecuteToDataTable(str, CommandType.StoredProcedure,
                "@soMonth", SqlDbType.Int, soThang);
                return dt;
            }
            catch (Exception e)
            {

                throw e;
            }
                
            
        }
        public DataTable ConnectDATA_BaoCaoThuoc_DonGiaThuoc()
        {
            string str = @"
                -- lấy đơn giá
                SELECT DISTINCT TENTHUOC,MAX(CT.DONGIABAN) AS DONGIA 
                FROM HOADONNHAP G 
                INNER JOIN CTHDNHAP_THUOC CT ON CT.IDHDN = G.IDHDN 
                INNER JOIN  THUOC TH ON TH.IDTHUOC = CT.IDTHUOC
                GROUP BY CT.IDTHUOC,TENTHUOC
                ORDER BY TENTHUOC
                 ";

            try
            {
                DataTable dt = KetNoiData.ExecuteToDataTable(str, CommandType.Text);
                return dt;
            }
            catch (Exception e)
            {

                throw e;
            }


        }
    }
}
