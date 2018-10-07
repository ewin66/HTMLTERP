using System;
using System.Drawing;
using System.Data;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using System.Windows.Forms;

namespace MLTERP
{

	#region �ɹ����ŵ�����ɫ������
	/// <summary>
	/// �ɹ����ŵ�����ɫ������
	/// </summary>
	public class BuyDepStatusProc
	{
		private static bool m_ColorIniFlag=false;//��ɫ�Ƿ��ʼ����־
		public static bool ColorIniFlag
		{
			get
			{
				if(!m_ColorIniFlag)//���û�г�ʼ������г�ʼ����ɫ
				{
					ColorIniProc();
					m_ColorIniFlag=true;
				}
				return m_ColorIniFlag;
			}
		}

		private static int[] ColorStatusID;
		private static string[] ColorStatusName;
		private static Color[] ColorStatusColor;
		/// <summary>
		/// ��ʼ����ɫ
		/// </summary>
		private static void ColorIniProc()
		{
			string sql="SELECT ID,Name,ColorStr FROM Enum_BuyDepStatus WHERE ID<>0 ORDER BY Code";
			DataTable dt = SysUtils.Fill(sql);
			ColorStatusID = new int[dt.Rows.Count];
			ColorStatusName = new string[dt.Rows.Count];
			ColorStatusColor= new Color[dt.Rows.Count];
			for(int i=0;i<dt.Rows.Count;i++)
			{
				ColorStatusID[i]=SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
				ColorStatusName[i]=dt.Rows[i]["Name"].ToString();
				string[] tempstr=dt.Rows[i]["ColorStr"].ToString().Split(',');
				if(tempstr.Length==3)//����Ϊ3
				{
					ColorStatusColor[i]=Color.FromArgb(SysConvert.ToInt32(tempstr[0]),SysConvert.ToInt32(tempstr[1]),SysConvert.ToInt32(tempstr[2]));
				}
				else
				{
					ColorStatusColor[i]=Color.White;
				}

			}			
		}

		/// <summary>
		/// ��ʼ���ؼ���ɫ
		/// </summary>
		/// <param name="p_TxtColor"></param>
		public static void ColorIniTextBox(TextBox[] p_TxtColor)
		{
			for(int i=0;i<p_TxtColor.Length;i++)
			{
				if(ColorStatusID.Length>i)
				{
					p_TxtColor[i].Text=ColorStatusName[i];
					p_TxtColor[i].BackColor=ColorStatusColor[i];

				}
				else
				{
					p_TxtColor[i].Visible=false;
				}
			}
		}

		/// <summary>
		/// ����״̬����
		/// </summary>
		/// <param name="p_Dt">���ݱ�</param>
		public static void ProcYarnStatusName(DataTable p_Dt)
		{
			
			decimal qty;
            decimal inwhqty;
			DateTime dt1;
			DateTime dt2;
			string statusname=string.Empty;
			foreach(DataRow dr in p_Dt.Rows)
			{
                qty = SysConvert.ToDecimal(dr["Qty"]);
                inwhqty = SysConvert.ToDecimal(dr["InWHQty"]);
                dt1 = SysConvert.ToDateTime(dr["NeedDate"]);
                dt2 = SysConvert.ToDateTime(dr["InWHDate"]);


                if (inwhqty != 0 || dt2 != SystemConfiguration.DateTimeDefaultValue)//�����������
				{
                    if (inwhqty < qty)
                    {
                        statusname = ColorStatusName[3];//�������
                    }
                    else
                    {
                        statusname = ColorStatusName[4];
                    }
				}
				else
				{
					DateTime chkTime=dt1;
                    //if(dt2!=SystemConfiguration.DateTimeDefaultValue)//�лظ�����
                    //{
                    //    chkTime=dt2;
                    //}
				
					TimeSpan ts=DateTime.Now-chkTime;
					if(ts.Days>0)//�Ѿ�����
					{
						statusname = ColorStatusName[2];
					}
                    else if (ts.Days > 0 - 3)//Ԥ��
					{
						statusname = ColorStatusName[1];
					}
					else
					{
						statusname = ColorStatusName[0];
					}

                  
				}

                dr["YarnStatusName"] = statusname;
			}
		}



