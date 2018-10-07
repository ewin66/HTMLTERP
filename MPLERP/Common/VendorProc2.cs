using System;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace MLTERP
{
	/// <summary>
	/// 客户双击查询处理
	/// </summary>
	public class VendorProc2:BaseForm
	{
		LookUpEdit m_Drp;
        string m_Condition;
		public VendorProc2(LookUpEdit p_Drp)
		{
			ClassIni(p_Drp,"");
		}
        public VendorProc2(LookUpEdit p_Drp, string p_Condition)
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
				frmVendorQuery2 frm=new frmVendorQuery2();				
				frm.FormID=this.GetFormIDByClassName("frmVendorQuery2");
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
}
