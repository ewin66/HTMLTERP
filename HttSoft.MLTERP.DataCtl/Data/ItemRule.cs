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
	/// 目的：Data_Item实体业务规则类
	/// 作者:陈加海
	/// 创建日期:2012-4-18
	/// </summary>
	public class ItemRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public ItemRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			Item entity=(Item)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM Data_Item WHERE 1=1";
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
        /// 显示数据
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShowColor(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_Data_ItemColorDts WHERE 1=1";
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
        /// 显示数据
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShowView(string p_condition)
        {
            try
            {
                return RShowView(p_condition, "*");
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
        public DataTable RShowView(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_Data_Item WHERE 1=1";
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

        #region 生成代码
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
                Item entity = (Item)p_BE;
                string sql = "SELECT ItemCode FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("编码已存在，请重新生成");
                }

                ItemCtl control = new ItemCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Data_Item, sqlTrans);
                control.AddNew(entity);


                FormNoControlRule fnrule=new  FormNoControlRule();
                fnrule.RAddSort("Data_Item", "ItemCode", entity.ItemTypeID, sqlTrans);
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
        //public void RAdd(Item[] p_BE)     // 王焕梅 添加 201204.26  
        //{
        //    for (int i = 0; i < p_BE.Length; i++)
        //    {
        //       ItemRule  rule = new ItemRule();
        //        Item entity= (Item)p_BE2[i];
        //        Item.ID = entity.ID;
        //        rule.RAdd(entity);
        //    }
        
        //}

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
				Item entity=(Item)p_BE;
                string sql = "SELECT ItemCode FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode) + " AND ID<>" + entity.ID;
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("编码已存在，请重新生成");
                }

				ItemCtl control=new ItemCtl(sqlTrans);				
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
				Item entity=(Item)p_BE;

                string sql = "";
                sql = "SELECT ID FROM Data_ItemGB WHERE MainID=" + SysString.ToDBString(entity.ID);
                if (sqlTrans.Fill(sql).Rows.Count != 0)
                {
                    throw new Exception("不能删除，有挂板信息存在");
                }

				ItemCtl control=new ItemCtl(sqlTrans);
				control.Delete(entity);

                sql = "DELETE FROM Data_ItemDts WHERE MainID=" + entity.ID;
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE FROM Data_ItemLBDts WHERE MainID=" + entity.ID;
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE FROM Data_ItemColorDts WHERE MainID=" + entity.ID;
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE FROM Data_ItemColorDtsHis WHERE MainID=" + entity.ID;
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE FROM Data_ItemGB WHERE MainID=" + entity.ID;
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE FROM Data_ItemCompositeDts WHERE MainID=" + entity.ID;
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE FROM Data_ItemCodeFacDts WHERE MainID=" + entity.ID;
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE FROM Data_ItemGreyFabReplace WHERE MainID=" + entity.ID;
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE FROM Data_ItemGYFlowDts WHERE MainID=" + entity.ID;
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE FROM Data_ItemGYFlowItemDts WHERE TopID=" + entity.ID;
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE FROM Data_ItemGY WHERE ID=" + entity.ID;
                sqlTrans.ExecuteNonQuery(sql);
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
        #endregion

        #region  新增方法
        /// <summary>
        /// 新增(复合布)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE3)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE3, sqlTrans);

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
        /// 新增(复合布)(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);

                Item entity = (Item)p_BE;
                this.RAdd(p_BE, sqlTrans);

                for (int i = 0; i < p_BE3.Length; i++)
                {
                    ItemCompositeDtsRule rule = new ItemCompositeDtsRule();
                    ItemCompositeDts entityItemDts = (ItemCompositeDts)p_BE3[i];
                    entityItemDts.MainID = entity.ID;
                    entityItemDts.Seq = i + 1;
                    rule.RAdd(entityItemDts, sqlTrans);
                }

                ;
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
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="p_BE3">原料</param>
        /// <param name="p_BE4">颜色</param>
        /// <param name="p_BE5">类别</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5)
        {
            RAdd(p_BE, p_BE3, p_BE4, p_BE5, null);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="p_BE3">原料</param>
        /// <param name="p_BE4">颜色</param>
        /// <param name="p_BE5">类别</param>
        /// <param name="p_BE6">物理指标</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, BaseEntity[] p_BE6)
        {
            RAdd(p_BE, p_BE3, p_BE4, p_BE5, p_BE6, null,null);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="p_BE3">原料</param>
        /// <param name="p_BE4">颜色</param>
        /// <param name="p_BE5">类别</param>
        /// <param name="p_BE6">物理指标</param>
        /// <param name="p_BE7">替代白坯</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, BaseEntity[] p_BE6, BaseEntity[] p_BE7)
        {
            RAdd(p_BE, p_BE3, p_BE4, p_BE5, p_BE6, p_BE7, null);
        }

       
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="p_BE3">原料</param>
        /// <param name="p_BE4">颜色</param>
        /// <param name="p_BE5">类别</param>
        /// <param name="p_BE6">物理指标</param>
        /// <param name="p_BE7">替代白坯</param>
        /// <param name="p_BE8">工厂编码及报价</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, BaseEntity[] p_BE6, BaseEntity[] p_BE7, BaseEntity[] p_BE8)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE3, p_BE4, p_BE5, p_BE6, p_BE7, p_BE8,sqlTrans);

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
        /// 新增(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="p_BE3">原料</param>
        /// <param name="p_BE4">颜色</param>
        /// <param name="p_BE5">类别</param>
        /// <param name="p_BE6">物理指标</param>
        /// <param name="p_BE7">替代白坯</param>
        /// <param name="p_BE8">工厂编码及报价</param>
        /// <param name="sqlTrans">事务类</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, BaseEntity[] p_BE6, BaseEntity[] p_BE7, BaseEntity[] p_BE8, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);

                Item entity = (Item)p_BE;
                this.RAdd(p_BE, sqlTrans);

                for (int i = 0; i < p_BE3.Length; i++)
                {
                    ItemDtsRule rule = new ItemDtsRule();
                    ItemDts entityItemDts = (ItemDts)p_BE3[i];
                    entityItemDts.MainID = entity.ID;
                    entityItemDts.Seq = i + 1;
                    rule.RAdd(entityItemDts, sqlTrans);
                }

                for (int i = 0; i < p_BE4.Length; i++)
                {
                    ItemColorDtsRule rule = new ItemColorDtsRule();
                    ItemColorDts entityItemColorDts = (ItemColorDts)p_BE4[i];
                    entityItemColorDts.MainID = entity.ID;
                    entityItemColorDts.Seq = i + 1;
                    rule.RAdd(entityItemColorDts, sqlTrans);
                }
                for (int i = 0; i < p_BE5.Length; i++)
                {
                    ItemLBDtsRule rule = new ItemLBDtsRule();
                    ItemLBDts entityItemLBDts = (ItemLBDts)p_BE5[i];
                    entityItemLBDts.MainID = entity.ID;
                    entityItemLBDts.Seq = i + 1;
                    rule.RAdd(entityItemLBDts, sqlTrans);
                }
                if (p_BE6 != null)
                {
                    for (int i = 0; i < p_BE6.Length; i++)
                    {
                        ItemCheckStandardPhyRule rule = new ItemCheckStandardPhyRule();
                        ItemCheckStandardPhy entityItemcsp = (ItemCheckStandardPhy)p_BE6[i];
                        entityItemcsp.MainID = entity.ID;
                        entityItemcsp.Seq = i + 1;
                        rule.RAdd(entityItemcsp, sqlTrans);
                    }
                }

                if (p_BE7 != null)
                {
                    for (int i = 0; i < p_BE7.Length; i++)
                    {
                        ItemGreyFabReplaceRule rule = new ItemGreyFabReplaceRule();
                        ItemGreyFabReplace entityItemgfr = (ItemGreyFabReplace)p_BE7[i];
                        entityItemgfr.MainID = entity.ID;
                        entityItemgfr.Seq = i + 1;
                        rule.RAdd(entityItemgfr, sqlTrans);
                    }
                }

                if (p_BE8 != null)
                {
                    for (int i = 0; i < p_BE8.Length; i++)
                    {
                        ItemCodeFacDtsRule rule = new ItemCodeFacDtsRule();
                        ItemCodeFacDts entityItemfac = (ItemCodeFacDts)p_BE8[i];
                        entityItemfac.MainID = entity.ID;
                        entityItemfac.Seq = i + 1;
                        rule.RAdd(entityItemfac, sqlTrans);
                    }
                }
                //FormNoControlRule rulefSt = new FormNoControlRule();
                //rulefSt.RAddSort((int)FormNoControlEnum.产品编码, sqlTrans);
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
        /// 修改
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="p_BE3">原料</param>
        /// <param name="p_BE4">颜色</param>
        /// <param name="p_BE5">类别</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5)
        {
            RUpdate(p_BE, p_BE3, p_BE4, p_BE5, null);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="p_BE3">原料</param>
        /// <param name="p_BE4">颜色</param>
        /// <param name="p_BE5">类别</param>
        /// <param name="p_BE6">物理指标</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, BaseEntity[] p_BE6)
        {
            RUpdate(p_BE, p_BE3, p_BE4, p_BE5, p_BE6, null,null);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="p_BE3">原料</param>
        /// <param name="p_BE4">颜色</param>
        /// <param name="p_BE5">类别</param>
        /// <param name="p_BE6">物理指标</param>
        /// <param name="p_BE7">替代白坯</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, BaseEntity[] p_BE6, BaseEntity[] p_BE7)
        {
            RUpdate(p_BE, p_BE3, p_BE4, p_BE5, p_BE6, p_BE7, null);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="p_BE3">原料</param>
        /// <param name="p_BE4">颜色</param>
        /// <param name="p_BE5">类别</param>
        /// <param name="p_BE6">物理指标</param>
        /// <param name="p_BE7">替代白坯</param>
        /// <param name="p_BE8">工厂编码及报价</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, BaseEntity[] p_BE6, BaseEntity[] p_BE7, BaseEntity[] p_BE8)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE3, p_BE4, p_BE5, p_BE6, p_BE7, p_BE8, sqlTrans);

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
        /// 修改
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="p_BE3">原料</param>
        /// <param name="p_BE4">颜色</param>
        /// <param name="p_BE5">类别</param>
        /// <param name="p_BE6">物理指标</param>
        /// <param name="p_BE7">替代白坯</param>
        /// <param name="p_BE8">工厂编码及报价</param>
        /// <param name="sqlTrans">事务类</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, BaseEntity[] p_BE6, BaseEntity[] p_BE7, BaseEntity[] p_BE8, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                Item entity = (Item)p_BE;

                this.RUpdate(entity, sqlTrans);

                ItemDtsRule rule1 = new ItemDtsRule();
                rule1.RSave(entity, p_BE3, sqlTrans);



                ItemColorDtsRule rule2 = new ItemColorDtsRule();
                rule2.RSave(entity, p_BE4, sqlTrans);


                ItemLBDtsRule rule3 = new ItemLBDtsRule();
                rule3.RSave(entity, p_BE5, sqlTrans);


                if (p_BE6 != null)
                {

                    ItemCheckStandardPhyRule rule4 = new ItemCheckStandardPhyRule();

                    rule4.RSave(entity, p_BE6, sqlTrans);
                }

                if (p_BE7 != null)
                {

                    ItemGreyFabReplaceRule rule4 = new ItemGreyFabReplaceRule();

                    rule4.RSave(entity, p_BE7, sqlTrans);
                }

                if (p_BE8 != null)
                {

                    ItemCodeFacDtsRule rule5 = new ItemCodeFacDtsRule();

                    rule5.RSave(entity, p_BE8, sqlTrans);
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
        /// 修改(复合布)
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE3)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE3, sqlTrans);

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
        /// 修改(复合布)
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                Item entity = (Item)p_BE;

                this.RUpdate(entity, sqlTrans);

                ItemCompositeDtsRule rule1 = new ItemCompositeDtsRule();
                rule1.RSave(entity, p_BE3, sqlTrans);






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

        #region 新增方法，维护纱线主从表
        /// <summary>
        /// 新增(纱线从表)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAddYarn(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAddYarn(p_BE, p_BE2, sqlTrans);

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
        /// 新增(纱线从表)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RAddYarn(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);

                Item entity = (Item)p_BE;
                this.RAdd(p_BE, sqlTrans);

                for (int i = 0; i < p_BE2.Length; i++)
                {
                    ItemDtsRule rule = new ItemDtsRule();
                    ItemDts entityItemDts = (ItemDts)p_BE2[i];
                    entityItemDts.MainID = entity.ID;
                    entityItemDts.Seq = i + 1;
                    rule.RAdd(entityItemDts, sqlTrans);
                }

                ;
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
        /// 修改(纱线从表)
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        public void RUpdateYarn(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdateYarn(p_BE, p_BE2, sqlTrans);

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
        /// 修改(纱线从表)
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RUpdateYarn(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                Item entity = (Item)p_BE;

                this.RUpdate(entity, sqlTrans);

                ItemDtsRule rule1 = new ItemDtsRule();
                rule1.RSave(entity, p_BE2, sqlTrans);

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

        #region 新生成方法
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4,int p_Flag)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE,p_BE2,p_BE3,p_BE4,p_Flag, sqlTrans);

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
        /// 新增(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, int p_Flag, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                Item entity = (Item)p_BE;
                string sql = "SELECT ItemCode FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("编码已存在，请重新生成");
                }

                ItemCtl control = new ItemCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Data_Item, sqlTrans);
                control.AddNew(entity);

                ItemColorDtsRule rule2 = new ItemColorDtsRule();
                rule2.RSave(entity, p_BE2, sqlTrans);

                ItemAddRule ruleItemAdd = new ItemAddRule();
                for (int i = 0; i < p_BE3.Length; i++)
                {
                    ItemAdd entityDts = (ItemAdd)p_BE3[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    ruleItemAdd.RAdd(entityDts,sqlTrans);

                    ruleItemAdd.UpdateFiledSet(entity.ID, entityDts.FiledSetID, entityDts.Value, sqlTrans);
                }

                ItemPicRule ruleItemPic = new ItemPicRule();
                for (int i = 0; i < p_BE4.Length; i++)
                {
                    ItemPic entityDts = (ItemPic)p_BE4[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    ruleItemPic.RAdd(entityDts, sqlTrans);
                }

                #region cost自动计算

                entity = new Item(sqlTrans);
                entity.ID = ((Item)p_BE).ID;
                entity.SelectByID();

                decimal Cost = 0;
                decimal PBPrice = entity.PBPrice;//坯价格
                decimal RShrinkage =GetDecimalByString(entity.RShrinkage,'%');
                decimal RSAmount = entity.RSAmount;
                decimal RSSH =GetDecimalByString(entity.RSSH,'%');
                decimal JGAmount = entity.JGAmount;
                decimal JGSH = GetDecimalByString(entity.JGSH, '%');
                decimal HZAmount = entity.HZAmount;
                decimal ProfitMargin = GetDecimalByString(entity.ProfitMargin, '%');
                decimal Quot = GetDecimalByString(entity.COST, '/') * (1m+(ProfitMargin / 100m));
                Cost = (((PBPrice * (1m + (RShrinkage / 100m)) + RSAmount) * (1m + (RSSH / 100m)) + JGAmount) * (1m + (JGSH / 100m)) + HZAmount) * 1.06m + 0.2m;
                Cost = SysConvert.ToDecimal(Cost,2);
                //Quot = SysConvert.ToDecimal(Quot,2);

                sql = "UPDATE Data_Item SET COSTA=" + SysString.ToDBString(Cost.ToString() + "/M");
                //sql += ",QUOT=" + SysString.ToDBString(Quot.ToString() + "/M");
                sql += " WHERE ID=" + SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);

                sql = "UPDATE Data_ItemAdd SET Value=" + SysString.ToDBString(Cost.ToString() + "/M");
                sql += " WHERE FiledName='COSTA'";// +SysString.ToDBString(entity.ID);
                sql += " AND MainID=" + SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);

                //sql = "UPDATE Data_ItemAdd SET Value=" + SysString.ToDBString(Quot.ToString() + "/M");
                //sql += " WHERE FiledName='QUOT'";// +SysString.ToDBString(entity.ID);
                //sql += " AND MainID=" + SysString.ToDBString(entity.ID);
                //sqlTrans.ExecuteNonQuery(sql);



                #endregion




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

        private decimal GetDecimalByString(string p_Decimal, char p_Char)
        {
            decimal value = 0;
            if (SysConvert.ToDecimal(p_Decimal) > 0)
            {
                value = SysConvert.ToDecimal(p_Decimal);
            }
            else
            {
                string[] decimalArr = p_Decimal.Split(p_Char);
                if (decimalArr.Length > 0)
                {
                    value = SysConvert.ToDecimal(decimalArr[0]);
                }
                else
                {
                    value = 0;
                }
            }
            return value;
        }

       


       
        

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, int p_Flag)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2, p_BE3, p_BE4, p_Flag,sqlTrans);

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
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, int p_Flag, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                Item entity = (Item)p_BE;
                string sql = "SELECT ItemCode FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode) + " AND ID<>" + entity.ID;
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("编码已存在，请重新生成");
                }

                ItemCtl control = new ItemCtl(sqlTrans);
                control.Update(entity);


                ItemColorDtsRule rule2 = new ItemColorDtsRule();
                rule2.RSave(entity, p_BE2, sqlTrans);

                if (p_BE3.Length > 0)
                {
                    sql = "DELETE  Data_ItemAdd WHERE MainID=" + SysString.ToDBString(entity.ID);
                    sql += " AND ISNULL(FormID,0)=" + SysString.ToDBString(((ItemAdd)p_BE3[0]).FormID);
                    sql += " AND ISNULL(FormAID,0)=" + SysString.ToDBString(((ItemAdd)p_BE3[0]).FormAID);
                    sql += " AND ISNULL(FormBID,0)=" + SysString.ToDBString(((ItemAdd)p_BE3[0]).FormBID);
                    sqlTrans.ExecuteNonQuery(sql);
                }

                ItemAddRule ruleItemAdd = new ItemAddRule();
                for (int i = 0; i < p_BE3.Length; i++)
                {
                    ItemAdd entityDts = (ItemAdd)p_BE3[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    ruleItemAdd.RAdd(entityDts, sqlTrans);

                    ruleItemAdd.UpdateFiledSet(entity.ID, entityDts.FiledSetID, entityDts.Value, sqlTrans);
                }

                sql = "DELETE Data_ItemPic WHERE MainID="+SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);

                ItemPicRule ruleItemPic = new ItemPicRule();
                for (int i = 0; i < p_BE4.Length; i++)
                {
                    ItemPic entityDts = (ItemPic)p_BE4[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    ruleItemPic.RAdd(entityDts, sqlTrans);
                }

                #region cost自动计算

                entity = new Item(sqlTrans);
                entity.ID = ((Item)p_BE).ID;
                entity.SelectByID();

                decimal Cost = 0;
                decimal PBPrice = entity.PBPrice;//坯价格
                decimal RShrinkage = GetDecimalByString(entity.RShrinkage, '%');
                decimal RSAmount = entity.RSAmount;
                decimal RSSH = GetDecimalByString(entity.RSSH, '%');
                decimal JGAmount = entity.JGAmount;
                decimal JGSH = GetDecimalByString(entity.JGSH, '%');
                decimal HZAmount =entity.HZAmount;
                decimal ProfitMargin = GetDecimalByString( entity.ProfitMargin,'%');
                decimal Quot =  GetDecimalByString( entity.COST,'/') * (1m+(ProfitMargin / 100m));
                Cost = (((PBPrice * (1m + (RShrinkage / 100m)) + RSAmount) * (1m + (RSSH / 100m)) + JGAmount) * (1m + (JGSH / 100m)) + HZAmount) * 1.06m + 0.2m;
                Cost = SysConvert.ToDecimal(Cost, 2);
                //Quot = SysConvert.ToDecimal(Quot, 2);

                sql = "UPDATE Data_Item SET COSTA=" + SysString.ToDBString(Cost.ToString() + "/M");
                //sql += ",QUOT="+SysString.ToDBString(Quot.ToString()+"/M");
                sql += " WHERE ID=" + SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);

                sql = "UPDATE Data_ItemAdd SET Value=" + SysString.ToDBString(Cost.ToString() + "/M");
                sql += " WHERE FiledName='COSTA'";// +SysString.ToDBString(entity.ID);
                sql += " AND MainID=" + SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);

                //sql = "UPDATE Data_ItemAdd SET Value=" + SysString.ToDBString(Quot.ToString() + "/M");
                //sql += " WHERE FiledName='QUOT'";// +SysString.ToDBString(entity.ID);
                //sql += " AND MainID=" + SysString.ToDBString(entity.ID);
                //sqlTrans.ExecuteNonQuery(sql);



                #endregion
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


       #region

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5,int Flag)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2, p_BE3, p_BE4,p_BE5,Flag, sqlTrans);

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
        /// 新增(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, int Flag, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                Item entity = (Item)p_BE;
                string sql = "SELECT ItemCode FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("编码已存在，请重新生成");
                }

                ItemCtl control = new ItemCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Data_Item, sqlTrans);
                control.AddNew(entity);

                ItemColorDtsRule rule2 = new ItemColorDtsRule();
                rule2.RSave(entity, p_BE2, sqlTrans);

                ItemAddRule ruleItemAdd = new ItemAddRule();
                for (int i = 0; i < p_BE3.Length; i++)
                {
                    ItemAdd entityDts = (ItemAdd)p_BE3[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    ruleItemAdd.RAdd(entityDts, sqlTrans);

                    ruleItemAdd.UpdateFiledSet(entity.ID, entityDts.FiledSetID, entityDts.Value, sqlTrans);
                }

                ItemPicRule ruleItemPic = new ItemPicRule();
                for (int i = 0; i < p_BE4.Length; i++)
                {
                    ItemPic entityDts = (ItemPic)p_BE4[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    ruleItemPic.RAdd(entityDts, sqlTrans);
                }

                ItemCodeFacDtsRule ruleItemCodeFac = new ItemCodeFacDtsRule();
                for (int i = 0; i < p_BE5.Length; i++)
                {
                    ItemCodeFacDts entityDts = (ItemCodeFacDts)p_BE5[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    ruleItemCodeFac.RAdd(entityDts, sqlTrans);
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
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, int Flag)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2, p_BE3, p_BE4, p_BE5,Flag, sqlTrans);

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
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, int Flag, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                Item entity = (Item)p_BE;
                string sql = "SELECT ItemCode FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode) + " AND ID<>" + entity.ID;
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("编码已存在，请重新生成");
                }

                ItemCtl control = new ItemCtl(sqlTrans);
                control.Update(entity);


                ItemColorDtsRule rule2 = new ItemColorDtsRule();
                rule2.RSave(entity, p_BE2, sqlTrans);

                if (p_BE3.Length > 0)
                {
                    sql = "DELETE  Data_ItemAdd WHERE MainID=" + SysString.ToDBString(entity.ID);
                    sql += " AND ISNULL(FormID,0)=" + SysString.ToDBString(((ItemAdd)p_BE3[0]).FormID);
                    sql += " AND ISNULL(FormAID,0)=" + SysString.ToDBString(((ItemAdd)p_BE3[0]).FormAID);
                    sql += " AND ISNULL(FormBID,0)=" + SysString.ToDBString(((ItemAdd)p_BE3[0]).FormBID);
                    sqlTrans.ExecuteNonQuery(sql);
                }

                ItemAddRule ruleItemAdd = new ItemAddRule();
                for (int i = 0; i < p_BE3.Length; i++)
                {
                    ItemAdd entityDts = (ItemAdd)p_BE3[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    ruleItemAdd.RAdd(entityDts, sqlTrans);

                    ruleItemAdd.UpdateFiledSet(entity.ID, entityDts.FiledSetID, entityDts.Value, sqlTrans);
                }

                sql = "DELETE Data_ItemPic WHERE MainID=" + SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);

                ItemPicRule ruleItemPic = new ItemPicRule();
                for (int i = 0; i < p_BE4.Length; i++)
                {
                    ItemPic entityDts = (ItemPic)p_BE4[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    ruleItemPic.RAdd(entityDts, sqlTrans);
                }

                sql = "DELETE Data_ItemCodeFacDts WHERE MainID=" + SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);

                ItemCodeFacDtsRule ruleItemCodeFac = new ItemCodeFacDtsRule();
                for (int i = 0; i < p_BE5.Length; i++)
                {
                    ItemCodeFacDts entityDts = (ItemCodeFacDts)p_BE5[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    ruleItemCodeFac.RAdd(entityDts, sqlTrans);
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
