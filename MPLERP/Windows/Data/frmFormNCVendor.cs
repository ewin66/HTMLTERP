using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：客户流水号查询
    /// 作者：章文强
    /// 日期：2012-04-17
    /// 操作：新增
    /// </summary>
    public partial class frmFormNCVendor : frmAPBaseUISin
    {
        public frmFormNCVendor()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]

        /// <summary>
        /// 查询条件
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (SysConvert.ToString(drpVendorID.EditValue) != "")//根据客户查询
            {
                tempStr += " AND VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            if (SysConvert.ToString(drpFNCVID.EditValue) != "")//根据单据查询
            {
                tempStr += " AND FNCVID=" + SysString.ToDBString(drpFNCVID.EditValue.ToString());
            }
            tempStr += " ORDER BY ID";
            HTDataConditionStr = tempStr;
        }

        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            FormNCVendorRule rule = new FormNCVendorRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FormNCVendorRule rule = new FormNCVendorRule();
            FormNCVendor entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_FormNCVendor";
            this.HTDataList = gridView1;
            Common.BindFNCV(drpFNCVID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.全部 }, true);//客户
            btnQuery_Click(null, null);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FormNCVendor EntityGet()
        {
            FormNCVendor entity = new FormNCVendor();
            entity.ID = HTDataID;      
            return entity;
        }

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        
    }
}