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
    public partial class frmGZNoteEdit : frmAPBaseUIFormEdit
    {
        public frmGZNoteEdit()
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
            GZNoteDtsRule rule = new GZNoteDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            GZNoteRule rule = new GZNoteRule();
            GZNote entity = EntityGet();
            GZNoteDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            GZNoteRule rule = new GZNoteRule();
            GZNote entity = EntityGet();
            GZNoteDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            GZNote entity = new GZNote();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtOPName.Text = entity.OPName.ToString(); 
  			txtFormDate.DateTime = entity.FormDate; 
  			txtRemark.Text = entity.Remark.ToString(); 
  			
  			
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
            GZNoteRule rule = new GZNoteRule();
            GZNote entity = EntityGet();
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
             base.IniInsertSet();
             txtFormNo_DoubleClick(null, null);
             txtFormDate.DateTime = DateTime.Now.Date;
             txtOPName.Text = FParamConfig.LoginName;
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_GZNote";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "GZContext" };//������ϸУ�����¼���ֶ�
           
            

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private GZNote EntityGet()
        {
            GZNote entity = new GZNote();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim();
            entity.OPID = FParamConfig.LoginID;
  			entity.OPName = txtOPName.Text.Trim(); 
  			entity.FormDate = txtFormDate.DateTime.Date; 
  			entity.Remark = txtRemark.Text.Trim(); 
  			 
            
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private GZNoteDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            GZNoteDts[] entitydts = new GZNoteDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new GZNoteDts();
                    entitydts[index].GZContext = SysConvert.ToString(gridView1.GetRowCellValue(i, "GZContext")); 
  			 		entitydts[index].HS = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "HS")); 
  			 		entitydts[index].Result = SysConvert.ToString(gridView1.GetRowCellValue(i, "Result")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormNoControlRule rule = new FormNoControlRule();
                txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.�ձ����);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region �����¼�
       
        #endregion


    }
}