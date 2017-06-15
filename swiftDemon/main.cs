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
            swiftDemon.settingsForm settings = new swiftDemon.settingsForm();
            settings.Show();
        }
    }
}
