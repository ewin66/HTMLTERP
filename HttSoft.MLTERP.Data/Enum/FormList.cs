using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Enum_FormList实体类
	/// 作者:周富春
	/// 创建日期:2014/11/19
	/// </summary>
	public sealed class FormList : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public FormList()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FormList(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Enum_FormList";
		 
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
  
  		private string m_FormNM = string.Empty ; 
  		public string FormNM 
  		{ 
  			get 
  			{ 
  				return m_FormNM ; 
  			}  
  			set 
  			{ 
  				m_FormNM = value ; 
  			}  
  		} 
  
  		private int m_ParentID = 0; 
  		public int ParentID 
  		{ 
  			get 
  			{ 
  				return m_ParentID ; 
  			}  
  			set 
  			{ 
  				m_ParentID = value ; 
  			}  
  		} 
  
  		private int m_IsShow = 0; 
  		public int IsShow 
  		{ 
  			get 
  			{ 
  				return m_IsShow ; 
  			}  
  			set 
  			{ 
  				m_IsShow = value ; 
  			}  
  		} 
  
  		private int m_FormNoControlID = 0; 
  		public int FormNoControlID 
  		{ 
  			get 
  			{ 
  				return m_FormNoControlID ; 
  			}  
  			set 
  			{ 
  				m_FormNoControlID = value ; 
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
  
  		private int m_CheckFlag = 0; 
  		public int CheckFlag 
  		{ 
  			get 
  			{ 
  				return m_CheckFlag ; 
  			}  
  			set 
  			{ 
  				m_CheckFlag = value ; 
  			}  
  		} 
  
  		private int m_MoveFlag = 0; 
  		public int MoveFlag 
  		{ 
  			get 
  			{ 
  				return m_MoveFlag ; 
  			}  
  			set 
  			{ 
  				m_MoveFlag = value ; 
  			}  
  		} 
  
  		private int m_WHQtyPosID = 0; 
  		public int WHQtyPosID 
  		{ 
  			get 
  			{ 
  				return m_WHQtyPosID ; 
  			}  
  			set 
  			{ 
  				m_WHQtyPosID = value ; 
  			}  
  		} 
  
  		private int m_LoadFormTypeID = 0; 
  		public int LoadFormTypeID 
  		{ 
  			get 
  			{ 
  				return m_LoadFormTypeID ; 
  			}  
  			set 
  			{ 
  				m_LoadFormTypeID = value ; 
  			}  
  		} 
  
  		private int m_FillDataTypeID = 0; 
  		public int FillDataTypeID 
  		{ 
  			get 
  			{ 
  				return m_FillDataTypeID ; 
  			}  
  			set 
  			{ 
  				m_FillDataTypeID = value ; 
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
  
  		private int m_VendorTypeID = 0; 
  		public int VendorTypeID 
  		{ 
  			get 
  			{ 
  				return m_VendorTypeID ; 
  			}  
  			set 
  			{ 
  				m_VendorTypeID = value ; 
  			}  
  		} 
  
  		private int m_VendorTypeID2 = 0; 
  		public int VendorTypeID2 
  		{ 
  			get 
  			{ 
  				return m_VendorTypeID2 ; 
  			}  
  			set 
  			{ 
  				m_VendorTypeID2 = value ; 
  			}  
  		} 
  
  		private int m_VendorTypeID3 = 0; 
  		public int VendorTypeID3 
  		{ 
  			get 
  			{ 
  				return m_VendorTypeID3 ; 
  			}  
  			set 
  			{ 
  				m_VendorTypeID3 = value ; 
  			}  
  		} 
  
  		private int m_VendorTypeID4 = 0; 
  		public int VendorTypeID4 
  		{ 
  			get 
  			{ 
  				return m_VendorTypeID4 ; 
  			}  
  			set 
  			{ 
  				m_VendorTypeID4 = value ; 
  			}  
  		} 
  
  		private int m_VendorTypeID5 = 0; 
  		public int VendorTypeID5 
  		{ 
  			get 
  			{ 
  				return m_VendorTypeID5 ; 
  			}  
  			set 
  			{ 
  				m_VendorTypeID5 = value ; 
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
  
  		private int m_DZType = 0; 
  		public int DZType 
  		{ 
  			get 
  			{ 
  				return m_DZType ; 
  			}  
  			set 
  			{ 
  				m_DZType = value ; 
  			}  
  		} 
  
  		private int m_CaiWuFlag = 0; 
  		public int CaiWuFlag 
  		{ 
  			get 
  			{ 
  				return m_CaiWuFlag ; 
  			}  
  			set 
  			{ 
  				m_CaiWuFlag = value ; 
  			}  
  		} 
  
  		private int m_CaiWuType = 0; 
  		public int CaiWuType 
  		{ 
  			get 
  			{ 
  				return m_CaiWuType ; 
  			}  
  			set 
  			{ 
  				m_CaiWuType = value ; 
  			}  
  		} 
  
  		private int m_InvoiceFlag = 0; 
  		public int InvoiceFlag 
  		{ 
  			get 
  			{ 
  				return m_InvoiceFlag ; 
  			}  
  			set 
  			{ 
  				m_InvoiceFlag = value ; 
  			}  
  		} 
  
  		private int m_IsFreeForm = 0; 
  		public int IsFreeForm 
  		{ 
  			get 
  			{ 
  				return m_IsFreeForm ; 
  			}  
  			set 
  			{ 
  				m_IsFreeForm = value ; 
  			}  
  		} 
  
  		private int m_FreeFormID = 0; 
  		public int FreeFormID 
  		{ 
  			get 
  			{ 
  				return m_FreeFormID ; 
  			}  
  			set 
  			{ 
  				m_FreeFormID = value ; 
  			}  
  		} 
  
  		private int m_IsDelForm = 0; 
  		public int IsDelForm 
  		{ 
  			get 
  			{ 
  				return m_IsDelForm ; 
  			}  
  			set 
  			{ 
  				m_IsDelForm = value ; 
  			}  
  		} 
  
  		private int m_UnLockFlag = 0; 
  		public int UnLockFlag 
  		{ 
  			get 
  			{ 
  				return m_UnLockFlag ; 
  			}  
  			set 
  			{ 
  				m_UnLockFlag = value ; 
  			}  
  		} 
  
  		private int m_DelFormID = 0; 
  		public int DelFormID 
  		{ 
  			get 
  			{ 
  				return m_DelFormID ; 
  			}  
  			set 
  			{ 
  				m_DelFormID = value ; 
  			}  
  		} 
  
  		private int m_LockFlag = 0; 
  		public int LockFlag 
  		{ 
  			get 
  			{ 
  				return m_LockFlag ; 
  			}  
  			set 
  			{ 
  				m_LockFlag = value ; 
  			}  
  		} 
  
  		private int m_CheckSOFlag = 0; 
  		public int CheckSOFlag 
  		{ 
  			get 
  			{ 
  				return m_CheckSOFlag ; 
  			}  
  			set 
  			{ 
  				m_CheckSOFlag = value ; 
  			}  
  		} 
  
  		private int m_SaleFlag = 0; 
  		public int SaleFlag 
  		{ 
  			get 
  			{ 
  				return m_SaleFlag ; 
  			}  
  			set 
  			{ 
  				m_SaleFlag = value ; 
  			}  
  		} 
  
  		private int m_ColorFlag = 0; 
  		public int ColorFlag 
  		{ 
  			get 
  			{ 
  				return m_ColorFlag ; 
  			}  
  			set 
  			{ 
  				m_ColorFlag = value ; 
  			}  
  		} 
  
  		private int m_BuyFlag = 0; 
  		public int BuyFlag 
  		{ 
  			get 
  			{ 
  				return m_BuyFlag ; 
  			}  
  			set 
  			{ 
  				m_BuyFlag = value ; 
  			}  
  		} 
  
  		private string m_PrintTitle = string.Empty ; 
  		public string PrintTitle 
  		{ 
  			get 
  			{ 
  				return m_PrintTitle ; 
  			}  
  			set 
  			{ 
  				m_PrintTitle = value ; 
  			}  
  		} 
  
  		private string m_PrintCondition = string.Empty ; 
  		public string PrintCondition 
  		{ 
  			get 
  			{ 
  				return m_PrintCondition ; 
  			}  
  			set 
  			{ 
  				m_PrintCondition = value ; 
  			}  
  		} 
  
  		private string m_PrintColTitle = string.Empty ; 
  		public string PrintColTitle 
  		{ 
  			get 
  			{ 
  				return m_PrintColTitle ; 
  			}  
  			set 
  			{ 
  				m_PrintColTitle = value ; 
  			}  
  		} 
  
  		private int m_SpecialFlag = 0; 
  		public int SpecialFlag 
  		{ 
  			get 
  			{ 
  				return m_SpecialFlag ; 
  			}  
  			set 
  			{ 
  				m_SpecialFlag = value ; 
  			}  
  		} 
  
  		private int m_RecInvoiceFlag = 0; 
  		public int RecInvoiceFlag 
  		{ 
  			get 
  			{ 
  				return m_RecInvoiceFlag ; 
  			}  
  			set 
  			{ 
  				m_RecInvoiceFlag = value ; 
  			}  
  		} 
  
  		private int m_OthFlag = 0; 
  		public int OthFlag 
  		{ 
  			get 
  			{ 
  				return m_OthFlag ; 
  			}  
  			set 
  			{ 
  				m_OthFlag = value ; 
  			}  
  		} 
  
  		private int m_CaiWuCostFlag = 0; 
  		public int CaiWuCostFlag 
  		{ 
  			get 
  			{ 
  				return m_CaiWuCostFlag ; 
  			}  
  			set 
  			{ 
  				m_CaiWuCostFlag = value ; 
  			}  
  		} 
  
  		private int m_CaiWuCostType = 0; 
  		public int CaiWuCostType 
  		{ 
  			get 
  			{ 
  				return m_CaiWuCostType ; 
  			}  
  			set 
  			{ 
  				m_CaiWuCostType = value ; 
  			}  
  		} 
  
  		private int m_NeedCheckType = 0; 
  		public int NeedCheckType 
  		{ 
  			get 
  			{ 
  				return m_NeedCheckType ; 
  			}  
  			set 
  			{ 
  				m_NeedCheckType = value ; 
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
  
  		private int m_WHFormTypeID = 0; 
  		public int WHFormTypeID 
  		{ 
  			get 
  			{ 
  				return m_WHFormTypeID ; 
  			}  
  			set 
  			{ 
  				m_WHFormTypeID = value ; 
  			}  
  		} 
  
  		private int m_WHSpecialTypeID = 0; 
  		public int WHSpecialTypeID 
  		{ 
  			get 
  			{ 
  				return m_WHSpecialTypeID ; 
  			}  
  			set 
  			{ 
  				m_WHSpecialTypeID = value ; 
  			}  
  		} 
  
  		private string m_DefaultWHID = string.Empty ; 
  		public string DefaultWHID 
  		{ 
  			get 
  			{ 
  				return m_DefaultWHID ; 
  			}  
  			set 
  			{ 
  				m_DefaultWHID = value ; 
  			}  
  		} 
  
  		private string m_VendorIDCaption = string.Empty ; 
  		public string VendorIDCaption 
  		{ 
  			get 
  			{ 
  				return m_VendorIDCaption ; 
  			}  
  			set 
  			{ 
  				m_VendorIDCaption = value ; 
  			}  
  		} 
  
  		private string m_CheckFieldName = string.Empty ; 
  		public string CheckFieldName 
  		{ 
  			get 
  			{ 
  				return m_CheckFieldName ; 
  			}  
  			set 
  			{ 
  				m_CheckFieldName = value ; 
  			}  
  		} 
  
  		private string m_CheckDtsFieldName = string.Empty ; 
  		public string CheckDtsFieldName 
  		{ 
  			get 
  			{ 
  				return m_CheckDtsFieldName ; 
  			}  
  			set 
  			{ 
  				m_CheckDtsFieldName = value ; 
  			}  
  		} 
  
  		private string m_SaleOPCaption = string.Empty ; 
  		public string SaleOPCaption 
  		{ 
  			get 
  			{ 
  				return m_SaleOPCaption ; 
  			}  
  			set 
  			{ 
  				m_SaleOPCaption = value ; 
  			}  
  		} 
  
  		private string m_CompactCodeVisible = string.Empty ; 
  		public string CompactCodeVisible 
  		{ 
  			get 
  			{ 
  				return m_CompactCodeVisible ; 
  			}  
  			set 
  			{ 
  				m_CompactCodeVisible = value ; 
  			}  
  		} 
  
  		private decimal m_CheckQtyPer1 = 0; 
  		public decimal CheckQtyPer1 
  		{ 
  			get 
  			{ 
  				return m_CheckQtyPer1 ; 
  			}  
  			set 
  			{ 
  				m_CheckQtyPer1 = value ; 
  			}  
  		} 
  
  		private decimal m_CheckQtyFrom = 0; 
  		public decimal CheckQtyFrom 
  		{ 
  			get 
  			{ 
  				return m_CheckQtyFrom ; 
  			}  
  			set 
  			{ 
  				m_CheckQtyFrom = value ; 
  			}  
  		} 
  
  		private decimal m_CheckQtyPer2 = 0; 
  		public decimal CheckQtyPer2 
  		{ 
  			get 
  			{ 
  				return m_CheckQtyPer2 ; 
  			}  
  			set 
  			{ 
  				m_CheckQtyPer2 = value ; 
  			}  
  		} 
  
  		private string m_THLoadFormListIDStr = string.Empty ; 
  		public string THLoadFormListIDStr 
  		{ 
  			get 
  			{ 
  				return m_THLoadFormListIDStr ; 
  			}  
  			set 
  			{ 
  				m_THLoadFormListIDStr = value ; 
  			}  
  		} 
  
  		private int m_CBSourceTypeID = 0; 
  		public int CBSourceTypeID 
  		{ 
  			get 
  			{ 
  				return m_CBSourceTypeID ; 
  			}  
  			set 
  			{ 
  				m_CBSourceTypeID = value ; 
  			}  
  		} 
  
  		private int m_DEditReadOnlyFlag = 0; 
  		public int DEditReadOnlyFlag 
  		{ 
  			get 
  			{ 
  				return m_DEditReadOnlyFlag ; 
  			}  
  			set 
  			{ 
  				m_DEditReadOnlyFlag = value ; 
  			}  
  		} 
  
  		private int m_DBFlag = 0; 
  		public int DBFlag 
  		{ 
  			get 
  			{ 
  				return m_DBFlag ; 
  			}  
  			set 
  			{ 
  				m_DBFlag = value ; 
  			}  
  		} 
  
  		private string m_DefaultVendorID = string.Empty ; 
  		public string DefaultVendorID 
  		{ 
  			get 
  			{ 
  				return m_DefaultVendorID ; 
  			}  
  			set 
  			{ 
  				m_DefaultVendorID = value ; 
  			}  
  		} 
  
  		private int m_DefaultSubTypeID = 0; 
  		public int DefaultSubTypeID 
  		{ 
  			get 
  			{ 
  				return m_DefaultSubTypeID ; 
  			}  
  			set 
  			{ 
  				m_DefaultSubTypeID = value ; 
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
            string Sql="SELECT * FROM Enum_FormList WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Enum_FormList WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_FormNM=SysConvert.ToString(MasterTable.Rows[0]["FormNM"]); 
  				m_ParentID=SysConvert.ToInt32(MasterTable.Rows[0]["ParentID"]); 
  				m_IsShow=SysConvert.ToInt32(MasterTable.Rows[0]["IsShow"]); 
  				m_FormNoControlID=SysConvert.ToInt32(MasterTable.Rows[0]["FormNoControlID"]); 
  				m_WHTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["WHTypeID"]); 
  				m_CheckFlag=SysConvert.ToInt32(MasterTable.Rows[0]["CheckFlag"]); 
  				m_MoveFlag=SysConvert.ToInt32(MasterTable.Rows[0]["MoveFlag"]); 
  				m_WHQtyPosID=SysConvert.ToInt32(MasterTable.Rows[0]["WHQtyPosID"]); 
  				m_LoadFormTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["LoadFormTypeID"]); 
  				m_FillDataTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["FillDataTypeID"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_VendorTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["VendorTypeID"]); 
  				m_VendorTypeID2=SysConvert.ToInt32(MasterTable.Rows[0]["VendorTypeID2"]); 
  				m_VendorTypeID3=SysConvert.ToInt32(MasterTable.Rows[0]["VendorTypeID3"]); 
  				m_VendorTypeID4=SysConvert.ToInt32(MasterTable.Rows[0]["VendorTypeID4"]); 
  				m_VendorTypeID5=SysConvert.ToInt32(MasterTable.Rows[0]["VendorTypeID5"]); 
  				m_DZFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DZFlag"]); 
  				m_DZType=SysConvert.ToInt32(MasterTable.Rows[0]["DZType"]); 
  				m_CaiWuFlag=SysConvert.ToInt32(MasterTable.Rows[0]["CaiWuFlag"]); 
  				m_CaiWuType=SysConvert.ToInt32(MasterTable.Rows[0]["CaiWuType"]); 
  				m_InvoiceFlag=SysConvert.ToInt32(MasterTable.Rows[0]["InvoiceFlag"]); 
  				m_IsFreeForm=SysConvert.ToInt32(MasterTable.Rows[0]["IsFreeForm"]); 
  				m_FreeFormID=SysConvert.ToInt32(MasterTable.Rows[0]["FreeFormID"]); 
  				m_IsDelForm=SysConvert.ToInt32(MasterTable.Rows[0]["IsDelForm"]); 
  				m_UnLockFlag=SysConvert.ToInt32(MasterTable.Rows[0]["UnLockFlag"]); 
  				m_DelFormID=SysConvert.ToInt32(MasterTable.Rows[0]["DelFormID"]); 
  				m_LockFlag=SysConvert.ToInt32(MasterTable.Rows[0]["LockFlag"]); 
  				m_CheckSOFlag=SysConvert.ToInt32(MasterTable.Rows[0]["CheckSOFlag"]); 
  				m_SaleFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SaleFlag"]); 
  				m_ColorFlag=SysConvert.ToInt32(MasterTable.Rows[0]["ColorFlag"]); 
  				m_BuyFlag=SysConvert.ToInt32(MasterTable.Rows[0]["BuyFlag"]); 
  				m_PrintTitle=SysConvert.ToString(MasterTable.Rows[0]["PrintTitle"]); 
  				m_PrintCondition=SysConvert.ToString(MasterTable.Rows[0]["PrintCondition"]); 
  				m_PrintColTitle=SysConvert.ToString(MasterTable.Rows[0]["PrintColTitle"]); 
  				m_SpecialFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SpecialFlag"]); 
  				m_RecInvoiceFlag=SysConvert.ToInt32(MasterTable.Rows[0]["RecInvoiceFlag"]); 
  				m_OthFlag=SysConvert.ToInt32(MasterTable.Rows[0]["OthFlag"]); 
  				m_CaiWuCostFlag=SysConvert.ToInt32(MasterTable.Rows[0]["CaiWuCostFlag"]); 
  				m_CaiWuCostType=SysConvert.ToInt32(MasterTable.Rows[0]["CaiWuCostType"]); 
  				m_NeedCheckType=SysConvert.ToInt32(MasterTable.Rows[0]["NeedCheckType"]); 
  				m_AuditFlag=SysConvert.ToInt32(MasterTable.Rows[0]["AuditFlag"]); 
  				m_WHFormTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["WHFormTypeID"]); 
  				m_WHSpecialTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["WHSpecialTypeID"]); 
  				m_DefaultWHID=SysConvert.ToString(MasterTable.Rows[0]["DefaultWHID"]); 
  				m_VendorIDCaption=SysConvert.ToString(MasterTable.Rows[0]["VendorIDCaption"]); 
  				m_CheckFieldName=SysConvert.ToString(MasterTable.Rows[0]["CheckFieldName"]); 
  				m_CheckDtsFieldName=SysConvert.ToString(MasterTable.Rows[0]["CheckDtsFieldName"]); 
  				m_SaleOPCaption=SysConvert.ToString(MasterTable.Rows[0]["SaleOPCaption"]); 
  				m_CompactCodeVisible=SysConvert.ToString(MasterTable.Rows[0]["CompactCodeVisible"]); 
  				m_CheckQtyPer1=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQtyPer1"]); 
  				m_CheckQtyFrom=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQtyFrom"]); 
  				m_CheckQtyPer2=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQtyPer2"]); 
  				m_THLoadFormListIDStr=SysConvert.ToString(MasterTable.Rows[0]["THLoadFormListIDStr"]); 
  				m_CBSourceTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CBSourceTypeID"]); 
  				m_DEditReadOnlyFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DEditReadOnlyFlag"]); 
  				m_DBFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DBFlag"]); 
  				m_DefaultVendorID=SysConvert.ToString(MasterTable.Rows[0]["DefaultVendorID"]); 
  				m_DefaultSubTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["DefaultSubTypeID"]); 
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
