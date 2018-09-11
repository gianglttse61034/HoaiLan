using System;
using DevExpress.XtraBars;

namespace GPP_Application_HL.DanhMuc
{
    partial class DanhMuc_NhaCungCapEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhMuc_NhaCungCapEdit));
            this.layoutControl_Top = new DevExpress.XtraLayout.LayoutControl();
            this.txtFax = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barThem = new DevExpress.XtraBars.BarButtonItem();
            this.barXoaTrang = new DevExpress.XtraBars.BarButtonItem();
            this.barSua = new DevExpress.XtraBars.BarButtonItem();
            this.barXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.txtSoDKDK = new DevExpress.XtraEditors.TextEdit();
            this.txtDienThoaiNCC = new DevExpress.XtraEditors.TextEdit();
            this.txtGhiChu = new DevExpress.XtraEditors.TextEdit();
            this.txtDiaChiNCC = new DevExpress.XtraEditors.TextEdit();
            this.txtTenNCC = new DevExpress.XtraEditors.TextEdit();
            this.txtMa_NCC = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridConTrol_CT = new DevExpress.XtraGrid.GridControl();
            this.gridView_CT = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl_Top)).BeginInit();
            this.layoutControl_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDKDK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienThoaiNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChiNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_NCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridConTrol_CT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_CT)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl_Top
            // 
            this.layoutControl_Top.Controls.Add(this.txtFax);
            this.layoutControl_Top.Controls.Add(this.txtSoDKDK);
            this.layoutControl_Top.Controls.Add(this.txtDienThoaiNCC);
            this.layoutControl_Top.Controls.Add(this.txtGhiChu);
            this.layoutControl_Top.Controls.Add(this.txtDiaChiNCC);
            this.layoutControl_Top.Controls.Add(this.txtTenNCC);
            this.layoutControl_Top.Controls.Add(this.txtMa_NCC);
            this.layoutControl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl_Top.Location = new System.Drawing.Point(0, 0);
            this.layoutControl_Top.Name = "layoutControl_Top";
            this.layoutControl_Top.Root = this.layoutControlGroup1;
            this.layoutControl_Top.Size = new System.Drawing.Size(990, 116);
            this.layoutControl_Top.TabIndex = 0;
            this.layoutControl_Top.Text = "layoutControl1";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(893, 60);
            this.txtFax.MenuManager = this.barManager1;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(85, 20);
            this.txtFax.StyleController = this.layoutControl_Top;
            this.txtFax.TabIndex = 10;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barThem,
            this.barXoaTrang,
            this.barSua,
            this.barXoa,
            this.barThoat});
            this.barManager1.MaxItemId = 5;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barThem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barXoaTrang),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSua),
            new DevExpress.XtraBars.LinkPersistInfo(this.barXoa),
            new DevExpress.XtraBars.LinkPersistInfo(this.barThoat)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barThem
            // 
            this.barThem.Caption = "Thêm";
            this.barThem.Glyph = ((System.Drawing.Image)(resources.GetObject("barThem.Glyph")));
            this.barThem.Id = 0;
            this.barThem.Name = "barThem";
            this.barThem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barThem_ItemClick);
            // 
            // barXoaTrang
            // 
            this.barXoaTrang.Caption = "Xóa Trắng";
            this.barXoaTrang.Glyph = ((System.Drawing.Image)(resources.GetObject("barXoaTrang.Glyph")));
            this.barXoaTrang.Id = 1;
            this.barXoaTrang.Name = "barXoaTrang";
            this.barXoaTrang.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barXoaTrang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barXoaTrang_ItemClick);
            // 
            // barSua
            // 
            this.barSua.Caption = "Sửa";
            this.barSua.Glyph = ((System.Drawing.Image)(resources.GetObject("barSua.Glyph")));
            this.barSua.Id = 2;
            this.barSua.Name = "barSua";
            this.barSua.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSua_ItemClick);
            // 
            // barXoa
            // 
            this.barXoa.Caption = "Xóa";
            this.barXoa.Glyph = ((System.Drawing.Image)(resources.GetObject("barXoa.Glyph")));
            this.barXoa.Id = 3;
            this.barXoa.Name = "barXoa";
            this.barXoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barXoa_ItemClick);
            // 
            // barThoat
            // 
            this.barThoat.Caption = "Thoát";
            this.barThoat.Glyph = ((System.Drawing.Image)(resources.GetObject("barThoat.Glyph")));
            this.barThoat.Id = 4;
            this.barThoat.Name = "barThoat";
            this.barThoat.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(990, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 469);
            this.barDockControlBottom.Size = new System.Drawing.Size(990, 43);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 469);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(990, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 469);
            // 
            // txtSoDKDK
            // 
            this.txtSoDKDK.Location = new System.Drawing.Point(512, 60);
            this.txtSoDKDK.MenuManager = this.barManager1;
            this.txtSoDKDK.Name = "txtSoDKDK";
            this.txtSoDKDK.Size = new System.Drawing.Size(120, 20);
            this.txtSoDKDK.StyleController = this.layoutControl_Top;
            this.txtSoDKDK.TabIndex = 9;
            // 
            // txtDienThoaiNCC
            // 
            this.txtDienThoaiNCC.Location = new System.Drawing.Point(712, 60);
            this.txtDienThoaiNCC.MenuManager = this.barManager1;
            this.txtDienThoaiNCC.Name = "txtDienThoaiNCC";
            this.txtDienThoaiNCC.Size = new System.Drawing.Size(101, 20);
            this.txtDienThoaiNCC.StyleController = this.layoutControl_Top;
            this.txtDienThoaiNCC.TabIndex = 8;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(88, 84);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(890, 20);
            this.txtGhiChu.StyleController = this.layoutControl_Top;
            this.txtGhiChu.TabIndex = 7;
            // 
            // txtDiaChiNCC
            // 
            this.txtDiaChiNCC.Location = new System.Drawing.Point(88, 60);
            this.txtDiaChiNCC.Name = "txtDiaChiNCC";
            this.txtDiaChiNCC.Size = new System.Drawing.Size(344, 20);
            this.txtDiaChiNCC.StyleController = this.layoutControl_Top;
            this.txtDiaChiNCC.TabIndex = 6;
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(88, 36);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(890, 20);
            this.txtTenNCC.StyleController = this.layoutControl_Top;
            this.txtTenNCC.TabIndex = 5;
            // 
            // txtMa_NCC
            // 
            this.txtMa_NCC.Location = new System.Drawing.Point(88, 12);
            this.txtMa_NCC.Name = "txtMa_NCC";
            this.txtMa_NCC.Properties.ReadOnly = true;
            this.txtMa_NCC.Size = new System.Drawing.Size(890, 20);
            this.txtMa_NCC.StyleController = this.layoutControl_Top;
            this.txtMa_NCC.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(990, 116);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMa_NCC;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(970, 24);
            this.layoutControlItem1.Text = "Mã Số";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(73, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtTenNCC;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(970, 24);
            this.layoutControlItem3.Text = "Tên NCC";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(73, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtDiaChiNCC;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(424, 24);
            this.layoutControlItem6.Text = "Địa chỉ NCC";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(73, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtGhiChu;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(970, 24);
            this.layoutControlItem7.Text = "Ghi chú";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(73, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtSoDKDK;
            this.layoutControlItem4.Location = new System.Drawing.Point(424, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem4.Text = "Số ĐKĐK";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(73, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtDienThoaiNCC;
            this.layoutControlItem2.Location = new System.Drawing.Point(624, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(181, 24);
            this.layoutControlItem2.Text = "Điện thoại NCC";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(73, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtFax;
            this.layoutControlItem5.Location = new System.Drawing.Point(805, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(165, 24);
            this.layoutControlItem5.Text = "FAX";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(73, 13);
            // 
            // gridConTrol_CT
            // 
            this.gridConTrol_CT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridConTrol_CT.Location = new System.Drawing.Point(0, 116);
            this.gridConTrol_CT.MainView = this.gridView_CT;
            this.gridConTrol_CT.Name = "gridConTrol_CT";
            this.gridConTrol_CT.Size = new System.Drawing.Size(990, 353);
            this.gridConTrol_CT.TabIndex = 8;
            this.gridConTrol_CT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_CT});
            // 
            // gridView_CT
            // 
            this.gridView_CT.GridControl = this.gridConTrol_CT;
            this.gridView_CT.Name = "gridView_CT";
            this.gridView_CT.OptionsView.ShowAutoFilterRow = true;
            this.gridView_CT.OptionsView.ShowDetailButtons = false;
            this.gridView_CT.OptionsView.ShowGroupPanel = false;
            this.gridView_CT.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_CT_FocusedRowChanged);
            // 
            // DanhMuc_NhaCungCapEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 512);
            this.Controls.Add(this.gridConTrol_CT);
            this.Controls.Add(this.layoutControl_Top);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "DanhMuc_NhaCungCapEdit";
            this.Text = "DanhMuc_BietDuocEdit";
            this.Load += new System.EventHandler(this.DanhMuc_NhaCungCapEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl_Top)).EndInit();
            this.layoutControl_Top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDKDK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienThoaiNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChiNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_NCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridConTrol_CT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_CT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl_Top;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridConTrol_CT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_CT;
        private DevExpress.XtraEditors.TextEdit txtGhiChu;
        private DevExpress.XtraEditors.TextEdit txtDiaChiNCC;
        private DevExpress.XtraEditors.TextEdit txtTenNCC;
        private DevExpress.XtraEditors.TextEdit txtMa_NCC;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem barThem;
        private DevExpress.XtraBars.BarButtonItem barXoaTrang;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barSua;
        private DevExpress.XtraBars.BarButtonItem barXoa;
        private DevExpress.XtraBars.BarButtonItem barThoat;
        private DevExpress.XtraEditors.TextEdit txtFax;
        private DevExpress.XtraEditors.TextEdit txtSoDKDK;
        private DevExpress.XtraEditors.TextEdit txtDienThoaiNCC;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}