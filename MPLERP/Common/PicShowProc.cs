using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;

namespace MLTERP
{
    public class PicShowProc : BaseForm
    {
        PictureBox m_PicBox;
        public PicShowProc(PictureBox p_PicBox)
        {
            m_PicBox = p_PicBox;
            p_PicBox.DoubleClick += new System.EventHandler(pic_DoubleClick);

        }
        void pic_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                PicShowForm frm = new PicShowForm();
                frm.ProImage = m_PicBox.Image;
                frm.ShowDialog();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}
