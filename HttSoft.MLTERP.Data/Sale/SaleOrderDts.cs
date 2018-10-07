using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_SaleOrderDts实体类
	/// 作者:zhp
	/// 创建日期:2016/8/29
	/// </summary>
	public sealed class SaleOrderDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public SaleOrderDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SaleOrderDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Sale_SaleOrderDts";
		 
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
  
  		private int m_OrderPreStepID = 0; 
  		public int OrderPreStepID 
  		{ 
  			get 
  			{ 
  				return m_OrderPreStepID ; 
  			}  
  			set 
  			{ 
  				m_OrderPreStepID = value ; 
  			}  
  		} 
  
  		private int m_OrderStepID = 0; 
  		public int OrderStepID 
  		{ 
  			get 
  			{ 
  				return m_OrderStepID ; 
  			}  
  			set 
  			{ 
  				m_OrderStepID = value ; 
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
  
  		private decimal m_PSCGQty = 0; 
  		public decimal PSCGQty 
  		{ 
  			get 
  			{ 
  				return m_PSCGQty ; 
  			}  
  			set 
  			{ 
  				m_PSCGQty = value ; 
  			}  
  		} 
  
  		private decimal m_PBCGQty = 0; 
  		public decimal PBCGQty 
  		{ 
  			get 
  			{ 
  				return m_PBCGQty ; 
  			}  
  			set 
  			{ 
  				m_PBCGQty = value ; 
  			}  
  		} 
  
  		private decimal m_CPCGQty = 0; 
  		public decimal CPCGQty 
  		{ 
  			get 
  			{ 
  				return m_CPCGQty ; 
  			}  
  			set 
  			{ 
  				m_CPCGQty = value ; 
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
  
  		private int m_CapFlag = 0; 
  		public int CapFlag 
  		{ 
  			get 
  			{ 
  				return m_CapFlag ; 
  			}  
  			set 
  			{ 
  				m_CapFlag = value ; 
  			}  
  		} 
  
  		private decimal m_DYPrice = 0; 
  		public decimal DYPrice 
  		{ 
  			get 
  			{ 
  				return m_DYPrice ; 
  			}  
  			set 
  			{ 
  				m_DYPrice = value ; 
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
  
  		private decimal m_FAmount1 = 0; 
  		public decimal FAmount1 
  		{ 
  			get 
  			{ 
  				return m_FAmount1 ; 
  			}  
  			set 
  			{ 
  				m_FAmount1 = value ; 
  			}  
  		} 
  
  		private decimal m_FAmount2 = 0; 
  		public decimal FAmount2 
  		{ 
  			get 
  			{ 
  				return m_FAmount2 ; 
  			}  
  			set 
  			{ 
  				m_FAmount2 = value ; 
  			}  
  		} 
  
  		private decimal m_FAmount3 = 0; 
  		public decimal FAmount3 
  		{ 
  			get 
  			{ 
  				return m_FAmount3 ; 
  			}  
  			set 
  			{ 
  				m_FAmount3 = value ; 
  			}  
  		} 
  
  		private decimal m_FAmount4 = 0; 
  		public decimal FAmount4 
  		{ 
  			get 
  			{ 
  				return m_FAmount4 ; 
  			}  
  			set 
  			{ 
  				m_FAmount4 = value ; 
  			}  
  		} 
  
  		private decimal m_FAmount5 = 0; 
  		public decimal FAmount5 
  		{ 
  			get 
  			{ 
  				return m_FAmount5 ; 
  			}  
  			set 
  			{ 
  				m_FAmount5 = value ; 
  			}  
  		} 
  
  		private decimal m_FAmount6 = 0; 
  		public decimal FAmount6 
  		{ 
  			get 
  			{ 
  				return m_FAmount6 ; 
  			}  
  			set 
  			{ 
  				m_FAmount6 = value ; 
  			}  
  		} 
  
  		private int m_YarnCalcFlag = 0; 
  		public int YarnCalcFlag 
  		{ 
  			get 
  			{ 
  				return m_YarnCalcFlag ; 
  			}  
  			set 
  			{ 
  				m_YarnCalcFlag = value ; 
  			}  
  		} 
  
  		private int m_FabricCalcFlag = 0; 
  		public int FabricCalcFlag 
  		{ 
  			get 
  			{ 
  				return m_FabricCalcFlag ; 
  			}  
  			set 
  			{ 
  				m_FabricCalcFlag = value ; 
  			}  
  		} 
  
  		private decimal m_ZS = 0; 
  		public decimal ZS 
  		{ 
  			get 
  			{ 
  				return m_ZS ; 
  			}  
  			set 
  			{ 
  				m_ZS = value ; 
  			}  
  		} 
  
  		private decimal m_InputQty = 0; 
  		public decimal InputQty 
  		{ 
  			get 
  			{ 
  				return m_InputQty ; 
  			}  
  			set 
  			{ 
  				m_InputQty = value ; 
  			}  
  		} 
  
  		private string m_InputUnit = string.Empty ; 
  		public string InputUnit 
  		{ 
  			get 
  			{ 
  				return m_InputUnit ; 
  			}  
  			set 
  			{ 
  				m_InputUnit = value ; 
  			}  
  		} 
  
  		private decimal m_InputSinglePrice = 0; 
  		public decimal InputSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_InputSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_InputSinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_InputAmount = 0; 
  		public decimal InputAmount 
  		{ 
  			get 
  			{ 
  				return m_InputAmount ; 
  			}  
  			set 
  			{ 
  				m_InputAmount = value ; 
  			}  
  		} 
  
  		private decimal m_InputConvertXS = 0; 
  		public decimal InputConvertXS 
  		{ 
  			get 
  			{ 
  				return m_InputConvertXS ; 
  			}  
  			set 
  			{ 
  				m_InputConvertXS = value ; 
  			}  
  		} 
  
  		private int m_CompSiteCalFlag = 0; 
  		public int CompSiteCalFlag 
  		{ 
  			get 
  			{ 
  				return m_CompSiteCalFlag ; 
  			}  
  			set 
  			{ 
  				m_CompSiteCalFlag = value ; 
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
  
  		private int m_ReceivedPieceQty = 0; 
  		public int ReceivedPieceQty 
  		{ 
  			get 
  			{ 
  				return m_ReceivedPieceQty ; 
  			}  
  			set 
  			{ 
  				m_ReceivedPieceQty = value ; 
  			}  
  		} 
  
  		private int m_TotalRecPieceQty = 0; 
  		public int TotalRecPieceQty 
  		{ 
  			get 
  			{ 
  				return m_TotalRecPieceQty ; 
  			}  
  			set 
  			{ 
  				m_TotalRecPieceQty = value ; 
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
  
  		private decimal m_ReceiveAmount = 0; 
  		public decimal ReceiveAmount 
  		{ 
  			get 
  			{ 
  				return m_ReceiveAmount ; 
  			}  
  			set 
  			{ 
  				m_ReceiveAmount = value ; 
  			}  
  		} 
  
  		private string m_OutRange = string.Empty ; 
  		public string OutRange 
  		{ 
  			get 
  			{ 
  				return m_OutRange ; 
  			}  
  			set 
  			{ 
  				m_OutRange = value ; 
  			}  
  		} 
  
  		private string m_FK = string.Empty ; 
  		public string FK 
  		{ 
  			get 
  			{ 
  				return m_FK ; 
  			}  
  			set 
  			{ 
  				m_FK = value ; 
  			}  
  		} 
  
  		private string m_MaxQty = string.Empty ; 
  		public string MaxQty 
  		{ 
  			get 
  			{ 
  				return m_MaxQty ; 
  			}  
  			set 
  			{ 
  				m_MaxQty = value ; 
  			}  
  		} 
  
  		private string m_MinQty = string.Empty ; 
  		public string MinQty 
  		{ 
  			get 
  			{ 
  				return m_MinQty ; 
  			}  
  			set 
  			{ 
  				m_MinQty = value ; 
  			}  
  		} 
  
  		private string m_Pos = string.Empty ; 
  		public string Pos 
  		{ 
  			get 
  			{ 
  				return m_Pos ; 
  			}  
  			set 
  			{ 
  				m_Pos = value ; 
  			}  
  		} 
  
  		private string m_OrderNo = string.Empty ; 
  		public string OrderNo 
  		{ 
  			get 
  			{ 
  				return m_OrderNo ; 
  			}  
  			set 
  			{ 
  				m_OrderNo = value ; 
  			}  
  		} 
  
  		private string m_VRCode = string.Empty ; 
  		public string VRCode 
  		{ 
  			get 
  			{ 
  				return m_VRCode ; 
  			}  
  			set 
  			{ 
  				m_VRCode = value ; 
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
  
  		private string m_ReqDateEdit = string.Empty ; 
  		public string ReqDateEdit 
  		{ 
  			get 
  			{ 
  				return m_ReqDateEdit ; 
  			}  
  			set 
  			{ 
  				m_ReqDateEdit = value ; 
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
  
  		private decimal m_ReceivedWeight = 0; 
  		public decimal ReceivedWeight 
  		{ 
  			get 
  			{ 
  				return m_ReceivedWeight ; 
  			}  
  			set 
  			{ 
  				m_ReceivedWeight = value ; 
  			}  
  		} 
  
  		private decimal m_TotalRecWeight = 0; 
  		public decimal TotalRecWeight 
  		{ 
  			get 
  			{ 
  				return m_TotalRecWeight ; 
  			}  
  			set 
  			{ 
  				m_TotalRecWeight = value ; 
  			}  
  		} 
  
  		private int m_StatusFlag = 0; 
  		public int StatusFlag 
  		{ 
  			get 
  			{ 
  				return m_StatusFlag ; 
  			}  
  			set 
  			{ 
  				m_StatusFlag = value ; 
  			}  
  		} 
  
  		private string m_StatusName = string.Empty ; 
  		public string StatusName 
  		{ 
  			get 
  			{ 
  				return m_StatusName ; 
  			}  
  			set 
  			{ 
  				m_StatusName = value ; 
  			}  
  		} 
  
  		private decimal m_Yard = 0; 
  		public decimal Yard 
  		{ 
  			get 
  			{ 
  				return m_Yard ; 
  			}  
  			set 
  			{ 
  				m_Yard = value ; 
  			}  
  		} 
  
  		private decimal m_ReceivedYard = 0; 
  		public decimal ReceivedYard 
  		{ 
  			get 
  			{ 
  				return m_ReceivedYard ; 
  			}  
  			set 
  			{ 
  				m_ReceivedYard = value ; 
  			}  
  		} 
  
  		private decimal m_TotalRecYard = 0; 
  		public decimal TotalRecYard 
  		{ 
  			get 
  			{ 
  				return m_TotalRecYard ; 
  			}  
  			set 
  			{ 
  				m_TotalRecYard = value ; 
  			}  
  		} 
  
  		private decimal m_PieceLength = 0; 
  		public decimal PieceLength 
  		{ 
  			get 
  			{ 
  				return m_PieceLength ; 
  			}  
  			set 
  			{ 
  				m_PieceLength = value ; 
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
            string Sql="SELECT * FROM Sale_SaleOrderDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_SaleOrderDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
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
  				m_OrderPreStepID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderPreStepID"]); 
  				m_OrderStepID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderStepID"]); 
  				m_DtsReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["DtsReqDate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_PSCGQty=SysConvert.ToDecimal(MasterTable.Rows[0]["PSCGQty"]); 
  				m_PBCGQty=SysConvert.ToDecimal(MasterTable.Rows[0]["PBCGQty"]); 
  				m_CPCGQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CPCGQty"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_CapFlag=SysConvert.ToInt32(MasterTable.Rows[0]["CapFlag"]); 
  				m_DYPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["DYPrice"]); 
  				m_BGNo=SysConvert.ToString(MasterTable.Rows[0]["BGNo"]); 
  				m_FAmount1=SysConvert.ToDecimal(MasterTable.Rows[0]["FAmount1"]); 
  				m_FAmount2=SysConvert.ToDecimal(MasterTable.Rows[0]["FAmount2"]); 
  				m_FAmount3=SysConvert.ToDecimal(MasterTable.Rows[0]["FAmount3"]); 
  				m_FAmount4=SysConvert.ToDecimal(MasterTable.Rows[0]["FAmount4"]); 
  				m_FAmount5=SysConvert.ToDecimal(MasterTable.Rows[0]["FAmount5"]); 
  				m_FAmount6=SysConvert.ToDecimal(MasterTable.Rows[0]["FAmount6"]); 
  				m_YarnCalcFlag=SysConvert.ToInt32(MasterTable.Rows[0]["YarnCalcFlag"]); 
  				m_FabricCalcFlag=SysConvert.ToInt32(MasterTable.Rows[0]["FabricCalcFlag"]); 
  				m_ZS=SysConvert.ToDecimal(MasterTable.Rows[0]["ZS"]); 
  				m_InputQty=SysConvert.ToDecimal(MasterTable.Rows[0]["InputQty"]); 
  				m_InputUnit=SysConvert.ToString(MasterTable.Rows[0]["InputUnit"]); 
  				m_InputSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["InputSinglePrice"]); 
  				m_InputAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["InputAmount"]); 
  				m_InputConvertXS=SysConvert.ToDecimal(MasterTable.Rows[0]["InputConvertXS"]); 
  				m_CompSiteCalFlag=SysConvert.ToInt32(MasterTable.Rows[0]["CompSiteCalFlag"]); 
  				m_PieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["PieceQty"]); 
  				m_ReceivedPieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["ReceivedPieceQty"]); 
  				m_TotalRecPieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["TotalRecPieceQty"]); 
  				m_AllMWidth=SysConvert.ToString(MasterTable.Rows[0]["AllMWidth"]); 
  				m_Needle=SysConvert.ToString(MasterTable.Rows[0]["Needle"]); 
  				m_ReceiveAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ReceiveAmount"]); 
  				m_OutRange=SysConvert.ToString(MasterTable.Rows[0]["OutRange"]); 
  				m_FK=SysConvert.ToString(MasterTable.Rows[0]["FK"]); 
  				m_MaxQty=SysConvert.ToString(MasterTable.Rows[0]["MaxQty"]); 
  				m_MinQty=SysConvert.ToString(MasterTable.Rows[0]["MinQty"]); 
  				m_Pos=SysConvert.ToString(MasterTable.Rows[0]["Pos"]); 
  				m_OrderNo=SysConvert.ToString(MasterTable.Rows[0]["OrderNo"]); 
  				m_VRCode=SysConvert.ToString(MasterTable.Rows[0]["VRCode"]); 
  				m_Currency=SysConvert.ToString(MasterTable.Rows[0]["Currency"]); 
  				m_StyleNo=SysConvert.ToString(MasterTable.Rows[0]["StyleNo"]); 
  				m_ReqDateEdit=SysConvert.ToString(MasterTable.Rows[0]["ReqDateEdit"]); 
  				m_Weight=SysConvert.ToDecimal(MasterTable.Rows[0]["Weight"]); 
  				m_ReceivedWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["ReceivedWeight"]); 
  				m_TotalRecWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalRecWeight"]); 
  				m_StatusFlag=SysConvert.ToInt32(MasterTable.Rows[0]["StatusFlag"]); 
  				m_StatusName=SysConvert.ToString(MasterTable.Rows[0]["StatusName"]); 
  				m_Yard=SysConvert.ToDecimal(MasterTable.Rows[0]["Yard"]); 
  				m_ReceivedYard=SysConvert.ToDecimal(MasterTable.Rows[0]["ReceivedYard"]); 
  				m_TotalRecYard=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalRecYard"]); 
  				m_PieceLength=SysConvert.ToDecimal(MasterTable.Rows[0]["PieceLength"]); 
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
