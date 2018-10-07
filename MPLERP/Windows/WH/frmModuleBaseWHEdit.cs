using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.MLTERP.Sys;
using HttSoft.MLTERP.DataCtl;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.WinUIBase;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using HTCPCheck;



namespace MLTERP
{
    /// <summary>
    /// �ֿⵥ�ݱ༭ҳ�� --ģ�����
    /// �¼Ӻ�
    /// 2014-5-12
    /// Ŀ�ģ���������ؿɳ�ȡ�����Ĺ��ܽ��г��봦�����ں����Ľ�ͳһ����
    /// </summary>
    public partial class frmModuleBaseWHEdit : frmAPBaseUIFormEdit
    {
        public frmModuleBaseWHEdit()
        {
            InitializeComponent();
        }


        #region ��������

        /// <summary>
        /// У���Ƿ�����
        /// �������֮ǰ�ĵ���
        /// </summary>
        /// <param name="p_FormDate">��������</param>
        /// <returns></returns>
        public bool CheckLastUpdateDay(DateTime p_FormDate)
        {
            if (ProductParamSet.GetIntValueByID(6422) > 0)//�ֿⵥ�����Ƽ������ڵ��������޸�
            {
                TimeSpan ts = FParamConfig.SysTime().Date - p_FormDate.Date;
                if (ts.Days > ProductParamSet.GetIntValueByID(6422))
                {
                    this.ShowMessage("�����ύ����" + ProductParamSet.GetIntValueByID(6422) + "�죬���������ύ�����޸�,��Ҫ�޸�����ϵ����Ա�޸Ĳ����趨");
                    return false;
                }
            }
            return true;
        }




        #endregion



