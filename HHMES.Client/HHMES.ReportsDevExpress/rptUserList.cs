using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HHMES.ReportsDevExpress
{
    public partial class rptUserList : DevExpress.XtraReports.UI.XtraReport
    {
        public rptUserList()
        {
            InitializeComponent();
        }

        public void SetReportDataSource(DataSet dataSource)
        {
            this.DataSource = dataSource.Tables[0];//�û�����

            xrLabelRowCount.Text = dataSource.Tables[0].Rows.Count.ToString();//��¼��
        }

    }
}
