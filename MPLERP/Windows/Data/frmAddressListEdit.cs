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
    public partial class frmAddressListEdit : frmAPBaseUIFormEdit
    {
        public frmAddressListEdit()
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
            AddressListDtsRule rule = new AddressListDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            AddressListRule rule = new AddressListRule();
            AddressList entity = EntityGet();
            AddressListDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            AddressListRule rule = new AddressListRule();
            AddressList entity = EntityGet();
            AddressListDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            AddressList entity = new AddressList();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtDVendorID.Text = entity.DVendorID.ToString(); 
  			txtDVendorAttn.Text = entity.DVendorAttn.ToString(); 
  			txtDVendorName.Text = entity.DVendorName.ToString(); 
  			
  			
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
            AddressListRule rule = new AddressListRule();
            AddressList entity = EntityGet();
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
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_AddressList";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "Contact" };//������ϸУ�����¼���ֶ�
           
            

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private AddressList EntityGet()
        {
            AddressList entity = new AddressList();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.DVendorID = txtDVendorID.Text.Trim(); 
  			entity.DVendorAttn = txtDVendorAttn.Text.Trim(); 
  			entity.DVendorName = txtDVendorName.Text.Trim(); 
  			 
            
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private AddressListDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            AddressListDts[] entitydts = new AddressListDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new AddressListDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();
                    
                    entitydts[index].Address = SysConvert.ToString(gridView1.GetRowCellValue(i, "Address")); 
  			 		entitydts[index].Tel = SysConvert.ToString(gridView1.GetRowCellValue(i, "Tel")); 
  			 		entitydts[index].MTel = SysConvert.ToString(gridView1.GetRowCellValue(i, "MTel")); 
  			 		entitydts[index].Fax = SysConvert.ToString(gridView1.GetRowCellValue(i, "Fax"));
                    entitydts[index].Contact = SysConvert.ToString(gridView1.GetRowCellValue(i,"Contact"));
  			 		 
                    
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