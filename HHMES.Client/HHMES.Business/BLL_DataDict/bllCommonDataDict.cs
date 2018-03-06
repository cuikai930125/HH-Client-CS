﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HHMES.Models;
using HHMES.Common;

using HHMES.Bridge;
using HHMES.Interfaces;
using HHMES.Business.BLL_Base;

namespace HHMES.Business
{
    /// <summary>
    /// 公共字典数据业务逻辑层
    /// </summary>
    public class bllCommonDataDict : bllBaseDataDict
    {
        private IBridge_CommonDataDict _SelfBridge;

        public bllCommonDataDict()
        {
            _KeyFieldName = tb_CommonDataDict.__KeyName; //主键字段
            _SummaryTableName = tb_CommonDataDict.__TableName;//表名
            _WriteDataLog = true;//是否保存日志            
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_CommonDataDict));
            _SelfBridge = BridgeFactory.CreateCommonDataDictBridge();
        }

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="dataType">字典类型</param>
        /// <param name="resetCurrent">重置当前处理的数据</param>
        /// <returns></returns>
        public DataTable SearchBy(int dataType, bool resetCurrent)
        {
            DataTable data = _SelfBridge.SearchBy(dataType);
            if (resetCurrent) _SummaryTable = data;
            this.SetDefault(_SummaryTable);
            return data;
        }

        /// <summary>
        /// 增加一个字典类型
        /// </summary>
        /// <param name="code">编号</param>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public bool AddCommonType(int code, string name)
        {
            return _SelfBridge.AddCommonType(code, name);
        }

        /// <summary>
        /// 删除字典类型
        /// </summary>
        /// <param name="code">编号</param>
        /// <returns></returns>
        public bool DeleteCommonType(int code)
        {
            return _SelfBridge.DeleteCommonType(code);
        }

        /// <summary>
        /// 检查字典类型是否存在
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public bool IsExistsCommonType(int id)
        {
            return _SelfBridge.IsExistsCommonType(id);
        }

    }
}
