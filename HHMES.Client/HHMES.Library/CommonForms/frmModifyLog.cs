﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HHMES.Business;
using HHMES.Common;
using HHMES.Core.Log;
using HHMES.Library;
using HHMES.Business.BLL_Business;

namespace HHMES.Library
{
    /// <summary>
    /// 修改历史记录查询窗体
    /// </summary>
    public partial class frmModifyLog : HHMES.Library.frmBaseChild
    {
        //最后一次搜索结果
        private DataSet _LastSearch = null;

        public frmModifyLog()
        {
            InitializeComponent();
        }

        //移动主表记录自动显示明细记录
        private void gvSummary_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if ((_LastSearch != null) && (e.FocusedRowHandle >= 0))
            {
                string GUID32 = ConvertEx.ToString(gvSummary.GetDataRow(e.FocusedRowHandle)["GUID32"]);
                DataView detail = _LastSearch.Tables[1].DefaultView;
                detail.RowFilter = "GUID32='" + GUID32 + "'";
                gcDetail.DataSource = detail;
            }
        }

        //执行查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (cbBusiness.ItemIndex >= 0)
            {
                DataRowView row = (DataRowView)cbBusiness.Properties.GetDataSourceRowByKeyValue(cbBusiness.EditValue);

                string tableName = ConvertEx.ToString(row.Row["Table1"]);
                _LastSearch = bllBusinessLog.SearchLog(Loginer.CurrentUser.Account, tableName, txtDateFrom.DateTime, txtDateTo.DateTime);
                gcSummary.DataSource = _LastSearch.Tables[0];
                gvSummary_FocusedRowChanged(gvSummary, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gvSummary.FocusedRowHandle));
            }
            else
            {
                Msg.Warning("请选择单据!");
                cbBusiness.Focus();
                cbBusiness.ShowPopup();
            }
        }

        private void btnEmpty_Click(object sender, EventArgs e)
        {
            txtDateFrom.EditValue = null;
            txtDateTo.EditValue = null;

            cbBusiness.Focus();
            cbBusiness.ShowPopup();
        }

        private void frmModifyLog_Load(object sender, EventArgs e)
        {
            this.InitButtons();

            txtDateTo.DateTime = DateTime.Today;
            DataTable BusinessTables = DataDictCache.GetCacheTableData("BUSINESSTABLE");
            DataBinder.BindingLookupEditDataSource(cbBusiness, BusinessTables, "FormCaption", "FormName");
        }

        public void ShowModifyLog(string formName)
        {
            cbBusiness.EditValue = formName;
            btnQuery.PerformClick();
        }

        private void chkRowHeight_CheckedChanged(object sender, EventArgs e)
        {
            gvSummary.OptionsView.RowAutoHeight = chkRowHeight.Checked;
        }
    }
}
