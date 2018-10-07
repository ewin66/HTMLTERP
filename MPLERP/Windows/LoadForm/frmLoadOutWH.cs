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
    /// ���ܣ�����ϸ���������
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-5-12
    /// </summary>
    public partial class frmLoadOutWH : BaseForm
    {
        public frmLoadOutWH()
        {
            InitializeComponent();
        }

        #region ����
        /// <summary>
        /// �����־
        /// </summary>
        bool m_SaveFlag = false;
        /// <summary>
        /// �����־
        /// </summary>
        public bool SaveFlag
        {
            get
            {
                return m_SaveFlag;
            }
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


        private int m_IOFormID = 0;
        public int IOFormID
        {
            get
            {
                return m_IOFormID;
            }
            set
            {
                m_IOFormID = value;
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


        private string m_JarNum;
        public string JarNum
        {
            get
            {
                return m_JarNum;
            }
            set
            {
                m_JarNum = value;
            }
        }

        private string m_Batch;
        public string Batch
        {
            get
            {
                return m_Batch;
            }
            set
            {
                m_Batch = value;
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


        private string m_SectionID;
        public string SectionID
        {
            get
            {
                return m_SectionID;
            }
            set
            {
                m_SectionID = value;
            }
        }

        private string m_SBitID;
        public string SBitID
        {
            get
            {
                return m_SBitID;
            }
            set
            {
                m_SBitID = value;
            }
        }

        private int m_WHType;
        public int WHType
        {
            get
            {
                return m_WHType;
            }
            set
            {
                m_WHType = value;
            }
        }


        /// <summary>
        /// ��ƥ��ť��־
        /// </summary>
        private bool m_KPButtonFlag;

        /// <summary>
        /// ��ƥ��ť��־
        /// </summary>
        public bool KPButtonFlag
        {
            get
            {
                return m_KPButtonFlag;
            }
            set
            {
                m_KPButtonFlag = value;
            }
        }
        private string m_OrderFormNo;
        public string OrderFormNo
        {
            get
            {
                return m_OrderFormNo;
            }
            set
            {
                m_OrderFormNo = value;
            }
        }
        #endregion
        #region �Զ��巽��
        /// <summary>
        /// �������Դ
        /// </summary>
        /// <returns></returns>
        DataTable GetDataSource()
        {
            string sql = string.Empty;
            //��ѯ����
            string condition = "";
            if (m_WHID != "")
            {
                condition += " AND WHID=" + SysString.ToDBString(m_WHID);
            }

            if (m_SectionID != "")
            {
                condition += " AND SectionID=" + SysString.ToDBString(m_SectionID);
            }
            if (m_SBitID != "")
            {
                condition += " AND SBitID=" + SysString.ToDBString(m_SBitID);
            }
            condition += " AND ItemCode=" + SysString.ToDBString(m_ItemCode);

            condition += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.���);

            condition += " AND OrderFormNo=" + SysString.ToDBString(m_OrderFormNo);



            //if (m_WHType == (int)EnumWHType.���ϲֿ�)
            //{
            condition += " AND ColorNum=" + SysString.ToDBString(m_ColorNum);
            condition += " AND ColorName=" + SysString.ToDBString(m_ColorName);
            //}
            //else //����ɫ����ɫ������
            //{ 

            //}

            if (radgSearchType.SelectedIndex == 0)//���׺�����
            {
                if (m_Batch != string.Empty)
                {
                    condition += " AND Batch=" + SysString.ToDBString(m_Batch);
                }
                if (m_JarNum != string.Empty)
                {
                    condition += " AND JarNum=" + SysString.ToDBString(m_JarNum);
                }
            }
            else if (radgSearchType.SelectedIndex == 1)//����ɫ��������
            {
            }

            condition += Condition2;
            sql = "SELECT  0 SelectFlag,ID, SubSeq,0 SelectFlag,BoxNo,Qty,Weight,Yard,GoodsLevel,'' ItemModel, JarNum,Batch FROM WH_PackBox WHERE 1=1";//KPFlag��ʱ����ƥ�ţ�Ҫ�޸Ĵ���   ��zfc��2014.10.17���������SubSeq�ֶ�
            sql += condition;
            sql += " ORDER BY SectionID,Batch,JarNum";//ȱ��ƥ��

            DataTable dt = SysUtils.Fill(sql);//���п�ѡ�뵥����

            //��ѯ��ѡ�뵥����
            if (PackType == (int)EnumPackType.�ֿⵥ��)
            {
                sql = "SELECT BoxNo FROM WH_IOFormDtsPack WHERE MainID=" + IOFormID;
            }
            else if (PackType == (int)EnumPackType.��������)
            {
                sql = "SELECT BoxNo FROM Sale_FHFormDtsPack WHERE MainID=" + IOFormID;
            }
            else if (PackType == (int)EnumPackType.���ϵ���)
            {
                sql = "SELECT BoxNo FROM WO_FabricWHOutFormDtsPack WHERE MainID=" + IOFormID;
            }
            else if (PackType == (int)EnumPackType.��������)
            {
                sql = "SELECT BoxNo FROM WH_DBFormDtsPack WHERE MainID=" + IOFormID;
            }
            DataTable dtSelect = SysUtils.Fill(sql);
            string isnSelect = string.Empty;
            for (int i = 0; i < dtSelect.Rows.Count; i++)
            {
                if (isnSelect != string.Empty)
                {
                    isnSelect += ",";
                }
                isnSelect += SysString.ToDBString(dtSelect.Rows[i]["BoxNo"].ToString());
            }
            if (isnSelect != string.Empty)//�������ѡ
            {
                DataRow[] drA = dt.Select("BoxNo IN(" + isnSelect + ")");
                for (int i = 0; i < drA.Length; i++)//����ѡ����ı��־
                {
                    drA[i]["SelectFlag"] = 1;
                }
            }
            return dt;
        }

        /// <summary>
        /// ��ʼ��¼��ؼ�
        /// </summary>
        void IniFabLoad()
        {


            DataTable dt = GetDataSource();

            ucFabLoad1.UCDataSource = dt;
            ucFabLoad1.UCAllowKPFlag = KPButtonFlag;
            if (KPButtonFlag)
            {
                ucFabLoad1.UCEventKPClick += new HttSoft.UCFab.UCFabSelectCancel(EventKPClick);
            }
            ucFabLoad1.UCAct();
        }




        /// <summary>
        /// ��ƥ�¼�����ί�е���
        /// </summary>
        /// <param name="p_ISN"></param>
        void EventKPClick(string p_ISN)
        {
            //this.ShowMessage(p_ISN+" TOP ");

            try
            {
                if (p_ISN == string.Empty)
                {
                    this.ShowMessage("��ѡ��һ����Ҫ��ƥ����Ϣ��");
                    return;
                }
                frmKPEdit frm = new frmKPEdit();
                frm.ISN = p_ISN;
                frm.ShowDialog();
                if (frm.KPFinishFlag)
                {
                    ucFabLoad1.UCActKP(GetDataSource());//ִ�п�ƥ��滭
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion


        #region �����¼�
        /// <summary>
        /// ��������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLoadPack_Load(object sender, EventArgs e)
        {
            try
            {
                IniFabLoad();
                //if (KPButtonFlag)
                //{
                //    btnKP.Visible = true;
                //}
                //CreateCheckBox();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }
        #endregion


        #region drop Code

        //private void CreateCheckBox()
        //{
        //    //��ѯ����
        //    string condition = "";
        //    if (m_WHID != "")
        //    {
        //        condition += " AND WHID=" + SysString.ToDBString(m_WHID);
        //    }
        //    condition += " AND ItemCode=" + SysString.ToDBString(m_ItemCode);
        //    condition += " AND ColorNum=" + SysString.ToDBString(m_ColorNum);
        //    condition += " AND ColorName=" + SysString.ToDBString(m_ColorName);
        //    condition += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.���);
        //    condition += Condition2;

        //    //�������׺ţ�����
        //    string sql = "SELECT SectionID,JarNum,Batch FROM WH_PackBox ";
        //    sql += "WHERE 1=1 ";
        //    sql += condition;
        //    sql += " GROUP BY SectionID,JarNum,Batch";
        //    DataTable dtitemtype = SysUtils.Fill(sql);
        //    int XSIZE = 10;
        //    int YSIZE = 10;
        //    for (int i = 0; i < dtitemtype.Rows.Count; i++)
        //    {

        //        XSIZE = 10;
        //        string Context =SysConvert.ToInt32(i + 1).ToString()+ "������" + SysConvert.ToString(dtitemtype.Rows[i]["SectionID"]) + "���׺ţ�" + SysConvert.ToString(dtitemtype.Rows[i]["JarNum"]) + "�����Σ�" + SysConvert.ToString(dtitemtype.Rows[i]["Batch"]);
        //        string Name = SysConvert.ToInt32(i + 1).ToString();
        //        DevExpress.XtraEditors.CheckEdit chk = new DevExpress.XtraEditors.CheckEdit();
        //        groupControlMainten.Controls.Add(chk);
        //        chk.Location = new System.Drawing.Point(XSIZE, YSIZE);
        //        chk.Properties.Caption = Context;
        //        chk.Size = new System.Drawing.Size(320, 19);
        //        chk.Name = Name;
        //        chk.ForeColor = System.Drawing.Color.Black;
        //        chk.Tag = SysConvert.ToInt32(i + 1).ToString();
        //        chk.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(100)));

        //        DevExpress.XtraEditors.CheckEdit chkAll = new DevExpress.XtraEditors.CheckEdit();
        //        groupControlMainten.Controls.Add(chkAll);
        //        chkAll.Location = new System.Drawing.Point(XSIZE + 330, YSIZE);
        //        chkAll.Properties.Caption = "ȫѡ";
        //        chkAll.Size = new System.Drawing.Size(60, 19);
        //        chkAll.CheckedChanged += new System.EventHandler(chkAll_CheckedChanged);
        //        chkAll.Name = Name + "chk";
        //        chkAll.ForeColor = System.Drawing.Color.Black;
        //        chkAll.Tag = SysConvert.ToInt32(i + 1).ToString();
        //        chkAll.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(100)));

        //        //�����ϼ�ƥ��/����
        //        Label lbl = new Label();
        //        groupControlMainten.Controls.Add(lbl);
        //        lbl.Size = new System.Drawing.Size(150, 19);
        //        lbl.Location = new System.Drawing.Point(XSIZE + 450, YSIZE);
        //        lbl.Text = "";
        //        lbl.Name = "Label" + SysConvert.ToInt32(i + 1).ToString();
        //        lbl.ForeColor = System.Drawing.Color.Black;
        //        lbl.Tag = SysConvert.ToInt32(i + 1).ToString();
        //        lbl.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(100)));

        //        //����ѡ��ƥ��/����
        //        Label lbl2 = new Label();
        //        groupControlMainten.Controls.Add(lbl2);
        //        lbl2.Size = new System.Drawing.Size(150, 19);
        //        lbl2.Location = new System.Drawing.Point(XSIZE + 600, YSIZE);
        //        lbl2.Text = "";
        //        lbl2.Name = "Label" + SysConvert.ToInt32(i + 1).ToString();
        //        lbl2.ForeColor = System.Drawing.Color.Black;
        //        lbl2.Tag = SysConvert.ToInt32(i + 1).ToString() + "lbl";
        //        lbl2.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(100)));



        //        sql = "SELECT ID,Qty FROM WH_PackBox WHERE ISNULL(JarNum,'')=" + SysString.ToDBString(SysConvert.ToString(dtitemtype.Rows[i]["JarNum"]));
        //        sql += " AND ISNULL(Batch,'')=" + SysString.ToDBString(SysConvert.ToString(dtitemtype.Rows[i]["Batch"]));
        //        sql += " AND ISNULL(SectionID,'')=" + SysString.ToDBString(SysConvert.ToString(dtitemtype.Rows[i]["SectionID"]));
        //        sql += condition;
        //        DataTable dtsql = SysUtils.Fill(sql);
        //        int Num = 0;
        //        if (dtsql.Rows.Count <= 10)
        //        {
        //            Num = 1;
        //        }
        //        else
        //        {
        //            if (dtsql.Rows.Count % 10 == 0)
        //            {
        //                Num = dtsql.Rows.Count / 10;

        //            }
        //            else
        //            {
        //                Num = (dtsql.Rows.Count / 10) + 1;
        //            }
        //        }

        //        int ToolTip = 0;
        //        int PieceQty = 0;
        //        decimal Qty = 0;
        //        for (int j = 0; j < Num; j++)
        //        {
        //            XSIZE = 50;
        //            YSIZE = YSIZE + 25;
        //            for (int k = 1; k <= 10; k++)
        //            {

        //                int Index = k + j * 10;
        //                if (Index <= dtsql.Rows.Count)
        //                {
        //                    DataRow dr = dtsql.Rows[Index - 1];
        //                    DevExpress.XtraEditors.CheckEdit chk2 = new DevExpress.XtraEditors.CheckEdit();
        //                    groupControlMainten.Controls.Add(chk2);
        //                    chk2.Location = new System.Drawing.Point(XSIZE, YSIZE);
        //                    chk2.Properties.Caption = "" + SysConvert.ToInt32(ToolTip + 1).ToString() + ">" + SysConvert.ToString(dr["Qty"]);
        //                    chk2.Size = new System.Drawing.Size(82, 19);
        //                    chk2.CheckedChanged += new System.EventHandler(chk2_CheckedChanged);
        //                    chk2.Name = SysConvert.ToInt32(dr["ID"]).ToString();
        //                    chk2.Tag = SysConvert.ToInt32(i + 1);
        //                    chk2.ToolTip = ToolTip.ToString();
        //                    chk2.ForeColor = System.Drawing.Color.Black;
        //                    XSIZE = XSIZE + 80;

        //                    ToolTip++;
        //                    PieceQty++;
        //                    Qty += SysConvert.ToDecimal(dr["Qty"]);
        //                }

        //            }
        //        }

        //        lbl.Text = "�ϼƣ�" + PieceQty.ToString() + " / " + Qty.ToString();
        //        YSIZE = YSIZE + 35;
        //    }





        //}


        ///// <summary>
        ///// ȫѡ
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void chkAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
        //        foreach (Control c in groupControlMainten.Controls)
        //        {
        //            if (c is DevExpress.XtraEditors.CheckEdit)
        //            {

        //                if (((DevExpress.XtraEditors.CheckEdit)c).Tag.ToString() == chk.Tag.ToString())
        //                {
        //                    ((DevExpress.XtraEditors.CheckEdit)c).Checked = chk.Checked;
        //                }


        //            }
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }

        //}

        ///// <summary>
        ///// �ӽڵ�ѡ��
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void chk2_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        #region shiftѡ��

        //        DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
        //        bool Find = false;
        //        int firstRow = 0;
        //        int endRow = 0;
        //        foreach (Control c in groupControlMainten.Controls)
        //        {
        //            if (c is DevExpress.XtraEditors.CheckEdit)
        //            {
        //                if (((DevExpress.XtraEditors.CheckEdit)c).Checked && ((DevExpress.XtraEditors.CheckEdit)c).ToolTip != chk.ToolTip)
        //                {
        //                    firstRow = SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).ToolTip);
        //                    Find = true;
        //                    break;
        //                }
        //            }
        //        }

        //        foreach (Control c in groupControlMainten.Controls)
        //        {
        //            if (c is DevExpress.XtraEditors.CheckEdit)
        //            {
        //                if (((DevExpress.XtraEditors.CheckEdit)c).Checked && ((DevExpress.XtraEditors.CheckEdit)c).ToolTip != chk.ToolTip)
        //                {
        //                    endRow = SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).ToolTip);
        //                }
        //            }
        //        }

        //        if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && Find)
        //        {
        //            int RID1 = 0;
        //            int RID2 = 0;

        //            if (chk.Checked)
        //            {
        //                if (firstRow > SysConvert.ToInt32(chk.ToolTip))
        //                {
        //                    RID1 = SysConvert.ToInt32(chk.ToolTip);
        //                    RID2 = firstRow;
        //                }
        //                else
        //                {
        //                    RID1 = firstRow;
        //                    RID2 = SysConvert.ToInt32(chk.ToolTip);
        //                }
        //                foreach (Control c in groupControlMainten.Controls)
        //                {
        //                    if (c is DevExpress.XtraEditors.CheckEdit)
        //                    {
        //                        if (SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).ToolTip) >= RID1 && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).ToolTip) <= RID2
        //                            && ((DevExpress.XtraEditors.CheckEdit)c).Tag.ToString() == chk.Tag.ToString() && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name) > 100)
        //                        {
        //                            ((DevExpress.XtraEditors.CheckEdit)c).Checked = true;
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (endRow > SysConvert.ToInt32(chk.ToolTip))
        //                {
        //                    RID1 = SysConvert.ToInt32(chk.ToolTip);
        //                    RID2 = endRow;
        //                }
        //                else
        //                {
        //                    RID1 = endRow;
        //                    RID2 = SysConvert.ToInt32(chk.ToolTip);
        //                }
        //                foreach (Control c in groupControlMainten.Controls)
        //                {
        //                    if (c is DevExpress.XtraEditors.CheckEdit)
        //                    {
        //                        if (SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).ToolTip) >= RID1 && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).ToolTip) <= RID2
        //                            && ((DevExpress.XtraEditors.CheckEdit)c).Tag.ToString() == chk.Tag.ToString() && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name) > 100)
        //                        {
        //                            ((DevExpress.XtraEditors.CheckEdit)c).Checked = false;
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        #endregion

        //        #region ��ʾѡ���ƥ��������

        //        int PieceQty = 0;
        //        decimal Qty = 0;
        //        foreach (Control c in groupControlMainten.Controls)
        //        {
        //            if (c is DevExpress.XtraEditors.CheckEdit && ((DevExpress.XtraEditors.CheckEdit)c).Tag != null)
        //            {
        //                if (((DevExpress.XtraEditors.CheckEdit)c).Tag.ToString() == chk.Tag.ToString() && ((DevExpress.XtraEditors.CheckEdit)c).Checked && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name) > 100)
        //                {
        //                    PieceQty++;
        //                    string[] TQty = ((DevExpress.XtraEditors.CheckEdit)c).Text.Split('>');
        //                    Qty += SysConvert.ToDecimal(TQty[1]);


        //                }
        //            }
        //        }

        //        foreach (Control c in groupControlMainten.Controls)
        //        {
        //            if (c is Label && ((Label)c).Tag != null)
        //            {
        //                if (((Label)c).Tag.ToString() == chk.Tag.ToString() + "lbl")
        //                {
        //                    ((Label)c).Text = "  ѡ��" + PieceQty.ToString() + " / " + Qty.ToString();
        //                }
        //            }
        //        }

        //        #endregion

        //        #region ����һ��ѡ���򸸽ڵ㹴��

        //        if (PieceQty > 0)
        //        {
        //            foreach (Control c in groupControlMainten.Controls)
        //            {
        //                if (c is DevExpress.XtraEditors.CheckEdit && ((DevExpress.XtraEditors.CheckEdit)c).Tag != null && !((DevExpress.XtraEditors.CheckEdit)c).Name.Contains("chk"))
        //                {
        //                    if (((DevExpress.XtraEditors.CheckEdit)c).Tag.ToString() == chk.Tag.ToString() && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name) < 100)
        //                    {
        //                        ((DevExpress.XtraEditors.CheckEdit)c).Checked = true;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            foreach (Control c in groupControlMainten.Controls)
        //            {
        //                if (c is DevExpress.XtraEditors.CheckEdit && ((DevExpress.XtraEditors.CheckEdit)c).Tag != null && !((DevExpress.XtraEditors.CheckEdit)c).Name.Contains("chk"))
        //                {
        //                    if (((DevExpress.XtraEditors.CheckEdit)c).Tag.ToString() == chk.Tag.ToString() && SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name) < 100)
        //                    {
        //                        ((DevExpress.XtraEditors.CheckEdit)c).Checked = false;
        //                    }
        //                }
        //            }
        //        }
        //        #endregion



        //        if (chk.Checked)
        //        {
        //            chk.ForeColor = System.Drawing.Color.White;

        //        }
        //        else
        //        {
        //            chk.ForeColor = System.Drawing.Color.Black;
        //        }





        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }

        //}
        #endregion

        #region ��ť�¼�

        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string IDText = "";
                for (int i = 0; i < ucFabLoad1.UCSelectDataSource.Rows.Count; i++)
                {
                    if (IDText != "")
                    {
                        IDText += ",";
                    }
                    IDText += ucFabLoad1.UCSelectDataSource.Rows[i]["ID"].ToString();
                }

                if (m_PackType == (int)EnumPackType.�ֿⵥ��)
                {
                    IOFormDtsPackRule rul = new IOFormDtsPackRule();
                    rul.RAdd(m_ID, IDText);
                }
                else if (m_PackType == (int)EnumPackType.��������)
                {
                    FHFormDtsPackRule rul = new FHFormDtsPackRule();
                    rul.RAdd(m_ID, IDText);
                }
                else if (m_PackType == (int)EnumPackType.���ϵ���)
                {
                    FabricWHOutFormRule rul = new FabricWHOutFormRule();
                    rul.RAdd(m_ID, IDText);
                }
                else if (m_PackType == (int)EnumPackType.���ϵ���)
                {
                    DBFormDtsPackRule rul = new DBFormDtsPackRule();
                    rul.RAdd(m_ID, IDText);
                }


                m_SaveFlag = true;
                this.ShowInfoMessage("����ɹ�");
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



        //private void btnKP_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int Num = 0;
        //        int ID = 0;
        //        foreach (Control c in groupControlMainten.Controls)
        //        {
        //            if (c is DevExpress.XtraEditors.CheckEdit &&SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name)>100 )
        //            {
        //                if (((DevExpress.XtraEditors.CheckEdit)c).Checked)
        //                {
        //                    Num++;
        //                    ID = SysConvert.ToInt32(((DevExpress.XtraEditors.CheckEdit)c).Name);
        //                }
        //            }
        //        }

        //        if (Num > 1 || Num == 0)
        //        {
        //            this.ShowMessage("��ѡ��һ����Ҫ��ƥ����Ϣ��");
        //            return;
        //        }
        //        frmKPEdit frm = new frmKPEdit();
        //        frm.ID = ID;
        //        frm.ShowDialog();
        //        groupControlMainten.Controls.Clear();
        //        CreateCheckBox();


        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        //private void btnSelect_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        frmSelect frm = new frmSelect();
        //        frm.ShowDialog();
        //        Condition2 = frm.Condition;
        //        groupControlMainten.Controls.Clear();
        //        CreateCheckBox();
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}


        /// <summary>
        /// ��ƥ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKP_Click(object sender, EventArgs e)
        {
            try
            {
                //EventKPClick("");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        #endregion




        #region ѡ����ı�
        /// <summary>
        /// ����ģʽ�ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radgSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                IniFabLoad();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }
        #endregion








    }
}