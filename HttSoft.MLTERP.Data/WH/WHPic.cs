using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�WH_WHPicʵ����
	/// ����:�ܸ���
	/// ��������:2009-7-18
	/// </summary>
	public sealed class WHPic : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public WHPic()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public WHPic(IDBTransAccess p_SqlCmd)
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
  
  		private string m_WHID = string.Empty ; 
  		public string WHID 
  		{ 
  			get 
  			{ 
  				return m_WHID ; 
  			}  
  			set 
  			{ 
  				m_WHID = value ; 
  			}  
  		} 
  
  		private string m_WHPicID = string.Empty ; 
  		public string WHPicID 
  		{ 
  			get 
  			{ 
  				return m_WHPicID ; 
  			}  
  			set 
  			{ 
  				m_WHPicID = value ; 
  			}  
  		} 
  
  		private int m_PosX = 0; 
  		public int PosX 
  		{ 
  			get 
  			{ 
  				return m_PosX ; 
  			}  
  			set 
  			{ 
  				m_PosX = value ; 
  			}  
  		} 
  
  		private int m_PosY = 0; 
  		public int PosY 
  		{ 
  			get 
  			{ 
  				return m_PosY ; 
  			}  
  			set 
  			{ 
  				m_PosY = value ; 
  			}  
  		} 
  
  		private int m_SizeWidth = 0; 
  		public int SizeWidth 
  		{ 
  			get 
  			{ 
  				return m_SizeWidth ; 
  			}  
  			set 
  			{ 
  				m_SizeWidth = value ; 
  			}  
  		} 
  
  		private int m_SizeHeight = 0; 
  		public int SizeHeight 
  		{ 
  			get 
  			{ 
  				return m_SizeHeight ; 
  			}  
  			set 
  			{ 
  				m_SizeHeight = value ; 
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
            string Sql="SELECT * FROM WH_WHPic WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND WHPicID="+SysString.ToDBString(m_WHPicID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_WHPic WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND WHPicID="+SysString.ToDBString(m_WHPicID);
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
  				m_WHID=SysConvert.ToString(MasterTable.Rows[0]["WHID"]); 
  				m_WHPicID=SysConvert.ToString(MasterTable.Rows[0]["WHPicID"]); 
  				m_PosX=SysConvert.ToInt32(MasterTable.Rows[0]["PosX"]); 
  				m_PosY=SysConvert.ToInt32(MasterTable.Rows[0]["PosY"]); 
  				m_SizeWidth=SysConvert.ToInt32(MasterTable.Rows[0]["SizeWidth"]); 
  				m_SizeHeight=SysConvert.ToInt32(MasterTable.Rows[0]["SizeHeight"]); 
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
