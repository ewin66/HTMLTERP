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
   /// 王焕梅添加 2012.05.02 快递管理 
   /// </summary>
    public partial class frmGoodsPost : frmAPBaseUISin
    {
        public frmGoodsPost()
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

            if (chkJSTime.Checked)
            {
                tempStr += " AND JSDate BETWEEN " + SysString.ToDBString(txtJSDateS.DateTime) + " AND " + SysString.ToDBString(txtJSDateE.DateTime);
            }
            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            }
            if (txtPostCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND PostCode = " + SysString.ToDBString(txtPostCode.Text.Trim());
            }
            if (SysConvert.ToString(drpTransComID.EditValue) != "")
            {
                tempStr += " AND PostComID = " + SysString.ToDBString(SysConvert.ToString(drpTransComID.EditValue));
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5430)) && !FParamConfig.LoginHTFlag)//销售订单业务员只查看自己的的订单
            {
                tempStr += " AND MakeOPID IN(" + WCommon.GetStructureMemberOPStr() + ")";
            }
            //if (chkJSFlag.Checked)
            //{
            //    tempStr += " AND JSFlag=1";
            //}
            if (txtFJR.Text.Trim() != "")
            {
                tempStr += " AND FJR LIKE "+SysString.ToDBString("%"+txtFJR.Text.Trim()+"%");
            }
            if (txtFKType.Text.Trim() != "")
            {
                tempStr += " AND SKType="+SysString.ToDBString(txtFKType.Text.Trim());
            }
            if (txtPostType.Text.Trim() != "")
            {
                tempStr += " AND PostType="+SysString.ToDBString(txtPostType.Text.Trim());
            }
            if (txtSJR.Text.Trim() != "")
            {
                tempStr += " AND RecName LIKE" + SysString.ToDBString("%"+txtSJR.Text.Trim()+"%");
            }
            if (txtRecPhone.Text.Trim() != "")
            {
                tempStr += " AND RecPhone LIKE "+SysString.ToDBString("%"+txtRecPhone.Text.Trim()+"%");
            }

            if (SysConvert.ToInt32(drpPostFormType.EditValue) > 0)
            {
                tempStr += " AND PostFormType="+SysString.ToDBString(SysConvert.ToInt32(drpPostFormType.EditValue));
            }

            if (txtConFormNo.Text.Trim() != "")
            {
                tempStr += " AND ConFormNo LIKE "+SysString.ToDBString("%"+txtConFormNo.Text.Trim()+"%");
            }

            tempStr += " ORDER BY FormNo DESC ";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            GoodsPostRule rule = new GoodsPostRule();
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SendDes","'' SendDes"));
            SetGrid(dt);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        private void SetGrid(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr["SendDes"] = GetSendDes(SysConvert.ToInt32(dr["ID"]));
            }
        }

        private string GetSendDes(int p_ID)
        {
            string sql = "SELECT * FROM SMS_MSGMain WHERE DID="+SysString.ToDBString(p_ID);
            sql += " AND MSGSourceID="+SysString.ToDBString((int)EnumMSGSource.快递单);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return "已发送";
            }
            else
            {
                return "未发送";
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
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Att_GoodsPost";
            this.HTDataList = gridView1;
            txtJSDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtJSDateE.DateTime = DateTime.Now.Date;
            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            Common.BindVendor(drpTransComID, new int[] { (int)EnumVendorType.快递公司 }, true);
            new VendorProc(drpTransComID);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户,(int)EnumVendorType.工厂 }, true);
            new VendorProc(drpVendorID);
            chkJSFlag.Checked = false;
            Common.BindCLS(txtPostType, "Att_GoodsPost", "PostType", true);
            Common.BindCLS(txtFKType, "Att_GoodsPost", "SKType", true);
            Common.BindPostFormType(drpPostFormType, true);
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
            return entity;
        }
        #endregion

        private void txtPostCode_EditValueChanged(object sender, EventArgs e)
        {
            GetCondtion();
            BindGrid();
        }

 
    }
}