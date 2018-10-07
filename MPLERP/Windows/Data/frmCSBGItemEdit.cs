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
    /// ���ܣ����Ա�����Ŀ����
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-18
    /// ����������
    /// </summary>
    public partial class frmCSBGItemEdit : frmAPBaseUIFormEdit
    {
        public frmCSBGItemEdit()
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
            return true;
        }


        /// <summary>
        /// ����
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
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            CSBGItemRule rule = new CSBGItemRule();
            CSBGItem entity = EntityGet();
            CSBGItemDts[] entityDts = EntityDtsGet();
            rule.RUpdate(entity, entityDts);
        }

        /// <summary>
        /// ����
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
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CSBGItemRule rule = new CSBGItemRule();
            CSBGItem entity = EntityGet();
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
            this.HTDataTableName = "Data_CSBGItem";
            this.HTDataDts = gridView1;
         //   Common.BindCLS(restxtUnit, "Data_CSBGItemDts", "DW", true); ��// ����÷���  20120427
            Common.BindCLS(restxtUnit, "CheckUnit", "Att_ItemTestFormDts ", true); 
            

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CSBGItem EntityGet()
        {
            CSBGItem entity = new CSBGItem();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();//����
            entity.Name = txtName.Text.Trim(); //����
  			entity.Remark = txtRemark.Text.Trim(); //��ע
            entity.Sort =SysConvert.ToInt32(txtSort.Text.Trim());//����
            entity.UseableFlag = SysConvert.ToInt32(drpUseableFlag.EditValue);//��Ч��
  			
            return entity;
        }

        /// <summary>
        /// ���ʵ��
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


                    entitydts[index].Name = SysConvert.ToString(gridView1.GetRowCellValue(i, "Name"));//���������Ŀ    
                    entitydts[index].DW = SysConvert.ToString(gridView1.GetRowCellValue(i, "DW"));//��λ
                    entitydts[index].JSYQ = SysConvert.ToString(gridView1.GetRowCellValue(i, "JSYQ"));//Ҫ��
                    entitydts[index].CSFree = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CSFree"));//���Է���
                    
                    index++;

                }
            }
            return entitydts;
        }
        #endregion

       
    }
}