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
    /// 目的：Sale_SaleOrder实体业务规则类
    /// 作者:陈加海
    /// 创建日期:2012-4-17
    /// </summary>
    public class SaleOrderRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SaleOrderRule()
        {
        }

        /// <summary>
        /// 检查将要操作的数据是否符合业务规则
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            SaleOrder entity = (SaleOrder)p_BE;
        }


        /// <summary>
        /// 显示数据
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
        /// 显示数据
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
        /// 显示数据
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
        /// 显示数据
        /// </summary>
        /// <param name="p_condition"></param>
        /// <summary>
        /// 显示数据
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
        /// 显示数据
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
        #region 提交处理
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="p_FormID">单据ID</param>
        /// <param name="p_Type">0/1:弃审/审核</param>
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
        /// 审核
        /// </summary>
        /// <param name="p_FormID">单据ID</param>
        /// <param name="p_Type">0/1/2/3:弃审/审核</param>
        public void RSubmit(int p_FormID, int p_Type, int p_WinFormID, int p_FormListAID, int p_FormListBID, IDBTransAccess sqlTrans)
        {
            try
            {
                int p_TempType = p_Type;//处理状态
                string sql = string.Empty;
                SaleOrder entity = new SaleOrder(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//如果相同异常
                {
                    throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
                }

                if (p_Type == (int)ConfirmFlag.未提交)//撤销提交验证
                {
                    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5409)))//销售订单有采购、加工、发货单、仓库单据不允许修改
                    {
                        bool allowOPFlag = true;
                        string refuseMessage = string.Empty;
                        DataTable dtSOFlow;
                        if (allowOPFlag)
                        {
                            //采购流程单据
                            sql = "SELECT TOP 1 ID,FormNo FROM UV1_Buy_ItemBuyFormDts WHERE DtsSO=" + SysString.ToDBString(entity.FormNo);
                            dtSOFlow = SysUtils.Fill(sql);
                            if (dtSOFlow.Rows.Count != 0)
                            {
                                allowOPFlag = false;
                                refuseMessage = "此单已有采购单(单号):" + dtSOFlow.Rows[0]["FormNo"].ToString() + "，不允许撤销";
                            }
                        }
                        if (allowOPFlag)
                        {
                            //加工流程单据
                            sql = "SELECT TOP 1 ID,FormNo  FROM UV1_WO_FabricProcessDts WHERE DtsSO=" + SysString.ToDBString(entity.FormNo);
                            dtSOFlow = SysUtils.Fill(sql);
                            if (dtSOFlow.Rows.Count != 0)
                            {
                                allowOPFlag = false;
                                refuseMessage = "此单已有加工单(单号):" + dtSOFlow.Rows[0]["FormNo"].ToString() + "，不允许撤销";
                            }
                        }

                        if (!allowOPFlag)//不允许操作
                        {
                            throw new Exception(refuseMessage);
                        }
                    }


                }

                sql = "UPDATE Sale_SaleOrder SET SubmitFlag=" + SysString.ToDBString(p_Type);

                sql += " WHERE ID=" + p_FormID.ToString();//更新单据主表审核状态
                sqlTrans.ExecuteNonQuery(sql);


                //WinListFillDateTypeRule wfdrule = new WinListFillDateTypeRule();
                //int[] fillDataTypeID ;
                //wfdrule.RGetFillDataType(p_WinFormID, p_FormListAID, p_FormListBID, out fillDataTypeID);
                //for (int i = 0; i < fillDataTypeID.Length; i++)
                //{
                //    switch (fillDataTypeID[i])
                //    {
                //        case (int)EnumFillDataType.销售订单制单标准回填调样单方法:
                //            sql = "SELECT ItemCode,ColorNum,SUM(Qty) Qty FROM Sale_SaleOrderDts WHERE MainID=" + p_FormID + " GROUP BY ItemCode,ColorNum";
                //            DataTable dtDts = sqlTrans.Fill(sql);
                //            break;
                //    }
                //}


                if (p_Type == (int)ConfirmFlag.已提交 || p_Type == (int)ConfirmFlag.审核通过)
                {
                    sql = "SELECT SO,ItemCode,ItemName,ItemStd,ItemModel,ColorName,SUM(Qty) Qty,MAX(Unit) Unit,Needle,MWeight,MWidth FROM Sale_SaleOrderFabric WHERE MainID=" + SysString.ToDBString(p_FormID);
                    sql += " GROUP BY SO,ItemCode,ItemName,ItemStd,ItemModel,ColorName,Needle,MWeight,MWidth";
                    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5009)))//面料的坯布启用可替换坯布功能,影响到订单坯布算料、坯布采购、织造等
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
                        if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5009)))//面料的坯布启用可替换坯布功能,影响到订单坯布算料、坯布采购、织造等
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
                    sql += " AND BuyType=" + SysString.ToDBString((int)EnumBuyType.胚纱采购);
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
                    sql += " AND BuyType=" + SysString.ToDBString((int)EnumBuyType.色纱采购);
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
                    sql += " AND BuyType=" + SysString.ToDBString((int)EnumBuyType.胚纱采购);
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
                else if (p_Type == (int)ConfirmFlag.未提交)
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

        #region 销售订单数据同步到采购单方法
        /// <summary>
        /// 检查是否需要同步 销售订单数据同步到采购单方法
        /// </summary>
        /// <param name="p_FormID"></param>
        public bool RSameDataToBuyCheck(int p_FormID)
        {
            ParamSetRule psrule = new ParamSetRule();

            if (psrule.RShowIntByID((int)ParamSetEnum.订单数据变更同步到采购单中) == (int)YesOrNo.Yes)//同步标志为 是
            {
                SaleOrder entity = new SaleOrder();
                entity.ID = p_FormID;
                entity.SelectByID();

                string sql = string.Empty;
                sql = "SELECT ID,ShopID FROM Buy_ItemBuyForm WHERE OrderFormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dtBuyMain = SysUtils.Fill(sql);//采购单主表

                if (dtBuyMain.Rows.Count != 0)//需要同步
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 销售订单数据同步到采购单方法
        /// </summary>
        /// <param name="p_FormID">单据ID</param>
        /// <param name="p_Type">0/1:弃审/审核</param>
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
                    //this.RSameDataToBuy(entity, sqlTrans);不再同步
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
        /// 销售订单数据同步到采购单方法
        /// </summary>
        /// <param name="p_FormID"></param>
        public void RSameDataToBuy(SaleOrder entity, IDBTransAccess sqlTrans)
        {
            ParamSetRule psrule = new ParamSetRule();
            if (psrule.RShowIntByID((int)ParamSetEnum.订单数据变更同步到采购单中) == (int)YesOrNo.Yes)//同步标志为 是
            {
                string sql = string.Empty;
                sql = "SELECT ID,ShopID FROM Buy_ItemBuyForm WHERE OrderFormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dtBuyMain = sqlTrans.Fill(sql);//采购单主表

                sql = "SELECT A.*,B.VendorID ItemShopID FROM Sale_SaleOrderDts A,Data_Item B WHERE  A.ItemCode=B.ItemCode AND A.MainID=" + entity.ID;
                DataTable dtSaleOrderDts = sqlTrans.Fill(sql);//销售订单数据明细

                bool findSameRecord = false;
                for (int i = 0; i < dtBuyMain.Rows.Count; i++)
                {
                    DataRow[] drA = dtSaleOrderDts.Select(" ItemShopID=" + SysString.ToDBString(dtBuyMain.Rows[i]["ShopID"].ToString()));//选择订单该厂码下的订单明细数据

                    sql = "SELECT * FROM Buy_ItemBuyFormDts WHERE MainID=" + SysString.ToDBString(dtBuyMain.Rows[i]["ID"].ToString());
                    DataTable dtBuyDts = sqlTrans.Fill(sql);//采购单数据明细

                    //STEP 2开始整理采购单明细数据
                    for (int bi = dtBuyDts.Rows.Count - 1; bi >= 0; bi--)//先行采购单明细和订单明细对比
                    {
                        findSameRecord = false;
                        for (int si = 0; si < drA.Length; si++)
                        {
                            if (SysConvert.ToInt32(dtBuyDts.Rows[bi]["DLoadID"]) > 0)
                            {
                                if (drA[si]["ID"].ToString() == dtBuyDts.Rows[bi]["DLoadID"].ToString())//找到相同产品，同步相关数据
                                {
                                    RSameDataToBuyCopyOne(drA[si], dtBuyDts.Rows[bi], entity.FormNo, entity.VendorID);
                                    findSameRecord = true;
                                    break;
                                }
                            }
                            else
                            {

                                if (drA[si]["ItemCode"].ToString() == dtBuyDts.Rows[bi]["ItemCode"].ToString()
                                    && drA[si]["ColorNum"].ToString() == dtBuyDts.Rows[bi]["ColorNum"].ToString())//找到相同产品，同步相关数据
                                {
                                    RSameDataToBuyCopyOne(drA[si], dtBuyDts.Rows[bi], entity.FormNo, entity.VendorID);
                                    findSameRecord = true;
                                    break;
                                }
                            }
                        }
                        if (!findSameRecord)//没有找到同样的数据则移除
                        {
                            dtBuyDts.Rows.Remove(dtBuyDts.Rows[bi]);
                        }
                    }

                    for (int si = 0; si < drA.Length; si++) //再行订单明细和采购单明细对比
                    {
                        findSameRecord = false;
                        for (int bi = dtBuyDts.Rows.Count - 1; bi >= 0; bi--)
                        {
                            if (SysConvert.ToInt32(dtBuyDts.Rows[bi]["DLoadID"]) > 0)
                            {
                                if (drA[si]["ID"].ToString() == dtBuyDts.Rows[bi]["DLoadID"].ToString())//找到相同产品，同步相关数据
                                {
                                    findSameRecord = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (drA[si]["ItemCode"].ToString() == dtBuyDts.Rows[bi]["ItemCode"].ToString()
                                    && drA[si]["ColorNum"].ToString() == dtBuyDts.Rows[bi]["ColorNum"].ToString())//找到相同产品，同步相关数据
                                {
                                    findSameRecord = true;
                                    break;
                                }
                            }
                        }
                        if (!findSameRecord)//没有找到同样的数据则添加数据
                        {
                            DataRow drBuy = dtBuyDts.NewRow();
                            RSameDataToBuyCopyOne(drA[si], drBuy, entity.FormNo, entity.VendorID);
                            dtBuyDts.Rows.Add(drBuy);
                        }
                    }
                    //结束整理采购单明细数据


                    //STEP 3 整理保存数据
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

                    //STEP 4 保存数据
                }

                sql = "SELECT ItemCode FROM UV1_Buy_ItemBuyFormDts WHERE OrderFormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    if (SysConvert.ToString(dt.Rows[0]["ItemCode"]) == "")
                    {
                        throw new BaseException("厂码发生变更，请更正后提交！");
                    }
                }

            }
        }

        /// <summary>
        /// 获得实体
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
        /// 获得实体
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
        /// 拷贝一行数据
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

        #region 销售订单制单标准回填调样单方法
        /// <summary>
        /// 销售订单制单标准回填调样单方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataXSDDDY(SaleOrder entity, DataTable dtDts, int p_Type, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;

            for (int i = 0; i < dtDts.Rows.Count; i++)//循环遍历历史
            {
                sql = "SELECT TOP 1 ID,Qty FROM Sale_DYGL WHERE VendorID=" + SysString.ToDBString(entity.VendorID);
                sql += " AND ItemCode=" + SysString.ToDBString(dtDts.Rows[i]["ItemCode"].ToString());
                sql += " AND ColorNum=" + SysString.ToDBString(dtDts.Rows[i]["ColorNum"].ToString());
                sql += " ORDER BY ID FormDate DESC ";
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    if (p_Type == (int)YesOrNo.Yes)//提交
                    {


                        sql = "UPDATE Sale_DYGL SET ";
                        sql += " LSaleOrderDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",SaleOrderCount=ISNULL(SaleOrderCount,0)+1";
                        sql += ",SaleOrderQty=ISNULL(SaleOrderQty,0)+" + SysString.ToDBString(SysConvert.ToDecimal(dtDts.Rows[i]["Qty"]));
                        sql += " WHERE ID=" + dtData.Rows[0]["ID"].ToString();
                    }
                    else//撤销提交
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
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
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
        /// 新增(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
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
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
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
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        /// <param name="sqlTrans">事务类</param>
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
        /// 删除
        /// </summary>
        /// <param name="p_BE">要删除的实体</param>
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
        /// 删除
        /// </summary>
        /// <param name="p_BE">要删除的实体</param>
        /// <param name="sqlTrans">事务类</param>
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

        #region 新增方法
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
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
        /// 新增(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
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
                    throw new BaseException("订单号已存在，请重新生成");
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
                procedureRule.RSave(entity, p_BE3, sqlTrans);//保存流程明细


                FormNoControlRule rulest = new FormNoControlRule();
                //rulest.RAddSort((int)FormNoControlEnum.合同号,sqlTrans);
                rulest.RAddSort("Sale_SaleOrder", "FormNo", 0, sqlTrans);




                SaleOrderCapDtsRule capRule = new SaleOrderCapDtsRule();
                capRule.RSaveSaleCap(entity, sqlTrans);//保存资金计划明细

                DeleteFabricSL(entity, sqlTrans);
                DeleteItemSL(entity, sqlTrans);


                if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5412)))//销售订单坯布自动算料
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
                            throw new BaseException("请维护成品面料对应的坯布面料！");
                        }
                        for (int j = 0; j < dto.Rows.Count; j++)
                        {
                            DataRow dr = dtF.NewRow();
                            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5009)))//面料的坯布启用可替换坯布功能,影响到订单坯布算料、坯布采购、织造等
                            {
                                dr["CPItemCode"] = entityMain.ItemCode;
                                dr["CPItemName"] = entityMain.ItemName;
                                dr["CPItemStd"] = entityMain.ItemStd;
                                dr["CPItemModel"] = entityMain.ItemModel;
                            }

                            dr["ItemCode"] = SysConvert.ToString(dto.Rows[j]["ItemCode"]);
                            dr["ItemName"] = SysConvert.ToString(dto.Rows[j]["ItemName"]);
                            dr["ItemStd"] = SysConvert.ToString(dto.Rows[j]["ItemStd"]);
                            //dr["ColorName"] = entitydts.ColorName;坯布带入颜色
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
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
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
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        /// <param name="sqlTrans">事务类</param>
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
                procedureRule.RSave(entity, p_BE3, sqlTrans);//保存流程明细

                SaleOrderCapDtsRule capRule = new SaleOrderCapDtsRule();
                capRule.RSaveSaleCap(entity, sqlTrans);//保存资金计划明细

                DeleteFabricSL(entity, sqlTrans);

                DeleteItemSL(entity, sqlTrans);

                if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5412)))//销售订单坯布自动算料
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
                            throw new BaseException("请维护成品面料对应的坯布面料！");
                        }
                        for (int j = 0; j < dto.Rows.Count; j++)
                        {
                            DataRow dr = dtF.NewRow();
                            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5009)))//面料的坯布启用可替换坯布功能,影响到订单坯布算料、坯布采购、织造等
                            {
                                dr["CPItemCode"] = entityMain.ItemCode;
                                dr["CPItemName"] = entityMain.ItemName;
                                dr["CPItemStd"] = entityMain.ItemStd;
                                dr["CPItemModel"] = entityMain.ItemModel;
                            }

                            dr["ItemCode"] = SysConvert.ToString(dto.Rows[j]["ItemCode"]);
                            dr["ItemName"] = SysConvert.ToString(dto.Rows[j]["ItemName"]);
                            dr["ItemStd"] = SysConvert.ToString(dto.Rows[j]["ItemStd"]);
                            //dr["ColorName"] = entitydts.ColorName;坯布带入颜色
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


        #region 状态更新
        /// <summary>
        /// 站别状态更新(传入事务处理)
        /// </summary>
        /// <param name="p_OrderNo">合同号</param>
        /// <param name="p_ColorNum">色号</param>
        /// <param name="p_ColorName">色名</param>
        /// <param name="p_SaleProcedureID">业务流程表单ID</param>
        /// <param name="p_FormListID">仓库单据类型ID</param>
        /// <param name="p_CWStepID">财务站类型，暂不使用</param>
        /// <param name="p_OrderStepID">更新站:一般不去使用</param>
        /// <param name="p_OPType">操作类型:1/0:提交/撤销提交</param>
        /// <param name="p_AllowCancelFlag">是否允许撤销</param>
        /// <param name="sqlTrans">事务类</param>
        public void RUpdateStep(string p_OrderNo, string p_ItemCode, string p_ColorNum, string p_ColorName, int p_SaleProcedureID, int p_FormListID, int p_CWStepID, int p_OrderStepID, int p_OPType, bool p_AllowCancelFlag, IDBTransAccess sqlTrans)
        {
            try
            {
                if (ProductParamSet.GetIntValueByID(5401) == (int)YesOrNo.No)//获取是否要更新状态标志
                {
                    return;
                }
                string sql = "";

                int updateOrderStepID = 0;//更新表单状态
                bool checkItemFlag = false;//检验物料
                bool checkColorFlag = false;//检验颜色

                sql = "SELECT ID,OrderStepID FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(p_OrderNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    sql = "SELECT ID,SaleProcedureID,FormListID,SaleProcedureID2,FormListID2,DZFlag,InvoiceFlag,RecAmountFlag,CheckItemFlag,CheckColorFlag FROM Enum_OrderStep ORDER BY Code";//Enum_OrderStepDts 支持更多表单，仓库单据类型支持，代码未来有需要时可补充；
                    DataTable dtStep = sqlTrans.Fill(sql);
                    DataRow[] drStepA = new DataRow[] { };
                    if (p_SaleProcedureID != 0)//检验业务流程表单状态更新
                    {
                        drStepA = dtStep.Select("SaleProcedureID=" + p_SaleProcedureID + " OR SaleProcedureID2=" + p_SaleProcedureID);
                    }
                    else if (p_FormListID != 0)//检索仓库单据
                    {
                        drStepA = dtStep.Select("FormListID=" + p_FormListID + " OR FormListID2=" + p_FormListID);
                    }
                    else if (p_CWStepID != 0)//检索财务单据
                    {
                        switch (p_CWStepID)
                        {
                            case 1://对账
                                drStepA = dtStep.Select("DZFlag=1");
                                break;
                            case 2://开票
                                drStepA = dtStep.Select("InvoiceFlag=1");
                                break;
                            case 3://收款
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

                    if (updateOrderStepID == 0)//如果没有更新站别，则不进行后续调用
                    {
                        return;
                    }

                    if (RGetUpdateStepFlag(dtStep, SysConvert.ToInt32(dt.Rows[0]["OrderStepID"]), updateOrderStepID))//更新订单
                    {
                        sql = "UPDATE Sale_SaleOrder SET OrderStepID=" + updateOrderStepID;
                        sql += ",OrderPreStepID=" + SysConvert.ToInt32(dt.Rows[0]["OrderStepID"]) + " WHERE ID=" + SysConvert.ToInt32(dt.Rows[0]["ID"]);
                        sqlTrans.Fill(sql);
                    }

                    sql = "SELECT ID,OrderStepID FROM Sale_SaleOrderDts WHERE MainID=" + SysConvert.ToInt32(dt.Rows[0]["ID"]);
                    if (checkItemFlag)//校验物料
                    {
                        sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
                    }
                    if (checkColorFlag)//校验颜色
                    {
                        sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum) + " AND ColorName=" + SysString.ToDBString(p_ColorName);
                    }
                    DataTable dtDts = sqlTrans.Fill(sql);//更新订单明细
                    for (int i = 0; i < dtDts.Rows.Count; i++)
                    {
                        if (RGetUpdateStepFlag(dtStep, SysConvert.ToInt32(dtDts.Rows[i]["OrderStepID"]), updateOrderStepID))//更新订单明细
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
        /// 获得是否更新状态的校验判定
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
            if (ProductParamSet.GetIntValueByID(5422) == (int)YesOrNo.Yes)//订单站别需大于当前站别才更新
            {
                if (updstepIndex > curstepIndex)//更新的站别序号超过当前的序号则更新
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

        #region 如果合同进行删行操作，则删除该行对应的算料数据,在新增和修改的地方调用此方法
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
