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
using DevExpress.XtraEditors.Controls;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmWHALarmDtsEdit : frmAPBaseUISinEdit
    {
        public frmWHALarmDtsEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (Common.CheckLookUpEditBlank(drpWHAlarmID))
            {
                this.ShowMessage("请输入预警类型");
                drpWHAlarmID.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpItemCode))
            {
                this.ShowMessage("请输入纱线编码");
                drpItemCode.Focus();
                return false;
            }
            if (txtAlarmLowQty.Text.Trim() == "")
            {
                this.ShowMessage("请输入最低数量");
                txtAlarmLowQty.Focus();
                return false;
            }
            else
            {
                if (!SysConvert.IsDecimal(txtAlarmLowQty.Text.Trim()))
                {
                    this.ShowMessage("最低数量必须为数字，请重新输入");
                    txtAlarmLowQty.Focus();
                    return false;
                }
            }

            if (txtAlarmHighQty.Text.Trim() == "")
            {
                this.ShowMessage("请输入最高数量");
                txtAlarmHighQty.Focus();
                return false;
            }
            else
            {
                if (!SysConvert.IsDecimal(txtAlarmHighQty.Text.Trim()))
                {
                    this.ShowMessage("最高数量必须为数字，请重新输入");
                    txtAlarmHighQty.Focus();
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            WHALarmDtsRule rule = new WHALarmDtsRule();
            WHALarmDts entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            WHALarmDtsRule rule = new WHALarmDtsRule();
            WHALarmDts entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            WHALarmDts entity = new WHALarmDts();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            drpWHAlarmID.EditValue = entity.WHAlarmID;
            drpItemCode.EditValue = entity.ItemCode.ToString();
            txtItemName.Text = entity.ItemName.ToString();
            txtItemStd.Text = entity.ItemStd.ToString();
            txtAlarmLowQty.Text = entity.AlarmLowQty.ToString();
            txtAlarmHighQty.Text = entity.AlarmHighQty.ToString();
            txtRemark.Text = entity.Remark.ToString();


            if (!findFlag)
            {

            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            WHALarmDtsRule rule = new WHALarmDtsRule();
            WHALarmDts entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }
        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {

            txtAlarmLowQty.Text = Common.TrimZero(txtAlarmLowQty.Text);
            txtAlarmHighQty.Text = Common.TrimZero(txtAlarmHighQty.Text);
   
        }
        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_WHALarmDts";

            Common.BindWHAlarmType(drpWHAlarmID, FormListAID,false);

            new ItemProcLookUp(drpItemCode, txtItemName, txtItemStd, txtItemModel, new int[] { (int)EnumItemType.面料 }, true, true);
            //if (this.FormListAID == 1)//纱线
            //{
            //    lable.Text = "纱线编码";
            //}
            //if (this.FormListAID == 2)//原料
            //{
            //    new ItemProcLookUp(drpItemCode, txtItemName, txtItemStd, txtItemModel, new int[] { (int)EnumItemType.原料 }, true, true);
            //    lable.Text = "原料编码";
            //}

            SetPosCondition=" AND WHAlarmID IN(SELECT ID FROM WH_WHAlarm WHERE 1=1 AND ItemTypeID=" + FormListAID + ")";
           
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private WHALarmDts EntityGet()
        {
            WHALarmDts entity = new WHALarmDts();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.WHAlarmID = SysConvert.ToInt32(drpWHAlarmID.EditValue.ToString());
            entity.ItemCode = drpItemCode.EditValue.ToString(); 
  			entity.ItemName = txtItemName.Text.Trim(); 
  			entity.ItemStd = txtItemStd.Text.Trim();
            entity.ItemModel = txtItemModel.Text.Trim();
  			entity.AlarmLowQty = SysConvert.ToDecimal(txtAlarmLowQty.Text.Trim()); 
  			entity.AlarmHighQty = SysConvert.ToDecimal(txtAlarmHighQty.Text.Trim()); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.LastUpdOP = FParamConfig.LoginID;
            entity.LastUpdTime = DateTime.Now.Date;

            return entity;
        }
        #endregion

    }
}