using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_SaleOrderJS实体类
	/// 作者:周富春
	/// 创建日期:2015/8/5
	/// </summary>
	public sealed class SaleOrderJS : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public SaleOrderJS()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SaleOrderJS(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Sale_SaleOrderJS";
		 
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
  
  		private string m_SO = string.Empty ; 
  		public string SO 
  		{ 
  			get 
  			{ 
  				return m_SO ; 
  			}  
  			set 
  			{ 
  				m_SO = value ; 
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
  
  		private decimal m_OrderAmount = 0; 
  		public decimal OrderAmount 
  		{ 
  			get 
  			{ 
  				return m_OrderAmount ; 
  			}  
  			set 
  			{ 
  				m_OrderAmount = value ; 
  			}  
  		} 
  
  		private decimal m_CGAmount = 0; 
  		public decimal CGAmount 
  		{ 
  			get 
  			{ 
  				return m_CGAmount ; 
  			}  
  			set 
  			{ 
  				m_CGAmount = value ; 
  			}  
  		} 
  
  		private decimal m_RSAmount = 0; 
  		public decimal RSAmount 
  		{ 
  			get 
  			{ 
  				return m_RSAmount ; 
  			}  
  			set 
  			{ 
  				m_RSAmount = value ; 
  			}  
  		} 
  
  		private decimal m_ZZAmount = 0; 
  		public decimal ZZAmount 
  		{ 
  			get 
  			{ 
  				return m_ZZAmount ; 
  			}  
  			set 
  			{ 
  				m_ZZAmount = value ; 
  			}  
  		} 
  
  		private decimal m_RZAmount = 0; 
  		public decimal RZAmount 
  		{ 
  			get 
  			{ 
  				return m_RZAmount ; 
  			}  
  			set 
  			{ 
  				m_RZAmount = value ; 
  			}  
  		} 
  
  		private decimal m_OtherAmount = 0; 
  		public decimal OtherAmount 
  		{ 
  			get 
  			{ 
  				return m_OtherAmount ; 
  			}  
  			set 
  			{ 
  				m_OtherAmount = value ; 
  			}  
  		} 
  
  		private decimal m_LRAmount = 0; 
  		public decimal LRAmount 
  		{ 
  			get 
  			{ 
  				return m_LRAmount ; 
  			}  
  			set 
  			{ 
  				m_LRAmount = value ; 
  			}  
  		} 
  
  		private int m_RowIndex = 0; 
  		public int RowIndex 
  		{ 
  			get 
  			{ 
  				return m_RowIndex ; 
  			}  
  			set 
  			{ 
  				m_RowIndex = value ; 
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
  
  		private decimal m_CBAmount = 0; 
  		public decimal CBAmount 
  		{ 
  			get 
  			{ 
  				return m_CBAmount ; 
  			}  
  			set 
  			{ 
  				m_CBAmount = value ; 
  			}  
  		} 
  
  		private decimal m_LRPer = 0; 
  		public decimal LRPer 
  		{ 
  			get 
  			{ 
  				return m_LRPer ; 
  			}  
  			set 
  			{ 
  				m_LRPer = value ; 
  			}  
  		} 
  
  		private decimal m_HKAmount = 0; 
  		public decimal HKAmount 
  		{ 
  			get 
  			{ 
  				return m_HKAmount ; 
  			}  
  			set 
  			{ 
  				m_HKAmount = value ; 
  			}  
  		} 
  
  		private decimal m_YSAmount = 0; 
  		public decimal YSAmount 
  		{ 
  			get 
  			{ 
  				return m_YSAmount ; 
  			}  
  			set 
  			{ 
  				m_YSAmount = value ; 
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
            string Sql="SELECT * FROM Sale_SaleOrderJS WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_SaleOrderJS WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_SO=SysConvert.ToString(MasterTable.Rows[0]["SO"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_OrderAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["OrderAmount"]); 
  				m_CGAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["CGAmount"]); 
  				m_RSAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["RSAmount"]); 
  				m_ZZAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ZZAmount"]); 
  				m_RZAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["RZAmount"]); 
  				m_OtherAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["OtherAmount"]); 
  				m_LRAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["LRAmount"]); 
  				m_RowIndex=SysConvert.ToInt32(MasterTable.Rows[0]["RowIndex"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_CBAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["CBAmount"]); 
  				m_LRPer=SysConvert.ToDecimal(MasterTable.Rows[0]["LRPer"]); 
  				m_HKAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["HKAmount"]); 
  				m_YSAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["YSAmount"]); 
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
