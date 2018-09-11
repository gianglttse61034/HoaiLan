using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GPP_DungChung_HL;
using BLL_GPP.DanhMuc;
using BLL_GPP;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;

namespace GPP_Application_HL
{
    public partial class FrmNhapHoaDon : DevExpress.XtraEditors.XtraForm
    {
        #region  Khai báo biến toàn cục.
        private int soid_goc = 0, soid_ct = 0, idCT_Max = 0, idGoc = 0;
        private string m_TableMaster = "HOADONNHAP", m_TableDetail = "CTHDNHAP_THUOC";
        GridHelper dungchung = new GridHelper();
        CurrencyManager m_CmG, m_CmCT;
        private DateTime tu_ngay, den_ngay;
        private DataSet m_DsResult;
        private DataTable dt_Thuoc, dt_NCC, dt_loaiSP, dt_LoaiThuoc, dt_NSX, dt_LyDo, dt_DVT;
        private Decimal tongtien = 0;
        private bool m_IsEditable = false, m_IsAddNew = false;
        private BLLNhap_Kho nk;
        private BLL_DanhMuc dm;
        #endregion

        public FrmNhapHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();
            nk = new BLLNhap_Kho();
            dm = new BLL_DanhMuc();
            #region format tool


            dtmNgayLapHD.Properties.Mask.EditMask = "dd/MM/yyyy";
            dtmNgayLapHD.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            dtmNgayLapHD.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtmNgayNhap.Properties.Mask.EditMask = "dd/MM/yyyy";
            dtmNgayNhap.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            dtmNgayNhap.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtmNgaySanXuat.Properties.Mask.EditMask = "dd/MM/yyyy";
            dtmNgaySanXuat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            dtmNgaySanXuat.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtmHanSuDung.Properties.Mask.EditMask = "dd/MM/yyyy";
            dtmHanSuDung.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            dtmHanSuDung.Properties.Mask.UseMaskAsDisplayFormat = true;

            dtmTuNgayRL.Properties.Mask.EditMask = "dd/MM/yyyy";
            dtmTuNgayRL.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            dtmTuNgayRL.Properties.Mask.UseMaskAsDisplayFormat = true;

            dtmDenNgayRL.Properties.Mask.EditMask = "dd/MM/yyyy";
            dtmDenNgayRL.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            dtmDenNgayRL.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtTongTien.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtTongTien.Properties.Mask.EditMask = "N0";
            txtTongTien.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtThanhTien.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtThanhTien.Properties.Mask.EditMask = "N0";
            txtThanhTien.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtDonGia.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDonGia.Properties.Mask.EditMask = "N0";
            txtDonGia.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtDonGiaBan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDonGiaBan.Properties.Mask.EditMask = "N0";
            txtDonGiaBan.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtSoLuongNhap.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtSoLuongNhap.Properties.Mask.EditMask = "N0";
            txtSoLuongNhap.Properties.Mask.UseMaskAsDisplayFormat = true;
            #endregion

            den_ngay = denNgay;
            tu_ngay = tuNgay;
            dtmTuNgayRL.EditValue = tuNgay;
            dtmDenNgayRL.EditValue = denNgay;
        }

        private void FrmNhapHoaDon_Load(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += delegate { soid_goc = Convert.ToInt32(dm.DanhMuc_TOPID("IDHDN", "HOADONNHAP").Rows[0]["MAXID"]); };
            bw.DoWork += delegate { soid_ct = Convert.ToInt32(dm.DanhMuc_TOPID("IdChiTietHoaDonNhap_Thuoc", "CTHDNHAP_THUOC").Rows[0]["MAXID"]); };
            bw.DoWork += delegate { dt_Thuoc = dm.DanhMuc_Thuoc(); };
            bw.DoWork += delegate { dt_NCC = dm.DanhMuc_NCC(); };
            bw.DoWork += delegate { dt_NSX = dm.DanhMuc_NSX(); };
            bw.DoWork += delegate { dt_LyDo = dm.DanhMuc_LyDo(); };
            bw.DoWork += delegate { dt_loaiSP = dm.DanhMuc_LOAISP(); };
            bw.DoWork += delegate { dt_LoaiThuoc = dm.DanhMuc_LOAITHUOC(); };
            bw.DoWork += delegate { dt_DVT = dm.DanhMuc_DVT(); };
            bw.DoWork += delegate { m_DsResult = nk.ConnectData(tu_ngay, den_ngay); };
            bw.RunWorkerCompleted += delegate
             {
                 DataTable lydoNhap = new DataTable();
                 lydoNhap.Columns.Add("IDLYDO", typeof(int));
                 lydoNhap.Columns.Add("LYDO", typeof(string));
                 lydoNhap.Rows.Add(new object[] { 5, "Nhập hàng" });
                 lydoNhap.Rows.Add(new object[] { 6, "Nhập hàng tồn đầu" });
                 lydoNhap.Rows.Add(new object[] { 3, "Trả hàng" });
                 DataTable ThueVAT = new DataTable();
                 ThueVAT.Columns.Add("VAT", typeof(decimal));
                 ThueVAT.Columns.Add("TENVAT", typeof(string));
                 ThueVAT.Rows.Add(new object[] { 5, "5%" });
                 ThueVAT.Rows.Add(new object[] { 10, "10%" });
                 ThueVAT.Rows.Add(new object[] { 15, "15%" });
                 ThueVAT.Rows.Add(new object[] { 20, "20%" });
                 ThueVAT.Rows.Add(new object[] { 25, "25%" });
                 ThueVAT.Rows.Add(new object[] { 0, "0%" });



                 #region Format lookup
                 lkpThueVAT.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("TENVAT", 250, "Tên")
                    });
                 lkpThueVAT.Properties.DisplayMember = "TENVAT";
                 lkpThueVAT.Properties.ValueMember = "VAT";
                 lkpThueVAT.Properties.NullText = "";
                 lkpThueVAT.Properties.ShowHeader = false;
                 lkpThueVAT.Properties.DataSource = ThueVAT;

