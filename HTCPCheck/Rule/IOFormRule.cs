using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;



namespace HttSoft.HTCPCheck.DataCtl
{
    /// <summary>
    /// 目的：WH_IOForm实体业务规则类
    /// 作者:陈加海
    /// 创建日期:2009-4-23
    /// </summary>
    public class IOFormRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public IOFormRule()
        {
        }

        /// <summary>
        /// 检查将要操作的数据是否符合业务规则
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            IOForm entity = (IOForm)p_BE;
        }

        #region 待整理代码
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
                string sql = "SELECT " + p_FieldName + " FROM WH_IOForm WHERE 1=1";
                sql += " AND ID IN(SELECT MainID FROM WH_IOFormDts WHERE 1=1 ";
                sql += ")";
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
        public DataTable RIOFormShow(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_IOFormDts WHERE 1=1 ";
         
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

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShowDtsPack(string p_condition)
        {
            try
            {
                return RShowDtsPack(p_condition, "*");
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
        public DataTable RShowDtsPack(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV2_WH_IOFormDtsPack WHERE 1=1";
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
        #region  主从表保存方法
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2, sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                IOForm entity = (IOForm)p_BE;
                IOFormDtsRule ruledts = new IOFormDtsRule();
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    IOFormDts entityDts = (IOFormDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    ruledts.RAdd(entityDts, sqlTrans);
                }

                //ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//保存从表
                //FormNoControlRule rulest = new FormNoControlRule();
                //rulest.RAddSort((int)FormNoControlEnum.入库单号,sqlTrans);


                FormNoControlRule rulefn = new FormNoControlRule();//更新单号
                int tempFormNoControlID = 0;
                string sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                    if (tempFormNoControlID == 0)//子类型没有配置 则读取主类型单号配置
                    {
                        sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.HeadType);
                        dt = sqlTrans.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                        }
                    }
                }
                rulefn.RAddSort(tempFormNoControlID, sqlTrans);

                #region 加载自动保存

                //sql = "SELECT * FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                //dt = sqlTrans.Fill(sql);
                //if (dt.Rows.Count != 0)
                //{
                //    int saveLoadFormType = SysConvert.ToInt32(dt.Rows[0]["LoadFormTypeID"]);
                //    if (saveLoadFormType == (int)LoadFormType.送货单)
                //    {
                //        sql = "SELECT LoadDtsID,ID,Seq FROM WH_IOFormDts WHERE MainID=" + SysString.ToDBString(entity.ID);
                //        dt = sqlTrans.Fill(sql);
                //        for (int i = 0; i < dt.Rows.Count; i++)
                //        {
                //            int LoadDtsID = SysConvert.ToInt32(dt.Rows[i]["LoadDtsID"]);
                //            int Seq = SysConvert.ToInt32(dt.Rows[i]["Seq"]);
                //            int ID = SysConvert.ToInt32(dt.Rows[i]["ID"]);
                //            int SubSeq = 1;
                //            if (LoadDtsID > 0)
                //            {
                //                sql = "SELECT * FROM Sale_FHFormDtsPack WHERE DID=" + SysString.ToDBString(LoadDtsID);
                //                DataTable dtfh = sqlTrans.Fill(sql);
                              
                //                for (int j = 0; j < dtfh.Rows.Count; j++)
                //                {
                //                    IOFormDtsPackRule rulePack = new IOFormDtsPackRule();
                //                    IOFormDtsPack entityPack = new IOFormDtsPack();
                //                    entityPack.MainID = entity.ID;
                //                    entityPack.Seq = Seq;
                //                    entityPack.DID = ID;
                //                    entityPack.SubSeq = SubSeq;
                //                    entityPack.BoxNo = SysConvert.ToString(dtfh.Rows[j]["BoxNo"]);
                //                    entityPack.Remark = SysConvert.ToString(dtfh.Rows[j]["BoxNo"]);
                //                    entityPack.Qty = SysConvert.ToDecimal(dtfh.Rows[j]["Qty"]);
                //                    SubSeq++;
                //                    rulePack.RAdd(entityPack,sqlTrans);
                                    
                //                }
                //            }
                //        }

                //    }
                //}

                
                #endregion

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
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd2(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd2(p_BE, p_BE2, sqlTrans);

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
        public void RAdd2(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                IOForm entity = (IOForm)p_BE;
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//保存从表
                FormNoControlRule rulest = new FormNoControlRule();
                //rulest.RAddSort((int)FormNoControlEnum.出库单号, sqlTrans);

                FormNoControlRule rulefn = new FormNoControlRule();//更新单号
                int tempFormNoControlID = 0;
                string sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                    if (tempFormNoControlID == 0)//子类型没有配置 则读取主类型单号配置
                    {
                        sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.HeadType);
                        dt = sqlTrans.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                        }
                    }
                }
                rulefn.RAddSort(tempFormNoControlID, sqlTrans);

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
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd3(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd3(p_BE, p_BE2, sqlTrans);

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
        public void RAdd3(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                IOForm entity = (IOForm)p_BE;
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//保存从表


                FormNoControlRule rulefn = new FormNoControlRule();//更新单号
                int tempFormNoControlID = 0;
                string sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                    if (tempFormNoControlID == 0)//子类型没有配置 则读取主类型单号配置
                    {
                        sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.HeadType);
                        dt = sqlTrans.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                        }
                    }
                }
                rulefn.RAddSort(tempFormNoControlID, sqlTrans);

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
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd4(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd4(p_BE, p_BE2, sqlTrans);

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
        public void RAdd4(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//保存从表



                IOForm entity = (IOForm)p_BE;
                FormNoControlRule rulefn = new FormNoControlRule();//更新单号
                int tempFormNoControlID = 0;
                string sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                    if (tempFormNoControlID == 0)//子类型没有配置 则读取主类型单号配置
                    {
                        sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.HeadType);
                        dt = sqlTrans.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                        }
                    }
                }
                rulefn.RAddSort(tempFormNoControlID, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {

                this.RUpdate(p_BE, sqlTrans);
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//保存从表


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

        #region 
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2,BaseEntity p_BE3, BaseEntity[] p_BE4)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2,p_BE3,p_BE4, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity p_BE3, BaseEntity[] p_BE4, IDBTransAccess sqlTrans)
        {
            try
            {

                this.RUpdate(p_BE, sqlTrans);
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//保存从表  

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
        public void RAdd(BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                IOForm entity = (IOForm)p_BE;
                IOFormCtl control = new IOFormCtl(sqlTrans);
                //校验单号唯一性
                string sql = "SELECT FormNo FROM WH_IOForm WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                if (sqlTrans.Fill(sql).Rows.Count != 0)
                {
                    throw new Exception("单号已经存在，请重新生成单号");
                }

                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WH_IOForm, sqlTrans);
                control.AddNew(entity);


                FormNoControlRule rulefn = new FormNoControlRule();//更新单号
                int tempFormNoControlID = 0;
                sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                    if (tempFormNoControlID == 0)//子类型没有配置 则读取主类型单号配置
                    {
                        sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.HeadType);
                        dt = sqlTrans.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                        }
                    }
                }
                rulefn.RAddSort(tempFormNoControlID, sqlTrans);
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
                IOForm entity = (IOForm)p_BE;
                IOFormCtl control = new IOFormCtl(sqlTrans);
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
                IOForm entity = (IOForm)p_BE;
                IOFormCtl control = new IOFormCtl(sqlTrans);

                string sql = string.Empty;
                int FormListTopType = IOFormDtsRule.GetFormListTopTypeByFormListID(entity.HeadType, sqlTrans);//顶层单据类型


                if (FormListTopType == (int)WHFormList.期初入库 || FormListTopType == (int)WHFormList.入库)//如果是入库
                {
                    sql = "DELETE FROM WH_PackBox WHERE BoxNo IN(SELECT BoxNo FROM WH_IOFormDtsPack WHERE MainID=" + entity.ID.ToString() + ")";
                    sqlTrans.ExecuteNonQuery(sql);//删除入库码单数据
                }

                sql = "DELETE FROM WH_IOFormDts WHERE MainID=" + entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//删除原单据明细数据


                sql = "DELETE FROM WH_IOFormDtsPack WHERE MainID=" + entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//删除原单据码单明细数据



                sql = "DELETE FROM WH_IOFormDtsInputPack WHERE MainID=" + entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//删除原单据录入码单明细数据


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
        public void RDelete(int p_IOFormID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    RDelete(p_IOFormID, sqlTrans);

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


    

        #region 其他事件
        /// <summary>
        /// 根据大货系列号从采购单得到样衣系列号
        /// </summary>
        /// <param name="p_dsn"></param>
        /// <returns></returns>
        public DataTable GetSSN(string p_dsn)
        {
            string sql = "SELECT * FROM Buy_YarnCompact WHERE DSN="+SysString.ToDBString(p_dsn);
            DataTable dt = SysUtils.Fill(sql);
            return dt;

        }
        public DataTable GetSSNFromSOM(string p_dsn)
        {
            string sql = " SELECT * FROM Sale_SOM WHERE DSN=" + SysString.ToDBString(p_dsn);
            DataTable dt = SysUtils.Fill(sql);
            return dt;
        }
        #endregion


   

        #region 新增方法
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList List)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2, List, sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList list, IDBTransAccess sqlTrans)
        {
            try
            {

                //RCheckMDQty(p_BE, p_BE2, list);//校验码单明细和单据明细数量是否一致

                IOForm entity = (IOForm)p_BE;
                this.RAdd(p_BE, sqlTrans);
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, (IOFormDts[])p_BE2, sqlTrans);//保存从表


                IOFormDtsPackRule dtsprule = new IOFormDtsPackRule();//保存码单明细
                dtsprule.RSave(entity, (IOFormDts[])p_BE2, list, sqlTrans);


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
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd2(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList List)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd2(p_BE, p_BE2, List, sqlTrans);

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
        public void RAdd2(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList list, IDBTransAccess sqlTrans)
        {
            try
            {
                //RCheckMDQty(p_BE, p_BE2, list);//校验码单明细和单据明细数量是否一致

                IOForm entity = (IOForm)p_BE;

                this.RAdd(p_BE, sqlTrans);
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//保存从表


                IOFormDtsPackRule dtsprule = new IOFormDtsPackRule();//保存码单明细
                dtsprule.RSave(entity, (IOFormDts[])p_BE2, list, sqlTrans);

              
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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList list)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2, list, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList list, IDBTransAccess sqlTrans)
        {
            try
            {

                //RCheckMDQty(p_BE, p_BE2, list);//校验码单明细和单据明细数量是否一致

                IOForm entity = (IOForm)p_BE;
                this.RUpdate(p_BE, sqlTrans);
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, (IOFormDts[])p_BE2, sqlTrans);//保存从表

                //删除数据库中此单据类型的码单信息2011-07-12

                IOFormDtsPackRule dtsprule = new IOFormDtsPackRule();//保存码单明细
                dtsprule.RSave(entity, (IOFormDts[])p_BE2, list, sqlTrans);
              
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


        #region 提交方法
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
                IOForm entity = new IOForm(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();

                //if (!RSubmitCheckJS(entity.FormDate, sqlTrans))
                //{
                //    throw new Exception("不允许操作，此单据日期之后已经有结算数据");
                //}

                if (entity.SubmitFlag == p_Type)//如果相同异常
                {
                    throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
                }

                int p_AuditFlag = -1;
                sql = "SELECT FillDataTypeID,AuditFlag,WHQtyPosID,CheckQtyPer1,CheckQtyFrom,CheckQtyPer2,DZFlag FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                DataTable dtFormList = sqlTrans.Fill(sql);
                if (dtFormList.Rows.Count != 0)
                {
                    p_AuditFlag = SysConvert.ToInt32(dtFormList.Rows[0]["AuditFlag"]);
                    if (p_AuditFlag == 0)//不需要审核
                    {
                        switch (p_Type)
                        {
                            case (int)ConfirmFlag.未提交:
                                //p_Type=(int)ConfirmFlag.未提交;
                                break;
                            case (int)ConfirmFlag.已提交:
                                p_Type = (int)ConfirmFlag.审核通过;
                                break;
                            case (int)ConfirmFlag.审核通过:
                                //								p_Type=(int)ConfirmFlag.审核通过;
                                break;
                            case (int)ConfirmFlag.审核拒绝:
                                p_Type = (int)ConfirmFlag.未提交;
                                break;
                        }
                    }

                    #region 提交
                    sql = "UPDATE WH_IOForm SET SubmitFlag=" + SysString.ToDBString(p_Type);
                    if (p_Type == (int)ConfirmFlag.审核通过 || p_Type == (int)ConfirmFlag.审核拒绝)
                    {
                        sql += ",SubmitOPID=" + SysString.ToDBString(ParamConfig.LoginName) + ",SubmitTime=" + SysString.ToDBString(DateTime.Now);
                    }
                    sql += " WHERE ID=" + p_FormID.ToString();//更新单据主表审核状态
                    sqlTrans.ExecuteNonQuery(sql);

                    //更新转换后单据的状态
                    sql = "UPDATE WH_IOForm SET SubmitFlag=" + SysString.ToDBString(p_Type);
                    if (p_Type == (int)ConfirmFlag.审核通过 || p_Type == (int)ConfirmFlag.审核拒绝)
                    {
                        sql += ",SubmitOPID=" + SysString.ToDBString(ParamConfig.LoginName) + ",SubmitTime=" + SysString.ToDBString(DateTime.Now);
                    }
                    sql += " WHERE FromIOFormID=" + p_FormID.ToString();
                    sqlTrans.ExecuteNonQuery(sql);


                    //开始检验和判断是否需要提交
                    int TempSubmitType = 0;//提交和撤销提交状态
                    bool SubmitFlag = false;//是否需要提交
                    if (p_AuditFlag == 0)//不需要审核
                    {
                        switch (p_TempType)
                        {
                            case (int)ConfirmFlag.审核通过:
                                SubmitFlag = true;
                                TempSubmitType = 1;
                                break;
                            case (int)ConfirmFlag.审核拒绝:
                                TempSubmitType = 0;
                                break;
                            case (int)ConfirmFlag.已提交:
                                SubmitFlag = true;
                                TempSubmitType = 1;
                                break;
                            case (int)ConfirmFlag.未提交:
                                SubmitFlag = true;
                                TempSubmitType = 0;
                                break;
                        }
                    }
                    else//需要审核
                    {
                        switch (p_TempType)
                        {
                            case (int)ConfirmFlag.审核通过:
                                TempSubmitType = 1;
                                SubmitFlag = true;
                                break;
                            case (int)ConfirmFlag.审核拒绝:
                                if (entity.SubmitFlag == (int)ConfirmFlag.审核通过)//如果之前的状态是审核通过的才执行
                                {
                                    TempSubmitType = 0;
                                    SubmitFlag = true;
                                }
                                break;
                            case (int)ConfirmFlag.已提交:
                                break;
                            case (int)ConfirmFlag.未提交:
                                break;
                        }
                    }

                    if (SubmitFlag)//需要执行提交操作
                    {

                        IOFormDtsRule ruledts = new IOFormDtsRule();
                        ruledts.RSubmit(p_FormID, TempSubmitType, dtFormList.Rows[0], sqlTrans);//操作子表库存

                    }
                    #endregion


                }
                if (entity.SubmitFlag == p_Type)//如果相同异常
                {
                    throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
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
