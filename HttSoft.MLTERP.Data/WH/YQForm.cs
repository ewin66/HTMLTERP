using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WH_YQForm实体类
	/// 作者:章文强
	/// 创建日期:2013/5/30
	/// </summary>
	public sealed class YQForm : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public YQForm()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public YQForm(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WH_YQForm";
		 
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
  
  		private int m_FromIOFormID = 0; 
  		public int FromIOFormID 
  		{ 
  			get 
  			{ 
  				return m_FromIOFormID ; 
  			}  
  			set 
  			{ 
  				m_FromIOFormID = value ; 
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
  
  		private int m_WHTypeID = 0; 
  		public int WHTypeID 
  		{ 
  			get 
  			{ 
  				return m_WHTypeID ; 
  			}  
  			set 
  			{ 
  				m_WHTypeID = value ; 
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
  
  		private int m_HeadType = 0; 
  		public int HeadType 
  		{ 
  			get 
  			{ 
  				return m_HeadType ; 
  			}  
  			set 
  			{ 
  				m_HeadType = value ; 
  			}  
  		} 
  
  		private int m_SubType = 0; 
  		public int SubType 
  		{ 
  			get 
  			{ 
  				return m_SubType ; 
  			}  
  			set 
  			{ 
  				m_SubType = value ; 
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
  
  		private string m_OutDep = string.Empty ; 
  		public string OutDep 
  		{ 
  			get 
  			{ 
  				return m_OutDep ; 
  			}  
  			set 
  			{ 
  				m_OutDep = value ; 
  			}  
  		} 
  
  		private string m_Indep = string.Empty ; 
  		public string Indep 
  		{ 
  			get 
  			{ 
  				return m_Indep ; 
  			}  
  			set 
  			{ 
  				m_Indep = value ; 
  			}  
  		} 
  
  		private string m_WHOP = string.Empty ; 
  		public string WHOP 
  		{ 
  			get 
  			{ 
  				return m_WHOP ; 
  			}  
  			set 
  			{ 
  				m_WHOP = value ; 
  			}  
  		} 
  
  		private string m_PassOP = string.Empty ; 
  		public string PassOP 
  		{ 
  			get 
  			{ 
  				return m_PassOP ; 
  			}  
  			set 
  			{ 
  				m_PassOP = value ; 
  			}  
  		} 
  
  		private string m_DutyOP = string.Empty ; 
  		public string DutyOP 
  		{ 
  			get 
  			{ 
  				return m_DutyOP ; 
  			}  
  			set 
  			{ 
  				m_DutyOP = value ; 
  			}  
  		} 
  
  		private string m_SOID = string.Empty ; 
  		public string SOID 
  		{ 
  			get 
  			{ 
  				return m_SOID ; 
  			}  
  			set 
  			{ 
  				m_SOID = value ; 
  			}  
  		} 
  
  		private string m_SpecialNo = string.Empty ; 
  		public string SpecialNo 
  		{ 
  			get 
  			{ 
  				return m_SpecialNo ; 
  			}  
  			set 
  			{ 
  				m_SpecialNo = value ; 
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
  
  		private string m_CardNo = string.Empty ; 
  		public string CardNo 
  		{ 
  			get 
  			{ 
  				return m_CardNo ; 
  			}  
  			set 
  			{ 
  				m_CardNo = value ; 
  			}  
  		} 
  
  		private int m_ConfirmFlag = 0; 
  		public int ConfirmFlag 
  		{ 
  			get 
  			{ 
  				return m_ConfirmFlag ; 
  			}  
  			set 
  			{ 
  				m_ConfirmFlag = value ; 
  			}  
  		} 
  
  		private string m_CheckOP = string.Empty ; 
  		public string CheckOP 
  		{ 
  			get 
  			{ 
  				return m_CheckOP ; 
  			}  
  			set 
  			{ 
  				m_CheckOP = value ; 
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
  
  		private string m_WHType = string.Empty ; 
  		public string WHType 
  		{ 
  			get 
  			{ 
  				return m_WHType ; 
  			}  
  			set 
  			{ 
  				m_WHType = value ; 
  			}  
  		} 
  
  		private DateTime m_LastUpdTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime LastUpdTime 
  		{ 
  			get 
  			{ 
  				return m_LastUpdTime ; 
  			}  
  			set 
  			{ 
  				m_LastUpdTime = value ; 
  			}  
  		} 
  
  		private string m_LastUpdOP = string.Empty ; 
  		public string LastUpdOP 
  		{ 
  			get 
  			{ 
  				return m_LastUpdOP ; 
  			}  
  			set 
  			{ 
  				m_LastUpdOP = value ; 
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
  
  		private string m_JHCode = string.Empty ; 
  		public string JHCode 
  		{ 
  			get 
  			{ 
  				return m_JHCode ; 
  			}  
  			set 
  			{ 
  				m_JHCode = value ; 
  			}  
  		} 
  
  		private string m_XZ = string.Empty ; 
  		public string XZ 
  		{ 
  			get 
  			{ 
  				return m_XZ ; 
  			}  
  			set 
  			{ 
  				m_XZ = value ; 
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
  
  		private string m_DM = string.Empty ; 
  		public string DM 
  		{ 
  			get 
  			{ 
  				return m_DM ; 
  			}  
  			set 
  			{ 
  				m_DM = value ; 
  			}  
  		} 
  
  		private string m_InvoiceNo = string.Empty ; 
  		public string InvoiceNo 
  		{ 
  			get 
  			{ 
  				return m_InvoiceNo ; 
  			}  
  			set 
  			{ 
  				m_InvoiceNo = value ; 
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
  
  		private int m_FHTypeID = 0; 
  		public int FHTypeID 
  		{ 
  			get 
  			{ 
  				return m_FHTypeID ; 
  			}  
  			set 
  			{ 
  				m_FHTypeID = value ; 
  			}  
  		} 
  
  		private string m_KDNo = string.Empty ; 
  		public string KDNo 
  		{ 
  			get 
  			{ 
  				return m_KDNo ; 
  			}  
  			set 
  			{ 
  				m_KDNo = value ; 
  			}  
  		} 
  
  		private int m_DEFlag = 0; 
  		public int DEFlag 
  		{ 
  			get 
  			{ 
  				return m_DEFlag ; 
  			}  
  			set 
  			{ 
  				m_DEFlag = value ; 
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
            string Sql="SELECT * FROM WH_YQForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_YQForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FromIOFormID=SysConvert.ToInt32(MasterTable.Rows[0]["FromIOFormID"]); 
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_WHTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["WHTypeID"]); 
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_HeadType=SysConvert.ToInt32(MasterTable.Rows[0]["HeadType"]); 
  				m_SubType=SysConvert.ToInt32(MasterTable.Rows[0]["SubType"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_OutDep=SysConvert.ToString(MasterTable.Rows[0]["OutDep"]); 
  				m_Indep=SysConvert.ToString(MasterTable.Rows[0]["Indep"]); 
  				m_WHOP=SysConvert.ToString(MasterTable.Rows[0]["WHOP"]); 
  				m_PassOP=SysConvert.ToString(MasterTable.Rows[0]["PassOP"]); 
  				m_DutyOP=SysConvert.ToString(MasterTable.Rows[0]["DutyOP"]); 
  				m_SOID=SysConvert.ToString(MasterTable.Rows[0]["SOID"]); 
  				m_SpecialNo=SysConvert.ToString(MasterTable.Rows[0]["SpecialNo"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_CardNo=SysConvert.ToString(MasterTable.Rows[0]["CardNo"]); 
  				m_ConfirmFlag=SysConvert.ToInt32(MasterTable.Rows[0]["ConfirmFlag"]); 
  				m_CheckOP=SysConvert.ToString(MasterTable.Rows[0]["CheckOP"]); 
  				m_CheckDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CheckDate"]); 
  				m_WHID=SysConvert.ToString(MasterTable.Rows[0]["WHID"]); 
  				m_WHType=SysConvert.ToString(MasterTable.Rows[0]["WHType"]); 
  				m_LastUpdTime=SysConvert.ToDateTime(MasterTable.Rows[0]["LastUpdTime"]); 
  				m_LastUpdOP=SysConvert.ToString(MasterTable.Rows[0]["LastUpdOP"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_JHCode=SysConvert.ToString(MasterTable.Rows[0]["JHCode"]); 
  				m_XZ=SysConvert.ToString(MasterTable.Rows[0]["XZ"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_DM=SysConvert.ToString(MasterTable.Rows[0]["DM"]); 
  				m_InvoiceNo=SysConvert.ToString(MasterTable.Rows[0]["InvoiceNo"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_SubmitOPID=SysConvert.ToString(MasterTable.Rows[0]["SubmitOPID"]); 
  				m_SubmitTime=SysConvert.ToDateTime(MasterTable.Rows[0]["SubmitTime"]); 
  				m_FHTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["FHTypeID"]); 
  				m_KDNo=SysConvert.ToString(MasterTable.Rows[0]["KDNo"]); 
  				m_DEFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DEFlag"]); 
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
