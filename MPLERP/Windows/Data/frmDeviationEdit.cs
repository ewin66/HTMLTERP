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
    ///功能： 偏差
    /// </summary>
    public partial class frmDeviationEdit : frmAPBaseUISinEdit
    {
        public frmDeviationEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("请输入名称");
                txtName.Focus();
                return false;
            }
  
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
            DeviationDtsRule rule = new DeviationDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            DeviationRule rule = new DeviationRule();
            Deviation entity = EntityGet();
            DeviationDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            DeviationRule rule = new DeviationRule();
            Deviation entity = EntityGet();
            DeviationDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            Deviation entity = new Deviation();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			
  			
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
        }


        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            DeviationRule rule = new DeviationRule();
            Deviation entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Deviation";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "Name", "ColorStr"};//数据明细校验必须录入字段
           
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Deviation EntityGet()
        {
            Deviation entity = new Deviation();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			 
            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private DeviationDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            DeviationDts[] entitydts = new DeviationDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new DeviationDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();
                    
                    entitydts[index].Code = SysConvert.ToString(gridView1.GetRowCellValue(i, "Code")); 
  			 		entitydts[index].Name = SysConvert.ToString(gridView1.GetRowCellValue(i, "Name")); 
  			 		entitydts[index].ColorStr = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorStr")); 
  			 		entitydts[index].Num = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "Num"));

                
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));


                    //ColorConverter cc = new ColorConverter();
                    //entitydts[index].Remark = cc.ConvertToString((TextBox)(gridView1.GetRowCellValue(i, "Remark"))); 
  			 		 
                    
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