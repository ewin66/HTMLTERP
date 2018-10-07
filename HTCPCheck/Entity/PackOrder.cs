using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// 目的：WO_PackOrder实体类
	/// 作者:qiuchao
	/// 创建日期:2015/6/16
	/// </summary>
	public sealed class PackOrder : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public PackOrder()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public PackOrder(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_PackOrder";
		 
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
  
  		private int m_SaleProcedureID = 0; 
  		public int SaleProcedureID 
  		{ 
  			get 
  			{ 
  				return m_SaleProcedureID ; 
  			}  
  			set 
  			{ 
  				m_SaleProcedureID = value ; 
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
  
  		private string m_SaleProcedureFormNo = string.Empty ; 
  		public string SaleProcedureFormNo 
  		{ 
  			get 
  			{ 
  				return m_SaleProcedureFormNo ; 
  			}  
  			set 
  			{ 
  				m_SaleProcedureFormNo = value ; 
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
  
  		private string m_CWeight = string.Empty ; 
  		public string CWeight 
  		{ 
  			get 
  			{ 
  				return m_CWeight ; 
  			}  
  			set 
  			{ 
  				m_CWeight = value ; 
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
  
  		private string m_CWidth = string.Empty ; 
  		public string CWidth 
  		{ 
  			get 
  			{ 
  				return m_CWidth ; 
  			}  
  			set 
  			{ 
  				m_CWidth = value ; 
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
  
  		private string m_ItemModel = string.Empty ; 
  		public string ItemModel 
  		{ 
  			get 
  			{ 
  				return m_ItemModel ; 
  			}  
  			set 
  			{ 
  				m_ItemModel = value ; 
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
  
  		private string m_Needle = string.Empty ; 
  		public string Needle 
  		{ 
  			get 
  			{ 
  				return m_Needle ; 
  			}  
  			set 
  			{ 
  				m_Needle = value ; 
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
            string Sql="SELECT * FROM WO_PackOrder WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_PackOrder WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_SaleProcedureID=SysConvert.ToInt32(MasterTable.Rows[0]["SaleProcedureID"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_ShopID=SysConvert.ToString(MasterTable.Rows[0]["ShopID"]); 
  				m_SaleProcedureFormNo=SysConvert.ToString(MasterTable.Rows[0]["SaleProcedureFormNo"]); 
  				m_CompactNo=SysConvert.ToString(MasterTable.Rows[0]["CompactNo"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_CWeight=SysConvert.ToString(MasterTable.Rows[0]["CWeight"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_ReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ReqDate"]); 
  				m_CWidth=SysConvert.ToString(MasterTable.Rows[0]["CWidth"]); 
  				m_PrintItemName=SysConvert.ToString(MasterTable.Rows[0]["PrintItemName"]); 
  				m_PrintGoodsCode=SysConvert.ToString(MasterTable.Rows[0]["PrintGoodsCode"]); 
  				m_PrintRemark1=SysConvert.ToString(MasterTable.Rows[0]["PrintRemark1"]); 
  				m_PrintRemark2=SysConvert.ToString(MasterTable.Rows[0]["PrintRemark2"]); 
  				m_PrintRemark3=SysConvert.ToString(MasterTable.Rows[0]["PrintRemark3"]); 
  				m_PrintRemark4=SysConvert.ToString(MasterTable.Rows[0]["PrintRemark4"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_Needle=SysConvert.ToString(MasterTable.Rows[0]["Needle"]); 
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