                 lkpNuocSanXuat.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("TENNSX", 250, "Tên")
                    });
                 lkpNuocSanXuat.Properties.DisplayMember = "TENNSX";
                 lkpNuocSanXuat.Properties.ValueMember = "IDNSX";
                 lkpNuocSanXuat.Properties.NullText = "";
                 lkpNuocSanXuat.Properties.ShowHeader = false;
                 lkpNuocSanXuat.Properties.DataSource = dt_NSX;

                 lkpNhaCungCap.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("TENNCC", 250, "Tên")
                    });
                 lkpNhaCungCap.Properties.DisplayMember = "TENNCC";
                 lkpNhaCungCap.Properties.ValueMember = "IDNCC";
                 lkpNhaCungCap.Properties.NullText = "";
                 lkpNhaCungCap.Properties.ShowHeader = false;
                 lkpNhaCungCap.Properties.DataSource = dt_NCC;

                 lkpLoaiBietDuoc.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("TENLOAI", 250, "Tên")
                    });
                 lkpLoaiBietDuoc.Properties.DisplayMember = "TENLOAI";
                 lkpLoaiBietDuoc.Properties.ValueMember = "IDLOAITHUOC";
                 lkpLoaiBietDuoc.Properties.NullText = "";
                 lkpLoaiBietDuoc.Properties.ShowHeader = false;
                 lkpLoaiBietDuoc.Properties.DataSource = dt_LoaiThuoc;

                 lkpLoaiSP.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("TENSP", 250, "Tên")
                    });
                 lkpLoaiSP.Properties.DisplayMember = "TENSP";
                 lkpLoaiSP.Properties.ValueMember = "IDSANPHAM";
                 lkpLoaiSP.Properties.NullText = "";
                 lkpLoaiSP.Properties.ShowHeader = false;
                 lkpLoaiSP.Properties.DataSource = dt_loaiSP;

                 lkpLyDoNhap.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("LYDO", 250, "Tên")
                    });
                 lkpLyDoNhap.Properties.DisplayMember = "LYDO";
                 lkpLyDoNhap.Properties.ValueMember = "IDLYDO";
                 lkpLyDoNhap.Properties.NullText = "";
                 lkpLyDoNhap.Properties.ShowHeader = false;
                 lkpLyDoNhap.Properties.DataSource = lydoNhap;

                 lkpDonViTinh.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("TENDVT", 250, "Tên")
                    });
                 lkpDonViTinh.Properties.DisplayMember = "TENDVT";
                 lkpDonViTinh.Properties.ValueMember = "IDDVT";
                 lkpDonViTinh.Properties.NullText = "";
                 lkpDonViTinh.Properties.ShowHeader = false;
                 lkpDonViTinh.Properties.DataSource = dt_DVT;

                 lkpBietDuoc.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("TENTHUOC", 250, "Tên")
                    });

                 lkpBietDuoc.Properties.DisplayMember = "TENTHUOC";
                 lkpBietDuoc.Properties.ValueMember = "IDTHUOC";
                 lkpBietDuoc.Properties.NullText = "";
                 lkpBietDuoc.Properties.ShowHeader = false;
                 lkpBietDuoc.Properties.DataSource = dt_Thuoc;

                 #endregion
                 BindingData();
                 LoadLayout();
                 KhoaButton(false);
                 SetProgressbar(false);
                 btnHuyLuu.Enabled = btnLuuHD.Enabled = false;
                 btnLuuHD.Enabled = false;
                 gridView_CT.FocusedRowHandle = GridControl.AutoFilterRowHandle;
             };
            bw.RunWorkerAsync(); SetProgressbar(true);
            bw.Dispose();
        }

        public void TongTienTheoDong()
        {
            if (gridView_CT.RowCount < 0) return;
            tongtien = 0;
            DataTable dt = ((DataView)gridView_CT.DataSource).ToTable();
            foreach (DataRow rw in dt.Rows)
            {
                tongtien += Convert.ToDecimal(rw["DONGIAN_VAT_"] == null ? 0 : rw["DONGIAN_VAT_"]) * Convert.ToDecimal(rw["SOLUONGNHAP"] == null ? 0 : rw["SOLUONGNHAP"]);
            }
            txtTongTien.EditValue = tongtien;
        }

        public void XoaDuLieu()
        {
            lkpLoaiSP.EditValue = null;
            lkpBietDuoc.EditValue = null;
            lkpLoaiBietDuoc.EditValue = null;
            lkpNuocSanXuat.EditValue = null;

            txtDonGiaVat.EditValue = 0;
            txtDonGiaBan.EditValue = 0;
            txtDonGia.EditValue = 0;
            txtSoLo.EditValue = "";
            lkpThueVAT.EditValue = Convert.ToDecimal(5);
            txtThanhTien.EditValue = 0;
            dtmNgaySanXuat.EditValue = "";
            dtmHanSuDung.EditValue = "";
            txtSoLuongNhap.EditValue = 0;
            if (!m_IsEditable && m_IsAddNew)
            {
                txtMSHĐ.EditValue = "";
                dtmNgayLapHD.EditValue = "";
                dtmNgayNhap.EditValue = "";
                lkpNhaCungCap.EditValue = "";
                lkpLyDoNhap.EditValue = "";
                txtTongTien.EditValue = 0;
            }

        }
        public void SetProgressbar(bool flag)
        {
            if (layoutControl_Top.InvokeRequired)
            {
                layoutControl_Top.Invoke((MethodInvoker)delegate
                {
                    //hiện progressbar
                    if (flag)
                    {
                        groupControl_Progress.BringToFront();
                    }
                    else
                        groupControl_Progress.SendToBack();

                    layoutControl_Top.Enabled = !flag;
                });
            }

            //hiện progressbar
            if (flag)
            {
                groupControl_Progress.BringToFront();
            }
            else
                groupControl_Progress.SendToBack();

            layoutControl_Top.Enabled = !flag;
        }

        private void SetEditable(bool bEdit)
        {
            foreach (Control ctr in layoutControl_CTHDN.Controls)
            {
                if (ctr is LookUpEdit)
                {
                    if (((LookUpEdit)ctr).Name == "lkpDVT" || ((LookUpEdit)ctr).Name == "lkpLoaiSP" || ((LookUpEdit)ctr).Name == "lkpLoaiBietDuoc")
                    {
                        return;
                    }
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
            foreach (Control ctr in layoutControl_HDN.Controls)
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
        }

        public void KhoaButton(bool tf) // x false => khởi tạo
        {
            //=> Khóa các button Thêm CT,Lưu HD,Hủy ưu,sửa hiện,xóa hiện
            SetEditable(tf);
            btnSua.Enabled = !tf;
            btnLuuHD.Enabled = tf; btnThemMoi.Enabled = !tf;
            btnHuyLuu.Enabled = tf;
            btnThemCT.Enabled = tf;
            btnThoat.Enabled = true;
            btnXoa.Enabled = true;
        }

        public void LoadLayout()
        {

            gridView_CT.Columns.Clear();
            gridView_Goc.Columns.Clear();
            GridHelper.FormatGrid(gridView_Goc,
            "IDHDN", "IDHDN", 100, "", false,
            "IDNCC", "Nhà cung cấp ", 100, GridHelper.LookupEDIT, true, dt_NCC, "TENNCC", "IDNCC",
            "TENHOADON", "Tên hóa đơn", 100, "", true,
            "NGAYNHAP", "Ngày nhập", 100, GridHelper.TextEdit_Mod, true, GridHelper.DateTimeMOD, 50, "Ola",
            "NGAYLAPHD", "Ngày lập hóa đơn", 100, GridHelper.TextEdit_Mod, true, GridHelper.DateTimeMOD, 50, "Ola",
            "Lydonhap", "Lý do nhập", 100, GridHelper.LookupEDIT, true, dt_LyDo, "Lydo", "Idlydo",
            "Flag", "Flag", 100, "", false,
            "daxoa", "daxoa", 100, "", false
            );
            GridHelper.FormatGrid(gridView_CT,
           "IdChiTietHoaDonNhap_Thuoc", "IdChiTietHoaDonNhap_Thuoc", 100, "", false,
           "IDHDN", "IDHDN", 100, "", false,
           "IDTHUOC", "IDTHUOC", 100, "", false,
           "SOLO", "Số lô", 100, "", true,
           "tensp", "Tên Thuốc", 200, "", true,
           "idloaithuoc", "Loại thuốc", 100, GridHelper.LookupEDIT, true, dt_LoaiThuoc, "TENLOAI", "IDLOAITHUOC",
           "idlsp", "Loại sản phẩm", 100, GridHelper.LookupEDIT, false, dt_loaiSP, "TENSP", "IDSANPHAM",
           "NGAYSX", "Ngày sản xuất", 100, GridHelper.TextEdit_Mod, true, GridHelper.DateTimeMOD, 50, "Ola",
           "HANSUDUNG", "Hạn sử dụng", 100, GridHelper.TextEdit_Mod, true, GridHelper.DateTimeMOD, 50, "Ola",
           "IDNSX", "Nhà sản xuất", 100, GridHelper.LookupEDIT, true, dt_NSX, "TENNSX", "IDNSX",
           "SOLUONGNHAP", "Số lượng nhập", 100, GridHelper.TextEdit_Mod, true, GridHelper.Numberic, 50, "N0",
           "DONGIAN", "Đơn giá", 100, GridHelper.TextEdit_Mod, true, GridHelper.Numberic, 50, "N0",
           "VAT", "VAT", 100, GridHelper.TextEdit_Mod, true, GridHelper.Numberic, 50, "N0",
           "DONGIAN_VAT_", "Đơn giá VAT", 100, GridHelper.TextEdit_Mod, true, GridHelper.Numberic, 50, "N0",
           "DONGIABAN", "Đơn giá bán", 100, GridHelper.TextEdit_Mod, true, GridHelper.Numberic, 50, "N0",
           "ThanhTienTheoDVTLonNhat", "Thành tiền theo DVT lớn nhất", 100, GridHelper.TextEdit_Mod, true, GridHelper.Numberic, 50, "N3",
           "QUYCACHNHAP", "Quy cách nhập", 100, "", false,
           "Flag", "Flag", 100, "", false,
           "daxoa", "daxoa", 100, "", false);

            gridView_CT.ColumnPanelRowHeight = 40;
            gridView_CT.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView_CT.Appearance.HeaderPanel.Options.UseTextOptions = true;


            gridView_Goc.ColumnPanelRowHeight = 40;
            gridView_Goc.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView_Goc.Appearance.HeaderPanel.Options.UseTextOptions = true;
            foreach (GridColumn col in gridView_CT.Columns)
            {
                if (col.Name == "NGAYSX")
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    col.DisplayFormat.FormatString = "dd/MM/yyyy";
                }
                if (col.FieldName == "tensp" || col.FieldName == "solo")
                {
                    col.Fixed = FixedStyle.Left;
                }
                col.OptionsColumn.AllowEdit = false;
            }
            foreach (GridColumn col in gridView_Goc.Columns)
            {
                if (col.Name == "NGAYLAPHD" || col.Name == "NGAYNHAP")
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    col.DisplayFormat.FormatString = "dd/MM/yyyy";
                }
                col.OptionsColumn.AllowEdit = false;
            }
        }

        public void RefreshData()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += delegate
            {
                m_DsResult = nk.ConnectData(tu_ngay, den_ngay);
            };
            bw.RunWorkerCompleted += delegate
            {

                BindingData();
                FindForm().Activate();
            };
            bw.RunWorkerAsync();
            bw.Dispose();
        }

        private void gridView_CT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (m_IsAddNew) return;
            if(gridView_CT.FocusedRowHandle == GridControl.AutoFilterRowHandle) return;
            //(TongTienTheoDong);
            DataRow rw = gridView_CT.GetDataRow(gridView_CT.FocusedRowHandle);
            if (rw != null)
                BindingData_CT(rw);
            else
                return;

        }

        private bool SaveXml()
        {

            gridView_CT.ClearColumnsFilter();
            gridView_CT.FocusedRowHandle = GridControl.AutoFilterRowHandle;

            //tạo xml cho phần gốc: Stat=0: delete phiếu, Stat=1: thêm mới phiếu, Stat=2: cập nhật phiếu
            StringBuilder xml_g = new StringBuilder();
            m_CmG.EndCurrentEdit();
            m_CmCT.EndCurrentEdit();
            DataRow rowNew_g = ((DataRowView)m_CmG.Current).Row;
            #region phần gốc

            xml_g.AppendLine("<Root>");
            xml_g.Append(string.Format("<{0} ", m_TableMaster));
            if (m_IsAddNew)//thêm mới
            {
                //gắn tình trạng của dữ liệu trong xml
                xml_g.Append("Stat = \"1\" ");
            }
            else if (m_IsEditable)//cập nhật
            {
                //gắn tình trạng của dữ liệu trong xml
                xml_g.Append("Stat = \"2\" ");
            }
            //đưa dữ liệu các column vào xml
            object data = null;
            foreach (DataColumn col in rowNew_g.Table.Columns)
            {
                data = rowNew_g[col];
                if (col.DataType == typeof(DateTime))
                {
                    if (data != null && data.ToString() != "")
                    {
                        data = ((DateTime)data).ToString("yyyy/MM/dd hh:mm:ss");
                    }
                    else
                        data = "";
                }
                else if (col.DataType == typeof(bool) && (data == null || data.ToString() == ""))
                    data = 0;
                else if (col.DataType == typeof(Decimal))
                {
                    if (data == null || data.ToString() == "")
                        data = 0;
                }

                xml_g.AppendFormat("{0} = \"{1}\" ", col.ColumnName
                    , data.ToString().Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;").Replace("'", "&apos;").Replace("\"", "&quot;")
                        );
            }
            xml_g.AppendLine("/>");
            xml_g.AppendLine("</Root>");
            #endregion

            #region phần chi tiết
            //tạo xml cho phần chi tiết
            StringBuilder xml_ct = new StringBuilder();
            //lấy dữ liệu trên lưới
            DataTable dt = ((DataView)gridView_CT.DataSource).ToTable();
            xml_ct.AppendLine("<Root>");
            //đưa dữ liệu các column vào xml
            foreach (DataRow row in dt.Rows)
            {
                idCT_Max = soid_ct + 1;
                //DataRow rowNew_ct = ((DataRowView)m_CmCT.Current).Row;
                DataRow rowNew_ct = row;
                if (m_IsAddNew)
                {
                    row["IdChiTietHoaDonNhap_Thuoc"] = idCT_Max;
                    soid_ct = idCT_Max;
                }
                if (Convert.ToBoolean(row["Flag"]) == true) { row["IdChiTietHoaDonNhap_Thuoc"] = idCT_Max; soid_ct = idCT_Max; }
                row["Flag"] = 0;
                xml_ct.Append(string.Format("<{0} ", m_TableDetail));
                if (rowNew_ct.RowState == DataRowState.Added)//thêm mới
                    xml_ct.Append("Stat = \"1\" ");
                else if (rowNew_ct.RowState == DataRowState.Modified) //cập nhật
                    xml_ct.Append("Stat = \"2\" ");

                foreach (DataColumn col in dt.Columns)
                {
                    data = row[col];
                    if (col.DataType == typeof(DateTime))
                    {
                        if (data != null && data.ToString() != "")
                        {
                            data = ((DateTime)data).ToString("yyyy/MM/dd hh:mm:ss");
                        }
                        else
                            data = "";
                    }
                    else if (col.DataType == typeof(bool) && (data == null || data.ToString() == ""))
                        data = 0;
                    else if (col.DataType == typeof(Decimal))
                    {
                        if (data == null || data.ToString() == "")
                            data = 0;
                    }
                    xml_ct.AppendFormat("{0} = \"{1}\" ", col.ColumnName
                        , data.ToString().Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;").Replace("'", "&apos;").Replace("\"", "&quot;")
                        );
                }

                xml_ct.AppendLine("/>");

            }
            xml_ct.AppendLine("</Root>");

            #endregion

            #region xử lý dưới database

            if (m_IsAddNew)//thêm mới
                dt = nk.InsertData(rowNew_g["IDHDN"], xml_g, xml_ct, gridView_CT.RowCount);
            else
            if (m_IsEditable)//chỉnh sửa
                dt = nk.UpdateData(rowNew_g["IDHDN"], xml_g, xml_ct);

            if (dt.Rows[0]["dungsodong"].ToString() == "1")//nếu đúng số dòng thì lưu thành công
            {
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //xác nhận thay đổi dữ liệu trên DataSet
                BindingData();
                m_DsResult.AcceptChanges();
                return true;
            }
            //nếu KHÔNG đúng số dòng thì lưu KHÔNG thành công
            if (dt.Rows[0]["dungsodong"].ToString() == "0")
            {
                string stt = string.Empty;
                foreach (DataRow row in dt.Rows)
                {
                    stt = string.Format("{0}, {1}", stt, row["sott"]);
                }
                MessageBox.Show(string.Format("{0}, các dòng {1}", "Lưu thất bại", stt.TrimStart(',')),
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;

            #endregion
        }

        private void XoaDongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView_CT.FocusedRowHandle < 0) return;
            if (gridView_CT.FocusedRowHandle == GridControl.AutoFilterRowHandle) return;
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;
            gridView_CT.DeleteRow(gridView_CT.FocusedRowHandle);
            TongTienTheoDong();
        }

        #region Sự kiện Layout top


        private void lkpLoaiSP_EditValueChanged(object sender, EventArgs e)
        {
            if (m_IsEditable || m_IsAddNew)
            {
                if (gridView_CT.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                {
                    gridView_CT.SetRowCellValue(gridView_CT.FocusedRowHandle, "idlsp", lkpLoaiSP.EditValue);
                }
            }
        }

        private void lkpLoaiBietDuoc_EditValueChanged(object sender, EventArgs e)
        {
            if (m_IsEditable || m_IsAddNew)
            {
                if (gridView_CT.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                {
                    gridView_CT.SetRowCellValue(gridView_CT.FocusedRowHandle, "idloaithuoc", lkpLoaiBietDuoc.EditValue);
                }
            }
        }

        private void lkpNuocSanXuat_EditValueChanged(object sender, EventArgs e)
        {

            if (m_IsEditable || m_IsAddNew)
            {
                if (gridView_CT.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                gridView_CT.SetRowCellValue(gridView_CT.FocusedRowHandle, "IDNSX", lkpNuocSanXuat.EditValue);

            }
        }

        private void dtmNgaySanXuat_EditValueChanged(object sender, EventArgs e)
        {

            if (m_IsEditable || m_IsAddNew)
            {
                if (gridView_CT.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                    gridView_CT.SetRowCellValue(gridView_CT.FocusedRowHandle, "NGAYSX", dtmNgaySanXuat.EditValue);
            }

        }

        private void txtSoLo_EditValueChanged(object sender, EventArgs e)
        {

            if (m_IsEditable || m_IsAddNew)
            {
                if (gridView_CT.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                {
                    gridView_CT.SetRowCellValue(gridView_CT.FocusedRowHandle, "SOLO", txtSoLo.EditValue);
                }
            }
        }

        private void txtSoLuongNhap_EditValueChanged(object sender, EventArgs e)
        {

            if (m_IsEditable || m_IsAddNew)
            {
                if (gridView_CT.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                {
                    gridView_CT.SetRowCellValue(gridView_CT.FocusedRowHandle, "SOLUONGNHAP", txtSoLuongNhap.EditValue);
                }
            }
        }

        private void txtDonGiaVat_EditValueChanged(object sender, EventArgs e)
        {

            if (m_IsEditable || m_IsAddNew)
            {
                if (gridView_CT.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                {
                    gridView_CT.SetRowCellValue(gridView_CT.FocusedRowHandle, "DONGIAN_VAT_", txtDonGiaVat.EditValue);
                }
                txtDonGiaBan.EditValue = Convert.ToDecimal(txtDonGiaVat.EditValue) + (Convert.ToDecimal(txtDonGiaVat.EditValue) * 20 / 100);
            }
        }

        private void dtmHanSuDung_EditValueChanged(object sender, EventArgs e)
        {

            if (m_IsEditable || m_IsAddNew)
            {
                if (gridView_CT.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                {
                    gridView_CT.SetRowCellValue(gridView_CT.FocusedRowHandle, "HANSUDUNG", dtmHanSuDung.EditValue);
                }
            }
        }

        private void txtThanhTien_EditValueChanged(object sender, EventArgs e)
        {
            if (m_IsEditable || m_IsAddNew)
            {
                if (gridView_CT.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                {
                    gridView_CT.SetRowCellValue(gridView_CT.FocusedRowHandle, "ThanhTienTheoDVTLonNhat", txtThanhTien.EditValue);
                }
                if (Convert.ToDecimal(txtSoLuongNhap.EditValue) == 0) return;
                txtDonGia.EditValue = Convert.ToDecimal(txtThanhTien.EditValue) / Convert.ToDecimal(txtSoLuongNhap.EditValue);
            }
        }

        private void txtDonGia_EditValueChanged(object sender, EventArgs e)
        {
            if (m_IsEditable || m_IsAddNew)
            {
                if (gridView_CT.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                {
                    gridView_CT.SetRowCellValue(gridView_CT.FocusedRowHandle, "DONGIAN", txtDonGia.EditValue);
                }
                txtDonGiaVat.EditValue = (Convert.ToDecimal(lkpThueVAT.EditValue) * Convert.ToDecimal(txtDonGia.EditValue) / 100) + Convert.ToDecimal(txtDonGia.EditValue);
            }
        }

        private void txtThueVAT_EditValueChanged(object sender, EventArgs e)
        {
            if (m_IsEditable || m_IsAddNew)
            {
                if (gridView_CT.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                {
                    gridView_CT.SetRowCellValue(gridView_CT.FocusedRowHandle, "VAT", lkpThueVAT.EditValue);
                }
            }
        }

        private void lkpDonViTinh_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDonGiaBan_EditValueChanged(object sender, EventArgs e)
        {
            if (m_IsEditable || m_IsAddNew)
            {
                if (gridView_CT.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                {
                    gridView_CT.SetRowCellValue(gridView_CT.FocusedRowHandle, "DONGIABAN", txtDonGiaBan.EditValue);
                }
            }
        }

        private void txtViTriThuoc_EditValueChanged(object sender, EventArgs e)
        {

        }

        #endregion
        private void lkpThueVAT_EditValueChanged(object sender, EventArgs e)
        {
            if (m_IsEditable || m_IsAddNew)
            {
                if (gridView_CT.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                {
                    gridView_CT.SetFocusedRowCellValue("VAT", lkpThueVAT.EditValue);
                }
                txtDonGiaVat.EditValue = (Convert.ToDecimal(lkpThueVAT.EditValue) * Convert.ToDecimal(txtDonGia.EditValue) / 100) + Convert.ToDecimal(txtDonGia.EditValue);

            }

        }

        private void gridView_Goc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            tongtien = 0;
            if (gridView_CT.RowCount <= 0) return;
            TongTienTheoDong();
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            if (m_IsEditable || m_IsAddNew)
            {
                m_CmCT.AddNew();
                DataRow rw = ((DataRowView)m_CmCT.Current).Row;
                if (m_IsAddNew)
                {
                    rw["FLAG"] = 0;
                }
                else
                    if (m_IsEditable)
                {
                    rw["FLAG"] = 1;
                }
                else rw["FLAG"] = 0;
                XoaDuLieu();
            }
        }

        private void BindingData_CT(DataRow drw)
        {
            txtDonGiaVat.EditValue = Convert.ToDecimal(drw["DONGIAN_VAT_"] == null || drw["DONGIAN_VAT_"].ToString() == "" ? 0 : drw["DONGIAN_VAT_"]);
            txtDonGiaBan.EditValue = Convert.ToDecimal(drw["DONGIABAN"] == null || drw["DONGIABAN"].ToString() == "" ? 0 : drw["DONGIABAN"]);
            txtDonGia.EditValue = Convert.ToDecimal(drw["DONGIAN"] == null || drw["DONGIAN"].ToString() == "" ? 0 : drw["DONGIAN"]);
            txtSoLo.EditValue = drw["SOLO"];
            lkpThueVAT.EditValue = Convert.ToDecimal(drw["VAT"] == null || drw["VAT"].ToString() == "" ? 0 : drw["VAT"]);
            txtThanhTien.EditValue = Convert.ToDecimal(drw["ThanhTienTheoDVTLonNhat"] == null || drw["ThanhTienTheoDVTLonNhat"].ToString() == "" ? 0 : drw["ThanhTienTheoDVTLonNhat"]);
            lkpBietDuoc.EditValue = drw["IDTHUOC"];
            lkpLoaiBietDuoc.EditValue = drw["IDLOAITHUOC"];
            lkpNuocSanXuat.EditValue = drw["IDNSX"];
            dtmNgaySanXuat.EditValue = drw["NGAYSX"];
            dtmHanSuDung.EditValue = drw["HANSUDUNG"];
            txtSoLuongNhap.EditValue = Convert.ToDecimal(drw["SOLUONGNHAP"] == null || drw["SOLUONGNHAP"].ToString() == "" ? 0 : drw["SOLUONGNHAP"]);

        }

        private void BindingData()
        {
            Form frm = FindForm();
            if (frm != null)
            {
                m_CmG = (CurrencyManager)frm.BindingContext[m_DsResult, "g"];
                m_CmCT = (CurrencyManager)frm.BindingContext[m_DsResult, "g.R_ct"];
            }
            gridControl_Goc.DataSource = m_DsResult;
            gridControl_Goc.DataMember = "g";
            gridControl_CT.DataSource = m_DsResult;
            gridControl_CT.DataMember = "g.R_ct";

            foreach (Control control in layoutControl_CTHDN.Controls)
            {
                if (control is LabelControl) continue;
                control.DataBindings.Clear();
            }
            foreach (Control control in layoutControl_HDN.Controls)
            {
                if (control is LabelControl) continue;
                control.DataBindings.Clear();
            }
            txtMSHĐ.DataBindings.Clear();
            txtMSHĐ.DataBindings.Add("EditValue", m_DsResult, "g.TENHOADON");
            lkpNhaCungCap.DataBindings.Add("EditValue", m_DsResult, "g.IDNCC");
            lkpLyDoNhap.DataBindings.Add("EditValue", m_DsResult, "g.Lydonhap");
            dtmNgayLapHD.DataBindings.Add("EditValue", m_DsResult, "g.NGAYLAPHD");
            dtmNgayNhap.DataBindings.Add("EditValue", m_DsResult, "g.NGAYNHAP");

        }

        private void InsertRow(DataRow drw)
        {
            //if (m_IsAddNew)
            //    if (!gridView_CT.IsFocusedView) gridView_CT.Focus();
            //if (!gridView_CT.UpdateCurrentRow()) return;
            //m_DsResult.Tables["ct"].Rows.Add(drw);
            //gridView_CT.UpdateCurrentRow();
            //gridView_CT.FocusedRowHandle = gridView_CT.FocusedRowHandle - 1;
            //gridView_CT.Focus();
        }

        #region Sự kiện
        //=> xóa trắng => thêm dòng => luu HĐ
        private void lkpBietDuoc_EditValueChanged(object sender, EventArgs e)
        {
            if (lkpBietDuoc.EditValue == null) return;

            if (lkpBietDuoc.EditValue.ToString() != "")
            {
                dt_Thuoc.DefaultView.RowFilter = string.Format("IDTHUOC={0}", lkpBietDuoc.EditValue.ToString());
            }
            DataTable dt = dt_Thuoc.DefaultView.ToTable();
            if (dt.Rows.Count != 0)
            {
                if (m_IsEditable || m_IsAddNew)
                {
                    if (gridView_CT.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                    {
                        gridView_CT.SetRowCellValue(gridView_CT.FocusedRowHandle, "IDTHUOC", lkpBietDuoc.EditValue);
                        gridView_CT.SetRowCellValue(gridView_CT.FocusedRowHandle, "tensp", dt.Rows[0]["Tenthuoc"]);
                    }
                }
                lkpDonViTinh.EditValue = Convert.ToInt32(dt.Rows[0]["IDDVT"].ToString());
                lkpLoaiSP.EditValue = Convert.ToInt32(dt.Rows[0]["IDSANPHAM"]);
                lkpLoaiBietDuoc.EditValue = Convert.ToInt32(dt.Rows[0]["IDLOAITHUOC"]);
                lkpNuocSanXuat.EditValue = Convert.ToInt32(dt.Rows[0]["idnsx"] == null || dt.Rows[0]["idnsx"].ToString() == "" ? 25 : dt.Rows[0]["idnsx"]);
            }

            dt_Thuoc.DefaultView.RowFilter = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa Hóa đơn không?", "Cảnh báo",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;
            //Xóa dòng
            DataRow row = ((DataRowView)m_CmG.Current).Row;
            nk.DeleteData(row["IDHDN"]);
            m_CmG.RemoveAt(m_CmG.Position);
            KhoaButton(false);

        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            m_CmCT.EndCurrentEdit();
            m_CmG.EndCurrentEdit();
            if (SaveXml())
            {
                m_IsEditable = m_IsAddNew = false;
                SetEditable(false);
                TongTienTheoDong();
                RefreshData();
                soid_goc++;
            }
            KhoaButton(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            m_IsEditable = true;
            KhoaButton(true);
            gridView_CT.FocusedRowHandle = GridControl.AutoFilterRowHandle;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable dt_X = ((DataView)gridView_CT.DataSource).ToTable();
            string strReport = "\\Report\\baocaonhansu.repx";
            XtraReport xtra_report = new XtraReport();
            xtra_report.Parameters.Clear();
            string file = Application.StartupPath + strReport;
            xtra_report.LoadLayout(file);
            xtra_report.DataSource = dt_X;
            GPP_DungChung_HL.Form.FrmXtraReportViewer rpt = new GPP_DungChung_HL.Form.FrmXtraReportViewer(xtra_report);
            rpt.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (m_IsAddNew || m_IsEditable) { MessageBox.Show("Bạn đang hãy hủy lưu trước khi thoát", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            m_DsResult.Dispose();
            this.Close();
        }

        private void ThemDongMoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_IsEditable || m_IsAddNew)
            {
                m_CmCT.AddNew();
                DataRow rw = ((DataRowView)m_CmCT.Current).Row;
                if (m_IsAddNew)
                {
                    rw["FLAG"] = 0;
                }
                else
                    if (m_IsEditable)
                {
                    rw["FLAG"] = 1;
                }
                else rw["FLAG"] = 0;
                XoaDuLieu();
            }
            else
                return;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            XoaDuLieu();
            //flag = true;
            tongtien = 0;
            lkpThueVAT.EditValue = Convert.ToDecimal(5);
            KhoaButton(true);
            m_IsAddNew = true;
            m_CmG.AddNew();
            m_CmCT.AddNew();
            idGoc = soid_goc + 1;
            ((DataRowView)m_CmG.Current).Row["IDHDN"] = idGoc;
            //Setedit
            m_CmG.EndCurrentEdit();
            m_CmCT.EndCurrentEdit();
            soid_goc = idGoc;
            txtMSHĐ.Focus();
        }

        private void btnHuyLuu_Click(object sender, EventArgs e)
        {
            gridView_CT.CancelUpdateCurrentRow();
            m_CmCT.RemoveAt(m_CmCT.Position);
            if (m_IsAddNew)
            {
                m_CmG.RemoveAt(m_CmG.Position);
                m_IsAddNew = false;
            }
            m_CmG.CancelCurrentEdit();
            m_CmCT.CancelCurrentEdit();
            KhoaButton(false);
            m_IsEditable = m_IsAddNew = false;
        }

        private void btnLoadDL_Click(object sender, EventArgs e)
        {
            tu_ngay = Convert.ToDateTime(dtmTuNgayRL.EditValue);
            den_ngay = Convert.ToDateTime(dtmDenNgayRL.EditValue);
            RefreshData();
        }
        #endregion
    }
}