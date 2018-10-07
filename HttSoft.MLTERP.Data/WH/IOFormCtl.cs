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
	/// 目的：WH_IOForm实体控制类
	/// 作者:XUSC
	/// 创建日期:2016/1/20
	/// </summary>
	public sealed class IOFormCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public IOFormCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public IOFormCtl(IDBTransAccess p_SqlCmd)
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
                IOForm MasterEntity=(IOForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WH_IOForm(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FromIOFormID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FromIOFormID)+","); 
  				MasterField.Append("CompanyTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				MasterField.Append("WHTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHTypeID)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
  				MasterField.Append("HeadType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HeadType)+","); 
  				MasterField.Append("SubType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubType)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("OutDep"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OutDep)+","); 
  				MasterField.Append("Indep"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Indep)+","); 
  				MasterField.Append("WHOP"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHOP)+","); 
  				MasterField.Append("PassOP"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PassOP)+","); 
  				MasterField.Append("DutyOP"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DutyOP)+","); 
  				MasterField.Append("SOID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SOID)+","); 
  				MasterField.Append("SpecialNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SpecialNo)+","); 
  				MasterField.Append("FormDate"+","); 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CardNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CardNo)+","); 
  				MasterField.Append("ConfirmFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ConfirmFlag)+","); 
  				MasterField.Append("CheckOP"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckOP)+","); 
  				MasterField.Append("CheckDate"+","); 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHID)+","); 
  				MasterField.Append("WHType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHType)+","); 
  				MasterField.Append("LastUpdTime"+","); 
  				if(MasterEntity.LastUpdTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LastUpdTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("LastUpdOP"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LastUpdOP)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("JHCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JHCode)+","); 
  				MasterField.Append("XZ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.XZ)+","); 
  				MasterField.Append("SaleOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				MasterField.Append("DM"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DM)+","); 
  				MasterField.Append("InvoiceNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceNo)+","); 
  				MasterField.Append("TotalQty"+","); 
  				if(MasterEntity.TotalQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalAmount"+","); 
  				if(MasterEntity.TotalAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SubmitOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitOPID)+","); 
  				MasterField.Append("SubmitTime"+","); 
  				if(MasterEntity.SubmitTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FHTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FHTypeID)+","); 
  				MasterField.Append("KDNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.KDNo)+","); 
  				MasterField.Append("DEFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DEFlag)+","); 
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
  
  				MasterField.Append("VendorOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorOPID)+","); 
  				MasterField.Append("VendorTel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorTel)+","); 
  				MasterField.Append("Address"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Address)+","); 
  				MasterField.Append("PackQty"+","); 
  				if(MasterEntity.PackQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PackQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PackSinglePrice"+","); 
  				if(MasterEntity.PackSinglePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PackSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PackAmount"+","); 
  				if(MasterEntity.PackAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PackAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Description"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Description)+","); 
  				MasterField.Append("Destination"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Destination)+","); 
  				MasterField.Append("RecordOPID1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecordOPID1)+","); 
  				MasterField.Append("RecordOPID2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecordOPID2)+","); 
  				MasterField.Append("RecordSBOPID1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecordSBOPID1)+","); 
  				MasterField.Append("RecordSBOPID2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecordSBOPID2)+","); 
  				MasterField.Append("RecordSBOPID3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecordSBOPID3)+","); 
  				MasterField.Append("RecordSBOPID4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecordSBOPID4)+","); 
  				MasterField.Append("RecordSBOPID5"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecordSBOPID5)+","); 
  				MasterField.Append("RecordYSOPID1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecordYSOPID1)+","); 
  				MasterField.Append("DZQty"+","); 
  				if(MasterEntity.DZQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DZQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DZSinglePrice"+","); 
  				if(MasterEntity.DZSinglePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DZSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DZAmount"+","); 
  				if(MasterEntity.DZAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DZAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DZFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DZFlag)+","); 
  				MasterField.Append("DZOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DZOPID)+","); 
  				MasterField.Append("DZTime"+","); 
  				if(MasterEntity.DZTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DZTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DZNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DZNo)+","); 
  				MasterField.Append("InvoiceQty"+","); 
  				if(MasterEntity.InvoiceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InvoiceAmount"+","); 
  				if(MasterEntity.InvoiceAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InvoiceDelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceDelFlag)+","); 
  				MasterField.Append("InvoiceDelOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceDelOPID)+","); 
  				MasterField.Append("InvoiceDelTime"+","); 
  				if(MasterEntity.InvoiceDelTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceDelTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PayAmount"+","); 
  				if(MasterEntity.PayAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PayAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
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
                IOForm MasterEntity=(IOForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WH_IOForm SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FromIOFormID="+SysString.ToDBString(MasterEntity.FromIOFormID)+","); 
  				UpdateBuilder.Append(" CompanyTypeID="+SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				UpdateBuilder.Append(" WHTypeID="+SysString.ToDBString(MasterEntity.WHTypeID)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
  				UpdateBuilder.Append(" HeadType="+SysString.ToDBString(MasterEntity.HeadType)+","); 
  				UpdateBuilder.Append(" SubType="+SysString.ToDBString(MasterEntity.SubType)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" OutDep="+SysString.ToDBString(MasterEntity.OutDep)+","); 
  				UpdateBuilder.Append(" Indep="+SysString.ToDBString(MasterEntity.Indep)+","); 
  				UpdateBuilder.Append(" WHOP="+SysString.ToDBString(MasterEntity.WHOP)+","); 
  				UpdateBuilder.Append(" PassOP="+SysString.ToDBString(MasterEntity.PassOP)+","); 
  				UpdateBuilder.Append(" DutyOP="+SysString.ToDBString(MasterEntity.DutyOP)+","); 
  				UpdateBuilder.Append(" SOID="+SysString.ToDBString(MasterEntity.SOID)+","); 
  				UpdateBuilder.Append(" SpecialNo="+SysString.ToDBString(MasterEntity.SpecialNo)+","); 
  				 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FormDate="+SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" CardNo="+SysString.ToDBString(MasterEntity.CardNo)+","); 
  				UpdateBuilder.Append(" ConfirmFlag="+SysString.ToDBString(MasterEntity.ConfirmFlag)+","); 
  				UpdateBuilder.Append(" CheckOP="+SysString.ToDBString(MasterEntity.CheckOP)+","); 
  				 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate="+SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" WHID="+SysString.ToDBString(MasterEntity.WHID)+","); 
  				UpdateBuilder.Append(" WHType="+SysString.ToDBString(MasterEntity.WHType)+","); 
  				 
  				if(MasterEntity.LastUpdTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" LastUpdTime="+SysString.ToDBString(MasterEntity.LastUpdTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LastUpdTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" LastUpdOP="+SysString.ToDBString(MasterEntity.LastUpdOP)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" JHCode="+SysString.ToDBString(MasterEntity.JHCode)+","); 
  				UpdateBuilder.Append(" XZ="+SysString.ToDBString(MasterEntity.XZ)+","); 
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				UpdateBuilder.Append(" DM="+SysString.ToDBString(MasterEntity.DM)+","); 
  				UpdateBuilder.Append(" InvoiceNo="+SysString.ToDBString(MasterEntity.InvoiceNo)+","); 
  				 
  				if(MasterEntity.TotalQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalQty="+SysString.ToDBString(MasterEntity.TotalQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalAmount="+SysString.ToDBString(MasterEntity.TotalAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" SubmitOPID="+SysString.ToDBString(MasterEntity.SubmitOPID)+","); 
  				 
  				if(MasterEntity.SubmitTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SubmitTime="+SysString.ToDBString(MasterEntity.SubmitTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SubmitTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" FHTypeID="+SysString.ToDBString(MasterEntity.FHTypeID)+","); 
  				UpdateBuilder.Append(" KDNo="+SysString.ToDBString(MasterEntity.KDNo)+","); 
  				UpdateBuilder.Append(" DEFlag="+SysString.ToDBString(MasterEntity.DEFlag)+","); 
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
  
  				UpdateBuilder.Append(" VendorOPID="+SysString.ToDBString(MasterEntity.VendorOPID)+","); 
  				UpdateBuilder.Append(" VendorTel="+SysString.ToDBString(MasterEntity.VendorTel)+","); 
  				UpdateBuilder.Append(" Address="+SysString.ToDBString(MasterEntity.Address)+","); 
  				 
  				if(MasterEntity.PackQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PackQty="+SysString.ToDBString(MasterEntity.PackQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PackQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.PackSinglePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PackSinglePrice="+SysString.ToDBString(MasterEntity.PackSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PackSinglePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.PackAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PackAmount="+SysString.ToDBString(MasterEntity.PackAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PackAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" Description="+SysString.ToDBString(MasterEntity.Description)+","); 
  				UpdateBuilder.Append(" Destination="+SysString.ToDBString(MasterEntity.Destination)+","); 
  				UpdateBuilder.Append(" RecordOPID1="+SysString.ToDBString(MasterEntity.RecordOPID1)+","); 
  				UpdateBuilder.Append(" RecordOPID2="+SysString.ToDBString(MasterEntity.RecordOPID2)+","); 
  				UpdateBuilder.Append(" RecordSBOPID1="+SysString.ToDBString(MasterEntity.RecordSBOPID1)+","); 
  				UpdateBuilder.Append(" RecordSBOPID2="+SysString.ToDBString(MasterEntity.RecordSBOPID2)+","); 
  				UpdateBuilder.Append(" RecordSBOPID3="+SysString.ToDBString(MasterEntity.RecordSBOPID3)+","); 
  				UpdateBuilder.Append(" RecordSBOPID4="+SysString.ToDBString(MasterEntity.RecordSBOPID4)+","); 
  				UpdateBuilder.Append(" RecordSBOPID5="+SysString.ToDBString(MasterEntity.RecordSBOPID5)+","); 
  				UpdateBuilder.Append(" RecordYSOPID1="+SysString.ToDBString(MasterEntity.RecordYSOPID1)+","); 
  				 
  				if(MasterEntity.DZQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DZQty="+SysString.ToDBString(MasterEntity.DZQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DZQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.DZSinglePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DZSinglePrice="+SysString.ToDBString(MasterEntity.DZSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DZSinglePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.DZAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DZAmount="+SysString.ToDBString(MasterEntity.DZAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DZAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" DZFlag="+SysString.ToDBString(MasterEntity.DZFlag)+","); 
  				UpdateBuilder.Append(" DZOPID="+SysString.ToDBString(MasterEntity.DZOPID)+","); 
  				 
  				if(MasterEntity.DZTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" DZTime="+SysString.ToDBString(MasterEntity.DZTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DZTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" DZNo="+SysString.ToDBString(MasterEntity.DZNo)+","); 
  				 
  				if(MasterEntity.InvoiceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceQty="+SysString.ToDBString(MasterEntity.InvoiceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.InvoiceAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceAmount="+SysString.ToDBString(MasterEntity.InvoiceAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" InvoiceDelFlag="+SysString.ToDBString(MasterEntity.InvoiceDelFlag)+","); 
  				UpdateBuilder.Append(" InvoiceDelOPID="+SysString.ToDBString(MasterEntity.InvoiceDelOPID)+","); 
  				 
  				if(MasterEntity.InvoiceDelTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceDelTime="+SysString.ToDBString(MasterEntity.InvoiceDelTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceDelTime=null,");  
  				} 
  
  				 
  				if(MasterEntity.PayAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PayAmount="+SysString.ToDBString(MasterEntity.PayAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PayAmount=null,");  
  				} 
  
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
                IOForm MasterEntity=(IOForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WH_IOForm WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
