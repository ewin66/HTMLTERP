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
using HttSoft.MLTERP.Sys;
using DevExpress.XtraGrid.Views.Base;



namespace MLTERP
{
    public partial class frmSParamset  : BaseForm
    {
        public frmSParamset()
        {
            InitializeComponent();
        }

        #region ҳ���ʼ��
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {
                BindSParamset1();
                BindSParamset2();
                BindSParamset3();
                BindSParamset4();
                BindSParamset5();
                BindSParamset6();
                BindSParamset7();
               
            }
            catch (Exception E)
            {
               
            }
        }

        #endregion

        #region ��������
        /// <summary>
        /// �����ܿ���
        /// </summary>
        private void BindSParamset1()
        {
            SParamset entity = new SParamset();
            entity.ID = (int)EnumSParamset.�����ܿ���;
            entity.SelectByID();
            if (entity.SetValueInt == 1)
            {
                chkOpen.Checked = true;
            }
            else
            {
                chkOpen.Checked = false;
            }

        }
        /// <summary>
        /// ���ͼ������ڵ�����
        /// </summary>
        private void BindSParamset2()
        {
            SParamset entity = new SParamset();
            entity.ID = (int)EnumSParamset.���ͼ������ڵ�����;
            entity.SelectByID();
            txtSendDay.Text = entity.SetValueInt.ToString();

        }