        #region ���ع����������
        /// <summary>
        /// ���ع������ݵ��÷���
        /// </summary>
        /// <param name="p_LoadFormType"></param>
        public void LoadRelFormData(int p_LoadFormType, GridView p_Grid, LookUpEdit p_DrpVendor)
        {
            if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
            {
                //if (Common.CheckLookUpEditBlank(drpSubType))
                //{
                //    this.ShowMessage("��ѡ�񵥾�����");
                //    return;
                //}
                switch (p_LoadFormType)
                {
                    case (int)LoadFormType.�ͻ���://�ھ���ҳ�����

                        break;
                    case (int)LoadFormType.����ⵥ:
                        WHLoadWHIOForm(p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.�ɹ���://���ϲɹ���
                        WHLoadItemBuyForm(p_Grid, p_DrpVendor);
                        break;

                    case (int)LoadFormType.ɴ�߲ɹ���:
                        WHLoadYarnBuyForm(p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.���۶���:
                        WHLoadSaleOrderForm(p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.���ϲɹ���:
                        WHLoadFLBuyForm(p_Grid, p_DrpVendor);
                        break;

                    case (int)LoadFormType.������:
                        WHLoadDYForm(p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.�����ɹ���:
                        WHLoadFabricBuyForm(p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.Ⱦ���ӹ���:
                        WHLoadFabricProcessForm((int)EnumProcessType.Ⱦ���ӹ���, p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.ӡ���ӹ���:
                        //WHLoadPrintingProcessForm();
                        WHLoadFabricProcessForm((int)EnumProcessType.ӡ���ӹ���, p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.����֯��ӹ���:
                        WHLoadFabricProcessForm((int)EnumProcessType.֯��ӹ���, p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.�����ӹ���:
                        WHLoadFabricProcessForm((int)EnumProcessType.�����ӹ���, p_Grid, p_DrpVendor);
                        //WHLoadOtherProcessForm();
                        break;
                    case (int)LoadFormType.���ϼӹ���:
                        WHLoadFabricProcessForm((int)EnumProcessType.���ϼӹ���, p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.����ָʾ��://�ƺ������ؼ���ָʾ����LoadJYForm
                        WHLoadJYForm(p_Grid);//���ؼ���ָʾ��
                        break;
                    case (int)LoadFormType.��Ʒ:
                        WHLoadProduct(p_Grid);//����
                        break;
                    case (int)LoadFormType.����:
                        WHLoadProductPB(p_Grid);//����
                        break;
                    case (int)LoadFormType.�������ϵ�:
                        WHLoadProductPBOrder(p_Grid);//����
                        break;
                    case (int)LoadFormType.����֪ͨ��:
                        WHLoadProductionNotice(p_Grid);//����
                        break;
                }
            }
        }
        public void LoadRelFormData(int p_LoadFormType, GridView p_Grid, SearchLookUpEdit p_DrpVendor)
        {
            if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
            {
                //if (Common.CheckLookUpEditBlank(drpSubType))
                //{
                //    this.ShowMessage("��ѡ�񵥾�����");
                //    return;
                //}
                switch (p_LoadFormType)
                {
                    case (int)LoadFormType.�ͻ���://�ھ���ҳ�����

                        break;
                    case (int)LoadFormType.����ⵥ:
                        WHLoadWHIOForm(p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.�ɹ���://���ϲɹ���
                        WHLoadItemBuyForm(p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.ԭ��:
                        WHLoadProductYL(p_Grid);//����
                        break;
                    case (int)LoadFormType.ɴ�߲ɹ���:
                        WHLoadYarnBuyForm(p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.���۶���:
                        WHLoadSaleOrderForm(p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.��������:
                        WHLoadSaleOrderFormNX(p_Grid, p_DrpVendor, 0);
                        break;
                    case (int)LoadFormType.��������:
                        WHLoadSaleOrderFormWX(p_Grid, p_DrpVendor, 1);
                        break;
                    case (int)LoadFormType.���ϲɹ���:
                        WHLoadFLBuyForm(p_Grid, p_DrpVendor);
                        break;

                    case (int)LoadFormType.������:
                        WHLoadDYForm(p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.�����ɹ���:
                        WHLoadFabricBuyForm(p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.Ⱦ���ӹ���:
                        WHLoadFabricProcessForm((int)EnumProcessType.Ⱦ���ӹ���, p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.�����ƻ���:  //ë�������ƻ���
                        WHLoadTowelProductionPlan(p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.ӡ���ӹ���:
                        //WHLoadPrintingProcessForm();
                        WHLoadFabricProcessForm((int)EnumProcessType.ӡ���ӹ���, p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.����֯��ӹ���:
                        WHLoadFabricProcessForm((int)EnumProcessType.֯��ӹ���, p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.�����ӹ���:
                        WHLoadFabricProcessForm((int)EnumProcessType.�����ӹ���, p_Grid, p_DrpVendor);
                        //WHLoadOtherProcessForm();
                        break;
                    case (int)LoadFormType.���ϼӹ���:
                        WHLoadFabricProcessForm((int)EnumProcessType.���ϼӹ���, p_Grid, p_DrpVendor);
                        break;
                    case (int)LoadFormType.����ָʾ��://�ƺ������ؼ���ָʾ����LoadJYForm
                        WHLoadJYForm(p_Grid);//���ؼ���ָʾ��
                        break;
                    case (int)LoadFormType.��Ʒ:
                        WHLoadProduct(p_Grid);//����
                        break;
                    case (int)LoadFormType.���Ʒ:
                        WHLoadProductBCP(p_Grid);//����
                        break;
                    case (int)LoadFormType.����:
                        WHLoadProductPB(p_Grid);//����
                        break;
                    case (int)LoadFormType.�������ϵ�:
                        WHLoadProductPBOrder(p_Grid);//����
                        break;
                    case (int)LoadFormType.����֪ͨ��:
                        WHLoadProductionNotice(p_Grid);//����
                        break;
                    case (int)LoadFormType.��Ʒ_��ɫ:
                        WHLoadProductColor(p_Grid);//����
                        break;
                }
            }
        }

        #region �������ۺ�ͬ
        /// <summary>
        /// �������ۺ�ͬ
        /// </summary>
        private void WHLoadSaleOrderForm(GridView p_Grid, LookUpEdit p_DrpVendor)
        {
            if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            {
                this.ShowMessage("��ѡ��λ");
                p_DrpVendor.Focus();
                return;
            }
            frmLoadOrder frm = new frmLoadOrder();
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.OrderID != null && frm.OrderID.Length != 0)
            {

                for (int i = 0; i < frm.OrderID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.OrderID[i]);
                }
                WHLoadSaleOrderFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }

        /// <summary>
        /// �������ۺ�ͬ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadSaleOrderFormSetWH(GridView p_Grid, LookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    p_Grid.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    //gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));
                    p_Grid.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    //gridView1.SetRowCellValue(setRowID, "JarNum", SysConvert.ToString(dt.Rows[0]["JarNum"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsInVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    //gridView1.SetRowCellValue(setRowID, "DYPrice", SysConvert.ToDecimal(dt.Rows[0]["DYPrice"]));
                    //gridView1.SetRowCellValue(setRowID, "InSO", SysConvert.ToString(dt.Rows[0]["SO"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    //switch (saveFillDataType)
                    //{
                    //    case (int)EnumFillDataType.���۳����׼�����:
                    //        gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                    //        break;
                    //    //case (int)EnumFillDataType.�������۳����׼�����:
                    //    //    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsDYFormNo"]));
                    //    //    break;
                    //}
                    p_Grid.SetRowCellValue(setRowID, "InOrderFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));//DtsOrderFormNo
                    p_Grid.SetRowCellValue(setRowID, "InSaleOPID", SysConvert.ToString(dt.Rows[0]["SaleOPID"]));

                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }

                    if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
                    }



                    p_Grid.SetRowCellValue(setRowID, "InputQty", SysConvert.ToDecimal(dt.Rows[0]["InputQty"]));
                    p_Grid.SetRowCellValue(setRowID, "InputUnit", SysConvert.ToString(dt.Rows[0]["InputUnit"]));
                    p_Grid.SetRowCellValue(setRowID, "InputSinglePrice", SysConvert.ToDecimal(dt.Rows[0]["InputSinglePrice"]));
                    p_Grid.SetRowCellValue(setRowID, "InputAmount", SysConvert.ToDecimal(dt.Rows[0]["InputAmount"]));
                    p_Grid.SetRowCellValue(setRowID, "InputConvertXS", SysConvert.ToDecimal(dt.Rows[0]["InputConvertXS"]));


                    string outsectionID, outSbitID;
                    //WHLoadFHFormSetWH(dt.Rows[0], out outsectionID, out outSbitID);

                    //p_Grid.SetRowCellValue(setRowID, "SectionID", outsectionID);
                    //p_Grid.SetRowCellValue(setRowID, "SBitID", outSbitID);
                    p_Grid.SetRowCellValue(setRowID, "LoadDtsID", SysConvert.ToString(dt.Rows[0]["DtsID"]));
                    setRowID++;
                }
            }
        }

        /// <summary>
        /// �������ۺ�ͬ
        /// </summary>
        private void WHLoadSaleOrderForm(GridView p_Grid, SearchLookUpEdit p_DrpVendor)
        {
            if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            {
                this.ShowMessage("��ѡ��λ");
                p_DrpVendor.Focus();
                return;
            }
            frmLoadOrder frm = new frmLoadOrder();
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.OrderID != null && frm.OrderID.Length != 0)
            {

                for (int i = 0; i < frm.OrderID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.OrderID[i]);
                }
                WHLoadSaleOrderFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }
        /// <summary>
        /// �������۶���
        /// </summary>
        /// <param name="p_Grid"></param>
        /// <param name="p_DrpVendor"></param>
        /// <param name="p_Str"></param>
        public void WHLoadSaleFormSetWH(GridView p_Grid, SearchLookUpEdit p_DrpVendor, int p_LoadFormType)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            {
                this.ShowMessage("��ѡ��λ");
                p_DrpVendor.Focus();
                return;
            }
            frmLoadOrder frm = new frmLoadOrder();
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            frm.NoLoadCondition = sql;

            //if (p_LoadFormType == (int)LoadFormType.��������)
            //{
            //    //frm.FAID = 0;
            //    frm.WaiGouStr = " and isnull(WaiGou,'') != '��'";
            //}
            //if (p_LoadFormType == (int)LoadFormType.��������)
            //{
            //    //frm.FAID = 1;
            //    frm.WaiGouStr = " and isnull(WaiGou,'') = '��'";
            //}
             
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.OrderID != null && frm.OrderID.Length != 0)
            {

                for (int i = 0; i < frm.OrderID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.OrderID[i]);
                }
                sql = "SELECT * FROM UV1_Sale_SaleOrderDts WHERE DtsID IN (" + str + ")";
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                        p_Grid.SetRowCellValue(setRowID, "DtsInVendorID", SysConvert.ToString(dt.Rows[i]["VendorID"]));
                        p_Grid.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToDecimal(dt.Rows[i]["SingPrice"]));
                        p_Grid.SetRowCellValue(setRowID, "LoadDtsID", SysConvert.ToString(dt.Rows[i]["DtsID"]));
                        p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[i]["FormNo"]));

                        p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                        p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[i]["ItemName"]));
                        p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[i]["ItemStd"]));
                        p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[i]["ItemModel"]));

                        p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[i]["Needle"]));
                        p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[i]["MWidth"]));
                        p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[i]["MWeight"]));
                        p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                        p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));

                        //p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToDecimal(dt.Rows[i]["InPutQty"]));
                        p_Grid.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));

                        string Unit = SysConvert.ToString(dt.Rows[i]["Unit"]);

                        if (Unit.EndsWith("M"))
                        {
                            p_Grid.SetRowCellValue(setRowID, "TotalOutQty", SysConvert.ToDecimal(dt.Rows[i]["ReceivedQty"]));
                        }
                        else if (Unit.EndsWith("KG"))
                        {
                            p_Grid.SetRowCellValue(setRowID, "TotalOutQty", SysConvert.ToDecimal(dt.Rows[i]["ReceivedWeight"]));
                        }
                        else if (Unit.EndsWith("Y"))
                        {
                            p_Grid.SetRowCellValue(setRowID, "TotalOutQty", SysConvert.ToDecimal(dt.Rows[i]["ReceivedYard"]));
                        }
                        else if (Unit.EndsWith("PC"))
                        {
                            p_Grid.SetRowCellValue(setRowID, "TotalOutQty", SysConvert.ToDecimal(dt.Rows[i]["ReceivedPieceQty"]));
                        }


                        p_Grid.SetRowCellValue(setRowID, "OrderQty", SysConvert.ToDecimal(dt.Rows[i]["InputQty"]));
                        p_Grid.SetRowCellValue(setRowID, "OrderUnit", SysConvert.ToString(dt.Rows[i]["Unit"]));

                        setRowID++;
                    }

                }




                //for (int i = 0; i < p_Grid.RowCount; i++)
                //{
                //    if (SysConvert.ToString(p_Grid.GetRowCellValue(i, "ItemCode")) != "")
                //    {
                //        foreach (DataRow dr in dt.Rows)
                //        {
                //            if (SysConvert.ToString(dr["ItemCode"]) == SysConvert.ToString(p_Grid.GetRowCellValue(i, "ItemCode")) && SysConvert.ToString(dr["ColorNum"]) == SysConvert.ToString(p_Grid.GetRowCellValue(i, "ColorNum")) && SysConvert.ToString(dr["ColorName"]) == SysConvert.ToString(p_Grid.GetRowCellValue(i, "ColorName")) && SysConvert.ToString(dr["MWidth"]) == SysConvert.ToString(p_Grid.GetRowCellValue(i, "MWidth")) && SysConvert.ToString(dr["MWeight"]) == SysConvert.ToString(p_Grid.GetRowCellValue(i, "MWeight")))
                //            {
                //                p_Grid.SetRowCellValue(i, "DtsSO", SysConvert.ToString(dr["FormNo"]));
                //                p_Grid.SetRowCellValue(i, "DtsInVendorID", SysConvert.ToString(dr["VendorID"]));
                //                p_Grid.SetRowCellValue(i, "SinglePrice", SysConvert.ToDecimal(dr["SingPrice"]));
                //                p_Grid.SetRowCellValue(i, "LoadDtsID", SysConvert.ToString(dr["DtsID"]));
                //                p_Grid.SetRowCellValue(i, "DtsOrderFormNo", SysConvert.ToString(dr["FormNo"]));
                //                p_Grid.SetRowCellValue(i, "Unit", SysConvert.ToString(dr["Unit"]));
                //            }
                //        }
                //    }
                //}


            }
        }

        /// <summary>
        /// �������۶�������
        /// </summary>
        /// <param name="p_Grid"></param>
        /// <param name="p_DrpVendor"></param>
        /// <param name="p_Str"></param>
        public void WHLoadSaleOrderFormNX(GridView p_Grid, SearchLookUpEdit p_DrpVendor, int p_LoadFormType)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            {
                this.ShowMessage("��ѡ��λ");
                p_DrpVendor.Focus();
                return;
            }
            frmLoadOrder frm = new frmLoadOrder();
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            frm.NoLoadCondition = sql;
            if (p_LoadFormType == (int)LoadFormType.��������)
            {
                frm.FAID = 0;
            }
            if (p_LoadFormType == (int)LoadFormType.��������)
            {
                frm.FAID = 1;
            }
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.OrderID != null && frm.OrderID.Length != 0)
            {

                for (int i = 0; i < frm.OrderID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.OrderID[i]);
                }
                if (str == "")
                {
                    this.ShowMessage("��ѡ������");
                    return;
                }
                sql = "SELECT * FROM UV1_Sale_SaleOrderDts WHERE DtsID IN (" + str + " )";
                DataTable dt = SysUtils.Fill(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[i]["ItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[i]["ItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[i]["ItemModel"]));

                    p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[i]["Needle"]));
                    p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[i]["MWidth"]));
                    p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[i]["MWeight"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                    setRowID++;

                }
            }
        }


        /// <summary>
        /// �������۶�������
        /// </summary>
        /// <param name="p_Grid"></param>
        /// <param name="p_DrpVendor"></param>
        /// <param name="p_Str"></param>
        public void WHLoadSaleOrderFormWX(GridView p_Grid, SearchLookUpEdit p_DrpVendor, int p_LoadFormType)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            {
                this.ShowMessage("��ѡ��λ");
                p_DrpVendor.Focus();
                return;
            }
            frmLoadOrder frm = new frmLoadOrder();
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            frm.NoLoadCondition = sql;
            if (p_LoadFormType == (int)LoadFormType.��������)
            {
                frm.FAID = 0;
            }
            if (p_LoadFormType == (int)LoadFormType.��������)
            {
                frm.FAID = 1;
            }
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.OrderID != null && frm.OrderID.Length != 0)
            {

                for (int i = 0; i < frm.OrderID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.OrderID[i]);
                }
                if (str == "")
                {
                    this.ShowMessage("��ѡ������");
                    return;
                }
                sql = "SELECT * FROM UV1_Sale_SaleOrderDts WHERE DtsID IN (" + str + " )";
                DataTable dt = SysUtils.Fill(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[i]["ItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[i]["ItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[i]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));
                    p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[i]["Needle"]));
                    p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[i]["MWidth"]));
                    p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[i]["MWeight"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                    setRowID++;

                }
            }
        }
        /// <summary>
        /// �������ۺ�ͬ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadSaleOrderFormSetWH(GridView p_Grid, SearchLookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    p_Grid.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    //gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));
                    p_Grid.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    //gridView1.SetRowCellValue(setRowID, "JarNum", SysConvert.ToString(dt.Rows[0]["JarNum"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsInVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    //gridView1.SetRowCellValue(setRowID, "DYPrice", SysConvert.ToDecimal(dt.Rows[0]["DYPrice"]));
                    //gridView1.SetRowCellValue(setRowID, "InSO", SysConvert.ToString(dt.Rows[0]["SO"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    //switch (saveFillDataType)
                    //{
                    //    case (int)EnumFillDataType.���۳����׼�����:
                    //        gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                    //        break;
                    //    //case (int)EnumFillDataType.�������۳����׼�����:
                    //    //    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsDYFormNo"]));
                    //    //    break;
                    //}
                    p_Grid.SetRowCellValue(setRowID, "InOrderFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));//DtsOrderFormNo
                    p_Grid.SetRowCellValue(setRowID, "InSaleOPID", SysConvert.ToString(dt.Rows[0]["SaleOPID"]));

                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }

                    if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
                    }



                    p_Grid.SetRowCellValue(setRowID, "InputQty", SysConvert.ToDecimal(dt.Rows[0]["InputQty"]));
                    p_Grid.SetRowCellValue(setRowID, "InputUnit", SysConvert.ToString(dt.Rows[0]["InputUnit"]));
                    p_Grid.SetRowCellValue(setRowID, "InputSinglePrice", SysConvert.ToDecimal(dt.Rows[0]["InputSinglePrice"]));
                    p_Grid.SetRowCellValue(setRowID, "InputAmount", SysConvert.ToDecimal(dt.Rows[0]["InputAmount"]));
                    p_Grid.SetRowCellValue(setRowID, "InputConvertXS", SysConvert.ToDecimal(dt.Rows[0]["InputConvertXS"]));


                    string outsectionID, outSbitID;
                    //WHLoadFHFormSetWH(dt.Rows[0], out outsectionID, out outSbitID);

                    //p_Grid.SetRowCellValue(setRowID, "SectionID", outsectionID);
                    //p_Grid.SetRowCellValue(setRowID, "SBitID", outSbitID);
                    p_Grid.SetRowCellValue(setRowID, "LoadDtsID", SysConvert.ToString(dt.Rows[0]["DtsID"]));
                    setRowID++;
                }
            }
        }
        #endregion

        #region �������ϲɹ���
        /// <summary>
        /// �������ϲɹ���
        /// </summary>
        private void WHLoadItemBuyForm(GridView p_Grid, LookUpEdit p_DrpVendor)
        {
            if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            {
                this.ShowMessage("��ѡ��λ");
                p_DrpVendor.Focus();
                return;
            }
            frmLoadItemBuy frm = new frmLoadItemBuy();
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            sql += " AND ISNULL(TotalRecQty,0)=0";
            //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(DtsSO+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WH_IOFormDts";
            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            //sql += ")";
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {

                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadItemBuyFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }
        /// <summary>
        /// �������ϲɹ���
        /// </summary>
        private void WHLoadItemBuyForm(GridView p_Grid, SearchLookUpEdit p_DrpVendor)
        {
            if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            {
                this.ShowMessage("��ѡ��λ");
                p_DrpVendor.Focus();
                return;
            }
            frmLoadItemBuy frm = new frmLoadItemBuy();
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            sql += " AND ISNULL(TotalRecQty,0)=0";
            //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(DtsSO+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WH_IOFormDts";
            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            //sql += ")";
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {

                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadItemBuyFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }
        /// <summary>
        /// �������ϲɹ�����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadItemBuyFormSetWH(GridView p_Grid, LookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Buy_ItemBuyFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    if (i == 0)
                    {
                        p_DrpVendor.EditValue = SysConvert.ToString(dt.Rows[0]["ShopID"]);
                    }

                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));//���ݺ���
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsSO"]));//������
                    p_Grid.SetRowCellValue(setRowID, "DVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));//��ͬ�ͻ�

                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));

                    p_Grid.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));

                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWeight", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWidth", DBNull.Value);
                    }


                    if (SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", DBNull.Value);
                    }

                    p_Grid.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsLevel", "");
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    p_Grid.SetRowCellValue(setRowID, "MLType", SysConvert.ToInt32(dt.Rows[0]["MLType"]));
                    //if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
                    //}

                    setRowID++;
                }
            }
        }
        /// <summary>
        /// �������ϲɹ�����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadItemBuyFormSetWH(GridView p_Grid, SearchLookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Buy_ItemBuyFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    if (i == 0)
                    {
                        p_DrpVendor.EditValue = SysConvert.ToString(dt.Rows[0]["ShopID"]);
                    }

                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));//���ݺ���
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsSO"]));//������
                    p_Grid.SetRowCellValue(setRowID, "DVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));//��ͬ�ͻ�

                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));

                    p_Grid.SetRowCellValue(setRowID, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["OrderQty"]));
                    p_Grid.SetRowCellValue(setRowID, "OrderUnit", SysConvert.ToString(dt.Rows[0]["OrderUnit"]));

                    p_Grid.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));

                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWeight", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWidth", DBNull.Value);
                    }


                    if (SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", DBNull.Value);
                    }

                    p_Grid.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsLevel", "");
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    p_Grid.SetRowCellValue(setRowID, "MLType", SysConvert.ToInt32(dt.Rows[0]["MLType"]));
                    //if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
                    //}

                    setRowID++;
                }
            }
        }
        #endregion

        #region ����ɴ�߲ɹ���
        /// <summary>
        /// ����ɴ�߲ɹ���
        /// </summary>
        private void WHLoadYarnBuyForm(GridView p_Grid, LookUpEdit p_DrpVendor)
        {
            //if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            //{
            //    this.ShowMessage("��ѡ��" + p_DrpVendor.ToolTip.ToString());
            //    p_DrpVendor.Focus();
            //    return;
            //}
            frmLoadItemBuy frm = new frmLoadItemBuy();
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            //sql += " AND ISNULL(TotalRecQty,0)<>0";
            //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(DtsSO+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WH_IOFormDts";
            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            //sql += ")";
            frm.LoadType = (int)EnumMLType.ɴ��;
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {

                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadYarnBuyFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }

        /// <summary>
        /// ����ɴ�߲ɹ�����ϸ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadYarnBuyFormSetWH(GridView p_Grid, LookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Buy_ItemBuyFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    if (i == 0)
                    {
                        p_DrpVendor.EditValue = SysConvert.ToString(dt.Rows[0]["ShopID"]);
                    }
                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                    p_Grid.SetRowCellValue(setRowID, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    p_Grid.SetRowCellValue(setRowID, "VendorBatch", SysConvert.ToString(dt.Rows[0]["VendorBatch"]));
                    p_Grid.SetRowCellValue(setRowID, "YarnType", SysConvert.ToString(dt.Rows[0]["YarnType"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));

                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsSO"]));
                    p_Grid.SetRowCellValue(setRowID, "DVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));//��ͬ�ͻ�

                    p_Grid.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));
                    //gridView1.SetRowCellValue(setRowID, "GoodsLevel", "");
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    p_Grid.SetRowCellValue(setRowID, "MLType", SysConvert.ToString(dt.Rows[0]["MLType"]));
                    if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
                    }

                    setRowID++;
                }
            }
        }

        /// <summary>
        /// ����ɴ�߲ɹ���
        /// </summary>
        private void WHLoadYarnBuyForm(GridView p_Grid, SearchLookUpEdit p_DrpVendor)
        {
            //if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            //{
            //    this.ShowMessage("��ѡ��" + p_DrpVendor.ToolTip.ToString());
            //    p_DrpVendor.Focus();
            //    return;
            //}
            frmLoadItemBuy frm = new frmLoadItemBuy();
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            //sql += " AND ISNULL(TotalRecQty,0)<>0";
            //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(DtsSO+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WH_IOFormDts";
            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            //sql += ")";
            frm.LoadType = (int)EnumMLType.ɴ��;
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {

                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadYarnBuyFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }

        /// <summary>
        /// ����ɴ�߲ɹ�����ϸ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadYarnBuyFormSetWH(GridView p_Grid, SearchLookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Buy_ItemBuyFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    if (i == 0)
                    {
                        p_DrpVendor.EditValue = SysConvert.ToString(dt.Rows[0]["ShopID"]);
                    }
                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                    p_Grid.SetRowCellValue(setRowID, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    p_Grid.SetRowCellValue(setRowID, "VendorBatch", SysConvert.ToString(dt.Rows[0]["VendorBatch"]));
                    p_Grid.SetRowCellValue(setRowID, "YarnType", SysConvert.ToString(dt.Rows[0]["YarnType"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));

                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsSO"]));
                    p_Grid.SetRowCellValue(setRowID, "DVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));//��ͬ�ͻ�

                    p_Grid.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));
                    //gridView1.SetRowCellValue(setRowID, "GoodsLevel", "");
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    p_Grid.SetRowCellValue(setRowID, "MLType", SysConvert.ToString(dt.Rows[0]["MLType"]));
                    if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
                    }

                    setRowID++;
                }
            }
        }
        #endregion

        #region ���ϲɹ���
        /// <summary>
        /// 
        /// </summary>
        private void WHLoadFLBuyForm(GridView p_Grid, LookUpEdit p_DrpVendor)
        {
            if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            {
                this.ShowMessage("��ѡ��" + p_DrpVendor.ToolTip.ToString());
                p_DrpVendor.Focus();
                return;
            }
            frmLoadItemBuy frm = new frmLoadItemBuy();
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            sql += " AND ISNULL(TotalRecQty,0)=0";
            frm.NoLoadCondition = sql;
            frm.LoadType = (int)EnumMLType.����;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {

                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadItemBuyFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void WHLoadFLBuyForm(GridView p_Grid, SearchLookUpEdit p_DrpVendor)
        {
            if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            {
                this.ShowMessage("��ѡ��" + p_DrpVendor.ToolTip.ToString());
                p_DrpVendor.Focus();
                return;
            }
            frmLoadItemBuy frm = new frmLoadItemBuy();
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            sql += " AND ISNULL(TotalRecQty,0)=0";
            frm.NoLoadCondition = sql;
            frm.LoadType = (int)EnumMLType.����;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {

                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadItemBuyFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }
        #endregion

        #region ���ز�Ʒ
        /// <summary>
        /// ���ز�Ʒ
        /// </summary>
        void WHLoadProduct(GridView p_Grid)
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
                setItemNews(p_Grid, str);
            }
        }

        private void setItemNews(GridView p_Grid, string str)
        {
            string[] gbid = str.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    //if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    //{
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    //}
                    //else
                    //{
                    //    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWidth", DBNull.Value);
                    //}
                    //if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    //{
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    //}
                    //else
                    //{
                    //    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWeight", DBNull.Value);
                    //}
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));

                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));

                }
            }
        }
        #endregion

        #region ���ذ��Ʒ
        /// <summary>
        /// ���ز�Ʒ
        /// </summary>
        void WHLoadProductBCP(GridView p_Grid)
        {
            frmLoadFabric frm = new frmLoadFabric();
            frm.HTItemTypeID = (int)EnumItemType.���Ʒ;
            //frm.HTItemTypeIDA = new int[] { (int)EnumItemType.���Ʒ };

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
                setItemNewsBCP(p_Grid, str);
            }
        }

        private void setItemNewsBCP(GridView p_Grid, string str)
        {
            string[] gbid = str.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    //if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    //{
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    //}
                    //else
                    //{
                    //    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWidth", DBNull.Value);
                    //}
                    //if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    //{
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    //}
                    //else
                    //{
                    //    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWeight", DBNull.Value);
                    //}
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));

                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));

                }
            }
        }
        #endregion

        #region ���ز�Ʒ����ɫ��
        /// <summary>
        /// ���ز�Ʒ����ɫ��
        /// </summary>
        void WHLoadProductColor(GridView p_Grid)
        {
            frmLoadFabricColor frm = new frmLoadFabricColor();
            frm.ShowDialog();
            string str = string.Empty;
            string seq = string.Empty;
            if (frm.GBID != null && frm.GBID.Length != 0)
            {
                for (int i = 0; i < frm.GBID.Length; i++)
                {
                    string gb = frm.GBID[i].ToString();
                    string[] gbs = gb.Split(',');
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(gbs[0]);
                    if (seq != string.Empty)
                    {
                        seq += ",";
                    }
                    seq += SysConvert.ToString(SysConvert.ToInt32(gbs[1]));
                }
                setItemNewsColor(p_Grid, str, seq);
            }
        }

        private void setItemNewsColor(GridView p_Grid, string str, string seq)
        {
            string[] gbid = str.Split(',');
            string[] gbseq = seq.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Data_ItemColorDts WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                sql += " AND ISNULL(Seq,0)=" + SysString.ToDBString(gbseq[i]);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    //if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    //{
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    //}
                    //else
                    //{
                    //    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWidth", DBNull.Value);
                    //}
                    //if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    //{
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));

                    //}
                    //else
                    //{
                    //    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWeight", DBNull.Value);
                    //}
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    //p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));

                    //p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));

                }
            }
        }
        #endregion
        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        void WHLoadProductPB(GridView p_Grid)
        {
            frmLoadFabric frm = new frmLoadFabric();
            frm.HTItemTypeID = (int)EnumItemType.����;
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
                setItemNewsPB(p_Grid, str);
            }
        }

        private void setItemNewsPB(GridView p_Grid, string str)
        {
            string[] gbid = str.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    {
                        p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWidth", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    {
                        p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWeight", DBNull.Value);
                    }

                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));

                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                }
            }
        }
        #endregion

        #region ���ؼ���ָʾ��
        /// <summary>
        /// ����ָʾ��
        /// </summary>
        void WHLoadJYForm(GridView p_Grid)
        {
            frmLoadJYForm frm = new frmLoadJYForm();
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.JYFormID != null && frm.JYFormID.Length != 0)
            {

                for (int i = 0; i < frm.JYFormID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.JYFormID[i]);
                }
                setItemNewsJY(p_Grid, str);
            }
        }

        private void setItemNewsJY(GridView p_Grid, string str)
        {
            string[] gbid = str.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WO_PackOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));//���ݵ���
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["CompactNo"]));//��ͬ��
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWidth", SysConvert.ToString(dt.Rows[0]["CWidth"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "MWeight", SysConvert.ToString(dt.Rows[0]["CWeight"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));//�ܶ�
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["ShopAttn"]));
                }
            }
        }
        #endregion
        #region �����������ϵ�
        /// <summary>
        /// ��������
        /// </summary>
        void WHLoadProductPBOrder(GridView p_Grid)
        {
            frmLoadSlaeOrderFabric frm = new frmLoadSlaeOrderFabric();
            frm.NoLoadCondition = " AND FormNo+ItemCode NOT IN (SELECT ISNULL(DtsSO+ItemCode,'') FROM UV1_Buy_ItemBuyFormDts)";
            frm.BuyFlag = true;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemID != null && frm.ItemID.Length != 0)
            {
                //SetGridView1();// ��ֹһ���ɹ�������������ͬ������
                for (int i = 0; i < frm.ItemID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemID[i]);
                }
                setItemNewsPBOrder(p_Grid, str);
            }
        }

        private void setItemNewsPBOrder(GridView p_Grid, string str)
        {
            string[] arr = str.Split(',');
            int index = p_Grid.FocusedRowHandle;//checkRowSet();
            int length = 0;
            for (int i = index; i < arr.Length + index; i++)
            {
                string sql = "SELECT * FROM UV1_Sale_SaleOrderTFabric WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count > 0)
                {
                    p_Grid.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));

                    p_Grid.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));//����
                    //p_Grid.SetRowCellValue(i, "FreeStr1", SysConvert.ToString(dt.Rows[0]["FreeStr1"]));//������

                    p_Grid.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(i, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    p_Grid.SetRowCellValue(i, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    p_Grid.SetRowCellValue(i, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    p_Grid.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));

                    string[] itemInfo = Common.GetItemArrayByCode(SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    if (itemInfo.Length >= 6)
                    {
                        if (itemInfo[4] != string.Empty)
                        {
                            p_Grid.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(itemInfo[4]));
                        }

                        if (itemInfo[5] != string.Empty)
                        {
                            p_Grid.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(itemInfo[5]));
                        }
                    }

                    p_Grid.SetRowCellValue(i, "CPItemCode", SysConvert.ToString(dt.Rows[0]["CPItemCode"]));
                    p_Grid.SetRowCellValue(i, "CPItemName", SysConvert.ToString(dt.Rows[0]["CPItemName"]));
                    p_Grid.SetRowCellValue(i, "CPItemModel", SysConvert.ToString(dt.Rows[0]["CPItemModel"]));
                    p_Grid.SetRowCellValue(i, "CPItemStd", SysConvert.ToString(dt.Rows[0]["CPItemStd"]));

                }
                length++;
            }
        }
        #endregion

        #region ���ؼӹ���
        /// <summary>
        /// ���ؼӹ���
        /// </summary>
        private void WHLoadFabricProcessForm(int p_ProcessTypeID, GridView p_Grid, LookUpEdit p_DrpVendor)
        {
            if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            {
                this.ShowMessage("��ѡ��" + p_DrpVendor.ToolTip.ToString());
                p_DrpVendor.Focus();
                return;
            }
            frmLoadWOProcess frm = new frmLoadWOProcess();
            frm.ProcessTypeID = p_ProcessTypeID;// (int)EnumProcessType.Ⱦ���ӹ���;
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {
                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadFabricProcessFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }

        /// <summary>
        /// ����Ⱦ���ӹ�����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadFabricProcessFormSetWH(GridView p_Grid, LookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WO_FabricProcessDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {

                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));//���ݵ���
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsSO"]));//���۶�����
                    p_Grid.SetRowCellValue(setRowID, "DVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));//���ۿͻ�

                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToDecimal(dt.Rows[0]["SingPrice"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));

                    p_Grid.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));

                    p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                    p_Grid.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }

                    p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));

                    p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));

                    if (SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", DBNull.Value);
                    }

                    setRowID++;
                }
            }
        }

        /// <summary>
        /// ���ؼӹ���
        /// </summary>
        private void WHLoadFabricProcessForm(int p_ProcessTypeID, GridView p_Grid, SearchLookUpEdit p_DrpVendor)
        {
            if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            {
                this.ShowMessage("��ѡ��" + p_DrpVendor.ToolTip.ToString());
                p_DrpVendor.Focus();
                return;
            }
            frmLoadWOProcess frm = new frmLoadWOProcess();
            frm.ProcessTypeID = p_ProcessTypeID;// (int)EnumProcessType.Ⱦ���ӹ���;
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            sql = " and FormNo+BCPItemCode+ColorNum not in (select isnull(DtsSO+ItemCode+ColorNum,'') from UV1_WH_IOFormDts )";
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {
                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadFabricProcessFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }

        /// <summary>
        /// ����Ⱦ���ӹ�����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadFabricProcessFormSetWH(GridView p_Grid, SearchLookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WO_FabricProcessDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {

                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));//���ݵ���
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsSO"]));//���۶�����
                    p_Grid.SetRowCellValue(setRowID, "DVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));//���ۿͻ�

                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["BCPItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["BCPItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["BCPItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["BCPItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToDecimal(dt.Rows[0]["SingPrice"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));

                    p_Grid.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));

                    p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    p_Grid.SetRowCellValue(setRowID, "OrderUnit", SysConvert.ToString(dt.Rows[0]["OrderUnit"]));
                    p_Grid.SetRowCellValue(setRowID, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["OrderQty"]));

                    p_Grid.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    //if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    //{
                    //    p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    //}

                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")  //֯��ӹ��� �������� ΪQty
                    {
                        p_Grid.SetRowCellValue(setRowID, "Weight", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    }

                    p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));

                    p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));

                    if (SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", DBNull.Value);
                    }

                    p_Grid.SetRowCellValue(setRowID, "LoadPieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    p_Grid.SetRowCellValue(setRowID, "LoadQty", SysConvert.ToInt32(dt.Rows[0]["Qty"]));
                    p_Grid.SetRowCellValue(setRowID, "LoadWeight", SysConvert.ToInt32(dt.Rows[0]["PieceWeight"]));

                    p_Grid.SetRowCellValue(setRowID, "OrderQty", SysConvert.ToString(dt.Rows[0]["OrderQty"]));
                    p_Grid.SetRowCellValue(setRowID, "OrderUnit", SysConvert.ToString(dt.Rows[0]["OrderUnit"]));


                    setRowID++;
                }
            }
        }
        #endregion




        /// <summary>
        /// ���ؼƻ���
        /// </summary>
        private void WHLoadTowelProductionPlan(GridView p_Grid, SearchLookUpEdit p_DrpVendor)
        {
            if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            {
                this.ShowMessage("��ѡ��" + p_DrpVendor.ToolTip.ToString());
                p_DrpVendor.Focus();
                return;
            }
            frmLoadTowelProductionPlan frm = new frmLoadTowelProductionPlan();
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            sql = " and DtsID not in (select isnull(LoadDtsID,0) from UV1_WH_IOFormDts  )";
            frm.NoLoadCondition = sql;
            sql = "";
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {
                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadTowelProductionPlan(p_Grid, p_DrpVendor, str);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadTowelProductionPlan(GridView p_Grid, SearchLookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WO_TowelProductionPlanDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    p_Grid.SetRowCellValue(setRowID, "LoadDtsID", SysConvert.ToInt32(dt.Rows[0]["DtsID"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));//���ݵ���
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsSO"]));//���۶�����
                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));

                    if (SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", DBNull.Value);
                    }
                    p_Grid.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }

                    p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));

                    p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));


                    p_Grid.SetRowCellValue(setRowID, "LLQty", SysConvert.ToDecimal(dt.Rows[0]["LLQty"]));
                    p_Grid.SetRowCellValue(setRowID, "LLUnit", SysConvert.ToString(dt.Rows[0]["LLUnit"]));

                    //p_Grid.SetRowCellValue(setRowID, "DVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));//���ۿͻ�
                    //p_Grid.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToDecimal(dt.Rows[0]["SingPrice"]));
                    //p_Grid.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    //p_Grid.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));

                    //p_Grid.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));

                    //p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    //p_Grid.SetRowCellValue(setRowID, "OrderUnit", SysConvert.ToString(dt.Rows[0]["OrderUnit"]));
                    //p_Grid.SetRowCellValue(setRowID, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["OrderQty"]));

                    //p_Grid.SetRowCellValue(setRowID, "LoadPieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    //p_Grid.SetRowCellValue(setRowID, "LoadQty", SysConvert.ToInt32(dt.Rows[0]["Qty"]));
                    //p_Grid.SetRowCellValue(setRowID, "LoadWeight", SysConvert.ToInt32(dt.Rows[0]["PieceWeight"]));




                    setRowID++;
                }
            }
        }




        #region ���س���ⵥ
        /// <summary>
        /// ���س���ⵥ
        /// </summary>
        private void WHLoadWHIOForm(GridView p_Grid, LookUpEdit p_DrpVendor)
        {
            frmLoadIOForm frm = new frmLoadIOForm();
            //frm.THConditionStr = saveTHLoadFormListIDStr;
            if (SysConvert.ToString(p_DrpVendor.EditValue) != "")
            {
                frm.HTLoadConditionStr = " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(p_DrpVendor.EditValue));
            }
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.DtsID != null && frm.DtsID.Length != 0)
            {

                for (int i = 0; i < frm.DtsID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.DtsID[i]);
                }
                WHLoadWHIOFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }

        private void WHLoadWHIOForm(GridView p_Grid, SearchLookUpEdit p_DrpVendor)
        {
            frmLoadIOForm frm = new frmLoadIOForm();
            //frm.THConditionStr = saveTHLoadFormListIDStr;
            if (SysConvert.ToString(p_DrpVendor.EditValue) != "")
            {
                frm.HTLoadConditionStr = " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(p_DrpVendor.EditValue));
            }
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.DtsID != null && frm.DtsID.Length != 0)
            {

                for (int i = 0; i < frm.DtsID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.DtsID[i]);
                }
                WHLoadWHIOFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }
        /// <summary>
        /// ���س���ⵥ��Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadWHIOFormSetWH(GridView p_Grid, LookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WH_IOFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    if (i == 0)
                    {
                        p_DrpVendor.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                    }

                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["DtsSO"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                    p_Grid.SetRowCellValue(setRowID, "DVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));

                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));

                    p_Grid.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["DLCode"]));
                    p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    p_Grid.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["DtsVendorID"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["Weight"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Weight", SysConvert.ToString(dt.Rows[0]["Weight"]));
                    }
                    p_Grid.SetRowCellValue(setRowID, "MLType", SysConvert.ToInt32(dt.Rows[0]["MLType"]));
                    setRowID++;
                }
            }
        }
        private void WHLoadWHIOFormSetWH(GridView p_Grid, SearchLookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WH_IOFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    if (i == 0)
                    {
                        p_DrpVendor.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                    }

                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["DtsSO"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                    p_Grid.SetRowCellValue(setRowID, "DVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));

                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));

                    p_Grid.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["DLCode"]));
                    p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    p_Grid.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["DtsVendorID"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["Weight"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Weight", SysConvert.ToString(dt.Rows[0]["Weight"]));
                    }
                    p_Grid.SetRowCellValue(setRowID, "MLType", SysConvert.ToInt32(dt.Rows[0]["MLType"]));
                    setRowID++;
                }
            }
        }
        #endregion

        #region ���ص�����
        /// <summary>
        /// ���ص�����
        /// </summary>
        private void WHLoadDYForm(GridView p_Grid, LookUpEdit p_DrpVendor)
        {
            frmLoadDY frm = new frmLoadDY();
            frm.VendorID2 = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            sql += " AND FormNo NOT IN(SELECT DtsSO FROM UV1_WH_IOFormDts";
            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            sql += " AND SubmitFlag=1";
            sql += " AND DtsSO<>''";
            sql += ")";
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.DYID != null && frm.DYID.Length != 0)
            {

                for (int i = 0; i < frm.DYID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.DYID[i]);
                }
                WHLoadDYFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }

        /// <summary>
        /// ���ص�������Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadDYFormSetWH(GridView p_Grid, LookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_DYGL WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    if (i == 0)
                    {
                        p_DrpVendor.EditValue = SysConvert.ToString(dt.Rows[0]["ShopID"]);
                    }
                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    //gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    //gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    //gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    //gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));
                    p_Grid.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                    p_Grid.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWeight", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWidth", DBNull.Value);
                    }
                    p_Grid.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsLevel", "");
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    //if (SysConvert.ToString(dt.Rows[0]["SinglePrice"]) != "")
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SinglePrice"]));
                    //}
                    setRowID++;
                }
            }
        }
        private void WHLoadDYForm(GridView p_Grid, SearchLookUpEdit p_DrpVendor)
        {
            frmLoadDY frm = new frmLoadDY();
            frm.VendorID2 = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            sql += " AND FormNo NOT IN(SELECT DtsSO FROM UV1_WH_IOFormDts";
            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            sql += " AND SubmitFlag=1";
            sql += " AND DtsSO<>''";
            sql += ")";
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.DYID != null && frm.DYID.Length != 0)
            {

                for (int i = 0; i < frm.DYID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.DYID[i]);
                }
                WHLoadDYFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }

        /// <summary>
        /// ���ص�������Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadDYFormSetWH(GridView p_Grid, SearchLookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_DYGL WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    if (i == 0)
                    {
                        p_DrpVendor.EditValue = SysConvert.ToString(dt.Rows[0]["ShopID"]);
                    }
                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    //gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    //gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    //gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    //gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));
                    p_Grid.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                    p_Grid.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWeight", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWidth", DBNull.Value);
                    }
                    p_Grid.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsLevel", "");
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    //if (SysConvert.ToString(dt.Rows[0]["SinglePrice"]) != "")
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SinglePrice"]));
                    //}
                    setRowID++;
                }
            }
        }
        #endregion

        #region ���������ɹ���
        /// <summary>
        /// ���������ɹ���
        /// </summary>
        private void WHLoadFabricBuyForm(GridView p_Grid, LookUpEdit p_DrpVendor)
        {
            if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            {
                this.ShowMessage("��ѡ��" + p_DrpVendor.ToolTip.ToString());
                p_DrpVendor.Focus();
                return;
            }
            frmLoadItemBuy frm = new frmLoadItemBuy();
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            //sql += " AND ISNULL(TotalRecQty,0)<>0";
            //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(DtsSO+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WH_IOFormDts";
            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            //sql += ")";
            frm.LoadType = (int)EnumMLType.����;
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {

                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadFabricBuyFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }

        /// <summary>
        /// ���������ɹ�����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadFabricBuyFormSetWH(GridView p_Grid, LookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Buy_ItemBuyFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    if (i == 0)
                    {
                        p_DrpVendor.EditValue = SysConvert.ToString(dt.Rows[0]["ShopID"]);
                    }

                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsSO"]));
                    p_Grid.SetRowCellValue(setRowID, "DVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));

                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));

                    p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    p_Grid.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));

                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWeight", DBNull.Value);
                    }

                    if (SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWidth", DBNull.Value);
                    }
                    p_Grid.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    p_Grid.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsLevel", "");
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    p_Grid.SetRowCellValue(setRowID, "MLType", SysConvert.ToInt32(dt.Rows[0]["MLType"]));
                    if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
                        p_Grid.SetRowCellValue(setRowID, "Amount", SysConvert.ToString(dt.Rows[0]["Amount"]));
                    }

                    setRowID++;
                }
            }
        }
        /// <summary>
        /// ���������ɹ���
        /// </summary>
        private void WHLoadFabricBuyForm(GridView p_Grid, SearchLookUpEdit p_DrpVendor)
        {
            if (SysConvert.ToString(p_DrpVendor.EditValue) == "")
            {
                this.ShowMessage("��ѡ��" + p_DrpVendor.ToolTip.ToString());
                p_DrpVendor.Focus();
                return;
            }
            frmLoadItemBuy frm = new frmLoadItemBuy();
            frm.VendorID = SysConvert.ToString(p_DrpVendor.EditValue);
            string sql = string.Empty;
            //sql += " AND ISNULL(TotalRecQty,0)<>0";
            //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(DtsSO+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WH_IOFormDts";
            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            //sql += ")";

            sql += " and FormNo+ItemCode not in (select isnull(DtsSO+ItemCode,'') from UV1_WH_IOFormDts )";

            frm.LoadType = (int)EnumMLType.����;
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {

                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadFabricBuyFormSetWH(p_Grid, p_DrpVendor, str);

            }
        }

        /// <summary>
        /// ���������ɹ�����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadFabricBuyFormSetWH(GridView p_Grid, SearchLookUpEdit p_DrpVendor, string p_Str)
        {
            int setRowID = p_Grid.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Buy_ItemBuyFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    if (i == 0)
                    {
                        p_DrpVendor.EditValue = SysConvert.ToString(dt.Rows[0]["ShopID"]);
                    }

                    p_Grid.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsSO"]));
                    p_Grid.SetRowCellValue(setRowID, "DVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));

                    p_Grid.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    p_Grid.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    p_Grid.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));

                    p_Grid.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    p_Grid.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));

                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWeight", DBNull.Value);
                    }

                    p_Grid.SetRowCellValue(setRowID, "LoadQty", SysConvert.ToInt32(dt.Rows[0]["Qty"]));
                    p_Grid.SetRowCellValue(setRowID, "LoadPieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    p_Grid.SetRowCellValue(setRowID, "LoadWeight", SysConvert.ToInt32(dt.Rows[0]["Weight"]));


                    if (SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "PieceQty", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        p_Grid.SetRowCellValue(setRowID, "MWidth", DBNull.Value);
                    }
                    p_Grid.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    p_Grid.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    p_Grid.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));
                    p_Grid.SetRowCellValue(setRowID, "GoodsLevel", "");
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    p_Grid.SetRowCellValue(setRowID, "MLType", SysConvert.ToInt32(dt.Rows[0]["MLType"]));
                    if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                    {
                        p_Grid.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
                        p_Grid.SetRowCellValue(setRowID, "Amount", SysConvert.ToString(dt.Rows[0]["Amount"]));
                    }

                    p_Grid.SetRowCellValue(setRowID, "TotalInQty", SysConvert.ToDecimal(dt.Rows[0]["TotalRecQty"]));

                    setRowID++;
                }
            }
        }
        #endregion

        #region ��������֪ͨ��
        /// <summary>
        /// ��������֪ͨ��
        /// </summary>
        void WHLoadProductionNotice(GridView p_Grid)
        {
            frmLoadProductionNotice frm = new frmLoadProductionNotice();
            frm.ShowDialog();
            if (frm.StorgeID != null)
            {
                int RowHandle = p_Grid.FocusedRowHandle;
                for (int i = 0; i < frm.StorgeID.Length; i++)
                {
                    int LaodID = SysConvert.ToInt32(frm.StorgeID[i]);
                    string sql = "SELECT * FROM UV1_Sale_ProductionNoticeDts WHERE DtsID=" + SysString.ToDBString(LaodID);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        p_Grid.SetRowCellValue(RowHandle + i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                        p_Grid.SetRowCellValue(RowHandle + i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                        p_Grid.SetRowCellValue(RowHandle + i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                        p_Grid.SetRowCellValue(RowHandle + i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                        if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) > 0)
                        {
                            p_Grid.SetRowCellValue(RowHandle + i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                        }
                        else
                        {
                            p_Grid.SetRowCellValue(RowHandle + i, "MWidth", DBNull.Value);
                        }
                        if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) > 0)
                        {
                            p_Grid.SetRowCellValue(RowHandle + i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                        }
                        else
                        {
                            p_Grid.SetRowCellValue(RowHandle + i, "MWeight", DBNull.Value);
                        }
                        p_Grid.SetRowCellValue(RowHandle + i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));

                        //p_Grid.SetRowCellValue(i, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                        p_Grid.SetRowCellValue(i, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["SO"]));
                        p_Grid.SetRowCellValue(i, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));

                    }
                }
            }
        }


        #endregion
        #endregion

        #region ���ؿ��
        public void LoadStorge()
        {
            try
            {
                frmStorgeLoad frm = new frmStorgeLoad();
                frm.FormListAID = this.FormListAID;
                frm.ShowDialog();
                string str = string.Empty;
                if (frm.StorgeID != null && frm.StorgeID.Length != 0)
                {

                    for (int i = 0; i < frm.StorgeID.Length; i++)
                    {
                        if (str != string.Empty)
                        {
                            str += ",";
                        }
                        str += SysConvert.ToString(frm.StorgeID[i]);
                    }
                }
                //int index = 0;
                int index = this.HTDataDts.FocusedRowHandle;
                //for (int i = 0; i < this.HTDataDts.RowCount; i++)
                //{
                //    if (SysConvert.ToString(this.HTDataDts.GetRowCellValue(i, "ItemCode")) != string.Empty)
                //    {
                //        index = i + 1;
                //    }
                //}
                string[] itembuyid = str.Split(',');
                for (int i = 0; i < itembuyid.Length; i++)
                {
                    string sql = "SELECT * FROM  UV1_WH_Storge WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count == 1)
                    {
                        this.HTDataDts.SetRowCellValue(index, "WHID", SysConvert.ToString(dt.Rows[0]["WHID"]));
                        this.HTDataDts.SetRowCellValue(index, "SectionID", SysConvert.ToString(dt.Rows[0]["SectionID"]));
                        this.HTDataDts.SetRowCellValue(index, "SBitID", SysConvert.ToString(dt.Rows[0]["SBitID"]));
                        this.HTDataDts.SetRowCellValue(index, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                        this.HTDataDts.SetRowCellValue(index, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                        this.HTDataDts.SetRowCellValue(index, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                        this.HTDataDts.SetRowCellValue(index, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                        this.HTDataDts.SetRowCellValue(index, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                        this.HTDataDts.SetRowCellValue(index, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                        this.HTDataDts.SetRowCellValue(index, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                        this.HTDataDts.SetRowCellValue(index, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));

                        this.HTDataDts.SetRowCellValue(index, "JarNum", SysConvert.ToString(dt.Rows[0]["JarNum"]));

                        this.HTDataDts.SetRowCellValue(index, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                        this.HTDataDts.SetRowCellValue(index, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                        this.HTDataDts.SetRowCellValue(index, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                        this.HTDataDts.SetRowCellValue(index, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                        this.HTDataDts.SetRowCellValue(index, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                        this.HTDataDts.SetRowCellValue(index, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                        this.HTDataDts.SetRowCellValue(index, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                        this.HTDataDts.SetRowCellValue(index, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));
                        this.HTDataDts.SetRowCellValue(index, "PieceQty", SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]));
                        this.HTDataDts.SetRowCellValue(index, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                        if (SysConvert.ToString(dt.Rows[0]["Unit"]) == "")
                        {
                            this.HTDataDts.SetRowCellValue(index, "Unit", "RMB/M");
                        }
                        else
                        {
                            this.HTDataDts.SetRowCellValue(index, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                        }
                        this.HTDataDts.SetRowCellValue(index, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                        this.HTDataDts.SetRowCellValue(index, "Weight", SysConvert.ToDecimal(dt.Rows[0]["Weight"]));
                        this.HTDataDts.SetRowCellValue(index, "Yard", SysConvert.ToDecimal(dt.Rows[0]["Yard"]));
                        this.HTDataDts.SetRowCellValue(index, "VendorBatch", SysConvert.ToString(dt.Rows[0]["VendorBatch"]));
                        this.HTDataDts.SetRowCellValue(index, "DtsInVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                        this.HTDataDts.SetRowCellValue(index, "InSO", SysConvert.ToString(dt.Rows[0]["SO"]));
                        this.HTDataDts.SetRowCellValue(index, "InOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));
                        //this.HTDataDts.SetRowCellValue(index, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));
                        this.HTDataDts.SetRowCellValue(index, "InSaleOPID", SysConvert.ToString(dt.Rows[0]["DutyOPID"]));
                        //index++;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
        #region ����ԭ��
        /// <summary>
        /// ����ԭ��
        /// </summary>
        void WHLoadProductYL(GridView p_Grid)
        {
            frmLoadYarnItem frm = new frmLoadYarnItem();
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.IdDts != null && frm.IdDts.Length != 0)
            {
                for (int i = 0; i < frm.IdDts.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.IdDts[i]);
                }
                setItemNewsYL(p_Grid, str);

            }
        }


        private void setItemNewsYL(GridView p_Grid, string str)
        {
            string[] gbid = str.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    p_Grid.SetRowCellValue(p_Grid.FocusedRowHandle + i, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));

                }
            }
        }
        #endregion
    }
}