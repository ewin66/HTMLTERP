using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Buy_ItemBuyFollowDtsʵ����
	/// ����:������
	/// ��������:2012/5/3
	/// </summary>
	public sealed class ItemBuyFollowDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemBuyFollowDts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public ItemBuyFollowDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "Buy_ItemBuyFollowDts";
		 
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

        private int m_DLoadDtsID = 0;

        public int DLoadDtsID
        {
            get { return m_DLoadDtsID; }
            set { m_DLoadDtsID = value; }
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
  
  		private int m_ProcStepID = 0; 
  		public int ProcStepID 
  		{ 
  			get 
  			{ 
  				return m_ProcStepID ; 
  			}  
  			set 
  			{ 
  				m_ProcStepID = value ; 
  			}  
  		} 
  
  		private string m_CheckItem = string.Empty ; 
  		public string CheckItem 
  		{ 
  			get 
  			{ 
  				return m_CheckItem ; 
  			}  
  			set 
  			{ 
  				m_CheckItem = value ; 
  			}  
  		} 
  
  		private DateTime m_FinishTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FinishTime 
  		{ 
  			get 
  			{ 
  				return m_FinishTime ; 
  			}  
  			set 
  			{ 
  				m_FinishTime = value ; 
  			}  
  		} 
  
  		private DateTime m_FactTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FactTime 
  		{ 
  			get 
  			{ 
  				return m_FactTime ; 
  			}  
  			set 
  			{ 
  				m_FactTime = value ; 
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
            string Sql="SELECT * FROM Buy_ItemBuyFollowDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Buy_ItemBuyFollowDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
                m_DLoadDtsID = SysConvert.ToInt32(MasterTable.Rows[0]["DLoadDtsID"]);
  				m_ProcStepID=SysConvert.ToInt32(MasterTable.Rows[0]["ProcStepID"]); 
  				m_CheckItem=SysConvert.ToString(MasterTable.Rows[0]["CheckItem"]); 
  				m_FinishTime=SysConvert.ToDateTime(MasterTable.Rows[0]["FinishTime"]); 
  				m_FactTime=SysConvert.ToDateTime(MasterTable.Rows[0]["FactTime"]); 
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
