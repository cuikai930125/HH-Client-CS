using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HHMES.Library;
using HHMES.Common;
using HHMES.Core;

namespace HHMES.SystemModule
{
    /// <summary>
    /// ϵͳ�������崰��
    /// </summary>
    public partial class frmSystemOptions : frmBaseDialog
    {
        public frmSystemOptions()
        {
            InitializeComponent();
        }

        private void frmSystemOptions_Load(object sender, EventArgs e)
        {
            SkinTools.LoadSkin(txtSkins); //����Ƥ���б�
            //ϵͳ����
            txtSkins.Text = SystemConfig.CurrentConfig.SkinName;
            chkLocalLog.Checked = SystemConfig.CurrentConfig.WriteLocalLog;
            chkAllowRunMultiInstance.Checked = SystemConfig.CurrentConfig.AllowRunMultiInstance;
            chkDoubleClickIntoEditMode.Checked = SystemConfig.CurrentConfig.DoubleClickIntoEditMode;

            rgAuthType.SelectedIndex = SystemConfig.CurrentConfig.LoginAuthType - 1;
            rgUpgraderType.SelectedIndex = SystemConfig.CurrentConfig.UpgradeType - 1;
            txtUpgraderIP.Text = SystemConfig.CurrentConfig.UpgraderServerIP;
            txtUpgraderPort.Text = SystemConfig.CurrentConfig.UpgraderServerPort;
            chkCheckVer.Checked = SystemConfig.CurrentConfig.AutoCheckVersion;
            chkExitAppIfOldVer.Checked = SystemConfig.CurrentConfig.ExitAppIfOldVersion;

            this.xtraTabControl1.SelectedTabPageIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SystemConfig.CurrentConfig.SkinName = txtSkins.Text;
            SystemConfig.CurrentConfig.WriteLocalLog = chkLocalLog.Checked;
            SystemConfig.CurrentConfig.AllowRunMultiInstance = chkAllowRunMultiInstance.Checked;
            SystemConfig.CurrentConfig.DoubleClickIntoEditMode = chkDoubleClickIntoEditMode.Checked;
            SystemConfig.CurrentConfig.LoginAuthType = rgAuthType.SelectedIndex + 1;
            SystemConfig.CurrentConfig.UpgradeType = rgUpgraderType.SelectedIndex + 1;
            SystemConfig.CurrentConfig.UpgraderServerIP = txtUpgraderIP.Text;
            SystemConfig.CurrentConfig.UpgraderServerPort = txtUpgraderPort.Text;
            SystemConfig.CurrentConfig.AutoCheckVersion = chkCheckVer.Checked;
            SystemConfig.CurrentConfig.ExitAppIfOldVersion = chkExitAppIfOldVer.Checked;
            SystemConfig.WriteSettings(SystemConfig.CurrentConfig);
            this.Close();
        }

        private void btnApplySkin_Click(object sender, EventArgs e)
        {
            if (txtSkins.SelectedItem != null)
                SkinTools.SetSkin(txtSkins.SelectedItem.ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtSkins.Text != SystemConfig.CurrentConfig.SkinName)
                SkinTools.SetSkin(SystemConfig.CurrentConfig.SkinName);
        }
    }
}