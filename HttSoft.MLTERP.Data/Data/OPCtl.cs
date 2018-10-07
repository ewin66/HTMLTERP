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
	/// 目的：Data_OP实体控制类
	/// 作者:zhp
	/// 创建日期:2016/9/2
	/// </summary>
	public sealed class OPCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public OPCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public OPCtl(IDBTransAccess p_SqlCmd)
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
                OP MasterEntity=(OP)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_OP(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("OPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OPID)+","); 
  				MasterField.Append("OPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OPName)+","); 
  				MasterField.Append("SDuty"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SDuty)+","); 
  				MasterField.Append("SDep"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SDep)+","); 
  				MasterField.Append("SWork"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SWork)+","); 
  				MasterField.Append("Sex"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Sex)+","); 
  				MasterField.Append("Birthday"+","); 
  				if(MasterEntity.Birthday!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Birthday.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Diploma"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Diploma)+","); 
  				MasterField.Append("InDate"+","); 
  				if(MasterEntity.InDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CardID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CardID)+","); 
  				MasterField.Append("Origin"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Origin)+","); 
  				MasterField.Append("Nation"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Nation)+","); 
  				MasterField.Append("Political"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Political)+","); 
  				MasterField.Append("MarriageState"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MarriageState)+","); 
  				MasterField.Append("Phone"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Phone)+","); 
  				MasterField.Append("Address"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Address)+","); 
  				MasterField.Append("Email"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Email)+","); 
  				MasterField.Append("DefaultFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DefaultFlag)+","); 
  				MasterField.Append("UseableFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UseableFlag)+","); 
  				MasterField.Append("WebFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WebFlag)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("DRoleID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DRoleID)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("Password"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Password)+","); 
  				MasterField.Append("Mobile"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Mobile)+","); 
  				MasterField.Append("OPCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OPCode)+","); 
  				MasterField.Append("DepID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DepID)+")"); 
 
                
                

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
                OP MasterEntity=(OP)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_OP SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" OPID="+SysString.ToDBString(MasterEntity.OPID)+","); 
  				UpdateBuilder.Append(" OPName="+SysString.ToDBString(MasterEntity.OPName)+","); 
  				UpdateBuilder.Append(" SDuty="+SysString.ToDBString(MasterEntity.SDuty)+","); 
  				UpdateBuilder.Append(" SDep="+SysString.ToDBString(MasterEntity.SDep)+","); 
  				UpdateBuilder.Append(" SWork="+SysString.ToDBString(MasterEntity.SWork)+","); 
  				UpdateBuilder.Append(" Sex="+SysString.ToDBString(MasterEntity.Sex)+","); 
  				 
  				if(MasterEntity.Birthday!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" Birthday="+SysString.ToDBString(MasterEntity.Birthday.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Birthday=null,");  
  				} 
  
  				UpdateBuilder.Append(" Diploma="+SysString.ToDBString(MasterEntity.Diploma)+","); 
  				 
  				if(MasterEntity.InDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" InDate="+SysString.ToDBString(MasterEntity.InDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" CardID="+SysString.ToDBString(MasterEntity.CardID)+","); 
  				UpdateBuilder.Append(" Origin="+SysString.ToDBString(MasterEntity.Origin)+","); 
  				UpdateBuilder.Append(" Nation="+SysString.ToDBString(MasterEntity.Nation)+","); 
  				UpdateBuilder.Append(" Political="+SysString.ToDBString(MasterEntity.Political)+","); 
  				UpdateBuilder.Append(" MarriageState="+SysString.ToDBString(MasterEntity.MarriageState)+","); 
  				UpdateBuilder.Append(" Phone="+SysString.ToDBString(MasterEntity.Phone)+","); 
  				UpdateBuilder.Append(" Address="+SysString.ToDBString(MasterEntity.Address)+","); 
  				UpdateBuilder.Append(" Email="+SysString.ToDBString(MasterEntity.Email)+","); 
  				UpdateBuilder.Append(" DefaultFlag="+SysString.ToDBString(MasterEntity.DefaultFlag)+","); 
  				UpdateBuilder.Append(" UseableFlag="+SysString.ToDBString(MasterEntity.UseableFlag)+","); 
  				UpdateBuilder.Append(" WebFlag="+SysString.ToDBString(MasterEntity.WebFlag)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" DRoleID="+SysString.ToDBString(MasterEntity.DRoleID)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" Password="+SysString.ToDBString(MasterEntity.Password)+","); 
  				UpdateBuilder.Append(" Mobile="+SysString.ToDBString(MasterEntity.Mobile)+","); 
  				UpdateBuilder.Append(" OPCode="+SysString.ToDBString(MasterEntity.OPCode)+","); 
  				UpdateBuilder.Append(" DepID="+SysString.ToDBString(MasterEntity.DepID)); 
 
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
                OP MasterEntity=(OP)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_OP WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
