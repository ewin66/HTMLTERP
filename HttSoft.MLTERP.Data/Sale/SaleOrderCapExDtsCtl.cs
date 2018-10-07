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
	/// 目的：Sale_SaleOrderCapExDts实体控制类
	/// 作者:章文强
	/// 创建日期:2012/7/30
	/// </summary>
	public sealed class SaleOrderCapExDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public SaleOrderCapExDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SaleOrderCapExDtsCtl(IDBTransAccess p_SqlCmd)
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
                SaleOrderCapExDts MasterEntity=(SaleOrderCapExDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Sale_SaleOrderCapExDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("ExCapName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ExCapName)+","); 
  				MasterField.Append("ExItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ExItemCode)+","); 
  				MasterField.Append("ExPayStepTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ExPayStepTypeID)+","); 
  				MasterField.Append("ExPayPer"+","); 
  				if(MasterEntity.ExPayPer!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ExPayPer)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ExPayAmount"+","); 
  				if(MasterEntity.ExPayAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ExPayAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ExPayLimitDate"+","); 
  				if(MasterEntity.ExPayLimitDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ExPayLimitDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ExRemark"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ExRemark)+")"); 
 
                
                

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
                SaleOrderCapExDts MasterEntity=(SaleOrderCapExDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Sale_SaleOrderCapExDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" ExCapName="+SysString.ToDBString(MasterEntity.ExCapName)+","); 
  				UpdateBuilder.Append(" ExItemCode="+SysString.ToDBString(MasterEntity.ExItemCode)+","); 
  				UpdateBuilder.Append(" ExPayStepTypeID="+SysString.ToDBString(MasterEntity.ExPayStepTypeID)+","); 
  				 
  				if(MasterEntity.ExPayPer!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ExPayPer="+SysString.ToDBString(MasterEntity.ExPayPer)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ExPayPer=null,");  
  				} 
  
  				 
  				if(MasterEntity.ExPayAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ExPayAmount="+SysString.ToDBString(MasterEntity.ExPayAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ExPayAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.ExPayLimitDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ExPayLimitDate="+SysString.ToDBString(MasterEntity.ExPayLimitDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ExPayLimitDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" ExRemark="+SysString.ToDBString(MasterEntity.ExRemark)); 
 
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
                SaleOrderCapExDts MasterEntity=(SaleOrderCapExDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Sale_SaleOrderCapExDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
