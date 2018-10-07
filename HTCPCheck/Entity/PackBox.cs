using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// 目的：WH_PackBox实体类
	/// 作者:陈加海
	/// 创建日期:2014/5/9
	/// </summary>
	public sealed class PackBox : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public PackBox()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public PackBox(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		 
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
  
  		private string m_BoxNo = string.Empty ; 
  		public string BoxNo 
  		{ 
  			get 
  			{ 
  				return m_BoxNo ; 
  			}  
  			set 
  			{ 
  				m_BoxNo = value ; 
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
  
  		private string m_SBitID = string.Empty ; 
  		public string SBitID 
  		{ 
  			get 
  			{ 
  				return m_SBitID ; 
  			}  
  			set 
  			{ 
  				m_SBitID = value ; 
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
  
  		private decimal m_MWidth = 0; 
  		public decimal MWidth 
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
  
  		private DateTime m_CreateTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CreateTime 
  		{ 
  			get 
  			{ 
  				return m_CreateTime ; 
  			}  
  			set 
  			{ 
  				m_CreateTime = value ; 
  			}  
  		} 
  
  		private int m_BoxStatusID = 0; 
  		public int BoxStatusID 
  		{ 
  			get 
  			{ 
  				return m_BoxStatusID ; 
  			}  
  			set 
  			{ 
  				m_BoxStatusID = value ; 
  			}  
  		} 
  
  		private string m_InFormNo = string.Empty ; 
  		public string InFormNo 
  		{ 
  			get 
  			{ 
  				return m_InFormNo ; 
  			}  
  			set 
  			{ 
  				m_InFormNo = value ; 
  			}  
  		} 
  
  		private string m_OutFormNo = string.Empty ; 
  		public string OutFormNo 
  		{ 
  			get 
  			{ 
  				return m_OutFormNo ; 
  			}  
  			set 
  			{ 
  				m_OutFormNo = value ; 
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
  
  		private int m_SourceTypeID = 0; 
  		public int SourceTypeID 
  		{ 
  			get 
  			{ 
  				return m_SourceTypeID ; 
  			}  
  			set 
  			{ 
  				m_SourceTypeID = value ; 
  			}  
  		} 
  
  		private int m_KPFlag = 0; 
  		public int KPFlag 
  		{ 
  			get 
  			{ 
  				return m_KPFlag ; 
  			}  
  			set 
  			{ 
  				m_KPFlag = value ; 
  			}  
  		} 
  
  		private string m_SourceBoxNo = string.Empty ; 
  		public string SourceBoxNo 
  		{ 
  			get 
  			{ 
  				return m_SourceBoxNo ; 
  			}  
  			set 
  			{ 
  				m_SourceBoxNo = value ; 
  			}  
  		} 
  
  		private int m_DID = 0; 
  		public int DID 
  		{ 
  			get 
  			{ 
  				return m_DID ; 
  			}  
  			set 
  			{ 
  				m_DID = value ; 
  			}  
  		} 
  
  		private int m_CreateSourceID = 0; 
  		public int CreateSourceID 
  		{ 
  			get 
  			{ 
  				return m_CreateSourceID ; 
  			}  
  			set 
  			{ 
  				m_CreateSourceID = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM WH_PackBox WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_PackBox WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_BoxNo=SysConvert.ToString(MasterTable.Rows[0]["BoxNo"]); 
  				m_WHID=SysConvert.ToString(MasterTable.Rows[0]["WHID"]); 
  				m_SectionID=SysConvert.ToString(MasterTable.Rows[0]["SectionID"]); 
  				m_SBitID=SysConvert.ToString(MasterTable.Rows[0]["SBitID"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_GoodsLevel=SysConvert.ToString(MasterTable.Rows[0]["GoodsLevel"]); 
  				m_MWidth=SysConvert.ToDecimal(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["MWeight"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_Batch=SysConvert.ToString(MasterTable.Rows[0]["Batch"]); 
  				m_VendorBatch=SysConvert.ToString(MasterTable.Rows[0]["VendorBatch"]); 
  				m_Weight=SysConvert.ToDecimal(MasterTable.Rows[0]["Weight"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]); 
  				m_CreateTime=SysConvert.ToDateTime(MasterTable.Rows[0]["CreateTime"]); 
  				m_BoxStatusID=SysConvert.ToInt32(MasterTable.Rows[0]["BoxStatusID"]); 
  				m_InFormNo=SysConvert.ToString(MasterTable.Rows[0]["InFormNo"]); 
  				m_OutFormNo=SysConvert.ToString(MasterTable.Rows[0]["OutFormNo"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_SourceTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["SourceTypeID"]); 
  				m_KPFlag=SysConvert.ToInt32(MasterTable.Rows[0]["KPFlag"]); 
  				m_SourceBoxNo=SysConvert.ToString(MasterTable.Rows[0]["SourceBoxNo"]); 
  				m_DID=SysConvert.ToInt32(MasterTable.Rows[0]["DID"]); 
  				m_CreateSourceID=SysConvert.ToInt32(MasterTable.Rows[0]["CreateSourceID"]); 
  				m_OrderFormNo=SysConvert.ToString(MasterTable.Rows[0]["OrderFormNo"]); 
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
