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
	/// 目的：Buy_ItemBuyFormDts实体控制类
	/// 作者:zhp
	/// 创建日期:2016/8/29
	/// </summary>
	public sealed class ItemBuyFormDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ItemBuyFormDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemBuyFormDtsCtl(IDBTransAccess p_SqlCmd)
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
                ItemBuyFormDts MasterEntity=(ItemBuyFormDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Buy_ItemBuyFormDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("GoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("MWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth)+","); 
  				MasterField.Append("MWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight)+","); 
  				MasterField.Append("WeightUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WeightUnit)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("VColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				MasterField.Append("VColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorName)+","); 
  				MasterField.Append("VItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				MasterField.Append("Qty"+","); 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("SingPrice"+","); 
  				if(MasterEntity.SingPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SingPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Amount"+","); 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ReceivedDate"+","); 
  				if(MasterEntity.ReceivedDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReceivedDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ReceivedQty"+","); 
  				if(MasterEntity.ReceivedQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReceivedQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalRecQty"+","); 
  				if(MasterEntity.TotalRecQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalRecQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RemainQty"+","); 
  				if(MasterEntity.RemainQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RemainQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RemainRate"+","); 
  				if(MasterEntity.RemainRate!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RemainRate)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OrderPreStatusID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderPreStatusID)+","); 
  				MasterField.Append("OrderStatusID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderStatusID)+","); 
  				MasterField.Append("DtsSO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsSO)+","); 
  				MasterField.Append("DVendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DVendorID)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("Batch"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Batch)+","); 
  				MasterField.Append("VendorBatch"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorBatch)+","); 
  				MasterField.Append("YarnType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YarnType)+","); 
  				MasterField.Append("DLoadID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DLoadID)+","); 
  				MasterField.Append("BGNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BGNo)+","); 
  				MasterField.Append("PieceQty"+","); 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Weight"+","); 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CPItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemCode)+","); 
  				MasterField.Append("CPItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemName)+","); 
  				MasterField.Append("CPItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemStd)+","); 
  				MasterField.Append("CPItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemModel)+","); 
  				MasterField.Append("DtsRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsRemark)+","); 
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
  				MasterField.Append("Needle"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Needle)+","); 
  				MasterField.Append("AddFee"+","); 
  				if(MasterEntity.AddFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AddFee2"+","); 
  				if(MasterEntity.AddFee2!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddFee2)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AddFee3"+","); 
  				if(MasterEntity.AddFee3!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddFee3)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AddFee4"+","); 
  				if(MasterEntity.AddFee4!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddFee4)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AddFee5"+","); 
  				if(MasterEntity.AddFee5!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddFee5)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AddFee6"+","); 
  				if(MasterEntity.AddFee6!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddFee6)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Currency"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Currency)+","); 
  				MasterField.Append("StyleNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StyleNo)+","); 
  				MasterField.Append("OrderUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderUnit)+","); 
  				MasterField.Append("OrderQty"+","); 
  				if(MasterEntity.OrderQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OrderQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BCPItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPItemCode)+","); 
  				MasterField.Append("BCPItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPItemStd)+","); 
  				MasterField.Append("BCPItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPItemName)+","); 
  				MasterField.Append("BCPItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPItemModel)+","); 
  				MasterField.Append("OrderSinglePrice"+","); 
  				if(MasterEntity.OrderSinglePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OrderSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BCPColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPColorNum)+","); 
  				MasterField.Append("BCPColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPColorName)+","); 
  				MasterField.Append("BCPMWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPMWidth)+","); 
  				MasterField.Append("BCPMWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPMWeight)+","); 
  				MasterField.Append("BoxQty"+","); 
  				if(MasterEntity.BoxQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BoxQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SetQty"+","); 
  				if(MasterEntity.SetQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SetQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DozensQty"+")"); 
  				if(MasterEntity.DozensQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DozensQty)+")"); 
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
                ItemBuyFormDts MasterEntity=(ItemBuyFormDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Buy_ItemBuyFormDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" GoodsCode="+SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" MWidth="+SysString.ToDBString(MasterEntity.MWidth)+","); 
  				UpdateBuilder.Append(" MWeight="+SysString.ToDBString(MasterEntity.MWeight)+","); 
  				UpdateBuilder.Append(" WeightUnit="+SysString.ToDBString(MasterEntity.WeightUnit)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" VColorNum="+SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				UpdateBuilder.Append(" VColorName="+SysString.ToDBString(MasterEntity.VColorName)+","); 
  				UpdateBuilder.Append(" VItemCode="+SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				 
  				if(MasterEntity.SingPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SingPrice="+SysString.ToDBString(MasterEntity.SingPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SingPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Amount="+SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Amount=null,");  
  				} 
  
  				 
  				if(MasterEntity.ReceivedDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedDate="+SysString.ToDBString(MasterEntity.ReceivedDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.ReceivedQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedQty="+SysString.ToDBString(MasterEntity.ReceivedQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalRecQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalRecQty="+SysString.ToDBString(MasterEntity.TotalRecQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalRecQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.RemainQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RemainQty="+SysString.ToDBString(MasterEntity.RemainQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RemainQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.RemainRate!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RemainRate="+SysString.ToDBString(MasterEntity.RemainRate)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RemainRate=null,");  
  				} 
  
  				UpdateBuilder.Append(" OrderPreStatusID="+SysString.ToDBString(MasterEntity.OrderPreStatusID)+","); 
  				UpdateBuilder.Append(" OrderStatusID="+SysString.ToDBString(MasterEntity.OrderStatusID)+","); 
  				UpdateBuilder.Append(" DtsSO="+SysString.ToDBString(MasterEntity.DtsSO)+","); 
  				UpdateBuilder.Append(" DVendorID="+SysString.ToDBString(MasterEntity.DVendorID)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" Batch="+SysString.ToDBString(MasterEntity.Batch)+","); 
  				UpdateBuilder.Append(" VendorBatch="+SysString.ToDBString(MasterEntity.VendorBatch)+","); 
  				UpdateBuilder.Append(" YarnType="+SysString.ToDBString(MasterEntity.YarnType)+","); 
  				UpdateBuilder.Append(" DLoadID="+SysString.ToDBString(MasterEntity.DLoadID)+","); 
  				UpdateBuilder.Append(" BGNo="+SysString.ToDBString(MasterEntity.BGNo)+","); 
  				 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty="+SysString.ToDBString(MasterEntity.PieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Weight="+SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Weight=null,");  
  				} 
  
  				UpdateBuilder.Append(" CPItemCode="+SysString.ToDBString(MasterEntity.CPItemCode)+","); 
  				UpdateBuilder.Append(" CPItemName="+SysString.ToDBString(MasterEntity.CPItemName)+","); 
  				UpdateBuilder.Append(" CPItemStd="+SysString.ToDBString(MasterEntity.CPItemStd)+","); 
  				UpdateBuilder.Append(" CPItemModel="+SysString.ToDBString(MasterEntity.CPItemModel)+","); 
  				UpdateBuilder.Append(" DtsRemark="+SysString.ToDBString(MasterEntity.DtsRemark)+","); 
  				UpdateBuilder.Append(" FreeStr1="+SysString.ToDBString(MasterEntity.FreeStr1)+","); 
  				UpdateBuilder.Append(" FreeStr2="+SysString.ToDBString(MasterEntity.FreeStr2)+","); 
  				UpdateBuilder.Append(" FreeStr3="+SysString.ToDBString(MasterEntity.FreeStr3)+","); 
  				UpdateBuilder.Append(" FreeStr4="+SysString.ToDBString(MasterEntity.FreeStr4)+","); 
  				UpdateBuilder.Append(" FreeStr5="+SysString.ToDBString(MasterEntity.FreeStr5)+","); 
  				UpdateBuilder.Append(" Needle="+SysString.ToDBString(MasterEntity.Needle)+","); 
  				 
  				if(MasterEntity.AddFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" AddFee="+SysString.ToDBString(MasterEntity.AddFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddFee=null,");  
  				} 
  
  				 
  				if(MasterEntity.AddFee2!=0) 
  				{ 
  			 		UpdateBuilder.Append(" AddFee2="+SysString.ToDBString(MasterEntity.AddFee2)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddFee2=null,");  
  				} 
  
  				 
  				if(MasterEntity.AddFee3!=0) 
  				{ 
  			 		UpdateBuilder.Append(" AddFee3="+SysString.ToDBString(MasterEntity.AddFee3)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddFee3=null,");  
  				} 
  
  				 
  				if(MasterEntity.AddFee4!=0) 
  				{ 
  			 		UpdateBuilder.Append(" AddFee4="+SysString.ToDBString(MasterEntity.AddFee4)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddFee4=null,");  
  				} 
  
  				 
  				if(MasterEntity.AddFee5!=0) 
  				{ 
  			 		UpdateBuilder.Append(" AddFee5="+SysString.ToDBString(MasterEntity.AddFee5)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddFee5=null,");  
  				} 
  
  				 
  				if(MasterEntity.AddFee6!=0) 
  				{ 
  			 		UpdateBuilder.Append(" AddFee6="+SysString.ToDBString(MasterEntity.AddFee6)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddFee6=null,");  
  				} 
  
  				UpdateBuilder.Append(" Currency="+SysString.ToDBString(MasterEntity.Currency)+","); 
  				UpdateBuilder.Append(" StyleNo="+SysString.ToDBString(MasterEntity.StyleNo)+","); 
  				UpdateBuilder.Append(" OrderUnit="+SysString.ToDBString(MasterEntity.OrderUnit)+","); 
  				 
  				if(MasterEntity.OrderQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" OrderQty="+SysString.ToDBString(MasterEntity.OrderQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OrderQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" BCPItemCode="+SysString.ToDBString(MasterEntity.BCPItemCode)+","); 
  				UpdateBuilder.Append(" BCPItemStd="+SysString.ToDBString(MasterEntity.BCPItemStd)+","); 
  				UpdateBuilder.Append(" BCPItemName="+SysString.ToDBString(MasterEntity.BCPItemName)+","); 
  				UpdateBuilder.Append(" BCPItemModel="+SysString.ToDBString(MasterEntity.BCPItemModel)+","); 
  				 
  				if(MasterEntity.OrderSinglePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" OrderSinglePrice="+SysString.ToDBString(MasterEntity.OrderSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OrderSinglePrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" BCPColorNum="+SysString.ToDBString(MasterEntity.BCPColorNum)+","); 
  				UpdateBuilder.Append(" BCPColorName="+SysString.ToDBString(MasterEntity.BCPColorName)+","); 
  				UpdateBuilder.Append(" BCPMWidth="+SysString.ToDBString(MasterEntity.BCPMWidth)+","); 
  				UpdateBuilder.Append(" BCPMWeight="+SysString.ToDBString(MasterEntity.BCPMWeight)+","); 
  				 
  				if(MasterEntity.BoxQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BoxQty="+SysString.ToDBString(MasterEntity.BoxQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BoxQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.SetQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SetQty="+SysString.ToDBString(MasterEntity.SetQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SetQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.DozensQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DozensQty="+SysString.ToDBString(MasterEntity.DozensQty)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DozensQty=null");  
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
                ItemBuyFormDts MasterEntity=(ItemBuyFormDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Buy_ItemBuyFormDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
