using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Drawing.Printing;

namespace HHMES.ReportsDevExpress
{
    /// <summary>
    /// ���ӱ���
    /// </summary>
    public partial class rptSO : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSO()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �������ӱ������Դ
        /// </summary>
        /// <param name="reportData"></param>
        public void SetReportDataSource(DataSet reportData)
        {
            //���漰���޸�DataSet���ڲ����ԣ����鴴���������в�����
            DataSet ds = reportData.Copy();//��������

            //��Ҫ����������(GroupHeader)�������ֶ�
            //�������ǰ�ҵ�񵥺ŷ���
            GroupField gf = new GroupField("SONO", XRColumnSortOrder.Ascending);
            GroupHeader1.GroupFields.Add(gf);

            //�����ݼ������������ϵ
            DataColumn parentColumn = ds.Tables["tb_SO"].Columns["SONO"];
            DataColumn childColumn = ds.Tables["tb_SOs"].Columns["SONO"];
            DataRelation R1 = new DataRelation("R1", parentColumn, childColumn);
            ds.Relations.Add(R1);

            //�����������Դ
            this.DataMember = "tb_SO";
            this.DataSource = ds;

            //����ϸ�������Դ
            this.DetailReport.DataMember = "R1";
            this.DetailReport.DataSource = ds;

            //�Զ�����ϸ��XRLabel������Դ
            this.BindingFields(ds, this.Detail1.Controls);

            xrLabel15.DataBindings.Add("Text", ds, "R1.Amount");//��С��(��ǰ���ݵ��ܽ��)
            xrLabel23.DataBindings.Add("Text", ds, "R1.Amount");//���ܼ�(���е��ݵ��ܽ��)
        }

        /// <summary>
        /// ��̬���ֶ�
        /// </summary>
        /// <param name="dataSource">���������Դ</param>
        /// <param name="bindableControls">��Ӧ�ֶεı���ؼ�����</param>
        private void BindingFields(DataSet dataSource, XRControlCollection bindableControls)
        {
            foreach (XRControl C in bindableControls)
            {
                if ((C.Tag != null) && (C.Tag.ToString() == "DATA")) //ע�⣡ֻ����Tag=DATA�Ŀؼ�
                {
                    C.DataBindings.Add("Text", dataSource, C.Text.Replace("[", "").Replace("]", ""));
                }
            }
        }

        private void XtraReport_MasterDetail_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {            
            //
        }

        private void XtraReport_MasterDetail_PrintProgress(object sender, DevExpress.XtraPrinting.PrintProgressEventArgs e)
        {
            //
        }

        private void XtraReport_MasterDetail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //
        }

    }
}
