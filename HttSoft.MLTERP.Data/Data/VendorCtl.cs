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
	/// 目的：Data_Vendor实体控制类
	/// 作者:周富春
	/// 创建日期:2014/11/11
	/// </summary>
	public sealed class VendorCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public VendorCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public VendorCtl(IDBTransAccess p_SqlCmd)
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
                Vendor MasterEntity=(Vendor)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_Vendor(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("VendorAttn"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorAttn)+","); 
  				MasterField.Append("VendorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorName)+","); 
  				MasterField.Append("VendorNameEn"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorNameEn)+","); 
  				MasterField.Append("VendorTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorTypeID)+","); 
  				MasterField.Append("Tel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Tel)+","); 
  				MasterField.Append("Fax"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Fax)+","); 
  				MasterField.Append("Address"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Address)+","); 
  				MasterField.Append("UseableFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UseableFlag)+","); 
  				MasterField.Append("WebFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WebFlag)+","); 
  				MasterField.Append("Password"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Password)+","); 
  				MasterField.Append("Country"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Country)+","); 
  				MasterField.Append("Contact"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Contact)+","); 
  				MasterField.Append("InDate"+","); 
  				if(MasterEntity.InDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InSaleOP"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InSaleOP)+","); 
  				MasterField.Append("WebUrl"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WebUrl)+","); 
  				MasterField.Append("Free1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Free1)+","); 
  				MasterField.Append("Free2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Free2)+","); 
  				MasterField.Append("Free3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Free3)+","); 
  				MasterField.Append("Area"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Area)+","); 
  				MasterField.Append("VendorTypeID2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorTypeID2)+","); 
  				MasterField.Append("VendorTypeID3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorTypeID3)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("QueryAccount"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QueryAccount)+","); 
  				MasterField.Append("VendorLevel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorLevel)+","); 
  				MasterField.Append("CHBrand"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CHBrand)+","); 
  				MasterField.Append("ENBrand"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ENBrand)+","); 
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
  
  				MasterField.Append("SJFG"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SJFG)+","); 
  				MasterField.Append("MPrice1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MPrice1)+","); 
  				MasterField.Append("MPrice2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MPrice2)+","); 
  				MasterField.Append("MPrice3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MPrice3)+","); 
  				MasterField.Append("MPrice4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MPrice4)+","); 
  				MasterField.Append("PF"+","); 
  				if(MasterEntity.PF!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PF)+","); 
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
  
  				MasterField.Append("ZY"+","); 
  				if(MasterEntity.ZY!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ZY)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MainSale"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainSale)+","); 
  				MasterField.Append("LimitAmount"+","); 
  				if(MasterEntity.LimitAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LimitAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				}

                MasterField.Append("SHXAmount" + ",");
                if (MasterEntity.SHXAmount != 0)
                {
                    MasterValue.Append(SysString.ToDBString(MasterEntity.SHXAmount) + ",");
                }
                else
                {
                    MasterValue.Append("null,");
                } 

  				MasterField.Append("LimitDayNum"+","); 
  				if(MasterEntity.LimitDayNum!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LimitDayNum)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("QQ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QQ)+","); 
  				MasterField.Append("Alibaba"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Alibaba)+","); 
  				MasterField.Append("MainBusiness"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainBusiness)+","); 
  				MasterField.Append("VendorNameSpell"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorNameSpell)+","); 
  				MasterField.Append("ZhangHao"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ZhangHao)+","); 
  				MasterField.Append("ContactEn"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ContactEn)+","); 
  				MasterField.Append("Mobile"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Mobile)+","); 
  				MasterField.Append("VendorStyle"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorStyle)+","); 
  				MasterField.Append("EMail"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.EMail)+","); 
  				MasterField.Append("Province"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Province)+","); 
  				MasterField.Append("PayMethodFlag"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PayMethodFlag)+")"); 
 
                
                

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
                Vendor MasterEntity=(Vendor)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_Vendor SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" VendorAttn="+SysString.ToDBString(MasterEntity.VendorAttn)+","); 
  				UpdateBuilder.Append(" VendorName="+SysString.ToDBString(MasterEntity.VendorName)+","); 
  				UpdateBuilder.Append(" VendorNameEn="+SysString.ToDBString(MasterEntity.VendorNameEn)+","); 
  				UpdateBuilder.Append(" VendorTypeID="+SysString.ToDBString(MasterEntity.VendorTypeID)+","); 
  				UpdateBuilder.Append(" Tel="+SysString.ToDBString(MasterEntity.Tel)+","); 
  				UpdateBuilder.Append(" Fax="+SysString.ToDBString(MasterEntity.Fax)+","); 
  				UpdateBuilder.Append(" Address="+SysString.ToDBString(MasterEntity.Address)+","); 
  				UpdateBuilder.Append(" UseableFlag="+SysString.ToDBString(MasterEntity.UseableFlag)+","); 
  				UpdateBuilder.Append(" WebFlag="+SysString.ToDBString(MasterEntity.WebFlag)+","); 
  				UpdateBuilder.Append(" Password="+SysString.ToDBString(MasterEntity.Password)+","); 
  				UpdateBuilder.Append(" Country="+SysString.ToDBString(MasterEntity.Country)+","); 
  				UpdateBuilder.Append(" Contact="+SysString.ToDBString(MasterEntity.Contact)+","); 
  				 
  				if(MasterEntity.InDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" InDate="+SysString.ToDBString(MasterEntity.InDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" InSaleOP="+SysString.ToDBString(MasterEntity.InSaleOP)+","); 
  				UpdateBuilder.Append(" WebUrl="+SysString.ToDBString(MasterEntity.WebUrl)+","); 
  				UpdateBuilder.Append(" Free1="+SysString.ToDBString(MasterEntity.Free1)+","); 
  				UpdateBuilder.Append(" Free2="+SysString.ToDBString(MasterEntity.Free2)+","); 
  				UpdateBuilder.Append(" Free3="+SysString.ToDBString(MasterEntity.Free3)+","); 
  				UpdateBuilder.Append(" Area="+SysString.ToDBString(MasterEntity.Area)+","); 
  				UpdateBuilder.Append(" VendorTypeID2="+SysString.ToDBString(MasterEntity.VendorTypeID2)+","); 
  				UpdateBuilder.Append(" VendorTypeID3="+SysString.ToDBString(MasterEntity.VendorTypeID3)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" QueryAccount="+SysString.ToDBString(MasterEntity.QueryAccount)+","); 
  				UpdateBuilder.Append(" VendorLevel="+SysString.ToDBString(MasterEntity.VendorLevel)+","); 
  				UpdateBuilder.Append(" CHBrand="+SysString.ToDBString(MasterEntity.CHBrand)+","); 
  				UpdateBuilder.Append(" ENBrand="+SysString.ToDBString(MasterEntity.ENBrand)+","); 
  				 
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
  
  				UpdateBuilder.Append(" SJFG="+SysString.ToDBString(MasterEntity.SJFG)+","); 
  				UpdateBuilder.Append(" MPrice1="+SysString.ToDBString(MasterEntity.MPrice1)+","); 
  				UpdateBuilder.Append(" MPrice2="+SysString.ToDBString(MasterEntity.MPrice2)+","); 
  				UpdateBuilder.Append(" MPrice3="+SysString.ToDBString(MasterEntity.MPrice3)+","); 
  				UpdateBuilder.Append(" MPrice4="+SysString.ToDBString(MasterEntity.MPrice4)+","); 
  				 
  				if(MasterEntity.PF!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PF="+SysString.ToDBString(MasterEntity.PF)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PF=null,");  
  				} 
  
  				 
  				if(MasterEntity.DL!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DL="+SysString.ToDBString(MasterEntity.DL)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DL=null,");  
  				} 
  
  				 
  				if(MasterEntity.ZY!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ZY="+SysString.ToDBString(MasterEntity.ZY)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ZY=null,");  
  				} 
  
  				UpdateBuilder.Append(" MainSale="+SysString.ToDBString(MasterEntity.MainSale)+","); 
  				 
  				if(MasterEntity.LimitAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" LimitAmount="+SysString.ToDBString(MasterEntity.LimitAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LimitAmount=null,");  
  				}

                if (MasterEntity.SHXAmount != 0)
                {
                    UpdateBuilder.Append(" SHXAmount=" + SysString.ToDBString(MasterEntity.SHXAmount) + ",");
                }
                else
                {
                    UpdateBuilder.Append(" SHXAmount=null,");
                } 
  				 
  				if(MasterEntity.LimitDayNum!=0) 
  				{ 
  			 		UpdateBuilder.Append(" LimitDayNum="+SysString.ToDBString(MasterEntity.LimitDayNum)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LimitDayNum=null,");  
  				} 
  
  				UpdateBuilder.Append(" QQ="+SysString.ToDBString(MasterEntity.QQ)+","); 
  				UpdateBuilder.Append(" Alibaba="+SysString.ToDBString(MasterEntity.Alibaba)+","); 
  				UpdateBuilder.Append(" MainBusiness="+SysString.ToDBString(MasterEntity.MainBusiness)+","); 
  				UpdateBuilder.Append(" VendorNameSpell="+SysString.ToDBString(MasterEntity.VendorNameSpell)+","); 
  				UpdateBuilder.Append(" ZhangHao="+SysString.ToDBString(MasterEntity.ZhangHao)+","); 
  				UpdateBuilder.Append(" ContactEn="+SysString.ToDBString(MasterEntity.ContactEn)+","); 
  				UpdateBuilder.Append(" Mobile="+SysString.ToDBString(MasterEntity.Mobile)+","); 
  				UpdateBuilder.Append(" VendorStyle="+SysString.ToDBString(MasterEntity.VendorStyle)+","); 
  				UpdateBuilder.Append(" EMail="+SysString.ToDBString(MasterEntity.EMail)+","); 
  				UpdateBuilder.Append(" Province="+SysString.ToDBString(MasterEntity.Province)+","); 
  				UpdateBuilder.Append(" PayMethodFlag="+SysString.ToDBString(MasterEntity.PayMethodFlag)); 
 
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
                Vendor MasterEntity=(Vendor)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_Vendor WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
