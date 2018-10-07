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
    /// <summary>
    /// 功能：数据输入追踪进度.黄课长为统计输入情况的跟踪报表
    /// </summary>
    public partial class frmSJSRZZJDRpt : frmAPBaseUIRpt
    {
        public frmSJSRZZJDRpt()
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

            tempStr += " ORDER BY LX,iCount DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {

            DataTable dt = SysUtils.Fill(GetSQL() + HTDataConditionStr);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

       

        private string GetSQL()
        {
            string SQL = "";
            SQL = " SELECT LX,MakeOPID,MakeOPName,iCount FROM (" + "\r\n";
            SQL += " select distinct '客户' LX, MakeOPID,(select opname from data_op where opid = b.makeopid) MakeOPName," + "\r\n";
            SQL += " (select count(*) from data_vendor a where a.makeopid = b.makeopid and vendortypeid = '1') iCount" + "\r\n";
            SQL += " from data_vendor b  WHERE vendortypeid = '1' " + "\r\n";
            SQL += " union " + "\r\n";
            SQL += " select distinct '品牌'LX, MakeOPID, (select opname from data_op where opid = b.makeopid) MakeOPName," + "\r\n";
            SQL += " (select count(*) from data_brand a where a.makeopid = b.makeopid ) iCount " + "\r\n";
            SQL += " from data_brand b" + "\r\n";
            SQL += " union" + "\r\n";
            SQL += " select distinct '样衣依赖' LX, MakeOPID, (select opname from data_op where opid = b.makeopid) MakeOPName," + "\r\n";
            SQL += " (select count(*) from pro_sampledepend a where a.makeopid = b.makeopid) iCount" + "\r\n";
            SQL += " from pro_sampledepend b" + "\r\n";
            SQL += " union" + "\r\n";
            SQL += " select distinct '样衣指示' LX, MakeOPID, (select opname from data_op where opid = b.makeopid) MakeOPName," + "\r\n";
            SQL += " (select count(*) from pro_sample a where a.makeopid = b.makeopid) iCount" + "\r\n";
            SQL += " from pro_sample b" + "\r\n";
            SQL += " union" + "\r\n";
            SQL += " select distinct '样衣形式发票' LX, MakeOPID, (select opname from data_op where opid = b.makeopid) MakeOPName," + "\r\n";
            SQL += " (select count(*) from pro_sample a where a.makeopid = b.makeopid and samplestatusid = '5') iCount" + "\r\n";
            SQL += " from pro_sample b  WHERE samplestatusid = '5'" + "\r\n";
            SQL += " union" + "\r\n";
            SQL += " select distinct '坯布指示' LX, MakeOPID, (select opname from data_op where opid = b.makeopid) MakeOPName," + "\r\n";
            SQL += "  (select count(*) from pro_greycloth a where a.makeopid = b.makeopid ) iCount" + "\r\n";
            SQL += " from pro_greycloth b " + "\r\n";
            SQL += " union" + "\r\n";
            SQL += " select distinct '坯布指示进度' LX, '计划员' MakeOPID , '计划员' MakeOPName," + "\r\n";
            SQL += "  (select count(*) from pro_greycloth) iCount" + "\r\n";
            SQL += "  from pro_greycloth b" + "\r\n";
            SQL += " union" + "\r\n";
            SQL += " select distinct '样衣报价' LX, MakeOPID, (select opname from data_op where opid = b.makeopid) MakeOPName," + "\r\n";
            SQL += " (select count(*) from pro_sampleprice a where a.makeopid = b.makeopid and samplepricetypeid = '2') iCount" + "\r\n";
            SQL += "  from pro_sampleprice  b WHERE samplepricetypeid = '2'" + "\r\n";
            SQL += " union" + "\r\n";
            SQL += " select distinct '见本作成' LX, MakeOPID, (select opname from data_op where opid = b.makeopid) MakeOPName," + "\r\n";
            SQL += "    (select count(*) from pro_sampleprice a where a.makeopid = b.makeopid and samplepricetypeid = '1') iCount" + "\r\n";
            SQL += " from pro_sampleprice b WHERE samplepricetypeid = '1'" + "\r\n";
            SQL += " union" + "\r\n";
            SQL += " select distinct '洗缩加工指示' LX, MakeOPID, (select opname from data_op where opid = b.makeopid) MakeOPName," + "\r\n";
            SQL += "  (select count(*) from pro_washfull a where a.makeopid = b.makeopid) iCount" + "\r\n";
            SQL += " from pro_washfull b  " + "\r\n";
            SQL += " ) AA " + "\r\n";
            SQL += " WHERE 1=1 " + "\r\n";

            return SQL;
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "";
            this.HTDataList = gridView1;
            //gridView1.OptionsView.AllowCellMerge = true;
            
        }

        #endregion


        #region 其他事件
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQLCNo_EditValueChanged(object sender, EventArgs e)
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
       
        #endregion
      
    }
}