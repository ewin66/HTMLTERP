using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_UpdateWHVendorʵ����
	/// ����:����ǿ
	/// ��������:2012/10/12
	/// </summary>
	public sealed class UpdateWHVendor : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public UpdateWHVendor()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public UpdateWHVendor(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "Data_UpdateWHVendor";
		 
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
  
  		private string m_FormNo = string.Empty ; 
  		public string FormNo 
  		{ 
  			get 
  			{ 
  				return m_FormNo ; 
  			}  
  			set 
  			{ 
  				m_FormNo = value ; 
  			}  
  		} 
  
  		private string m_OldVendor = string.Empty ; 
  		public string OldVendor 
  		{ 
  			get 
  			{ 
  				return m_OldVendor ; 
  			}  
  			set 
  			{ 
  				m_OldVendor = value ; 
  			}  
  		} 
  
  		private string m_NewVendor = string.Empty ; 
  		public string NewVendor 
  		{ 
  			get 
  			{ 
  				return m_NewVendor ; 
  			}  
  			set 
  			{ 
  				m_NewVendor = value ; 
  			}  
  		} 
  
  		private DateTime m_FormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FormDate 
  		{ 
  			get 
  			{ 
  				return m_FormDate ; 
  			}  
  			set 
  			{ 
  				m_FormDate = value ; 
  			}  
  		} 
  
  		private string m_UpdateOPName = string.Empty ; 
  		public string UpdateOPName 
  		{ 
  			get 
  			{ 
  				return m_UpdateOPName ; 
  			}  
  			set 
  			{ 
  				m_UpdateOPName = value ; 
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
            string Sql="SELECT * FROM Data_UpdateWHVendor WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_UpdateWHVendor WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_OldVendor=SysConvert.ToString(MasterTable.Rows[0]["OldVendor"]); 
  				m_NewVendor=SysConvert.ToString(MasterTable.Rows[0]["NewVendor"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_UpdateOPName=SysConvert.ToString(MasterTable.Rows[0]["UpdateOPName"]); 
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
