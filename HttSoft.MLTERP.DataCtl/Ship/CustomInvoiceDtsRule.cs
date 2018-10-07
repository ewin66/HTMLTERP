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
    /// 目的：Ship_CustomInvoiceDts实体业务规则类
    /// 作者:鲁帆
    /// 创建日期:2015-1-12
    /// </summary>
    public class CustomInvoiceDtsRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomInvoiceDtsRule()
        {
        }

        /// <summary>
        /// 检查将要操作的数据是否符合业务规则
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            CustomInvoiceDts entity = (CustomInvoiceDts)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM Ship_CustomInvoiceDts WHERE 1=1";
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Ship_CustomDts WHERE 1=1";
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
        /// 保存(传入事务处理)
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <param name="p_BE"></param>
        /// <param name="sqlTrans"></param>
        public void RSave(Custom p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "DELETE FROM Ship_CustomInvoiceDts WHERE MainID=" + p_Entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//删除原单据明细数据

                // sql = "DELETE FROM Ship_CustomDts WHERE MainID=" + p_Entity.ID.ToString();
                //sqlTrans.ExecuteNonQuery(sql);//删除原单据明细数据

                for (int i = 0; i < p_BE.Length; i++)
                {
                    CustomInvoiceDts entitydts = (CustomInvoiceDts)p_BE[i];
                    sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM Ship_CustomInvoiceDts WHERE MainID=" + p_Entity.ID.ToString();
                    entitydts.Seq = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());//找到最大的Seq
                    entitydts.MainID = p_Entity.ID;
                    this.RAdd(entitydts, sqlTrans);

                    //sql = " UPDATE Ship_Ship_PackPlan Set LoadFlag=1 WHERE ID=" + entitydts.PackPlanID;//更新已加载标志
                    //sqlTrans.ExecuteNonQuery(sql);
                }

                /////根据保存汇总信息保存到 Ship_CustomDts中           
                //sql = "select Style,Model,MWidth,MWeight,Unit,SinglePrice,QGSinglePrice, SUM(Qty) Qty,SUM(Amount) Amount,SUM(QGQty) QGQty,SUM(QGAmount) QGAmount ";
                //sql += " ,SUM(Volume) Volume,SUM(GrossWeight) GrossWeight,SUM(NetWeight) NetWeight from Ship_CustomInvoiceDts where 1=1";
                //sql += " AND MainID=" + p_Entity.ID;
                //sql += " Group By Style,Model,MWidth,MWeight,Unit,SinglePrice,QGSinglePrice";
                //DataTable dtDts = sqlTrans.Fill(sql);
                //if (dtDts.Rows.Count != 0)
                //{
                //    CustomDtsRule ruleDts = new CustomDtsRule();
                //    for (int i = 0; i < dtDts.Rows.Count; i++)
                //    {
                //        CustomDts entityDts = new CustomDts(sqlTrans);
                //        entityDts.MainID = p_Entity.ID;
                //        entityDts.Seq = i + 1;

                //        entityDts.Style = SysConvert.ToString(dtDts.Rows[i]["Style"]);
                //        entityDts.Model = SysConvert.ToString(dtDts.Rows[i]["Model"]);
                //        //entityDts.MWidth = SysConvert.ToString(dtDts.Rows[i]["MWidth"]);
                //        //entityDts.MWeight = SysConvert.ToString(dtDts.Rows[i]["MWeight"]);
                //        entityDts.Unit = SysConvert.ToString(dtDts.Rows[i]["Unit"]);
                //        entityDts.SinglePrice = SysConvert.ToDecimal(dtDts.Rows[i]["SinglePrice"]);
                //        //entityDts.QGSinglePrice = SysConvert.ToString(dtDts.Rows[i]["QGSinglePrice"]);
                //        entityDts.Qty = SysConvert.ToInt32(dtDts.Rows[i]["Qty"]);



                //        ruleDts.RAdd(entityDts, sqlTrans);

                //    }
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
                CustomInvoiceDts entity = (CustomInvoiceDts)p_BE;
                CustomInvoiceDtsCtl control = new CustomInvoiceDtsCtl(sqlTrans);
                //entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Ship_CustomDts,sqlTrans);
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
                CustomInvoiceDts entity = (CustomInvoiceDts)p_BE;
                CustomInvoiceDtsCtl control = new CustomInvoiceDtsCtl(sqlTrans);
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
                CustomInvoiceDts entity = (CustomInvoiceDts)p_BE;
                CustomInvoiceDtsCtl control = new CustomInvoiceDtsCtl(sqlTrans);
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
    }
}

