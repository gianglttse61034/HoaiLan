using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL_GPP
{
    public class BLL_TimKiem
    {
        private DAL_GPP.DAL_TimKiem dal = new DAL_GPP.DAL_TimKiem();
        public DataSet ConnectData_TheoSolo(string solo)
        {
            return dal.ConnectData(solo, 1);
        }
        public DataSet ConnectData_TheoID(int idthuoc)
        {
            return dal.ConnectData(idthuoc.ToString(), 0);
        }
    }
}
