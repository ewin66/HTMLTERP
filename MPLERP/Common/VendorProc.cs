using System;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;

namespace MLTERP
{
	/// <summary>
	/// 客户双击查询处理
	/// </summary>
	public class VendorProc:BaseForm
	{
		LookUpEdit m_Drp;
        string m_Condition;
		public VendorProc(LookUpEdit p_Drp)
		{
			ClassIni(p_Drp,"");
		}
        public VendorProc(LookUpEdit p_Drp,string p_Condition)
        {
            ClassIni(p_Drp, p_Condition);
        }


        private void ClassIni(LookUpEdit p_Drp, string p_Condition)
		{
			m_Drp=p_Drp;
            m_Condition = p_Condition;
			p_Drp.DoubleClick+=  new System.EventHandler(drpItem_DoubleClick);
		}

		/// <summary>
		/// 双击带出客户查询
		/// </summary>
		private void drpItem_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				if(m_Drp.Properties.ReadOnly)
				{
					return;
				}
				frmVendorQuery frm=new frmVendorQuery();				
				frm.FormID=this.GetFormIDByClassName("frmVendorQuery");
                frm.p_Condition = m_Condition;
                try//赋值类型
                {
                    frm.p_VendorType = (int[])m_Drp.Tag;
                }
                catch
                {
                }
				frm.ShowDialog();
				if(frm.p_SelectFlag)
				{						
					m_Drp.EditValue=frm.p_VendorID;
				}
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}
	}





    /// <summary>
    /// 客户双击查询处理
    /// </summary>
    public class VendorProcRepository : BaseForm
    {
        RepositoryItemLookUpEdit m_Drp;
        string m_Condition;
         GridView  m_View;
        string m_FieldName;
        int[] m_VendorType;
        public VendorProcRepository(Label p_FocusLabel, GridView p_View,RepositoryItemLookUpEdit p_Drp,string p_FieldName, int[] p_VendorType)
        {
            ClassIni(p_FocusLabel, p_View, p_Drp, p_FieldName, p_VendorType, "");
        }
        public VendorProcRepository(Label p_FocusLabel, GridView p_View, RepositoryItemLookUpEdit p_Drp, string p_FieldName, int[] p_VendorType, string p_Condition)
        {
            ClassIni(p_FocusLabel, p_View, p_Drp, p_FieldName, p_VendorType, p_Condition);
        }


        private void ClassIni(Label p_FocusLabel, GridView p_View, RepositoryItemLookUpEdit p_Drp, string p_FieldName, int[] p_VendorType, string p_Condition)
        {
            m_Drp = p_Drp;
            m_View = p_View;
            m_FieldName = p_FieldName;
            m_VendorType = p_VendorType;
            m_Condition = p_Condition;



            Common.BindVendor(p_Drp, p_VendorType, true);
           

            p_Drp.DoubleClick += new System.EventHandler(drpItem_DoubleClick);
        }

       


        /// <summary>
        /// 双击带出客户查询
        /// </summary>
        private void drpItem_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                frmVendorQuery frm = new frmVendorQuery();
                frm.FormID = this.GetFormIDByClassName("frmVendorQuery");
                frm.p_Condition = m_Condition;
                frm.p_VendorType = m_VendorType;
                frm.ShowDialog();
                if (frm.p_SelectFlag)
                {
                    ////解决菁诚弹出新增后编码没刷新问题（重新绑定）
                    //string sql = "SELECT VendorID,VendorAttn,VendorName FROM Data_Vendor WHERE 1=1";
                    //if (m_VendorType != null && m_VendorType.Length > 0)
                    //{
                    //    sql += " AND VendorTypeID IN(" + Common.ConvertArrayIntToStr(m_VendorType) + ")";
                    //}
                    //sql += " ORDER BY VendorID";
                    //DataTable dt = SysUtils.Fill(sql);
                  

                    //FCommon.RepositoryLookupEditColAdd(m_Item, new int[] { 50, 50, 200 }, new string[] { "ItemCode", "ItemStd", "ItemName" }, new string[] { "物品编码", "物品规格", "物品名称" }, new bool[] { true, true, true });
                    //FCommon.LoadDropRepositoryLookUP(m_Item, dt, "ItemCode", "ItemCode", true);


                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_FieldName, frm.p_VendorID);
                  

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}
