using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Buy_ItemBuyForm实体类
	/// 作者:章文强
	/// 创建日期:2014/3/24
	/// </summary>
	public sealed class ItemBuyForm : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemBuyForm()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemBuyForm(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Buy_ItemBuyForm";
		 
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
  
  		private string m_OrderCode = string.Empty ; 
  		public string OrderCode 
  		{ 
  			get 
  			{ 
  				return m_OrderCode ; 
  			}  
  			set 
  			{ 
  				m_OrderCode = value ; 
  			}  
  		} 
  
  		private string m_CustomerStyleNo = string.Empty ; 
  		public string CustomerStyleNo 
  		{ 
  			get 
  			{ 
  				return m_CustomerStyleNo ; 
  			}  
  			set 
  			{ 
  				m_CustomerStyleNo = value ; 
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
        private string m_VendorID = string.Empty;
        public string VendorID
        {
            get
            {
                return m_VendorID;
            }
            set
            {
                m_VendorID = value;
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
  
  		private int m_MLType = 0; 
  		public int MLType 
  		{ 
  			get 
  			{ 
  				return m_MLType ; 
  			}  
  			set 
  			{ 
  				m_MLType = value ; 
  			}  
  		} 
  
  		private int m_FormAID = 0; 
  		public int FormAID 
  		{ 
  			get 
  			{ 
  				return m_FormAID ; 
  			}  
  			set 
  			{ 
  				m_FormAID = value ; 
  			}  
  		} 
  
  		private int m_FKFlag = 0; 
  		public int FKFlag 
  		{ 
  			get 
  			{ 
  				return m_FKFlag ; 
  			}  
  			set 
  			{ 
  				m_FKFlag = value ; 
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
  
  		private string m_CGOPID = string.Empty ; 
  		public string CGOPID 
  		{ 
  			get 
  			{ 
  				return m_CGOPID ; 
  			}  
  			set 
  			{ 
  				m_CGOPID = value ; 
  			}  
  		} 
  
  		private int m_BuyTypeID = 0; 
  		public int BuyTypeID 
  		{ 
  			get 
  			{ 
  				return m_BuyTypeID ; 
  			}  
  			set 
  			{ 
  				m_BuyTypeID = value ; 
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
            string Sql="SELECT * FROM Buy_ItemBuyForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Buy_ItemBuyForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_OrderCode=SysConvert.ToString(MasterTable.Rows[0]["OrderCode"]); 
  				m_CustomerStyleNo=SysConvert.ToString(MasterTable.Rows[0]["CustomerStyleNo"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeOPName=SysConvert.ToString(MasterTable.Rows[0]["MakeOPName"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_CheckOPID=SysConvert.ToString(MasterTable.Rows[0]["CheckOPID"]); 
  				m_CheckDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CheckDate"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_ShopID=SysConvert.ToString(MasterTable.Rows[0]["ShopID"]);
                m_VendorID = SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_ReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ReqDate"]); 
  				m_OrderFormNo=SysConvert.ToString(MasterTable.Rows[0]["OrderFormNo"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_PayMethodID=SysConvert.ToString(MasterTable.Rows[0]["PayMethodID"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_OrderDate=SysConvert.ToDateTime(MasterTable.Rows[0]["OrderDate"]); 
  				m_ContractDesc=SysConvert.ToString(MasterTable.Rows[0]["ContractDesc"]); 
  				m_PayMethodFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PayMethodFlag"]); 
  				m_StatusFlag=SysConvert.ToInt32(MasterTable.Rows[0]["StatusFlag"]); 
  				m_StatusName=SysConvert.ToString(MasterTable.Rows[0]["StatusName"]); 
  				m_MLType=SysConvert.ToInt32(MasterTable.Rows[0]["MLType"]); 
  				m_FormAID=SysConvert.ToInt32(MasterTable.Rows[0]["FormAID"]); 
  				m_FKFlag=SysConvert.ToInt32(MasterTable.Rows[0]["FKFlag"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_CGOPID=SysConvert.ToString(MasterTable.Rows[0]["CGOPID"]); 
  				m_BuyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["BuyTypeID"]); 
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
