using System;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.MLTERP.Sys;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data;
using System.Windows.Forms;
using System.Data;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace MLTERP
{
	public delegate void ProcFoSizeSetGridSort();// 定义委托处理程序


    #region 处理尺码
    /// <summary>
	/// 处理尺码
	/// </summary>
	public class ProcFOSize:BaseForm
	{
		
		LookUpEdit m_DrpSizeNum;
		Label[] m_LblSizeNmA;
		ComboBoxEdit[] m_DrpSizeNmA;
		GridView m_View;
		string[] m_FieldNameA;

        public ProcFOSize(LookUpEdit p_DrpSizeNum, Label[] p_LblSizeNmA, ComboBoxEdit[] p_DrpSizeNmA, GridView p_View, string[] p_FieldNameA, 
            string p_TableName, string p_FieldName, bool p_ShowBlank)
		{
            ClassIni(p_DrpSizeNum, p_LblSizeNmA, p_DrpSizeNmA, p_View, p_FieldNameA, p_TableName, p_FieldName, p_ShowBlank);
		}

		/// <summary>
		/// 类初始化
		/// </summary>
        private void ClassIni(LookUpEdit p_DrpSizeNum, Label[] p_LblSizeNmA, ComboBoxEdit[] p_DrpSizeNmA, GridView p_View, string[] p_FieldNameA, 
            string p_TableName, string p_FieldName, bool p_ShowBlank)
		{
			m_DrpSizeNum=p_DrpSizeNum;
			m_LblSizeNmA=p_LblSizeNmA;
			m_DrpSizeNmA=p_DrpSizeNmA;
			m_FieldNameA=p_FieldNameA;
			m_View=p_View;			
			p_DrpSizeNum.EditValueChanged+=new System.EventHandler(drpEditValueChanged);

			
			Common.BindSizeNum(m_DrpSizeNum,"SOType",true);
			for(int i=0;i<12;i++)
			{

                m_DrpSizeNmA[i].Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;

				m_DrpSizeNmA[i].EditValueChanged+= new System.EventHandler(drpSizeName_EditValueChanged);
                Common.BindCLS(m_DrpSizeNmA[i], p_TableName, p_FieldName, p_ShowBlank);

				p_View.Columns["Qty"+(i+1).ToString()].Caption="";
			
			}

			drpEditValueChanged(null,null);
			
		}

		/// <summary>
		/// 设置改变
		/// </summary>
		/// <param name="p_SO"></param>
		public void SetSizeNameBySO(string p_SO)
		{
			string sql="SELECT SizeNumID,SizeName1,SizeName2,SizeName3,SizeName4,SizeName5,SizeName6";
			sql+=",SizeName7,SizeName8,SizeName9,SizeName10,SizeName11,SizeName12";
			sql+=" FROM Sale_SOM WHERE SO="+SysString.ToDBString(p_SO);
			DataTable dt=SysUtils.Fill(sql);
			if(dt.Rows.Count!=0)
			{
				m_DrpSizeNum.EditValue=SysConvert.ToInt32(dt.Rows[0]["SizeNumID"]);
			
				for( int i=0;i<12;i++)
				{
					m_DrpSizeNmA[i].Text=dt.Rows[0]["SizeName"+(i+1).ToString()].ToString();
				}
			}
			else
			{
				m_DrpSizeNum.EditValue=3;
			
				for( int i=0;i<12;i++)
				{
					m_DrpSizeNmA[i].Text="";
				}
			}
		}

		/// <summary>
		/// 选择改变
		/// </summary>
		private void drpEditValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				for( int i=0;i<12;i++)
				{
					m_DrpSizeNmA[i].Visible=false;
					m_LblSizeNmA[i].Visible=false;
					m_View.Columns["Qty"+(i+1).ToString()].Visible=false;
				}
				for(int i=0;i<SysConvert.ToInt32(m_DrpSizeNum.EditValue);i++)
				{
					m_DrpSizeNmA[i].Visible=true;
					m_LblSizeNmA[i].Visible=true;
					m_View.Columns["Qty"+(i+1).ToString()].Visible=true;
				}

				ProcessGrid.GridSortSet(m_View,m_FieldNameA);
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}


		/// <summary>
		/// 设置GridView2列名称
		/// </summary>
		private void drpSizeName_EditValueChanged(object sender, System.EventArgs e)
		{
			try
			{				
				SetGridSize((ComboBoxEdit)sender);
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}

		/// <summary>
		/// 设置Grid头部信息
		/// </summary>
		/// <param name="p_Drp"></param>
		private void SetGridSize(ComboBoxEdit p_Drp)
		{
			string sort=p_Drp.Name.Substring(11,p_Drp.Name.Length-11);
			m_View.Columns["Qty"+sort].Caption=p_Drp.Text.Trim();
		}

    }

    #endregion


    #region 处理尺码--bandedGridView 
    /// <summary>
    /// 处理尺码
    /// </summary>
    public class ProcFOSizeBanded : BaseForm
    {

        LookUpEdit m_DrpSizeNum;
        Label[] m_LblSizeNmA;
        ComboBoxEdit[] m_DrpSizeNmA;
        BandedGridView m_View;
        string[] m_FieldNameA;
        GridBand[] m_Banded;

        public ProcFOSizeBanded(LookUpEdit p_DrpSizeNum, Label[] p_LblSizeNmA, ComboBoxEdit[] p_DrpSizeNmA, BandedGridView p_View,  string[] p_FieldNameA,
            string p_TableName, string p_FieldName, GridBand[] p_Banded, bool p_ShowBlank)
        {
            ClassIni(p_DrpSizeNum, p_LblSizeNmA, p_DrpSizeNmA, p_View, p_FieldNameA, p_TableName, p_FieldName,p_Banded, p_ShowBlank);
        }

        /// <summary>
        /// 类初始化
        /// </summary>
        private void ClassIni(LookUpEdit p_DrpSizeNum, Label[] p_LblSizeNmA, ComboBoxEdit[] p_DrpSizeNmA, BandedGridView p_View, string[] p_FieldNameA,
            string p_TableName, string p_FieldName, GridBand[] p_Banded, bool p_ShowBlank)
        {
            m_DrpSizeNum = p_DrpSizeNum;
            m_LblSizeNmA = p_LblSizeNmA;
            m_DrpSizeNmA = p_DrpSizeNmA;
            m_FieldNameA = p_FieldNameA;
            m_View = p_View;
            m_Banded = p_Banded;
            p_DrpSizeNum.EditValueChanged += new System.EventHandler(drpEditValueChanged);


            Common.BindSizeNum(m_DrpSizeNum, "SOType", true);
            for (int i = 0; i < 12; i++)
            {
                m_DrpSizeNmA[i].Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;

                m_DrpSizeNmA[i].EditValueChanged += new System.EventHandler(drpSizeName_EditValueChanged);
                Common.BindCLS(m_DrpSizeNmA[i], p_TableName, p_FieldName, p_ShowBlank);


                m_Banded[i].Caption = "";         

            }

            drpEditValueChanged(null, null);

        }

        /// <summary>
        /// 设置改变
        /// </summary>
        /// <param name="p_SO"></param>
        public void SetSizeNameBySO(string p_SO)
        {
            string sql = "SELECT SizeNumID,SizeName1,SizeName2,SizeName3,SizeName4,SizeName5,SizeName6";
            sql += ",SizeName7,SizeName8,SizeName9,SizeName10,SizeName11,SizeName12";
            sql += " FROM Sale_SOM WHERE SO=" + SysString.ToDBString(p_SO);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                m_DrpSizeNum.EditValue = SysConvert.ToInt32(dt.Rows[0]["SizeNumID"]);

                for (int i = 0; i < 12; i++)
                {
                    m_DrpSizeNmA[i].Text = dt.Rows[0]["SizeName" + (i + 1).ToString()].ToString();
                }
            }
            else
            {
                m_DrpSizeNum.EditValue = 3;

                for (int i = 0; i < 12; i++)
                {
                    m_DrpSizeNmA[i].Text = "";
                }
            }
        }

        /// <summary>
        /// 选择改变
        /// </summary>
        private void drpEditValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                for (int i = 0; i < 12; i++)
                {
                    m_DrpSizeNmA[i].Visible = false;
                    m_LblSizeNmA[i].Visible = false;

                    m_Banded[i].Visible = false;
                }
                for (int i = 0; i < SysConvert.ToInt32(m_DrpSizeNum.EditValue); i++)
                {
                    m_DrpSizeNmA[i].Visible = true;
                    m_LblSizeNmA[i].Visible = true;

                    m_Banded[i].Visible = true;
                }

                ProcessGrid.GridSortSet(m_View, m_FieldNameA);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 设置GridView2列名称
        /// </summary>
        private void drpSizeName_EditValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                SetGridSize((ComboBoxEdit)sender);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 设置Grid头部信息
        /// </summary>
        /// <param name="p_Drp"></param>
        private void SetGridSize(ComboBoxEdit p_Drp)
        {
            string sort = p_Drp.Name.Substring(11, p_Drp.Name.Length - 11);

            m_Banded[SysConvert.ToInt32(sort)-1].Caption = p_Drp.Text.Trim();
        }

    }

    #endregion



    

    /// <summary>
    /// 处理配色
    /// </summary>
    public class ProcSampleWT : BaseForm
    {

        ComboBoxEdit m_DrpWTNum;
        Label[] m_LblWTName;
        TextEdit[] m_TxtWTName;

        public ProcSampleWT(ComboBoxEdit p_DrpWTNum, Label[] p_LblWTName, TextEdit[] p_TxtWTName, bool p_ShowBlank)
        {
            ClassIni(p_DrpWTNum, p_LblWTName, p_TxtWTName, p_ShowBlank);
        }

        /// <summary>
        /// 类初始化
        /// </summary>
        private void ClassIni(ComboBoxEdit p_DrpWTNum, Label[] p_LblWTName, TextEdit[] p_TxtWTName, bool p_ShowBlank)
        {
            m_DrpWTNum = p_DrpWTNum;
            m_LblWTName = p_LblWTName;
            m_TxtWTName = p_TxtWTName;

            p_DrpWTNum.EditValueChanged += new System.EventHandler(drpEditValueChanged);
            Common.BindWTNum(p_DrpWTNum, m_TxtWTName.Length, true);
            drpEditValueChanged(null, null);

        }

        /// <summary>
        /// 选择改变
        /// </summary>
        private void drpEditValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                for (int i = 0; i < m_TxtWTName.Length; i++)
                {
                    m_TxtWTName[i].Visible = false;
                    m_LblWTName[i].Visible = false;
                }
                for (int i = 0; i < SysConvert.ToInt32(m_DrpWTNum.EditValue); i++)
                {
                    m_TxtWTName[i].Visible = true;
                    m_LblWTName[i].Visible = true;
                }
                for (int i = SysConvert.ToInt32(m_DrpWTNum.EditValue); i < m_TxtWTName.Length; i++)
                {
                    m_TxtWTName[i].Text = "";
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }


  
}
