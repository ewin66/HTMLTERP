using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;


namespace HttSoft.MLTERP.DataCtl
{
	/// <summary>
	/// 目的：WH_DBForm实体业务规则类
	/// 作者:陈加海
	/// 创建日期:2014/7/21
	/// </summary>
	public class DBFormRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public DBFormRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			DBForm entity=(DBForm)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM WH_DBForm WHERE 1=1";
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
        public DataTable RShowDts(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_DBFormDts WHERE 1=1";
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



        #region 提交处理
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="p_FormID">单据ID</param>
        /// <param name="p_Type">0/1:弃审/审核</param>
        public void RSubmit(int p_FormID, int p_Type)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSubmit(p_FormID, p_Type, sqlTrans);
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
        /// 审核
        /// </summary>
        /// <param name="p_FormID">单据ID</param>
        /// <param name="p_Type">0/1/2/3:弃审/审核</param>
        public void RSubmit(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        {
            try
            {
                int p_TempType = p_Type;//处理状态
                string sql = string.Empty;
                DBForm entity = new DBForm(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();

                if (!RSubmitCheckJS(entity.FormDate, sqlTrans))
                {
                    throw new Exception("不允许操作，此单据日期之后已经有结算数据");
                }

                if (entity.SubmitFlag == p_Type)//如果相同异常
                {
                    throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
                }

                int p_AuditFlag = 0;
                //sql = "SELECT FillDataTypeID,AuditFlag,WHQtyPosID,CheckQtyPer1,CheckQtyFrom,CheckQtyPer2,DZFlag FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                //DataTable dtFormList = sqlTrans.Fill(sql);
                //if (dtFormList.Rows.Count != 0)
                //{
                //p_AuditFlag = SysConvert.ToInt32(dtFormList.Rows[0]["AuditFlag"]);
                if (p_AuditFlag == 0)//不需要审核
                {
                    switch (p_Type)
                    {
                        case (int)ConfirmFlag.未提交:
                            //p_Type=(int)ConfirmFlag.未提交;
                            break;
                        case (int)ConfirmFlag.已提交:
                            p_Type = (int)ConfirmFlag.审核通过;
                            break;
                        case (int)ConfirmFlag.审核通过:
                            //								p_Type=(int)ConfirmFlag.审核通过;
                            break;
                        case (int)ConfirmFlag.审核拒绝:
                            p_Type = (int)ConfirmFlag.未提交;
                            break;
                    }
                }

                #region 提交
                sql = "UPDATE WH_IOForm SET SubmitFlag=" + SysString.ToDBString(p_Type);
                if (p_Type == (int)ConfirmFlag.审核通过 || p_Type == (int)ConfirmFlag.审核拒绝)
                {
                    sql += ",SubmitOPID=" + SysString.ToDBString(ParamConfig.LoginName) + ",SubmitTime=" + SysString.ToDBString(DateTime.Now);
                }
                sql += " WHERE ID=" + p_FormID.ToString();//更新单据主表审核状态
                sqlTrans.ExecuteNonQuery(sql);



                //IOFormDtsRule ruledts = new IOFormDtsRule();
                //ruledts.RSubmit(p_FormID, TempSubmitType, dtFormList.Rows[0], sqlTrans);//操作子表库存

                #endregion

                if (entity.SubmitFlag == p_Type)//如果相同异常
                {
                    throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
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
        /// 提交时校验结算日
        /// </summary>
        /// <returns></returns>
        bool RSubmitCheckJS(DateTime p_FormDate, IDBTransAccess sqlTrans)
        {
            bool outbool = true;
            //ParamSetRule psrule = new ParamSetRule();
            //bool checkFlag = SysConvert.ToBoolean(psrule.RShowIntByID((int)ParamSetEnum.仓库提交校验库存结算日));//(int)ParamSetEnum.仓库提交校验库存结算日
            bool checkFlag = SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6421));

            if (checkFlag)//检测
            {
                string sql = string.Empty;
                sql = "SELECT TOP 1 JSDateE FROM WH_StorgeJS WHERE   JSFlag=1 ORDER BY JSDateE DESC";
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)//找到结算数据
                {
                    if (SysConvert.ToDateTime(dt.Rows[0]["JSDateE"]) >= p_FormDate)
                    {
                        outbool = false;
                    }
                }
            }

            return outbool;
        }
        #endregion


        #region  主从表保存方法
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2, sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                DBForm entity = (DBForm)p_BE;
                DBFormDtsRule ruledts = new DBFormDtsRule();
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    DBFormDts entityDts = (DBFormDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    ruledts.RAdd(entityDts, sqlTrans);
                }

                //ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//保存从表
                //FormNoControlRule rulest = new FormNoControlRule();
                //rulest.RAddSort((int)FormNoControlEnum.入库单号,sqlTrans);


                FormNoControlRule rulefn = new FormNoControlRule();//更新单号
                int tempFormNoControlID = 0;
                string sql = "SELECT FormNoControlID FROM Enum_FormListDB WHERE ID=" + SysString.ToDBString(entity.FormListDBID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                    
                }
                rulefn.RAddSort(tempFormNoControlID, sqlTrans);

                

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {

                this.RUpdate(p_BE, sqlTrans);
                DBFormDtsRule ruledts = new DBFormDtsRule();
                ruledts.RSave((DBForm)p_BE, p_BE2, sqlTrans);//保存从表


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


        #region 提交校验码单明细数据和列表数据内容是否一致
        /// <summary>
        /// 校验码单数据一致性
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        public bool RCheckCorrectPackData(int p_ID, out string o_ErrorMsg)
        {
            o_ErrorMsg = string.Empty;

            bool outb = true;
            string sql = string.Empty;
            sql = "SELECT * FROM WH_DBFormDts WHERE MainID=" + p_ID;
            DataTable dtDts = SysUtils.Fill(sql);

            sql = "SELECT * FROM WH_DBFormDtsPack WHERE MainID=" + p_ID;
            DataTable dtDtsPack = SysUtils.Fill(sql);

            int rowID = 0;
            foreach (DataRow drDts in dtDts.Rows)//逐行校验
            {
                rowID++;
                //校验码单和数据明细的属性是否一致
                sql = "SELECT ID FROM WH_PackBox WHERE BoxNo IN(SELECT BoxNo FROM WH_DBFormDtsPack WHERE DID=" + drDts["ID"].ToString() + ")";
                sql += " AND (ItemCode<>" + SysString.ToDBString(drDts["ItemCode"].ToString()) + " OR ColorNum<>" + SysString.ToDBString(drDts["ColorNum"].ToString()) + "  OR ColorName<>" + SysString.ToDBString(drDts["ColorName"].ToString());
                sql += " OR Batch<>" + SysString.ToDBString(drDts["Batch"].ToString()) + " OR JarNum<>" + SysString.ToDBString(drDts["JarNum"].ToString());
                sql += ")";
                DataTable dtBoxNo = SysUtils.Fill(sql);
                if (dtBoxNo.Rows.Count != 0)//有异常数据
                {
                    o_ErrorMsg = "行" + rowID + "数据异常,数据明细和码单属性不一致" + Environment.NewLine + "请重新保存码单明细";
                    outb = false;
                    break;
                }

                //校验数量是否一致
                if (outb)//如果验证通过继续校验
                {
                    int mdCount = SysConvert.ToInt32(dtDtsPack.Compute("COUNT(ID)", " DID=" + drDts["ID"].ToString()));
                    decimal mdQty = SysConvert.ToDecimal(dtDtsPack.Compute("SUM(Qty)", " DID=" + drDts["ID"].ToString()));
                    if (SysConvert.ToInt32(drDts["PieceQty"]) != mdCount)
                    {
                        o_ErrorMsg = "行" + rowID + "数据异常,数据明细和码单件数不一致" + Environment.NewLine + "请重新保存码单明细";
                        outb = false;
                        break;
                    }

                    if (SysConvert.ToInt32(drDts["PieceQty"]) != mdCount)
                    {
                        o_ErrorMsg = "行" + rowID + "数据异常,数据明细和码单数量不一致" + Environment.NewLine + "请重新保存码单明细";
                        outb = false;
                        break;
                    }
                    //DataRow[] drDtsPackA = dtDtsPack.Select(" DID="+SysConvert.ToInt32(drDts["ID"]));//比对颜色品种明细是否一致
                }
            }
            return outb;
        }
        #endregion


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
				DBForm entity=(DBForm)p_BE;				
				DBFormCtl control=new DBFormCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.WH_DBForm,sqlTrans);
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
				DBForm entity=(DBForm)p_BE;				
				DBFormCtl control=new DBFormCtl(sqlTrans);				
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
				DBForm entity=(DBForm)p_BE;				
				DBFormCtl control=new DBFormCtl(sqlTrans);
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
        #endregion
    }
}
