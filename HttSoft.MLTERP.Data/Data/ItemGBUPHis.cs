using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_ItemGBUPHisʵ����
	/// ����:����ǿ
	/// ��������:2012-5-31
	/// </summary>
	public sealed class ItemGBUPHis : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemGBUPHis()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public ItemGBUPHis(IDBTransAccess p_SqlCmd)
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
  
  		private string m_GBCode = string.Empty ; 
  		public string GBCode 
  		{ 
  			get 
  			{ 
  				return m_GBCode ; 
  			}  
  			set 
  			{ 
  				m_GBCode = value ; 
  			}  
  		} 
  
  		private int m_GBStatusIDS = 0; 
  		public int GBStatusIDS 
  		{ 
  			get 
  			{ 
  				return m_GBStatusIDS ; 
  			}  
  			set 
  			{ 
  				m_GBStatusIDS = value ; 
  			}  
  		} 
  
  		private int m_GBStatusIDE = 0; 
  		public int GBStatusIDE 
  		{ 
  			get 
  			{ 
  				return m_GBStatusIDE ; 
  			}  
  			set 
  			{ 
  				m_GBStatusIDE = value ; 
  			}  
  		} 
  
  		private DateTime m_GDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime GDate 
  		{ 
  			get 
  			{ 
  				return m_GDate ; 
  			}  
  			set 
  			{ 
  				m_GDate = value ; 
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
  
  		private string m_UpOPID = string.Empty ; 
  		public string UpOPID 
  		{ 
  			get 
  			{ 
  				return m_UpOPID ; 
  			}  
  			set 
  			{ 
  				m_UpOPID = value ; 
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
            string Sql="SELECT * FROM Data_ItemGBUPHis WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_ItemGBUPHis WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_GBCode=SysConvert.ToString(MasterTable.Rows[0]["GBCode"]); 
  				m_GBStatusIDS=SysConvert.ToInt32(MasterTable.Rows[0]["GBStatusIDS"]); 
  				m_GBStatusIDE=SysConvert.ToInt32(MasterTable.Rows[0]["GBStatusIDE"]); 
  				m_GDate=SysConvert.ToDateTime(MasterTable.Rows[0]["GDate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_UpOPID=SysConvert.ToString(MasterTable.Rows[0]["UpOPID"]); 
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
