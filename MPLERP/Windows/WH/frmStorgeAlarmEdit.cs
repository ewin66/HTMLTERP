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


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (Common.CheckLookUpEditBlank(drpWHTypeID))
            {
                this.ShowMessage("请输入仓库类型");
                drpWHTypeID.Focus();
                return false;
            }

            if (txtItemCode.Text.Trim() == "")
            {
                this.ShowMessage("请输入产品编码");
                txtItemCode.Focus();
                return false;
            }
            if (txtAlarmLowQty.Text.Trim() == "")
            {
                this.ShowMessage("请输入最低数量");
                txtAlarmLowQty.Focus();
                return false;
            }
            else
            {
                if (!SysConvert.IsDecimal(txtAlarmLowQty.Text.Trim()))
                {
                    this.ShowMessage("最低数量必须为数字，请重新输入");
                    txtAlarmLowQty.Focus();
                    return false;
                }
            }

            if (txtAlarmHighQty.Text.Trim() == "")
            {
                this.ShowMessage("请输入最高数量");
                txtAlarmHighQty.Focus();
                return false;
            }
            else
            {
                if (!SysConvert.IsDecimal(txtAlarmHighQty.Text.Trim()))
                {
                    this.ShowMessage("最高数量必须为数字，请重新输入");
                    txtAlarmHighQty.Focus();
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            StorgeAlarmRule rule = new StorgeAlarmRule();
            StorgeAlarm entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            StorgeAlarmRule rule = new StorgeAlarmRule();
            StorgeAlarm entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
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
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            StorgeAlarmRule rule = new StorgeAlarmRule();
            StorgeAlarm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_StorgeAlarm";
            Common.BindWHByWHType(drpWHTypeID, true);
            Common.BindCLS(txtGoodsLevel, "WH_IOFormDts", "GoodsLevel", true);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
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
        /// 双击带出产品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    frmLoadItemGB frm = new frmLoadItemGB();
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.GBID.Length > 1)
                    {
                        this.ShowMessage("请只加载一条信息");
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