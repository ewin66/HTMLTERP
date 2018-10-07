using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_FormNCVendorʵ����
	/// ����:�¼Ӻ�
	/// ��������:2012-4-17
	/// </summary>
	public sealed class FormNCVendor : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public FormNCVendor()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public FormNCVendor(IDBTransAccess p_SqlCmd)
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
  
  		private string m_VendorID = string.Empty ; 
  		public string VendorID 
  		{ 
  			get 
  			{ 
  				return m_VendorID ; 
  			}  
  			set 
  			{ 
  				m_VendorID = value ; 
  			}  
  		} 
  
  		private int m_FNCVID = 0; 
  		public int FNCVID 
  		{ 
  			get 
  			{ 
  				return m_FNCVID ; 
  			}  
  			set 
  			{ 
  				m_FNCVID = value ; 
  			}  
  		} 
  
  		private int m_CurSort = 0; 
  		public int CurSort 
  		{ 
  			get 
  			{ 
  				return m_CurSort ; 
  			}  
  			set 
  			{ 
  				m_CurSort = value ; 
  			}  
  		} 
  
  		private int m_CurYear = 0; 
  		public int CurYear 
  		{ 
  			get 
  			{ 
  				return m_CurYear ; 
  			}  
  			set 
  			{ 
  				m_CurYear = value ; 
  			}  
  		} 
  
  		private int m_CurMonth = 0; 
  		public int CurMonth 
  		{ 
  			get 
  			{ 
  				return m_CurMonth ; 
  			}  
  			set 
  			{ 
  				m_CurMonth = value ; 
  			}  
  		} 
  
  		private int m_CurDay = 0; 
  		public int CurDay 
  		{ 
  			get 
  			{ 
  				return m_CurDay ; 
  			}  
  			set 
  			{ 
  				m_CurDay = value ; 
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
            string Sql="SELECT * FROM Data_FormNCVendor WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_FormNCVendor WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_FNCVID=SysConvert.ToInt32(MasterTable.Rows[0]["FNCVID"]); 
  				m_CurSort=SysConvert.ToInt32(MasterTable.Rows[0]["CurSort"]); 
  				m_CurYear=SysConvert.ToInt32(MasterTable.Rows[0]["CurYear"]); 
  				m_CurMonth=SysConvert.ToInt32(MasterTable.Rows[0]["CurMonth"]); 
  				m_CurDay=SysConvert.ToInt32(MasterTable.Rows[0]["CurDay"]); 
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
