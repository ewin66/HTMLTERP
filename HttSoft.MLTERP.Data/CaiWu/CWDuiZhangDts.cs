using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�CaiWu_CWDuiZhangDtsʵ����
	/// ����:�ܸ���
	/// ��������:2011/12/27
	/// </summary>
	public sealed class CWDuiZhangDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CWDuiZhangDts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public CWDuiZhangDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		 
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
  
  		private int m_IOFormID = 0; 
  		public int IOFormID 
  		{ 
  			get 
  			{ 
  				return m_IOFormID ; 
  			}  
  			set 
  			{ 
  				m_IOFormID = value ; 
  			}  
  		} 
  
  		private int m_IOFormSeq = 0; 
  		public int IOFormSeq 
  		{ 
  			get 
  			{ 
  				return m_IOFormSeq ; 
  			}  
  			set 
  			{ 
  				m_IOFormSeq = value ; 
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
  
  		private decimal m_SinglePrice = 0; 
  		public decimal SinglePrice 
  		{ 
  			get 
  			{ 
  				return m_SinglePrice ; 
  			}  
  			set 
  			{ 
  				m_SinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_Amount = 0; 
  		public decimal Amount 
  		{ 
  			get 
  			{ 
  				return m_Amount ; 
  			}  
  			set 
  			{ 
  				m_Amount = value ; 
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
            string Sql="SELECT * FROM CaiWu_CWDuiZhangDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM CaiWu_CWDuiZhangDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
                m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_IOFormID=SysConvert.ToInt32(MasterTable.Rows[0]["IOFormID"]); 
  				m_IOFormSeq=SysConvert.ToInt32(MasterTable.Rows[0]["IOFormSeq"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_SinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SinglePrice"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
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
