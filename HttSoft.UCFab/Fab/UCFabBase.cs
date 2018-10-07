using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HttSoft.UCFab
{
    /// <summary>
    /// ���ܣ������û��ؼ� ������
    ///    ���ڹ��÷���
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-31
    /// </summary>
    public partial class UCFabBase : UserControl
    {
        public UCFabBase()
        {
            InitializeComponent();
        }


        #region ��������
        #region ��ʾ��Ϣ

        /// <summary>
        /// ��ʾ������ʾ��Ϣ
        /// </summary>
        /// <param name="p_Message">������Ϣ����</param>
        public void ShowMessage(string p_Message)
        {
            MessageBox.Show(p_Message, "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// ��ʾ��ʾ��Ϣ
        /// </summary>
        /// <param name="p_Message">��ʾ��Ϣ����</param>
        public void ShowInfoMessage(string p_Message)
        {
            MessageBox.Show(p_Message, "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ��ʾȷ����Ϣ
        /// </summary>
        /// <param name="p_Message">ѯ����Ϣ</param>
        /// <returns></returns>
        public DialogResult ShowConfirmMessage(string p_Message)
        {
            return MessageBox.Show(p_Message, "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion
        #endregion


        #region �������ⷽ��
        
        /// <summary>
        /// �Ƴ��ؼ�(��Ч�ͷ���Դ����ֹ���������)
        /// </summary>
        /// <param name="ctlContainer">�ؼ�����</param>
        public void RemoveUserCtl(Control ctlContainer)
        {
            foreach (Control ctl in ctlContainer.Controls)
            {
                ctl.Dispose();
            }
            ctlContainer.Controls.Clear();
        }
        #endregion

        #region ����Բ�Ǿ��η���
        #region �Զ��巽��

        /// <summary>
        /// ���ƻ�Բ��,�߿���ɫʹ��Tag�����ַ���ʶ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ctlDisplay_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                DrawRoundRect(e.Graphics, (Control)sender);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���Ʒ���
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="label"></param>
        private void DrawRoundRect(Graphics graphics, Control label)
        {
            float X = float.Parse(label.Width.ToString()) - 1;
            float Y = float.Parse(label.Height.ToString()) - 1;
            PointF[] points = 
			{
				new PointF(2,0),
				new PointF(X-2,0),
				new PointF(X-1,1),
				new PointF(X,2),
				new PointF(X,Y-2),
				new PointF(X-1,Y-1),
				new PointF(X-2,Y),
				new PointF(2,Y),
				new PointF(1,Y-1),
				new PointF(0,Y-2),
				new PointF(0,2),
				new PointF(1,1)
			};
            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);

            string colorStr = string.Empty;
            try
            {
                if (label.Tag.ToString()!=string.Empty)//����������� ��ɫ�ַ����洢��Tag��,���ڿؼ�ʶ��,�����Է���
                {
                    colorStr = label.Tag.ToString();
                }
            }
            catch
            {
                //������
            }
            Color oc = Color.Blue;
            if (colorStr != string.Empty)//�����ȡ����ɫ�ַ�����
            {
                oc = UCStatusBarParamSet.ConvertColorByStr(colorStr);
                if (oc == Color.White)//����ǰ�ɫ��Ĭ�Ϸ���
                {
                    oc = Color.Blue;
                }
            }
            Pen pen = new Pen(Color.FromArgb(150, oc), 1);
            pen.DashStyle = DashStyle.Solid;
            graphics.DrawPath(pen, path);
        }
         #endregion
        #endregion
    }
}
