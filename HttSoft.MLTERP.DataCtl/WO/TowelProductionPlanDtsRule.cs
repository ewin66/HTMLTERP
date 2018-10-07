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
    /// 目的：WO_TowelProductionPlanDts实体业务规则类
    /// 作者:zhp
    /// 创建日期:2016/8/25
    /// </summary>
    public class TowelProductionPlanDtsRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public TowelProductionPlanDtsRule()
        {
        }

        /// <summary>
        /// 检查将要操作的数据是否符合业务规则
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            TowelProductionPlanDts entity = (TowelProductionPlanDts)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM WO_TowelProductionPlanDts WHERE 1=1";
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

        #region 保存
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
                TowelProductionPlanDts entitydts = (TowelProductionPlanDts)p_BE[i];
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
        public void RSave(TowelProductionPlan p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "DELETE FROM WO_TowelProductionPlanDts WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(p_BE));
                sqlTrans.ExecuteNonQuery(sql);//删除原单据里应该删除的明细数据，即数据库里有但是UI里已经删除的数据
                sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM WO_TowelProductionPlanDts WHERE MainID=" + p_Entity.ID.ToString();////找到最大的Seq    将获得最大Seq的语句放到循环外更高效(多人操作时会有问题吗?)
                int MSEQ = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());
                for (int i = 0; i < p_BE.Length; i++)
                {
                    TowelProductionPlanDts entitydts = (TowelProductionPlanDts)p_BE[i];
                    if (entitydts.ID != 0)//ID不为0说明数据库中已经存在
                    {
                        this.RUpdate(entitydts, sqlTrans);
                    }
                    else
                    {
                        entitydts.Seq = MSEQ;
                        entitydts.MainID = p_Entity.ID;
                        this.RAdd(entitydts, sqlTrans);

                        MSEQ++;//最大值加1
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
        public void RAdd(BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                TowelProductionPlanDts entity = (TowelProductionPlanDts)p_BE;
                TowelProductionPlanDtsCtl control = new TowelProductionPlanDtsCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WO_TowelProductionPlanDts, sqlTrans);
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

                TowelProductionPlanDts entity = (TowelProductionPlanDts)p_BE;
                if (entity.CardNo != "")
                {
                    string sql = "SELECT ItemCode FROM WO_TowelProductionPlanDts WHERE CardNo=" + SysString.ToDBString(entity.CardNo);
                    sql += " and ID <> " + entity.ID;
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        throw new BaseException("卡号已存在，请重新输入");
                    }
                }

                TowelProductionPlanDtsCtl control = new TowelProductionPlanDtsCtl(sqlTrans);
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
                TowelProductionPlanDts entity = (TowelProductionPlanDts)p_BE;
                TowelProductionPlanDtsCtl control = new TowelProductionPlanDtsCtl(sqlTrans);
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
        /// 提交
        /// </summary>
        /// <param name="p_FormID"></param>
        /// <param name="p_Type"></param>
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


        public void RSubmit(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        {
            try
            {
                int p_TempType = p_Type;//处理状态
                string sql = string.Empty;
                TowelProduction entity = new TowelProduction(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();

                sql = " select * from WO_TowelProductionPlanDts where CardNo = " + SysString.ToDBString(entity.CardNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    int stepID = SysConvert.ToInt32(dt.Rows[0]["StepID"]);
                    if (stepID != 0 && stepID > entity.WOTypeID)
                    {
                        throw new BaseException("该卡号不可逆向操作");
                    }
                }

                if (p_Type == 1)
                {
                    sql = " update WO_TowelProduction set SubmitFlag = " + p_Type;
                    sql += ",SubmitOPID=" + SysString.ToDBString(ParamConfig.LoginName) + ",SubmitTime=" + SysString.ToDBString(DateTime.Now);
                    sql += " where 1=1 and ID = " + p_FormID;
                    sqlTrans.ExecuteNonQuery(sql);

                    sql = "update WO_TowelProductionPlanDts set StepID = " + entity.WOTypeID;
                    sql += " where 1=1 and CardNo = " + SysString.ToDBString(entity.CardNo);
                    sqlTrans.ExecuteNonQuery(sql);
                }



                else if (p_Type == 0)
                {
                    sql = " update WO_TowelProduction set SubmitFlag = " + p_Type;
                    sql += ",SubmitOPID=" + SysString.ToDBString(ParamConfig.LoginName) + ",SubmitTime=" + SysString.ToDBString(DateTime.Now);
                    sql += " where 1=1 and ID = " + p_FormID;
                    sqlTrans.ExecuteNonQuery(sql);

                    sql = "update WO_TowelProductionPlanDts set StepID = ''";
                    sql += " where 1=1 and CardNo = " + SysString.ToDBString(entity.CardNo);
                    sqlTrans.ExecuteNonQuery(sql);
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






    }
}
