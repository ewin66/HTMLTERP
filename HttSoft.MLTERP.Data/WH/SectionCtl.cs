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
	/// 目的：WH_Section实体控制类
	/// 作者:章文强
	/// 创建日期:2014/6/10
	/// </summary>
	public sealed class SectionCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public SectionCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SectionCtl(IDBTransAccess p_SqlCmd)
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
                Section MasterEntity=(Section)p_Entity;
                if (MasterEntity.SectionID=="")
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WH_Section(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("WHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHID)+","); 
  				MasterField.Append("SectionID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SectionID)+","); 
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
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("BulkMax"+","); 
  				if(MasterEntity.BulkMax!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BulkMax)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PosX"+","); 
  				if(MasterEntity.PosX!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PosX)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PosY"+","); 
  				if(MasterEntity.PosY!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PosY)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SizeWidth"+","); 
  				if(MasterEntity.SizeWidth!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SizeWidth)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SizeHeight"+","); 
  				if(MasterEntity.SizeHeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SizeHeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WHPicID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHPicID)+","); 
  				MasterField.Append("WHISN"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHISN)+")"); 
 
                
                

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
                Section MasterEntity=(Section)p_Entity;
                if (MasterEntity.SectionID=="")
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WH_Section SET ");
                UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" WHID="+SysString.ToDBString(MasterEntity.WHID)+","); 
  				UpdateBuilder.Append(" SectionID="+SysString.ToDBString(MasterEntity.SectionID)+","); 
  				 
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
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.BulkMax!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BulkMax="+SysString.ToDBString(MasterEntity.BulkMax)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BulkMax=null,");  
  				} 
  
  				 
  				if(MasterEntity.PosX!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PosX="+SysString.ToDBString(MasterEntity.PosX)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PosX=null,");  
  				} 
  
  				 
  				if(MasterEntity.PosY!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PosY="+SysString.ToDBString(MasterEntity.PosY)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PosY=null,");  
  				} 
  
  				 
  				if(MasterEntity.SizeWidth!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SizeWidth="+SysString.ToDBString(MasterEntity.SizeWidth)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SizeWidth=null,");  
  				} 
  
  				 
  				if(MasterEntity.SizeHeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SizeHeight="+SysString.ToDBString(MasterEntity.SizeHeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SizeHeight=null,");  
  				} 
  
  				UpdateBuilder.Append(" WHPicID="+SysString.ToDBString(MasterEntity.WHPicID)+","); 
  				UpdateBuilder.Append(" WHISN="+SysString.ToDBString(MasterEntity.WHISN)); 
 
                UpdateBuilder.Append(" WHERE "+ "SectionID="+SysString.ToDBString(MasterEntity.SectionID));
                
                

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
                Section MasterEntity=(Section)p_Entity;
                if (MasterEntity.SectionID=="")
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WH_Section WHERE "+ "SectionID="+SysString.ToDBString(MasterEntity.SectionID);
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
