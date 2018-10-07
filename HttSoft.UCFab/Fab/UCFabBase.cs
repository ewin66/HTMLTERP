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
    /// 功能：基类用户控件 根基类
    ///    用于共用方法
    /// 作者：陈加海
    /// 日期：2014-3-31
    /// </summary>
    public partial class UCFabBase : UserControl
    {
        public UCFabBase()
        {
            InitializeComponent();
        }


        #region 公共方法
        #region 提示信息

        /// <summary>
        /// 显示错误提示信息
        /// </summary>
        /// <param name="p_Message">错误信息内容</param>
        public void ShowMessage(string p_Message)
        {
            MessageBox.Show(p_Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="p_Message">提示信息内容</param>
        public void ShowInfoMessage(string p_Message)
        {
            MessageBox.Show(p_Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示确认信息
        /// </summary>
        /// <param name="p_Message">询问信息</param>
        /// <returns></returns>
        public DialogResult ShowConfirmMessage(string p_Message)
        {
            return MessageBox.Show(p_Message, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion
        #endregion


        #region 公共特殊方法
        
        /// <summary>
        /// 移除控件(有效释放资源，防止报句柄错误)
        /// </summary>
        /// <param name="ctlContainer">控件容器</param>
        public void RemoveUserCtl(Control ctlContainer)
        {
            foreach (Control ctl in ctlContainer.Controls)
            {
                ctl.Dispose();
            }
            ctlContainer.Controls.Clear();
        }
        #endregion

        #region 绘制圆角矩形方法
        #region 自定义方法

        /// <summary>
        /// 绘制画圆角,边框颜色使用Tag传入字符串识别
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
        /// 绘制方法
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
                if (label.Tag.ToString()!=string.Empty)//如果下列内容 颜色字符串存储在Tag内,便于控件识别,短暂性方法
                {
                    colorStr = label.Tag.ToString();
                }
            }
            catch
            {
                //不处理
            }
            Color oc = Color.Blue;
            if (colorStr != string.Empty)//如果读取到颜色字符串了
            {
                oc = UCStatusBarParamSet.ConvertColorByStr(colorStr);
                if (oc == Color.White)//如果是白色用默认方法
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
