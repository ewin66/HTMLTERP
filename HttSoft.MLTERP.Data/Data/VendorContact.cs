using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_VendorContact实体类
	/// 作者:章文强
	/// 创建日期:2014/11/3
	/// </summary>
	public sealed class VendorContact : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public VendorContact()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public VendorContact(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_VendorContact";
		 
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
  
  		private string m_Name = string.Empty ; 
  		public string Name 
  		{ 
  			get 
  			{ 
  				return m_Name ; 
  			}  
  			set 
  			{ 
  				m_Name = value ; 
  			}  
  		} 
  
  		private string m_FL = string.Empty ; 
  		public string FL 
  		{ 
  			get 
  			{ 
  				return m_FL ; 
  			}  
  			set 
  			{ 
  				m_FL = value ; 
  			}  
  		} 
  
  		private string m_TEL = string.Empty ; 
  		public string TEL 
  		{ 
  			get 
  			{ 
  				return m_TEL ; 
  			}  
  			set 
  			{ 
  				m_TEL = value ; 
  			}  
  		} 
  
  		private string m_FAX = string.Empty ; 
  		public string FAX 
  		{ 
  			get 
  			{ 
  				return m_FAX ; 
  			}  
  			set 
  			{ 
  				m_FAX = value ; 
  			}  
  		} 
  
  		private string m_Mobil = string.Empty ; 
  		public string Mobil 
  		{ 
  			get 
  			{ 
  				return m_Mobil ; 
  			}  
  			set 
  			{ 
  				m_Mobil = value ; 
  			}  
  		} 
  
  		private string m_SubTel = string.Empty ; 
  		public string SubTel 
  		{ 
  			get 
  			{ 
  				return m_SubTel ; 
  			}  
  			set 
  			{ 
  				m_SubTel = value ; 
  			}  
  		} 
  
  		private string m_Dep = string.Empty ; 
  		public string Dep 
  		{ 
  			get 
  			{ 
  				return m_Dep ; 
  			}  
  			set 
  			{ 
  				m_Dep = value ; 
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
  
  		private DateTime m_SpecialDay = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SpecialDay 
  		{ 
  			get 
  			{ 
  				return m_SpecialDay ; 
  			}  
  			set 
  			{ 
  				m_SpecialDay = value ; 
  			}  
  		} 
  
  		private int m_BirthdayNoAlarmFlag = 0; 
  		public int BirthdayNoAlarmFlag 
  		{ 
  			get 
  			{ 
  				return m_BirthdayNoAlarmFlag ; 
  			}  
  			set 
  			{ 
  				m_BirthdayNoAlarmFlag = value ; 
  			}  
  		} 
  
  		private string m_TELTwo = string.Empty ; 
  		public string TELTwo 
  		{ 
  			get 
  			{ 
  				return m_TELTwo ; 
  			}  
  			set 
  			{ 
  				m_TELTwo = value ; 
  			}  
  		} 
  
  		private string m_TELThree = string.Empty ; 
  		public string TELThree 
  		{ 
  			get 
  			{ 
  				return m_TELThree ; 
  			}  
  			set 
  			{ 
  				m_TELThree = value ; 
  			}  
  		} 
  
  		private string m_QQ = string.Empty ; 
  		public string QQ 
  		{ 
  			get 
  			{ 
  				return m_QQ ; 
  			}  
  			set 
  			{ 
  				m_QQ = value ; 
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
  
  		private string m_FreeStr = string.Empty ; 
  		public string FreeStr 
  		{ 
  			get 
  			{ 
  				return m_FreeStr ; 
  			}  
  			set 
  			{ 
  				m_FreeStr = value ; 
  			}  
  		} 
  
  		private string m_ContactEn = string.Empty ; 
  		public string ContactEn 
  		{ 
  			get 
  			{ 
  				return m_ContactEn ; 
  			}  
  			set 
  			{ 
  				m_ContactEn = value ; 
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
            string Sql="SELECT * FROM Data_VendorContact WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_VendorContact WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_Name=SysConvert.ToString(MasterTable.Rows[0]["Name"]); 
  				m_FL=SysConvert.ToString(MasterTable.Rows[0]["FL"]); 
  				m_TEL=SysConvert.ToString(MasterTable.Rows[0]["TEL"]); 
  				m_FAX=SysConvert.ToString(MasterTable.Rows[0]["FAX"]); 
  				m_Mobil=SysConvert.ToString(MasterTable.Rows[0]["Mobil"]); 
  				m_SubTel=SysConvert.ToString(MasterTable.Rows[0]["SubTel"]); 
  				m_Dep=SysConvert.ToString(MasterTable.Rows[0]["Dep"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_Birthday=SysConvert.ToDateTime(MasterTable.Rows[0]["Birthday"]); 
  				m_SpecialDay=SysConvert.ToDateTime(MasterTable.Rows[0]["SpecialDay"]); 
  				m_BirthdayNoAlarmFlag=SysConvert.ToInt32(MasterTable.Rows[0]["BirthdayNoAlarmFlag"]); 
  				m_TELTwo=SysConvert.ToString(MasterTable.Rows[0]["TELTwo"]); 
  				m_TELThree=SysConvert.ToString(MasterTable.Rows[0]["TELThree"]); 
  				m_QQ=SysConvert.ToString(MasterTable.Rows[0]["QQ"]); 
  				m_Email=SysConvert.ToString(MasterTable.Rows[0]["Email"]); 
  				m_FreeStr=SysConvert.ToString(MasterTable.Rows[0]["FreeStr"]); 
  				m_ContactEn=SysConvert.ToString(MasterTable.Rows[0]["ContactEn"]); 
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
