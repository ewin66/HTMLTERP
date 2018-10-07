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
using HttSoft.MLTERP.Sys.Enum;

namespace MLTERP
{
    public partial class frmTowelProductionEdit : frmAPBaseUISinEdit
    {
        public frmTowelProductionEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtTitle.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入标题");
            //    txtTitle.Focus();
            //    return false;
            //}            

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            TowelProductionRule rule = new TowelProductionRule();
            TowelProduction entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            TowelProductionRule rule = new TowelProductionRule();
            TowelProduction entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            TowelProduction entity = new TowelProduction();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtFormNo.Text = entity.FormNo.ToString();
            txtFormDate.DateTime = entity.FormDate;
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtCardNo.Text = entity.CardNo.ToString();
            txtQty.Text = entity.Qty.ToString();
            txtMWidth.Text = entity.MWidth.ToString();
            txtMWeight.Text = entity.MWeight.ToString();
            txtSeLaoDu.Text = entity.SeLaoDu.ToString();
            txtSeCha.Text = entity.SeCha.ToString();
            txtXishuiXing.Text = entity.XishuiXing.ToString();
            drpWOTypeID.EditValue = SysConvert.ToInt32(entity.WOTypeID);

            drpSaleOPID.EditValue = entity.SaleOPID.ToString();

            txtHeGe.Text = entity.HeGe.ToString();
            txtPackNo.Text = entity.PackNo.ToString();
            txtBoxNo.Text = entity.BoxNo.ToString();

            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;

            if (!findFlag)
            {

            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            TowelProductionRule rule = new TowelProductionRule();
            TowelProduction entity = EntityGet();
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
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_TowelProduction";
            //

            txtFormDate.DateTime = DateTime.Now;
            txtMakeDate.DateTime = DateTime.Now;
            txtMakeOPName.Text = FParamConfig.LoginName;

            Common.BindWOTypeType(drpWOTypeID, true);
            DevMethod.BindOP(drpSaleOPID, new int[] { (int)EnumOPDep.生产部 }, true);



        }
        public override void IniInsertSet()
        {
            base.IniInsertSet();
            txtMakeDate.DateTime = DateTime.Now;
            txtFormDate.DateTime = DateTime.Now;
            txtMakeOPName.Text = FParamConfig.LoginName;

            drpWOTypeID.EditValue = this.FormListAID;

            txtFormNo_DoubleClick(null, null);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private TowelProduction EntityGet()
        {
            TowelProduction entity = new TowelProduction();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim();
            entity.FormDate = txtFormDate.DateTime;
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
            entity.MakeDate = txtMakeDate.DateTime;
            entity.CardNo = txtCardNo.Text.Trim();
            entity.Qty = SysConvert.ToDecimal(txtQty.Text.Trim());
            entity.MWidth = txtMWidth.Text.Trim();
            entity.MWeight = txtMWeight.Text.Trim();
            entity.SeLaoDu = txtSeLaoDu.Text.Trim();
            entity.SeCha = txtSeCha.Text.Trim();
            entity.XishuiXing = txtXishuiXing.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.HeGe = txtHeGe.Text.Trim();
            entity.PackNo = txtPackNo.Text.Trim();
            entity.BoxNo = txtBoxNo.Text.Trim();

            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);

            entity.WOTypeID = SysConvert.ToInt32(drpWOTypeID.EditValue);
            entity.FAid = SysConvert.ToInt32(drpWOTypeID.EditValue);

            return entity;
        }
        #endregion

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    ProductCommon.FormNoIniSet(txtFormNo, "WO_TowelProduction", "FormNo", this.FormListAID);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }




        public override void btnSubmit_Click(object sender, EventArgs e)
        {
            //base.btnSubmit_Click(sender, e);
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交1))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }
                if (!HTSubmitCheck(FormStatus.提交))
                {
                    return;
                }

                //HTSubmit(_HTDataTableName, _HTDataID.ToString());
                TowelProductionPlanDtsRule rule = new TowelProductionPlanDtsRule();
                rule.RSubmit(HTDataID,1);

                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        public override void btnSubmitCancel_Click(object sender, EventArgs e)
        {
            //base.btnSubmitCancel_Click(sender, e);
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交1))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }
                if (!HTSubmitCheck(FormStatus.撤消提交))
                {
                    return;
                }

                //HTSubmit(_HTDataTableName, _HTDataID.ToString());
                TowelProductionPlanDtsRule rule = new TowelProductionPlanDtsRule();
                rule.RSubmit(HTDataID, 0);

                FCommon.AddDBLog(this.Text, FormStatus.撤消提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }




    }
}