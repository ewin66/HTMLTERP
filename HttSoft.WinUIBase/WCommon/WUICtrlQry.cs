using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using System.Collections;

namespace HttSoft.WinUIBase
{
    //提供两种方法，回车检索，值改变检索

    /// <summary>
    /// 界面数据检索委托方法
    /// 一般界面上使用的是BindGrid()方法
    /// </summary>
    public delegate void UIMethodQryData();// 定义委托处理程序

    /// <summary>
    /// 控件检索方法类
    /// 
    /// 提供两种方法，回车检索，值改变检索
    /// </summary>
    public class WUICtrlQry
    {
        /// <summary>
        /// 检索条件方法
        /// </summary>
        UIMethodQryData _qryConMethod;
        /// <summary>
        /// 检索方法
        /// </summary>
        UIMethodQryData _qryMethod;

        /// <summary>
        /// 窗体
        /// </summary>
        BaseForm _qryFrm;


        /// <summary>
        /// 构造函数(传入查询容器)
        /// </summary>
        /// <param name="qryContainer">控件容器</param>
        /// <param name="qryConMethod">检索条件方法</param>
        /// <param name="qryMethod">检索方法</param>
        /// <param name="qryOPType">检索类型：0/1/2:不检索，回车检索，改变值检索</param>
        /// <param name="qryFrm">窗体，传入用于提示信息用</param>
        public WUICtrlQry(Control qryContainer, UIMethodQryData qryConMethod,UIMethodQryData qryMethod, int qryOPType, BaseForm qryFrm)
        {
            _qryConMethod = qryConMethod;
            _qryMethod = qryMethod;
            _qryFrm = qryFrm;
            Control[] ctlA = FindCtronlAll(qryContainer);
            for (int i = 0; i < ctlA.Length; i++)
            {
                WUICtrlQryIni(ctlA[i], qryOPType);
            }

        }

        /// <summary>
        /// 构造函数(传入查询条件数组)
        /// </summary>
        /// <param name="ctlA">控件数组</param>
        /// <param name="qryConMethod">检索条件方法</param>
        /// <param name="qryMethod">检索方法</param>
        /// <param name="qryOPType">检索类型：0/1/2:不检索，回车检索，改变值检索</param>
        /// <param name="qryFrm">窗体，传入用于提示信息用</param>
        public WUICtrlQry(Control[] ctlA, UIMethodQryData qryConMethod, UIMethodQryData qryMethod, int qryOPType, BaseForm qryFrm)
        {
            _qryConMethod = qryConMethod;
            _qryMethod = qryMethod;
            _qryFrm = qryFrm;
            for (int i = 0; i < ctlA.Length; i++)
            {
                WUICtrlQryIni(ctlA[i], qryOPType);
            }
        }

        #region 内部方法
        /// <summary>
        /// 寻找容器所有控件
        /// </summary>
        /// <param name="qryContainer"></param>
        /// <returns></returns>
        Control[] FindCtronlAll(Control qryContainer)
        {
            ArrayList al = new ArrayList();
            foreach (Control ctl in qryContainer.Controls)
            {
                if (ctl is DevExpress.XtraEditors.BaseEdit || ctl is System.Windows.Forms.TextBoxBase
                    || ctl is System.Windows.Forms.ComboBox)
                {
                    al.Add(ctl);
                }
            }
            Control[] ctlA = new Control[al.Count];
            for (int i = 0; i < al.Count; i++)
            {
                ctlA[i] = (Control)al[i];
            }
            return ctlA;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="ctl">控件</param>
        /// <param name="qryMethod">检索方法</param>
        /// <param name="qryOPType">检索类型：0/1/2:不检索，回车检索，改变值检索</param>
        void WUICtrlQryIni(Control ctl, int qryOPType)
        {
            switch (qryOPType)
            {
                case 0://未设置不检索
                    break;
                case 1://回车检索
                    ctl.KeyDown += new System.Windows.Forms.KeyEventHandler(Ctl_KeyDown);
                    break;
                case 2://改变值检索
                    BindCtlValueChangeEvent(ctl);
                    break;
                case 3://不检索
                    break;
            }
        }
        /// <summary>
        /// 绑定值改变事件
        /// </summary>
        /// <param name="ctl"></param>
        void BindCtlValueChangeEvent(Control ctl)
        {
            if (ctl is DevExpress.XtraEditors.BaseEdit)
            {
                ((DevExpress.XtraEditors.BaseEdit)ctl).EditValueChanged += new System.EventHandler(Ctl_EditValueChanged);
            }
            else if (ctl is System.Windows.Forms.TextBoxBase)
            {
                ((TextBoxBase)ctl).TextChanged += new System.EventHandler(Ctl_EditValueChanged);
            }
            else if (ctl is System.Windows.Forms.ComboBox)
            {
                ((System.Windows.Forms.ComboBox)ctl).TextChanged += new System.EventHandler(Ctl_EditValueChanged);
            }
        }
        #endregion

        #region 事件定义

        /// <summary>
        /// 回车检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ctl_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//输入条码了
                {
                    if (_qryConMethod != null)
                    {
                        _qryConMethod();
                    }
                    if (_qryMethod != null)
                    {
                        _qryMethod();
                    }
                }
            }
            catch (Exception E)
            {
                if (_qryFrm != null)
                {
                    _qryFrm.ShowMessage(E.Message);
                }
            }
        }



        /// <summary>
        /// 值改变检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ctl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_qryConMethod != null)
                {
                    _qryConMethod();
                }
                if (_qryMethod != null)
                {
                    _qryMethod();
                }
            }
            catch (Exception E)
            {
                if (_qryFrm != null)
                {
                    _qryFrm.ShowMessage(E.Message);
                }
            }
        }
        #endregion
    }
}
