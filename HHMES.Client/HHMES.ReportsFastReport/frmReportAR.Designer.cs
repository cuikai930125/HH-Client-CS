﻿namespace HHMES.ReportsFastReport
{
    partial class frmReportAR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportAR));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNoFrom = new DevExpress.XtraEditors.TextEdit();
            this.txtNoTo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDateTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.rptAR = new FastReport.Report();
            this.cmbReportType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.rptAR_Checklist = new FastReport.Report();
            this.rptARNormal = new FastReport.Report();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbReportType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Size = new System.Drawing.Size(445, 226);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 254);
            this.panel1.Size = new System.Drawing.Size(445, 74);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.cmbReportType);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtDateTo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtDateFrom);
            this.groupControl1.Controls.Add(this.txtNoTo);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtNoFrom);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Size = new System.Drawing.Size(445, 226);
            // 
            // label4
            // 
            this.label4.Size = new System.Drawing.Size(445, 2);
            // 
            // pcBK
            // 
            this.pcBK.Image = null;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(52, 69);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "收款编号：";
            // 
            // txtNoFrom
            // 
            this.txtNoFrom.Location = new System.Drawing.Point(118, 66);
            this.txtNoFrom.Name = "txtNoFrom";
            this.txtNoFrom.Size = new System.Drawing.Size(100, 21);
            this.txtNoFrom.TabIndex = 1;
            // 
            // txtNoTo
            // 
            this.txtNoTo.Location = new System.Drawing.Point(257, 66);
            this.txtNoTo.Name = "txtNoTo";
            this.txtNoTo.Size = new System.Drawing.Size(100, 21);
            this.txtNoTo.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(231, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "至";
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.EditValue = null;
            this.txtDateFrom.Location = new System.Drawing.Point(118, 103);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDateFrom.Size = new System.Drawing.Size(100, 21);
            this.txtDateFrom.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(231, 106);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(12, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "至";
            // 
            // txtDateTo
            // 
            this.txtDateTo.EditValue = null;
            this.txtDateTo.Location = new System.Drawing.Point(257, 103);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDateTo.Size = new System.Drawing.Size(100, 21);
            this.txtDateTo.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(52, 106);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "收款日期：";
            // 
            // rptAR
            // 
            this.rptAR.ReportResourceString = resources.GetString("rptAR.ReportResourceString");
            // 
            // cmbReportType
            // 
            this.cmbReportType.EditValue = "Document Report 1 - 文档报表";
            this.cmbReportType.Location = new System.Drawing.Point(118, 159);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbReportType.Properties.Items.AddRange(new object[] {
            "Document Report 1 - 文档报表",
            "Document Report 2 - 凭证格式",
            "Checklist Report - 清单报表"});
            this.cmbReportType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbReportType.Size = new System.Drawing.Size(238, 21);
            this.cmbReportType.TabIndex = 8;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(52, 162);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "报表类型：";
            // 
            // rptAR_Checklist
            // 
            this.rptAR_Checklist.ReportResourceString = resources.GetString("rptAR_Checklist.ReportResourceString");
            // 
            // rptARNormal
            // 
            this.rptARNormal.ReportResourceString = resources.GetString("rptARNormal.ReportResourceString");
            // 
            // frmReportAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(445, 328);
            this.Name = "frmReportAR";
            this.Text = "AR-应收款报表";
            this.Load += new System.EventHandler(this.frmReportAR_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbReportType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNoTo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtNoFrom;
        private DevExpress.XtraEditors.DateEdit txtDateTo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit txtDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private FastReport.Report rptAR;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit cmbReportType;
        private FastReport.Report rptAR_Checklist;
        private FastReport.Report rptARNormal;
    }
}
