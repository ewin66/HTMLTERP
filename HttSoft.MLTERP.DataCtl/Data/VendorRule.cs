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
	/// 目的：Data_Vendor实体业务规则类
	/// 作者:陈加海
	/// 创建日期:2012-4-19
	/// </summary>
	public class VendorRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public VendorRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			Vendor entity=(Vendor)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Data_Vendor WHERE 1=1";
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
				Vendor entity=(Vendor)p_BE;


                string sql = "SELECT ID FROM Data_Vendor WHERE VendorID=" + SysString.ToDBString(entity.VendorID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("客户编码已存在，请检查后重新输入");
                }
                sql = "SELECT ID FROM Data_Vendor WHERE VendorAttn=" + SysString.ToDBString(entity.VendorAttn);
                dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("客户简称已存在，请检查后重新输入");
                }
                sql = "SELECT ID FROM Data_Vendor WHERE VendorName=" + SysString.ToDBString(entity.VendorName);
                dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("客户全称已存在，请检查后重新输入");
                }


                sql = "SELECT ID FROM Data_Vendor WHERE QQ=" + SysString.ToDBString(entity.QQ);
                sql += " AND ISNULL(QQ,'')<>''";
                dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("客户QQ已存在，请检查后重新输入");
                }
                sql = "SELECT ID FROM Data_Vendor WHERE Address=" + SysString.ToDBString(entity.Address);
                sql += " AND ISNULL(Address,'')<>''";
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("客户地址已存在，请检查后重新输入");
                }


				VendorCtl control=new VendorCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Data_Vendor,sqlTrans);
				control.AddNew(entity);

                FormNoControlRule fnrule = new FormNoControlRule();
                fnrule.RAddSort("Data_Vendor", "VendorID", entity.VendorTypeID, sqlTrans);
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
				Vendor entity=(Vendor)p_BE;				
				VendorCtl control=new VendorCtl(sqlTrans);

                string sql = "SELECT ID FROM Data_Vendor WHERE ID<>"+entity.ID+" AND VendorID=" + SysString.ToDBString(entity.VendorID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("客户编码已存在，请检查后重新输入");
                }
                sql = "SELECT ID FROM Data_Vendor WHERE ID<>" + entity.ID + " AND VendorAttn=" + SysString.ToDBString(entity.VendorAttn);
                dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("客户简称已存在，请检查后重新输入");
                }
                sql = "SELECT ID FROM Data_Vendor WHERE ID<>" + entity.ID + " AND VendorName=" + SysString.ToDBString(entity.VendorName);
                dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("客户全称已存在，请检查后重新输入");
                }



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
				Vendor entity=(Vendor)p_BE;				
				VendorCtl control=new VendorCtl(sqlTrans);
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

        #region 新增方法

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, ArrayList p_BE6)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2, p_BE3, p_BE4, p_BE5,p_BE6,sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, ArrayList p_BE6, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                Vendor entity = (Vendor)p_BE;
                this.RAdd(entity, sqlTrans);
                //string sql = "SELECT * FROM Data_Vendor WHERE VendorID="+SysString.ToDBString(entity.VendorID);
                //DataTable dt = sqlTrans.Fill(sql);
                //if (dt.Rows.Count > 0)
                //{
                //    throw new BaseException("客户编码已存在，请检查后重新输入");
                //}
                //sql = "SELECT * FROM Data_Vendor WHERE VendorAttn=" + SysString.ToDBString(entity.VendorAttn);
                //dt = sqlTrans.Fill(sql);
                //if (dt.Rows.Count > 0)
                //{
                //    throw new BaseException("客户简称已存在，请检查后重新输入");
                //}
                //sql = "SELECT * FROM Data_Vendor WHERE VendorName=" + SysString.ToDBString(entity.VendorName);
                //dt = sqlTrans.Fill(sql);
                //if (dt.Rows.Count > 0)
                //{
                //    throw new BaseException("客户全称已存在，请检查后重新输入");
                //}
                //VendorCtl control = new VendorCtl(sqlTrans);
                //entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Data_Vendor, sqlTrans);
                //control.AddNew(entity);
                //新增客户联系人
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    VendorContactRule rule = new VendorContactRule();
                    VendorContact entityVendorContact = (VendorContact)p_BE2[i];
                    entityVendorContact.MainID = entity.ID;
                    entityVendorContact.Seq = i + 1;
                    rule.RAdd(entityVendorContact, sqlTrans);
                }
                //新增客户归属业务员
                for (int i = 0; i < p_BE3.Length; i++)
                {
                    VendorSaleOPRule rule = new VendorSaleOPRule();
                    VendorSaleOP entityVendorSaleOP = (VendorSaleOP)p_BE3[i];
                    entityVendorSaleOP.MainID = entity.ID;
                    entityVendorSaleOP.Seq = i + 1;
                    rule.RAdd(entityVendorSaleOP, sqlTrans);
                }

                for (int i = 0; i < p_BE4.Length; i++)
                {
                    VendorAddressRule rule = new VendorAddressRule();
                    VendorAddress entityVendorAddress = (VendorAddress)p_BE4[i];
                    entityVendorAddress.MainID = entity.ID;
                    entityVendorAddress.Seq = i + 1;
                    rule.RAdd(entityVendorAddress, sqlTrans);
                }

                for (int i = 0; i < p_BE5.Length; i++)
                {
                    VendorNewsRule rule = new VendorNewsRule();
                    VendorNews entityVendorNews = (VendorNews)p_BE5[i];
                    entityVendorNews.MainID = entity.ID;
                    entityVendorNews.Seq = i + 1;
                    rule.RAdd(entityVendorNews, sqlTrans);
                }


                VendorTypeDtsRule vendortyperule = new VendorTypeDtsRule();
                vendortyperule.RSave(p_BE, p_BE6, sqlTrans);
                //FormNoControlRule fnrule = new FormNoControlRule();
                //fnrule.RAddSort("Data_Vendor", "VendorID", entity.VendorTypeID, sqlTrans);
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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5,ArrayList p_BE6)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2, p_BE3, p_BE4, p_BE5, p_BE6,sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, ArrayList p_BE6, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                Vendor entity = (Vendor)p_BE;
                this.RUpdate(p_BE, sqlTrans);
                //VendorCtl control = new VendorCtl(sqlTrans);
                //control.Update(entity);
                string sql = "DELETE Data_VendorSaleOP WHERE MainID="+SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE  Data_VendorContact WHERE MainID="+SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE  Data_VendorAddress WHERE MainID=" + SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE  Data_VendorNews WHERE MainID=" + SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);
                //新增客户联系人
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    VendorContactRule rule = new VendorContactRule();
                    VendorContact entityVendorContact = (VendorContact)p_BE2[i];
                    entityVendorContact.MainID = entity.ID;
                    entityVendorContact.Seq = i + 1;
                    rule.RAdd(entityVendorContact, sqlTrans);
                }
                //新增客户归属业务员
                for (int i = 0; i < p_BE3.Length; i++)
                {
                    VendorSaleOPRule rule = new VendorSaleOPRule();
                    VendorSaleOP entityVendorSaleOP = (VendorSaleOP)p_BE3[i];
                    entityVendorSaleOP.MainID = entity.ID;
                    entityVendorSaleOP.Seq = i + 1;
                    rule.RAdd(entityVendorSaleOP, sqlTrans);
                }

                for (int i = 0; i < p_BE4.Length; i++)
                {
                    VendorAddressRule rule = new VendorAddressRule();
                    VendorAddress entityVendorAddress = (VendorAddress)p_BE4[i];
                    entityVendorAddress.MainID = entity.ID;
                    entityVendorAddress.Seq = i + 1;
                    rule.RAdd(entityVendorAddress, sqlTrans);
                }

                for (int i = 0; i < p_BE5.Length; i++)
                {
                    VendorNewsRule rule = new VendorNewsRule();
                    VendorNews entityVendorNews = (VendorNews)p_BE5[i];
                    entityVendorNews.MainID = entity.ID;
                    entityVendorNews.Seq = i + 1;
                    rule.RAdd(entityVendorNews, sqlTrans);
                }

                VendorTypeDtsRule vendortyperule = new VendorTypeDtsRule();
                vendortyperule.RSave(p_BE, p_BE6, sqlTrans);


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

        #region 带辅助信息

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, ArrayList p_BE6, BaseEntity[] p_BE7, BaseEntity[] p_BE8)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2, p_BE3, p_BE4, p_BE5, p_BE6, p_BE7, p_BE8,sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, ArrayList p_BE6, BaseEntity[] p_BE7, BaseEntity[] p_BE8, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                Vendor entity = (Vendor)p_BE;
                this.RAdd(entity, sqlTrans);
              
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    VendorContactRule rule = new VendorContactRule();
                    VendorContact entityVendorContact = (VendorContact)p_BE2[i];
                    entityVendorContact.MainID = entity.ID;
                    entityVendorContact.Seq = i + 1;
                    rule.RAdd(entityVendorContact, sqlTrans);
                }
                //新增客户归属业务员
                for (int i = 0; i < p_BE3.Length; i++)
                {
                    VendorSaleOPRule rule = new VendorSaleOPRule();
                    VendorSaleOP entityVendorSaleOP = (VendorSaleOP)p_BE3[i];
                    entityVendorSaleOP.MainID = entity.ID;
                    entityVendorSaleOP.Seq = i + 1;
                    rule.RAdd(entityVendorSaleOP, sqlTrans);
                }

                for (int i = 0; i < p_BE4.Length; i++)
                {
                    VendorAddressRule rule = new VendorAddressRule();
                    VendorAddress entityVendorAddress = (VendorAddress)p_BE4[i];
                    entityVendorAddress.MainID = entity.ID;
                    entityVendorAddress.Seq = i + 1;
                    rule.RAdd(entityVendorAddress, sqlTrans);
                }

                for (int i = 0; i < p_BE5.Length; i++)
                {
                    VendorNewsRule rule = new VendorNewsRule();
                    VendorNews entityVendorNews = (VendorNews)p_BE5[i];
                    entityVendorNews.MainID = entity.ID;
                    entityVendorNews.Seq = i + 1;
                    rule.RAdd(entityVendorNews, sqlTrans);
                }

                for (int i = 0; i < p_BE7.Length; i++)
                {
                    ItemAddRule rule = new ItemAddRule();
                    ItemAdd entityItemAdd = (ItemAdd)p_BE7[i];
                    entityItemAdd.MainID = entity.ID;
                    entityItemAdd.Seq = i + 1;
                    rule.RAdd(entityItemAdd, sqlTrans);
                    rule.UpdateFiledSet(entity.ID, entityItemAdd.FiledSetID, entityItemAdd.Value, sqlTrans);
                }

                for (int i = 0; i < p_BE8.Length; i++)
                {
                    VendorInvoiceDtsRule rule = new VendorInvoiceDtsRule();
                    VendorInvoiceDts entityItemInvoice = (VendorInvoiceDts)p_BE8[i];
                    entityItemInvoice.MainID = entity.ID;
                    entityItemInvoice.Seq = i + 1;
                    rule.RAdd(entityItemInvoice, sqlTrans);
                   
                }


                VendorTypeDtsRule vendortyperule = new VendorTypeDtsRule();
                vendortyperule.RSave(p_BE, p_BE6, sqlTrans);
                //FormNoControlRule fnrule = new FormNoControlRule();
                //fnrule.RAddSort("Data_Vendor", "VendorID", entity.VendorTypeID, sqlTrans);
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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, ArrayList p_BE6, BaseEntity[] p_BE7, BaseEntity[] p_BE8)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2, p_BE3, p_BE4, p_BE5, p_BE6,p_BE7,p_BE8, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4, BaseEntity[] p_BE5, ArrayList p_BE6, BaseEntity[] p_BE7, BaseEntity[] p_BE8, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                Vendor entity = (Vendor)p_BE;
                this.RUpdate(p_BE, sqlTrans);
                //VendorCtl control = new VendorCtl(sqlTrans);
                //control.Update(entity);
                string sql = "DELETE Data_VendorSaleOP WHERE MainID=" + SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE  Data_VendorContact WHERE MainID=" + SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE  Data_VendorAddress WHERE MainID=" + SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE  Data_VendorNews WHERE MainID=" + SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE  Data_VendorInvoiceDts WHERE MainID=" + SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);
                if (p_BE7.Length > 0)
                {
                    sql = "DELETE  Data_ItemAdd WHERE MainID=" + SysString.ToDBString(entity.ID);
                    sql += " AND ISNULL(FormID,0)=" + SysString.ToDBString(((ItemAdd)p_BE7[0]).FormID);
                    sql += " AND ISNULL(FormAID,0)=" + SysString.ToDBString(((ItemAdd)p_BE7[0]).FormAID);
                    sql += " AND ISNULL(FormBID,0)=" + SysString.ToDBString(((ItemAdd)p_BE7[0]).FormBID);
                    sqlTrans.ExecuteNonQuery(sql);
                }
                //新增客户联系人
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    VendorContactRule rule = new VendorContactRule();
                    VendorContact entityVendorContact = (VendorContact)p_BE2[i];
                    entityVendorContact.MainID = entity.ID;
                    entityVendorContact.Seq = i + 1;
                    rule.RAdd(entityVendorContact, sqlTrans);
                }
                //新增客户归属业务员
                for (int i = 0; i < p_BE3.Length; i++)
                {
                    VendorSaleOPRule rule = new VendorSaleOPRule();
                    VendorSaleOP entityVendorSaleOP = (VendorSaleOP)p_BE3[i];
                    entityVendorSaleOP.MainID = entity.ID;
                    entityVendorSaleOP.Seq = i + 1;
                    rule.RAdd(entityVendorSaleOP, sqlTrans);
                }

                for (int i = 0; i < p_BE4.Length; i++)
                {
                    VendorAddressRule rule = new VendorAddressRule();
                    VendorAddress entityVendorAddress = (VendorAddress)p_BE4[i];
                    entityVendorAddress.MainID = entity.ID;
                    entityVendorAddress.Seq = i + 1;
                    rule.RAdd(entityVendorAddress, sqlTrans);
                }

                for (int i = 0; i < p_BE5.Length; i++)
                {
                    VendorNewsRule rule = new VendorNewsRule();
                    VendorNews entityVendorNews = (VendorNews)p_BE5[i];
                    entityVendorNews.MainID = entity.ID;
                    entityVendorNews.Seq = i + 1;
                    rule.RAdd(entityVendorNews, sqlTrans);
                }

                for (int i = 0; i < p_BE7.Length; i++)
                {
                    ItemAddRule rule = new ItemAddRule();
                    ItemAdd entityItemAdd = (ItemAdd)p_BE7[i];
                    entityItemAdd.MainID = entity.ID;
                    entityItemAdd.Seq = i + 1;
                    rule.RAdd(entityItemAdd, sqlTrans);
                    rule.UpdateFiledSet(entity.ID, entityItemAdd.FiledSetID, entityItemAdd.Value, sqlTrans);
                }

                for (int i = 0; i < p_BE8.Length; i++)
                {
                    VendorInvoiceDtsRule rule = new VendorInvoiceDtsRule();
                    VendorInvoiceDts entityItemInvoice = (VendorInvoiceDts)p_BE8[i];
                    entityItemInvoice.MainID = entity.ID;
                    entityItemInvoice.Seq = i + 1;
                    rule.RAdd(entityItemInvoice, sqlTrans);

                }

                VendorTypeDtsRule vendortyperule = new VendorTypeDtsRule();
                vendortyperule.RSave(p_BE, p_BE6, sqlTrans);


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
