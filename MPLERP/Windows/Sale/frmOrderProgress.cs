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
    public partial class frmOrderProgress : frmAPBaseUIForm
    {
        public frmOrderProgress()
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
            //
            if (txtFormNo.Text != "")
            {
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if (chkINDate.Checked)
            {
                tempStr += " AND MakeDate Between "+SysString.ToDBString(txtQIndateS.DateTime)+" AND "+SysString.ToDBString(txtQIndateE.DateTime);
            }

            if (txtFollowNo.Text.Trim() != "")
            {
                tempStr += " AND FollowNo LIKE "+SysString.ToDBString("%"+txtFollowNo.Text.Trim()+"%");
            }

            if (txtModelCode.Text.Trim() != "")
            {
                tempStr += " AND ModelCode LIKE "+SysString.ToDBString("%"+txtModelCode.Text.Trim()+"%");
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            OrderProgressRule rule = new OrderProgressRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            OrderProgressRule rule = new OrderProgressRule();
            OrderProgress entity = EntityGet();
            rule.RDelete(entity);
        }
        
         /// <summary>
        /// 设置定位数据及状态
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_OrderProgress";
            this.HTDataList = gridView1;
            txtQIndateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtQIndateE.DateTime = DateTime.Now.Date;

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private OrderProgress EntityGet()
        {
            OrderProgress entity = new OrderProgress();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}