using System;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace PharMaSoft.Common
{
    public partial class FrmWaitting : XtraForm
    {
        private bool m_Cancel;

        public FrmWaitting()
        {
            InitializeComponent();
            Text = "Hoài Lan";
        }

        public bool Cancel
        {
            get { return m_Cancel; }
            //set { m_Cancel = value; }
        }

        private void FrmWaitting_FormClosing(object sender, FormClosingEventArgs e)
        {
            ////SetText("Đang hủy bỏ tác vụ ...");
            //////btnCancel.Enabled = false;
            ////m_Cancel = true;
            ////e.Cancel = true;
        }

        public void SetText(String text)
        {
            if (prgState.InvokeRequired)
            {
                prgState.Invoke(
                    (MethodInvoker) delegate { prgState.Text = text; }
                    );
                return;
            }
            prgState.Text = text;
        }
    }
}