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
    /// Ŀ�ģ�Ship_CustomInvoiceDtsʵ��ҵ�������
    /// ����:³��
    /// ��������:2015-1-12
    /// </summary>
    public class CustomInvoiceDtsRule
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public CustomInvoiceDtsRule()
        {
        }

        /// <summary>
        /// ��齫Ҫ�����������Ƿ����ҵ�����
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            CustomInvoiceDts entity = (CustomInvoiceDts)p_BE;
        }


        /// <summary>
        /// ��ʾ����
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
        /// ��ʾ����
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
        /// ��ʾ����
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
        #region ����

        /// <summary>
        /// ����(����������)
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <param name="p_BE"></param>
        /// <param name="sqlTrans"></param>
        public void RSave(Custom p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "DELETE FROM Ship_CustomInvoiceDts WHERE MainID=" + p_Entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������ϸ����

                // sql = "DELETE FROM Ship_CustomDts WHERE MainID=" + p_Entity.ID.ToString();
                //sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������ϸ����

                for (int i = 0; i < p_BE.Length; i++)
                {
                    CustomInvoiceDts entitydts = (CustomInvoiceDts)p_BE[i];
                    sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM Ship_CustomInvoiceDts WHERE MainID=" + p_Entity.ID.ToString();
                    entitydts.Seq = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());//�ҵ�����Seq
                    entitydts.MainID = p_Entity.ID;
                    this.RAdd(entitydts, sqlTrans);

                    //sql = " UPDATE Ship_Ship_PackPlan Set LoadFlag=1 WHERE ID=" + entitydts.PackPlanID;//�����Ѽ��ر�־
                    //sqlTrans.ExecuteNonQuery(sql);
                }

                /////���ݱ��������Ϣ���浽 Ship_CustomDts��           
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
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
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
        /// ����(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
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
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
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
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        /// <param name="sqlTrans">������</param>
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
        /// ɾ��
        /// </summary>
        /// <param name="p_BE">Ҫɾ����ʵ��</param>
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
        /// ɾ��
        /// </summary>
        /// <param name="p_BE">Ҫɾ����ʵ��</param>
        /// <param name="sqlTrans">������</param>
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