		/// <summary>
		/// ����״̬����Ⱦɫ��ͬ
		/// </summary>
		/// <param name="p_Dt">���ݱ�</param>
		public static void ProcColorStatusName(DataTable p_Dt)
		{

            decimal qty;
            decimal inwhqty;
            DateTime dt1;
            DateTime dt2;
            string statusname = string.Empty;
            foreach (DataRow dr in p_Dt.Rows)
            {
                qty = SysConvert.ToDecimal(dr["Qty"]);
                inwhqty = SysConvert.ToDecimal(dr["InWHQty"]);
                dt1 = SysConvert.ToDateTime(dr["NeedDate"]);
                dt2 = SysConvert.ToDateTime(dr["InWHDate"]);


                if (inwhqty != 0 || dt2 != SystemConfiguration.DateTimeDefaultValue)//�����������
                {
                    if (inwhqty < qty)
                    {
                        statusname = ColorStatusName[3];//�������
                    }
                    else
                    {
                        statusname = ColorStatusName[4];
                    }
                }
                else
                {
                    DateTime chkTime = dt1;
                    //if(dt2!=SystemConfiguration.DateTimeDefaultValue)//�лظ�����
                    //{
                    //    chkTime=dt2;
                    //}

                    TimeSpan ts = DateTime.Now - chkTime;
                    if (ts.Days > 0)//�Ѿ�����
                    {
                        statusname = ColorStatusName[2];
                    }
                    else if (ts.Days > 0 - 3)//Ԥ��
                    {
                        statusname = ColorStatusName[1];
                    }
                    else
                    {
                        statusname = ColorStatusName[0];
                    }


                }

                dr["YarnStatusName"] = statusname;
            }
		}

        /// <summary>
        /// ����״̬���Ƽӹ���
        /// </summary>
        /// <param name="p_Dt">���ݱ�</param>
        public static void ProcOthStatusName(DataTable p_Dt)
        {

            decimal qty;
            decimal inwhqty;
            DateTime dt1;
            DateTime dt2;
            string statusname = string.Empty;
            foreach (DataRow dr in p_Dt.Rows)
            {
                qty = SysConvert.ToDecimal(dr["Qty"]);
                inwhqty = SysConvert.ToDecimal(dr["InWHQty"]);
                dt1 = SysConvert.ToDateTime(dr["NeedDate"]);
                dt2 = SysConvert.ToDateTime(dr["InWHDate"]);


                if (inwhqty != 0 || dt2 != SystemConfiguration.DateTimeDefaultValue)//�����������
                {
                    if (inwhqty < qty)
                    {
                        statusname = ColorStatusName[3];//�������
                    }
                    else
                    {
                        statusname = ColorStatusName[4];
                    }
                }
                else
                {
                    DateTime chkTime = dt1;
                    //if(dt2!=SystemConfiguration.DateTimeDefaultValue)//�лظ�����
                    //{
                    //    chkTime=dt2;
                    //}

                    TimeSpan ts = DateTime.Now - chkTime;
                    if (ts.Days > 0)//�Ѿ�����
                    {
                        statusname = ColorStatusName[2];
                    }
                    else if (ts.Days > 0 - 3)//Ԥ��
                    {
                        statusname = ColorStatusName[1];
                    }
                    else
                    {
                        statusname = ColorStatusName[0];
                    }


                }

                dr["YarnStatusName"] = statusname;
            }
        }
		/// <summary>
		/// ����Grid����ɫ
		/// </summary>
		/// <param name="p_Dt1"></param>
		/// <param name="p_Dt2"></param>
		/// <param name="p_RecQty"></param>
		/// <returns></returns>
        public static Color GetGridRowBackColor(DateTime p_Dt1, DateTime p_Dt2, decimal p_InWHQty, decimal p_Qty,int p_PreDateNum)
		{
            if (p_InWHQty != 0 || p_Dt2!=SystemConfiguration.DateTimeDefaultValue)//�����������
			{
                if (p_InWHQty < p_Qty)
                {
                    return GetGridRowBackColor(4);//�������
                }
                else
                {
                    return GetGridRowBackColor(5);//ȫ�����
                }
			}
			else
			{
				DateTime chkTime=p_Dt1;
                //if(p_Dt2!=SystemConfiguration.DateTimeDefaultValue)//��Ҫ������
                //{
                //    chkTime=p_Dt2;
                //}
				
				TimeSpan ts=DateTime.Now-chkTime;
				if(ts.Days>0)//�Ѿ�����
				{
					return GetGridRowBackColor(3);
				}
                else if (ts.Days > 0 - p_PreDateNum)//Ԥ��
				{
					return GetGridRowBackColor(2);
				}

			}
			return GetGridRowBackColor(1);
		}
       
