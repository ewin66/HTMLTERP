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
    public partial class frmVendorTrackRecordEdit : frmAPBaseUISinEdit
    {
        public frmVendorTrackRecordEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (drpTrackType.Text.Trim() == "")
            {
                this.ShowMessage("请输入跟踪类型");
                drpTrackType.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue)=="")
            {
                this.ShowMessage("请选择客户");
                drpVendorID.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            VendorTrackRecordRule rule = new VendorTrackRecordRule();
            VendorTrackRecord entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            VendorTrackRecordRule rule = new VendorTrackRecordRule();
            VendorTrackRecord entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            VendorTrackRecord entity = new VendorTrackRecord();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtFormNo.Text = entity.FormNo.ToString(); 
  			txtFormDate.DateTime = entity.FormDate; 
  		
  			drpVendorID.EditValue = entity.VendorID.ToString(); 
  			txtSaleOPID.Tag = entity.SaleOPID.ToString();
            txtSaleOPID.Text = entity.SaleOPID +" "+ Common.GetOPName(entity.SaleOPID);
  			drpTrackType.Text = entity.TrackType.ToString(); 
  			txtTrackTitle.Text = entity.TrackTitle.ToString();
            txtTrackContext.RichText = entity.TrackContextRtf;
            chkTrackFlag.Checked = SysConvert.ToBoolean(entity.TrackFlag);
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
            VendorTrackRecordRule rule = new VendorTrackRecordRule();
            VendorTrackRecord entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);


            //ProductCommon.FormNoIniSet(txtFormNo, "Att_VendorTrackRecord", "FormNo");
            ProductCommon.FormNoCtlEditSet(txtFormNo, "Att_VendorTrackRecord", "FormNo", p_Flag);
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            txtSaleOPID.Text = FParamConfig.LoginName;
            txtSaleOPID.Tag = FParamConfig.LoginID;

        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Att_VendorTrackRecord";


       

            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);

            Common.BindCLS(drpTrackType, "Att_VendorTrackRecord", "TrackType", true);

            //
        }


        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private VendorTrackRecord EntityGet()
        {
            VendorTrackRecord entity = new VendorTrackRecord();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.FormDate = txtFormDate.DateTime.Date;
            if (HTFormStatus == FormStatus.新增)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeDate = DateTime.Now.Date;
            }
  			entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.SaleOPID = SysConvert.ToString(txtSaleOPID.Tag);
  			entity.TrackType = drpTrackType.Text.Trim(); 
  			entity.TrackTitle = txtTrackTitle.Text.Trim();
            entity.TrackContext = txtTrackContext.Text;
            entity.TrackContextRtf = txtTrackContext.RichText;
  			entity.TrackFlag = SysConvert.ToInt32(chkTrackFlag.Checked); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion

        #region 其他事件
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.合同号);
                    ProductCommon.FormNoIniSet(txtFormNo, "Att_VendorTrackRecord", "FormNo");
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