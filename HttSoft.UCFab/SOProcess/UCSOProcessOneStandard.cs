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
    /// 功能：单个进度表单 标准格式 (后续可呈现多个模式)
    /// 作者：Standy
    /// 日期：2015-5-15
    /// </summary>
    public partial class UCSOProcessOneStandard : UCSOProcessOneBase
    {
        public UCSOProcessOneStandard()
        {
            InitializeComponent();
        }

        #region 虚方法重写

        /// <summary>
        /// 执行绘画
        /// 一般在全部赋值完成后
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
        /// 初始化
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

        #region 内部方法
        /// <summary>
        /// 设置一个数据源
        /// </summary>
        /// <param name="dr">行数据源</param>
        /// <param name="rowIndex">行号</param>
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
        #region 内部属性
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
                    SetOneDataSource(UCDataSource[_ShowIndex], _ShowIndex);//设置一个数据源
                }
            }
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 下一页
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
        /// 前一页
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
