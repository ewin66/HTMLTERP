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
	/// Ŀ�ģ�WO_PackOrderDtsʵ��ҵ�������
	/// ����:��Զ��
	/// ��������:2012/11/7
	/// </summary>
	public class PackOrderDtsRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public PackOrderDtsRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			PackOrderDts entity=(PackOrderDts)p_BE;
		}	
		
        ///// <summary>
        ///// �����ֶ�ֵ�Ƿ��Ѵ���
        ///// </summary>
        ///// <param name="p_TableName">����</param>
        ///// <param name="p_FieldName">�ֶ���</param>
        ///// <param name="p_FieldValue">�ֶ�ֵ</param>
        ///// <param name="p_KeyField">������ֻ��������ΪID�������</param>
        ///// <param name="p_KeyValue">����ֵ</param>
        ///// <param name="p_sqlTrans"></param>
        ///// <returns></returns>
        //private bool CheckFieldValueIsExist(BaseEntity p_BE, string p_FieldName, string p_FieldValue, IDBTransAccess p_sqlTrans)
        //{
        //    PackOrderDts entity = (PackOrderDts)p_BE;
        //    bool ret = false;
        //    string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, PackOrderDts.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
        //    DataTable dt = p_sqlTrans.Fill(sql);
        //    if (dt.Rows.Count != 0)
        //    {
        //        ret = true;
        //    }

        //    return ret;
        //}
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
                string sql = "SELECT " + p_FieldName + " FROM WO_PackOrderDts WHERE 1=1";
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
        public void RSave(PackOrder p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {

                string sql = "DELETE FROM WO_PackOrderDts WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(p_BE));
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������ϸ����

                for (int i = 0; i < p_BE.Length; i++)
                {
                    PackOrderDts entitydts = (PackOrderDts)p_BE[i];
                    if (entitydts.ID == 0)
                    {
                        sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM WO_PackOrderDts WHERE MainID=" + p_Entity.ID.ToString();
                        entitydts.Seq = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());//�ҵ�����Seq
                        entitydts.MainID = p_Entity.ID;
                        this.RAdd(entitydts, sqlTrans);
                    }
                    else
                    {
                        entitydts.MainID = p_Entity.ID;
                        this.RUpdate(entitydts, sqlTrans);
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
                PackOrderDts entitydts = (PackOrderDts)p_BE[i];
                if (entitydts.ID != 0)
                {
                    outstr += "," + entitydts.ID;
                }
            }
            return outstr;
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
				PackOrderDts entity=(PackOrderDts)p_BE;				
				PackOrderDtsCtl control=new PackOrderDtsCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.WO_PackOrderDts,sqlTrans);
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
				PackOrderDts entity=(PackOrderDts)p_BE;				
				PackOrderDtsCtl control=new PackOrderDtsCtl(sqlTrans);				
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
				PackOrderDts entity=(PackOrderDts)p_BE;				
				PackOrderDtsCtl control=new PackOrderDtsCtl(sqlTrans);
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
