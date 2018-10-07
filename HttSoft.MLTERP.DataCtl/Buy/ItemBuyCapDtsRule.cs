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
	/// Ŀ�ģ�Buy_ItemBuyCapDtsʵ��ҵ�������
	/// ����:����ǿ
	/// ��������:2012/7/30
	/// </summary>
	public class ItemBuyCapDtsRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public ItemBuyCapDtsRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			ItemBuyCapDts entity=(ItemBuyCapDts)p_BE;
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
            ItemBuyCapDts entity = (ItemBuyCapDts)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, ItemBuyCapDts.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
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
                string sql = "SELECT " + p_FieldName + " FROM Buy_ItemBuyCapDts WHERE 1=1";
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

        #region �����ʽ���ϸ

        /// <summary>
        /// �����ʽ���ϸ
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RSaveBuyCap(ItemBuyForm p_BEMain)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSaveBuyCap(p_BEMain, sqlTrans);

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
        /// �����ʽ���ϸ(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RSaveBuyCap(ItemBuyForm p_BEMain , IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;
                sql = "SELECT * FROM Buy_ItemBuyCapDts WHERE MainID="+p_BEMain.ID+" ORDER BY Seq";
                DataTable dtOld = sqlTrans.Fill(sql);//�ҵ�ԭʼ��ID

                sql = "SELECT * FROM Data_PayMethodDts WHERE MainID=" + SysConvert.ToInt32(p_BEMain.PayMethodFlag) + " ORDER BY Seq";
                DataTable dtPayMethodDts = sqlTrans.Fill(sql);//���ʽ��ϸ

                sql = "SELECT ItemCode,SUM(Amount) Amount FROM Buy_ItemBuyFormDts WHERE MainID=" + p_BEMain.ID + " GROUP BY ItemCode";
                DataTable dtBuyDts = sqlTrans.Fill(sql);//�ɹ���Ʒ����ϸ



                //���ݲ�ͬƷ�����ɶ����ĸ�����ϸ
                ItemBuyCapDts[] entityDts = new ItemBuyCapDts[dtPayMethodDts.Rows.Count * dtBuyDts.Rows.Count];//��ʼ���ʽ���ϸʵ������
                int ci = 0;
                for (int i = 0; i < dtPayMethodDts.Rows.Count; i++)
                {
                    for (int m = 0; m < dtBuyDts.Rows.Count; m++)//���Ʒ�����ɶ������ʽ�ƻ�
                    {
                        entityDts[ci] = new ItemBuyCapDts();
                        if (dtOld.Rows.Count > ci)
                        {
                            entityDts[ci].ID = SysConvert.ToInt32(dtOld.Rows[ci]["ID"]);
                        }
                        entityDts[ci].MainID = p_BEMain.ID;
                        entityDts[ci].Seq = ci + 1;
                        entityDts[ci].CapName = dtPayMethodDts.Rows[i]["Name"].ToString();//����
                        entityDts[ci].PayStepTypeID = SysConvert.ToInt32(dtPayMethodDts.Rows[i]["PayStepTypeID"]);
                        entityDts[ci].PayPer = SysConvert.ToDecimal(dtPayMethodDts.Rows[i]["PayPer"]);
                        switch (SysConvert.ToInt32(dtPayMethodDts.Rows[i]["PayDateTypeInt"]))//���ݸ����ж�������������
                        {
                            case (int)EnumPayDateType.���ݺ�ͬǩ����:
                                entityDts[ci].PayLimitDate = p_BEMain.FormDate.AddDays(SysConvert.ToInt32(dtPayMethodDts.Rows[i]["DelayDayNum"])).Date;//��ͬ���Ӻ������
                                break;

                            case (int)EnumPayDateType.���ݷ�����://��ע�·����գ���ȡĬ�Ͻ��ڣ��������������ʵ������
                                entityDts[ci].Remark = "���ݷ�����";
                                entityDts[ci].PayLimitDate = p_BEMain.ReqDate.AddDays(SysConvert.ToInt32(dtPayMethodDts.Rows[i]["DelayDayNum"])).Date;
                                break;
                        }

                        entityDts[ci].ItemCode = dtBuyDts.Rows[m]["ItemCode"].ToString();
                        entityDts[ci].PayAmount = SysConvert.ToDecimal(dtBuyDts.Rows[m]["Amount"]) * entityDts[ci].PayPer;//������
                        ci++;
                    }
                }
                this.RSave(p_BEMain, entityDts, sqlTrans);//������ϸ

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


        #region ���淽��
        /// <summary>
        /// ����(����������)
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <param name="p_BE"></param>
        /// <param name="sqlTrans"></param>
        public void RSave(ItemBuyForm p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "DELETE FROM Buy_ItemBuyCapDts WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(p_BE));
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������Ӧ��ɾ������ϸ���ݣ������ݿ����е���UI���Ѿ�ɾ��������
                for (int i = 0; i < p_BE.Length; i++)
                {
                    ItemBuyCapDts entitydts = (ItemBuyCapDts)p_BE[i];
                    if (entitydts.ID != 0)//ID��Ϊ0˵�����ݿ����Ѿ�����
                    {
                        this.RUpdate(entitydts, sqlTrans);
                    }
                    else
                    {
                        entitydts.MainID = p_Entity.ID;
                        this.RAdd(entitydts, sqlTrans);
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
                ItemBuyCapDts entitydts = (ItemBuyCapDts)p_BE[i];
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
				ItemBuyCapDts entity=(ItemBuyCapDts)p_BE;				
				ItemBuyCapDtsCtl control=new ItemBuyCapDtsCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Buy_ItemBuyCapDts,sqlTrans);
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
				ItemBuyCapDts entity=(ItemBuyCapDts)p_BE;				
				ItemBuyCapDtsCtl control=new ItemBuyCapDtsCtl(sqlTrans);				
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
				ItemBuyCapDts entity=(ItemBuyCapDts)p_BE;				
				ItemBuyCapDtsCtl control=new ItemBuyCapDtsCtl(sqlTrans);
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

        #region ��������
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(int p_ID,BaseEntity[] p_BE)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_ID,p_BE, sqlTrans);

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
        public void RAdd(int p_ID,BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                if (p_ID > 0)
                {
                    string sql = "DELETE Buy_ItemBuyCapDts WHERE MainID=" + SysString.ToDBString(p_ID);
                    sqlTrans.ExecuteNonQuery(sql);
                    for (int i = 0; i < p_BE.Length; i++)
                    {
                        ItemBuyCapDtsRule rule = new ItemBuyCapDtsRule();
                        ItemBuyCapDts entity = (ItemBuyCapDts)p_BE[i];
                        entity.MainID = p_ID;
                        entity.Seq = i + 1;
                        rule.RAdd(entity, sqlTrans);

                    }
                    sql = "UPDATE Buy_ItemBuyForm SET FKFlag=1";
                    sql += " WHERE ID=" + SysString.ToDBString(p_ID);
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
    }
}
