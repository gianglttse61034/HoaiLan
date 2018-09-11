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
using BLL_GPP.DanhMuc;
using DevExpress.XtraGrid.Columns;

namespace GPP_Application_HL.DanhMuc
{
    public partial class DanhMuc_BietDuocEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Khai Báo Biến Toàn cục
        private DataTable m_Dt_dvt, m_Dt_NSX, m_Dt_LoaiBD, m_dt_BietDuoc, m_dt_loaiSp;
        private BLL_DanhMuc dm;
        private BLL_DANHMUC_THUOC dm_thuoc;
        private int maxID_BD;
        private CurrencyManager m_CT;
        private bool m_isAddNew = false;
        #endregion
        public DanhMuc_BietDuocEdit()
        {
            InitializeComponent();
            dm = new BLL_DanhMuc();
            dm_thuoc = new BLL_DANHMUC_THUOC();
        }
        private void DanhMuc_BietDuocEdit_Load(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += delegate { maxID_BD = Convert.ToInt32(dm.DanhMuc_TOPID("IDTHUOC", "THUOC").Rows[0]["MAXID"]); };
            bw.DoWork += delegate { m_dt_BietDuoc = dm.DanhMuc_Thuoc(); };
            bw.DoWork += delegate { m_Dt_NSX = dm.DanhMuc_NSX(); };
            bw.DoWork += delegate { m_Dt_LoaiBD = dm.DanhMuc_LOAITHUOC(); };
            bw.DoWork += delegate { m_Dt_dvt = dm.DanhMuc_DVT(); };
            bw.DoWork += delegate { m_dt_loaiSp = dm.DanhMuc_LOAISP(); };
            bw.RunWorkerCompleted += delegate
            {
                 #region Format lookup
                lkpNuocSanXuat.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("TENNSX", 250, "Tên")
                    });
                lkpNuocSanXuat.Properties.DisplayMember = "TENNSX";
                lkpNuocSanXuat.Properties.ValueMember = "IDNSX";
                lkpNuocSanXuat.Properties.NullText = "";
                lkpNuocSanXuat.Properties.ShowHeader = false;
                lkpNuocSanXuat.Properties.DataSource = m_Dt_NSX;

