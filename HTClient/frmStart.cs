using System; 
using System.Security.Principal;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
using HttSoft.Framework;
using HttSoft.FrameFunc; 
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid;
using HttSoft.HTERP.Sys; 

namespace HTERP
{
	/// <summary>
	/// ���ܣ�ϵͳ����MDI����
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-5-10
	/// </summary>
	public class frmStart : frmMainFunc
    {
        private Timer timer1;
        private Timer timer2;
        private IContainer components;

		public frmStart()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		

		#region ����������
		/// <summary>
		/// �鷽����ô���(��д����)
		/// </summary>
		/// <param name="p_ClassName">����</param>
		/// <returns>���ش���</returns>
		public override BaseForm NavItemClickGetForm(string p_ClassName)
		{
            if (p_ClassName == "frmStartFlow")
            {
                p_ClassName = "HTERP.frmStartFlow";
            }
            if (p_ClassName == "frmPlatform")
            {
                p_ClassName = "HTERP.frmPlatform";
            }
            BaseForm formToShow = new BaseForm();
            if (!FrameCommon.UseNewOpenType)
            {
                string namespstr = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace;
                string p_ClassNameAll = string.Empty;
                if (p_ClassName.IndexOf(".") != -1)
                {
                    p_ClassNameAll = p_ClassName;
                }
                else
                {
                    p_ClassNameAll = namespstr + "." + p_ClassName;
                }
                Type TypeToLoad = Type.GetType(p_ClassNameAll);
                object obj = Activator.CreateInstance(TypeToLoad);
                formToShow = (BaseForm)obj;
              
            }
            else
            {
                formToShow = FrameCommon.NavItemClickGetForm(p_ClassName);
            }
            return formToShow;
		}
		#endregion


		private static void MDIStart()
		{
			ParamConfig.LoginID=FParamConfig.LoginID;
			ParamConfig.LoginName=FParamConfig.LoginName;

            ParamConfigIni.PIni();//ϵͳ��Ʒ������ʼ��

            
        }


        #region ���ܵ���Ϣ����ʽ

        
        /// <summary>
        /// ���յ���Ϣ
        /// </summary>
        /// <param name="text"></param>
        public override void MsgOnReceive(string text)
        {
            base.MsgOnReceive(text);
            //this.Text = DateTime.Now.ToString();
        }
        /// <summary>
        /// ���յ���Ϣ
        /// </summary>
        /// <param name="text"></param>
        public override void MsgOnReceiveDataTable(DataTable p_Dt)
        {
            base.MsgOnReceiveDataTable(p_Dt);
            //this.ShowMessage(p_Dt.Rows.Count.ToString());
           
        }
        #endregion



        #region  Ԥ��ƽ̨����
        /// <summary>
        /// Ԥ����Ϣ��ʼ��
        /// </summary>
        void AlarmMsgIni()
        {
            SysAlarmCommon.AlarmMsgIni(timer1);
            if (timer1.Enabled)
            {
                timer1_Tick(null, null);//������ã�����ִ��һ�£������������ü������ʱ�䳤�㣬����Ƶ���������ݿ����Ч�ʵĵ���
            }
        }

        /// <summary>
        /// Ԥ������
        /// </summary>
        MessageFormAlarm AlarmShowMessageForm;
        int AlarmShowTimes = 0;//Ԥ����Ϣ��ʾ����
        /// <summary>
        /// ��ȡ�Զ���������
        /// </summary>
        public override void GetMessageTable()
        {
            if (MessageTable == null)
            {
                MessageTable = new DataTable();
            }
            SysAlarmCommon.GetMessageTable(MessageTable, AlarmShowTimes);          
        }

        #region ��������
       
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                GetMessageTable();

