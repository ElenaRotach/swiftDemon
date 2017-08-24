using swiftDemon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using transliter_RUENGRU;

namespace swift
{
    
    public partial class fMain : Form
    {
        private delegate DialogResult ShowOpenFileDialogInvoker();
        public fMain()
        {
            InitializeComponent();
            translite.init();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            //AutoSizeChanged += new EventHandler(AutoSizeChangedDelegate);
            ClientSizeChanged += new EventHandler(AutoSizeChangedDelegate);

        }

        void AutoSizeChangedDelegate(object sender, EventArgs e)
        {
            //MessageBox.Show("Test");
        }

        private void rUENGToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eNGRUToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void транслитерацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 translite = new Form1();
            translite.Show();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Message val = new Message();
            //MessageBox.Show(val.ToString());
            Thread.EndThreadAffinity();
            Thread work = Thread.CurrentThread;
            work.Abort();
            this.Close();
        }

        private void журналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JournalForm messForm = new JournalForm();
            messForm.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void системныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            swiftDemon.settingsForm settings = new swiftDemon.settingsForm();
            settings.Show();
        }

        private void столбцыЖурналаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            swiftDemon.settingsColumnsJournal settingsColumnsJournal = new swiftDemon.settingsColumnsJournal();
            settingsColumnsJournal.Show();
        }

        private void звукToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sound soundForm = new sound();
            soundForm.Show();
        }
        [STAThread]
        private void весьТекстВВерхнийРегистрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            dlg.ShowDialog();
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //ShowOpenFileDialogInvoker invoker = new ShowOpenFileDialogInvoker(openFileDialog.ShowDialog);

            //if (DialogResult == DialogResult.OK)
            //{
            //    //файл выбран
            //}
            //this.Invoke(invoker);
            /*Sub Uppercase()
                For Each Cell In oExcel.Selection
                    If Not Cell.HasFormula Then
			            if Cell.Value <> "" then
				            Cell.Value = UCase(Cell.Value)
			            end if
            
                    End If
                Next
            End Sub

            sub main
               oExcel.Range("A1:AX300").Select
               Uppercase
               msgbox("end")
            end sub
	            Set oExcel = GetObject(, "Excel.Application")
	            Set Sheet = oExcel.ActiveWorkBook.WorkSheets(1)
	            call main*/
            //using (var openFileDialog = new OpenFileDialog())
            //{
            //    openFileDialog.Filter = "Comma Separated Value(*.csv) | *.csv";

            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        MessageBox.Show("Test");
            //    }
            //}
            //          try
            //          {
            //              Invoke(
            //                (MethodInvoker)delegate
            //                {
            //                    FileDialog dlg = new OpenFileDialog();
            //                    dlg.Filter = "Excel Worksheets|*.xls";
            //                    dlg.ShowDialog();
            //                });
            //    // Thread tr = new Thread(ofd);

            //    //OpenFileDialog1.ShowDialog();
            //    //if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            //    //{
            //    //    dynamic pfile = OpenFileDialog1.FileName;
            //    //}
            //}
            //          catch(ApplicationException ex)
            //          {
            //              MessageBox.Show(ex.Message);
            //          }
        }
        
        public void ofd()
        {
            try
            {
                FileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Excel Worksheets|*.xls";
                dlg.ShowDialog();
            }
            catch(Exception exept)
            {
                MessageBox.Show(exept.Message);
            }
        }

        private void весьТекстВНижнийРегистрToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}