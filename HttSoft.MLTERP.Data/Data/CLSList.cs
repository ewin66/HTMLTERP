using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_CLSListʵ����
	/// ����:LookSun
	/// ��������:2009-4-1
	/// </summary>
	public sealed class CLSList : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CLSList()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public CLSList(IDBTransAccess p_SqlCmd)
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
  
  		private string m_CLSA = string.Empty ; 
  		public string CLSA 
  		{ 
  			get 
  			{ 
  				return m_CLSA ; 
  			}  
  			set 
  			{ 
  				m_CLSA = value ; 
  			}  
  		} 
  
  		private string m_CLSB = string.Empty ; 
  		public string CLSB 
  		{ 
  			get 
  			{ 
  				return m_CLSB ; 
  			}  
  			set 
  			{ 
  				m_CLSB = value ; 
  			}  
  		} 
  
  		private string m_CLSDESC = string.Empty ; 
  		public string CLSDESC 
  		{ 
  			get 
  			{ 
  				return m_CLSDESC ; 
  			}  
  			set 
  			{ 
  				m_CLSDESC = value ; 
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
 
		#endregion
		
		/// <summary>
        /// ��ID��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>IDΪ�ؼ���</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Data_CLSList WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_CLSList WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_CLSA=SysConvert.ToString(MasterTable.Rows[0]["CLSA"]); 
  				m_CLSB=SysConvert.ToString(MasterTable.Rows[0]["CLSB"]); 
  				m_CLSDESC=SysConvert.ToString(MasterTable.Rows[0]["CLSDESC"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
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
