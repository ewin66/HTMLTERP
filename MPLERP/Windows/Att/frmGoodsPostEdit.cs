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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;
///

///
namespace MLTERP
{
    public partial class frmGoodsPostEdit : frmAPBaseUISinEdit
    {
        public frmGoodsPostEdit()
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

            if (SysConvert.ToInt32(drpPostFormType.EditValue) == 0)
            {
                this.ShowMessage("请选择快递来源");
                drpPostFormType.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择收货单位");
                drpVendorID.Focus();
                return false;
            }

            if (SysConvert.ToString(drpPostComID.EditValue) == "")
            {
                this.ShowMessage("请选择快递公司");
                drpPostComID.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            GoodsPostRule rule = new GoodsPostRule();
            GoodsPost entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            GoodsPostRule rule = new GoodsPostRule();
            GoodsPost entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            GoodsPost entity = new GoodsPost();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtFormNo.Text = entity.FormNo.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtPostCode.Text = entity.PostCode.ToString();
            drpRecName.EditValue = entity.RecName.ToString();
            drpRecPhone.EditValue = entity.RecPhone.ToString(); 
  			txtPostFee.Text = entity.PostFee.ToString();
            drpVendorID.EditValue = entity.VendorID;
            drpRecAddress.EditValue = entity.RecAddress.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            drpJSFlag.EditValue = entity.JSFlag;
  			txtJSDate.DateTime = entity.JSDate; 
  			txtJSFee.Text = entity.JSFee.ToString(); 
  			txtJSRemark.Text = entity.JSRemark.ToString();
            drpPostComID.EditValue = entity.PostComID;
            drpPostComFirst.EditValue = entity.PostComFirst;
            txtFJR.Text = entity.FJR.ToString();
            txtPostType.Text = entity.PostType.ToString();
            drpGOFlag.EditValue = entity.GOFlag;
            txtFKType.Text = entity.SKType.ToString();
            drpJJVendor.EditValue = entity.JJVendor.ToString();

            drpPostFormType.EditValue =entity.PostFormType;
            txtContext.Text = entity.Context;
            txtConFormNo.Text = entity.ConFormNo;
            if (!findFlag)
            {
              
            }
            string sql = "SELECT * FROM SMS_MSGMain WHERE DID=" + SysString.ToDBString(HTDataID);
            sql += " AND MSGSourceID=" + SysString.ToDBString((int)EnumMSGSource.快递单);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                lbSendShow.Text = "已发送";
            }
            else
            {
                lbSendShow.Text = "未发送";
            }
           
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            GoodsPostRule rule = new GoodsPostRule();
            GoodsPost entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProductCommon.FormNoCtlEditSet(txtFormNo, "Att_GoodsPost", "FormNo", 0, p_Flag);
            txtConFormNo.Properties.ReadOnly = true;
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Att_GoodsPost";
            
            Common.BindCLS(txtPostType, "Att_GoodsPost", "PostType", true);
            Common.BindCLS(txtFKType, "Att_GoodsPost", "SKType", true);
         //  drpVendorID_EditValueChanged(null, null);
            txtPostType.EditValue = "寄出";
          //  this.ToolBarItemAdd(32, "btnSend", "发送短信", true, btnSend_Click, eShortcut.F9);
           // this.ToolBarItemAdd(32, "btnCancelSend", "取消发送", true, btnCancelSend_Click, eShortcut.F9);
            Common.BindPostFormType(drpPostFormType,true);
            //
          drpVendorID_EditValueChanged(null, null);

        }

