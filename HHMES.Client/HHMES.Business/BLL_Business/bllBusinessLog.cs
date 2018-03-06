﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HHMES.Interfaces.Interfaces_Bridge;
using HHMES.Bridge;
using HHMES.Bridge.SystemModule;
using HHMES.Common;

namespace HHMES.Business.BLL_Business
{
    public class bllBusinessLog
    {
        public static DataSet SearchLog(string logUser, string tableName, DateTime dateFrom, DateTime dateTo)
        {
            IBridge_EditLogHistory bridge = CreateEditLogHistoryBridge();
            return bridge.SearchLog(logUser, tableName, dateFrom, dateTo);
        }

        public static bool SaveFieldDef(DataTable data)
        {
            IBridge_EditLogHistory bridge = CreateEditLogHistoryBridge();
            return bridge.SaveFieldDef(data);
        }

        public static DataTable GetLogFieldDef(string tableName)
        {
            IBridge_EditLogHistory bridge = CreateEditLogHistoryBridge();
            return bridge.GetLogFieldDef(tableName);
        }

        /// <summary>
        /// 创建修改历史记录的数据层桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_EditLogHistory CreateEditLogHistoryBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_Log().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_Log();

            throw new CustomException("UNKNOW_BRIDGE_TYPE:CreateEditLogHistoryBridge()");
        }

    }
}
