﻿using System;
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
using DevExpress.XtraGrid;
using BLL_GPP;
using BLL_GPP.DanhMuc;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;

namespace GPP_Application_HL
{
    public partial class FrmXuatHoaDon_New : DevExpress.XtraEditors.XtraForm
    {
        #region  Khai báo biến toàn cục.
        private decimal TongTien = 0;
        private int soid_goc = 0, soid_ct = 0, idCT_Max = 0, idGoc = 0, maxid = 0;
        private string m_TableMaster = "HOADONXUAT", m_TableDetail = "CTHDX_THUOC";
        CurrencyManager m_CmG, m_CmCT;
        private DateTime tu_ngay, den_ngay;
        private DataRow rowSolo;
        private bool flag;
        private DataSet m_DsResult;
        private DataTable dt_Thuoc, dt_NCC, dt_loaiSP, dt_LoaiThuoc, dt_LyDo, dt_BacSi, dt_DVT, dt_theoID, dt_KH;


        private bool m_IsEditable = false, m_IsAddNew = false;

        private BLLXuat_Kho nk;
        private BLL_DanhMuc dm;
        #endregion

        public FrmXuatHoaDon_New(DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();
            nk = new BLLXuat_Kho();
            dm = new BLL_DanhMuc();
            dtmNgayLapHoaDon.Properties.Mask.EditMask = "dd/MM/yyyy";
            dtmNgayLapHoaDon.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            dtmNgayLapHoaDon.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtmNgayXuat.Properties.Mask.EditMask = "dd/MM/yyyy";
            dtmNgayXuat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            dtmNgayXuat.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtSoTon.Properties.Mask.MaskType = txtChiPhiChiTra.Properties.Mask.MaskType = txtGiaBan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtSoTon.Properties.Mask.UseMaskAsDisplayFormat = txtGiaBan.Properties.Mask.UseMaskAsDisplayFormat = txtChiPhiChiTra.Properties.Mask.UseMaskAsDisplayFormat = true;

            tu_ngay = tuNgay;
            den_ngay = denNgay;
        }
        private void FrmXuatHoaDon_New_Load(object sender, EventArgs e)
        {
            KhoaButton(false);
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += delegate { soid_goc = Convert.ToInt32(dm.DanhMuc_TOPID("IDHDX", "HOADONXUAT").Rows[0]["MAXID"]); };
            bw.DoWork += delegate { soid_ct = Convert.ToInt32(dm.DanhMuc_TOPID("IDCTXUAT", "CTHDX_THUOC").Rows[0]["MAXID"]); };
            bw.DoWork += delegate { dt_Thuoc = dm.DanhMuc_Thuoc(); };

            bw.DoWork += delegate { dt_NCC = dm.DanhMuc_NCC(); };
            bw.DoWork += delegate { dt_LyDo = dm.DanhMuc_LyDo(); };
            bw.DoWork += delegate { dt_BacSi = dm.DanhMuc_BACSI(); };
            bw.DoWork += delegate { dt_loaiSP = dm.DanhMuc_LOAISP(); };
            bw.DoWork += delegate { dt_KH = dm.DanhMuc_KHACHHANG(); };
            bw.DoWork += delegate { dt_LoaiThuoc = dm.DanhMuc_LOAITHUOC(); };
            bw.DoWork += delegate { dt_DVT = dm.DanhMuc_DVT(); };
            bw.DoWork += delegate { m_DsResult = nk.ConnectData(tu_ngay, den_ngay); };
            bw.RunWorkerCompleted += delegate
            {
                DataTable lydoXuat = new DataTable();
                lydoXuat.Columns.Add("IDLYDO", typeof(int));
                lydoXuat.Columns.Add("LYDO", typeof(string));
                lydoXuat.Rows.Add(new object[] { 4, "Xuất hàng" });
                lydoXuat.Rows.Add(new object[] { 10, "Xuất kho" });

                #region Format lookup
                lkpSoLo.Properties.Columns.Clear();
                lkpSoLo.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("SOLO", 100, "SÔ LÔ")
                         ,new LookUpColumnInfo("TonKho", 100, "TỒN KHO")
                          ,new LookUpColumnInfo("HANSUDUNG", 100, "HẠN SỬ DỤNG")
                    });

