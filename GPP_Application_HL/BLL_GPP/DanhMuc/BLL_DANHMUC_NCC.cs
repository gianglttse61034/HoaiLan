using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_GPP.DanhMuc;
using System.Data;

namespace BLL_GPP.DanhMuc
{
    public class BLL_DANHMUC_NCC
    {
        DAL_DANHMUC_NCC thuoc = new DAL_DANHMUC_NCC();
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
