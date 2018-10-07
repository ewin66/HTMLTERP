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
	/// Ŀ�ģ�CaiWu_CWDuiZhangDtsʵ��ҵ�������
	/// ����:������
	/// ��������:2011-11-3
	/// </summary>
	public class CWDuiZhangDtsRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public CWDuiZhangDtsRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			CWDuiZhangDts entity=(CWDuiZhangDts)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_CaiWu_CWDuiZhangIOFormDts WHERE 1=1";
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
        public void RSave(CWDuiZhang p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                ///��ʼ�����˱�־
                string sql = "Select * From CaiWu_CWDuiZhangDts WHERE  1=1";
                sql += " AND MainID=" + SysString.ToDBString(p_Entity.ID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sql = "Update WH_IOFormDts Set DZFlag=0,DZTime=null,DZOPID='',DZNo='',DZQty=0";
                        sql += " WHERE 1=1 AND MainID=" + SysConvert.ToInt32(dt.Rows[i]["IOFormID"]);
                        sql += " AND Seq=" + SysConvert.ToInt32(dt.Rows[i]["IOFormSeq"]);
                        sqlTrans.ExecuteNonQuery(sql);
                    }
                }

                 sql = "DELETE FROM CaiWu_CWDuiZhangDts WHERE MainID=" + p_Entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������ϸ����
                for (int i = 0; i < p_BE.Length; i++)
                {
                    CWDuiZhangDts entitydts = (CWDuiZhangDts)p_BE[i];
                    sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM CaiWu_CWDuiZhangDts WHERE MainID=" + p_Entity.ID.ToString();
                    entitydts.Seq = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());//�ҵ�����Seq
                    entitydts.MainID = p_Entity.ID;
                    this.RAdd(entitydts, sqlTrans);

                    ///������˱�־
                    sql = "Update WH_IOFormDts Set DZFlag=1";
                    if (p_Entity.DZDate != SystemConfiguration.DateTimeDefaultValue)
                    {
                        sql += " ,DZTime=" + SysString.ToDBString(p_Entity.DZDate.Date);
                    }
                    else
                    {
                        sql += " ,DZTime=null";
                    }
                    sql += ",DZQty=" + SysString.ToDBString(p_Entity.DZQty);
                    sql += ",DZOPID=" + SysString.ToDBString(p_Entity.DZOPID);
                    sql += ",DZNo=" + SysString.ToDBString(p_Entity.Code);
                    sql += ",SinglePrice=" + SysString.ToDBString(entitydts.SinglePrice);
                    sql += ",Amount=" + SysString.ToDBString(entitydts.Amount);


                    sql += " WHERE 1=1 AND MainID=" + SysConvert.ToInt32(entitydts.IOFormID);
                    sql += " AND Seq=" + SysConvert.ToInt32(entitydts.IOFormSeq);
                    sqlTrans.ExecuteNonQuery(sql);
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
				CWDuiZhangDts entity=(CWDuiZhangDts)p_BE;				
				CWDuiZhangDtsCtl control=new CWDuiZhangDtsCtl(sqlTrans);
				//entity.ID=(int)EntityIDTable.GetID((long)SysEntity.CaiWu_CWDuiZhangDts,sqlTrans);
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
				CWDuiZhangDts entity=(CWDuiZhangDts)p_BE;				
				CWDuiZhangDtsCtl control=new CWDuiZhangDtsCtl(sqlTrans);				
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
				CWDuiZhangDts entity=(CWDuiZhangDts)p_BE;				
				CWDuiZhangDtsCtl control=new CWDuiZhangDtsCtl(sqlTrans);
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
