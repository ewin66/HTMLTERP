using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_AuthGrpWinListʵ����
	/// ����:�ܸ���
	/// ��������:2012-4-24
	/// </summary>
	public sealed class AuthGrpWinList : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public AuthGrpWinList()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public AuthGrpWinList(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		 
  		private int m_AuthGrpID = 0; 
  		public int AuthGrpID 
  		{ 
  			get 
  			{ 
  				return m_AuthGrpID ; 
  			}  
  			set 
  			{ 
  				m_AuthGrpID = value ; 
  			}  
  		} 
  
  		private int m_WinListID = 0; 
  		public int WinListID 
  		{ 
  			get 
  			{ 
  				return m_WinListID ; 
  			}  
  			set 
  			{ 
  				m_WinListID = value ; 
  			}  
  		} 
  
  		private int m_HeadTypeID = 0; 
  		public int HeadTypeID 
  		{ 
  			get 
  			{ 
  				return m_HeadTypeID ; 
  			}  
  			set 
  			{ 
  				m_HeadTypeID = value ; 
  			}  
  		} 
  
  		private int m_SubTypeID = 0; 
  		public int SubTypeID 
  		{ 
  			get 
  			{ 
  				return m_SubTypeID ; 
  			}  
  			set 
  			{ 
  				m_SubTypeID = value ; 
  			}  
  		} 
 
		#endregion
		
		/// <summary>
        /// ��ID��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>IDΪ�ؼ���</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Data_AuthGrpWinList WHERE "+ "AuthGrpID="+SysString.ToDBString(m_AuthGrpID)+" AND WinListID="+SysString.ToDBString(m_WinListID)+" AND HeadTypeID="+SysString.ToDBString(m_HeadTypeID)+" AND SubTypeID="+SysString.ToDBString(m_SubTypeID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_AuthGrpWinList WHERE "+ "AuthGrpID="+SysString.ToDBString(m_AuthGrpID)+" AND WinListID="+SysString.ToDBString(m_WinListID)+" AND HeadTypeID="+SysString.ToDBString(m_HeadTypeID)+" AND SubTypeID="+SysString.ToDBString(m_SubTypeID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// �������SQL����ѯ������Ը�ֵ
        /// </summary>
        /// <param name="p_Sql">SQL���</param>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
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
                //��ѯ�����¼
                m_AuthGrpID=SysConvert.ToInt32(MasterTable.Rows[0]["AuthGrpID"]); 
  				m_WinListID=SysConvert.ToInt32(MasterTable.Rows[0]["WinListID"]); 
  				m_HeadTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["HeadTypeID"]); 
  				m_SubTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["SubTypeID"]); 
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
