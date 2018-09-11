using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL_GPP.Report;
using System.Data;

namespace BLL_GPP.Report
{
    public class BLL_BaoCao
    {
        DAL_BaoCao BC = new DAL_BaoCao();
        public DataTable ConnectData_BaoCaoThuocCanDate(int soThang)
        {
            return BC.ConnectDATA_BaoCaoThuoc_CanDate(soThang);
        }
        public DataTable ConnectData_BaoCaoDonGiaThuoc()
        {
            return BC.ConnectDATA_BaoCaoThuoc_DonGiaThuoc();
        }
    }
}
