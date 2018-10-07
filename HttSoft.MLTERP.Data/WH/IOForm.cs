using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WH_IOForm实体类
	/// 作者:XUSC
	/// 创建日期:2016/1/20
	/// </summary>
	public sealed class IOForm : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public IOForm()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public IOForm(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WH_IOForm";
		 
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
  
  		private string m_VendorOPID = string.Empty ; 
  		public string VendorOPID 
  		{ 
  			get 
  			{ 
  				return m_VendorOPID ; 
  			}  
  			set 
  			{ 
  				m_VendorOPID = value ; 
  			}  
  		} 
  
  		private string m_VendorTel = string.Empty ; 
  		public string VendorTel 
  		{ 
  			get 
  			{ 
  				return m_VendorTel ; 
  			}  
  			set 
  			{ 
  				m_VendorTel = value ; 
  			}  
  		} 
  
  		private string m_Address = string.Empty ; 
  		public string Address 
  		{ 
  			get 
  			{ 
  				return m_Address ; 
  			}  
  			set 
  			{ 
  				m_Address = value ; 
  			}  
  		} 
  
  		private int m_PackQty = 0; 
  		public int PackQty 
  		{ 
  			get 
  			{ 
  				return m_PackQty ; 
  			}  
  			set 
  			{ 
  				m_PackQty = value ; 
  			}  
  		} 
  
  		private decimal m_PackSinglePrice = 0; 
  		public decimal PackSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_PackSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_PackSinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_PackAmount = 0; 
  		public decimal PackAmount 
  		{ 
  			get 
  			{ 
  				return m_PackAmount ; 
  			}  
  			set 
  			{ 
  				m_PackAmount = value ; 
  			}  
  		} 
  
  		private string m_Description = string.Empty ; 
  		public string Description 
  		{ 
  			get 
  			{ 
  				return m_Description ; 
  			}  
  			set 
  			{ 
  				m_Description = value ; 
  			}  
  		} 
  
  		private string m_Destination = string.Empty ; 
  		public string Destination 
  		{ 
  			get 
  			{ 
  				return m_Destination ; 
  			}  
  			set 
  			{ 
  				m_Destination = value ; 
  			}  
  		} 
  
  		private string m_RecordOPID1 = string.Empty ; 
  		public string RecordOPID1 
  		{ 
  			get 
  			{ 
  				return m_RecordOPID1 ; 
  			}  
  			set 
  			{ 
  				m_RecordOPID1 = value ; 
  			}  
  		} 
  
  		private string m_RecordOPID2 = string.Empty ; 
  		public string RecordOPID2 
  		{ 
  			get 
  			{ 
  				return m_RecordOPID2 ; 
  			}  
  			set 
  			{ 
  				m_RecordOPID2 = value ; 
  			}  
  		} 
  
  		private string m_RecordSBOPID1 = string.Empty ; 
  		public string RecordSBOPID1 
  		{ 
  			get 
  			{ 
  				return m_RecordSBOPID1 ; 
  			}  
  			set 
  			{ 
  				m_RecordSBOPID1 = value ; 
  			}  
  		} 
  
  		private string m_RecordSBOPID2 = string.Empty ; 
  		public string RecordSBOPID2 
  		{ 
  			get 
  			{ 
  				return m_RecordSBOPID2 ; 
  			}  
  			set 
  			{ 
  				m_RecordSBOPID2 = value ; 
  			}  
  		} 
  
  		private string m_RecordSBOPID3 = string.Empty ; 
  		public string RecordSBOPID3 
  		{ 
  			get 
  			{ 
  				return m_RecordSBOPID3 ; 
  			}  
  			set 
  			{ 
  				m_RecordSBOPID3 = value ; 
  			}  
  		} 
  
  		private string m_RecordSBOPID4 = string.Empty ; 
  		public string RecordSBOPID4 
  		{ 
  			get 
  			{ 
  				return m_RecordSBOPID4 ; 
  			}  
  			set 
  			{ 
  				m_RecordSBOPID4 = value ; 
  			}  
  		} 
  
  		private string m_RecordSBOPID5 = string.Empty ; 
  		public string RecordSBOPID5 
  		{ 
  			get 
  			{ 
  				return m_RecordSBOPID5 ; 
  			}  
  			set 
  			{ 
  				m_RecordSBOPID5 = value ; 
  			}  
  		} 
  
  		private string m_RecordYSOPID1 = string.Empty ; 
  		public string RecordYSOPID1 
  		{ 
  			get 
  			{ 
  				return m_RecordYSOPID1 ; 
  			}  
  			set 
  			{ 
  				m_RecordYSOPID1 = value ; 
  			}  
  		} 
  
  		private decimal m_DZQty = 0; 
  		public decimal DZQty 
  		{ 
  			get 
  			{ 
  				return m_DZQty ; 
  			}  
  			set 
  			{ 
  				m_DZQty = value ; 
  			}  
  		} 
  
  		private decimal m_DZSinglePrice = 0; 
  		public decimal DZSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_DZSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_DZSinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_DZAmount = 0; 
  		public decimal DZAmount 
  		{ 
  			get 
  			{ 
  				return m_DZAmount ; 
  			}  
  			set 
  			{ 
  				m_DZAmount = value ; 
  			}  
  		} 
  
  		private int m_DZFlag = 0; 
  		public int DZFlag 
  		{ 
  			get 
  			{ 
  				return m_DZFlag ; 
  			}  
  			set 
  			{ 
  				m_DZFlag = value ; 
  			}  
  		} 
  
  		private string m_DZOPID = string.Empty ; 
  		public string DZOPID 
  		{ 
  			get 
  			{ 
  				return m_DZOPID ; 
  			}  
  			set 
  			{ 
  				m_DZOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_DZTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime DZTime 
  		{ 
  			get 
  			{ 
  				return m_DZTime ; 
  			}  
  			set 
  			{ 
  				m_DZTime = value ; 
  			}  
  		} 
  
  		private string m_DZNo = string.Empty ; 
  		public string DZNo 
  		{ 
  			get 
  			{ 
  				return m_DZNo ; 
  			}  
  			set 
  			{ 
  				m_DZNo = value ; 
  			}  
  		} 
  
  		private decimal m_InvoiceQty = 0; 
  		public decimal InvoiceQty 
  		{ 
  			get 
  			{ 
  				return m_InvoiceQty ; 
  			}  
  			set 
  			{ 
  				m_InvoiceQty = value ; 
  			}  
  		} 
  
  		private decimal m_InvoiceAmount = 0; 
  		public decimal InvoiceAmount 
  		{ 
  			get 
  			{ 
  				return m_InvoiceAmount ; 
  			}  
  			set 
  			{ 
  				m_InvoiceAmount = value ; 
  			}  
  		} 
  
  		private int m_InvoiceDelFlag = 0; 
  		public int InvoiceDelFlag 
  		{ 
  			get 
  			{ 
  				return m_InvoiceDelFlag ; 
  			}  
  			set 
  			{ 
  				m_InvoiceDelFlag = value ; 
  			}  
  		} 
  
  		private string m_InvoiceDelOPID = string.Empty ; 
  		public string InvoiceDelOPID 
  		{ 
  			get 
  			{ 
  				return m_InvoiceDelOPID ; 
  			}  
  			set 
  			{ 
  				m_InvoiceDelOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_InvoiceDelTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime InvoiceDelTime 
  		{ 
  			get 
  			{ 
  				return m_InvoiceDelTime ; 
  			}  
  			set 
  			{ 
  				m_InvoiceDelTime = value ; 
  			}  
  		} 
  
  		private decimal m_PayAmount = 0; 
  		public decimal PayAmount 
  		{ 
  			get 
  			{ 
  				return m_PayAmount ; 
  			}  
  			set 
  			{ 
  				m_PayAmount = value ; 
  			}  
  		} 
  
  		private int m_ReadFlag = 0; 
  		public int ReadFlag 
  		{ 
  			get 
  			{ 
  				return m_ReadFlag ; 
  			}  
  			set 
  			{ 
  				m_ReadFlag = value ; 
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
            string Sql="SELECT * FROM WH_IOForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_IOForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeOPName=SysConvert.ToString(MasterTable.Rows[0]["MakeOPName"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_VendorOPID=SysConvert.ToString(MasterTable.Rows[0]["VendorOPID"]); 
  				m_VendorTel=SysConvert.ToString(MasterTable.Rows[0]["VendorTel"]); 
  				m_Address=SysConvert.ToString(MasterTable.Rows[0]["Address"]); 
  				m_PackQty=SysConvert.ToInt32(MasterTable.Rows[0]["PackQty"]); 
  				m_PackSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["PackSinglePrice"]); 
  				m_PackAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PackAmount"]); 
  				m_Description=SysConvert.ToString(MasterTable.Rows[0]["Description"]); 
  				m_Destination=SysConvert.ToString(MasterTable.Rows[0]["Destination"]); 
  				m_RecordOPID1=SysConvert.ToString(MasterTable.Rows[0]["RecordOPID1"]); 
  				m_RecordOPID2=SysConvert.ToString(MasterTable.Rows[0]["RecordOPID2"]); 
  				m_RecordSBOPID1=SysConvert.ToString(MasterTable.Rows[0]["RecordSBOPID1"]); 
  				m_RecordSBOPID2=SysConvert.ToString(MasterTable.Rows[0]["RecordSBOPID2"]); 
  				m_RecordSBOPID3=SysConvert.ToString(MasterTable.Rows[0]["RecordSBOPID3"]); 
  				m_RecordSBOPID4=SysConvert.ToString(MasterTable.Rows[0]["RecordSBOPID4"]); 
  				m_RecordSBOPID5=SysConvert.ToString(MasterTable.Rows[0]["RecordSBOPID5"]); 
  				m_RecordYSOPID1=SysConvert.ToString(MasterTable.Rows[0]["RecordYSOPID1"]); 
  				m_DZQty=SysConvert.ToDecimal(MasterTable.Rows[0]["DZQty"]); 
  				m_DZSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["DZSinglePrice"]); 
  				m_DZAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["DZAmount"]); 
  				m_DZFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DZFlag"]); 
  				m_DZOPID=SysConvert.ToString(MasterTable.Rows[0]["DZOPID"]); 
  				m_DZTime=SysConvert.ToDateTime(MasterTable.Rows[0]["DZTime"]); 
  				m_DZNo=SysConvert.ToString(MasterTable.Rows[0]["DZNo"]); 
  				m_InvoiceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["InvoiceQty"]); 
  				m_InvoiceAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["InvoiceAmount"]); 
  				m_InvoiceDelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["InvoiceDelFlag"]); 
  				m_InvoiceDelOPID=SysConvert.ToString(MasterTable.Rows[0]["InvoiceDelOPID"]); 
  				m_InvoiceDelTime=SysConvert.ToDateTime(MasterTable.Rows[0]["InvoiceDelTime"]); 
  				m_PayAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PayAmount"]); 
  				m_ReadFlag=SysConvert.ToInt32(MasterTable.Rows[0]["ReadFlag"]); 
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
