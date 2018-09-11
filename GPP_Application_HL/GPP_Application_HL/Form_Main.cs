using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraBars;
using System.IO;
using GPP_Application_HL.DanhMuc;
using GPP_DungChung_HL;

namespace GPP_Application_HL
{
    public partial class Form_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            DocGiaoDien_Main();
            XtraTabbedMdiManager mdiManager = new XtraTabbedMdiManager();
            mdiManager.MdiParent = this;
            var form = Application.OpenForms["FrmReport_WithoutTime"] as FrmReport_WithoutTime;
            if (form != null)
            {
                form.Activate();
            }
            FrmReport_WithoutTime frm = new FrmReport_WithoutTime(new UCReport_BaoCaoThuocCanDate());
            // Set the Parent Form of the Child window.
            frm.MdiParent = this;
            frm.Text = "Báo cáo thuốc cận date";
            // Display the new form.
            frm.Show();

        }

        private void barNhapKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = Application.OpenForms["FrmNhapHoaDon"] as FrmNhapHoaDon;
            if (frm!= null)
            {
                frm.Activate();
            }
            else
            {
                GPP_DungChung_HL.Form.FrmChonLoaiThoiGian frmTime = new GPP_DungChung_HL.Form.FrmChonLoaiThoiGian();
                if (frmTime.ShowDialog() != DialogResult.OK) return;
                FrmNhapHoaDon form = new FrmNhapHoaDon(frmTime.TuNgay,frmTime.DenNgay);
                // Set the Parent Form of the Child window.
                form.MdiParent = this;
                form.Text = "Chi Tiết Hóa Đơn Nhập";
                // Display the new form.
                form.Show();
            }
        }

        private void barXuatKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = Application.OpenForms["FrmXuatHoaDon"] as FrmXuatHoaDon;
            if (form != null)
            {
                form.Activate();
            }
            else
            {

                GPP_DungChung_HL.Form.FrmChonLoaiThoiGian frmTime = new GPP_DungChung_HL.Form.FrmChonLoaiThoiGian();
                if (frmTime.ShowDialog() != DialogResult.OK) return;
                FrmXuatHoaDon frm = new FrmXuatHoaDon(frmTime.TuNgay, frmTime.DenNgay);
                // Set the Parent Form of the Child window.
                frm.MdiParent = this;
                frm.Text = "Chi tiết hóa đơn xuất";
                // Display the new form.
                frm.Show();
            }
        }

        /// <summary>
        /// lưu giao diện đã chọn
        /// </summary>
        private void LuuGiaoDien_Main()
        {
            try
            {
                string url = String.Format(@"{0}\\HoaiLan_GPP.skin", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                //xóa file cũ
                if (File.Exists(url)) File.Delete(url);
                //tạo file mới
                StreamWriter file = File.CreateText(url);
                file.WriteLine(defaultLookAndFeel1.LookAndFeel.SkinName);
                file.Close();
            }
            catch
            {

            }
        }

        /// <summary>
        /// đọc file lưu giao diện
        /// </summary>
        /// <returns></returns>
        private bool DocGiaoDien_Main()
        {
            try
            {
                string url = String.Format(@"{0}\\HoaiLan_GPP.skin", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                //nều file không tồn tại thì bỏ qua
                if (!File.Exists(url)) return false;
                //đọc dữ liệu trong file
                StreamReader file = File.OpenText(url);
                string str = file.ReadLine();
                if (!string.IsNullOrEmpty(str))//nếu có dữ liệu thì đổi skin
                    defaultLookAndFeel1.LookAndFeel.SetSkinStyle(str);
                file.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            LuuGiaoDien_Main();
            Application.Exit();
        }

        private void barDanhMucThuoc_BietDuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = Application.OpenForms["DanhMuc_BietDuocEdit"] as DanhMuc_BietDuocEdit;
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                DanhMuc_BietDuocEdit frm = new DanhMuc_BietDuocEdit();
                // Set the Parent Form of the Child window.
                frm.MdiParent = this;
                frm.Text = "DANH MỤC CHI TIẾT BIỆT DƯỢC";
                // Display the new form.
                frm.Show();
            }
        }

        private void barTimKiem_Solo_thongtin_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = Application.OpenForms["frmTimKiem_Solo_IDTHUOC"] as frmTimKiem_Solo_IDTHUOC;
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frmTimKiem_Solo_IDTHUOC frm = new frmTimKiem_Solo_IDTHUOC();
                // Set the Parent Form of the Child window.
                frm.MdiParent = this;
                frm.Text = "TÌM KIẾM SỐ LÔ";
                // Display the new form.
                frm.Show();
            }
        }

        private void barNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = Application.OpenForms["DanhMuc_NhaCungCapEdit"] as DanhMuc_NhaCungCapEdit;
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                DanhMuc_NhaCungCapEdit frm = new DanhMuc_NhaCungCapEdit();
                // Set the Parent Form of the Child window.
                frm.MdiParent = this;
                frm.Text = "DANH MỤC CHI TIẾT NHÀ CUNG CẤP";
                // Display the new form.
                frm.Show();
            }
        }

        private void barBaoCaoThuocCanDate_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = Application.OpenForms["FrmReport_WithoutTime"] as FrmReport_WithoutTime;
            if (form != null)
            {
                form.Close();
                FrmReport_WithoutTime frm = new FrmReport_WithoutTime(new UCReport_BaoCaoThuocCanDate());
                // Set the Parent Form of the Child window.
                frm.MdiParent = this;
                frm.Text = "Báo cáo thuốc cận date";
                // Display the new form.
                frm.Show();
            }
            else
            {
                FrmReport_WithoutTime frm = new FrmReport_WithoutTime(new UCReport_BaoCaoThuocCanDate());
                // Set the Parent Form of the Child window.
                frm.MdiParent = this;
                frm.Text = "Báo cáo thuốc cận date";
                // Display the new form.
                frm.Show();
            }
        }

        private void barKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = Application.OpenForms["DanhMuc_KhachHang"] as DanhMuc_KhachHang;
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                DanhMuc_KhachHang frm = new DanhMuc_KhachHang();
                // Set the Parent Form of the Child window.
                frm.MdiParent = this;
                frm.Text = "DANH MỤC KHÁCH HÀNG";
                // Display the new form.
                frm.Show();
            }
        }

        private void barDVT_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = Application.OpenForms["DanhMuc_DVT"] as DanhMuc_DVT;
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                DanhMuc_DVT frm = new DanhMuc_DVT();
                // Set the Parent Form of the Child window.
                frm.MdiParent = this;
                frm.Text = "DANH MỤC ĐƠN VỊ TÍNH";
                // Display the new form.
                frm.Show();
            }
        }

        private void barLoaiThuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = Application.OpenForms["DanhMuc_LOAITHUOC"] as DanhMuc_LOAITHUOC;
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                DanhMuc_LOAITHUOC frm = new DanhMuc_LOAITHUOC();
                // Set the Parent Form of the Child window.
                frm.MdiParent = this;
                frm.Text = "DANH MỤC LOẠI THUỐC";
                // Display the new form.
                frm.Show();
            }
        }

        private void barBaoCaoDonGiaThuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            var form = Application.OpenForms["FrmReport_WithoutTime"] as FrmReport_WithoutTime;
            if (form != null)
            {
                form.Close();
                FrmReport_WithoutTime frm = new FrmReport_WithoutTime(new UCReport_BaoCaoThuoc_DonGia());
                // Set the Parent Form of the Child window.
                frm.MdiParent = this;
                frm.Text = "Báo cáo đơn giá thuốc";
                // Display the new form.
                frm.Show();
            }
            else
            {
                FrmReport_WithoutTime frm = new FrmReport_WithoutTime(new UCReport_BaoCaoThuoc_DonGia());
                // Set the Parent Form of the Child window.
                frm.MdiParent = this;
                frm.Text = "Báo cáo đơn giá thuốc";
                // Display the new form.
                frm.Show();
            }
        }
    }
}
