using System;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace MLTERP
{
    /// <summary>
    /// LookUpProc 的摘要说明。
    /// </summary>
    public class LookUpClear : BaseForm
    {
        LookUpEdit m_Drp;
        public LookUpClear(LookUpEdit p_Drp)
        {
            ClassIni(p_Drp);
        }


        private void ClassIni(LookUpEdit p_Drp)
        {
            m_Drp = p_Drp;
            p_Drp.KeyDown += new System.Windows.Forms.KeyEventHandler(drpItem_KeyDown);
            p_Drp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(drpItem_KeyPress);
            p_Drp.Leave += new System.EventHandler(drpItem_Leave);
        }


        bool clearflag = false;
        private void drpItem_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 8)
                {
                    if (SysConvert.ToString(m_Drp.Text) == "")
                    {
                        clearflag = true;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpItem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (SysConvert.ToString(m_Drp.Text) == "")
                    {
                        clearflag = true;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private void drpItem_Leave(object sender, System.EventArgs e)
        {
            if (clearflag)
            {
                m_Drp.EditValue = "";
                clearflag = false;
            }
        }

    }
}
