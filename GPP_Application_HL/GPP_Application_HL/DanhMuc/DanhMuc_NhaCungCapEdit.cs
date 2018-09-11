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
    public partial class DanhMuc_NhaCungCapEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Khai Báo Biến Toàn cục
        private DataTable m_Dt_NCC;
        private BLL_DanhMuc dm;
        private BLL_DANHMUC_NCC dm_ncc;
        private int maxID_BD;
        private CurrencyManager m_CT;
        private bool m_isAddNew = false;
        #endregion
        public DanhMuc_NhaCungCapEdit()
        {
            InitializeComponent();
            dm = new BLL_DanhMuc();
            dm_ncc = new BLL_DANHMUC_NCC();
        }
        private void DanhMuc_NhaCungCapEdit_Load(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += delegate { maxID_BD = Convert.ToInt32(dm.DanhMuc_TOPID("IDTHUOC", "THUOC").Rows[0]["MAXID"]); };
            bw.DoWork += delegate { m_Dt_NCC = dm.DanhMuc_NCC(); };
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
                m_CT = (CurrencyManager)frm.BindingContext[m_Dt_NCC];
            }
            gridConTrol_CT.DataSource = m_Dt_NCC;

            foreach (Control control in layoutControl_Top.Controls)
            {
                if (control is LabelControl) continue;
                control.DataBindings.Clear();
            }
            txtTenNCC.DataBindings.Add("EditValue", m_Dt_NCC, "TENNCC");
            txtDiaChiNCC.DataBindings.Add("EditValue", m_Dt_NCC, "DIACHINCC");
            txtDienThoaiNCC.DataBindings.Add("EditValue", m_Dt_NCC, "DIENTHOAINCC");
            txtSoDKDK.DataBindings.Add("EditValue", m_Dt_NCC, "SoDKDK");
            txtGhiChu.DataBindings.Add("EditValue", m_Dt_NCC, "GHICHU");
            txtFax.DataBindings.Add("EditValue", m_Dt_NCC, "FAX");
        }
        private void LoadLayout()
        {
            gridView_CT.Columns.Clear();
            GridHelper.FormatGrid(gridView_CT,
             "IDNCC", "IDNCC", 100, "", false,
             "TENNCC", "Tên NCC", 100, "", true,
             "DIACHINCC", "Địa chỉ NCC", 100, "", true,
            "DIENTHOAINCC", "Điện thoại NCC", 100, "", true,
            "SoDKDK", "Số ĐKKD", 100, "", true,
            "FAX", "FAX", 100, "", true,
            "GHICHU", "Ghi Chú", 100, "", true
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
            bw.DoWork += delegate { m_Dt_NCC = dm.DanhMuc_NCC(); };
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
            txtMa_NCC.Focus();
            SetEdit(false);
            if (!m_isAddNew) return;
            DataRow drw = m_Dt_NCC.NewRow();
            drw["IDNCC"] = maxID_BD+1;
            drw["SoDKDK"] = txtSoDKDK.EditValue;
            drw["FAX"] = txtFax.EditValue;
            drw["DIENTHOAINCC"] = txtDienThoaiNCC.EditValue;
            drw["TENNCC"] = txtTenNCC.EditValue;
            drw["GhiChu"] = txtGhiChu.EditValue;
            drw["DIACHINCC"] = txtDiaChiNCC.EditValue;
            dm_ncc.Insert(drw);
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
            txtTenNCC.EditValue = "";
            txtGhiChu.EditValue = "";
            txtDiaChiNCC.EditValue = "";
            txtMa_NCC.EditValue = "";
        }

        private void barSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMa_NCC.Focus();
            DataRow drw = gridView_CT.GetDataRow(gridView_CT.FocusedRowHandle);
            drw["SoDKDK"] = txtSoDKDK.EditValue;
            drw["FAX"] = txtFax.EditValue;
            drw["DIENTHOAINCC"] = txtDienThoaiNCC.EditValue;
            drw["TENNCC"] = txtTenNCC.EditValue;
            drw["GhiChu"] = txtGhiChu.EditValue;
            drw["DIACHINCC"] = txtDiaChiNCC.EditValue;
            dm_ncc.Update(drw);
            RefeshData();
            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void barXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = Convert.ToInt32(gridView_CT.GetRowCellValue(gridView_CT.FocusedRowHandle, "IDNCC"));
            if (dm_ncc.Delete(id))
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefeshData();
        }

        private void barThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_Dt_NCC.Dispose();
            this.Close();
        }
        #endregion
    }
}