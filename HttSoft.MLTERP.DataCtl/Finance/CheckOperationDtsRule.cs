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
	/// Ŀ�ģ�Finance_CheckOperationDtsʵ��ҵ�������
	/// ����:������
	/// ��������:2012/5/8
	/// </summary>
	public class CheckOperationDtsRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public CheckOperationDtsRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			CheckOperationDts entity=(CheckOperationDts)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV2_Finance_CheckOperationDts WHERE 1=1";
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
        public DataTable RShow2(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV2_Finance_CheckOperationDts2 WHERE 1=1";
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
        /// ������ݿ���û�б�ɾ����ID(�����ݿ����ж���UI��Ҳû��ɾ��������)
        /// </summary>
        /// <param name="p_BE"></param>
        /// <returns></returns>
        private string GetIDExist(BaseEntity[] p_BE)
        {
            string outstr = "0";
            for (int i = 0; i < p_BE.Length; i++)
            {
                CheckOperationDts entitydts = (CheckOperationDts)p_BE[i];
                if (entitydts.ID != 0)
                {
                    outstr += "," + entitydts.ID;
                }
            }
            return outstr;
        }
        private string GetIDExist2(BaseEntity[] p_BE)
        {
            string outstr = "0";
            for (int i = 0; i < p_BE.Length; i++)
            {
                CheckOperationInvDts entitydts = (CheckOperationInvDts)p_BE[i];
                if (entitydts.ID != 0)
                {
                    outstr += "," + entitydts.ID;
                }
            }
            return outstr;
        }
        private string GetIDExist3(BaseEntity[] p_BE)
        {
            string outstr = "0";
            for (int i = 0; i < p_BE.Length; i++)
            {
                CheckOperationPayDts entitydts = (CheckOperationPayDts)p_BE[i];
                if (entitydts.ID != 0)
                {
                    outstr += "," + entitydts.ID;
                }
            }
            return outstr;
        }
        /// <summary>
        /// ����(����������)
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <param name="p_BE"></param>
        /// <param name="sqlTrans"></param>
        public void RSave(CheckOperation p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "DELETE FROM Finance_CheckOperationDts WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(p_BE));
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������Ӧ��ɾ������ϸ���ݣ������ݿ����е���UI���Ѿ�ɾ��������
                sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM Finance_CheckOperationDts WHERE MainID=" + p_Entity.ID.ToString();////�ҵ�����Seq    ��������Seq�����ŵ�ѭ�������Ч(���˲���ʱ����������?)
                int MSEQ = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());
                for (int i = 0; i < p_BE.Length; i++)
                {
                    CheckOperationDts entitydts = (CheckOperationDts)p_BE[i];
                    if (entitydts.ID != 0)//ID��Ϊ0˵�����ݿ����Ѿ�����
                    {
                        this.RUpdate(entitydts, sqlTrans);
                    }
                    else
                    {
                        entitydts.Seq = MSEQ;
                        entitydts.MainID = p_Entity.ID;
                        this.RAdd(entitydts, sqlTrans);

                        MSEQ++;//���ֵ��1
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

        public void RSave(CheckOperation p_Entity, BaseEntity[] p_BE,BaseEntity[] p_BE2,BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "DELETE FROM Finance_CheckOperationDts WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(p_BE));
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������Ӧ��ɾ������ϸ���ݣ������ݿ����е���UI���Ѿ�ɾ��������
                sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM Finance_CheckOperationDts WHERE MainID=" + p_Entity.ID.ToString();////�ҵ�����Seq    ��������Seq�����ŵ�ѭ�������Ч(���˲���ʱ����������?)
                int MSEQ = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());
                for (int i = 0; i < p_BE.Length; i++)
                {
                    CheckOperationDts entitydts = (CheckOperationDts)p_BE[i];
                    if (entitydts.ID != 0)//ID��Ϊ0˵�����ݿ����Ѿ�����
                    {
                        this.RUpdate(entitydts, sqlTrans);
                    }
                    else
                    {
                        entitydts.Seq = MSEQ;
                        entitydts.MainID = p_Entity.ID;
                        this.RAdd(entitydts, sqlTrans);

                        MSEQ++;//���ֵ��1
                    }
                }

                sql = "DELETE FROM Finance_CheckOperationInvDts WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist2(p_BE2));
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������Ӧ��ɾ������ϸ���ݣ������ݿ����е���UI���Ѿ�ɾ��������
                sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM Finance_CheckOperationInvDts WHERE MainID=" + p_Entity.ID.ToString();////�ҵ�����Seq    ��������Seq�����ŵ�ѭ�������Ч(���˲���ʱ����������?)
                MSEQ = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    CheckOperationInvDtsRule rule2 = new CheckOperationInvDtsRule();
                    CheckOperationInvDts entityInvDts = (CheckOperationInvDts)p_BE2[i];
                    if (entityInvDts.ID != 0)//ID��Ϊ0˵�����ݿ����Ѿ�����
                    {
                        rule2.RUpdate(entityInvDts, sqlTrans);
                    }
                    else
                    {
                        entityInvDts.Seq = MSEQ;
                        entityInvDts.MainID = p_Entity.ID;
                        rule2.RAdd(entityInvDts, sqlTrans);

                        MSEQ++;//���ֵ��1
                    }
                }


                sql = "DELETE FROM Finance_CheckOperationPayDts WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist3(p_BE3));
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������Ӧ��ɾ������ϸ���ݣ������ݿ����е���UI���Ѿ�ɾ��������
                sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM Finance_CheckOperationPayDts WHERE MainID=" + p_Entity.ID.ToString();////�ҵ�����Seq    ��������Seq�����ŵ�ѭ�������Ч(���˲���ʱ����������?)
                MSEQ = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());
                for (int i = 0; i < p_BE3.Length; i++)
                {
                    CheckOperationPayDtsRule rule3 = new CheckOperationPayDtsRule();
                    CheckOperationPayDts entityPayDts = (CheckOperationPayDts)p_BE3[i];
                    if (entityPayDts.ID != 0)//ID��Ϊ0˵�����ݿ����Ѿ�����
                    {
                        rule3.RUpdate(entityPayDts, sqlTrans);
                    }
                    else
                    {
                        entityPayDts.Seq = MSEQ;
                        entityPayDts.MainID = p_Entity.ID;
                        rule3.RAdd(entityPayDts, sqlTrans);

                        MSEQ++;//���ֵ��1
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
				CheckOperationDts entity=(CheckOperationDts)p_BE;				
				CheckOperationDtsCtl control=new CheckOperationDtsCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Finance_CheckOperationDts,sqlTrans);
				control.AddNew(entity);
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
				CheckOperationDts entity=(CheckOperationDts)p_BE;				
				CheckOperationDtsCtl control=new CheckOperationDtsCtl(sqlTrans);				
				control.Update(entity);
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
				CheckOperationDts entity=(CheckOperationDts)p_BE;				
				CheckOperationDtsCtl control=new CheckOperationDtsCtl(sqlTrans);
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
