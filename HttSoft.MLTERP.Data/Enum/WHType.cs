using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Enum_WHTypeʵ����
	/// ����:������
	/// ��������:2012/4/23
	/// </summary>
	public sealed class WHType : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public WHType()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public WHType(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "Enum_WHType";
		 
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
  
  		private int m_WHPosMethodID = 0; 
  		public int WHPosMethodID 
  		{ 
  			get 
  			{ 
  				return m_WHPosMethodID ; 
  			}  
  			set 
  			{ 
  				m_WHPosMethodID = value ; 
  			}  
  		} 
  
  		private int m_ItemTypeID = 0; 
  		public int ItemTypeID 
  		{ 
  			get 
  			{ 
  				return m_ItemTypeID ; 
  			}  
  			set 
  			{ 
  				m_ItemTypeID = value ; 
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
  
  		private decimal m_Tax = 0; 
  		public decimal Tax 
  		{ 
  			get 
  			{ 
  				return m_Tax ; 
  			}  
  			set 
  			{ 
  				m_Tax = value ; 
  			}  
  		} 
  
  		private int m_ItemTypeID2 = 0; 
  		public int ItemTypeID2 
  		{ 
  			get 
  			{ 
  				return m_ItemTypeID2 ; 
  			}  
  			set 
  			{ 
  				m_ItemTypeID2 = value ; 
  			}  
  		} 
  
  		private int m_ItemTypeID3 = 0; 
  		public int ItemTypeID3 
  		{ 
  			get 
  			{ 
  				return m_ItemTypeID3 ; 
  			}  
  			set 
  			{ 
  				m_ItemTypeID3 = value ; 
  			}  
  		} 
  
  		private int m_ItemTypeID4 = 0; 
  		public int ItemTypeID4 
  		{ 
  			get 
  			{ 
  				return m_ItemTypeID4 ; 
  			}  
  			set 
  			{ 
  				m_ItemTypeID4 = value ; 
  			}  
  		} 
  
  		private int m_ItemTypeID5 = 0; 
  		public int ItemTypeID5 
  		{ 
  			get 
  			{ 
  				return m_ItemTypeID5 ; 
  			}  
  			set 
  			{ 
  				m_ItemTypeID5 = value ; 
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
            string Sql="SELECT * FROM Enum_WHType WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Enum_WHType WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Name=SysConvert.ToString(MasterTable.Rows[0]["Name"]); 
  				m_WHPosMethodID=SysConvert.ToInt32(MasterTable.Rows[0]["WHPosMethodID"]); 
  				m_ItemTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["ItemTypeID"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_Tax=SysConvert.ToDecimal(MasterTable.Rows[0]["Tax"]); 
  				m_ItemTypeID2=SysConvert.ToInt32(MasterTable.Rows[0]["ItemTypeID2"]); 
  				m_ItemTypeID3=SysConvert.ToInt32(MasterTable.Rows[0]["ItemTypeID3"]); 
  				m_ItemTypeID4=SysConvert.ToInt32(MasterTable.Rows[0]["ItemTypeID4"]); 
  				m_ItemTypeID5=SysConvert.ToInt32(MasterTable.Rows[0]["ItemTypeID5"]); 
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
