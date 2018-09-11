using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPP_DungChung_HL
{
   public  class Function
    {
        public static void CreateXtraReportParameters(XtraReport xtraReport, params object[] parameters)
        {
            for (int i = 0; i < parameters.Length; i += 3)
            {
                string name = parameters[i].ToString();
                Type type = (Type)parameters[i + 1];
                object value = parameters[i + 2];
                if (xtraReport.Parameters[parameters[i].ToString()] == null)
                    xtraReport.Parameters.Add(new Parameter()
                    {
                        Name = name,
                        Type = type,
                        Value = value,
                        Visible = false
                    });
                else
                    xtraReport.Parameters[name].Value = value;
            }
        }

    }
}
