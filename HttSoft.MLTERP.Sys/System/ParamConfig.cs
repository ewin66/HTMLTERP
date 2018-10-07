using System;
//using HttSoft.Framework;
using Microsoft.Win32;

namespace HttSoft.MLTERP.Sys
{
	/// <summary>
	/// 作用：补充 系统配置信息类.(为了把Framework抽离出来)
	/// 作者:陈加海
	/// 创建日期:2005.1.29.
	/// </summary>
	/// <remarks>设置系统配置信息,如不设置则为默认初始值</remarks> 
	public sealed class ParamConfig
	{
		public ParamConfig()
		{
		}

	
		private static string m_MailCharSet="";
		private static string m_MailAccount="";
		private static string m_MailPassword="";
		private static string m_MailServer="";

		private static int m_QueryDayNum=15;
		private static int m_LockDayNum=0;

		private static string m_LoginName="";//登录姓名
        private static string m_LoginID = "";//登录ID
        private static string m_SelfVendorID = "MLTERP";//登录ID
        private static int m_CompanyType = 0;       //公司别

        ///// <summary>
        ///// 仓库开启库别权限校验
        ///// </summary>
        //public static bool WHIDRightFlag = false;

        /// <summary>
        /// 面料仓库单据验证码单和单据明细数量一致性
        /// </summary>
        //public static bool WHMLMDCheckQtyFlag = false;

		#region 关于邮件配置
		/// <summary>
		/// 邮件编码
		/// </summary>
		public static string MailCharSet
		{
			get
			{
				return m_MailCharSet;
			}
			set
			{
				m_MailCharSet=value;
			}
		}

		/// <summary>
		/// 邮件帐号
		/// </summary>
		public static string MailAccount
		{
			get
			{
				return m_MailAccount;
			}
			set
			{
				m_MailAccount=value;
			}
		}

		/// <summary>
		/// 邮件密码
		/// </summary>
		public static string MailPassword
		{
			get
			{
				return m_MailPassword;
			}
			set
			{
				m_MailPassword=value;
			}
		}

		/// <summary>
		/// 邮件服务器
		/// </summary>
		public static string MailServer
		{
			get
			{
				return m_MailServer;
			}
			set
			{
				m_MailServer=value;
			}
		}
		#endregion

        /// <summary>
        /// 公司别
        /// </summary>

        public static int CompanyType
        {
            get
            {
                return m_CompanyType;
            }
            set
            {
                m_CompanyType = value;
            }
        }
        /// <summary>
        /// Query Day Number
        /// </summary>
        public static string SelfVendorID
        {
            get
            {
                return m_SelfVendorID;
            }
            set
            {
                m_SelfVendorID = value;
            }
        }

		/// <summary>
		/// Query Day Number
		/// </summary>
		public static int QueryDayNum
		{
			get
			{
				return m_QueryDayNum;
			}
			set
			{
				m_QueryDayNum=value;
			}
		}

		/// <summary>
		/// Lock Day Number
		/// </summary>
		public static int LockDayNum
		{
			get
			{
				return m_LockDayNum;
			}
			set
			{
				m_LockDayNum=value;
			}
		}
		

		/// <summary>
		/// 登录姓名
		/// </summary>
		public static string LoginName
		{
			get
			{
				return m_LoginName;
			}
			set
			{
				m_LoginName=value;
			}
		}

		

		/// <summary>
		/// 登录帐号
		/// </summary>
		public static string LoginID
		{
			get
			{
				return m_LoginID;
			}
			set
			{
				m_LoginID=value;
			}
		}
	}
}
