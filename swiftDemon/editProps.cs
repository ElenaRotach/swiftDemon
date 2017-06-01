using System;
using System.Windows.Forms;
using swiftDemon;

namespace swift
{
    public partial class editProps : Form
    {
        public JournalForm parent;
        int X;
        int Y;
        public editProps(JournalForm parent, int str, int column)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.parent = parent;
            X = str;
            Y = column;
            this.param.Text = parent.tabMess.Rows[X].Cells[Y].Value.ToString();
        }

        private void editProps_Load(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_Click(object sender, EventArgs e)
        {
            parent.tabMess.Rows[X].Cells[Y].Value = param.Text;
            logs.saveParam(parent.tabMess.Columns[Y].HeaderCell.FormattedValue.ToString(), param.Text, parent.tabMess.Rows[X].Cells["26"].Value.ToString());
            parent.tabMess.Rows[X].Cells[16].Value = "True";
            for (int cellNum = 0; cellNum < 27; cellNum++)
            {
                parent.tabMess.Rows[X].Cells[cellNum].Style.BackColor = System.Drawing.Color.White;
            }
            this.Close();
        }
    }
}
