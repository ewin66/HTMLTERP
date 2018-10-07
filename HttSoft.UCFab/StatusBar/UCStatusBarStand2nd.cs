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
    /// 标准进度控件进度元控件,模式二
    /// 陈加海
    /// 2014.5.22
    /// </summary>
    public partial class UCStatusBarStand2nd : UCStatusBarStandItemBase
    {
        public UCStatusBarStand2nd()
        {
            InitializeComponent();
        }

        

        #region 虚方法，重写方法
        /// <summary>
        /// 设置内容宽度
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
        /// 设置内容高度
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
        /// 设置背景色
        /// </summary>
        /// <param name="p_Value"></param>
        public override void UCSetBackColor(Color p_Value)
        {
            lblColorSOStatus1.BackColor = p_Value;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="p_Value"></param>
        public override void UCSetContext(string p_Value)
        {
            lblColorSOStatus1.Text = p_Value;
        }
        #endregion


        #region 控件加载
        private void UCStatusBarStand2nd_Load(object sender, EventArgs e)
        {
            try
            {
                lblColorSOStatus1.Paint += new PaintEventHandler(labelDisplay_Paint);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 自定义方法

        /// <summary>
        /// 绘制画圆角label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDisplay_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                DrawRoundRect(e.Graphics, lblColorSOStatus1);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 绘制方法
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="label"></param>
        private void DrawRoundRect(Graphics graphics, Label label)
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

            Pen pen = new Pen(Color.FromArgb(150, UCBorderColor), 1);
            pen.DashStyle = DashStyle.Solid;
            graphics.DrawPath(pen, path);
        }
        #endregion

      
    }
}
