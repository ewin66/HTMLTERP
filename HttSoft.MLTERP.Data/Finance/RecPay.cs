using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Finance_RecPay实体类
	/// 作者:XUSC
	/// 创建日期:2016/1/20
	/// </summary>
	public sealed class RecPay : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public RecPay()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public RecPay(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Finance_RecPay";
		 
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
  
  		private decimal m_ExAmount = 0; 
  		public decimal ExAmount 
  		{ 
  			get 
  			{ 
  				return m_ExAmount ; 
  			}  
  			set 
  			{ 
  				m_ExAmount = value ; 
  			}  
  		} 
  
  		private string m_MoneyType = string.Empty ; 
  		public string MoneyType 
  		{ 
  			get 
  			{ 
  				return m_MoneyType ; 
  			}  
  			set 
  			{ 
  				m_MoneyType = value ; 
  			}  
  		} 
  
  		private string m_ExMethod = string.Empty ; 
  		public string ExMethod 
  		{ 
  			get 
  			{ 
  				return m_ExMethod ; 
  			}  
  			set 
  			{ 
  				m_ExMethod = value ; 
  			}  
  		} 
  
  		private decimal m_Rate = 0; 
  		public decimal Rate 
  		{ 
  			get 
  			{ 
  				return m_Rate ; 
  			}  
  			set 
  			{ 
  				m_Rate = value ; 
  			}  
  		} 
  
  		private string m_ExOP = string.Empty ; 
  		public string ExOP 
  		{ 
  			get 
  			{ 
  				return m_ExOP ; 
  			}  
  			set 
  			{ 
  				m_ExOP = value ; 
  			}  
  		} 
  
  		private DateTime m_ExDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ExDate 
  		{ 
  			get 
  			{ 
  				return m_ExDate ; 
  			}  
  			set 
  			{ 
  				m_ExDate = value ; 
  			}  
  		} 
  
  		private string m_ExBank = string.Empty ; 
  		public string ExBank 
  		{ 
  			get 
  			{ 
  				return m_ExBank ; 
  			}  
  			set 
  			{ 
  				m_ExBank = value ; 
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
  
  		private decimal m_HXAmount = 0; 
  		public decimal HXAmount 
  		{ 
  			get 
  			{ 
  				return m_HXAmount ; 
  			}  
  			set 
  			{ 
  				m_HXAmount = value ; 
  			}  
  		} 
  
  		private int m_HXFlag = 0; 
  		public int HXFlag 
  		{ 
  			get 
  			{ 
  				return m_HXFlag ; 
  			}  
  			set 
  			{ 
  				m_HXFlag = value ; 
  			}  
  		} 
  
  		private int m_RecPayTypeID = 0; 
  		public int RecPayTypeID 
  		{ 
  			get 
  			{ 
  				return m_RecPayTypeID ; 
  			}  
  			set 
  			{ 
  				m_RecPayTypeID = value ; 
  			}  
  		} 
  
  		private decimal m_HTAmount = 0; 
  		public decimal HTAmount 
  		{ 
  			get 
  			{ 
  				return m_HTAmount ; 
  			}  
  			set 
  			{ 
  				m_HTAmount = value ; 
  			}  
  		} 
  
  		private int m_HTFlag = 0; 
  		public int HTFlag 
  		{ 
  			get 
  			{ 
  				return m_HTFlag ; 
  			}  
  			set 
  			{ 
  				m_HTFlag = value ; 
  			}  
  		} 
  
  		private string m_HTNo = string.Empty ; 
  		public string HTNo 
  		{ 
  			get 
  			{ 
  				return m_HTNo ; 
  			}  
  			set 
  			{ 
  				m_HTNo = value ; 
  			}  
  		} 
  
  		private int m_PayStepTypeID = 0; 
  		public int PayStepTypeID 
  		{ 
  			get 
  			{ 
  				return m_PayStepTypeID ; 
  			}  
  			set 
  			{ 
  				m_PayStepTypeID = value ; 
  			}  
  		} 
  
  		private string m_HTGoodsCode = string.Empty ; 
  		public string HTGoodsCode 
  		{ 
  			get 
  			{ 
  				return m_HTGoodsCode ; 
  			}  
  			set 
  			{ 
  				m_HTGoodsCode = value ; 
  			}  
  		} 
  
  		private decimal m_NoHXAmount = 0; 
  		public decimal NoHXAmount 
  		{ 
  			get 
  			{ 
  				return m_NoHXAmount ; 
  			}  
  			set 
  			{ 
  				m_NoHXAmount = value ; 
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
  
  		private decimal m_PreAmount = 0; 
  		public decimal PreAmount 
  		{ 
  			get 
  			{ 
  				return m_PreAmount ; 
  			}  
  			set 
  			{ 
  				m_PreAmount = value ; 
  			}  
  		} 
  
  		private decimal m_YJAmount = 0; 
  		public decimal YJAmount 
  		{ 
  			get 
  			{ 
  				return m_YJAmount ; 
  			}  
  			set 
  			{ 
  				m_YJAmount = value ; 
  			}  
  		} 
  
  		private decimal m_SaleAmount = 0; 
  		public decimal SaleAmount 
  		{ 
  			get 
  			{ 
  				return m_SaleAmount ; 
  			}  
  			set 
  			{ 
  				m_SaleAmount = value ; 
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
  
  		private decimal m_LeftAmount = 0; 
  		public decimal LeftAmount 
  		{ 
  			get 
  			{ 
  				return m_LeftAmount ; 
  			}  
  			set 
  			{ 
  				m_LeftAmount = value ; 
  			}  
  		} 
  
  		private decimal m_SJAmount = 0; 
  		public decimal SJAmount 
  		{ 
  			get 
  			{ 
  				return m_SJAmount ; 
  			}  
  			set 
  			{ 
  				m_SJAmount = value ; 
  			}  
  		} 
  
  		private int m_NoAmountFlag = 0; 
  		public int NoAmountFlag 
  		{ 
  			get 
  			{ 
  				return m_NoAmountFlag ; 
  			}  
  			set 
  			{ 
  				m_NoAmountFlag = value ; 
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
            string Sql="SELECT * FROM Finance_RecPay WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_RecPay WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_ExAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ExAmount"]); 
  				m_MoneyType=SysConvert.ToString(MasterTable.Rows[0]["MoneyType"]); 
  				m_ExMethod=SysConvert.ToString(MasterTable.Rows[0]["ExMethod"]); 
  				m_Rate=SysConvert.ToDecimal(MasterTable.Rows[0]["Rate"]); 
  				m_ExOP=SysConvert.ToString(MasterTable.Rows[0]["ExOP"]); 
  				m_ExDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ExDate"]); 
  				m_ExBank=SysConvert.ToString(MasterTable.Rows[0]["ExBank"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_HXAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["HXAmount"]); 
  				m_HXFlag=SysConvert.ToInt32(MasterTable.Rows[0]["HXFlag"]); 
  				m_RecPayTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["RecPayTypeID"]); 
  				m_HTAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["HTAmount"]); 
  				m_HTFlag=SysConvert.ToInt32(MasterTable.Rows[0]["HTFlag"]); 
  				m_HTNo=SysConvert.ToString(MasterTable.Rows[0]["HTNo"]); 
  				m_PayStepTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["PayStepTypeID"]); 
  				m_HTGoodsCode=SysConvert.ToString(MasterTable.Rows[0]["HTGoodsCode"]); 
  				m_NoHXAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["NoHXAmount"]); 
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_PreAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PreAmount"]); 
  				m_YJAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["YJAmount"]); 
  				m_SaleAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["SaleAmount"]); 
  				m_OtherAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["OtherAmount"]); 
  				m_LeftAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["LeftAmount"]); 
  				m_SJAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["SJAmount"]); 
  				m_NoAmountFlag=SysConvert.ToInt32(MasterTable.Rows[0]["NoAmountFlag"]); 
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
