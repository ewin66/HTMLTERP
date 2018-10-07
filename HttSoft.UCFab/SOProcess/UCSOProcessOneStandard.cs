using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;

namespace HttSoft.UCFab
{
    /// <summary>
    /// ���ܣ��������ȱ� ��׼��ʽ (�����ɳ��ֶ��ģʽ)
    /// ���ߣ�Standy
    /// ���ڣ�2015-5-15
    /// </summary>
    public partial class UCSOProcessOneStandard : UCSOProcessOneBase
    {
        public UCSOProcessOneStandard()
        {
            InitializeComponent();
        }

        #region �鷽����д

        /// <summary>
        /// ִ�л滭
        /// һ����ȫ����ֵ��ɺ�
        /// </summary>
        public override void UCAct()
        {
            if (UCDataSource != null)
            {
                if (UCDataSource.Length > 1)
                {
                    groupToolButton.Visible = true;
                    lbTotalCount.Text = UCDataSource.Length.ToString();
                }
                else
                {
                    groupToolButton.Visible = false;
                }
                if (UCDataSource.Length > 0)
                {
                    SetOneDataSource(UCDataSource[0], 0);
                }
                else
                {
                    SetOneDataSource(null, 0);
                }
            }
            else
            {
            }
        }


        /// <summary>
        /// ��ʼ��
        /// </summary>
        public override void UCIni()
        {
            if (UCSettingDr != null)
            {
                lblTitle.Text = "STEP " + UCStepIndex.ToString() + UCSettingDr["Name"].ToString();
                UCStepID = SysConvert.ToInt32(UCSettingDr["ID"]);
            }
        }
        #endregion

        #region �ڲ�����
        /// <summary>
        /// ����һ������Դ
        /// </summary>
        /// <param name="dr">������Դ</param>
        /// <param name="rowIndex">�к�</param>
        void SetOneDataSource(DataRow dr,int rowIndex)
        {
            if (dr != null)
            {
                txtFormDate.Text = SysConvert.ToDateTime(dr["FormDate"]).ToString("yyyy-MM-dd");
                txtFormNo.Text = dr["FormNo"].ToString();
                txtTotalQty.Text = dr["Qty"].ToString();
                txtReceiveQty.Text = dr["ReceiveQty"].ToString();

                lbShowIndex.Text = (rowIndex + 1).ToString();
            }
            else
            {
                txtFormDate.Text = "";
                txtFormNo.Text = "";
                txtTotalQty.Text = "";
                txtReceiveQty.Text = "";

                lbShowIndex.Text = "0";
            }
        }
        #endregion
        #region �ڲ�����
        int _ShowIndex = 0;
        int ShowIndex
        {
            get
            {
                return _ShowIndex;
            }
            set
            {
                if (value < 0)
                {
                    _ShowIndex = 0;
                }
                else if (value >= UCDataSource.Length)
                {
                    _ShowIndex = UCDataSource.Length - 1;
                }
                else
                {
                    _ShowIndex = value;
                    SetOneDataSource(UCDataSource[_ShowIndex], _ShowIndex);//����һ������Դ
                }
            }
        }
        #endregion

        #region ��ť�¼�
        /// <summary>
        /// ��һҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                ShowIndex = ShowIndex + 1;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ǰһҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                ShowIndex = ShowIndex - 1;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
    }
}
