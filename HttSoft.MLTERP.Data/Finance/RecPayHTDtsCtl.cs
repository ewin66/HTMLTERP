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
	/// 目的：Finance_RecPayHTDts实体控制类
	/// 作者:章文强
	/// 创建日期:2013/8/2
	/// </summary>
	public sealed class RecPayHTDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public RecPayHTDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public RecPayHTDtsCtl(IDBTransAccess p_SqlCmd)
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
                RecPayHTDts MasterEntity=(RecPayHTDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Finance_RecPayHTDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("HTOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HTOPID)+","); 
  				MasterField.Append("HTOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HTOPName)+","); 
  				MasterField.Append("HTNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HTNo)+","); 
  				MasterField.Append("HTTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HTTypeID)+","); 
  				MasterField.Append("HTDate"+","); 
  				if(MasterEntity.HTDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.HTDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("HTAmount"+","); 
  				if(MasterEntity.HTAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.HTAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("HTItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HTItemCode)+","); 
  				MasterField.Append("HTGoodsCode"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HTGoodsCode)+")"); 
 
                
                

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
                RecPayHTDts MasterEntity=(RecPayHTDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Finance_RecPayHTDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" HTOPID="+SysString.ToDBString(MasterEntity.HTOPID)+","); 
  				UpdateBuilder.Append(" HTOPName="+SysString.ToDBString(MasterEntity.HTOPName)+","); 
  				UpdateBuilder.Append(" HTNo="+SysString.ToDBString(MasterEntity.HTNo)+","); 
  				UpdateBuilder.Append(" HTTypeID="+SysString.ToDBString(MasterEntity.HTTypeID)+","); 
  				 
  				if(MasterEntity.HTDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" HTDate="+SysString.ToDBString(MasterEntity.HTDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" HTDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.HTAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" HTAmount="+SysString.ToDBString(MasterEntity.HTAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" HTAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" HTItemCode="+SysString.ToDBString(MasterEntity.HTItemCode)+","); 
  				UpdateBuilder.Append(" HTGoodsCode="+SysString.ToDBString(MasterEntity.HTGoodsCode)); 
 
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
                RecPayHTDts MasterEntity=(RecPayHTDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Finance_RecPayHTDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
