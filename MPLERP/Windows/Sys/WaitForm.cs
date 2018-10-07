using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MLTERP
{
    public partial class WaitForm : Form
    {
        private BackgroundWorker worker = null;
       // private WaitForm waitForm;
        //private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        //private DataTable datatable;

        public WaitForm()
        {
            InitializeComponent();


            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_Complete);
        }


        public void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //try
            //{
            //    this.GetCondition();
            //    BindGrid2();
            //}
            //catch (Exception E)
            //{
            //    this.ShowMessage(E.Message);
            //}
        }

        public void worker_Complete(object sender, EventArgs e)
        {
            //gridView2.GridControl.DataSource = datatable;
            //gridView2.GridControl.Show();
            //waitForm.Close();
        }

    }
}