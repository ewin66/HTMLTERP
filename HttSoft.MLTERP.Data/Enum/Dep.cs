using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_Depʵ����
	/// ����:�¼Ӻ�
	/// ��������:2014/6/6
	/// </summary>
	public sealed class Dep : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Dep()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public Dep(IDBTransAccess p_SqlCmd)
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
  
  		private int m_StructureID = 0; 
  		public int StructureID 
  		{ 
  			get 
  			{ 
  				return m_StructureID ; 
  			}  
  			set 
  			{ 
  				m_StructureID = value ; 
  			}  
  		} 
  
  		private int m_IncludeSubStructureFlag = 0; 
  		public int IncludeSubStructureFlag 
  		{ 
  			get 
  			{ 
  				return m_IncludeSubStructureFlag ; 
  			}  
  			set 
  			{ 
  				m_IncludeSubStructureFlag = value ; 
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
            string Sql="SELECT * FROM Data_Dep WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_Dep WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Name=SysConvert.ToString(MasterTable.Rows[0]["Name"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_StructureID=SysConvert.ToInt32(MasterTable.Rows[0]["StructureID"]); 
  				m_IncludeSubStructureFlag=SysConvert.ToInt32(MasterTable.Rows[0]["IncludeSubStructureFlag"]); 
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
