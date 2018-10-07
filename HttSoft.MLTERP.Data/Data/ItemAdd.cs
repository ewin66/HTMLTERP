using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_ItemAddʵ����
	/// ����:����ǿ
	/// ��������:2014/11/3
	/// </summary>
	public sealed class ItemAdd : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemAdd()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public ItemAdd(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "Data_ItemAdd";
		 
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
  
  		private string m_Name = string.Empty ; 
  		public string Name 
  		{ 
  			get 
  			{ 
  				return m_Name ; 
  			}  
  			set 
  			{ 
  				m_Name = value ; 
  			}  
  		} 
  
  		private string m_FiledName = string.Empty ; 
  		public string FiledName 
  		{ 
  			get 
  			{ 
  				return m_FiledName ; 
  			}  
  			set 
  			{ 
  				m_FiledName = value ; 
  			}  
  		} 
  
  		private string m_Value = string.Empty ; 
  		public string Value 
  		{ 
  			get 
  			{ 
  				return m_Value ; 
  			}  
  			set 
  			{ 
  				m_Value = value ; 
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
  
  		private int m_FiledSetID = 0; 
  		public int FiledSetID 
  		{ 
  			get 
  			{ 
  				return m_FiledSetID ; 
  			}  
  			set 
  			{ 
  				m_FiledSetID = value ; 
  			}  
  		} 
  
  		private int m_FormID = 0; 
  		public int FormID 
  		{ 
  			get 
  			{ 
  				return m_FormID ; 
  			}  
  			set 
  			{ 
  				m_FormID = value ; 
  			}  
  		} 
  
  		private int m_FormAID = 0; 
  		public int FormAID 
  		{ 
  			get 
  			{ 
  				return m_FormAID ; 
  			}  
  			set 
  			{ 
  				m_FormAID = value ; 
  			}  
  		} 
  
  		private int m_FormBID = 0; 
  		public int FormBID 
  		{ 
  			get 
  			{ 
  				return m_FormBID ; 
  			}  
  			set 
  			{ 
  				m_FormBID = value ; 
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
            string Sql="SELECT * FROM Data_ItemAdd WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_ItemAdd WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
  				m_Name=SysConvert.ToString(MasterTable.Rows[0]["Name"]); 
  				m_FiledName=SysConvert.ToString(MasterTable.Rows[0]["FiledName"]); 
  				m_Value=SysConvert.ToString(MasterTable.Rows[0]["Value"]); 
  				m_DRemark=SysConvert.ToString(MasterTable.Rows[0]["DRemark"]); 
  				m_FiledSetID=SysConvert.ToInt32(MasterTable.Rows[0]["FiledSetID"]); 
  				m_FormID=SysConvert.ToInt32(MasterTable.Rows[0]["FormID"]); 
  				m_FormAID=SysConvert.ToInt32(MasterTable.Rows[0]["FormAID"]); 
  				m_FormBID=SysConvert.ToInt32(MasterTable.Rows[0]["FormBID"]); 
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