                lkpLoaiBietDuoc.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("TENLOAI", 250, "Tên")
                    });
                lkpLoaiBietDuoc.Properties.DisplayMember = "TENLOAI";
                lkpLoaiBietDuoc.Properties.ValueMember = "IDLOAITHUOC";
                lkpLoaiBietDuoc.Properties.NullText = "";
                lkpLoaiBietDuoc.Properties.ShowHeader = false;
                lkpLoaiBietDuoc.Properties.DataSource = m_Dt_LoaiBD;

                lkpDVT.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("TENDVT", 250, "Tên")
                    });
                lkpDVT.Properties.DisplayMember = "TENDVT";
                lkpDVT.Properties.ValueMember = "IDDVT";
                lkpDVT.Properties.NullText = "";
                lkpDVT.Properties.ShowHeader = false;
                lkpDVT.Properties.DataSource = m_Dt_dvt;

                lkpLoaiSP.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("TENSP", 250, "Tên")
                    });
                lkpLoaiSP.Properties.DisplayMember = "TENSP";
                lkpLoaiSP.Properties.ValueMember = "IDSANPHAM";
                lkpLoaiSP.Properties.NullText = "";
                lkpLoaiSP.Properties.ShowHeader = false;
                lkpLoaiSP.Properties.DataSource = m_dt_loaiSp;
                #endregion

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
                m_CT = (CurrencyManager)frm.BindingContext[m_dt_BietDuoc];
            }
            gridConTrol_CT.DataSource = m_dt_BietDuoc;

            foreach (Control control in layoutControl_Top.Controls)
            {
                if (control is LabelControl) continue;
                control.DataBindings.Clear();
            }
            foreach (Control control in groupbox.Controls)
            {
                if (control is LabelControl) continue;
                control.DataBindings.Clear();
            }

            lkpDVT.DataBindings.Add("EditValue", m_dt_BietDuoc, "IDDVT");
            lkpLoaiBietDuoc.DataBindings.Add("EditValue", m_dt_BietDuoc, "IDLOAITHUOC");
            txtMa_BietDuoc.DataBindings.Add("EditValue", m_dt_BietDuoc, "MATHUOC");
            txtTenBietDuoc.DataBindings.Add("EditValue", m_dt_BietDuoc, "TENTHUOC");
            lkpLoaiSP.DataBindings.Add("EditValue", m_dt_BietDuoc, "IDSANPHAM");
            txtGhiChu.DataBindings.Add("EditValue", m_dt_BietDuoc, "GhiChu");
            lkpNuocSanXuat.DataBindings.Add("EditValue", m_dt_BietDuoc, "idnsx");
        }
        private void LoadLayout()
        {
            gridView_CT.Columns.Clear();
            GridHelper.FormatGrid(gridView_CT,
             "IDTHUOC", "IDTHUOC", 100, "", false,
             "IDLOAITHUOC", "Loại thuốc",300, GridHelper.LookupEDIT, true, m_Dt_LoaiBD, "TENLOAI", "IDLOAITHUOC",
             "IDSANPHAM", "Sản phẩm", 100, GridHelper.LookupEDIT, true, m_dt_loaiSp, "TENSP", "IDSANPHAM",
            "IDDVT", "ĐVT", 100, GridHelper.LookupEDIT, true, m_Dt_dvt, "TENDVT", "IDDVT",
            "MATHUOC", "Mã thuốc", 100, "", true,
            "TENTHUOC", "Tên thuốc", 200, "", true,
            "NHIETDOBQ", "NHIETDOBQ", 100, "", false,
            "TRANHAM", "TRANHAM", 100, "", false,
            "TRANHANHSANG", "TRANHANHSANG", 100, "", false,
            "TRANHNHIETDO", "TRANHNHIETDO", 100, "", false,
            "TRANHDONG", "TRANHDONG", 100, "", false,
            "idnsx", "NƯỚC SẢN XUẤT", 150, GridHelper.LookupEDIT, true, m_Dt_NSX, "TENNSX", "IDNSX",
            "GhiChu", "Ghi chú", 100, "", true,
            "ViTriThuoc", "ViTriThuoc", 100, "", false,
            "Dongia", "Dongia", 100, "", false
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
            bw.DoWork += delegate { m_dt_BietDuoc = dm.DanhMuc_Thuoc(); };
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
            txtMa_BietDuoc.Focus();
            SetEdit(false);
            string maSoHD;
            if (!m_isAddNew) return;
            if (lkpLoaiSP.EditValue.ToString() == "2")
            {
                maSoHD = string.Format("VT{0}", maxID_BD + 1);
            }
            else
                maSoHD = string.Format("BD{0}", maxID_BD + 1);
            DataRow drw = m_dt_BietDuoc.NewRow();
            drw["IDTHUOC"] = maxID_BD + 1;
            drw["IDLOAITHUOC"] = lkpLoaiBietDuoc.EditValue;
            drw["IDSANPHAM"] = lkpLoaiSP.EditValue;
            drw["IDDVT"] = lkpDVT.EditValue;
            drw["MATHUOC"] = maSoHD;
            drw["TENTHUOC"] = txtTenBietDuoc.EditValue;
            drw["NHIETDOBQ"] = txtNhietDoBaoQuan.EditValue;
            drw["TRANHAM"] = ckTranhAmUot.Checked == true ? 1 : 0;
            drw["TRANHANHSANG"] = ckTranhAnhSang.Checked == true ? 1 : 0;
            drw["TRANHNHIETDO"] = ckTranhNhietDoCao.Checked == true ? 1 : 0;
            drw["TRANHDONG"] = ckTranhDongLanh.Checked == true ? 1 : 0;
            drw["idnsx"] = lkpNuocSanXuat.EditValue;
            drw["GhiChu"] = txtGhiChu.EditValue;
            drw["ViTriThuoc"] = txtvitrithuoc.EditValue;
            drw["Dongia"] = 0;
            dm_thuoc.Insert(drw);
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
            DataRow drw=  gridView_CT.GetDataRow(e.FocusedRowHandle);
            if (drw != null)
            {
                ckTranhAmUot.Checked = Convert.ToInt16(drw["TRANHAM"]) == 1 ?true:false;
                ckTranhDongLanh.Checked = Convert.ToInt16(drw["TRANHDONG"]) == 1 ? true : false;
                ckTranhNhietDoCao.Checked = Convert.ToInt16(drw["TRANHNHIETDO"]) == 1 ? true : false;
                ckTranhAnhSang.Checked = Convert.ToInt16(drw["TRANHANHSANG"]) == 1 ? true : false;
            }
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
                    if(((TextEdit)ctr).Name == "txtMa_BietDuoc")
                    {
                        return;
                    }
                    ((TextEdit)ctr).Properties.ReadOnly = !bEdit;
                }
            }
            barThem.Enabled = bEdit; barSua.Enabled = !bEdit; barXoa.Enabled = !bEdit;

        }
        // Xóa trắng dữ liệu
        private void XoaDuLieu()
        {
            txtTenBietDuoc.EditValue = "";
            txtNhietDoBaoQuan.EditValue = "";
            txtGhiChu.EditValue = "";
            txtvitrithuoc.EditValue = "";
            txtMa_BietDuoc.EditValue = "";
            lkpDVT.EditValue = 0;
            lkpLoaiBietDuoc.EditValue = 0;
            lkpNuocSanXuat.EditValue = 0;
        }

        private void barSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMa_BietDuoc.Focus();
            DataRow drw = gridView_CT.GetDataRow(gridView_CT.FocusedRowHandle);
            drw["IDLOAITHUOC"] = lkpLoaiBietDuoc.EditValue;
            drw["IDSANPHAM"] = lkpLoaiSP.EditValue;
            drw["IDDVT"] = lkpDVT.EditValue;
            drw["TENTHUOC"] = txtTenBietDuoc.EditValue;
            drw["NHIETDOBQ"] = txtNhietDoBaoQuan.EditValue;
            drw["TRANHAM"] = ckTranhAmUot.Checked == true ? 1 : 0;
            drw["TRANHANHSANG"] = ckTranhAnhSang.Checked == true ? 1 : 0;
            drw["TRANHNHIETDO"] = ckTranhNhietDoCao.Checked == true ? 1 : 0;
            drw["TRANHDONG"] = ckTranhDongLanh.Checked == true ? 1 : 0;
            drw["idnsx"] = lkpNuocSanXuat.EditValue;
            drw["GhiChu"] = txtGhiChu.EditValue;
            drw["ViTriThuoc"] = txtvitrithuoc.EditValue;
            drw["Dongia"] = 0;
            dm_thuoc.Update(drw);
            RefeshData();
            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void barXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = Convert.ToInt32(gridView_CT.GetRowCellValue(gridView_CT.FocusedRowHandle, "IDTHUOC"));
            if (dm_thuoc.Delete(id))
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefeshData();
        }

        private void barThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_dt_BietDuoc.Dispose();
            this.Close();
        }
        #endregion
    }
}