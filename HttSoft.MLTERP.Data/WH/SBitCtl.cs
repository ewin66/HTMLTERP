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
	/// 目的：WH_SBit实体控制类
	/// 作者:xushoucheng
	/// 创建日期:2015/11/20
	/// </summary>
	public sealed class SBitCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public SBitCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SBitCtl(IDBTransAccess p_SqlCmd)
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
                SBit MasterEntity=(SBit)p_Entity;
                if (MasterEntity.SBitID=="")
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WH_SBit(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("SubSeq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubSeq)+","); 
  				MasterField.Append("WHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHID)+","); 
  				MasterField.Append("SectionID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SectionID)+","); 
  				MasterField.Append("SBitID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SBitID)+","); 
  				MasterField.Append("IsUseable"+","); 
  				if(MasterEntity.IsUseable!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.IsUseable)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WeightMax"+","); 
  				if(MasterEntity.WeightMax!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.WeightMax)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BulkMax"+","); 
  				if(MasterEntity.BulkMax!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BulkMax)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("SBitISN"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SBitISN)+")"); 
 
                
                

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
                SBit MasterEntity=(SBit)p_Entity;
                if (MasterEntity.SBitID=="")
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WH_SBit SET ");
                UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" SubSeq="+SysString.ToDBString(MasterEntity.SubSeq)+","); 
  				UpdateBuilder.Append(" WHID="+SysString.ToDBString(MasterEntity.WHID)+","); 
  				UpdateBuilder.Append(" SectionID="+SysString.ToDBString(MasterEntity.SectionID)+","); 
  				UpdateBuilder.Append(" SBitID="+SysString.ToDBString(MasterEntity.SBitID)+","); 
  				 
  				if(MasterEntity.IsUseable!=0) 
  				{ 
  			 		UpdateBuilder.Append(" IsUseable="+SysString.ToDBString(MasterEntity.IsUseable)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" IsUseable=null,");  
  				} 
  
  				 
  				if(MasterEntity.WeightMax!=0) 
  				{ 
  			 		UpdateBuilder.Append(" WeightMax="+SysString.ToDBString(MasterEntity.WeightMax)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" WeightMax=null,");  
  				} 
  
  				 
  				if(MasterEntity.BulkMax!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BulkMax="+SysString.ToDBString(MasterEntity.BulkMax)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BulkMax=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" SBitISN="+SysString.ToDBString(MasterEntity.SBitISN)); 
 
                UpdateBuilder.Append(" WHERE "+ "SBitID="+SysString.ToDBString(MasterEntity.SBitID));
                
                

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
                SBit MasterEntity=(SBit)p_Entity;
                if (MasterEntity.SBitID=="")
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WH_SBit WHERE "+ "SBitID="+SysString.ToDBString(MasterEntity.SBitID);
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
