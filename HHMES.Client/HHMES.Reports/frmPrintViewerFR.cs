
///*************************************************************************/
///*
///* �ļ���    ��frmPrintViewerFR.cs    
///* ����˵��  : ��ӡԤ������
///* ԭ������  �������� 
///* 
///* Copyright 2010-2011 HHMES www.HHMES.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FastReport;
using System.IO;
using HHMES.Common;
using HHMES.Library;

namespace HHMES.Reports
{
    /// <summary>
    /// ��ӡԤ������
    /// </summary>
    public partial class frmPrintViewerFR : Form
    {
        private TfrxReportClass _CurrentReport;
        private Form _CurrentOwnerForm;

        //private������,��ֹ�ⲿ����ʵ��
        private frmPrintViewerFR()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ��ʾԤ������
        /// </summary>
        public static void ExecutePreview(Form owner, TfrxReportClass report)
        {
            frmPrintViewerFR preview = new frmPrintViewerFR();
            preview.ShowInTaskbar = false;
            preview.Text = "��ӡԤ������";
            preview.Owner = owner;
            preview._CurrentReport = report;
            preview._CurrentOwnerForm = owner;
            preview.ShowDialog();
        }

        private void frmPrintViewerFR_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadExportTypes();
                
                _CurrentReport.PreviewOptions.Buttons ^= frxPreviewButtons.pb_Tools;
                _CurrentReport.PreviewOptions.Buttons ^= frxPreviewButtons.pb_Outline;
                _CurrentReport.PreviewOptions.Buttons ^= frxPreviewButtons.pb_NoClose;
                _CurrentReport.PreviewOptions.Buttons ^= frxPreviewButtons.pb_Edit;

                _CurrentReport.OnAfterPrintReport += new IfrxReportEventDispatcher_OnAfterPrintReportEventHandler(tfrx_OnAfterPrintReport);
                _CurrentReport.PreviewOptions.DoubleBuffered = true;

                FRPreview.Report = _CurrentReport as TfrxReport;
                FRPreview.Report.PrepareReport(true);
                //FRPreview.Report.ShowReport(); //�����������
            }
            catch (Exception ex)
            {
                Msg.Warning(ex.Message);
            }
        }

        private void LoadExportTypes()
        {
            cbExportTypes.Items.Clear();
            cbExportTypes.Items.Add(new ExportReportItem("PDF��ʽ����", ExportReportItem.ExportType.PDF));
            cbExportTypes.Items.Add(new ExportReportItem("Excel��ʽ����", ExportReportItem.ExportType.XLS));
            cbExportTypes.Items.Add(new ExportReportItem("HTML��ʽ����", ExportReportItem.ExportType.HTML));
            cbExportTypes.SelectedIndex = 0;//PDFԤ��
        }

        /// <summary>
        /// ��ӡ����¼�
        /// </summary>
        private void tfrx_OnAfterPrintReport(IfrxComponent Sender)
        {
            //
        }

        private void frmPrintViewerFR_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_CurrentOwnerForm != null) _CurrentOwnerForm.Activate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