                bool showFlag=SysAlarmCommon.AlarmWinAct(MessageTable, AlarmShowMessageForm,this);//ִ��Ԥ����ʾ
                if (showFlag)
                {
                    AlarmShowTimes++;//Ԥ����ʾ�����ۼ�
                }
            }
            catch (Exception E)
            {
                timer1.Enabled = false;
                this.ShowMessage(E.Message);
            }
        }


        #endregion

        #region Windows ������������ɵĴ���
        /// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart));
            this.timer1 = new System.Windows.Forms.Timer();
            this.timer2 = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).BeginInit();
            this.SuspendLayout();
            // 
            // imageListNavIcon
            // 
            this.imageListNavIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListNavIcon.ImageStream")));
            this.imageListNavIcon.Images.SetKeyName(0, "folerclose.gif");
            this.imageListNavIcon.Images.SetKeyName(1, "folder.gif");
            this.imageListNavIcon.Images.SetKeyName(2, "Leaf.bmp");
            this.imageListNavIcon.Images.SetKeyName(3, "plus.bmp");
            this.imageListNavIcon.Images.SetKeyName(4, "minus.bmp");
            this.imageListNavIcon.Images.SetKeyName(5, "FolderClosed.gif");
            this.imageListNavIcon.Images.SetKeyName(6, "Folder.gif");
            this.imageListNavIcon.Images.SetKeyName(7, "Leaf.gif");
            this.imageListNavIcon.Images.SetKeyName(8, "FolderClosed.bmp");
            this.imageListNavIcon.Images.SetKeyName(9, "Folder.bmp");
            this.imageListNavIcon.Images.SetKeyName(10, "page.gif");
            this.imageListNavIcon.Images.SetKeyName(11, "ئ-59.png");
            this.imageListNavIcon.Images.SetKeyName(12, "ئ-60.png");
            // 
            // panBottom
            // 
            this.panBottom.Location = new System.Drawing.Point(231, 273);
            this.panBottom.Margin = new System.Windows.Forms.Padding(4);
            this.panBottom.Size = new System.Drawing.Size(497, 20);
            // 
            // panStatus
            // 
            this.panStatus.Location = new System.Drawing.Point(0, 293);
            this.panStatus.Margin = new System.Windows.Forms.Padding(4);
            this.panStatus.Size = new System.Drawing.Size(728, 20);
            // 
            // BaseIlYesOrNo
            // 
            this.BaseIlYesOrNo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BaseIlYesOrNo.ImageStream")));
            this.BaseIlYesOrNo.Images.SetKeyName(0, "");
            this.BaseIlYesOrNo.Images.SetKeyName(1, "");
            // 
            // BaseIlAll
            // 
            this.BaseIlAll.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BaseIlAll.ImageStream")));
            this.BaseIlAll.Images.SetKeyName(0, "");
            this.BaseIlAll.Images.SetKeyName(1, "");
            this.BaseIlAll.Images.SetKeyName(2, "");
            this.BaseIlAll.Images.SetKeyName(3, "");
            this.BaseIlAll.Images.SetKeyName(4, "");
            this.BaseIlAll.Images.SetKeyName(5, "");
            this.BaseIlAll.Images.SetKeyName(6, "");
            this.BaseIlAll.Images.SetKeyName(7, "");
            this.BaseIlAll.Images.SetKeyName(8, "");
            this.BaseIlAll.Images.SetKeyName(9, "");
            this.BaseIlAll.Images.SetKeyName(10, "");
            this.BaseIlAll.Images.SetKeyName(11, "");
            this.BaseIlAll.Images.SetKeyName(12, "");
            this.BaseIlAll.Images.SetKeyName(13, "");
            this.BaseIlAll.Images.SetKeyName(14, "");
            this.BaseIlAll.Images.SetKeyName(15, "");
            this.BaseIlAll.Images.SetKeyName(16, "");
            this.BaseIlAll.Images.SetKeyName(17, "");
            this.BaseIlAll.Images.SetKeyName(18, "");
            this.BaseIlAll.Images.SetKeyName(19, "");
            this.BaseIlAll.Images.SetKeyName(20, "");
            this.BaseIlAll.Images.SetKeyName(21, "");
            this.BaseIlAll.Images.SetKeyName(22, "");
            this.BaseIlAll.Images.SetKeyName(23, "");
            this.BaseIlAll.Images.SetKeyName(24, "");
            this.BaseIlAll.Images.SetKeyName(25, "");
            this.BaseIlAll.Images.SetKeyName(26, "");
            this.BaseIlAll.Images.SetKeyName(27, "");
            this.BaseIlAll.Images.SetKeyName(28, "");
            this.BaseIlAll.Images.SetKeyName(29, "");
            this.BaseIlAll.Images.SetKeyName(30, "");
            this.BaseIlAll.Images.SetKeyName(31, "");
            this.BaseIlAll.Images.SetKeyName(32, "");
            this.BaseIlAll.Images.SetKeyName(33, "");
            this.BaseIlAll.Images.SetKeyName(34, "");
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(728, 339);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmStart";
            this.Text = "ERPϵͳ";
            this.Load += new System.EventHandler(this.frmStart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmStart_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.ExeName="HTERP.exe";
                MDIStart();
                AlarmMsgIni();//Ԥ����Ϣ��ʼ��

                //timer2.Enabled = true;
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
        }

        


        
    }
}
