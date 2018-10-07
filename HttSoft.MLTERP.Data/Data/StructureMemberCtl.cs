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
	/// 目的：Data_StructureMember实体控制类
	/// 作者:章文强
	/// 创建日期:2014/6/4
	/// </summary>
	public sealed class StructureMemberCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public StructureMemberCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public StructureMemberCtl(IDBTransAccess p_SqlCmd)
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
                StructureMember MasterEntity=(StructureMember)p_Entity;
                if (MasterEntity.StuctureID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_StructureMember(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("StuctureID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StuctureID)+","); 
  				MasterField.Append("OPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OPID)+","); 
  				MasterField.Append("LeaderFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LeaderFlag)+","); 
  				MasterField.Append("LeaderAttnFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LeaderAttnFlag)+","); 
  				MasterField.Append("DSort"+","); 
  				if(MasterEntity.DSort!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DSort)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
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
                StructureMember MasterEntity=(StructureMember)p_Entity;
                if (MasterEntity.StuctureID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_StructureMember SET ");
                UpdateBuilder.Append(" StuctureID="+SysString.ToDBString(MasterEntity.StuctureID)+","); 
  				UpdateBuilder.Append(" OPID="+SysString.ToDBString(MasterEntity.OPID)+","); 
  				UpdateBuilder.Append(" LeaderFlag="+SysString.ToDBString(MasterEntity.LeaderFlag)+","); 
  				UpdateBuilder.Append(" LeaderAttnFlag="+SysString.ToDBString(MasterEntity.LeaderAttnFlag)+","); 
  				 
  				if(MasterEntity.DSort!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DSort="+SysString.ToDBString(MasterEntity.DSort)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DSort=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)); 
 
                UpdateBuilder.Append(" WHERE "+ "StuctureID="+SysString.ToDBString(MasterEntity.StuctureID)+" AND OPID="+SysString.ToDBString(MasterEntity.OPID));
                
                

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
                StructureMember MasterEntity=(StructureMember)p_Entity;
                if (MasterEntity.StuctureID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_StructureMember WHERE "+ "StuctureID="+SysString.ToDBString(MasterEntity.StuctureID)+" AND OPID="+SysString.ToDBString(MasterEntity.OPID);
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
