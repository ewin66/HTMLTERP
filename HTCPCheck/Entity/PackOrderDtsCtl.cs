using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;

namespace HttSoft.HTCPCheck.DataCtl
{
	/// <summary>
	/// 目的：WO_PackOrderDts实体控制类
	/// 作者:周富春
	/// 创建日期:2014/12/26
	/// </summary>
	public sealed class PackOrderDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public PackOrderDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public PackOrderDtsCtl(IDBTransAccess p_SqlCmd)
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
                PackOrderDts MasterEntity=(PackOrderDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_PackOrderDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+",");
                MasterField.Append("JarNo" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.JarNo) + ","); 

  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorNumEn"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNumEn)+","); 
  				MasterField.Append("ColorNameEn"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNameEn)+","); 
  				MasterField.Append("MLength"+","); 
  				if(MasterEntity.MLength!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MLength)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("YLength"+","); 
  				if(MasterEntity.YLength!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YLength)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("CheckQty"+","); 
  				if(MasterEntity.CheckQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JarNum"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JarNum)+")"); 
 
                
                

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
                PackOrderDts MasterEntity=(PackOrderDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_PackOrderDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+",");
                UpdateBuilder.Append(" JarNo=" + SysString.ToDBString(MasterEntity.JarNo) + ","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorNumEn="+SysString.ToDBString(MasterEntity.ColorNumEn)+","); 
  				UpdateBuilder.Append(" ColorNameEn="+SysString.ToDBString(MasterEntity.ColorNameEn)+","); 
  				 
  				if(MasterEntity.MLength!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MLength="+SysString.ToDBString(MasterEntity.MLength)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MLength=null,");  
  				} 
  
  				 
  				if(MasterEntity.YLength!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YLength="+SysString.ToDBString(MasterEntity.YLength)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YLength=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.CheckQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckQty="+SysString.ToDBString(MasterEntity.CheckQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" JarNum="+SysString.ToDBString(MasterEntity.JarNum)); 
 
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
                PackOrderDts MasterEntity=(PackOrderDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WO_PackOrderDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
