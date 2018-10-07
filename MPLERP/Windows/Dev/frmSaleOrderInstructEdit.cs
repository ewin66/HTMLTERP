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
    public partial class frmSaleOrderInstructEdit : frmAPBaseUIFormEdit
    {
        public frmSaleOrderInstructEdit()
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
            SaleOrderInstructDtsRule rule = new SaleOrderInstructDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            SaleOrderInstructRule rule = new SaleOrderInstructRule();
            SaleOrderInstruct entity = EntityGet();
            SaleOrderInstructDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            SaleOrderInstructRule rule = new SaleOrderInstructRule();
            SaleOrderInstruct entity = EntityGet();
            SaleOrderInstructDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            SaleOrderInstruct entity = new SaleOrderInstruct();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtOrderFormNo.Text = entity.OrderFormNo.ToString(); 
  			txtFormDate.DateTime = entity.FormDate; 
  			txtReqDate.DateTime = entity.ReqDate; 
  			drpSaleOPID.Text = entity.SaleOPID.ToString(); 
  			txtPBItemCode.Text = entity.PBItemCode.ToString(); 
  			txtPBDensity.Text = entity.PBDensity.ToString(); 
  			txtPBMWidth.Text = entity.PBMWidth.ToString(); 
  			txtPBMWeight.Text = entity.PBMWeight.ToString();
            drpFactoryID2.Text = entity.FactoryID2.ToString(); 
  			txtCPItemCode.Text = entity.CPItemCode.ToString(); 
  			txtCPDensity.Text = entity.CPDensity.ToString(); 
  			txtCPMWidth.Text = entity.CPMWidth.ToString(); 
  			txtCPMWeight.Text = entity.CPMWeight.ToString();
            drpFactoryID3.Text = entity.FactoryID3.ToString(); 
  			txtTecReq.Text = entity.TecReq.ToString(); 
  			txtPBQty.Text = entity.PBQty.ToString(); 
  			txtBCPSampleQty.Text = entity.BCPSampleQty.ToString(); 
  			txtPBSampleQty.Text = entity.PBSampleQty.ToString(); 
  			txtMakeOPID.Text = entity.MakeOPID.ToString(); 
  			txtMakeOPName.Text = entity.MakeOPName.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
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
            SaleOrderInstructRule rule = new SaleOrderInstructRule();
            SaleOrderInstruct entity = EntityGet();
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
            txtFormDate.Text = DateTime.Now.ToShortDateString();
            txtReqDate.Text = DateTime.Now.AddDays(10).ToShortDateString();
            txtMakeDate.Text = DateTime.Now.ToShortDateString();
            txtMakeOPID.Text = FParamConfig.LoginID;
            txtMakeOPName.Text = FParamConfig.LoginName;
            txtFormNo_DoubleClick(null, null);
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_SaleOrderInstruct";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {};//������ϸУ�����¼���ֶ�
            Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);//ҵ��Ա
            Common.BindVendor(drpFactoryID2, (int)EnumVendorType.�����ӹ���, true);//û��������
            Common.BindVendor(drpFactoryID3, (int)EnumVendorType.Ⱦ��, true);//Ⱦ��

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SaleOrderInstruct EntityGet()
        {
            SaleOrderInstruct entity = new SaleOrderInstruct();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.OrderFormNo = txtOrderFormNo.Text.Trim(); 
  			entity.FormDate = txtFormDate.DateTime.Date; 
  			entity.ReqDate = txtReqDate.DateTime.Date;
            entity.SaleOPID = drpSaleOPID.Text.Trim(); 
  			entity.PBItemCode = txtPBItemCode.Text.Trim(); 
  			entity.PBDensity = txtPBDensity.Text.Trim(); 
  			entity.PBMWidth = txtPBMWidth.Text.Trim(); 
  			entity.PBMWeight = txtPBMWeight.Text.Trim();
            entity.FactoryID2 = drpFactoryID2.Text.Trim(); 
  			entity.CPItemCode = txtCPItemCode.Text.Trim(); 
  			entity.CPDensity = txtCPDensity.Text.Trim(); 
  			entity.CPMWidth = txtCPMWidth.Text.Trim(); 
  			entity.CPMWeight = txtCPMWeight.Text.Trim();
            entity.FactoryID3 = drpFactoryID3.Text.Trim(); 
  			entity.TecReq = txtTecReq.Text.Trim(); 
  			entity.PBQty = SysConvert.ToDecimal(txtPBQty.Text.Trim()); 
  			entity.BCPSampleQty = SysConvert.ToDecimal(txtBCPSampleQty.Text.Trim()); 
  			entity.PBSampleQty = SysConvert.ToDecimal(txtPBSampleQty.Text.Trim()); 
  			entity.MakeOPID = txtMakeOPID.Text.Trim(); 
  			entity.MakeOPName = txtMakeOPName.Text.Trim(); 
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.Remark = txtRemark.Text.Trim(); 
  			 
            
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SaleOrderInstructDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            SaleOrderInstructDts[] entitydts = new SaleOrderInstructDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new SaleOrderInstructDts();
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
                    
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")); 
  			 		entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")); 
  			 		entitydts[index].TPQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TPQty")); 
  			 		entitydts[index].Shrinkage = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Shrinkage")); 
  			 		entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice")); 
  			 		entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount")); 
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
                if (HTFormStatus == FormStatus.����)
                {
                    ProductCommon.FormNoIniSet(txtFormNo, "Sale_SaleOrderInstruct", "FormNo", 0);
                }
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