using System;
//using HttSoft.Framework;
using Microsoft.Win32;

namespace HttSoft.MLTERP.Sys
{
	/// <summary>
	/// ���ã����� ϵͳ������Ϣ��.(Ϊ�˰�Framework�������)
	/// ����:�¼Ӻ�
	/// ��������:2005.1.29.
	/// </summary>
	/// <remarks>����ϵͳ������Ϣ,�粻������ΪĬ�ϳ�ʼֵ</remarks> 
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

		private static string m_LoginName="";//��¼����
        private static string m_LoginID = "";//��¼ID
        private static string m_SelfVendorID = "MLTERP";//��¼ID
        private static int m_CompanyType = 0;       //��˾��

        ///// <summary>
        ///// �ֿ⿪�����Ȩ��У��
        ///// </summary>
        //public static bool WHIDRightFlag = false;

        /// <summary>
        /// ���ϲֿⵥ����֤�뵥�͵�����ϸ����һ����
        /// </summary>
        //public static bool WHMLMDCheckQtyFlag = false;

		#region �����ʼ�����
		/// <summary>
		/// �ʼ�����
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
		/// �ʼ��ʺ�
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
		/// �ʼ�����
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
		/// �ʼ�������
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
        /// ��˾��
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
		/// ��¼����
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
		/// ��¼�ʺ�
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
