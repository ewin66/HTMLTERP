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
    /// <summary>
    /// 功能：仓库单据类型管理表
    /// 作者：刘德苏
    /// 日期：2012-4-19
    /// 操作：新增
    /// </summary>
    public partial class frmFormListEdit : frmAPBaseUISinEdit
    {
        public frmFormListEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtID.Text.Trim() == "")
            {
                this.ShowMessage("请输入ID");
                txtID.Focus();
                return false;
            }

            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("请输入编号");
                txtCode.Focus();
                return false;
            }

            if (txtFormNM.Text.Trim() == "")
            {
                this.ShowMessage("请输入名称");
                txtFormNM.Focus();
                return false;
            }

            if (SysConvert.ToString(drpParentID.EditValue) == "")
            {
                this.ShowMessage("请选择父类型");
                drpParentID.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            FormListRule rule = new FormListRule();
            FormList entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            FormListRule rule = new FormListRule();
            FormList entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            FormList entity = new FormList();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtID.Text = entity.ID.ToString();
            txtCode.Text = entity.Code.ToString(); 
  			txtFormNM.Text = entity.FormNM.ToString(); 

  			drpParentID.EditValue = SysConvert.ToInt32(entity.ParentID.ToString());

            drpIsShow.EditValue =SysConvert.ToInt32(entity.IsShow.ToString()); 
  			drpFormNoControlID.EditValue =SysConvert.ToInt32(entity.FormNoControlID.ToString());
            drpWHTypeID.EditValue = entity.WHTypeID;
  			txtRemark.Text = entity.Remark.ToString();
            drpVendorTypeID.EditValue = entity.VendorTypeID;
            drpVendorTypeID2.EditValue = entity.VendorTypeID2;
            drpVendorTypeID3.EditValue = entity.VendorTypeID3;
            drpVendorTypeID4.EditValue = entity.VendorTypeID4;
  			drpCheckSOFlag.EditValue = entity.CheckSOFlag;
            txtSaleFlag.EditValue = entity.SaleFlag;
            txtColorFlag.EditValue = entity.ColorFlag;
            txtBuyFlag.EditValue = entity.BuyFlag; 
  			
            txtOthFlag.EditValue = entity.OthFlag;
            drpDZFlag.EditValue = entity.DZFlag;
  			drpDZType.EditValue = entity.DZType;
            txtCaiWuFlag.EditValue = entity.CaiWuFlag; 
  			drpCaiWuType.EditValue = entity.CaiWuType;
            drpDefaultWH.EditValue = entity.DefaultWHID;
            drpLoadFormTypeID.EditValue = entity.LoadFormTypeID;
            drpFillDataTypeID.EditValue = entity.FillDataTypeID;
            drpCheckFlag.EditValue = entity.CheckFlag;
            drpMoveFlag.EditValue = entity.MoveFlag;
            txtCheckQtyPer1.Text = entity.CheckQtyPer1.ToString();
            txtCheckQtyFrom.Text = entity.CheckQtyFrom.ToString();
            txtCheckQtyPer2.Text = entity.CheckQtyPer2.ToString();
            txtVendorIDCaption.Text = entity.VendorIDCaption;
            SetCheckInOutType(chkLamp1, entity.THLoadFormListIDStr);

            drpDefaultVendorID.EditValue = entity.DefaultVendorID;
            drpDefaultSubTypeID.EditValue = entity.DefaultSubTypeID;

            drpDEditReadOnlyFlag.EditValue = entity.DEditReadOnlyFlag;
            drpDBFlag.EditValue = entity.DBFlag;

            if (!findFlag)
            {
              
            }
        }

        /// <summary>
        /// 设置出入库类型
        /// </summary>
        /// <param name="p_CheckList"></param>
        /// <param name="p_CheckValus"></param>
        private void SetCheckInOutType(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList, string p_CheckValus)
        {
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                p_CheckList.SetItemCheckState(i, CheckState.Unchecked);
            }
            string[] VenodrTypes = p_CheckValus.Split(',');

            foreach (string dr in VenodrTypes)
            {
                for (int i = 0; i < p_CheckList.ItemCount; i++)
                {
                    if (dr == p_CheckList.GetItemValue(i).ToString())//
                    {
                        p_CheckList.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }


        /// <summary>
        /// 获取面料类别
        /// </summary>
        /// <param name="p_CheckList"></param>
        /// <returns></returns>
        private string GetCheckInOutType(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList)
        {
            string MLLB = string.Empty;
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                if (p_CheckList.GetItemCheckState(i) == CheckState.Checked)
                {
                    if (MLLB == string.Empty)
                    {
                        MLLB += p_CheckList.GetItemValue(i).ToString();
                    }
                    else
                    {
                        MLLB += "," + p_CheckList.GetItemValue(i).ToString();
                    }

                }
            }
            return MLLB;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FormListRule rule = new FormListRule();
            FormList entity = EntityGet();
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
        /// 编辑单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniUpdateSet()
        {
            txtID.Properties.ReadOnly = true;
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_FormList";
            Common.BindWHType(drpWHTypeID, true);
            Common.BindWHCaiWuType(drpCaiWuType, true);
            Common.BindDZType(drpDZType, true);
            Common.BindFillDataType(drpFillDataTypeID, true);       //数据回填
            Common.BindSubType(drpParentID, true);
            //Common.BindFormNoControlID(drpFormNoControlID, true);
            Common.BindFormNoControl(drpFormNoControlID, true);
            Common.BindDefaultWH(drpDefaultWH, true);       //默认仓库
            Common.BindLoadFormType(drpLoadFormTypeID, true);   //加载窗体类型
            Common.BindVendorType(drpVendorTypeID, true);
            Common.BindVendorType(drpVendorTypeID2, true);
            Common.BindVendorType(drpVendorTypeID3, true);
            Common.BindVendorType(drpVendorTypeID4, true);
            Common.BindDZFlag(drpDZFlag, true);//绑定对账标志
            Common.BindTHWHLoad(chkLamp1, true);

            Common.BindVendor(drpDefaultVendorID,true);

            Common.BindSubType(drpDefaultSubTypeID, HTDataID, true);        
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FormList EntityGet()
        {
            FormList entity = new FormList();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();
            entity.ID =SysConvert.ToInt32(txtID.Text.Trim());
  			entity.FormNM = txtFormNM.Text.Trim(); 
  			entity.ParentID = SysConvert.ToInt32(drpParentID.EditValue); 
  			entity.IsShow = SysConvert.ToInt32(drpIsShow.EditValue); 
  			entity.FormNoControlID = SysConvert.ToInt32(drpFormNoControlID.EditValue); 
  			entity.WHTypeID = SysConvert.ToInt32(drpWHTypeID.EditValue); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.VendorTypeID = SysConvert.ToInt32(drpVendorTypeID.EditValue);
            entity.VendorTypeID2 = SysConvert.ToInt32(drpVendorTypeID2.EditValue);
            entity.VendorTypeID3 = SysConvert.ToInt32(drpVendorTypeID3.EditValue);
            entity.VendorTypeID4 = SysConvert.ToInt32(drpVendorTypeID4.EditValue);  
  			entity.CheckSOFlag = SysConvert.ToInt32(drpCheckSOFlag.EditValue); 
  			entity.SaleFlag = SysConvert.ToInt32(txtSaleFlag.EditValue); 
  			entity.ColorFlag = SysConvert.ToInt32(txtColorFlag.EditValue); 
  			entity.BuyFlag = SysConvert.ToInt32(txtBuyFlag.EditValue);
  			entity.OthFlag = SysConvert.ToInt32(txtOthFlag.EditValue); 
  			entity.DZFlag = SysConvert.ToInt32(drpDZFlag.EditValue); 
  			entity.DZType = SysConvert.ToInt32(drpDZType.EditValue);
            entity.CaiWuFlag = SysConvert.ToInt32(txtCaiWuFlag.EditValue); 
  			entity.CaiWuType = SysConvert.ToInt32(drpCaiWuType.EditValue);
            entity.DefaultWHID = SysConvert.ToString(drpDefaultWH.EditValue);
            entity.LoadFormTypeID = SysConvert.ToInt32(drpLoadFormTypeID.EditValue);
            entity.CheckFlag = SysConvert.ToInt32(drpCheckFlag.EditValue);
            entity.MoveFlag = SysConvert.ToInt32(drpMoveFlag.EditValue);
            entity.FillDataTypeID = SysConvert.ToInt32(drpFillDataTypeID.EditValue);
            entity.THLoadFormListIDStr = GetCheckInOutType(chkLamp1);
            entity.CheckQtyPer1 = Convert.ToDecimal(txtCheckQtyPer1.Text.Trim());
            entity.CheckQtyFrom = Convert.ToDecimal(txtCheckQtyFrom.Text.Trim());
            entity.CheckQtyPer2 = Convert.ToDecimal(txtCheckQtyPer2.Text.Trim());
            entity.VendorIDCaption = txtVendorIDCaption.Text.Trim();



            entity.DefaultVendorID = SysConvert.ToString(drpDefaultVendorID.EditValue);
            entity.DefaultSubTypeID = SysConvert.ToInt32(drpDefaultSubTypeID.EditValue);

            entity.DEditReadOnlyFlag = SysConvert.ToInt32(drpDEditReadOnlyFlag.EditValue);
            entity.DBFlag = SysConvert.ToInt32(drpDBFlag.EditValue);
            return entity;
        }
        #endregion

        #region 选择
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkLamp1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                string outstr = string.Empty;
                for (int i = 0; i < chkLamp1.ItemCount; i++)
                {
                    if (chkLamp1.GetItemCheckState(i) == CheckState.Checked)
                    {
                        if (outstr != string.Empty)
                        {
                            outstr += ",";
                        }
                        outstr += chkLamp1.GetItemText(i).ToString();
                    }
                }
                drpLamp1.EditValue = outstr;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion


        /// <summary>
        /// 绑定客户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpDefaultSubTypeID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Common.BindVendorByFormListID(drpDefaultVendorID, SysConvert.ToInt32(drpDefaultSubTypeID.EditValue), true);//设置客户
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }





    }
}