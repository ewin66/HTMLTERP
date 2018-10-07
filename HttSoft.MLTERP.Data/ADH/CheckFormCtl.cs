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
	/// 目的：ADH_CheckForm实体控制类
	/// 作者:章文强
	/// 创建日期:2012/10/29
	/// </summary>
	public sealed class CheckFormCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public CheckFormCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CheckFormCtl(IDBTransAccess p_SqlCmd)
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
                CheckForm MasterEntity=(CheckForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO ADH_CheckForm(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FormCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormCode)+","); 
  				MasterField.Append("FormDate"+","); 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DataDHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DataDHID)+","); 
  				MasterField.Append("DVendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DVendorID)+","); 
  				MasterField.Append("DRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DRemark)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("AddTime"+","); 
  				if(MasterEntity.AddTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("UpdTime"+","); 
  				if(MasterEntity.UpdTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.UpdTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("BJHB"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BJHB)+","); 
  				MasterField.Append("BJHL"+","); 
  				if(MasterEntity.BJHL!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BJHL)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Width"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Width)+","); 
  				MasterField.Append("Weight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Weight)+","); 
  				MasterField.Append("FormTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormTypeID)+","); 
  				MasterField.Append("ConOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ConOPName)+","); 
  				MasterField.Append("Tel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Tel)+","); 
  				MasterField.Append("Address"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Address)+","); 
  				MasterField.Append("DVendorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DVendorName)+","); 
  				MasterField.Append("DYFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DYFlag)+","); 
  				MasterField.Append("LevelID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LevelID)+","); 
  				MasterField.Append("SaleOPID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+")"); 
 
                
                

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
                CheckForm MasterEntity=(CheckForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE ADH_CheckForm SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FormCode="+SysString.ToDBString(MasterEntity.FormCode)+","); 
  				 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FormDate="+SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" DataDHID="+SysString.ToDBString(MasterEntity.DataDHID)+","); 
  				UpdateBuilder.Append(" DVendorID="+SysString.ToDBString(MasterEntity.DVendorID)+","); 
  				UpdateBuilder.Append(" DRemark="+SysString.ToDBString(MasterEntity.DRemark)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				 
  				if(MasterEntity.AddTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" AddTime="+SysString.ToDBString(MasterEntity.AddTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddTime=null,");  
  				} 
  
  				 
  				if(MasterEntity.UpdTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" UpdTime="+SysString.ToDBString(MasterEntity.UpdTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" UpdTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" BJHB="+SysString.ToDBString(MasterEntity.BJHB)+","); 
  				 
  				if(MasterEntity.BJHL!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BJHL="+SysString.ToDBString(MasterEntity.BJHL)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BJHL=null,");  
  				} 
  
  				UpdateBuilder.Append(" Width="+SysString.ToDBString(MasterEntity.Width)+","); 
  				UpdateBuilder.Append(" Weight="+SysString.ToDBString(MasterEntity.Weight)+","); 
  				UpdateBuilder.Append(" FormTypeID="+SysString.ToDBString(MasterEntity.FormTypeID)+","); 
  				UpdateBuilder.Append(" ConOPName="+SysString.ToDBString(MasterEntity.ConOPName)+","); 
  				UpdateBuilder.Append(" Tel="+SysString.ToDBString(MasterEntity.Tel)+","); 
  				UpdateBuilder.Append(" Address="+SysString.ToDBString(MasterEntity.Address)+","); 
  				UpdateBuilder.Append(" DVendorName="+SysString.ToDBString(MasterEntity.DVendorName)+","); 
  				UpdateBuilder.Append(" DYFlag="+SysString.ToDBString(MasterEntity.DYFlag)+","); 
  				UpdateBuilder.Append(" LevelID="+SysString.ToDBString(MasterEntity.LevelID)+","); 
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)); 
 
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
                CheckForm MasterEntity=(CheckForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM ADH_CheckForm WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
