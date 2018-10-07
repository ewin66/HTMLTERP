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
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmBoard : frmAPBaseUISin
    {
        public frmBoard()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtQTitle.Text.Trim() != "")
            {
                tempStr += " AND Title LIKE " + SysString.ToDBString("%" + txtQTitle.Text.Trim() + "%");
            }
            if ((SysConvert.ToString(txtQSendDateS.Text.Trim()) != "") && (SysConvert.ToString(txtQSendDateE.Text.Trim()) != ""))
            {
                tempStr += " AND SendDate BETWEEN " + SysString.ToDBString(txtQSendDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQSendDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            BoardRule rule = new BoardRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            BoardRule rule = new BoardRule();
            Board entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Board";
            this.HTDataList = gridView1;
            txtQSendDateS.DateTime = DateTime.Now.Date.AddDays(0 - FParamConfig.QueryDayNum);
            txtQSendDateE.DateTime = DateTime.Now.Date;
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Board EntityGet()
        {
            Board entity = new Board();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void txtQTitle_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

    }
}