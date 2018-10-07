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
	/// 目的：Enum_CompanyType实体控制类
	/// 作者:刘德苏
	/// 创建日期:2012/4/20
	/// </summary>
	public sealed class CompanyTypeCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public CompanyTypeCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CompanyTypeCtl(IDBTransAccess p_SqlCmd)
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
                CompanyType MasterEntity=(CompanyType)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Enum_CompanyType(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("Code"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Code)+","); 
  				MasterField.Append("Name"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Name)+","); 
  				MasterField.Append("OrganizeCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrganizeCode)+","); 
  				MasterField.Append("Tel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Tel)+","); 
  				MasterField.Append("Fax"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Fax)+","); 
  				MasterField.Append("Address"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Address)+","); 
  				MasterField.Append("ZipCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ZipCode)+","); 
  				MasterField.Append("TaxCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TaxCode)+","); 
  				MasterField.Append("Bank"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Bank)+","); 
  				MasterField.Append("Account"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Account)+","); 
  				MasterField.Append("BasedCurrency"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BasedCurrency)+","); 
  				MasterField.Append("DealCurrency"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DealCurrency)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("EnName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.EnName)+","); 
  				MasterField.Append("EnAddress"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.EnAddress)+","); 
  				MasterField.Append("AllName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AllName)+","); 
  				MasterField.Append("Picture"+","); 
  				MasterValue.Append(@"@Picture"+","); 
  				MasterField.Append("AddNo"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AddNo)+")"); 
 
                
                 
  				object[,] obja= new object[2,1]; 
  				obja[0,0]="@Picture"; 
  				obja[1,0]=MasterEntity.Picture;

                //执行
                int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString(),obja);
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString(),obja);
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
                CompanyType MasterEntity=(CompanyType)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Enum_CompanyType SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" Code="+SysString.ToDBString(MasterEntity.Code)+","); 
  				UpdateBuilder.Append(" Name="+SysString.ToDBString(MasterEntity.Name)+","); 
  				UpdateBuilder.Append(" OrganizeCode="+SysString.ToDBString(MasterEntity.OrganizeCode)+","); 
  				UpdateBuilder.Append(" Tel="+SysString.ToDBString(MasterEntity.Tel)+","); 
  				UpdateBuilder.Append(" Fax="+SysString.ToDBString(MasterEntity.Fax)+","); 
  				UpdateBuilder.Append(" Address="+SysString.ToDBString(MasterEntity.Address)+","); 
  				UpdateBuilder.Append(" ZipCode="+SysString.ToDBString(MasterEntity.ZipCode)+","); 
  				UpdateBuilder.Append(" TaxCode="+SysString.ToDBString(MasterEntity.TaxCode)+","); 
  				UpdateBuilder.Append(" Bank="+SysString.ToDBString(MasterEntity.Bank)+","); 
  				UpdateBuilder.Append(" Account="+SysString.ToDBString(MasterEntity.Account)+","); 
  				UpdateBuilder.Append(" BasedCurrency="+SysString.ToDBString(MasterEntity.BasedCurrency)+","); 
  				UpdateBuilder.Append(" DealCurrency="+SysString.ToDBString(MasterEntity.DealCurrency)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" EnName="+SysString.ToDBString(MasterEntity.EnName)+","); 
  				UpdateBuilder.Append(" EnAddress="+SysString.ToDBString(MasterEntity.EnAddress)+","); 
  				UpdateBuilder.Append(" AllName="+SysString.ToDBString(MasterEntity.AllName)+","); 
  				UpdateBuilder.Append(" Picture=@Picture"+","); 
  				UpdateBuilder.Append(" AddNo="+SysString.ToDBString(MasterEntity.AddNo)); 
 
                UpdateBuilder.Append(" WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID));
                
                 
  				object[,] obja= new object[2,1]; 
  				obja[0,0]="@Picture"; 
  				obja[1,0]=MasterEntity.Picture;

               //执行
				int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(UpdateBuilder.ToString(),obja);
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(UpdateBuilder.ToString(),obja);
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
                CompanyType MasterEntity=(CompanyType)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Enum_CompanyType WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
