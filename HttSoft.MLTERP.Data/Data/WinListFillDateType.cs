using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_WinListFillDateTypeʵ����
	/// ����:�¼Ӻ�
	/// ��������:2012/5/22
	/// </summary>
	public sealed class WinListFillDateType : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public WinListFillDateType()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public WinListFillDateType(IDBTransAccess p_SqlCmd)
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
  
  		private string m_Code = string.Empty ; 
  		public string Code 
  		{ 
  			get 
  			{ 
  				return m_Code ; 
  			}  
  			set 
  			{ 
  				m_Code = value ; 
  			}  
  		} 
  
  		private int m_WinListID = 0; 
  		public int WinListID 
  		{ 
  			get 
  			{ 
  				return m_WinListID ; 
  			}  
  			set 
  			{ 
  				m_WinListID = value ; 
  			}  
  		} 
  
  		private int m_HeadTypeID = 0; 
  		public int HeadTypeID 
  		{ 
  			get 
  			{ 
  				return m_HeadTypeID ; 
  			}  
  			set 
  			{ 
  				m_HeadTypeID = value ; 
  			}  
  		} 
  
  		private int m_SubTypeID = 0; 
  		public int SubTypeID 
  		{ 
  			get 
  			{ 
  				return m_SubTypeID ; 
  			}  
  			set 
  			{ 
  				m_SubTypeID = value ; 
  			}  
  		} 
  
  		private int m_FillDataTypeID = 0; 
  		public int FillDataTypeID 
  		{ 
  			get 
  			{ 
  				return m_FillDataTypeID ; 
  			}  
  			set 
  			{ 
  				m_FillDataTypeID = value ; 
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
            string Sql="SELECT * FROM Data_WinListFillDateType WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_WinListFillDateType WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_WinListID=SysConvert.ToInt32(MasterTable.Rows[0]["WinListID"]); 
  				m_HeadTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["HeadTypeID"]); 
  				m_SubTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["SubTypeID"]); 
  				m_FillDataTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["FillDataTypeID"]); 
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
