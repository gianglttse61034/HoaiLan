using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL_HeThong;
using GPP_DungChung_HL;
using BLL_GPP.Report;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Columns;
using BLL_GPP.DanhMuc;
namespace GPP_Application_HL
{

    public partial class UCReport_BaoCaoThuocCanDate : DevExpress.XtraEditors.XtraUserControl, IReport
    {
        #region  Khai báo biến toàn cục
        BLL_BaoCao BC = new BLL_BaoCao();
        private DataTable dt;
        private BLL_DanhMuc dm;
        #endregion
        public UCReport_BaoCaoThuocCanDate()
        {
            InitializeComponent();
            dm = new BLL_DanhMuc();
        }
        private void LoadLayout()
        {
            gridViewCT.Columns.Clear();
            GridHelper.FormatGrid(gridViewCT,
            "TENTHUOC", "THUỐC", 100, "", true,
            "TENDVT", "ĐVT", 100, "", true,
            "SOLO", "Số lô", 100, "", true,
            "TonKho", "TỒN KHO", 100, GridHelper.TextEdit_Mod, true, GridHelper.Numberic, 50, "N0",
            "HANSUDUNG", "Hạn Sử Dụng", 100, GridHelper.TextEdit_Mod, true, GridHelper.DateTimeMOD, 50, "Ola",
            "DONGIABAN", "Đơn giá bán", 100, GridHelper.TextEdit_Mod, true, GridHelper.Numberic, 50, "N2"
            );
            foreach (GridColumn col in gridViewCT.Columns)
            {
                if (col.FieldName == "TENTHUOC")
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
                else
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            }


        }
        #region IReport
        void IReport.ExportExcel()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx";
            save.FileName = "Báo cáo thuốc cận date";
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (save.FilterIndex == 1)
                {
                    gridControl_CT.ExportToXls(save.FileName);
                    System.Diagnostics.Process.Start(save.FileName);
                }

                else if (save.FilterIndex == 2)
                {
                    gridControl_CT.ExportToXlsx(save.FileName);
                    System.Diagnostics.Process.Start(save.FileName);
                }

            }
        }
        void IReport.Preview()
        {
            DataTable dt_X = ((DataView)gridViewCT.DataSource).ToTable();
            string strReport = "\\Report\\RptBaoCaoThuocCanDate.repx";
            XtraReport xtra_report = new XtraReport();
            xtra_report.Parameters.Clear();
            string file = Application.StartupPath + strReport;
            xtra_report.LoadLayout(file);
            xtra_report.DataSource = dt_X;
            GPP_DungChung_HL.Form.FrmXtraReportViewer rpt = new GPP_DungChung_HL.Form.FrmXtraReportViewer(xtra_report);
            rpt.ShowDialog();
        }
        string IReport.Title()
        {
            return "Báo Cáo Thuốc Cận Date";
        }
        void IReport.RefeshData(DateTime tuNgay, DateTime denNgay)
        {

        }
        void IReport.RefeshData()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += delegate { dt = BC.ConnectData_BaoCaoThuocCanDate(3); };
            bw.RunWorkerCompleted += delegate
            {
                gridControl_CT.DataSource = dt;
                LoadLayout();
            };
            bw.RunWorkerAsync();
            bw.Dispose();
        }
        void IReport.ShowDetail()
        {
            //throw new NotImplementedException();
        }
        void IReport.Exit()
        {
            if (dt != null)
                dt.Dispose();
            FindForm().Close();
        }
        // Khi khởi tạo.
        void IReport.Load()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += delegate { dt = BC.ConnectData_BaoCaoThuocCanDate(3); };
            bw.RunWorkerCompleted += delegate
            {
                gridControl_CT.DataSource = dt;
                LoadLayout();
            };
            bw.RunWorkerAsync();
            bw.Dispose();
        }
        #endregion

    }
}
