using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MLTERP
{
    public partial class frmLoadSOProcess : Form
    {
        public frmLoadSOProcess()
        {
            InitializeComponent();
        }

        public string FormNo = string.Empty;
        public int FormDataID = 0;

        private void frmLoadSOProcess_Load(object sender, EventArgs e)
        {
            try
            {
                ucsoProcessView1.FormNo = FormNo;
                ucsoProcessView1.FormDataID = FormDataID;
                ucsoProcessView1.UCAct();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}