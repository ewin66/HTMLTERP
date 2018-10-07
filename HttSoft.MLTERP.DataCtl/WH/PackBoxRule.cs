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
	/// Ŀ�ģ�WH_PackBoxʵ��ҵ�������
	/// ����:�¼Ӻ�
	/// ��������:2012-5-7
	/// </summary>
	public class PackBoxRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public PackBoxRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			PackBox entity=(PackBox)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM WH_PackBox WHERE 1=1";
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
        public DataTable RUShow(string p_condition)
        {
            try
            {
                return RUShow(p_condition, "*");
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
        public DataTable RUShow(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_PackBox WHERE 1=1";
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
        #region �Զ��巽��
        /// <summary>
        /// У��ɾ������(����������)
        /// </summary>
        /// <param name="p_BoxNo">���</param>
        /// <param name="sqlTrans"></param>
        public void RCheckDelete(string p_BoxNo, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;
                if (p_BoxNo != string.Empty)
                {
                    return;
                }
                sql = "SELECT BoxStatusID FROM WH_PackBox WHERE BoxNo="+SysString.ToDBString(p_BoxNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    if (SysConvert.ToInt32(dt.Rows[0]["BoxStatusID"]) != (int)EnumBoxStatus.δ���)
                    {
                        throw new Exception("����" + p_BoxNo + "״̬����δ���״̬������ɾ��");
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
        /// У����¹���(����������)
        /// </summary>
        /// <param name="p_BoxNo">���</param>
        /// <param name="sqlTrans"></param>
        public void RCheckUpdate(string p_BoxNo, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;
                if (p_BoxNo != string.Empty)
                {
                    return;
                }
                sql = "SELECT BoxStatusID,KPFlag FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(p_BoxNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    if (SysConvert.ToInt32(dt.Rows[0]["BoxStatusID"]) != (int)EnumBoxStatus.δ���)
                    {
                        throw new Exception("����" + p_BoxNo + "״̬����δ���״̬�����ܸ���");
                    }
                    if (SysConvert.ToInt32(dt.Rows[0]["KPFlag"]) == (int)YesOrNo.Yes)
                    {
                        throw new Exception("����" + p_BoxNo + "״̬�����Ѿ�����ƥ״̬�����ܸ���");
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
        /// ���ݻ��ʵ�����
        /// </summary>
        /// <param name="p_BoxNo">���</param>
        /// <returns>�������ʵ��</returns>
        public PackBox RGetEntityByBoxNo(string p_BoxNo, IDBTransAccess sqlTrans)
        {
            PackBox entity = new PackBox(sqlTrans);
            string sql = "SELECT ID FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(p_BoxNo);//Ѱ��ID
            DataTable dt = sqlTrans.Fill(sql);

            if (dt.Rows.Count != 0)
            {
                entity.ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                entity.SelectByID();
            }
            return entity;
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
				PackBox entity=(PackBox)p_BE;				
				PackBoxCtl control=new PackBoxCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.WH_PackBox,sqlTrans);
                if (entity.BoxNo == string.Empty)//����Ų�����
                {
                    entity.CreateTime = DateTime.Now;

                    FormNoControlRule rulest = new FormNoControlRule();

                    //�����������
                    entity.BoxNo = rulest.RGetFormNo((int)FormNoControlEnum.�뵥���, sqlTrans);
                    rulest.RAddSort((int)FormNoControlEnum.�뵥���, sqlTrans);
                }
                else//�Ѵ���
                {
                    string sql = "SELECT BoxNo FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(entity.BoxNo);
                    if (sqlTrans.Fill(sql).Rows.Count != 0)//������Ѵ��ڣ�������������
                    {
                        entity.CreateTime = DateTime.Now;

                        FormNoControlRule rulest = new FormNoControlRule();

                        //�����������
                        entity.BoxNo = rulest.RGetFormNo((int)FormNoControlEnum.�뵥���, sqlTrans);
                        rulest.RAddSort((int)FormNoControlEnum.�뵥���, sqlTrans);
                    }
                }

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
				PackBox entity=(PackBox)p_BE;				
				PackBoxCtl control=new PackBoxCtl(sqlTrans);				
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
				PackBox entity=(PackBox)p_BE;				
				PackBoxCtl control=new PackBoxCtl(sqlTrans);
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
