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
    public partial class frmSampleSale : frmAPBaseUIForm
    {
        public frmSampleSale()
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
            //
            if (txtFormNo.Text.Trim() != "")
            {
                tempStr = " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpSampleType.EditValue)!="")
            {
                tempStr = " AND SampleType = " + SysString.ToDBString(SysConvert.ToString(drpSampleType.EditValue));
            }
            if (SysConvert.ToString(drpMakeOPID.EditValue) != "")
            {
                tempStr += "AND MakeOPID LIKE" + SysString.ToDBString("%" + SysConvert.ToString(drpMakeOPID.EditValue) + "%");
            }
            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            }
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            SampleSaleRule rule = new SampleSaleRule();
            gridView1.GridControl.DataSource=rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();

            //ProcessGrid.SetGridEdit(gridView1, new string[] { "FinishedFlag" }, true); 
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            SampleSaleRule rule = new SampleSaleRule();
            SampleSale entity = EntityGet();
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
        /// ��д��ʼ��֮��ķ���
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "FinishedFlag" }, true);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_SampleSale";
            this.HTDataList = gridView1;
            Common.BindOP(drpMakeOPID, true);
            Common.BindSampleType(drpSampleType, true);


            Common.BindSubmitFlag(drpGridSubmitFlag, true);

            txtMakeDateS.DateTime = DateTime.Now.AddDays(-15).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;



            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
        }
        

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SampleSale EntityGet()
        {
            SampleSale entity = new SampleSale();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        /// <summary>
        /// ��ѡ��ɱ�־
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkFinishedFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��0))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }




                this.BaseFocusLabel.Focus();

                if (SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SubmitFlag")) == 0)
                {                   
                    this.ShowMessage("�˵���δ�ύ,���ܹ�ѡ��ɣ�");
                    return;
                }



                string sql = "Update Sale_SampleSaleDts set FinishedFlag =" + SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FinishedFlag"));              
                sql += " Where ID = " + SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                SysUtils.ExecuteNonQuery(sql);
                MessageBox.Show("�޸ĳɹ���");

                BindGrid();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}