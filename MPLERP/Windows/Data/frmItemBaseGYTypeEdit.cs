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
    public partial class frmItemBaseGYTypeEdit : frmAPBaseUIFormEdit
    {
        public frmItemBaseGYTypeEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("������ɫ�����");
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
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {
            ItemBaseGYTypeDtsRule rule = new ItemBaseGYTypeDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            ItemBaseGYTypeRule rule = new ItemBaseGYTypeRule();
            ItemBaseGYType entity = EntityGet();
            ItemBaseGYTypeDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            ItemBaseGYTypeRule rule = new ItemBaseGYTypeRule();
            ItemBaseGYType entity = EntityGet();
            ItemBaseGYTypeDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            ItemBaseGYType entity = new ItemBaseGYType();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString();
            chkDShowFlag.Checked = SysConvert.ToBoolean(entity.DShowFlag);
            drpSaleProcedureID.EditValue = entity.SaleProcedureID;
            drpWOOtherTypeID.EditValue = entity.WOOtherTypeID;
  			
  			
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ItemBaseGYTypeRule rule = new ItemBaseGYTypeRule();
            ItemBaseGYType entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            chkDShowFlag.Checked = true;
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_ItemBaseGYType";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"Name"};//������ϸУ�����¼���ֶ�

            Common.BindSaleProcedure(drpSaleProcedureID, true);
            Common.BindWOOtherType(drpWOOtherTypeID, true);
            

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ItemBaseGYType EntityGet()
        {
            ItemBaseGYType entity = new ItemBaseGYType();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.DShowFlag = SysConvert.ToInt32(chkDShowFlag.Checked); 
  			entity.SaleProcedureID = SysConvert.ToInt32(drpSaleProcedureID.EditValue); 
  			entity.WOOtherTypeID = SysConvert.ToInt32(drpWOOtherTypeID.EditValue); 
  			 
            
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ItemBaseGYTypeDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            ItemBaseGYTypeDts[] entitydts = new ItemBaseGYTypeDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new ItemBaseGYTypeDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();
                    
                    entitydts[index].Code = SysConvert.ToString(gridView1.GetRowCellValue(i, "Code")); 
  			 		entitydts[index].Name = SysConvert.ToString(gridView1.GetRowCellValue(i, "Name")); 
  			 		entitydts[index].CLSA = SysConvert.ToString(gridView1.GetRowCellValue(i, "CLSA")); 
  			 		entitydts[index].CLSB = SysConvert.ToString(gridView1.GetRowCellValue(i, "CLSB")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

     
        #region �����¼�
       
        #endregion


    }
}