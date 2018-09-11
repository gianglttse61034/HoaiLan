namespace GPP_Application_HL
{
    partial class frmTimKiem_Solo_IDTHUOC
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
            this.layoutControl_TOP = new DevExpress.XtraLayout.LayoutControl();
            this.lkpTHUOC = new DevExpress.XtraEditors.LookUpEdit();
            this.radTheoThuoc = new System.Windows.Forms.RadioButton();
            this.radTheoSoLo = new System.Windows.Forms.RadioButton();
            this.btnThucHien = new DevExpress.XtraEditors.SimpleButton();
            this.txtThongTin = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl_G = new DevExpress.XtraGrid.GridControl();
            this.gridView_G = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl_CT = new DevExpress.XtraGrid.GridControl();
            this.gridView_CT = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl_TOP)).BeginInit();
            this.layoutControl_TOP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTHUOC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThongTin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_CT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_CT)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl_TOP
            // 
            this.layoutControl_TOP.Controls.Add(this.lkpTHUOC);
            this.layoutControl_TOP.Controls.Add(this.radTheoThuoc);
            this.layoutControl_TOP.Controls.Add(this.radTheoSoLo);
            this.layoutControl_TOP.Controls.Add(this.btnThucHien);
            this.layoutControl_TOP.Controls.Add(this.txtThongTin);
            this.layoutControl_TOP.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl_TOP.Location = new System.Drawing.Point(0, 0);
            this.layoutControl_TOP.Name = "layoutControl_TOP";
            this.layoutControl_TOP.Root = this.layoutControlGroup1;
            this.layoutControl_TOP.Size = new System.Drawing.Size(887, 49);
            this.layoutControl_TOP.TabIndex = 0;
            this.layoutControl_TOP.Text = "layoutControl1";
            // 
            // lkpTHUOC
            // 
            this.lkpTHUOC.Location = new System.Drawing.Point(506, 12);
            this.lkpTHUOC.Name = "lkpTHUOC";
            this.lkpTHUOC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpTHUOC.Size = new System.Drawing.Size(200, 20);
            this.lkpTHUOC.StyleController = this.layoutControl_TOP;
            this.lkpTHUOC.TabIndex = 9;
            // 
            // radTheoThuoc
            // 
            this.radTheoThuoc.Location = new System.Drawing.Point(95, 12);
            this.radTheoThuoc.Name = "radTheoThuoc";
            this.radTheoThuoc.Size = new System.Drawing.Size(105, 25);
            this.radTheoThuoc.TabIndex = 8;
            this.radTheoThuoc.TabStop = true;
            this.radTheoThuoc.Text = "Theo Tên Thuốc";
            this.radTheoThuoc.UseVisualStyleBackColor = true;
            this.radTheoThuoc.CheckedChanged += new System.EventHandler(this.radTheoThuoc_CheckedChanged);
            // 
            // radTheoSoLo
            // 
            this.radTheoSoLo.Location = new System.Drawing.Point(12, 12);
            this.radTheoSoLo.Name = "radTheoSoLo";
            this.radTheoSoLo.Size = new System.Drawing.Size(79, 25);
            this.radTheoSoLo.TabIndex = 7;
            this.radTheoSoLo.TabStop = true;
            this.radTheoSoLo.Text = "Theo Số Lô";
            this.radTheoSoLo.UseVisualStyleBackColor = true;
            this.radTheoSoLo.CheckedChanged += new System.EventHandler(this.radTheoSoLo_CheckedChanged);
            // 
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(710, 12);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(165, 22);
            this.btnThucHien.StyleController = this.layoutControl_TOP;
            this.btnThucHien.TabIndex = 6;
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // txtThongTin
            // 
            this.txtThongTin.Location = new System.Drawing.Point(319, 12);
            this.txtThongTin.Name = "txtThongTin";
            this.txtThongTin.Size = new System.Drawing.Size(125, 20);
            this.txtThongTin.StyleController = this.layoutControl_TOP;
            this.txtThongTin.TabIndex = 4;
            this.txtThongTin.EditValueChanged += new System.EventHandler(this.txtThongTin_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(887, 49);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtThongTin;
            this.layoutControlItem1.Location = new System.Drawing.Point(192, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(244, 29);
            this.layoutControlItem1.Text = "Tìm kiếm thông tin:";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(110, 20);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.radTheoSoLo;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(83, 29);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.radTheoThuoc;
            this.layoutControlItem4.Location = new System.Drawing.Point(83, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(109, 29);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnThucHien;
            this.layoutControlItem3.Location = new System.Drawing.Point(698, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(169, 29);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lkpTHUOC;
            this.layoutControlItem5.Location = new System.Drawing.Point(436, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(262, 29);
            this.layoutControlItem5.Text = "Chọn thuốc";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(55, 13);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 49);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl_G);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl_CT);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(887, 482);
            this.splitContainerControl1.SplitterPosition = 436;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl_G
            // 
            this.gridControl_G.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_G.Location = new System.Drawing.Point(0, 0);
            this.gridControl_G.MainView = this.gridView_G;
            this.gridControl_G.Name = "gridControl_G";
            this.gridControl_G.Size = new System.Drawing.Size(436, 482);
            this.gridControl_G.TabIndex = 0;
            this.gridControl_G.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_G});
            // 
            // gridView_G
            // 
            this.gridView_G.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView_G.Appearance.Row.Options.UseFont = true;
            this.gridView_G.GridControl = this.gridControl_G;
            this.gridView_G.Name = "gridView_G";
            this.gridView_G.OptionsView.ColumnAutoWidth = false;
            this.gridView_G.OptionsView.ShowAutoFilterRow = true;
            this.gridView_G.OptionsView.ShowDetailButtons = false;
            this.gridView_G.OptionsView.ShowGroupPanel = false;
            // 
            // gridControl_CT
            // 
            this.gridControl_CT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_CT.Location = new System.Drawing.Point(0, 0);
            this.gridControl_CT.MainView = this.gridView_CT;
            this.gridControl_CT.Name = "gridControl_CT";
            this.gridControl_CT.Size = new System.Drawing.Size(446, 482);
            this.gridControl_CT.TabIndex = 0;
            this.gridControl_CT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_CT});
            // 
            // gridView_CT
            // 
            this.gridView_CT.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_CT.Appearance.Row.Options.UseFont = true;
            this.gridView_CT.GridControl = this.gridControl_CT;
            this.gridView_CT.Name = "gridView_CT";
            this.gridView_CT.OptionsView.ColumnAutoWidth = false;
            this.gridView_CT.OptionsView.ShowAutoFilterRow = true;
            this.gridView_CT.OptionsView.ShowDetailButtons = false;
            this.gridView_CT.OptionsView.ShowGroupPanel = false;
            // 
            // frmTimKiem_Solo_IDTHUOC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 531);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.layoutControl_TOP);
            this.Name = "frmTimKiem_Solo_IDTHUOC";
            this.Text = "frmTimKiem_Solo_IDTHUOC";
            this.Load += new System.EventHandler(this.frmTimKiem_Solo_IDTHUOC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl_TOP)).EndInit();
            this.layoutControl_TOP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkpTHUOC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThongTin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_CT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_CT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl_TOP;
        private System.Windows.Forms.RadioButton radTheoThuoc;
        private System.Windows.Forms.RadioButton radTheoSoLo;
        private DevExpress.XtraEditors.SimpleButton btnThucHien;
        private DevExpress.XtraEditors.TextEdit txtThongTin;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl_G;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_G;
        private DevExpress.XtraGrid.GridControl gridControl_CT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_CT;
        private DevExpress.XtraEditors.LookUpEdit lkpTHUOC;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}