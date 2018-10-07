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
    /// 功能：客户流水号明细
    /// 作者：章文强
    /// 日期：2012-04-17
    /// 操作：新增
    /// </summary>
    public partial class frmFormNCVendorEdit : frmAPBaseUISinEdit
    {
        public frmFormNCVendorEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择客户");
                drpVendorID.Focus();
                return false;
            }   

            if (SysConvert.ToString(drpFNCVID.EditValue) == "")
            {
                this.ShowMessage("请选择单据");
                drpFNCVID.Focus();
                return false;
            }

                  
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            FormNCVendorRule rule = new FormNCVendorRule();
            FormNCVendor entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            FormNCVendorRule rule = new FormNCVendorRule();
            FormNCVendor entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            FormNCVendor entity = new FormNCVendor();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            drpVendorID.EditValue = entity.VendorID;
            drpFNCVID.EditValue = entity.FNCVID;
            txtCurSort.Text = entity.CurSort.ToString();
            txtCurYear.Text = entity.CurYear.ToString();
            txtCurMonth.Text = entity.CurMonth.ToString();
            txtCurDay.Text = entity.CurDay.ToString();
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
            FormNCVendorRule rule = new FormNCVendorRule();
            FormNCVendor entity = EntityGet();
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
            this.HTDataTableName = "Data_FormNCVendor";
            Common.BindFNCV(drpFNCVID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);//客户
            //
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
            entity.SelectByID();
            entity.FNCVID = SysConvert.ToInt32(drpFNCVID.EditValue);
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.CurYear =SysConvert.ToInt32(txtCurYear.Text.ToString());
            entity.CurMonth =SysConvert.ToInt32(txtCurMonth.Text.ToString());
            entity.CurDay = SysConvert.ToInt32(txtCurMonth.Text.ToString());
            entity.CurSort = SysConvert.ToInt32(txtCurSort.Text.ToString());
            entity.Remark = txtRemark.Text.ToString();
            return entity;
        }
        #endregion

       
    }
}