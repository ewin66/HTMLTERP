using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�ADH_CheckFormʵ����
	/// ����:����ǿ
	/// ��������:2012/10/29
	/// </summary>
	public sealed class CheckForm : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CheckForm()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public CheckForm(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "ADH_CheckForm";
		 
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
  
  		private string m_FormCode = string.Empty ; 
  		public string FormCode 
  		{ 
  			get 
  			{ 
  				return m_FormCode ; 
  			}  
  			set 
  			{ 
  				m_FormCode = value ; 
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
  
  		private int m_DataDHID = 0; 
  		public int DataDHID 
  		{ 
  			get 
  			{ 
  				return m_DataDHID ; 
  			}  
  			set 
  			{ 
  				m_DataDHID = value ; 
  			}  
  		} 
  
  		private string m_DVendorID = string.Empty ; 
  		public string DVendorID 
  		{ 
  			get 
  			{ 
  				return m_DVendorID ; 
  			}  
  			set 
  			{ 
  				m_DVendorID = value ; 
  			}  
  		} 
  
  		private string m_DRemark = string.Empty ; 
  		public string DRemark 
  		{ 
  			get 
  			{ 
  				return m_DRemark ; 
  			}  
  			set 
  			{ 
  				m_DRemark = value ; 
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
  
  		private DateTime m_AddTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime AddTime 
  		{ 
  			get 
  			{ 
  				return m_AddTime ; 
  			}  
  			set 
  			{ 
  				m_AddTime = value ; 
  			}  
  		} 
  
  		private DateTime m_UpdTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime UpdTime 
  		{ 
  			get 
  			{ 
  				return m_UpdTime ; 
  			}  
  			set 
  			{ 
  				m_UpdTime = value ; 
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
  
  		private string m_BJHB = string.Empty ; 
  		public string BJHB 
  		{ 
  			get 
  			{ 
  				return m_BJHB ; 
  			}  
  			set 
  			{ 
  				m_BJHB = value ; 
  			}  
  		} 
  
  		private decimal m_BJHL = 0; 
  		public decimal BJHL 
  		{ 
  			get 
  			{ 
  				return m_BJHL ; 
  			}  
  			set 
  			{ 
  				m_BJHL = value ; 
  			}  
  		} 
  
  		private string m_Width = string.Empty ; 
  		public string Width 
  		{ 
  			get 
  			{ 
  				return m_Width ; 
  			}  
  			set 
  			{ 
  				m_Width = value ; 
  			}  
  		} 
  
  		private string m_Weight = string.Empty ; 
  		public string Weight 
  		{ 
  			get 
  			{ 
  				return m_Weight ; 
  			}  
  			set 
  			{ 
  				m_Weight = value ; 
  			}  
  		} 
  
  		private int m_FormTypeID = 0; 
  		public int FormTypeID 
  		{ 
  			get 
  			{ 
  				return m_FormTypeID ; 
  			}  
  			set 
  			{ 
  				m_FormTypeID = value ; 
  			}  
  		} 
  
  		private string m_ConOPName = string.Empty ; 
  		public string ConOPName 
  		{ 
  			get 
  			{ 
  				return m_ConOPName ; 
  			}  
  			set 
  			{ 
  				m_ConOPName = value ; 
  			}  
  		} 
  
  		private string m_Tel = string.Empty ; 
  		public string Tel 
  		{ 
  			get 
  			{ 
  				return m_Tel ; 
  			}  
  			set 
  			{ 
  				m_Tel = value ; 
  			}  
  		} 
  
  		private string m_Address = string.Empty ; 
  		public string Address 
  		{ 
  			get 
  			{ 
  				return m_Address ; 
  			}  
  			set 
  			{ 
  				m_Address = value ; 
  			}  
  		} 
  
  		private string m_DVendorName = string.Empty ; 
  		public string DVendorName 
  		{ 
  			get 
  			{ 
  				return m_DVendorName ; 
  			}  
  			set 
  			{ 
  				m_DVendorName = value ; 
  			}  
  		} 
  
  		private int m_DYFlag = 0; 
  		public int DYFlag 
  		{ 
  			get 
  			{ 
  				return m_DYFlag ; 
  			}  
  			set 
  			{ 
  				m_DYFlag = value ; 
  			}  
  		} 
  
  		private int m_LevelID = 0; 
  		public int LevelID 
  		{ 
  			get 
  			{ 
  				return m_LevelID ; 
  			}  
  			set 
  			{ 
  				m_LevelID = value ; 
  			}  
  		} 
  
  		private string m_SaleOPID = string.Empty ; 
  		public string SaleOPID 
  		{ 
  			get 
  			{ 
  				return m_SaleOPID ; 
  			}  
  			set 
  			{ 
  				m_SaleOPID = value ; 
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
            string Sql="SELECT * FROM ADH_CheckForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM ADH_CheckForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FormCode=SysConvert.ToString(MasterTable.Rows[0]["FormCode"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_DataDHID=SysConvert.ToInt32(MasterTable.Rows[0]["DataDHID"]); 
  				m_DVendorID=SysConvert.ToString(MasterTable.Rows[0]["DVendorID"]); 
  				m_DRemark=SysConvert.ToString(MasterTable.Rows[0]["DRemark"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_AddTime=SysConvert.ToDateTime(MasterTable.Rows[0]["AddTime"]); 
  				m_UpdTime=SysConvert.ToDateTime(MasterTable.Rows[0]["UpdTime"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_BJHB=SysConvert.ToString(MasterTable.Rows[0]["BJHB"]); 
  				m_BJHL=SysConvert.ToDecimal(MasterTable.Rows[0]["BJHL"]); 
  				m_Width=SysConvert.ToString(MasterTable.Rows[0]["Width"]); 
  				m_Weight=SysConvert.ToString(MasterTable.Rows[0]["Weight"]); 
  				m_FormTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["FormTypeID"]); 
  				m_ConOPName=SysConvert.ToString(MasterTable.Rows[0]["ConOPName"]); 
  				m_Tel=SysConvert.ToString(MasterTable.Rows[0]["Tel"]); 
  				m_Address=SysConvert.ToString(MasterTable.Rows[0]["Address"]); 
  				m_DVendorName=SysConvert.ToString(MasterTable.Rows[0]["DVendorName"]); 
  				m_DYFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DYFlag"]); 
  				m_LevelID=SysConvert.ToInt32(MasterTable.Rows[0]["LevelID"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
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
