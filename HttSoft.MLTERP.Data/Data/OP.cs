using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_OP实体类
	/// 作者:zhp
	/// 创建日期:2016/9/2
	/// </summary>
	public sealed class OP : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public OP()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public OP(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_OP";
		 
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
  
  		private string m_OPID = string.Empty ; 
  		public string OPID 
  		{ 
  			get 
  			{ 
  				return m_OPID ; 
  			}  
  			set 
  			{ 
  				m_OPID = value ; 
  			}  
  		} 
  
  		private string m_OPName = string.Empty ; 
  		public string OPName 
  		{ 
  			get 
  			{ 
  				return m_OPName ; 
  			}  
  			set 
  			{ 
  				m_OPName = value ; 
  			}  
  		} 
  
  		private string m_SDuty = string.Empty ; 
  		public string SDuty 
  		{ 
  			get 
  			{ 
  				return m_SDuty ; 
  			}  
  			set 
  			{ 
  				m_SDuty = value ; 
  			}  
  		} 
  
  		private string m_SDep = string.Empty ; 
  		public string SDep 
  		{ 
  			get 
  			{ 
  				return m_SDep ; 
  			}  
  			set 
  			{ 
  				m_SDep = value ; 
  			}  
  		} 
  
  		private string m_SWork = string.Empty ; 
  		public string SWork 
  		{ 
  			get 
  			{ 
  				return m_SWork ; 
  			}  
  			set 
  			{ 
  				m_SWork = value ; 
  			}  
  		} 
  
  		private string m_Sex = string.Empty ; 
  		public string Sex 
  		{ 
  			get 
  			{ 
  				return m_Sex ; 
  			}  
  			set 
  			{ 
  				m_Sex = value ; 
  			}  
  		} 
  
  		private DateTime m_Birthday = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime Birthday 
  		{ 
  			get 
  			{ 
  				return m_Birthday ; 
  			}  
  			set 
  			{ 
  				m_Birthday = value ; 
  			}  
  		} 
  
  		private string m_Diploma = string.Empty ; 
  		public string Diploma 
  		{ 
  			get 
  			{ 
  				return m_Diploma ; 
  			}  
  			set 
  			{ 
  				m_Diploma = value ; 
  			}  
  		} 
  
  		private DateTime m_InDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime InDate 
  		{ 
  			get 
  			{ 
  				return m_InDate ; 
  			}  
  			set 
  			{ 
  				m_InDate = value ; 
  			}  
  		} 
  
  		private string m_CardID = string.Empty ; 
  		public string CardID 
  		{ 
  			get 
  			{ 
  				return m_CardID ; 
  			}  
  			set 
  			{ 
  				m_CardID = value ; 
  			}  
  		} 
  
  		private string m_Origin = string.Empty ; 
  		public string Origin 
  		{ 
  			get 
  			{ 
  				return m_Origin ; 
  			}  
  			set 
  			{ 
  				m_Origin = value ; 
  			}  
  		} 
  
  		private string m_Nation = string.Empty ; 
  		public string Nation 
  		{ 
  			get 
  			{ 
  				return m_Nation ; 
  			}  
  			set 
  			{ 
  				m_Nation = value ; 
  			}  
  		} 
  
  		private string m_Political = string.Empty ; 
  		public string Political 
  		{ 
  			get 
  			{ 
  				return m_Political ; 
  			}  
  			set 
  			{ 
  				m_Political = value ; 
  			}  
  		} 
  
  		private string m_MarriageState = string.Empty ; 
  		public string MarriageState 
  		{ 
  			get 
  			{ 
  				return m_MarriageState ; 
  			}  
  			set 
  			{ 
  				m_MarriageState = value ; 
  			}  
  		} 
  
  		private string m_Phone = string.Empty ; 
  		public string Phone 
  		{ 
  			get 
  			{ 
  				return m_Phone ; 
  			}  
  			set 
  			{ 
  				m_Phone = value ; 
  			}  
  		} 
  
  		private string m_Address = string.Empty ; 
  		public string Address 
  		{ 
  			get 
  			{ 
  				return m_Address ; 
  			}  
  			set 
  			{ 
  				m_Address = value ; 
  			}  
  		} 
  
  		private string m_Email = string.Empty ; 
  		public string Email 
  		{ 
  			get 
  			{ 
  				return m_Email ; 
  			}  
  			set 
  			{ 
  				m_Email = value ; 
  			}  
  		} 
  
  		private int m_DefaultFlag = 0; 
  		public int DefaultFlag 
  		{ 
  			get 
  			{ 
  				return m_DefaultFlag ; 
  			}  
  			set 
  			{ 
  				m_DefaultFlag = value ; 
  			}  
  		} 
  
  		private int m_UseableFlag = 0; 
  		public int UseableFlag 
  		{ 
  			get 
  			{ 
  				return m_UseableFlag ; 
  			}  
  			set 
  			{ 
  				m_UseableFlag = value ; 
  			}  
  		} 
  
  		private int m_WebFlag = 0; 
  		public int WebFlag 
  		{ 
  			get 
  			{ 
  				return m_WebFlag ; 
  			}  
  			set 
  			{ 
  				m_WebFlag = value ; 
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
  
  		private int m_DRoleID = 0; 
  		public int DRoleID 
  		{ 
  			get 
  			{ 
  				return m_DRoleID ; 
  			}  
  			set 
  			{ 
  				m_DRoleID = value ; 
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
  
  		private string m_Password = string.Empty ; 
  		public string Password 
  		{ 
  			get 
  			{ 
  				return m_Password ; 
  			}  
  			set 
  			{ 
  				m_Password = value ; 
  			}  
  		} 
  
  		private string m_Mobile = string.Empty ; 
  		public string Mobile 
  		{ 
  			get 
  			{ 
  				return m_Mobile ; 
  			}  
  			set 
  			{ 
  				m_Mobile = value ; 
  			}  
  		} 
  
  		private string m_OPCode = string.Empty ; 
  		public string OPCode 
  		{ 
  			get 
  			{ 
  				return m_OPCode ; 
  			}  
  			set 
  			{ 
  				m_OPCode = value ; 
  			}  
  		} 
  
  		private int m_DepID = 0; 
  		public int DepID 
  		{ 
  			get 
  			{ 
  				return m_DepID ; 
  			}  
  			set 
  			{ 
  				m_DepID = value ; 
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
            string Sql="SELECT * FROM Data_OP WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_OP WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_OPID=SysConvert.ToString(MasterTable.Rows[0]["OPID"]); 
  				m_OPName=SysConvert.ToString(MasterTable.Rows[0]["OPName"]); 
  				m_SDuty=SysConvert.ToString(MasterTable.Rows[0]["SDuty"]); 
  				m_SDep=SysConvert.ToString(MasterTable.Rows[0]["SDep"]); 
  				m_SWork=SysConvert.ToString(MasterTable.Rows[0]["SWork"]); 
  				m_Sex=SysConvert.ToString(MasterTable.Rows[0]["Sex"]); 
  				m_Birthday=SysConvert.ToDateTime(MasterTable.Rows[0]["Birthday"]); 
  				m_Diploma=SysConvert.ToString(MasterTable.Rows[0]["Diploma"]); 
  				m_InDate=SysConvert.ToDateTime(MasterTable.Rows[0]["InDate"]); 
  				m_CardID=SysConvert.ToString(MasterTable.Rows[0]["CardID"]); 
  				m_Origin=SysConvert.ToString(MasterTable.Rows[0]["Origin"]); 
  				m_Nation=SysConvert.ToString(MasterTable.Rows[0]["Nation"]); 
  				m_Political=SysConvert.ToString(MasterTable.Rows[0]["Political"]); 
  				m_MarriageState=SysConvert.ToString(MasterTable.Rows[0]["MarriageState"]); 
  				m_Phone=SysConvert.ToString(MasterTable.Rows[0]["Phone"]); 
  				m_Address=SysConvert.ToString(MasterTable.Rows[0]["Address"]); 
  				m_Email=SysConvert.ToString(MasterTable.Rows[0]["Email"]); 
  				m_DefaultFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DefaultFlag"]); 
  				m_UseableFlag=SysConvert.ToInt32(MasterTable.Rows[0]["UseableFlag"]); 
  				m_WebFlag=SysConvert.ToInt32(MasterTable.Rows[0]["WebFlag"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_DRoleID=SysConvert.ToInt32(MasterTable.Rows[0]["DRoleID"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_Password=SysConvert.ToString(MasterTable.Rows[0]["Password"]); 
  				m_Mobile=SysConvert.ToString(MasterTable.Rows[0]["Mobile"]); 
  				m_OPCode=SysConvert.ToString(MasterTable.Rows[0]["OPCode"]); 
  				m_DepID=SysConvert.ToInt32(MasterTable.Rows[0]["DepID"]); 
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
