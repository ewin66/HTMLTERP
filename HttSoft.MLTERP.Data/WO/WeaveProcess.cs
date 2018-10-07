using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WO_WeaveProcess实体类
	/// 作者:翟晓东
	/// 创建日期:2012/8/29
	/// </summary>
	public sealed class WeaveProcess : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public WeaveProcess()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public WeaveProcess(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_WeaveProcess";
		 
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
  
  		private string m_DyeFactory = string.Empty ; 
  		public string DyeFactory 
  		{ 
  			get 
  			{ 
  				return m_DyeFactory ; 
  			}  
  			set 
  			{ 
  				m_DyeFactory = value ; 
  			}  
  		} 
  
  		private string m_CustomerReq = string.Empty ; 
  		public string CustomerReq 
  		{ 
  			get 
  			{ 
  				return m_CustomerReq ; 
  			}  
  			set 
  			{ 
  				m_CustomerReq = value ; 
  			}  
  		} 
  
  		private decimal m_LossQty = 0; 
  		public decimal LossQty 
  		{ 
  			get 
  			{ 
  				return m_LossQty ; 
  			}  
  			set 
  			{ 
  				m_LossQty = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM WO_WeaveProcess WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_WeaveProcess WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_DyeFactory=SysConvert.ToString(MasterTable.Rows[0]["DyeFactory"]); 
  				m_CustomerReq=SysConvert.ToString(MasterTable.Rows[0]["CustomerReq"]); 
  				m_LossQty=SysConvert.ToDecimal(MasterTable.Rows[0]["LossQty"]); 
  				m_SendAddress=SysConvert.ToString(MasterTable.Rows[0]["SendAddress"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_NLQty=SysConvert.ToDecimal(MasterTable.Rows[0]["NLQty"]); 
  				m_NLFormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["NLFormDate"]); 
  				m_InQty=SysConvert.ToDecimal(MasterTable.Rows[0]["InQty"]); 
  				m_InFormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["InFormDate"]); 
  				m_OutQty=SysConvert.ToDecimal(MasterTable.Rows[0]["OutQty"]); 
  				m_OutFormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["OutFormDate"]); 
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
