using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HttSoft.UCFab
{
    /// <summary>
    /// 功能：基类 订单显示 标准格式
    /// 作者：Standy
    /// 日期：2015-5-15
    /// </summary>
    public partial class UCSOProcessSOStandard : UCSOProcessSOBase
    {
        public UCSOProcessSOStandard()
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
                if (UCDataSource.Rows.Count > 0)
                {
                    SetOneDataSource(UCDataSource.Rows[0], 0);
                }
            }
        }

        #endregion

        #region 内部方法
        /// <summary>
        /// 设置一个数据源
        /// </summary>
        /// <param name="dr">行数据源</param>
        /// <param name="rowIndex">行号</param>
        void SetOneDataSource(DataRow dr, int rowIndex)
        {
            txtFormDate.Text = dr["FormDate"].ToString();
            txtFormNo.Text = dr["FormNo"].ToString();
            txtTotalQty.Text = dr["Qty"].ToString();
            txtReceiveQty.Text = dr["ReceiveQty"].ToString();
        }
        #endregion
    }
}
