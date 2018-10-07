using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WO_Design实体类
	/// 作者:曹小艮
	/// 创建日期:2011-12-1
	/// </summary>
	public sealed class Design : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Design()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public Design(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		 
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
  
  		private string m_Code = string.Empty ; 
  		public string Code 
  		{ 
  			get 
  			{ 
  				return m_Code ; 
  			}  
  			set 
  			{ 
  				m_Code = value ; 
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
  
  		private string m_PlanCode = string.Empty ; 
  		public string PlanCode 
  		{ 
  			get 
  			{ 
  				return m_PlanCode ; 
  			}  
  			set 
  			{ 
  				m_PlanCode = value ; 
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
  
  		private string m_XinXian = string.Empty ; 
  		public string XinXian 
  		{ 
  			get 
  			{ 
  				return m_XinXian ; 
  			}  
  			set 
  			{ 
  				m_XinXian = value ; 
  			}  
  		} 
  
  		private string m_YaXian = string.Empty ; 
  		public string YaXian 
  		{ 
  			get 
  			{ 
  				return m_YaXian ; 
  			}  
  			set 
  			{ 
  				m_YaXian = value ; 
  			}  
  		} 
  
  		private string m_FuXian = string.Empty ; 
  		public string FuXian 
  		{ 
  			get 
  			{ 
  				return m_FuXian ; 
  			}  
  			set 
  			{ 
  				m_FuXian = value ; 
  			}  
  		} 
  
  		private string m_GYRemark = string.Empty ; 
  		public string GYRemark 
  		{ 
  			get 
  			{ 
  				return m_GYRemark ; 
  			}  
  			set 
  			{ 
  				m_GYRemark = value ; 
  			}  
  		} 
  
  		private decimal m_PJiaoChang = 0; 
  		public decimal PJiaoChang 
  		{ 
  			get 
  			{ 
  				return m_PJiaoChang ; 
  			}  
  			set 
  			{ 
  				m_PJiaoChang = value ; 
  			}  
  		} 
  
  		private decimal m_PJiaoZhong = 0; 
  		public decimal PJiaoZhong 
  		{ 
  			get 
  			{ 
  				return m_PJiaoZhong ; 
  			}  
  			set 
  			{ 
  				m_PJiaoZhong = value ; 
  			}  
  		} 
  
  		private string m_PRemark = string.Empty ; 
  		public string PRemark 
  		{ 
  			get 
  			{ 
  				return m_PRemark ; 
  			}  
  			set 
  			{ 
  				m_PRemark = value ; 
  			}  
  		} 
  
  		private decimal m_SJiaoChang = 0; 
  		public decimal SJiaoChang 
  		{ 
  			get 
  			{ 
  				return m_SJiaoChang ; 
  			}  
  			set 
  			{ 
  				m_SJiaoChang = value ; 
  			}  
  		} 
  
  		private decimal m_SJiaoZhong = 0; 
  		public decimal SJiaoZhong 
  		{ 
  			get 
  			{ 
  				return m_SJiaoZhong ; 
  			}  
  			set 
  			{ 
  				m_SJiaoZhong = value ; 
  			}  
  		} 
  
  		private string m_SRemark = string.Empty ; 
  		public string SRemark 
  		{ 
  			get 
  			{ 
  				return m_SRemark ; 
  			}  
  			set 
  			{ 
  				m_SRemark = value ; 
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
            string Sql="SELECT * FROM WO_Design WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_Design WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_PlanCode=SysConvert.ToString(MasterTable.Rows[0]["PlanCode"]); 
  				m_SOID=SysConvert.ToString(MasterTable.Rows[0]["SOID"]); 
  				m_XinXian=SysConvert.ToString(MasterTable.Rows[0]["XinXian"]); 
  				m_YaXian=SysConvert.ToString(MasterTable.Rows[0]["YaXian"]); 
  				m_FuXian=SysConvert.ToString(MasterTable.Rows[0]["FuXian"]); 
  				m_GYRemark=SysConvert.ToString(MasterTable.Rows[0]["GYRemark"]); 
  				m_PJiaoChang=SysConvert.ToDecimal(MasterTable.Rows[0]["PJiaoChang"]); 
  				m_PJiaoZhong=SysConvert.ToDecimal(MasterTable.Rows[0]["PJiaoZhong"]); 
  				m_PRemark=SysConvert.ToString(MasterTable.Rows[0]["PRemark"]); 
  				m_SJiaoChang=SysConvert.ToDecimal(MasterTable.Rows[0]["SJiaoChang"]); 
  				m_SJiaoZhong=SysConvert.ToDecimal(MasterTable.Rows[0]["SJiaoZhong"]); 
  				m_SRemark=SysConvert.ToString(MasterTable.Rows[0]["SRemark"]); 
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
