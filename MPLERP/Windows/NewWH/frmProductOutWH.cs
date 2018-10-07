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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmProductOutWH : frmAPBaseUIForm
    {
        #region 全局变量
        //多线程
        BackgroundWorker work;
        //时间控件
        System.Windows.Forms.Timer timer = new Timer();
        //GridView绑定用的Table
        DataTable GridView1Table = new DataTable();
        //时间
        public int StartM { get; set; }

        int ID = 0;
        #endregion
        public frmProductOutWH()
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
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (txtQItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND  ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtQItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtQItemModel.Text.Trim() + "%");
            }
            if (txtItemStd.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtItemStd.Text.Trim() + "%");
            }
            if (txtQJarNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtQJarNum.Text.Trim() + "%");
            }
            if (txtQColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtQColorNum.Text.Trim() + "%");
            }
            if (txtQColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtQColorName.Text.Trim() + "%");
            }
            if (txtDtsOrderFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND InOrderFormNo LIKE " + SysString.ToDBString("%" + txtDtsOrderFormNo.Text.Trim() + "%");
            }

            if (txtVendorAttn.Text.Trim() != string.Empty)
            {
                tempStr += " AND VendorAttn LIKE " + SysString.ToDBString("%" + txtVendorAttn.Text.Trim() + "%");
            }

            if (chkOrderDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtQFormDateS.DateTime) + " AND " + SysString.ToDBString(txtQFormDateE.DateTime);
            }



            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }


            if (txtQBoxNo.Text.Trim() != string.Empty)//条码查询
            {
                tempStr += " AND ID in(select MainID from WH_IOFormDtsPack where BoxNo =" + SysString.ToDBString(txtQBoxNo.Text.Trim()) + ")";
            }


            if (SysConvert.ToString(drpSubType.EditValue) != string.Empty)
            {
                tempStr += " AND SubType=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
            }
            if (this.FormListAID != 0)
            {
                tempStr += " AND HeadType=" + this.FormListAID;
            }


            tempStr += Common.GetWHRightCondition();


            tempStr += " ORDER BY FormDate DESC,ID DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            if (!work.IsBusy)
            {
                timer1.Start();
                work.RunWorkerAsync();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
            rule.RDelete(entity);
        }

        ///// <summary>
        ///// 设置定位数据及状态
        ///// </summary>
        ///// <param name="p_ID">ID</param>
        //public override void SetPosStatus(int p_ID)
        //{
        //    int tempID = HTDataID;
        //    BindGrid();
        //    ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        //}


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView1;
            this.HTQryContainer = groupControlQuery;
            this.IsPostBack = false;
            txtQFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtQFormDateE.DateTime = DateTime.Now.Date;
            Common.BindSubType(drpSubType, this.FormListAID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂 }, true);
            new VendorProc(drpVendorID);
            
            work = new BackgroundWorker();
            work.DoWork += new DoWorkEventHandler(work_DoWork);
            work.RunWorkerCompleted += new RunWorkerCompletedEventHandler(work_RunWorkerCompleted);
        }
        public override void ToolIniCreateBar()
        {
            base.ToolIniCreateBar();
            this.ToolBarItemAdd(26, "btnLoadYY", "已阅", true, btnLoadYY_Click);
            this.ToolBarItemAdd(29, "btnLoadFJF", "附加费", true, btnLoadFJF_Click);
            this.ToolBarLItemAdd(ToolButtonName.lblFormStatus.ToString(), Color.Red);
        }
        void work_DoWork(object sender, DoWorkEventArgs e)
        {
            IOFormRule rule = new IOFormRule();
            GridView1Table = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
        }
        void work_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StartM = 0;
            timer1.Stop();
            gridView1.GridControl.DataSource = GridView1Table;
            gridView1.GridControl.Show();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { ID.ToString() });
            LabelItem label = this.ToolBarLItemGet(-1, ToolButtonName.lblFormStatus.ToString());
            label.Text = "查询结束";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            StartM++;
            LabelItem label = this.ToolBarLItemGet(-1, ToolButtonName.lblFormStatus.ToString());
            label.Text = "查询开始，分析数据需要几分钟，请耐心等待。。。。已经用时" + StartM + "S";
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            return entity;
        }


        #endregion
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnQuery_Click(object sender, EventArgs e)
        {
            base.btnQuery_Click(sender, e);
        }

        public  void btnLoadYY_Click(object sender, EventArgs e)
        {
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))
            {
                this.ShowMessage("没有此权限，请联系管理员");
                return;
            }
            int row = gridView1.FocusedRowHandle;
            ButtonItem btn = (ButtonItem)sender;
            IOFormRule rule = new IOFormRule();
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            entity.SelectByID();
            if (btn.Text == "撤销已阅")
            {
                if (entity.ReadFlag == 0)
                {
                    this.ShowMessage("该出库单还未阅，无需撤销");
                    return;
                }
                entity.ReadFlag = 0;
                rule.RUpdate(entity);
            }
            if (btn.Text == "已阅")
            {
                if (entity.ReadFlag == 1)
                {
                    this.ShowMessage("该出库单已阅，无需再阅");
                    return;
                }
                entity.ReadFlag = 1;
                rule.RUpdate(entity);
            }
            ID = entity.ID;
            btnQuery_Click(null, null);

        }
        public override void gridViewRowChanged1(object sender)
        {
            base.gridViewRowChanged1(sender);
            int ReadFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ReadFlag"));
            if (ReadFlag == 1)
            {
                this.ToolBarItemSet(-1, "btnLoad", "撤销已阅", true, 27);
            }
            else
            {
                this.ToolBarItemSet(-1, "btnLoad", "已阅", true, 26);
            }
        }
        public void btnLoadFJF_Click(object sender, EventArgs e)
        {
            string OrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FormNo"));
            string VendorID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VendorID"));
            if (OrderFormNo == "")
            {
                this.ShowMessage("请先选择一条出库单");
                return;
            }
            frmWHfrmPayment frm = new frmWHfrmPayment();
            frm.OrderFormNo = OrderFormNo;
            frm.VendorID = VendorID;
            frm.ShowDialog();
        }
        public override void _HTDataDts_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //base._HTDataDts_RowCellStyle(sender, e);
            if (SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "ReadFlag")) == 1)
            {
                e.Appearance.BackColor = Color.Pink;
            }
        }
    }
}
