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
    /// 功能：测试报告项目管理
    /// 作者：章文强
    /// 日期：2012-04-18
    /// 操作：新增
    /// </summary>
    public partial class frmCSBGItemEdit : frmAPBaseUIFormEdit
    {
        public frmCSBGItemEdit()
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
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            CSBGItemRule rule = new CSBGItemRule();
            CSBGItem entity = EntityGet();
            CSBGItemDts[] entityDts = EntityDtsGet();
            rule.RAdd(entity, entityDts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            CSBGItemRule rule = new CSBGItemRule();
            CSBGItem entity = EntityGet();
            CSBGItemDts[] entityDts = EntityDtsGet();
            rule.RUpdate(entity, entityDts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            CSBGItem entity = new CSBGItem();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            txtRemark.Text = entity.Remark.ToString();
            drpUseableFlag.EditValue = entity.UseableFlag;
            txtSort.Text = entity.Sort.ToString();

            if (!findFlag)
            {
               
            }
            BindGrid();
        }

        private void BindGrid()
        {
            CSBGItemDtsRule rule = new CSBGItemDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CSBGItemRule rule = new CSBGItemRule();
            CSBGItem entity = EntityGet();
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
            this.HTDataTableName = "Data_CSBGItem";
            this.HTDataDts = gridView1;
         //   Common.BindCLS(restxtUnit, "Data_CSBGItemDts", "DW", true); 　// 王焕梅添加  20120427
            Common.BindCLS(restxtUnit, "CheckUnit", "Att_ItemTestFormDts ", true); 
            

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CSBGItem EntityGet()
        {
            CSBGItem entity = new CSBGItem();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();//编码
            entity.Name = txtName.Text.Trim(); //名称
  			entity.Remark = txtRemark.Text.Trim(); //备注
            entity.Sort =SysConvert.ToInt32(txtSort.Text.Trim());//排序
            entity.UseableFlag = SysConvert.ToInt32(drpUseableFlag.EditValue);//有效性
  			
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CSBGItemDts[] EntityDtsGet()
        {
            int Num = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "Name")) != string.Empty)
                {
                    Num++;
                }
            }
            CSBGItemDts[] entitydts = new CSBGItemDts[Num];
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "Name")) != string.Empty)
                {
                    entitydts[index] = new CSBGItemDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();


                    entitydts[index].Name = SysConvert.ToString(gridView1.GetRowCellValue(i, "Name"));//检验测试项目    
                    entitydts[index].DW = SysConvert.ToString(gridView1.GetRowCellValue(i, "DW"));//单位
                    entitydts[index].JSYQ = SysConvert.ToString(gridView1.GetRowCellValue(i, "JSYQ"));//要求
                    entitydts[index].CSFree = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CSFree"));//测试费用
                    
                    index++;

                }
            }
            return entitydts;
        }
        #endregion

       
    }
}