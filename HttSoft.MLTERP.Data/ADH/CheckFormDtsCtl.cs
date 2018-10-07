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
	/// 目的：ADH_CheckFormDts实体控制类
	/// 作者:章文强
	/// 创建日期:2012/10/26
	/// </summary>
	public sealed class CheckFormDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public CheckFormDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CheckFormDtsCtl(IDBTransAccess p_SqlCmd)
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
                CheckFormDts MasterEntity=(CheckFormDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO ADH_CheckFormDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("ISN"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ISN)+","); 
  				MasterField.Append("DataGradeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DataGradeID)+","); 
  				MasterField.Append("SOQtyDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SOQtyDesc)+","); 
  				MasterField.Append("SODateDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SODateDesc)+","); 
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
  
  				MasterField.Append("YPQty"+","); 
  				if(MasterEntity.YPQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YPQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("YSQty"+","); 
  				if(MasterEntity.YSQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YSQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FreeStr1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr1)+","); 
  				MasterField.Append("FreeStr2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr2)+","); 
  				MasterField.Append("FreeStr3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr3)+","); 
  				MasterField.Append("FreeStr4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr4)+","); 
  				MasterField.Append("FreeStr5"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr5)+","); 
  				MasterField.Append("FreeDec1"+","); 
  				if(MasterEntity.FreeDec1!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FreeDec1)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FreeDec2"+","); 
  				if(MasterEntity.FreeDec2!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FreeDec2)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FreeDec3"+","); 
  				if(MasterEntity.FreeDec3!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FreeDec3)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FreeDec4"+","); 
  				if(MasterEntity.FreeDec4!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FreeDec4)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FreeDec5"+","); 
  				if(MasterEntity.FreeDec5!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FreeDec5)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JYFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JYFlag)+","); 
  				MasterField.Append("DYFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DYFlag)+","); 
  				MasterField.Append("Qty"+")"); 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Qty)+")"); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null)"); 
  				} 
  
 
                
                

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
                CheckFormDts MasterEntity=(CheckFormDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE ADH_CheckFormDts SET ");
                UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" ISN="+SysString.ToDBString(MasterEntity.ISN)+","); 
  				UpdateBuilder.Append(" DataGradeID="+SysString.ToDBString(MasterEntity.DataGradeID)+","); 
  				UpdateBuilder.Append(" SOQtyDesc="+SysString.ToDBString(MasterEntity.SOQtyDesc)+","); 
  				UpdateBuilder.Append(" SODateDesc="+SysString.ToDBString(MasterEntity.SODateDesc)+","); 
  				 
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
  
  				 
  				if(MasterEntity.YPQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YPQty="+SysString.ToDBString(MasterEntity.YPQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YPQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.YSQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YSQty="+SysString.ToDBString(MasterEntity.YSQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YSQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" FreeStr1="+SysString.ToDBString(MasterEntity.FreeStr1)+","); 
  				UpdateBuilder.Append(" FreeStr2="+SysString.ToDBString(MasterEntity.FreeStr2)+","); 
  				UpdateBuilder.Append(" FreeStr3="+SysString.ToDBString(MasterEntity.FreeStr3)+","); 
  				UpdateBuilder.Append(" FreeStr4="+SysString.ToDBString(MasterEntity.FreeStr4)+","); 
  				UpdateBuilder.Append(" FreeStr5="+SysString.ToDBString(MasterEntity.FreeStr5)+","); 
  				 
  				if(MasterEntity.FreeDec1!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FreeDec1="+SysString.ToDBString(MasterEntity.FreeDec1)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FreeDec1=null,");  
  				} 
  
  				 
  				if(MasterEntity.FreeDec2!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FreeDec2="+SysString.ToDBString(MasterEntity.FreeDec2)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FreeDec2=null,");  
  				} 
  
  				 
  				if(MasterEntity.FreeDec3!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FreeDec3="+SysString.ToDBString(MasterEntity.FreeDec3)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FreeDec3=null,");  
  				} 
  
  				 
  				if(MasterEntity.FreeDec4!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FreeDec4="+SysString.ToDBString(MasterEntity.FreeDec4)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FreeDec4=null,");  
  				} 
  
  				 
  				if(MasterEntity.FreeDec5!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FreeDec5="+SysString.ToDBString(MasterEntity.FreeDec5)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FreeDec5=null,");  
  				} 
  
  				UpdateBuilder.Append(" JYFlag="+SysString.ToDBString(MasterEntity.JYFlag)+","); 
  				UpdateBuilder.Append(" DYFlag="+SysString.ToDBString(MasterEntity.DYFlag)+","); 
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null");  
  				} 
  
 
                UpdateBuilder.Append(" WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq));
                
                

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
                CheckFormDts MasterEntity=(CheckFormDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM ADH_CheckFormDts WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq);
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
