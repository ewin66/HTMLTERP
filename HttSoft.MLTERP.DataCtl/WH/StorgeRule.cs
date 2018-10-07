using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;


namespace HttSoft.MLTERP.DataCtl
{
    /// <summary>
    /// 目的：WH_Storge实体业务规则类
    /// 作者:陈加海
    /// 创建日期:2009-4-23
    /// </summary>
    public class StorgeRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public StorgeRule()
        {
        }

        /// <summary>
        /// 检查将要操作的数据是否符合业务规则
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            Storge entity = (Storge)p_BE;
        }

        #region 显示数据
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_Storge WHERE 1=1";
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
        public DataTable LKRShow(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM WH_Storge WHERE 1=1";
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

        #endregion

        #region  生成的代码
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
                Storge entity = (Storge)p_BE;
                StorgeCtl control = new StorgeCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WH_Storge, sqlTrans);
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
                Storge entity = (Storge)p_BE;
                StorgeCtl control = new StorgeCtl(sqlTrans);
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
                Storge entity = (Storge)p_BE;
                StorgeCtl control = new StorgeCtl(sqlTrans);
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
        #endregion

        #region 结算库存
        /// <summary>
        /// 结算库存
        /// </summary>
        /// <param name="p_Entity">IOForm实体</param>
        /// <param name="p_EntityDts">IOFormDts实体</param>
        /// <param name="p_Type">1/3 审核通过/审核拒绝</param>
        public void RSubmit(int p_FormTopType, IOForm p_Entity, IOFormDts p_EntityDts, int p_Type, IDBTransAccess sqlTrans)
        {
            try
            {
                if (p_FormTopType == (int)WHFormList.移库)//移库单结算
                {
                    this.RSubmitMove(p_FormTopType, p_Entity, p_EntityDts, p_Type, sqlTrans);
                    return;
                }

                if (p_FormTopType == (int)WHFormList.盘点)//盘点单结算
                {
                    this.RSubmitCheck(p_FormTopType, p_Entity, p_EntityDts, p_Type, sqlTrans);
                    return;
                }



                Storge entityst = new Storge(sqlTrans);//出入库结算
                int StorgeID = 0;
                bool p_NegativeFlag = false;//负数标志
                bool p_ZeroExitFlag = false;//为0标志
                int p_ISJK = 0;//寄库标志

                WH entityWH = new WH(sqlTrans);
                string sqlWH = "Select ID,ISJK FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_EntityDts.WHID);
                DataTable dtWH = sqlTrans.Fill(sqlWH);
                if (dtWH.Rows.Count != 0)
                {
                    entityWH.ID = SysConvert.ToInt32(dtWH.Rows[0]["ID"]);
                    entityWH.SelectByID();

                    p_ISJK = SysConvert.ToInt32(dtWH.Rows[0]["ISJK"]);//寄库
                }



                StorgeID = FindStorge(p_EntityDts, sqlTrans);
                if (StorgeID != 0)//找到历史记录
                {
                    entityst.ID = StorgeID;
                    entityst.SelectByID();

                }
                else//找不到历史记录
                {
                    entityst.Indate = p_Entity.FormDate;
                    entityst.DutyOPID = p_Entity.DutyOP;
                    entityst.WHID = p_EntityDts.WHID;
                    entityst.SectionID = p_EntityDts.SectionID;
                    entityst.SBitID = p_EntityDts.SBitID;
                    entityst.ItemCode = p_EntityDts.ItemCode;
                    entityst.ItemName = p_EntityDts.ItemName;
                    entityst.ItemStd = p_EntityDts.ItemStd;
                    entityst.ColorNum = p_EntityDts.ColorNum;
                    entityst.ColorName = p_EntityDts.ColorName;
                    entityst.JarNum = p_EntityDts.JarNum;
                    entityst.Batch = p_EntityDts.Batch;
                    entityst.VendorBatch = p_EntityDts.VendorBatch;
                    entityst.YarnType = p_EntityDts.YarnType;
                    entityst.Unit = p_EntityDts.Unit;
                    entityst.SinglePrice = p_EntityDts.SinglePrice;
                    entityst.TubeGW = p_EntityDts.TubeGW;
                    entityst.Remark = p_EntityDts.Remark;
                    entityst.VColorNum = p_EntityDts.VColorNum;
                    entityst.VColorName = p_EntityDts.VColorName;
                    entityst.VItemCode = p_EntityDts.VItemCode;
                    entityst.GoodsCode = p_EntityDts.GoodsCode;
                    entityst.GoodsLevel = p_EntityDts.GoodsLevel;
                    entityst.MWidth = p_EntityDts.MWidth;
                    entityst.MWeight = p_EntityDts.MWeight;
                    entityst.WeightUnit = p_EntityDts.WeightUnit;
                    entityst.MLType = p_EntityDts.MLType;   //用于区分成品面料和坯布
                    if (p_FormTopType != (int)WHFormList.出库)//非出库状态
                    {
                        entityst.VendorID = p_EntityDts.DtsVendorID;//
                        entityst.SO = p_EntityDts.DtsSO;//单据号
                        entityst.DutyOPID = p_EntityDts.DtsSaleOPID;//业务员
                        entityst.OrderFormNo = p_EntityDts.DtsOrderFormNo;//合同号
                    }
                    else//出库状态
                    {
                        entityst.VendorID = p_EntityDts.DtsInVendorID;//入库客户
                        entityst.SO = p_EntityDts.InSO;//入库订单
                        entityst.DutyOPID = p_EntityDts.InSaleOPID;//入库业务员
                        entityst.OrderFormNo = p_EntityDts.InOrderFormNo;//入库合同号
                    }

                    entityst.DVendorID = p_EntityDts.DVendorID;//销售合同
                    entityst.Needle = p_EntityDts.Needle;



                }
                if (p_Entity.SubmitFlag == (int)ConfirmFlag.审核通过)
                {
                    switch (p_FormTopType)
                    {
                        case (int)WHFormList.入库:
                            entityst.Qty += p_EntityDts.Qty;
                            entityst.PieceQty += p_EntityDts.PieceQty;
                            entityst.Weight += p_EntityDts.Weight;
                            entityst.Yard += p_EntityDts.Yard;
                            entityst.Amount += p_EntityDts.Qty * p_EntityDts.SinglePrice;//计算金额

                            break;
                        case (int)WHFormList.出库:
                            entityst.Qty -= p_EntityDts.Qty;
                            entityst.Yard -= p_EntityDts.Yard;
                            entityst.PieceQty -= p_EntityDts.PieceQty;
                            entityst.Weight -= p_EntityDts.Weight;
                            entityst.Amount -= p_EntityDts.Qty * p_EntityDts.SinglePrice;//计算金额
                            break;
                        case (int)WHFormList.期初入库:
                            goto case (int)WHFormList.入库;
                    }

                }
                else
                {
                    switch (p_FormTopType)
                    {
                        case (int)WHFormList.入库:
                            entityst.Qty -= p_EntityDts.Qty;
                            entityst.PieceQty -= p_EntityDts.PieceQty;
                            entityst.Weight -= p_EntityDts.Weight;
                            entityst.Yard -= p_EntityDts.Yard;
                            entityst.Amount -= p_EntityDts.Qty * p_EntityDts.SinglePrice;//计算金额
                            break;
                        case (int)WHFormList.出库:
                            entityst.Qty += p_EntityDts.Qty;

                            entityst.PieceQty += p_EntityDts.PieceQty;
                            entityst.Weight += p_EntityDts.Weight;
                            entityst.Yard += p_EntityDts.Yard;
                            entityst.Amount += p_EntityDts.Qty * p_EntityDts.SinglePrice;//计算金额
                            break;
                        case (int)WHFormList.期初入库:
                            goto case (int)WHFormList.入库;
                    }

                }


                if (entityst.Qty < -0.001m || entityst.Weight < -0.001m || entityst.Yard < -0.001m)//库存数量大于0
                {
                    throw new Exception("操作后库存数量低于0，不能操作，编码：" + entityst.ItemCode + " 批号：" + entityst.Batch + " 色号：" + entityst.ColorNum + " 颜色：" + entityst.ColorName + " 缸号：" + entityst.JarNum + " 米数：" + entityst.Qty.ToString() + "重量：" + entityst.Weight.ToString());
                }

                if (entityst.FreeQty < -0.001m)//库存可使用数量大于0
                {
                    throw new Exception("操作后库存可使用数量低于0，不能操作，编码：" + entityst.ItemCode + "  色号：" + entityst.ColorNum + " 颜色：" + entityst.ColorName + " 数量：" + entityst.FreeQty.ToString());
                }

                this.RSaveEntity(entityst, p_ZeroExitFlag, sqlTrans);


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
        /// 面料出入库查找库存
        /// </summary>
        /// <param name="p_entity"></param>
        /// <param name="sqlTrans"></param>
        /// <returns></returns>
        public int FindStorge(IOFormDts p_entity, IDBTransAccess sqlTrans)
        {

            if (p_entity.WHID == string.Empty)
            {
                throw new Exception("单据仓库未找到，不能操作");
            }

            string conditionstr = string.Empty;
            string sql = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(p_entity.WHID);//获得仓库结算类型字段
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                conditionstr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
            }



            sql = "SELECT ID FROM WH_Storge WHERE 1=1";//查找库存ID
            int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
            if (conditionstr != string.Empty)
            {
                string[] FieldName = conditionstr.Split('+');
                sql += " AND WHID=" + SysString.ToDBString(p_entity.WHID);
                sql += " AND SectionID=" + SysString.ToDBString(p_entity.SectionID);
                sql += " AND SBitID=" + SysString.ToDBString(p_entity.SBitID);
                for (int i = 0; i < FieldName.Length; i++)
                {
                    string sqlFieldName = "SELECT ID FROM Enum_WHCalMethodFieldName WHERE Name=" + SysString.ToDBString(FieldName[i]);//找到库存结算字段对应的ID
                    DataTable dtFieldName = sqlTrans.Fill(sqlFieldName);
                    if (dtFieldName.Rows.Count != 0 && dtFieldName.Rows[0]["ID"].ToString() != "")
                    {
                        CalFieldName = SysConvert.ToInt32(dtFieldName.Rows[0]["ID"]);
                    }

                    switch (CalFieldName)
                    {
                        case (int)WHCalMethodFieldName.WHID://库
                            sql += " AND WHID=" + SysString.ToDBString(p_entity.WHID);
                            break;
                        case (int)WHCalMethodFieldName.SectionID://区
                            sql += " AND SectionID=" + SysString.ToDBString(p_entity.SectionID);
                            break;
                        case (int)WHCalMethodFieldName.SBitID://位
                            sql += " AND SBitID=" + SysString.ToDBString(p_entity.SBitID);
                            break;
                        case (int)WHCalMethodFieldName.ItemCode://产品编码
                            sql += " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(p_entity.ItemCode);
                            break;
                        case (int)WHCalMethodFieldName.JarNum://缸号
                            sql += " AND ISNULL(JarNum,'')=" + SysString.ToDBString(p_entity.JarNum);
                            break;
                        case (int)WHCalMethodFieldName.ColorNum://色号
                            sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(p_entity.ColorNum);
                            break;
                        case (int)WHCalMethodFieldName.ColorName://颜色
                            sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(p_entity.ColorName);
                            break;
                        case (int)WHCalMethodFieldName.MWidth://门幅
                            sql += " AND ISNULL(MWidth,0)=" + SysString.ToDBString(p_entity.MWidth);
                            break;
                        case (int)WHCalMethodFieldName.MWeight://克重
                            sql += " AND ISNULL(MWeight,0)=" + SysString.ToDBString(p_entity.MWeight);
                            break;
                        case (int)WHCalMethodFieldName.VendorID://客户
                            sql += " AND ISNULL(VendorID,'')=" + SysString.ToDBString(p_entity.DtsVendorID);
                            break;
                        case (int)WHCalMethodFieldName.GoodsCode://商品码
                            sql += " AND ISNULL(GoodsCode,'')=" + SysString.ToDBString(p_entity.GoodsCode);
                            break;
                        case (int)WHCalMethodFieldName.GoodsLevel://等级
                            sql += " AND ISNULL(GoodsLevel,'')=" + SysString.ToDBString(p_entity.GoodsLevel);
                            break;
                        case (int)WHCalMethodFieldName.Batch:   //批号
                            sql += " AND ISNULL(Batch,'')=" + SysString.ToDBString(p_entity.Batch);
                            break;
                        case (int)WHCalMethodFieldName.Unit:   //单位
                            sql += " AND ISNULL(Unit,'')=" + SysString.ToDBString(p_entity.Unit);
                            break;
                        case (int)WHCalMethodFieldName.VendorBatch:  //客户批号
                            sql += " AND ISNULL(VendorBatch,'')=" + SysString.ToDBString(p_entity.VendorBatch);
                            break;
                        case (int)WHCalMethodFieldName.DtsOrderFormNo:  //订单号
                            sql += " AND ISNULL(OrderFormNo,'')=" + SysString.ToDBString(p_entity.DtsOrderFormNo);
                            break;
                        default:
                            throw new Exception("结算异常，结算定义的字段底层未对应：" + CalFieldName);

                    }
                }
            }
            else
            {
                throw new Exception("没有找到结算类型，请联系管理员检查仓库类型配置信息");
            }
            DataTable dtlog = sqlTrans.Fill(sql);
            if (dtlog.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dtlog.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// 面料移库查找库存
        /// </summary>
        /// <param name="p_entity"></param>
        /// <param name="sqlTrans"></param>
        /// <returns></returns>
        public int FindStorge(IOFormDts p_entity, int p_Type, IDBTransAccess sqlTrans)
        {

            if (p_entity.WHID == string.Empty)
            {
                throw new Exception("单据仓库未找到，不能操作");
            }

            string conditionstr = string.Empty;
            string sql = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(p_entity.WHID);//获得仓库结算类型字段
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                conditionstr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
            }



            sql = "SELECT ID FROM WH_Storge WHERE 1=1";//查找库存ID
            int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
            if (conditionstr != string.Empty)
            {
                string[] FieldName = conditionstr.Split('+');
                if (p_Type == (int)EnumWHMove.移动库)
                {
                    sql += " AND WHID=" + SysString.ToDBString(p_entity.WHID);
                    sql += " AND SectionID=" + SysString.ToDBString(p_entity.SectionID);
                    sql += " AND SBitID=" + SysString.ToDBString(p_entity.SBitID);
                }
                else if (p_Type == (int)EnumWHMove.目的库)
                {
                    sql += " AND WHID=" + SysString.ToDBString(p_entity.ToWHID);
                    sql += " AND SectionID=" + SysString.ToDBString(p_entity.ToSectionID);
                    sql += " AND SBitID=" + SysString.ToDBString(p_entity.ToSBitID);
                }
                else
                {
                    throw new Exception("传入参数类型异常");
                }
                for (int i = 0; i < FieldName.Length; i++)
                {
                    string sqlFieldName = "SELECT ID FROM Enum_WHCalMethodFieldName WHERE Name=" + SysString.ToDBString(FieldName[i]);//找到库存结算字段对应的ID
                    DataTable dtFieldName = sqlTrans.Fill(sqlFieldName);
                    if (dtFieldName.Rows.Count != 0 && dtFieldName.Rows[0]["ID"].ToString() != "")
                    {
                        CalFieldName = SysConvert.ToInt32(dtFieldName.Rows[0]["ID"]);
                    }

                    switch (CalFieldName)
                    {
                        case (int)WHCalMethodFieldName.WHID://库 上方已处理
                            break;
                        case (int)WHCalMethodFieldName.SectionID://区
                            break;
                        case (int)WHCalMethodFieldName.SBitID://位
                            break;
                        case (int)WHCalMethodFieldName.ItemCode://产品编码
                            sql += " AND ItemCode=" + SysString.ToDBString(p_entity.ItemCode);
                            break;
                        case (int)WHCalMethodFieldName.JarNum://缸号
                            sql += " AND JarNum=" + SysString.ToDBString(p_entity.JarNum);
                            break;
                        case (int)WHCalMethodFieldName.ColorNum://色号
                            sql += " AND ColorNum=" + SysString.ToDBString(p_entity.ColorNum);
                            break;
                        case (int)WHCalMethodFieldName.ColorName://颜色
                            sql += " AND ColorName=" + SysString.ToDBString(p_entity.ColorName);
                            break;
                        case (int)WHCalMethodFieldName.MWidth://门幅
                            sql += " AND MWidth=" + SysString.ToDBString(p_entity.MWidth);
                            break;
                        case (int)WHCalMethodFieldName.MWeight://克重
                            sql += " AND MWeight=" + SysString.ToDBString(p_entity.MWeight);
                            break;
                        case (int)WHCalMethodFieldName.VendorID://客户
                            sql += " AND VendorID=" + SysString.ToDBString(p_entity.DtsVendorID);
                            break;
                        case (int)WHCalMethodFieldName.GoodsCode://商品码
                            sql += " AND GoodsCode=" + SysString.ToDBString(p_entity.GoodsCode);
                            break;
                        case (int)WHCalMethodFieldName.GoodsLevel://等级
                            sql += " AND GoodsLevel=" + SysString.ToDBString(p_entity.GoodsLevel);
                            break;
                        case (int)WHCalMethodFieldName.Batch:   //批号
                            sql += " AND Batch=" + SysString.ToDBString(p_entity.Batch);
                            break;
                        case (int)WHCalMethodFieldName.Unit:   //批号
                            sql += " AND Unit=" + SysString.ToDBString(p_entity.Unit);
                            break;
                        case (int)WHCalMethodFieldName.VendorBatch:  //客户批号
                            sql += " AND VendorBatch=" + SysString.ToDBString(p_entity.VendorBatch);
                            break;
                        case (int)WHCalMethodFieldName.DtsOrderFormNo:  //订单号
                            sql += " AND ISNULL(DtsOrderFormNo,'')=" + SysString.ToDBString(p_entity.DtsOrderFormNo);
                            break;
                        case (int)WHCalMethodFieldName.DtsSO:  //订单号
                            sql += " AND ISNULL(DtsSO,'')=" + SysString.ToDBString(p_entity.DtsSO);
                            break;
                        default:
                            throw new Exception("结算异常，结算定义的字段底层未对应：" + CalFieldName);


                    }
                }
            }
            else
            {
                throw new Exception("没有找到结算类型，请联系管理员检查仓库类型配置信息");
            }
            DataTable dtlog = sqlTrans.Fill(sql);
            if (dtlog.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dtlog.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 其他辅助
        /// <summary>
        /// 取得仓库结算类型
        /// </summary>
        /// <param name="p_WHID"></param>
        /// <returns></returns>
        private int GetAmountType(string p_WHID, IDBTransAccess sqlTrans)
        {
            int p_AmountType = 0;
            string sql = "SELECT AmountType FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_WHID);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                p_AmountType = SysConvert.ToInt32(dt.Rows[0]["AmountType"].ToString());
            }
            return p_AmountType;
        }
        #endregion

        #region 保存库存汇总实体
        /// <summary>
        /// 保存库存汇总实体
        /// </summary>
        private void RSaveEntity(BaseEntity p_BE, bool p_ZeroExitFlag, IDBTransAccess sqlTrans)
        {
            try
            {
                Storge entity = (Storge)p_BE;


                ///2010.2.1修改--周富春
                if (entity.ID == 0)//新增
                {
                    this.RAdd(entity, sqlTrans);
                }

                if (entity.ID != 0)//更新 
                {
                    this.RUpdate(entity, sqlTrans);
                }


                if (!p_ZeroExitFlag)//如果不允许为0的库存存在，则清除记录
                {
                    if (entity.ID != 0 && (entity.Qty == 0 && entity.Weight == 0 && entity.Yard == 0))//更新 && entity.PieceQty==0
                    {
                        this.RDelete(entity, sqlTrans);
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

        #region 找库存数量
        //public int FindStorge(string p_WHID, string p_SectionID, string p_SBitID, int p_CompanyTypeID, string p_ItemCode, string p_Batch, string p_VendorBatch, string p_JarNum, string p_ColorNum, string p_ColorName, string p_Needle, string p_YarnStatus, string p_DtsSO, int p_WHTypeID, string p_SizeName)
        //{
        //    try
        //    {
        //        IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
        //        try
        //        {
        //            sqlTrans.OpenTrans();

        //            return FindStorge(p_WHID, p_SectionID, p_SBitID, p_CompanyTypeID, p_ItemCode, p_Batch, p_VendorBatch, p_JarNum, p_ColorNum, p_ColorName, p_Needle, p_YarnStatus, p_DtsSO, p_WHTypeID, p_SizeName, sqlTrans);

        //            sqlTrans.CommitTrans();
        //        }
        //        catch (Exception TE)
        //        {
        //            sqlTrans.RollbackTrans();
        //            throw TE;
        //        }
        //    }
        //    catch (BaseException)
        //    {
        //        throw;
        //    }
        //    catch (Exception E)
        //    {
        //        throw new BaseException(E.Message);
        //    }
        //}
        ///// <summary>
        ///// 判断库存表是否存在该记录
        ///// </summary>
        ///// <param name="p_WHID"></param>
        ///// <param name="p_SectionID"></param>
        ///// <param name="p_SBitID"></param>
        ///// <param name="p_ItemCode"></param>
        ///// <param name="p_Batch"></param>
        ///// <param name="p_JarNum"></param>
        ///// <param name="p_ColorNum"></param>
        ///// <param name="sqlTrans"></param>
        ///// <returns>返回ID</returns>
        //public int FindStorge(string p_WHID, string p_SectionID, string p_SBitID, int p_CompanyTypeID, string p_ItemCode, string p_Batch, string p_VendorBatch, string p_JarNum, string p_ColorNum, string p_ColorName, string p_Needle, string p_YarnStatus, string p_DtsSO, int p_WHTypeID, string p_SizeName, IDBTransAccess sqlTrans)
        //{

        //    string sql="SELECT WHCalMethodID FROM WH_WH WHERE WHID="+SysString.ToDBString(p_WHID);
        //    int CalType = (int)EnumWHCalMethod.按编号;//
        //    DataTable dt = sqlTrans.Fill(sql);//获得当前仓库的结算方式
        //    if (dt.Rows.Count != 0)
        //    {
        //        CalType = SysConvert.ToInt32(dt.Rows[0][0].ToString());
        //    }
        //    else
        //    {
        //        CalType = (int)EnumWHCalMethod.按编号客户批号本厂批号;
        //    }
        //    sql="SELECT ID FROM WH_Storge WHERE WHID="+SysString.ToDBString(p_WHID)+" AND SectionID="+SysString.ToDBString(p_SectionID);
        //    sql+=" AND SBitID="+SysString.ToDBString(p_SBitID);
        //    switch (CalType)
        //    {
        //        case (int)EnumWHCalMethod.按编号:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            break;
        //        case (int)EnumWHCalMethod.按编号客户批号:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
        //            break;
        //        case (int)EnumWHCalMethod.按编号本厂批号:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            break;
        //        case (int)EnumWHCalMethod.按编号客户批号本厂批号:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            break;
        //        case (int)EnumWHCalMethod.按编号色号:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            break;
        //        case (int)EnumWHCalMethod.按编号缸号:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            break;
        //        case (int)EnumWHCalMethod.按编号色号缸号:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            break;
        //        case (int)EnumWHCalMethod.按编号客户批号本厂批号色号缸号:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            break;
        //        case (int)EnumWHCalMethod.按编号针型:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND Needle=" + SysString.ToDBString(p_Needle);
        //            break;
        //        case (int)EnumWHCalMethod.按编号色号缸号纱线形态:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.按编号客户批号本厂批号纱线形态:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);                  
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.按编号客户批号本厂批号色号缸号纱线形态:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.按编号客户批号本厂批号订单号纱线形态:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
        //            sql += " AND DtsSO=" + SysString.ToDBString(p_DtsSO);
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.按编号色号缸号定单号纱线形态:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND DtsSO=" + SysString.ToDBString(p_DtsSO);
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.按编号客户批号本厂批号色号缸号订单号纱线形态:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND DtsSO=" + SysString.ToDBString(p_DtsSO);
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.按编号色号色名缸号订单号纱线形态:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND DtsSO=" + SysString.ToDBString(p_DtsSO);
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.按编号客户批号本厂批号色号色名缸号订单号纱线形态:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND DtsSO=" + SysString.ToDBString(p_DtsSO);
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.按编号色号色名缸号纱线形态:
        //            sql += " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND ISNULL(DesignNO,'')=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(p_ColorName);
        //            sql += " AND ISNULL(JarNum,'')=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND ISNULL(YarnStatus,'')=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.按编号色号色名缸号:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            break;
        //        case (int)EnumWHCalMethod.按编号针型色号色名:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //            sql += " AND Needle=" + SysString.ToDBString(p_Needle);
        //            break;


        //    }
        //    DataTable dtlog = sqlTrans.Fill(sql);
        //    if (dtlog.Rows.Count > 0)
        //    {
        //        return SysConvert.ToInt32(dtlog.Rows[0][0].ToString());
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        #endregion

        #region 染色单找库存
        public int[] FindStorges(string p_WHID, string p_SectionID, string p_SBitID, int p_CompanyTypeID, string p_ItemCode, string p_Batch, string p_VendorBatch, string p_JarNum, string p_ColorNum, string p_ColorName, string p_Needle, string p_YarnStatus, string p_DtsSO, int p_WHTypeID, string p_SizeName, string p_SSN, string p_DSN, string p_Unit)
        {
            int[] iFindStorges = new int[0];
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    //return FindStorges(p_WHID, p_SectionID, p_SBitID, p_CompanyTypeID, p_ItemCode, p_Batch, p_VendorBatch, p_JarNum, p_ColorNum, p_ColorName, p_Needle, p_YarnStatus, p_DtsSO, p_WHTypeID, p_SizeName, p_SSN, p_DSN, sqlTrans);
                    iFindStorges = FindStorges(p_WHID, p_SectionID, p_SBitID, p_CompanyTypeID, p_ItemCode, p_Batch, p_VendorBatch, p_JarNum, p_ColorNum, p_ColorName, p_Needle, p_YarnStatus, p_DtsSO, p_WHTypeID, p_SizeName, p_SSN, p_DSN, p_Unit, sqlTrans);

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
            return iFindStorges;
        }
        /// <summary>
        /// 判断库存表是否存在该记录
        /// </summary>
        /// <param name="p_WHID"></param>
        /// <param name="p_SectionID"></param>
        /// <param name="p_SBitID"></param>
        /// <param name="p_ItemCode"></param>
        /// <param name="p_Batch"></param>
        /// <param name="p_JarNum"></param>
        /// <param name="p_ColorNum"></param>
        /// <param name="sqlTrans"></param>
        /// <returns>返回ID</returns>
        public int[] FindStorges(string p_WHID, string p_SectionID, string p_SBitID, int p_CompanyTypeID, string p_ItemCode, string p_Batch, string p_VendorBatch, string p_JarNum, string p_ColorNum, string p_ColorName, string p_Needle, string p_YarnStatus, string p_DtsSO, int p_WHTypeID, string p_SizeName, string p_SSN, string p_DSN, string p_Unit, IDBTransAccess sqlTrans)
        {
            string conditionstr = string.Empty;
            string sql = "SELECT WHCalMethodName,FieldName FROM UV1_Enum_WHType WHERE ID=" + SysString.ToDBString(p_WHTypeID);//获得仓库结算类型字段
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                conditionstr = SysConvert.ToString(dt.Rows[0]["FieldName"]);
            }


            int WHJKFlag = 0;
            string sqlWH = "Select ISJK FROM WH_WH WHERE WHID=" + SysString.ToDBString(SysConvert.ToString(p_WHID));
            DataTable dtWH = sqlTrans.Fill(sqlWH);
            if (dtWH.Rows.Count != 0)
            {
                WHJKFlag = SysConvert.ToInt32(dtWH.Rows[0]["ISJK"]);
            }

            if (WHJKFlag == 1)//寄库---染厂库默认的是根据物料、公司别、系列号、库结算
            {
                conditionstr = "ItemCode+CompanyTypeID";
            }


            sql = "SELECT ID FROM WH_Storge WHERE 1=1";//查找库存ID
            int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
            if (conditionstr != string.Empty)
            {
                string[] FieldName = conditionstr.Split('+');
                for (int i = 0; i < FieldName.Length; i++)
                {
                    string sqlFieldName = "SELECT ID FROM Enum_WHCalMethodFieldName WHERE Name=" + SysString.ToDBString(FieldName[i]);//找到库存结算字段对应的ID
                    DataTable dtFieldName = sqlTrans.Fill(sqlFieldName);
                    if (dtFieldName.Rows.Count != 0 && dtFieldName.Rows[0]["ID"].ToString() != "")
                    {
                        CalFieldName = SysConvert.ToInt32(dtFieldName.Rows[0]["ID"]);
                    }


                    sql += " AND WHID=" + SysString.ToDBString(p_WHID);
                    //sql += " AND SectionID=" + SysString.ToDBString(p_SectionID);----2010.3.9注释掉
                    //sql += " AND SBitID=" + SysString.ToDBString(p_SBitID);

                    switch (CalFieldName)
                    {
                        case (int)WHCalMethodFieldName.ItemCode://编码
                            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
                            break;
                        case (int)WHCalMethodFieldName.WHID://库
                            sql += " AND WHID=" + SysString.ToDBString(p_WHID);
                            break;
                        case (int)WHCalMethodFieldName.SectionID://区
                            sql += " AND SectionID=" + SysString.ToDBString(p_SectionID);
                            break;
                        case (int)WHCalMethodFieldName.SBitID://位
                            sql += " AND SBitID=" + SysString.ToDBString(p_SBitID);
                            break;

                        case (int)WHCalMethodFieldName.Batch://本厂批号
                            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
                            break;

                        case (int)WHCalMethodFieldName.JarNum://缸号
                            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
                            break;
                        case (int)WHCalMethodFieldName.ColorNum://色号
                            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
                            break;
                        case (int)WHCalMethodFieldName.ColorName://色名
                            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
                            break;

                        case (int)WHCalMethodFieldName.Unit:   //批号
                            sql += " AND Unit=" + SysString.ToDBString(p_Unit);
                            break;

                        case (int)WHCalMethodFieldName.WHTypeID://仓库类型
                            sql += " AND WHTypeID=" + SysString.ToDBString(p_WHTypeID);
                            break;
                        case (int)WHCalMethodFieldName.SizeName://尺码
                            sql += " AND SizeName=" + SysString.ToDBString(p_SizeName);
                            break;

                        case (int)WHCalMethodFieldName.VendorBatch:  //客户批号
                            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
                            break;

                    }
                }
            }
            int[] outinta = new int[0];
            DataTable dtlog = sqlTrans.Fill(sql);
            if (dtlog.Rows.Count > 0)
            {
                outinta = new int[dtlog.Rows.Count];
                for (int i = 0; i < dtlog.Rows.Count; i++)
                {
                    outinta[i] = SysConvert.ToInt32(dtlog.Rows[i]["ID"]);
                }
            }

            return outinta;
        }
        #endregion

        #region 移库审核
        /// <summary>
        /// 移库审核
        /// </summary>
        /// <param name="p_FormID">单据ID</param>
        /// <param name="p_Type">0/1:弃审/审核</param>
        public void RSubmitMove(int p_FormTopType, IOForm p_Entity, IOFormDts p_EntityDts, int p_Type, IDBTransAccess sqlTrans)
        {
            try
            {
                Storge entitystdtsSource = new Storge(sqlTrans);//源库存
                Storge entitystdts = new Storge(sqlTrans);//目的库存

                //int StorgeIDS = FindStorge(p_EntityDts.WHID, p_EntityDts.SectionID, p_EntityDts.SBitID, p_EntityDts.ItemCode, p_EntityDts.Batch, p_EntityDts.VendorBatch, p_EntityDts.JarNum, p_EntityDts.ColorNum, p_EntityDts.ColorName, p_EntityDts.Needle, p_EntityDts.YarnStatus, p_EntityDts.DtsSO, sqlTrans);//源库存
                //int StorgeIDT = FindStorge(p_EntityDts.FromWHID, p_EntityDts.FromSectionID, p_EntityDts.FromSBitID, p_EntityDts.ItemCode, p_EntityDts.Batch, p_EntityDts.VendorBatch, p_EntityDts.JarNum, p_EntityDts.ColorNum, p_EntityDts.ColorName, p_EntityDts.Needle, p_EntityDts.YarnStatus, p_EntityDts.DtsSO, sqlTrans);//目的库存


                int StorgeIDS = FindStorge(p_EntityDts, (int)EnumWHMove.移动库, sqlTrans); //FindStorge(p_EntityDts.WHID, p_EntityDts.SectionID, p_EntityDts.SBitID, p_EntityDts.CompanyTypeID, p_EntityDts.ItemCode, p_EntityDts.Batch, p_EntityDts.VendorBatch, p_EntityDts.JarNum, p_EntityDts.ColorNum, p_EntityDts.ColorName, p_EntityDts.Needle, p_EntityDts.YarnStatus, p_EntityDts.DtsSO, p_EntityDts.WHTypeID, p_EntityDts.SizeName, sqlTrans);
                int StorgeIDT = FindStorge(p_EntityDts, (int)EnumWHMove.目的库, sqlTrans);  //FindStorge(p_EntityDts.FromWHID, p_EntityDts.FromSectionID, p_EntityDts.FromSBitID, p_EntityDts.CompanyTypeID, p_EntityDts.ItemCode, p_EntityDts.Batch, p_EntityDts.VendorBatch, p_EntityDts.JarNum, p_EntityDts.ColorNum, p_EntityDts.ColorName, p_EntityDts.Needle, p_EntityDts.YarnStatus, p_EntityDts.DtsSO, p_EntityDts.WHTypeID, p_EntityDts.SizeName, sqlTrans);



                bool p_NegativeFlag = false;//负数标志
                bool p_ZeroExitFlag = false;//为0标志

                bool p_NegativeFlagT = false;//负数标志
                bool p_ZeroExitFlagT = false;//为0标志

                WH entityWH = new WH(sqlTrans);
                entityWH.WHID = p_EntityDts.WHID;
                entityWH.SelectByID();

                entityWH.WHID = p_EntityDts.FromWHID;
                entityWH.SelectByID();




                if (StorgeIDT != 0)//目的库存
                {
                    entitystdts.ID = StorgeIDT;
                    entitystdts.SelectByID();
                }


                if (StorgeIDS != 0)//源库存
                {
                    entitystdtsSource.ID = StorgeIDS;
                    entitystdtsSource.SelectByID();
                }
                else
                {

                    entitystdtsSource.DutyOPID = entitystdts.DutyOPID;
                    entitystdtsSource.WHID = p_EntityDts.WHID;
                    entitystdtsSource.SectionID = p_EntityDts.SectionID;
                    entitystdtsSource.SBitID = p_EntityDts.SBitID;
                    entitystdtsSource.VendorID = p_EntityDts.DtsVendorID;
                    entitystdtsSource.ItemCode = p_EntityDts.ItemCode;
                    // entitystdtsSource.ItemModel = p_EntityDts.ItemModel;
                    entitystdtsSource.ItemName = p_EntityDts.ItemName;
                    entitystdtsSource.ItemStd = p_EntityDts.ItemStd;
                    entitystdtsSource.Batch = p_EntityDts.Batch;
                    entitystdtsSource.VendorBatch = p_EntityDts.VendorBatch;
                    entitystdtsSource.Unit = p_EntityDts.Unit;
                    entitystdtsSource.SinglePrice = p_EntityDts.SinglePrice;
                    entitystdtsSource.ColorNum = p_EntityDts.ColorNum;
                    entitystdtsSource.ColorName = p_EntityDts.ColorName;
                    entitystdtsSource.JarNum = p_EntityDts.JarNum;
                    entitystdtsSource.TubeGW = p_EntityDts.TubeGW;
                    entitystdtsSource.Remark = p_EntityDts.Remark;
                    entitystdtsSource.VColorNum = p_EntityDts.VColorNum;
                    entitystdtsSource.VColorName = p_EntityDts.VColorName;
                    entitystdtsSource.VItemCode = p_EntityDts.VItemCode;
                    entitystdtsSource.GoodsCode = p_EntityDts.GoodsCode;
                    entitystdtsSource.GoodsLevel = p_EntityDts.GoodsLevel;
                    entitystdtsSource.MWidth = p_EntityDts.MWidth;
                    entitystdtsSource.MWeight = p_EntityDts.MWeight;
                    entitystdtsSource.WeightUnit = p_EntityDts.WeightUnit;
                    entitystdtsSource.MLType = p_EntityDts.MLType;   //用于区分成品面料和坯布

                    entitystdtsSource.VendorID = p_EntityDts.DtsVendorID;//
                    entitystdtsSource.SO = p_EntityDts.DtsSO;//单据号
                    entitystdtsSource.DutyOPID = p_EntityDts.DtsSaleOPID;//业务员
                    entitystdtsSource.OrderFormNo = p_EntityDts.DtsOrderFormNo;//合同号

                }



                if (StorgeIDT == 0)//目的库存,找不到历史记录
                {

                    entitystdts.DutyOPID = entitystdtsSource.DutyOPID;
                    entitystdts.WHID = p_EntityDts.ToWHID;
                    entitystdts.SectionID = p_EntityDts.ToSectionID;
                    entitystdts.SBitID = p_EntityDts.ToSBitID;
                    entitystdts.VendorID = p_EntityDts.DtsVendorID;
                    entitystdts.ItemCode = p_EntityDts.ItemCode;
                    entitystdts.ItemName = p_EntityDts.ItemName;
                    entitystdts.ItemStd = p_EntityDts.ItemStd;
                    entitystdts.Batch = p_EntityDts.Batch;
                    entitystdts.VendorBatch = p_EntityDts.VendorBatch;
                    entitystdts.Twist = p_EntityDts.Twist;
                    entitystdts.Unit = p_EntityDts.Unit;
                    entitystdts.SinglePrice = p_EntityDts.SinglePrice;
                    entitystdts.ColorNum = p_EntityDts.ColorNum;
                    entitystdts.ColorName = p_EntityDts.ColorName;
                    entitystdts.JarNum = p_EntityDts.JarNum;

                    entitystdts.TubeGW = p_EntityDts.TubeGW;
                    entitystdts.Remark = p_EntityDts.Remark;
                    entitystdts.VColorNum = p_EntityDts.VColorNum;
                    entitystdts.VColorName = p_EntityDts.VColorName;
                    entitystdts.VItemCode = p_EntityDts.VItemCode;
                    entitystdts.GoodsCode = p_EntityDts.GoodsCode;
                    entitystdts.GoodsLevel = p_EntityDts.GoodsLevel;
                    entitystdts.MWidth = p_EntityDts.MWidth;
                    entitystdts.MWeight = p_EntityDts.MWeight;
                    entitystdts.WeightUnit = p_EntityDts.WeightUnit;

                    entitystdts.VendorID = p_EntityDts.DtsVendorID;//
                    entitystdts.SO = p_EntityDts.DtsSO;//单据号
                    entitystdts.DutyOPID = p_EntityDts.DtsSaleOPID;//业务员
                    entitystdts.OrderFormNo = p_EntityDts.DtsOrderFormNo;//合同号

                    entitystdts.MLType = p_EntityDts.MLType;        //用于区分成品面料和坯布


                }
                //int AmountTypeID = 0;
                switch (p_FormTopType)
                {
                    case (int)WHFormList.移库://移库
                        if (p_Type == (int)ConfirmFlag.未提交)//弃审
                        {
                            entitystdts.PieceQty -= p_EntityDts.PieceQty;//实际数量

                            entitystdts.Qty -= p_EntityDts.Qty;//实际数量
                            //entitystdts.FreeQty -= p_EntityDts.Qty;//可用数量
                            entitystdts.Weight -= p_EntityDts.Weight;//实际数量

                            entitystdtsSource.PieceQty += p_EntityDts.PieceQty;//实际数量

                            entitystdtsSource.Qty += p_EntityDts.Qty;//实际数量
                            entitystdtsSource.Weight += p_EntityDts.Weight;//实际数量
                            if (p_EntityDts.Unit == "RMB/KG")
                            {
                                entitystdts.Amount -= p_EntityDts.Weight * p_EntityDts.SinglePrice;
                                entitystdtsSource.Amount += p_EntityDts.Weight * p_EntityDts.SinglePrice;
                            }
                            if (p_EntityDts.Unit == "RMB/M")
                            {
                                entitystdts.Amount -= p_EntityDts.Qty * p_EntityDts.SinglePrice;
                                entitystdtsSource.Amount += p_EntityDts.Qty * p_EntityDts.SinglePrice;
                            }
                        }
                        else
                        {
                            entitystdts.PieceQty += p_EntityDts.PieceQty;//实际数量	
                            entitystdts.Qty += p_EntityDts.Qty;//实际数量	
                            entitystdts.Weight += p_EntityDts.Weight;//实际数量								

                            entitystdtsSource.PieceQty -= p_EntityDts.PieceQty;//实际数量
                            entitystdtsSource.Qty -= p_EntityDts.Qty;//实际数量
                            entitystdtsSource.Weight -= p_EntityDts.Weight;//实际数量

                            if (p_EntityDts.Unit == "RMB/KG")
                            {
                                entitystdtsSource.Amount -= p_EntityDts.Weight * p_EntityDts.SinglePrice;
                                entitystdts.Amount += p_EntityDts.Weight * p_EntityDts.SinglePrice;
                            }
                            if (p_EntityDts.Unit == "RMB/M")
                            {
                                entitystdtsSource.Amount -= p_EntityDts.Qty * p_EntityDts.SinglePrice;
                                entitystdts.Amount += p_EntityDts.Qty * p_EntityDts.SinglePrice;
                            }
                        }
                        break;
                }
                if (!p_NegativeFlag)//如果不允许负数则校验
                {
                    if (entitystdtsSource.Qty < -0.001m || entitystdtsSource.Weight < -0.001m)
                    {
                        throw new Exception("操作后库存数量低于0，不能操作，产品编码：" + entitystdts.ItemCode + " 色号：" + entitystdts.ColorNum + " 数量：" + entitystdtsSource.Qty.ToString() + " 目的数量：" + entitystdts.Qty.ToString() + " 公斤数：" + entitystdtsSource.Weight.ToString() + " 目的公斤数：" + entitystdts.Weight.ToString());
                    }
                }
                if (!p_NegativeFlagT)//如果不允许负数则校验
                {
                    if (entitystdts.Qty < -0.001m || entitystdtsSource.Weight < -0.001m)
                    {
                        throw new Exception("操作后库存数量低于0，不能操作，产品编码：" + entitystdts.ItemCode + " 色号：" + entitystdts.ColorNum + " 数量：" + entitystdtsSource.Qty.ToString() + " 目的数量：" + entitystdts.Qty.ToString() + " 公斤数：" + entitystdtsSource.Weight.ToString() + " 目的公斤数：" + entitystdts.Weight.ToString());
                    }
                }


                this.RSaveEntity(entitystdtsSource, p_ZeroExitFlag, sqlTrans);
                this.RSaveEntity(entitystdts, p_ZeroExitFlagT, sqlTrans);
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

        #region 盘点审核
        /// <summary>
        /// 盘点审核
        /// </summary>
        /// <param name="p_FormID">单据ID</param>
        /// <param name="p_Type">0/1:弃审/审核</param>
        public void RSubmitCheck(int p_FormTopType, IOForm p_Entity, IOFormDts p_EntityDts, int p_Type, IDBTransAccess sqlTrans)
        {
            try
            {
                Storge entitystdts = new Storge(sqlTrans);

                //int StorgeID = 0;
                bool p_NegativeFlag = false;//负数标志
                bool p_ZeroExitFlag = false;//为0标志

                //WH entityWH = new WH(sqlTrans);
                //entityWH.WHID = p_EntityDts.WHID;
                //entityWH.SelectByID();
                WH entityWH = new WH(sqlTrans);
                string sqlWH = "Select ID FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_EntityDts.WHID);
                DataTable dtWH = sqlTrans.Fill(sqlWH);
                if (dtWH.Rows.Count != 0)
                {
                    entityWH.ID = SysConvert.ToInt32(dtWH.Rows[0]["ID"]);
                    entityWH.SelectByID();
                }
                //if (entityWH.NegativeFlag == (int)YesOrNo.Yes)
                //{
                //    p_NegativeFlag = true;
                //}
                //if (entityWH.ZeroExitFlag == (int)YesOrNo.Yes)
                //{
                //    p_ZeroExitFlag = true;
                //}

                //int StorgeIDT = FindStorge(p_EntityDts.WHID, p_EntityDts.SectionID, p_EntityDts.SBitID, p_EntityDts.ItemCode, p_EntityDts.Batch, p_EntityDts.VendorBatch, p_EntityDts.JarNum, p_EntityDts.ColorNum, p_EntityDts.ColorName, p_EntityDts.Needle, p_EntityDts.YarnStatus, p_EntityDts.DtsSO, sqlTrans);

                int StorgeIDT = FindStorge(p_EntityDts, sqlTrans); //FindStorge(p_EntityDts.WHID, p_EntityDts.SectionID, p_EntityDts.SBitID, p_EntityDts.CompanyTypeID, p_EntityDts.ItemCode, p_EntityDts.Batch, p_EntityDts.VendorBatch, p_EntityDts.JarNum, p_EntityDts.ColorNum, p_EntityDts.ColorName, p_EntityDts.Needle, p_EntityDts.YarnStatus, p_EntityDts.DtsSO, p_EntityDts.WHTypeID, p_EntityDts.SizeName, sqlTrans);



                if (StorgeIDT != 0)//找到历史记录
                {
                    entitystdts.ID = StorgeIDT;
                    entitystdts.SelectByID();
                }
                else//找不到历史记录
                {
                    //entitystdts.InDate = p_Entity.FormDate;
                    entitystdts.WHID = p_Entity.WHID;
                    entitystdts.SectionID = p_EntityDts.SectionID;
                    entitystdts.SBitID = p_EntityDts.SBitID;
                    entitystdts.ItemCode = p_EntityDts.ItemCode;
                    entitystdts.ItemName = p_EntityDts.ItemName;
                    entitystdts.ItemStd = p_EntityDts.ItemStd;
                    //entitystdts.ItemModel = p_EntityDts.ItemModel;
                    entitystdts.Batch = p_EntityDts.Batch;
                    entitystdts.VendorBatch = p_EntityDts.VendorBatch;
                    entitystdts.ColorNum = p_EntityDts.ColorNum;
                    entitystdts.ColorName = p_EntityDts.ColorName;
                    entitystdts.JarNo = p_EntityDts.JarNo;
                    entitystdts.JarNum = p_EntityDts.JarNum;
                    entitystdts.Twist = p_EntityDts.Twist;
                    entitystdts.Needle = p_EntityDts.Needle;
                    entitystdts.Unit = p_EntityDts.Unit;
                    entitystdts.SinglePrice = p_EntityDts.SinglePrice;
                    entitystdts.VendorID = p_EntityDts.DtsVendorID;
                    entitystdts.TubeGW = p_EntityDts.TubeGW;
                    entitystdts.Remark = p_EntityDts.Remark;
                    entitystdts.VColorNum = p_EntityDts.VColorNum;
                    entitystdts.VColorName = p_EntityDts.VColorName;
                    entitystdts.VItemCode = p_EntityDts.VItemCode;
                    entitystdts.GoodsCode = p_EntityDts.GoodsCode;
                    entitystdts.GoodsLevel = p_EntityDts.GoodsLevel;
                    entitystdts.MWidth = p_EntityDts.MWidth;
                    entitystdts.MWeight = p_EntityDts.MWeight;
                    entitystdts.WeightUnit = p_EntityDts.WeightUnit;

                    entitystdts.VendorID = p_EntityDts.DtsVendorID;//
                    entitystdts.SO = p_EntityDts.DtsSO;//单据号
                    entitystdts.DutyOPID = p_EntityDts.DtsSaleOPID;//业务员
                    entitystdts.OrderFormNo = p_EntityDts.DtsOrderFormNo;//合同号

                    entitystdts.MLType = p_EntityDts.MLType;    //用于区分成品面料和坯布

                }

                switch (p_FormTopType)
                {
                    case (int)WHFormList.盘点:
                        if (p_Type == (int)ConfirmFlag.未提交)//弃审
                        {
                            entitystdts.Qty += (p_EntityDts.Qty - p_EntityDts.MoveQty);//实际数量
                            entitystdts.Weight += (p_EntityDts.Weight - p_EntityDts.MoveWeight);//实际数量
                            entitystdts.PieceQty += (p_EntityDts.PieceQty - p_EntityDts.MovePieceQty);//实际数量
                            if (entitystdts.Unit == "RMB/KG")
                            {
                                entitystdts.Amount = entitystdts.Weight * entitystdts.SinglePrice;
                            }
                            if (entitystdts.Unit == "RMB/M")
                            {
                                entitystdts.Amount = entitystdts.Qty * entitystdts.SinglePrice;
                            }
                            //if (p_Entity.SubType == 801)
                            //{
                            //    entitystdts.PDFlag = 0;
                            //    entitystdts.PDDate = SysConvert.ToDateTime(DBNull.Value);
                            //}


                        }
                        else//审核
                        {
                            entitystdts.Qty -= (p_EntityDts.Qty - p_EntityDts.MoveQty);//实际数量
                            entitystdts.Weight -= (p_EntityDts.Weight - p_EntityDts.MoveWeight);//实际数量
                            entitystdts.PieceQty -= (p_EntityDts.PieceQty - p_EntityDts.MovePieceQty);//实际数量
                            if (entitystdts.Unit == "RMB/KG")
                            {
                                entitystdts.Amount = entitystdts.Weight * entitystdts.SinglePrice;
                            }
                            if (entitystdts.Unit == "RMB/M")
                            {
                                entitystdts.Amount = entitystdts.Qty * entitystdts.SinglePrice;
                            }
                        }
                        break;
                }

                this.RSaveEntity(entitystdts, p_ZeroExitFlag, sqlTrans);
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

        #region 更新库存数据
        /// <summary>
        /// 更新库存
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void UpdateStorge(int p_StorgeID, float P_LockQty, bool p_Flag)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.UpdateStorge(p_StorgeID, P_LockQty, p_Flag, sqlTrans);

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
        /// 更新库存
        /// </summary>
        /// <param name="p_Storge">库存ID</param>
        /// <param name="P_LockQty">锁定数量</param>
        public void UpdateStorge(int p_StorgeID, float P_LockQty, bool p_Flag, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            if (p_Flag)
            {
                sql = "UPDATE WH_Storge SET LOCKQTY=ISNULL(LOCKQTY,0)+" + P_LockQty + ", FREEQTY=ISNULL(FREEQTY,0)-" + P_LockQty + " WHERE ID=" + SysString.ToDBString(p_StorgeID);
            }
            else
            {
                sql = "UPDATE WH_Storge SET LOCKQTY=ISNULL(LOCKQTY,0)-" + P_LockQty + ", FREEQTY=ISNULL(FREEQTY,0)+" + P_LockQty + " WHERE ID=" + SysString.ToDBString(p_StorgeID);
            }
            sqlTrans.ExecuteNonQuery(sql);
        }
        #endregion

        #region 更新备注内容
        /// <summary>
        /// 更新内容
        /// </summary>
        /// <param name="p_ID">ID号</param>
        /// <param name="p_Field">字段名</param>
        /// <param name="p_value">值</param>
        public void RUpdateSBitRemark(int p_ID, string p_Field, string p_value)
        {
            try
            {
                string sql = "UPDATE  WH_STORGE SET " + p_Field + "=" + SysString.ToDBString(p_value) + " WHERE ID=" + SysString.ToDBString(p_ID);
                SysUtils.ExecuteNonQuery(sql);
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }
        #endregion

        #region 校验是否存在出入库操作、盘点库存
        /// <summary>
        ///  校验是否存在出入库操作
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="state">状态：0非期初，1期初</param>
        /// <returns></returns>
        public bool CheckIOForm(Storge entity, int state)
        {
            string sql = "SELECT * FROM UV1_WH_IOFormDts WHERE 1=1";

            sql += " AND isnull(ColorNum,'')=" + SysString.ToDBString(entity.ColorNum);
            sql += " AND isnull(ColorName,'')=" + SysString.ToDBString(entity.ColorName);
            sql += " AND isnull(Batch,'')=" + SysString.ToDBString(entity.Batch);
            sql += " AND isnull(VendorBatch,'')=" + SysString.ToDBString(entity.VendorBatch);
            sql += " AND isnull(JarNum,'')=" + SysString.ToDBString(entity.JarNum);
            //sql += " AND isnull(SizeName,'')=" + SysString.ToDBString(entity.SizeName);
            sql += " AND isnull(ItemCode,'')=" + SysString.ToDBString(entity.ItemCode);
            //sql += " AND isnull(YarnStatus,'')=" + SysString.ToDBString(entity.YarnStatus);
            sql += " AND isnull(WHID,'')=" + SysString.ToDBString(entity.WHID);
            if (state == 0)
            {
                sql += " AND HeadType<>'9'";

                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                sql += " AND HeadType='9'";
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }

        }
        /// <summary>
        /// 盘点删除库存
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteIOForm(Storge entity)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    string sql = "Delete From WH_STORGE  WHERE ID=" + SysString.ToDBString(entity.ID);
                    sqlTrans.ExecuteNonQuery(sql);

                    sql = "Delete From  WH_IOFormDts WHERE 1=1";

                    sql += " AND isnull(ColorNum,'')=" + SysString.ToDBString(entity.ColorNum);
                    sql += " AND isnull(ColorName,'')=" + SysString.ToDBString(entity.ColorName);
                    sql += " AND isnull(Batch,'')=" + SysString.ToDBString(entity.Batch);
                    sql += " AND isnull(VendorBatch,'')=" + SysString.ToDBString(entity.VendorBatch);
                    sql += " AND isnull(JarNum,'')=" + SysString.ToDBString(entity.JarNum);
                    //sql += " AND isnull(SizeName,'')=" + SysString.ToDBString(entity.SizeName);
                    sql += " AND isnull(ItemCode,'')=" + SysString.ToDBString(entity.ItemCode);
                    //sql += " AND isnull(YarnStatus,'')=" + SysString.ToDBString(entity.YarnStatus);
                    sql += " AND isnull(WHID,'')=" + SysString.ToDBString(entity.WHID);

                    sqlTrans.ExecuteNonQuery(sql);


                    sql = "Delete From  WH_IOFormLedger WHERE 1=1";

                    sql += " AND isnull(ColorNum,'')=" + SysString.ToDBString(entity.ColorNum);
                    sql += " AND isnull(ColorName,'')=" + SysString.ToDBString(entity.ColorName);
                    sql += " AND isnull(Batch,'')=" + SysString.ToDBString(entity.Batch);
                    sql += " AND isnull(VendorBatch,'')=" + SysString.ToDBString(entity.VendorBatch);
                    sql += " AND isnull(JarNum,'')=" + SysString.ToDBString(entity.JarNum);
                    //sql += " AND isnull(SizeName,'')=" + SysString.ToDBString(entity.SizeName);
                    sql += " AND isnull(ItemCode,'')=" + SysString.ToDBString(entity.ItemCode);
                    //sql += " AND isnull(YarnStatus,'')=" + SysString.ToDBString(entity.YarnStatus);
                    sql += " AND isnull(WHID,'')=" + SysString.ToDBString(entity.WHID);

                    sqlTrans.ExecuteNonQuery(sql);

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
        #endregion

        #region 删除库存0的数据--没有交易记录的

        /// <summary>
        ///  校验是否存在出入库操作
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="state">状态：0非期初，1期初</param>
        /// <returns></returns>
        public bool CheckIOForm(Storge entity)
        {
            string sql = "SELECT * FROM UV1_WH_IOFormDts WHERE 1=1";

            sql += " AND isnull(ColorNum,'')=" + SysString.ToDBString(entity.ColorNum);
            sql += " AND isnull(ColorName,'')=" + SysString.ToDBString(entity.ColorName);
            sql += " AND isnull(Batch,'')=" + SysString.ToDBString(entity.Batch);
            sql += " AND isnull(VendorBatch,'')=" + SysString.ToDBString(entity.VendorBatch);
            sql += " AND isnull(JarNum,'')=" + SysString.ToDBString(entity.JarNum);
            //sql += " AND isnull(SizeName,'')=" + SysString.ToDBString(entity.SizeName);
            sql += " AND isnull(ItemCode,'')=" + SysString.ToDBString(entity.ItemCode);
            //sql += " AND isnull(YarnStatus,'')=" + SysString.ToDBString(entity.YarnStatus);
            //sql += " AND isnull(WHID,'')=" + SysString.ToDBString(entity.WHID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除库存0的数据--没有交易记录的
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteZeroIOForm(Storge entity)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();
                    string sql = "Delete From WH_STORGE  WHERE ID =" + entity.ID;
                    sqlTrans.ExecuteNonQuery(sql);

                    sql = "Delete From  WH_IOFormLedger WHERE 1=1";

                    sql += " AND isnull(ColorNum,'')=" + SysString.ToDBString(entity.ColorNum);
                    sql += " AND isnull(ColorName,'')=" + SysString.ToDBString(entity.ColorName);
                    sql += " AND isnull(Batch,'')=" + SysString.ToDBString(entity.Batch);
                    sql += " AND isnull(VendorBatch,'')=" + SysString.ToDBString(entity.VendorBatch);
                    sql += " AND isnull(JarNum,'')=" + SysString.ToDBString(entity.JarNum);
                    //sql += " AND isnull(SizeName,'')=" + SysString.ToDBString(entity.SizeName);
                    sql += " AND isnull(ItemCode,'')=" + SysString.ToDBString(entity.ItemCode);
                    //sql += " AND isnull(YarnStatus,'')=" + SysString.ToDBString(entity.YarnStatus);
                    sql += " AND isnull(WHID,'')=" + SysString.ToDBString(entity.WHID);

                    sqlTrans.ExecuteNonQuery(sql);

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
        #endregion

        #region 处理实收数  zhoufc20111221--MLTERP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void RDealColorInQty(int p_ID, IOForm p_Entity, IOFormDts p_EntityDts, IOFormDts p_NewEntityDts, IDBTransAccess sqlTrans)
        {
            try
            {
                //Storge entityst = new Storge(sqlTrans);//出入库结算
                //int StorgeID = 0;
                //bool p_NegativeFlag = false;//负数标志
                //bool p_ZeroExitFlag = false;//为0标志
                //int p_ISJK = 0;//寄库标志

                //WH entityWH = new WH(sqlTrans);
                //string sqlWH = "Select ID,ISJK FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_EntityDts.WHID);
                //DataTable dtWH = sqlTrans.Fill(sqlWH);
                //if (dtWH.Rows.Count != 0)
                //{
                //    entityWH.ID = SysConvert.ToInt32(dtWH.Rows[0]["ID"]);
                //    entityWH.SelectByID();

                //    p_ISJK = SysConvert.ToInt32(dtWH.Rows[0]["ISJK"]);//寄库
                //}
                ////if (entityWH.NegativeFlag == (int)YesOrNo.Yes)
                ////{
                ////    p_NegativeFlag = true;
                ////}
                ////if (entityWH.ZeroExitFlag == (int)YesOrNo.Yes)
                ////{
                ////    p_ZeroExitFlag = true;
                ////}


                //StorgeID = FindStorge(p_EntityDts.WHID, p_EntityDts.SectionID, p_EntityDts.SBitID, p_EntityDts.CompanyTypeID, p_EntityDts.ItemCode, p_EntityDts.Batch, p_EntityDts.VendorBatch, p_EntityDts.JarNum, p_EntityDts.ColorNum, p_EntityDts.ColorName, p_EntityDts.Needle, p_EntityDts.YarnStatus, p_EntityDts.DtsSO, p_EntityDts.WHTypeID, p_EntityDts.SizeName, sqlTrans);
                //if (StorgeID != 0)//找到历史记录
                //{
                //    entityst.ID = StorgeID;
                //    entityst.SelectByID();

                //}
                //else//找不到历史记录
                //{

                //    entityst.DutyOPID = p_Entity.DutyOP;
                //    entityst.WHID = p_Entity.WHID;
                //    entityst.SectionID = p_EntityDts.SectionID;
                //    entityst.SBitID = p_EntityDts.SBitID;
                //    entityst.VendorID = p_EntityDts.DtsVendorID;


                //    entityst.ItemCode = p_EntityDts.ItemCode;
                //    entityst.ItemName = p_EntityDts.ItemName;
                //    entityst.ItemStd = p_EntityDts.ItemStd;
                //    if (p_ISJK == 0)//非寄库、也就是非染厂库的
                //    {


                //        entityst.Batch = p_EntityDts.Batch;
                //        entityst.VendorBatch = p_EntityDts.VendorBatch;
                //        entityst.ColorNum = p_EntityDts.ColorNum;
                //        entityst.ColorName = p_EntityDts.ColorName;
                //        entityst.JarNo = p_EntityDts.JarNo;
                //        entityst.JarNum = p_EntityDts.JarNum;
                //        entityst.Twist = p_EntityDts.Twist;
                //        entityst.Needle = p_EntityDts.Needle;

                //    }



                //    entityst.Unit = p_EntityDts.Unit;
                //    entityst.SinglePrice = p_EntityDts.SinglePrice;

                //    entityst.TubeGW = p_EntityDts.TubeGW;
                //    entityst.Remark = p_EntityDts.Remark;

                //}


                //entityst.Qty += p_NewEntityDts.Qty;
                //entityst.FreeQty += p_NewEntityDts.Qty;
                //entityst.Amount += p_NewEntityDts.Qty * p_NewEntityDts.SinglePrice;//计算金额


                //entityst.Qty -= p_EntityDts.Qty;
                //entityst.FreeQty -= p_EntityDts.Qty;
                //entityst.Amount -= p_EntityDts.Qty * p_EntityDts.SinglePrice;//计算金额



                //if (!p_NegativeFlag)//如果不允许负数则校验
                //{
                //    if (entityst.Qty < -0.001m)//库存数量大于0
                //    {
                //        throw new Exception("操作后库存数量低于0，不能操作，编码：" + entityst.ItemCode + " 缸号：" + entityst.JarNum + " 数量：" + entityst.Qty.ToString());
                //    }

                //    if (entityst.FreeQty < -0.001m)//库存可使用数量大于0
                //    {
                //        throw new Exception("操作后库存可使用数量低于0，不能操作，编码：" + entityst.ItemCode + " 缸号：" + entityst.JarNum + " 数量：" + entityst.FreeQty.ToString());
                //    }
                //}
                //this.RSaveEntity(entityst, p_ZeroExitFlag, sqlTrans);

                ////this.RSaveEntity(entityst, p_ZeroExitFlag, sqlTrans);

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

    }
}
