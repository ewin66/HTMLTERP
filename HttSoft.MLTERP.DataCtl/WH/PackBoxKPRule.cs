using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;


namespace HttSoft.MLTERP.DataCtl
{
    /// <summary>
    /// 目的：WH_PackBoxKP实体业务规则类
    /// 作者:陈加海
    /// 创建日期:2012-5-7
    /// </summary>
    public class PackBoxKPRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PackBoxKPRule()
        {
        }

        /// <summary>
        /// 检查将要操作的数据是否符合业务规则
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            PackBoxKP entity = (PackBoxKP)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_PackBoxKP WHERE 1=1";
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
                PackBoxKP entity = (PackBoxKP)p_BE;
                string sql = "SELECT FormNo FROM WH_PackBoxKP WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("单号已存在，请重新生成");
                }
                PackBoxKPCtl control = new PackBoxKPCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WH_PackBoxKP, sqlTrans);
                control.AddNew(entity);
                FormNoControlRule rulest = new FormNoControlRule();
                rulest.RAddSort((int)FormNoControlEnum.开匹单号, sqlTrans);
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
                PackBoxKP entity = (PackBoxKP)p_BE;
                PackBoxKPCtl control = new PackBoxKPCtl(sqlTrans);
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
                PackBoxKP entity = (PackBoxKP)p_BE;
                PackBoxKPCtl control = new PackBoxKPCtl(sqlTrans);
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

        #region 提交处理
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="p_FormID">单据ID</param>
        /// <param name="p_Type">0/1:弃审/审核</param>
        public void RSubmit(int p_FormID, int p_Type)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSubmit(p_FormID, p_Type, sqlTrans);
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
        public void RSubmit(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        {
            try
            {
                int p_TempType = p_Type;//处理状态
                string sql = string.Empty;
                PackBoxKP entity = new PackBoxKP(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//如果相同异常
                {
                    throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
                }


                //开匹数据提交

                PackBoxRule pbrule = new PackBoxRule();
                PackBox pbentitysource = pbrule.RGetEntityByBoxNo(entity.BoxNo, sqlTrans);
                if (pbentitysource.ID != 0)
                {
                    if (pbentitysource.BoxStatusID == (int)EnumBoxStatus.入库)
                    {
                        if (p_Type == (int)YesOrNo.Yes)//开匹操作
                        {
                            if ((pbentitysource.Qty <= entity.TargetQty && pbentitysource.Qty != 0 && entity.TargetQty != 0) || (pbentitysource.Weight <= entity.TargetWeight && pbentitysource.Weight != 0 && entity.TargetWeight != 0) || (pbentitysource.Yard <= entity.TargetYard && pbentitysource.Yard != 0 && entity.TargetYard != 0))
                            {
                                throw new Exception("操作错误，源条码数量或者码数或者公斤数小于等于开匹目标数量或者码数或者公斤数！");
                            }

                            entity.Qty = pbentitysource.Qty;//赋值主表数量，防止调整过数量
                            entity.Weight = pbentitysource.Weight;
                            entity.Yard = pbentitysource.Yard;
                            PackBox pbentity = new PackBox(sqlTrans);//目标箱号实体
                            pbentity.SelectByID();
                            CopyEntityData(pbentitysource, pbentity);
                            pbentity.SourceTypeID = (int)PackBoxSourceType.开匹;
                            pbentity.BoxStatusID = (int)EnumBoxStatus.入库;
                            pbentity.Qty = entity.TargetQty;
                            pbentity.Weight = entity.TargetWeight;
                            pbentity.Yard = entity.Yard;
                            pbentity.SourceBoxNo = pbentitysource.BoxNo;
                            pbrule.RAdd(pbentity, sqlTrans);

                            pbentitysource.Qty = pbentitysource.Qty - pbentity.Qty;//修改源箱号数量
                            pbentitysource.Weight = pbentitysource.Weight - pbentity.Weight;
                            pbentitysource.Yard = pbentitysource.Yard - pbentity.Yard;
                            pbentitysource.KPFlag = (int)YesOrNo.Yes;//修改源箱号开匹标志
                            pbrule.RUpdate(pbentitysource, sqlTrans);
                            entity.TargetBoxNo = pbentity.BoxNo;

                            //插入开匹明细数据
                            PackBoxKPDtsRule dtsRule = new PackBoxKPDtsRule();
                            PackBoxKPDts entitydts1 = new PackBoxKPDts(sqlTrans);
                            entitydts1.MainID = entity.ID;
                            entitydts1.Seq = 1;
                            entitydts1.BoxNo = entity.BoxNo;
                            entitydts1.ColorNO = entity.ColorNO;
                            entitydts1.ColorName = entity.ColorName;
                            entitydts1.SourceQty = pbentitysource.Qty + pbentity.Qty;//主数据更新时把数据删除了
                            entitydts1.SourceWeight = pbentitysource.Weight + pbentity.Weight;//主数据更新时把数据删除了
                            entitydts1.SourceYard = pbentitysource.Yard + pbentity.Yard;//主数据更新时把数据删除了
                            entitydts1.Qty = pbentitysource.Qty;//主数据更新时把数据删除了
                            entitydts1.Weight = pbentitysource.Weight;//主数据更新时把数据删除了
                            entitydts1.Yard = pbentitysource.Yard;//主数据更新时把数据删除了
                            dtsRule.RAdd(entitydts1, sqlTrans);

                            PackBoxKPDts entitydts2 = new PackBoxKPDts(sqlTrans);
                            entitydts2.MainID = entity.ID;
                            entitydts2.Seq = 2;
                            entitydts2.BoxNo = entity.TargetBoxNo;
                            entitydts2.ColorNO = entity.ColorNO;
                            entitydts2.ColorName = entity.ColorName;
                            entitydts2.SourceQty = 0;
                            entitydts2.Qty = entity.TargetQty;
                            entitydts2.Weight = entity.TargetWeight;
                            entitydts2.Yard = entity.TargetYard;
                            dtsRule.RAdd(entitydts2, sqlTrans);
                            #region 查找仓库结算类型
                            string sqlCal = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(pbentity.WHID);//获得仓库结算类型字段
                            DataTable dt = sqlTrans.Fill(sqlCal);
                            string FieldNamestr = string.Empty;
                            if (dt.Rows.Count != 0)
                            {
                                FieldNamestr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
                            }
                            sql = "UPDATE WH_Storge SET PieceQty=PieceQty+1 WHERE 1=1";
                            sql += " AND WHID=" + SysString.ToDBString(pbentity.WHID);
                            sql += " AND SectionID=" + SysString.ToDBString(pbentity.SectionID);
                            sql += " AND SBitID=" + SysString.ToDBString(pbentity.SBitID);
                            int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
                            if (FieldNamestr != string.Empty)
                            {
                                string[] FieldName = FieldNamestr.Split('+');
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
                                        case (int)WHCalMethodFieldName.ItemCode://产品编码
                                            sql += " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(pbentity.ItemCode);
                                            break;
                                        case (int)WHCalMethodFieldName.ColorNum://色号
                                            sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(pbentity.ColorNum);
                                            break;
                                        case (int)WHCalMethodFieldName.ColorName://颜色
                                            sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(pbentity.ColorName);
                                            break;
                                        case (int)WHCalMethodFieldName.Batch:   //批号
                                            sql += " AND ISNULL(Batch,'')=" + SysString.ToDBString(pbentity.Batch);
                                            break;
                                        case (int)WHCalMethodFieldName.VendorBatch:  //客户批号
                                            sql += " AND ISNULL(VendorBatch,'')=" + SysString.ToDBString(pbentity.VendorBatch);
                                            break;
                                        case (int)WHCalMethodFieldName.JarNum:  //缸号
                                            sql += " AND ISNULL(JarNum,'')=" + SysString.ToDBString(pbentity.JarNum);
                                            break;
                                        case (int)WHCalMethodFieldName.MWidth://门幅
                                            sql += " AND ISNULL(MWidth,'')=" + SysString.ToDBString(pbentity.MWidth);
                                            break;
                                        case (int)WHCalMethodFieldName.MWeight://克重
                                            sql += " AND ISNULL(MWeight,'')=" + SysString.ToDBString(pbentity.MWeight);
                                            break;
                                        case (int)WHCalMethodFieldName.DtsOrderFormNo://克重
                                            sql += " AND ISNULL(OrderFormNo,0)=" + SysString.ToDBString(pbentity.OrderFormNo);
                                            break;
                                        default:
                                            throw new Exception("结算异常，结算定义的字段底层未对应：" + CalFieldName + ",请联系管理员");
                                    }
                                }
                            }
                            #endregion
                            sqlTrans.ExecuteNonQuery(sql);

                        }
                        else//撤销开匹操作
                        {
                            PackBox pbentity = pbrule.RGetEntityByBoxNo(entity.TargetBoxNo, sqlTrans);//目标箱号实体
                            if (pbentitysource.ID == 0)
                            {
                                throw new Exception("操作错误，未找到目标条码");
                            }
                            //开始检验是否允许撤销提交
                            if (pbentity.WHID == pbentitysource.WHID && pbentity.SectionID == pbentitysource.SectionID
                                && pbentity.SBitID == pbentitysource.SBitID)
                            {
                            }
                            else//库区有改变
                            {
                                throw new Exception("操作错误，开匹后的条码的移库了，必须撤销删除移库单后再进行移库操作");
                            }
                            #region 判断开匹后的条码有没有再次被开匹
                            sql = "SELECT * FROM WH_PackBox WHERE SourceBoxNo =" + SysString.ToDBString(pbentity.BoxNo);
                            DataTable dtSource = sqlTrans.Fill(sql);
                            if (dtSource.Rows.Count > 0)
                            {
                                throw new Exception("操作错误,开匹后的条码又开过匹，必须撤销该条码的开匹后再进行撤销");
                            }
                            #endregion
                            #region 判断开匹后的条码的状态
                            sql = "SELECT BoxStatusID FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(pbentity.BoxNo);
                            DataTable dtBoxStatus = sqlTrans.Fill(sql);
                            if (dtBoxStatus.Rows.Count != 0)
                            {
                                if (SysConvert.ToInt32(dtBoxStatus.Rows[0]["BoxStatusID"]) != (int)EnumBoxStatus.入库)
                                {
                                    throw new Exception("条码" + pbentity.BoxNo + "状态未处于入库状态，不能撤销");
                                }
                            }
                            #endregion
                            //结束检验是否允许撤销提交
                            //pbrule.RCheckDelete(entity.TargetBoxNo, sqlTrans);//校验是否允许删除
                            pbrule.RDelete(pbentity, sqlTrans);

                            pbentitysource.Qty = pbentitysource.Qty + pbentity.Qty;//修改源箱号数量
                            pbentitysource.Weight = pbentitysource.Weight + pbentity.Weight;
                            pbentitysource.Yard = pbentitysource.Yard + pbentity.Yard;
                            #region 判断该匹是否有其开匹
                            sql = "SELECT * FROM WH_PackBox WHERE SourceBoxNo =" + SysString.ToDBString(pbentitysource.BoxNo);
                            DataTable dtpbentitysource = sqlTrans.Fill(sql);
                            if (dtpbentitysource.Rows.Count == 0)
                            {
                                pbentitysource.KPFlag = (int)YesOrNo.No;//修改源箱号开匹标志
                            }
                            #endregion
                            pbrule.RUpdate(pbentitysource, sqlTrans);
                            entity.TargetBoxNo = "";//目标箱号
                            sql = "DELETE FROM WH_PackBoxKPDts WHERE MainID=" + entity.ID;//删除开匹明细数据
                            sqlTrans.ExecuteNonQuery(sql);

                            #region 查找仓库结算类型
                            string sqlCal = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(pbentity.WHID);//获得仓库结算类型字段
                            DataTable dt = sqlTrans.Fill(sqlCal);
                            string FieldNamestr = string.Empty;
                            if (dt.Rows.Count != 0)
                            {
                                FieldNamestr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
                            }
                            sql = "UPDATE WH_Storge SET PieceQty=PieceQty-1 WHERE 1=1";
                            sql += " AND WHID=" + SysString.ToDBString(pbentity.WHID);
                            sql += " AND SectionID=" + SysString.ToDBString(pbentity.SectionID);
                            sql += " AND SBitID=" + SysString.ToDBString(pbentity.SBitID);
                            int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
                            if (FieldNamestr != string.Empty)
                            {
                                string[] FieldName = FieldNamestr.Split('+');
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
                                        case (int)WHCalMethodFieldName.ItemCode://产品编码
                                            sql += " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(pbentity.ItemCode);
                                            break;
                                        case (int)WHCalMethodFieldName.ColorNum://色号
                                            sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(pbentity.ColorNum);
                                            break;
                                        case (int)WHCalMethodFieldName.ColorName://颜色
                                            sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(pbentity.ColorName);
                                            break;
                                        case (int)WHCalMethodFieldName.Batch:   //批号
                                            sql += " AND ISNULL(Batch,'')=" + SysString.ToDBString(pbentity.Batch);
                                            break;
                                        case (int)WHCalMethodFieldName.VendorBatch:  //客户批号
                                            sql += " AND ISNULL(VendorBatch,'')=" + SysString.ToDBString(pbentity.VendorBatch);
                                            break;
                                        case (int)WHCalMethodFieldName.JarNum:  //缸号
                                            sql += " AND ISNULL(JarNum,'')=" + SysString.ToDBString(pbentity.JarNum);
                                            break;
                                        case (int)WHCalMethodFieldName.MWidth://门幅
                                            sql += " AND ISNULL(MWidth,'')=" + SysString.ToDBString(pbentity.MWidth);
                                            break;
                                        case (int)WHCalMethodFieldName.MWeight://克重
                                            sql += " AND ISNULL(MWeight,'')=" + SysString.ToDBString(pbentity.MWeight);
                                            break;
                                        case (int)WHCalMethodFieldName.DtsOrderFormNo://克重
                                            sql += " AND ISNULL(OrderFormNo,0)=" + SysString.ToDBString(pbentity.OrderFormNo);
                                            break;
                                        default:
                                            throw new Exception("结算异常，结算定义的字段底层未对应：" + CalFieldName + ",请联系管理员");
                                    }
                                }
                            }
                            #endregion
                            sqlTrans.ExecuteNonQuery(sql);
                        }
                    }
                    else
                    {
                        throw new Exception("操作错误，源条码不处于入库状态");
                    }
                }
                else
                {
                    throw new Exception("操作错误，未找到源条码");
                }

                entity.SubmitFlag = p_Type;
                this.RUpdate(entity, sqlTrans);//更新主表状态


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
        /// 拷贝数据到实体内
        /// </summary>
        /// <param name="p_MainDts"></param>
        /// <param name="p_BE"></param>
        public void CopyEntityData(PackBox p_PBEntitySouce, PackBox p_PBEntity)
        {
            p_PBEntity.CompanyTypeID = p_PBEntitySouce.CompanyTypeID;
            p_PBEntity.GoodsCode = p_PBEntitySouce.GoodsCode;
            p_PBEntity.GoodsLevel = p_PBEntitySouce.GoodsLevel;
            p_PBEntity.MWeight = p_PBEntitySouce.MWeight;
            p_PBEntity.MWidth = p_PBEntitySouce.MWidth;
            p_PBEntity.ItemCode = p_PBEntitySouce.ItemCode;
            p_PBEntity.ItemName = p_PBEntitySouce.ItemName;
            p_PBEntity.ItemStd = p_PBEntitySouce.ItemStd;
            p_PBEntity.Batch = p_PBEntitySouce.Batch;
            p_PBEntity.VendorBatch = p_PBEntitySouce.VendorBatch;
            p_PBEntity.WHID = p_PBEntitySouce.WHID;
            p_PBEntity.SectionID = p_PBEntitySouce.SectionID;
            p_PBEntity.SBitID = p_PBEntitySouce.SBitID;
            p_PBEntity.Unit = p_PBEntitySouce.Unit;
            p_PBEntity.ColorName = p_PBEntitySouce.ColorName;
            p_PBEntity.ColorNum = p_PBEntitySouce.ColorNum;
            p_PBEntity.JarNum = p_PBEntitySouce.JarNum;
            p_PBEntity.OrderFormNo = p_PBEntitySouce.OrderFormNo;
            p_PBEntity.ItemModel = p_PBEntitySouce.ItemModel;
        }
        #endregion

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(int p_ID, decimal p_Qty, string p_OPID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_ID, p_Qty, p_OPID, sqlTrans);

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
        public void RAdd(int p_ID, decimal p_Qty, string p_OPID, IDBTransAccess sqlTrans)
        {
            try
            {


                PackBoxKPRule rule = new PackBoxKPRule();
                PackBox entity = new PackBox(sqlTrans);
                entity.ID = p_ID;
                entity.SelectByID();

                FormNoControlRule frule = new FormNoControlRule();
                PackBoxKP pentity = new PackBoxKP();
                pentity.FormNo = frule.RGetFormNo((int)FormNoControlEnum.开匹单号, sqlTrans);
                pentity.FormDate = DateTime.Now;
                pentity.MakeDate = DateTime.Now;
                pentity.MakeOPID = p_OPID;
                pentity.SaleOPID = p_OPID;
                pentity.KPOPID = p_OPID;
                pentity.BoxNo = entity.BoxNo;
                pentity.Qty = entity.Qty;
                pentity.TargetQty = p_Qty;

                rule.RAdd(pentity, sqlTrans);

                rule.RSubmit(pentity.ID, 1, sqlTrans);


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





    }
}
