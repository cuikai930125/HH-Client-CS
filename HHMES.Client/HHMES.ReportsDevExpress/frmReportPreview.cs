using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace DevReportTester
{
    public partial class frmReportPreview : DevExpress.XtraEditors.XtraForm
    {
        private frmReportPreview()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �򿪱���Ԥ������
        /// </summary>
        /// <param name="report">����ʵ��</param>
        /// <param name="owner">��������</param>
        public static void DoPreviewReport(XtraReport report, Form owner)
        {
            using (frmReportPreview preview = new frmReportPreview())
            {
                preview.Owner = owner;
                preview.Initialize(report);
                preview.WindowState = FormWindowState.Maximized; //���
                preview.ShowDialog();
            }
        }

        private void Initialize(XtraReport report)
        {
            //��Ҫ��XtraReport(����ʵ��)��PrintControl(��ӡԤ�����)��������!
            printControl1.PrintingSystem = report.PrintingSystem;

            //��ʼ������������������Ԥ��״̬��
            report.CreateDocument(true);

            //����ĳЩ��ť,CommandVisibility.None ��ʾ����
            printControl1.PrintingSystem.SetCommandVisibility(new PrintingSystemCommand[]
            {
                PrintingSystemCommand.Open,
                PrintingSystemCommand.Save,
                PrintingSystemCommand.ClosePreview,
                PrintingSystemCommand.Customize,
                PrintingSystemCommand.SendCsv,
                PrintingSystemCommand.SendFile,
                PrintingSystemCommand.SendGraphic,
                PrintingSystemCommand.SendMht,
                PrintingSystemCommand.SendPdf,
                PrintingSystemCommand.SendRtf,
                PrintingSystemCommand.SendTxt,
                PrintingSystemCommand.SendXls,
                PrintingSystemCommand.Watermark
            }, CommandVisibility.None);


        }
    }
}
