using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.WinUIBase
{
	/// <summary>
	/// 目的：Data_ReportManage实体控制类
	/// 作者:陈加海
	/// 创建日期:2011-11-9
	/// </summary>
	public sealed class ReportManageCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ReportManageCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ReportManageCtl(IDBTransAccess p_SqlCmd)
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
                ReportManage MasterEntity=(ReportManage)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_ReportManage(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("ParentID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ParentID)+","); 
  				MasterField.Append("WinListID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WinListID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("ReportName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ReportName)+","); 
  				MasterField.Append("FileName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FileName)+","); 
  				MasterField.Append("FileID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FileID)+","); 
  				MasterField.Append("ModelType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ModelType)+","); 
  				MasterField.Append("ModelID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ModelID)+","); 
  				MasterField.Append("Url"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Url)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("MDate"+","); 
  				if(MasterEntity.MDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MUser"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MUser)+","); 
  				MasterField.Append("MenuID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MenuID)+","); 
  				MasterField.Append("WinID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WinID)+","); 
  				MasterField.Append("HeadTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HeadTypeID)+","); 
  				MasterField.Append("SubTypeID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubTypeID)+")"); 
 
                
                

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
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)EnumMessage.CommonDBInsert), E);
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
                ReportManage MasterEntity=(ReportManage)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_ReportManage SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" ParentID="+SysString.ToDBString(MasterEntity.ParentID)+","); 
  				UpdateBuilder.Append(" WinListID="+SysString.ToDBString(MasterEntity.WinListID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" ReportName="+SysString.ToDBString(MasterEntity.ReportName)+","); 
  				UpdateBuilder.Append(" FileName="+SysString.ToDBString(MasterEntity.FileName)+","); 
  				UpdateBuilder.Append(" FileID="+SysString.ToDBString(MasterEntity.FileID)+","); 
  				UpdateBuilder.Append(" ModelType="+SysString.ToDBString(MasterEntity.ModelType)+","); 
  				UpdateBuilder.Append(" ModelID="+SysString.ToDBString(MasterEntity.ModelID)+","); 
  				UpdateBuilder.Append(" Url="+SysString.ToDBString(MasterEntity.Url)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.MDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MDate="+SysString.ToDBString(MasterEntity.MDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" MUser="+SysString.ToDBString(MasterEntity.MUser)+","); 
  				UpdateBuilder.Append(" MenuID="+SysString.ToDBString(MasterEntity.MenuID)+","); 
  				UpdateBuilder.Append(" WinID="+SysString.ToDBString(MasterEntity.WinID)+","); 
  				UpdateBuilder.Append(" HeadTypeID="+SysString.ToDBString(MasterEntity.HeadTypeID)+","); 
  				UpdateBuilder.Append(" SubTypeID="+SysString.ToDBString(MasterEntity.SubTypeID)); 
 
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
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)EnumMessage.CommonDBUpdate), E);
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
                ReportManage MasterEntity=(ReportManage)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_ReportManage WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)EnumMessage.CommonDBDelete), E);
            }
        }
	}
}
