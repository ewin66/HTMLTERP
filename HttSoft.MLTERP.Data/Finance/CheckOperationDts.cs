using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Finance_CheckOperationDts实体类
	/// 作者:周富春
	/// 创建日期:2014/10/17
	/// </summary>
	public sealed class CheckOperationDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CheckOperationDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CheckOperationDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Finance_CheckOperationDts";
		 
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
  
  		private decimal m_DCheckQty = 0; 
  		public decimal DCheckQty 
  		{ 
  			get 
  			{ 
  				return m_DCheckQty ; 
  			}  
  			set 
  			{ 
  				m_DCheckQty = value ; 
  			}  
  		} 
  
  		private decimal m_DCheckSinglePrice = 0; 
  		public decimal DCheckSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_DCheckSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_DCheckSinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_DCheckAmount = 0; 
  		public decimal DCheckAmount 
  		{ 
  			get 
  			{ 
  				return m_DCheckAmount ; 
  			}  
  			set 
  			{ 
  				m_DCheckAmount = value ; 
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
  
  		private decimal m_DCheckDYPrice = 0; 
  		public decimal DCheckDYPrice 
  		{ 
  			get 
  			{ 
  				return m_DCheckDYPrice ; 
  			}  
  			set 
  			{ 
  				m_DCheckDYPrice = value ; 
  			}  
  		} 
  
  		private int m_QSID = 0; 
  		public int QSID 
  		{ 
  			get 
  			{ 
  				return m_QSID ; 
  			}  
  			set 
  			{ 
  				m_QSID = value ; 
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
  
  		private int m_LoadFlag = 0; 
  		public int LoadFlag 
  		{ 
  			get 
  			{ 
  				return m_LoadFlag ; 
  			}  
  			set 
  			{ 
  				m_LoadFlag = value ; 
  			}  
  		} 
  
  		private decimal m_YuLiaoQty = 0; 
  		public decimal YuLiaoQty 
  		{ 
  			get 
  			{ 
  				return m_YuLiaoQty ; 
  			}  
  			set 
  			{ 
  				m_YuLiaoQty = value ; 
  			}  
  		} 
  
  		private decimal m_TZAmount = 0; 
  		public decimal TZAmount 
  		{ 
  			get 
  			{ 
  				return m_TZAmount ; 
  			}  
  			set 
  			{ 
  				m_TZAmount = value ; 
  			}  
  		} 
  
  		private decimal m_FAmount1 = 0; 
  		public decimal FAmount1 
  		{ 
  			get 
  			{ 
  				return m_FAmount1 ; 
  			}  
  			set 
  			{ 
  				m_FAmount1 = value ; 
  			}  
  		} 
  
  		private decimal m_FAmount2 = 0; 
  		public decimal FAmount2 
  		{ 
  			get 
  			{ 
  				return m_FAmount2 ; 
  			}  
  			set 
  			{ 
  				m_FAmount2 = value ; 
  			}  
  		} 
  
  		private decimal m_FAmount3 = 0; 
  		public decimal FAmount3 
  		{ 
  			get 
  			{ 
  				return m_FAmount3 ; 
  			}  
  			set 
  			{ 
  				m_FAmount3 = value ; 
  			}  
  		} 
  
  		private decimal m_FAmount4 = 0; 
  		public decimal FAmount4 
  		{ 
  			get 
  			{ 
  				return m_FAmount4 ; 
  			}  
  			set 
  			{ 
  				m_FAmount4 = value ; 
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
            string Sql="SELECT * FROM Finance_CheckOperationDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_CheckOperationDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_DCheckQty=SysConvert.ToDecimal(MasterTable.Rows[0]["DCheckQty"]); 
  				m_DCheckSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["DCheckSinglePrice"]); 
  				m_DCheckAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["DCheckAmount"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_InvoiceFlag=SysConvert.ToInt32(MasterTable.Rows[0]["InvoiceFlag"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_DCheckDYPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["DCheckDYPrice"]); 
  				m_QSID=SysConvert.ToInt32(MasterTable.Rows[0]["QSID"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_LoadFlag=SysConvert.ToInt32(MasterTable.Rows[0]["LoadFlag"]); 
  				m_YuLiaoQty=SysConvert.ToDecimal(MasterTable.Rows[0]["YuLiaoQty"]); 
  				m_TZAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TZAmount"]); 
  				m_FAmount1=SysConvert.ToDecimal(MasterTable.Rows[0]["FAmount1"]); 
  				m_FAmount2=SysConvert.ToDecimal(MasterTable.Rows[0]["FAmount2"]); 
  				m_FAmount3=SysConvert.ToDecimal(MasterTable.Rows[0]["FAmount3"]); 
  				m_FAmount4=SysConvert.ToDecimal(MasterTable.Rows[0]["FAmount4"]); 
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
