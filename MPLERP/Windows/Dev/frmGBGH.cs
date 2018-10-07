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
    /// ���ܣ��Ұ�������ѯ
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-20
    /// ����������
    /// </summary>
    public partial class frmGBGH : frmAPBaseUIRpt
    {
        public frmGBGH()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �ж�����
        /// 1.ɨ������
        /// 2.�ж��ǹ黹���ǳ����黹
        /// 3.���ǹ黹�����жϸ������Ƿ��д��ڽ��״̬������
        /// 4.��������µ��黹״̬
        /// 5.���ǳ����黹����
        /// 6.�ж�ɨ��������Ƿ���gridview1��
        /// 7.�粻�ڣ�����ʾ���ܳ���
        /// 8.���ڣ�����MainID���½������״̬
        /// </summary>
        public DataTable dtCode=null;

        int LYFlag = 0;
        #region �����¼�
        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGBGH_Load(object sender, EventArgs e)
        {
            try
            {
                Common.BindGBStatus(repGBStatus, true);

                txtScan.Focus();
                string sql = "SELECT *,'' ItemCode,'' ItemName,'' ItemStd,'' ItemModel,'' MWidth,'' MWeight,'' ColorNum,'' ColorName FROM Dev_GBJCDts WHERE 1=0";
                dtCode = SysUtils.Fill(sql);


                ProcessGrid.BindGridColumn(gridView1, this.FormID);//����				
                ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//������UI

                gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
                gridViewBindEventA1(gridView1);


                ProcessGrid.BindGridColumn(gridView2, this.FormID);//����				
                ProcessGrid.SetGridColumnUI(gridView2, FormListAID, FormListBID);//������UI
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region ɨ���¼�
        /// <summary>
        /// ����ɨ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string GBCode = txtScan.Text.Trim();
                    if (GBCode == "")
                    {
                        this.ShowMessage("��ɨ������");
                        return;
                    }

                    GBJCRule rule = new GBJCRule();
                    string sql = "SELECT * FROM Dev_GBJCDts WHERE GBCode=" + SysString.ToDBString(GBCode);
                    DataTable dt = new DataTable();
                    dt = SysUtils.Fill(sql);
                    if(dt.Rows.Count != 0)
                    {
                        if (SysConvert.ToDecimal(dt.Rows[0]["LYFlag"]) == 1)
                        {
                            this.ShowMessage("�˹Ұ�������");
                            //return;
                        }
                    }

                    LYFlag = SysConvert.ToInt32(dt.Rows[0]["LYFlag"]);             
                    //if (chkLY.Checked)
                    //{
                    //    LYFlag = 1;
                    //}
                    if (chkCancel.Checked)
                    {

                        if (!CheckCancelFind())
                        {
                            this.ShowMessage("���벻�����б��ڣ����ܳ����黹");
                            return;

                        }
                        if (!CheckCancelStatus(GBCode))
                        {
                            return;
                        }

                        //int MainID = GetGBMainID(GBCode);//���Ǵ���һ��δ�����һ���ύ���ݣ���ȡ��һ�е�MainID

                        //rule.RUpdate(GBCode, 0, MainID, LYFlag,FParamConfig.LoginID);
                        rule.RUpdate(GBCode, 0, -1, LYFlag, FParamConfig.LoginID); // 2013.12.26  sc
                        SetGridView1(GBCode);
                        ProcessGrid.GridViewFocus(gridView1, new string[1] { "GBCode" }, new string[1] { GBCode });
                        gridViewRowChanged1(gridView1);


                    }
                    else
                    {

                        if (!CheckJC())
                        {
                            return;
                        }
                        CreateDatable();
                        rule.RUpdate(GBCode, 1, -1, LYFlag, FParamConfig.LoginID);                       
                        gridViewRowChanged1(gridView1);


                    }

                    txtScan.Text = "";
                    txtScan.Focus();




                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �Զ��巽��



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        private void gridViewRowChanged1(object sender)
        {
            BaseFocusLabel.Focus();
            ColumnView view = sender as ColumnView;
            ProcessGrid.SetFormValue(this, view);
            int MainID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["MainID"]));
            string GBCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["GBCode"]));
            byte[] pic = GetPic(GBCode);
            if (pic != null)
            {
                img1.Image = TemplatePic.ByteToImage(pic);
            }
            else
            {
                img1.Image = null;
            }
            BindGrid2(MainID);
            GetItemLabel(GBCode);
        }

        private void GetItemLabel(string GBCode)
        {
            string sql = "SELECT * FROM UV1_Data_ItemGB WHERE GBCode=" + SysString.ToDBString(GBCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                lbItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                lbGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                lbVendorID.Text = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                lbColorNum.Text = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                lbColorName.Text = SysConvert.ToString(dt.Rows[0]["ColorName"]);
            }
        }
        /// <summary>
        /// ��������õ�ͼƬ
        /// </summary>
        /// <param name="p_Code"></param>
        /// <returns></returns>
        private byte[] GetPic(string p_Code)
        {
            string sql = "SELECT GBPic2 FROM Data_ItemGB WHERE GBCode=" + SysString.ToDBString(p_Code);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return (byte[])dt.Rows[0]["GBPic2"];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��GridView2
        /// </summary>
        /// <param name="MainID"></param>
        private void BindGrid2(int MainID)
        {
            string sql = "SELECT * FROM UV1_Dev_GBJCDts WHERE MainID="+SysString.ToDBString(MainID);
            sql += " AND GBStatusID="+SysString.ToDBString((int)EnumGBStatus.���);
            DataTable dt = SysUtils.Fill(sql);
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }
       

        private bool CheckCancelStatus(string p_Code)
        {
            string sql = "SELECT GBStatusID FROM Data_ItemGB WHERE GBCode="+SysString.ToDBString(p_Code);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                int GBStatusID = SysConvert.ToInt32(dt.Rows[0][0]);
                if (GBStatusID != (int)EnumGBStatus.�黹)
                {
                    this.ShowMessage("�Ұ�["+p_Code+"]�����ڹ黹״̬�����ܳ���");
                    return false;
                }
                return true;
            }
            return false;
        }

        private int GetGBMainID(string GBCode)
        {
             for (int i = 0; i < gridView1.RowCount; i++)
            {
                if(GBCode==SysConvert.ToString(gridView1.GetRowCellValue(i,"GBCode")))
                {
                    return SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID"));
                }

            }
            return 0;
        }

        /// <summary>
        /// �����黹��������
        /// </summary>
        /// <param name="GBCode"></param>
        private void SetGridView1(string GBCode)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if(GBCode==SysConvert.ToString(gridView1.GetRowCellValue(i,"GBCode")))
                {
                    gridView1.SetRowCellValue(i,"GBStatusID",(int)EnumGBStatus.���);
                    gridView1.SetRowCellValue(i,"GHTime",null);
                    gridView1.SetRowCellValue(i,"GHOPID","");
                }

            }
        }

        /// <summary>
        /// �����黹����ʱ�����֤
        /// </summary>
        /// <returns></returns>
        private bool CheckCancelFind()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode")) == txtScan.Text.Trim())
                {
                    
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// �黹����ʱ����֤
        /// </summary>
        /// <returns></returns>
        private bool CheckJC()
        {
            string sql = "SELECT JCTime FROM UV1_Dev_GBJCDts WHERE GBCode=" + SysString.ToDBString(txtScan.Text.Trim());
            sql += " AND GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.���);
            sql += " AND ISNULL(SubmitFlag,0)=1";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 0)
            {
                txtScan.Text = "";
                this.ShowMessage("�Ұ�:["+txtScan.Text.Trim()+"]û�д��ڽ��״̬�Ľ��������鿴");
                return false;
            }
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                txtScan.Text = "";
                this.ShowMessage("�Ұ�:[" + txtScan.Text.Trim() + "]����������쳣�������������ϵĴ��ڽ��״̬��ͬһ�Ұ壬��鿴");
                return false ;
            }
        }

        /// <summary>
        /// ����DataTable
        /// </summary>
        private void CreateDatable()
        {
            string[] ItemStr = GetItemStr(txtScan.Text.Trim());
            DataRow row = dtCode.NewRow();
            row["GBCode"] = txtScan.Text.Trim();
            row["GHTime"] = DateTime.Now.Date;
            row["GHOPID"] = FParamConfig.LoginID;
            row["MainID"]=GetMainID(txtScan.Text.Trim());
            row["JCTime"]=GetJCTime(txtScan.Text.Trim());
            row["GBStatusID"] = (int)EnumGBStatus.�黹;
            row["LYFlag"] = LYFlag;

            row["ItemCode"] = ItemStr[0];
            row["ItemName"] = ItemStr[1];
            row["ItemStd"] = ItemStr[2];
            row["ItemModel"] = ItemStr[3];
            row["MWidth"] = ItemStr[4];
            row["MWeight"] = ItemStr[5];
            row["ColorNum"] = ItemStr[6];
            row["ColorName"] = ItemStr[7];

            dtCode.Rows.Add(row);
            gridView1.GridControl.DataSource = dtCode;
            gridView1.GridControl.Show();
            ProcessGrid.GridViewFocus(gridView1, new string[1] { "GBCode" }, new string[1] { txtScan.Text.Trim() });

        }

        private string[] GetItemStr(string p_GBCode)
        {
            string[] ItemStr=new string[8];
            string sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel,MWidth,MWeight,ColorNum,ColorName FROM UV1_Data_ItemGB WHERE GBCode=" + SysString.ToDBString(p_GBCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                ItemStr[0] = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                ItemStr[1] = SysConvert.ToString(dt.Rows[0]["ItemName"]);
                ItemStr[2] = SysConvert.ToString(dt.Rows[0]["ItemStd"]);
                ItemStr[3] = SysConvert.ToString(dt.Rows[0]["ItemModel"]);
                ItemStr[4] = SysConvert.ToString(dt.Rows[0]["MWidth"]);
                ItemStr[5] = SysConvert.ToString(dt.Rows[0]["MWeight"]);
                ItemStr[6] = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                ItemStr[7] = SysConvert.ToString(dt.Rows[0]["ColorName"]);
            }
            return ItemStr;
        }

      


        /// <summary>
        /// �õ������ID
        /// </summary>
        /// <param name="p_Code"></param>
        /// <returns></returns>
        private int GetMainID(string p_Code)
        {
            string sql = "SELECT MainID FROM Dev_GBJCDts WHERE GBCode="+SysString.ToDBString(p_Code);
            sql += " AND GBStatusID="+SysString.ToDBString((int)EnumGBStatus.���);
            DataTable dt = SysUtils.Fill(sql);
            return SysConvert.ToInt32(dt.Rows[0]["MainID"]);
        }

        /// <summary>
        /// �õ����ʱ��
        /// </summary>
        /// <param name="p_Code"></param>
        /// <returns></returns>
        private DateTime GetJCTime(string p_Code)
        {
            string sql = "SELECT JCTime FROM Dev_GBJCDts WHERE GBCode=" + SysString.ToDBString(p_Code);
            sql += " AND GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.���);
            DataTable dt = SysUtils.Fill(sql);
            return SysConvert.ToDateTime(dt.Rows[0]["JCTime"]);
        }

      



        #endregion

        #region �Ұ������ӡ

        /// <summary>
        /// ��ӡ��������
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            string GBCodeStr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode")) != "")
                {
                    if (GBCodeStr != "")
                    {
                        GBCodeStr += ",";
                    }
                    GBCodeStr +=SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode")));
                }
            }

            if (GBCodeStr == "")
            {
                this.ShowMessage("û�й黹����");
                return false;
            }

            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return false;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 1)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return false;
            }

            string sql = "SELECT * FROM UV1_Data_ItemGB WHERE GBCode IN(" + GBCodeStr + ")";
            DataTable dt = SysUtils.Fill(sql);
            dt.Columns.Add("LYFlag",typeof(int));
            foreach (DataRow dr in dt.Rows)
            {
                sql = "SELECT LYFlag FROM UV1_Dev_GBJCDts WHERE GBCode="+SysString.ToDBString(dr["GBCode"].ToString());
                sql += " AND SubmitFlag=1 ";
                sql += " AND GBStatusID="+SysString.ToDBString((int)EnumGBStatus.�黹);
                sql += " ORDER BY GHTime,FormNo DESC ";
                DataTable dto = SysUtils.Fill(sql);
                if (dto.Rows.Count > 0)
                {
                    dr["LYFlag"] = SysConvert.ToInt32(dto.Rows[0][0]);
                }
                else
                {
                    dr["LYFlag"] = 0;
                }
            }
            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dt);
            return true;

           
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnPreview_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.Ԥ��);


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                base.btnPrint_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.��ӡ);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnDesign_Click(sender, e);
                btnPrintAbount((int)ReportPrintType.���);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

      




    }
}