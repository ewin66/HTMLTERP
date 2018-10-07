using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Ship_ShipBoat实体类
	/// 作者:qiuchao
	/// 创建日期:2015/7/27
	/// </summary>
	public sealed class ShipBoat : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ShipBoat()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ShipBoat(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Ship_ShipBoat";
		 
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
  
  		private string m_IvoiceNo = string.Empty ; 
  		public string IvoiceNo 
  		{ 
  			get 
  			{ 
  				return m_IvoiceNo ; 
  			}  
  			set 
  			{ 
  				m_IvoiceNo = value ; 
  			}  
  		} 
  
  		private int m_CompanyTypeID = 0; 
  		public int CompanyTypeID 
  		{ 
  			get 
  			{ 
  				return m_CompanyTypeID ; 
  			}  
  			set 
  			{ 
  				m_CompanyTypeID = value ; 
  			}  
  		} 
  
  		private string m_SaleNo = string.Empty ; 
  		public string SaleNo 
  		{ 
  			get 
  			{ 
  				return m_SaleNo ; 
  			}  
  			set 
  			{ 
  				m_SaleNo = value ; 
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
  
  		private string m_Model = string.Empty ; 
  		public string Model 
  		{ 
  			get 
  			{ 
  				return m_Model ; 
  			}  
  			set 
  			{ 
  				m_Model = value ; 
  			}  
  		} 
  
  		private string m_ModelEn = string.Empty ; 
  		public string ModelEn 
  		{ 
  			get 
  			{ 
  				return m_ModelEn ; 
  			}  
  			set 
  			{ 
  				m_ModelEn = value ; 
  			}  
  		} 
  
  		private DateTime m_ShipDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ShipDate 
  		{ 
  			get 
  			{ 
  				return m_ShipDate ; 
  			}  
  			set 
  			{ 
  				m_ShipDate = value ; 
  			}  
  		} 
  
  		private DateTime m_RevisedDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime RevisedDate 
  		{ 
  			get 
  			{ 
  				return m_RevisedDate ; 
  			}  
  			set 
  			{ 
  				m_RevisedDate = value ; 
  			}  
  		} 
  
  		private DateTime m_OutDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime OutDate 
  		{ 
  			get 
  			{ 
  				return m_OutDate ; 
  			}  
  			set 
  			{ 
  				m_OutDate = value ; 
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
  
  		private string m_GainType = string.Empty ; 
  		public string GainType 
  		{ 
  			get 
  			{ 
  				return m_GainType ; 
  			}  
  			set 
  			{ 
  				m_GainType = value ; 
  			}  
  		} 
  
  		private string m_ReceiveType = string.Empty ; 
  		public string ReceiveType 
  		{ 
  			get 
  			{ 
  				return m_ReceiveType ; 
  			}  
  			set 
  			{ 
  				m_ReceiveType = value ; 
  			}  
  		} 
  
  		private string m_TransType = string.Empty ; 
  		public string TransType 
  		{ 
  			get 
  			{ 
  				return m_TransType ; 
  			}  
  			set 
  			{ 
  				m_TransType = value ; 
  			}  
  		} 
  
  		private string m_ShipTo = string.Empty ; 
  		public string ShipTo 
  		{ 
  			get 
  			{ 
  				return m_ShipTo ; 
  			}  
  			set 
  			{ 
  				m_ShipTo = value ; 
  			}  
  		} 
  
  		private string m_FactoryID = string.Empty ; 
  		public string FactoryID 
  		{ 
  			get 
  			{ 
  				return m_FactoryID ; 
  			}  
  			set 
  			{ 
  				m_FactoryID = value ; 
  			}  
  		} 
  
  		private DateTime m_OutFacDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime OutFacDate 
  		{ 
  			get 
  			{ 
  				return m_OutFacDate ; 
  			}  
  			set 
  			{ 
  				m_OutFacDate = value ; 
  			}  
  		} 
  
  		private DateTime m_ExportDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ExportDate 
  		{ 
  			get 
  			{ 
  				return m_ExportDate ; 
  			}  
  			set 
  			{ 
  				m_ExportDate = value ; 
  			}  
  		} 
  
  		private string m_Messrs = string.Empty ; 
  		public string Messrs 
  		{ 
  			get 
  			{ 
  				return m_Messrs ; 
  			}  
  			set 
  			{ 
  				m_Messrs = value ; 
  			}  
  		} 
  
  		private string m_SpeRequest = string.Empty ; 
  		public string SpeRequest 
  		{ 
  			get 
  			{ 
  				return m_SpeRequest ; 
  			}  
  			set 
  			{ 
  				m_SpeRequest = value ; 
  			}  
  		} 
  
  		private string m_SCNo = string.Empty ; 
  		public string SCNo 
  		{ 
  			get 
  			{ 
  				return m_SCNo ; 
  			}  
  			set 
  			{ 
  				m_SCNo = value ; 
  			}  
  		} 
  
  		private string m_BoatName = string.Empty ; 
  		public string BoatName 
  		{ 
  			get 
  			{ 
  				return m_BoatName ; 
  			}  
  			set 
  			{ 
  				m_BoatName = value ; 
  			}  
  		} 
  
  		private string m_Container = string.Empty ; 
  		public string Container 
  		{ 
  			get 
  			{ 
  				return m_Container ; 
  			}  
  			set 
  			{ 
  				m_Container = value ; 
  			}  
  		} 
  
  		private string m_Special = string.Empty ; 
  		public string Special 
  		{ 
  			get 
  			{ 
  				return m_Special ; 
  			}  
  			set 
  			{ 
  				m_Special = value ; 
  			}  
  		} 
  
  		private decimal m_CroosWeight = 0; 
  		public decimal CroosWeight 
  		{ 
  			get 
  			{ 
  				return m_CroosWeight ; 
  			}  
  			set 
  			{ 
  				m_CroosWeight = value ; 
  			}  
  		} 
  
  		private decimal m_NetWeight = 0; 
  		public decimal NetWeight 
  		{ 
  			get 
  			{ 
  				return m_NetWeight ; 
  			}  
  			set 
  			{ 
  				m_NetWeight = value ; 
  			}  
  		} 
  
  		private decimal m_PackNum = 0; 
  		public decimal PackNum 
  		{ 
  			get 
  			{ 
  				return m_PackNum ; 
  			}  
  			set 
  			{ 
  				m_PackNum = value ; 
  			}  
  		} 
  
  		private string m_Shippers = string.Empty ; 
  		public string Shippers 
  		{ 
  			get 
  			{ 
  				return m_Shippers ; 
  			}  
  			set 
  			{ 
  				m_Shippers = value ; 
  			}  
  		} 
  
  		private string m_Consignee = string.Empty ; 
  		public string Consignee 
  		{ 
  			get 
  			{ 
  				return m_Consignee ; 
  			}  
  			set 
  			{ 
  				m_Consignee = value ; 
  			}  
  		} 
  
  		private string m_NotifyParty = string.Empty ; 
  		public string NotifyParty 
  		{ 
  			get 
  			{ 
  				return m_NotifyParty ; 
  			}  
  			set 
  			{ 
  				m_NotifyParty = value ; 
  			}  
  		} 
  
  		private string m_PortLoading = string.Empty ; 
  		public string PortLoading 
  		{ 
  			get 
  			{ 
  				return m_PortLoading ; 
  			}  
  			set 
  			{ 
  				m_PortLoading = value ; 
  			}  
  		} 
  
  		private string m_PortDischarge = string.Empty ; 
  		public string PortDischarge 
  		{ 
  			get 
  			{ 
  				return m_PortDischarge ; 
  			}  
  			set 
  			{ 
  				m_PortDischarge = value ; 
  			}  
  		} 
  
  		private string m_LCNo = string.Empty ; 
  		public string LCNo 
  		{ 
  			get 
  			{ 
  				return m_LCNo ; 
  			}  
  			set 
  			{ 
  				m_LCNo = value ; 
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
  
  		private DateTime m_AddTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime AddTime 
  		{ 
  			get 
  			{ 
  				return m_AddTime ; 
  			}  
  			set 
  			{ 
  				m_AddTime = value ; 
  			}  
  		} 
  
  		private string m_AddOPID = string.Empty ; 
  		public string AddOPID 
  		{ 
  			get 
  			{ 
  				return m_AddOPID ; 
  			}  
  			set 
  			{ 
  				m_AddOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_UpdTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime UpdTime 
  		{ 
  			get 
  			{ 
  				return m_UpdTime ; 
  			}  
  			set 
  			{ 
  				m_UpdTime = value ; 
  			}  
  		} 
  
  		private string m_UpdOPID = string.Empty ; 
  		public string UpdOPID 
  		{ 
  			get 
  			{ 
  				return m_UpdOPID ; 
  			}  
  			set 
  			{ 
  				m_UpdOPID = value ; 
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
  
  		private DateTime m_SubmitTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SubmitTime 
  		{ 
  			get 
  			{ 
  				return m_SubmitTime ; 
  			}  
  			set 
  			{ 
  				m_SubmitTime = value ; 
  			}  
  		} 
  
  		private string m_SubmitOPID = string.Empty ; 
  		public string SubmitOPID 
  		{ 
  			get 
  			{ 
  				return m_SubmitOPID ; 
  			}  
  			set 
  			{ 
  				m_SubmitOPID = value ; 
  			}  
  		} 
  
  		private int m_AuditFlag = 0; 
  		public int AuditFlag 
  		{ 
  			get 
  			{ 
  				return m_AuditFlag ; 
  			}  
  			set 
  			{ 
  				m_AuditFlag = value ; 
  			}  
  		} 
  
  		private string m_FromOPName = string.Empty ; 
  		public string FromOPName 
  		{ 
  			get 
  			{ 
  				return m_FromOPName ; 
  			}  
  			set 
  			{ 
  				m_FromOPName = value ; 
  			}  
  		} 
  
  		private string m_ToOPName = string.Empty ; 
  		public string ToOPName 
  		{ 
  			get 
  			{ 
  				return m_ToOPName ; 
  			}  
  			set 
  			{ 
  				m_ToOPName = value ; 
  			}  
  		} 
  
  		private DateTime m_GoodsINWHDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime GoodsINWHDate 
  		{ 
  			get 
  			{ 
  				return m_GoodsINWHDate ; 
  			}  
  			set 
  			{ 
  				m_GoodsINWHDate = value ; 
  			}  
  		} 
  
  		private int m_FormListAID = 0; 
  		public int FormListAID 
  		{ 
  			get 
  			{ 
  				return m_FormListAID ; 
  			}  
  			set 
  			{ 
  				m_FormListAID = value ; 
  			}  
  		} 
  
  		private DateTime m_BoatDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime BoatDate 
  		{ 
  			get 
  			{ 
  				return m_BoatDate ; 
  			}  
  			set 
  			{ 
  				m_BoatDate = value ; 
  			}  
  		} 
  
  		private string m_dex = string.Empty ; 
  		public string dex 
  		{ 
  			get 
  			{ 
  				return m_dex ; 
  			}  
  			set 
  			{ 
  				m_dex = value ; 
  			}  
  		} 
  
  		private string m_Code = string.Empty ; 
  		public string Code 
  		{ 
  			get 
  			{ 
  				return m_Code ; 
  			}  
  			set 
  			{ 
  				m_Code = value ; 
  			}  
  		} 
  
  		private int m_PrintStatus = 0; 
  		public int PrintStatus 
  		{ 
  			get 
  			{ 
  				return m_PrintStatus ; 
  			}  
  			set 
  			{ 
  				m_PrintStatus = value ; 
  			}  
  		} 
  
  		private decimal m_TotalBulk = 0; 
  		public decimal TotalBulk 
  		{ 
  			get 
  			{ 
  				return m_TotalBulk ; 
  			}  
  			set 
  			{ 
  				m_TotalBulk = value ; 
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
            string Sql="SELECT * FROM Ship_ShipBoat WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Ship_ShipBoat WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_IvoiceNo=SysConvert.ToString(MasterTable.Rows[0]["IvoiceNo"]); 
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_SaleNo=SysConvert.ToString(MasterTable.Rows[0]["SaleNo"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_Model=SysConvert.ToString(MasterTable.Rows[0]["Model"]); 
  				m_ModelEn=SysConvert.ToString(MasterTable.Rows[0]["ModelEn"]); 
  				m_ShipDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ShipDate"]); 
  				m_RevisedDate=SysConvert.ToDateTime(MasterTable.Rows[0]["RevisedDate"]); 
  				m_OutDate=SysConvert.ToDateTime(MasterTable.Rows[0]["OutDate"]); 
  				m_TradeType=SysConvert.ToString(MasterTable.Rows[0]["TradeType"]); 
  				m_GainType=SysConvert.ToString(MasterTable.Rows[0]["GainType"]); 
  				m_ReceiveType=SysConvert.ToString(MasterTable.Rows[0]["ReceiveType"]); 
  				m_TransType=SysConvert.ToString(MasterTable.Rows[0]["TransType"]); 
  				m_ShipTo=SysConvert.ToString(MasterTable.Rows[0]["ShipTo"]); 
  				m_FactoryID=SysConvert.ToString(MasterTable.Rows[0]["FactoryID"]); 
  				m_OutFacDate=SysConvert.ToDateTime(MasterTable.Rows[0]["OutFacDate"]); 
  				m_ExportDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ExportDate"]); 
  				m_Messrs=SysConvert.ToString(MasterTable.Rows[0]["Messrs"]); 
  				m_SpeRequest=SysConvert.ToString(MasterTable.Rows[0]["SpeRequest"]); 
  				m_SCNo=SysConvert.ToString(MasterTable.Rows[0]["SCNo"]); 
  				m_BoatName=SysConvert.ToString(MasterTable.Rows[0]["BoatName"]); 
  				m_Container=SysConvert.ToString(MasterTable.Rows[0]["Container"]); 
  				m_Special=SysConvert.ToString(MasterTable.Rows[0]["Special"]); 
  				m_CroosWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["CroosWeight"]); 
  				m_NetWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["NetWeight"]); 
  				m_PackNum=SysConvert.ToDecimal(MasterTable.Rows[0]["PackNum"]); 
  				m_Shippers=SysConvert.ToString(MasterTable.Rows[0]["Shippers"]); 
  				m_Consignee=SysConvert.ToString(MasterTable.Rows[0]["Consignee"]); 
  				m_NotifyParty=SysConvert.ToString(MasterTable.Rows[0]["NotifyParty"]); 
  				m_PortLoading=SysConvert.ToString(MasterTable.Rows[0]["PortLoading"]); 
  				m_PortDischarge=SysConvert.ToString(MasterTable.Rows[0]["PortDischarge"]); 
  				m_LCNo=SysConvert.ToString(MasterTable.Rows[0]["LCNo"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_AddTime=SysConvert.ToDateTime(MasterTable.Rows[0]["AddTime"]); 
  				m_AddOPID=SysConvert.ToString(MasterTable.Rows[0]["AddOPID"]); 
  				m_UpdTime=SysConvert.ToDateTime(MasterTable.Rows[0]["UpdTime"]); 
  				m_UpdOPID=SysConvert.ToString(MasterTable.Rows[0]["UpdOPID"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_SubmitTime=SysConvert.ToDateTime(MasterTable.Rows[0]["SubmitTime"]); 
  				m_SubmitOPID=SysConvert.ToString(MasterTable.Rows[0]["SubmitOPID"]); 
  				m_AuditFlag=SysConvert.ToInt32(MasterTable.Rows[0]["AuditFlag"]); 
  				m_FromOPName=SysConvert.ToString(MasterTable.Rows[0]["FromOPName"]); 
  				m_ToOPName=SysConvert.ToString(MasterTable.Rows[0]["ToOPName"]); 
  				m_GoodsINWHDate=SysConvert.ToDateTime(MasterTable.Rows[0]["GoodsINWHDate"]); 
  				m_FormListAID=SysConvert.ToInt32(MasterTable.Rows[0]["FormListAID"]); 
  				m_BoatDate=SysConvert.ToDateTime(MasterTable.Rows[0]["BoatDate"]); 
  				m_dex=SysConvert.ToString(MasterTable.Rows[0]["dex"]); 
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_PrintStatus=SysConvert.ToInt32(MasterTable.Rows[0]["PrintStatus"]); 
  				m_TotalBulk=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalBulk"]); 
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
