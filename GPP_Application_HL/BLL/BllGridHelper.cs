using System.Data;

namespace BLL
{
    public class BllGridHelper
    {
        public DataTable LayDMLoaiNV(string maLoainx, string loaict)
        {
            DAL.DalGridHelper dalGridHelper = new DAL.DalGridHelper();
            return dalGridHelper.LayDMLoaiNV(maLoainx, loaict);
        }
    }
}
