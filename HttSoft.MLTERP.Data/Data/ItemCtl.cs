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
	/// 目的：Data_Item实体控制类
	/// 作者:qiuchao
	/// 创建日期:2015/6/8
	/// </summary>
	public sealed class ItemCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ItemCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemCtl(IDBTransAccess p_SqlCmd)
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
                Item MasterEntity=(Item)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_Item(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("ItemDate"+","); 
  				if(MasterEntity.ItemDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ItemDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("MLDLCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MLDLCode)+","); 
  				MasterField.Append("MLLBCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MLLBCode)+","); 
  				MasterField.Append("GoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				MasterField.Append("ItemTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemTypeID)+","); 
  				MasterField.Append("ItemClassID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemClassID)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("ItemNameEn"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemNameEn)+","); 
  				MasterField.Append("ItemModelEn"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModelEn)+","); 
  				MasterField.Append("ItemUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemUnit)+","); 
  				MasterField.Append("ItemAttnCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemAttnCode)+","); 
  				MasterField.Append("MWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth)+","); 
  				MasterField.Append("MWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight)+","); 
  				MasterField.Append("WeightUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WeightUnit)+","); 
  				MasterField.Append("YarnStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YarnStd)+","); 
  				MasterField.Append("JWM"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JWM)+","); 
  				MasterField.Append("ZWZZ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ZWZZ)+","); 
  				MasterField.Append("Season"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Season)+","); 
  				MasterField.Append("Needle"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Needle)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("UseableFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UseableFlag)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("PFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PFlag)+","); 
  				MasterField.Append("XFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.XFlag)+","); 
  				MasterField.Append("MLLBName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MLLBName)+","); 
  				MasterField.Append("BuyPrice"+","); 
  				if(MasterEntity.BuyPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BuyPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BuyPriceDate"+","); 
  				if(MasterEntity.BuyPriceDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BuyPriceDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SalePrice"+","); 
  				if(MasterEntity.SalePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SalePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SalePriceDate"+","); 
  				if(MasterEntity.SalePriceDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SalePriceDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Web"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Web)+","); 
  				MasterField.Append("PerMiWeight"+","); 
  				if(MasterEntity.PerMiWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PerMiWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("GreyFabItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GreyFabItemCode)+","); 
  				MasterField.Append("Shrinkage"+","); 
  				if(MasterEntity.Shrinkage!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Shrinkage)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ColorLoss"+","); 
  				if(MasterEntity.ColorLoss!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ColorLoss)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("LastLoss"+","); 
  				if(MasterEntity.LastLoss!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LastLoss)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FabricTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FabricTypeID)+","); 
  				MasterField.Append("ClientNO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ClientNO)+","); 
  				MasterField.Append("MiDu"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MiDu)+","); 
  				MasterField.Append("ShiYangNO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ShiYangNO)+","); 
  				MasterField.Append("PBPrice"+","); 
  				if(MasterEntity.PBPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PBPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CPPrice"+","); 
  				if(MasterEntity.CPPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CPPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ColorRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorRemark)+","); 
  				MasterField.Append("YPSource"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YPSource)+","); 
  				MasterField.Append("RFPrice"+","); 
  				if(MasterEntity.RFPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RFPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RFUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RFUnit)+","); 
  				MasterField.Append("ValidMWidth"+","); 
  				if(MasterEntity.ValidMWidth!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ValidMWidth)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SampleCBPrice"+","); 
  				if(MasterEntity.SampleCBPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SampleCBPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AttRSGYDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AttRSGYDesc)+","); 
  				MasterField.Append("AttMachineDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AttMachineDesc)+","); 
  				MasterField.Append("AttYarnDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AttYarnDesc)+","); 
  				MasterField.Append("FreeStr1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr1)+","); 
  				MasterField.Append("FreeStr2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr2)+","); 
  				MasterField.Append("FreeStr3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr3)+","); 
  				MasterField.Append("FreeStr4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr4)+","); 
  				MasterField.Append("FreeStr5"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr5)+","); 
  				MasterField.Append("Machine"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Machine)+","); 
  				MasterField.Append("TecDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TecDesc)+","); 
  				MasterField.Append("HD"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HD)+","); 
  				MasterField.Append("DB"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DB)+","); 
  				MasterField.Append("SS"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SS)+","); 
  				MasterField.Append("FK"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FK)+","); 
  				MasterField.Append("AfterFinish"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AfterFinish)+","); 
  				MasterField.Append("COST"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.COST)+","); 
  				MasterField.Append("COSTA"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.COSTA)+","); 
  				MasterField.Append("QUOT"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QUOT)+","); 
  				MasterField.Append("RShrinkage"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RShrinkage)+","); 
  				MasterField.Append("RSAmount"+","); 
  				if(MasterEntity.RSAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RSAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RSSH"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RSSH)+","); 
  				MasterField.Append("JGAmount"+","); 
  				if(MasterEntity.JGAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JGAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JGSH"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JGSH)+","); 
  				MasterField.Append("RColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RColorName)+","); 
  				MasterField.Append("PBVendor"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBVendor)+","); 
  				MasterField.Append("RSVendor"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RSVendor)+","); 
  				MasterField.Append("HZVendor"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HZVendor)+","); 
  				MasterField.Append("HZAmount"+","); 
  				if(MasterEntity.HZAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.HZAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ProfitMargin"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ProfitMargin)+","); 
  				MasterField.Append("JGAmount2"+","); 
  				if(MasterEntity.JGAmount2!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JGAmount2)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JGSH2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JGSH2)+","); 
  				MasterField.Append("JGAmount3"+","); 
  				if(MasterEntity.JGAmount3!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JGAmount3)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JGSH3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JGSH3)+","); 
  				MasterField.Append("MWeight2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight2)+","); 
  				MasterField.Append("HZType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HZType)+","); 
  				MasterField.Append("Organ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Organ)+","); 
  				MasterField.Append("MinQty"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MinQty)+","); 
  				MasterField.Append("DeliveryTime"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DeliveryTime)+","); 
  				MasterField.Append("SalePriceRMB"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SalePriceRMB)+","); 
  				MasterField.Append("SalePriceUSD"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SalePriceUSD)+","); 
  				MasterField.Append("SalePricePro"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SalePricePro)+","); 
  				MasterField.Append("SLDGM"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SLDGM)+","); 
  				MasterField.Append("SLDSM"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SLDSM)+","); 
  				MasterField.Append("SSLJX"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SSLJX)+","); 
  				MasterField.Append("SSLWX"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SSLWX)+","); 
  				MasterField.Append("SPQLJX"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SPQLJX)+","); 
  				MasterField.Append("SPQLWX"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SPQLWX)+","); 
  				MasterField.Append("LSQLJX"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LSQLJX)+","); 
  				MasterField.Append("LSQLWX"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LSQLWX)+","); 
  				MasterField.Append("PH"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PH)+","); 
  				MasterField.Append("KQMQ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.KQMQ)+","); 
  				MasterField.Append("GZLD"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GZLD)+","); 
  				MasterField.Append("MFUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MFUnit)+","); 
  				MasterField.Append("InchNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InchNum)+","); 
  				MasterField.Append("ItemModelNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModelNo)+","); 
  				MasterField.Append("ColorPrice"+","); 
  				if(MasterEntity.ColorPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ColorPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ZLPrice"+","); 
  				if(MasterEntity.ZLPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ZLPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalPriceUSB"+","); 
  				if(MasterEntity.TotalPriceUSB!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalPriceUSB)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ExchangeRate"+","); 
  				if(MasterEntity.ExchangeRate!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ExchangeRate)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalPriceRMB"+","); 
  				if(MasterEntity.TotalPriceRMB!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalPriceRMB)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CBPrice"+","); 
  				if(MasterEntity.CBPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CBPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ZJBJDate"+","); 
  				if(MasterEntity.ZJBJDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ZJBJDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JGPrice"+","); 
  				if(MasterEntity.JGPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JGPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalPrice"+","); 
  				if(MasterEntity.TotalPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ZXBJDate"+")"); 
  				if(MasterEntity.ZXBJDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ZXBJDate.ToString("yyyy-MM-dd HH:mm:ss"))+")"); 
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
                Item MasterEntity=(Item)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_Item SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				 
  				if(MasterEntity.ItemDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ItemDate="+SysString.ToDBString(MasterEntity.ItemDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ItemDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" MLDLCode="+SysString.ToDBString(MasterEntity.MLDLCode)+","); 
  				UpdateBuilder.Append(" MLLBCode="+SysString.ToDBString(MasterEntity.MLLBCode)+","); 
  				UpdateBuilder.Append(" GoodsCode="+SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				UpdateBuilder.Append(" ItemTypeID="+SysString.ToDBString(MasterEntity.ItemTypeID)+","); 
  				UpdateBuilder.Append(" ItemClassID="+SysString.ToDBString(MasterEntity.ItemClassID)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" ItemNameEn="+SysString.ToDBString(MasterEntity.ItemNameEn)+","); 
  				UpdateBuilder.Append(" ItemModelEn="+SysString.ToDBString(MasterEntity.ItemModelEn)+","); 
  				UpdateBuilder.Append(" ItemUnit="+SysString.ToDBString(MasterEntity.ItemUnit)+","); 
  				UpdateBuilder.Append(" ItemAttnCode="+SysString.ToDBString(MasterEntity.ItemAttnCode)+","); 
  				UpdateBuilder.Append(" MWidth="+SysString.ToDBString(MasterEntity.MWidth)+","); 
  				UpdateBuilder.Append(" MWeight="+SysString.ToDBString(MasterEntity.MWeight)+","); 
  				UpdateBuilder.Append(" WeightUnit="+SysString.ToDBString(MasterEntity.WeightUnit)+","); 
  				UpdateBuilder.Append(" YarnStd="+SysString.ToDBString(MasterEntity.YarnStd)+","); 
  				UpdateBuilder.Append(" JWM="+SysString.ToDBString(MasterEntity.JWM)+","); 
  				UpdateBuilder.Append(" ZWZZ="+SysString.ToDBString(MasterEntity.ZWZZ)+","); 
  				UpdateBuilder.Append(" Season="+SysString.ToDBString(MasterEntity.Season)+","); 
  				UpdateBuilder.Append(" Needle="+SysString.ToDBString(MasterEntity.Needle)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" UseableFlag="+SysString.ToDBString(MasterEntity.UseableFlag)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" PFlag="+SysString.ToDBString(MasterEntity.PFlag)+","); 
  				UpdateBuilder.Append(" XFlag="+SysString.ToDBString(MasterEntity.XFlag)+","); 
  				UpdateBuilder.Append(" MLLBName="+SysString.ToDBString(MasterEntity.MLLBName)+","); 
  				 
  				if(MasterEntity.BuyPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BuyPrice="+SysString.ToDBString(MasterEntity.BuyPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BuyPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.BuyPriceDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" BuyPriceDate="+SysString.ToDBString(MasterEntity.BuyPriceDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BuyPriceDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.SalePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SalePrice="+SysString.ToDBString(MasterEntity.SalePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SalePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.SalePriceDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SalePriceDate="+SysString.ToDBString(MasterEntity.SalePriceDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SalePriceDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" Web="+SysString.ToDBString(MasterEntity.Web)+","); 
  				 
  				if(MasterEntity.PerMiWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PerMiWeight="+SysString.ToDBString(MasterEntity.PerMiWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PerMiWeight=null,");  
  				} 
  
  				UpdateBuilder.Append(" GreyFabItemCode="+SysString.ToDBString(MasterEntity.GreyFabItemCode)+","); 
  				 
  				if(MasterEntity.Shrinkage!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Shrinkage="+SysString.ToDBString(MasterEntity.Shrinkage)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Shrinkage=null,");  
  				} 
  
  				 
  				if(MasterEntity.ColorLoss!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ColorLoss="+SysString.ToDBString(MasterEntity.ColorLoss)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ColorLoss=null,");  
  				} 
  
  				 
  				if(MasterEntity.LastLoss!=0) 
  				{ 
  			 		UpdateBuilder.Append(" LastLoss="+SysString.ToDBString(MasterEntity.LastLoss)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LastLoss=null,");  
  				} 
  
  				UpdateBuilder.Append(" FabricTypeID="+SysString.ToDBString(MasterEntity.FabricTypeID)+","); 
  				UpdateBuilder.Append(" ClientNO="+SysString.ToDBString(MasterEntity.ClientNO)+","); 
  				UpdateBuilder.Append(" MiDu="+SysString.ToDBString(MasterEntity.MiDu)+","); 
  				UpdateBuilder.Append(" ShiYangNO="+SysString.ToDBString(MasterEntity.ShiYangNO)+","); 
  				 
  				if(MasterEntity.PBPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PBPrice="+SysString.ToDBString(MasterEntity.PBPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PBPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.CPPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CPPrice="+SysString.ToDBString(MasterEntity.CPPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CPPrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" ColorRemark="+SysString.ToDBString(MasterEntity.ColorRemark)+","); 
  				UpdateBuilder.Append(" YPSource="+SysString.ToDBString(MasterEntity.YPSource)+","); 
  				 
  				if(MasterEntity.RFPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RFPrice="+SysString.ToDBString(MasterEntity.RFPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RFPrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" RFUnit="+SysString.ToDBString(MasterEntity.RFUnit)+","); 
  				 
  				if(MasterEntity.ValidMWidth!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ValidMWidth="+SysString.ToDBString(MasterEntity.ValidMWidth)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ValidMWidth=null,");  
  				} 
  
  				 
  				if(MasterEntity.SampleCBPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SampleCBPrice="+SysString.ToDBString(MasterEntity.SampleCBPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SampleCBPrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" AttRSGYDesc="+SysString.ToDBString(MasterEntity.AttRSGYDesc)+","); 
  				UpdateBuilder.Append(" AttMachineDesc="+SysString.ToDBString(MasterEntity.AttMachineDesc)+","); 
  				UpdateBuilder.Append(" AttYarnDesc="+SysString.ToDBString(MasterEntity.AttYarnDesc)+","); 
  				UpdateBuilder.Append(" FreeStr1="+SysString.ToDBString(MasterEntity.FreeStr1)+","); 
  				UpdateBuilder.Append(" FreeStr2="+SysString.ToDBString(MasterEntity.FreeStr2)+","); 
  				UpdateBuilder.Append(" FreeStr3="+SysString.ToDBString(MasterEntity.FreeStr3)+","); 
  				UpdateBuilder.Append(" FreeStr4="+SysString.ToDBString(MasterEntity.FreeStr4)+","); 
  				UpdateBuilder.Append(" FreeStr5="+SysString.ToDBString(MasterEntity.FreeStr5)+","); 
  				UpdateBuilder.Append(" Machine="+SysString.ToDBString(MasterEntity.Machine)+","); 
  				UpdateBuilder.Append(" TecDesc="+SysString.ToDBString(MasterEntity.TecDesc)+","); 
  				UpdateBuilder.Append(" HD="+SysString.ToDBString(MasterEntity.HD)+","); 
  				UpdateBuilder.Append(" DB="+SysString.ToDBString(MasterEntity.DB)+","); 
  				UpdateBuilder.Append(" SS="+SysString.ToDBString(MasterEntity.SS)+","); 
  				UpdateBuilder.Append(" FK="+SysString.ToDBString(MasterEntity.FK)+","); 
  				UpdateBuilder.Append(" AfterFinish="+SysString.ToDBString(MasterEntity.AfterFinish)+","); 
  				UpdateBuilder.Append(" COST="+SysString.ToDBString(MasterEntity.COST)+","); 
  				UpdateBuilder.Append(" COSTA="+SysString.ToDBString(MasterEntity.COSTA)+","); 
  				UpdateBuilder.Append(" QUOT="+SysString.ToDBString(MasterEntity.QUOT)+","); 
  				UpdateBuilder.Append(" RShrinkage="+SysString.ToDBString(MasterEntity.RShrinkage)+","); 
  				 
  				if(MasterEntity.RSAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RSAmount="+SysString.ToDBString(MasterEntity.RSAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RSAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" RSSH="+SysString.ToDBString(MasterEntity.RSSH)+","); 
  				 
  				if(MasterEntity.JGAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" JGAmount="+SysString.ToDBString(MasterEntity.JGAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JGAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" JGSH="+SysString.ToDBString(MasterEntity.JGSH)+","); 
  				UpdateBuilder.Append(" RColorName="+SysString.ToDBString(MasterEntity.RColorName)+","); 
  				UpdateBuilder.Append(" PBVendor="+SysString.ToDBString(MasterEntity.PBVendor)+","); 
  				UpdateBuilder.Append(" RSVendor="+SysString.ToDBString(MasterEntity.RSVendor)+","); 
  				UpdateBuilder.Append(" HZVendor="+SysString.ToDBString(MasterEntity.HZVendor)+","); 
  				 
  				if(MasterEntity.HZAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" HZAmount="+SysString.ToDBString(MasterEntity.HZAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" HZAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" ProfitMargin="+SysString.ToDBString(MasterEntity.ProfitMargin)+","); 
  				 
  				if(MasterEntity.JGAmount2!=0) 
  				{ 
  			 		UpdateBuilder.Append(" JGAmount2="+SysString.ToDBString(MasterEntity.JGAmount2)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JGAmount2=null,");  
  				} 
  
  				UpdateBuilder.Append(" JGSH2="+SysString.ToDBString(MasterEntity.JGSH2)+","); 
  				 
  				if(MasterEntity.JGAmount3!=0) 
  				{ 
  			 		UpdateBuilder.Append(" JGAmount3="+SysString.ToDBString(MasterEntity.JGAmount3)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JGAmount3=null,");  
  				} 
  
  				UpdateBuilder.Append(" JGSH3="+SysString.ToDBString(MasterEntity.JGSH3)+","); 
  				UpdateBuilder.Append(" MWeight2="+SysString.ToDBString(MasterEntity.MWeight2)+","); 
  				UpdateBuilder.Append(" HZType="+SysString.ToDBString(MasterEntity.HZType)+","); 
  				UpdateBuilder.Append(" Organ="+SysString.ToDBString(MasterEntity.Organ)+","); 
  				UpdateBuilder.Append(" MinQty="+SysString.ToDBString(MasterEntity.MinQty)+","); 
  				UpdateBuilder.Append(" DeliveryTime="+SysString.ToDBString(MasterEntity.DeliveryTime)+","); 
  				UpdateBuilder.Append(" SalePriceRMB="+SysString.ToDBString(MasterEntity.SalePriceRMB)+","); 
  				UpdateBuilder.Append(" SalePriceUSD="+SysString.ToDBString(MasterEntity.SalePriceUSD)+","); 
  				UpdateBuilder.Append(" SalePricePro="+SysString.ToDBString(MasterEntity.SalePricePro)+","); 
  				UpdateBuilder.Append(" SLDGM="+SysString.ToDBString(MasterEntity.SLDGM)+","); 
  				UpdateBuilder.Append(" SLDSM="+SysString.ToDBString(MasterEntity.SLDSM)+","); 
  				UpdateBuilder.Append(" SSLJX="+SysString.ToDBString(MasterEntity.SSLJX)+","); 
  				UpdateBuilder.Append(" SSLWX="+SysString.ToDBString(MasterEntity.SSLWX)+","); 
  				UpdateBuilder.Append(" SPQLJX="+SysString.ToDBString(MasterEntity.SPQLJX)+","); 
  				UpdateBuilder.Append(" SPQLWX="+SysString.ToDBString(MasterEntity.SPQLWX)+","); 
  				UpdateBuilder.Append(" LSQLJX="+SysString.ToDBString(MasterEntity.LSQLJX)+","); 
  				UpdateBuilder.Append(" LSQLWX="+SysString.ToDBString(MasterEntity.LSQLWX)+","); 
  				UpdateBuilder.Append(" PH="+SysString.ToDBString(MasterEntity.PH)+","); 
  				UpdateBuilder.Append(" KQMQ="+SysString.ToDBString(MasterEntity.KQMQ)+","); 
  				UpdateBuilder.Append(" GZLD="+SysString.ToDBString(MasterEntity.GZLD)+","); 
  				UpdateBuilder.Append(" MFUnit="+SysString.ToDBString(MasterEntity.MFUnit)+","); 
  				UpdateBuilder.Append(" InchNum="+SysString.ToDBString(MasterEntity.InchNum)+","); 
  				UpdateBuilder.Append(" ItemModelNo="+SysString.ToDBString(MasterEntity.ItemModelNo)+","); 
  				 
  				if(MasterEntity.ColorPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ColorPrice="+SysString.ToDBString(MasterEntity.ColorPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ColorPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.ZLPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ZLPrice="+SysString.ToDBString(MasterEntity.ZLPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ZLPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalPriceUSB!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalPriceUSB="+SysString.ToDBString(MasterEntity.TotalPriceUSB)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalPriceUSB=null,");  
  				} 
  
  				 
  				if(MasterEntity.ExchangeRate!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ExchangeRate="+SysString.ToDBString(MasterEntity.ExchangeRate)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ExchangeRate=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalPriceRMB!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalPriceRMB="+SysString.ToDBString(MasterEntity.TotalPriceRMB)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalPriceRMB=null,");  
  				} 
  
  				 
  				if(MasterEntity.CBPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CBPrice="+SysString.ToDBString(MasterEntity.CBPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CBPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.ZJBJDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ZJBJDate="+SysString.ToDBString(MasterEntity.ZJBJDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ZJBJDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.JGPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" JGPrice="+SysString.ToDBString(MasterEntity.JGPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JGPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalPrice="+SysString.ToDBString(MasterEntity.TotalPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.ZXBJDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ZXBJDate="+SysString.ToDBString(MasterEntity.ZXBJDate.ToString("yyyy-MM-dd HH:mm:ss"))); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ZXBJDate=null");  
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
                Item MasterEntity=(Item)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_Item WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
