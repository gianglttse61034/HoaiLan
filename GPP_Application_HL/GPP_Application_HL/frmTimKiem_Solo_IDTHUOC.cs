using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GPP_DungChung_HL;
using BLL_GPP.DanhMuc;
using DevExpress.XtraEditors.Controls;

namespace GPP_Application_HL
{
    public partial class frmTimKiem_Solo_IDTHUOC : DevExpress.XtraEditors.XtraForm
    {
        private BLL_GPP.BLL_TimKiem tk;
        private BLL_DanhMuc dm;
        private DataSet ds;
        private DataTable dt_Thuoc, dt_NCC,dt_khachhang,dt_NSX, dt_LyDo;
        public frmTimKiem_Solo_IDTHUOC()
        {
            InitializeComponent();
            tk = new BLL_GPP.BLL_TimKiem();
            dm = new BLL_DanhMuc();
        }
        private void radTheoThuoc_CheckedChanged(object sender, EventArgs e)
        {
            lkpTHUOC.Visible = true;
            txtThongTin.Visible = false;
            lkpTHUOC.Enabled = true;
            txtThongTin.Enabled = false;
        }
        private void radTheoSoLo_CheckedChanged(object sender, EventArgs e)
        {
            lkpTHUOC.Visible = false;
            txtThongTin.Visible = true;
            lkpTHUOC.Enabled = false;
            txtThongTin.Enabled = true;
        }
        private void txtThongTin_EditValueChanged(object sender, EventArgs e)
        {
           
        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            if (radTheoSoLo.Checked == true)
            {
                bw.DoWork += delegate { ds = tk.ConnectData_TheoSolo(txtThongTin.EditValue.ToString()); };
                bw.RunWorkerCompleted += delegate
                {
                    BindData();
                    LoadLayout();
                };
                bw.RunWorkerAsync();
                bw.Dispose();
            }
            else
                if (radTheoThuoc.Checked == true)
            {
                bw.DoWork += delegate { ds = tk.ConnectData_TheoID(Convert.ToInt32(lkpTHUOC.EditValue)); };
                bw.RunWorkerCompleted += delegate
                {
                    BindData();
                    LoadLayout();
                };
                bw.RunWorkerAsync();
                bw.Dispose();
            }

        }
        public void BindData()
        {
            gridControl_G.DataSource = ds;
            gridControl_G.DataMember = "g";
            gridControl_CT.DataSource = ds;
            gridControl_CT.DataMember = "g.R_ct";
        }
        public void LoadLayout()
        {
           
            gridView_CT.Columns.Clear();
            gridView_G.Columns.Clear();
            GridHelper.FormatGrid(gridView_G,
            "SOLO", "Số lô", 100, "", true,
            "IDTHUOC", "THUỐC", 150, GridHelper.LookupEDIT, true, dt_Thuoc, "TENTHUOC", "IDTHUOC",
            "TENHOADON", "Hóa đơn nhập", 200, "", true,
            "soluongnhap", "SL Nhập", 100,GridHelper.TextEdit_Mod, true, GridHelper.Numberic, 50, "N0",
            "HANSUDUNG", "Hạn sử dụng", 100, GridHelper.TextEdit_Mod, true, GridHelper.DateTimeMOD, 50, "Ola",
            "NGAYNHAP", "NGÀY NHẬP", 100, GridHelper.TextEdit_Mod, true, GridHelper.DateTimeMOD , 50, "Ola",
            "IDNCC", "Tên NCC ", 100, GridHelper.LookupEDIT, true, dt_NCC, "TENNCC", "IDNCC",
            "IDNCC", "Địa chỉ NCC ", 100, GridHelper.LookupEDIT, true, dt_NCC, "DIACHINCC", "IDNCC",
            "IDNCC", "Điện thoại NCC ", 100, GridHelper.LookupEDIT, true, dt_NCC, "DIENTHOAINCC", "IDNCC"
            );

            GridHelper.FormatGrid(gridView_CT,
            "TENHDX", "Hóa đơn xuất", 100, "", true,
            "IDKHACHHANG", "Mã Khách Hàng", 100, GridHelper.LookupEDIT, true, dt_khachhang, "MAKHACHHANG", "IDKHACHHANG",
            "IDKHACHHANG", "Tên Khách Hàng", 150, GridHelper.LookupEDIT, true, dt_khachhang, "TENKH", "IDKHACHHANG",
            "soluongxuat", "SL Xuất", 100, GridHelper.TextEdit_Mod, true, GridHelper.Numberic, 50, "N0",
            "NGAYXUAT", "Ngày xuất", 100, GridHelper.TextEdit_Mod, true, GridHelper.DateTimeMOD, 50, "Ola",
            "IDKHACHHANG", "Điện thoại", 100, GridHelper.LookupEDIT, true, dt_khachhang, "DIENTHOAIKH", "IDKHACHHANG",
            "IDKHACHHANG", "Địa chỉ KH", 100, GridHelper.LookupEDIT, true, dt_khachhang, "DIACHIKH", "IDKHACHHANG",
           
            "NGAYLAP", "Ngày lập", 100, GridHelper.TextEdit_Mod, true, GridHelper.DateTimeMOD, 50, "Ola",
            
            "Lydoxuat", "Lý do xuất", 100, GridHelper.LookupEDIT, true, dt_LyDo, "Lydo", "Idlydo");
        }
        private void frmTimKiem_Solo_IDTHUOC_Load(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += delegate { dt_Thuoc = dm.DanhMuc_Thuoc(); };
            bw.DoWork += delegate { dt_NCC = dm.DanhMuc_NCC(); };
            bw.DoWork += delegate { dt_khachhang = dm.DanhMuc_KHACHHANG(); };
            bw.DoWork += delegate { dt_NSX = dm.DanhMuc_NSX(); };
            bw.DoWork += delegate { dt_LyDo = dm.DanhMuc_LyDo(); };
            bw.RunWorkerCompleted += delegate
            {
                lkpTHUOC.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("TENTHUOC", 250, "Tên")
                    });
                lkpTHUOC.Properties.DisplayMember = "TENTHUOC";
                lkpTHUOC.Properties.ValueMember = "IDTHUOC";
                lkpTHUOC.Properties.NullText = "";
                lkpTHUOC.Properties.ShowHeader = false;
                lkpTHUOC.Properties.DataSource = dt_Thuoc;
                lkpTHUOC.Enabled = false;
                radTheoSoLo.Checked = true;
            };
            bw.RunWorkerAsync();
            bw.Dispose();

        }
    }
}