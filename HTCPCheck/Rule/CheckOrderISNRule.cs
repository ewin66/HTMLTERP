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
	/// Ŀ�ģ�Chk_CheckOrderISNʵ��ҵ�������
	/// ����:�ܸ���
	/// ��������:2015/11/4
	/// </summary>
	public class CheckOrderISNRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public CheckOrderISNRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			CheckOrderISN entity=(CheckOrderISN)p_BE;
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
            CheckOrderISN entity = (CheckOrderISN)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, CheckOrderISN.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
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
                string sql = "SELECT " + p_FieldName + " FROM Chk_CheckOrderISN WHERE 1=1";
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Chk_CheckOrderISN WHERE 1=1";
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
				CheckOrderISN entity=(CheckOrderISN)p_BE;				
                //CheckOrderISNCtl control=new CheckOrderISNCtl(sqlTrans);
                //entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Chk_CheckOrderISN, sqlTrans);
                //control.AddNew(entity);

                if (entity.ID == 0)
                {
                    CheckOrderISNCtl control = new CheckOrderISNCtl(sqlTrans);
                    entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Chk_CheckOrderISN, sqlTrans);
                    if (entity.Seq == 0)
                    {
                        entity.StatusID = (int)EnumBoxStatus.δ���;
                        entity.DISN = GetDISN(sqlTrans);
                        entity.Seq = GetMaxSeq(entity.MainID, entity.JarNum, sqlTrans);
                        entity.ReelNo = SysConvert.ToString(entity.Seq);//���

                    }

                    control.AddNew(entity);
                }
                else
                {
                    if (entity.StatusID != (int)EnumBoxStatus.δ���)//�Ѿ��������벻���޸�
                    {
                        throw new Exception("���벻�ǳ�ʼ״̬�����޸�");
                    }

                    RUpdate(entity, sqlTrans);
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
				CheckOrderISN entity=(CheckOrderISN)p_BE;				
				CheckOrderISNCtl control=new CheckOrderISNCtl(sqlTrans);				
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
				CheckOrderISN entity=(CheckOrderISN)p_BE;				
				CheckOrderISNCtl control=new CheckOrderISNCtl(sqlTrans);
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


        #region ��ȡID
        /// <summary>
        /// �õ������
        /// </summary>
        /// <param name="sqlTrans"></param>
        /// <returns></returns>
        string GetDISN(IDBTransAccess sqlTrans)
        {
            string Str = string.Empty;
            string sql = "SELECT MAX(DISN) DISN FROM Chk_CheckOrderISN WHERE DISN LIKE " + SysString.ToDBString(DateTime.Now.ToString("yyyyMMdd") + "____");
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["DISN"].ToString() == string.Empty)
                {
                    return DateTime.Now.ToString("yyyyMMdd") + "0001";
                }
                else
                {
                    Str = dt.Rows[0]["DISN"].ToString();
                    Str = Str.Substring(8, 4);
                    return DateTime.Now.ToString("yyyyMMdd") + SysString.LongToStr(SysConvert.ToInt32(Str) + 1, 4);
                }
            }
            else
            {
                return DateTime.Now.ToString("yyyyMMdd") + "0001";
            }
            return Str;
        }

        public int GetMaxSeq(int p_ID, string JarNum, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT MAX(Seq) Seq FROM Chk_CheckOrderISN WHERE JarNum=" + SysString.ToDBString(JarNum);
            sql += " AND MainID=" + p_ID;
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                return SysConvert.ToInt32(dt.Rows[0]["Seq"]) + 1;
            }
            else
            {
                return 1;
            }
        }
        #endregion
    }
}
