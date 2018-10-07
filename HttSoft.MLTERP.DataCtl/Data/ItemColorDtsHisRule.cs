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
	/// 目的：Data_ItemColorDtsHis实体业务规则类
	/// 作者:陈加海
	/// 创建日期:2012-4-18
	/// </summary>
	public class ItemColorDtsHisRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public ItemColorDtsHisRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			ItemColorDtsHis entity=(ItemColorDtsHis)p_BE;
		}	
		
		
		 /// <summary>
        /// 显示数据
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
        /// 显示数据
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

        #region 历史报价保存
        /// <summary>
        /// 新增(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RSave(ItemColorDts p_Entity, IDBTransAccess sqlTrans)
        {
            try
            {
                if ( p_Entity.BuyPrice==0 &&  p_Entity.SalePrice==0)//价格均为0,直接跳出
                {
                    return;
                }
                ParamSetRule psrule = new ParamSetRule();
                int dayNum = psrule.RShowIntByCode((int)ParamSetEnum.产品价格管理历史价格检验天数);
                if(dayNum<=0)
                {
                    dayNum=3;
                }
                string sql = "";

                sql = "SELECT TOP 1 ID FROM Data_ItemColorDtsHis WHERE MainID=" + p_Entity.MainID + " AND ColorNum=" + SysString.ToDBString(p_Entity.ColorNum);
                sql += " ORDER BY Seq DESC";//采购价、销售价
                DataTable dt = sqlTrans.Fill(sql);
                ItemColorDtsHis entityLast = new ItemColorDtsHis(sqlTrans);//最近一次历史
                bool addNewHisFlag = false;
                if (dt.Rows.Count != 0)
                {
                    entityLast.ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                    entityLast.SelectByID();

                    if (entityLast.BuyPriceDate.AddDays(dayNum) < DateTime.Now)//说明是三天之前的了
                    {
                        addNewHisFlag = true;
                    }
                }
                else//没有找到历史记录
                {
                    addNewHisFlag = true;
                }

                if (addNewHisFlag)//需要新增加历史记录
                {
                    if (entityLast.ID != 0)//有历史
                    {
                        if (entityLast.BuyPrice != p_Entity.BuyPrice || entityLast.SalePrice != p_Entity.SalePrice)//价格有不同则增加
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
                        else//价格和历史完全一样，不保存
                        {
                        }
                    }
                    else//没有历史，直接增加
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
                else//不增加历史，就更新为最新的价格即可
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
		/// 新增
		/// </summary>
		/// <param name="p_BE">要新增的实体</param>
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
		/// 新增(传入事务处理)
		/// </summary>
		/// <param name="p_BE">要新增的实体</param>
		/// <param name="sqlTrans">事务类</param>
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
		/// 修改
		/// </summary>
		/// <param name="p_BE">要修改的实体</param>
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
		/// 修改
		/// </summary>
		/// <param name="p_BE">要修改的实体</param>
		/// <param name="sqlTrans">事务类</param>
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
		/// 删除
		/// </summary>
		/// <param name="p_BE">要删除的实体</param>
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
		/// 删除
		/// </summary>
		/// <param name="p_BE">要删除的实体</param>
		/// <param name="sqlTrans">事务类</param>
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