		/// <summary>
		/// ����Grid����ɫ
		/// </summary>
		/// <param name="p_Dt1"></param>
		/// <param name="p_Dt2"></param>
		/// <param name="p_RecQty"></param>
		/// <returns></returns>
		public static Color GetGridRowBackColor(string p_StatusName)
		{
			for(int i=0;i<ColorStatusName.Length;i++)
			{
				if(p_StatusName==ColorStatusName[i])
				{
					return GetGridRowBackColor(ColorStatusID[i]);
				}
			}

			return GetGridRowBackColor(1);
		}

		/// <summary>
		/// ����Grid����ɫ
		/// </summary>
		public static Color GetGridRowBackColor(int p_ColorStatusID)
		{
			int findsort=-1;
			for(int i=0;i<ColorStatusID.Length;i++)
			{
				if(ColorStatusID[i]==p_ColorStatusID)
				{
					findsort=i;
					break;
				}
			}
			if(findsort!=-1)
			{
				return ColorStatusColor[findsort];
			}
			return Color.White;
		}
	}
	#endregion

	#region ʹ�������ɫ������
	/// <summary>
	/// ʹ�������ɫ������
	/// </summary>
	public class UseStatusProc
	{
		private static bool m_ColorIniFlag=false;//��ɫ�Ƿ��ʼ����־
		public static bool ColorIniFlag
		{
			get
			{
				if(!m_ColorIniFlag)//���û�г�ʼ������г�ʼ����ɫ
				{
					ColorIniProc();
					m_ColorIniFlag=true;
				}
				return m_ColorIniFlag;
			}
		}

		private static int[] ColorStatusID;
		private static string[] ColorStatusName;
		private static Color[] ColorStatusColor;
		/// <summary>
		/// ��ʼ����ɫ
		/// </summary>
		private static void ColorIniProc()
		{
			string sql="SELECT ID,Name,ColorStr FROM Enum_UseStatus WHERE ID<>0 ORDER BY Code";
			DataTable dt = SysUtils.Fill(sql);
			ColorStatusID = new int[dt.Rows.Count];
			ColorStatusName = new string[dt.Rows.Count];
			ColorStatusColor= new Color[dt.Rows.Count];
			for(int i=0;i<dt.Rows.Count;i++)
			{
				ColorStatusID[i]=SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
				ColorStatusName[i]=dt.Rows[i]["Name"].ToString();
				string[] tempstr=dt.Rows[i]["ColorStr"].ToString().Split(',');
				if(tempstr.Length==3)//����Ϊ3
				{
					ColorStatusColor[i]=Color.FromArgb(SysConvert.ToInt32(tempstr[0]),SysConvert.ToInt32(tempstr[1]),SysConvert.ToInt32(tempstr[2]));
				}
				else
				{
					ColorStatusColor[i]=Color.White;
				}

			}			
		}

		/// <summary>
		/// ��ʼ���ؼ���ɫ
		/// </summary>
		/// <param name="p_TxtColor"></param>
		public static void ColorIniTextBox(TextBox[] p_TxtColor)
		{
			for(int i=0;i<p_TxtColor.Length;i++)
			{
				if(ColorStatusID.Length>i)
				{
					p_TxtColor[i].Text=ColorStatusName[i];
					p_TxtColor[i].BackColor=ColorStatusColor[i];

				}
				else
				{
					p_TxtColor[i].Visible=false;
				}
			}
		}

