using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�WO_PackISNʵ����
	/// ����:Johnny
	/// ��������:2012/5/26
	/// </summary>
	public sealed class PackISN : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public PackISN()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public PackISN(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "WO_PackISN";
		 
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
  
  		private string m_PackISNS = string.Empty ; 
  		public string PackISNS 
  		{ 
  			get 
  			{ 
  				return m_PackISNS ; 
  			}  
  			set 
  			{ 
  				m_PackISNS = value ; 
  			}  
  		} 
  
  		private DateTime m_PackDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime PackDate 
  		{ 
  			get 
  			{ 
  				return m_PackDate ; 
  			}  
  			set 
  			{ 
  				m_PackDate = value ; 
  			}  
  		} 
  
  		private string m_PackOPID = string.Empty ; 
  		public string PackOPID 
  		{ 
  			get 
  			{ 
  				return m_PackOPID ; 
  			}  
  			set 
  			{ 
  				m_PackOPID = value ; 
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
  
  		private string m_ItemCode = string.Empty ; 
  		public string ItemCode 
  		{ 
  			get 
  			{ 
  				return m_ItemCode ; 
  			}  
  			set 
  			{ 
  				m_ItemCode = value ; 
  			}  
  		} 
  
  		private string m_ItemName = string.Empty ; 
  		public string ItemName 
  		{ 
  			get 
  			{ 
  				return m_ItemName ; 
  			}  
  			set 
  			{ 
  				m_ItemName = value ; 
  			}  
  		} 
  
  		private string m_ItemStd = string.Empty ; 
  		public string ItemStd 
  		{ 
  			get 
  			{ 
  				return m_ItemStd ; 
  			}  
  			set 
  			{ 
  				m_ItemStd = value ; 
  			}  
  		} 
  
  		private string m_FlowType = string.Empty ; 
  		public string FlowType 
  		{ 
  			get 
  			{ 
  				return m_FlowType ; 
  			}  
  			set 
  			{ 
  				m_FlowType = value ; 
  			}  
  		} 
  
  		private decimal m_TotalLength = 0; 
  		public decimal TotalLength 
  		{ 
  			get 
  			{ 
  				return m_TotalLength ; 
  			}  
  			set 
  			{ 
  				m_TotalLength = value ; 
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
 
		#endregion
		
		/// <summary>
        /// ��ID��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>IDΪ�ؼ���</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM WO_PackISN WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_PackISN WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_PackISNS=SysConvert.ToString(MasterTable.Rows[0]["PackISNS"]); 
  				m_PackDate=SysConvert.ToDateTime(MasterTable.Rows[0]["PackDate"]); 
  				m_PackOPID=SysConvert.ToString(MasterTable.Rows[0]["PackOPID"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_FlowType=SysConvert.ToString(MasterTable.Rows[0]["FlowType"]); 
  				m_TotalLength=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalLength"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
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
