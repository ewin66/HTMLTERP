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
	/// 目的：Sale_SaleOrderDts实体控制类
	/// 作者:zhp
	/// 创建日期:2016/8/29
	/// </summary>
	public sealed class SaleOrderDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public SaleOrderDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SaleOrderDtsCtl(IDBTransAccess p_SqlCmd)
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
                SaleOrderDts MasterEntity=(SaleOrderDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Sale_SaleOrderDts(");
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
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
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
  
  				MasterField.Append("OrderPreStepID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderPreStepID)+","); 
  				MasterField.Append("OrderStepID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderStepID)+","); 
  				MasterField.Append("DtsReqDate"+","); 
  				if(MasterEntity.DtsReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DtsReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("PSCGQty"+","); 
  				if(MasterEntity.PSCGQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PSCGQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PBCGQty"+","); 
  				if(MasterEntity.PBCGQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PBCGQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CPCGQty"+","); 
  				if(MasterEntity.CPCGQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CPCGQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("CapFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CapFlag)+","); 
  				MasterField.Append("DYPrice"+","); 
  				if(MasterEntity.DYPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DYPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BGNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BGNo)+","); 
  				MasterField.Append("FAmount1"+","); 
  				if(MasterEntity.FAmount1!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FAmount1)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FAmount2"+","); 
  				if(MasterEntity.FAmount2!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FAmount2)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FAmount3"+","); 
  				if(MasterEntity.FAmount3!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FAmount3)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FAmount4"+","); 
  				if(MasterEntity.FAmount4!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FAmount4)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FAmount5"+","); 
  				if(MasterEntity.FAmount5!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FAmount5)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FAmount6"+","); 
  				if(MasterEntity.FAmount6!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FAmount6)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("YarnCalcFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YarnCalcFlag)+","); 
  				MasterField.Append("FabricCalcFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FabricCalcFlag)+","); 
  				MasterField.Append("ZS"+","); 
  				if(MasterEntity.ZS!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ZS)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InputQty"+","); 
  				if(MasterEntity.InputQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InputQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InputUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InputUnit)+","); 
  				MasterField.Append("InputSinglePrice"+","); 
  				if(MasterEntity.InputSinglePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InputSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InputAmount"+","); 
  				if(MasterEntity.InputAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InputAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InputConvertXS"+","); 
  				if(MasterEntity.InputConvertXS!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InputConvertXS)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CompSiteCalFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompSiteCalFlag)+","); 
  				MasterField.Append("PieceQty"+","); 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ReceivedPieceQty"+","); 
  				if(MasterEntity.ReceivedPieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReceivedPieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalRecPieceQty"+","); 
  				if(MasterEntity.TotalRecPieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalRecPieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AllMWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AllMWidth)+","); 
  				MasterField.Append("Needle"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Needle)+","); 
  				MasterField.Append("ReceiveAmount"+","); 
  				if(MasterEntity.ReceiveAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReceiveAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OutRange"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OutRange)+","); 
  				MasterField.Append("FK"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FK)+","); 
  				MasterField.Append("MaxQty"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MaxQty)+","); 
  				MasterField.Append("MinQty"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MinQty)+","); 
  				MasterField.Append("Pos"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Pos)+","); 
  				MasterField.Append("OrderNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderNo)+","); 
  				MasterField.Append("VRCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VRCode)+","); 
  				MasterField.Append("Currency"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Currency)+","); 
  				MasterField.Append("StyleNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StyleNo)+","); 
  				MasterField.Append("ReqDateEdit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ReqDateEdit)+","); 
  				MasterField.Append("Weight"+","); 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ReceivedWeight"+","); 
  				if(MasterEntity.ReceivedWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReceivedWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalRecWeight"+","); 
  				if(MasterEntity.TotalRecWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalRecWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("StatusFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StatusFlag)+","); 
  				MasterField.Append("StatusName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StatusName)+","); 
  				MasterField.Append("Yard"+","); 
  				if(MasterEntity.Yard!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Yard)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ReceivedYard"+","); 
  				if(MasterEntity.ReceivedYard!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReceivedYard)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalRecYard"+","); 
  				if(MasterEntity.TotalRecYard!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalRecYard)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PieceLength"+","); 
  				if(MasterEntity.PieceLength!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PieceLength)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
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
                SaleOrderDts MasterEntity=(SaleOrderDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Sale_SaleOrderDts SET ");
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
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
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
  
  				UpdateBuilder.Append(" OrderPreStepID="+SysString.ToDBString(MasterEntity.OrderPreStepID)+","); 
  				UpdateBuilder.Append(" OrderStepID="+SysString.ToDBString(MasterEntity.OrderStepID)+","); 
  				 
  				if(MasterEntity.DtsReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" DtsReqDate="+SysString.ToDBString(MasterEntity.DtsReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DtsReqDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.PSCGQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PSCGQty="+SysString.ToDBString(MasterEntity.PSCGQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PSCGQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.PBCGQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PBCGQty="+SysString.ToDBString(MasterEntity.PBCGQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PBCGQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.CPCGQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CPCGQty="+SysString.ToDBString(MasterEntity.CPCGQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CPCGQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" CapFlag="+SysString.ToDBString(MasterEntity.CapFlag)+","); 
  				 
  				if(MasterEntity.DYPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DYPrice="+SysString.ToDBString(MasterEntity.DYPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DYPrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" BGNo="+SysString.ToDBString(MasterEntity.BGNo)+","); 
  				 
  				if(MasterEntity.FAmount1!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FAmount1="+SysString.ToDBString(MasterEntity.FAmount1)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FAmount1=null,");  
  				} 
  
  				 
  				if(MasterEntity.FAmount2!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FAmount2="+SysString.ToDBString(MasterEntity.FAmount2)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FAmount2=null,");  
  				} 
  
  				 
  				if(MasterEntity.FAmount3!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FAmount3="+SysString.ToDBString(MasterEntity.FAmount3)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FAmount3=null,");  
  				} 
  
  				 
  				if(MasterEntity.FAmount4!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FAmount4="+SysString.ToDBString(MasterEntity.FAmount4)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FAmount4=null,");  
  				} 
  
  				 
  				if(MasterEntity.FAmount5!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FAmount5="+SysString.ToDBString(MasterEntity.FAmount5)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FAmount5=null,");  
  				} 
  
  				 
  				if(MasterEntity.FAmount6!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FAmount6="+SysString.ToDBString(MasterEntity.FAmount6)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FAmount6=null,");  
  				} 
  
  				UpdateBuilder.Append(" YarnCalcFlag="+SysString.ToDBString(MasterEntity.YarnCalcFlag)+","); 
  				UpdateBuilder.Append(" FabricCalcFlag="+SysString.ToDBString(MasterEntity.FabricCalcFlag)+","); 
  				 
  				if(MasterEntity.ZS!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ZS="+SysString.ToDBString(MasterEntity.ZS)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ZS=null,");  
  				} 
  
  				 
  				if(MasterEntity.InputQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InputQty="+SysString.ToDBString(MasterEntity.InputQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InputQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" InputUnit="+SysString.ToDBString(MasterEntity.InputUnit)+","); 
  				 
  				if(MasterEntity.InputSinglePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InputSinglePrice="+SysString.ToDBString(MasterEntity.InputSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InputSinglePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.InputAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InputAmount="+SysString.ToDBString(MasterEntity.InputAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InputAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.InputConvertXS!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InputConvertXS="+SysString.ToDBString(MasterEntity.InputConvertXS)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InputConvertXS=null,");  
  				} 
  
  				UpdateBuilder.Append(" CompSiteCalFlag="+SysString.ToDBString(MasterEntity.CompSiteCalFlag)+","); 
  				 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty="+SysString.ToDBString(MasterEntity.PieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.ReceivedPieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedPieceQty="+SysString.ToDBString(MasterEntity.ReceivedPieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedPieceQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalRecPieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalRecPieceQty="+SysString.ToDBString(MasterEntity.TotalRecPieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalRecPieceQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" AllMWidth="+SysString.ToDBString(MasterEntity.AllMWidth)+","); 
  				UpdateBuilder.Append(" Needle="+SysString.ToDBString(MasterEntity.Needle)+","); 
  				 
  				if(MasterEntity.ReceiveAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ReceiveAmount="+SysString.ToDBString(MasterEntity.ReceiveAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReceiveAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" OutRange="+SysString.ToDBString(MasterEntity.OutRange)+","); 
  				UpdateBuilder.Append(" FK="+SysString.ToDBString(MasterEntity.FK)+","); 
  				UpdateBuilder.Append(" MaxQty="+SysString.ToDBString(MasterEntity.MaxQty)+","); 
  				UpdateBuilder.Append(" MinQty="+SysString.ToDBString(MasterEntity.MinQty)+","); 
  				UpdateBuilder.Append(" Pos="+SysString.ToDBString(MasterEntity.Pos)+","); 
  				UpdateBuilder.Append(" OrderNo="+SysString.ToDBString(MasterEntity.OrderNo)+","); 
  				UpdateBuilder.Append(" VRCode="+SysString.ToDBString(MasterEntity.VRCode)+","); 
  				UpdateBuilder.Append(" Currency="+SysString.ToDBString(MasterEntity.Currency)+","); 
  				UpdateBuilder.Append(" StyleNo="+SysString.ToDBString(MasterEntity.StyleNo)+","); 
  				UpdateBuilder.Append(" ReqDateEdit="+SysString.ToDBString(MasterEntity.ReqDateEdit)+","); 
  				 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Weight="+SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Weight=null,");  
  				} 
  
  				 
  				if(MasterEntity.ReceivedWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedWeight="+SysString.ToDBString(MasterEntity.ReceivedWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalRecWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalRecWeight="+SysString.ToDBString(MasterEntity.TotalRecWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalRecWeight=null,");  
  				} 
  
  				UpdateBuilder.Append(" StatusFlag="+SysString.ToDBString(MasterEntity.StatusFlag)+","); 
  				UpdateBuilder.Append(" StatusName="+SysString.ToDBString(MasterEntity.StatusName)+","); 
  				 
  				if(MasterEntity.Yard!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Yard="+SysString.ToDBString(MasterEntity.Yard)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Yard=null,");  
  				} 
  
  				 
  				if(MasterEntity.ReceivedYard!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedYard="+SysString.ToDBString(MasterEntity.ReceivedYard)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedYard=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalRecYard!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalRecYard="+SysString.ToDBString(MasterEntity.TotalRecYard)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalRecYard=null,");  
  				} 
  
  				 
  				if(MasterEntity.PieceLength!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PieceLength="+SysString.ToDBString(MasterEntity.PieceLength)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PieceLength=null,");  
  				} 
  
  				 
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
                SaleOrderDts MasterEntity=(SaleOrderDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Sale_SaleOrderDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