                lkpSoLo.Properties.DisplayMember = "SOLO";
                lkpSoLo.Properties.ValueMember = "SOLO";
                //lkpSoLo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                //lkpSoLo.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                //lkpSoLo.Properties.DropDownRows = 10;
                lkpSoLo.Properties.NullText = "";
                lkpSoLo.Properties.ShowHeader = true;

                lkpLyDoXuat.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("LYDO", 250, "Tên")
                    });
                lkpLyDoXuat.Properties.DisplayMember = "LYDO";
                lkpLyDoXuat.Properties.ValueMember = "IDLYDO";
                lkpLyDoXuat.Properties.NullText = "";
                lkpLyDoXuat.Properties.ShowHeader = false;
                lkpLyDoXuat.Properties.DataSource = lydoXuat;

                lkpKhachHang.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("TENKH", 250, "Tên")
                    });
                lkpKhachHang.Properties.DisplayMember = "TENKH";
                lkpKhachHang.Properties.ValueMember = "IDKHACHHANG";
                lkpKhachHang.Properties.NullText = "";
                lkpKhachHang.Properties.ShowHeader = false;
                lkpKhachHang.Properties.DataSource = dt_KH;

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

                lkpDVT.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                        new LookUpColumnInfo("TENDVT", 250, "Tên")
                    });
                lkpDVT.Properties.DisplayMember = "TENDVT";
                lkpDVT.Properties.ValueMember = "IDDVT";
                lkpDVT.Properties.NullText = "";
                lkpDVT.Properties.ShowHeader = false;
                lkpDVT.Properties.DataSource = dt_DVT;

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
              
                SetProgressbar(false);
            };
            bw.RunWorkerAsync();
            SetProgressbar(true);
            bw.Dispose();
        }

        public void XoaDuLieu()
        {
            lkpLoaiSP.EditValue = null;
            lkpBietDuoc.EditValue = null;
            lkpLoaiBietDuoc.EditValue = null;
            txtCachDung.EditValue = "";
            txtChanBenh.EditValue = "";
            
            txtGiaBan.EditValue = 0;
            if (m_IsAddNew && !m_IsEditable)
            {
                txtBacSi.EditValue = "";
                txtChiPhiChiTra.EditValue = "";
                txtDiaChi.EditValue = "";
                txtMaHoaDonXuat.EditValue = "";
                txtSDT.EditValue = "";
                chkNam.Checked = true;
                chkNu.Checked = false;
                dtmNgayLapHoaDon.EditValue = "";
                dtmNgayXuat.EditValue = "";
                lkpKhachHang.EditValue = "";
                txtTuoi.EditValue = 0;
                txtViTri.EditValue = "";
            }
            txtSoLuongXuat.EditValue = 0;
            txtSoTon.EditValue = 0;

            


            
        }

        public bool KiemTraDuLieu()
        {
            if(dtmNgayXuat.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn ngày xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;

            }
            if (dtmNgayLapHoaDon.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn ngày lập HD xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtSoLuongXuat.EditValue == null )
            {
                MessageBox.Show("Vui lòng nhập số lượng xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void SetEditable(bool bEdit) // True => mở khóa false la khóa control
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
                    if (((TextEdit)ctr).Name == "txtChiPhiChiTra")
                        return;

                    ((TextEdit)ctr).Properties.ReadOnly = !bEdit;
                }
            }
            foreach (Control ctr in layoutControl_Mid.Controls)
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
                    if (((TextEdit)ctr).Name == "txtGiaBan" || ((TextEdit)ctr).Name == "txtSoTon") return;
                    ((TextEdit)ctr).Properties.ReadOnly = !bEdit;
                }
            }
        }

        public void KhoaButton(bool tf) // x false => khởi tạo
        {
            //=> Khóa các button Thêm CT,Lưu HD,Hủy lưu,sửa hiện,xóa hiện
            if (tf == false) // mới khởi tạo form
            {
                SetEditable(tf);
                btnHuyLuu.Enabled = tf; //btnIn.Enabled = !tf;
                btnThemChiTiet.Enabled = tf; btnSua.Enabled = !tf;
                btnLuuHD.Enabled = tf; btnThemMoi.Enabled = !tf;
                btnHuyLuu.Enabled = tf; btnThoat.Enabled = !tf; btnXoa.Enabled = !tf;
                lkpBietDuoc.Enabled = tf; lkpLyDoXuat.Enabled = tf;
            }
            else// Khi nhấn nút thêm mới // x= true => thêm mới
            {
                SetEditable(tf);
                btnHuyLuu.Enabled = tf; ///btnIn.Enabled = tf;
                btnThemChiTiet.Enabled = tf; btnSua.Enabled = !tf;
                btnLuuHD.Enabled = tf; btnThemMoi.Enabled = !tf;
                btnHuyLuu.Enabled = tf; btnThoat.Enabled = tf; btnXoa.Enabled = tf;
                lkpBietDuoc.Enabled = tf; lkpLyDoXuat.Enabled = tf;
            }

            //=> nhấn nút thêm mới => Thêm CT và Lưu HD và Hủy hiện lên, sửa ẩn đi .. => khóa nút thêm mới


        }

        public void SetProgressbar(bool flag)
        {
            if (layoutControl_Main.InvokeRequired)
            {
                layoutControl_Main.Invoke((MethodInvoker)delegate
                {
                    //hiện progressbar
                    if (flag)
                    {
                        groupControl_Progress.BringToFront();
                    }
                    else
                        groupControl_Progress.SendToBack();

                    layoutControl_Main.Enabled = !flag;
                });
            }

            //hiện progressbar
            if (flag)
            {
                groupControl_Progress.BringToFront();
            }
            else
                groupControl_Progress.SendToBack();

            layoutControl_Main.Enabled = !flag;
        }

        public void TinhTongTien()
        {
            TongTien = 0; // RefeshTongTien
            if (gridViewCT.RowCount <= 0) return;
            DataTable dt = ((DataView)gridViewCT.DataSource).ToTable();
            foreach (DataRow drw in dt.Rows)
            {
                TongTien += Convert.ToDecimal(drw["DONGIAX"]) * Convert.ToDecimal(drw["SOLUONGXUAT"]);
            }
        }

        public decimal LayTongCong_TheoDong(int id)
        {
            DataRow row = m_DsResult.Tables["ct"].Rows[id];
            decimal donGia = Convert.ToDecimal(row["DONGIAX"]);
            decimal SoLuongXuat = Convert.ToDecimal(row["SOLUONGXUAT"]);
            return donGia * SoLuongXuat;
        }

        public void LoadLayout()
        {

            gridViewCT.Columns.Clear();
            gridView_G.Columns.Clear();
            GridHelper.FormatGrid(gridView_G,
            "IDHDX", "IDHDX", 100, "", false,
            "IDKHACHHANG", "KHÁCH HÀNG", 100, GridHelper.LookupEDIT, true, dt_KH, "TENKH", "IDKHACHHANG",
            "TENHDX", "Tên HĐX", 100, "", true,
            "NGAYXUAT", "NGÀY XUẤT", 100, GridHelper.TextEdit_Mod, true, GridHelper.DateTimeMOD, 50, "Ola",
            "NGAYLAP", "NGÀY LẬP", 100, GridHelper.TextEdit_Mod, true, GridHelper.DateTimeMOD, 50, "Ola",
            "Lydoxuat", "Lý do xuất", 100, GridHelper.LookupEDIT, true, dt_LyDo, "Lydo", "Idlydo",
            "TongTien_HDX", "Tổng tiền HDX", 100, GridHelper.TextEdit_Mod, true, GridHelper.Numberic, 50, "N2",
            "toathuoc", "TOA THUỐC ", 100, "", false,
            "Idnhanvien", "Idnhanvien", 100, "", false,
            "TenBacSi", "TenBacSi", 100, "", false,
            "Benh", "Benh", 100, "", false,
            "IdBacsi", "TÊN BÁC SĨ", 100, GridHelper.LookupEDIT, true, dt_BacSi, "TENBACSI", "IDBACSI",
            "daxoa", "daxoa", 100, "", false
            );

            GridHelper.FormatGrid(gridViewCT,
            "IDCTXUAT", "IDCTXUAT", 100, "", false,
            "IDHDX", "IDHDX", 100, "", false,
            "IDLSP", "Loại SP", 100, GridHelper.LookupEDIT, true, dt_loaiSP, "TENSP", "IDSANPHAM",
            "IDTHUOC", "Tên thuốc", 200, GridHelper.LookupEDIT, true, dt_Thuoc, "TENTHUOC", "IDTHUOC",
            "SOLO", "SOLO", 100, "", true,
            "IDKHUYENMAI", "IDKHUYENMAI", 100, "", false,
            "IDDONGIA", "IDDONGIA", 100, "", false,
            "DONGIAX", "Giá bán", 100, GridHelper.TextEdit_Mod, true, GridHelper.Numberic, 50, "N2",
            "SOLUONGXUAT", "số lượng xuất", 100, GridHelper.TextEdit_Mod, true, GridHelper.Numberic, 50, "N0",
            "TongTien_ct", "Tiền thuốc", 100, GridHelper.TextEdit_Mod, true, GridHelper.Numberic, 50, "N2",
            "HANDUNG", "Hạn dùng", 100, GridHelper.TextEdit_Mod, true, GridHelper.DateTimeMOD, 50, "Ola",
            "QUYCACHXUAT", "Quy cách xuất", 100, "", false,
            "IDTEMP", "IDTEMP", 100, "", false,
            "IDHDN", "IDHDN", 100, "", false,
            "CACHDUNG", "Cách dùng", 100, "", false,
            "daxoa", "daxoa", 100, "", false

);
         
            gridViewCT.ColumnPanelRowHeight = 40;
            gridViewCT.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridViewCT.Appearance.HeaderPanel.Options.UseTextOptions = true;


            gridView_G.ColumnPanelRowHeight = 40;
            gridView_G.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView_G.Appearance.HeaderPanel.Options.UseTextOptions = true;

            foreach (GridColumn colum in gridView_G.Columns)
            {
                colum.OptionsColumn.AllowEdit = false;
            }
            foreach (GridColumn colum in gridViewCT.Columns)
            {
                colum.OptionsColumn.AllowEdit = false;
                if (colum.FieldName == "IDTHUOC" )
                {
                    colum.Fixed = FixedStyle.Left;
                }
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
                //binding data
                BindingData();
                /*---------------------------*/
                FindForm().Activate();
            };
            bw.RunWorkerAsync();
            bw.Dispose();
        }

        private void gridViewCT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (m_IsAddNew) return;
            DataRow rw = gridViewCT.GetDataRow(gridViewCT.FocusedRowHandle);
            if (rw != null)
                BindingData_CT(rw);
            else
                return;
        }

        private bool SaveXml()
        {

            gridViewCT.ClearColumnsFilter();
            gridViewCT.FocusedRowHandle = GridControl.AutoFilterRowHandle;

            //tạo xml cho phần gốc: Stat=0: delete phiếu, Stat=1: thêm mới phiếu, Stat=2: cập nhật phiếu
            StringBuilder xml_g = new StringBuilder();
            m_CmG.EndCurrentEdit();
            m_CmCT.EndCurrentEdit();
            DataRow rowNew_g = ((DataRowView)m_CmG.Current).Row;
            soid_goc = idGoc;

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
            DataTable dt = ((DataView)gridViewCT.DataSource).ToTable();
            xml_ct.AppendLine("<Root>");
            //đưa dữ liệu các column vào xml
            foreach (DataRow row in dt.Rows)
            {
                idCT_Max = soid_ct + 1;
                DataRow rowNew_ct = row;
                if (m_IsAddNew)
                {
                    row["IDCTXUAT"] = idCT_Max;
                    soid_ct = idCT_Max;
                }
                // nếu đang sửa là true => thì thêm dòng mới
                if (Convert.ToBoolean(row["IDTEMP"]) == true)
                { row["IDCTXUAT"] = idCT_Max; soid_ct = idCT_Max; row["IDTEMP"] = 0; }

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
                dt = nk.InsertData(rowNew_g["IDHDX"], xml_g, xml_ct, gridViewCT.RowCount);
            else
            if (m_IsEditable)//chỉnh sửa
                dt = nk.UpdateData(rowNew_g["IDHDX"], xml_g, xml_ct);

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
                MessageBox.Show(string.Format(" Lưu thất bại"),
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;

            #endregion
        }

        private void txtSoLuongXuat_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSoLuongXuat.EditValue == null || !m_IsEditable || !m_IsAddNew|| !flag) return;
            gridViewCT.SetRowCellValue(gridViewCT.FocusedRowHandle, "SOLUONGXUAT",txtSoLuongXuat.EditValue);

        }

        private void gridView_G_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TinhTongTien();
            txtChiPhiChiTra.EditValue = TongTien;
        }

        private void XoaDongChiTietToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridViewCT.FocusedRowHandle < 0) return;
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;
            gridViewCT.DeleteRow(gridViewCT.FocusedRowHandle);
            TinhTongTien();
            txtChiPhiChiTra.EditValue = TongTien;
        }

        private void gridViewCT_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            //if (e.Column.FieldName == "TongCong" && e.IsGetData)
            //    e.Value = LayTongCong_TheoDong(e.ListSourceRowIndex);
        }

        private void txtGiaBan_EditValueChanged(object sender, EventArgs e)
        {
            if (txtGiaBan.EditValue == null ||!m_IsEditable ||!m_IsAddNew) return;
            gridViewCT.SetRowCellValue(gridViewCT.FocusedRowHandle, "DONGIAX", txtGiaBan.EditValue);
        }

        public void LayTonTheoIDTHUOC(int IDTHUOC)
        {
            int tong = 0;
            dt_theoID = dm.LaySoTon(IDTHUOC);
            foreach (DataRow drw in dt_theoID.Rows)
            {
                tong += Convert.ToInt32(drw["TonKho"]);
            }
            txtSoTon.EditValue = tong;
        }

        private void lkpSoLo_EditValueChanged(object sender, EventArgs e)
        {
            if (!m_IsAddNew && !m_IsEditable) return;
            DataRowView rowView = (DataRowView)lkpSoLo.GetSelectedDataRow();
            rowSolo = rowView.Row;
        }

        private void BindingData_CT(DataRow drw)
        {
            TongTien = TongTien - (Convert.ToDecimal(drw["SOLUONGXUAT"]) * Convert.ToDecimal(drw["DONGIAX"]));
            txtGiaBan.EditValue = Convert.ToDecimal(drw["DONGIAX"]);
            lkpSoLo.Text = drw["SOLO"].ToString();
            lkpLoaiSP.EditValue = Convert.ToInt32(drw["IDLSP"]);
            lkpBietDuoc.EditValue = Convert.ToInt32(drw["IDTHUOC"]);
            txtCachDung.EditValue = drw["CACHDUNG"];
            txtSoLuongXuat.EditValue = drw["SOLUONGXUAT"];

        }

        private void BindingData()
        {
            Form frm = FindForm();
            if (frm != null)
            {
                m_CmG = (CurrencyManager)frm.BindingContext[m_DsResult, "g"];
                m_CmCT = (CurrencyManager)frm.BindingContext[m_DsResult, "g.R_ct"];
            }
            gridControl_G.DataSource = m_DsResult;
            gridControl_G.DataMember = "g";
            gridControl_CT.DataSource = m_DsResult;
            gridControl_CT.DataMember = "g.R_ct";

            foreach (Control control in layoutControl_Top.Controls)
            {
                if (control is LabelControl) continue;
                control.DataBindings.Clear();
            }
            foreach (Control control in layoutControl_Mid.Controls)
            {
                if (control is LabelControl) continue;
                control.DataBindings.Clear();
            }
            txtMaHoaDonXuat.DataBindings.Clear();
            txtMaHoaDonXuat.DataBindings.Add("EditValue", m_DsResult, "g.TENHDX");
            txtBacSi.DataBindings.Add("EditValue", m_DsResult, "g.TenBacSi");
            lkpLyDoXuat.DataBindings.Add("EditValue", m_DsResult, "g.Lydoxuat");
            lkpKhachHang.DataBindings.Add("EditValue", m_DsResult, "g.IDKHACHHANG");
            dtmNgayLapHoaDon.DataBindings.Add("EditValue", m_DsResult, "g.NGAYLAP");
            dtmNgayXuat.DataBindings.Add("EditValue", m_DsResult, "g.NGAYXUAT");
            txtChiPhiChiTra.DataBindings.Add("EditValue", m_DsResult, "g.TongTien_HDX");
        }

        /// <summary>
        /// Chèn dòng
        /// </summary>
        /// <param name="drw"></param>
        private void InsertRow(DataRow drw)
        {
            if (m_IsAddNew)
                if (!gridViewCT.IsFocusedView) gridViewCT.Focus();
            if (!gridViewCT.UpdateCurrentRow()) return;
            m_DsResult.Tables["ct"].Rows.Add(drw);
            gridViewCT.UpdateCurrentRow();
            gridViewCT.FocusedRowHandle = gridViewCT.FocusedRowHandle - 1;
            gridViewCT.Focus();
        }

        /// <summary>
        /// Thêm dòng mới
        /// </summary>
        public void NewRow()
        {
            if (!m_IsAddNew && !m_IsEditable) return;
            gridViewCT.AddNewRow();
            // Nếu đang sửa => IDTEMP : true
            if (m_IsEditable)
                gridViewCT.SetRowCellValue(gridViewCT.FocusedRowHandle, "IDTEMP", 1);
            gridViewCT.SetRowCellValue(gridViewCT.FocusedRowHandle, "IDHDX", idGoc);
            gridViewCT.GridControl.BeginInvoke((MethodInvoker)delegate { gridViewCT.ShowEditor(); });
            ; // tăng số id lên
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
                DataTable dt_grid = ((DataView)(gridViewCT.DataSource)).ToTable();
                foreach (DataRow drw in dt_grid.Rows )
                {
                    if (drw["IDTHUOC"].ToString() == lkpBietDuoc.EditValue.ToString())
                    {
                        flag = false;
                        break;
                    }
                        
                }
                if (m_IsEditable && flag==true)
                {
                    gridViewCT.SetRowCellValue(gridViewCT.FocusedRowHandle, "IDTHUOC", lkpBietDuoc.EditValue);
                    gridViewCT.SetRowCellValue(gridViewCT.FocusedRowHandle, "QUYCACHXUAT", dt.Rows[0]["Tenthuoc"]);
                }
                LayTonTheoIDTHUOC(Convert.ToInt32(lkpBietDuoc.EditValue));
                lkpDVT.EditValue = Convert.ToInt32(dt.Rows[0]["IDDVT"].ToString());
                lkpLoaiSP.EditValue = Convert.ToInt32(dt.Rows[0]["IDSANPHAM"]);
                lkpLoaiBietDuoc.EditValue = Convert.ToInt32(dt.Rows[0]["IDLOAITHUOC"]);
                if (dt_theoID != null)
                {
                    decimal maxDonGia = 0;

                    lkpSoLo.Properties.DataSource = dt_theoID;

                    if (dt_theoID.Rows.Count > 0 && (m_IsAddNew || m_IsEditable))
                    {
                        foreach (DataRow drw in dt_theoID.Rows)
                        {
                            if (maxDonGia < Convert.ToDecimal(drw["DONGIABAN"]))
                            {
                                maxDonGia = Convert.ToDecimal(drw["DONGIABAN"]);
                            }
                        }
                            txtGiaBan.EditValue = maxDonGia;
                    }
                }
            }

            dt_Thuoc.DefaultView.RowFilter = "";
        }

        private void btnXoaTrang_Click(object sender, EventArgs e)
        {
            XoaDuLieu();
            flag = false; // tất cả các control không binding
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            if(!KiemTraDuLieu()) return;
            DataRow row_G = ((DataRowView)m_CmG.Current).Row;
            int soluong_x = Convert.ToInt32(txtSoLuongXuat.EditValue);
            if (!m_IsEditable && !m_IsAddNew) return;
            if (dt_theoID == null) { MessageBox.Show("Thuốc không tồn không thể xuất"); return; }
            if (lkpSoLo.EditValue == null) { MessageBox.Show("Vui lòng chọn số lô","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            DataRow rw = m_DsResult.Tables["ct"].NewRow();
            if (m_IsAddNew)
            {
                rw["IDHDX"] = idGoc;
                rw["IDTEMP"] = 0;
            }
            else
            if (m_IsEditable)
            {
                rw["IDHDX"] = row_G["IDHDX"];
                rw["IDTEMP"] = 1;
            }
            else rw["IDTEMP"] = 0;
            rw["IDTHUOC"] = lkpBietDuoc.EditValue;
            rw["IDHDN"] = rowSolo["IDHDN"];
            rw["SOLO"] = lkpSoLo.EditValue;
            rw["IDLSP"] = lkpLoaiSP.EditValue;
            rw["IDKHUYENMAI"] = 0;
            rw["IDDONGIA"] = 0;
            rw["DONGIAX"] = txtGiaBan.EditValue;
            rw["HANDUNG"] = rowSolo["HANSUDUNG"];
            rw["SOLUONGXUAT"] = txtSoLuongXuat.EditValue;
            rw["QUYCACHXUAT"] = lkpDVT.Text;
            rw["CACHDUNG"] = txtCachDung.EditValue;
            rw["daxoa"] = 0;
            rw["TongTien_ct"] = Convert.ToDecimal(rw["DONGIAX"]) * Convert.ToDecimal(rw["SOLUONGXUAT"]);
            m_DsResult.Tables["ct"].LoadDataRow(rw.ItemArray, LoadOption.OverwriteChanges);
            TinhTongTien();
            txtChiPhiChiTra.EditValue = TongTien;
            flag = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa Hóa đơn không?", "Cảnh báo",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;
            //Xóa dòng
            DataRow row = ((DataRowView)m_CmG.Current).Row;
            nk.DeleteData(row["IDHDX"]);
            m_CmG.RemoveAt(m_CmG.Position);
            KhoaButton(false);
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            TinhTongTien();
            txtChiPhiChiTra.EditValue = TongTien;
            if (SaveXml())
            {
                m_IsEditable = m_IsAddNew = false;
                SetEditable(false);
            }
            soid_goc++;
            KhoaButton(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            m_IsEditable = true;
            KhoaButton(true);
            flag = true; // refesh lại
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable dt = ((DataView)gridViewCT.DataSource).ToTable();
            dt.Columns.Add("tenthuoc",typeof(string));
            foreach (DataRow rw in dt.Rows)
            {
                string str = string.Empty;
                dt_Thuoc.DefaultView.RowFilter = string.Format("IDTHUOC ={0}",rw["IDTHUOC"]);
                if (dt_Thuoc.DefaultView.ToTable() != null)
                {
                    str = (dt_Thuoc.DefaultView.ToTable()).Rows[0]["TENTHUOC"].ToString();
                    rw["tenthuoc"] = str;
                }
                dt_Thuoc.DefaultView.RowFilter = "";

            }
            DataRow rowNew_g = ((DataRowView)m_CmG.Current).Row;
            string strReport = "\\Report\\RptHoaDonXuat.repx";
            string ma_kh = string.Empty, ten_kh= string.Empty,diachi = string.Empty;
            dt_KH.DefaultView.RowFilter = string.Format("IDKHACHHANG = {0}", rowNew_g["IDKHACHHANG"]);
            if (dt_KH.DefaultView.ToTable() != null)
            {
                ma_kh = dt_KH.DefaultView.ToTable().Rows[0]["MAKHACHHANG"].ToString();
                ten_kh = dt_KH.DefaultView.ToTable().Rows[0]["TENKH"].ToString();
                diachi = dt_KH.DefaultView.ToTable().Rows[0]["DIACHIKH"].ToString();
            }
            XtraReport xtra_report = new XtraReport();
            xtra_report.Parameters.Clear();
            string file = Application.StartupPath + strReport;
            xtra_report.LoadLayout(file);
            GPP_DungChung_HL.Function.CreateXtraReportParameters(xtra_report,
                                 "m_kh", typeof(string),ma_kh,
                                 "khachhang", typeof(string), ten_kh,
                                 "diachi", typeof(string), diachi,
                                "tieude", typeof(string), "PHIẾU XUẤT THUỐC",
                                "ngayxuat", typeof(string), Convert.ToDateTime(rowNew_g["ngayxuat"]).ToString("dd/MM/yyyy")
                                  );
            xtra_report.DataSource = dt;
            GPP_DungChung_HL.Form.FrmXtraReportViewer rpt = new GPP_DungChung_HL.Form.FrmXtraReportViewer(xtra_report);
            rpt.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            m_DsResult.Dispose();
            this.Close();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            gridView_G.ActiveFilter.Clear();
            gridViewCT.ActiveFilter.Clear();
            dtmNgayXuat.Focus();
            m_IsAddNew = true;
            BackgroundWorker bw = new BackgroundWorker();
            XoaDuLieu();
            bw.DoWork += delegate { maxid = dm.LaySoMaxHD("HOADONXUAT"); };
            bw.RunWorkerCompleted += delegate
           {
               txtMaHoaDonXuat.EditValue = string.Format(@"{0}{1}/{2}", DateTime.Now.Month, DateTime.Now.Year, maxid + 1);
           };
            bw.RunWorkerAsync();
            bw.Dispose();
            KhoaButton(true);
            TongTien = 0;
           
            m_CmG.AddNew();
            idGoc = soid_goc + 1;
            ((DataRowView)m_CmG.Current).Row["IDHDX"] = idGoc;
            //Setedit
            m_CmG.EndCurrentEdit();
        }

        private void btnHuyLuu_Click(object sender, EventArgs e)
        {
            gridViewCT.CancelUpdateCurrentRow();
            m_CmCT.CancelCurrentEdit();
            if (m_IsAddNew)
            {
                m_CmG.RemoveAt(m_CmG.Position);
                m_IsAddNew = false;
            }
            m_CmG.CancelCurrentEdit();
            KhoaButton(false);
            m_IsEditable = m_IsAddNew = false;
            RefreshData();
        }
        #endregion
    }
}