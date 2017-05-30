using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using swift;
namespace swiftDemon
{
    public partial class condition : Form
    {
        private JournalForm parent;
        public condition(JournalForm parent)
        {
            this.parent = parent;
            List<string> tabNameSource = new List<string>(); //new Array(parent.tabMess.ColumnCount);
            for (int i = 0; i < parent.tabMess.ColumnCount; i++)
            {
                tabNameSource.Add(parent.tabMess.Columns[i].HeaderCell.FormattedValue.ToString());
            }
            InitializeComponent();
            cb_columnsName.DataSource = tabNameSource;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
