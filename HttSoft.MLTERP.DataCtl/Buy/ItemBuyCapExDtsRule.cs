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
	/// Ŀ�ģ�Buy_ItemBuyCapExDtsʵ��ҵ�������
	/// ����:����ǿ
	/// ��������:2012/7/30
	/// </summary>
	public class ItemBuyCapExDtsRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public ItemBuyCapExDtsRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			ItemBuyCapExDts entity=(ItemBuyCapExDts)p_BE;
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
            ItemBuyCapExDts entity = (ItemBuyCapExDts)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, ItemBuyCapExDts.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
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
                string sql = "SELECT " + p_FieldName + " FROM Buy_ItemBuyCapExDts WHERE 1=1";
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

        #region �ʽ����������������������
        /// <summary>
        /// �ʽ��������
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sqlTrans"></param>
        public void RHT(RecPay payEntity, RecPayHTDts htentity, IDBTransAccess sqlTrans)
        {
            ItemBuyCapExDts entityDts = new ItemBuyCapExDts();
            entityDts.ExCapName = payEntity.FormNo;//�洢�����
            entityDts.ExItemCode = htentity.HTItemCode;
            entityDts.ExPayStepTypeID = payEntity.PayStepTypeID;
            entityDts.ExPayAmount = htentity.HTAmount;
            entityDts.ExPayLimitDate = payEntity.ExDate.Date;
            entityDts.ExRemark = htentity.ID.ToString();//��ע��¼�����ͬ����ID,���ڹ�������            
                
            string sql = string.Empty;
            sql = "SELECT ID FROM Buy_ItemBuyForm WHERE FormNo=" + SysString.ToDBString(htentity.HTNo);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                entityDts.MainID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
            }

            sql = "SELECT ISNULL(MAX(Seq),0)+1 AS MSeq FROM Buy_ItemBuyCapExDts WHERE MainID=" + SysString.ToDBString(entityDts.MainID);
            entityDts.Seq = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0]["MSeq"]);

            this.RAdd(entityDts, sqlTrans);
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sqlTrans"></param>
        public void RHTCancel(RecPayHTDts htentity, IDBTransAccess sqlTrans)
        {
            ItemBuyCapExDts entityDts = new ItemBuyCapExDts();
            string sql = string.Empty;
            sql = "SELECT ID FROM Buy_ItemBuyCapExDts WHERE ExRemark=" + SysString.ToDBString(htentity.ID);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                entityDts.ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                entityDts.SelectByID();
            }

            this.RDelete(entityDts, sqlTrans);
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
				ItemBuyCapExDts entity=(ItemBuyCapExDts)p_BE;				
				ItemBuyCapExDtsCtl control=new ItemBuyCapExDtsCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Buy_ItemBuyCapExDts,sqlTrans);
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
				ItemBuyCapExDts entity=(ItemBuyCapExDts)p_BE;				
				ItemBuyCapExDtsCtl control=new ItemBuyCapExDtsCtl(sqlTrans);				
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
				ItemBuyCapExDts entity=(ItemBuyCapExDts)p_BE;				
				ItemBuyCapExDtsCtl control=new ItemBuyCapExDtsCtl(sqlTrans);
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
