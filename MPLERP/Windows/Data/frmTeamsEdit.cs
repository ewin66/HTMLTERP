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
    public partial class frmTeamsEdit : frmAPBaseUISinEdit
    {
        public frmTeamsEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("�����������");
                txtCode.Focus();
                return false;
            }
            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("�������������");
                txtName.Focus();
                return false;
            }

            if (Common.CheckLookUpEditBlank(drpBaseShop))
            {
                this.ShowMessage("�����복��");
                drpBaseShop.Focus();
                return false;
            }
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
            TeamsDtsRule rule = new TeamsDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            TeamsRule rule = new TeamsRule();
            Teams entity = EntityGet();
            TeamsDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            TeamsRule rule = new TeamsRule();
            Teams entity = EntityGet();
            TeamsDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            Teams entity = new Teams();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			drpBaseShop.EditValue = entity.BaseShop.ToString();
            txtMakeOPID.Text = Common.GetNameByOPID(entity.MakeOPID.ToString());
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtRemark.Text = entity.Remark.ToString();
            chkValidType.EditValue = entity.ValidType;
  			
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
            TeamsRule rule = new TeamsRule();
            Teams entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProcessCtl.ProcControlEdit(new Control[] { txtMakeDate, txtMakeOPID }, false);
            
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
            this.HTDataTableName = "Data_Teams";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"OPID"};//������ϸУ�����¼���ֶ�

            Common.BindDepartment(drpBaseShop, true, true);
            Common.BindOPID(drpGridOPID, true);


            SetTabIndex(0, groupControlMainten);
            

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Teams EntityGet()
        {
            Teams entity = new Teams();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim();
            entity.BaseShop = drpBaseShop.EditValue.ToString();
            entity.MakeOPID = FParamConfig.LoginID; 
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.Remark = txtRemark.Text.Trim();
            entity.ValidType =SysConvert.ToInt32(chkValidType.EditValue);
            
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private TeamsDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            TeamsDts[] entitydts = new TeamsDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new TeamsDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();
                    
                    entitydts[index].OPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "OPID")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].TeamsCode = txtCode.Text.Trim();
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        private void drpBaseShop_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Common.BindOPID(drpGridOPID, true, " AND Department=" + SysString.ToDBString(drpBaseShop.EditValue.ToString()));
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