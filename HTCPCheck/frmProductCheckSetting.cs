using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;

namespace HTCPCheck
{
    /// <summary>
    /// �������ã�
    /// </summary>
    public partial class frmProductCheckSetting :BaseForm
    {
        public frmProductCheckSetting()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveMB_Click(object sender, EventArgs e)
        {
            try
            {
                SysIniFile ini = new SysIniFile(Application.StartupPath + @"\htcheckset.ini");

                ini.IniWriteValue("MB", "PORTNAME", drpPortName.Text);
                ini.IniWriteValue("MB", "BRATE", drpBaudrate.Text);

                ini.IniWriteValue("MB2", "PORTNAME", drpPortName2.Text);
                ini.IniWriteValue("MB2", "BRATE", drpBaudrate2.Text);

                this.ShowInfoMessage("�������óɹ������������ã���رռ�����棬���´�");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProductCheckSetting_Load(object sender, EventArgs e)
        {
            try
            {
                SysIniFile ini = new SysIniFile(Application.StartupPath + @"\htcheckset.ini");

                string pn=ini.IniReadValue("MB", "PORTNAME");
                if (pn != string.Empty)
                {
                    drpPortName.Text = pn;
                }

                string brate = ini.IniReadValue("MB", "BRATE");
                if (brate != string.Empty)
                {
                    drpBaudrate.Text = brate;
                }



                string pn2 = ini.IniReadValue("MB2", "PORTNAME");
                if (pn2 != string.Empty)
                {
                    drpPortName2.Text = pn2;
                }

                string brate2 = ini.IniReadValue("MB2", "BRATE");
                if (brate2 != string.Empty)
                {
                    drpBaudrate2.Text = brate2;
                }


                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #region ���������


        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {

                this.ShowInfoMessage("����ǰȷ�������治�������ģʽ��������쳣");
                //frmProductCheckMBTest frm = new frmProductCheckMBTest();

                //frm.ShowDialog();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        #endregion

       
    }
}