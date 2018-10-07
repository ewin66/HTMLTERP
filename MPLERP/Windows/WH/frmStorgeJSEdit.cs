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
using System.Data.SqlClient;
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmStorgeJSEdit : frmAPBaseUIFormEdit
    {
        public frmStorgeJSEdit()
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
                this.ShowMessage("请输入结算单号");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpMakeOPID.EditValue)=="")
            {
                this.ShowMessage("请选择制单人");
                drpMakeOPID.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            StorgeJSRule rule = new StorgeJSRule();
            StorgeJS entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            StorgeJSRule rule = new StorgeJSRule();
            StorgeJS entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            StorgeJS entity = new StorgeJS();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.FormNo;

             txtFormNo.Text = entity.FormNo.ToString(); 
  			txtFormDate.DateTime = entity.FormDate; 
  			txtJSDateS.DateTime = entity.JSDateS; 
  			txtJSDateE.DateTime = entity.JSDateE;
            drpMakeOPID.EditValue = entity.FormOPID;
  			txtRemark.Text = entity.Remark.ToString();
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            lblJS.ForeColor = Color.Red;
            if (!findFlag)
            {
              
            }
            switch (entity.JSFlag)
            {
                case 1:
                    lblJS.Text = "已结算";
                  
                    break;
                case 0:
                    lblJS.Text = "未结算";
                    break;
                default:
                    lblJS.Text = ""; break;
            }
            SetSubStatus();
            BindGrid();
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            StorgeJSRule rule = new StorgeJSRule();
            StorgeJS entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(new Control[] { drpQWHID, txtQItemCode, txtJHFormNo }, true);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_StorgeJS";
            this.HTDataDts = gridView1;
            Common.BindOP(drpMakeOPID, true);
            //if (this.FormListAID > 0)
            //{
            //    Common.BindWHByWHType(drpQWHID, this.FormListAID, true);
            //}
            //else
            //{
            //    Common.BindWHByWHType(drpQWHID, new int[]{1,2,3,4,6}, true);
            //}
            Common.BindAllWH(drpQWHID, true);
            Common.BindAllWH(drpResWHID, true);
            this.ToolBarItemAdd(29, "btnJs", "结算", true, btnJs_Click);
            this.ToolBarItemAdd(29, "btnJsCancel", "撤销结算", true, btnJsCancel_Click);

        }

        /// <summary>
        /// 新增初始化
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
            string sql = " SELECT TOP 1 JSDateE FROM WH_StorgeJS ORDER BY JSDateE DESC";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                txtJSDateS.DateTime = SysConvert.ToDateTime(dt.Rows[0][0]).AddDays(1);
                txtJSDateE.DateTime = SysConvert.ToDateTime(dt.Rows[0][0]).AddDays(ParamConfig.QueryDayNum + 1);
            }
            drpMakeOPID.EditValue = FParamConfig.LoginID;
            txtFormNo_EditValueChanged(null, null);
            
           
        }

        /// <summary>
        /// 绑定结算数据
        /// </summary>
        public  void BindGrid()
        {

            StorgeJSDtsRule rule = new StorgeJSDtsRule();
            string conditionStr = " AND MainID=" + SysString.ToDBString(HTDataID);

            if (!Common.CheckLookUpEditBlank(drpQWHID))
            {
                conditionStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
            }
            if (txtQItemCode.Text.Trim() != string.Empty)
            {
                conditionStr += " AND ItemCode=" + SysString.ToDBString(txtQItemCode.Text);
            }
            if (txtJHFormNo.Text.Trim() != string.Empty)
            {
                conditionStr += " AND JHFormNo=" + SysString.ToDBString(txtJHFormNo.Text);
            }
            gridView1.GridControl.DataSource = rule.RShow(conditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private StorgeJS EntityGet()
        {
            StorgeJS entity = new StorgeJS();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.FormDate = txtFormDate.DateTime.Date; 
  			entity.JSDateS = txtJSDateS.DateTime.Date; 
  			entity.JSDateE = txtJSDateE.DateTime.Date;
            entity.FormOPID = drpMakeOPID.EditValue.ToString();

  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
       
        #endregion

        #region 结算-撤销结算
        private void btnJs_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    this.ShowMessage("请先保存单据后再进行结算操作");
                    return;
                }
                StorgeJS entity = new StorgeJS();
                entity.ID = HTDataID;
                entity.SelectByID();
                if (entity.SubmitFlag == (int)YesOrNo.No)
                {
                    this.ShowMessage("请先提交单据后再进行结算");
                    return;
                }
                if (entity.JSFlag == (int)YesOrNo.Yes)
                {
                    this.ShowMessage("该单据已经进行结算，请核对");
                    return;
                }

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@JSID", SqlDbType.Int);
                param[0].Value = SysConvert.ToInt32(HTDataID);//ID

                param[1] = new SqlParameter("@JSOPID", SqlDbType.VarChar, 50);
                param[1].Value = SysConvert.ToString(FParamConfig.LoginID);//结算人ID

                DataTable dt = SysUtils.ExecuteStoredProc("USP3_WH_JSEXEC", param);
                gridView1.GridControl.DataSource = dt;
                gridView1.GridControl.Show();
                BindGrid();
                SetSubStatus();
                lblJS.Text = "已结算";
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private void btnJsCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    this.ShowMessage("请先保存单据后再进行撤销结算操作");
                    return;
                }
                StorgeJS entity = new StorgeJS();
                entity.ID = HTDataID;
                entity.SelectByID();
                if (entity.JSFlag == (int)YesOrNo.No)
                {
                    this.ShowMessage("该单据还未进行结算，请核对");
                    return;
                }

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@JSID", SqlDbType.Int);
                param[0].Value = SysConvert.ToInt32(HTDataID);//ID

                param[1] = new SqlParameter("@JSOPID", SqlDbType.VarChar, 50);
                param[1].Value = SysConvert.ToString(FParamConfig.LoginID);//结算人ID

                DataTable dt = SysUtils.ExecuteStoredProc("USP3_WH_JSEXECCancel", param);
                gridView1.GridControl.DataSource = dt;
                gridView1.GridControl.Show();
                BindGrid();
                SetSubStatus();
                lblJS.Text = "未结算";
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion 

        private void txtFormNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.结算单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void SetSubStatus()
        {
            ButtonItem btnJs = ToolBarItemGet(-1, "btnJs");
            ButtonItem btnJsCancel = ToolBarItemGet(-1, "btnJsCancel");
            StorgeJS entity = new StorgeJS();
            entity.ID = HTDataID;
            entity.SelectByID();
            if (entity.JSFlag == 1)
            {
                btnJs.Enabled = false;
                btnJsCancel.Enabled = true;
            }
            else
            {
                btnJs.Enabled = true;
                btnJsCancel.Enabled = false;
            }
        }
          
         
         
        #region  提交-撤销提交 
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                StorgeJSRule rule = new StorgeJSRule();
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
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                StorgeJSRule rule = new StorgeJSRule();
                rule.RSubmit(HTDataID, 0);

                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtQItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindGrid();
            }
        }

        private void drpQWHID_EditValueChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
  
    }
}