		/// <summary>
		/// ����ʹ��״̬����(ɴ�߶�����ͬ)
		/// </summary>
		/// <param name="p_Dt">���ݱ�</param>
		public static void ProcUseStatusName(DataTable p_Dt,string p_YarnFinishName,int p_MaxDayNum)
		{			
			decimal qty=0;
			decimal leaveqty=0;
			string sql=string.Empty;
			string statusname=string.Empty;
			DateTime dtInTime;
			DataTable dt;
			foreach(DataRow dr in p_Dt.Rows)
			{	
				if(p_YarnFinishName==dr["YarnStatusName"].ToString())//�Ѿ�����˲Ŵ������״̬
				{
					dtInTime=DateTime.Now.Date;
					leaveqty=0;
					qty=SysConvert.ToDecimal(dr["HaveInQty"].ToString());//�����
					sql="SELECT InDate,Qty FROM WH_Storge WHERE DtsSO="+SysString.ToDBString(dr["BuytNo"].ToString())+" AND ItemCode="+SysString.ToDBString(dr["ItemCode"].ToString());
					dt = SysUtils.Fill(sql);
					foreach(DataRow drStorge in dt.Rows)
					{
						dtInTime=SysConvert.ToDateTime(drStorge["InDate"]);
						leaveqty+=SysConvert.ToDecimal(drStorge["Qty"]);
					}

					dr["LeaveQty"]=leaveqty;

					if(leaveqty>=qty*0.1m)//���ʣ�೬��10%
					{
						if(dtInTime.AddDays(p_MaxDayNum)<=DateTime.Now.Date)//�������Ƶ�������
						{
							statusname = ColorStatusName[1];
						}
						else//��������
						{							
							statusname = ColorStatusName[0];
						}
					}
					else//״̬ ��ʹ��
					{
						statusname = ColorStatusName[2];
					}
				}
				else//����
				{					
					statusname = ColorStatusName[0];
				}
			
				dr["UseStatusName"]=statusname;
			}
		}


		/// <summary>
		/// ����ʹ��״̬����(Ⱦɫ��ͬ)
		/// </summary>
		/// <param name="p_Dt">���ݱ�</param>
		public static void ProcColorUseStatusName(DataTable p_Dt,string p_YarnFinishName,int p_MaxDayNum)
		{			
			decimal qty=0;
			decimal leaveqty=0;
			string sql=string.Empty;
			string statusname=string.Empty;
			DateTime dtInTime;
			DataTable dt;
			foreach(DataRow dr in p_Dt.Rows)
			{	
				if(p_YarnFinishName==dr["YarnStatusName"].ToString())//�Ѿ�����˲Ŵ������״̬
				{
					dtInTime=DateTime.Now.Date;
					leaveqty=0;
					qty=SysConvert.ToDecimal(dr["HaveInQty"].ToString());//�����
					sql="SELECT InDate,Qty FROM WH_Storge WHERE DtsSO="+SysString.ToDBString(dr["CompactCode"].ToString())+" AND ItemCode="+SysString.ToDBString(dr["ItemCode"].ToString());
					sql+=" AND ColorName="+SysString.ToDBString(dr["ColorName"].ToString());
					dt = SysUtils.Fill(sql);
					foreach(DataRow drStorge in dt.Rows)
					{
						dtInTime=SysConvert.ToDateTime(drStorge["InDate"]);
						leaveqty+=SysConvert.ToDecimal(drStorge["Qty"]);
					}

					dr["LeaveQty"]=leaveqty;

					if(leaveqty>=qty*0.1m)//���ʣ�೬��10%
					{
						if(dtInTime.AddDays(p_MaxDayNum)<=DateTime.Now.Date)//�������Ƶ�������
						{
							statusname = ColorStatusName[1];
						}
						else//��������
						{							
							statusname = ColorStatusName[0];
						}
					}
					else//״̬ ��ʹ��
					{
						statusname = ColorStatusName[2];
					}
				}
				else//����
				{					
					statusname = ColorStatusName[0];
				}
			
				dr["UseStatusName"]=statusname;
			}
		}


		/// <summary>
		/// ����Grid����ɫ
		/// </summary>
		/// <param name="p_Dt1"></param>
		/// <param name="p_Dt2"></param>
		/// <param name="p_RecQty"></param>
		/// <returns></returns>
		public static Color GetGridRowBackColor(string p_StatusName)
		{
			for(int i=0;i<ColorStatusName.Length;i++)
			{
				if(p_StatusName==ColorStatusName[i])
				{
					return GetGridRowBackColor(ColorStatusID[i]);
				}
			}

			return GetGridRowBackColor(1);
		}

		/// <summary>
		/// ����Grid����ɫ
		/// </summary>
		public static Color GetGridRowBackColor(int p_ColorStatusID)
		{
			int findsort=-1;
			for(int i=0;i<ColorStatusID.Length;i++)
			{
				if(ColorStatusID[i]==p_ColorStatusID)
				{
					findsort=i;
					break;
				}
			}
			if(findsort!=-1)
			{
				return ColorStatusColor[findsort];
			}
			return Color.White;
		}
	}
	#endregion

