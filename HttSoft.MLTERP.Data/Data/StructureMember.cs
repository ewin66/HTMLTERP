using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_StructureMemberʵ����
	/// ����:����ǿ
	/// ��������:2014/6/4
	/// </summary>
	public sealed class StructureMember : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public StructureMember()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public StructureMember(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "Data_StructureMember";
		 
  		private int m_StuctureID = 0; 
  		public int StuctureID 
  		{ 
  			get 
  			{ 
  				return m_StuctureID ; 
  			}  
  			set 
  			{ 
  				m_StuctureID = value ; 
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
  
  		private int m_LeaderFlag = 0; 
  		public int LeaderFlag 
  		{ 
  			get 
  			{ 
  				return m_LeaderFlag ; 
  			}  
  			set 
  			{ 
  				m_LeaderFlag = value ; 
  			}  
  		} 
  
  		private int m_LeaderAttnFlag = 0; 
  		public int LeaderAttnFlag 
  		{ 
  			get 
  			{ 
  				return m_LeaderAttnFlag ; 
  			}  
  			set 
  			{ 
  				m_LeaderAttnFlag = value ; 
  			}  
  		} 
  
  		private int m_DSort = 0; 
  		public int DSort 
  		{ 
  			get 
  			{ 
  				return m_DSort ; 
  			}  
  			set 
  			{ 
  				m_DSort = value ; 
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
            string Sql="SELECT * FROM Data_StructureMember WHERE "+ "StuctureID="+SysString.ToDBString(m_StuctureID)+" AND OPID="+SysString.ToDBString(m_OPID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_StructureMember WHERE "+ "StuctureID="+SysString.ToDBString(m_StuctureID)+" AND OPID="+SysString.ToDBString(m_OPID);
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
                m_StuctureID=SysConvert.ToInt32(MasterTable.Rows[0]["StuctureID"]); 
  				m_OPID=SysConvert.ToString(MasterTable.Rows[0]["OPID"]); 
  				m_LeaderFlag=SysConvert.ToInt32(MasterTable.Rows[0]["LeaderFlag"]); 
  				m_LeaderAttnFlag=SysConvert.ToInt32(MasterTable.Rows[0]["LeaderAttnFlag"]); 
  				m_DSort=SysConvert.ToInt32(MasterTable.Rows[0]["DSort"]); 
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
