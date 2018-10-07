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
	/// Ŀ�ģ�Data_ItemColorDtsHisʵ��ҵ�������
	/// ����:�¼Ӻ�
	/// ��������:2012-4-18
	/// </summary>
	public class ItemColorDtsHisRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public ItemColorDtsHisRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			ItemColorDtsHis entity=(ItemColorDtsHis)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM Data_ItemColorDtsHis WHERE 1=1";
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

        #region ��ʷ���۱���
        /// <summary>
        /// ����(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RSave(ItemColorDts p_Entity, IDBTransAccess sqlTrans)
        {
            try
            {
                if ( p_Entity.BuyPrice==0 &&  p_Entity.SalePrice==0)//�۸��Ϊ0,ֱ������
                {
                    return;
                }
                ParamSetRule psrule = new ParamSetRule();
                int dayNum = psrule.RShowIntByCode((int)ParamSetEnum.��Ʒ�۸������ʷ�۸��������);
                if(dayNum<=0)
                {
                    dayNum=3;
                }
                string sql = "";

                sql = "SELECT TOP 1 ID FROM Data_ItemColorDtsHis WHERE MainID=" + p_Entity.MainID + " AND ColorNum=" + SysString.ToDBString(p_Entity.ColorNum);
                sql += " ORDER BY Seq DESC";//�ɹ��ۡ����ۼ�
                DataTable dt = sqlTrans.Fill(sql);
                ItemColorDtsHis entityLast = new ItemColorDtsHis(sqlTrans);//���һ����ʷ
                bool addNewHisFlag = false;
                if (dt.Rows.Count != 0)
                {
                    entityLast.ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                    entityLast.SelectByID();

                    if (entityLast.BuyPriceDate.AddDays(dayNum) < DateTime.Now)//˵��������֮ǰ����
                    {
                        addNewHisFlag = true;
                    }
                }
                else//û���ҵ���ʷ��¼
                {
                    addNewHisFlag = true;
                }

                if (addNewHisFlag)//��Ҫ��������ʷ��¼
                {
                    if (entityLast.ID != 0)//����ʷ
                    {
                        if (entityLast.BuyPrice != p_Entity.BuyPrice || entityLast.SalePrice != p_Entity.SalePrice)//�۸��в�ͬ������
                        {
                            ItemColorDtsHis entity = new ItemColorDtsHis(sqlTrans);
                            entity.MainID = p_Entity.MainID;
                            entity.Seq = entityLast.Seq + 1;
                            entity.ColorNum = p_Entity.ColorNum;
                            entity.ColorName = p_Entity.ColorName;
                            entity.BuyPrice = p_Entity.BuyPrice;
                            entity.BuyPriceDate = p_Entity.BuyPriceDate;
                            entity.SalePrice = p_Entity.SalePrice;
                            entity.SalePriceDate = p_Entity.SalePriceDate;
                            this.RAdd(entity, sqlTrans);
                        }
                        else//�۸����ʷ��ȫһ����������
                        {
                        }
                    }
                    else//û����ʷ��ֱ������
                    {
                        ItemColorDtsHis entity = new ItemColorDtsHis(sqlTrans);
                        entity.MainID = p_Entity.MainID;
                        entity.Seq = 1;
                        entity.ColorNum = p_Entity.ColorNum;
                        entity.ColorName = p_Entity.ColorName;
                        entity.BuyPrice = p_Entity.BuyPrice;
                        entity.BuyPriceDate = p_Entity.BuyPriceDate;
                        entity.SalePrice = p_Entity.SalePrice;
                        entity.SalePriceDate = p_Entity.SalePriceDate;
                        this.RAdd(entity, sqlTrans);
                    }
                }
                else//��������ʷ���͸���Ϊ���µļ۸񼴿�
                {
                    entityLast.BuyPrice = p_Entity.BuyPrice;
                    entityLast.SalePrice = p_Entity.SalePrice;
                    this.RUpdate(entityLast, sqlTrans);
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
				ItemColorDtsHis entity=(ItemColorDtsHis)p_BE;				
				ItemColorDtsHisCtl control=new ItemColorDtsHisCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Data_ItemColorDtsHis,sqlTrans);
				control.AddNew(entity);
                if (entity.BuyPrice > 0)
                {
                    string sql = "UPDATE Data_Item SET BuyPrice=" + SysString.ToDBString(entity.BuyPrice);
                    sql += " WHERE ID=" + SysString.ToDBString(entity.MainID);
                    sqlTrans.ExecuteNonQuery(sql);
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
				ItemColorDtsHis entity=(ItemColorDtsHis)p_BE;				
				ItemColorDtsHisCtl control=new ItemColorDtsHisCtl(sqlTrans);				
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
				ItemColorDtsHis entity=(ItemColorDtsHis)p_BE;				
				ItemColorDtsHisCtl control=new ItemColorDtsHisCtl(sqlTrans);
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
