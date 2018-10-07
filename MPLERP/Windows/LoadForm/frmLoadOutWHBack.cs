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
    public partial class frmLoadOutWHBack :BaseForm
    {
        public frmLoadOutWHBack()
        {
            InitializeComponent();
        }

        public string Condition2 = "";

        private int m_PackType;
        public int PackType
        {
            get
            {
                return m_PackType;
            }
            set
            {
                m_PackType = value;
            }
        }


        private int m_ID;
        public int ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        private string m_ItemCode;
        public string ItemCode
        {
            get
            {
                return m_ItemCode;
            }
            set
            {
                m_ItemCode = value;
            }
        }

        private string m_ColorNum;
        public string ColorNum
        {
            get
            {
                return m_ColorNum;
            }
            set
            {
                m_ColorNum = value;
            }
        }


        private string m_ColorName;
        public string ColorName
        {
            get
            {
                return m_ColorName;
            }
            set
            {
                m_ColorName = value;
            }
        }

        private string m_WHID;
        public string WHID
        {
            get
            {
                return m_WHID;
            }
            set
            {
                m_WHID = value;
            }
        }



        
        private void frmLoadPack_Load(object sender, EventArgs e)
        {
            try
            {

                CreateCheckBox();
             
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        private void CreateCheckBox()
        {
            //查询条件
            string condition = "";
            if (m_WHID != "")
            {
                condition += " AND WHID=" + SysString.ToDBString(m_WHID);
            }
            condition += " AND ItemCode=" + SysString.ToDBString(m_ItemCode);
            condition += " AND ColorNum=" + SysString.ToDBString(m_ColorNum);
            condition += " AND ColorName=" + SysString.ToDBString(m_ColorName);
            condition += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.入库);
            condition += Condition2;

            //分区，缸号，批次
            string sql = "SELECT SectionID,JarNum,Batch FROM WH_PackBox ";
            sql += "WHERE 1=1 ";
            sql += condition;
            sql += " GROUP BY SectionID,JarNum,Batch";
            DataTable dtitemtype = SysUtils.Fill(sql);
            int XSIZE = 10;
            int YSIZE = 10;
            for (int i = 0; i < dtitemtype.Rows.Count; i++)
            {

                XSIZE = 10;
                string Context =SysConvert.ToInt32(i + 1).ToString()+ "、区：" + SysConvert.ToString(dtitemtype.Rows[i]["SectionID"]) + "、缸号：" + SysConvert.ToString(dtitemtype.Rows[i]["JarNum"]) + "、批次：" + SysConvert.ToString(dtitemtype.Rows[i]["Batch"]);
                string Name = SysConvert.ToInt32(i + 1).ToString();
                DevExpress.XtraEditors.CheckEdit chk = new DevExpress.XtraEditors.CheckEdit();
                groupControlMainten.Controls.Add(chk);
                chk.Location = new System.Drawing.Point(XSIZE, YSIZE);
                chk.Properties.Caption = Context;
                chk.Size = new System.Drawing.Size(320, 19);
                chk.Name = Name;
                chk.ForeColor = System.Drawing.Color.Black;
                chk.Tag = SysConvert.ToInt32(i + 1).ToString();
                chk.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(100)));

                DevExpress.XtraEditors.CheckEdit chkAll = new DevExpress.XtraEditors.CheckEdit();
                groupControlMainten.Controls.Add(chkAll);
                chkAll.Location = new System.Drawing.Point(XSIZE + 330, YSIZE);
                chkAll.Properties.Caption = "全选";
                chkAll.Size = new System.Drawing.Size(60, 19);
                chkAll.CheckedChanged += new System.EventHandler(chkAll_CheckedChanged);
                chkAll.Name = Name + "chk";
                chkAll.ForeColor = System.Drawing.Color.Black;
                chkAll.Tag = SysConvert.ToInt32(i + 1).ToString();
                chkAll.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(100)));

                //创建合计匹数/数量
                Label lbl = new Label();
                groupControlMainten.Controls.Add(lbl);
                lbl.Size = new System.Drawing.Size(150, 19);
                lbl.Location = new System.Drawing.Point(XSIZE + 450, YSIZE);
                lbl.Text = "";
                lbl.Name = "Label" + SysConvert.ToInt32(i + 1).ToString();
                lbl.ForeColor = System.Drawing.Color.Black;
                lbl.Tag = SysConvert.ToInt32(i + 1).ToString();
                lbl.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(100)));

                //创建选择匹数/数量
                Label lbl2 = new Label();
                groupControlMainten.Controls.Add(lbl2);
                lbl2.Size = new System.Drawing.Size(150, 19);
                lbl2.Location = new System.Drawing.Point(XSIZE + 600, YSIZE);
                lbl2.Text = "";
                lbl2.Name = "Label" + SysConvert.ToInt32(i + 1).ToString();
                lbl2.ForeColor = System.Drawing.Color.Black;
                lbl2.Tag = SysConvert.ToInt32(i + 1).ToString() + "lbl";
                lbl2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(100)));



                sql = "SELECT ID,Qty FROM WH_PackBox WHERE ISNULL(JarNum,'')=" + SysString.ToDBString(SysConvert.ToString(dtitemtype.Rows[i]["JarNum"]));
                sql += " AND ISNULL(Batch,'')=" + SysString.ToDBString(SysConvert.ToString(dtitemtype.Rows[i]["Batch"]));
                sql += " AND ISNULL(SectionID,'')=" + SysString.ToDBString(SysConvert.ToString(dtitemtype.Rows[i]["SectionID"]));
                sql += condition;
                DataTable dtsql = SysUtils.Fill(sql);
                int Num = 0;
                if (dtsql.Rows.Count <= 10)
                {
                    Num = 1;
                }
                else
                {
                    if (dtsql.Rows.Count % 10 == 0)
                    {
                        Num = dtsql.Rows.Count / 10;

                    }
                    else
                    {
                        Num = (dtsql.Rows.Count / 10) + 1;
                    }
                }

                int ToolTip = 0;
                int PieceQty = 0;
                decimal Qty = 0;
                for (int j = 0; j < Num; j++)
                {
                    XSIZE = 50;
                    YSIZE = YSIZE + 25;
                    for (int k = 1; k <= 10; k++)
                    {

                        int Index = k + j * 10;
                        if (Index <= dtsql.Rows.Count)
                        {
                            DataRow dr = dtsql.Rows[Index - 1];
                            DevExpress.XtraEditors.CheckEdit chk2 = new DevExpress.XtraEditors.CheckEdit();
                            groupControlMainten.Controls.Add(chk2);
                            chk2.Location = new System.Drawing.Point(XSIZE, YSIZE);
                            chk2.Properties.Caption = "" + SysConvert.ToInt32(ToolTip + 1).ToString() + ">" + SysConvert.ToString(dr["Qty"]);
                            chk2.Size = new System.Drawing.Size(82, 19);
                            chk2.CheckedChanged += new System.EventHandler(chk2_CheckedChanged);
                            chk2.Name = SysConvert.ToInt32(dr["ID"]).ToString();
                            chk2.Tag = SysConvert.ToInt32(i + 1);
                            chk2.ToolTip = ToolTip.ToString();
                            chk2.ForeColor = System.Drawing.Color.Black;
                            XSIZE = XSIZE + 80;

                            ToolTip++;
                            PieceQty++;
                            Qty += SysConvert.ToDecimal(dr["Qty"]);
                        }

                    }
                }

                lbl.Text = "合计：" + PieceQty.ToString() + " / " + Qty.ToString();
                YSIZE = YSIZE + 35;
            }





        }


        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                foreach (Control c in groupControlMainten.Controls)
                {
                    if (c is DevExpress.XtraEditors.CheckEdit)
                    {

                        if (((DevExpress.XtraEditors.CheckEdit)c).Tag.ToString() == chk.Tag.ToString())
                        {
                            ((DevExpress.XtraEditors.CheckEdit)c).Checked = chk.Checked;
                        }
                        
                       
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        /// <summary>
        /// 子节点选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                #region shift选择

                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                bool Find = false;
                int firstRow = 0;
                int endRow = 0;
                foreach (Control c in groupControlMainten.Controls)
                {
                    if (c is DevExpress.XtraEditors.CheckEdit)
                    {
                        if (((DevExpress.XtraEditors.CheckEdit)c).Checked && ((DevExpress.XtraEditors.CheckEdit)c).ToolTip != chk.ToolTip)
                        {
                            firstRow = SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).ToolTip);
                            Find = true;
                            break;
                        }
                    }
                }

                foreach (Control c in groupControlMainten.Controls)
                {
                    if (c is DevExpress.XtraEditors.CheckEdit)
                    {
                        if (((DevExpress.XtraEditors.CheckEdit)c).Checked && ((DevExpress.XtraEditors.CheckEdit)c).ToolTip != chk.ToolTip)
                        {
                            endRow = SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).ToolTip);
                        }
                    }
                }

                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && Find)
                {
                    int RID1 = 0;
                    int RID2 = 0;

                    if (chk.Checked)
                    {
                        if (firstRow > SysConvert.ToInt32(chk.ToolTip))
                        {
                            RID1 = SysConvert.ToInt32(chk.ToolTip);
                            RID2 = firstRow;
                        }
                        else
                        {
                            RID1 = firstRow;
                            RID2 = SysConvert.ToInt32(chk.ToolTip);
                        }
                        foreach (Control c in groupControlMainten.Controls)
                        {
                            if (c is DevExpress.XtraEditors.CheckEdit)
                            {
                                if (SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).ToolTip) >= RID1 && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).ToolTip) <= RID2
                                    && ((DevExpress.XtraEditors.CheckEdit)c).Tag.ToString() == chk.Tag.ToString() && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name) > 100)
                                {
                                    ((DevExpress.XtraEditors.CheckEdit)c).Checked = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (endRow > SysConvert.ToInt32(chk.ToolTip))
                        {
                            RID1 = SysConvert.ToInt32(chk.ToolTip);
                            RID2 = endRow;
                        }
                        else
                        {
                            RID1 = endRow;
                            RID2 = SysConvert.ToInt32(chk.ToolTip);
                        }
                        foreach (Control c in groupControlMainten.Controls)
                        {
                            if (c is DevExpress.XtraEditors.CheckEdit)
                            {
                                if (SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).ToolTip) >= RID1 && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).ToolTip) <= RID2
                                    && ((DevExpress.XtraEditors.CheckEdit)c).Tag.ToString() == chk.Tag.ToString() && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name) > 100)
                                {
                                    ((DevExpress.XtraEditors.CheckEdit)c).Checked = false;
                                }
                            }
                        }
                    }
                }

                #endregion

                #region 显示选择的匹数和数量

                int PieceQty = 0;
                decimal Qty = 0;
                foreach (Control c in groupControlMainten.Controls)
                {
                    if (c is DevExpress.XtraEditors.CheckEdit && ((DevExpress.XtraEditors.CheckEdit)c).Tag != null)
                    {
                        if (((DevExpress.XtraEditors.CheckEdit)c).Tag.ToString() == chk.Tag.ToString() && ((DevExpress.XtraEditors.CheckEdit)c).Checked && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name) > 100)
                        {
                            PieceQty++;
                            string[] TQty = ((DevExpress.XtraEditors.CheckEdit)c).Text.Split('>');
                            Qty += SysConvert.ToDecimal(TQty[1]);


                        }
                    }
                }

                foreach (Control c in groupControlMainten.Controls)
                {
                    if (c is Label && ((Label)c).Tag != null)
                    {
                        if (((Label)c).Tag.ToString() == chk.Tag.ToString() + "lbl")
                        {
                            ((Label)c).Text = "  选择：" + PieceQty.ToString() + " / " + Qty.ToString();
                        }
                    }
                }

                #endregion

                #region 如有一个选择，则父节点勾上

                if (PieceQty > 0)
                {
                    foreach (Control c in groupControlMainten.Controls)
                    {
                        if (c is DevExpress.XtraEditors.CheckEdit && ((DevExpress.XtraEditors.CheckEdit)c).Tag != null && !((DevExpress.XtraEditors.CheckEdit)c).Name.Contains("chk"))
                        {
                            if (((DevExpress.XtraEditors.CheckEdit)c).Tag.ToString() == chk.Tag.ToString() && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name) < 100)
                            {
                                ((DevExpress.XtraEditors.CheckEdit)c).Checked = true;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Control c in groupControlMainten.Controls)
                    {
                        if (c is DevExpress.XtraEditors.CheckEdit && ((DevExpress.XtraEditors.CheckEdit)c).Tag != null && !((DevExpress.XtraEditors.CheckEdit)c).Name.Contains("chk"))
                        {
                            if (((DevExpress.XtraEditors.CheckEdit)c).Tag.ToString() == chk.Tag.ToString() && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name) < 100)
                            {
                                ((DevExpress.XtraEditors.CheckEdit)c).Checked = false;
                            }
                        }
                    }
                }
                #endregion



                if (chk.Checked)
                {
                    chk.ForeColor = System.Drawing.Color.White;

                }
                else
                {
                    chk.ForeColor = System.Drawing.Color.Black;
                }





            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }


        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string IDText = "";
                foreach (Control c in groupControlMainten.Controls)
                {
                    if (c is DevExpress.XtraEditors.CheckEdit)
                    {
                        if (((DevExpress.XtraEditors.CheckEdit)c).Checked && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name) >100)
                        {
                            if (IDText != "")
                            {
                                IDText += ",";
                            }
                            IDText += SysConvert.ToString(((DevExpress.XtraEditors.CheckEdit)c).Name);
                        }
                    }
                }
             

                if (m_PackType == (int)EnumPackType.仓库单据)
                {
                    IOFormDtsPackRule rul = new IOFormDtsPackRule();
                    rul.RAdd(m_ID, IDText);
                }
                else
                {
                    FHFormDtsPackRule rul = new FHFormDtsPackRule();
                    rul.RAdd(m_ID, IDText);
                }

                this.ShowInfoMessage("已保存");
                this.Close();

                

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnKP_Click(object sender, EventArgs e)
        {
            try
            {
                int Num = 0;
                int ID = 0;
                foreach (Control c in groupControlMainten.Controls)
                {
                    if (c is DevExpress.XtraEditors.CheckEdit &&SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name)>100 )
                    {
                        if (((DevExpress.XtraEditors.CheckEdit)c).Checked)
                        {
                            Num++;
                            ID = SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name);
                        }
                    }
                }

                if (Num > 1 || Num == 0)
                {
                    this.ShowMessage("请选择一条需要开匹的信息！");
                    return;
                }
                frmKPEdit frm = new frmKPEdit();
                frm.ID = ID;
                frm.ShowDialog();
                groupControlMainten.Controls.Clear();
                CreateCheckBox();
               
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                frmSelect frm = new frmSelect();
                frm.ShowDialog();
                Condition2 = frm.Condition;
                groupControlMainten.Controls.Clear();
                CreateCheckBox();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



        



      






    }
}