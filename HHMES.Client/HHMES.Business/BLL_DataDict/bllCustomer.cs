﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HHMES.Models;
using HHMES.Common;

using HHMES.Bridge;
using HHMES.Interfaces;
using HHMES.Business.BLL_Base;
using HHMES.Bridge.DataDictModule;

namespace HHMES.Business
{
    /// <summary>
    /// 客户资料管理业务逻辑层
    /// </summary>
    public class bllCustomer : bllBaseDataDict
    {
        private IBridge_Customer _MyBridge; //桥接/策略接口

        public bllCustomer()
        {
            _KeyFieldName = tb_Customer.__KeyName; //主键字段
            _SummaryTableName = tb_Customer.__TableName;//表名
            _WriteDataLog = true;//是否保存日志
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_Customer));
            _MyBridge = this.CreateBridge();
        }

        /// <summary>
        /// 创建桥接通信通道
        /// </summary>
        /// <returns></returns>
        private IBridge_Customer CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_Customer().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_Customer();

            return null;
        }

        public DataTable SearchBy(string CustomerFrom, string CustomerTo, string Name,
            string Attribute, bool resetCurrent)
        {
            DataTable data = _MyBridge.SearchBy(CustomerFrom, CustomerTo, Name, Attribute);
            if (resetCurrent) _SummaryTable = data;
            this.SetDefault(_SummaryTable);
            return data;
        }

        public DataTable GetCustomerByAttributeCodes(string attributeCodes, bool nameWithCode)
        {
            return _MyBridge.GetCustomerByAttributeCodes(attributeCodes, nameWithCode);
        }

        public DataTable FuzzySearch(string content)
        {
            return _MyBridge.FuzzySearch(content);
        }

        public DataTable FuzzySearch(string attributeCodes, string content)
        {
            return _MyBridge.FuzzySearch(attributeCodes, content);
        }
    }
}
