using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// 目的：WO_BProductCheckDts实体类
	/// 作者:周富春
	/// 创建日期:2015/5/7
	/// </summary>
	public sealed class BProductCheckDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public BProductCheckDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public BProductCheckDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_BProductCheckDts";
		 
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
  
  		private string m_DISN = string.Empty ; 
  		public string DISN 
  		{ 
  			get 
  			{ 
  				return m_DISN ; 
  			}  
  			set 
  			{ 
  				m_DISN = value ; 
  			}  
  		} 
  
  		private int m_StatusID = 0; 
  		public int StatusID 
  		{ 
  			get 
  			{ 
  				return m_StatusID ; 
  			}  
  			set 
  			{ 
  				m_StatusID = value ; 
  			}  
  		} 
  
  		private string m_Fault = string.Empty ; 
  		public string Fault 
  		{ 
  			get 
  			{ 
  				return m_Fault ; 
  			}  
  			set 
  			{ 
  				m_Fault = value ; 
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
  
  		private decimal m_YQty = 0; 
  		public decimal YQty 
  		{ 
  			get 
  			{ 
  				return m_YQty ; 
  			}  
  			set 
  			{ 
  				m_YQty = value ; 
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
  
  		private decimal m_YWeight = 0; 
  		public decimal YWeight 
  		{ 
  			get 
  			{ 
  				return m_YWeight ; 
  			}  
  			set 
  			{ 
  				m_YWeight = value ; 
  			}  
  		} 
  
  		private decimal m_CJQty = 0; 
  		public decimal CJQty 
  		{ 
  			get 
  			{ 
  				return m_CJQty ; 
  			}  
  			set 
  			{ 
  				m_CJQty = value ; 
  			}  
  		} 
  
  		private decimal m_FMQty = 0; 
  		public decimal FMQty 
  		{ 
  			get 
  			{ 
  				return m_FMQty ; 
  			}  
  			set 
  			{ 
  				m_FMQty = value ; 
  			}  
  		} 
  
  		private string m_SO = string.Empty ; 
  		public string SO 
  		{ 
  			get 
  			{ 
  				return m_SO ; 
  			}  
  			set 
  			{ 
  				m_SO = value ; 
  			}  
  		} 
  
  		private string m_CompactNo = string.Empty ; 
  		public string CompactNo 
  		{ 
  			get 
  			{ 
  				return m_CompactNo ; 
  			}  
  			set 
  			{ 
  				m_CompactNo = value ; 
  			}  
  		} 
  
  		private string m_DLever = string.Empty ; 
  		public string DLever 
  		{ 
  			get 
  			{ 
  				return m_DLever ; 
  			}  
  			set 
  			{ 
  				m_DLever = value ; 
  			}  
  		} 
  
  		private decimal m_Deduction = 0; 
  		public decimal Deduction 
  		{ 
  			get 
  			{ 
  				return m_Deduction ; 
  			}  
  			set 
  			{ 
  				m_Deduction = value ; 
  			}  
  		} 
  
  		private decimal m_MQty1 = 0; 
  		public decimal MQty1 
  		{ 
  			get 
  			{ 
  				return m_MQty1 ; 
  			}  
  			set 
  			{ 
  				m_MQty1 = value ; 
  			}  
  		} 
  
  		private decimal m_MQty2 = 0; 
  		public decimal MQty2 
  		{ 
  			get 
  			{ 
  				return m_MQty2 ; 
  			}  
  			set 
  			{ 
  				m_MQty2 = value ; 
  			}  
  		} 
  
  		private decimal m_MQty3 = 0; 
  		public decimal MQty3 
  		{ 
  			get 
  			{ 
  				return m_MQty3 ; 
  			}  
  			set 
  			{ 
  				m_MQty3 = value ; 
  			}  
  		} 
  
  		private decimal m_MQty4 = 0; 
  		public decimal MQty4 
  		{ 
  			get 
  			{ 
  				return m_MQty4 ; 
  			}  
  			set 
  			{ 
  				m_MQty4 = value ; 
  			}  
  		} 
  
  		private decimal m_MQty5 = 0; 
  		public decimal MQty5 
  		{ 
  			get 
  			{ 
  				return m_MQty5 ; 
  			}  
  			set 
  			{ 
  				m_MQty5 = value ; 
  			}  
  		} 
  
  		private int m_RepairFlag = 0; 
  		public int RepairFlag 
  		{ 
  			get 
  			{ 
  				return m_RepairFlag ; 
  			}  
  			set 
  			{ 
  				m_RepairFlag = value ; 
  			}  
  		} 
  
  		private int m_RepairCount = 0; 
  		public int RepairCount 
  		{ 
  			get 
  			{ 
  				return m_RepairCount ; 
  			}  
  			set 
  			{ 
  				m_RepairCount = value ; 
  			}  
  		} 
  
  		private string m_InitialISN = string.Empty ; 
  		public string InitialISN 
  		{ 
  			get 
  			{ 
  				return m_InitialISN ; 
  			}  
  			set 
  			{ 
  				m_InitialISN = value ; 
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
  
  		private string m_RepairReason = string.Empty ; 
  		public string RepairReason 
  		{ 
  			get 
  			{ 
  				return m_RepairReason ; 
  			}  
  			set 
  			{ 
  				m_RepairReason = value ; 
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
  
  		private string m_JarNum = string.Empty ; 
  		public string JarNum 
  		{ 
  			get 
  			{ 
  				return m_JarNum ; 
  			}  
  			set 
  			{ 
  				m_JarNum = value ; 
  			}  
  		} 
  
  		private string m_ShopID = string.Empty ; 
  		public string ShopID 
  		{ 
  			get 
  			{ 
  				return m_ShopID ; 
  			}  
  			set 
  			{ 
  				m_ShopID = value ; 
  			}  
  		} 
  
  		private string m_VendorID = string.Empty ; 
  		public string VendorID 
  		{ 
  			get 
  			{ 
  				return m_VendorID ; 
  			}  
  			set 
  			{ 
  				m_VendorID = value ; 
  			}  
  		} 
  
  		private int m_JarCount = 0; 
  		public int JarCount 
  		{ 
  			get 
  			{ 
  				return m_JarCount ; 
  			}  
  			set 
  			{ 
  				m_JarCount = value ; 
  			}  
  		} 
  
  		private int m_MaXIndex = 0; 
  		public int MaXIndex 
  		{ 
  			get 
  			{ 
  				return m_MaXIndex ; 
  			}  
  			set 
  			{ 
  				m_MaXIndex = value ; 
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
  
  		private DateTime m_CheckDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CheckDate 
  		{ 
  			get 
  			{ 
  				return m_CheckDate ; 
  			}  
  			set 
  			{ 
  				m_CheckDate = value ; 
  			}  
  		} 
  
  		private string m_CheckOPID = string.Empty ; 
  		public string CheckOPID 
  		{ 
  			get 
  			{ 
  				return m_CheckOPID ; 
  			}  
  			set 
  			{ 
  				m_CheckOPID = value ; 
  			}  
  		} 
  
  		private string m_MF = string.Empty ; 
  		public string MF 
  		{ 
  			get 
  			{ 
  				return m_MF ; 
  			}  
  			set 
  			{ 
  				m_MF = value ; 
  			}  
  		} 
  
  		private decimal m_KZ = 0; 
  		public decimal KZ 
  		{ 
  			get 
  			{ 
  				return m_KZ ; 
  			}  
  			set 
  			{ 
  				m_KZ = value ; 
  			}  
  		} 
  
  		private string m_ZNMF = string.Empty ; 
  		public string ZNMF 
  		{ 
  			get 
  			{ 
  				return m_ZNMF ; 
  			}  
  			set 
  			{ 
  				m_ZNMF = value ; 
  			}  
  		} 
  
  		private decimal m_XMQty = 0; 
  		public decimal XMQty 
  		{ 
  			get 
  			{ 
  				return m_XMQty ; 
  			}  
  			set 
  			{ 
  				m_XMQty = value ; 
  			}  
  		} 
  
  		private decimal m_BMKF = 0; 
  		public decimal BMKF 
  		{ 
  			get 
  			{ 
  				return m_BMKF ; 
  			}  
  			set 
  			{ 
  				m_BMKF = value ; 
  			}  
  		} 
  
  		private decimal m_JYBZ = 0; 
  		public decimal JYBZ 
  		{ 
  			get 
  			{ 
  				return m_JYBZ ; 
  			}  
  			set 
  			{ 
  				m_JYBZ = value ; 
  			}  
  		} 
  
  		private decimal m_CY = 0; 
  		public decimal CY 
  		{ 
  			get 
  			{ 
  				return m_CY ; 
  			}  
  			set 
  			{ 
  				m_CY = value ; 
  			}  
  		} 
  
  		private decimal m_CJZC = 0; 
  		public decimal CJZC 
  		{ 
  			get 
  			{ 
  				return m_CJZC ; 
  			}  
  			set 
  			{ 
  				m_CJZC = value ; 
  			}  
  		} 
  
  		private decimal m_CJRC = 0; 
  		public decimal CJRC 
  		{ 
  			get 
  			{ 
  				return m_CJRC ; 
  			}  
  			set 
  			{ 
  				m_CJRC = value ; 
  			}  
  		} 
  
  		private decimal m_WX = 0; 
  		public decimal WX 
  		{ 
  			get 
  			{ 
  				return m_WX ; 
  			}  
  			set 
  			{ 
  				m_WX = value ; 
  			}  
  		} 
  
  		private decimal m_ZCKF = 0; 
  		public decimal ZCKF 
  		{ 
  			get 
  			{ 
  				return m_ZCKF ; 
  			}  
  			set 
  			{ 
  				m_ZCKF = value ; 
  			}  
  		} 
  
  		private decimal m_RCKF = 0; 
  		public decimal RCKF 
  		{ 
  			get 
  			{ 
  				return m_RCKF ; 
  			}  
  			set 
  			{ 
  				m_RCKF = value ; 
  			}  
  		} 
  
  		private decimal m_KF = 0; 
  		public decimal KF 
  		{ 
  			get 
  			{ 
  				return m_KF ; 
  			}  
  			set 
  			{ 
  				m_KF = value ; 
  			}  
  		} 
  
  		private decimal m_PF = 0; 
  		public decimal PF 
  		{ 
  			get 
  			{ 
  				return m_PF ; 
  			}  
  			set 
  			{ 
  				m_PF = value ; 
  			}  
  		} 
  
  		private string m_FactoryCode = string.Empty ; 
  		public string FactoryCode 
  		{ 
  			get 
  			{ 
  				return m_FactoryCode ; 
  			}  
  			set 
  			{ 
  				m_FactoryCode = value ; 
  			}  
  		} 
  
  		private int m_JarNumCount = 0; 
  		public int JarNumCount 
  		{ 
  			get 
  			{ 
  				return m_JarNumCount ; 
  			}  
  			set 
  			{ 
  				m_JarNumCount = value ; 
  			}  
  		} 
  
  		private decimal m_YM = 0; 
  		public decimal YM 
  		{ 
  			get 
  			{ 
  				return m_YM ; 
  			}  
  			set 
  			{ 
  				m_YM = value ; 
  			}  
  		} 
  
  		private decimal m_SM = 0; 
  		public decimal SM 
  		{ 
  			get 
  			{ 
  				return m_SM ; 
  			}  
  			set 
  			{ 
  				m_SM = value ; 
  			}  
  		} 
  
  		private string m_JSUnit = string.Empty ; 
  		public string JSUnit 
  		{ 
  			get 
  			{ 
  				return m_JSUnit ; 
  			}  
  			set 
  			{ 
  				m_JSUnit = value ; 
  			}  
  		} 
  
  		private string m_PT = string.Empty ; 
  		public string PT 
  		{ 
  			get 
  			{ 
  				return m_PT ; 
  			}  
  			set 
  			{ 
  				m_PT = value ; 
  			}  
  		} 
  
  		private string m_ZG = string.Empty ; 
  		public string ZG 
  		{ 
  			get 
  			{ 
  				return m_ZG ; 
  			}  
  			set 
  			{ 
  				m_ZG = value ; 
  			}  
  		} 
  
  		private string m_GZ = string.Empty ; 
  		public string GZ 
  		{ 
  			get 
  			{ 
  				return m_GZ ; 
  			}  
  			set 
  			{ 
  				m_GZ = value ; 
  			}  
  		} 
  
  		private decimal m_FMZC = 0; 
  		public decimal FMZC 
  		{ 
  			get 
  			{ 
  				return m_FMZC ; 
  			}  
  			set 
  			{ 
  				m_FMZC = value ; 
  			}  
  		} 
  
  		private decimal m_FMRC = 0; 
  		public decimal FMRC 
  		{ 
  			get 
  			{ 
  				return m_FMRC ; 
  			}  
  			set 
  			{ 
  				m_FMRC = value ; 
  			}  
  		} 
  
  		private string m_SectionID = string.Empty ; 
  		public string SectionID 
  		{ 
  			get 
  			{ 
  				return m_SectionID ; 
  			}  
  			set 
  			{ 
  				m_SectionID = value ; 
  			}  
  		} 
  
  		private string m_WHID = string.Empty ; 
  		public string WHID 
  		{ 
  			get 
  			{ 
  				return m_WHID ; 
  			}  
  			set 
  			{ 
  				m_WHID = value ; 
  			}  
  		} 
  
  		private decimal m_MQty = 0; 
  		public decimal MQty 
  		{ 
  			get 
  			{ 
  				return m_MQty ; 
  			}  
  			set 
  			{ 
  				m_MQty = value ; 
  			}  
  		} 
  
  		private decimal m_MWeight = 0; 
  		public decimal MWeight 
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
  
  		private int m_KF20 = 0; 
  		public int KF20 
  		{ 
  			get 
  			{ 
  				return m_KF20 ; 
  			}  
  			set 
  			{ 
  				m_KF20 = value ; 
  			}  
  		} 
  
  		private int m_KF22 = 0; 
  		public int KF22 
  		{ 
  			get 
  			{ 
  				return m_KF22 ; 
  			}  
  			set 
  			{ 
  				m_KF22 = value ; 
  			}  
  		} 
  
  		private int m_KF24 = 0; 
  		public int KF24 
  		{ 
  			get 
  			{ 
  				return m_KF24 ; 
  			}  
  			set 
  			{ 
  				m_KF24 = value ; 
  			}  
  		} 
  
  		private int m_KF25 = 0; 
  		public int KF25 
  		{ 
  			get 
  			{ 
  				return m_KF25 ; 
  			}  
  			set 
  			{ 
  				m_KF25 = value ; 
  			}  
  		} 
  
  		private int m_InWHFlag = 0; 
  		public int InWHFlag 
  		{ 
  			get 
  			{ 
  				return m_InWHFlag ; 
  			}  
  			set 
  			{ 
  				m_InWHFlag = value ; 
  			}  
  		} 
  
  		private decimal m_SJQty = 0; 
  		public decimal SJQty 
  		{ 
  			get 
  			{ 
  				return m_SJQty ; 
  			}  
  			set 
  			{ 
  				m_SJQty = value ; 
  			}  
  		} 
  
  		private int m_JarNo = 0; 
  		public int JarNo 
  		{ 
  			get 
  			{ 
  				return m_JarNo ; 
  			}  
  			set 
  			{ 
  				m_JarNo = value ; 
  			}  
  		} 
  
  		private string m_GoodsLevel = string.Empty ; 
  		public string GoodsLevel 
  		{ 
  			get 
  			{ 
  				return m_GoodsLevel ; 
  			}  
  			set 
  			{ 
  				m_GoodsLevel = value ; 
  			}  
  		} 
  
  		private string m_PrintItemName = string.Empty ; 
  		public string PrintItemName 
  		{ 
  			get 
  			{ 
  				return m_PrintItemName ; 
  			}  
  			set 
  			{ 
  				m_PrintItemName = value ; 
  			}  
  		} 
  
  		private string m_PrintGoodsCode = string.Empty ; 
  		public string PrintGoodsCode 
  		{ 
  			get 
  			{ 
  				return m_PrintGoodsCode ; 
  			}  
  			set 
  			{ 
  				m_PrintGoodsCode = value ; 
  			}  
  		} 
  
  		private string m_PrintCD = string.Empty ; 
  		public string PrintCD 
  		{ 
  			get 
  			{ 
  				return m_PrintCD ; 
  			}  
  			set 
  			{ 
  				m_PrintCD = value ; 
  			}  
  		} 
  
  		private string m_PrintRemark1 = string.Empty ; 
  		public string PrintRemark1 
  		{ 
  			get 
  			{ 
  				return m_PrintRemark1 ; 
  			}  
  			set 
  			{ 
  				m_PrintRemark1 = value ; 
  			}  
  		} 
  
  		private string m_PrintRemark2 = string.Empty ; 
  		public string PrintRemark2 
  		{ 
  			get 
  			{ 
  				return m_PrintRemark2 ; 
  			}  
  			set 
  			{ 
  				m_PrintRemark2 = value ; 
  			}  
  		} 
  
  		private string m_PrintRemark3 = string.Empty ; 
  		public string PrintRemark3 
  		{ 
  			get 
  			{ 
  				return m_PrintRemark3 ; 
  			}  
  			set 
  			{ 
  				m_PrintRemark3 = value ; 
  			}  
  		} 
  
  		private string m_PrintRemark4 = string.Empty ; 
  		public string PrintRemark4 
  		{ 
  			get 
  			{ 
  				return m_PrintRemark4 ; 
  			}  
  			set 
  			{ 
  				m_PrintRemark4 = value ; 
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
            string Sql="SELECT * FROM WO_BProductCheckDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_BProductCheckDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_DISN=SysConvert.ToString(MasterTable.Rows[0]["DISN"]); 
  				m_StatusID=SysConvert.ToInt32(MasterTable.Rows[0]["StatusID"]); 
  				m_Fault=SysConvert.ToString(MasterTable.Rows[0]["Fault"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_YQty=SysConvert.ToDecimal(MasterTable.Rows[0]["YQty"]); 
  				m_Weight=SysConvert.ToDecimal(MasterTable.Rows[0]["Weight"]); 
  				m_YWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["YWeight"]); 
  				m_CJQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CJQty"]); 
  				m_FMQty=SysConvert.ToDecimal(MasterTable.Rows[0]["FMQty"]); 
  				m_SO=SysConvert.ToString(MasterTable.Rows[0]["SO"]); 
  				m_CompactNo=SysConvert.ToString(MasterTable.Rows[0]["CompactNo"]); 
  				m_DLever=SysConvert.ToString(MasterTable.Rows[0]["DLever"]); 
  				m_Deduction=SysConvert.ToDecimal(MasterTable.Rows[0]["Deduction"]); 
  				m_MQty1=SysConvert.ToDecimal(MasterTable.Rows[0]["MQty1"]); 
  				m_MQty2=SysConvert.ToDecimal(MasterTable.Rows[0]["MQty2"]); 
  				m_MQty3=SysConvert.ToDecimal(MasterTable.Rows[0]["MQty3"]); 
  				m_MQty4=SysConvert.ToDecimal(MasterTable.Rows[0]["MQty4"]); 
  				m_MQty5=SysConvert.ToDecimal(MasterTable.Rows[0]["MQty5"]); 
  				m_RepairFlag=SysConvert.ToInt32(MasterTable.Rows[0]["RepairFlag"]); 
  				m_RepairCount=SysConvert.ToInt32(MasterTable.Rows[0]["RepairCount"]); 
  				m_InitialISN=SysConvert.ToString(MasterTable.Rows[0]["InitialISN"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_RepairReason=SysConvert.ToString(MasterTable.Rows[0]["RepairReason"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]); 
  				m_ShopID=SysConvert.ToString(MasterTable.Rows[0]["ShopID"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_JarCount=SysConvert.ToInt32(MasterTable.Rows[0]["JarCount"]); 
  				m_MaXIndex=SysConvert.ToInt32(MasterTable.Rows[0]["MaXIndex"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_VColorName=SysConvert.ToString(MasterTable.Rows[0]["VColorName"]); 
  				m_VColorNum=SysConvert.ToString(MasterTable.Rows[0]["VColorNum"]); 
  				m_CheckDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CheckDate"]); 
  				m_CheckOPID=SysConvert.ToString(MasterTable.Rows[0]["CheckOPID"]); 
  				m_MF=SysConvert.ToString(MasterTable.Rows[0]["MF"]); 
  				m_KZ=SysConvert.ToDecimal(MasterTable.Rows[0]["KZ"]); 
  				m_ZNMF=SysConvert.ToString(MasterTable.Rows[0]["ZNMF"]); 
  				m_XMQty=SysConvert.ToDecimal(MasterTable.Rows[0]["XMQty"]); 
  				m_BMKF=SysConvert.ToDecimal(MasterTable.Rows[0]["BMKF"]); 
  				m_JYBZ=SysConvert.ToDecimal(MasterTable.Rows[0]["JYBZ"]); 
  				m_CY=SysConvert.ToDecimal(MasterTable.Rows[0]["CY"]); 
  				m_CJZC=SysConvert.ToDecimal(MasterTable.Rows[0]["CJZC"]); 
  				m_CJRC=SysConvert.ToDecimal(MasterTable.Rows[0]["CJRC"]); 
  				m_WX=SysConvert.ToDecimal(MasterTable.Rows[0]["WX"]); 
  				m_ZCKF=SysConvert.ToDecimal(MasterTable.Rows[0]["ZCKF"]); 
  				m_RCKF=SysConvert.ToDecimal(MasterTable.Rows[0]["RCKF"]); 
  				m_KF=SysConvert.ToDecimal(MasterTable.Rows[0]["KF"]); 
  				m_PF=SysConvert.ToDecimal(MasterTable.Rows[0]["PF"]); 
  				m_FactoryCode=SysConvert.ToString(MasterTable.Rows[0]["FactoryCode"]); 
  				m_JarNumCount=SysConvert.ToInt32(MasterTable.Rows[0]["JarNumCount"]); 
  				m_YM=SysConvert.ToDecimal(MasterTable.Rows[0]["YM"]); 
  				m_SM=SysConvert.ToDecimal(MasterTable.Rows[0]["SM"]); 
  				m_JSUnit=SysConvert.ToString(MasterTable.Rows[0]["JSUnit"]); 
  				m_PT=SysConvert.ToString(MasterTable.Rows[0]["PT"]); 
  				m_ZG=SysConvert.ToString(MasterTable.Rows[0]["ZG"]); 
  				m_GZ=SysConvert.ToString(MasterTable.Rows[0]["GZ"]); 
  				m_FMZC=SysConvert.ToDecimal(MasterTable.Rows[0]["FMZC"]); 
  				m_FMRC=SysConvert.ToDecimal(MasterTable.Rows[0]["FMRC"]); 
  				m_SectionID=SysConvert.ToString(MasterTable.Rows[0]["SectionID"]); 
  				m_WHID=SysConvert.ToString(MasterTable.Rows[0]["WHID"]); 
  				m_MQty=SysConvert.ToDecimal(MasterTable.Rows[0]["MQty"]); 
  				m_MWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["MWeight"]); 
  				m_KF20=SysConvert.ToInt32(MasterTable.Rows[0]["KF20"]); 
  				m_KF22=SysConvert.ToInt32(MasterTable.Rows[0]["KF22"]); 
  				m_KF24=SysConvert.ToInt32(MasterTable.Rows[0]["KF24"]); 
  				m_KF25=SysConvert.ToInt32(MasterTable.Rows[0]["KF25"]); 
  				m_InWHFlag=SysConvert.ToInt32(MasterTable.Rows[0]["InWHFlag"]); 
  				m_SJQty=SysConvert.ToDecimal(MasterTable.Rows[0]["SJQty"]); 
  				m_JarNo=SysConvert.ToInt32(MasterTable.Rows[0]["JarNo"]); 
  				m_GoodsLevel=SysConvert.ToString(MasterTable.Rows[0]["GoodsLevel"]); 
  				m_PrintItemName=SysConvert.ToString(MasterTable.Rows[0]["PrintItemName"]); 
  				m_PrintGoodsCode=SysConvert.ToString(MasterTable.Rows[0]["PrintGoodsCode"]); 
  				m_PrintCD=SysConvert.ToString(MasterTable.Rows[0]["PrintCD"]); 
  				m_PrintRemark1=SysConvert.ToString(MasterTable.Rows[0]["PrintRemark1"]); 
  				m_PrintRemark2=SysConvert.ToString(MasterTable.Rows[0]["PrintRemark2"]); 
  				m_PrintRemark3=SysConvert.ToString(MasterTable.Rows[0]["PrintRemark3"]); 
  				m_PrintRemark4=SysConvert.ToString(MasterTable.Rows[0]["PrintRemark4"]); 
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
