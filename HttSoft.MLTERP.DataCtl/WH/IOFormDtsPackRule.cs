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
    /// 目的：WH_IOFormDtsPack实体业务规则类
    /// 作者:陈加海
    /// 创建日期:2012-5-7
    /// </summary>
    public class IOFormDtsPackRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public IOFormDtsPackRule()
        {
        }

        /// <summary>
        /// 检查将要操作的数据是否符合业务规则
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            IOFormDtsPack entity = (IOFormDtsPack)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM WH_IOFormDtsPack WHERE 1=1";
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_IOFormDtsPackBT WHERE 1=1";
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

        #region 保存代码
        /// <summary>
        /// 获得数据库里没有被删除的ID(即数据库里有而且UI里也没有删除的数据)
        /// </summary>
        /// <param name="p_BE"></param>
        /// <returns></returns>
        private string GetIDExist(ArrayList p_BE)
        {
            string outstr = "0";
            for (int i = 0; i < p_BE.Count; i++)
            {
                IOFormDtsPack entitydts = (IOFormDtsPack)p_BE[i];
                if (entitydts.ID != 0)
                {
                    outstr += "," + entitydts.ID;
                }
            }
            return outstr;
        }

        /// <summary>
        /// 保存(传入事务处理)
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <param name="p_BE"></param>
        /// <param name="sqlTrans"></param>
        public void RSave(IOForm p_Entity, IOFormDts[] p_EntityDts, ArrayList list, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;

                int FormListTopType = IOFormDtsRule.GetFormListTopTypeByFormListID(p_Entity.HeadType, sqlTrans);//顶层单据类型
                //if (FormListTopType != (int)WHFormList.入库 && FormListTopType != (int)WHFormList.期初入库)//如果不是入库类型的单据
                if (FormListTopType != (int)WHFormList.入库 && FormListTopType != (int)WHFormList.期初入库
                     && FormListTopType != (int)WHFormList.面料入库单 && FormListTopType != (int)WHFormList.坯布入库单)//如果不是入库类型的单据
                {
                    RSaveOther(p_Entity, p_EntityDts, list, sqlTrans);
                    return;
                }


                sql = "SELECT BoxNo FROM WH_IOFormDtsPack WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(list));
                DataTable dtDelete = sqlTrans.Fill(sql);//删除表结构
                if (dtDelete.Rows.Count != 0)//有需要删除的数据
                {
                    foreach (DataRow dr in dtDelete.Rows)//校验是否可以删除
                    {
                        PackBoxRule pbrule = new PackBoxRule();
                        pbrule.RCheckDelete(dr["BoxNo"].ToString(), sqlTrans);//检测调用
                    }

                    sql = "DELETE FROM WH_PackBox WHERE BoxNo IN(SELECT BoxNo FROM WH_IOFormDtsPack WHERE MainID=" + p_Entity.ID.ToString();
                    sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(list)) + ")";//删除码单明细数据
                    sqlTrans.ExecuteNonQuery(sql);

                    sql = "DELETE FROM WH_IOFormDtsPack WHERE MainID=" + p_Entity.ID.ToString();
                    sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(list));
                    sqlTrans.ExecuteNonQuery(sql);//删除原单据里应该删除的明细数据，即数据库里有但是UI里已经删除的数据
                }
                for (int i = 0; i < list.Count; i++)
                {
                    IOFormDtsPack entitydts = (IOFormDtsPack)list[i];
                    int ioformdtsdex = -1;
                    for (int m = 0; m < p_EntityDts.Length; m++)
                    {
                        if (p_EntityDts[m].Seq == entitydts.Seq)//找到相同的SEQ了
                        {
                            ioformdtsdex = m;
                            break;
                        }
                    }
                    if (ioformdtsdex == -1)//未找到，异常
                    {
                        throw new Exception("码单输入异常，未找到单据明细，行号:" + entitydts.Seq);
                    }


                    if (entitydts.ID != 0)//ID不为0说明数据库中已经存在
                    {
                        PackBoxRule pbrule = new PackBoxRule();
                        pbrule.RCheckUpdate(entitydts.BoxNo, sqlTrans);//检测调用
                        this.RUpdate(p_EntityDts[ioformdtsdex], entitydts, sqlTrans);
                    }
                    else
                    {
                        entitydts.MainID = p_Entity.ID;
                        this.RAdd(p_Entity, p_EntityDts[ioformdtsdex], entitydts, sqlTrans);
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
        /// 保存(传入事务处理)
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <param name="p_BE"></param>
        /// <param name="sqlTrans"></param>
        public void RSaveOther(IOForm p_Entity, IOFormDts[] p_EntityDts, ArrayList list, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;
                int FormListTopType = IOFormDtsRule.GetFormListTopTypeByFormListID(p_Entity.HeadType, sqlTrans);//顶层单据类型

                sql = "SELECT BoxNo FROM WH_IOFormDtsPack WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(list));
                DataTable dtDelete = sqlTrans.Fill(sql);//删除表结构
                if (dtDelete.Rows.Count != 0)//有需要删除的数据
                {
                    sql = "DELETE FROM WH_IOFormDtsPack WHERE MainID=" + p_Entity.ID.ToString();
                    sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(list));
                    sqlTrans.ExecuteNonQuery(sql);//删除原单据里应该删除的明细数据，即数据库里有但是UI里已经删除的数据
                }
                for (int i = 0; i < list.Count; i++)
                {
                    IOFormDtsPack entitydts = (IOFormDtsPack)list[i];
                    int ioformdtsdex = -1;
                    for (int m = 0; m < p_EntityDts.Length; m++)
                    {
                        if (p_EntityDts[m].Seq == entitydts.Seq)//找到相同的SEQ了
                        {
                            ioformdtsdex = m;
                            break;
                        }
                    }
                    if (ioformdtsdex == -1)//未找到，异常
                    {
                        throw new Exception("码单输入异常，未找到单据明细，行号:" + entitydts.Seq);
                    }

                    if (entitydts.ID != 0)//ID不为0说明数据库中已经存在
                    {
                        this.RUpdateOther(p_EntityDts[ioformdtsdex], entitydts, sqlTrans);
                    }
                    else
                    {
                        entitydts.MainID = p_Entity.ID;
                        entitydts.DID = p_EntityDts[ioformdtsdex].ID;
                        this.RAddOther(p_EntityDts[ioformdtsdex], entitydts, sqlTrans);

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
        public void RAdd(IOForm p_MainEntity, IOFormDts p_MainDts, BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                IOFormDtsPack entity = (IOFormDtsPack)p_BE;

                PackBox pbentity = new PackBox(sqlTrans);
                pbentity.SourceTypeID = (int)PackBoxSourceType.入库单;
                pbentity.BoxStatusID = (int)EnumBoxStatus.未入库;
                CopyEntityData(p_MainDts, entity, pbentity);
                //if (entity.BoxNo != string.Empty && p_MainEntity.Remark == "EIN")//仅仅在导数据时使用到
                if (entity.BoxNo != string.Empty)//仅仅在导数据时使用到
                {
                    pbentity.CreateTime = p_MainEntity.FormDate;
                    pbentity.BoxNo = entity.BoxNo;
                }
                pbentity.DID = p_MainDts.ID;
                pbentity.SubSeq = entity.SubSeq;
                PackBoxRule pbrule = new PackBoxRule();
                pbrule.RAdd(pbentity, sqlTrans);



                entity.DID = p_MainDts.ID;//20141009 zhoufc
                entity.BoxNo = pbentity.BoxNo;
                this.RAdd(entity, sqlTrans);//后插入的原因是箱号是在插入箱号实体时生成的
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
        public void RAddOther(IOFormDts p_MainDts, BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                IOFormDtsPack entity = (IOFormDtsPack)p_BE;

                RSaveOtherCheck(p_MainDts, p_BE, sqlTrans);


                this.RAdd(entity, sqlTrans);
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
        /// 保存其它单据时检查匹配性
        /// </summary>
        public void RSaveOtherCheck(IOFormDts p_MainDts, BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            this.CheckCorrect(p_BE);
            IOFormDtsPack entity = (IOFormDtsPack)p_BE;

            if (entity.BoxNo == string.Empty)
            {
                throw new Exception("异常，没有读取到码单箱号");
            }
            PackBoxRule pbrule = new PackBoxRule();
            PackBox pbentity = pbrule.RGetEntityByBoxNo(entity.BoxNo, sqlTrans);
            if (pbentity.BoxStatusID != (int)EnumBoxStatus.入库)
            {
                throw new Exception("异常，码单箱号" + entity.BoxNo + "当前未处于入库状态，不允许操作");
            }
            if (pbentity.ItemCode != p_MainDts.ItemCode || pbentity.ColorNum != p_MainDts.ColorNum ||
                pbentity.ColorName != p_MainDts.ColorName)//|| pbentity.GoodsLevel != p_MainDts.GoodsLevel 先不管等级
            {
                throw new Exception("异常，码单箱号" + entity.BoxNo + "和单据明细属性不匹配");
            }

        }

        /// <summary>
        /// 拷贝数据到实体内
        /// </summary>
        /// <param name="p_MainDts"></param>
        /// <param name="p_BE"></param>
        public void CopyEntityData(IOFormDts p_MainDts, IOFormDtsPack p_BE, PackBox p_PBEntity)
        {
            p_PBEntity.ColorName = p_MainDts.ColorName;
            p_PBEntity.ColorNum = p_MainDts.ColorNum;
            p_PBEntity.CompanyTypeID = p_MainDts.CompanyTypeID;
            p_PBEntity.GoodsCode = p_MainDts.GoodsCode;
            p_PBEntity.GoodsLevel = p_MainDts.GoodsLevel;
            p_PBEntity.ItemCode = p_MainDts.ItemCode;
            p_PBEntity.ItemName = p_MainDts.ItemName;
            p_PBEntity.ItemStd = p_MainDts.ItemStd;
            p_PBEntity.JarNum = p_MainDts.JarNum;
            p_PBEntity.Batch = p_MainDts.Batch;
            p_PBEntity.VendorBatch = p_MainDts.VendorBatch;
            p_PBEntity.MWeight = p_MainDts.MWeight;
            p_PBEntity.MWidth = p_MainDts.MWidth;
            p_PBEntity.Qty = p_BE.Qty;
            p_PBEntity.Weight = p_BE.Weight;
            //p_PBEntity.Unit = p_MainDts.Unit;
            p_PBEntity.FMQty = p_BE.FMQty;// 放码

        }



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RUpdate(IOFormDts p_MainDts, BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                IOFormDtsPack entity = (IOFormDtsPack)p_BE;
                this.RUpdate(p_BE, sqlTrans);

                PackBoxRule pbrule = new PackBoxRule();
                PackBox pbentity = pbrule.RGetEntityByBoxNo(entity.BoxNo, sqlTrans);//获得箱单实体               

                CopyEntityData(p_MainDts, entity, pbentity);//拷贝数据

                pbrule.RUpdate(pbentity, sqlTrans);//更新
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
        public void RUpdateOther(IOFormDts p_MainDts, BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                IOFormDtsPack entity = (IOFormDtsPack)p_BE;

                RSaveOtherCheck(p_MainDts, p_BE, sqlTrans);

                this.RUpdate(p_BE, sqlTrans);

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
                IOFormDtsPack entity = (IOFormDtsPack)p_BE;
                IOFormDtsPackCtl control = new IOFormDtsPackCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WH_IOFormDtsPack, sqlTrans);


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
                IOFormDtsPack entity = (IOFormDtsPack)p_BE;
                IOFormDtsPackCtl control = new IOFormDtsPackCtl(sqlTrans);
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
                IOFormDtsPack entity = (IOFormDtsPack)p_BE;
                IOFormDtsPackCtl control = new IOFormDtsPackCtl(sqlTrans);
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
        /// 保存
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RSave(int p_ID, int p_MainID, int p_Seq, BaseEntity[] p_BE, bool p_UpdateFlag)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSave(p_ID, p_MainID, p_Seq, p_BE, p_UpdateFlag, sqlTrans);

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
        /// 保存(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RSave(int p_ID, int p_MainID, int p_Seq, BaseEntity[] p_BE, bool p_UpdateFlag, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "";
                if (p_UpdateFlag)//修改状态下首先清除被删除的码单明细
                {
                    string idStr = string.Empty;//ID字符串
                    idStr = "0";
                    for (int i = 0; i < p_BE.Length; i++)
                    {
                        IOFormDtsPack entity = (IOFormDtsPack)p_BE[i];
                        if (entity.ID != 0)//有ID
                        {
                            if (idStr != string.Empty)
                            {
                                idStr += ",";
                            }
                            idStr += entity.ID.ToString();
                        }
                    }

                    if (idStr != string.Empty)
                    {
                        sql = "DELETE FROM WH_PackBox WHERE BoxNo IN (SELECT BoxNo FROM WH_IOFormDtsPack WHERE DID=" + SysString.ToDBString(p_ID) + " AND ID NOT IN(" + idStr + ") )";
                        sqlTrans.ExecuteNonQuery(sql);//执行条形码删除

                        sql = "DELETE FROM WH_IOFormDtsPack WHERE DID=" + SysString.ToDBString(p_ID) + " AND ID NOT IN(" + idStr + ")";//WH_IOFormDtsPack WH_PackBox
                        sqlTrans.ExecuteNonQuery(sql);
                    }
                }
                else//新增状态
                {
                    sql = "SELECT TOP 1 ID FROM WH_IOFormDtsPack WHERE DID=" + SysString.ToDBString(p_ID);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        throw new BaseException("不能重复保存！");
                    }
                }


                IOForm p_Main = new IOForm(sqlTrans);
                p_Main.ID = p_MainID;
                p_Main.SelectByID();

                IOFormDts p_MainDts = new IOFormDts(sqlTrans);
                p_MainDts.ID = p_ID;
                p_MainDts.SelectByID();



                IOFormDtsPackRule rule = new IOFormDtsPackRule();
                PackBoxRule Brule = new PackBoxRule();
                decimal Qty = 0;
                decimal Weight = 0;
                decimal Yard = 0;
                decimal PieceQty = 0;
                for (int i = 0; i < p_BE.Length; i++)
                {
                    FormNoControlRule frule = new FormNoControlRule();
                    IOFormDtsPack entity = (IOFormDtsPack)p_BE[i];
                    int boxNoCreateTypeID = 0;//箱号条码来源
                    if (entity.ID == 0)
                    {
                        if (entity.BoxNo == string.Empty)//没有箱号条码
                        {
                            entity.BoxNo = frule.RGetFormNo((int)FormNoControlEnum.码单箱号, sqlTrans);
                            rule.RAdd(entity, sqlTrans);
                            frule.RAddSort((int)FormNoControlEnum.码单箱号, sqlTrans);
                        }
                        else//有箱号条码说明是验布产生的条码
                        {
                            boxNoCreateTypeID = 1;//验布来源
                        }
                    }
                    else
                    {
                        rule.RUpdate(entity, sqlTrans);
                    }


                    PackBox entityBox = new PackBox();
                    if (entity.ID != 0)//仓库明细已生成，则寻找箱号ID 此处判断其实无意义，经过上面的代码肯定有ID值了
                    {
                        sql = "SELECT ID FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(entity.BoxNo);
                        DataTable dtPackBox = sqlTrans.Fill(sql);
                        if (dtPackBox.Rows.Count != 0)//如果找到条码
                        {
                            entityBox.ID = SysConvert.ToInt32(dtPackBox.Rows[0]["ID"]);
                        }
                        else//如果未找到条码
                        {
                            entityBox.CreateSourceID = boxNoCreateTypeID;////原始条码表加个字段表示来源 0:表示入库录入
                        }
                    }
                    entityBox.BoxNo = entity.BoxNo;
                    entityBox.WHID = p_MainDts.WHID;
                    entityBox.SectionID = p_MainDts.SectionID;
                    entityBox.SBitID = p_MainDts.SBitID;
                    entityBox.ColorName = p_MainDts.ColorName;
                    entityBox.ColorNum = p_MainDts.ColorNum;
                    entityBox.CompanyTypeID = p_MainDts.CompanyTypeID;
                    entityBox.GoodsCode = p_MainDts.GoodsCode;
                    // entityBox.GoodsLevel = p_MainDts.GoodsLevel;
                    entityBox.ItemCode = p_MainDts.ItemCode;
                    entityBox.ItemModel = p_MainDts.ItemModel;
                    entityBox.ItemName = p_MainDts.ItemName;
                    entityBox.ItemStd = p_MainDts.ItemStd;
                    entityBox.JarNum = p_MainDts.JarNum;
                    entityBox.Batch = p_MainDts.Batch;
                    entityBox.VendorBatch = p_MainDts.VendorBatch;
                    entityBox.MWeight = p_MainDts.MWeight;
                    entityBox.MWidth = p_MainDts.MWidth;
                    entityBox.Qty = entity.Qty;
                    entityBox.Weight = entity.Weight;
                    entityBox.Yard = entity.Yard;
                    entityBox.GoodsLevel = entity.GoodsLevel;
                    entityBox.Unit = p_MainDts.Unit;
                    entityBox.BoxStatusID = (int)EnumBoxStatus.未入库;
                    entityBox.DID = p_ID;
                    entityBox.InFormNo = p_Main.FormNo;
                    entityBox.OrderFormNo = p_MainDts.DtsOrderFormNo;//合同号明细
                    entityBox.SubSeq = entity.SubSeq;//卷号

                    if (entityBox.ID == 0)//没有ID则新增
                    {
                        Brule.RAdd(entityBox, sqlTrans);
                    }
                    else//有ID则修改
                    {
                        Brule.RUpdate(entityBox, sqlTrans);
                    }

                    Qty += entity.Qty;
                    Weight += entity.Weight;
                    Yard += entity.Yard;
                    PieceQty++;


                }

                //if (PieceQty == 0)
                //{
                //    throw new BaseException("请填写细码后点击保存");
                //}

                sql = "UPDATE WH_IOFormDts SET Qty=" + SysString.ToDBString(Qty);
                sql += ",Weight=" + SysString.ToDBString(Weight);
                sql += ",Yard=" + SysString.ToDBString(Yard);
                sql += ",PieceQty=" + SysString.ToDBString(PieceQty);
                sql += ",PackFlag=1 ";
                sql += " WHERE ID=" + SysString.ToDBString(p_ID);
                sqlTrans.ExecuteNonQuery(sql);
                sql = "UPDATE WH_IOFormDts SET Amount=ISNULL(SinglePrice,0)*(";
                sql += "CASE";
                sql += " WHEN Unit='RMB/KG' OR Unit='USD/KG' THEN ISNULL(Weight,0)";
                sql += " WHEN Unit='RMB/Y' OR Unit='USD/Y' THEN ISNULL(Yard,0) ";
                sql += " WHEN Unit='RMB/M' OR Unit='USD/M' THEN ISNULL(Qty,0) ";
                sql += " ELSE 0 END)";
                sql += " WHERE ID=" + SysString.ToDBString(p_ID);
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

        #region 细码出库

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(int p_ID, string p_IDStr)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_ID, p_IDStr, sqlTrans);

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
        public void RAdd(int p_ID, string p_IDStr, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "SELECT WHID,SectionID,SBitID,JarNum,Batch FROM WH_PackBox WHERE ID IN (" + p_IDStr + ")";
                sql += " GROUP BY WHID,SectionID,SBitID,JarNum,Batch";
                DataTable dt = sqlTrans.Fill(sql);
                int MaxSeq = GetMaxSeq(p_ID);
                decimal Qty = 0;
                IOFormDtsRule rule = new IOFormDtsRule();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)//第一行更新
                    {
                        sql = "SELECT * FROM WH_PackBox WHERE ID IN (" + p_IDStr + ")";
                        sql += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["WHID"]));
                        sql += " AND SectionID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["SectionID"]));
                        sql += " AND SBitID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["SBitID"]));
                        sql += " AND JarNum=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["JarNum"]));
                        sql += " AND Batch=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["Batch"]));
                        DataTable dtsql = sqlTrans.Fill(sql);

                        IOFormDts entitydts = new IOFormDts(sqlTrans);
                        entitydts.ID = p_ID;
                        entitydts.SelectByID();
                        entitydts.WHID = SysConvert.ToString(dt.Rows[i]["WHID"]);
                        entitydts.SectionID = SysConvert.ToString(dt.Rows[i]["SectionID"]);
                        entitydts.SBitID = SysConvert.ToString(dt.Rows[i]["SBitID"]);
                        entitydts.JarNum = SysConvert.ToString(dt.Rows[i]["JarNum"]);
                        entitydts.Batch = SysConvert.ToString(dt.Rows[i]["Batch"]);
                        entitydts.Qty = SysConvert.ToDecimal(SysConvert.ToDecimal(dtsql.Compute("SUM(Qty)", "")), 2);
                        entitydts.Weight = SysConvert.ToDecimal(SysConvert.ToDecimal(dtsql.Compute("SUM(Weight)", "")), 2);
                        entitydts.Yard = SysConvert.ToDecimal(SysConvert.ToDecimal(dtsql.Compute("SUM(Yard)", "")), 2);
                        entitydts.PieceQty = dtsql.Rows.Count;
                        entitydts.PackFlag = 1;
                        if (entitydts.Unit == "RMB/KG" || entitydts.Unit == "USD/KG")
                        {
                            entitydts.Amount = entitydts.Weight * entitydts.SinglePrice;
                        }
                        if (entitydts.Unit == "RMB/M" || entitydts.Unit == "USD/M")
                        {
                            entitydts.Amount = entitydts.Qty * entitydts.SinglePrice;
                        }
                        if (entitydts.Unit == "RMB/Y" || entitydts.Unit == "USD/Y")
                        {
                            entitydts.Amount = entitydts.Yard * entitydts.SinglePrice;
                        }
                        rule.RUpdate(entitydts, sqlTrans);

                        IOFormDtsPackRule prule = new IOFormDtsPackRule();
                        sql = "DELETE WH_IOFormDtsPack WHERE MainID=" + SysString.ToDBString(entitydts.MainID);
                        sql += " AND Seq=" + SysString.ToDBString(entitydts.Seq);
                        sqlTrans.ExecuteNonQuery(sql);
                        for (int j = 0; j < dtsql.Rows.Count; j++)
                        {
                            IOFormDtsPack pentity = new IOFormDtsPack(sqlTrans);
                            pentity.MainID = entitydts.MainID;
                            pentity.Seq = entitydts.Seq;
                            pentity.SubSeq = SysConvert.ToInt32(dtsql.Rows[j]["SubSeq"]); //zhoufc 2014.10.17 SubSeq表示卷号
                            pentity.GoodsLevel = SysConvert.ToString(dtsql.Rows[j]["GoodsLevel"]);
                            pentity.BoxNo = SysConvert.ToString(dtsql.Rows[j]["BoxNo"]);
                            pentity.Weight = SysConvert.ToDecimal(dtsql.Rows[j]["Weight"]);
                            pentity.Qty = SysConvert.ToDecimal(dtsql.Rows[j]["Qty"]);
                            pentity.Yard = SysConvert.ToDecimal(dtsql.Rows[j]["Yard"]);
                            pentity.DID = entitydts.ID;
                            prule.RAdd(pentity, sqlTrans);
                        }
                    }
                    else
                    {
                        sql = "SELECT * FROM WH_PackBox WHERE ID IN (" + p_IDStr + ")";
                        sql += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["WHID"]));
                        sql += " AND SectionID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["SectionID"]));
                        sql += " AND SBitID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["SBitID"]));
                        sql += " AND JarNum=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["JarNum"]));
                        sql += " AND Batch=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["Batch"]));
                        DataTable dtsql = sqlTrans.Fill(sql);

                        IOFormDts entitydts = new IOFormDts(sqlTrans);
                        entitydts.ID = p_ID;
                        entitydts.SelectByID();
                        entitydts.Seq = MaxSeq + i;
                        entitydts.WHID = SysConvert.ToString(dt.Rows[i]["WHID"]);
                        entitydts.SectionID = SysConvert.ToString(dt.Rows[i]["SectionID"]);
                        entitydts.SBitID = SysConvert.ToString(dt.Rows[i]["SBitID"]);
                        entitydts.JarNum = SysConvert.ToString(dt.Rows[i]["JarNum"]);
                        entitydts.Batch = SysConvert.ToString(dt.Rows[i]["Batch"]);
                        entitydts.Qty = SysConvert.ToDecimal(SysConvert.ToDecimal(dtsql.Compute("SUM(Qty)", "")));
                        entitydts.Weight = SysConvert.ToDecimal(SysConvert.ToDecimal(dtsql.Compute("SUM(Weight)", "")), 2);
                        entitydts.Yard = SysConvert.ToDecimal(SysConvert.ToDecimal(dtsql.Compute("SUM(Yard)", "")), 2);
                        entitydts.PieceQty = dtsql.Rows.Count;
                        entitydts.PackFlag = 1;
                        if (entitydts.Unit == "RMB/KG" || entitydts.Unit == "USD/KG")
                        {
                            entitydts.Amount = entitydts.Weight * entitydts.SinglePrice;
                        }
                        if (entitydts.Unit == "RMB/M" || entitydts.Unit == "USD/M")
                        {
                            entitydts.Amount = entitydts.Qty * entitydts.SinglePrice;
                        }
                        if (entitydts.Unit == "RMB/Y" || entitydts.Unit == "USD/Y")
                        {
                            entitydts.Amount = entitydts.Yard * entitydts.SinglePrice;
                        }
                        sql = "SELECT ID FROM WH_IOFormDts WHERE MainID=" + SysString.ToDBString(entitydts.MainID);
                        sql += " AND Seq=" + SysString.ToDBString(entitydts.Seq);
                        if (sqlTrans.Fill(sql).Rows.Count > 0)
                        {
                            throw new BaseException("不能增行，该行已存在");
                        }
                        rule.RAdd(entitydts, sqlTrans);
                        IOFormDtsPackRule prule = new IOFormDtsPackRule();
                        sql = "DELETE WH_IOFormDtsPack WHERE MainID=" + SysString.ToDBString(entitydts.MainID);
                        sql += " AND Seq=" + SysString.ToDBString(entitydts.Seq);
                        sqlTrans.ExecuteNonQuery(sql);
                        for (int j = 0; j < dtsql.Rows.Count; j++)
                        {
                            IOFormDtsPack pentity = new IOFormDtsPack(sqlTrans);
                            pentity.MainID = entitydts.MainID;
                            pentity.Seq = entitydts.Seq;
                            pentity.SubSeq = SysConvert.ToInt32(dtsql.Rows[j]["SubSeq"]); //zhoufc 2014.10.17 SubSeq表示卷号
                            pentity.GoodsLevel = SysConvert.ToString(dtsql.Rows[j]["GoodsLevel"]);
                            pentity.BoxNo = SysConvert.ToString(dtsql.Rows[j]["BoxNo"]);
                            pentity.Weight = SysConvert.ToDecimal(dtsql.Rows[j]["Weight"]);
                            pentity.Qty = SysConvert.ToDecimal(dtsql.Rows[j]["Qty"]);
                            pentity.Yard = SysConvert.ToDecimal(dtsql.Rows[j]["Yard"]);
                            pentity.DID = entitydts.ID;
                            prule.RAdd(pentity, sqlTrans);
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

        private int GetMaxSeq(int p_ID)
        {
            int MaxSeq = 0;
            string sql = "SELECT Max(Seq) Seq FROM WH_IOFormDts WHERE MainID=(SELECT MainID FROM WH_IOFormDts WHERE ID=" + SysString.ToDBString(p_ID) + ")";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                MaxSeq = SysConvert.ToInt32(dt.Rows[0][0]);
            }
            return MaxSeq;
        }

        #endregion




    }
}
