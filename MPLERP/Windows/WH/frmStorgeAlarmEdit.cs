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
using DevExpress.XtraEditors.Controls;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmStorgeAlarmEdit : frmAPBaseUISinEdit
    {
        public frmStorgeAlarmEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (Common.CheckLookUpEditBlank(drpWHTypeID))
            {
                this.ShowMessage("������ֿ�����");
                drpWHTypeID.Focus();
                return false;
            }

            if (txtItemCode.Text.Trim() == "")
            {
                this.ShowMessage("�������Ʒ����");
                txtItemCode.Focus();
                return false;
            }
            if (txtAlarmLowQty.Text.Trim() == "")
            {
                this.ShowMessage("�������������");
                txtAlarmLowQty.Focus();
                return false;
            }
            else
            {
                if (!SysConvert.IsDecimal(txtAlarmLowQty.Text.Trim()))
                {
                    this.ShowMessage("�����������Ϊ���֣�����������");
                    txtAlarmLowQty.Focus();
                    return false;
                }
            }

            if (txtAlarmHighQty.Text.Trim() == "")
            {
                this.ShowMessage("�������������");
                txtAlarmHighQty.Focus();
                return false;
            }
            else
            {
                if (!SysConvert.IsDecimal(txtAlarmHighQty.Text.Trim()))
                {
                    this.ShowMessage("�����������Ϊ���֣�����������");
                    txtAlarmHighQty.Focus();
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            StorgeAlarmRule rule = new StorgeAlarmRule();
            StorgeAlarm entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            StorgeAlarmRule rule = new StorgeAlarmRule();
            StorgeAlarm entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            StorgeAlarm entity = new StorgeAlarm();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            drpWHTypeID.EditValue = entity.WHID;
            txtMWeight.Text = entity.MWeight.ToString();
            txtMWidth.Text = entity.MWidth.ToString();
            txtGoodsCode.Text = entity.GoodsCode.ToString();
            txtGoodsLevel.Text = entity.GoodsLevel.ToString();
            txtItemName.Text = entity.ItemName.ToString();
            txtItemCode.Text = entity.ItemCode.ToString();
            txtAlarmLowQty.Text = entity.AlarmLowQty.ToString();
            txtAlarmHighQty.Text = entity.AlarmHighQty.ToString();

            txtRemark.Text = entity.Remark.ToString();


            if (!findFlag)
            {

            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            StorgeAlarmRule rule = new StorgeAlarmRule();
            StorgeAlarm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_StorgeAlarm";
            Common.BindWHByWHType(drpWHTypeID, true);
            Common.BindCLS(txtGoodsLevel, "WH_IOFormDts", "GoodsLevel", true);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private StorgeAlarm EntityGet()
        {
            StorgeAlarm entity = new StorgeAlarm();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.WHID = SysConvert.ToString(drpWHTypeID.EditValue.ToString());
            entity.ItemCode = txtItemCode.Text.Trim();
            entity.ItemName = txtItemName.Text.Trim();
            entity.LastUpdOP = FParamConfig.LoginID;
            entity.LastUpdTime = DateTime.Now.Date;
            entity.GoodsCode = txtGoodsCode.Text.Trim();
            entity.GoodsLevel = txtGoodsLevel.Text.Trim();
            entity.MWidth = SysConvert.ToDecimal(txtMWidth.Text.Trim());
            entity.MWeight = SysConvert.ToDecimal(txtMWeight.Text.Trim());
            entity.AlarmHighQty = SysConvert.ToDecimal(txtAlarmHighQty.Text.Trim());
            entity.AlarmLowQty = SysConvert.ToDecimal(txtAlarmLowQty.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();

            return entity;
        }
        #endregion

        /// <summary>
        /// ˫��������Ʒ��Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    frmLoadItemGB frm = new frmLoadItemGB();
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.GBID.Length > 1)
                    {
                        this.ShowMessage("��ֻ����һ����Ϣ");
                        return;
                    }
                    if (frm.GBID != null && frm.GBID.Length != 0)
                    {

                        for (int i = 0; i < frm.GBID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.GBID[i]);
                        }
                        setItemNews(str);
                    }




                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews(string str)
        {
            string[] arr = str.Split(',');
            string sql = "SELECT * FROM UV1_Data_ItemGB WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[0]));
            DataTable dt = SysUtils.Fill(sql);

            if (dt.Rows.Count > 0)
            {
                txtItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                txtItemName.Text = SysConvert.ToString(dt.Rows[0]["ItemName"]);
                txtMWidth.Text = SysConvert.ToDecimal(dt.Rows[0]["MWidth"]).ToString();
                txtMWeight.Text = SysConvert.ToDecimal(dt.Rows[0]["MWeight"]).ToString();
                txtGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
               

            }

        }
    }
}