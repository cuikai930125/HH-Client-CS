﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HHMES.Common;

namespace HHMES.Business.BLL_Base
{
    /// <summary>
    /// 业务逻辑层基类
    /// </summary>
    public class bllBase
    {
        /// <summary>
        /// 创建原始数据用于更新. 由DataTable转换为DataSet
        /// </summary>
        protected DataSet CreateDataset(DataTable data, UpdateType updateType)
        {
            DataSet ds = new DataSet();
            data.AcceptChanges(); //保存缓存数据
            foreach (DataRow row in data.Rows)
                this.SetRowState(row, updateType); //设置记录状态
            ds.Tables.Add(data.Copy()); //加到新的DataSet
            return ds;
        }

        /// <summary>
        /// 更新记录状态
        /// </summary>
        /// <param name="dataRow">记录</param>
        /// <param name="updateType">操作类型</param>
        private void SetRowState(DataRow dataRow, UpdateType updateType)
        {
            if (dataRow.RowState != DataRowState.Unchanged) return;
            if (updateType == UpdateType.Add)
                dataRow.SetAdded();
            if (updateType == UpdateType.Modify)
                dataRow.SetModified();
        }

        /// <summary>
        /// 数字类型设置预设值0
        /// </summary>
        /// <param name="ds"></param>
        protected void SetNumericDefaultValue(DataSet ds)
        {
            foreach (DataTable t in ds.Tables)
                this.SetNumericDefaultValue(t);
        }

        /// <summary>
        /// 数字类型设置预设值0
        /// </summary>
        /// <param name="dt"></param>
        protected void SetNumericDefaultValue(DataTable dt)
        {
            string names = ",int,int16,int32,int64,decimal,float,double,";
            foreach (DataColumn col in dt.Columns)
                if (names.IndexOf(col.DataType.Name.ToLower()) > 0)
                    col.DefaultValue = 0.00;

        }

       
    }
}
