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
	/// Ŀ�ģ�CaiWu_CWInvoiceʵ��ҵ�������
	/// ����:������
	/// ��������:2011-11-4
	/// </summary>
	public class CWInvoiceRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public CWInvoiceRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			CWInvoice entity=(CWInvoice)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_CaiWu_CWInvoice WHERE 1=1";
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
        
        
        #region  ���ӱ��淽��
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
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
        /// ����(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                CWInvoiceDtsRule ruledts = new CWInvoiceDtsRule();
                ruledts.RSave((CWInvoice)p_BE, p_BE2, sqlTrans);//����ӱ�


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
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {

                this.RUpdate(p_BE, sqlTrans);
                CWInvoiceDtsRule ruledts = new CWInvoiceDtsRule();
                ruledts.RSave((CWInvoice)p_BE, p_BE2, sqlTrans);//����ӱ�
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
					
					this.RAdd(p_BE,sqlTrans);
			
			        sqlTrans.CommitTrans();
				}
				catch(Exception TE)
				{					
					sqlTrans.RollbackTrans();
					throw TE;
				}
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
		
		/// <summary>
		/// ����(����������)
		/// </summary>
		/// <param name="p_BE">Ҫ������ʵ��</param>
		/// <param name="sqlTrans">������</param>
		public void RAdd(BaseEntity p_BE,IDBTransAccess sqlTrans)
		{
            try
            {
                this.CheckCorrect(p_BE);
                CWInvoice entity = (CWInvoice)p_BE;
                CWInvoiceCtl control = new CWInvoiceCtl(sqlTrans);

                string sql = string.Empty;
                sql = " SELECT InvoiceNo FROM CaiWu_CWInvoice WHERE 1=1 AND InvoiceNo=" + SysString.ToDBString(entity.InvoiceNo);
                if (sqlTrans.Fill(sql).Rows.Count != 0)
                {
                    throw new Exception("��Ʊ���Ѿ����ڣ�����������");
                }
                //entity.ID = (int)EntityIDTable.GetID((long)SysEntity.CaiWu_CWInvoice, sqlTrans);
                control.AddNew(entity);

                //sql = " UPDATE Enum_FormNoControl SET CurSort=CurSort+1 WHERE ID=" + (int)FormNoControlEnum.��Ʊ����;//����CurSort
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
					
					this.RUpdate(p_BE,sqlTrans);
					
					sqlTrans.CommitTrans();
				}
				catch(Exception TE)
				{					
					sqlTrans.RollbackTrans();
					throw TE;
				}				
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
		
		/// <summary>
		/// �޸�
		/// </summary>
		/// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
		/// <param name="sqlTrans">������</param>
		public void RUpdate(BaseEntity p_BE,IDBTransAccess sqlTrans)
		{
            try
            {
                this.CheckCorrect(p_BE);
                CWInvoice entity = (CWInvoice)p_BE;
                CWInvoiceCtl control = new CWInvoiceCtl(sqlTrans);
                string sql = string.Empty;
                sql = " SELECT InvoiceNo FROM CaiWu_CWInvoice WHERE 1=1 AND InvoiceNo=" + SysString.ToDBString(entity.InvoiceNo)+" AND ID<>"+SysString.ToDBString(entity.ID);
                if (sqlTrans.Fill(sql).Rows.Count != 0)
                {
                    throw new Exception("�÷�Ʊ���Ѿ����ڣ�����������");
                }
                else
                {
                    control.Update(entity);
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
		public void RDelete(BaseEntity p_BE)
		{
			try
			{
				IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();				
				try
				{
					sqlTrans.OpenTrans();
					
					this.RDelete(p_BE,sqlTrans);
					
					sqlTrans.CommitTrans();
				}
				catch(Exception TE)
				{					
					sqlTrans.RollbackTrans();
					throw TE;
				}				
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
		
		/// <summary>
		/// ɾ��
		/// </summary>
		/// <param name="p_BE">Ҫɾ����ʵ��</param>
		/// <param name="sqlTrans">������</param>
		public void RDelete(BaseEntity p_BE,IDBTransAccess sqlTrans)
		{
			try
			{
			    this.CheckCorrect(p_BE);
				CWInvoice entity=(CWInvoice)p_BE;				
				CWInvoiceCtl control=new CWInvoiceCtl(sqlTrans);
				
				
       
                string sql = "Select * From CaiWu_CWInvoiceDts WHERE  1=1";
                sql += " AND MainID=" + SysString.ToDBString(entity.ID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        #region ������˺Ͳֿ⿪Ʊ�����ݻ���
                        //������˵��еĶ��˱�־
                        sql = "UPDATE CaiWu_CWDuiZhang Set DZFlag=0 WHERE Code=" + SysString.ToDBString(dt.Rows[i]["DZCode"].ToString());
                        sqlTrans.ExecuteNonQuery(sql);


                        sql = "Select * From CaiWu_CWDuiZhangDts WHERE  1=1 ";
                        sql += " AND MainID=" + " (SELECT ID FROM CaiWu_CWDuiZhang WHERE Code=" + SysString.ToDBString(dt.Rows[i]["DZCode"].ToString()) +")";
                        DataTable dt2 = sqlTrans.Fill(sql);
                        if (dt2.Rows.Count != 0)
                        {
                            for (int j = 0; j < dt2.Rows.Count; j++)
                            {
                                ///����ֿⷢƱ��־

                                sql = "Update WH_IOFormDts Set DtsInvoiceDelFlag=0,DtsInvoiceDelTime=null,DtsInvoiceDelOPID='',DtsInvoiceNo='',InvoiceQty=0";
                                sql += " WHERE 1=1 AND MainID=" + SysString.ToDBString(dt2.Rows[j]["IOFormID"].ToString());
                                sql += " AND Seq=" + SysString.ToDBString(dt2.Rows[j]["IOFormSeq"].ToString());
                                sqlTrans.ExecuteNonQuery(sql);
                            }
                        }
                    }
                    #endregion
                }

                 sql = "DELETE FROM CaiWu_CWInvoiceDts WHERE MainID=" + entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������ϸ����
				control.Delete(entity);						
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
	}
}
