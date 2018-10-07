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
	/// 目的：Data_OPWinListSub实体控制类
	/// 作者:陈加海
	/// 创建日期:2006-12-12
	/// </summary>
	public sealed class OPWinListSubCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public OPWinListSubCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public OPWinListSubCtl(IDBTransAccess p_SqlCmd)
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
                OPWinListSub MasterEntity=(OPWinListSub)p_Entity;
                if (MasterEntity.OPID=="")
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_OPWinListSub(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("OPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OPID)+","); 
  				MasterField.Append("WinListSubID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WinListSubID)+","); 
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
                OPWinListSub MasterEntity=(OPWinListSub)p_Entity;
                if (MasterEntity.OPID=="")
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_OPWinListSub SET ");
                UpdateBuilder.Append(" OPID="+SysString.ToDBString(MasterEntity.OPID)+","); 
  				UpdateBuilder.Append(" WinListSubID="+SysString.ToDBString(MasterEntity.WinListSubID)+","); 
  				UpdateBuilder.Append(" HeadTypeID="+SysString.ToDBString(MasterEntity.HeadTypeID)+","); 
  				UpdateBuilder.Append(" SubTypeID="+SysString.ToDBString(MasterEntity.SubTypeID)); 
 
                UpdateBuilder.Append(" WHERE "+ "OPID="+SysString.ToDBString(MasterEntity.OPID)+" AND WinListSubID="+SysString.ToDBString(MasterEntity.WinListSubID)+" AND HeadTypeID="+SysString.ToDBString(MasterEntity.HeadTypeID)+" AND SubTypeID="+SysString.ToDBString(MasterEntity.SubTypeID));
                
                

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
                OPWinListSub MasterEntity=(OPWinListSub)p_Entity;
                if (MasterEntity.OPID=="")
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_OPWinListSub WHERE "+ "OPID="+SysString.ToDBString(MasterEntity.OPID)+" AND WinListSubID="+SysString.ToDBString(MasterEntity.WinListSubID)+" AND HeadTypeID="+SysString.ToDBString(MasterEntity.HeadTypeID)+" AND SubTypeID="+SysString.ToDBString(MasterEntity.SubTypeID);
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
