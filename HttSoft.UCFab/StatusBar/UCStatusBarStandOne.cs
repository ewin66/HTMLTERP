using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HttSoft.UCFab
{
    /// <summary>
    /// ��׼���ȿؼ�����Ԫ�ؼ�
    /// �¼Ӻ�
    /// 2014.4.18
    /// </summary>
    public partial class UCStatusBarStandOne : UCStatusBarStandItemBase
    {
        public UCStatusBarStandOne()
        {
            InitializeComponent();
        }

        

        #region �鷽������д����
        /// <summary>
        /// �������ݿ��
        /// </summary>
        /// <param name="p_Value"></param>
        public override void UCSetContextWidth(int p_Value)
        {
            if (p_Value != 0)
            {
                this.Width = p_Value;
            }
            else
            {
                this.Width = 60;
            }
        }


        /// <summary>
        /// �������ݸ߶�
        /// </summary>
        /// <param name="p_Value"></param>
        public override void UCSetContextHeight(int p_Value)
        {
            if (p_Value != 0)
            {
                this.Height = p_Value;
            }
            else
            {
                this.Height = 16;
            }
        }

        /// <summary>
        /// ���ñ���ɫ
        /// </summary>
        /// <param name="p_Value"></param>
        public override void UCSetBackColor(Color p_Value)
        {
            txtColorSOStatus1.BackColor = p_Value;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="p_Value"></param>
        public override void UCSetContext(string p_Value)
        {
            txtColorSOStatus1.Text = p_Value;
        }
        #endregion
    }
}
