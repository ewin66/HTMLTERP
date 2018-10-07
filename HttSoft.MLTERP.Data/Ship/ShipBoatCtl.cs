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
	/// 目的：Ship_ShipBoat实体控制类
	/// 作者:qiuchao
	/// 创建日期:2015/7/27
	/// </summary>
	public sealed class ShipBoatCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ShipBoatCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ShipBoatCtl(IDBTransAccess p_SqlCmd)
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
                ShipBoat MasterEntity=(ShipBoat)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Ship_ShipBoat(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("IvoiceNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.IvoiceNo)+","); 
  				MasterField.Append("CompanyTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				MasterField.Append("SaleNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleNo)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("Model"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Model)+","); 
  				MasterField.Append("ModelEn"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ModelEn)+","); 
  				MasterField.Append("ShipDate"+","); 
  				if(MasterEntity.ShipDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ShipDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RevisedDate"+","); 
  				if(MasterEntity.RevisedDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RevisedDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OutDate"+","); 
  				if(MasterEntity.OutDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OutDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TradeType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TradeType)+","); 
  				MasterField.Append("GainType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GainType)+","); 
  				MasterField.Append("ReceiveType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ReceiveType)+","); 
  				MasterField.Append("TransType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TransType)+","); 
  				MasterField.Append("ShipTo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ShipTo)+","); 
  				MasterField.Append("FactoryID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FactoryID)+","); 
  				MasterField.Append("OutFacDate"+","); 
  				if(MasterEntity.OutFacDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OutFacDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ExportDate"+","); 
  				if(MasterEntity.ExportDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ExportDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Messrs"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Messrs)+","); 
  				MasterField.Append("SpeRequest"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SpeRequest)+","); 
  				MasterField.Append("SCNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SCNo)+","); 
  				MasterField.Append("BoatName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BoatName)+","); 
  				MasterField.Append("Container"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Container)+","); 
  				MasterField.Append("Special"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Special)+","); 
  				MasterField.Append("CroosWeight"+","); 
  				if(MasterEntity.CroosWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CroosWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("NetWeight"+","); 
  				if(MasterEntity.NetWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NetWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PackNum"+","); 
  				if(MasterEntity.PackNum!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PackNum)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Shippers"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Shippers)+","); 
  				MasterField.Append("Consignee"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Consignee)+","); 
  				MasterField.Append("NotifyParty"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.NotifyParty)+","); 
  				MasterField.Append("PortLoading"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PortLoading)+","); 
  				MasterField.Append("PortDischarge"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PortDischarge)+","); 
  				MasterField.Append("LCNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LCNo)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("AddTime"+","); 
  				if(MasterEntity.AddTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AddOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AddOPID)+","); 
  				MasterField.Append("UpdTime"+","); 
  				if(MasterEntity.UpdTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.UpdTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("UpdOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UpdOPID)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("SubmitTime"+","); 
  				if(MasterEntity.SubmitTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SubmitOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitOPID)+","); 
  				MasterField.Append("AuditFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AuditFlag)+","); 
  				MasterField.Append("FromOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FromOPName)+","); 
  				MasterField.Append("ToOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ToOPName)+","); 
  				MasterField.Append("GoodsINWHDate"+","); 
  				if(MasterEntity.GoodsINWHDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsINWHDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FormListAID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormListAID)+","); 
  				MasterField.Append("BoatDate"+","); 
  				if(MasterEntity.BoatDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BoatDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("dex"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.dex)+","); 
  				MasterField.Append("Code"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Code)+","); 
  				MasterField.Append("PrintStatus"+","); 
  				if(MasterEntity.PrintStatus!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PrintStatus)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalBulk"+")"); 
  				if(MasterEntity.TotalBulk!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalBulk)+")"); 
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
                ShipBoat MasterEntity=(ShipBoat)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Ship_ShipBoat SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" IvoiceNo="+SysString.ToDBString(MasterEntity.IvoiceNo)+","); 
  				UpdateBuilder.Append(" CompanyTypeID="+SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				UpdateBuilder.Append(" SaleNo="+SysString.ToDBString(MasterEntity.SaleNo)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" Model="+SysString.ToDBString(MasterEntity.Model)+","); 
  				UpdateBuilder.Append(" ModelEn="+SysString.ToDBString(MasterEntity.ModelEn)+","); 
  				 
  				if(MasterEntity.ShipDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ShipDate="+SysString.ToDBString(MasterEntity.ShipDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ShipDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.RevisedDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" RevisedDate="+SysString.ToDBString(MasterEntity.RevisedDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RevisedDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.OutDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" OutDate="+SysString.ToDBString(MasterEntity.OutDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OutDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" TradeType="+SysString.ToDBString(MasterEntity.TradeType)+","); 
  				UpdateBuilder.Append(" GainType="+SysString.ToDBString(MasterEntity.GainType)+","); 
  				UpdateBuilder.Append(" ReceiveType="+SysString.ToDBString(MasterEntity.ReceiveType)+","); 
  				UpdateBuilder.Append(" TransType="+SysString.ToDBString(MasterEntity.TransType)+","); 
  				UpdateBuilder.Append(" ShipTo="+SysString.ToDBString(MasterEntity.ShipTo)+","); 
  				UpdateBuilder.Append(" FactoryID="+SysString.ToDBString(MasterEntity.FactoryID)+","); 
  				 
  				if(MasterEntity.OutFacDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" OutFacDate="+SysString.ToDBString(MasterEntity.OutFacDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OutFacDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.ExportDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ExportDate="+SysString.ToDBString(MasterEntity.ExportDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ExportDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" Messrs="+SysString.ToDBString(MasterEntity.Messrs)+","); 
  				UpdateBuilder.Append(" SpeRequest="+SysString.ToDBString(MasterEntity.SpeRequest)+","); 
  				UpdateBuilder.Append(" SCNo="+SysString.ToDBString(MasterEntity.SCNo)+","); 
  				UpdateBuilder.Append(" BoatName="+SysString.ToDBString(MasterEntity.BoatName)+","); 
  				UpdateBuilder.Append(" Container="+SysString.ToDBString(MasterEntity.Container)+","); 
  				UpdateBuilder.Append(" Special="+SysString.ToDBString(MasterEntity.Special)+","); 
  				 
  				if(MasterEntity.CroosWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CroosWeight="+SysString.ToDBString(MasterEntity.CroosWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CroosWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.NetWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" NetWeight="+SysString.ToDBString(MasterEntity.NetWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NetWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.PackNum!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PackNum="+SysString.ToDBString(MasterEntity.PackNum)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PackNum=null,");  
  				} 
  
  				UpdateBuilder.Append(" Shippers="+SysString.ToDBString(MasterEntity.Shippers)+","); 
  				UpdateBuilder.Append(" Consignee="+SysString.ToDBString(MasterEntity.Consignee)+","); 
  				UpdateBuilder.Append(" NotifyParty="+SysString.ToDBString(MasterEntity.NotifyParty)+","); 
  				UpdateBuilder.Append(" PortLoading="+SysString.ToDBString(MasterEntity.PortLoading)+","); 
  				UpdateBuilder.Append(" PortDischarge="+SysString.ToDBString(MasterEntity.PortDischarge)+","); 
  				UpdateBuilder.Append(" LCNo="+SysString.ToDBString(MasterEntity.LCNo)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				 
  				if(MasterEntity.AddTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" AddTime="+SysString.ToDBString(MasterEntity.AddTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" AddOPID="+SysString.ToDBString(MasterEntity.AddOPID)+","); 
  				 
  				if(MasterEntity.UpdTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" UpdTime="+SysString.ToDBString(MasterEntity.UpdTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" UpdTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" UpdOPID="+SysString.ToDBString(MasterEntity.UpdOPID)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				 
  				if(MasterEntity.SubmitTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SubmitTime="+SysString.ToDBString(MasterEntity.SubmitTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SubmitTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" SubmitOPID="+SysString.ToDBString(MasterEntity.SubmitOPID)+","); 
  				UpdateBuilder.Append(" AuditFlag="+SysString.ToDBString(MasterEntity.AuditFlag)+","); 
  				UpdateBuilder.Append(" FromOPName="+SysString.ToDBString(MasterEntity.FromOPName)+","); 
  				UpdateBuilder.Append(" ToOPName="+SysString.ToDBString(MasterEntity.ToOPName)+","); 
  				 
  				if(MasterEntity.GoodsINWHDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" GoodsINWHDate="+SysString.ToDBString(MasterEntity.GoodsINWHDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" GoodsINWHDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" FormListAID="+SysString.ToDBString(MasterEntity.FormListAID)+","); 
  				 
  				if(MasterEntity.BoatDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" BoatDate="+SysString.ToDBString(MasterEntity.BoatDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BoatDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" dex="+SysString.ToDBString(MasterEntity.dex)+","); 
  				UpdateBuilder.Append(" Code="+SysString.ToDBString(MasterEntity.Code)+","); 
  				 
  				if(MasterEntity.PrintStatus!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PrintStatus="+SysString.ToDBString(MasterEntity.PrintStatus)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PrintStatus=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalBulk!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalBulk="+SysString.ToDBString(MasterEntity.TotalBulk)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalBulk=null");  
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
                ShipBoat MasterEntity=(ShipBoat)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Ship_ShipBoat WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
