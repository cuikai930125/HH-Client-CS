using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HHMES.Common;
using HHMES.Library;
using DevExpress.XtraReports.UI;
using DevReportTester;

namespace HHMES.ReportsDevExpress
{
    /// <summary>
    /// 报表打印窗体基类
    /// </summary>
    public partial class frmPrintBase : frmBase
    {

        public frmPrintBase()
        {
            InitializeComponent();
        }

        protected virtual XtraReport DoPrepareReport() { return null; }

        private void btnPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoPreview(); //打印预览
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoPrint();//打印
        }

        private void btnHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoHelp();//打开帮助
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoClose();//关闭窗体
        }

        protected void AssertNull(object o, string throwMsg)
        {
            if (o == null) throw new Exception(throwMsg);
        }

        protected void AssertNullDataSet(DataSet ds, string throwMsg)
        {
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) throw new Exception(throwMsg);
        }

        protected virtual void DoPreview()
        {
            XtraReport rpt = this.DoPrepareReport();//准备报表
            frmReportPreview.DoPreviewReport(rpt, this);//打开报表预览窗体
        }

        protected virtual void DoPrint()
        {
            XtraReport rpt = this.DoPrepareReport();
            rpt.Print();
        }

        protected virtual void DoHelp()
        {
            //
        }

        protected virtual void DoClose()
        {
            this.Close();
        }

        private void frmPrintBase_Load(object sender, EventArgs e)
        {
            btnClose.Glyph = Globals.LoadImage("24_Exit.ico");
            btnPrint.Glyph = Globals.LoadImage("24_Print.ico");
            btnPreview.Glyph = Globals.LoadImage("24_PrintPreview.ico");
            btnHelp.Glyph = Globals.LoadImage("24_Help.ico");
        }

    }
}