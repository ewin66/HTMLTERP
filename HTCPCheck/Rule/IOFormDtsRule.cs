using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTCPCheck;

using System.Windows.Forms;
using HttSoft.HTERP.Sys;
using HTCPCheck;

namespace HttSoft.HTCPCheck.DataCtl
{
    /// <summary>
    /// 目的：WH_IOFormDts实体业务规则类
    /// 作者:陈加海
    /// 创建日期:2009-4-23
    /// </summary>
    public class IOFormDtsRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public IOFormDtsRule()
        {
        }

        /// <summary>
        /// 检查将要操作的数据是否符合业务规则
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            IOFormDts entity = (IOFormDts)p_BE;
        }


        #region  显示数据

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
        public DataTable RShowDts2(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM WH_IOFormDts WHERE 1=1";
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
        public DataTable RShow(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM WH_IOFormDts WHERE 1=1";
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
        public DataTable RShowDts(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM WH_IOFormDts WHERE 1=1";
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
        public DataTable RShow(int p_ID, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM WH_IOFormDts WHERE 1=1";
                sql += " AND MainID=" + p_ID;
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
        /// 显示数据                  // 王焕梅添加 ，显示出入库报表
        /// </summary>
        /// <param name="p_condition"></param>

        public DataTable RShowIO(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_IOFormDts WHERE 1=1";
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

        #region 保存方法
        /// <summary>
        /// 保存(传入事务处理)
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <param name="p_BE"></param>
        /// <param name="sqlTrans"></param>
        public void RSave(IOForm p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;

                sql = "";//删除码单明细表，代码待补充；如果是入库要删除原始码单表，需要仔细研究，因为某些情况下(先验布)原始码单还是需要保存的
                
                sql = "DELETE FROM WH_IOFormDts WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(p_BE));
                sqlTrans.ExecuteNonQuery(sql);//删除原单据里应该删除的明细数据，即数据库里有但是UI里已经删除的数据


                for (int i = 0; i < p_BE.Length; i++)
                {
                    IOFormDts entitydts = (IOFormDts)p_BE[i];
                    if (entitydts.ID != 0)//ID不为0说明数据库中已经存在
                    {
                        this.RUpdate(entitydts, sqlTrans);
                    }
                    else
                    {
                        entitydts.MainID = p_Entity.ID;
                        this.RAdd(entitydts, sqlTrans);
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
        /// 获得数据库里没有被删除的ID(即数据库里有而且UI里也没有删除的数据)
        /// </summary>
        /// <param name="p_BE"></param>
        /// <returns></returns>
        private string GetIDExist(BaseEntity[] p_BE)
        {
            string outstr = "0";
            for (int i = 0; i < p_BE.Length; i++)
            {
                IOFormDts entitydts = (IOFormDts)p_BE[i];
                if (entitydts.ID != 0)
                {
                    outstr += "," + entitydts.ID;
                }
            }
            return outstr;
        }
        #endregion


        #region 保存

        ///// <summary>
        ///// 保存(传入事务处理)
        ///// </summary>
        ///// <param name="p_Entity"></param>
        ///// <param name="p_BE"></param>
        ///// <param name="sqlTrans"></param>
        //public void RSave(IOForm p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        //{
        //    try
        //    {
        //        string sql = "DELETE FROM WH_IOFormDts WHERE MainID=" + p_Entity.ID.ToString();
        //        sqlTrans.ExecuteNonQuery(sql);//删除原单据明细数据
        //        for (int i = 0; i < p_BE.Length; i++)
        //        {
        //            IOFormDts entitydts = (IOFormDts)p_BE[i];
        //            sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM WH_IOFormDts WHERE MainID=" + p_Entity.ID.ToString();
        //            entitydts.Seq = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());//找到最大的Seq
        //            entitydts.MainID = p_Entity.ID;
        //            this.RAdd(entitydts, sqlTrans);
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

        #endregion


        #region 生产代码

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
                IOFormDts entity = (IOFormDts)p_BE;
                IOFormDtsCtl control = new IOFormDtsCtl(sqlTrans);

                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WH_IOFormDts, sqlTrans);
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
                IOFormDts entity = (IOFormDts)p_BE;
                IOFormDtsCtl control = new IOFormDtsCtl(sqlTrans);
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
                IOFormDts entity = (IOFormDts)p_BE;
                IOFormDtsCtl control = new IOFormDtsCtl(sqlTrans);
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

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p_IOFormID">单据ID</param>
        /// <param name="sqlTrans">事物类</param>
        public void RDelete(int p_IOFormID, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "UPDATE WH_IOForm SET DelFlag=1 WHERE ID=" + SysString.ToDBString(p_IOFormID);
                sqlTrans.ExecuteNonQuery(sql);
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


        #region 其他辅助
        /// <summary>
        /// 根据FormListAID得到顶层单据类型入库、出库、盘点、移库、形态转换、期初入库
        /// </summary>
        /// <param name="p_FormListAID">loginID</param>
        /// <returns></returns>
        public static int GetFormListTopTypeByFormListID(int p_FormListAID, IDBTransAccess sqlTrans)
        {
            int outint = p_FormListAID;
            string sql = "SELECT ParentID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListAID);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                if (SysConvert.ToInt32(dt.Rows[0]["ParentID"]) != 0)
                {
                    outint = SysConvert.ToInt32(dt.Rows[0]["ParentID"]);
                }
            }
            return outint;
        }

        /// <summary>
        /// 获得单据明细类数组
        /// </summary>
        /// <param name="p_IOFormID">单据ID</param>
        /// <param name="sqlTrans">事务类</param>
        private IOFormDts[] RGetFormDts(int p_IOFormID, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "SELECT ID FROM WH_IOFormDts WHERE MainID=" + p_IOFormID.ToString();
                DataTable dt = sqlTrans.Fill(sql);
                IOFormDts[] entity = new IOFormDts[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    entity[i] = new IOFormDts(sqlTrans);
                    entity[i].ID = SysConvert.ToInt32(dt.Rows[i][0].ToString());
                    entity[i].SelectByID();
                }
                return entity;
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

        #region 提交撤销提交--处理库存
        /// <summary>
        /// 审核通过和审核拒绝
        /// </summary>
        /// <param name="p_FormID">单据ID</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        /// <param name="drFormList">单据小类的属性值行</param>
        /// <returns></returns>
        public void RSubmit(int p_FormID, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            try
            {
                IOForm entity = new IOForm(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();

                int FormListTopType = GetFormListTopTypeByFormListID(entity.HeadType, sqlTrans);//顶层单据类型

                IOFormDts[] entitydts = this.RGetFormDts(p_FormID, sqlTrans);
                for (int i = 0; i < entitydts.Length; i++)
                {
                    StorgeRule rulest = new StorgeRule();//结算库存
                    rulest.RSubmit(FormListTopType, entity, entitydts[i], p_Type, sqlTrans);
                }

                PackBoxProc(FormListTopType, entity, entitydts, p_Type, sqlTrans);//处理装箱单数据

                RFillDataType(entity, entitydts, p_Type, SysConvert.ToInt32(drFormList["FillDataTypeID"]), drFormList, sqlTrans);//回填数据处理
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

        #region 处理箱号
        /// <summary>
        /// 处理装箱单状态
        /// </summary>
        void PackBoxProc(int p_FormListTopType, IOForm p_entity, IOFormDts[] p_entitydts, int p_Type, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            sql = "SELECT Seq,BoxNo,Qty,FactQty FROM WH_IOFormDtsPack WHERE MainID=" + SysString.ToDBString(p_entity.ID) + " ORDER BY MainID,Seq";
            DataTable dtBoxNo = sqlTrans.Fill(sql);
            for (int i = 0; i < dtBoxNo.Rows.Count; i++)
            {
                //寻找对应仓库单据明细序号
                int ioformdtsdex = -1;
                for (int m = 0; m < p_entitydts.Length; m++)
                {
                    if (p_entitydts[m].Seq == SysConvert.ToInt32(dtBoxNo.Rows[i]["Seq"]))//找到相同的SEQ了
                    {
                        ioformdtsdex = m;
                        break;
                    }
                }
                if (ioformdtsdex == -1)//未找到，异常
                {
                    throw new Exception("码单异常，未找到单据明细，行号:" + SysConvert.ToInt32(dtBoxNo.Rows[0]["Seq"]));
                }


                //寻找码单序号
                PackBoxRule pbrule = new PackBoxRule();
                PackBox entity = pbrule.RGetEntityByBoxNo(dtBoxNo.Rows[i]["BoxNo"].ToString(), sqlTrans);
                if (entity.ID == 0)
                {
                    throw new Exception("异常，码单明细数据未存储到码单箱号表内，可以尝试重新输入码单明细保存");
                }


                switch (p_FormListTopType)
                {
                    case (int)WHFormList.入库:
                        if (p_Type == (int)YesOrNo.Yes)//提交
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.未入库)
                            {
                                throw new Exception("当前码单" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "不是处于未入库状态，不允许改变未入库状态");
                            }
                            entity.WHID = p_entitydts[ioformdtsdex].WHID;
                            entity.SectionID = p_entitydts[ioformdtsdex].SectionID;
                            entity.SBitID = p_entitydts[ioformdtsdex].SBitID;
                            entity.InFormNo = p_entity.FormNo;
                            entity.BoxStatusID = (int)EnumBoxStatus.入库;
                        }
                        else//撤销提交
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.入库)
                            {
                                throw new Exception("当前码单" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "不是处于入库状态，不允许改变为未入库状态");
                            }
                            entity.BoxStatusID = (int)EnumBoxStatus.未入库;
                        }

                        pbrule.RUpdate(entity, sqlTrans);//更新数据
                        break;

                    case (int)WHFormList.出库:
                        if (p_Type == (int)YesOrNo.Yes)//提交
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.入库)
                            {
                                throw new Exception("当前码单" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "不是处于入库状态，不允许改变为出库状态");
                            }

                            entity.OutFormNo = p_entity.FormNo;
                            entity.BoxStatusID = (int)EnumBoxStatus.出库;
                        }
                        else//撤销提交
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.出库)
                            {
                                throw new Exception("当前码单" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "不是处于出库状态，不允许改变未入库状态");
                            }
                            entity.BoxStatusID = (int)EnumBoxStatus.入库;
                        }

                        pbrule.RUpdate(entity, sqlTrans);//更新数据
                        break;

                    case (int)WHFormList.盘点://盘点应当改变数量,要单独处理
                        if (p_Type == (int)YesOrNo.Yes)//提交
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.入库)
                            {
                                throw new Exception("当前码单" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "不是处于入库状态，不允许移库");
                            }
                            entity.Qty = SysConvert.ToDecimal(dtBoxNo.Rows[i]["FactQty"]);

                        }
                        else//撤销提交
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.入库)
                            {
                                throw new Exception("当前码单" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "不是处于入库状态，不允许移库");
                            }
                            entity.Qty = SysConvert.ToDecimal(dtBoxNo.Rows[i]["Qty"]);

                        }

                        pbrule.RUpdate(entity, sqlTrans);//更新数据
                        break;

                    case (int)WHFormList.移库://移库应改变区位状态，要单独处理
                        if (p_Type == (int)YesOrNo.Yes)//提交
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.入库)
                            {
                                throw new Exception("当前码单" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "不是处于入库状态，不允许移库");
                            }

                            if (entity.Qty != SysConvert.ToDecimal(dtBoxNo.Rows[i]["Qty"]))
                            {
                                throw new Exception("当前码单" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "数量已改变，不允许操作，请检查是否进行过开匹操作");
                            }
                            entity.WHID = p_entitydts[ioformdtsdex].ToWHID;
                            entity.SectionID = p_entitydts[ioformdtsdex].ToSectionID;
                            entity.SBitID = p_entitydts[ioformdtsdex].ToSBitID;
                        }
                        else//撤销提交
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.入库)
                            {
                                throw new Exception("当前码单" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "不是处于入库状态，不允许移库");
                            }
                            if (entity.Qty != SysConvert.ToDecimal(dtBoxNo.Rows[i]["Qty"]))
                            {
                                throw new Exception("当前码单" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "数量已改变，不允许操作，请检查是否进行过开匹操作");
                            }
                            entity.WHID = p_entitydts[ioformdtsdex].WHID;
                            entity.SectionID = p_entitydts[ioformdtsdex].SectionID;
                            entity.SBitID = p_entitydts[ioformdtsdex].SBitID;
                        }

                        pbrule.RUpdate(entity, sqlTrans);//更新数据
                        break;
                }
            }
        }
        #endregion

        #region 回填数据处理
        /// <summary>
        /// 回填数据总处理方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        /// <param name="p_FillDataTypeID">回填方法类型</param>
        /// <returns></returns>
        public void RFillDataType(IOForm entity, IOFormDts[] entitydts, int p_Type, int p_FillDataTypeID, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            switch (p_FillDataTypeID)
            {
                //case (int)EnumFillDataType.采购入库标准回填方法:   //后续隐藏
                //    goto case (int)EnumFillDataType.采购单入库标准回填方法;
                ////case (int)EnumFillDataType.坯布纱线采购回填方法:
                ////    RFillDataPSCGRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                ////    break;
                //case (int)EnumFillDataType.销售出库标准回填方法:
                //    RFillDataXSCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    RFillDataXSCKFH(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;
                //case (int)EnumFillDataType.销售出库仅回填销售订单方法:
                //    RFillDataXSCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;

                //case (int)EnumFillDataType.采购单入库标准回填方法:
                //    RFillDataCGRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;


                //case (int)EnumFillDataType.加工单入库标准回填方法:
                //    RFillDataWORK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;
              
            }

        }

      


        #region 织造加工入库标准回填方法
        /// <summary>
        /// 织造加工入库标准回填方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataZZRK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT DtsID,Qty,InQty FROM UV1_WO_WeaveProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//退货用负数处理
                    }

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//提交
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) + thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则 ：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_WeaveProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//撤销提交
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_WeaveProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的织造加工单及颜色：" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }
            }
        }
        #endregion

        #region 织造加工出库回填方法
        /// <summary>
        /// 织造加工出库回填方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataZZCK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }
            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT DtsID,Qty,OutQty,NLQty FROM UV1_WO_WeaveProcessDts2 WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND ItemName=" + SysString.ToDBString(entitydts[i].ItemName);
                sql += " AND ItemStd=" + SysString.ToDBString(entitydts[i].ItemStd);
                sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//退货用负数处理
                    }
                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//提交
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["NLQty"]) + thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则 ：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_WeaveProcessDts2 SET ";
                        sql += " NLFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",NLQty=ISNULL(NLQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//撤销提交
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["NLQty"]) - thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_WeaveProcessDts2 SET ";
                        sql += " NLFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",NLQty=ISNULL(NLQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的织造加工单及颜色：" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }
            }
        }
        #endregion

        #region 校验数量合理性
        /// <summary>
        /// 校验数量合理性
        /// </summary>
        /// <param name="drFormList">单据属性</param>
        /// <param name="p_PlanQty">计划数</param>
        /// <param name="p_FactQty">实际发生数</param>
        /// <returns>true/false</returns>
        bool RFillDataCheckQty(DataRow drFormList, decimal p_PlanQty, decimal p_FactQty, out string o_ErrorMsg)
        {
            bool outbool = false;
            o_ErrorMsg = "计划数:" + p_PlanQty + "  累计完成数:" + p_FactQty;
            if (p_PlanQty < SysConvert.ToDecimal(drFormList["CheckQtyFrom"]))//小数量，使用前一比例判断
            {
                if (SysConvert.ToDecimal(drFormList["CheckQtyPer1"]) > 0)//必须有值才判断
                {
                    if (p_PlanQty != 0)
                    {
                        if (p_FactQty / p_PlanQty - 1 <= SysConvert.ToDecimal(drFormList["CheckQtyPer1"]))//在合理数量范围内
                        {
                            outbool = true;
                        }
                    }
                }
                else
                {
                    outbool = true;
                }
            }
            else//大数量，使用后一比例判断
            {
                if (SysConvert.ToDecimal(drFormList["CheckQtyPer2"]) > 0)//必须有值才判断
                {
                    if (p_PlanQty != 0)
                    {
                        if (p_FactQty / p_PlanQty - 1 <= SysConvert.ToDecimal(drFormList["CheckQtyPer2"]))//在合理数量范围内
                        {
                            outbool = true;
                        }
                    }
                }
                else
                {
                    outbool = true;
                }
            }

            return outbool;
        }
        #endregion
        #endregion

    }
}
