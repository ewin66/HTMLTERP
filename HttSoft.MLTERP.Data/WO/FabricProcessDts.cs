using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WO_FabricProcessDts实体类
	/// 作者:zhp
	/// 创建日期:2016/9/22
	/// </summary>
	public sealed class FabricProcessDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public FabricProcessDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FabricProcessDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_FabricProcessDts";
		 
  		private int m_ID = 0; 
  		public int ID 
  		{ 
  			get 
  			{ 
  				return m_ID ; 
  			}  
  			set 
  			{ 
  				m_ID = value ; 
  			}  
  		} 
  
  		private int m_MainID = 0; 
  		public int MainID 
  		{ 
  			get 
  			{ 
  				return m_MainID ; 
  			}  
  			set 
  			{ 
  				m_MainID = value ; 
  			}  
  		} 
  
  		private int m_Seq = 0; 
  		public int Seq 
  		{ 
  			get 
  			{ 
  				return m_Seq ; 
  			}  
  			set 
  			{ 
  				m_Seq = value ; 
  			}  
  		} 
  
  		private string m_ItemCode = string.Empty ; 
  		public string ItemCode 
  		{ 
  			get 
  			{ 
  				return m_ItemCode ; 
  			}  
  			set 
  			{ 
  				m_ItemCode = value ; 
  			}  
  		} 
  
  		private string m_GoodsCode = string.Empty ; 
  		public string GoodsCode 
  		{ 
  			get 
  			{ 
  				return m_GoodsCode ; 
  			}  
  			set 
  			{ 
  				m_GoodsCode = value ; 
  			}  
  		} 
  
  		private string m_ColorNum = string.Empty ; 
  		public string ColorNum 
  		{ 
  			get 
  			{ 
  				return m_ColorNum ; 
  			}  
  			set 
  			{ 
  				m_ColorNum = value ; 
  			}  
  		} 
  
  		private string m_ColorName = string.Empty ; 
  		public string ColorName 
  		{ 
  			get 
  			{ 
  				return m_ColorName ; 
  			}  
  			set 
  			{ 
  				m_ColorName = value ; 
  			}  
  		} 
  
  		private string m_MWidth = string.Empty ; 
  		public string MWidth 
  		{ 
  			get 
  			{ 
  				return m_MWidth ; 
  			}  
  			set 
  			{ 
  				m_MWidth = value ; 
  			}  
  		} 
  
  		private string m_MWeight = string.Empty ; 
  		public string MWeight 
  		{ 
  			get 
  			{ 
  				return m_MWeight ; 
  			}  
  			set 
  			{ 
  				m_MWeight = value ; 
  			}  
  		} 
  
  		private string m_WeightUnit = string.Empty ; 
  		public string WeightUnit 
  		{ 
  			get 
  			{ 
  				return m_WeightUnit ; 
  			}  
  			set 
  			{ 
  				m_WeightUnit = value ; 
  			}  
  		} 
  
  		private string m_ItemName = string.Empty ; 
  		public string ItemName 
  		{ 
  			get 
  			{ 
  				return m_ItemName ; 
  			}  
  			set 
  			{ 
  				m_ItemName = value ; 
  			}  
  		} 
  
  		private string m_VColorNum = string.Empty ; 
  		public string VColorNum 
  		{ 
  			get 
  			{ 
  				return m_VColorNum ; 
  			}  
  			set 
  			{ 
  				m_VColorNum = value ; 
  			}  
  		} 
  
  		private string m_VColorName = string.Empty ; 
  		public string VColorName 
  		{ 
  			get 
  			{ 
  				return m_VColorName ; 
  			}  
  			set 
  			{ 
  				m_VColorName = value ; 
  			}  
  		} 
  
  		private string m_VItemCode = string.Empty ; 
  		public string VItemCode 
  		{ 
  			get 
  			{ 
  				return m_VItemCode ; 
  			}  
  			set 
  			{ 
  				m_VItemCode = value ; 
  			}  
  		} 
  
  		private decimal m_Qty = 0; 
  		public decimal Qty 
  		{ 
  			get 
  			{ 
  				return m_Qty ; 
  			}  
  			set 
  			{ 
  				m_Qty = value ; 
  			}  
  		} 
  
  		private string m_Unit = string.Empty ; 
  		public string Unit 
  		{ 
  			get 
  			{ 
  				return m_Unit ; 
  			}  
  			set 
  			{ 
  				m_Unit = value ; 
  			}  
  		} 
  
  		private decimal m_SingPrice = 0; 
  		public decimal SingPrice 
  		{ 
  			get 
  			{ 
  				return m_SingPrice ; 
  			}  
  			set 
  			{ 
  				m_SingPrice = value ; 
  			}  
  		} 
  
  		private decimal m_Amount = 0; 
  		public decimal Amount 
  		{ 
  			get 
  			{ 
  				return m_Amount ; 
  			}  
  			set 
  			{ 
  				m_Amount = value ; 
  			}  
  		} 
  
  		private DateTime m_ReceivedDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ReceivedDate 
  		{ 
  			get 
  			{ 
  				return m_ReceivedDate ; 
  			}  
  			set 
  			{ 
  				m_ReceivedDate = value ; 
  			}  
  		} 
  
  		private decimal m_ReceivedQty = 0; 
  		public decimal ReceivedQty 
  		{ 
  			get 
  			{ 
  				return m_ReceivedQty ; 
  			}  
  			set 
  			{ 
  				m_ReceivedQty = value ; 
  			}  
  		} 
  
  		private decimal m_TotalRecQty = 0; 
  		public decimal TotalRecQty 
  		{ 
  			get 
  			{ 
  				return m_TotalRecQty ; 
  			}  
  			set 
  			{ 
  				m_TotalRecQty = value ; 
  			}  
  		} 
  
  		private decimal m_RemainQty = 0; 
  		public decimal RemainQty 
  		{ 
  			get 
  			{ 
  				return m_RemainQty ; 
  			}  
  			set 
  			{ 
  				m_RemainQty = value ; 
  			}  
  		} 
  
  		private decimal m_RemainRate = 0; 
  		public decimal RemainRate 
  		{ 
  			get 
  			{ 
  				return m_RemainRate ; 
  			}  
  			set 
  			{ 
  				m_RemainRate = value ; 
  			}  
  		} 
  
  		private DateTime m_DtsReqDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime DtsReqDate 
  		{ 
  			get 
  			{ 
  				return m_DtsReqDate ; 
  			}  
  			set 
  			{ 
  				m_DtsReqDate = value ; 
  			}  
  		} 
  
  		private string m_Remark = string.Empty ; 
  		public string Remark 
  		{ 
  			get 
  			{ 
  				return m_Remark ; 
  			}  
  			set 
  			{ 
  				m_Remark = value ; 
  			}  
  		} 
  
  		private int m_OrderPreStatusID = 0; 
  		public int OrderPreStatusID 
  		{ 
  			get 
  			{ 
  				return m_OrderPreStatusID ; 
  			}  
  			set 
  			{ 
  				m_OrderPreStatusID = value ; 
  			}  
  		} 
  
  		private int m_OrderStatusID = 0; 
  		public int OrderStatusID 
  		{ 
  			get 
  			{ 
  				return m_OrderStatusID ; 
  			}  
  			set 
  			{ 
  				m_OrderStatusID = value ; 
  			}  
  		} 
  
  		private string m_DtsSO = string.Empty ; 
  		public string DtsSO 
  		{ 
  			get 
  			{ 
  				return m_DtsSO ; 
  			}  
  			set 
  			{ 
  				m_DtsSO = value ; 
  			}  
  		} 
  
  		private string m_DVendorID = string.Empty ; 
  		public string DVendorID 
  		{ 
  			get 
  			{ 
  				return m_DVendorID ; 
  			}  
  			set 
  			{ 
  				m_DVendorID = value ; 
  			}  
  		} 
  
  		private decimal m_NLQty = 0; 
  		public decimal NLQty 
  		{ 
  			get 
  			{ 
  				return m_NLQty ; 
  			}  
  			set 
  			{ 
  				m_NLQty = value ; 
  			}  
  		} 
  
  		private DateTime m_NLFormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime NLFormDate 
  		{ 
  			get 
  			{ 
  				return m_NLFormDate ; 
  			}  
  			set 
  			{ 
  				m_NLFormDate = value ; 
  			}  
  		} 
  
  		private decimal m_InQty = 0; 
  		public decimal InQty 
  		{ 
  			get 
  			{ 
  				return m_InQty ; 
  			}  
  			set 
  			{ 
  				m_InQty = value ; 
  			}  
  		} 
  
  		private DateTime m_InFormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime InFormDate 
  		{ 
  			get 
  			{ 
  				return m_InFormDate ; 
  			}  
  			set 
  			{ 
  				m_InFormDate = value ; 
  			}  
  		} 
  
  		private decimal m_OutQty = 0; 
  		public decimal OutQty 
  		{ 
  			get 
  			{ 
  				return m_OutQty ; 
  			}  
  			set 
  			{ 
  				m_OutQty = value ; 
  			}  
  		} 
  
  		private DateTime m_OutFormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime OutFormDate 
  		{ 
  			get 
  			{ 
  				return m_OutFormDate ; 
  			}  
  			set 
  			{ 
  				m_OutFormDate = value ; 
  			}  
  		} 
  
  		private int m_PieceQty = 0; 
  		public int PieceQty 
  		{ 
  			get 
  			{ 
  				return m_PieceQty ; 
  			}  
  			set 
  			{ 
  				m_PieceQty = value ; 
  			}  
  		} 
  
  		private string m_ItemStd = string.Empty ; 
  		public string ItemStd 
  		{ 
  			get 
  			{ 
  				return m_ItemStd ; 
  			}  
  			set 
  			{ 
  				m_ItemStd = value ; 
  			}  
  		} 
  
  		private string m_ItemModel = string.Empty ; 
  		public string ItemModel 
  		{ 
  			get 
  			{ 
  				return m_ItemModel ; 
  			}  
  			set 
  			{ 
  				m_ItemModel = value ; 
  			}  
  		} 
  
  		private string m_GreyFabItemCode = string.Empty ; 
  		public string GreyFabItemCode 
  		{ 
  			get 
  			{ 
  				return m_GreyFabItemCode ; 
  			}  
  			set 
  			{ 
  				m_GreyFabItemCode = value ; 
  			}  
  		} 
  
  		private decimal m_CalNum = 0; 
  		public decimal CalNum 
  		{ 
  			get 
  			{ 
  				return m_CalNum ; 
  			}  
  			set 
  			{ 
  				m_CalNum = value ; 
  			}  
  		} 
  
  		private string m_CalUnit = string.Empty ; 
  		public string CalUnit 
  		{ 
  			get 
  			{ 
  				return m_CalUnit ; 
  			}  
  			set 
  			{ 
  				m_CalUnit = value ; 
  			}  
  		} 
  
  		private string m_DtsRemark = string.Empty ; 
  		public string DtsRemark 
  		{ 
  			get 
  			{ 
  				return m_DtsRemark ; 
  			}  
  			set 
  			{ 
  				m_DtsRemark = value ; 
  			}  
  		} 
  
  		private string m_DesignNo = string.Empty ; 
  		public string DesignNo 
  		{ 
  			get 
  			{ 
  				return m_DesignNo ; 
  			}  
  			set 
  			{ 
  				m_DesignNo = value ; 
  			}  
  		} 
  
  		private string m_EditionOK = string.Empty ; 
  		public string EditionOK 
  		{ 
  			get 
  			{ 
  				return m_EditionOK ; 
  			}  
  			set 
  			{ 
  				m_EditionOK = value ; 
  			}  
  		} 
  
  		private string m_FreeStr1 = string.Empty ; 
  		public string FreeStr1 
  		{ 
  			get 
  			{ 
  				return m_FreeStr1 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr1 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr2 = string.Empty ; 
  		public string FreeStr2 
  		{ 
  			get 
  			{ 
  				return m_FreeStr2 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr2 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr3 = string.Empty ; 
  		public string FreeStr3 
  		{ 
  			get 
  			{ 
  				return m_FreeStr3 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr3 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr4 = string.Empty ; 
  		public string FreeStr4 
  		{ 
  			get 
  			{ 
  				return m_FreeStr4 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr4 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr5 = string.Empty ; 
  		public string FreeStr5 
  		{ 
  			get 
  			{ 
  				return m_FreeStr5 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr5 = value ; 
  			}  
  		} 
  
  		private decimal m_SL = 0; 
  		public decimal SL 
  		{ 
  			get 
  			{ 
  				return m_SL ; 
  			}  
  			set 
  			{ 
  				m_SL = value ; 
  			}  
  		} 
  
  		private decimal m_PBWeight = 0; 
  		public decimal PBWeight 
  		{ 
  			get 
  			{ 
  				return m_PBWeight ; 
  			}  
  			set 
  			{ 
  				m_PBWeight = value ; 
  			}  
  		} 
  
  		private string m_CPItemCode = string.Empty ; 
  		public string CPItemCode 
  		{ 
  			get 
  			{ 
  				return m_CPItemCode ; 
  			}  
  			set 
  			{ 
  				m_CPItemCode = value ; 
  			}  
  		} 
  
  		private string m_CPItemName = string.Empty ; 
  		public string CPItemName 
  		{ 
  			get 
  			{ 
  				return m_CPItemName ; 
  			}  
  			set 
  			{ 
  				m_CPItemName = value ; 
  			}  
  		} 
  
  		private string m_CPItemStd = string.Empty ; 
  		public string CPItemStd 
  		{ 
  			get 
  			{ 
  				return m_CPItemStd ; 
  			}  
  			set 
  			{ 
  				m_CPItemStd = value ; 
  			}  
  		} 
  
  		private string m_CPItemModel = string.Empty ; 
  		public string CPItemModel 
  		{ 
  			get 
  			{ 
  				return m_CPItemModel ; 
  			}  
  			set 
  			{ 
  				m_CPItemModel = value ; 
  			}  
  		} 
  
  		private string m_Machine = string.Empty ; 
  		public string Machine 
  		{ 
  			get 
  			{ 
  				return m_Machine ; 
  			}  
  			set 
  			{ 
  				m_Machine = value ; 
  			}  
  		} 
  
  		private string m_Needle = string.Empty ; 
  		public string Needle 
  		{ 
  			get 
  			{ 
  				return m_Needle ; 
  			}  
  			set 
  			{ 
  				m_Needle = value ; 
  			}  
  		} 
  
  		private string m_DtsAfterFinish = string.Empty ; 
  		public string DtsAfterFinish 
  		{ 
  			get 
  			{ 
  				return m_DtsAfterFinish ; 
  			}  
  			set 
  			{ 
  				m_DtsAfterFinish = value ; 
  			}  
  		} 
  
  		private string m_DtsPackMethod = string.Empty ; 
  		public string DtsPackMethod 
  		{ 
  			get 
  			{ 
  				return m_DtsPackMethod ; 
  			}  
  			set 
  			{ 
  				m_DtsPackMethod = value ; 
  			}  
  		} 
  
  		private decimal m_AddFee = 0; 
  		public decimal AddFee 
  		{ 
  			get 
  			{ 
  				return m_AddFee ; 
  			}  
  			set 
  			{ 
  				m_AddFee = value ; 
  			}  
  		} 
  
  		private decimal m_AddFee2 = 0; 
  		public decimal AddFee2 
  		{ 
  			get 
  			{ 
  				return m_AddFee2 ; 
  			}  
  			set 
  			{ 
  				m_AddFee2 = value ; 
  			}  
  		} 
  
  		private decimal m_AddFee3 = 0; 
  		public decimal AddFee3 
  		{ 
  			get 
  			{ 
  				return m_AddFee3 ; 
  			}  
  			set 
  			{ 
  				m_AddFee3 = value ; 
  			}  
  		} 
  
  		private decimal m_AddFee4 = 0; 
  		public decimal AddFee4 
  		{ 
  			get 
  			{ 
  				return m_AddFee4 ; 
  			}  
  			set 
  			{ 
  				m_AddFee4 = value ; 
  			}  
  		} 
  
  		private decimal m_AddFee5 = 0; 
  		public decimal AddFee5 
  		{ 
  			get 
  			{ 
  				return m_AddFee5 ; 
  			}  
  			set 
  			{ 
  				m_AddFee5 = value ; 
  			}  
  		} 
  
  		private string m_PUnit = string.Empty ; 
  		public string PUnit 
  		{ 
  			get 
  			{ 
  				return m_PUnit ; 
  			}  
  			set 
  			{ 
  				m_PUnit = value ; 
  			}  
  		} 
  
  		private string m_StyleNo = string.Empty ; 
  		public string StyleNo 
  		{ 
  			get 
  			{ 
  				return m_StyleNo ; 
  			}  
  			set 
  			{ 
  				m_StyleNo = value ; 
  			}  
  		} 
  
  		private string m_Batch = string.Empty ; 
  		public string Batch 
  		{ 
  			get 
  			{ 
  				return m_Batch ; 
  			}  
  			set 
  			{ 
  				m_Batch = value ; 
  			}  
  		} 
  
  		private string m_HandleStatus = string.Empty ; 
  		public string HandleStatus 
  		{ 
  			get 
  			{ 
  				return m_HandleStatus ; 
  			}  
  			set 
  			{ 
  				m_HandleStatus = value ; 
  			}  
  		} 
  
  		private DateTime m_HandleStatusDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime HandleStatusDate 
  		{ 
  			get 
  			{ 
  				return m_HandleStatusDate ; 
  			}  
  			set 
  			{ 
  				m_HandleStatusDate = value ; 
  			}  
  		} 
  
  		private string m_AllMWidth = string.Empty ; 
  		public string AllMWidth 
  		{ 
  			get 
  			{ 
  				return m_AllMWidth ; 
  			}  
  			set 
  			{ 
  				m_AllMWidth = value ; 
  			}  
  		} 
  
  		private decimal m_OrderQty = 0; 
  		public decimal OrderQty 
  		{ 
  			get 
  			{ 
  				return m_OrderQty ; 
  			}  
  			set 
  			{ 
  				m_OrderQty = value ; 
  			}  
  		} 
  
  		private string m_OrderUnit = string.Empty ; 
  		public string OrderUnit 
  		{ 
  			get 
  			{ 
  				return m_OrderUnit ; 
  			}  
  			set 
  			{ 
  				m_OrderUnit = value ; 
  			}  
  		} 
  
  		private string m_BCPItemCode = string.Empty ; 
  		public string BCPItemCode 
  		{ 
  			get 
  			{ 
  				return m_BCPItemCode ; 
  			}  
  			set 
  			{ 
  				m_BCPItemCode = value ; 
  			}  
  		} 
  
  		private string m_BCPItemStd = string.Empty ; 
  		public string BCPItemStd 
  		{ 
  			get 
  			{ 
  				return m_BCPItemStd ; 
  			}  
  			set 
  			{ 
  				m_BCPItemStd = value ; 
  			}  
  		} 
  
  		private string m_BCPItemName = string.Empty ; 
  		public string BCPItemName 
  		{ 
  			get 
  			{ 
  				return m_BCPItemName ; 
  			}  
  			set 
  			{ 
  				m_BCPItemName = value ; 
  			}  
  		} 
  
  		private string m_BCPItemModel = string.Empty ; 
  		public string BCPItemModel 
  		{ 
  			get 
  			{ 
  				return m_BCPItemModel ; 
  			}  
  			set 
  			{ 
  				m_BCPItemModel = value ; 
  			}  
  		} 
  
  		private decimal m_PieceWeight = 0; 
  		public decimal PieceWeight 
  		{ 
  			get 
  			{ 
  				return m_PieceWeight ; 
  			}  
  			set 
  			{ 
  				m_PieceWeight = value ; 
  			}  
  		} 
  
  		private string m_BCPColorNum = string.Empty ; 
  		public string BCPColorNum 
  		{ 
  			get 
  			{ 
  				return m_BCPColorNum ; 
  			}  
  			set 
  			{ 
  				m_BCPColorNum = value ; 
  			}  
  		} 
  
  		private string m_BCPColorName = string.Empty ; 
  		public string BCPColorName 
  		{ 
  			get 
  			{ 
  				return m_BCPColorName ; 
  			}  
  			set 
  			{ 
  				m_BCPColorName = value ; 
  			}  
  		} 
  
  		private string m_BCPMWidth = string.Empty ; 
  		public string BCPMWidth 
  		{ 
  			get 
  			{ 
  				return m_BCPMWidth ; 
  			}  
  			set 
  			{ 
  				m_BCPMWidth = value ; 
  			}  
  		} 
  
  		private string m_BCPMWeight = string.Empty ; 
  		public string BCPMWeight 
  		{ 
  			get 
  			{ 
  				return m_BCPMWeight ; 
  			}  
  			set 
  			{ 
  				m_BCPMWeight = value ; 
  			}  
  		} 
  
  		private int m_BoxQty = 0; 
  		public int BoxQty 
  		{ 
  			get 
  			{ 
  				return m_BoxQty ; 
  			}  
  			set 
  			{ 
  				m_BoxQty = value ; 
  			}  
  		} 
  
  		private int m_SetQty = 0; 
  		public int SetQty 
  		{ 
  			get 
  			{ 
  				return m_SetQty ; 
  			}  
  			set 
  			{ 
  				m_SetQty = value ; 
  			}  
  		} 
  
  		private int m_DozensQty = 0; 
  		public int DozensQty 
  		{ 
  			get 
  			{ 
  				return m_DozensQty ; 
  			}  
  			set 
  			{ 
  				m_DozensQty = value ; 
  			}  
  		} 
  
  		private string m_LoadFormNo = string.Empty ; 
  		public string LoadFormNo 
  		{ 
  			get 
  			{ 
  				return m_LoadFormNo ; 
  			}  
  			set 
  			{ 
  				m_LoadFormNo = value ; 
  			}  
  		} 
  
  		private string m_VOrderFormNo = string.Empty ; 
  		public string VOrderFormNo 
  		{ 
  			get 
  			{ 
  				return m_VOrderFormNo ; 
  			}  
  			set 
  			{ 
  				m_VOrderFormNo = value ; 
  			}  
  		} 
  
  		private decimal m_CPInQty = 0; 
  		public decimal CPInQty 
  		{ 
  			get 
  			{ 
  				return m_CPInQty ; 
  			}  
  			set 
  			{ 
  				m_CPInQty = value ; 
  			}  
  		} 
  
  		private DateTime m_CPInDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CPInDate 
  		{ 
  			get 
  			{ 
  				return m_CPInDate ; 
  			}  
  			set 
  			{ 
  				m_CPInDate = value ; 
  			}  
  		} 
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM WO_FabricProcessDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_FabricProcessDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按传入的SQL语句查询后给属性赋值
        /// </summary>
        /// <param name="p_Sql">SQL语句</param>
        /// <returns>记录存在回true，不存在返回false</returns>
        protected override bool Select(string p_Sql)
        {
            DataTable MasterTable=new DataTable();
            if(!this.sqlTransFlag)
			{
				MasterTable=this.Fill(p_Sql);
			}
			else
			{
				MasterTable=sqlTrans.Fill(p_Sql);
			}
				
            if (MasterTable.Rows.Count>0)
            {
                //查询主表记录
                m_ID=SysConvert.ToInt32(MasterTable.Rows[0]["ID"]); 
  				m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_MWidth=SysConvert.ToString(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToString(MasterTable.Rows[0]["MWeight"]); 
  				m_WeightUnit=SysConvert.ToString(MasterTable.Rows[0]["WeightUnit"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_VColorNum=SysConvert.ToString(MasterTable.Rows[0]["VColorNum"]); 
  				m_VColorName=SysConvert.ToString(MasterTable.Rows[0]["VColorName"]); 
  				m_VItemCode=SysConvert.ToString(MasterTable.Rows[0]["VItemCode"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_SingPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SingPrice"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
  				m_ReceivedDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ReceivedDate"]); 
  				m_ReceivedQty=SysConvert.ToDecimal(MasterTable.Rows[0]["ReceivedQty"]); 
  				m_TotalRecQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalRecQty"]); 
  				m_RemainQty=SysConvert.ToDecimal(MasterTable.Rows[0]["RemainQty"]); 
  				m_RemainRate=SysConvert.ToDecimal(MasterTable.Rows[0]["RemainRate"]); 
  				m_DtsReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["DtsReqDate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_OrderPreStatusID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderPreStatusID"]); 
  				m_OrderStatusID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderStatusID"]); 
  				m_DtsSO=SysConvert.ToString(MasterTable.Rows[0]["DtsSO"]); 
  				m_DVendorID=SysConvert.ToString(MasterTable.Rows[0]["DVendorID"]); 
  				m_NLQty=SysConvert.ToDecimal(MasterTable.Rows[0]["NLQty"]); 
  				m_NLFormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["NLFormDate"]); 
  				m_InQty=SysConvert.ToDecimal(MasterTable.Rows[0]["InQty"]); 
  				m_InFormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["InFormDate"]); 
  				m_OutQty=SysConvert.ToDecimal(MasterTable.Rows[0]["OutQty"]); 
  				m_OutFormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["OutFormDate"]); 
  				m_PieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["PieceQty"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_GreyFabItemCode=SysConvert.ToString(MasterTable.Rows[0]["GreyFabItemCode"]); 
  				m_CalNum=SysConvert.ToDecimal(MasterTable.Rows[0]["CalNum"]); 
  				m_CalUnit=SysConvert.ToString(MasterTable.Rows[0]["CalUnit"]); 
  				m_DtsRemark=SysConvert.ToString(MasterTable.Rows[0]["DtsRemark"]); 
  				m_DesignNo=SysConvert.ToString(MasterTable.Rows[0]["DesignNo"]); 
  				m_EditionOK=SysConvert.ToString(MasterTable.Rows[0]["EditionOK"]); 
  				m_FreeStr1=SysConvert.ToString(MasterTable.Rows[0]["FreeStr1"]); 
  				m_FreeStr2=SysConvert.ToString(MasterTable.Rows[0]["FreeStr2"]); 
  				m_FreeStr3=SysConvert.ToString(MasterTable.Rows[0]["FreeStr3"]); 
  				m_FreeStr4=SysConvert.ToString(MasterTable.Rows[0]["FreeStr4"]); 
  				m_FreeStr5=SysConvert.ToString(MasterTable.Rows[0]["FreeStr5"]); 
  				m_SL=SysConvert.ToDecimal(MasterTable.Rows[0]["SL"]); 
  				m_PBWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["PBWeight"]); 
  				m_CPItemCode=SysConvert.ToString(MasterTable.Rows[0]["CPItemCode"]); 
  				m_CPItemName=SysConvert.ToString(MasterTable.Rows[0]["CPItemName"]); 
  				m_CPItemStd=SysConvert.ToString(MasterTable.Rows[0]["CPItemStd"]); 
  				m_CPItemModel=SysConvert.ToString(MasterTable.Rows[0]["CPItemModel"]); 
  				m_Machine=SysConvert.ToString(MasterTable.Rows[0]["Machine"]); 
  				m_Needle=SysConvert.ToString(MasterTable.Rows[0]["Needle"]); 
  				m_DtsAfterFinish=SysConvert.ToString(MasterTable.Rows[0]["DtsAfterFinish"]); 
  				m_DtsPackMethod=SysConvert.ToString(MasterTable.Rows[0]["DtsPackMethod"]); 
  				m_AddFee=SysConvert.ToDecimal(MasterTable.Rows[0]["AddFee"]); 
  				m_AddFee2=SysConvert.ToDecimal(MasterTable.Rows[0]["AddFee2"]); 
  				m_AddFee3=SysConvert.ToDecimal(MasterTable.Rows[0]["AddFee3"]); 
  				m_AddFee4=SysConvert.ToDecimal(MasterTable.Rows[0]["AddFee4"]); 
  				m_AddFee5=SysConvert.ToDecimal(MasterTable.Rows[0]["AddFee5"]); 
  				m_PUnit=SysConvert.ToString(MasterTable.Rows[0]["PUnit"]); 
  				m_StyleNo=SysConvert.ToString(MasterTable.Rows[0]["StyleNo"]); 
  				m_Batch=SysConvert.ToString(MasterTable.Rows[0]["Batch"]); 
  				m_HandleStatus=SysConvert.ToString(MasterTable.Rows[0]["HandleStatus"]); 
  				m_HandleStatusDate=SysConvert.ToDateTime(MasterTable.Rows[0]["HandleStatusDate"]); 
  				m_AllMWidth=SysConvert.ToString(MasterTable.Rows[0]["AllMWidth"]); 
  				m_OrderQty=SysConvert.ToDecimal(MasterTable.Rows[0]["OrderQty"]); 
  				m_OrderUnit=SysConvert.ToString(MasterTable.Rows[0]["OrderUnit"]); 
  				m_BCPItemCode=SysConvert.ToString(MasterTable.Rows[0]["BCPItemCode"]); 
  				m_BCPItemStd=SysConvert.ToString(MasterTable.Rows[0]["BCPItemStd"]); 
  				m_BCPItemName=SysConvert.ToString(MasterTable.Rows[0]["BCPItemName"]); 
  				m_BCPItemModel=SysConvert.ToString(MasterTable.Rows[0]["BCPItemModel"]); 
  				m_PieceWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["PieceWeight"]); 
  				m_BCPColorNum=SysConvert.ToString(MasterTable.Rows[0]["BCPColorNum"]); 
  				m_BCPColorName=SysConvert.ToString(MasterTable.Rows[0]["BCPColorName"]); 
  				m_BCPMWidth=SysConvert.ToString(MasterTable.Rows[0]["BCPMWidth"]); 
  				m_BCPMWeight=SysConvert.ToString(MasterTable.Rows[0]["BCPMWeight"]); 
  				m_BoxQty=SysConvert.ToInt32(MasterTable.Rows[0]["BoxQty"]); 
  				m_SetQty=SysConvert.ToInt32(MasterTable.Rows[0]["SetQty"]); 
  				m_DozensQty=SysConvert.ToInt32(MasterTable.Rows[0]["DozensQty"]); 
  				m_LoadFormNo=SysConvert.ToString(MasterTable.Rows[0]["LoadFormNo"]); 
  				m_VOrderFormNo=SysConvert.ToString(MasterTable.Rows[0]["VOrderFormNo"]); 
  				m_CPInQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CPInQty"]); 
  				m_CPInDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CPInDate"]); 
                MasterTable.Dispose();
                return true;
            }
            else
            {
                MasterTable.Dispose();
                return false;
            }
        }
	}
}
