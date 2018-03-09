using System;
using System.Collections.Generic;
using HHMES.Library;
using HHMES.Business;

namespace HHMES.Main
{
    public partial class frmAbout : frmBase
    {
        public frmAbout()
        {
            InitializeComponent();
            CommonData.GetCommonInfos(); //��ȡ��˾��Ϣ����
            lblCompany.Text= CommonData.CompanyInfo.NativeName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}