using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_CLSʵ����
	/// ����:�¼Ӻ�
	/// ��������:2011-11-4
	/// </summary>
	public sealed class CLS : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CLS()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public CLS(IDBTransAccess p_SqlCmd)
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
  
  		private string m_CLSIDC = string.Empty ; 
  		public string CLSIDC 
  		{ 
  			get 
  			{ 
  				return m_CLSIDC ; 
  			}  
  			set 
  			{ 
  				m_CLSIDC = value ; 
  			}  
  		} 
  
  		private string m_CLSNM = string.Empty ; 
  		public string CLSNM 
  		{ 
  			get 
  			{ 
  				return m_CLSNM ; 
  			}  
  			set 
  			{ 
  				m_CLSNM = value ; 
  			}  
  		} 
  
  		private int m_CLSListID = 0; 
  		public int CLSListID 
  		{ 
  			get 
  			{ 
  				return m_CLSListID ; 
  			}  
  			set 
  			{ 
  				m_CLSListID = value ; 
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
 
		#endregion
		
		/// <summary>
        /// ��ID��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>IDΪ�ؼ���</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Data_CLS WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_CLS WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_CLSIDC=SysConvert.ToString(MasterTable.Rows[0]["CLSIDC"]); 
  				m_CLSNM=SysConvert.ToString(MasterTable.Rows[0]["CLSNM"]); 
  				m_CLSListID=SysConvert.ToInt32(MasterTable.Rows[0]["CLSListID"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
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
