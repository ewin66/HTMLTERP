using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_ItemGYFlowItemDtsʵ����
	/// ����:�¼Ӻ�
	/// ��������:2014/6/20
	/// </summary>
	public sealed class ItemGYFlowItemDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemGYFlowItemDts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public ItemGYFlowItemDts(IDBTransAccess p_SqlCmd)
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
  
  		private int m_TopID = 0; 
  		public int TopID 
  		{ 
  			get 
  			{ 
  				return m_TopID ; 
  			}  
  			set 
  			{ 
  				m_TopID = value ; 
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
  
  		private string m_GYItemName = string.Empty ; 
  		public string GYItemName 
  		{ 
  			get 
  			{ 
  				return m_GYItemName ; 
  			}  
  			set 
  			{ 
  				m_GYItemName = value ; 
  			}  
  		} 
  
  		private string m_GYItemValue = string.Empty ; 
  		public string GYItemValue 
  		{ 
  			get 
  			{ 
  				return m_GYItemValue ; 
  			}  
  			set 
  			{ 
  				m_GYItemValue = value ; 
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
            string Sql="SELECT * FROM Data_ItemGYFlowItemDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_ItemGYFlowItemDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_TopID=SysConvert.ToInt32(MasterTable.Rows[0]["TopID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_GYItemName=SysConvert.ToString(MasterTable.Rows[0]["GYItemName"]); 
  				m_GYItemValue=SysConvert.ToString(MasterTable.Rows[0]["GYItemValue"]); 
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
