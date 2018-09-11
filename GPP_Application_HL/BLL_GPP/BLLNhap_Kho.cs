using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_GPP;
using System.Data;

namespace BLL_GPP
{
    public class BLLNhap_Kho
    {
        #region Khởi tạo biến toàn cục
        Nhap_Kho nk = new Nhap_Kho();
        #endregion
        public DataSet ConnectData(DateTime tu_ngay,DateTime den_ngay,object soid = null)
        {
           return nk.ConnectData(tu_ngay,den_ngay,soid);
        }

        public DataTable InsertData(object soid, object xml_g, object xml_ct, int rowcount_ct)
        {
            return nk.InsertData(soid,xml_g,xml_ct,rowcount_ct);
        }

        public DataTable UpdateData(object soid, object xml_g, object xml_ct)
        {
            return nk.UpdateData(soid,xml_g,xml_ct);
        }

        public DataTable DeleteData(object soid)
        {
            return nk.DeleteData(soid);
        }
    }
}
