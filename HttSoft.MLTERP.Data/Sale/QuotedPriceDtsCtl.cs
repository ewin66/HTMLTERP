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
	/// 目的：Sale_QuotedPriceDts实体控制类
	/// 作者:qiuchao
	/// 创建日期:2015/6/11
	/// </summary>
	public sealed class QuotedPriceDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public QuotedPriceDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public QuotedPriceDtsCtl(IDBTransAccess p_SqlCmd)
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
                QuotedPriceDts MasterEntity=(QuotedPriceDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Sale_QuotedPriceDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("GBCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GBCode)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("SalePrice"+","); 
  				if(MasterEntity.SalePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SalePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SelePriceDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SelePriceDesc)+","); 
  				MasterField.Append("SalePriceYXDate"+","); 
  				if(MasterEntity.SalePriceYXDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SalePriceYXDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SelePriceRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SelePriceRemark)+","); 
  				MasterField.Append("JQDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JQDesc)+","); 
  				MasterField.Append("PBFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBFlag)+","); 
  				MasterField.Append("SaleOPPrice"+","); 
  				if(MasterEntity.SaleOPPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("PBPrice"+","); 
  				if(MasterEntity.PBPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PBPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
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
  				MasterField.Append("HZAmount"+","); 
  				if(MasterEntity.HZAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.HZAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
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
  				MasterField.Append("ProfitMargin"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ProfitMargin)+","); 
  				MasterField.Append("AddPrice"+","); 
  				if(MasterEntity.AddPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FK"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FK)+","); 
  				MasterField.Append("HZType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HZType)+","); 
  				MasterField.Append("ItemClassID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemClassID)+","); 
  				MasterField.Append("DeliveryTime"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DeliveryTime)+","); 
  				MasterField.Append("MinQty"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MinQty)+","); 
  				MasterField.Append("PerMiWeight"+","); 
  				if(MasterEntity.PerMiWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PerMiWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("KZ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.KZ)+","); 
  				MasterField.Append("HL"+","); 
  				if(MasterEntity.HL!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.HL)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("USDPrice"+","); 
  				if(MasterEntity.USDPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.USDPrice)+","); 
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
  
  				MasterField.Append("TotalPriceRMB"+","); 
  				if(MasterEntity.TotalPriceRMB!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalPriceRMB)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
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
  
  				MasterField.Append("Shrinkage"+","); 
  				if(MasterEntity.Shrinkage!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Shrinkage)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("MWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth)+","); 
  				MasterField.Append("MWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight)+","); 
  				MasterField.Append("VItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				MasterField.Append("VColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				MasterField.Append("VColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorName)+","); 
  				MasterField.Append("USB"+","); 
  				if(MasterEntity.USB!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.USB)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ItemUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemUnit)+","); 
  				MasterField.Append("PackFee"+","); 
  				if(MasterEntity.PackFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PackFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("LiRunFee"+","); 
  				if(MasterEntity.LiRunFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LiRunFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TradeFee"+","); 
  				if(MasterEntity.TradeFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TradeFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("YongJin"+","); 
  				if(MasterEntity.YongJin!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YongJin)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("HouZLReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HouZLReq)+","); 
  				MasterField.Append("Fee1"+","); 
  				if(MasterEntity.Fee1!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Fee1)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Needle"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Needle)+","); 
  				MasterField.Append("RMB"+","); 
  				if(MasterEntity.RMB!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RMB)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RMBY"+","); 
  				if(MasterEntity.RMBY!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RMBY)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("USBY"+")"); 
  				if(MasterEntity.USBY!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.USBY)+")"); 
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
                QuotedPriceDts MasterEntity=(QuotedPriceDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Sale_QuotedPriceDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" GBCode="+SysString.ToDBString(MasterEntity.GBCode)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.SalePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SalePrice="+SysString.ToDBString(MasterEntity.SalePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SalePrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" SelePriceDesc="+SysString.ToDBString(MasterEntity.SelePriceDesc)+","); 
  				 
  				if(MasterEntity.SalePriceYXDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SalePriceYXDate="+SysString.ToDBString(MasterEntity.SalePriceYXDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SalePriceYXDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" SelePriceRemark="+SysString.ToDBString(MasterEntity.SelePriceRemark)+","); 
  				UpdateBuilder.Append(" JQDesc="+SysString.ToDBString(MasterEntity.JQDesc)+","); 
  				UpdateBuilder.Append(" PBFlag="+SysString.ToDBString(MasterEntity.PBFlag)+","); 
  				 
  				if(MasterEntity.SaleOPPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SaleOPPrice="+SysString.ToDBString(MasterEntity.SaleOPPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SaleOPPrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				 
  				if(MasterEntity.PBPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PBPrice="+SysString.ToDBString(MasterEntity.PBPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PBPrice=null,");  
  				} 
  
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
  				 
  				if(MasterEntity.HZAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" HZAmount="+SysString.ToDBString(MasterEntity.HZAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" HZAmount=null,");  
  				} 
  
  				 
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
  				UpdateBuilder.Append(" ProfitMargin="+SysString.ToDBString(MasterEntity.ProfitMargin)+","); 
  				 
  				if(MasterEntity.AddPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" AddPrice="+SysString.ToDBString(MasterEntity.AddPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddPrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" FK="+SysString.ToDBString(MasterEntity.FK)+","); 
  				UpdateBuilder.Append(" HZType="+SysString.ToDBString(MasterEntity.HZType)+","); 
  				UpdateBuilder.Append(" ItemClassID="+SysString.ToDBString(MasterEntity.ItemClassID)+","); 
  				UpdateBuilder.Append(" DeliveryTime="+SysString.ToDBString(MasterEntity.DeliveryTime)+","); 
  				UpdateBuilder.Append(" MinQty="+SysString.ToDBString(MasterEntity.MinQty)+","); 
  				 
  				if(MasterEntity.PerMiWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PerMiWeight="+SysString.ToDBString(MasterEntity.PerMiWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PerMiWeight=null,");  
  				} 
  
  				UpdateBuilder.Append(" KZ="+SysString.ToDBString(MasterEntity.KZ)+","); 
  				 
  				if(MasterEntity.HL!=0) 
  				{ 
  			 		UpdateBuilder.Append(" HL="+SysString.ToDBString(MasterEntity.HL)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" HL=null,");  
  				} 
  
  				 
  				if(MasterEntity.USDPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" USDPrice="+SysString.ToDBString(MasterEntity.USDPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" USDPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalPriceUSB!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalPriceUSB="+SysString.ToDBString(MasterEntity.TotalPriceUSB)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalPriceUSB=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalPriceRMB!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalPriceRMB="+SysString.ToDBString(MasterEntity.TotalPriceRMB)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalPriceRMB=null,");  
  				} 
  
  				 
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
  
  				 
  				if(MasterEntity.Shrinkage!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Shrinkage="+SysString.ToDBString(MasterEntity.Shrinkage)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Shrinkage=null,");  
  				} 
  
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" MWidth="+SysString.ToDBString(MasterEntity.MWidth)+","); 
  				UpdateBuilder.Append(" MWeight="+SysString.ToDBString(MasterEntity.MWeight)+","); 
  				UpdateBuilder.Append(" VItemCode="+SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				UpdateBuilder.Append(" VColorNum="+SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				UpdateBuilder.Append(" VColorName="+SysString.ToDBString(MasterEntity.VColorName)+","); 
  				 
  				if(MasterEntity.USB!=0) 
  				{ 
  			 		UpdateBuilder.Append(" USB="+SysString.ToDBString(MasterEntity.USB)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" USB=null,");  
  				} 
  
  				UpdateBuilder.Append(" ItemUnit="+SysString.ToDBString(MasterEntity.ItemUnit)+","); 
  				 
  				if(MasterEntity.PackFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PackFee="+SysString.ToDBString(MasterEntity.PackFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PackFee=null,");  
  				} 
  
  				 
  				if(MasterEntity.LiRunFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" LiRunFee="+SysString.ToDBString(MasterEntity.LiRunFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LiRunFee=null,");  
  				} 
  
  				 
  				if(MasterEntity.TradeFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TradeFee="+SysString.ToDBString(MasterEntity.TradeFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TradeFee=null,");  
  				} 
  
  				 
  				if(MasterEntity.YongJin!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YongJin="+SysString.ToDBString(MasterEntity.YongJin)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YongJin=null,");  
  				} 
  
  				UpdateBuilder.Append(" HouZLReq="+SysString.ToDBString(MasterEntity.HouZLReq)+","); 
  				 
  				if(MasterEntity.Fee1!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Fee1="+SysString.ToDBString(MasterEntity.Fee1)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Fee1=null,");  
  				} 
  
  				UpdateBuilder.Append(" Needle="+SysString.ToDBString(MasterEntity.Needle)+","); 
  				 
  				if(MasterEntity.RMB!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RMB="+SysString.ToDBString(MasterEntity.RMB)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RMB=null,");  
  				} 
  
  				 
  				if(MasterEntity.RMBY!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RMBY="+SysString.ToDBString(MasterEntity.RMBY)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RMBY=null,");  
  				} 
  
  				 
  				if(MasterEntity.USBY!=0) 
  				{ 
  			 		UpdateBuilder.Append(" USBY="+SysString.ToDBString(MasterEntity.USBY)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" USBY=null");  
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
                QuotedPriceDts MasterEntity=(QuotedPriceDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Sale_QuotedPriceDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
