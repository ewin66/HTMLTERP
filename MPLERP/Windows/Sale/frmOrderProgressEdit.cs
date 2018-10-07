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
    public partial class frmOrderProgressEdit : frmAPBaseUIFormEdit
    {
        public frmOrderProgressEdit()
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
            OrderProgressDtsRule rule = new OrderProgressDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            OrderProgressRule rule = new OrderProgressRule();
            OrderProgress entity = EntityGet();
            OrderProgressDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            OrderProgressRule rule = new OrderProgressRule();
            OrderProgress entity = EntityGet();
            OrderProgressDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            OrderProgress entity = new OrderProgress();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.FormNo;

  			txtFormNo.Text = entity.FormNo.ToString(); 
  		
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtTotalQty.Text = entity.TotalQty.ToString(); 
  			
  			
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
            OrderProgressRule rule = new OrderProgressRule();
            OrderProgress entity = EntityGet();
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
            this.HTDataTableName = "Sale_OrderProgress";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {};//数据明细校验必须录入字段
           
            

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private OrderProgress EntityGet()
        {
            OrderProgress entity = new OrderProgress();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim()); 
  			 
            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private OrderProgressDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            OrderProgressDts[] entitydts = new OrderProgressDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new OrderProgressDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();
                    
                    entitydts[index].FollowNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "FollowNo")); 
  			 		entitydts[index].ModelCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ModelCode")); 
  			 		entitydts[index].ModelName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ModelName")); 
  			 		entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode")); 
  			 		entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")); 
  			 		entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")); 
  			 		entitydts[index].ReqDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "ReqDate")); 
  			 		entitydts[index].SR = SysConvert.ToString(gridView1.GetRowCellValue(i, "SR")); 
  			 		entitydts[index].FS = SysConvert.ToString(gridView1.GetRowCellValue(i, "FS")); 
  			 		entitydts[index].ZZ = SysConvert.ToString(gridView1.GetRowCellValue(i, "ZZ")); 
  			 		entitydts[index].RZ = SysConvert.ToString(gridView1.GetRowCellValue(i, "RZ")); 
  			 		entitydts[index].CP = SysConvert.ToString(gridView1.GetRowCellValue(i, "CP")); 
  			 		entitydts[index].DRemark = SysConvert.ToString(gridView1.GetRowCellValue(i, "DRemark")); 
  			 		 
                    
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