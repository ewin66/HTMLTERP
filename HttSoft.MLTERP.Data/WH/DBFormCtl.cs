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
	/// 目的：WH_DBForm实体控制类
	/// 作者:陈加海
	/// 创建日期:2014/7/22
	/// </summary>
	public sealed class DBFormCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public DBFormCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public DBFormCtl(IDBTransAccess p_SqlCmd)
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
                DBForm MasterEntity=(DBForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WH_DBForm(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FormListDBID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormListDBID)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
  				MasterField.Append("FormDate"+","); 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHID)+","); 
  				MasterField.Append("TargetWHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TargetWHID)+","); 
  				MasterField.Append("TargetDtsSO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TargetDtsSO)+","); 
  				MasterField.Append("OutWHFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OutWHFormNo)+","); 
  				MasterField.Append("OutWHFormID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OutWHFormID)+","); 
  				MasterField.Append("InWHFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InWHFormNo)+","); 
  				MasterField.Append("InWHFormID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InWHFormID)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("SubmitOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitOPID)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("MakeOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				MasterField.Append("MakeDate"+","); 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("CheckOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckOPID)+","); 
  				MasterField.Append("CheckDate"+","); 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalQty"+","); 
  				if(MasterEntity.TotalQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalPieceQty"+","); 
  				if(MasterEntity.TotalPieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalPieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("VendorID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+")"); 
 
                
                

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
                DBForm MasterEntity=(DBForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WH_DBForm SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FormListDBID="+SysString.ToDBString(MasterEntity.FormListDBID)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
  				 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FormDate="+SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" WHID="+SysString.ToDBString(MasterEntity.WHID)+","); 
  				UpdateBuilder.Append(" TargetWHID="+SysString.ToDBString(MasterEntity.TargetWHID)+","); 
  				UpdateBuilder.Append(" TargetDtsSO="+SysString.ToDBString(MasterEntity.TargetDtsSO)+","); 
  				UpdateBuilder.Append(" OutWHFormNo="+SysString.ToDBString(MasterEntity.OutWHFormNo)+","); 
  				UpdateBuilder.Append(" OutWHFormID="+SysString.ToDBString(MasterEntity.OutWHFormID)+","); 
  				UpdateBuilder.Append(" InWHFormNo="+SysString.ToDBString(MasterEntity.InWHFormNo)+","); 
  				UpdateBuilder.Append(" InWHFormID="+SysString.ToDBString(MasterEntity.InWHFormID)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" SubmitOPID="+SysString.ToDBString(MasterEntity.SubmitOPID)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" CheckOPID="+SysString.ToDBString(MasterEntity.CheckOPID)+","); 
  				 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate="+SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalQty="+SysString.ToDBString(MasterEntity.TotalQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalPieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalPieceQty="+SysString.ToDBString(MasterEntity.TotalPieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalPieceQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)); 
 
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
                DBForm MasterEntity=(DBForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WH_DBForm WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
