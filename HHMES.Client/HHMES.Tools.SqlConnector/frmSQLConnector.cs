using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;
using HHMES.Common;
using HHMES.Core;

namespace HHMES.Tools.SqlConnector
{
    /// <summary>
    /// SQL连接配置工具
    /// </summary>
    public partial class frmSQLConnector : Form
    {
        /// <summary>
        /// 配置信息存储策略
        /// </summary>
        private IWriteSQLConfigValue _writer = null;

        /// <summary>
        /// 服务器列表
        /// </summary>
        private ListBox _SrvList = null;

        /// <summary>
        /// 连接成功标记
        /// </summary>
        private bool Successed = false;

        private frmSQLConnector()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打开配置窗体
        /// </summary>
        /// <param name="RegPath"></param>
        public static bool ExecuteConnection()
        {
            frmSQLConnector form = new frmSQLConnector();
            form.LoadCurrentConfiguration();
            form.ShowDialog();
            return form.Successed;
        }

        //当连接已经配置,显示上次配置的数据
        private void LoadCurrentConfiguration()
        {
            //连接配置保存在INI文件                
            IWriteSQLConfigValue writer = new IniFileWriter(Application.StartupPath + SqlConfiguration.INI_CFG_PATH);
            txtDatabase.Text = writer.InitialCatalog;
            txtPwd.Text = writer.Password;
            txtServerName.Text = writer.ServerName;
            txtUserName.Text = writer.UserName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            try
            {
                string errMsg = string.Empty;
                label5.Visible = true;
                timer1.Start();

                if (rbINI.Checked)//连接配置保存在INI文件                
                    _writer = new IniFileWriter(Application.StartupPath + SqlConfiguration.INI_CFG_PATH);
                else//连接配置保存在注册表. Registry.LocalMachine根目录下                
                    _writer = new RegisterWriter(SqlConfiguration.REG_SQL_CFG);

                SqlConnection conn = this.TestConnection(txtServerName.Text, txtDatabase.Text, txtUserName.Text, txtPwd.Text, ref errMsg);
                if (conn == null)
                {
                    timer1.Stop();
                    label5.Visible = false;
                    MessageBox.Show("Connecting to SQL Server failed.\n" + errMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else //连接成功，保存连接参数
                {
                    _writer.ServerName = txtServerName.Text;
                    _writer.UserName = txtUserName.Text;
                    _writer.Password = txtPwd.Text;
                    _writer.InitialCatalog = txtDatabase.Text;
                    _writer.Write();
                    Successed = true;
                    MessageBox.Show("Connect SQL Server successfully!", "Connect to Server", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
            }
            finally
            {
                timer1.Stop();
                label5.Visible = false;
                btnConnect.Enabled = true;
            }
        }


        /// <summary>
        /// 测试连接
        /// </summary>
        private SqlConnection TestConnection(string server, string database, string user, string password, ref string errMsg)
        {
            const string DEF_SQL_CONNECTION = @"Data Source={0};Initial Catalog={1};User ID={2};Password ={3};Persist Security Info=True;";

            try
            {
                string connstr = string.Format(DEF_SQL_CONNECTION, server, database, user, password);
                SqlConnection conn = new SqlConnection(connstr);

                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        private void btnGetList_Click(object sender, EventArgs e)
        {//查找局域网的服务器列表
            if (_SrvList != null && _SrvList.Items.Count > 0)
            {
                _SrvList.Visible = true;
                _SrvList.Focus();
                this.Cursor = Cursors.Default;
                return;
            }

            try
            {
                ShowWaitCursor();
                _SrvList = new ListBox();
                _SrvList.Visible = false;
                _SrvList.Parent = this;
                _SrvList.Width = txtServerName.Width;
                _SrvList.Location = new Point(txtServerName.Left, txtServerName.Top + txtServerName.Height + 1);
                _SrvList.SelectedIndexChanged += new EventHandler(SrvList_SelectedIndexChanged);
                string[] srvs = SqlLocator.GetServers();
                foreach (string srv in srvs)
                    _SrvList.Items.Add(srv);

                if (_SrvList.Items.Count > 0)
                {
                    _SrvList.Visible = true;
                    _SrvList.BringToFront();
                }
            }
            finally
            {
                ShowDefaultCursor();
            }
        }

        private void ShowWaitCursor()
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
        }

        private void ShowDefaultCursor()
        {
            Cursor.Current = Cursors.Default;
            Cursor.Hide();
        }

        private void SrvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtServerName.Text = ((ListBox)sender).SelectedItem.ToString();
            txtServerName.Focus();
        }

        private void txtServerName_Enter(object sender, EventArgs e)
        {
            if (_SrvList != null)
            {
                _SrvList.Visible = false;
            }
        }

        private int _timer = 30;
        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = _timer.ToString() + " seconds remains.";
            _timer--;
            if (_timer == 0)
            {
                timer1.Stop();
                label5.Visible = false;
                _timer = 30;
            }
        }


    }
}