using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Ship_CustomReportDts实体类
	/// 作者:鲁帆
	/// 创建日期:2015/3/26
	/// </summary>
	public sealed class CustomReportDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CustomReportDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CustomReportDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Ship_CustomReportDts";
		 
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
  
  		private string m_GoodNo = string.Empty ; 
  		public string GoodNo 
  		{ 
  			get 
  			{ 
  				return m_GoodNo ; 
  			}  
  			set 
  			{ 
  				m_GoodNo = value ; 
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
  
  		private int m_Qty = 0; 
  		public int Qty 
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
  
  		private decimal m_UnitPrice = 0; 
  		public decimal UnitPrice 
  		{ 
  			get 
  			{ 
  				return m_UnitPrice ; 
  			}  
  			set 
  			{ 
  				m_UnitPrice = value ; 
  			}  
  		} 
  
  		private int m_ICheckedQty = 0; 
  		public int ICheckedQty 
  		{ 
  			get 
  			{ 
  				return m_ICheckedQty ; 
  			}  
  			set 
  			{ 
  				m_ICheckedQty = value ; 
  			}  
  		} 
  
  		private int m_ILeftQty = 0; 
  		public int ILeftQty 
  		{ 
  			get 
  			{ 
  				return m_ILeftQty ; 
  			}  
  			set 
  			{ 
  				m_ILeftQty = value ; 
  			}  
  		} 
  
  		private decimal m_ICheckedAmount = 0; 
  		public decimal ICheckedAmount 
  		{ 
  			get 
  			{ 
  				return m_ICheckedAmount ; 
  			}  
  			set 
  			{ 
  				m_ICheckedAmount = value ; 
  			}  
  		} 
  
  		private decimal m_ILeftAmount = 0; 
  		public decimal ILeftAmount 
  		{ 
  			get 
  			{ 
  				return m_ILeftAmount ; 
  			}  
  			set 
  			{ 
  				m_ILeftAmount = value ; 
  			}  
  		} 
  
  		private int m_SCQty = 0; 
  		public int SCQty 
  		{ 
  			get 
  			{ 
  				return m_SCQty ; 
  			}  
  			set 
  			{ 
  				m_SCQty = value ; 
  			}  
  		} 
  
  		private decimal m_SCAmount = 0; 
  		public decimal SCAmount 
  		{ 
  			get 
  			{ 
  				return m_SCAmount ; 
  			}  
  			set 
  			{ 
  				m_SCAmount = value ; 
  			}  
  		} 
  
  		private decimal m_BGFY = 0; 
  		public decimal BGFY 
  		{ 
  			get 
  			{ 
  				return m_BGFY ; 
  			}  
  			set 
  			{ 
  				m_BGFY = value ; 
  			}  
  		} 
  
  		private decimal m_BGFY2 = 0; 
  		public decimal BGFY2 
  		{ 
  			get 
  			{ 
  				return m_BGFY2 ; 
  			}  
  			set 
  			{ 
  				m_BGFY2 = value ; 
  			}  
  		} 
  
  		private decimal m_BGFY3 = 0; 
  		public decimal BGFY3 
  		{ 
  			get 
  			{ 
  				return m_BGFY3 ; 
  			}  
  			set 
  			{ 
  				m_BGFY3 = value ; 
  			}  
  		} 
  
  		private decimal m_BGFY4 = 0; 
  		public decimal BGFY4 
  		{ 
  			get 
  			{ 
  				return m_BGFY4 ; 
  			}  
  			set 
  			{ 
  				m_BGFY4 = value ; 
  			}  
  		} 
  
  		private decimal m_BGFY5 = 0; 
  		public decimal BGFY5 
  		{ 
  			get 
  			{ 
  				return m_BGFY5 ; 
  			}  
  			set 
  			{ 
  				m_BGFY5 = value ; 
  			}  
  		} 
  
  		private string m_Country = string.Empty ; 
  		public string Country 
  		{ 
  			get 
  			{ 
  				return m_Country ; 
  			}  
  			set 
  			{ 
  				m_Country = value ; 
  			}  
  		} 
  
  		private string m_ZM = string.Empty ; 
  		public string ZM 
  		{ 
  			get 
  			{ 
  				return m_ZM ; 
  			}  
  			set 
  			{ 
  				m_ZM = value ; 
  			}  
  		} 
  
  		private string m_Model = string.Empty ; 
  		public string Model 
  		{ 
  			get 
  			{ 
  				return m_Model ; 
  			}  
  			set 
  			{ 
  				m_Model = value ; 
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
  
  		private string m_KGUnit = string.Empty ; 
  		public string KGUnit 
  		{ 
  			get 
  			{ 
  				return m_KGUnit ; 
  			}  
  			set 
  			{ 
  				m_KGUnit = value ; 
  			}  
  		} 
  
  		private string m_AmountUnit = string.Empty ; 
  		public string AmountUnit 
  		{ 
  			get 
  			{ 
  				return m_AmountUnit ; 
  			}  
  			set 
  			{ 
  				m_AmountUnit = value ; 
  			}  
  		} 
  
  		private string m_AmountEnUnit = string.Empty ; 
  		public string AmountEnUnit 
  		{ 
  			get 
  			{ 
  				return m_AmountEnUnit ; 
  			}  
  			set 
  			{ 
  				m_AmountEnUnit = value ; 
  			}  
  		} 
  
  		private decimal m_NetQty = 0; 
  		public decimal NetQty 
  		{ 
  			get 
  			{ 
  				return m_NetQty ; 
  			}  
  			set 
  			{ 
  				m_NetQty = value ; 
  			}  
  		} 
  
  		private decimal m_Amount = 0; 
  		public decimal Amount 
  		{ 
  			get 
  			{ 
  				return m_Amount ; 
  			}  
  			set 
  			{ 
  				m_Amount = value ; 
  			}  
  		} 
  
  		private string m_Size1 = string.Empty ; 
  		public string Size1 
  		{ 
  			get 
  			{ 
  				return m_Size1 ; 
  			}  
  			set 
  			{ 
  				m_Size1 = value ; 
  			}  
  		} 
  
  		private string m_Size2 = string.Empty ; 
  		public string Size2 
  		{ 
  			get 
  			{ 
  				return m_Size2 ; 
  			}  
  			set 
  			{ 
  				m_Size2 = value ; 
  			}  
  		} 
  
  		private string m_Size3 = string.Empty ; 
  		public string Size3 
  		{ 
  			get 
  			{ 
  				return m_Size3 ; 
  			}  
  			set 
  			{ 
  				m_Size3 = value ; 
  			}  
  		} 
  
  		private string m_Size4 = string.Empty ; 
  		public string Size4 
  		{ 
  			get 
  			{ 
  				return m_Size4 ; 
  			}  
  			set 
  			{ 
  				m_Size4 = value ; 
  			}  
  		} 
  
  		private string m_Size5 = string.Empty ; 
  		public string Size5 
  		{ 
  			get 
  			{ 
  				return m_Size5 ; 
  			}  
  			set 
  			{ 
  				m_Size5 = value ; 
  			}  
  		} 
  
  		private string m_Size6 = string.Empty ; 
  		public string Size6 
  		{ 
  			get 
  			{ 
  				return m_Size6 ; 
  			}  
  			set 
  			{ 
  				m_Size6 = value ; 
  			}  
  		} 
  
  		private decimal m_length1 = 0; 
  		public decimal length1 
  		{ 
  			get 
  			{ 
  				return m_length1 ; 
  			}  
  			set 
  			{ 
  				m_length1 = value ; 
  			}  
  		} 
  
  		private decimal m_length2 = 0; 
  		public decimal length2 
  		{ 
  			get 
  			{ 
  				return m_length2 ; 
  			}  
  			set 
  			{ 
  				m_length2 = value ; 
  			}  
  		} 
  
  		private decimal m_length3 = 0; 
  		public decimal length3 
  		{ 
  			get 
  			{ 
  				return m_length3 ; 
  			}  
  			set 
  			{ 
  				m_length3 = value ; 
  			}  
  		} 
  
  		private decimal m_length4 = 0; 
  		public decimal length4 
  		{ 
  			get 
  			{ 
  				return m_length4 ; 
  			}  
  			set 
  			{ 
  				m_length4 = value ; 
  			}  
  		} 
  
  		private decimal m_length5 = 0; 
  		public decimal length5 
  		{ 
  			get 
  			{ 
  				return m_length5 ; 
  			}  
  			set 
  			{ 
  				m_length5 = value ; 
  			}  
  		} 
  
  		private decimal m_length6 = 0; 
  		public decimal length6 
  		{ 
  			get 
  			{ 
  				return m_length6 ; 
  			}  
  			set 
  			{ 
  				m_length6 = value ; 
  			}  
  		} 
  
  		private string m_Size7 = string.Empty ; 
  		public string Size7 
  		{ 
  			get 
  			{ 
  				return m_Size7 ; 
  			}  
  			set 
  			{ 
  				m_Size7 = value ; 
  			}  
  		} 
  
  		private string m_Size8 = string.Empty ; 
  		public string Size8 
  		{ 
  			get 
  			{ 
  				return m_Size8 ; 
  			}  
  			set 
  			{ 
  				m_Size8 = value ; 
  			}  
  		} 
  
  		private decimal m_length7 = 0; 
  		public decimal length7 
  		{ 
  			get 
  			{ 
  				return m_length7 ; 
  			}  
  			set 
  			{ 
  				m_length7 = value ; 
  			}  
  		} 
  
  		private decimal m_length8 = 0; 
  		public decimal length8 
  		{ 
  			get 
  			{ 
  				return m_length8 ; 
  			}  
  			set 
  			{ 
  				m_length8 = value ; 
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
            string Sql="SELECT * FROM Ship_CustomReportDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Ship_CustomReportDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
                m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_GoodNo=SysConvert.ToString(MasterTable.Rows[0]["GoodNo"]); 
  				m_Description=SysConvert.ToString(MasterTable.Rows[0]["Description"]); 
  				m_Qty=SysConvert.ToInt32(MasterTable.Rows[0]["Qty"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_UnitPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["UnitPrice"]); 
  				m_ICheckedQty=SysConvert.ToInt32(MasterTable.Rows[0]["ICheckedQty"]); 
  				m_ILeftQty=SysConvert.ToInt32(MasterTable.Rows[0]["ILeftQty"]); 
  				m_ICheckedAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ICheckedAmount"]); 
  				m_ILeftAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ILeftAmount"]); 
  				m_SCQty=SysConvert.ToInt32(MasterTable.Rows[0]["SCQty"]); 
  				m_SCAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["SCAmount"]); 
  				m_BGFY=SysConvert.ToDecimal(MasterTable.Rows[0]["BGFY"]); 
  				m_BGFY2=SysConvert.ToDecimal(MasterTable.Rows[0]["BGFY2"]); 
  				m_BGFY3=SysConvert.ToDecimal(MasterTable.Rows[0]["BGFY3"]); 
  				m_BGFY4=SysConvert.ToDecimal(MasterTable.Rows[0]["BGFY4"]); 
  				m_BGFY5=SysConvert.ToDecimal(MasterTable.Rows[0]["BGFY5"]); 
  				m_Country=SysConvert.ToString(MasterTable.Rows[0]["Country"]); 
  				m_ZM=SysConvert.ToString(MasterTable.Rows[0]["ZM"]); 
  				m_Model=SysConvert.ToString(MasterTable.Rows[0]["Model"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_KGUnit=SysConvert.ToString(MasterTable.Rows[0]["KGUnit"]); 
  				m_AmountUnit=SysConvert.ToString(MasterTable.Rows[0]["AmountUnit"]); 
  				m_AmountEnUnit=SysConvert.ToString(MasterTable.Rows[0]["AmountEnUnit"]); 
  				m_NetQty=SysConvert.ToDecimal(MasterTable.Rows[0]["NetQty"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
  				m_Size1=SysConvert.ToString(MasterTable.Rows[0]["Size1"]); 
  				m_Size2=SysConvert.ToString(MasterTable.Rows[0]["Size2"]); 
  				m_Size3=SysConvert.ToString(MasterTable.Rows[0]["Size3"]); 
  				m_Size4=SysConvert.ToString(MasterTable.Rows[0]["Size4"]); 
  				m_Size5=SysConvert.ToString(MasterTable.Rows[0]["Size5"]); 
  				m_Size6=SysConvert.ToString(MasterTable.Rows[0]["Size6"]); 
  				m_length1=SysConvert.ToDecimal(MasterTable.Rows[0]["length1"]); 
  				m_length2=SysConvert.ToDecimal(MasterTable.Rows[0]["length2"]); 
  				m_length3=SysConvert.ToDecimal(MasterTable.Rows[0]["length3"]); 
  				m_length4=SysConvert.ToDecimal(MasterTable.Rows[0]["length4"]); 
  				m_length5=SysConvert.ToDecimal(MasterTable.Rows[0]["length5"]); 
  				m_length6=SysConvert.ToDecimal(MasterTable.Rows[0]["length6"]); 
  				m_Size7=SysConvert.ToString(MasterTable.Rows[0]["Size7"]); 
  				m_Size8=SysConvert.ToString(MasterTable.Rows[0]["Size8"]); 
  				m_length7=SysConvert.ToDecimal(MasterTable.Rows[0]["length7"]); 
  				m_length8=SysConvert.ToDecimal(MasterTable.Rows[0]["length8"]); 
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
