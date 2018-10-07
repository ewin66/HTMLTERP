using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Buy_ItemBuyFormDts实体类
	/// 作者:zhp
	/// 创建日期:2016/8/29
	/// </summary>
	public sealed class ItemBuyFormDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemBuyFormDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemBuyFormDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Buy_ItemBuyFormDts";
		 
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
  
  		private string m_VendorBatch = string.Empty ; 
  		public string VendorBatch 
  		{ 
  			get 
  			{ 
  				return m_VendorBatch ; 
  			}  
  			set 
  			{ 
  				m_VendorBatch = value ; 
  			}  
  		} 
  
  		private string m_YarnType = string.Empty ; 
  		public string YarnType 
  		{ 
  			get 
  			{ 
  				return m_YarnType ; 
  			}  
  			set 
  			{ 
  				m_YarnType = value ; 
  			}  
  		} 
  
  		private int m_DLoadID = 0; 
  		public int DLoadID 
  		{ 
  			get 
  			{ 
  				return m_DLoadID ; 
  			}  
  			set 
  			{ 
  				m_DLoadID = value ; 
  			}  
  		} 
  
  		private string m_BGNo = string.Empty ; 
  		public string BGNo 
  		{ 
  			get 
  			{ 
  				return m_BGNo ; 
  			}  
  			set 
  			{ 
  				m_BGNo = value ; 
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
  
  		private decimal m_Weight = 0; 
  		public decimal Weight 
  		{ 
  			get 
  			{ 
  				return m_Weight ; 
  			}  
  			set 
  			{ 
  				m_Weight = value ; 
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
  
  		private decimal m_AddFee6 = 0; 
  		public decimal AddFee6 
  		{ 
  			get 
  			{ 
  				return m_AddFee6 ; 
  			}  
  			set 
  			{ 
  				m_AddFee6 = value ; 
  			}  
  		} 
  
  		private string m_Currency = string.Empty ; 
  		public string Currency 
  		{ 
  			get 
  			{ 
  				return m_Currency ; 
  			}  
  			set 
  			{ 
  				m_Currency = value ; 
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
  
  		private decimal m_OrderSinglePrice = 0; 
  		public decimal OrderSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_OrderSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_OrderSinglePrice = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Buy_ItemBuyFormDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Buy_ItemBuyFormDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_OrderPreStatusID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderPreStatusID"]); 
  				m_OrderStatusID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderStatusID"]); 
  				m_DtsSO=SysConvert.ToString(MasterTable.Rows[0]["DtsSO"]); 
  				m_DVendorID=SysConvert.ToString(MasterTable.Rows[0]["DVendorID"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_Batch=SysConvert.ToString(MasterTable.Rows[0]["Batch"]); 
  				m_VendorBatch=SysConvert.ToString(MasterTable.Rows[0]["VendorBatch"]); 
  				m_YarnType=SysConvert.ToString(MasterTable.Rows[0]["YarnType"]); 
  				m_DLoadID=SysConvert.ToInt32(MasterTable.Rows[0]["DLoadID"]); 
  				m_BGNo=SysConvert.ToString(MasterTable.Rows[0]["BGNo"]); 
  				m_PieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["PieceQty"]); 
  				m_Weight=SysConvert.ToDecimal(MasterTable.Rows[0]["Weight"]); 
  				m_CPItemCode=SysConvert.ToString(MasterTable.Rows[0]["CPItemCode"]); 
  				m_CPItemName=SysConvert.ToString(MasterTable.Rows[0]["CPItemName"]); 
  				m_CPItemStd=SysConvert.ToString(MasterTable.Rows[0]["CPItemStd"]); 
  				m_CPItemModel=SysConvert.ToString(MasterTable.Rows[0]["CPItemModel"]); 
  				m_DtsRemark=SysConvert.ToString(MasterTable.Rows[0]["DtsRemark"]); 
  				m_FreeStr1=SysConvert.ToString(MasterTable.Rows[0]["FreeStr1"]); 
  				m_FreeStr2=SysConvert.ToString(MasterTable.Rows[0]["FreeStr2"]); 
  				m_FreeStr3=SysConvert.ToString(MasterTable.Rows[0]["FreeStr3"]); 
  				m_FreeStr4=SysConvert.ToString(MasterTable.Rows[0]["FreeStr4"]); 
  				m_FreeStr5=SysConvert.ToString(MasterTable.Rows[0]["FreeStr5"]); 
  				m_Needle=SysConvert.ToString(MasterTable.Rows[0]["Needle"]); 
  				m_AddFee=SysConvert.ToDecimal(MasterTable.Rows[0]["AddFee"]); 
  				m_AddFee2=SysConvert.ToDecimal(MasterTable.Rows[0]["AddFee2"]); 
  				m_AddFee3=SysConvert.ToDecimal(MasterTable.Rows[0]["AddFee3"]); 
  				m_AddFee4=SysConvert.ToDecimal(MasterTable.Rows[0]["AddFee4"]); 
  				m_AddFee5=SysConvert.ToDecimal(MasterTable.Rows[0]["AddFee5"]); 
  				m_AddFee6=SysConvert.ToDecimal(MasterTable.Rows[0]["AddFee6"]); 
  				m_Currency=SysConvert.ToString(MasterTable.Rows[0]["Currency"]); 
  				m_StyleNo=SysConvert.ToString(MasterTable.Rows[0]["StyleNo"]); 
  				m_OrderUnit=SysConvert.ToString(MasterTable.Rows[0]["OrderUnit"]); 
  				m_OrderQty=SysConvert.ToDecimal(MasterTable.Rows[0]["OrderQty"]); 
  				m_BCPItemCode=SysConvert.ToString(MasterTable.Rows[0]["BCPItemCode"]); 
  				m_BCPItemStd=SysConvert.ToString(MasterTable.Rows[0]["BCPItemStd"]); 
  				m_BCPItemName=SysConvert.ToString(MasterTable.Rows[0]["BCPItemName"]); 
  				m_BCPItemModel=SysConvert.ToString(MasterTable.Rows[0]["BCPItemModel"]); 
  				m_OrderSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["OrderSinglePrice"]); 
  				m_BCPColorNum=SysConvert.ToString(MasterTable.Rows[0]["BCPColorNum"]); 
  				m_BCPColorName=SysConvert.ToString(MasterTable.Rows[0]["BCPColorName"]); 
  				m_BCPMWidth=SysConvert.ToString(MasterTable.Rows[0]["BCPMWidth"]); 
  				m_BCPMWeight=SysConvert.ToString(MasterTable.Rows[0]["BCPMWeight"]); 
  				m_BoxQty=SysConvert.ToInt32(MasterTable.Rows[0]["BoxQty"]); 
  				m_SetQty=SysConvert.ToInt32(MasterTable.Rows[0]["SetQty"]); 
  				m_DozensQty=SysConvert.ToInt32(MasterTable.Rows[0]["DozensQty"]); 
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
