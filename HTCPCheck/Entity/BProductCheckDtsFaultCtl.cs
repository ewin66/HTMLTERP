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
	/// 目的：WO_BProductCheckDtsFault实体控制类
	/// 作者:陈加海
	/// 创建日期:2014/5/4
	/// </summary>
	public sealed class BProductCheckDtsFaultCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public BProductCheckDtsFaultCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public BProductCheckDtsFaultCtl(IDBTransAccess p_SqlCmd)
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
                BProductCheckDtsFault MasterEntity=(BProductCheckDtsFault)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_BProductCheckDtsFault(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("FaultType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FaultType)+","); 
  				MasterField.Append("BLength"+","); 
  				if(MasterEntity.BLength!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BLength)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ELength"+","); 
  				if(MasterEntity.ELength!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ELength)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FaultDes"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FaultDes)+","); 
  				MasterField.Append("Deduction"+","); 
  				if(MasterEntity.Deduction!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Deduction)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DQuantity"+","); 
  				if(MasterEntity.DQuantity!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DQuantity)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Position"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Position)+","); 
  				MasterField.Append("MaxIndex"+","); 
  				if(MasterEntity.MaxIndex!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MaxIndex)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DYM"+","); 
  				if(MasterEntity.DYM!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DYM)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CYQty"+")"); 
  				if(MasterEntity.CYQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CYQty)+")"); 
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
                BProductCheckDtsFault MasterEntity=(BProductCheckDtsFault)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_BProductCheckDtsFault SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" FaultType="+SysString.ToDBString(MasterEntity.FaultType)+","); 
  				 
  				if(MasterEntity.BLength!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BLength="+SysString.ToDBString(MasterEntity.BLength)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BLength=null,");  
  				} 
  
  				 
  				if(MasterEntity.ELength!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ELength="+SysString.ToDBString(MasterEntity.ELength)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ELength=null,");  
  				} 
  
  				UpdateBuilder.Append(" FaultDes="+SysString.ToDBString(MasterEntity.FaultDes)+","); 
  				 
  				if(MasterEntity.Deduction!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Deduction="+SysString.ToDBString(MasterEntity.Deduction)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Deduction=null,");  
  				} 
  
  				 
  				if(MasterEntity.DQuantity!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DQuantity="+SysString.ToDBString(MasterEntity.DQuantity)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DQuantity=null,");  
  				} 
  
  				UpdateBuilder.Append(" Position="+SysString.ToDBString(MasterEntity.Position)+","); 
  				 
  				if(MasterEntity.MaxIndex!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MaxIndex="+SysString.ToDBString(MasterEntity.MaxIndex)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MaxIndex=null,");  
  				} 
  
  				 
  				if(MasterEntity.DYM!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DYM="+SysString.ToDBString(MasterEntity.DYM)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DYM=null,");  
  				} 
  
  				 
  				if(MasterEntity.CYQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CYQty="+SysString.ToDBString(MasterEntity.CYQty)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CYQty=null");  
  				} 
  
 
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
                BProductCheckDtsFault MasterEntity=(BProductCheckDtsFault)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WO_BProductCheckDtsFault WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
