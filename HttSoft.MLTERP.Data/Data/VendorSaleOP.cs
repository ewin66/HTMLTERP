using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_VendorSaleOPʵ����
	/// ����:qiuchao
	/// ��������:2014/8/20
	/// </summary>
	public sealed class VendorSaleOP : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public VendorSaleOP()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public VendorSaleOP(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "Data_VendorSaleOP";
		 
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
  
  		private int m_MainID = 0; 
  		public int MainID 
  		{ 
  			get 
  			{ 
  				return m_MainID ; 
  			}  
  			set 
  			{ 
  				m_MainID = value ; 
  			}  
  		} 
  
  		private int m_Seq = 0; 
  		public int Seq 
  		{ 
  			get 
  			{ 
  				return m_Seq ; 
  			}  
  			set 
  			{ 
  				m_Seq = value ; 
  			}  
  		} 
  
  		private string m_OPID = string.Empty ; 
  		public string OPID 
  		{ 
  			get 
  			{ 
  				return m_OPID ; 
  			}  
  			set 
  			{ 
  				m_OPID = value ; 
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
  
  		private DateTime m_ContactTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ContactTime 
  		{ 
  			get 
  			{ 
  				return m_ContactTime ; 
  			}  
  			set 
  			{ 
  				m_ContactTime = value ; 
  			}  
  		} 
  
  		private string m_ContactDts = string.Empty ; 
  		public string ContactDts 
  		{ 
  			get 
  			{ 
  				return m_ContactDts ; 
  			}  
  			set 
  			{ 
  				m_ContactDts = value ; 
  			}  
  		} 
  
  		private string m_DFContact = string.Empty ; 
  		public string DFContact 
  		{ 
  			get 
  			{ 
  				return m_DFContact ; 
  			}  
  			set 
  			{ 
  				m_DFContact = value ; 
  			}  
  		} 
  
  		private string m_HXTrack = string.Empty ; 
  		public string HXTrack 
  		{ 
  			get 
  			{ 
  				return m_HXTrack ; 
  			}  
  			set 
  			{ 
  				m_HXTrack = value ; 
  			}  
  		} 
  
  		private string m_FreeStr = string.Empty ; 
  		public string FreeStr 
  		{ 
  			get 
  			{ 
  				return m_FreeStr ; 
  			}  
  			set 
  			{ 
  				m_FreeStr = value ; 
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
            string Sql="SELECT * FROM Data_VendorSaleOP WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_VendorSaleOP WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_OPID=SysConvert.ToString(MasterTable.Rows[0]["OPID"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_ContactTime=SysConvert.ToDateTime(MasterTable.Rows[0]["ContactTime"]); 
  				m_ContactDts=SysConvert.ToString(MasterTable.Rows[0]["ContactDts"]); 
  				m_DFContact=SysConvert.ToString(MasterTable.Rows[0]["DFContact"]); 
  				m_HXTrack=SysConvert.ToString(MasterTable.Rows[0]["HXTrack"]); 
  				m_FreeStr=SysConvert.ToString(MasterTable.Rows[0]["FreeStr"]); 
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
