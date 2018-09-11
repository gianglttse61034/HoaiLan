using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GPP_DATA;
using System.Windows.Forms;
using System.ComponentModel;

namespace GPP_DungChung_HL
{
    public  class Lookup
    {

            public static DataRow LookupDM_Thuoc(object id)
            {
            string sql = string.Format(@"select * from THUOC where IDTHUOC = {0} ", Convert.ToInt32(id));
            DataTable dt = KetNoiData.ExecuteToDataTable(sql);
            //đã có đữ liệu
            if (dt.Rows.Count == 1)
                return dt.Rows[0];

             sql = "select 1 as ischanged, * from THUOC  order by TENTHUOC";
             dt = KetNoiData.ExecuteToDataTable(sql);
             List<object> arrColumn = new List<object>();
             arrColumn.AddRange(new object[] {
            "IDTHUOC", "IDTHUOC", 100, "", false,
            "MATHUOC", "Mã Thuốc", 100, "",true,
            "TENTHUOC", "Tên Thuốc", 100, "",true
            });
                GPP_DungChung_HL.Form.FrmLookupData frm = new GPP_DungChung_HL.Form.FrmLookupData("Danh mục Thuốc", dt, arrColumn
                    , string.Format("Contains([IDTHUOC], '{0}')", Convert.ToInt32(id)));
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    return frm.RowResult;
                }
            return null;
        }
    }
}
