using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Enum_WOFollowFieldSetʵ����
	/// ����:�ܸ���
	/// ��������:2014/8/1
	/// </summary>
	public sealed class WOFollowFieldSet : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public WOFollowFieldSet()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public WOFollowFieldSet(IDBTransAccess p_SqlCmd)
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
  
  		private int m_WOFollowTypeID = 0; 
  		public int WOFollowTypeID 
  		{ 
  			get 
  			{ 
  				return m_WOFollowTypeID ; 
  			}  
  			set 
  			{ 
  				m_WOFollowTypeID = value ; 
  			}  
  		} 
  
  		private int m_FTableType = 0; 
  		public int FTableType 
  		{ 
  			get 
  			{ 
  				return m_FTableType ; 
  			}  
  			set 
  			{ 
  				m_FTableType = value ; 
  			}  
  		} 
  
  		private int m_DFieldName = 0; 
  		public int DFieldName 
  		{ 
  			get 
  			{ 
  				return m_DFieldName ; 
  			}  
  			set 
  			{ 
  				m_DFieldName = value ; 
  			}  
  		} 
  
  		private string m_DCaption = string.Empty ; 
  		public string DCaption 
  		{ 
  			get 
  			{ 
  				return m_DCaption ; 
  			}  
  			set 
  			{ 
  				m_DCaption = value ; 
  			}  
  		} 
  
  		private int m_DShowFlag = 0; 
  		public int DShowFlag 
  		{ 
  			get 
  			{ 
  				return m_DShowFlag ; 
  			}  
  			set 
  			{ 
  				m_DShowFlag = value ; 
  			}  
  		} 
  
  		private string m_UpdateMainFieldName = string.Empty ; 
  		public string UpdateMainFieldName 
  		{ 
  			get 
  			{ 
  				return m_UpdateMainFieldName ; 
  			}  
  			set 
  			{ 
  				m_UpdateMainFieldName = value ; 
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
            string Sql="SELECT * FROM Enum_WOFollowFieldSet WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Enum_WOFollowFieldSet WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_WOFollowTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["WOFollowTypeID"]); 
  				m_FTableType=SysConvert.ToInt32(MasterTable.Rows[0]["FTableType"]); 
  				m_DFieldName=SysConvert.ToInt32(MasterTable.Rows[0]["DFieldName"]); 
  				m_DCaption=SysConvert.ToString(MasterTable.Rows[0]["DCaption"]); 
  				m_DShowFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DShowFlag"]); 
  				m_UpdateMainFieldName=SysConvert.ToString(MasterTable.Rows[0]["UpdateMainFieldName"]); 
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
