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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;


namespace GPP_DungChung_HL.Form
{
    public partial class FrmLookupData : DevExpress.XtraEditors.XtraForm
    {
        #region Khai báo biến toàn cục
        private DataTable m_DtResult;
        //kết quả chọn trên form lookup
        private DataRow m_RowResult;
        private GridHelper helpGrid = new GridHelper();
        #endregion
        public FrmLookupData()
        {
            InitializeComponent();
        }

        private void barLayDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LayDuLieu();
        }

        private void barThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            m_DtResult.Dispose();
            Close();
        }

        public DataRow RowResult
        {
            get { return m_RowResult; }
            set { m_RowResult = value; }
        }

        //khởi tạo
        public FrmLookupData(string title, DataTable Dt, List<object> arrColumn, string filter = "", int width = 600, int height = 500)
        {
            InitializeComponent();
            Size = new Size(width, height);
            gridControl_Data.Text = title;
            this.Text = title;
            //đưa dữ liệu lên lưới
            m_DtResult = Dt;
            gridControl_Data.DataSource = Dt;
            //Định dạng và hiện các cột
            GridHelper.FormatGrid(gridView1,arrColumn.ToArray());
            gridView1.Focus();
            //filter
            if (filter != "") gridView1.ActiveFilterString = filter;
            //nếu filter ko có đữ liệu thì hiển thị tất cả
            if (gridView1.RowCount == 0) gridView1.ActiveFilterString = string.Empty;
        }

        private void FrmLookupData_KeyDown(object sender, KeyEventArgs e)
        {
            //Escape
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                m_DtResult.Dispose();
                Close();
            }
            else if (e.KeyCode == Keys.F3)
            {
                gridView1.FocusedRowHandle = GridControl.AutoFilterRowHandle;
                gridView1.GridControl.BeginInvoke(new MethodInvoker(gridView1.ShowEditor));
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (gridView1.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                    LayDuLieu();
            }
        }

        //lấy dữ liệu của dòng đang chọn
        private void LayDuLieu()
        {
            m_RowResult = gridView1.GetFocusedDataRow();

            DialogResult = System.Windows.Forms.DialogResult.OK;
            m_DtResult.Dispose();
            Close();
        }

        //chọn dòng bằng sự kiện double click chuột
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        //phím tắt trên lưới
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //Escape
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                m_DtResult.Dispose();
                Close();
            }
            else if (e.KeyCode == Keys.F3)
            {
                gridView1.FocusedRowHandle = GridControl.AutoFilterRowHandle;
                gridView1.GridControl.BeginInvoke(new MethodInvoker(gridView1.ShowEditor));
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (gridView1.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                    LayDuLieu();
            }
        }

       

    }
}