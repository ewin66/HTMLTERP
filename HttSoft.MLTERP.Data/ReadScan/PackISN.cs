using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WO_PackISN实体类
	/// 作者:Johnny
	/// 创建日期:2012/5/26
	/// </summary>
	public sealed class PackISN : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public PackISN()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public PackISN(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_PackISN";
		 
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
  
  		private string m_PackISNS = string.Empty ; 
  		public string PackISNS 
  		{ 
  			get 
  			{ 
  				return m_PackISNS ; 
  			}  
  			set 
  			{ 
  				m_PackISNS = value ; 
  			}  
  		} 
  
  		private DateTime m_PackDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime PackDate 
  		{ 
  			get 
  			{ 
  				return m_PackDate ; 
  			}  
  			set 
  			{ 
  				m_PackDate = value ; 
  			}  
  		} 
  
  		private string m_PackOPID = string.Empty ; 
  		public string PackOPID 
  		{ 
  			get 
  			{ 
  				return m_PackOPID ; 
  			}  
  			set 
  			{ 
  				m_PackOPID = value ; 
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
  
  		private string m_FlowType = string.Empty ; 
  		public string FlowType 
  		{ 
  			get 
  			{ 
  				return m_FlowType ; 
  			}  
  			set 
  			{ 
  				m_FlowType = value ; 
  			}  
  		} 
  
  		private decimal m_TotalLength = 0; 
  		public decimal TotalLength 
  		{ 
  			get 
  			{ 
  				return m_TotalLength ; 
  			}  
  			set 
  			{ 
  				m_TotalLength = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM WO_PackISN WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_PackISN WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_PackISNS=SysConvert.ToString(MasterTable.Rows[0]["PackISNS"]); 
  				m_PackDate=SysConvert.ToDateTime(MasterTable.Rows[0]["PackDate"]); 
  				m_PackOPID=SysConvert.ToString(MasterTable.Rows[0]["PackOPID"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_FlowType=SysConvert.ToString(MasterTable.Rows[0]["FlowType"]); 
  				m_TotalLength=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalLength"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
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
