using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_FHForm实体类
	/// 作者:qiuchao
	/// 创建日期:2015/6/23
	/// </summary>
	public sealed class FHForm : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public FHForm()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FHForm(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Sale_FHForm";
		 
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
  
  		private string m_SHR = string.Empty ; 
  		public string SHR 
  		{ 
  			get 
  			{ 
  				return m_SHR ; 
  			}  
  			set 
  			{ 
  				m_SHR = value ; 
  			}  
  		} 
  
  		private string m_LXR = string.Empty ; 
  		public string LXR 
  		{ 
  			get 
  			{ 
  				return m_LXR ; 
  			}  
  			set 
  			{ 
  				m_LXR = value ; 
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
  
  		private string m_SendCode = string.Empty ; 
  		public string SendCode 
  		{ 
  			get 
  			{ 
  				return m_SendCode ; 
  			}  
  			set 
  			{ 
  				m_SendCode = value ; 
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
  
  		private int m_FHForTypeID = 0; 
  		public int FHForTypeID 
  		{ 
  			get 
  			{ 
  				return m_FHForTypeID ; 
  			}  
  			set 
  			{ 
  				m_FHForTypeID = value ; 
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
  
  		private string m_DYFormNo = string.Empty ; 
  		public string DYFormNo 
  		{ 
  			get 
  			{ 
  				return m_DYFormNo ; 
  			}  
  			set 
  			{ 
  				m_DYFormNo = value ; 
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
  
  		private int m_SendFlag = 0; 
  		public int SendFlag 
  		{ 
  			get 
  			{ 
  				return m_SendFlag ; 
  			}  
  			set 
  			{ 
  				m_SendFlag = value ; 
  			}  
  		} 
  
  		private string m_Tel = string.Empty ; 
  		public string Tel 
  		{ 
  			get 
  			{ 
  				return m_Tel ; 
  			}  
  			set 
  			{ 
  				m_Tel = value ; 
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
  
  		private string m_FHStatusID = string.Empty ; 
  		public string FHStatusID 
  		{ 
  			get 
  			{ 
  				return m_FHStatusID ; 
  			}  
  			set 
  			{ 
  				m_FHStatusID = value ; 
  			}  
  		} 
  
  		private string m_SHVendorID = string.Empty ; 
  		public string SHVendorID 
  		{ 
  			get 
  			{ 
  				return m_SHVendorID ; 
  			}  
  			set 
  			{ 
  				m_SHVendorID = value ; 
  			}  
  		} 
  
  		private string m_SHOPID = string.Empty ; 
  		public string SHOPID 
  		{ 
  			get 
  			{ 
  				return m_SHOPID ; 
  			}  
  			set 
  			{ 
  				m_SHOPID = value ; 
  			}  
  		} 
  
  		private string m_SHTel = string.Empty ; 
  		public string SHTel 
  		{ 
  			get 
  			{ 
  				return m_SHTel ; 
  			}  
  			set 
  			{ 
  				m_SHTel = value ; 
  			}  
  		} 
  
  		private string m_MaiTou = string.Empty ; 
  		public string MaiTou 
  		{ 
  			get 
  			{ 
  				return m_MaiTou ; 
  			}  
  			set 
  			{ 
  				m_MaiTou = value ; 
  			}  
  		} 
  
  		private string m_Duanyizhuang = string.Empty ; 
  		public string Duanyizhuang 
  		{ 
  			get 
  			{ 
  				return m_Duanyizhuang ; 
  			}  
  			set 
  			{ 
  				m_Duanyizhuang = value ; 
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
            string Sql="SELECT * FROM Sale_FHForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_FHForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_SHR=SysConvert.ToString(MasterTable.Rows[0]["SHR"]); 
  				m_LXR=SysConvert.ToString(MasterTable.Rows[0]["LXR"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_SendCode=SysConvert.ToString(MasterTable.Rows[0]["SendCode"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_FHForTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["FHForTypeID"]); 
  				m_OrderFormNo=SysConvert.ToString(MasterTable.Rows[0]["OrderFormNo"]); 
  				m_DYFormNo=SysConvert.ToString(MasterTable.Rows[0]["DYFormNo"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_SendFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SendFlag"]); 
  				m_Tel=SysConvert.ToString(MasterTable.Rows[0]["Tel"]); 
  				m_Address=SysConvert.ToString(MasterTable.Rows[0]["Address"]); 
  				m_FHTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["FHTypeID"]); 
  				m_FHStatusID=SysConvert.ToString(MasterTable.Rows[0]["FHStatusID"]); 
  				m_SHVendorID=SysConvert.ToString(MasterTable.Rows[0]["SHVendorID"]); 
  				m_SHOPID=SysConvert.ToString(MasterTable.Rows[0]["SHOPID"]); 
  				m_SHTel=SysConvert.ToString(MasterTable.Rows[0]["SHTel"]); 
  				m_MaiTou=SysConvert.ToString(MasterTable.Rows[0]["MaiTou"]); 
  				m_Duanyizhuang=SysConvert.ToString(MasterTable.Rows[0]["Duanyizhuang"]); 
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
