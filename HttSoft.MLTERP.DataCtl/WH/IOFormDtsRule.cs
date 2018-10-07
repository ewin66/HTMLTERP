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
        public DataTable SOShow(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM WH_IOFormDtsISN WHERE 1=1";
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



                int FormListTopType = GetFormListTopTypeByFormListID(p_Entity.HeadType, sqlTrans);//顶层单据类型
                if (FormListTopType == (int)WHFormList.入库)//删除没用的细码
                {
                    sql = "DELETE FROM WH_PackBox WHERE BoxNo in(select BoxNo from WH_IOFormDtsPack where MainID=" + p_Entity.ID.ToString();
                    sql += " AND DID NOT IN" + string.Format("({0})", GetIDExist(p_BE));
                    sql += ")";
                    sqlTrans.ExecuteNonQuery(sql);//删除原单据里应该删除的明细数据，即数据库里有但是UI里已经删除的数据
                }


                sql = "DELETE FROM WH_IOFormDtsPack WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND DID NOT IN" + string.Format("({0})", GetIDExist(p_BE));
                sqlTrans.ExecuteNonQuery(sql);//删除原单据里应该删除的明细数据，即数据库里有但是UI里已经删除的数据







                for (int i = 0; i < p_BE.Length; i++)
                {
                    IOFormDts entitydts = (IOFormDts)p_BE[i];
                    if (entitydts.ID != 0)//ID不为0说明数据库中已经存在
                    {
                        this.RUpdate(entitydts, sqlTrans);

                        ///防止增行删行操作，Seq重新赋值
                        sql = "Update WH_IOFormDtsPack Set Seq=" + entitydts.Seq + " where  MainID=" + p_Entity.ID.ToString();
                        sql += " AND DID =" + entitydts.ID;
                        sqlTrans.ExecuteNonQuery(sql);//



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
                    if (FormListTopType == (int)WHFormList.盘点)//如果相同不盘点
                    {
                        if (entitydts[i].MoveQty == entitydts[i].SourceQty && entitydts[i].SourceQty != 0)
                        {
                            if (entity.SubType == 801)
                            {
                                UpdatePDDate(p_FormID, p_Type, entitydts[i].ID, sqlTrans);
                            }
                            continue;
                        }
                    }
                    if (FormListTopType == (int)WHFormList.移库)//如果库区位相同不移库
                    {
                        if (entitydts[i].WHID == entitydts[i].ToWHID
                            && entitydts[i].SectionID == entitydts[i].ToSectionID
                            && entitydts[i].SBitID == entitydts[i].ToSBitID)
                        {
                            continue;
                        }
                    }



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

        private void UpdatePDDate(int p_FormID, int p_Type, int p_ID, IDBTransAccess sqlTrans)
        {
            IOFormDts entity = new IOFormDts();
            entity.ID = p_ID;
            entity.SelectByID();
            if (p_Type == (int)ConfirmFlag.未提交)
            {
                string sql = "UPDATE WH_Storge SET PDDate=NULL";
                sql += " WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode);
                sql += " AND GoodsCode=" + SysString.ToDBString(entity.GoodsCode);
                sql += " AND ColorNum=" + SysString.ToDBString(entity.ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entity.ColorName);
                sql += " AND SectionID=" + SysString.ToDBString(entity.SectionID);
                sql += " AND WHID=" + SysString.ToDBString(entity.WHID);
                sqlTrans.ExecuteNonQuery(sql);
            }
            else
            {
                string sql = "UPDATE WH_Storge SET PDDate=" + SysString.ToDBString(DateTime.Now.Date);
                sql += " WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode);
                sql += " AND GoodsCode=" + SysString.ToDBString(entity.GoodsCode);
                sql += " AND ColorNum=" + SysString.ToDBString(entity.ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entity.ColorName);
                sql += " AND SectionID=" + SysString.ToDBString(entity.SectionID);
                sql += " AND WHID=" + SysString.ToDBString(entity.WHID);
                sqlTrans.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// 处理装箱单状态
        /// </summary>
        void PackBoxProc(int p_FormListTopType, IOForm p_entity, IOFormDts[] p_entitydts, int p_Type, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            sql = "SELECT Seq,BoxNo,Qty,FactQty,Weight,Yard,GoodsLevel FROM WH_IOFormDtsPack WHERE MainID=" + SysString.ToDBString(p_entity.ID) + " ORDER BY MainID,Seq";
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


                            ///更新校验入库的条码状态  zhoufc
                            sql = "Update WO_BProductCheckDts set InWHFlag=1 where DISN =" + SysString.ToDBString(entity.BoxNo);
                            sqlTrans.ExecuteNonQuery(sql);//
                        }
                        else//撤销提交
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.入库)
                            {
                                throw new Exception("当前码单" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "不是处于入库状态，不允许改变为未入库状态");
                            }
                            entity.BoxStatusID = (int)EnumBoxStatus.未入库;

                            ///更新校验入库的条码状态 zhoufc
                            sql = "Update WO_BProductCheckDts set InWHFlag=0 where DISN =" + SysString.ToDBString(entity.BoxNo);
                            sqlTrans.ExecuteNonQuery(sql);//
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
                            entity.Qty = SysConvert.ToDecimal(dtBoxNo.Rows[i]["Qty"]);
                            entity.Weight = SysConvert.ToDecimal(dtBoxNo.Rows[i]["Weight"]);
                            //if(entity.BoxNo)
                        }
                        else//撤销提交
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.入库)
                            {
                                throw new Exception("当前码单" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "不是处于入库状态，不允许移库");
                            }
                            entity.Qty = SysConvert.ToDecimal(dtBoxNo.Rows[i]["Qty"]);
                            entity.Weight = SysConvert.ToDecimal(dtBoxNo.Rows[i]["Weight"]);
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
                #region 盘点注释
                //if (p_FormListTopType == (int)WHFormList.盘点)
                //{
                //    for (int f = 0; f < p_entitydts.Length; f++)
                //    {
                //        sql = "SELECT * FROM WH_PackBox WHERE BoxNo NOT IN( SELECT BoxNo FROM WH_IOFormDtsPack WHERE DID=" + SysString.ToDBString(p_entitydts[f].ID) + " )";
                //        #region
                //        sql = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(p_entitydts[f].WHID);//获得仓库结算类型字段
                //        DataTable dt = SysUtils.Fill(sql);
                //        string FieldNamestr = string.Empty;
                //        if (dt.Rows.Count != 0)
                //        {
                //            FieldNamestr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
                //        }
                //        #endregion
                //        sql = "SELECT *  FROM UV1_WH_PackBox WHERE 1=1";
                //        sql += " AND WHID=" + SysString.ToDBString(p_entitydts[f].WHID);
                //        sql += " AND SectionID=" + SysString.ToDBString(p_entitydts[f].SectionID);
                //        sql += " AND SBitID=" + SysString.ToDBString(p_entitydts[f].SBitID);
                //        sql += "AND BoxNo NOT IN( SELECT BoxNo FROM WH_IOFormDtsPack WHERE DID=" + SysString.ToDBString(p_entitydts[f].ID) + " )";
                //        int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
                //        if (FieldNamestr != string.Empty)
                //        {
                //            string[] FieldName = FieldNamestr.Split('+');
                //            for (int h = 0; h < FieldName.Length; h++)
                //            {
                //                string sqlFieldName = "SELECT ID FROM Enum_WHCalMethodFieldName WHERE Name=" + SysString.ToDBString(FieldName[h]);//找到库存结算字段对应的ID
                //                DataTable dtFieldName = SysUtils.Fill(sqlFieldName);
                //                if (dtFieldName.Rows.Count != 0 && dtFieldName.Rows[0]["ID"].ToString() != "")
                //                {
                //                    CalFieldName = SysConvert.ToInt32(dtFieldName.Rows[0]["ID"]);
                //                }
                //                switch (CalFieldName)
                //                {
                //                    case (int)WHCalMethodFieldName.ItemCode://产品编码
                //                        sql += " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(p_entitydts[f].ItemCode);
                //                        break;
                //                    case (int)WHCalMethodFieldName.ColorNum://色号
                //                        sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(p_entitydts[f].ColorNum);
                //                        break;
                //                    case (int)WHCalMethodFieldName.ColorName://颜色
                //                        sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(p_entitydts[f].ColorName);
                //                        break;
                //                    case (int)WHCalMethodFieldName.Batch:   //批号
                //                        sql += " AND ISNULL(Batch,'')=" + SysString.ToDBString(p_entitydts[f].Batch);
                //                        break;
                //                    case (int)WHCalMethodFieldName.VendorBatch:  //客户批号
                //                        sql += " AND ISNULL(VendorBatch,'')=" + SysString.ToDBString(p_entitydts[f].VendorBatch);
                //                        break;
                //                    case (int)WHCalMethodFieldName.JarNum:  //缸号
                //                        sql += " AND ISNULL(JarNum,'')=" + SysString.ToDBString(p_entitydts[f].JarNum);
                //                        break;
                //                    case (int)WHCalMethodFieldName.MWidth://门幅
                //                        sql += " AND ISNULL(MWidth,0)=" + SysString.ToDBString(p_entitydts[f].MWidth);
                //                        break;
                //                    case (int)WHCalMethodFieldName.MWeight://克重
                //                        sql += " AND ISNULL(MWeight,0)=" + SysString.ToDBString(p_entitydts[f].MWeight);
                //                        break;
                //                    default:
                //                        throw new Exception("结算异常，结算定义的字段底层未对应：" + CalFieldName + ",请联系管理员");
                //                }
                //            }
                //        }

                //        sql += " AND (ISNULL(Qty,0)>0 OR ISNULL(Weight,0)>0)";

                //        if (p_Type == (int)YesOrNo.Yes)//提交
                //        {
                //            sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.入库);
                //            DataTable dtBox = sqlTrans.Fill(sql);
                //            if (dtBox.Rows.Count > 0)
                //            {
                //                sql = "UPDATE WH_PackBox SET BoxStatusID =" + SysString.ToDBString((int)EnumBoxStatus.盘点);
                //                sql += " WHERE BoxNo IN (";
                //                string str = string.Empty;
                //                foreach (DataRow dr in dtBox.Rows)
                //                {
                //                    if (str != string.Empty)
                //                    {
                //                        str += ",";
                //                    }
                //                    str += SysString.ToDBString(SysConvert.ToString(dr["BoxNo"]));
                //                }
                //                sql += str + ")";
                //                sqlTrans.ExecuteNonQuery(sql);
                //            }


                //        }
                //        else//撤销提交
                //        {
                //            sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.盘点);
                //            DataTable dtBox = sqlTrans.Fill(sql);
                //            if (dtBox.Rows.Count > 0)
                //            {
                //                sql = "UPDATE WH_PackBox SET BoxStatusID =" + SysString.ToDBString((int)EnumBoxStatus.入库);
                //                sql += " WHERE BoxNo IN (";
                //                string str = string.Empty;
                //                foreach (DataRow dr in dtBox.Rows)
                //                {
                //                    if (str != string.Empty)
                //                    {
                //                        str += ",";
                //                    }
                //                    str += SysString.ToDBString(SysConvert.ToString(dr["BoxNo"]));
                //                }
                //                sql += str + ")";
                //                sqlTrans.ExecuteNonQuery(sql);
                //            }
                //        }
                //        //pbrule.RUpdate(entity, sqlTrans);//更新数据
                //    }
                //}
                #endregion
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
                case (int)EnumFillDataType.采购入库标准回填方法:   //后续隐藏
                    goto case (int)EnumFillDataType.采购单入库标准回填方法;
                //case (int)EnumFillDataType.坯布纱线采购回填方法:
                //    RFillDataPSCGRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //break;
                case (int)EnumFillDataType.销售出库标准回填方法:
                    RFillDataXSCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    RFillDataXSCKFH(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;
                case (int)EnumFillDataType.销售出库仅回填销售订单方法:
                    RFillDataXSCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;

                case (int)EnumFillDataType.采购单入库标准回填方法:
                    RFillDataCGRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;


                case (int)EnumFillDataType.加工单入库标准回填方法:
                    RFillDataWORK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;
                case (int)EnumFillDataType.销售出库回填销售出货数:
                    RFillDataXSCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;
                //case (int)EnumFillDataType.调样入库标准回填方法:
                //    RFillDataDYRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;
                //case (int)EnumFillDataType.调样销售出库标准回填方法:
                //    RFillDataDYXSCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    RFillDataXSCKFH(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;
                case (int)EnumFillDataType.染布加工出库标准回填方法:
                    RFillDataRBCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;
                case (int)EnumFillDataType.染布加工入库标准回填方法:
                    RFillDataRBRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;

                case (int)EnumFillDataType.后整加工入库标准回填方法:
                    RFillDataHZRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;
                case (int)EnumFillDataType.后整加工出库标准回填方法:
                    RFillDataHZCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;

                case (int)EnumFillDataType.成品加工入库标准回填方法:
                    RFillDataCPHZRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;

                //case (int)EnumFillDataType.印花加工出库标准回填方法:
                //    RFillDataYHCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;
                //case (int)EnumFillDataType.印花加工入库标准回填方法:
                //    RFillDataYHRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;


                case (int)EnumFillDataType.织造加工出库标准回填方法:
                    RFillDataZZCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;
                case (int)EnumFillDataType.织造加工入库标准回填方法:
                    RFillDataZZRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;
            }

        }

        #region 采购入库标准回填方法
        /// <summary>
        /// 采购入库标准回填方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataCGRK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            SaleOrderRule sorule = new SaleOrderRule();
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT DtsID,Qty,TotalRecQty,* FROM UV1_Buy_ItemBuyFormDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
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

                    decimal thisWeight = entitydts[i].Weight;
                    if (thFlag)
                    {
                        thisWeight = 0 - thisWeight;//退货用负数处理
                    }

                    string Unit = SysConvert.ToString(dtData.Rows[0]["Unit"]);//采购的单位

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//提交
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["TotalRecQty"]) + thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则 ：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE Buy_ItemBuyFormDts SET ";
                        sql += " ReceivedDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (Unit.EndsWith("KG"))//如果采购的单位是公斤 则回填公斤
                        {
                            sql += ",ReceivedQty=" + "(" + SysString.ToDBString(thisWeight) + ")";
                            sql += ",TotalRecQty=ISNULL(TotalRecQty,0)+" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        else
                        {
                            sql += ",ReceivedQty=" + "(" + SysString.ToDBString(thisQty) + ")";
                            sql += ",TotalRecQty=ISNULL(TotalRecQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//撤销提交
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["TotalRecQty"]) - thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE Buy_ItemBuyFormDts SET ";

                        sql += " ReceivedDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",ReceivedQty=0";
                        if (Unit.EndsWith("KG"))
                        {
                            sql += ",TotalRecQty=ISNULL(TotalRecQty,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        else
                        {
                            sql += ",TotalRecQty=ISNULL(TotalRecQty,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的采购单及颜色：" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }


                sorule.RUpdateStep(entitydts[i].DtsOrderFormNo, entitydts[i].ItemCode, entitydts[i].ColorNum, entitydts[i].ColorName, 0, entity.SubType, 0, 0, p_Type, true, sqlTrans);//更新订单进度 (int)EnumOrderStep.采购入库



            }
        }
        #endregion

        #region 加工入库标准回填方法
        /// <summary>
        /// 加工入库标准回填方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataWORK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }

            SaleOrderRule sorule = new SaleOrderRule();

            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT DtsID,Qty,InQty FROM UV1_WO_FabricProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
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

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",ReceivedDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",ReceivedQty=" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",TotalRecQty=ISNULL(TotalRecQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//撤销提交
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",ReceivedDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",ReceivedQty=0";
                        sql += ",TotalRecQty=ISNULL(TotalRecQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的加工单及颜色：" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }

                sorule.RUpdateStep(entitydts[i].DtsOrderFormNo, entitydts[i].ItemCode, entitydts[i].ColorNum, entitydts[i].ColorName, 0, entity.SubType, 0, 0, p_Type, true, sqlTrans);//更新订单进度 (int)EnumOrderStep.采购入库

            }
        }
        #endregion

        #region 销售出库标准回填方法
        /// <summary>
        /// 销售出库标准回填方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataXSCK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            SaleOrderRule sorule = new SaleOrderRule();
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }


            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT DtsID,Qty,Weight,Yard,PieceQty,TotalRecQty,TotalRecWeight,TotalRecYard,TotalRecPieceQty FROM UV1_Sale_SaleOrderDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsOrderFormNo);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    decimal thisWeight = entitydts[i].Weight;
                    decimal thisYard = entitydts[i].Yard;
                    int thisPieceQty = entitydts[i].PieceQty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//退货用负数处理
                        thisWeight = 0 - thisWeight;
                        thisYard = 0 - thisYard;
                        thisPieceQty = 0 - thisPieceQty;
                    }
                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//提交
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["TotalRecQty"]) + thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则 ：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_SaleOrderDts SET ";
                        sql += " ReceivedDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",ReceivedQty=" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",TotalRecQty=ISNULL(TotalRecQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",ReceivedWeight=" + "(" + SysString.ToDBString(thisWeight) + ")";
                        sql += ",TotalRecWeight=ISNULL(TotalRecWeight,0)+" + "(" + SysString.ToDBString(thisWeight) + ")";
                        sql += ",ReceivedYard=" + "(" + SysString.ToDBString(thisYard) + ")";
                        sql += ",TotalRecYard=ISNULL(TotalRecYard,0)+" + "(" + SysString.ToDBString(thisYard) + ")";
                        sql += ",ReceivedPieceQty=" + "(" + SysString.ToDBString(thisPieceQty) + ")";
                        sql += ",TotalRecPieceQty=ISNULL(TotalRecPieceQty,0)+" + "(" + SysString.ToDBString(thisPieceQty) + ")";
                        sql += ",OrderstepID = " + (int)EnumOrderStep.销售出库;//
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//撤销提交
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["TotalRecQty"]) - thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_SaleOrderDts SET ";
                        sql += " ReceivedDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",ReceivedQty=0";
                        sql += ",TotalRecQty=ISNULL(TotalRecQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",ReceivedWeight=0";
                        sql += ",TotalRecWeight=ISNULL(TotalRecWeight,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        sql += ",ReceivedYard=0";
                        sql += ",TotalRecYard=ISNULL(TotalRecYard,0)-" + "(" + SysString.ToDBString(thisYard) + ")";
                        sql += ",ReceivedPieceQty=0";
                        sql += ",TotalRecPieceQty=ISNULL(TotalRecPieceQty,0)-" + "(" + SysString.ToDBString(thisPieceQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的销售订单及颜色：" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }


                sorule.RUpdateStep(entitydts[i].DtsOrderFormNo, entitydts[i].ItemCode, entitydts[i].ColorNum, entitydts[i].ColorName, 0, entity.SubType, 0, 0, p_Type, true, sqlTrans);//更新订单进度 (int)EnumOrderStep.销售出库



            }
        }
        #endregion

        #region 调样入库标准回填方法
        /// <summary>
        /// 调样入库标准回填方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataDYRK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT ID,Qty,InQty FROM Sale_DYGL WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
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

                        sql = "UPDATE Sale_DYGL SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["ID"].ToString();
                    }
                    else//撤销提交
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_DYGL SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["ID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的调样单及颜色：" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }

            }
        }
        #endregion

        #region 调样销售出库标准回填方法
        /// <summary>
        /// 调样销售出库标准回填方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataDYXSCK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }
            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT ID,Qty,OutQty FROM Sale_DYGL WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsOrderFormNo);
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
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["OutQty"]) + thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则 ：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_DYGL SET ";
                        sql += " OutFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",OutQty=ISNULL(OutQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",DYStatusID=" + SysString.ToDBString((int)EnumDYStatus.已完成);
                        sql += ",FormDate=" + SysString.ToDBString(DateTime.Now.Date);
                        sql += " WHERE ID=" + dtData.Rows[0]["ID"].ToString();
                    }
                    else//撤销提交
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["OutQty"]) - thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_DYGL SET ";
                        sql += " OutFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",OutQty=ISNULL(OutQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",DYStatusID=" + SysString.ToDBString((int)EnumDYStatus.进行中);
                        sql += ",FormDate=null";
                        sql += " WHERE ID=" + dtData.Rows[0]["ID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的调样单及颜色：" + entitydts[i].DtsOrderFormNo + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }
            }
        }
        #endregion

        #region 销售出库发货单回填方法(子方法，供销售出库调用)
        /// <summary>
        /// 销售出库发货单回填方法(子方法，供销售出库调用)
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataXSCKFH(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            SaleOrderRule sorule = new SaleOrderRule();
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }
            if (thFlag)//退货不处理发货单
            {
                return;
            }
            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT DtsID,Qty,TotalSendQty FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//提交
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["TotalSendQty"]) + entitydts[i].Qty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则 ：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_FHFormDts SET ";
                        sql += " SendDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += " ,DtsSendFlag=1";
                        sql += ",TotalSendQty=ISNULL(TotalSendQty,0)+" + SysString.ToDBString(entitydts[i].Qty);
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//撤销提交
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["TotalSendQty"]) - entitydts[i].Qty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_FHFormDts SET ";
                        sql += " SendDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (SysConvert.ToDecimal(dtData.Rows[0]["TotalSendQty"]) - entitydts[i].Qty <= 0)
                        {
                            sql += " ,DtsSendFlag=0";
                        }
                        sql += ",TotalSendQty=ISNULL(TotalSendQty,0)-" + SysString.ToDBString(entitydts[i].Qty);
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的发货单及颜色：" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }





            }
        }
        #endregion

        #region 染布加工入库标准回填方法
        /// <summary>
        /// 染布加工入库标准回填方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataRBRK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT DtsID,Qty,InQty ,Unit FROM UV1_WO_FabricProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                //sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND BCPItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);//半成品编码
                //sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND BCPColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    //如果入库的单位 和加工单的单位不一样
                    if (!SysConvert.ToString(entitydts[i].Unit).EndsWith(SysConvert.ToString(dtData.Rows[0]["Unit"])))
                    {
                        throw new BaseException("单位和加工单的单位不一致，请检查");
                    }

                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//退货用负数处理
                    }

                    decimal thisWeight = entitydts[i].Weight;
                    if (thFlag)
                    {
                        thisWeight = 0 - thisWeight;//退货用负数处理
                    }

                    decimal thisYard = entitydts[i].Yard;
                    if (thFlag)
                    {
                        thisYard = 0 - thisYard;//退货用负数处理
                    }

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//提交
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) + thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则 ：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.EndsWith("M"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("KG"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("Y"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisYard) + ")";
                        }
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//撤销提交
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.EndsWith("M"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("KG"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("Y"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisYard) + ")";
                        }
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的染布加工单及颜色：" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }

            }
        }
        #endregion

        #region 染布加工出库回填方法
        /// <summary>
        /// 染布加工出库回填方法(回填领料数)
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataRBCK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }
            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT DtsID,Qty,OutQty,NLQty FROM UV1_WO_FabricProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                //sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND CPItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);//坯布编码
                //sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                //sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    decimal thisWeight = entitydts[i].Weight;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//退货用负数处理
                        thisWeight = 0 - thisWeight;//退货用负数处理
                    }
                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//提交
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["NLQty"]) + thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则 ：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " OutFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));

                        //sql += ",NLQty=ISNULL(NLQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",OutQty=ISNULL(OutQty,0)+" + "(" + SysString.ToDBString(thisWeight) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//撤销提交
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["NLQty"]) - thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " OutFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        //sql += ",NLQty=ISNULL(NLQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",OutQty=ISNULL(OutQty,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的染布加工单及颜色：" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }
            }
        }
        #endregion



        #region 后整加工入库标准回填方法
        /// <summary>
        /// 后整加工入库标准回填方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataHZRK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT DtsID,Qty,InQty ,Unit FROM UV1_WO_FabricProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                //sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND BCPItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);//半成品编码
                sql += " AND BCPColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND BCPColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    //如果入库的单位 和加工单的单位不一样
                    if (!SysConvert.ToString(entitydts[i].Unit).EndsWith(SysConvert.ToString(dtData.Rows[0]["Unit"])))
                    {
                        throw new BaseException("单位和加工单的单位不一致，请检查");
                    }

                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//退货用负数处理
                    }
                    decimal thisWeight = entitydts[i].Weight;
                    if (thFlag)
                    {
                        thisWeight = 0 - thisWeight;//退货用负数处理
                    }
                    decimal thisYard = entitydts[i].Yard;
                    if (thFlag)
                    {
                        thisYard = 0 - thisYard;//退货用负数处理
                    }

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//提交
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) + thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则 ：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.EndsWith("M"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("KG"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("Y"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisYard) + ")";
                        }
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//撤销提交
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.EndsWith("M"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("KG"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("Y"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisYard) + ")";
                        }
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的染布加工单及颜色：" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }

            }
        }
        #endregion




        #region 成品后整加工入库标准回填方法
        /// <summary>
        /// 后整加工入库标准回填方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataCPHZRK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT DtsID,Qty,InQty FROM UV1_WO_FabricProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
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

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " CPInDate =" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",CPInQty =ISNULL(CPInQty ,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//撤销提交
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " CPInDate =" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",CPInQty=ISNULL(CPInQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的染布加工单及颜色：" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }

            }
        }
        #endregion

        #region 后整加工出库标准回填方法
        /// <summary>
        /// 后整加工出库标准回填方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataHZCK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT DtsID,Qty,InQty, Unit FROM UV1_WO_FabricProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                //sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND BCPItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);//半成品编码
                sql += " AND BCPColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND BCPColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    //如果入库的单位 和加工单的单位不一样
                    if (!SysConvert.ToString(entitydts[i].Unit).EndsWith(SysConvert.ToString(dtData.Rows[0]["Unit"])))
                    {
                        throw new BaseException("单位和加工单的单位不一致，请检查");
                    }

                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//退货用负数处理
                    }
                    decimal thisWeight = entitydts[i].Weight;
                    if (thFlag)
                    {
                        thisWeight = 0 - thisWeight;//退货用负数处理
                    }
                    decimal thisYard = entitydts[i].Yard;
                    if (thFlag)
                    {
                        thisYard = 0 - thisYard;//退货用负数处理
                    }

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//提交
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) + thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则 ：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " OutFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.EndsWith("M"))
                        {
                            sql += ",OutQty=ISNULL(OutQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("KG"))
                        {
                            sql += ",OutQty=ISNULL(OutQty,0)+" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("Y"))
                        {
                            sql += ",OutQty=ISNULL(OutQty,0)+" + "(" + SysString.ToDBString(thisYard) + ")";
                        }

                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//撤销提交
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " OutFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.EndsWith("M"))
                        {
                            sql += ",OutQty=ISNULL(OutQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("KG"))
                        {
                            sql += ",OutQty=ISNULL(OutQty,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("Y"))
                        {
                            sql += ",OutQty=ISNULL(OutQty,0)-" + "(" + SysString.ToDBString(thisYard) + ")";
                        }

                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的染布加工单及颜色：" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }

            }
        }
        #endregion


        #region 印花加工入库标准回填方法
        /// <summary>
        /// 印花加工入库标准回填方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataYHRK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT DtsID,Qty,InQty FROM UV1_WO_PrintingProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                //sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                //sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
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

                        sql = "UPDATE WO_PrintingProcessDts SET ";
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

                        sql = "UPDATE WO_PrintingProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的印花加工单及颜色：" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }
            }
        }
        #endregion

        #region 印花加工出库回填方法
        /// <summary>
        /// 印花加工出库回填方法
        /// </summary>
        /// <param name="entity">单头</param>
        /// <param name="entitydts">单据明细</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        void RFillDataYHCK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.对帐负)
            {
                thFlag = true;
            }
            for (int i = 0; i < entitydts.Length; i++)//循环遍历历史
            {
                sql = "SELECT DtsID,Qty,OutQty,NLQty FROM UV1_WO_PrintingProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                //sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                //sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
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

                        sql = "UPDATE WO_PrintingProcessDts SET ";
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

                        sql = "UPDATE WO_PrintingProcessDts SET ";
                        sql += " NLFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",NLQty=ISNULL(NLQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("回填数据失败，没有找到对应的印花加工单及颜色：" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }
            }
        }
        #endregion

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
                sql = "SELECT DtsID,Qty,InQty FROM UV1_WO_FabricProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    decimal thisWeight = entitydts[i].Weight;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//退货用负数处理
                        thisWeight = 0 - thisWeight;//退货用负数处理
                    }

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//提交
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) + thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则 ：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE UV1_WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.Contains("KG"))  //公斤 就回填重量
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        else
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        sql += " WHERE DtsID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//撤销提交
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//校验数量合理性
                        {
                            throw new Exception("不能操作，数量不符合设置的规则：编码：" + entitydts[i].ItemCode + "色号：" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE UV1_WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.Contains("KG"))  //公斤 就回填重量
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        else
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        sql += " WHERE DtsID=" + dtData.Rows[0]["DtsID"].ToString();
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


        #region 坯纱染色出库自动入染厂库处理
        ///// <summary>
        ///// 自动染厂入库
        ///// </summary>
        ///// <param name="p_FormID">单据ID</param>
        ///// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        ///// <returns></returns>
        //public void RSubmitColorIn(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        //{
        //    try
        //    {
        //        ParamSetRule rulePS = new ParamSetRule();
        //        //if (SysConvert.ToInt32(rulePS.RShowIntByCode((int)ParamSetEnum.染厂是否自动出入库)) == (int)YesOrNo.No)//染厂出库自动入染厂库 && p_Type == (int)ConfirmFlag.已提交
        //        //{
        //        //    return;
        //        //}
        //        IOForm entity = new IOForm(sqlTrans);
        //        entity.ID = p_FormID;
        //        entity.SelectByID();


        //        IOFormDts[] entitydts = this.RGetFormDts(p_FormID, sqlTrans);
        //        if (p_Type == (int)ConfirmFlag.已提交)
        //        {
        //            //增加出库记录
        //            IOFormRule rule = new IOFormRule();
        //            FormNoControlRule formconrule = new FormNoControlRule();
        //            IOForm entityi = new IOForm(sqlTrans);
        //            entityi.HeadType = (int)WHFormList.坯纱入库单;
        //            entityi.SubType = (int)WHFormList.染厂入库;
        //            entityi.CardNo = entity.FormNo;
        //            entityi.FormNo = formconrule.RGetFormNo((int)WHFormList.染厂入库, 0, "", sqlTrans);
        //            entityi.FormDate = DateTime.Now.Date;
        //            entityi.PassOP = ParamConfig.LoginName;
        //            entityi.WHOP = ParamConfig.LoginName;
        //            //entityi.Indep = "仓库";
        //            entityi.WHID = entity.VendorID;
        //            entityi.VendorID = entity.VendorID;
        //            //entityi.JSCFlag = (int)YesOrNo.Yes;
        //            entityi.WHTypeID = (int)EnumWHType.坯纱;
        //            string sql = "SELECT * FROM WH_IOFormDts WHERE MainID=" + p_FormID.ToString();
        //            DataTable dt = sqlTrans.Fill(sql);//获得明细数据
        //            ArrayList al = new ArrayList();
        //            foreach (DataRow dr in dt.Rows)//得出有几条数据
        //            {
        //                IOFormDts entitydtsi = new IOFormDts(sqlTrans);
        //                entitydtsi.DtsSO = dr["DtsSO"].ToString();
        //                entitydtsi.DtsVendorID = entityi.VendorID;
        //                entitydtsi.ItemCode = dr["ItemCode"].ToString();
        //                entitydtsi.ItemName = dr["ItemName"].ToString();
        //                entitydtsi.ItemStd = dr["ItemStd"].ToString();
        //                entitydtsi.ColorName = dr["ColorName"].ToString();
        //                entitydtsi.ColorNum = dr["ColorNum"].ToString();
        //                entitydtsi.VendorBatch = dr["VendorBatch"].ToString();
        //                entitydtsi.Batch = dr["Batch"].ToString();
        //                entitydtsi.Amount = SysConvert.ToDecimal(dr["Amount"]);
        //                entitydtsi.SinglePrice = SysConvert.ToDecimal(dr["SinglePrice"]);
        //                entitydtsi.Weight = SysConvert.ToDecimal(dr["Weight"]);
        //                entitydtsi.Qty = SysConvert.ToDecimal(dr["Qty"]);
        //                entitydtsi.Unit = SysConvert.ToString(dr["Unit"]);
        //                entitydtsi.DtsSaleOPID = SysConvert.ToString(dr["DtsSaleOPID"]);
        //                entitydtsi.WHID = entity.VendorID;
        //                entitydtsi.WHTypeID = (int)EnumWHType.坯纱;

        //                entitydtsi.CompanyTypeID =SysConvert.ToInt32(dr["CompanyTypeID"]);

        //                al.Add(entitydtsi);
        //            }

        //            IOFormDts[] dtsarray = new IOFormDts[al.Count];
        //            for (int i = 0; i < al.Count; i++)
        //            {
        //                dtsarray[i] = (IOFormDts)al[i];
        //            }

        //            rule.RAdd(entityi, dtsarray, sqlTrans);//增加
        //            rule.RSubmit(entityi.ID, p_Type, sqlTrans);//审核

        //        }
        //        else if (p_Type == (int)ConfirmFlag.未提交)
        //        {
        //            string sql = "SELECT ID FROM WH_IOForm WHERE SubType=" + (int)WHFormList.染厂入库 + " AND CardNo=" + SysString.ToDBString(entity.FormNo) + " AND DelFlag=0";
        //            DataTable dt = sqlTrans.Fill(sql);
        //            if (dt.Rows.Count != 0)
        //            {
        //                IOFormRule rule = new IOFormRule();
        //                int p_ID = SysConvert.ToInt32(dt.Rows[0][0].ToString());
        //                rule.RSubmit(p_ID, p_Type, sqlTrans);//撤销审核
        //                rule.RDelete(p_ID, sqlTrans);//删除
        //            }
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

        #region 委外染色退纱入库时染厂自动出库
        ///// <summary>
        ///// 自动染厂出库
        ///// </summary>
        ///// <param name="p_FormID">单据ID</param>
        ///// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        ///// <returns></returns>
        //public void RSubmitColorOut(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        //{
        //    try
        //    {

        //        ParamSetRule rulePS = new ParamSetRule();
        //        //if (SysConvert.ToInt32(rulePS.RShowIntByCode((int)ParamSetEnum.染厂是否自动出入库)) == (int)YesOrNo.No)//染厂出库自动入染厂库 && p_Type == (int)ConfirmFlag.已提交
        //        //{
        //        //    return;
        //        //}

        //        IOForm entity = new IOForm(sqlTrans);
        //        entity.ID = p_FormID;
        //        entity.SelectByID();

        //        IOFormDts[] entitydts = this.RGetFormDts(p_FormID, sqlTrans);
        //        if (p_Type == (int)ConfirmFlag.已提交)
        //        {
        //            string tempStr = CheckShopStorge(p_FormID, sqlTrans);
        //            if (tempStr != string.Empty)//校验数据
        //            {
        //                //if (DialogResult.Yes != BaseForm.d ShowConfirmMessage(tempStr + Environment.NewLine + "确定要提交此单？"))

        //                if (DialogResult.Yes != MessageBox.Show(tempStr + Environment.NewLine + "确定要提交此单？", FParamConfig.SystemName, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        //                {
        //                    throw new Exception("没有确定提交该单据");
        //                }
        //            }

        //            //增加出库记录
        //            IOFormRule rule = new IOFormRule();
        //            FormNoControlRule formconrule = new FormNoControlRule();
        //            IOForm entityi = new IOForm(sqlTrans);
        //            entityi.HeadType = (int)WHFormList.坯纱出库单;
        //            entityi.SubType = (int)WHFormList.染厂出库;
        //            entityi.CardNo = entity.FormNo;
        //            entityi.FormNo = formconrule.RGetFormNo((int)WHFormList.染厂出库, 0, "", sqlTrans);
        //            entityi.FormDate = DateTime.Now.Date;
        //            entityi.PassOP = ParamConfig.LoginName;
        //            entityi.WHOP = ParamConfig.LoginName;
        //            //entityi.Indep = "仓库";
        //            entityi.WHID = entity.VendorID;
        //            entityi.VendorID = entity.VendorID;
        //            //entityi.JSCFlag = (int)YesOrNo.Yes;
        //            entityi.WHTypeID = (int)EnumWHType.坯纱;
        //            string sql = "SELECT * FROM WH_IOFormDts WHERE MainID=" + p_FormID.ToString();
        //            DataTable dt = sqlTrans.Fill(sql);//获得明细数据
        //            ArrayList al = new ArrayList();
        //            foreach (DataRow dr in dt.Rows)//得出有几条数据
        //            {
        //                IOFormDts entitydtsi = new IOFormDts(sqlTrans);
        //                entitydtsi.DtsSO = dr["DtsSO"].ToString();
        //                entitydtsi.DtsVendorID = entityi.VendorID;
        //                entitydtsi.ItemCode = dr["ItemCode"].ToString();
        //                entitydtsi.ItemName = dr["ItemName"].ToString();
        //                entitydtsi.ItemStd = dr["ItemStd"].ToString();
        //                entitydtsi.ColorName = dr["ColorName"].ToString();
        //                entitydtsi.ColorNum = dr["ColorNum"].ToString();
        //                entitydtsi.VendorBatch = dr["VendorBatch"].ToString();
        //                entitydtsi.Batch = dr["Batch"].ToString();
        //                entitydtsi.Amount = SysConvert.ToDecimal(dr["Amount"]);
        //                entitydtsi.SinglePrice = SysConvert.ToDecimal(dr["SinglePrice"]);
        //                entitydtsi.Weight = SysConvert.ToDecimal(dr["Weight"]);
        //                entitydtsi.Qty = SysConvert.ToDecimal(dr["Qty"]);
        //                entitydtsi.Unit = SysConvert.ToString(dr["Unit"]);
        //                entitydtsi.DtsSaleOPID = SysConvert.ToString(dr["DtsSaleOPID"]);
        //                entitydtsi.WHID = entity.VendorID;

        //                entitydtsi.CompanyTypeID =SysConvert.ToInt32(dr["CompanyTypeID"]);

        //                entitydtsi.WHTypeID = (int)EnumWHType.坯纱;
        //                al.Add(entitydtsi);
        //            }

        //            IOFormDts[] dtsarray = new IOFormDts[al.Count];
        //            for (int i = 0; i < al.Count; i++)
        //            {
        //                dtsarray[i] = (IOFormDts)al[i];
        //            }

        //            rule.RAdd(entityi, dtsarray, sqlTrans);//增加
        //            rule.RSubmit(entityi.ID, p_Type, sqlTrans);//审核

        //        }
        //        else if (p_Type == (int)ConfirmFlag.未提交)
        //        {
        //            string sql = "SELECT ID FROM WH_IOForm WHERE SubType=" + (int)WHFormList.染厂出库 + " AND CardNo=" + SysString.ToDBString(entity.FormNo) + " AND DelFlag=0";
        //            DataTable dt = sqlTrans.Fill(sql);
        //            if (dt.Rows.Count != 0)
        //            {
        //                IOFormRule rule = new IOFormRule();
        //                int p_ID = SysConvert.ToInt32(dt.Rows[0][0].ToString());
        //                rule.RSubmit(p_ID, p_Type, sqlTrans);//撤销审核
        //                rule.RDelete(p_ID, sqlTrans);//删除
        //            }
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
        ///// 校验染厂库存是否够用
        ///// </summary>
        ///// <returns></returns>
        //private string CheckShopStorge(int p_FormID, IDBTransAccess sqlTrans)
        //{
        //    string outStr = string.Empty;
        //    IOForm entity = new IOForm(sqlTrans);
        //    entity.ID = p_FormID;
        //    entity.SelectByID();

        //    string sql = "SELECT * From WH_IOFormDts WHERE MainID=" + p_FormID;
        //    DataTable dt = sqlTrans.Fill(sql);
        //    if (dt.Rows.Count != 0)
        //    {
        //        bool findError = false;
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {

        //            string ItemCode = SysConvert.ToString(dt.Rows[i]["ItemCode"]);
        //            //string Batch = SysConvert.ToString(dt.Rows[i]["Batch"]);
        //            //string VendorBatch = SysConvert.ToString(dt.Rows[i]["VendorBatch"]);
        //            decimal Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);

        //            StorgeRule rule = new StorgeRule();
        //            int[] stia = rule.FindStorges(entity.VendorID, "", "", entity.CompanyTypeID, ItemCode, "", "", "", "", "", "", "", "", (int)EnumWHType.坯纱, "", "", "", sqlTrans);
        //            Storge entityS = new Storge();
        //            if (stia.Length > 0)
        //            {
        //                entityS.ID = stia[0];
        //                entityS.SelectByID();
        //            }
        //            if (Qty > entityS.Qty)
        //            {
        //                findError = true;
        //            }
        //            if (outStr != string.Empty)
        //            {
        //                outStr += Environment.NewLine;
        //            }
        //            outStr += "纱线编号：" + ItemCode +  " 染厂库存数量：" + entityS.Qty + "KG" + " 染色数量：" + Qty.ToString() + " KG";//+ " 批号：" + tempA[1]
        //        }
        //        if (findError)
        //        {
        //            outStr = "提醒信息：染厂库存纱比染色数量少" + Environment.NewLine + outStr;
        //        }
        //        return outStr;
        //    }
        //    return outStr;
        //}
        #endregion


        #region  处理染色入库单实收数
        /// <summary>
        /// 审核通过和审核拒绝
        /// </summary>
        /// <param name="p_FormID">单据ID</param>
        /// <param name="p_Type">1/0 审核通过/审核拒绝</param>
        /// <returns></returns>
        public void RDealColorInQty(int p_FormID, IOFormDts[] p_entityDts)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    IOForm entity = new IOForm(sqlTrans);
                    entity.ID = p_FormID;
                    entity.SelectByID();

                    IOFormDts[] entitydts = this.RGetFormDts(p_FormID, sqlTrans);
                    for (int i = 0; i < entitydts.Length; i++)
                    {
                        StorgeRule rulest = new StorgeRule();//库存
                        rulest.RDealColorInQty(p_FormID, entity, entitydts[i], p_entityDts[i], sqlTrans);

                        ///更新入库单数据
                        string sql = "UPDATE WH_IOFormDts Set Qty=" + SysConvert.ToDecimal(p_entityDts[i].Qty);
                        sql += " ,Amount=" + SysConvert.ToDecimal(SysConvert.ToDecimal(p_entityDts[i].Qty) * SysConvert.ToDecimal(p_entityDts[i].SinglePrice), 2);
                        sql += " ,QtyDiff=" + SysConvert.ToDecimal(SysConvert.ToDecimal(p_entityDts[i].Weight) - SysConvert.ToDecimal(p_entityDts[i].Qty), 2);//损益=实收数-标重
                        //if (SysConvert.ToDecimal(p_entityDts[i].CompactQty)-SysConvert.ToDecimal(p_entityDts[i].Qty) != 0 && SysConvert.ToDecimal(p_entityDts[i].CompactQty) != 0)
                        //{
                        //    ///染色损耗=(投染数-实收数)/投染数
                        //    sql += " ,LossRate=" + SysConvert.ToDecimal((SysConvert.ToDecimal(p_entityDts[i].CompactQty)-SysConvert.ToDecimal(p_entityDts[i].Qty)) / SysConvert.ToDecimal(p_entityDts[i].CompactQty)*100, 2);
                        //}
                        sql += " WHERE 1=1 AND MainID=" + p_FormID;
                        sql += " AND Seq=" + entitydts[i].Seq;
                        sqlTrans.ExecuteNonQuery(sql);
                    }
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
