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
	/// Ŀ�ģ�BBS_InfoMainʵ��ҵ�������
	/// ����:����ǿ
	/// ��������:2012/7/21
	/// </summary>
	public class InfoMainRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public InfoMainRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			InfoMain entity=(InfoMain)p_BE;
		}	
		
		/// <summary>
        /// �����ֶ�ֵ�Ƿ��Ѵ���
        /// </summary>
        /// <param name="p_TableName">����</param>
        /// <param name="p_FieldName">�ֶ���</param>
        /// <param name="p_FieldValue">�ֶ�ֵ</param>
        /// <param name="p_KeyField">������ֻ��������ΪID�������</param>
        /// <param name="p_KeyValue">����ֵ</param>
        /// <param name="p_sqlTrans"></param>
        /// <returns></returns>
        private bool CheckFieldValueIsExist(BaseEntity p_BE, string p_FieldName, string p_FieldValue, IDBTransAccess p_sqlTrans)
        {
            InfoMain entity = (InfoMain)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, InfoMain.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.DSYSID);
            DataTable dt = p_sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                ret = true;
            }

            return ret;
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
                string sql = "SELECT " + p_FieldName + " FROM BBS_InfoMain WHERE 1=1";
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
				InfoMain entity=(InfoMain)p_BE;				
				InfoMainCtl control=new InfoMainCtl(sqlTrans);
				entity.DSYSID=(int)EntityIDTable.GetID((long)SysEntity.BBS_InfoMain,sqlTrans);
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
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(BaseEntity p_BE,BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE,p_BE2,sqlTrans);

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
        public void RAdd(BaseEntity p_BE,BaseEntity[] p_BE2,IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                InfoMain entity = (InfoMain)p_BE;
                InfoMainCtl control = new InfoMainCtl(sqlTrans);
                entity.DSYSID = (int)EntityIDTable.GetID((long)SysEntity.BBS_InfoMain, sqlTrans);
                control.AddNew(entity);

                for (int i = 0; i < p_BE2.Length; i++)
                {
                    InfoMainShareDtsRule rule = new InfoMainShareDtsRule();
                    InfoMainShareDts entityDts = (InfoMainShareDts)p_BE2[i];
                    entityDts.MainID = entity.DSYSID;
                    entityDts.Seq = i + 1;
                    rule.RAdd(entityDts, sqlTrans);
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
				InfoMain entity=(InfoMain)p_BE;				
				InfoMainCtl control=new InfoMainCtl(sqlTrans);				
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
				InfoMain entity=(InfoMain)p_BE;				
				InfoMainCtl control=new InfoMainCtl(sqlTrans);
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
