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
	/// 目的：WO_FabricProcessItemDts实体控制类
	/// 作者:陈加海
	/// 创建日期:2014/7/15
	/// </summary>
	public sealed class FabricProcessItemDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public FabricProcessItemDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FabricProcessItemDtsCtl(IDBTransAccess p_SqlCmd)
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
                FabricProcessItemDts MasterEntity=(FabricProcessItemDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_FabricProcessItemDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("DtsID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("DtsItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsItemCode)+","); 
  				MasterField.Append("DtsItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsItemName)+","); 
  				MasterField.Append("DtsItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsItemStd)+","); 
  				MasterField.Append("DtsItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsItemModel)+","); 
  				MasterField.Append("Percentage"+","); 
  				if(MasterEntity.Percentage!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Percentage)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Loss"+","); 
  				if(MasterEntity.Loss!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Loss)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("UseQty"+","); 
  				if(MasterEntity.UseQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.UseQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DtsRemark"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsRemark)+")"); 
 
                
                

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
                FabricProcessItemDts MasterEntity=(FabricProcessItemDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_FabricProcessItemDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" DtsID="+SysString.ToDBString(MasterEntity.DtsID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" DtsItemCode="+SysString.ToDBString(MasterEntity.DtsItemCode)+","); 
  				UpdateBuilder.Append(" DtsItemName="+SysString.ToDBString(MasterEntity.DtsItemName)+","); 
  				UpdateBuilder.Append(" DtsItemStd="+SysString.ToDBString(MasterEntity.DtsItemStd)+","); 
  				UpdateBuilder.Append(" DtsItemModel="+SysString.ToDBString(MasterEntity.DtsItemModel)+","); 
  				 
  				if(MasterEntity.Percentage!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Percentage="+SysString.ToDBString(MasterEntity.Percentage)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Percentage=null,");  
  				} 
  
  				 
  				if(MasterEntity.Loss!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Loss="+SysString.ToDBString(MasterEntity.Loss)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Loss=null,");  
  				} 
  
  				 
  				if(MasterEntity.UseQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" UseQty="+SysString.ToDBString(MasterEntity.UseQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" UseQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" DtsRemark="+SysString.ToDBString(MasterEntity.DtsRemark)); 
 
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
                FabricProcessItemDts MasterEntity=(FabricProcessItemDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WO_FabricProcessItemDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
