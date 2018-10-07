using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_ReportFileModelʵ����
	/// ����:�¼Ӻ�
	/// ��������:2011-11-9
	/// </summary>
	public sealed class ReportFileModel : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ReportFileModel()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public ReportFileModel(IDBTransAccess p_SqlCmd)
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
  
  		private byte[] m_Context = new byte[1]; 
  		public byte[] Context 
  		{ 
  			get 
  			{ 
  				return m_Context ; 
  			}  
  			set 
  			{ 
  				m_Context = value ; 
  			}  
  		} 
  
  		private int m_FileID = 0; 
  		public int FileID 
  		{ 
  			get 
  			{ 
  				return m_FileID ; 
  			}  
  			set 
  			{ 
  				m_FileID = value ; 
  			}  
  		} 
  
  		private int m_FileType = 0; 
  		public int FileType 
  		{ 
  			get 
  			{ 
  				return m_FileType ; 
  			}  
  			set 
  			{ 
  				m_FileType = value ; 
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
  
  		private string m_FileName = string.Empty ; 
  		public string FileName 
  		{ 
  			get 
  			{ 
  				return m_FileName ; 
  			}  
  			set 
  			{ 
  				m_FileName = value ; 
  			}  
  		} 
  
  		private string m_FileExec = string.Empty ; 
  		public string FileExec 
  		{ 
  			get 
  			{ 
  				return m_FileExec ; 
  			}  
  			set 
  			{ 
  				m_FileExec = value ; 
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
  
  		private DateTime m_UploadTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime UploadTime 
  		{ 
  			get 
  			{ 
  				return m_UploadTime ; 
  			}  
  			set 
  			{ 
  				m_UploadTime = value ; 
  			}  
  		} 
  
  		private int m_MFlag = 0; 
  		public int MFlag 
  		{ 
  			get 
  			{ 
  				return m_MFlag ; 
  			}  
  			set 
  			{ 
  				m_MFlag = value ; 
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
            string Sql="SELECT * FROM Data_ReportFileModel WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_ReportFileModel WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				if(MasterTable.Rows[0]["Context"]!=DBNull.Value) 
  				{ 
  				 	m_Context=(byte[])(MasterTable.Rows[0]["Context"]); 
  				} 
  				m_FileID=SysConvert.ToInt32(MasterTable.Rows[0]["FileID"]); 
  				m_FileType=SysConvert.ToInt32(MasterTable.Rows[0]["FileType"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_FileName=SysConvert.ToString(MasterTable.Rows[0]["FileName"]); 
  				m_FileExec=SysConvert.ToString(MasterTable.Rows[0]["FileExec"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_UploadTime=SysConvert.ToDateTime(MasterTable.Rows[0]["UploadTime"]); 
  				m_MFlag=SysConvert.ToInt32(MasterTable.Rows[0]["MFlag"]); 
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
