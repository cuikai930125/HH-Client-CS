using System;
using System.Collections.Generic;
using System.Text;
using FastReport;
using System.IO;
using HHMES.Common;

namespace HHMES.Reports
{

    /// <summary>
    /// ��������
    /// </summary>
    public enum ReportType
    {
        PrintDocument = 0,
        PrintCheckList = 1
    }

    /// <summary>
    /// ������������
    /// </summary>
    public class ExportReportItem
    {

        /// <summary>
        /// �����������ݵ�����
        /// </summary>
        public enum ExportType
        {
            PDF,
            XLS,
            HTML
        }

        private string _ItemCaption;
        private ExportType _exportType;

        public ExportReportItem(string itemCaption, ExportType exportType)
        {
            _ItemCaption = itemCaption;
            _exportType = exportType;
        }

        public override string ToString()
        {
            return _ItemCaption;
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="report">����ʵ��</param>
        /// <returns></returns>
        public string ExportToFile(TfrxReportClass report)
        {
            string fileName = Path.GetTempPath() + @"\_rpt" + DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + Loginer.CurrentUser.Account;

            if (ExportType.PDF == _exportType)//PDF
            {
                fileName = fileName + ".pdf";
                report.ExportToPDF(fileName, false, false, false);
            }
            else if (ExportType.XLS == _exportType)//XLS
            {
                fileName = fileName + ".xls";
                report.ExportToXLS(fileName, true, false, false, false, true);
            }
            else if (ExportType.HTML == _exportType)//HTML
            {
                fileName = fileName + ".html";
                report.ExportToHTML(fileName, true, true, false, false, true, true);
            }

            return fileName;
        }
    }
}
