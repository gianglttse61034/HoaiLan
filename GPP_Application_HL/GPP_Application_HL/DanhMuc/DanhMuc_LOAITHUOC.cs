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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraBars.Controls;
using GPP_DungChung_HL;
using DevExpress.XtraGrid.Columns;
using BLL_GPP.DanhMuc;

namespace GPP_Application_HL.DanhMuc
{
    public partial class DanhMuc_LOAITHUOC : DevExpress.XtraEditors.XtraForm
    {
        #region Khai Báo Biến Toàn cục
        private DataTable m_Dt_LOAITHUOC;
        private BLL_DanhMuc dm;
        private BLL_DANHMUC_LOAITHUOC dm_loaithuoc;
        private int maxID_BD;
        private CurrencyManager m_CT;
        private bool m_isAddNew = false;
        #endregion
        public DanhMuc_LOAITHUOC()
        {
            InitializeComponent();
            dm = new BLL_DanhMuc();
            dm_loaithuoc = new BLL_DANHMUC_LOAITHUOC();
        }
        private void DanhMuc_LOAITHUOC_Load(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += delegate { maxID_BD = Convert.ToInt32(dm.DanhMuc_TOPID("IDLOAITHUOC", "LOAITHUOC").Rows[0]["MAXID"]); };
            bw.DoWork += delegate { m_Dt_LOAITHUOC = dm.DanhMuc_LOAITHUOC(); };
            bw.RunWorkerCompleted += delegate
            {
                BindingData();
                LoadLayout();
                SetEdit(false);
            };
            bw.RunWorkerAsync();
            bw.Dispose();
        }
        private void BindingData()
        {
            Form frm = FindForm();
            if (frm != null)
            {
                m_CT = (CurrencyManager)frm.BindingContext[m_Dt_LOAITHUOC];
            }
            gridConTrol_CT.DataSource = m_Dt_LOAITHUOC;

            foreach (Control control in layoutControl_Top.Controls)
            {
                if (control is LabelControl) continue;
                control.DataBindings.Clear();
            }
            txtTenLoai.DataBindings.Add("EditValue", m_Dt_LOAITHUOC, "TENLOAI");
        }
        private void LoadLayout()
        {
            gridView_CT.Columns.Clear();
            GridHelper.FormatGrid(gridView_CT,
             "IDLOAITHUOC", "IDLOAITHUOC", 100, "", false,
             "TENLOAI", "Tên Loại Thuốc", 100, "", true
            );
            gridView_CT.ColumnPanelRowHeight = 40;
            gridView_CT.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView_CT.Appearance.HeaderPanel.Options.UseTextOptions = true;


            foreach (GridColumn col in gridView_CT.Columns)
            {
                col.OptionsColumn.AllowEdit = false;
            }
        }
        private void RefeshData()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += delegate { m_Dt_LOAITHUOC = dm.DanhMuc_LOAITHUOC(); };
            bw.RunWorkerCompleted += delegate
            {
                BindingData();
            };
            bw.RunWorkerAsync();
            bw.Dispose();
        }

        #region Sự kiện


        private void barThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTenLoai.Focus();
            SetEdit(false);
            if (!m_isAddNew) return;
            DataRow drw = m_Dt_LOAITHUOC.NewRow();
            drw["IDLOAITHUOC"] = maxID_BD+1;
            drw["TENLOAI"] = txtTenLoai.EditValue;
            dm_loaithuoc.Insert(drw);
            maxID_BD = maxID_BD + 1;
            RefeshData();
            m_isAddNew = false;
            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView_CT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (m_isAddNew) return;
            SetEdit(true);
            barSua.Enabled = true;
            barThem.Enabled = false;
            barXoa.Enabled = true;
        }

        private void barXoaTrang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XoaDuLieu();
            SetEdit(true);
            m_isAddNew = true;
            barThem.Enabled = true;
            barSua.Enabled = false;
            barXoa.Enabled = false;
        }

        public void SetEdit(bool bEdit)
        {
            foreach (Control ctr in layoutControl_Top.Controls)
            {
                if (ctr is LookUpEdit)
                {
                    ((LookUpEdit)ctr).Properties.Buttons[0].Visible = bEdit;
                    ((LookUpEdit)ctr).Properties.ReadOnly = !bEdit;
                }
                else if (ctr is DateEdit)
                {
                    ((DateEdit)ctr).Properties.Buttons[0].Visible = bEdit;
                    ((DateEdit)ctr).Properties.ReadOnly = !bEdit;
                }
                else if (ctr is ButtonEdit)
                {
                    ((ButtonEdit)ctr).Properties.Buttons[0].Visible = bEdit;
                    ((ButtonEdit)ctr).Properties.ReadOnly = !bEdit;
                }
                else if (ctr is SimpleButton)
                    ctr.Enabled = bEdit;
                else if (ctr is CheckEdit)
                    ((CheckEdit)ctr).Properties.ReadOnly = !bEdit;
                else if (ctr is TextEdit)
                {
                    ((TextEdit)ctr).Properties.ReadOnly = !bEdit;
                }
            }
            barThem.Enabled = bEdit; barSua.Enabled = !bEdit; barXoa.Enabled = !bEdit;

        }
        // Xóa trắng dữ liệu
        private void XoaDuLieu()
        {
            txtTenLoai.EditValue = "";
        }

        private void barSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTenLoai.Focus();
            DataRow drw = gridView_CT.GetDataRow(gridView_CT.FocusedRowHandle);
            drw["TENLOAI"] = txtTenLoai.EditValue;
            dm_loaithuoc.Update(drw);
            RefeshData();
            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void barXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = Convert.ToInt32(gridView_CT.GetRowCellValue(gridView_CT.FocusedRowHandle, "IDLOAITHUOC"));
            if (dm_loaithuoc.Delete(id))
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefeshData();
        }

        private void barThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_Dt_LOAITHUOC.Dispose();
            this.Close();
        }
        #endregion
    }
}