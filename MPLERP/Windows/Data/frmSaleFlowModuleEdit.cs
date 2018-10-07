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


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtTitle.Text.Trim() == "")
            //{
            //    this.ShowMessage("���������");
            //    txtTitle.Focus();
            //    return false;
            //}            

            return true;
        }


        /// <summary>
        /// ����
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
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            SaleFlowModuleRule rule = new SaleFlowModuleRule();
            SaleFlowModule entity = EntityGet();
            SaleFlowModuleDts[] entityDts = EntityDtsGet();
            rule.RUpdate(entity, entityDts);
        }

        /// <summary>
        /// ����
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
        /// ������ѡ��
        /// </summary>
        /// <param name="p_CheckList"></param>
        private void SetCheckProcedure(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList,DataTable p_Dt)
        {
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                p_CheckList.SetItemCheckState(i, CheckState.Unchecked);
            }

            foreach (DataRow dr in p_Dt.Rows)//������¼
            {
                for (int i = 0; i < p_CheckList.ItemCount; i++)
                {
                    if (dr["SaleProcedureID"].ToString() == p_CheckList.GetItemValue(i).ToString())//ֵ���
                    {
                        p_CheckList.SetItemCheckState(i, CheckState.Checked);
                        break;
                    }
                }
            }
        }



       

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            SaleFlowModuleRule rule = new SaleFlowModuleRule();
            SaleFlowModule entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_SaleFlowModule";
            Common.BindSaleProcedure(drpSaleProcedure, false);


            Common.BindItemType(drpSaleItemType,1,true);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
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
        /// �����ϸʵ��
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
        /// ����ı�����
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
                        outstr += "��";
                    }
                    outstr += drpSaleProcedure.GetItemText(i);
                }
            }
            return outstr;
        }
        #endregion

        #region �����¼�
        /// <summary>
        /// ѡ����ı�
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
