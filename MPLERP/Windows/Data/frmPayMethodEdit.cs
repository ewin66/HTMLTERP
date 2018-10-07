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
    /// ���ܣ����ʽ��ϸ
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-17
    /// ����������
    /// </summary>
    public partial class frmPayMethodEdit : frmAPBaseUISinEdit
    {
        public frmPayMethodEdit()
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
                this.ShowMessage("���������");
                txtCode.Focus();
                return false;
            }

            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("����������");
                txtName.Focus();
                return false;
            }
            if (txtID.Text.Trim() == "")
            {
                this.ShowMessage("������ID");
                txtID.Focus();
                return false;
            }
            //int Num = 0;
            //decimal per = 0;
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (SysConvert.ToString(gridView1.GetRowCellValue(i, "Name")) != "")
            //    {
            //        Num++;
            //        per += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PayPer"));
            //    }
            //}
            //if (Num > 0)
            //{
            //    if (per != 1)
            //    {
            //        this.ShowMessage("��ϸ�������֮�ͱ���Ϊ1");
            //        return false;
            //    }
               
            //}
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            PayMethodRule rule = new PayMethodRule();
            PayMethod entity = EntityGet();
            PayMethodDts[] entityDts = EntityDtsGet();
            rule.RAdd(entity,entityDts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            PayMethodRule rule = new PayMethodRule();
            PayMethod entity = EntityGet();
            PayMethodDts[] entityDts = EntityDtsGet();
            rule.RUpdate(entity,entityDts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            PayMethod entity = new PayMethod();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtID.Text = entity.ID.ToString();
            txtCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            txtRemark.Text = entity.Remark.ToString();


            if (!findFlag)
            {
               
            }
            BindGridDts();
        }

        /// <summary>
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {
            PayMethodDtsRule rule = new PayMethodDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            PayMethodRule rule = new PayMethodRule();
            PayMethod entity = EntityGet();
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
            this.HTDataTableName = "Data_PayMethod";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "Name" };//������ϸУ�����¼���ֶ�
            SetTabIndex(0, groupControlMainten);
            Common.BindPayDateType(drpPayDateTypeInt, true);
            Common.BindPayStepType(drpPayStepType, true);
         
        }
  
        public override void IniInsertSet()
        {
          
        }
        public override void IniUpdateSet()
        {
            txtID.Properties.ReadOnly = true;
        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private PayMethod EntityGet()
        {
            PayMethod entity = new PayMethod();
            //entity.ID = HTDataID;
            entity.SelectByID();
            entity.ID = Convert.ToInt32(txtID.Text.Trim());
            entity.Code = txtCode.Text.Trim();//����
            entity.Name = txtName.Text.Trim(); //����
  			entity.Remark = txtRemark.Text.Trim(); //��ע
  			
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private PayMethodDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            PayMethodDts[] entitydts = new PayMethodDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new PayMethodDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].Name = SysConvert.ToString(gridView1.GetRowCellValue(i, "Name"));
                    entitydts[index].PayPer = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PayPer"));
                    entitydts[index].PayDateTypeInt = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PayDateTypeInt"));
                    entitydts[index].DelayDayNum = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DelayDayNum"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].PayStepTypeID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PayStepTypeID"));

                    index++;
                }
            }
            return entitydts;
        }

        #endregion

       
    }
}