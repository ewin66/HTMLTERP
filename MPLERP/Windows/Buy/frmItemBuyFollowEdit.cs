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
    public partial class frmItemBuyFollowEdit : frmAPBaseUIFormEdit
    {
        public frmItemBuyFollowEdit()
        {
            InitializeComponent();
        }


        int saveNoLoadCheckDayNum = 0;//δ���رȶ���������ֹ����ʱ�������ϵͳ����
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
            ItemBuyFollowDtsRule rule = new ItemBuyFollowDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            ItemBuyFollowRule rule = new ItemBuyFollowRule();
            ItemBuyFollow entity = EntityGet();
            ItemBuyFollowDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            ItemBuyFollowRule rule = new ItemBuyFollowRule();
            ItemBuyFollow entity = EntityGet();
            ItemBuyFollowDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            ItemBuyFollow entity = new ItemBuyFollow();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.FormNo;

  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			drpShopID.Text = entity.ShopID.ToString();
            if (entity.ReqDate == SysConvert.ToDateTime("1900-01-01"))
            {

            }
            else
            {
                txtReqDate.DateTime = entity.ReqDate;
            }
  			txtOrderFormNo.Text = entity.OrderFormNo.ToString(); 
  			txtBuyFormNo.Text = entity.BuyFormNo.ToString(); 
  			txtColorCount.Text = entity.ColorCount.ToString(); 
  			txtItemCode.Text = entity.ItemCode.ToString(); 
  			txtGoodsCode.Text = entity.GoodsCode.ToString(); 
  			txtItemModel.Text = entity.ItemModel.ToString(); 
  			txtMWidth.Text = entity.MWidth.ToString(); 
  			txtMWeight.Text = entity.MWeight.ToString(); 
  			txtYarnStd.Text = entity.YarnStd.ToString(); 
  			txtJWM.Text = entity.JWM.ToString(); 
  			txtZWZZ.Text = entity.ZWZZ.ToString(); 
  			txtRSType.Text = entity.RSType.ToString(); 
  			txtItemName.Text = entity.ItemName.ToString(); 
  			txtPackReq.Text = entity.PackReq.ToString();
            txtFYFlag.EditValue = entity.FYFlag;
  			txtFYCount.Text = entity.FYCount.ToString();
            if (txtItemCode.Text.Trim() != "")
            {
                lbWeightUnit.Text = Common.GetWeightUnit(txtItemCode.Text.Trim());
            }
            if (entity.FactFinishDate == SysConvert.ToDateTime("1900-01-01"))
            {
                
            }
            else
            {
                txtFactFinishDate.DateTime = entity.FactFinishDate;
            }
  			txtPGZL.Text = entity.PGZL.ToString(); 
  			txtPGZLDesc.Text = entity.PGZLDesc.ToString(); 
  			txtPGJQ.Text = entity.PGJQ.ToString(); 
  			txtPGJQDesc.Text = entity.PGJQDesc.ToString(); 
  			txtPGPH.Text = entity.PGPH.ToString(); 
  			txtPGPHDesc.Text = entity.PGPHDesc.ToString(); 
  			txtPGZH.Text = entity.PGZH.ToString(); 
  			txtPGZHDesc.Text = entity.PGZHDesc.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtFYItemName.Text = entity.FYItemName.ToString();
            txtDLoadDtsID.Text = entity.DLoadDtsID.ToString();
  			
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
            ItemBuyFollowRule rule = new ItemBuyFollowRule();
            ItemBuyFollow entity = EntityGet();
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
             txtMakeDate.DateTime = DateTime.Now;
             txtFormNo_DoubleClick(null, null);
             txtReqDate.DateTime =SysConvert.ToDateTime("1900-01-01");
             txtFactFinishDate.DateTime =SysConvert.ToDateTime("1900-01-01");
             gridSet();
           
        }

        public void gridSet()
        {
            DataTable dt = (DataTable)gridView1.GridControl.DataSource;
            int index = 0;
            string sql = "SELECT * FROM Data_Follow order by Sort";
            DataTable dto = SysUtils.Fill(sql);
            foreach (DataRow dr in dt.Rows)
            {
                if (index < dto.Rows.Count)
                {
                    dr["ProcStepID"] = SysConvert.ToInt32(dto.Rows[index]["ID"]);
                    dr["CheckItem"] = SysConvert.ToString(dto.Rows[index]["Des"]);
                }
                index++;
            }
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//������UI
            this.HTDataTableName = "Buy_ItemBuyFollow";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ProcStepID", "CheckItem" };//������ϸУ�����¼���ֶ�
            Common.BindVendor(drpShopID, new int[] { (int)EnumVendorType.���� }, true);
            Common.BindCLS(txtPackReq, "Buy_ItemBuyFollow", "PackReq", true);
            new VendorProc(drpShopID);
            txtOrderFormNo.ToolTip = "��˫�����زɹ���";
            Common.BindFollow(drpFollow, true);


            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "����", false, txtOrderFormNo_DoubleClick);

            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.δ�������ݱȶ�����);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ItemBuyFollow EntityGet()
        {
            ItemBuyFollow entity = new ItemBuyFollow();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName; 
  			entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.ShopID = SysConvert.ToString(drpShopID.EditValue);
            entity.FormDate = DateTime.Now.Date;
            if (txtReqDate.Text == "")
            {
                entity.ReqDate =SysConvert.ToDateTime("1900-01-01");
            }
            else
            {
                entity.ReqDate = txtReqDate.DateTime.Date;
            }
  			entity.OrderFormNo = txtOrderFormNo.Text.Trim(); 
  			entity.BuyFormNo = txtBuyFormNo.Text.Trim(); 
  			entity.ColorCount = SysConvert.ToString(txtColorCount.Text.Trim()); 
  			entity.ItemCode = txtItemCode.Text.Trim(); 
  			entity.GoodsCode = txtGoodsCode.Text.Trim(); 
  			entity.ItemModel = txtItemModel.Text.Trim(); 
  			entity.MWidth = SysConvert.ToDecimal(txtMWidth.Text.Trim()); 
  			entity.MWeight = SysConvert.ToDecimal(txtMWeight.Text.Trim()); 
  			entity.YarnStd = txtYarnStd.Text.Trim(); 
  			entity.JWM = txtJWM.Text.Trim(); 
  			entity.ZWZZ = txtZWZZ.Text.Trim(); 
  			entity.RSType = txtRSType.Text.Trim(); 
  			entity.ItemName = txtItemName.Text.Trim(); 
  			entity.PackReq = txtPackReq.Text.Trim(); 
  			entity.FYFlag = SysConvert.ToInt32(txtFYFlag.EditValue); 
  			entity.FYCount = SysConvert.ToInt32(txtFYCount.Text.Trim());
            if (txtFactFinishDate.Text == "")
            {
                entity.FactFinishDate =SysConvert.ToDateTime("1900-01-01");
            }
            else
            {
                entity.FactFinishDate = txtFactFinishDate.DateTime.Date;
            }
  			entity.PGZL = txtPGZL.Text.Trim(); 
  			entity.PGZLDesc = txtPGZLDesc.Text.Trim(); 
  			entity.PGJQ = txtPGJQ.Text.Trim(); 
  			entity.PGJQDesc = txtPGJQDesc.Text.Trim(); 
  			entity.PGPH = txtPGPH.Text.Trim(); 
  			entity.PGPHDesc = txtPGPHDesc.Text.Trim(); 
  			entity.PGZH = txtPGZH.Text.Trim(); 
  			entity.PGZHDesc = txtPGZHDesc.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.FYItemName = txtFYItemName.Text.Trim();
            entity.DLoadDtsID = SysConvert.ToInt32(txtDLoadDtsID.Text.Trim());
            
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ItemBuyFollowDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            ItemBuyFollowDts[] entitydts = new ItemBuyFollowDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new ItemBuyFollowDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));

                    entitydts[index].SelectByID();

                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = index + 1;


                    entitydts[index].ProcStepID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ProcStepID"));
                    entitydts[index].DLoadDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLoadDtsID"));
                    entitydts[index].CheckItem = SysConvert.ToString(gridView1.GetRowCellValue(i, "CheckItem"));
                    entitydts[index].FinishTime = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "FinishTime"));
                    entitydts[index].FactTime = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "FactTime"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));


                    index++;
                }
            }
            return entitydts;
        }

        #endregion


        #region ���زɹ���

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��������);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrderFormNo_DoubleClick(object sender, EventArgs e)
        {

            if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
            {
                frmLoadItemBuy frm = new frmLoadItemBuy();
                string sql ="";
                //sql += " AND FormNo NOT IN (SELECT BuyFormNo FROM Buy_ItemBuyFollow";
                sql += " AND DtsID NOT IN (SELECT ISNULL(DLoadDtsID,0) FROM Buy_ItemBuyFollow";
                if (saveNoLoadCheckDayNum != 0)
                {
                    sql += " WHERE FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
                }
                sql += ") ";
                frm.NoLoadCondition = sql;
                frm.ShowDialog();
                string str = string.Empty;
                if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
                {
                    if (frm.ItemBuyID.Length > 1)
                    {
                        this.ShowMessage("��ֻѡ��һ���ɹ�����Ϣ���м���");
                        return;
                    }
                    for (int i = 0; i < frm.ItemBuyID.Length; i++)
                    {
                        if (str != string.Empty)
                        {
                            str += ",";
                        }
                        str += SysConvert.ToString(frm.ItemBuyID[i]);
                    }
                    SetBuyNo(str);

                }
            }
        }

        /// <summary>
        /// ���زɹ�����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void SetBuyNo(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            
            string sql = "SELECT * FROM  UV1_Buy_ItemBuyFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[0]));
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
            {

                txtOrderFormNo.Text = SysConvert.ToString(dt.Rows[0]["DtsSo"]);
                txtItemCode.Text=SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                txtItemName.Text = SysConvert.ToString(dt.Rows[0]["ItemName"]);
                drpShopID.EditValue = SysConvert.ToString(dt.Rows[0]["ShopID"]);
                txtMWeight.Text = SysConvert.ToString(dt.Rows[0]["MWeight"]);
                txtMWidth.Text = SysConvert.ToString(dt.Rows[0]["MWidth"]);
                txtGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                txtReqDate.DateTime = SysConvert.ToDateTime(dt.Rows[0]["ReqDate"]);
                txtYarnStd.Text = GetYarnStd(txtItemCode.Text);
                txtZWZZ.Text = GetZWZZ(txtItemCode.Text);
                txtItemModel.Text = GetItemModel(txtItemCode.Text);
                txtJWM.Text = GetJWM(txtItemCode.Text);
                txtBuyFormNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
                txtColorCount.Text = SysConvert.ToString(dt.Rows[0]["ColorNum"]) + SysConvert.ToString(dt.Rows[0]["ColorName"]);
                txtDLoadDtsID.Text = SysConvert.ToString(dt.Rows [0]["DtsID"]);
               
                setRowID++;
            }
            if (txtItemCode.Text.Trim() != "")
            {
                lbWeightUnit.Text = Common.GetWeightUnit(txtItemCode.Text.Trim());

            }
            //GetItemBuyColor(txtBuyFormNo.Text.Trim(),txtItemCode.Text);

        }

        private void GetItemBuyColor(string p_BuyFormNo,string p_ItemCode)
        {
            string sql = "SELECT * FROM UV1_Buy_ItemBuyFormDts WHERE FormNo="+SysString.ToDBString(p_BuyFormNo)+" AND ItemCode="+SysString.ToDBString(p_ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            string str = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (str != "")
                    {
                        str += "    ";
                    }
                    string ColorNum = SysConvert.ToString(dt.Rows[i]["ColorNum"]);
                    string ColorName = SysConvert.ToString(dt.Rows[i]["ColorName"]);
                    string ColorGroup = "";
                    if (ColorNum == ColorName)
                    {
                        ColorGroup = ColorNum;
                    }
                    else
                    {
                        ColorGroup = ColorNum + ColorName;
                    }
                    str += ColorGroup + "/" + SysConvert.ToString(dt.Rows[i]["Qty"]) + SysConvert.ToString(dt.Rows[i]["Unit"]);
                }
            }
            txtColorCount.Text = str;
        }

        private string GetYarnStd(string p_ItemCode)
        {
            string sql = "SELECT YarnStd FROM Data_Item WHERE ItemCode="+SysString.ToDBString(p_ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            return string.Empty;
        }


        private string GetJWM(string p_ItemCode)
        {
            string sql = "SELECT JWM FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            return string.Empty;
        }

        private string GetZWZZ(string p_ItemCode)
        {
            string sql = "SELECT ZWZZ FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            return string.Empty;
        }

        private string GetItemModel(string p_ItemCode)
        {
            string sql = "SELECT ItemModel FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            return string.Empty;
        }
        #endregion

        


        #region �����¼�

        #endregion


    }
}