using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Buy_YarnCompactDts实体类
	/// 作者:辛明献
	/// 创建日期:2011-11-4
	/// </summary>
	public sealed class YarnCompactDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public YarnCompactDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public YarnCompactDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		 
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
  
  		private string m_DesignNo = string.Empty ; 
  		public string DesignNo 
  		{ 
  			get 
  			{ 
  				return m_DesignNo ; 
  			}  
  			set 
  			{ 
  				m_DesignNo = value ; 
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
  
  		private string m_SOID = string.Empty ; 
  		public string SOID 
  		{ 
  			get 
  			{ 
  				return m_SOID ; 
  			}  
  			set 
  			{ 
  				m_SOID = value ; 
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
  
  		private string m_EditionNo = string.Empty ; 
  		public string EditionNo 
  		{ 
  			get 
  			{ 
  				return m_EditionNo ; 
  			}  
  			set 
  			{ 
  				m_EditionNo = value ; 
  			}  
  		} 
  
  		private DateTime m_InWHDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime InWHDate 
  		{ 
  			get 
  			{ 
  				return m_InWHDate ; 
  			}  
  			set 
  			{ 
  				m_InWHDate = value ; 
  			}  
  		} 
  
  		private string m_Yarnstatus = string.Empty ; 
  		public string Yarnstatus 
  		{ 
  			get 
  			{ 
  				return m_Yarnstatus ; 
  			}  
  			set 
  			{ 
  				m_Yarnstatus = value ; 
  			}  
  		} 
  
  		private decimal m_CompactQty = 0; 
  		public decimal CompactQty 
  		{ 
  			get 
  			{ 
  				return m_CompactQty ; 
  			}  
  			set 
  			{ 
  				m_CompactQty = value ; 
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
  
  		private decimal m_InWHQty = 0; 
  		public decimal InWHQty 
  		{ 
  			get 
  			{ 
  				return m_InWHQty ; 
  			}  
  			set 
  			{ 
  				m_InWHQty = value ; 
  			}  
  		} 
  
  		private int m_YarnTypeID = 0; 
  		public int YarnTypeID 
  		{ 
  			get 
  			{ 
  				return m_YarnTypeID ; 
  			}  
  			set 
  			{ 
  				m_YarnTypeID = value ; 
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
            string Sql="SELECT * FROM Buy_YarnCompactDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Buy_YarnCompactDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_DesignNo=SysConvert.ToString(MasterTable.Rows[0]["DesignNo"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_SOID=SysConvert.ToString(MasterTable.Rows[0]["SOID"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_EditionNo=SysConvert.ToString(MasterTable.Rows[0]["EditionNo"]); 
  				m_InWHDate=SysConvert.ToDateTime(MasterTable.Rows[0]["InWHDate"]); 
  				m_Yarnstatus=SysConvert.ToString(MasterTable.Rows[0]["Yarnstatus"]); 
  				m_CompactQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CompactQty"]); 
  				m_UnitPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["UnitPrice"]); 
  				m_InWHQty=SysConvert.ToDecimal(MasterTable.Rows[0]["InWHQty"]); 
  				m_YarnTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["YarnTypeID"]); 
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
