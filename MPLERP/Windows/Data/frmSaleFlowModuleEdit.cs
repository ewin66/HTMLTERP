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
    public partial class frmSaleFlowModuleEdit : frmAPBaseUISinEdit
    {
        public frmSaleFlowModuleEdit()
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

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            SaleFlowModuleRule rule = new SaleFlowModuleRule();
            SaleFlowModule entity = EntityGet();
            SaleFlowModuleDts[] entityDts = EntityDtsGet();
            rule.RAdd(entity, entityDts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            SaleFlowModuleRule rule = new SaleFlowModuleRule();
            SaleFlowModule entity = EntityGet();
            SaleFlowModuleDts[] entityDts = EntityDtsGet();
            rule.RUpdate(entity, entityDts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            SaleFlowModule entity = new SaleFlowModule();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtShowDesc.Text = entity.ShowDesc.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();

            drpSaleItemType.EditValue = entity.SaleItemTypeID;

            SaleFlowModuleDtsRule dtsrule = new SaleFlowModuleDtsRule();
            DataTable dtDts= dtsrule.RShow(" AND MainID=" + this.HTDataID + " ORDER BY Seq");
            SetCheckProcedure(drpSaleProcedure, dtDts);

            if (!findFlag)
            {
              
            }
        }

        /// <summary>
        /// 设置已选项
        /// </summary>
        /// <param name="p_CheckList"></param>
        private void SetCheckProcedure(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList,DataTable p_Dt)
        {
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                p_CheckList.SetItemCheckState(i, CheckState.Unchecked);
            }

            foreach (DataRow dr in p_Dt.Rows)//遍历记录
            {
                for (int i = 0; i < p_CheckList.ItemCount; i++)
                {
                    if (dr["SaleProcedureID"].ToString() == p_CheckList.GetItemValue(i).ToString())//值相等
                    {
                        p_CheckList.SetItemCheckState(i, CheckState.Checked);
                        break;
                    }
                }
            }
        }



       

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            SaleFlowModuleRule rule = new SaleFlowModuleRule();
            SaleFlowModule entity = EntityGet();
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
            this.HTDataTableName = "Data_SaleFlowModule";
            Common.BindSaleProcedure(drpSaleProcedure, false);


            Common.BindItemType(drpSaleItemType,1,true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SaleFlowModule EntityGet()
        {
            SaleFlowModule entity = new SaleFlowModule();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim();
            entity.ShowDesc = GetProcedureDesc();
  			entity.Remark = txtRemark.Text.Trim();
            entity.SaleItemTypeID = SysConvert.ToInt32(drpSaleItemType.EditValue);

            return entity;
        }


        /// <summary>
        /// 获得明细实体
        /// </summary>
        /// <returns></returns>
        private SaleFlowModuleDts[] EntityDtsGet()
        {
            int num = 0;
            for (int i = 0; i < drpSaleProcedure.ItemCount; i++)
            {
                if (drpSaleProcedure.GetItemCheckState(i) == CheckState.Checked)
                {
                    num++;
                }
            }

            SaleFlowModuleDts[] entityA = new SaleFlowModuleDts[num];
            num = 0;
            for (int i = 0; i < drpSaleProcedure.ItemCount; i++)
            {
                if (drpSaleProcedure.GetItemCheckState(i) == CheckState.Checked)
                {
                    entityA[num] = new SaleFlowModuleDts();
                    entityA[num].MainID = HTDataID;
                    entityA[num].Seq = num + 1;
                    entityA[num].SaleProcedureID = SysConvert.ToInt32(drpSaleProcedure.GetItemValue(i));
                    num++;
                }
            }
            return entityA;
        }


        /// <summary>
        /// 获得文本描述
        /// </summary>
        private string GetProcedureDesc()
        {
            string outstr = string.Empty;
            for (int i = 0; i < drpSaleProcedure.ItemCount; i++)
            {
                if (drpSaleProcedure.GetItemCheckState(i) == CheckState.Checked)
                {
                    if (outstr != string.Empty)
                    {
                        outstr += "—";
                    }
                    outstr += drpSaleProcedure.GetItemText(i);
                }
            }
            return outstr;
        }
        #endregion

        #region 其它事件
        /// <summary>
        /// 选择项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpSaleProcedure_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                txtShowDesc.Text = GetProcedureDesc();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
    }
} 
