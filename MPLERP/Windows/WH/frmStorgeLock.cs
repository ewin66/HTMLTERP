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
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// �������
    /// </summary>
    public partial class frmStorgeLock : frmAPBaseUIRpt
    {
        public frmStorgeLock()
        {
            InitializeComponent();
        }

        #region ȫ�ֱ���
        int saveLockID = 0;
        private string saveBatch = string.Empty;
        private string saveVendorBatch = string.Empty;
        private string saveColorNum = string.Empty;
        private string saveColorName = string.Empty;
        private string saveJarNum = string.Empty;
        private string saveItemCode = string.Empty, saveItemName = string.Empty, saveItemStd = string.Empty, saveItemWHID;
        private string saveSectionID = string.Empty;
        private string saveSBitID = string.Empty;
        private string saveNeedle = string.Empty;
        private string saveDSN = string.Empty;
        private string saveSSN = string.Empty;
        //int saveWHTypeID = 0;       
        int saveStorgeID = 0;
        #endregion

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (SysConvert.ToString(drpQWHID.EditValue) != "")
            {
                tempStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
            }
            if (SysConvert.ToString(drpQWHTypeID.EditValue) != "")
            {
                tempStr += " AND WHTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQWHTypeID.EditValue));
            }
            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
          
            if (SysConvert.ToString(drpQItemCode.EditValue) != "")
            {
                tempStr += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(drpQItemCode.EditValue));
            }
            if (txtQItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            }
            if (txtQColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtQColorNum.Text.Trim() + "%");
            }
            if (txtQColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtQColorName.Text.Trim() + "%");
            }
            if (txtQJarNum.Text.Trim() != "")
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtQJarNum.Text.Trim() + "%");
            }
            if (txtQBatch.Text.Trim() != "")
            {
                tempStr += " AND Batch LIKE " + SysString.ToDBString("%" + txtQBatch.Text.Trim() + "%");
            }
            if (txtQVendorBatch.Text.Trim() != "")
            {
                tempStr += " AND VendorBatch LIKE " + SysString.ToDBString("%" + txtQVendorBatch.Text.Trim() + "%");
            }


            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            StorgeRule rule = new StorgeRule();

            DataTable dt = new DataTable();
            dt = rule.LKRShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
           
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();

        }


        /// <summary>
        /// ����������
        /// </summary>
        private void BindGridLockHis(string p_StorgeID)
        {
            StorgeLockHisRule rule = new StorgeLockHisRule();
            //gridView3.GridControl.DataSource=rule.RShow(" AND WHID="+SysString.ToDBString(p_WHID)+" AND ItemCode="+SysString.ToDBString(p_ItemCode),ProcessGrid.GetQueryField(gridView3));
            gridView3.GridControl.DataSource = rule.RShow(" AND StorgeID=" + SysString.ToDBString(p_StorgeID), ProcessGrid.GetQueryField(gridView3));
            gridView3.GridControl.Show();
        }
        /// <summary>
        /// ����������
        /// </summary>
        private void BindGridLock(string p_StorgeID)
        {
            StorgeLockRule rule = new StorgeLockRule();
            //gridView1.GridControl.DataSource=rule.RShow(" AND WHID="+SysString.ToDBString(p_WHID)+" AND ItemCode="+SysString.ToDBString(p_ItemCode),ProcessGrid.GetQueryField(gridView1));
            gridView2.GridControl.DataSource = rule.RShow(" AND StorgeID=" + SysString.ToDBString(p_StorgeID), ProcessGrid.GetQueryField(gridView2));
            gridView2.GridControl.Show();
        }

     


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_StorgeLock";
            this.HTDataList = gridView1;

            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2, gridView3 };


            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);

            gridViewBaseRowChangedA3 += new gridViewBaseRowChangedA(gridViewRowChanged3);
            gridViewBindEventA3(gridView2);

            //Common.BindVendor(drpQVendorID, "WH_StorgeLock", "VendorID", true);

            //Common.BindOP(drpOPID, "WH_StorgeLock", "LockOPID", true);

            Common.BindWHType(drpQWHTypeID, false);
            Common.BindWH(drpQWHID, true);
            new ItemProcLookUp(drpQItemCode, new int[] { 1 }, true, true);//(int)ItemType.ɴ��

            SetTabIndex(0, groupControlQuery);
        }
        /// <summary>
        /// ��������ʵ��1
        /// </summary>
        private void gridViewRowChanged2(object sender)
        {
            ColumnView view = sender as ColumnView;
            saveStorgeID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
            txtTotalQty.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Qty"]));
            txtTotalLockQty.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LockQty"]));
            txtLeftQty.Text = SysConvert.ToString(SysConvert.ToDecimal(txtTotalQty.Text.Trim()) - SysConvert.ToDecimal(txtTotalLockQty.Text.Trim()));
            saveItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ItemCode"]));
            saveItemName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ItemName"]));
            saveItemStd = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ItemStd"]));
            saveItemWHID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["WHID"]));
            saveBatch = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Batch"]));
            saveVendorBatch = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["VendorBatch"]));
            saveColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ColorNum"]));
            saveColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ColorName"]));
            saveJarNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["JarNum"]));
            //saveWHTypeID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["WHTypeID"]));
            saveSectionID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SectionID"]));
            saveSBitID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SBitID"]));
            saveNeedle = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Needle"]));
            BindGridLockHis(saveStorgeID.ToString());
            BindGridLock(saveStorgeID.ToString());
           
        }


        /// <summary>
        /// ��������ʵ��1
        /// </summary>
        private void gridViewRowChanged3(object sender)
        {
            ColumnView view = sender as ColumnView;
            txtLockQty.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LockQty"]));
            txtLockSO.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LockSO"]));
            txtRemark.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Remark"]));
            saveLockID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
            drpOPID.EditValue = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LockOPID"]));

        }

        #endregion

        #region ��ť�¼�
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLockStorge_Click(object sender, EventArgs e)
        {
            try
            {

                if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (saveStorgeID == 0)
                {
                    this.ShowMessage("���Ȳ�ѯҪ�����ļ�¼");
                    return;
                }
                if (SysConvert.ToFloat(txtLockQty.Text.Trim()) > SysConvert.ToFloat(txtLeftQty.Text.Trim()))
                {
                    this.ShowMessage("�����������ڵ�ǰ��ʹ������������ʵ�ֿ������");
                    return;
                }
                if (!NewCheckCorrect())
                {
                    return;
                }
                //if (!CheckCorrectLock())
                //{
                //    return;
                //}
                StorgeLockRule rule = new StorgeLockRule();
                StorgeLock entity = this.GetEntity();
                rule.RLock(entity, true);

                string tempwhid = saveItemWHID;
                string tempitemcode = saveItemCode;
                string tempStorgeID = saveStorgeID.ToString();
                BindGrid();
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { tempStorgeID });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelLock_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (saveLockID == 0)
                {
                    this.ShowMessage("���Ȳ�ѯҪ�����ļ�¼");
                    return;
                }

                if (DialogResult.Yes != ShowConfirmMessage("�������Ϊ���ɻָ�������ȷ��Ҫ�����"))
                {
                    return;
                }
                if (!NewCheckCorrect())
                {
                    return;
                }
                //if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.���1))//���������Ȩ��
                //{
                //    if (!CheckOPID(FParamConfig.LoginID, saveLockID))//�����ǲ��ǹ���Ա !Common.CheckAdmin(FParamConfig.LoginID) && !Common.CheckWHAdmin(FParamConfig.LoginID) && 
                //    {
                //        this.ShowMessage("�㲻�Ǹõ���ҵ��Ա�����ܲ����õ���");
                //        return;
                //    }
                //}
                if (SysConvert.ToDecimal(txtLockQty.Text.Trim()) > SysConvert.ToDecimal(txtTotalLockQty.Text.Trim()))
                {
                    this.ShowMessage("��������������������������ʧ��");
                    txtLockQty.Focus();
                    return;
                }
                StorgeLockRule rule = new StorgeLockRule();
                rule.RUnLock(saveLockID, SysConvert.ToDecimal(txtLockQty.Text.Trim()), txtRemark.Text.Trim(), true);

                string tempwhid = saveItemWHID;
                string tempitemcode = saveItemCode;
                string tempStorgeID = saveStorgeID.ToString();
                BindGrid();
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { tempStorgeID });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// У������
        /// </summary>
        /// <returns></returns>
        private bool NewCheckCorrect()
        {
            if (txtLockQty.Text.Trim() == "")
            {
                this.ShowMessage("��������������");
                txtLockQty.Focus();
                return false;
            }
            else if (!SysConvert.IsDecimal(txtLockQty.Text.Trim()))
            {
                this.ShowMessage("��������ȷ����������������");
                txtLockQty.Focus();
                return false;
            }
            else if (SysConvert.ToDecimal(txtLockQty.Text.Trim()) < 0)
            {
                this.ShowMessage("���������0����������");
                txtLockQty.Focus();
                return false;
            }
            //if (Common.CheckLookUpEditBlank(drpOPID))
            //{
            //    this.ShowMessage("��ѡ��ҵ��Ա");
            //    drpOPID.Focus();
            //    return false;
            //}
            //			if(txtLockSO.Text.Trim()=="")
            //			{
            //				this.ShowMessage("�����붩����");
            //				txtLockSO.Focus();
            //				return false;
            //			}
            return true;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private StorgeLock GetEntity()
        {
            StorgeLock entity = new StorgeLock();
            entity.ID = saveLockID;
            entity.SelectByID();
            entity.WHID = saveItemWHID;
            entity.ItemCode = saveItemCode;
            entity.ItemName = saveItemName;
            entity.ItemStd = saveItemStd;
            entity.LockSO = txtLockSO.Text.Trim();
            entity.LockQty = SysConvert.ToDecimal(txtLockQty.Text.Trim());
            entity.LockTime = DateTime.Now.Date;
            //ParamSetRule rule = new ParamSetRule();
            //if (this.FormListAID == (int)WHType.ɫɴ)
            //{
            //    entity.NeedDate = DateTime.Now.AddDays(rule.RShowInt((int)ParamSet.ɫɴ��������));
            //}
            //else if (this.FormListAID == (int)WHType.��ɴ)
            //{
            //    entity.NeedDate = DateTime.Now.AddDays(rule.RShowInt((int)ParamSet.��ɴ��������));
            //}
            entity.LockOPID = SysConvert.ToString(drpOPID.EditValue);
            entity.LockDesc = txtRemark.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            //entity.StorgeID = saveStorgeID;
            entity.Batch = saveBatch;
            entity.VendorBatch = saveVendorBatch;
            entity.ColorNum = saveColorNum;
            entity.ColorName = saveColorName;
            entity.JarNum = saveJarNum;
            //entity.DSN = saveDSN;
            //entity.SSN = saveSSN;
            return entity;
        }
        #endregion

    }
}