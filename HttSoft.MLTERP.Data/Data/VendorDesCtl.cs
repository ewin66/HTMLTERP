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
	/// 目的：Data_VendorDes实体控制类
	/// 作者:章文强
	/// 创建日期:2012/11/27
	/// </summary>
	public sealed class VendorDesCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public VendorDesCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public VendorDesCtl(IDBTransAccess p_SqlCmd)
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
                VendorDes MasterEntity=(VendorDes)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_VendorDes(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("VendorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorName)+","); 
  				MasterField.Append("CHBrand"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CHBrand)+","); 
  				MasterField.Append("ENBrand"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ENBrand)+","); 
  				MasterField.Append("Tel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Tel)+","); 
  				MasterField.Append("Fax"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Fax)+","); 
  				MasterField.Append("Contact"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Contact)+","); 
  				MasterField.Append("www"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.www)+","); 
  				MasterField.Append("Address"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Address)+","); 
  				MasterField.Append("MLCGDate"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MLCGDate)+","); 
  				MasterField.Append("DHHDate"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DHHDate)+","); 
  				MasterField.Append("PF"+","); 
  				if(MasterEntity.PF!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PF)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("LS"+","); 
  				if(MasterEntity.LS!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LS)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PFANDLS"+","); 
  				if(MasterEntity.PFANDLS!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PFANDLS)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PFBL"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PFBL)+","); 
  				MasterField.Append("LSBL"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LSBL)+","); 
  				MasterField.Append("WF"+","); 
  				if(MasterEntity.WF!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.WF)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ZX"+","); 
  				if(MasterEntity.ZX!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ZX)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PVendorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PVendorName)+","); 
  				MasterField.Append("PVendorAddress"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PVendorAddress)+","); 
  				MasterField.Append("ContactTel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ContactTel)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("AddOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AddOPID)+","); 
  				MasterField.Append("AddOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AddOPName)+","); 
  				MasterField.Append("AddDate"+","); 
  				if(MasterEntity.AddDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CGJJ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CGJJ)+","); 
  				MasterField.Append("DHJJ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DHJJ)+","); 
  				MasterField.Append("age1"+","); 
  				if(MasterEntity.age1!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.age1)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("age2"+","); 
  				if(MasterEntity.age2!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.age2)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Fprice1"+","); 
  				if(MasterEntity.Fprice1!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Fprice1)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Fprice2"+","); 
  				if(MasterEntity.Fprice2!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Fprice2)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Fprice3"+","); 
  				if(MasterEntity.Fprice3!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Fprice3)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Fprice4"+","); 
  				if(MasterEntity.Fprice4!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Fprice4)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SJFG"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SJFG)+","); 
  				MasterField.Append("CG1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CG1)+","); 
  				MasterField.Append("CG2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CG2)+","); 
  				MasterField.Append("CG3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CG3)+","); 
  				MasterField.Append("CG4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CG4)+","); 
  				MasterField.Append("MPrice1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MPrice1)+","); 
  				MasterField.Append("MPrice2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MPrice2)+","); 
  				MasterField.Append("MPrice3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MPrice3)+","); 
  				MasterField.Append("MPrice4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MPrice4)+","); 
  				MasterField.Append("ZY"+","); 
  				if(MasterEntity.ZY!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ZY)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DL"+","); 
  				if(MasterEntity.DL!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DL)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JJ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JJ)+","); 
  				MasterField.Append("MakeDate"+","); 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FormDate"+","); 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FormOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormOPName)+","); 
  				MasterField.Append("SaleOPID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+")"); 
 
                
                

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
                VendorDes MasterEntity=(VendorDes)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_VendorDes SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" VendorName="+SysString.ToDBString(MasterEntity.VendorName)+","); 
  				UpdateBuilder.Append(" CHBrand="+SysString.ToDBString(MasterEntity.CHBrand)+","); 
  				UpdateBuilder.Append(" ENBrand="+SysString.ToDBString(MasterEntity.ENBrand)+","); 
  				UpdateBuilder.Append(" Tel="+SysString.ToDBString(MasterEntity.Tel)+","); 
  				UpdateBuilder.Append(" Fax="+SysString.ToDBString(MasterEntity.Fax)+","); 
  				UpdateBuilder.Append(" Contact="+SysString.ToDBString(MasterEntity.Contact)+","); 
  				UpdateBuilder.Append(" www="+SysString.ToDBString(MasterEntity.www)+","); 
  				UpdateBuilder.Append(" Address="+SysString.ToDBString(MasterEntity.Address)+","); 
  				UpdateBuilder.Append(" MLCGDate="+SysString.ToDBString(MasterEntity.MLCGDate)+","); 
  				UpdateBuilder.Append(" DHHDate="+SysString.ToDBString(MasterEntity.DHHDate)+","); 
  				 
  				if(MasterEntity.PF!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PF="+SysString.ToDBString(MasterEntity.PF)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PF=null,");  
  				} 
  
  				 
  				if(MasterEntity.LS!=0) 
  				{ 
  			 		UpdateBuilder.Append(" LS="+SysString.ToDBString(MasterEntity.LS)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LS=null,");  
  				} 
  
  				 
  				if(MasterEntity.PFANDLS!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PFANDLS="+SysString.ToDBString(MasterEntity.PFANDLS)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PFANDLS=null,");  
  				} 
  
  				UpdateBuilder.Append(" PFBL="+SysString.ToDBString(MasterEntity.PFBL)+","); 
  				UpdateBuilder.Append(" LSBL="+SysString.ToDBString(MasterEntity.LSBL)+","); 
  				 
  				if(MasterEntity.WF!=0) 
  				{ 
  			 		UpdateBuilder.Append(" WF="+SysString.ToDBString(MasterEntity.WF)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" WF=null,");  
  				} 
  
  				 
  				if(MasterEntity.ZX!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ZX="+SysString.ToDBString(MasterEntity.ZX)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ZX=null,");  
  				} 
  
  				UpdateBuilder.Append(" PVendorName="+SysString.ToDBString(MasterEntity.PVendorName)+","); 
  				UpdateBuilder.Append(" PVendorAddress="+SysString.ToDBString(MasterEntity.PVendorAddress)+","); 
  				UpdateBuilder.Append(" ContactTel="+SysString.ToDBString(MasterEntity.ContactTel)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" AddOPID="+SysString.ToDBString(MasterEntity.AddOPID)+","); 
  				UpdateBuilder.Append(" AddOPName="+SysString.ToDBString(MasterEntity.AddOPName)+","); 
  				 
  				if(MasterEntity.AddDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" AddDate="+SysString.ToDBString(MasterEntity.AddDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" CGJJ="+SysString.ToDBString(MasterEntity.CGJJ)+","); 
  				UpdateBuilder.Append(" DHJJ="+SysString.ToDBString(MasterEntity.DHJJ)+","); 
  				 
  				if(MasterEntity.age1!=0) 
  				{ 
  			 		UpdateBuilder.Append(" age1="+SysString.ToDBString(MasterEntity.age1)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" age1=null,");  
  				} 
  
  				 
  				if(MasterEntity.age2!=0) 
  				{ 
  			 		UpdateBuilder.Append(" age2="+SysString.ToDBString(MasterEntity.age2)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" age2=null,");  
  				} 
  
  				 
  				if(MasterEntity.Fprice1!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Fprice1="+SysString.ToDBString(MasterEntity.Fprice1)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Fprice1=null,");  
  				} 
  
  				 
  				if(MasterEntity.Fprice2!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Fprice2="+SysString.ToDBString(MasterEntity.Fprice2)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Fprice2=null,");  
  				} 
  
  				 
  				if(MasterEntity.Fprice3!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Fprice3="+SysString.ToDBString(MasterEntity.Fprice3)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Fprice3=null,");  
  				} 
  
  				 
  				if(MasterEntity.Fprice4!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Fprice4="+SysString.ToDBString(MasterEntity.Fprice4)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Fprice4=null,");  
  				} 
  
  				UpdateBuilder.Append(" SJFG="+SysString.ToDBString(MasterEntity.SJFG)+","); 
  				UpdateBuilder.Append(" CG1="+SysString.ToDBString(MasterEntity.CG1)+","); 
  				UpdateBuilder.Append(" CG2="+SysString.ToDBString(MasterEntity.CG2)+","); 
  				UpdateBuilder.Append(" CG3="+SysString.ToDBString(MasterEntity.CG3)+","); 
  				UpdateBuilder.Append(" CG4="+SysString.ToDBString(MasterEntity.CG4)+","); 
  				UpdateBuilder.Append(" MPrice1="+SysString.ToDBString(MasterEntity.MPrice1)+","); 
  				UpdateBuilder.Append(" MPrice2="+SysString.ToDBString(MasterEntity.MPrice2)+","); 
  				UpdateBuilder.Append(" MPrice3="+SysString.ToDBString(MasterEntity.MPrice3)+","); 
  				UpdateBuilder.Append(" MPrice4="+SysString.ToDBString(MasterEntity.MPrice4)+","); 
  				 
  				if(MasterEntity.ZY!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ZY="+SysString.ToDBString(MasterEntity.ZY)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ZY=null,");  
  				} 
  
  				 
  				if(MasterEntity.DL!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DL="+SysString.ToDBString(MasterEntity.DL)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DL=null,");  
  				} 
  
  				UpdateBuilder.Append(" JJ="+SysString.ToDBString(MasterEntity.JJ)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FormDate="+SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" FormOPName="+SysString.ToDBString(MasterEntity.FormOPName)+","); 
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)); 
 
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
                VendorDes MasterEntity=(VendorDes)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_VendorDes WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