	#region ���ۺ�ͬ��ɫ������
	/// <summary>
	/// ʹ�������ɫ������
	/// </summary>
	public class VCompactStatusProc
	{
		private static bool m_ColorIniFlag=false;//��ɫ�Ƿ��ʼ����־
		public static bool ColorIniFlag
		{
			get
			{
				if(!m_ColorIniFlag)//���û�г�ʼ������г�ʼ����ɫ
				{
					ColorIniProc();
					m_ColorIniFlag=true;
				}
				return m_ColorIniFlag;
			}
		}

		private static int[] ColorStatusID;
		private static string[] ColorStatusName;
		private static Color[] ColorStatusColor;
		/// <summary>
		/// ��ʼ����ɫ
		/// </summary>
		private static void ColorIniProc()
		{
			string sql="SELECT ID,Name,ColorStr FROM Enum_VCompactStatus WHERE ID<>0 ORDER BY Code";
			DataTable dt = SysUtils.Fill(sql);
			ColorStatusID = new int[dt.Rows.Count];
			ColorStatusName = new string[dt.Rows.Count];
			ColorStatusColor= new Color[dt.Rows.Count];
			for(int i=0;i<dt.Rows.Count;i++)
			{
				ColorStatusID[i]=SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
				ColorStatusName[i]=dt.Rows[i]["Name"].ToString();
				string[] tempstr=dt.Rows[i]["ColorStr"].ToString().Split(',');
				if(tempstr.Length==3)//����Ϊ3
				{
					ColorStatusColor[i]=Color.FromArgb(SysConvert.ToInt32(tempstr[0]),SysConvert.ToInt32(tempstr[1]),SysConvert.ToInt32(tempstr[2]));
				}
				else
				{
					ColorStatusColor[i]=Color.White;
				}

			}			
		}

		/// <summary>
		/// ��ʼ���ؼ���ɫ
		/// </summary>
		/// <param name="p_TxtColor"></param>
		public static void ColorIniTextBox(TextBox[] p_TxtColor)
		{
			for(int i=0;i<p_TxtColor.Length;i++)
			{
				if(ColorStatusID.Length>i)
				{
					p_TxtColor[i].Text=ColorStatusName[i];
					p_TxtColor[i].BackColor=ColorStatusColor[i];

				}
				else
				{
					p_TxtColor[i].Visible=false;
				}
			}
		}

		/// <summary>
		/// ����ʹ��״̬����(ɴ�߶�����ͬ)
		/// </summary>
		/// <param name="p_Dt">���ݱ�</param>
		public static void ProcUseStatusName(DataTable p_Dt)
		{			
			decimal qty=0;
			decimal saleQty=0;
			string sql=string.Empty;
			string statusname=string.Empty;
			DataTable dt;
			foreach(DataRow dr in p_Dt.Rows)
			{
				saleQty=0;
				qty=SysConvert.ToDecimal(dr["Qty"].ToString());//��ͬ����
				//sql="SELECT SUM(SaleQty) SaleQty FROM UV2_Sale_SODts WHERE SubmitFlag=1 AND SOID="+SysString.ToDBString(dr["SOID"].ToString());
                sql = "SELECT SUM(Qty) SaleQty FROM UV2_Sale_SODts WHERE SubmitFlag=1 AND SOID=" + SysString.ToDBString(dr["SOID"].ToString());
				dt = SysUtils.Fill(sql);
				saleQty=SysConvert.ToDecimal(dt.Rows[0][0]);

				dr["SaleQty"]=saleQty;

				if(saleQty>=qty*0.8m)//����������80%
				{						
					statusname = ColorStatusName[1];
				}
				else//״̬ 
				{
					statusname = ColorStatusName[0];
				}
			
				dr["YarnStatusName"]=statusname;
			}
		}

