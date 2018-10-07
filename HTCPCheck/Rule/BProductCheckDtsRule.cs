using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;




namespace HttSoft.HTCPCheck.DataCtl
{
    /// <summary>
    /// 目的：WO_BProductCheckDts实体业务规则类
    /// 作者:朱小涛
    /// 创建日期:2013/3/21
    /// </summary>
    public class BProductCheckDtsRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BProductCheckDtsRule()
        {
        }

        /// <summary>
        /// 检查将要操作的数据是否符合业务规则
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            BProductCheckDts entity = (BProductCheckDts)p_BE;
        }

        ///// <summary>
        ///// 检验字段值是否已存在
        ///// </summary>
        ///// <param name="p_TableName">表名</param>
        ///// <param name="p_FieldName">字段名</param>
        ///// <param name="p_FieldValue">字段值</param>
        ///// <param name="p_KeyField">主键（只考虑主键为ID的情况）</param>
        ///// <param name="p_KeyValue">主键值</param>
        ///// <param name="p_sqlTrans"></param>
        ///// <returns></returns>
        //private bool CheckFieldValueIsExist(BaseEntity p_BE, string p_FieldName, string p_FieldValue, IDBTransAccess p_sqlTrans)
        //{
        //    BProductCheckDts entity = (BProductCheckDts)p_BE;
        //    bool ret = false;
        //    string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, BProductCheckDts.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
        //    DataTable dt = p_sqlTrans.Fill(sql);
        //    if (dt.Rows.Count != 0)
        //    {
        //        ret = true;
        //    }

        //    return ret;
        //}
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
                string sql = "SELECT " + p_FieldName + " FROM WO_BProductCheckDts WHERE 1=1";
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

                BProductCheckDts entity = (BProductCheckDts)p_BE;


                if (entity.ID == 0)
                {
                    BProductCheckDtsCtl control = new BProductCheckDtsCtl(sqlTrans);
                    entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WO_BProductCheckDts, sqlTrans);
                    if (entity.Seq == 0)
                    {
                        entity.StatusID = (int)EnumBoxStatus.未入库;
                        entity.DISN = GetDISN(sqlTrans);
                        entity.Seq = GetMaxSeq(entity.MainID, entity.JarNum, sqlTrans);

                        
                    }

                    //CalcQty(entity);
                    control.AddNew(entity);
                }
                else
                {
                    if (entity.StatusID != (int)EnumBoxStatus.未入库)//已经入库的条码不能修改
                    {
                        throw new Exception("条码不是初始状态不能修改");
                    }

                    RUpdate(entity, sqlTrans);
                }

                ///RCalcMZJZ(entity, sqlTrans);
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
        public void RAdd2(BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                BProductCheckDts entity = (BProductCheckDts)p_BE;
                BProductCheckDtsCtl control = new BProductCheckDtsCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WO_BProductCheckDts, sqlTrans);
                control.AddNew(entity);
                RCalcMZJZ(entity, sqlTrans);
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
        /// 得到条码号
        /// </summary>
        /// <param name="sqlTrans"></param>
        /// <returns></returns>
        string GetDISN(IDBTransAccess sqlTrans)
        {
            string Str = string.Empty;
            string sql = "SELECT MAX(DISN) DISN FROM WO_BProductCheckDts WHERE DISN LIKE " + SysString.ToDBString(DateTime.Now.ToString("yyyyMMdd") + "____");
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["DISN"].ToString() == string.Empty)
                {
                    return DateTime.Now.ToString("yyyyMMdd") + "0001";
                }
                else
                {
                    Str = dt.Rows[0]["DISN"].ToString();
                    Str = Str.Substring(8, 4);
                    return DateTime.Now.ToString("yyyyMMdd") + SysString.LongToStr(SysConvert.ToInt32(Str) + 1, 4);
                }
            }
            else
            {
                return DateTime.Now.ToString("yyyyMMdd") + "0001";
            }
            return Str;
        }

        public int GetMaxSeq(int p_ID, string JarNum, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT MAX(Seq) Seq FROM WO_BProductCheckDts WHERE JarNum=" + SysString.ToDBString(JarNum);
            sql += " AND MainID=" + p_ID;
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                return SysConvert.ToInt32(dt.Rows[0]["Seq"]) + 1;
            }
            else
            {
                return 1;
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
                BProductCheckDts entity = (BProductCheckDts)p_BE;
                BProductCheckDtsCtl control = new BProductCheckDtsCtl(sqlTrans);
                //CalcQty(entity);
                control.Update(entity);

                //RCalcMZJZ(entity, sqlTrans);
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


        private void CalcQty(BProductCheckDts entity)
        {
            //==entity.KF25=1 开匹后新增加条码，entity.KF20 = 1，被开匹过的条码
            if (entity.KF25 != 1 && entity.KF20 != 1)//不是开匹的才计算
            {
                entity.KF = entity.RCKF + entity.ZCKF;//合计扣分=织疵点+染疵点
                entity.Qty = entity.SM - entity.CJRC - entity.CJZC - entity.FMZC - entity.FMRC - entity.CY - entity.MQty3;
                entity.MQty4 = entity.SM - entity.CJRC - entity.CJZC - entity.FMZC - entity.FMRC - entity.CY - entity.MQty3;
                if (entity.Qty != 0m)
                {
                    entity.BMKF = entity.KF / entity.Qty;
                }

                if (entity.MQty4 != 0m)
                {
                    entity.FMQty = SysConvert.ToDecimal(entity.MQty4 * 1.0936132983377m);
                }
                else
                {
                    entity.FMQty = SysConvert.ToDecimal(entity.Qty * 1.0936132983377m);
                }
                if (!SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6428)))//仓库出库选择客户直接带出该客户相关单据
                {
                    entity.Qty = GetChangeQty(entity.Qty);
                    entity.FMQty = GetChangeQty(entity.FMQty);
                }
              


            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RUpdate2(BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                BProductCheckDts entity = (BProductCheckDts)p_BE;
                BProductCheckDtsCtl control = new BProductCheckDtsCtl(sqlTrans);
                control.Update(entity);

                RCalcMZJZ(entity, sqlTrans);
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
        /// 改变数量算法
        /// </summary>
        /// <param name="Qty"></param>
        /// <returns></returns>
        private decimal GetChangeQty(decimal Qty)
        {
            decimal MQty = Qty;


            if (Qty.ToString().IndexOf('.') >= 0)
            {
                string strBase = Qty.ToString().Substring(0, Qty.ToString().IndexOf('.'));
                string str = Qty.ToString().Substring(Qty.ToString().IndexOf('.') + 1, Qty.ToString().Length - Qty.ToString().IndexOf('.') - 1);
                decimal X = SysConvert.ToDecimal("0." + str);
                if (X < 0.3m)
                {
                    MQty = SysConvert.ToDecimal(strBase);
                }
                else if (X >= 0.3m && X < 0.7m)
                {
                    MQty = SysConvert.ToDecimal(strBase + ".5");
                }
                else
                {
                    MQty = SysConvert.ToDecimal(strBase) + 1m;
                }

            }

            return MQty;
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
                BProductCheckDts entity = (BProductCheckDts)p_BE;
                BProductCheckDtsCtl control = new BProductCheckDtsCtl(sqlTrans);
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


        #region

        /// <summary>
        /// 修改条码状态
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void ModifyLog(BProductCheckDts p_BE, BProductCheckDtsModifyLog p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.ModifyLog(p_BE, p_BE2, sqlTrans);

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
        public void ModifyLog(BProductCheckDts p_BE, BProductCheckDtsModifyLog p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {


                if (p_BE.StatusID != (int)EnumBoxStatus.未入库)
                {
                    throw new Exception("不是已经出库的条码，不能修改");
                }

                if (p_BE.KF24 == 1)
                {
                    throw new Exception("此匹布已经修改过一次了，不能在此修改");
                }

                #region 备份的老条码
                BProductCheckDts entityold = new BProductCheckDts(sqlTrans);
                entityold.ID = p_BE.ID;
                entityold.SelectByID();//复制的老条码
                #endregion


                #region 更新老的条码为新的条码，只换条码号，和修改的内容，其他信息不变
                if (p_BE2.CompactNo != string.Empty)
                {
                    p_BE2.OldCompactNo = p_BE.CompactNo;

                    p_BE.CompactNo = p_BE2.CompactNo;

                    string sqlcheck = "SELECT ID FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(p_BE2.CompactNo) + " AND SubmitFlag=1";
                    DataTable dtcheck = sqlTrans.Fill(sqlcheck);
                    if (dtcheck.Rows.Count != 1)
                    {
                        throw new Exception("变更的合同号不存在，请检查");
                    }

                }
                if (p_BE2.JarNum != string.Empty)
                {
                    p_BE2.OldJarNum = p_BE.JarNum;


                    p_BE.JarNum = p_BE2.JarNum;


                }

                if (p_BE2.Seq != 0)
                {
                    p_BE2.OldSeq = p_BE.Seq;

                    p_BE.Seq = p_BE2.Seq;
                }



                p_BE.KF24 = 0;
                p_BE.KF22 = 1;//退货冲销后产生的新的条码
                p_BE.DISN = GetDISN(sqlTrans);
                p_BE.StatusID = (int)EnumBoxStatus.未入库;
                RUpdate2(p_BE, sqlTrans);

                #endregion


                #region 备份老的条码，标志为不可修改，并增加Log日志
                p_BE2.ModifyID = p_BE.ID;
                entityold.StatusID = (int)EnumBoxStatus.未入库;
                entityold.KF24 = 1;//修改后新产生条码

                entityold.ID = 0;
                RAdd2(entityold, sqlTrans);
                p_BE2.NewISNID = entityold.ID;//新产生条码的ID
                BProductCheckDtsModifyLogRule rule = new BProductCheckDtsModifyLogRule();
                rule.RAdd(p_BE2, sqlTrans);
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
        #endregion


        /// <summary>
        /// 计算毛重净重
        /// </summary>
        /// <param name="p_BE">要删除的实体</param>
        public void RCalcMZJZ(BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                //BProductCheckDts entity = p_BE as BProductCheckDts;
                //string sql = "SELECT CWith,CWeight,FMQty,Qty,JSUnit FROM UV1_WO_BProductCheckDts WHERE DISN="+SysString.ToDBString(entity.DISN);
                //DataTable dt = sqlTrans.Fill(sql);
                //if (dt.Rows.Count != 0)
                //{
                //    //if (dt.Rows[0]["JSUnit"].ToString() == "Y")
                //    //{
                //    //    entity.MQty = SysConvert.ToDecimal(dt.Rows[0]["CWeight"]) * SysConvert.ToDecimal(dt.Rows[0]["FMQty"])/1000m;
                //    //}
                //    //else
                //    //{
                //        entity.MQty = SysConvert.ToDecimal(dt.Rows[0]["CWeight"]) * SysConvert.ToDecimal(dt.Rows[0]["Qty"])/1000m;
                //    //}
                //    entity.MWeight = entity.MQty + 0.3m;

                //    sql = "UPDATE WO_BProductCheckDts SET MQty=" + SysString.ToDBString(entity.MQty.ToString()) + ",MWeight=" + SysString.ToDBString(entity.MWeight.ToString()) + " WHERE DISN=" + SysString.ToDBString(entity.DISN);
                //    sqlTrans.Fill(sql);
                //}


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
