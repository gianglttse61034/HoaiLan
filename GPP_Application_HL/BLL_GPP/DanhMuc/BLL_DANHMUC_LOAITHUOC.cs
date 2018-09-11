using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_GPP.DanhMuc;

namespace BLL_GPP.DanhMuc
{
    public class BLL_DANHMUC_LOAITHUOC
    {
        DAL_DANHMUC_LOAITHUOC LOAITHUOC = new DAL_DANHMUC_LOAITHUOC();
        public bool Insert(DataRow rw)
        {
            return LOAITHUOC.InsertCommand(rw);
        }
        public bool Update(DataRow rw)
        {
            return LOAITHUOC.UpdateCommand(rw);
        }
        public bool Delete(int id)
        {
            return LOAITHUOC.DeleteCommand(id);
        }
    }
}
