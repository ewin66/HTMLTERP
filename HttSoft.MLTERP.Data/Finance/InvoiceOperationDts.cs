using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Finance_InvoiceOperationDts实体类
	/// 作者:xushoucheng
	/// 创建日期:2015/8/17
	/// </summary>
	public sealed class InvoiceOperationDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public InvoiceOperationDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public InvoiceOperationDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Finance_InvoiceOperationDts";
		 
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
  
  		private int m_MainID = 0; 
  		public int MainID 
  		{ 
  			get 
  			{ 
  				return m_MainID ; 
  			}  
  			set 
  			{ 
  				m_MainID = value ; 
  			}  
  		} 
  
  		private int m_Seq = 0; 
  		public int Seq 
  		{ 
  			get 
  			{ 
  				return m_Seq ; 
  			}  
  			set 
  			{ 
  				m_Seq = value ; 
  			}  
  		} 
  
  		private int m_DLOADID = 0; 
  		public int DLOADID 
  		{ 
  			get 
  			{ 
  				return m_DLOADID ; 
  			}  
  			set 
  			{ 
  				m_DLOADID = value ; 
  			}  
  		} 
  
  		private int m_DLOADSEQ = 0; 
  		public int DLOADSEQ 
  		{ 
  			get 
  			{ 
  				return m_DLOADSEQ ; 
  			}  
  			set 
  			{ 
  				m_DLOADSEQ = value ; 
  			}  
  		} 
  
  		private string m_DLOADNO = string.Empty ; 
  		public string DLOADNO 
  		{ 
  			get 
  			{ 
  				return m_DLOADNO ; 
  			}  
  			set 
  			{ 
  				m_DLOADNO = value ; 
  			}  
  		} 
  
  		private int m_DLOADDtsID = 0; 
  		public int DLOADDtsID 
  		{ 
  			get 
  			{ 
  				return m_DLOADDtsID ; 
  			}  
  			set 
  			{ 
  				m_DLOADDtsID = value ; 
  			}  
  		} 
  
  		private decimal m_DInvoiceQty = 0; 
  		public decimal DInvoiceQty 
  		{ 
  			get 
  			{ 
  				return m_DInvoiceQty ; 
  			}  
  			set 
  			{ 
  				m_DInvoiceQty = value ; 
  			}  
  		} 
  
  		private decimal m_DInvoiceSinglePrice = 0; 
  		public decimal DInvoiceSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_DInvoiceSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_DInvoiceSinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_DInvoiceAmount = 0; 
  		public decimal DInvoiceAmount 
  		{ 
  			get 
  			{ 
  				return m_DInvoiceAmount ; 
  			}  
  			set 
  			{ 
  				m_DInvoiceAmount = value ; 
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
  
  		private decimal m_DInvoiceTaxAmount = 0; 
  		public decimal DInvoiceTaxAmount 
  		{ 
  			get 
  			{ 
  				return m_DInvoiceTaxAmount ; 
  			}  
  			set 
  			{ 
  				m_DInvoiceTaxAmount = value ; 
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
  
  		private int m_DLoadCheckDtsID = 0; 
  		public int DLoadCheckDtsID 
  		{ 
  			get 
  			{ 
  				return m_DLoadCheckDtsID ; 
  			}  
  			set 
  			{ 
  				m_DLoadCheckDtsID = value ; 
  			}  
  		} 
  
  		private decimal m_DInvoiceDYPrice = 0; 
  		public decimal DInvoiceDYPrice 
  		{ 
  			get 
  			{ 
  				return m_DInvoiceDYPrice ; 
  			}  
  			set 
  			{ 
  				m_DInvoiceDYPrice = value ; 
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
  
  		private int m_MergeFlage = 0; 
  		public int MergeFlage 
  		{ 
  			get 
  			{ 
  				return m_MergeFlage ; 
  			}  
  			set 
  			{ 
  				m_MergeFlage = value ; 
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
            string Sql="SELECT * FROM Finance_InvoiceOperationDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_InvoiceOperationDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_DLOADID=SysConvert.ToInt32(MasterTable.Rows[0]["DLOADID"]); 
  				m_DLOADSEQ=SysConvert.ToInt32(MasterTable.Rows[0]["DLOADSEQ"]); 
  				m_DLOADNO=SysConvert.ToString(MasterTable.Rows[0]["DLOADNO"]); 
  				m_DLOADDtsID=SysConvert.ToInt32(MasterTable.Rows[0]["DLOADDtsID"]); 
  				m_DInvoiceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["DInvoiceQty"]); 
  				m_DInvoiceSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["DInvoiceSinglePrice"]); 
  				m_DInvoiceAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["DInvoiceAmount"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_PayAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PayAmount"]); 
  				m_DInvoiceTaxAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["DInvoiceTaxAmount"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_DLoadCheckDtsID=SysConvert.ToInt32(MasterTable.Rows[0]["DLoadCheckDtsID"]); 
  				m_DInvoiceDYPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["DInvoiceDYPrice"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_MergeFlage=SysConvert.ToInt32(MasterTable.Rows[0]["MergeFlage"]); 
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
