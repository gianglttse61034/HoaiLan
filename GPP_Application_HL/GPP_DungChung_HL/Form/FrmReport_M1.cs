using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace PharMaSoft.DungChung.Forms
{
    public partial class FrmReport_M1 : DevExpress.XtraEditors.XtraForm
    {
        private IReport_M1 m_IReport;
        public IReport_M1 IReport
        {
            get { return m_IReport; }
        }

        private DateTime m_TuNgay, m_DenNgay;

        public FrmReport_M1(IReport_M1 iReport)
        {
            InitializeComponent();
            //ẩn progressbar
            groupControl_Progress.SendToBack();
            m_IReport = iReport;
        }

        private void FrmReport_M1_Load(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            SetText(GlobalConstant.STR_PROCESS_KHOI_TAO_DU_LIEU);
            bw.DoWork += delegate 
            {
            };
            bw.RunWorkerCompleted += delegate
            {
                //định dạng ngày
                ((RepositoryItemDateEdit)dtmTuNgay.Edit).Mask.EditMask = ((RepositoryItemDateEdit)dtmDenNgay.Edit).Mask.EditMask = GlobalVariable.DateMask;
                ((RepositoryItemDateEdit)dtmTuNgay.Edit).Mask.MaskType = ((RepositoryItemDateEdit)dtmDenNgay.Edit).Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
                ((RepositoryItemDateEdit)dtmTuNgay.Edit).Mask.UseMaskAsDisplayFormat = ((RepositoryItemDateEdit)dtmDenNgay.Edit).Mask.UseMaskAsDisplayFormat = true;
                //lấy ngày đầu tháng hiện tại
                dtmTuNgay.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtmDenNgay.EditValue = DateTime.Now;
                //lookup edit

                //tên hiển thị trên tab
                Text = m_IReport.FormTitle.ToUpper();
                //tiêu đề form
                lblTitle.Text = m_IReport.Title.ToUpper();
                //add control vào main form
                pnlMain.Controls.Add((Control)m_IReport);
                ((Control)m_IReport).Dock = DockStyle.Fill;

                /*---------------------------*/
                SetProgressbar(false);
                Activate();
            };
            bw.RunWorkerAsync();
            SetProgressbar(true);
            bw.Dispose();

        }

        #region phương thức
        
        /// <summary>
        /// hiển thị text cho progressbar
        /// </summary>
        /// <param name="text"></param>
        public void SetText(String text)
        {
            if (prgState.InvokeRequired)
            {
                prgState.Invoke((MethodInvoker)delegate { prgState.Text = text; });
                return;
            }
            prgState.Text = text;
        }

        /// <summary>
        /// ẩn / hiện progressbar
        /// </summary>
        /// <param name="flag"></param>
        public void SetProgressbar(bool flag)
        {
            if (pnlMain.InvokeRequired)
            {
                pnlMain.Invoke((MethodInvoker)delegate
                {
                    //hiện progressbar
                    if (flag)
                    {
                        groupControl_Progress.BringToFront();
                    }
                    else
                        groupControl_Progress.SendToBack();

                    pnlMain.Enabled = !flag;
                });
            }

            //hiện progressbar
            if (flag)
            {
                groupControl_Progress.BringToFront();
            }
            else
                groupControl_Progress.SendToBack();

            pnlMain.Enabled = !flag;
        }

        #endregion

        #region sự kiện

        private void FrmReport_M1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                m_IReport.Exit();
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                m_IReport.ShowDetail();
            }
            else if (e.KeyCode == Keys.F5)
            {
                if (dtmTuNgay.EditValue != null && dtmDenNgay.EditValue != null) return;
                m_TuNgay = (DateTime)dtmTuNgay.EditValue;
                m_DenNgay = (DateTime)dtmDenNgay.EditValue;
                m_IReport.RefreshData(m_TuNgay, m_DenNgay);
            }
        }

        private void FrmReport_M1_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        
        //lấy dữ liệu
        private void btnThucHien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtmTuNgay.EditValue == null && dtmDenNgay.EditValue == null) return;
            m_TuNgay = (DateTime)dtmTuNgay.EditValue;
            m_DenNgay = (DateTime)dtmDenNgay.EditValue;
            //hiển thị thông tin report
            if (m_TuNgay != m_DenNgay)
                lblTitle.Text = string.Format("{0} ({1} - {2})"
                    , m_IReport.Title, m_TuNgay.ToString("dd/MM/yyyy"), m_DenNgay.ToString("dd/MM/yyyy"));
            else
                lblTitle.Text = string.Format("{0} ({1})", m_IReport.Title, m_TuNgay.ToString("dd/MM/yyyy"));
            //lấy dữ liệu
            m_IReport.RefreshData(m_TuNgay, m_DenNgay);
        }

        //xem mẫu in
        private void btnPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_IReport.Preview();
        }

        //xuất excel
        private void btnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_IReport.ExportExcel();
        }

        //thoát
        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_IReport.Exit();
        }

        #endregion

    }
}