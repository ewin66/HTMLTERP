using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_OPAuthGrpʵ����
	/// ����:�ܸ���
	/// ��������:2009-7-16
	/// </summary>
	public sealed class OPAuthGrp : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public OPAuthGrp()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public OPAuthGrp(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		 
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
  
  		private int m_AuthGrpID = 0; 
  		public int AuthGrpID 
  		{ 
  			get 
  			{ 
  				return m_AuthGrpID ; 
  			}  
  			set 
  			{ 
  				m_AuthGrpID = value ; 
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
            string Sql="SELECT * FROM Data_OPAuthGrp WHERE "+ "OPID="+SysString.ToDBString(m_OPID)+" AND AuthGrpID="+SysString.ToDBString(m_AuthGrpID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_OPAuthGrp WHERE "+ "OPID="+SysString.ToDBString(m_OPID)+" AND AuthGrpID="+SysString.ToDBString(m_AuthGrpID);
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
                m_OPID=SysConvert.ToString(MasterTable.Rows[0]["OPID"]); 
  				m_AuthGrpID=SysConvert.ToInt32(MasterTable.Rows[0]["AuthGrpID"]); 
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
