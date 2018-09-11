using System;
using System.Data;

namespace BLL
{
    public class MD
    {
        public static LoaiNV Loainv = new LoaiNV();
    }
    public class LoaiNV
    {
        readonly DataTable m_DtLoaiNV;
        public NV HANG;
        public NV VAT;
        public NV NK;
        public NV VC;
        public NV KM;
        public NV CK;
        public NV TT;//Thu tiền
        public NV CT;//Chi tiền
        public NV BH;//Bảo hiểm
        public LoaiNV()
        {
            m_DtLoaiNV = new DataTable();
            m_DtLoaiNV.Columns.AddRange(new DataColumn[] {
                    new DataColumn("ma_loainv",typeof(String)),
                    new DataColumn("ten_loainv",typeof(String))
                });
            m_DtLoaiNV.PrimaryKey = new DataColumn[] { m_DtLoaiNV.Columns["ma_loainv"] };
            //Hàng hóa
            HANG = new NV("HANG", "Hàng hóa");
            AddLoaiNV(HANG);
            //THUE NHẬP KHẨU
            NK = new NV("THUENK", "Thuế NK");
            AddLoaiNV(NK);
            //VAT
            VAT = new NV("THUEGTGT", "Thuế GTGT");
            AddLoaiNV(VAT);
            //Van chuyen
            VC = new NV("PHIVC", "Vận chuyển");
            AddLoaiNV(VC);
            //Khuyến mãi
            KM = new NV("KMHH", "Khuyến mãi");
            AddLoaiNV(KM);
            //Chiết khấu
            CK = new NV("CK", "Chiết khấu bán hàng");
            AddLoaiNV(CK);
            //Thu tiền
            TT = new NV("TT", "Thu tiền");
            AddLoaiNV(TT);
            //Chung tiền
            CT = new NV("CT", "Thu tiền");
            AddLoaiNV(CT);
            //Bảo hiểm
            BH = new NV("PHIBH", "Phí bảo hiểm");
            AddLoaiNV(BH);
        }
        private void AddLoaiNV(NV nv)
        {
            DataRow row = m_DtLoaiNV.NewRow();
            row["ma_loainv"] = nv.MaLoainv;
            row["ten_loainv"] = nv.TenLoainv;
            m_DtLoaiNV.Rows.Add(row);
        }
        public string GetTenLoaiNV(String maLoainv)
        {
            DataRow rowFind = m_DtLoaiNV.Rows.Find(maLoainv);
            return rowFind != null ? rowFind["ten_loainv"].ToString() : "";
        }
        public string GetTenLoaiNV(String maLoainv, DataTable dtLnv)
        {
            DataRow rowFind = dtLnv.Rows.Find(maLoainv);
            return rowFind != null ? rowFind["ten_loainv"].ToString() : "";
        }
        public string GetTKNOLoaiNV(String maLoainv, DataTable dtLnv)
        {
            DataRow rowFind = dtLnv.Rows.Find(maLoainv);
            return rowFind != null ? rowFind["tkno"].ToString() : "";
        }
        public string GetTKCOLoaiNV(String maLoainv, DataTable dtLnv)
        {
            DataRow rowFind = dtLnv.Rows.Find(maLoainv);
            return rowFind != null ? rowFind["tkco"].ToString() : "";
        }
        //public string GetLoaiNVMacDinh(String maLoaiNX, DataTable dtLnv)
        //{
        //    DataRow rowFind = dtLnv.Rows.Find();
        //    return rowFind != null ? rowFind["tkco"].ToString() : "";
        //}
        public string GetTKThueLoaiNV(String maLoainv, DataTable dtLnv)
        {
            DataRow rowFind = dtLnv.Rows.Find(maLoainv);
            return rowFind != null ? rowFind["tkthue"].ToString() : "";
        }
        public DataTable BangLoaiNV
        {
            get
            {
                return m_DtLoaiNV;
            }
        }
    }
    public class NV
    {
        public string MaLoainv;
        public string TenLoainv;
        const int LEN = 10;
        public NV(string maLoainv, string tenLoainv)
        {
            MaLoainv = maLoainv.PadRight(LEN, ' ');
            TenLoainv = tenLoainv;
        }
    }
    public class ChungTu
    {
        #region Tạo khoá tự động (KeyGenerator)
        /// <summary>
        /// Tạo khoá tự động
        /// Trần Văn Tài
        /// </summary>
        /// <param name="loaict"></param>
        /// <param name="ngayct">Ngày chứng từ</param>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="master"></param>
        /// <returns>Khóa mới</returns>
        public static String KeyGenerator(String loaict, DateTime ngayct, DateTime tuNgay, DateTime denNgay, String master)
        {
            String maNV = LayMaNghiepVu(loaict);
            return KeyGenerator(maNV, loaict, ngayct, tuNgay, denNgay, master);
        }
        /// <summary>
        /// Tạo khoá tự động
        /// Trần Văn Tài
        /// </summary>
        /// <param name="loaict"></param>
        /// <param name="ngayct">Ngày chứng từ</param>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="master"></param>
        /// <returns>Khóa mới</returns>
        public static String[] KeyGenerators(String loaict, DateTime ngayct, DateTime tuNgay, DateTime denNgay, String master)
        {
            String maNV = LayMaNghiepVu(loaict);
            String[] arr = maNV.Split(',');
            String[] results = new string[arr.Length == 0 ? 1 : arr.Length];
            if (arr.Length == 0)
                results[0] = KeyGenerator("", loaict, ngayct, tuNgay, denNgay, master);
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    results[i] = KeyGenerator(arr[i], loaict, ngayct, tuNgay, denNgay, master);
                }
            }
            return results;
        }
        /// <summary>
        /// Tạo khoá tự động
        /// Trần Văn Tài
        /// </summary>
        /// <param name="loaict"></param>
        /// <param name="ngayct">Ngày chứng từ</param>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="master"></param>
        /// <returns>Khóa mới</returns>
        public static String KeyGenerator(String maNV, String loaict, DateTime ngayct, DateTime tuNgay, DateTime denNgay, String master)
        {
            string ret = "";
            const int len = 3;
            int stt = 0;
            //ko sử dụng tham số này cho 2/9
            maNV = "";
            //----
            if (ngayct.CompareTo(tuNgay) < 0 || ngayct.CompareTo(denNgay) > 0) return "";
            String sql;
            if (String.IsNullOrEmpty(maNV))
            {
                sql = "SELECT soct FROM " + master +
                    " WHERE MONTH(ngayct) = @thang AND YEAR(ngayct) = @nam " +
                    " ORDER BY soct DESC";
            }
            else
            {
                sql = "SELECT soct FROM " + master +
                    " WHERE MONTH(ngayct) = @thang AND YEAR(ngayct) = @nam and left(soct,len(@maNV)) = @maNV " +
                    " ORDER BY soct DESC";
            }
            DataTable dt = BllLib.ExecuteDataTable(sql, CommandType.Text,
                "@thang", SqlDbType.Int, ngayct.Month,
                "@nam", SqlDbType.Int, ngayct.Year,
                "@maNV", SqlDbType.NChar, maNV);
            if (dt.Rows.Count > 0)//Đã tồn tại phiếu
            {
                try
                {
                    int i = 0;

                    while (stt <= 0)
                    {
                        String soct = dt.Rows[i++]["soct"].ToString().Trim();
                        //Int32.TryParse(soct.Substring(String.IsNullOrEmpty(maNV) ? 0 : maNV.Length, len), out stt);
                        Int32.TryParse(soct.Substring(soct.Length - len, len), out stt);
                    }
                    stt++;
                }
                catch
                {
                    stt = 1;
                }
            }
            else //Khởi tạo phiếu đầu tiên
            {
                stt = 1;
            }
            for (int i = 0; i < len - stt.ToString().Length; i++)
            {
                ret += "0";
            }
            //return maNV + ret + stt + "/" + ngayct.ToString("yyMM");
            return string.Format("{0}/{1}", ngayct.ToString("yyMM"), stt.ToString().PadLeft(3, '0'));
        }


        /// <summary>
        /// Tạo khoá tự động
        /// Trần Văn Tài
        /// </summary>
        /// <param name="loaict"></param>
        /// <param name="ngayct">Ngày chứng từ</param>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="master"></param>
        /// <returns>Khóa mới</returns>
        public static String KeyGenerator(String loaict, DateTime ngayct, DateTime tuNgay, DateTime denNgay, String master, string n_loaict)
        {
            String maNV = LayMaNghiepVu(loaict);
            return KeyGenerator(maNV, loaict, ngayct, tuNgay, denNgay, master, n_loaict);
        }
        /// <summary>
        /// Tạo khoá tự động
        /// Trần Văn Tài
        /// </summary>
        /// <param name="loaict"></param>
        /// <param name="ngayct">Ngày chứng từ</param>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="master"></param>
        /// <returns>Khóa mới</returns>
        public static String[] KeyGenerators(String loaict, DateTime ngayct, DateTime tuNgay, DateTime denNgay, String master, string n_loaict)
        {
            String maNV = LayMaNghiepVu(loaict);
            String[] arr = maNV.Split(',');
            String[] results = new string[arr.Length == 0 ? 1 : arr.Length];
            if (arr.Length == 0)
                results[0] = KeyGenerator("", loaict, ngayct, tuNgay, denNgay, master, n_loaict);
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    results[i] = KeyGenerator(arr[i], loaict, ngayct, tuNgay, denNgay, master, n_loaict);
                }
            }
            return results;
        }
        /// <summary>
        /// Tạo khoá tự động
        /// Trần Văn Tài
        /// </summary>
        /// <param name="loaict"></param>
        /// <param name="ngayct">Ngày chứng từ</param>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="master"></param>
        /// <returns>Khóa mới</returns>
        public static String KeyGenerator(String maNV, String loaict, DateTime ngayct, DateTime tuNgay, DateTime denNgay, String master, string n_loaict)
        {
            string ret = "";
            const int len = 3;
            int stt = 0;
            //ko sử dụng tham số này cho 2/9
            maNV = "";
            //----
            if (ngayct.CompareTo(tuNgay) < 0 || ngayct.CompareTo(denNgay) > 0) return "";
            String sql;
            if (String.IsNullOrEmpty(maNV))
            {
                sql = "SELECT soct FROM " + master +
                    " WHERE MONTH(ngayct) = @thang AND YEAR(ngayct) = @nam and loaict = @loaict" +
                    " ORDER BY soct DESC";
            }
            else
            {
                sql = "SELECT soct FROM " + master +
                    " WHERE MONTH(ngayct) = @thang AND YEAR(ngayct) = @nam and loaict = @loaict and left(soct,len(@maNV)) = @maNV " +
                    " ORDER BY soct DESC";
            }
            DataTable dt = BllLib.ExecuteDataTable(sql, CommandType.Text,
                "@thang", SqlDbType.Int, ngayct.Month,
                "@nam", SqlDbType.Int, ngayct.Year,
                "@maNV", SqlDbType.NChar, maNV,
                "@loaict", SqlDbType.NChar, loaict);
            if (dt.Rows.Count > 0)//Đã tồn tại phiếu
            {
                try
                {
                    int i = 0;

                    while (stt <= 0)
                    {
                        String soct = dt.Rows[i++]["soct"].ToString().Trim();
                        //Int32.TryParse(soct.Substring(String.IsNullOrEmpty(maNV) ? 0 : maNV.Length, len), out stt);
                        Int32.TryParse(soct.Substring(soct.Length - len, len), out stt);
                    }
                    stt++;
                }
                catch
                {
                    stt = 1;
                }
            }
            else //Khởi tạo phiếu đầu tiên
            {
                stt = 1;
            }
            for (int i = 0; i < len - stt.ToString().Length; i++)
            {
                ret += "0";
            }
            //return maNV + ret + stt + "/" + ngayct.ToString("yyMM");
            return string.Format("{0}/{1}", ngayct.ToString("yyMM"), stt.ToString().PadLeft(3, '0'));
        }
        #endregion Tạo khoá tự động (KeyGenerator)

        public static String LayMaNghiepVu(String loaict)
        {
            String sql = "Select * from dm_ct where loaict = @loaict";
            DataTable dt = BllLib.ExecuteDataTable(sql, CommandType.Text,
                "@loaict", SqlDbType.NChar, loaict);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ma_nv"] == null ? "" : dt.Rows[0]["ma_nv"].ToString();
            }
            return "";
        }

        #region loại chứng từ

        public const string Phieu_thu_chuyen_khoan = "BCNH";
        public const string Phieu_chi_chuyen_khoan = "BNNH";
        public const string Chung_tu_ghi_so_tong_hop = "CTGS";
        public const string Di_chuyen_noi_bo_hang_hoa = "DCHH";
        public const string Di_chuyen_noi_bo_ngoai_bang = "DCNB";
        public const string Di_chuyen_noi_bo_nguyen_lieu = "DCNL";
        public const string Di_chuyen_noi_bo_thanh_pham = "DCTP";
        public const string Di_chuyen_noi_bo_vat_lieu = "DCVL";
        public const string Dieu_dong_cong_cu = "DDCC";
        public const string Dieu_dong_tai_san = "DDTS";
        public const string Don_mua_hang = "DMH ";
        public const string Hoa_don_dich_vu = "HDDV";
        public const string Hoa_don_hang_hoa = "HDHH";
        public const string Lenh_dong_goi = "LDG ";
        public const string Lenh_pha_che_nguyen_lieu = "LPC ";
        public const string Phieu_chi_tien_mat = "PCTM";
        public const string Phieu_kiem_nghiem = "PKN ";
        public const string Phieu_lay_mau_kiem_nghiem = "PLM ";
        public const string Phieu_nhap_bao_bi = "PNBB";
        public const string Phieu_nhap_gia_cong = "PNGC";
        public const string Phieu_nhap_hang_hoa = "PNHH";
        public const string Phieu_nhap_ngoai_bang = "PNNB";
        public const string Phieu_nhap_nguyen_lieu = "PNNL";
        public const string Phieu_nhap_thanh_pham = "PNTP";
        public const string Phieu_nhap_tai_san = "PNTS";
        public const string Phieu_nhap_vat_lieu = "PNVL";
        public const string Phieu_nhap_vat_tu = "PNVT";
        public const string Phieu_nhap_phu_tung = "NPHT";
        public const string Phieu_nhap_nhien_lieu = "NNHL";
        public const string Phieu_nhap_cong_cu = "NCDC";
        public const string Phieu_thu_tien_mat = "PTTM";
        public const string Phieu_xuat_bao_bi = "PXBB";
        public const string Phieu_xuat_gia_cong = "PXGC";
        public const string Phieu_xuat_hang_hoa = "PXHH";
        public const string Phieu_xuat_ngoai_bang = "PXNB";
        public const string Phieu_xuat_nguyen_lieu = "PXNL";
        public const string Phieu_xuat_thanh_pham = "PXTP";
        public const string Phieu_xuat_tai_san = "PXTS";
        public const string Phieu_xuat_vat_lieu = "PXVL";
        public const string Phieu_xuat_vat_tu = "PXVT";
        public const string Phieu_xuat_phu_tung = "XPHT";
        public const string Phieu_xuat_nhien_lieu = "XNHL";
        public const string Phieu_xuat_cong_cu = "XCDC";
        public const string Tiep_nhan_bao_bi = "TNBB";
        public const string Tiep_nhan_nguyen_lieu = "TNNL";
        public const string Tiep_nhan_thanh_pham = "TNTP";
        public const string Tiep_nhan_vat_lieu = "TNVL";
        public const string Tra_vay_dai_han = "TVDH";
        public const string Tra_vay_ngan_han = "TVNH";
        public const string Vay_dai_han = "VDH ";
        public const string Vay_ngan_han = "VNH ";
        public const string Xuat_tiep_nhan_bao_bi = "XTNBB";
        public const string Xuat_tiep_nhan_nguyen_lieu = "XTNNL";
        public const string Xuat_tiep_nhan_vat_lieu = "XTNVL";
        public const string Yeu_cau_mua_hang = "YCMH";


        #endregion

    }
}
