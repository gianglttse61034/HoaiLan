using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL_HeThong;

namespace GPP_DungChung_HL.Form
{
    public partial class FrmChonLoaiThoiGian : XtraForm
    {
        #region Khai báo biến (Variable Declare)

        private DateTime m_DenNgay;
        private DateTime m_TuNgay;

        #endregion Khai báo biến (Variable Declare)


        /// <summary>
        /// Constructor
        /// </summary>
        public FrmChonLoaiThoiGian()
        {
            InitializeComponent();
            d_ChonThang.DateTime = DateTime.Now;
            d_ChonNam.DateTime = DateTime.Now;
            d_ChonNgay_1.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            d_ChonNgay_2.DateTime = DateTime.Now;
            d_ChonNam.Enabled = false;
            ;
            d_ChonNgay_1.Enabled = false;
            d_ChonNgay_2.Enabled = false;
            m_TuNgay = DateTime.Now;
            m_DenNgay = DateTime.Now;
        }

        /* ==================================================================================================== */

        /// <summary>
        /// From Date
        /// </summary>
        public DateTime TuNgay
        {
            get { return m_TuNgay; }
        }

        /// <summary>
        /// To Date
        /// </summary>
        public DateTime DenNgay
        {
            get { return m_DenNgay; }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            d_ChonThang.Enabled = radioGroup1.SelectedIndex == 0;
            d_ChonNam.Enabled = radioGroup1.SelectedIndex == 1;
            d_ChonNgay_1.Enabled = radioGroup1.SelectedIndex == 2;
            d_ChonNgay_2.Enabled = radioGroup1.SelectedIndex == 2;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (radioGroup1.SelectedIndex)
            {
                case 0:
                    m_TuNgay = new DateTime(d_ChonThang.DateTime.Year, d_ChonThang.DateTime.Month, 1);
                    m_DenNgay = new DateTime(d_ChonThang.DateTime.Year, d_ChonThang.DateTime.Month,
                                           DateTime.DaysInMonth(d_ChonThang.DateTime.Year, d_ChonThang.DateTime.Month));
                    break;
                case 1:
                    m_TuNgay = new DateTime(d_ChonNam.DateTime.Year, 1, 1);
                    m_DenNgay = new DateTime(d_ChonNam.DateTime.Year, 12, 31);
                    break;
                case 2:
                    m_TuNgay = new DateTime(d_ChonNgay_1.DateTime.Year, d_ChonNgay_1.DateTime.Month,
                                          d_ChonNgay_1.DateTime.Day);
                    m_DenNgay = new DateTime(d_ChonNgay_2.DateTime.Year, d_ChonNgay_2.DateTime.Month,
                                           d_ChonNgay_2.DateTime.Day);
                    break;
            }

            m_TuNgay = m_TuNgay.AddHours(-m_TuNgay.Hour);
            m_TuNgay = m_TuNgay.AddMinutes(-m_TuNgay.Minute);
            m_TuNgay = m_TuNgay.AddSeconds(-m_TuNgay.Second);
            m_TuNgay = m_TuNgay.AddMilliseconds(-m_TuNgay.Millisecond);

            m_DenNgay = m_DenNgay.AddHours(23 - m_DenNgay.Hour);
            m_DenNgay = m_DenNgay.AddMinutes(59 - m_DenNgay.Minute);
            m_DenNgay = m_DenNgay.AddSeconds(59 - m_DenNgay.Second);
            m_DenNgay = m_DenNgay.AddMilliseconds(998 - m_DenNgay.Millisecond);
            if (MDDateTime.KiemTraTuNgayDenNgay(m_TuNgay, m_DenNgay))
            {
                XtraMessageBox.Show("Đến ngày >= từ ngày!", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
            }
        }
    }
}