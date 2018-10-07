using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HTCPCheck
{
    public partial class frmKeyBoard : Form
    {
        public frmKeyBoard()
        {
            InitializeComponent();
        }
        #region 属性
        private string m_InputStr = string.Empty;
        public string InputStr
        {
            set
            {
                m_InputStr = value;
            }
            get
            {
                return m_InputStr;
            }
        }
        #endregion

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Tag.ToString() != "OK")
            {
                if (btn.Text != "<---")
                {
                    lbShow.Text += btn.Text;
                }
                else
                {
                    if (lbShow.Text.Length > 0)
                    {
                        lbShow.Text = lbShow.Text.Substring(0, lbShow.Text.Length - 1);
                    }
                }
            }
            else
            {
                m_InputStr = lbShow.Text;
                this.Close();
            }
        }
        /// <param name="e"></param>
        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = global::HTCPCheck.Properties.Resources._8默认;
        }
        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = global::HTCPCheck.Properties.Resources._8_单击;
        }

        /// <param name="e"></param>
        private void btn_MouseUpOK(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = global::HTCPCheck.Properties.Resources._10_默认;
        }
        private void btn_MouseDownOK(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = global::HTCPCheck.Properties.Resources._10_单击;
        }

        /// <param name="e"></param>
        private void btn_MouseUpBack(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = global::HTCPCheck.Properties.Resources._9_默认;
        }
        private void btn_MouseDownBack(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = global::HTCPCheck.Properties.Resources._9_单击;
        }


        private void frmKeyBoard_Load(object sender, EventArgs e)
        {
            this.btn9.Click += new System.EventHandler(this.btn_Click);
            this.btn8.Click += new System.EventHandler(this.btn_Click);
            this.btn7.Click += new System.EventHandler(this.btn_Click);
            this.btn6.Click += new System.EventHandler(this.btn_Click);
            this.btn5.Click += new System.EventHandler(this.btn_Click);
            this.btn4.Click += new System.EventHandler(this.btn_Click);
            this.btn3.Click += new System.EventHandler(this.btn_Click);
            this.btn2.Click += new System.EventHandler(this.btn_Click);
            this.btn1.Click += new System.EventHandler(this.btn_Click);
            this.btn0.Click += new System.EventHandler(this.btn_Click);
            this.btnBack.Click += new System.EventHandler(this.btn_Click);

            this.btnP.Click += new System.EventHandler(this.btn_Click);
            this.btnO.Click += new System.EventHandler(this.btn_Click);
            this.btnI.Click += new System.EventHandler(this.btn_Click);
            this.btnU.Click += new System.EventHandler(this.btn_Click);
            this.btnY.Click += new System.EventHandler(this.btn_Click);
            this.btnT.Click += new System.EventHandler(this.btn_Click);
            this.btnR.Click += new System.EventHandler(this.btn_Click);
            this.btnE.Click += new System.EventHandler(this.btn_Click);
            this.btnW.Click += new System.EventHandler(this.btn_Click);
            this.btnQ.Click += new System.EventHandler(this.btn_Click);
            this.btnPoint.Click += new System.EventHandler(this.btn_Click);

            this.btnL.Click += new System.EventHandler(this.btn_Click);
            this.btnK.Click += new System.EventHandler(this.btn_Click);
            this.btnJ.Click += new System.EventHandler(this.btn_Click);
            this.btnH.Click += new System.EventHandler(this.btn_Click);
            this.btnG.Click += new System.EventHandler(this.btn_Click);
            this.btnF.Click += new System.EventHandler(this.btn_Click);
            this.btnD.Click += new System.EventHandler(this.btn_Click);
            this.btnS.Click += new System.EventHandler(this.btn_Click);
            this.btnA.Click += new System.EventHandler(this.btn_Click);
            this.btnHengXian.Click += new System.EventHandler(this.btn_Click);

            this.btnNull.Click += new System.EventHandler(this.btn_Click);
            this.btnM.Click += new System.EventHandler(this.btn_Click);
            this.btnN.Click += new System.EventHandler(this.btn_Click);
            this.btnB.Click += new System.EventHandler(this.btn_Click);
            this.btnV.Click += new System.EventHandler(this.btn_Click);
            this.btnC.Click += new System.EventHandler(this.btn_Click);
            this.btnX.Click += new System.EventHandler(this.btn_Click);
            this.btnZ.Click += new System.EventHandler(this.btn_Click);
            this.buttonZuoXie.Click += new System.EventHandler(this.btn_Click);
            this.btnOK.Click += new System.EventHandler(this.btn_Click);


            this.btn9.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btn8.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btn7.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btn6.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btn5.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btn4.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btn3.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btn2.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btn1.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btn0.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnBack.MouseUp += new MouseEventHandler(this.btn_MouseUpBack);//*****

            this.btnP.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnO.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnI.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnU.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnY.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnT.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnR.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnE.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnW.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnQ.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnPoint.MouseUp += new MouseEventHandler(this.btn_MouseUp);

            this.btnL.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnK.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnJ.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnH.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnG.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnF.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnD.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnS.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnA.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnHengXian.MouseUp += new MouseEventHandler(this.btn_MouseUp);

            this.btnNull.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnM.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnN.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnB.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnV.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnC.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnX.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnZ.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.buttonZuoXie.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btnOK.MouseUp += new MouseEventHandler(this.btn_MouseUpOK);//*****








            this.btn9.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btn8.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btn7.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btn6.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btn5.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btn4.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btn3.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btn2.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btn1.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btn0.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnBack.MouseDown += new MouseEventHandler(this.btn_MouseDownBack);//******

            this.btnP.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnO.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnI.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnU.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnY.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnT.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnR.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnE.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnW.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnQ.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnPoint.MouseDown += new MouseEventHandler(this.btn_MouseDown);

            this.btnL.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnK.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnJ.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnH.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnG.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnF.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnD.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnS.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnA.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnHengXian.MouseDown += new MouseEventHandler(this.btn_MouseDown);

            this.btnNull.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnM.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnN.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnB.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnV.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnC.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnX.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnZ.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.buttonZuoXie.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btnOK.MouseDown += new MouseEventHandler(this.btn_MouseDownOK);//******






            lbShow.Text = m_InputStr;

        }
    }
}