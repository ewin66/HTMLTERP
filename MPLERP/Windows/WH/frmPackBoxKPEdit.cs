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
    public partial class frmPackBoxKPEdit : frmAPBaseUIFormEdit
    {
        public frmPackBoxKPEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入单号");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) == "")
            {
                this.ShowMessage("请选择业务员");
                drpSaleOPID.Focus();
                return false;
            }

            if (SysConvert.ToString(txtKPOPID.EditValue) == "")
            {
                this.ShowMessage("请选择开匹人员");
                txtKPOPID.Focus();
                return false;
            }

            if (!CheckPackNo())
            {
                return false;
            }

            if (SysConvert.ToDecimal(txtTargetQty.Text.Trim()) >= SysConvert.ToDecimal(txtQty.Text.Trim()) && SysConvert.ToDecimal(txtQty.Text.Trim()) != 0 && SysConvert.ToDecimal(txtTargetQty.Text.Trim()) != 0)
            {
                this.ShowMessage("目标条码数量应小于条码数量，请重新输入");
                return false;
            }
            if (SysConvert.ToDecimal(txtTargetWeight.Text.Trim()) >= SysConvert.ToDecimal(txtWeight.Text.Trim()) && SysConvert.ToDecimal(txtWeight.Text.Trim()) != 0 && SysConvert.ToDecimal(txtTargetWeight.Text.Trim()) != 0)
            {
                this.ShowMessage("目标条码公斤数应小于条码公斤数，请重新输入");
                return false;
            }
            if (SysConvert.ToDecimal(txtTargetYard.Text.Trim()) >= SysConvert.ToDecimal(txtYard.Text.Trim()) && SysConvert.ToDecimal(txtYard.Text.Trim()) != 0 && SysConvert.ToDecimal(txtTargetYard.Text.Trim()) != 0)
            {
                this.ShowMessage("目标条码码数应小于条码码数，请重新输入");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 判断条码是否能开匹
        /// </summary>
        /// <returns></returns>
        private bool CheckPackNo()
        {
            string sql = "SELECT BoxNo,BoxStatusID FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(txtBoxNo.Text.Trim());
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                if (SysConvert.ToInt32(dt.Rows[0]["BoxStatusID"]) != (int)EnumBoxStatus.入库)
                {
                    this.ShowMessage("条码[" + txtBoxNo.Text.Trim() + "]不处于入库状态，请检查");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                this.ShowMessage("条码[" + txtBoxNo.Text.Trim() + "]不存在，请检查");
                return false;
            }
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            PackBoxKPRule rule = new PackBoxKPRule();
            PackBoxKP entity = EntityGet();
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            PackBoxKPRule rule = new PackBoxKPRule();
            PackBoxKP entity = EntityGet();
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            PackBoxKP entity = new PackBoxKP();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;

            drpVendorID.EditValue = entity.VendorID;
            txtKPQXDesc.Text = entity.KPQXDesc.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
            txtKPOPID.EditValue = entity.KPOPID.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtBoxNo.Text = entity.BoxNo.ToString();
            txtQty.Text = entity.Qty.ToString();
            txtTargetBoxNo.Text = entity.TargetBoxNo.ToString();
            txtTargetQty.Text = entity.TargetQty.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
            txtColorName.Text = entity.ColorName.ToString();
            txtColorNO.Text = entity.ColorNO.ToString();
            txtWeight.Text = entity.Weight.ToString();
            txtTargetWeight.Text = entity.TargetWeight.ToString();
            txtYard.Text = entity.Yard.ToString();
            txtTargetYard.Text = entity.TargetYard.ToString();
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {

            }
            BindGrid();
        }


        /// <summary>
        /// 绑定Grids
        /// </summary>
        private void BindGrid()
        {
            PackBoxKPDtsRule rule = new PackBoxKPDtsRule();
            gridView1.GridControl.DataSource = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            PackBoxKPRule rule = new PackBoxKPRule();
            PackBoxKP entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            txtQty.Properties.ReadOnly = true;
            txtWeight.Properties.ReadOnly = true;
            txtYard.Properties.ReadOnly = true;
            txtTargetBoxNo.Properties.ReadOnly = true;
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_PackBoxKP";
            this.HTDataDts = this.gridView1;
            Common.BindOP(drpSaleOPID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID);
            Common.BindOP(drpSaleOPID, true);
            Common.BindOP(txtKPOPID, true);
        }

        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            drpSaleOPID.EditValue = FParamConfig.LoginID;
            txtMakeOPName.Text = FParamConfig.LoginName;
        
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private PackBoxKP EntityGet()
        {
            PackBoxKP entity = new PackBoxKP();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.FormDate = DateTime.Now.Date;
            entity.VendorID = drpVendorID.EditValue.ToString();
            entity.KPQXDesc = txtKPQXDesc.Text.Trim();
            entity.SaleOPID = drpSaleOPID.EditValue.ToString();
            entity.KPOPID = SysConvert.ToString(txtKPOPID.EditValue);
            entity.Remark = txtRemark.Text.Trim();
            entity.BoxNo = txtBoxNo.Text.Trim();
            entity.Qty = SysConvert.ToDecimal(txtQty.Text.Trim());
            entity.TargetBoxNo = txtTargetBoxNo.Text.Trim();
            entity.TargetQty = SysConvert.ToDecimal(txtTargetQty.Text.Trim());
            entity.Weight = SysConvert.ToDecimal(txtWeight.Text.Trim());
            entity.TargetWeight = SysConvert.ToDecimal(txtTargetWeight.Text.Trim());
            entity.Yard = SysConvert.ToDecimal(txtYard.Text.Trim());
            entity.TargetYard = SysConvert.ToDecimal(txtTargetYard.Text.Trim());
            entity.ColorNO = SysConvert.ToString(txtColorNO.Text.Trim());
            entity.ColorName = SysConvert.ToString(txtColorName.Text.Trim());
            return entity;
        }


        #endregion


        #region 提交、撤销提交处理
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmit_Click(object sender, EventArgs e)
        {
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

                PackBoxKPRule rule = new PackBoxKPRule();
                rule.RSubmit(HTDataID, 1);

                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 撤销提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmitCancel_Click(object sender, EventArgs e)
        {
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
                //sc 撤销提交前判断细码是否已经出库
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string sql = "SELECT BoxStatusID FROM WH_PackBox WHERE BoxNo = " + SysString.ToDBString(SysConvert.ToString((gridView1.GetRowCellValue(i, "BoxNo"))));
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        if (SysConvert.ToInt32(dt.Rows[0]["BoxStatusID"]) == (int)EnumBoxStatus.出库)
                        {
                            this.ShowMessage("此细码:" + SysConvert.ToString((gridView1.GetRowCellValue(i, "BoxNo"))) + "  已出库，不可撤销提交!");
                            return;
                        }
                    }
                }

                PackBoxKPRule rule = new PackBoxKPRule();
                rule.RSubmit(HTDataID, 0);

                FCommon.AddDBLog(this.Text, FormStatus.撤消提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);

            }
        }
        #endregion

        #region 其它事件
        /// <summary>
        /// 双击生成单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.开匹单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        ///// <summary>
        ///// 条码号改变
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void txtBoxNo_EditValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
        //        {
        //            FormNoControlRule rule = new FormNoControlRule();
        //            txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.开匹单号);
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}


        private void txtBoxNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                    {
                        string sql = "SELECT Qty,Weight,Yard,ColorNum ,ColorName FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(txtBoxNo.Text.Trim());
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            txtQty.Text = dt.Rows[0]["Qty"].ToString();
                            txtWeight.Text = dt.Rows[0]["Weight"].ToString();
                            txtYard.Text = dt.Rows[0]["Yard"].ToString();
                            txtColorNO.Text = dt.Rows[0]["ColorNum"].ToString();
                            txtColorName.Text = dt.Rows[0]["ColorName"].ToString();
                        }
                        else
                        {
                            txtQty.Text = "";
                            txtWeight.Text = "";
                            txtYard.Text = "";
                            txtColorNO.Text = "";
                            txtColorName.Text = "";
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

    }
}