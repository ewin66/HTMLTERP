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
	/// 目的：Enum_FormListDB实体控制类
	/// 作者:陈加海
	/// 创建日期:2014/7/21
	/// </summary>
	public sealed class FormListDBCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public FormListDBCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FormListDBCtl(IDBTransAccess p_SqlCmd)
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
                FormListDB MasterEntity=(FormListDB)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Enum_FormListDB(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("Code"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Code)+","); 
  				MasterField.Append("FormNM"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNM)+","); 
  				MasterField.Append("WHTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHTypeID)+","); 
  				MasterField.Append("DefaultWHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DefaultWHID)+","); 
  				MasterField.Append("FormNoControlID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNoControlID)+","); 
  				MasterField.Append("WHDBFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHDBFlag)+","); 
  				MasterField.Append("SODBFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SODBFlag)+","); 
  				MasterField.Append("OutFormListID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OutFormListID)+","); 
  				MasterField.Append("InFormListID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InFormListID)+","); 
  				MasterField.Append("XMFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.XMFlag)+","); 
  				MasterField.Append("Remark"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+")"); 
 
                
                

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
                FormListDB MasterEntity=(FormListDB)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Enum_FormListDB SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" Code="+SysString.ToDBString(MasterEntity.Code)+","); 
  				UpdateBuilder.Append(" FormNM="+SysString.ToDBString(MasterEntity.FormNM)+","); 
  				UpdateBuilder.Append(" WHTypeID="+SysString.ToDBString(MasterEntity.WHTypeID)+","); 
  				UpdateBuilder.Append(" DefaultWHID="+SysString.ToDBString(MasterEntity.DefaultWHID)+","); 
  				UpdateBuilder.Append(" FormNoControlID="+SysString.ToDBString(MasterEntity.FormNoControlID)+","); 
  				UpdateBuilder.Append(" WHDBFlag="+SysString.ToDBString(MasterEntity.WHDBFlag)+","); 
  				UpdateBuilder.Append(" SODBFlag="+SysString.ToDBString(MasterEntity.SODBFlag)+","); 
  				UpdateBuilder.Append(" OutFormListID="+SysString.ToDBString(MasterEntity.OutFormListID)+","); 
  				UpdateBuilder.Append(" InFormListID="+SysString.ToDBString(MasterEntity.InFormListID)+","); 
  				UpdateBuilder.Append(" XMFlag="+SysString.ToDBString(MasterEntity.XMFlag)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)); 
 
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
                FormListDB MasterEntity=(FormListDB)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Enum_FormListDB WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
