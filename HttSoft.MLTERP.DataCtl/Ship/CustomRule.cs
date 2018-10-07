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
    /// 目的：Ship_Custom实体业务规则类
    /// 作者:潘杰俊
    /// 创建日期:2009-4-28
    /// </summary>
    public class CustomRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomRule()
        {
        }

        /// <summary>
        /// 检查将要操作的数据是否符合业务规则
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            Custom entity = (Custom)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Ship_CustomInvoiceDts WHERE 1=1";
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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2, p_BE3, p_BE4, p_BE5, sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                CustomDtsRule ruledts = new CustomDtsRule();
                ruledts.RSave((Custom)p_BE, p_BE2, sqlTrans);//保存从表

                //CustomPackDtsRule packruledts = new CustomPackDtsRule();
                //packruledts.RSave((Custom)p_BE, p_BE3, sqlTrans);//保存从表

                //CustomReportDtsRule Reportruledts = new CustomReportDtsRule();
                //Reportruledts.RSave((Custom)p_BE, p_BE4, sqlTrans);//保存从表

                CustomInvoiceDtsRule Invoiceruledts = new CustomInvoiceDtsRule();
                Invoiceruledts.RSave((Custom)p_BE, p_BE5, sqlTrans);//保存从表


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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2, p_BE3, p_BE4, p_BE5, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, IDBTransAccess sqlTrans)
        {
            try
            {

                this.RUpdate(p_BE, sqlTrans);
                CustomDtsRule ruledts = new CustomDtsRule();
                ruledts.RSave((Custom)p_BE, p_BE2, sqlTrans);//保存从表

                CustomPackDtsRule packruledts = new CustomPackDtsRule();
                packruledts.RSave((Custom)p_BE, p_BE3, sqlTrans);//保存从表

                CustomReportDtsRule Reportruledts = new CustomReportDtsRule();
                Reportruledts.RSave((Custom)p_BE, p_BE4, sqlTrans);//保存从表

                CustomInvoiceDtsRule Invoiceruledts = new CustomInvoiceDtsRule();
                Invoiceruledts.RSave((Custom)p_BE, p_BE5, sqlTrans);//保存从表

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
                Custom entity = (Custom)p_BE;
                CustomCtl control = new CustomCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Ship_Custom, sqlTrans);
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
                Custom entity = (Custom)p_BE;
                CustomCtl control = new CustomCtl(sqlTrans);
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
                Custom entity = (Custom)p_BE;
                CustomCtl control = new CustomCtl(sqlTrans);


                string sql = "DELETE FROM Ship_CustomDts WHERE MainID=" + entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//删除原单据明细数据

                sql = "DELETE FROM Ship_CustomPackDts WHERE MainID=" + entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//删除原单据明细数据

                sql = "DELETE FROM Ship_CustomInvoiceDts WHERE MainID=" + entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//删除原单据明细数据
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

        #region 提交
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RSubmit(Custom p_BE)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSubmit(p_BE, sqlTrans);

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

        public void RSubmit(Custom p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                if (p_BE.SubmitFlag == 0)
                {
                    p_BE.SubmitFlag = 1;
                    RUpdate(p_BE, sqlTrans);

                    #region 自动产生清关文件
                    string sql = "SELECT MainID,Seq FROM Ship_CustomInvoiceDts WHERE MainID=" + p_BE.ID;//准备明细数据源
                    DataTable dtdts1 = sqlTrans.Fill(sql);//准备明细数据源

                    string sqlcheck = "SELECT ID FROM Ship_Custom WHERE InvoiceNo=" + SysString.ToDBString(p_BE.InvoiceNo) + " AND CompanyTypeID=3";
                    DataTable dtcheck = sqlTrans.Fill(sqlcheck);//检查是否已经自动产生了清关文件
                    if (dtcheck.Rows.Count == 0)//没有产生的情况下才执行
                    {
                        p_BE.CompanyTypeID = 3;
                        p_BE.ID = 0;
                        RAdd(p_BE, sqlTrans);


                        foreach (DataRow dr in dtdts1.Rows)//增加发票明细
                        {
                            CustomInvoiceDts entitydts1 = new CustomInvoiceDts(sqlTrans);
                            entitydts1.MainID = SysConvert.ToInt32(dr["MainID"]);
                            entitydts1.Seq = SysConvert.ToInt32(dr["Seq"]);
                            entitydts1.SelectByID();

                            entitydts1.MainID = p_BE.ID;

                            CustomInvoiceDtsRule ruledts1 = new CustomInvoiceDtsRule();
                            ruledts1.RAdd(entitydts1, sqlTrans);

                        }
                        //后面可以增加其他明细数据，代码和上面类似。。。

                    }

                    #endregion
                }
                else
                {
                    throw new Exception("单据不是未提交状态请检查！");
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
