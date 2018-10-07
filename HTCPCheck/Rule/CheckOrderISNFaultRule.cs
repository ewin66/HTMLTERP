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
	/// 目的：Chk_CheckOrderISNFault实体业务规则类
	/// 作者:周富春
	/// 创建日期:2015/11/4
	/// </summary>
	public class CheckOrderISNFaultRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public CheckOrderISNFaultRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			CheckOrderISNFault entity=(CheckOrderISNFault)p_BE;
		}	
		
		/// <summary>
        /// 检验字段值是否已存在
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_FieldName">字段名</param>
        /// <param name="p_FieldValue">字段值</param>
        /// <param name="p_KeyField">主键（只考虑主键为ID的情况）</param>
        /// <param name="p_KeyValue">主键值</param>
        /// <param name="p_sqlTrans"></param>
        /// <returns></returns>
        private bool CheckFieldValueIsExist(BaseEntity p_BE, string p_FieldName, string p_FieldValue, IDBTransAccess p_sqlTrans)
        {
            CheckOrderISNFault entity = (CheckOrderISNFault)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, CheckOrderISNFault.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
            DataTable dt = p_sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                ret = true;
            }

            return ret;
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
                string sql = "SELECT " + p_FieldName + " FROM Chk_CheckOrderISNFault WHERE 1=1";
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
				CheckOrderISNFault entity=(CheckOrderISNFault)p_BE;				
				CheckOrderISNFaultCtl control=new CheckOrderISNFaultCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Chk_CheckOrderISNFault, sqlTrans);
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
				CheckOrderISNFault entity=(CheckOrderISNFault)p_BE;				
				CheckOrderISNFaultCtl control=new CheckOrderISNFaultCtl(sqlTrans);				
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
				CheckOrderISNFault entity=(CheckOrderISNFault)p_BE;				
				CheckOrderISNFaultCtl control=new CheckOrderISNFaultCtl(sqlTrans);
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


        #region 保存疵点
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public int RSaveFault(CheckOrderISNFault p_BE, CheckOrderISN entity, int MainID, int PackDtsID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    int TempID = this.RSaveFault(p_BE, entity, MainID, PackDtsID, sqlTrans);

                    sqlTrans.CommitTrans();

                    return TempID;
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
        public int RSaveFault(CheckOrderISNFault p_BE, CheckOrderISN entityMain, int MainID, int PackDtsID, IDBTransAccess sqlTrans)
        {
            try
            {
                if (PackDtsID == 0)
                {
                    throw new Exception("请先选择检验指示单");
                }
                CheckOrderISNFault entity = p_BE as CheckOrderISNFault;
                if (MainID == 0)
                {
                    entityMain.MainID = PackDtsID;

                    CheckOrderISNRule rulebp = new CheckOrderISNRule();


                    //entityMain.CY += entity.CYQty;
                    entityMain.Qty = entityMain.ChkQty - entityMain.KJQty;

                    rulebp.RAdd(entityMain, sqlTrans);

                    entity.MainID = entityMain.ID;
                }
                else
                {
                    CheckOrderISNRule rulebp = new CheckOrderISNRule();

                    //entityMain.CY += entity.CYQty;

                    entityMain.Qty = entityMain.ChkQty - entityMain.KJQty;

                    rulebp.RUpdate(entityMain, sqlTrans);
                }

                RAdd(entity, sqlTrans);



                return entity.MainID;
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


        #region 此卷结束
        /// <summary>
        /// 检验结束
        /// </summary>
        /// <param name="p_BE"></param>
        /// <param name="entity"></param>
        /// <param name="p_PackID"></param>
        /// <param name="Qty">码表数量</param>
        /// <param name="YMQty">原码数量，暂不使用</param>
        /// <param name="JarNo">缸号</param>
        /// <returns></returns>
        public int RJYEnd(int p_BE, CheckOrderISN entity, int p_PackID, decimal Qty, decimal YMQty, int JarNo)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    int tempID = this.RJYEnd(p_BE, entity, p_PackID, Qty, YMQty, JarNo, sqlTrans);

                    sqlTrans.CommitTrans();


                    return tempID;
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
        /// 检验结束
        /// </summary>
        /// <param name="p_BE">要删除的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public int RJYEnd(int p_BE, CheckOrderISN entity2, int p_PackID, decimal Qty, decimal YMQty, int ReelNo, IDBTransAccess sqlTrans)
        {
            try
            {

                if (p_BE == 0)//如果是0 则表示没有疵点
                {
                    entity2.MainID = p_PackID;

                    CheckOrderISNRule rulebp = new CheckOrderISNRule();

                    rulebp.RAdd(entity2, sqlTrans);

                    p_BE = entity2.ID;
                }
                CheckOrderISN entity = new CheckOrderISN(sqlTrans);
                entity.ID = p_BE;
                entity.SelectByID();
                entity.MainID = p_PackID;

                entity.ChkQty = Qty;//码表数量  
            

                entity.ColorName = entity2.ColorName;//颜色
                entity.ColorNum = entity2.ColorNum;//色号
                entity.MWidth = entity2.MWidth;//平均门幅
                entity.MWeight = entity2.MWeight;//平均克重



                string sqls = "SELECT MAX(Seq) Seq FROM Chk_CheckOrderISN WHERE JarNum=" + SysString.ToDBString(entity.JarNum);
                sqls += " AND MainID=" + p_BE;

                //string sqls = "Select ISNULL(Max(ReelNo),0) From Chk_CheckOrderISN where JarNum=" + SysString.ToDBString(SysConvert.ToString(entity.JarNum));
                //sqls += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(entity.ItemCode));
                //sqls += " AND ColorNum=" + SysString.ToDBString(SysConvert.ToString(entity.ColorNum));
                DataTable dts = sqlTrans.Fill(sqls);
                if ((SysConvert.ToInt32(dts.Rows[0][0]) + 1) != ReelNo)
                {
                    entity.ReelNo = SysConvert.ToString(SysConvert.ToInt32(dts.Rows[0][0]) + 1);//卷号
                }
                else
                {
                    entity.ReelNo = SysConvert.ToString(ReelNo);//卷号
                }

        

                //entity.YQty = SysConvert.ToDecimal(Qty * 1.0936132983377m, 2);//米数转码数
                CheckOrderISNRule rule = new CheckOrderISNRule();
                rule.RUpdate(entity, sqlTrans);







                #region 统计合计数据
                entity.KJQty = 0.0m;//开剪数量合计
                string sql = "SELECT SUM(cast(Deduction as decimal(10,2))) Deduction FROM Chk_CheckOrderISNFault  WHERE 1=1";
                sql += " AND MainID=" + p_BE;
                sql += " AND FaultType=3";//开剪
                sql += " AND ISNUMERIC(Deduction)=1";
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    entity.KJQty = SysConvert.ToDecimal(dt.Rows[0]["Deduction"]);
                }

                entity.Qty = SysConvert.ToDecimal(entity.ChkQty - entity.KJQty, 2);//实际数量=码表数量-裁剪数量
                CheckOrderISNRule rulebp2 = new CheckOrderISNRule();
                rulebp2.RUpdate(entity, sqlTrans);

                #endregion


                #region 合计检验米数汇总到待检清单

                 sql = "Select SUM(Qty) Qty from Chk_CheckOrderISN where MainID=" + p_PackID;
                DataTable dtS = sqlTrans.Fill(sql);
                if (dtS.Rows.Count != 0)
                {
                    sql = "Update Chk_CheckOrderDts Set CheckQty=" + SysConvert.ToDecimal(dtS.Rows[0]["Qty"]);
                    sql += " where ID=" + p_PackID;
                    sqlTrans.ExecuteNonQuery(sql);
                }
                #endregion

                #region 计算同个缸号的平均门幅、克重
                //decimal AvgMWidth = 0.0m;
                //decimal AvgMWeight = 0.0m;
                //sql = "Select Avg(MWidth) MWidth,Avg(MWeight) MWeight from WO_BProductCheckDtsFault where 1=1";
                //sql += " AND MainID in(select ID from WO_BProductCheckDts  where 1=1 AND MainID=" + entity.MainID + ")";
                //sql += " AND ISNULL(MWidth,0)<>0  AND ISNULL(MWeight,0)<>0  ";
                //DataTable dtAvg = sqlTrans.Fill(sql);
                //if (dtAvg.Rows.Count != 0)
                //{
                //    AvgMWidth = SysConvert.ToDecimal(dtAvg.Rows[0]["MWidth"]);
                //    AvgMWeight = SysConvert.ToDecimal(dtAvg.Rows[0]["MWeight"]);
                //}
                //sql = "Update WO_BProductCheckDts set JarNumMWidth =" + AvgMWidth;
                //sql += ",JarNumMWeight=" + AvgMWeight;
                //sql += " where 1=1 AND MainID=" + entity.MainID;
                //sqlTrans.ExecuteNonQuery(sql);

                #endregion


                return p_BE;

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
