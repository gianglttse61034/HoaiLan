using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_GPP;
using System.Data;

namespace BLL_GPP
{
   public class BLLXuat_Kho
    {
        #region Khởi tạo biến toàn cục
        Xuat_Kho xk = new Xuat_Kho() ;
        #endregion

        public DataSet ConnectData(DateTime tu_ngay, DateTime den_ngay, object soid = null)
        {
            return xk.ConnectData(tu_ngay, den_ngay, soid);
        }

        public DataTable InsertData(object soid, object xml_g, object xml_ct, int rowcount_ct)
        {
            return xk.InsertData(soid, xml_g, xml_ct, rowcount_ct);
        }

        public DataTable UpdateData(object soid, object xml_g, object xml_ct)
        {
            return xk.UpdateData(soid, xml_g, xml_ct);
        }

        public DataTable DeleteData(object soid)
        {
            return xk.DeleteData(soid);
        }

    }
}
