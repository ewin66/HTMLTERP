using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;

namespace HttSoft.MLTERP.DataCtl
{
	/// <summary>
	/// 目的：Enum_FormNoControl实体控制类
	/// 作者:陈加海
	/// 创建日期:2012-4-17
	/// </summary>
	public sealed class FormNoControlCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public FormNoControlCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FormNoControlCtl(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		
		/// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int AddNew(BaseEntity p_Entity)
        {
            try
            {
                FormNoControl MasterEntity=(FormNoControl)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Enum_FormNoControl(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("Code"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Code)+","); 
  				MasterField.Append("NoType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.NoType)+","); 
  				MasterField.Append("FormNM"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNM)+","); 
  				MasterField.Append("FormRuleSpecial"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormRuleSpecial)+","); 
  				MasterField.Append("FormRulePre"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormRulePre)+","); 
  				MasterField.Append("FormRuleSort"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormRuleSort)+","); 
  				MasterField.Append("CurSort"+","); 
  				if(MasterEntity.CurSort!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CurSort)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CurYear"+","); 
  				if(MasterEntity.CurYear!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CurYear)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CurMonth"+","); 
  				if(MasterEntity.CurMonth!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CurMonth)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CurDay"+","); 
  				if(MasterEntity.CurDay!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CurDay)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DTableName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DTableName)+","); 
  				MasterField.Append("DFieldName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DFieldName)+","); 
  				MasterField.Append("Condition"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Condition)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("SortAddType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SortAddType)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("SourceFlag"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SourceFlag)+")"); 
 
                
                

                //执行
                int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString());
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString());
				}
                return AffectedRows;
            }
            catch(BaseException E)
            {
                throw new BaseException(E.Message,E);
            }
            catch(Exception E)
            {
               throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBInsert),E);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int Update(BaseEntity p_Entity)
        {
            try
            {
                FormNoControl MasterEntity=(FormNoControl)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Enum_FormNoControl SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" Code="+SysString.ToDBString(MasterEntity.Code)+","); 
  				UpdateBuilder.Append(" NoType="+SysString.ToDBString(MasterEntity.NoType)+","); 
  				UpdateBuilder.Append(" FormNM="+SysString.ToDBString(MasterEntity.FormNM)+","); 
  				UpdateBuilder.Append(" FormRuleSpecial="+SysString.ToDBString(MasterEntity.FormRuleSpecial)+","); 
  				UpdateBuilder.Append(" FormRulePre="+SysString.ToDBString(MasterEntity.FormRulePre)+","); 
  				UpdateBuilder.Append(" FormRuleSort="+SysString.ToDBString(MasterEntity.FormRuleSort)+","); 
  				 
  				if(MasterEntity.CurSort!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CurSort="+SysString.ToDBString(MasterEntity.CurSort)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CurSort=null,");  
  				} 
  
  				 
  				if(MasterEntity.CurYear!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CurYear="+SysString.ToDBString(MasterEntity.CurYear)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CurYear=null,");  
  				} 
  
  				 
  				if(MasterEntity.CurMonth!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CurMonth="+SysString.ToDBString(MasterEntity.CurMonth)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CurMonth=null,");  
  				} 
  
  				 
  				if(MasterEntity.CurDay!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CurDay="+SysString.ToDBString(MasterEntity.CurDay)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CurDay=null,");  
  				} 
  
  				UpdateBuilder.Append(" DTableName="+SysString.ToDBString(MasterEntity.DTableName)+","); 
  				UpdateBuilder.Append(" DFieldName="+SysString.ToDBString(MasterEntity.DFieldName)+","); 
  				UpdateBuilder.Append(" Condition="+SysString.ToDBString(MasterEntity.Condition)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" SortAddType="+SysString.ToDBString(MasterEntity.SortAddType)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" SourceFlag="+SysString.ToDBString(MasterEntity.SourceFlag)); 
 
                UpdateBuilder.Append(" WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID));
                
                

               //执行
				int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(UpdateBuilder.ToString());
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(UpdateBuilder.ToString());
				}
                return AffectedRows;
            }
            catch(BaseException E)
            {
                throw new BaseException(E.Message,E);
            }
            catch(Exception E)
            {
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBUpdate),E);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int Delete(BaseEntity p_Entity)
        {
            try
            {
                FormNoControl MasterEntity=(FormNoControl)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Enum_FormNoControl WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
                //执行
				int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(Sql);
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(Sql);
				}

                return AffectedRows;
            }
            catch(BaseException E)
            {
                throw new BaseException(E.Message,E);
            }
            catch(Exception E)
            {
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBDelete),E);
            }
        }
	}
}
