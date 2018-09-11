using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_GPP.DanhMuc;

namespace BLL_GPP.DanhMuc
{
    public class BLL_DANHMUC_KH
    {
        DAL_DANHMUC_KH thuoc = new DAL_DANHMUC_KH();
        public bool Insert(DataRow rw)
        {
            return thuoc.InsertCommand(rw);
        }
        public bool Update(DataRow rw)
        {
            return thuoc.UpdateCommand(rw);
        }
        public bool Delete(int id)
        {
            return thuoc.DeleteCommand(id);
        }
    }
}
