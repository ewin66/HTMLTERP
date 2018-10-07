using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�WH_WHʵ����
	/// ����:�¼Ӻ�
	/// ��������:2012/5/10
	/// </summary>
	public sealed class WH : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public WH()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public WH(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		 
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
        /// ��ID��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>IDΪ�ؼ���</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM WH_WH WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_WH WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
