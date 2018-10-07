using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;

namespace MLTERP
{
    public partial class frmSelect :BaseForm
    {
        public frmSelect()
        {
            InitializeComponent();
        }

        private string m_Condition;
        public string Condition
        {
            get
            {
                return m_Condition;
            }
            set
            {
                m_Condition = value;
            }
        }


        
        private void frmLoadPack_Load(object sender, EventArgs e)
        {
            try
            {

               
               
 
            }
            catch (Exception E)
            {
               
            }

        }

     

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_Condition = "";
                if (txtBoxNo.Text.Trim() != "")
                {
                    m_Condition += " AND BoxNo LIKE "+SysString.ToDBString(txtBoxNo.Text.Trim());
                }

                if (txtBatch.Text.Trim() != "")
                {
                    m_Condition += " AND Batch LIKE " + SysString.ToDBString(txtBatch.Text.Trim());
                }

                if (txtJarNum.Text.Trim() != "")
                {
                    m_Condition += " AND JarNum LIKE " + SysString.ToDBString(txtJarNum.Text.Trim());
                }
                this.Close();



            }
            catch (Exception E)
            {

            }
        }








    }
}