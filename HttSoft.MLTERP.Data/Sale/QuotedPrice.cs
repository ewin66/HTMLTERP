using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_QuotedPrice实体类
	/// 作者:qiuchao
	/// 创建日期:2015/7/30
	/// </summary>
	public sealed class QuotedPrice : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public QuotedPrice()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public QuotedPrice(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Sale_QuotedPrice";
		 
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
  
  		private string m_FormNo = string.Empty ; 
  		public string FormNo 
  		{ 
  			get 
  			{ 
  				return m_FormNo ; 
  			}  
  			set 
  			{ 
  				m_FormNo = value ; 
  			}  
  		} 
  
  		private string m_MakeOPID = string.Empty ; 
  		public string MakeOPID 
  		{ 
  			get 
  			{ 
  				return m_MakeOPID ; 
  			}  
  			set 
  			{ 
  				m_MakeOPID = value ; 
  			}  
  		} 
  
  		private string m_MakeOPName = string.Empty ; 
  		public string MakeOPName 
  		{ 
  			get 
  			{ 
  				return m_MakeOPName ; 
  			}  
  			set 
  			{ 
  				m_MakeOPName = value ; 
  			}  
  		} 
  
  		private DateTime m_MakeDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime MakeDate 
  		{ 
  			get 
  			{ 
  				return m_MakeDate ; 
  			}  
  			set 
  			{ 
  				m_MakeDate = value ; 
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
  
  		private int m_SubmitFlag = 0; 
  		public int SubmitFlag 
  		{ 
  			get 
  			{ 
  				return m_SubmitFlag ; 
  			}  
  			set 
  			{ 
  				m_SubmitFlag = value ; 
  			}  
  		} 
  
  		private int m_DelFlag = 0; 
  		public int DelFlag 
  		{ 
  			get 
  			{ 
  				return m_DelFlag ; 
  			}  
  			set 
  			{ 
  				m_DelFlag = value ; 
  			}  
  		} 
  
  		private DateTime m_FormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FormDate 
  		{ 
  			get 
  			{ 
  				return m_FormDate ; 
  			}  
  			set 
  			{ 
  				m_FormDate = value ; 
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
  
  		private string m_SaleOPID = string.Empty ; 
  		public string SaleOPID 
  		{ 
  			get 
  			{ 
  				return m_SaleOPID ; 
  			}  
  			set 
  			{ 
  				m_SaleOPID = value ; 
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
  
  		private string m_VendorOPName = string.Empty ; 
  		public string VendorOPName 
  		{ 
  			get 
  			{ 
  				return m_VendorOPName ; 
  			}  
  			set 
  			{ 
  				m_VendorOPName = value ; 
  			}  
  		} 
  
  		private DateTime m_EffDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime EffDate 
  		{ 
  			get 
  			{ 
  				return m_EffDate ; 
  			}  
  			set 
  			{ 
  				m_EffDate = value ; 
  			}  
  		} 
  
  		private string m_PriceContext = string.Empty ; 
  		public string PriceContext 
  		{ 
  			get 
  			{ 
  				return m_PriceContext ; 
  			}  
  			set 
  			{ 
  				m_PriceContext = value ; 
  			}  
  		} 
  
  		private string m_TradeType = string.Empty ; 
  		public string TradeType 
  		{ 
  			get 
  			{ 
  				return m_TradeType ; 
  			}  
  			set 
  			{ 
  				m_TradeType = value ; 
  			}  
  		} 
  
  		private decimal m_AddPer = 0; 
  		public decimal AddPer 
  		{ 
  			get 
  			{ 
  				return m_AddPer ; 
  			}  
  			set 
  			{ 
  				m_AddPer = value ; 
  			}  
  		} 
  
  		private string m_EffTime = string.Empty ; 
  		public string EffTime 
  		{ 
  			get 
  			{ 
  				return m_EffTime ; 
  			}  
  			set 
  			{ 
  				m_EffTime = value ; 
  			}  
  		} 
  
  		private decimal m_HL = 0; 
  		public decimal HL 
  		{ 
  			get 
  			{ 
  				return m_HL ; 
  			}  
  			set 
  			{ 
  				m_HL = value ; 
  			}  
  		} 
  
  		private string m_TradeWay = string.Empty ; 
  		public string TradeWay 
  		{ 
  			get 
  			{ 
  				return m_TradeWay ; 
  			}  
  			set 
  			{ 
  				m_TradeWay = value ; 
  			}  
  		} 
  
  		private int m_PayMethodFlag = 0; 
  		public int PayMethodFlag 
  		{ 
  			get 
  			{ 
  				return m_PayMethodFlag ; 
  			}  
  			set 
  			{ 
  				m_PayMethodFlag = value ; 
  			}  
  		} 
  
  		private string m_TransportWay = string.Empty ; 
  		public string TransportWay 
  		{ 
  			get 
  			{ 
  				return m_TransportWay ; 
  			}  
  			set 
  			{ 
  				m_TransportWay = value ; 
  			}  
  		} 
  
  		private string m_SelvageReq = string.Empty ; 
  		public string SelvageReq 
  		{ 
  			get 
  			{ 
  				return m_SelvageReq ; 
  			}  
  			set 
  			{ 
  				m_SelvageReq = value ; 
  			}  
  		} 
  
  		private string m_DyeReq = string.Empty ; 
  		public string DyeReq 
  		{ 
  			get 
  			{ 
  				return m_DyeReq ; 
  			}  
  			set 
  			{ 
  				m_DyeReq = value ; 
  			}  
  		} 
  
  		private string m_ArrangeReq = string.Empty ; 
  		public string ArrangeReq 
  		{ 
  			get 
  			{ 
  				return m_ArrangeReq ; 
  			}  
  			set 
  			{ 
  				m_ArrangeReq = value ; 
  			}  
  		} 
  
  		private string m_PackReq = string.Empty ; 
  		public string PackReq 
  		{ 
  			get 
  			{ 
  				return m_PackReq ; 
  			}  
  			set 
  			{ 
  				m_PackReq = value ; 
  			}  
  		} 
  
  		private string m_QualityReq = string.Empty ; 
  		public string QualityReq 
  		{ 
  			get 
  			{ 
  				return m_QualityReq ; 
  			}  
  			set 
  			{ 
  				m_QualityReq = value ; 
  			}  
  		} 
  
  		private string m_DeliveryReq = string.Empty ; 
  		public string DeliveryReq 
  		{ 
  			get 
  			{ 
  				return m_DeliveryReq ; 
  			}  
  			set 
  			{ 
  				m_DeliveryReq = value ; 
  			}  
  		} 
  
  		private string m_OtherReq = string.Empty ; 
  		public string OtherReq 
  		{ 
  			get 
  			{ 
  				return m_OtherReq ; 
  			}  
  			set 
  			{ 
  				m_OtherReq = value ; 
  			}  
  		} 
  
  		private string m_VAddress = string.Empty ; 
  		public string VAddress 
  		{ 
  			get 
  			{ 
  				return m_VAddress ; 
  			}  
  			set 
  			{ 
  				m_VAddress = value ; 
  			}  
  		} 
  
  		private string m_VTelephone = string.Empty ; 
  		public string VTelephone 
  		{ 
  			get 
  			{ 
  				return m_VTelephone ; 
  			}  
  			set 
  			{ 
  				m_VTelephone = value ; 
  			}  
  		} 
  
  		private string m_VFax = string.Empty ; 
  		public string VFax 
  		{ 
  			get 
  			{ 
  				return m_VFax ; 
  			}  
  			set 
  			{ 
  				m_VFax = value ; 
  			}  
  		} 
  
  		private string m_VEmail = string.Empty ; 
  		public string VEmail 
  		{ 
  			get 
  			{ 
  				return m_VEmail ; 
  			}  
  			set 
  			{ 
  				m_VEmail = value ; 
  			}  
  		} 
  
  		private DateTime m_JiaoQi = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime JiaoQi 
  		{ 
  			get 
  			{ 
  				return m_JiaoQi ; 
  			}  
  			set 
  			{ 
  				m_JiaoQi = value ; 
  			}  
  		} 
  
  		private string m_YongJing = string.Empty ; 
  		public string YongJing 
  		{ 
  			get 
  			{ 
  				return m_YongJing ; 
  			}  
  			set 
  			{ 
  				m_YongJing = value ; 
  			}  
  		} 
  
  		private string m_GangKou = string.Empty ; 
  		public string GangKou 
  		{ 
  			get 
  			{ 
  				return m_GangKou ; 
  			}  
  			set 
  			{ 
  				m_GangKou = value ; 
  			}  
  		} 
  
  		private string m_KHType = string.Empty ; 
  		public string KHType 
  		{ 
  			get 
  			{ 
  				return m_KHType ; 
  			}  
  			set 
  			{ 
  				m_KHType = value ; 
  			}  
  		} 
  
  		private string m_ZZMarket = string.Empty ; 
  		public string ZZMarket 
  		{ 
  			get 
  			{ 
  				return m_ZZMarket ; 
  			}  
  			set 
  			{ 
  				m_ZZMarket = value ; 
  			}  
  		} 
  
  		private DateTime m_AuditTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime AuditTime 
  		{ 
  			get 
  			{ 
  				return m_AuditTime ; 
  			}  
  			set 
  			{ 
  				m_AuditTime = value ; 
  			}  
  		} 
  
  		private string m_BJSaleOPID = string.Empty ; 
  		public string BJSaleOPID 
  		{ 
  			get 
  			{ 
  				return m_BJSaleOPID ; 
  			}  
  			set 
  			{ 
  				m_BJSaleOPID = value ; 
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
            string Sql="SELECT * FROM Sale_QuotedPrice WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_QuotedPrice WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeOPName=SysConvert.ToString(MasterTable.Rows[0]["MakeOPName"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_CheckOPID=SysConvert.ToString(MasterTable.Rows[0]["CheckOPID"]); 
  				m_CheckDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CheckDate"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_VendorOPName=SysConvert.ToString(MasterTable.Rows[0]["VendorOPName"]); 
  				m_EffDate=SysConvert.ToDateTime(MasterTable.Rows[0]["EffDate"]); 
  				m_PriceContext=SysConvert.ToString(MasterTable.Rows[0]["PriceContext"]); 
  				m_TradeType=SysConvert.ToString(MasterTable.Rows[0]["TradeType"]); 
  				m_AddPer=SysConvert.ToDecimal(MasterTable.Rows[0]["AddPer"]); 
  				m_EffTime=SysConvert.ToString(MasterTable.Rows[0]["EffTime"]); 
  				m_HL=SysConvert.ToDecimal(MasterTable.Rows[0]["HL"]); 
  				m_TradeWay=SysConvert.ToString(MasterTable.Rows[0]["TradeWay"]); 
  				m_PayMethodFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PayMethodFlag"]); 
  				m_TransportWay=SysConvert.ToString(MasterTable.Rows[0]["TransportWay"]); 
  				m_SelvageReq=SysConvert.ToString(MasterTable.Rows[0]["SelvageReq"]); 
  				m_DyeReq=SysConvert.ToString(MasterTable.Rows[0]["DyeReq"]); 
  				m_ArrangeReq=SysConvert.ToString(MasterTable.Rows[0]["ArrangeReq"]); 
  				m_PackReq=SysConvert.ToString(MasterTable.Rows[0]["PackReq"]); 
  				m_QualityReq=SysConvert.ToString(MasterTable.Rows[0]["QualityReq"]); 
  				m_DeliveryReq=SysConvert.ToString(MasterTable.Rows[0]["DeliveryReq"]); 
  				m_OtherReq=SysConvert.ToString(MasterTable.Rows[0]["OtherReq"]); 
  				m_VAddress=SysConvert.ToString(MasterTable.Rows[0]["VAddress"]); 
  				m_VTelephone=SysConvert.ToString(MasterTable.Rows[0]["VTelephone"]); 
  				m_VFax=SysConvert.ToString(MasterTable.Rows[0]["VFax"]); 
  				m_VEmail=SysConvert.ToString(MasterTable.Rows[0]["VEmail"]); 
  				m_JiaoQi=SysConvert.ToDateTime(MasterTable.Rows[0]["JiaoQi"]); 
  				m_YongJing=SysConvert.ToString(MasterTable.Rows[0]["YongJing"]); 
  				m_GangKou=SysConvert.ToString(MasterTable.Rows[0]["GangKou"]); 
  				m_KHType=SysConvert.ToString(MasterTable.Rows[0]["KHType"]); 
  				m_ZZMarket=SysConvert.ToString(MasterTable.Rows[0]["ZZMarket"]); 
  				m_AuditTime=SysConvert.ToDateTime(MasterTable.Rows[0]["AuditTime"]); 
  				m_BJSaleOPID=SysConvert.ToString(MasterTable.Rows[0]["BJSaleOPID"]); 
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
