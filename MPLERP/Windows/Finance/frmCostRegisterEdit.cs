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
    public partial class frmCostRegisterEdit : frmAPBaseUIFormEdit
    {
        public frmCostRegisterEdit()
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
            CostRegisterDtsRule rule = new CostRegisterDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            CostRegisterRule rule = new CostRegisterRule();
            CostRegister entity = EntityGet();
            CostRegisterDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            CostRegisterRule rule = new CostRegisterRule();
            CostRegister entity = EntityGet();
            CostRegisterDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            CostRegister entity = new CostRegister();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtCheckOPID.Text = entity.CheckOPID.ToString(); 
  			txtCheckDate.DateTime = entity.CheckDate; 
  			txtMakeOPID.Text = entity.MakeOPID.ToString(); 
  			txtMakeOPName.Text = entity.MakeOPName.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtTotalAmount.Text = entity.TotalAmount.ToString(); 
  			
  			
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
            CostRegisterRule rule = new CostRegisterRule();
            CostRegister entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProcessCtl.ProcControlEdit(new Control[] { txtMakeDate, txtMakeOPID, txtMakeOPName, txtFormNo }, false);
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormNo_DoubleClick(null, null);
            txtMakeOPID.Text = FParamConfig.LoginID;
            txtMakeOPName.Text = FParamConfig.LoginName;
            txtMakeDate.DateTime = DateTime.Now;

        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_CostRegister";
            this.HTDataDts = gridView1;
           // this.FormNoControl = txtFormNo;//ָ����Ҫ����
           // this.FormNoTableField = "FormNo";
            this.HTCheckDataField = new string[] { "Type" };//������ϸУ�����¼���ֶ�

           
            

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CostRegister EntityGet()
        {
            CostRegister entity = new CostRegister();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.CheckOPID = txtCheckOPID.Text.Trim(); 
  			entity.CheckDate = txtCheckDate.DateTime.Date; 
  			entity.MakeOPID = txtMakeOPID.Text.Trim(); 
  			entity.MakeOPName = txtMakeOPName.Text.Trim(); 
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim()); 
  			 
            
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CostRegisterDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            CostRegisterDts[] entitydts = new CostRegisterDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new CostRegisterDts();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID")); 
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//�Ѵ��ڱ�ʾ�޸�
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); 
                        entitydts[index].SelectByID();
                    }
                    else//����
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }
                    
                    entitydts[index].DailyTIme = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "DailyTIme")); 
  			 		entitydts[index].Type = SysConvert.ToString(gridView1.GetRowCellValue(i, "Type")); 
  			 		entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount")); 
  			 		entitydts[index].DtsRemark = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsRemark")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (HTFormStatus == FormStatus.�޸� || HTFormStatus == FormStatus.����)
            {
                decimal totalamount = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    decimal Am=SysConvert.ToDecimal(Common.GetCellValue(gridView1, i, "Amount"));
                    if ( Am!= 0)
                    {
                        totalamount += Am;
                    }
                }
                txtTotalAmount.Text = totalamount.ToString();
            }
        }

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormNoControlRule rule = new FormNoControlRule();
                txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.�ճ����õǼǵ���);
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