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
using DevExpress.XtraGrid.Views.Base;
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// ���ܣ����۹���
    ///  
    /// </summary>
    public partial class frmQuotedPriceEdit : frmAPBaseUIFormEdit
    {
        public frmQuotedPriceEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("�����뱨�۵���");
                txtFormNo.Focus();
                return false;
            }

            //if (SysConvert.ToString(drpSaleOPID.EditValue) == "")
            //{
            //    this.ShowMessage("��ѡ��ҵ��Ա");
            //    drpSaleOPID.Focus();
            //    return false;
            //}

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("��ѡ�񱨼ۿͻ�");
                drpVendorID.Focus();
                return false;
            }

            if (ProductParamSet.GetIntValueByID(5416) == (int)YesOrNo.Yes)//��ʾ�۸�����۸���Ч��
            {
                if (txtTradeType.Text == "")
                {
                    this.ShowMessage("��ѡ��ó������");
                    txtTradeType.Focus();
                    return false;
                }
            }

            if (!this.CheckCorrectDts())
            {
                return false;
            }

            //if (!CheckQuotedPrice())
            //{
            //    return false;
            //}
            return true;
        }


        /// <summary>
        /// У����ϸ�����Ƿ��ظ�
        /// </summary>
        /// <returns></returns>
        //private bool CheckQuotedPrice()
        //{
        //    for (int i = 0; i < gridView1.RowCount; i++)
        //    {
        //        if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
        //        {
        //            for (int j = 0; j < gridView1.RowCount; j++)
        //            {
        //                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
        //                {
        //                    if (i != j && SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ItemCode")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ColorNum")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ColorName")))
        //                    {
        //                        this.ShowMessage("��" + SysConvert.ToString(SysConvert.ToInt32(i + 1)) + "���������" + SysConvert.ToString(SysConvert.ToInt32(j + 1)) + "�������ظ�,��Ʒ���.ɫ��.��ɫһ��,��������±���");
        //                        return false;
        //                    }
        //                }
        //            }

        //            if (SysConvert.ToString(drpVendorID.EditValue) != "")
        //            {
        //                string sql = "SELECT FormNo,MakeDate,USB,RMB FROM UV1_Sale_QuotedPriceDts where DVendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
        //                sql += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")));
        //                sql += " AND SubmitFlag=1";
        //                DataTable dt = SysUtils.Fill(sql);
        //                if (dt.Rows.Count > 0)
        //                {
        //                    if (DialogResult.Yes != ShowConfirmMessage("�ÿͻ��Ĳ�Ʒ��" + SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) + "�ѱ��ۣ����۵���Ϊ��" + SysConvert.ToString(dt.Rows[0]["FormNo"].ToString()) + ",��������Ϊ��" + SysConvert.ToDateTime(dt.Rows[0]["MakeDate"]).ToString("yyyy-MM-dd") + ",����Ϊ��" + SysConvert.ToString(dt.Rows[0]["USB"].ToString()) + SysConvert.ToString(dt.Rows[0]["RMB"].ToString()) + "ȷ������������"))
        //                    {
        //                        return false;
        //                    }
        //                    //this.ShowMessage("�ÿͻ��Ĳ�Ʒ��" + SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) + "�ѱ��ۣ����۵���Ϊ��" + SysConvert.ToString(dt.Rows[0]["FormNo"].ToString()) + ",��������Ϊ��" + SysConvert.ToDateTime(dt.Rows[0]["MakeDate"]).ToString("yyyy-MM-dd") + ",����Ϊ��" + SysConvert.ToString(dt.Rows[0]["SalePrice"].ToString()));
        //                    //return false;
        //                }
        //            }
        //        }


        //    }
        //    return true;
        //}

        /// <summary>
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {
            QuotedPriceDtsRule rule = new QuotedPriceDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();

            //if (dtDts.Rows.Count > 0)
            //{
            //    txtMHL.Text = SysConvert.ToString(gridView1.GetRowCellValue(0,"HL"));
            //}
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            QuotedPriceRule rule = new QuotedPriceRule();
            QuotedPrice entity = EntityGet();
            QuotedPriceDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            QuotedPriceRule rule = new QuotedPriceRule();
            QuotedPrice entity = EntityGet();
            QuotedPriceDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);

        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            QuotedPrice entity = new QuotedPrice();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            drpVendorID.EditValue = entity.VendorID.ToString();
            txtRemark.Text = entity.Remark.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
            drpVendorOPName.EditValue = entity.VendorOPName;
            txtMHL.Text = entity.HL.ToString();
            txtPriceContext.Text = entity.PriceContext;
            txtEffDate.DateTime = entity.EffDate;

            txtJiaoQi.DateTime = entity.JiaoQi;
            txtYongJing.Text = entity.YongJing.ToString();
            txtGangKou.Text = entity.GangKou.ToString();
            txtKHType.Text = entity.KHType.ToString();
            txtZZMarket.Text = entity.ZZMarket.ToString();

            txtTradeType.Text = entity.TradeType;
            txtAddper.Text = entity.AddPer.ToString();

            txtEffTime.Text = entity.EffTime;
            drpTradeWay.EditValue = entity.TradeWay;
            drpPayMothodFlag.EditValue = entity.PayMethodFlag;
            drpTransportWay.EditValue = entity.TransportWay;
            drpSelvageReq.EditValue = entity.SelvageReq;
            drpDyeReq.EditValue = entity.DyeReq;
            drpArrangeReq.EditValue = entity.ArrangeReq;
            drpPackReq.EditValue = entity.PackReq;
            drpQualityReq.EditValue = entity.QualityReq;
            drpDeliveryReq.EditValue = entity.DeliveryReq;
            drpVEmail.EditValue = entity.VEmail;
            drpVTelephone.EditValue = entity.VTelephone;
            drpVFax.EditValue = entity.VFax;
            drpVAddress.EditValue = entity.VAddress;
            txtOtherReq.EditValue = entity.OtherReq;
            drpBJSaleOPID.EditValue = entity.BJSaleOPID;
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
            QuotedPriceRule rule = new QuotedPriceRule();
            QuotedPrice entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProductCommon.FormNoCtlEditSet(txtFormNo, "Sale_QuotedPrice", "FormNo", 0, p_Flag);
            //ProcessGrid.SetGridEdit(gridView1, new string[] { "SalePrice" }, true);
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now;
            txtFormNo_DoubleClick(null, null);
            txtJiaoQi.DateTime = DateTime.Now.Date;
            drpSaleOPID.EditValue = FParamConfig.LoginID;
            drpBJSaleOPID.EditValue = FParamConfig.LoginID;
            txtTradeType.EditValue = "��ó";
            txtEffDate.DateTime = DateTime.Now.Date;
            txtMHL.Text = "6.8";
        }
        public override void IniRefreshData()
        {
            Common.BindPayMethod(drpPayMothodFlag, true);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            IniUCPicture();

            ProcessGrid.BindGridColumn(gridView1, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//������UI
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[3] { gridView2, gridView3, gridView4 };
            this.HTDataTableName = "Sale_QuotedPrice";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode" };//������ϸУ�����¼���ֶ�
            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);//�ͻ�
            //Common.BindEnumUnit(txtUnit, true);

            Common.BindCLS(txtUnit, "Data_Item", "ItemUnitFab", true);
            // Common.BindOP(drpSaleOPID, true);
            //if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//��֯�ṹ��ϵ����
            //{
            //    Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            //}
            //else
            //{
            //    Common.BindOPID(drpSaleOPID, true);
            //}
            DevMethod.BindItem(drpItemCode, true);
            DevMethod.BindOP(drpSaleOPID, new int[] { (int)EnumOPDep.ҵ�� }, true);
            DevMethod.BindOP(drpBJSaleOPID, new int[] { (int)EnumOPDep.ҵ�� }, true);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "��������", false, btnLoad_Click);

            //if (!SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5201)))//���۵��������������ذ�ť
            //{
            //    this.ToolBarItemAdd(28, "btnLoadLY", "����������", false, btnLoadLY_Click);
            //}
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);

            Common.BindItemClass(drpItemClassID, new int[] { (int)EnumItemType.���� }, true);

            if (ProductParamSet.GetIntValueByID(5416) == (int)YesOrNo.Yes)//��ʾ�۸�����۸���Ч��
            {
                lbEffDate.Visible = true;
                txtEffDate.Visible = true;
                lbPriceContext.Visible = true;
                txtPriceContext.Visible = true;
                lbAddPrice.Visible = true;
                txtAddper.Visible = true;
                lbTrade.Visible = true;
                txtTradeType.Visible = true;
                lbMHL.Visible = true;
                txtMHL.Visible = true;
            }



            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��0))//�鿴�۸�Ȩ��
            {
                txtGridSet.PasswordChar = '*';
            }


        }

        /// <summary>
        /// ���иı��¼�
        /// </summary>
        /// <param name="sender"></param>
        public void gridViewRowChanged1(object sender)
        {
            try
            {
                ColumnView view = sender as ColumnView;
                string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
                string ColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorName"));



                string sql = "SELECT * FROM Data_ItemColorDtsHis WHERE MainID IN (SELECT ID FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(ItemCode) + ")";
                sql += " ORDER BY Seq DESC";
                DataTable dt = SysUtils.Fill(sql);
                gridView2.GridControl.DataSource = dt;
                gridView2.GridControl.Show();

                sql = "SELECT * FROM UV1_Sale_QuotedPriceDts WHERE ItemCode=" + SysString.ToDBString(ItemCode);
                sql += " ORDER BY MakeDate DESC";
                dt = SysUtils.Fill(sql);
                gridView3.GridControl.DataSource = dt;
                gridView3.GridControl.Show();


                if (SysConvert.ToString(drpVendorID.EditValue) != "")
                {
                    sql = "SELECT * FROM UV1_Sale_QuotedPriceDts WHERE VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
                    sql += " ORDER BY MakeDate DESC";
                    dt = SysUtils.Fill(sql);
                    gridView4.GridControl.DataSource = dt;
                    gridView4.GridControl.Show();
                }

                BindGridColor();
                BindImage();
                //string GBCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "GBCode"));

                GetItemLabel(ItemCode);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// �������б��ڵ���ɫ�ؼ�
        /// </summary>
        void BindGridColor()
        {
            if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)//�������޸ģ�����ɫ��ɫ��
            {
                string itemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                Common.BindItemColor(drpGridColorNum, drpGridColorName, itemCode, true);//�������ϰ�ɫ��ɫ��
            }
        }


        #region �Զ��巽��ͼƬ���
        /// <summary>
        /// ��ͼƬ
        /// </summary>
        void BindImage()
        {
            string itemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));

            byte[] picdata = GetPic(itemCode);

            if (picdata != null)
            {
                List<Image> lstimage = new List<Image>();
                if (picdata.Length > 10)
                {
                    lstimage.Add(TemplatePic.ByteToImage(picdata));
                }
                ucPictureView1.UCDataLstImage = lstimage;
            }
            else
            {
                List<Image> lstimage = new List<Image>();
                ucPictureView1.UCDataLstImage = lstimage;
            }

        }


        /// <summary>
        /// ��������õ�ͼƬ
        /// </summary>
        /// <param name="p_Code"></param>
        /// <returns></returns>
        private byte[] GetPic(string p_Code)
        {
            string sql = "SELECT TOP 1 GBPic FROM UV1_Data_ItemGB WHERE ItemCode=" + SysString.ToDBString(p_Code) + " ORDER BY GBCode ";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["GBPic"] != DBNull.Value)
                {
                    return (byte[])dt.Rows[0]["GBPic"];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��ʼ��ͼƬ�ؼ�
        /// </summary>
        void IniUCPicture()
        {
            ucPictureView1.UCReadOnly = true;
            ucPictureView1.UCInputPictureMultiFlag = false;//��ͼģʽ
            ucPictureView1.UCInputMainType = 2;//ͼƬģʽ
            ucPictureView1.UCInputDBSaveType = 1;//ͬһ����ֻ��Update  

            ucPictureView1.UCDBMainIDFieldName = "";
            ucPictureView1.UCDBRemarkFieldName = "";
            ucPictureView1.UCDBTableName = "Data_ItemGB";
            ucPictureView1.UCDBPicFieldName = "GBPic";
            ucPictureView1.UCDBSmallPicFieldName = "GBPic2";
            ucPictureView1.UCDataID = 0;
            ucPictureView1.UCAct();
        }
        #endregion


        private void GetItemLabel(string itemCode)
        {
            string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(itemCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                lbItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                //lbGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                //lbVendorID.Text = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                lbColorNum.Text = SysConvert.ToString(dt.Rows[0]["MWidth"]);
                lbColorName.Text = SysConvert.ToString(dt.Rows[0]["MWeight"]);
            }
        }

        /// ���عҰ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {

                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    restxtItemCode_DoubleClick(null, null);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnLoadLY_Click(object sender, EventArgs e)
        {
            try
            {

                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    LoadLYForm();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void LoadLYForm()
        {
            frmLoadLY frm = new frmLoadLY();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.LYID != null && frm.LYID.Length != 0)
            {

                for (int i = 0; i < frm.LYID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.LYID[i]);
                }
                setLYNews(str);
                gridViewRowChanged1(gridView1);
            }
        }


        private void setLYNews(string str)
        {
            string[] arr = str.Split(',');
            int index = checkRowSet();
            int length = 0;
            for (int i = index; i < arr.Length + index; i++)
            {
                string sql = "SELECT * FROM UV1_Dev_LYGLDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    //gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(i, "GBCode", SysConvert.ToString(dt.Rows[0]["GBCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "MLLBName", SysConvert.ToString(dt.Rows[0]["MLLBName"]));

                }
                length++;
            }
        }



        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private QuotedPrice EntityGet()
        {
            QuotedPrice entity = new QuotedPrice();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.VendorID = drpVendorID.EditValue.ToString();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.BJSaleOPID = SysConvert.ToString(drpBJSaleOPID.EditValue);
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
            entity.Remark = txtRemark.Text.Trim();
            entity.VendorOPName = SysConvert.ToString(drpVendorOPName.EditValue);
            entity.EffDate = txtEffDate.DateTime;
            entity.PriceContext = txtPriceContext.Text.Trim();
            entity.TradeType = txtTradeType.Text.Trim();

            entity.JiaoQi = txtJiaoQi.DateTime.Date;
            entity.YongJing = txtYongJing.Text.Trim();
            entity.GangKou = txtGangKou.Text.Trim();
            entity.KHType = txtKHType.Text.Trim();
            entity.ZZMarket = txtZZMarket.Text.Trim();

            entity.AddPer = SysConvert.ToDecimal(txtAddper.Text.Trim());
            entity.HL = SysConvert.ToDecimal(txtMHL.Text.Trim());

            // entity.TradeType = txtTradeType.Text.Trim();
            entity.EffTime = txtEffTime.Text.Trim();

            entity.TradeWay = SysConvert.ToString(drpTradeWay.EditValue);
            entity.PayMethodFlag = SysConvert.ToInt32(drpPayMothodFlag.EditValue);
            entity.TransportWay = SysConvert.ToString(drpTransportWay.EditValue);
            entity.SelvageReq = SysConvert.ToString(drpSelvageReq.EditValue);
            entity.DyeReq = SysConvert.ToString(drpDyeReq.EditValue);
            entity.ArrangeReq = SysConvert.ToString(drpArrangeReq.EditValue);
            entity.PackReq = SysConvert.ToString(drpPackReq.EditValue);
            entity.QualityReq = SysConvert.ToString(drpQualityReq.EditValue);
            entity.DeliveryReq = SysConvert.ToString(drpDeliveryReq.EditValue);
            entity.OtherReq = SysConvert.ToString(txtOtherReq.EditValue);
            entity.VEmail = SysConvert.ToString(drpVEmail.EditValue);
            entity.VTelephone = SysConvert.ToString(drpVTelephone.EditValue);
            entity.VFax = SysConvert.ToString(drpVFax.EditValue);
            entity.VAddress = SysConvert.ToString(drpVAddress.EditValue);


            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private QuotedPriceDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            QuotedPriceDts[] entitydts = new QuotedPriceDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new QuotedPriceDts();

                    if (HTFormStatus == FormStatus.����)
                    {
                        entitydts[index].ID = HTDataID;
                    }
                    else
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    }
                  
                    entitydts[index].SelectByID();

                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;

                    entitydts[index].GBCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode"));
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));//�ͻ�Ʒ��
                    entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum"));//�ͻ�ɫ��
                    entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName"));//�ͻ�ɫ��
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    //entitydts[index] = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")); 
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].MinQty = SysConvert.ToString(gridView1.GetRowCellValue(i, "MinQty"));
                    entitydts[index].PBPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PBPrice"));
                    entitydts[index].ColorPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "ColorPrice"));
                    entitydts[index].ZLPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "ZLPrice"));
                    entitydts[index].Shrinkage = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Shrinkage"));
                    entitydts[index].TotalPriceUSB = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TotalPriceUSB"));
                    entitydts[index].HL = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "HL"));
                    entitydts[index].TotalPriceRMB = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TotalPriceRMB"));
                    entitydts[index].FK = SysConvert.ToString(gridView1.GetRowCellValue(i, "FK"));
                    entitydts[index].KZ = SysConvert.ToString(gridView1.GetRowCellValue(i, "KZ"));
                    entitydts[index].USB = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "USB"));//��Ԫ����M
                    entitydts[index].ItemUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemUnit"));

                    entitydts[index].PackFee = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PackFee"));//��װ��
                    entitydts[index].LiRunFee = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "LiRunFee"));//����
                    entitydts[index].YongJin = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "YongJin"));//Ӷ��
                    entitydts[index].TradeFee = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TradeFee"));//�˷�
                    entitydts[index].Fee1 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Fee1"));//��������
                    entitydts[index].HouZLReq = SysConvert.ToString(gridView1.GetRowCellValue(i, "HouZLReq"));///������Ҫ��
                    entitydts[index].RMB = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "RMB"));//�����M����
                    entitydts[index].Needle = SysConvert.ToString(gridView1.GetRowCellValue(i, "Needle"));///�ܶ�
                    entitydts[index].RMBY = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "RMBY"));//�����Y����
                    entitydts[index].USBY = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "USBY"));//��ԪY����

                    index++;
                }
            }
            return entitydts;
        }

        #endregion


        #region ����
        /// <summary>
        /// ���عҰ���Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restxtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {


                    frmLoadFabric frm = new frmLoadFabric();

                    frm.SelectItemType = SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5413)); //0����ʾֻ֧�ּ��ز�Ʒ  1����ʾֻ֧��ѡ����ز�Ʒ��������  2:��ʾ����


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
                        setItemNews(str);
                    }
                    gridViewRowChanged1(gridView1);


                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void setItemNews(string str)
        {
            int setRowID = Common.GetNewRow(gridView1, "ItemCode");
            string[] gbid = str.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));//�ƺ�ʹ�ã����θ�Ϊ�ܶ�
                    gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));
                    setRowID++;
                }
            }
        }

        //private void setItemNews(string str)
        //{
        //    string[] arr = str.Split(',');
        //    int index = checkRowSet();
        //    int length = 0;
        //    for (int i = index; i < arr.Length + index; i++)
        //    {
        //        string sql = "SELECT * FROM UV1_Data_ItemGB WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
        //        DataTable dt = SysUtils.Fill(sql);

        //        if (dt.Rows.Count > 0)
        //        {
        //            gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
        //            gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
        //            gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
        //            gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
        //            gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
        //            gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
        //            gridView1.SetRowCellValue(i, "GBCode", SysConvert.ToString(dt.Rows[0]["GBCode"]));
        //            gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
        //            gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
        //            gridView1.SetRowCellValue(i, "MLLBName", SysConvert.ToString(dt.Rows[0]["MLLBName"]));

        //        }
        //        length++;
        //    }
        //}

        private int checkRowSet()
        {
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) == string.Empty)
                {
                    index = i;
                    return index;
                }
            }
            return index;

        }

        #endregion


        #region �����¼�

        /// <summary>
        /// ɨ��Ұ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemGBCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    if (ProductParamSet.GetIntValueByID(5015) == (int)YesOrNo.Yes)//����ɨ���Ʒ��ţ�0��ʾɨ��Ұ���
                    {
                        string ItemCode = txtItemGBCode.Text.Trim();
                        if (ItemCode != "")
                        {
                            string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(ItemCode);
                            DataTable dt = SysUtils.Fill(sql);
                            if (dt.Rows.Count > 0)
                            {
                                int RowHandle = checkRowSet();
                                gridView1.SetRowCellValue(RowHandle, "ItemCode", dt.Rows[0]["ItemCode"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "ItemName", dt.Rows[0]["ItemName"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "ItemModel", dt.Rows[0]["ItemModel"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "ItemStd", dt.Rows[0]["ItemStd"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "GoodsCode", dt.Rows[0]["GoodsCode"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"].ToString()));
                                gridView1.SetRowCellValue(RowHandle, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"].ToString()));
                                gridView1.SetRowCellValue(RowHandle, "HZType", dt.Rows[0]["HZType"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "ItemClassID", SysConvert.ToInt32(dt.Rows[0]["ItemClassID"].ToString()));
                                gridView1.SetRowCellValue(RowHandle, "DeliveryTime", dt.Rows[0]["DeliveryTime"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "MinQty", dt.Rows[0]["MinQty"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "PerMiWeight", SysConvert.ToDecimal(dt.Rows[0]["PerMiWeight"].ToString()));
                                gridView1.SetRowCellValue(RowHandle, "SalePrice", SysConvert.ToDecimal(dt.Rows[0]["SalePrice"].ToString()));

                                txtItemGBCode.Text = "";
                                txtItemGBCode.Focus();

                                if (ProductParamSet.GetIntValueByID(5416) == (int)YesOrNo.Yes)//���ӼӼ۱���,�ܿ�Ҫ������
                                {
                                    if (SysConvert.ToDecimal(dt.Rows[0]["SalePrice"]) > 0)
                                    {
                                        gridView1.SetRowCellValue(RowHandle, "SaleOPPrice", SysConvert.ToDecimal(dt.Rows[0]["SalePrice"]));
                                        gridView1.SetRowCellValue(RowHandle, "SalePrice", SysConvert.ToDecimal(dt.Rows[0]["SalePrice"].ToString()));
                                    }
                                    else
                                    {
                                        gridView1.SetRowCellValue(RowHandle, "SaleOPPrice", DBNull.Value);
                                        gridView1.SetRowCellValue(RowHandle, "SalePrice", DBNull.Value);
                                    }
                                }

                            }
                            else
                            {
                                this.ShowMessage("���벻���ڣ�");
                                txtItemGBCode.Text = "";
                                txtItemGBCode.Focus();
                            }
                        }
                        else
                        {
                            this.ShowMessage("��ɨ�����룡");
                            txtItemGBCode.Text = "";
                            txtItemGBCode.Focus();
                        }
                    }
                    else
                    {
                        string GBCode = txtItemGBCode.Text.Trim();
                        if (GBCode != string.Empty)
                        {
                            string sql = "SELECT * FROM UV1_Data_ItemGB WHERE 1=1 ";
                            sql += " AND GBCode = " + SysString.ToDBString(GBCode);
                            DataTable dt = SysUtils.Fill(sql);
                            if (dt.Rows.Count == 1)
                            {
                                bool Insertbol = false;
                                for (int i = 0; i < gridView1.RowCount; i++)
                                {
                                    if (!CheckDataCompleteDts(i))
                                    {
                                        gridView1.SetRowCellValue(i, "GBCode", dt.Rows[0]["GBCode"].ToString());
                                        gridView1.SetRowCellValue(i, "ItemCode", dt.Rows[0]["ItemCode"].ToString());
                                        gridView1.SetRowCellValue(i, "ItemName", dt.Rows[0]["ItemName"].ToString());
                                        gridView1.SetRowCellValue(i, "ItemModel", dt.Rows[0]["ItemModel"].ToString());
                                        gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"].ToString()));
                                        gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"].ToString()));
                                        gridView1.SetRowCellValue(i, "ColorNum", dt.Rows[0]["ColorNum"].ToString());
                                        gridView1.SetRowCellValue(i, "ColorName", dt.Rows[0]["ColorName"].ToString());
                                        gridView1.SetRowCellValue(i, "MLLBName", dt.Rows[0]["MLLBName"].ToString());
                                        Insertbol = true;
                                    }
                                    if (Insertbol)
                                    {
                                        break;
                                    }

                                }
                            }
                            else
                            {
                                if (dt.Rows.Count == 0)
                                {
                                    this.ShowMessage("�ùҰ����벻��������");
                                }
                                else
                                {
                                    this.ShowMessage("�����쳣���ùҰ����벻Ψһ������");
                                }
                                return;
                            }

                        }
                        txtItemGBCode.Text = "";
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// �������ɱ��۵���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    ProductCommon.FormNoIniSet(txtFormNo, "Sale_QuotedPrice", "FormNo", 0);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// ֵ�ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (this.HTFormStatus == FormStatus.���� || this.HTFormStatus == FormStatus.�޸�)
                {
                    if (e.Column.FieldName == "ItemCode")
                    {
                        ColumnView view = sender as ColumnView;
                        string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                        string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(ItemCode);
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count == 1)
                        {
                            view.SetRowCellValue(view.FocusedRowHandle, "ItemName", dt.Rows[0]["ItemName"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "ItemStd", dt.Rows[0]["ItemStd"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "ItemModel", dt.Rows[0]["ItemModel"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "Unit", dt.Rows[0]["ItemUnit"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "Needle", dt.Rows[0]["Needle"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "MWidth", dt.Rows[0]["MWidth"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "MWeight", dt.Rows[0]["MWeight"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "GoodsCode", dt.Rows[0]["GoodsCode"]);
                        }
                    }

                    //if (e.Column.FieldName == "ColorNum")//ɫ�Ÿı䣬������ֵɫ��
                    //{
                    //    ColumnView view = sender as ColumnView;
                    //    string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                    //    string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
                    //    view.SetRowCellValue(view.FocusedRowHandle, "ColorName", Common.GetItemColorNameByColorNum(ItemCode, ColorNum));

                    //}
                    //    if (e.Column.FieldName == "PBPrice" || e.Column.FieldName == "ColorPrice" || e.Column.FieldName == "ZLPrice" || e.Column.FieldName == "HL" || e.Column.FieldName == "PackFee" || e.Column.FieldName == "LiRunFee" || e.Column.FieldName == "Shrinkage" || e.Column.FieldName == "Fee1" || e.Column.FieldName == "TradeFee" || e.Column.FieldName == "YongJin")//�۸�仯�������=������/��1-����%��+Ⱦ����+�������+��װ��+����+��������
                    //    {
                    //        ColumnView view = sender as ColumnView;
                    //        decimal PBPrice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "PBPrice"));//�����۸�
                    //        decimal ColorPrice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "ColorPrice"));//Ⱦɫ����
                    //        decimal ZLPrice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "ZLPrice"));//�������
                    //        decimal PackFee = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "PackFee"));//��װ����
                    //        decimal LiRunFee = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "LiRunFee"));//����
                    //        decimal Shrinkage = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "Shrinkage"));//��������
                    //        decimal Fee1 = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "Fee1"));//��������
                    //        //decimal HL = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "HL"));//����
                    //        decimal HL = SysConvert.ToDecimal(txtMHL.Text.Trim());//����
                    //        decimal a = Shrinkage * SysConvert.ToDecimal(0.01);
                    //        decimal TotalPriceRMB = PBPrice / (1 - a) + ZLPrice + ColorPrice + PackFee + LiRunFee + Fee1;
                    //        view.SetRowCellValue(view.FocusedRowHandle, "TotalPriceRMB", SysConvert.ToDecimal(TotalPriceRMB, 2));
                    //        if (HL != 0)
                    //        {
                    //            decimal TradeFee = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "TradeFee"));
                    //            decimal YongJin = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "YongJin")) * SysConvert.ToDecimal(0.01) + 1;
                    //            decimal b = TotalPriceRMB * SysConvert.ToDecimal(0.9144);
                    //            decimal c = SysConvert.ToDecimal(b / HL, 2) + TradeFee;
                    //            decimal TotalPriceUSB = SysConvert.ToDecimal(c * YongJin, 2);

                    //            view.SetRowCellValue(view.FocusedRowHandle, "TotalPriceUSB", TotalPriceUSB);

                    //        }
                    //    }

                    //}
                    if (e.Column.FieldName == "RMB" || e.Column.FieldName == "HL")
                    {
                        //�������/����=�����ף��������*0.9144/����=�����룻
                        ColumnView view = sender as ColumnView;
                        decimal rmb = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "RMB"));

                        //decimal HL = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "HL"));
                        decimal HL = SysConvert.ToDecimal(txtMHL.Text.Trim());//����
                        decimal usb = SysConvert.ToDecimal(rmb / HL, 2);//�����M/����=��M
                        decimal a = SysConvert.ToDecimal(rmb * SysConvert.ToDecimal(0.9144), 2);
                        decimal usby = SysConvert.ToDecimal(a / HL, 2);
                        view.SetRowCellValue(view.FocusedRowHandle, "USB", usb);
                        view.SetRowCellValue(view.FocusedRowHandle, "USBY", usby);
                    }
                    if (e.Column.FieldName == "RMBY" || e.Column.FieldName == "HL")
                    {
                        //�������/0.9144/����=�����ף��������/����=�����룻
                        ColumnView view = sender as ColumnView;

                        decimal rmby = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "RMBY"));
                        //decimal HL = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "HL"));
                        decimal HL = SysConvert.ToDecimal(txtMHL.Text.Trim());//����
                        decimal a = SysConvert.ToDecimal(rmby / SysConvert.ToDecimal(0.9144), 2);
                        decimal usb = SysConvert.ToDecimal(a / HL, 2);
                        decimal usby = SysConvert.ToDecimal(rmby / HL, 2);
                        view.SetRowCellValue(view.FocusedRowHandle, "USB", usb);
                        view.SetRowCellValue(view.FocusedRowHandle, "USBY", usby);
                        //�����M/����=��M

                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        private void txtCost_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal Cost = 0;
                decimal PBPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PBPrice"));//������
                decimal RShrinkage = GetDecimalByString(SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "RShrinkage")), '%');//Ⱦ��
                decimal RSAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "RSAmount"));//Ⱦ��
                decimal RSSH = GetDecimalByString(SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "RSSH")), '%');//Ⱦɫ���
                decimal JGAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "JGAmount"));//�ӹ���
                decimal JGSH = GetDecimalByString(SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "JGSH")), '%');//�ӹ����
                decimal HZAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HZAmount"));//��������
                //decimal ProfitMargin = GetDecimalByString(SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProfitMargin")), '%');//������
                decimal Quot = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Quot"));//Quot

                //Cost=[{(������*(1+(Ⱦ��/100))+RSAmount) *(1+(Ⱦɫ���/100))+ �ӹ���}*(1+(�ӹ����/100))+��������]*1.06+0.2
                Cost = (((PBPrice * (1m + (RShrinkage / 100m)) + RSAmount) * (1m + (RSSH / 100m)) + JGAmount) * (1m + (JGSH / 100m)) + HZAmount) * 1.06m + 0.2m;
                Cost = SysConvert.ToDecimal(Cost, 2);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "COSTA", Cost + "/M");  //COST�Զ���ֵ

                //decimal Quot = 0.0m;
                decimal ProfitMargin = 0.0m;
                if (Quot != 0 && Cost != 0)
                {
                    ProfitMargin = Quot / Cost - 1;
                }
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ProfitMargin", ProfitMargin);  //Quot

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private decimal GetDecimalByString(string p_Decimal, char p_Char)
        {
            decimal value = 0;
            if (SysConvert.ToDecimal(p_Decimal) > 0)
            {
                value = SysConvert.ToDecimal(p_Decimal);
            }
            else
            {
                string[] decimalArr = p_Decimal.Split(p_Char);
                if (decimalArr.Length > 0)
                {
                    value = SysConvert.ToDecimal(decimalArr[0]);
                }
                else
                {
                    value = 0;
                }
            }
            return value;
        }

        private void txtAddPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal SaleOPPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SaleOPPrice"));
                decimal ProfitMargin = SysConvert.ToDecimal(txtAddper.Text.Trim());
                decimal SalePrice = 0;
                if (ProfitMargin > 0)
                {
                    SalePrice = SaleOPPrice * (1m + ProfitMargin / 100m);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "SalePrice", SalePrice);
                }

                if (txtTradeType.Text == "����")
                {

                    //decimal HL = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HL"));
                    //if (HL > 0)
                    //{
                    //    decimal USDPrice = SysConvert.ToDecimal(SalePrice / HL, 2);// *(1m + ProfitMargin / 100m);
                    //    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "USDPrice", USDPrice);
                    //}
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void groupControlMainten_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtHL_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    this.BaseFocusLabel.Focus();
            //    decimal SalePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalePrice"));
            //    decimal HL = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HL"));
            //    if (HL > 0)
            //    {
            //        decimal USDPrice = SysConvert.ToDecimal(SalePrice / HL, 2);// *(1m + ProfitMargin / 100m);
            //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "USDPrice", USDPrice);
            //    }
            //}
            //catch (Exception E)
            //{
            //    this.ShowMessage(E.Message);
            //}
        }

        private void txtTradeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTradeType.Text == "����")
                {
                    this.gridColumn65.Visible = false;
                    this.gridColumn66.Visible = false;

                }
                else if (txtTradeType.Text.Trim() == "����")
                {
                    this.gridColumn65.Visible = true;
                    this.gridColumn66.Visible = true;
                    this.gridColumn65.VisibleIndex = 14;
                    this.gridColumn66.VisibleIndex = 15;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtAddper_Leave(object sender, EventArgs e)
        {
            this.BaseFocusLabel.Focus();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SaleOPPrice")) > 0)
                {
                    decimal SaleOPPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SaleOPPrice"));
                    decimal ProfitMargin = SysConvert.ToDecimal(txtAddper.Text.Trim());
                    decimal SalePrice = 0;
                    if (ProfitMargin > 0)
                    {
                        SalePrice = SaleOPPrice * (1m + ProfitMargin / 100m);
                        gridView1.SetRowCellValue(i, "SalePrice", SalePrice);
                    }
                    if (txtTradeType.Text == "����")
                    {

                        //  decimal HL = SysConvert.ToDecimal(txtMHL.Text.Trim());
                        //if (HL > 0)
                        //{
                        //    decimal USDPrice = SysConvert.ToDecimal(SalePrice / HL, 2);// *(1m + ProfitMargin / 100m);
                        //    gridView1.SetRowCellValue(i, "HL", HL);
                        //    gridView1.SetRowCellValue(i, "USDPrice", USDPrice);
                        //}
                    }
                }
            }
        }

        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
                {
                    Common.BindVendorAddress(drpVAddress, SysConvert.ToString(drpVendorID.EditValue), true);
                    Common.BindVendorContact(drpVendorOPName, SysConvert.ToString(drpVendorID.EditValue), true);

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpVendorOPName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
                {
                    drpVTelephone.Text = Common.GetVendorContactTelByVendorContact(SysConvert.ToString(drpVendorID.EditValue), SysConvert.ToString(drpVendorOPName.EditValue));
                    drpVEmail.Text = Common.GetVendorContactEmailByVendorContact(SysConvert.ToString(drpVendorID.EditValue), SysConvert.ToString(drpVendorOPName.EditValue));
                    drpVFax.Text = Common.GetVendorContactFAXByVendorContact(SysConvert.ToString(drpVendorID.EditValue), SysConvert.ToString(drpVendorOPName.EditValue));
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtMHL_EditValueChanged(object sender, EventArgs e)
        {
            if (this.HTFormStatus == FormStatus.���� || this.HTFormStatus == FormStatus.�޸�)
            {
                // gridView1_CellValueChanged(null,null);
                decimal mhl = SysConvert.ToDecimal(txtMHL.Text.Trim());
                if (mhl > 0)
                {

                    DataTable dt = (DataTable)gridView1.GridControl.DataSource;
                    dt.AcceptChanges();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (SysConvert.ToDecimal(dt.Rows[i]["RMB"]) > 0)
                        {
                            dt.Rows[i]["USB"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dt.Rows[i]["RMB"]) / mhl, 2);
                            dt.Rows[i]["USBY"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dt.Rows[i]["RMB"]) * SysConvert.ToDecimal(0.9144) / mhl, 2);
                        }
                        else if (SysConvert.ToDecimal(dt.Rows[i]["RMBY"]) > 0)
                        {
                            dt.Rows[i]["RMB"] = 0;
                            dt.Rows[i]["USB"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dt.Rows[i]["RMBY"]) / SysConvert.ToDecimal(0.9144) / mhl, 2);
                            dt.Rows[i]["USBY"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dt.Rows[i]["RMBY"]) / mhl, 2);
                        }

                    }

                    gridView1.GridControl.DataSource = dt;
                    gridView1.GridControl.Show();
                }

            }


        }




    }
}