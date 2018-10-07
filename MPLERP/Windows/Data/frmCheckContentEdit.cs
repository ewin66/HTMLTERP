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
    public partial class frmCheckContentEdit : frmAPBaseUISinEdit
    {
        public frmCheckContentEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入色卡编号");
            //    txtCode.Focus();
            //    return false;
            //}
  

            if (!this.CheckCorrectDts())
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            CheckContentDtsRule rule = new CheckContentDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            CheckContentRule rule = new CheckContentRule();
            CheckContent entity = EntityGet();
            CheckContentDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            CheckContentRule rule = new CheckContentRule();
            CheckContent entity = EntityGet();
            CheckContentDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            CheckContent entity = new CheckContent();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtCompanyTypeID.Text = entity.CompanyTypeID.ToString(); 
  			txtContent.Text = entity.Content.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtMakeOPID.Text = Common.GetNameByOPID(entity.MakeOPID.ToString()); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtParentID.Text = entity.ParentID.ToString();
            if (txtMakeDate.DateTime == SystemConfiguration.DateTimeDefaultValue)
            {
                txtMakeDate.Text = "";
            }
  			
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
                txtMakeOPID.Text = FParamConfig.LoginName;
            }

            BindGridDts();
        }


        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CheckContentRule rule = new CheckContentRule();
            CheckContent entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            txtMakeOPID.Properties.ReadOnly = true;
            txtMakeDate.Properties.ReadOnly = true;
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtMakeOPID.Text = FParamConfig.LoginName;
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_CheckContent";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "Content" };//数据明细校验必须录入字段
            SetTabIndex(0, groupControlMainten);
            

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CheckContent EntityGet()
        {
            CheckContent entity = new CheckContent();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.CompanyTypeID = SysConvert.ToInt32(txtCompanyTypeID.Text.Trim()); 
  			entity.Content = txtContent.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID; 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.ParentID = SysConvert.ToInt32(txtParentID.Text.Trim());
            if (txtMakeDate.DateTime != SystemConfiguration.DateTimeDefaultValue && txtMakeDate.Text != "")
            {
                entity.MakeDate = txtMakeDate.DateTime.Date; 
                
            }
            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CheckContentDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            CheckContentDts[] entitydts = new CheckContentDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new CheckContentDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();
                    
                    entitydts[index].Content = SysConvert.ToString(gridView1.GetRowCellValue(i, "Content")); 
  			 		entitydts[index].UseableFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "UseableFlag")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        #region 其它事件
       
        #endregion


    }
}