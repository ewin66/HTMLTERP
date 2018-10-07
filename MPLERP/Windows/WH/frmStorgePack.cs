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
    /// 开匹管理
    /// </summary>
    public partial class frmStorgePack : frmAPBaseUIRpt
    {
        public frmStorgePack()
        {
            InitializeComponent();
        }

       

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (SysConvert.ToString(drpQWHID.EditValue) != "")
            {
                tempStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
            }

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (txtColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if (txtColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }

            if (txtItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE "+SysString.ToDBString("%"+txtItemName.Text.Trim()+"%");
            }
            if (txtMWeightS.Text.Trim() != "")
            {
                tempStr += " AND MWeight >"+SysString.ToDBString(SysConvert.ToDecimal(txtMWeightS.Text.Trim()));
            }

            if (txtMWeightE.Text.Trim() != "")
            {
                tempStr += " AND MWeight <"+SysString.ToDBString(SysConvert.ToDecimal(txtMWeightE.Text.Trim()));
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            StorgeRule rule = new StorgeRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            gridView1.GridControl.Show();


        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_Storge";
            this.HTDataList = gridView1;
            Common.BindWHByWHType(drpQWHID, true);
            drpQWHID_EditValueChanged(null, null);
            //HTDataList.OptionsBehavior.ShowEditorOnMouseUp = false;
            gridView1.GridControl.ContextMenuStrip = contextMenuStrip1;
        }

        /// <summary>
        /// 重写初始化之后的方法
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }

        #endregion
          
        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Storge EntityGet()
        {
            Storge entity = new Storge();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion


        #region   其他事件
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpQWHID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetCondtion();
                this.BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        /// <summary>
        /// 开匹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPackSet_Click(object sender, EventArgs e)
        {
            try
            {
                frmSetPack frm = new frmSetPack();
                frm.StorgeID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"ID"));
                frm.ShowDialog();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }



        


    }
}