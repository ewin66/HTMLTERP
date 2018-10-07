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
	/// 目的：Finance_RecPay实体控制类
	/// 作者:XUSC
	/// 创建日期:2016/1/20
	/// </summary>
	public sealed class RecPayCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public RecPayCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public RecPayCtl(IDBTransAccess p_SqlCmd)
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
                RecPay MasterEntity=(RecPay)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Finance_RecPay(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
  				MasterField.Append("MakeOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				MasterField.Append("MakeOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPName)+","); 
  				MasterField.Append("MakeDate"+","); 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
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
  
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("ExAmount"+","); 
  				if(MasterEntity.ExAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ExAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MoneyType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MoneyType)+","); 
  				MasterField.Append("ExMethod"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ExMethod)+","); 
  				MasterField.Append("Rate"+","); 
  				if(MasterEntity.Rate!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Rate)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ExOP"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ExOP)+","); 
  				MasterField.Append("ExDate"+","); 
  				if(MasterEntity.ExDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ExDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ExBank"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ExBank)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("HXAmount"+","); 
  				if(MasterEntity.HXAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.HXAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("HXFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HXFlag)+","); 
  				MasterField.Append("RecPayTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecPayTypeID)+","); 
  				MasterField.Append("HTAmount"+","); 
  				if(MasterEntity.HTAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.HTAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("HTFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HTFlag)+","); 
  				MasterField.Append("HTNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HTNo)+","); 
  				MasterField.Append("PayStepTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PayStepTypeID)+","); 
  				MasterField.Append("HTGoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HTGoodsCode)+","); 
  				MasterField.Append("NoHXAmount"+","); 
  				if(MasterEntity.NoHXAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NoHXAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CompanyTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				MasterField.Append("PreAmount"+","); 
  				if(MasterEntity.PreAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PreAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("YJAmount"+","); 
  				if(MasterEntity.YJAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YJAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SaleAmount"+","); 
  				if(MasterEntity.SaleAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SaleAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OtherAmount"+","); 
  				if(MasterEntity.OtherAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OtherAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("LeftAmount"+","); 
  				if(MasterEntity.LeftAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LeftAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SJAmount"+","); 
  				if(MasterEntity.SJAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SJAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("NoAmountFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.NoAmountFlag)+","); 
  				MasterField.Append("ReadFlag"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ReadFlag)+")"); 
 
                
                

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
                RecPay MasterEntity=(RecPay)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Finance_RecPay SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				UpdateBuilder.Append(" MakeOPName="+SysString.ToDBString(MasterEntity.MakeOPName)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" CheckOPID="+SysString.ToDBString(MasterEntity.CheckOPID)+","); 
  				 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate="+SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				 
  				if(MasterEntity.ExAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ExAmount="+SysString.ToDBString(MasterEntity.ExAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ExAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" MoneyType="+SysString.ToDBString(MasterEntity.MoneyType)+","); 
  				UpdateBuilder.Append(" ExMethod="+SysString.ToDBString(MasterEntity.ExMethod)+","); 
  				 
  				if(MasterEntity.Rate!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Rate="+SysString.ToDBString(MasterEntity.Rate)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Rate=null,");  
  				} 
  
  				UpdateBuilder.Append(" ExOP="+SysString.ToDBString(MasterEntity.ExOP)+","); 
  				 
  				if(MasterEntity.ExDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ExDate="+SysString.ToDBString(MasterEntity.ExDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ExDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" ExBank="+SysString.ToDBString(MasterEntity.ExBank)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.HXAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" HXAmount="+SysString.ToDBString(MasterEntity.HXAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" HXAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" HXFlag="+SysString.ToDBString(MasterEntity.HXFlag)+","); 
  				UpdateBuilder.Append(" RecPayTypeID="+SysString.ToDBString(MasterEntity.RecPayTypeID)+","); 
  				 
  				if(MasterEntity.HTAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" HTAmount="+SysString.ToDBString(MasterEntity.HTAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" HTAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" HTFlag="+SysString.ToDBString(MasterEntity.HTFlag)+","); 
  				UpdateBuilder.Append(" HTNo="+SysString.ToDBString(MasterEntity.HTNo)+","); 
  				UpdateBuilder.Append(" PayStepTypeID="+SysString.ToDBString(MasterEntity.PayStepTypeID)+","); 
  				UpdateBuilder.Append(" HTGoodsCode="+SysString.ToDBString(MasterEntity.HTGoodsCode)+","); 
  				 
  				if(MasterEntity.NoHXAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" NoHXAmount="+SysString.ToDBString(MasterEntity.NoHXAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NoHXAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" CompanyTypeID="+SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				 
  				if(MasterEntity.PreAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PreAmount="+SysString.ToDBString(MasterEntity.PreAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PreAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.YJAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YJAmount="+SysString.ToDBString(MasterEntity.YJAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YJAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.SaleAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SaleAmount="+SysString.ToDBString(MasterEntity.SaleAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SaleAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.OtherAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" OtherAmount="+SysString.ToDBString(MasterEntity.OtherAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OtherAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.LeftAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" LeftAmount="+SysString.ToDBString(MasterEntity.LeftAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LeftAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.SJAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SJAmount="+SysString.ToDBString(MasterEntity.SJAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SJAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" NoAmountFlag="+SysString.ToDBString(MasterEntity.NoAmountFlag)+","); 
  				UpdateBuilder.Append(" ReadFlag="+SysString.ToDBString(MasterEntity.ReadFlag)); 
 
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
                RecPay MasterEntity=(RecPay)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Finance_RecPay WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
