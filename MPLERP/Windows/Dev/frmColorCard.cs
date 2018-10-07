using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using HttSoft.WinUIBase;
using DevComponents.DotNetBar;

namespace MLTERP
{
    public partial class frmColorCard : frmAPBaseUIForm
    {
        public frmColorCard()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtFormNo.Text.Trim() !=  string .Empty)
            {
                tempStr += " and FormNO Like " + SysString.ToDBString("%" + txtFormNo.Text.Trim() +"%"); 
            }
            if (Convert.ToString( drpShopID.EditValue) != string.Empty)
            {
                tempStr += " and ShopID =  " + SysString.ToDBString(drpShopID.EditValue.ToString());
            }
            
            if(Convert.ToString( drpVendorID.EditValue) != string.Empty)
            {
                tempStr += " and VendorID = " + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            if (chkOrderDate.Checked)
            {
                tempStr += " and FormDate Between " + SysString.ToDBString(begintime.DateTime) + " and " + SysString.ToDBString(endtime.DateTime );
            }
            if (chkFinishFlag.Checked)
            {
                //tempStr += " AND FinishDate IS NOT NULL";
            }

            //
            tempStr += " AND SampleType = " + this.FormListAID;//1: L/D��    2��S/O��
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            ColorCardRule rule = new ColorCardRule();
            gridView1.GridControl.DataSource = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ColorCardRule rule = new ColorCardRule();
            ColorCard entity = EntityGet();
            rule.RDelete(entity);
        }
        
         /// <summary>
        /// ���ö�λ���ݼ�״̬
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_ColorCard";
            this.HTDataList = gridView1;
            begintime.DateTime = DateTime.Now.AddDays(-15).Date;
            endtime.DateTime = DateTime.Now.Date;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            Common.BindVendor(drpShopID, new int[] { (int)EnumVendorType.����, (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.�����ӹ���}, true);
            Common.BindOP(drpResScrapSampleNo, true);
            this.ToolBarItemAdd(32, "btnUpdateColorStatus", "�޸�ɫ��״̬", true, btnUpdateColorStatus_Click, eShortcut.None);
            if (ColorCardStatusProc.ColorIniFlag)
            {
                ucStatusBarStand1.UCDataSource = ColorCardStatusProc.ColorStatusDt;
                ucStatusBarStand1.UCAct();
            }

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// �޸�ɫ��״̬
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateColorStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("û�д�Ȩ�ޣ�����ϵ����Ա");
                    return;
                }
                //1: L/D��    2��S/D��
                if (this.FormListAID == 1)
                {
                    frmUpdateColorCardStatus frm = new frmUpdateColorCardStatus();
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.Location = new Point(400, 280);
                    frm.DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                    frm.ShowDialog();
                    btnQuery_Click(null, null);
                    ProcessGrid.GridViewFocus(gridView1, new string[1] { "DtsID" }, new string[1] { frm.DtsID.ToString() });
                }
                else if (this.FormListAID == 2)
                {
                    frmUpdateColorCardStatusSD frm = new frmUpdateColorCardStatusSD();
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.Location = new Point(400, 280);
                    frm.DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                    frm.ShowDialog();
                    btnQuery_Click(null, null);
                    ProcessGrid.GridViewFocus(gridView1, new string[1] { "DtsID" }, new string[1] { frm.DtsID.ToString() });
                }

                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ColorCard EntityGet()
        {
            ColorCard entity = new ColorCard();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion


        #region �����¼�


        /// <summary>
        /// ��ɫ�仯 ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void _HTDataDts_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                base._HTDataDts_RowCellStyle(sender, e);
                if (e.Column.FieldName == "ColorCardStatusName")
                {
                    e.Appearance.BackColor = ColorCardStatusProc.GetGridRowBackColor(SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "ColorCardStatusID")));
                }

                //if (e.Column.FieldName == "FormNo")
                //{
                //    if(SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle,"CapFlag"))==1)
                //    {
                //        e.Appearance.BackColor = Color.LightBlue;
                //    }
                //}

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

    }
}