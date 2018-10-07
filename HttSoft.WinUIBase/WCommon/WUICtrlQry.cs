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
    //�ṩ���ַ������س�������ֵ�ı����

    /// <summary>
    /// �������ݼ���ί�з���
    /// һ�������ʹ�õ���BindGrid()����
    /// </summary>
    public delegate void UIMethodQryData();// ����ί�д������

    /// <summary>
    /// �ؼ�����������
    /// 
    /// �ṩ���ַ������س�������ֵ�ı����
    /// </summary>
    public class WUICtrlQry
    {
        /// <summary>
        /// ������������
        /// </summary>
        UIMethodQryData _qryConMethod;
        /// <summary>
        /// ��������
        /// </summary>
        UIMethodQryData _qryMethod;

        /// <summary>
        /// ����
        /// </summary>
        BaseForm _qryFrm;


        /// <summary>
        /// ���캯��(�����ѯ����)
        /// </summary>
        /// <param name="qryContainer">�ؼ�����</param>
        /// <param name="qryConMethod">������������</param>
        /// <param name="qryMethod">��������</param>
        /// <param name="qryOPType">�������ͣ�0/1/2:���������س��������ı�ֵ����</param>
        /// <param name="qryFrm">���壬����������ʾ��Ϣ��</param>
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
        /// ���캯��(�����ѯ��������)
        /// </summary>
        /// <param name="ctlA">�ؼ�����</param>
        /// <param name="qryConMethod">������������</param>
        /// <param name="qryMethod">��������</param>
        /// <param name="qryOPType">�������ͣ�0/1/2:���������س��������ı�ֵ����</param>
        /// <param name="qryFrm">���壬����������ʾ��Ϣ��</param>
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

        #region �ڲ�����
        /// <summary>
        /// Ѱ���������пؼ�
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
        /// ��ʼ��
        /// </summary>
        /// <param name="ctl">�ؼ�</param>
        /// <param name="qryMethod">��������</param>
        /// <param name="qryOPType">�������ͣ�0/1/2:���������س��������ı�ֵ����</param>
        void WUICtrlQryIni(Control ctl, int qryOPType)
        {
            switch (qryOPType)
            {
                case 0://δ���ò�����
                    break;
                case 1://�س�����
                    ctl.KeyDown += new System.Windows.Forms.KeyEventHandler(Ctl_KeyDown);
                    break;
                case 2://�ı�ֵ����
                    BindCtlValueChangeEvent(ctl);
                    break;
                case 3://������
                    break;
            }
        }
        /// <summary>
        /// ��ֵ�ı��¼�
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

        #region �¼�����

        /// <summary>
        /// �س�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ctl_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//����������
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
        /// ֵ�ı����
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
