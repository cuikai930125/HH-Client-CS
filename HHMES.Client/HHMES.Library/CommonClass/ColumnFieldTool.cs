﻿using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Data;
using HHMES.Business;
using HHMES.Common;

namespace HHMES.Library
{
    /// <summary>
    /// 自动设置表格栏位标题
    /// </summary>
    public class ColumnFieldTool
    {
        /// <summary>
        /// 自动设置表格栏位标题
        /// </summary>
        /// <param name="view">表格</param>
        /// <param name="bindingTableName">物理表名,从数据库取该表的字段标题</param>
        public static void SetColumnFieldTitle(GridView view, string bindingTableName)
        {
            if (view.GridControl.DataSource == null) return;

            //获取表的字段显示名称
            DataTable fieldNames = CommonData.GetTableFieldsDef(bindingTableName, true); 

            view.BeginInit();
            foreach (GridColumn column in view.Columns)
            {
                DataRow[] rows = fieldNames.Select("FieldName='" + column.FieldName + "'");
                if (rows.Length > 0)
                    column.Caption = ConvertEx.ToString(rows[0]["DisplayName"]);
                else
                    column.VisibleIndex = -1;
            }
            view.EndInit();
        }

    }


}
