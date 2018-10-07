using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;


namespace HttSoft.HTCPCheck.DataCtl
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
                            entityst.Amount += p_EntityDts.Qty * p_EntityDts.SinglePrice;//计算金额
                           
                            break;
                        case (int)WHFormList.出库:
                            entityst.Qty -= p_EntityDts.Qty;
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
                            entityst.Amount -= p_EntityDts.Qty * p_EntityDts.SinglePrice;//计算金额
                            break;
                        case (int)WHFormList.出库:
                            entityst.Qty += p_EntityDts.Qty;

                            entityst.PieceQty += p_EntityDts.PieceQty;
                            entityst.Weight += p_EntityDts.Weight;
                            entityst.Amount += p_EntityDts.Qty * p_EntityDts.SinglePrice;//计算金额
                            break;
                        case (int)WHFormList.期初入库:
                            goto case (int)WHFormList.入库;
                    }

                }

              
                if (entityst.Qty < -0.001m)//库存数量大于0
                {
                    throw new Exception("操作后库存数量低于0，不能操作，编码：" + entityst.ItemCode + " 色号：" + entityst.ColorNum + " 颜色：" + entityst.ColorName + " 数量：" + entityst.Qty.ToString());
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
                        default:
                            throw new Exception("结算异常，结算定义的字段底层未对应："+CalFieldName);

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
        public int FindStorge(IOFormDts p_entity,int p_Type,IDBTransAccess sqlTrans)
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
                    if (entity.ID != 0 && (entity.Qty == 0))//更新 && entity.PieceQty==0
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

       

    }
}
