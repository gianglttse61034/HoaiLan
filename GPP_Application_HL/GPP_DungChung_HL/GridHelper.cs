using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using System.Data;

namespace GPP_DungChung_HL
{
    public class GridHelper
    {
        #region Khai báo biến toàn cục
        public static string Numberic="Numberic";
        public static string DateTimeMOD = "DateTime";
        public static string LookupEDIT= "LookUpEdit";
        public static string TextEdit_Mod = "TextEdit";
        public RepositoryItemLookUpEdit lookup = new RepositoryItemLookUpEdit();
        #endregion
        public void HideColunm(GridView grid)
        {
            grid.Columns.Clear();
        }

        /// <summary>
        /// Format grid
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="parameter"> par 0: name column,par1 : caption, par2: width, par3: type, par4 : visible,</param>
        public static void FormatGrid(GridView grid, params object[] parameter)
        {

            grid.Columns.Clear();
           
            for (int i = 0; i < parameter.Length;)
            {
                bool flag = false;
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = parameter[i].ToString();
                col.Caption = parameter[i + 1].ToString();
                col.Width = Convert.ToInt32(parameter[i + 2]);
                col.Visible = Convert.ToBoolean(parameter[i + 4]);
               
                if (parameter[i + 3].ToString() == LookupEDIT)
                {
                    flag = true;
                    RepositoryItemLookUpEdit repositoryItem = new RepositoryItemLookUpEdit();
                    DataTable dt = (DataTable)parameter[i + 5]; // i = 5
                    string display = parameter[i + 6].ToString();// i =6
                    string value = parameter[i + 7].ToString();//i = 7 
                    col.ColumnEdit = KhoiTaoLookupEdit_Grid(dt, repositoryItem, display, value);
                    
                }
                else
                    if (parameter[i + 3].ToString() == TextEdit_Mod)
                     {
                     flag = true;
                     RepositoryItemTextEdit repositoryItem = new RepositoryItemTextEdit();

                        if (parameter[i + 5].ToString() == DateTimeMOD)
                        {
                            repositoryItem.Mask.EditMask = "dd/MM/yyyy";
                            repositoryItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
                            repositoryItem.Mask.UseMaskAsDisplayFormat = true;
                        }
                        else
                            if (parameter[i + 5].ToString() == Numberic)
                            {
                                repositoryItem.Mask.EditMask = parameter[i + 7].ToString();
                                repositoryItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                                repositoryItem.Mask.UseMaskAsDisplayFormat = true;
                                repositoryItem.MaxLength = Convert.ToInt32(parameter[i + 6]);
                    }
                            else
                                    if (parameter[i + 5].ToString() == "Text")
                                    {
                                        repositoryItem.MaxLength = Convert.ToInt32(parameter[i + 6]);
                                    }
                                     col.ColumnEdit = repositoryItem;
                }
               
                if (!flag)
                {
                    col.DisplayFormat.FormatString = parameter[i + 3].ToString();
                    i = i + 5;
                }
                else
                    i = i + 8;
                //col.AppearanceHeader.FontSizeDelta = 20;
                //col.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
                grid.Columns.Add(col);

            }
        }
        public DataTable GetDataOfGridView(GridView grid)
        {
            DataTable dt = new DataTable();
            if (grid.ActiveFilter == null || grid.ActiveFilter.Expression == string.Empty)
                return grid.DataSource as DataTable;

            DataView filter = grid.DataSource as DataView;
            filter.RowFilter = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(grid.ActiveFilterCriteria);
            dt = filter.ToTable();
            return dt;
        }
        public DataTable GridControlToDataTable(GridControl dgrid)
        {
            System.Windows.Forms.BindingSource bs = (System.Windows.Forms.BindingSource)dgrid.DataSource; // Se convierte el DataSource 
            DataTable tbl = (DataTable)bs.DataSource;
            return tbl;
        }
        public static RepositoryItemLookUpEdit KhoiTaoLookupEdit_Grid(DataTable dt, RepositoryItemLookUpEdit item, string display_member, string value_member)
        {
            item.DataSource = dt;
            item.DisplayMember = display_member;
            item.ValueMember = value_member;
            item.NullText = "";
            return item;
        }
    }
}
