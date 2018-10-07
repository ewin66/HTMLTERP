using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Enum_SampleTypeʵ����
	/// ����:�˽ܿ�
	/// ��������:2009-10-26
	/// </summary>
	public sealed class SampleType : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public SampleType()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public SampleType(IDBTransAccess p_SqlCmd)
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
  
  		private string m_NameEn = string.Empty ; 
  		public string NameEn 
  		{ 
  			get 
  			{ 
  				return m_NameEn ; 
  			}  
  			set 
  			{ 
  				m_NameEn = value ; 
  			}  
  		} 
  
  		private string m_NameJP = string.Empty ; 
  		public string NameJP 
  		{ 
  			get 
  			{ 
  				return m_NameJP ; 
  			}  
  			set 
  			{ 
  				m_NameJP = value ; 
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
  
  		private string m_TecClass = string.Empty ; 
  		public string TecClass 
  		{ 
  			get 
  			{ 
  				return m_TecClass ; 
  			}  
  			set 
  			{ 
  				m_TecClass = value ; 
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
  
  		private decimal m_UnitPrice = 0; 
  		public decimal UnitPrice 
  		{ 
  			get 
  			{ 
  				return m_UnitPrice ; 
  			}  
  			set 
  			{ 
  				m_UnitPrice = value ; 
  			}  
  		} 
  
  		private decimal m_Period = 0; 
  		public decimal Period 
  		{ 
  			get 
  			{ 
  				return m_Period ; 
  			}  
  			set 
  			{ 
  				m_Period = value ; 
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
            string Sql="SELECT * FROM Enum_SampleType WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Enum_SampleType WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_NameEn=SysConvert.ToString(MasterTable.Rows[0]["NameEn"]); 
  				m_NameJP=SysConvert.ToString(MasterTable.Rows[0]["NameJP"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_TecClass=SysConvert.ToString(MasterTable.Rows[0]["TecClass"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_UnitPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["UnitPrice"]); 
  				m_Period=SysConvert.ToDecimal(MasterTable.Rows[0]["Period"]); 
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
