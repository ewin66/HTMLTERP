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
    /// 功能：付款方式明细
    /// 作者：章文强
    /// 日期：2012-04-17
    /// 操作：新增
    /// </summary>
    public partial class frmPayMethodEdit : frmAPBaseUISinEdit
    {
        public frmPayMethodEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("请输入编码");
                txtCode.Focus();
                return false;
            }

            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("请输入名称");
                txtName.Focus();
                return false;
            }
            if (txtID.Text.Trim() == "")
            {
                this.ShowMessage("请输入ID");
                txtID.Focus();
                return false;
            }
            //int Num = 0;
            //decimal per = 0;
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (SysConvert.ToString(gridView1.GetRowCellValue(i, "Name")) != "")
            //    {
            //        Num++;
            //        per += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PayPer"));
            //    }
            //}
            //if (Num > 0)
            //{
            //    if (per != 1)
            //    {
            //        this.ShowMessage("明细付款比例之和必须为1");
            //        return false;
            //    }
               
            //}
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            PayMethodRule rule = new PayMethodRule();
            PayMethod entity = EntityGet();
            PayMethodDts[] entityDts = EntityDtsGet();
            rule.RAdd(entity,entityDts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            PayMethodRule rule = new PayMethodRule();
            PayMethod entity = EntityGet();
            PayMethodDts[] entityDts = EntityDtsGet();
            rule.RUpdate(entity,entityDts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            PayMethod entity = new PayMethod();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtID.Text = entity.ID.ToString();
            txtCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            txtRemark.Text = entity.Remark.ToString();


            if (!findFlag)
            {
               
            }
            BindGridDts();
        }

        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            PayMethodDtsRule rule = new PayMethodDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            PayMethodRule rule = new PayMethodRule();
            PayMethod entity = EntityGet();
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
            this.HTDataTableName = "Data_PayMethod";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "Name" };//数据明细校验必须录入字段
            SetTabIndex(0, groupControlMainten);
            Common.BindPayDateType(drpPayDateTypeInt, true);
            Common.BindPayStepType(drpPayStepType, true);
         
        }
  
        public override void IniInsertSet()
        {
          
        }
        public override void IniUpdateSet()
        {
            txtID.Properties.ReadOnly = true;
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private PayMethod EntityGet()
        {
            PayMethod entity = new PayMethod();
            //entity.ID = HTDataID;
            entity.SelectByID();
            entity.ID = Convert.ToInt32(txtID.Text.Trim());
            entity.Code = txtCode.Text.Trim();//编码
            entity.Name = txtName.Text.Trim(); //名称
  			entity.Remark = txtRemark.Text.Trim(); //备注
  			
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private PayMethodDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            PayMethodDts[] entitydts = new PayMethodDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new PayMethodDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].Name = SysConvert.ToString(gridView1.GetRowCellValue(i, "Name"));
                    entitydts[index].PayPer = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PayPer"));
                    entitydts[index].PayDateTypeInt = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PayDateTypeInt"));
                    entitydts[index].DelayDayNum = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DelayDayNum"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].PayStepTypeID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PayStepTypeID"));

                    index++;
                }
            }
            return entitydts;
        }

        #endregion

       
    }
}