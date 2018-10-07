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
    public partial class frmQASampleEdit : frmAPBaseUIFormEdit
    {
        public frmQASampleEdit()
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
            QASampleDtsRule rule = new QASampleDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            QASampleRule rule = new QASampleRule();
            QASample entity = EntityGet();
            QASampleDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            QASampleRule rule = new QASampleRule();
            QASample entity = EntityGet();
            QASampleDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            QASample entity = new QASample();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.FormNo;

  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtSampleTypeID.Text = entity.SampleTypeID.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtFormDate.DateTime = entity.FormDate; 
  			txtReqDate.DateTime = entity.ReqDate; 
  			txtVendorID.Text = entity.VendorID.ToString(); 
  			txtSaleOPID.Text = entity.SaleOPID.ToString(); 
  			txtMVendorID.Text = entity.MVendorID.ToString(); 
  			txtYVendorID.Text = entity.YVendorID.ToString(); 
  			txtMakeOPID.Text = entity.MakeOPID.ToString(); 
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
            QASampleRule rule = new QASampleRule();
            QASample entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProductCommon.FormNoCtlEditSet(txtFormNo, "Dev_QASample", "FormNo", 0, p_Flag);
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
            txtReqDate.DateTime = DateTime.Now.Date;
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtMakeOPID.Text = FParamConfig.LoginName;
            txtFormNo_DoubleClick(null, null);
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_QASample";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode" };//������ϸУ�����¼���ֶ�
            Common.BindVendor(txtVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            Common.BindOP(txtSaleOPID, (int)EnumOPDep.ҵ��, true);
            //Common.BindOP(txtMVendorID, (int)EnumVendorType.�����ӹ���, true);
            //Common.BindOP(txtYVendorID, (int)EnumVendorType.�����ӹ���, true);
            this.ToolBarItemAdd(29, ToolButtonName.btnLoad.ToString(), "��������", false, btnDevItemLoad_Click);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private QASample EntityGet()
        {
            QASample entity = new QASample();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.SampleTypeID = txtSampleTypeID.Text.Trim(); 
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.FormDate = txtFormDate.DateTime.Date; 
  			entity.ReqDate = txtReqDate.DateTime.Date; 
  			entity.VendorID = txtVendorID.Text.Trim(); 
  			entity.SaleOPID = txtSaleOPID.Text.Trim(); 
  			entity.MVendorID = txtMVendorID.Text.Trim(); 
  			entity.YVendorID = txtYVendorID.Text.Trim(); 
  			entity.MakeOPID = txtMakeOPID.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			 
            
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private QASampleDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            QASampleDts[] entitydts = new QASampleDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new QASampleDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();
                    
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName")); 
  			 		entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd")); 
  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel")); 
  			 		entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")); 
  			 		entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO")); 
  			 		entitydts[index].SampleDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "SampleDate")); 
  			 		entitydts[index].SMDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "SMDate")); 
  			 		entitydts[index].DtsRemark = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsRemark")); 
  			 		 
                    
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
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.Ʒ��������);  
                    ProductCommon.FormNoIniSet(txtFormNo, "Dev_QASample", "FormNo",0);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region �����¼�
       
        #endregion

        /// <summary>
        /// ���ز�Ʒ������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnDevItemLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    frmLoadFabric frm = new frmLoadFabric();
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.GBID != null && frm.GBID.Length != 0)
                    {

                        for (int i = 0; i < frm.GBID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.GBID[i]);
                        }
                        setItemFabricNews(str);
                    }

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private void setItemFabricNews(string p_Str)
        {
            string[] gbid = p_Str.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    //gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    //gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));

                    //gridView1.SetRowCellValue(i, "DLoadID", SysConvert.ToInt32(orderid[i]));

                    //if (i == 0)
                    //{
                    //    sql = "SELECT VendorID FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    //    dt = SysUtils.Fill(sql);
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0][0]);
                    //    }
                    //}

                }
            }
        }
    }
}