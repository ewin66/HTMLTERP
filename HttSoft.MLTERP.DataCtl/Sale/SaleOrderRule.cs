using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;
using HttSoft.FrameFunc;


namespace HttSoft.MLTERP.DataCtl
{
    /// <summary>
    /// Ŀ�ģ�Sale_SaleOrderʵ��ҵ�������
    /// ����:�¼Ӻ�
    /// ��������:2012-4-17
    /// </summary>
    public class SaleOrderRule
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public SaleOrderRule()
        {
        }

        /// <summary>
        /// ��齫Ҫ�����������Ƿ����ҵ�����
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            SaleOrder entity = (SaleOrder)p_BE;
        }


        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShow(string p_condition)
        {
            try
            {
                return RShow(p_condition, "*");
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShow(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM Sale_SaleOrder WHERE 1=1";
                sql += p_condition;
                return SysUtils.Fill(sql);
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }
        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShow2(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV2_Sale_SaleOrder WHERE 1=1";
                sql += p_condition;
                return SysUtils.Fill(sql);
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }
        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="p_condition"></param>
        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShowDts(string p_condition)
        {
            try
            {
                return RShowDts(p_condition, "*");
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShowDts(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_Sale_SaleOrderDts WHERE 1=1";
                sql += p_condition;
                sql += " ORDER BY MakeDate DESC ";
                return SysUtils.Fill(sql);
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }
        #region �ύ����
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="p_FormID">����ID</param>
        /// <param name="p_Type">0/1:����/���</param>
        public void RSubmit(int p_FormID, int p_Type, int p_WinFormID, int p_FormListAID, int p_FormListBID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSubmit(p_FormID, p_Type, p_WinFormID, p_FormListAID, p_FormListBID, sqlTrans);
                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="p_FormID">����ID</param>
        /// <param name="p_Type">0/1/2/3:����/���</param>
        public void RSubmit(int p_FormID, int p_Type, int p_WinFormID, int p_FormListAID, int p_FormListBID, IDBTransAccess sqlTrans)
        {
            try
            {
                int p_TempType = p_Type;//����״̬
                string sql = string.Empty;
                SaleOrder entity = new SaleOrder(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//�����ͬ�쳣
                {
                    throw new Exception("����״̬�ظ����ã���رճ������´򿪲���");
                }

                if (p_Type == (int)ConfirmFlag.δ�ύ)//�����ύ��֤
                {
                    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5409)))//���۶����вɹ����ӹ������������ֿⵥ�ݲ������޸�
                    {
                        bool allowOPFlag = true;
                        string refuseMessage = string.Empty;
                        DataTable dtSOFlow;
                        if (allowOPFlag)
                        {
                            //�ɹ����̵���
                            sql = "SELECT TOP 1 ID,FormNo FROM UV1_Buy_ItemBuyFormDts WHERE DtsSO=" + SysString.ToDBString(entity.FormNo);
                            dtSOFlow = SysUtils.Fill(sql);
                            if (dtSOFlow.Rows.Count != 0)
                            {
                                allowOPFlag = false;
                                refuseMessage = "�˵����вɹ���(����):" + dtSOFlow.Rows[0]["FormNo"].ToString() + "����������";
                            }
                        }
                        if (allowOPFlag)
                        {
                            //�ӹ����̵���
                            sql = "SELECT TOP 1 ID,FormNo  FROM UV1_WO_FabricProcessDts WHERE DtsSO=" + SysString.ToDBString(entity.FormNo);
                            dtSOFlow = SysUtils.Fill(sql);
                            if (dtSOFlow.Rows.Count != 0)
                            {
                                allowOPFlag = false;
                                refuseMessage = "�˵����мӹ���(����):" + dtSOFlow.Rows[0]["FormNo"].ToString() + "����������";
                            }
                        }

                        if (!allowOPFlag)//���������
                        {
                            throw new Exception(refuseMessage);
                        }
                    }


                }

                sql = "UPDATE Sale_SaleOrder SET SubmitFlag=" + SysString.ToDBString(p_Type);

                sql += " WHERE ID=" + p_FormID.ToString();//���µ����������״̬
                sqlTrans.ExecuteNonQuery(sql);


                //WinListFillDateTypeRule wfdrule = new WinListFillDateTypeRule();
                //int[] fillDataTypeID ;
                //wfdrule.RGetFillDataType(p_WinFormID, p_FormListAID, p_FormListBID, out fillDataTypeID);
                //for (int i = 0; i < fillDataTypeID.Length; i++)
                //{
                //    switch (fillDataTypeID[i])
                //    {
                //        case (int)EnumFillDataType.���۶����Ƶ���׼�������������:
                //            sql = "SELECT ItemCode,ColorNum,SUM(Qty) Qty FROM Sale_SaleOrderDts WHERE MainID=" + p_FormID + " GROUP BY ItemCode,ColorNum";
                //            DataTable dtDts = sqlTrans.Fill(sql);
                //            break;
                //    }
                //}


                if (p_Type == (int)ConfirmFlag.���ύ || p_Type == (int)ConfirmFlag.���ͨ��)
                {
                    sql = "SELECT SO,ItemCode,ItemName,ItemStd,ItemModel,ColorName,SUM(Qty) Qty,MAX(Unit) Unit,Needle,MWeight,MWidth FROM Sale_SaleOrderFabric WHERE MainID=" + SysString.ToDBString(p_FormID);
                    sql += " GROUP BY SO,ItemCode,ItemName,ItemStd,ItemModel,ColorName,Needle,MWeight,MWidth";
                    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5009)))//���ϵ��������ÿ��滻��������,Ӱ�쵽�����������ϡ������ɹ���֯���
                    {
                        sql = "SELECT SO,ItemCode,ItemName,ItemStd,ItemModel,CPItemCode,MAX(CPItemName) CPItemName,MAX(CPItemStd) CPItemStd,MAX(CPItemModel) CPItemModel,ColorName,SUM(Qty) Qty,MAX(Unit) Unit,Needle,MWeight,MWidth FROM Sale_SaleOrderFabric WHERE MainID=" + SysString.ToDBString(p_FormID);
                        sql += " GROUP BY SO,ItemCode,ItemName,ItemStd,ItemModel,CPItemCode,ColorName,Needle,MWeight,MWidth";
                    }
                    DataTable dt = sqlTrans.Fill(sql);
                    SaleOrderTFabricRule ruleF = new SaleOrderTFabricRule();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SaleOrderTFabric entityF = new SaleOrderTFabric();
                        entityF.MainID = p_FormID;
                        entityF.Seq = i + 1;
                        if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5009)))//���ϵ��������ÿ��滻��������,Ӱ�쵽�����������ϡ������ɹ���֯���
                        {
                            entityF.CPItemCode = SysConvert.ToString(dt.Rows[i]["CPItemCode"]);
                            entityF.CPItemName = SysConvert.ToString(dt.Rows[i]["CPItemName"]);
                            entityF.CPItemStd = SysConvert.ToString(dt.Rows[i]["CPItemStd"]);
                            entityF.CPItemModel = SysConvert.ToString(dt.Rows[i]["CPItemModel"]);
                        }
                        entityF.ItemCode = SysConvert.ToString(dt.Rows[i]["ItemCode"]);
                        entityF.ItemName = SysConvert.ToString(dt.Rows[i]["ItemName"]);
                        entityF.ItemStd = SysConvert.ToString(dt.Rows[i]["ItemStd"]);
                        entityF.ItemModel = SysConvert.ToString(dt.Rows[i]["ItemModel"]);
                        entityF.ColorName = SysConvert.ToString(dt.Rows[i]["ColorName"]);
                        entityF.SO = SysConvert.ToString(dt.Rows[i]["SO"]);
                        entityF.Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                        entityF.Unit = SysConvert.ToString(dt.Rows[i]["Unit"]);
                        entityF.MWidth = SysConvert.ToDecimal(dt.Rows[i]["MWidth"]);
                        entityF.MWeight = SysConvert.ToDecimal(dt.Rows[i]["MWeight"]);
                        entityF.Needle = SysConvert.ToString(dt.Rows[i]["Needle"]);
                        ruleF.RAdd(entityF, sqlTrans);
                    }


                    sql = "SELECT MAX(ComTypeID) ComTypeID,SO,ItemCode,ItemName,ItemStd,ItemModel,ColorName,SUM(Qty) Qty,MAX(Unit) Unit FROM Sale_SaleOrderFabricCompSite WHERE MainID=" + SysString.ToDBString(p_FormID);
                    sql += " GROUP BY SO,ItemCode,ItemName,ItemStd,ItemModel,ColorName";
                    dt = sqlTrans.Fill(sql);
                    SaleOrderTFabricCompSiteRule ruleFC = new SaleOrderTFabricCompSiteRule();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SaleOrderTFabricCompSite entityF = new SaleOrderTFabricCompSite();
                        entityF.MainID = p_FormID;
                        entityF.Seq = i + 1;
                        entityF.ComTypeID = SysConvert.ToInt32(dt.Rows[i]["ComTypeID"]);
                        entityF.ItemCode = SysConvert.ToString(dt.Rows[i]["ItemCode"]);
                        entityF.ItemName = SysConvert.ToString(dt.Rows[i]["ItemName"]);
                        entityF.ItemStd = SysConvert.ToString(dt.Rows[i]["ItemStd"]);
                        entityF.ItemModel = SysConvert.ToString(dt.Rows[i]["ItemModel"]);
                        entityF.ColorName = SysConvert.ToString(dt.Rows[i]["ColorName"]);
                        entityF.SO = SysConvert.ToString(dt.Rows[i]["SO"]);
                        entityF.Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                        entityF.Unit = SysConvert.ToString(dt.Rows[i]["Unit"]);
                        ruleFC.RAdd(entityF, sqlTrans);
                    }



                    sql = "SELECT SO,ItemCode,ItemName,ItemStd,ItemModel,SUM(Qty) Qty,MAX(Unit) Unit FROM Sale_SaleOrderItem WHERE MainID=" + SysString.ToDBString(p_FormID);
                    sql += " AND BuyType=" + SysString.ToDBString((int)EnumBuyType.��ɴ�ɹ�);
                    sql += " GROUP BY SO,ItemCode,ItemName,ItemStd,ItemModel";
                    dt = sqlTrans.Fill(sql);
                    SaleOrderTItemRule ruleI = new SaleOrderTItemRule();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SaleOrderTItem entityI = new SaleOrderTItem();
                        entityI.MainID = p_FormID;
                        entityI.Seq = i + 1;
                        entityI.ItemCode = SysConvert.ToString(dt.Rows[i]["ItemCode"]);
                        entityI.ItemName = SysConvert.ToString(dt.Rows[i]["ItemName"]);
                        entityI.ItemStd = SysConvert.ToString(dt.Rows[i]["ItemStd"]);
                        entityI.ItemModel = SysConvert.ToString(dt.Rows[i]["ItemModel"]);
                        //entityI.ColorName = SysConvert.ToString(dt.Rows[i]["ColorName"]);
                        entityI.SO = SysConvert.ToString(dt.Rows[i]["SO"]);
                        entityI.Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                        entityI.Unit = SysConvert.ToString(dt.Rows[i]["Unit"]);
                        ruleI.RAdd(entityI, sqlTrans);
                    }

                    sql = "SELECT SO,ItemCode,ItemName,ItemStd,ItemModel,ColorName,SUM(Qty) Qty,MAX(Unit) Unit FROM Sale_SaleOrderItem WHERE MainID=" + SysString.ToDBString(p_FormID);
                    sql += " AND BuyType=" + SysString.ToDBString((int)EnumBuyType.ɫɴ�ɹ�);
                    sql += " GROUP BY SO,ItemCode,ItemName,ItemStd,ItemModel,ColorName";
                    dt = sqlTrans.Fill(sql);
                    SaleOrderTItemRule ruleI2 = new SaleOrderTItemRule();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SaleOrderTItem entityI2 = new SaleOrderTItem();
                        entityI2.MainID = p_FormID;
                        entityI2.Seq = i + 1;
                        entityI2.ItemCode = SysConvert.ToString(dt.Rows[i]["ItemCode"]);
                        entityI2.ItemName = SysConvert.ToString(dt.Rows[i]["ItemName"]);
                        entityI2.ItemStd = SysConvert.ToString(dt.Rows[i]["ItemStd"]);
                        entityI2.ItemModel = SysConvert.ToString(dt.Rows[i]["ItemModel"]);
                        entityI2.ColorName = SysConvert.ToString(dt.Rows[i]["ColorName"]);
                        entityI2.SO = SysConvert.ToString(dt.Rows[i]["SO"]);
                        entityI2.Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                        entityI2.Unit = SysConvert.ToString(dt.Rows[i]["Unit"]);
                        ruleI2.RAdd(entityI2, sqlTrans);
                    }

                    sql = "SELECT SO,ItemCode,ItemName,ItemStd,ItemModel,ColorName,SUM(Qty) Qty,MAX(Unit) Unit FROM Sale_SaleOrderItem WHERE MainID=" + SysString.ToDBString(p_FormID);
                    sql += " AND BuyType=" + SysString.ToDBString((int)EnumBuyType.��ɴ�ɹ�);
                    sql += " AND ISNULL(SH2,0)>0";
                    sql += " GROUP BY SO,ItemCode,ItemName,ItemStd,ItemModel,ColorName";
                    dt = sqlTrans.Fill(sql);
                    SaleOrderTColorItemRule ruleS = new SaleOrderTColorItemRule();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SaleOrderTColorItem entityS = new SaleOrderTColorItem();
                        entityS.MainID = p_FormID;
                        entityS.Seq = i + 1;
                        entityS.ItemCode = SysConvert.ToString(dt.Rows[i]["ItemCode"]);
                        entityS.ItemName = SysConvert.ToString(dt.Rows[i]["ItemName"]);
                        entityS.ItemStd = SysConvert.ToString(dt.Rows[i]["ItemStd"]);
                        entityS.ItemModel = SysConvert.ToString(dt.Rows[i]["ItemModel"]);
                        entityS.ColorName = SysConvert.ToString(dt.Rows[i]["ColorName"]);
                        entityS.SO = SysConvert.ToString(dt.Rows[i]["SO"]);
                        entityS.Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                        entityS.Unit = SysConvert.ToString(dt.Rows[i]["Unit"]);
                        ruleS.RAdd(entityS, sqlTrans);
                    }
                }
                else if (p_Type == (int)ConfirmFlag.δ�ύ)
                {
                    sql = "DELETE Sale_SaleOrderTItem WHERE MainID=" + SysString.ToDBString(p_FormID);
                    sqlTrans.ExecuteNonQuery(sql);

                    sql = "DELETE Sale_SaleOrderTFabric WHERE MainID=" + SysString.ToDBString(p_FormID);
                    sqlTrans.ExecuteNonQuery(sql);

                    sql = "DELETE Sale_SaleOrderTColorItem WHERE MainID=" + SysString.ToDBString(p_FormID);
                    sqlTrans.ExecuteNonQuery(sql);

                    sql = "DELETE Sale_SaleOrderTFabricCompSite WHERE MainID=" + SysString.ToDBString(p_FormID);
                    sqlTrans.ExecuteNonQuery(sql);
                }


            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        #endregion

        #region ���۶�������ͬ�����ɹ�������
        /// <summary>
        /// ����Ƿ���Ҫͬ�� ���۶�������ͬ�����ɹ�������
        /// </summary>
        /// <param name="p_FormID"></param>
        public bool RSameDataToBuyCheck(int p_FormID)
        {
            ParamSetRule psrule = new ParamSetRule();

            if (psrule.RShowIntByID((int)ParamSetEnum.�������ݱ��ͬ�����ɹ�����) == (int)YesOrNo.Yes)//ͬ����־Ϊ ��
            {
                SaleOrder entity = new SaleOrder();
                entity.ID = p_FormID;
                entity.SelectByID();

                string sql = string.Empty;
                sql = "SELECT ID,ShopID FROM Buy_ItemBuyForm WHERE OrderFormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dtBuyMain = SysUtils.Fill(sql);//�ɹ�������

                if (dtBuyMain.Rows.Count != 0)//��Ҫͬ��
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ���۶�������ͬ�����ɹ�������
        /// </summary>
        /// <param name="p_FormID">����ID</param>
        /// <param name="p_Type">0/1:����/���</param>
        public void RSameDataToBuy(int p_FormID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();
                    SaleOrder entity = new SaleOrder(sqlTrans);
                    entity.ID = p_FormID;
                    entity.SelectByID();
                    //this.RSameDataToBuy(entity, sqlTrans);����ͬ��
                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// ���۶�������ͬ�����ɹ�������
        /// </summary>
        /// <param name="p_FormID"></param>
        public void RSameDataToBuy(SaleOrder entity, IDBTransAccess sqlTrans)
        {
            ParamSetRule psrule = new ParamSetRule();
            if (psrule.RShowIntByID((int)ParamSetEnum.�������ݱ��ͬ�����ɹ�����) == (int)YesOrNo.Yes)//ͬ����־Ϊ ��
            {
                string sql = string.Empty;
                sql = "SELECT ID,ShopID FROM Buy_ItemBuyForm WHERE OrderFormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dtBuyMain = sqlTrans.Fill(sql);//�ɹ�������

                sql = "SELECT A.*,B.VendorID ItemShopID FROM Sale_SaleOrderDts A,Data_Item B WHERE  A.ItemCode=B.ItemCode AND A.MainID=" + entity.ID;
                DataTable dtSaleOrderDts = sqlTrans.Fill(sql);//���۶���������ϸ

                bool findSameRecord = false;
                for (int i = 0; i < dtBuyMain.Rows.Count; i++)
                {
                    DataRow[] drA = dtSaleOrderDts.Select(" ItemShopID=" + SysString.ToDBString(dtBuyMain.Rows[i]["ShopID"].ToString()));//ѡ�񶩵��ó����µĶ�����ϸ����

                    sql = "SELECT * FROM Buy_ItemBuyFormDts WHERE MainID=" + SysString.ToDBString(dtBuyMain.Rows[i]["ID"].ToString());
                    DataTable dtBuyDts = sqlTrans.Fill(sql);//�ɹ���������ϸ

                    //STEP 2��ʼ����ɹ�����ϸ����
                    for (int bi = dtBuyDts.Rows.Count - 1; bi >= 0; bi--)//���вɹ�����ϸ�Ͷ�����ϸ�Ա�
                    {
                        findSameRecord = false;
                        for (int si = 0; si < drA.Length; si++)
                        {
                            if (SysConvert.ToInt32(dtBuyDts.Rows[bi]["DLoadID"]) > 0)
                            {
                                if (drA[si]["ID"].ToString() == dtBuyDts.Rows[bi]["DLoadID"].ToString())//�ҵ���ͬ��Ʒ��ͬ���������
                                {
                                    RSameDataToBuyCopyOne(drA[si], dtBuyDts.Rows[bi], entity.FormNo, entity.VendorID);
                                    findSameRecord = true;
                                    break;
                                }
                            }
                            else
                            {

                                if (drA[si]["ItemCode"].ToString() == dtBuyDts.Rows[bi]["ItemCode"].ToString()
                                    && drA[si]["ColorNum"].ToString() == dtBuyDts.Rows[bi]["ColorNum"].ToString())//�ҵ���ͬ��Ʒ��ͬ���������
                                {
                                    RSameDataToBuyCopyOne(drA[si], dtBuyDts.Rows[bi], entity.FormNo, entity.VendorID);
                                    findSameRecord = true;
                                    break;
                                }
                            }
                        }
                        if (!findSameRecord)//û���ҵ�ͬ�����������Ƴ�
                        {
                            dtBuyDts.Rows.Remove(dtBuyDts.Rows[bi]);
                        }
                    }

                    for (int si = 0; si < drA.Length; si++) //���ж�����ϸ�Ͳɹ�����ϸ�Ա�
                    {
                        findSameRecord = false;
                        for (int bi = dtBuyDts.Rows.Count - 1; bi >= 0; bi--)
                        {
                            if (SysConvert.ToInt32(dtBuyDts.Rows[bi]["DLoadID"]) > 0)
                            {
                                if (drA[si]["ID"].ToString() == dtBuyDts.Rows[bi]["DLoadID"].ToString())//�ҵ���ͬ��Ʒ��ͬ���������
                                {
                                    findSameRecord = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (drA[si]["ItemCode"].ToString() == dtBuyDts.Rows[bi]["ItemCode"].ToString()
                                    && drA[si]["ColorNum"].ToString() == dtBuyDts.Rows[bi]["ColorNum"].ToString())//�ҵ���ͬ��Ʒ��ͬ���������
                                {
                                    findSameRecord = true;
                                    break;
                                }
                            }
                        }
                        if (!findSameRecord)//û���ҵ�ͬ�����������������
                        {
                            DataRow drBuy = dtBuyDts.NewRow();
                            RSameDataToBuyCopyOne(drA[si], drBuy, entity.FormNo, entity.VendorID);
                            dtBuyDts.Rows.Add(drBuy);
                        }
                    }
                    //��������ɹ�����ϸ����


                    //STEP 3 ����������
                    ItemBuyFormRule buyrule = new ItemBuyFormRule();
                    ItemBuyForm buyentity = RSameDataToBuyEntityGet(SysConvert.ToInt32(dtBuyMain.Rows[i]["ID"]), sqlTrans);
                    ItemBuyFormDts[] buyentitydts = RSameDataToBuyEntityDtsGet(SysConvert.ToInt32(dtBuyMain.Rows[i]["ID"]), dtBuyDts, sqlTrans);
                    decimal totalqty = 0;
                    decimal totalAmount = 0;
                    for (int lasti = 0; lasti < buyentitydts.Length; lasti++)
                    {
                        totalqty += SysConvert.ToDecimal(buyentitydts[lasti].Qty);
                        totalAmount += SysConvert.ToDecimal(buyentitydts[lasti].Amount);
                    }
                    buyentity.TotalQty = totalqty;
                    buyentity.TotalAmount = totalAmount;
                    buyrule.RUpdate(buyentity, buyentitydts, sqlTrans);

                    //STEP 4 ��������
                }

                sql = "SELECT ItemCode FROM UV1_Buy_ItemBuyFormDts WHERE OrderFormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    if (SysConvert.ToString(dt.Rows[0]["ItemCode"]) == "")
                    {
                        throw new BaseException("���뷢���������������ύ��");
                    }
                }

            }
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ItemBuyForm RSameDataToBuyEntityGet(int p_BuyID, IDBTransAccess sqlTrans)
        {
            ItemBuyForm entity = new ItemBuyForm(sqlTrans);
            entity.ID = p_BuyID;
            entity.SelectByID();
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ItemBuyFormDts[] RSameDataToBuyEntityDtsGet(int p_BuyID, DataTable dtBuyDts, IDBTransAccess sqlTrans)
        {

            int index = dtBuyDts.Rows.Count;
            ItemBuyFormDts[] entitydts = new ItemBuyFormDts[index];
            for (int i = 0; i < index; i++)
            {
                entitydts[i] = new ItemBuyFormDts(sqlTrans);
                entitydts[i].ID = SysConvert.ToInt32(dtBuyDts.Rows[i]["ID"]);
                entitydts[i].SelectByID();
                entitydts[i].MainID = p_BuyID;
                entitydts[i].Seq = i + 1;

                entitydts[i].ItemCode = SysConvert.ToString(dtBuyDts.Rows[i]["ItemCode"]);
                entitydts[i].GoodsCode = SysConvert.ToString(dtBuyDts.Rows[i]["GoodsCode"]);
                entitydts[i].ColorNum = SysConvert.ToString(dtBuyDts.Rows[i]["ColorNum"]);
                entitydts[i].ColorName = SysConvert.ToString(dtBuyDts.Rows[i]["ColorName"]);
                entitydts[i].MWidth = SysConvert.ToString(dtBuyDts.Rows[i]["MWidth"]);
                entitydts[i].MWeight = SysConvert.ToString(dtBuyDts.Rows[i]["MWeight"]);
                entitydts[i].WeightUnit = SysConvert.ToString(dtBuyDts.Rows[i]["WeightUnit"]);
                entitydts[i].ItemName = SysConvert.ToString(dtBuyDts.Rows[i]["ItemName"]);
                entitydts[i].VColorNum = SysConvert.ToString(dtBuyDts.Rows[i]["VColorNum"]);
                entitydts[i].VColorName = SysConvert.ToString(dtBuyDts.Rows[i]["VColorName"]);
                entitydts[i].VItemCode = SysConvert.ToString(dtBuyDts.Rows[i]["VItemCode"]);
                entitydts[i].Qty = SysConvert.ToDecimal(dtBuyDts.Rows[i]["Qty"]);
                entitydts[i].Unit = SysConvert.ToString(dtBuyDts.Rows[i]["Unit"]);
                entitydts[i].SingPrice = SysConvert.ToDecimal(dtBuyDts.Rows[i]["SingPrice"]);
                entitydts[i].Amount = entitydts[i].Qty * entitydts[i].SingPrice;
                entitydts[i].DVendorID = SysConvert.ToString(dtBuyDts.Rows[i]["DVendorID"]);
                entitydts[i].DtsSO = SysConvert.ToString(dtBuyDts.Rows[i]["DtsSO"]);
                entitydts[i].DLoadID = SysConvert.ToInt32(dtBuyDts.Rows[i]["DLoadID"]);


            }
            return entitydts;
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="drSale"></param>
        /// <param name="drBuy"></param>
        void RSameDataToBuyCopyOne(DataRow drSale, DataRow drBuy, string p_SaleFormNo, string p_VendorID)
        {
            drBuy["ItemCode"] = drSale["ItemCode"];
            drBuy["GoodsCode"] = drSale["GoodsCode"];
            drBuy["ColorNum"] = drSale["ColorNum"];
            drBuy["ColorName"] = drSale["ColorName"];
            drBuy["MWidth"] = drSale["MWidth"];
            drBuy["MWeight"] = drSale["MWeight"];
            drBuy["WeightUnit"] = drSale["WeightUnit"];
            drBuy["ItemName"] = drSale["ItemName"];
            drBuy["VColorNum"] = drSale["VColorNum"];
            drBuy["VColorName"] = drSale["VColorName"];
            drBuy["VItemCode"] = drSale["VItemCode"];
            drBuy["Qty"] = drSale["Qty"];
            drBuy["Unit"] = drSale["Unit"];
            drBuy["DtsSO"] = p_SaleFormNo;
            drBuy["DVendorID"] = p_VendorID;
            drBuy["SingPrice"] = drBuy["SingPrice"];
            drBuy["DLoadID"] = drSale["ID"];
        }
        #endregion

        #region ���۶����Ƶ���׼�������������
        /// <summary>
        /// ���۶����Ƶ���׼�������������
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataXSDDDY(SaleOrder entity, DataTable dtDts, int p_Type, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;

            for (int i = 0; i < dtDts.Rows.Count; i++)//ѭ��������ʷ
            {
                sql = "SELECT TOP 1 ID,Qty FROM Sale_DYGL WHERE VendorID=" + SysString.ToDBString(entity.VendorID);
                sql += " AND ItemCode=" + SysString.ToDBString(dtDts.Rows[i]["ItemCode"].ToString());
                sql += " AND ColorNum=" + SysString.ToDBString(dtDts.Rows[i]["ColorNum"].ToString());
                sql += " ORDER BY ID FormDate DESC ";
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {


                        sql = "UPDATE Sale_DYGL SET ";
                        sql += " LSaleOrderDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",SaleOrderCount=ISNULL(SaleOrderCount,0)+1";
                        sql += ",SaleOrderQty=ISNULL(SaleOrderQty,0)+" + SysString.ToDBString(SysConvert.ToDecimal(dtDts.Rows[i]["Qty"]));
                        sql += " WHERE ID=" + dtData.Rows[0]["ID"].ToString();
                    }
                    else//�����ύ
                    {


                        sql = "UPDATE Sale_DYGL SET ";
                        sql += " LSaleOrderDate=NULL";
                        sql += ",SaleOrderCount=ISNULL(SaleOrderCount,0)-1";
                        sql += ",SaleOrderQty=ISNULL(SaleOrderQty,0)-" + SysString.ToDBString(SysConvert.ToDecimal(dtDts.Rows[i]["Qty"]));
                        sql += " WHERE ID=" + dtData.Rows[0]["ID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {

                }
            }
        }
        #endregion

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(BaseEntity p_BE)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, sqlTrans);

                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// ����(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RAdd(BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                SaleOrder entity = (SaleOrder)p_BE;
                SaleOrderCtl control = new SaleOrderCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Sale_SaleOrder, sqlTrans);
                control.AddNew(entity);
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        public void RUpdate(BaseEntity p_BE)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, sqlTrans);

                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RUpdate(BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                SaleOrder entity = (SaleOrder)p_BE;
                SaleOrderCtl control = new SaleOrderCtl(sqlTrans);
                control.Update(entity);
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="p_BE">Ҫɾ����ʵ��</param>
        public void RDelete(BaseEntity p_BE)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RDelete(p_BE, sqlTrans);

                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="p_BE">Ҫɾ����ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RDelete(BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                SaleOrder entity = (SaleOrder)p_BE;
                SaleOrderCtl control = new SaleOrderCtl(sqlTrans);
                control.Delete(entity);
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        #region ��������
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2, p_BE3, sqlTrans);

                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// ����(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                SaleOrder entity = (SaleOrder)p_BE;
                string sql = "SELECT FormNo FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("�������Ѵ��ڣ�����������");
                }
                SaleOrderCtl control = new SaleOrderCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Sale_SaleOrder, sqlTrans);
                control.AddNew(entity);
                string unit = "";
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    SaleOrderDtsRule rule = new SaleOrderDtsRule();
                    SaleOrderDts entityDts = (SaleOrderDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    if (unit == "" && entityDts.Unit != "")
                    {
                        unit = entityDts.Unit;
                    }
                    if (entityDts.Unit == "")
                    {
                        entityDts.Unit = unit;
                    }
                    rule.RAdd(entityDts, sqlTrans);
                }

                SaleOrderProcedureDtsRule procedureRule = new SaleOrderProcedureDtsRule();
                procedureRule.RSave(entity, p_BE3, sqlTrans);//����������ϸ


                FormNoControlRule rulest = new FormNoControlRule();
                //rulest.RAddSort((int)FormNoControlEnum.��ͬ��,sqlTrans);
                rulest.RAddSort("Sale_SaleOrder", "FormNo", 0, sqlTrans);




                SaleOrderCapDtsRule capRule = new SaleOrderCapDtsRule();
                capRule.RSaveSaleCap(entity, sqlTrans);//�����ʽ�ƻ���ϸ

                DeleteFabricSL(entity, sqlTrans);
                DeleteItemSL(entity, sqlTrans);


                if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5412)))//���۶��������Զ�����
                {
                    sql = "SELECT ID FROM Sale_SaleOrderDts WHERE MainID=" + SysString.ToDBString(entity.ID);
                    dt = sqlTrans.Fill(sql);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int ID = SysConvert.ToInt32(dt.Rows[i][0]);

                        sql = "SELECT * FROM Sale_SaleOrderFabric WHERE Mainid=" + SysString.ToDBString(ID);
                        sql += " AND 1=0";
                        DataTable dtF = sqlTrans.Fill(sql);

                        SaleOrderDts entityMain = new SaleOrderDts(sqlTrans);
                        entityMain.ID = ID;
                        entityMain.SelectByID();
                        sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel,ItemUnit FROM Data_Item WHERE ItemCode IN (SELECT GreyFabItemCode FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(entityMain.ItemCode) + ")";
                        DataTable dto = SysUtils.Fill(sql);
                        if (dto.Rows.Count == 0)
                        {
                            throw new BaseException("��ά����Ʒ���϶�Ӧ���������ϣ�");
                        }
                        for (int j = 0; j < dto.Rows.Count; j++)
                        {
                            DataRow dr = dtF.NewRow();
                            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5009)))//���ϵ��������ÿ��滻��������,Ӱ�쵽�����������ϡ������ɹ���֯���
                            {
                                dr["CPItemCode"] = entityMain.ItemCode;
                                dr["CPItemName"] = entityMain.ItemName;
                                dr["CPItemStd"] = entityMain.ItemStd;
                                dr["CPItemModel"] = entityMain.ItemModel;
                            }

                            dr["ItemCode"] = SysConvert.ToString(dto.Rows[j]["ItemCode"]);
                            dr["ItemName"] = SysConvert.ToString(dto.Rows[j]["ItemName"]);
                            dr["ItemStd"] = SysConvert.ToString(dto.Rows[j]["ItemStd"]);
                            //dr["ColorName"] = entitydts.ColorName;����������ɫ
                            dr["ItemModel"] = SysConvert.ToString(dto.Rows[j]["ItemModel"]);
                            dr["SQty"] = entityMain.Qty;
                            dr["RQty"] = entityMain.Qty;
                            dr["Unit"] = SysConvert.ToString(dto.Rows[j]["ItemUnit"]); //"KG";
                            dr["SO"] = entity.FormNo;
                            dr["DID"] = ID;
                            dtF.Rows.Add(dr);
                        }

                        SaleOrderFabricRule Srule = new SaleOrderFabricRule();
                        SaleOrderFabric[] entityFabric = GetEntityDts(dtF);
                        Srule.RUpdate(entity.ID, ID, entityFabric, sqlTrans);
                    }




                }

            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }


        private SaleOrderFabric[] GetEntityDts(DataTable p_dt)
        {
            int Index = 0;
            int Row = 0;
            for (int i = 0; i < p_dt.Rows.Count; i++)
            {
                if (SysConvert.ToString(p_dt.Rows[i]["ItemCode"]) != "")
                {
                    Index++;
                }
            }
            SaleOrderFabric[] entity = new SaleOrderFabric[Index];
            Index = 0;
            for (int i = 0; i < p_dt.Rows.Count; i++)
            {
                Row = i + 1;
                if (SysConvert.ToString(p_dt.Rows[i]["ItemCode"]) != "")
                {

                    entity[Index] = new SaleOrderFabric();
                    entity[Index].CPItemCode = SysConvert.ToString(p_dt.Rows[i]["CPItemCode"]);
                    entity[Index].CPItemModel = SysConvert.ToString(p_dt.Rows[i]["CPItemModel"]);
                    entity[Index].CPItemName = SysConvert.ToString(p_dt.Rows[i]["CPItemName"]);
                    entity[Index].CPItemStd = SysConvert.ToString(p_dt.Rows[i]["CPItemStd"]);

                    entity[Index].ItemCode = SysConvert.ToString(p_dt.Rows[i]["ItemCode"]);
                    entity[Index].ItemModel = SysConvert.ToString(p_dt.Rows[i]["ItemModel"]);
                    entity[Index].ItemName = SysConvert.ToString(p_dt.Rows[i]["ItemName"]);
                    entity[Index].ItemStd = SysConvert.ToString(p_dt.Rows[i]["ItemStd"]);
                    entity[Index].ColorName = SysConvert.ToString(p_dt.Rows[i]["ColorName"]);
                    entity[Index].Unit = SysConvert.ToString(p_dt.Rows[i]["Unit"]);
                    entity[Index].BL = SysConvert.ToDecimal(p_dt.Rows[i]["BL"]);
                    entity[Index].SH = SysConvert.ToDecimal(p_dt.Rows[i]["SH"]);
                    entity[Index].SQty = SysConvert.ToDecimal(p_dt.Rows[i]["SQty"]);
                    entity[Index].Qty = SysConvert.ToDecimal(p_dt.Rows[i]["Qty"]);

                    if (entity[Index].BL > 0)
                    {
                        entity[Index].Qty = entity[Index].Qty * entity[Index].BL;
                        entity[Index].RQty = entity[Index].SQty * entity[Index].BL;
                    }
                    else
                    {
                        entity[Index].RQty = entity[Index].SQty;
                    }
                    entity[Index].SO = SysConvert.ToString(p_dt.Rows[i]["SO"]);
                    entity[Index].DID = SysConvert.ToInt32(p_dt.Rows[i]["DID"]);
                    Index++;

                }
            }

            return entity;

        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2, p_BE3, sqlTrans);

                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                SaleOrder entity = (SaleOrder)p_BE;
                SaleOrderCtl control = new SaleOrderCtl(sqlTrans);
                control.Update(entity);


                SaleOrderDtsRule rule = new SaleOrderDtsRule();
                rule.RSave(entity, p_BE2, sqlTrans);
                //string sql = "DELETE Sale_SaleOrderDts WHERE MainID="+SysString.ToDBString(entity.ID);
                //sqlTrans.ExecuteNonQuery(sql);
                //for (int i = 0; i < p_BE2.Length; i++)
                //{
                //    SaleOrderDtsRule rule = new SaleOrderDtsRule();
                //    SaleOrderDts entityDts = (SaleOrderDts)p_BE2[i];
                //    entityDts.MainID = entity.ID;
                //    entityDts.Seq = i + 1;
                //    rule.RAdd(entityDts, sqlTrans);
                //}


                SaleOrderProcedureDtsRule procedureRule = new SaleOrderProcedureDtsRule();
                procedureRule.RSave(entity, p_BE3, sqlTrans);//����������ϸ

                SaleOrderCapDtsRule capRule = new SaleOrderCapDtsRule();
                capRule.RSaveSaleCap(entity, sqlTrans);//�����ʽ�ƻ���ϸ

                DeleteFabricSL(entity, sqlTrans);

                DeleteItemSL(entity, sqlTrans);

                if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5412)))//���۶��������Զ�����
                {
                    string sql = "SELECT ID FROM Sale_SaleOrderDts WHERE MainID=" + SysString.ToDBString(entity.ID);
                    DataTable dt = sqlTrans.Fill(sql);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int ID = SysConvert.ToInt32(dt.Rows[i][0]);

                        sql = "SELECT * FROM Sale_SaleOrderFabric WHERE Mainid=" + SysString.ToDBString(ID);
                        sql += " AND 1=0";
                        DataTable dtF = sqlTrans.Fill(sql);

                        SaleOrderDts entityMain = new SaleOrderDts(sqlTrans);
                        entityMain.ID = ID;
                        entityMain.SelectByID();
                        sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel,ItemUnit FROM Data_Item WHERE ItemCode IN (SELECT GreyFabItemCode FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(entityMain.ItemCode) + ")";
                        DataTable dto = SysUtils.Fill(sql);
                        if (dto.Rows.Count == 0)
                        {
                            throw new BaseException("��ά����Ʒ���϶�Ӧ���������ϣ�");
                        }
                        for (int j = 0; j < dto.Rows.Count; j++)
                        {
                            DataRow dr = dtF.NewRow();
                            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5009)))//���ϵ��������ÿ��滻��������,Ӱ�쵽�����������ϡ������ɹ���֯���
                            {
                                dr["CPItemCode"] = entityMain.ItemCode;
                                dr["CPItemName"] = entityMain.ItemName;
                                dr["CPItemStd"] = entityMain.ItemStd;
                                dr["CPItemModel"] = entityMain.ItemModel;
                            }

                            dr["ItemCode"] = SysConvert.ToString(dto.Rows[j]["ItemCode"]);
                            dr["ItemName"] = SysConvert.ToString(dto.Rows[j]["ItemName"]);
                            dr["ItemStd"] = SysConvert.ToString(dto.Rows[j]["ItemStd"]);
                            //dr["ColorName"] = entitydts.ColorName;����������ɫ
                            dr["ItemModel"] = SysConvert.ToString(dto.Rows[j]["ItemModel"]);
                            dr["SQty"] = entityMain.Qty;
                            dr["RQty"] = entityMain.Qty;
                            dr["Unit"] = SysConvert.ToString(dto.Rows[j]["ItemUnit"]); //"KG";
                            dr["SO"] = entity.FormNo;
                            dr["DID"] = ID;
                            dtF.Rows.Add(dr);
                        }

                        SaleOrderFabricRule Srule = new SaleOrderFabricRule();
                        SaleOrderFabric[] entityFabric = GetEntityDts(dtF);
                        Srule.RUpdate(entity.ID, ID, entityFabric, sqlTrans);
                    }




                }

            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }
        #endregion


        #region ״̬����
        /// <summary>
        /// վ��״̬����(����������)
        /// </summary>
        /// <param name="p_OrderNo">��ͬ��</param>
        /// <param name="p_ColorNum">ɫ��</param>
        /// <param name="p_ColorName">ɫ��</param>
        /// <param name="p_SaleProcedureID">ҵ�����̱�ID</param>
        /// <param name="p_FormListID">�ֿⵥ������ID</param>
        /// <param name="p_CWStepID">����վ���ͣ��ݲ�ʹ��</param>
        /// <param name="p_OrderStepID">����վ:һ�㲻ȥʹ��</param>
        /// <param name="p_OPType">��������:1/0:�ύ/�����ύ</param>
        /// <param name="p_AllowCancelFlag">�Ƿ�������</param>
        /// <param name="sqlTrans">������</param>
        public void RUpdateStep(string p_OrderNo, string p_ItemCode, string p_ColorNum, string p_ColorName, int p_SaleProcedureID, int p_FormListID, int p_CWStepID, int p_OrderStepID, int p_OPType, bool p_AllowCancelFlag, IDBTransAccess sqlTrans)
        {
            try
            {
                if (ProductParamSet.GetIntValueByID(5401) == (int)YesOrNo.No)//��ȡ�Ƿ�Ҫ����״̬��־
                {
                    return;
                }
                string sql = "";

                int updateOrderStepID = 0;//���±�״̬
                bool checkItemFlag = false;//��������
                bool checkColorFlag = false;//������ɫ

                sql = "SELECT ID,OrderStepID FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(p_OrderNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    sql = "SELECT ID,SaleProcedureID,FormListID,SaleProcedureID2,FormListID2,DZFlag,InvoiceFlag,RecAmountFlag,CheckItemFlag,CheckColorFlag FROM Enum_OrderStep ORDER BY Code";//Enum_OrderStepDts ֧�ָ�������ֿⵥ������֧�֣�����δ������Ҫʱ�ɲ��䣻
                    DataTable dtStep = sqlTrans.Fill(sql);
                    DataRow[] drStepA = new DataRow[] { };
                    if (p_SaleProcedureID != 0)//����ҵ�����̱�״̬����
                    {
                        drStepA = dtStep.Select("SaleProcedureID=" + p_SaleProcedureID + " OR SaleProcedureID2=" + p_SaleProcedureID);
                    }
                    else if (p_FormListID != 0)//�����ֿⵥ��
                    {
                        drStepA = dtStep.Select("FormListID=" + p_FormListID + " OR FormListID2=" + p_FormListID);
                    }
                    else if (p_CWStepID != 0)//�������񵥾�
                    {
                        switch (p_CWStepID)
                        {
                            case 1://����
                                drStepA = dtStep.Select("DZFlag=1");
                                break;
                            case 2://��Ʊ
                                drStepA = dtStep.Select("InvoiceFlag=1");
                                break;
                            case 3://�տ�
                                drStepA = dtStep.Select("RecAmountFlag=1");
                                break;
                        }
                    }
                    else if (p_OrderStepID != 0)
                    {
                        updateOrderStepID = p_OrderStepID;
                    }
                    if (drStepA.Length > 0)
                    {
                        updateOrderStepID = SysConvert.ToInt32(drStepA[0]["ID"]);
                        checkItemFlag = SysConvert.ToBoolean(SysConvert.ToInt32(drStepA[0]["CheckItemFlag"]));
                        checkColorFlag = SysConvert.ToBoolean(SysConvert.ToInt32(drStepA[0]["CheckColorFlag"]));
                    }

                    if (updateOrderStepID == 0)//���û�и���վ���򲻽��к�������
                    {
                        return;
                    }

                    if (RGetUpdateStepFlag(dtStep, SysConvert.ToInt32(dt.Rows[0]["OrderStepID"]), updateOrderStepID))//���¶���
                    {
                        sql = "UPDATE Sale_SaleOrder SET OrderStepID=" + updateOrderStepID;
                        sql += ",OrderPreStepID=" + SysConvert.ToInt32(dt.Rows[0]["OrderStepID"]) + " WHERE ID=" + SysConvert.ToInt32(dt.Rows[0]["ID"]);
                        sqlTrans.Fill(sql);
                    }

                    sql = "SELECT ID,OrderStepID FROM Sale_SaleOrderDts WHERE MainID=" + SysConvert.ToInt32(dt.Rows[0]["ID"]);
                    if (checkItemFlag)//У������
                    {
                        sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
                    }
                    if (checkColorFlag)//У����ɫ
                    {
                        sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum) + " AND ColorName=" + SysString.ToDBString(p_ColorName);
                    }
                    DataTable dtDts = sqlTrans.Fill(sql);//���¶�����ϸ
                    for (int i = 0; i < dtDts.Rows.Count; i++)
                    {
                        if (RGetUpdateStepFlag(dtStep, SysConvert.ToInt32(dtDts.Rows[i]["OrderStepID"]), updateOrderStepID))//���¶�����ϸ
                        {
                            sql = "UPDATE Sale_SaleOrderDts SET OrderStepID=" + updateOrderStepID;
                            sql += ",OrderPreStepID=" + SysConvert.ToInt32(dtDts.Rows[i]["OrderStepID"]) + " WHERE ID=" + SysConvert.ToInt32(dtDts.Rows[i]["ID"]);
                            sqlTrans.Fill(sql);
                        }
                    }

                }

            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// ����Ƿ����״̬��У���ж�
        /// </summary>
        /// <param name="dtStep"></param>
        /// <param name="p_CurStepID"></param>
        /// <param name="p_UpdStepID"></param>
        /// <returns></returns>
        bool RGetUpdateStepFlag(DataTable dtStep, int p_CurStepID, int p_UpdStepID)
        {
            bool outbool = false;
            int curstepIndex = -1;
            int updstepIndex = -1;
            for (int i = 0; i < dtStep.Rows.Count; i++)
            {
                if (p_CurStepID == SysConvert.ToInt32(dtStep.Rows[i]["ID"]))
                {
                    curstepIndex = i;
                }
                if (p_UpdStepID == SysConvert.ToInt32(dtStep.Rows[i]["ID"]))
                {
                    updstepIndex = i;
                }
            }
            if (ProductParamSet.GetIntValueByID(5422) == (int)YesOrNo.Yes)//����վ������ڵ�ǰվ��Ÿ���
            {
                if (updstepIndex > curstepIndex)//���µ�վ����ų�����ǰ����������
                {
                    outbool = true;
                }
            }
            else
            {
                outbool = true;
            }
            return outbool;
        }
        #endregion

        #region �����ͬ����ɾ�в�������ɾ�����ж�Ӧ����������,���������޸ĵĵط����ô˷���
        private void DeleteFabricSL(SaleOrder p_Entity, IDBTransAccess sqlTrans)
        {
            string sql = "DELETE FROM Sale_SaleOrderFabric WHERE MainID = " + SysString.ToDBString(p_Entity.ID);
            sql += " AND DID NOT IN (SELECT ID FROM Sale_SaleOrderDts WHERE MainID = " + SysString.ToDBString(p_Entity.ID) + " )";
            sqlTrans.Fill(sql);
        }

        private void DeleteItemSL(SaleOrder p_Entity, IDBTransAccess sqlTrans)
        {
            string sql = "DELETE FROM Sale_SaleOrderItem WHERE MainID = " + SysString.ToDBString(p_Entity.ID);
            sql += " AND DID NOT IN (SELECT ID FROM Sale_SaleOrderDts WHERE MainID = " + SysString.ToDBString(p_Entity.ID) + " )";
            sqlTrans.Fill(sql);
        }
        #endregion
    }
}
