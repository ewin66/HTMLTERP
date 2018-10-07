using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_HandleEvent实体类
	/// 作者:tanghao
	/// 创建日期:2015/5/22
	/// </summary>
	public sealed class HandleEvent : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public HandleEvent()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public HandleEvent(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Sale_HandleEvent";
		 
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
  
  		private DateTime m_FormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FormDate 
  		{ 
  			get 
  			{ 
  				return m_FormDate ; 
  			}  
  			set 
  			{ 
  				m_FormDate = value ; 
  			}  
  		} 
  
  		private string m_EventType = string.Empty ; 
  		public string EventType 
  		{ 
  			get 
  			{ 
  				return m_EventType ; 
  			}  
  			set 
  			{ 
  				m_EventType = value ; 
  			}  
  		} 
  
  		private string m_VedorID = string.Empty ; 
  		public string VedorID 
  		{ 
  			get 
  			{ 
  				return m_VedorID ; 
  			}  
  			set 
  			{ 
  				m_VedorID = value ; 
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
  
  		private string m_Remark1 = string.Empty ; 
  		public string Remark1 
  		{ 
  			get 
  			{ 
  				return m_Remark1 ; 
  			}  
  			set 
  			{ 
  				m_Remark1 = value ; 
  			}  
  		} 
  
  		private string m_Remark2 = string.Empty ; 
  		public string Remark2 
  		{ 
  			get 
  			{ 
  				return m_Remark2 ; 
  			}  
  			set 
  			{ 
  				m_Remark2 = value ; 
  			}  
  		} 
  
  		private string m_Remark3 = string.Empty ; 
  		public string Remark3 
  		{ 
  			get 
  			{ 
  				return m_Remark3 ; 
  			}  
  			set 
  			{ 
  				m_Remark3 = value ; 
  			}  
  		} 
  
  		private string m_Remark4 = string.Empty ; 
  		public string Remark4 
  		{ 
  			get 
  			{ 
  				return m_Remark4 ; 
  			}  
  			set 
  			{ 
  				m_Remark4 = value ; 
  			}  
  		} 
  
  		private string m_Remark5 = string.Empty ; 
  		public string Remark5 
  		{ 
  			get 
  			{ 
  				return m_Remark5 ; 
  			}  
  			set 
  			{ 
  				m_Remark5 = value ; 
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
  
  		private int m_EventStatus = 0; 
  		public int EventStatus 
  		{ 
  			get 
  			{ 
  				return m_EventStatus ; 
  			}  
  			set 
  			{ 
  				m_EventStatus = value ; 
  			}  
  		} 
  
  		private DateTime m_RDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime RDate 
  		{ 
  			get 
  			{ 
  				return m_RDate ; 
  			}  
  			set 
  			{ 
  				m_RDate = value ; 
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
            string Sql="SELECT * FROM Sale_HandleEvent WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_HandleEvent WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_EventType=SysConvert.ToString(MasterTable.Rows[0]["EventType"]); 
  				m_VedorID=SysConvert.ToString(MasterTable.Rows[0]["VedorID"]); 
  				m_OrderFormNo=SysConvert.ToString(MasterTable.Rows[0]["OrderFormNo"]); 
  				m_Remark1=SysConvert.ToString(MasterTable.Rows[0]["Remark1"]); 
  				m_Remark2=SysConvert.ToString(MasterTable.Rows[0]["Remark2"]); 
  				m_Remark3=SysConvert.ToString(MasterTable.Rows[0]["Remark3"]); 
  				m_Remark4=SysConvert.ToString(MasterTable.Rows[0]["Remark4"]); 
  				m_Remark5=SysConvert.ToString(MasterTable.Rows[0]["Remark5"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_EventStatus=SysConvert.ToInt32(MasterTable.Rows[0]["EventStatus"]); 
  				m_RDate=SysConvert.ToDateTime(MasterTable.Rows[0]["RDate"]); 
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