        /// <summary>
        /// 新增初始化
        /// </summary>
        public override void IniInsertSet()
        {
            txtJSDate.DateTime = DateTime.Now.Date;
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            txtFJR.Text = FParamConfig.LoginName;
        }
        public override void IniRefreshData()
        {
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂, (int)EnumVendorType.检测机构, (int)EnumVendorType.供应商, (int)EnumVendorType.织厂, (int)EnumVendorType.染厂, (int)EnumVendorType.其他加工厂, (int)EnumVendorType.工厂 }, true);
            new VendorProc(drpVendorID);
            Common.BindVendor(drpPostComID, new int[] { (int)EnumVendorType.快递公司 }, true);
            new VendorProc(drpPostComID);
            Common.BindVendor(drpPostComFirst, new int[] { (int)EnumVendorType.快递公司 }, true);
            new VendorProc(drpPostComFirst);
            Common.BindVendor(drpJJVendor, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂, (int)EnumVendorType.检测机构, (int)EnumVendorType.供应商, (int)EnumVendorType.织厂, (int)EnumVendorType.染厂, (int)EnumVendorType.其他加工厂, (int)EnumVendorType.工厂 }, true);
            new VendorProc(drpJJVendor);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private GoodsPost EntityGet()
        {
            GoodsPost entity = new GoodsPost();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
  			entity.MakeDate = txtMakeDate.DateTime.Date;

            entity.PostComID = SysConvert.ToString(drpPostComID.EditValue);
            entity.PostComFirst = SysConvert.ToString(drpPostComFirst.EditValue);
  			entity.PostCode = txtPostCode.Text.Trim(); 
  			entity.RecName = SysConvert.ToString(drpRecName.EditValue);
            entity.RecPhone = SysConvert.ToString(drpRecPhone.EditValue); 
  			entity.PostFee = SysConvert.ToDecimal(txtPostFee.Text.Trim());
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.RecAddress = SysConvert.ToString(drpRecAddress.EditValue);
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.JSFlag = SysConvert.ToInt32(drpJSFlag.EditValue); 
  			entity.JSDate = txtJSDate.DateTime.Date; 
  			entity.JSFee = SysConvert.ToDecimal(txtJSFee.Text.Trim()); 
  			entity.JSRemark = txtJSRemark.Text.Trim();

            entity.GOFlag = SysConvert.ToInt32(drpGOFlag.EditValue);
            entity.PostType = txtPostType.Text.Trim();
            entity.SKType = txtFKType.Text.Trim();
            entity.FJR = txtFJR.Text.Trim();

            entity.JJVendor = SysConvert.ToString(drpJJVendor.EditValue);

            entity.PostFormType = SysConvert.ToInt32(drpPostFormType.EditValue);
            entity.ConFormNo = txtConFormNo.Text.Trim();
            entity.Context = txtContext.Text.Trim();
            return entity;
        }
        #endregion

        #region 其他方法
        /// <summary>
        /// 得到收货单位地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       

        /// <summary>
        /// 双击生成快递单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            if (HTFormStatus == FormStatus.新增)
            {
                //FormNoControlRule rule = new FormNoControlRule();
                //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.快递单号);  
                ProductCommon.FormNoIniSet(txtFormNo, "Att_GoodsPost", "FormNo", 0);           
            }
        }
        #endregion

        #region 发送和取消
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID == 0)
                {
                    this.ShowMessage("请保存数据后发送短信息！");
                    return;
                }

                if (drpRecPhone.EditValue == "")
                {
                    this.ShowMessage("请输入收件人号码后点击发送信息！");
                    return;
                }
                if (drpRecPhone.EditValue.ToString().Length != 11)
                {
                    this.ShowMessage("请输入正确的收件人号码后点击发送信息！");
                    return;
                }
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限2))
                {
                    this.ShowMessage("没有此权限，请联系管理员");
                    return;
                }
                MSGMainRule rule = new MSGMainRule();
                MSGMain entity = new MSGMain();
                entity.FormDate = DateTime.Now;
                entity.InsertTime = DateTime.Now;
                entity.MSGSourceID = (int)EnumMSGSource.快递单;
                entity.SendPhone = "***********";//发送短信号码
                entity.TargetPhone = SysConvert.ToString(drpRecPhone.EditValue);
                entity.TaregtInfo = SysConvert.ToString(drpRecName.EditValue);
                entity.SendTime = DateTime.Now;
                string Context = "";
                Context += "尊敬的客户：您好！您的快递已寄出，快递公司：";
                Context +=Common.GetVendorNameByVendorID(drpPostComID.EditValue.ToString());
                Context += ",快递单号：";
                Context += txtPostCode.Text.Trim();
                Context += "请注意查收，如有疑问请来电。   杭州云虹纺织品进出口有限公司";
                entity.Context = Context;
                entity.SendDesc = "来源：快递管理，单号：" + txtFormNo.Text.Trim() + ",收货单位：" + Common.GetVendorNameByVendorID(drpVendorID.EditValue.ToString());
                entity.SendInfo += ",发件人："+txtFJR.Text.Trim();
                entity.DID = HTDataID;
                rule.RAdd(entity);
                this.ShowInfoMessage("发送成功！");
                lbSendShow.Text = "已发送";
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnCancelSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限2))
                {
                    this.ShowMessage("没有此权限，请联系管理员");
                    return;
                }
                string sql = "SELECT * FROM SMS_MSGMain WHERE DID="+SysString.ToDBString(HTDataID);
                sql += " AND MSGSourceID="+SysString.ToDBString((int)EnumMSGSource.快递单);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count ==0)
                {
                    this.ShowMessage("信息还未发送！");
                    return;
                }
                sql = "SELECT * FROM SMS_MSGMain WHERE DID=" + SysString.ToDBString(HTDataID);
                sql += " AND MSGSourceID=" + SysString.ToDBString((int)EnumMSGSource.快递单);
                sql += " AND ISNULL(SendFlag,0)=1";
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    this.ShowMessage("信息已发送给客户，取消无效！");
                    return;
                }

                sql = "DELETE SMS_MSGMain WHERE DID=" + SysString.ToDBString(HTDataID);
                sql += " AND MSGSourceID=" + SysString.ToDBString((int)EnumMSGSource.快递单);
                SysUtils.ExecuteNonQuery(sql);
                this.ShowMessage("取消成功！");
                lbSendShow.Text = "未发送";
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        /// <summary>
        /// 加载订单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtConFormNo_DoubleClick(object sender, EventArgs e)
        {
             try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    LoadSaleOrder();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
                {

                    Common.BindVendorContact(drpRecName, SysConvert.ToString(drpVendorID.EditValue), true);
                    Common.BindVendorAddress(drpRecAddress, SysConvert.ToString(drpVendorID.EditValue), true);
                   // Common.BindVendorHisAddress(drpRecAddress, SysConvert.ToString(drpVendorID.EditValue), true);

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void LoadSaleOrder()
        {
            frmLoadOrder frm = new frmLoadOrder();
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.OrderID != null && frm.OrderID.Length != 0)
            {
                for (int i = 0; i < frm.OrderID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.OrderID[i]);
                }
                setItemNews(str);
            }
        }

        /// <summary>
        /// 加载订单数据
        /// </summary>
        /// <param name="p_Str"></param>
        private void setItemNews(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            string sql = "SELECT FormNo,VendorID FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[0]));
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count >0)
            {
               txtConFormNo.Text=SysConvert.ToString(dt.Rows[0]["FormNo"]);
               drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);
            }
        }

        private void drpRecName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToString(drpRecName.EditValue) != string.Empty)
                {
                    drpRecPhone.Text = Common.GetVendorContactTelByVendorContact(SysConvert.ToString(drpVendorID.EditValue), SysConvert.ToString(drpRecName.EditValue));
                    
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



    }
}