		/// <summary>
		/// ����ʹ��״̬����(ɴ�߶�����ͬ)
		/// </summary>
		/// <param name="p_Dt">���ݱ�</param>
		public static void ProcUseStatusNameMore(DataTable p_Dt,Label p_lblInfo)
		{			
			decimal qty=0;
			decimal saleQty=0,saleAmount=0;
			string sql=string.Empty;
			string statusname=string.Empty;
			DataTable dt;

			int i=0;
			foreach(DataRow dr in p_Dt.Rows)
			{
				i++;
				p_lblInfo.Text="���ݴ����У����� "+p_Dt.Rows.Count.ToString()+" �����ݣ���������� " +i.ToString()+" ��";
				Application.DoEvents();
				saleQty=0;
				qty=SysConvert.ToDecimal(dr["Qty"].ToString());//��ͬ����
				//sql="SELECT SUM(SaleQty) SaleQty FROM UV2_Sale_SODts WHERE SubmitFlag=1 AND SOID="+SysString.ToDBString(dr["SOID"].ToString());
				//CaiwuType 1/2/3:����/�ɹ�/�ӹ�
				sql="SELECT SUM(CASE DZFlag WHEN 2 THEN 0-Qty ELSE Qty END) Qty,SUM(CASE DZFlag WHEN 2 THEN 0-Amount ELSE Amount END) Amount FROM UV1_WH_IOFormDts ";
				sql += "WHERE ConfirmFlag=1 AND CaiwuFlag=1";				
				sql+=" AND CaiwuType=1 AND DtsSO="+SysString.ToDBString(dr["SOID"].ToString());

				dt = SysUtils.Fill(sql);
				saleQty=SysConvert.ToDecimal(dt.Rows[0]["Qty"]);
				saleAmount=SysConvert.ToDecimal(dt.Rows[0]["Amount"]);//���۽��

				//�ɹ����

				dr["SaleQty"]=saleQty;
				dr["SaleAmount"]=saleAmount;

				dt=SysUtils.Fill("EXEC USP1_GetSaleCost "+SysString.ToDBString(dr["SOID"].ToString())+","+SysString.ToDBString(dr["CompactNo"].ToString())+","+SysString.ToDBString(dr["ItemCode"].ToString()));
				
				dr["BuyQty"]=SysConvert.ToDecimal(dt.Rows[0]["BuyQty"]);
				dr["BuyAmount"]=SysConvert.ToDecimal(dt.Rows[0]["BuyAmount"]);
				dr["MatchQty"]=SysConvert.ToDecimal(dt.Rows[0]["JgQty"]);
				dr["MatchAmount"]=SysConvert.ToDecimal(dt.Rows[0]["JgAmount"]);
				dr["WHQty"]=SysConvert.ToDecimal(dt.Rows[0]["WHQty"]);
				dr["WHAmount"]=SysConvert.ToDecimal(dt.Rows[0]["WHAmount"]);
				dr["UseQty"]=SysConvert.ToDecimal(dt.Rows[0]["UseQty"]);
				dr["UseAmount"]=SysConvert.ToDecimal(dt.Rows[0]["UseAmount"]);
				dr["ProfitAmount"]= saleAmount-SysConvert.ToDecimal(dt.Rows[0]["WHAmount"])-SysConvert.ToDecimal(dt.Rows[0]["JgAmount"])-SysConvert.ToDecimal(dt.Rows[0]["UseAmount"]);
				if(saleAmount!=0)
				{
					dr["ProfitPer"]= SysConvert.ToDecimal( 100*SysConvert.ToDecimal(dr["ProfitAmount"])/saleAmount,1);
				}
				

				if(saleQty>=qty*0.8m)//����������80%
				{						
					statusname = ColorStatusName[1];
				}
				else//״̬ 
				{
					statusname = ColorStatusName[0];
				}
			
				dr["YarnStatusName"]=statusname;
			}
			p_lblInfo.Text="�������";
		}

		/// <summary>
		/// ����Grid����ɫ
		/// </summary>
		/// <param name="p_Dt1"></param>
		/// <param name="p_Dt2"></param>
		/// <param name="p_RecQty"></param>
		/// <returns></returns>
		public static Color GetGridRowBackColor(string p_StatusName)
		{
			for(int i=0;i<ColorStatusName.Length;i++)
			{
				if(p_StatusName==ColorStatusName[i])
				{
					return GetGridRowBackColor(ColorStatusID[i]);
				}
			}

			return GetGridRowBackColor(1);
		}

		/// <summary>
		/// ����Grid����ɫ
		/// </summary>
		public static Color GetGridRowBackColor(int p_ColorStatusID)
		{
			int findsort=-1;
			for(int i=0;i<ColorStatusID.Length;i++)
			{
				if(ColorStatusID[i]==p_ColorStatusID)
				{
					findsort=i;
					break;
				}
			}
			if(findsort!=-1)
			{
				return ColorStatusColor[findsort];
			}
			return Color.White;
		}
	}
	#endregion

}
