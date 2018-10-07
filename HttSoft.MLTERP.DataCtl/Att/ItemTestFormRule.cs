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
    /// 目的：Att_ItemTestForm实体业务规则类
    /// 作者:陈加海
    /// 创建日期:2012-4-17
    /// </summary>
    public class ItemTestFormRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ItemTestFormRule()
        {
        }

        /// <summary>
        /// 检查将要操作的数据是否符合业务规则
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            ItemTestForm entity = (ItemTestForm)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Att_ItemTestForm WHERE 1=1";
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
                ItemTestForm entity = (ItemTestForm)p_BE;
                ItemTestFormCtl control = new ItemTestFormCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Att_ItemTestForm, sqlTrans);
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
                ItemTestForm entity = (ItemTestForm)p_BE;
                ItemTestFormCtl control = new ItemTestFormCtl(sqlTrans);
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
                ItemTestForm entity = (ItemTestForm)p_BE;
                ItemTestFormCtl control = new ItemTestFormCtl(sqlTrans);
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
        #region  添加的方法  whm
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
                this.CheckCorrect(p_BE);
                ItemTestForm entity = (ItemTestForm)p_BE;

                string sql = "SELECT FormNo FROM Att_ItemTestForm WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("测试单号已存在，请重新生成");
                }
                if (entity.BGNo != "")
                {
                    sql = "SELECT BGNo FROM Att_ItemTestForm WHERE BGNo=" + SysString.ToDBString(entity.BGNo);
                    dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        throw new BaseException("报告编号已存在，请检查后输入");
                    }
                }
                ItemTestFormCtl control = new ItemTestFormCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Att_ItemTestForm, sqlTrans);
                control.AddNew(entity);
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    ItemTestFormDtsRule rule = new ItemTestFormDtsRule();
                    ItemTestFormDts entityDts = (ItemTestFormDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    rule.RAdd(entityDts, sqlTrans);
                }
                FormNoControlRule rulest = new FormNoControlRule();
                rulest.RAddSort((int)FormNoControlEnum.检验单号, sqlTrans);
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
                this.CheckCorrect(p_BE);
                ItemTestForm entity = (ItemTestForm)p_BE;
                ItemTestFormCtl control = new ItemTestFormCtl(sqlTrans);
                control.Update(entity);
                ItemTestFormDtsRule rule = new ItemTestFormDtsRule();
                rule.RSave(entity, p_BE2, sqlTrans);
                //string sql = "DELETE Att_ItemTestFormDts WHERE MainID="+SysString.ToDBString(entity.ID);
                //sqlTrans.ExecuteNonQuery(sql);
                //for (int i = 0; i < p_BE2.Length; i++)
                //{
                //    ItemTestFormDtsRule rule = new ItemTestFormDtsRule();
                //    ItemTestFormDts entityDts = (ItemTestFormDts)p_BE2[i];
                //    entityDts.MainID = entity.ID;
                //    entityDts.Seq = i + 1;
                //    rule.RAdd(entityDts, sqlTrans);
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


        #endregion

        #region 提交/撤销提交
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
                string str = string.Empty;
                ItemTestForm entity = new ItemTestForm(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//如果相同异常
                {
                    throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
                }
                entity.SubmitFlag = p_Type;
                this.RUpdate(entity, sqlTrans);//更新主表状态
                switch(p_Type)
                {
                    case 1:
                        sql = "SELECT * FROM Att_ItemTestForm WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode);
                        sql += " AND ColorNum=" + SysString.ToDBString(entity.ColorNum);
                        sql += " AND ColorName=" + SysString.ToDBString(entity.ColorName);
                        sql += " AND SubmitFlag=1";
                        DataTable dt = sqlTrans.Fill(sql);
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (str != "")
                                {
                                    str += ",";
                                }
                                str += SysConvert.ToString(dt.Rows[i]["FormNo"]);
                            }
                            sql = "UPDATE Data_ItemGB SET testReportFlag=1,testReportNum=" + SysString.ToDBString(str) + " WHERE 1=1 ";
                            sql += " AND MainID IN(SELECT ID FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode);
                            sql += ")";
                            sql += " AND ColorNum=" + SysString.ToDBString(entity.ColorNum);
                            sql += " AND ColorName=" + SysString.ToDBString(entity.ColorName);
                            sqlTrans.ExecuteNonQuery(sql);
                        }

                        sql = "UPDATE Sale_SaleOrderDts SET BGNo="+SysString.ToDBString(entity.FormNo);
                        sql += " WHERE ID="+SysString.ToDBString(entity.DLoadID);
                        sqlTrans.ExecuteNonQuery(sql);

                        sql = "UPDATE Buy_ItemBuyFormDts SET BGNo=" + SysString.ToDBString(entity.FormNo);
                        sql += " WHERE DLoadID=" + SysString.ToDBString(entity.DLoadID);
                        sqlTrans.ExecuteNonQuery(sql);
                    break;
                    case 0:
                        sql = "SELECT * FROM Att_ItemTestForm WHERE ItemCode="+SysString.ToDBString(entity.ItemCode);
                        sql += " AND ColorNum="+SysString.ToDBString(entity.ColorNum);
                        sql += " AND ColorName="+SysString.ToDBString(entity.ColorName);
                        sql += " AND SubmitFlag=1";
                        dt = sqlTrans.Fill(sql);
                        if (dt.Rows.Count == 0)
                        {
                            sql = "UPDATE Data_ItemGB SET testReportFlag=0,testReportNum='' WHERE 1=1 ";
                            sql += " AND MainID IN(SELECT ID FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode);
                            sql += ")";
                            sql += " AND ColorNum=" + SysString.ToDBString(entity.ColorNum);
                            sql += " AND ColorName=" + SysString.ToDBString(entity.ColorName);
                            sqlTrans.ExecuteNonQuery(sql);
                        }
                        else
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (str != "")
                                {
                                    str += ",";
                                }
                                str += SysConvert.ToString(dt.Rows[i]["FormNo"]);
                            }
                            sql = "UPDATE Data_ItemGB SET  testReportFlag=1,testReportNum=" + SysString.ToDBString(str) + " WHERE 1=1 ";
                            sql += " AND MainID IN(SELECT ID FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode);
                            sql += ")";
                            sql += " AND ColorNum=" + SysString.ToDBString(entity.ColorNum);
                            sql += " AND ColorName=" + SysString.ToDBString(entity.ColorName);
                            sqlTrans.ExecuteNonQuery(sql);
                        }

                        sql = "UPDATE Sale_SaleOrderDts SET BGNo=''";// +SysString.ToDBString(entity.BGNo);
                        sql += " WHERE ID=" + SysString.ToDBString(entity.DLoadID);
                        sqlTrans.ExecuteNonQuery(sql);

                        sql = "UPDATE Buy_ItemBuyFormDts SET BGNo=''";// +SysString.ToDBString(entity.BGNo);
                        sql += " WHERE DLoadID=" + SysString.ToDBString(entity.DLoadID);
                        sqlTrans.ExecuteNonQuery(sql);
                        break;
                }



        }
           
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }


        #endregion



    }
}