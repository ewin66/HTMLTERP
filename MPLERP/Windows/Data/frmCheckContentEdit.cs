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
            CheckContentDtsRule rule = new CheckContentDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
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
        /// �޸�
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
        /// ����
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
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CheckContentRule rule = new CheckContentRule();
            CheckContent entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            txtMakeOPID.Properties.ReadOnly = true;
            txtMakeDate.Properties.ReadOnly = true;
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtMakeOPID.Text = FParamConfig.LoginName;
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_CheckContent";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "Content" };//������ϸУ�����¼���ֶ�
            SetTabIndex(0, groupControlMainten);
            

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
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
        /// ���ʵ��
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

        #region �����¼�
       
        #endregion


    }
}