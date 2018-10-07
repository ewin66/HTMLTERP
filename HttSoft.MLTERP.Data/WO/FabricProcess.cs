using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WO_FabricProcess实体类
	/// 作者:zhp
	/// 创建日期:2016/9/1
	/// </summary>
	public sealed class FabricProcess : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public FabricProcess()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FabricProcess(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_FabricProcess";
		 
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
  
  		private string m_CustomerCode = string.Empty ; 
  		public string CustomerCode 
  		{ 
  			get 
  			{ 
  				return m_CustomerCode ; 
  			}  
  			set 
  			{ 
  				m_CustomerCode = value ; 
  			}  
  		} 
  
  		private int m_OrderTypeID = 0; 
  		public int OrderTypeID 
  		{ 
  			get 
  			{ 
  				return m_OrderTypeID ; 
  			}  
  			set 
  			{ 
  				m_OrderTypeID = value ; 
  			}  
  		} 
  
  		private int m_OrderLevelID = 0; 
  		public int OrderLevelID 
  		{ 
  			get 
  			{ 
  				return m_OrderLevelID ; 
  			}  
  			set 
  			{ 
  				m_OrderLevelID = value ; 
  			}  
  		} 
  
  		private DateTime m_OrderDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime OrderDate 
  		{ 
  			get 
  			{ 
  				return m_OrderDate ; 
  			}  
  			set 
  			{ 
  				m_OrderDate = value ; 
  			}  
  		} 
  
  		private DateTime m_ReqDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ReqDate 
  		{ 
  			get 
  			{ 
  				return m_ReqDate ; 
  			}  
  			set 
  			{ 
  				m_ReqDate = value ; 
  			}  
  		} 
  
  		private string m_OrderFormNo = string.Empty ; 
  		public string OrderFormNo 
  		{ 
  			get 
  			{ 
  				return m_OrderFormNo ; 
  			}  
  			set 
  			{ 
  				m_OrderFormNo = value ; 
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
  
  		private string m_PayMethodID = string.Empty ; 
  		public string PayMethodID 
  		{ 
  			get 
  			{ 
  				return m_PayMethodID ; 
  			}  
  			set 
  			{ 
  				m_PayMethodID = value ; 
  			}  
  		} 
  
  		private string m_ContractDesc = string.Empty ; 
  		public string ContractDesc 
  		{ 
  			get 
  			{ 
  				return m_ContractDesc ; 
  			}  
  			set 
  			{ 
  				m_ContractDesc = value ; 
  			}  
  		} 
  
  		private decimal m_TotalQty = 0; 
  		public decimal TotalQty 
  		{ 
  			get 
  			{ 
  				return m_TotalQty ; 
  			}  
  			set 
  			{ 
  				m_TotalQty = value ; 
  			}  
  		} 
  
  		private decimal m_TotalAmount = 0; 
  		public decimal TotalAmount 
  		{ 
  			get 
  			{ 
  				return m_TotalAmount ; 
  			}  
  			set 
  			{ 
  				m_TotalAmount = value ; 
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
  
  		private int m_WLAmountType = 0; 
  		public int WLAmountType 
  		{ 
  			get 
  			{ 
  				return m_WLAmountType ; 
  			}  
  			set 
  			{ 
  				m_WLAmountType = value ; 
  			}  
  		} 
  
  		private decimal m_WLAmount = 0; 
  		public decimal WLAmount 
  		{ 
  			get 
  			{ 
  				return m_WLAmount ; 
  			}  
  			set 
  			{ 
  				m_WLAmount = value ; 
  			}  
  		} 
  
  		private string m_DyeFactorty = string.Empty ; 
  		public string DyeFactorty 
  		{ 
  			get 
  			{ 
  				return m_DyeFactorty ; 
  			}  
  			set 
  			{ 
  				m_DyeFactorty = value ; 
  			}  
  		} 
  
  		private string m_DyeingReq = string.Empty ; 
  		public string DyeingReq 
  		{ 
  			get 
  			{ 
  				return m_DyeingReq ; 
  			}  
  			set 
  			{ 
  				m_DyeingReq = value ; 
  			}  
  		} 
  
  		private string m_SendAddress = string.Empty ; 
  		public string SendAddress 
  		{ 
  			get 
  			{ 
  				return m_SendAddress ; 
  			}  
  			set 
  			{ 
  				m_SendAddress = value ; 
  			}  
  		} 
  
  		private string m_DyeingTec = string.Empty ; 
  		public string DyeingTec 
  		{ 
  			get 
  			{ 
  				return m_DyeingTec ; 
  			}  
  			set 
  			{ 
  				m_DyeingTec = value ; 
  			}  
  		} 
  
  		private string m_LightSource = string.Empty ; 
  		public string LightSource 
  		{ 
  			get 
  			{ 
  				return m_LightSource ; 
  			}  
  			set 
  			{ 
  				m_LightSource = value ; 
  			}  
  		} 
  
  		private string m_SGReq = string.Empty ; 
  		public string SGReq 
  		{ 
  			get 
  			{ 
  				return m_SGReq ; 
  			}  
  			set 
  			{ 
  				m_SGReq = value ; 
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
  
  		private int m_JGType = 0; 
  		public int JGType 
  		{ 
  			get 
  			{ 
  				return m_JGType ; 
  			}  
  			set 
  			{ 
  				m_JGType = value ; 
  			}  
  		} 
  
  		private int m_ProcessTypeID = 0; 
  		public int ProcessTypeID 
  		{ 
  			get 
  			{ 
  				return m_ProcessTypeID ; 
  			}  
  			set 
  			{ 
  				m_ProcessTypeID = value ; 
  			}  
  		} 
  
  		private int m_WHOutFormFlag = 0; 
  		public int WHOutFormFlag 
  		{ 
  			get 
  			{ 
  				return m_WHOutFormFlag ; 
  			}  
  			set 
  			{ 
  				m_WHOutFormFlag = value ; 
  			}  
  		} 
  
  		private string m_AllItemModel = string.Empty ; 
  		public string AllItemModel 
  		{ 
  			get 
  			{ 
  				return m_AllItemModel ; 
  			}  
  			set 
  			{ 
  				m_AllItemModel = value ; 
  			}  
  		} 
  
  		private string m_WOOtherTypeIDStr = string.Empty ; 
  		public string WOOtherTypeIDStr 
  		{ 
  			get 
  			{ 
  				return m_WOOtherTypeIDStr ; 
  			}  
  			set 
  			{ 
  				m_WOOtherTypeIDStr = value ; 
  			}  
  		} 
  
  		private string m_WOOtherTypeNameStr = string.Empty ; 
  		public string WOOtherTypeNameStr 
  		{ 
  			get 
  			{ 
  				return m_WOOtherTypeNameStr ; 
  			}  
  			set 
  			{ 
  				m_WOOtherTypeNameStr = value ; 
  			}  
  		} 
  
  		private string m_PackMethod = string.Empty ; 
  		public string PackMethod 
  		{ 
  			get 
  			{ 
  				return m_PackMethod ; 
  			}  
  			set 
  			{ 
  				m_PackMethod = value ; 
  			}  
  		} 
  
  		private string m_YHStyle = string.Empty ; 
  		public string YHStyle 
  		{ 
  			get 
  			{ 
  				return m_YHStyle ; 
  			}  
  			set 
  			{ 
  				m_YHStyle = value ; 
  			}  
  		} 
  
  		private string m_GYRequire = string.Empty ; 
  		public string GYRequire 
  		{ 
  			get 
  			{ 
  				return m_GYRequire ; 
  			}  
  			set 
  			{ 
  				m_GYRequire = value ; 
  			}  
  		} 
  
  		private decimal m_Loss = 0; 
  		public decimal Loss 
  		{ 
  			get 
  			{ 
  				return m_Loss ; 
  			}  
  			set 
  			{ 
  				m_Loss = value ; 
  			}  
  		} 
  
  		private string m_BiLi = string.Empty ; 
  		public string BiLi 
  		{ 
  			get 
  			{ 
  				return m_BiLi ; 
  			}  
  			set 
  			{ 
  				m_BiLi = value ; 
  			}  
  		} 
  
  		private string m_AfterFinish = string.Empty ; 
  		public string AfterFinish 
  		{ 
  			get 
  			{ 
  				return m_AfterFinish ; 
  			}  
  			set 
  			{ 
  				m_AfterFinish = value ; 
  			}  
  		} 
  
  		private string m_ShipMethod = string.Empty ; 
  		public string ShipMethod 
  		{ 
  			get 
  			{ 
  				return m_ShipMethod ; 
  			}  
  			set 
  			{ 
  				m_ShipMethod = value ; 
  			}  
  		} 
  
  		private int m_ProductionID = 0; 
  		public int ProductionID 
  		{ 
  			get 
  			{ 
  				return m_ProductionID ; 
  			}  
  			set 
  			{ 
  				m_ProductionID = value ; 
  			}  
  		} 
  
  		private int m_HZTypeID = 0; 
  		public int HZTypeID 
  		{ 
  			get 
  			{ 
  				return m_HZTypeID ; 
  			}  
  			set 
  			{ 
  				m_HZTypeID = value ; 
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
  
  		private string m_GenDan = string.Empty ; 
  		public string GenDan 
  		{ 
  			get 
  			{ 
  				return m_GenDan ; 
  			}  
  			set 
  			{ 
  				m_GenDan = value ; 
  			}  
  		} 
  
  		private string m_LightSource2 = string.Empty ; 
  		public string LightSource2 
  		{ 
  			get 
  			{ 
  				return m_LightSource2 ; 
  			}  
  			set 
  			{ 
  				m_LightSource2 = value ; 
  			}  
  		} 
  
  		private string m_LightSource3 = string.Empty ; 
  		public string LightSource3 
  		{ 
  			get 
  			{ 
  				return m_LightSource3 ; 
  			}  
  			set 
  			{ 
  				m_LightSource3 = value ; 
  			}  
  		} 
  
  		private string m_OrderType = string.Empty ; 
  		public string OrderType 
  		{ 
  			get 
  			{ 
  				return m_OrderType ; 
  			}  
  			set 
  			{ 
  				m_OrderType = value ; 
  			}  
  		} 
  
  		private string m_PriceReportID = string.Empty ; 
  		public string PriceReportID 
  		{ 
  			get 
  			{ 
  				return m_PriceReportID ; 
  			}  
  			set 
  			{ 
  				m_PriceReportID = value ; 
  			}  
  		} 
  
  		private string m_GongXu = string.Empty ; 
  		public string GongXu 
  		{ 
  			get 
  			{ 
  				return m_GongXu ; 
  			}  
  			set 
  			{ 
  				m_GongXu = value ; 
  			}  
  		} 
  
  		private string m_RCVendorID = string.Empty ; 
  		public string RCVendorID 
  		{ 
  			get 
  			{ 
  				return m_RCVendorID ; 
  			}  
  			set 
  			{ 
  				m_RCVendorID = value ; 
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
            string Sql="SELECT * FROM WO_FabricProcess WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_FabricProcess WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_CustomerCode=SysConvert.ToString(MasterTable.Rows[0]["CustomerCode"]); 
  				m_OrderTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderTypeID"]); 
  				m_OrderLevelID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderLevelID"]); 
  				m_OrderDate=SysConvert.ToDateTime(MasterTable.Rows[0]["OrderDate"]); 
  				m_ReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ReqDate"]); 
  				m_OrderFormNo=SysConvert.ToString(MasterTable.Rows[0]["OrderFormNo"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_PayMethodID=SysConvert.ToString(MasterTable.Rows[0]["PayMethodID"]); 
  				m_ContractDesc=SysConvert.ToString(MasterTable.Rows[0]["ContractDesc"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_OrderPreStepID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderPreStepID"]); 
  				m_OrderStepID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderStepID"]); 
  				m_PayMethodFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PayMethodFlag"]); 
  				m_StatusFlag=SysConvert.ToInt32(MasterTable.Rows[0]["StatusFlag"]); 
  				m_StatusName=SysConvert.ToString(MasterTable.Rows[0]["StatusName"]); 
  				m_WLAmountType=SysConvert.ToInt32(MasterTable.Rows[0]["WLAmountType"]); 
  				m_WLAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["WLAmount"]); 
  				m_DyeFactorty=SysConvert.ToString(MasterTable.Rows[0]["DyeFactorty"]); 
  				m_DyeingReq=SysConvert.ToString(MasterTable.Rows[0]["DyeingReq"]); 
  				m_SendAddress=SysConvert.ToString(MasterTable.Rows[0]["SendAddress"]); 
  				m_DyeingTec=SysConvert.ToString(MasterTable.Rows[0]["DyeingTec"]); 
  				m_LightSource=SysConvert.ToString(MasterTable.Rows[0]["LightSource"]); 
  				m_SGReq=SysConvert.ToString(MasterTable.Rows[0]["SGReq"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_NLQty=SysConvert.ToDecimal(MasterTable.Rows[0]["NLQty"]); 
  				m_NLFormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["NLFormDate"]); 
  				m_InQty=SysConvert.ToDecimal(MasterTable.Rows[0]["InQty"]); 
  				m_InFormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["InFormDate"]); 
  				m_OutQty=SysConvert.ToDecimal(MasterTable.Rows[0]["OutQty"]); 
  				m_OutFormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["OutFormDate"]); 
  				m_JGType=SysConvert.ToInt32(MasterTable.Rows[0]["JGType"]); 
  				m_ProcessTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["ProcessTypeID"]); 
  				m_WHOutFormFlag=SysConvert.ToInt32(MasterTable.Rows[0]["WHOutFormFlag"]); 
  				m_AllItemModel=SysConvert.ToString(MasterTable.Rows[0]["AllItemModel"]); 
  				m_WOOtherTypeIDStr=SysConvert.ToString(MasterTable.Rows[0]["WOOtherTypeIDStr"]); 
  				m_WOOtherTypeNameStr=SysConvert.ToString(MasterTable.Rows[0]["WOOtherTypeNameStr"]); 
  				m_PackMethod=SysConvert.ToString(MasterTable.Rows[0]["PackMethod"]); 
  				m_YHStyle=SysConvert.ToString(MasterTable.Rows[0]["YHStyle"]); 
  				m_GYRequire=SysConvert.ToString(MasterTable.Rows[0]["GYRequire"]); 
  				m_Loss=SysConvert.ToDecimal(MasterTable.Rows[0]["Loss"]); 
  				m_BiLi=SysConvert.ToString(MasterTable.Rows[0]["BiLi"]); 
  				m_AfterFinish=SysConvert.ToString(MasterTable.Rows[0]["AfterFinish"]); 
  				m_ShipMethod=SysConvert.ToString(MasterTable.Rows[0]["ShipMethod"]); 
  				m_ProductionID=SysConvert.ToInt32(MasterTable.Rows[0]["ProductionID"]); 
  				m_HZTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["HZTypeID"]); 
  				m_AuditTime=SysConvert.ToDateTime(MasterTable.Rows[0]["AuditTime"]); 
  				m_GenDan=SysConvert.ToString(MasterTable.Rows[0]["GenDan"]); 
  				m_LightSource2=SysConvert.ToString(MasterTable.Rows[0]["LightSource2"]); 
  				m_LightSource3=SysConvert.ToString(MasterTable.Rows[0]["LightSource3"]); 
  				m_OrderType=SysConvert.ToString(MasterTable.Rows[0]["OrderType"]); 
  				m_PriceReportID=SysConvert.ToString(MasterTable.Rows[0]["PriceReportID"]); 
  				m_GongXu=SysConvert.ToString(MasterTable.Rows[0]["GongXu"]); 
  				m_RCVendorID=SysConvert.ToString(MasterTable.Rows[0]["RCVendorID"]); 
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
