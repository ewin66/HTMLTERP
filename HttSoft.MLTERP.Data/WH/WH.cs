using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WH_WH实体类
	/// 作者:陈加海
	/// 创建日期:2012/5/10
	/// </summary>
	public sealed class WH : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public WH()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public WH(IDBTransAccess p_SqlCmd)
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
  
  		private string m_WHID = string.Empty ; 
  		public string WHID 
  		{ 
  			get 
  			{ 
  				return m_WHID ; 
  			}  
  			set 
  			{ 
  				m_WHID = value ; 
  			}  
  		} 
  
  		private string m_WHNM = string.Empty ; 
  		public string WHNM 
  		{ 
  			get 
  			{ 
  				return m_WHNM ; 
  			}  
  			set 
  			{ 
  				m_WHNM = value ; 
  			}  
  		} 
  
  		private string m_WHType = string.Empty ; 
  		public string WHType 
  		{ 
  			get 
  			{ 
  				return m_WHType ; 
  			}  
  			set 
  			{ 
  				m_WHType = value ; 
  			}  
  		} 
  
  		private DateTime m_WHStartDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime WHStartDate 
  		{ 
  			get 
  			{ 
  				return m_WHStartDate ; 
  			}  
  			set 
  			{ 
  				m_WHStartDate = value ; 
  			}  
  		} 
  
  		private int m_WHCalMethodID = 0; 
  		public int WHCalMethodID 
  		{ 
  			get 
  			{ 
  				return m_WHCalMethodID ; 
  			}  
  			set 
  			{ 
  				m_WHCalMethodID = value ; 
  			}  
  		} 
  
  		private int m_IsUseable = 0; 
  		public int IsUseable 
  		{ 
  			get 
  			{ 
  				return m_IsUseable ; 
  			}  
  			set 
  			{ 
  				m_IsUseable = value ; 
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
  
  		private int m_WHPosMethodID = 0; 
  		public int WHPosMethodID 
  		{ 
  			get 
  			{ 
  				return m_WHPosMethodID ; 
  			}  
  			set 
  			{ 
  				m_WHPosMethodID = value ; 
  			}  
  		} 
  
  		private string m_ItemUnit = string.Empty ; 
  		public string ItemUnit 
  		{ 
  			get 
  			{ 
  				return m_ItemUnit ; 
  			}  
  			set 
  			{ 
  				m_ItemUnit = value ; 
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
  
  		private int m_ISJK = 0; 
  		public int ISJK 
  		{ 
  			get 
  			{ 
  				return m_ISJK ; 
  			}  
  			set 
  			{ 
  				m_ISJK = value ; 
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
            string Sql="SELECT * FROM WH_WH WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_WH WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_WHID=SysConvert.ToString(MasterTable.Rows[0]["WHID"]); 
  				m_WHNM=SysConvert.ToString(MasterTable.Rows[0]["WHNM"]); 
  				m_WHType=SysConvert.ToString(MasterTable.Rows[0]["WHType"]); 
  				m_WHStartDate=SysConvert.ToDateTime(MasterTable.Rows[0]["WHStartDate"]); 
  				m_WHCalMethodID=SysConvert.ToInt32(MasterTable.Rows[0]["WHCalMethodID"]); 
  				m_IsUseable=SysConvert.ToInt32(MasterTable.Rows[0]["IsUseable"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_WHPosMethodID=SysConvert.ToInt32(MasterTable.Rows[0]["WHPosMethodID"]); 
  				m_ItemUnit=SysConvert.ToString(MasterTable.Rows[0]["ItemUnit"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_ISJK=SysConvert.ToInt32(MasterTable.Rows[0]["ISJK"]); 
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