        /// <summary>
        /// ��Ϣ������������
        /// </summary>
        private void BindSParamset3()
        {
            SParamset entity = new SParamset();
            entity.ID = (int)EnumSParamset.��Ϣ������������;
            entity.SelectByID();
            txtFontNum.Text = entity.SetValueInt.ToString();


        }
        /// <summary>
        /// ��ʱ����ʱ��
        /// </summary>
        private void BindSParamset4()
        {
            SParamset entity = new SParamset();
            entity.ID = (int)EnumSParamset.��ʱ����ʱ��;
            entity.SelectByID();
            txtTimeSend.Text = entity.SetValueStr.ToString();

        }
        /// <summary>
        /// ��ֹ����ʱ�䷶Χ
        /// </summary>
        private void BindSParamset5()
        {
            SParamset entity = new SParamset();
            entity.ID = (int)EnumSParamset.��ֹ����ʱ�䷶Χ;
            entity.SelectByID();
            txtNoSendTimeArea.Text = entity.SetValueStr.ToString();

        }
        /// <summary>
        /// ��ֹ�������ڼ�����
        /// </summary>
        private void BindSParamset6()
        {
            SParamset entity = new SParamset();
            entity.ID = (int)EnumSParamset.��ֹ�������ڼ�����;
            entity.SelectByID();
            string str = entity.SetValueStr;
            string[] arr = str.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                switch(SysConvert.ToInt32(arr[i]))
                {
                    case 1:
                        chk1.Checked=true;
                        break;
                    case 2:
                        chk2.Checked=true;
                        break;
                    case 3:
                        chk3.Checked=true;
                        break;
                    case 4:
                        chk4.Checked=true;
                        break;
                    case 5:
                        chk5.Checked=true;
                        break;
                    case 6:
                        chk6.Checked=true;
                        break;
                    case 7:
                        chk7.Checked=true;
                        break;
                    default:
                        break;
                    
                }
            }

        }
        /// <summary>
        /// ��ֹ������������
        /// </summary>
        private void BindSParamset7()
        {
            SParamset entity = new SParamset();
            entity.ID = (int)EnumSParamset.��ֹ������������;
            entity.SelectByID();
            txtNoSendDate.Text = entity.SetValueStr.ToString();

        }
        #endregion

        #region �����������
        /// <summary>
        /// �����ܿ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                SParamsetRule rule = new SParamsetRule();
                SParamset entity = new SParamset();
                entity.ID = (int)EnumSParamset.�����ܿ���;
                entity.SelectByID();
                if (chkOpen.Checked)
                {
                    entity.SetValueInt = 1;
                }
                else
                {
                    entity.SetValueInt = 0;
                }
                rule.RUpdate(entity);
                this.ShowMessage("�������óɹ�");
                BindSParamset1();
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���ͼ������ڵ�����,�������ò��������ݲ��ٷ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                SParamsetRule rule = new SParamsetRule();
                SParamset entity = new SParamset();
                entity.ID = (int)EnumSParamset.���ͼ������ڵ�����;
                entity.SelectByID();
                entity.SetValueInt = SysConvert.ToInt32(txtSendDay.Text.Trim());
                rule.RUpdate(entity);
                this.ShowMessage("�������óɹ�");
                BindSParamset2();
              
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ��Ϣ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave3_Click(object sender, EventArgs e)
        {
            try
            {
                SParamsetRule rule = new SParamsetRule();
                SParamset entity = new SParamset();
                entity.ID = (int)EnumSParamset.��Ϣ������������;
                entity.SelectByID();
                entity.SetValueInt = SysConvert.ToInt32(txtFontNum.Text.Trim());
                rule.RUpdate(entity);
                this.ShowMessage("�������óɹ�");
                BindSParamset3();
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ��ʱ����ʱ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave4_Click(object sender, EventArgs e)
        {
            try
            {
                SParamsetRule rule = new SParamsetRule();
                SParamset entity = new SParamset();
                entity.ID = (int)EnumSParamset.��ʱ����ʱ��;
                entity.SelectByID();
                entity.SetValueStr = SysConvert.ToString(txtTimeSend.Text.Trim());
                rule.RUpdate(entity);
                this.ShowMessage("�������óɹ�");
                BindSParamset4();
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ��ֹ����ʱ�䷶Χ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave5_Click(object sender, EventArgs e)
        {
            try
            {
                SParamsetRule rule = new SParamsetRule();
                SParamset entity = new SParamset();
                entity.ID = (int)EnumSParamset.��ֹ����ʱ�䷶Χ;
                entity.SelectByID();
                entity.SetValueStr = SysConvert.ToString(txtNoSendTimeArea.Text.Trim());
                rule.RUpdate(entity);
                this.ShowMessage("�������óɹ�");
                BindSParamset5();
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnSave6_Click(object sender, EventArgs e)
        {
            try
            {
                SParamsetRule rule = new SParamsetRule();
                SParamset entity = new SParamset();
                entity.ID = (int)EnumSParamset.��ֹ�������ڼ�����;
                entity.SelectByID();
                string str = "";
                for (int i = 0; i <= 7; i++)
                {
                    if (str != "")
                    {
                        str += ",";
                    }
                    switch (i)
                    {
                        case 1:
                            if (chk1.Checked)
                            {
                                str += "1";
                            }
                            else
                            {
                                str += "0";
                            }
                            break;
                        case 2:
                            if (chk2.Checked)
                            {
                                str += "2";
                            }
                            else
                            {
                                str += "0";
                            }
                            break;
                        case 3:
                            if (chk3.Checked)
                            {
                                str += "3";
                            }
                            else
                            {
                                str += "0";
                            }
                            break;
                        case 4:
                            if (chk4.Checked)
                            {
                                str += "4";
                            }
                            else
                            {
                                str += "0";
                            }
                            break;
                        case 5:
                            if (chk5.Checked)
                            {
                                str += "5";
                            }
                            else
                            {
                                str += "0";
                            }
                            break;
                        case 6:
                            if (chk6.Checked)
                            {
                                str += "6";
                            }
                            else
                            {
                                str += "0";
                            }
                            break;
                        case 7:
                            if (chk7.Checked)
                            {
                                str += "7";
                            }
                            else
                            {
                                str += "0";
                            }
                            break;
                        default:
                            break;

                    }
                }
                entity.SetValueStr = str;
                rule.RUpdate(entity);
                this.ShowMessage("�������óɹ�");
                BindSParamset6();
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ��ֹ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave7_Click(object sender, EventArgs e)
        {
            try
            {
                SParamsetRule rule = new SParamsetRule();
                SParamset entity = new SParamset();
                entity.ID = (int)EnumSParamset.��ֹ������������;
                entity.SelectByID();
                entity.SetValueStr = SysConvert.ToString(txtNoSendDate.Text.Trim());
                rule.RUpdate(entity);
                this.ShowMessage("�������óɹ�");
                BindSParamset7();
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion








    }

}