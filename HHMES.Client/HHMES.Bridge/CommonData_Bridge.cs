﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ServiceModel;
using HHMES.Interfaces.Interfaces_Bridge;
using HHMES.Core;
using HHMES.Common;
using HHMES.WebServiceReference;
using HHMES.Server.DataAccess.DAL_System;
using HHMES.WebServiceReference.WCF_CommonService;

namespace HHMES.Bridge.CommonBridge
{
    /// <summary>
    /// 使用ADODirect访问公共数据DAL层
    /// </summary>
    public class ADODirect_CommonData
    {
        private IBridge_CommonData _DAL_Instance = null;//数据层实例

        public ADODirect_CommonData()
        {
            _DAL_Instance = new dalCommon(Loginer.CurrentUser);
        }

        public IBridge_CommonData GetInstance()
        {
            return _DAL_Instance;
        }
    }

    /// <summary>
    /// 使用WebService访问公共数据DAL层
    /// </summary>
    public class WebService_CommonData : IBridge_CommonData
    {

        public WebService_CommonData()
        {
        }

        #region IBridge_CommonDAL Members

        public System.Data.DataTable GetSystemDataSet()
        {
            using (CommonServiceClient client = SoapClientFactory.CreateCommonServiceClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] receivedData = client.GetSystemDataSet(validationTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable GetTableFieldsDef(string tableName, bool onlyDisplayField)
        {
            using (CommonServiceClient client = SoapClientFactory.CreateCommonServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetTableFieldsDef(loginTicket, tableName, onlyDisplayField);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable GetTableFields(string tableName)
        {
            using (CommonServiceClient client = SoapClientFactory.CreateCommonServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetTableFields(loginTicket, tableName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable GetBusinessTables()
        {
            using (CommonServiceClient client = SoapClientFactory.CreateCommonServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetBusinessTables(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }


        public DataTable GetModules()
        {
            using (CommonServiceClient client = SoapClientFactory.CreateCommonServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetModules(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        #endregion


        public DataTable GetDB4Backup()
        {
            using (CommonServiceClient client = SoapClientFactory.CreateCommonServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bs = client.GetDB4Backup(loginTicket);
                return ZipTools.DecompressionDataSet(bs).Tables[0];
            }
        }

        public DataTable GetBackupHistory(int topList)
        {
            using (CommonServiceClient client = SoapClientFactory.CreateCommonServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bs = client.GetBackupHistory(loginTicket, topList);
                return ZipTools.DecompressionDataSet(bs).Tables[0];
            }
        }

        public bool BackupDatabase(string DBNAME, string BKPATH)
        {
            using (CommonServiceClient client = SoapClientFactory.CreateCommonServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.BackupDatabase(DBNAME, BKPATH);
            }
        }

        public bool RestoreDatabase(string BKFILE, string DBNAME)
        {
            using (CommonServiceClient client = SoapClientFactory.CreateCommonServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.RestoreDatabase(BKFILE, DBNAME);
            }
        }

        public string GetDataSN(string dataCode, bool asHeader)
        {
            using (CommonServiceClient client = SoapClientFactory.CreateCommonServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.GetDataSN(loginTicket, dataCode, asHeader);
            }
        }

        public DataTable SearchOutstanding(string invoiceNo, string customer, DateTime dateFrom, DateTime dateTo, DateTime dateEnd, string outstandingType)
        {
            using (CommonServiceClient client = SoapClientFactory.CreateCommonServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bs = client.SearchOutstanding(loginTicket, invoiceNo, customer, dateFrom, dateTo, dateEnd, outstandingType);
                return ZipTools.DecompressionDataSet(bs).Tables[0];
            }
        }

        public void SyncServerTime()
        {
            using (CommonServiceClient client = SoapClientFactory.CreateCommonServiceClient())
            {
                client.SyncServerTime();
            }
        }
    }
}
