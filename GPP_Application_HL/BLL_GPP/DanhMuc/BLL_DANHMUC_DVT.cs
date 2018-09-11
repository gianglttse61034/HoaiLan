using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_GPP.DanhMuc;

namespace BLL_GPP.DanhMuc
{
    public class BLL_DANHMUC_DVT
    {
        DAL_DANHMUC_DVT dvt = new DAL_DANHMUC_DVT();
        public bool Insert(DataRow rw)
        {
            return dvt.InsertCommand(rw);
        }
        public bool Update(DataRow rw)
        {
            return dvt.UpdateCommand(rw);
        }
        public bool Delete(int id)
        {
            return dvt.DeleteCommand(id);
        }
    }
}
