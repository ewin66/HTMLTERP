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
	/// 目的：Sys_FiledSet实体控制类
	/// 作者:周富春
	/// 创建日期:2014/10/14
	/// </summary>
	public sealed class FiledSetCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public FiledSetCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FiledSetCtl(IDBTransAccess p_SqlCmd)
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
                FiledSet MasterEntity=(FiledSet)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Sys_FiledSet(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FormID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormID)+","); 
  				MasterField.Append("FAID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FAID)+","); 
  				MasterField.Append("FBID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FBID)+","); 
  				MasterField.Append("Sort"+","); 
  				if(MasterEntity.Sort!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Sort)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Code"+","); 
  				if(MasterEntity.Code!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Code)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Name"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Name)+","); 
  				MasterField.Append("FiledName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FiledName)+","); 
  				MasterField.Append("FiledType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FiledType)+","); 
  				MasterField.Append("BindType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BindType)+","); 
  				MasterField.Append("Length"+","); 
  				if(MasterEntity.Length!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Length)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("UseableFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UseableFlag)+","); 
  				MasterField.Append("UpDateFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UpDateFlag)+","); 
  				MasterField.Append("MainTable"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainTable)+")"); 
 
                
                

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
                FiledSet MasterEntity=(FiledSet)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Sys_FiledSet SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FormID="+SysString.ToDBString(MasterEntity.FormID)+","); 
  				UpdateBuilder.Append(" FAID="+SysString.ToDBString(MasterEntity.FAID)+","); 
  				UpdateBuilder.Append(" FBID="+SysString.ToDBString(MasterEntity.FBID)+","); 
  				 
  				if(MasterEntity.Sort!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Sort="+SysString.ToDBString(MasterEntity.Sort)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Sort=null,");  
  				} 
  
  				 
  				if(MasterEntity.Code!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Code="+SysString.ToDBString(MasterEntity.Code)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Code=null,");  
  				} 
  
  				UpdateBuilder.Append(" Name="+SysString.ToDBString(MasterEntity.Name)+","); 
  				UpdateBuilder.Append(" FiledName="+SysString.ToDBString(MasterEntity.FiledName)+","); 
  				UpdateBuilder.Append(" FiledType="+SysString.ToDBString(MasterEntity.FiledType)+","); 
  				UpdateBuilder.Append(" BindType="+SysString.ToDBString(MasterEntity.BindType)+","); 
  				 
  				if(MasterEntity.Length!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Length="+SysString.ToDBString(MasterEntity.Length)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Length=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" UseableFlag="+SysString.ToDBString(MasterEntity.UseableFlag)+","); 
  				UpdateBuilder.Append(" UpDateFlag="+SysString.ToDBString(MasterEntity.UpDateFlag)+","); 
  				UpdateBuilder.Append(" MainTable="+SysString.ToDBString(MasterEntity.MainTable)); 
 
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
                FiledSet MasterEntity=(FiledSet)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Sys_FiledSet WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
