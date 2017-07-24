using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swiftDemon
{
    public partial class settingsColumnsJournal : Form
    {
        private Dictionary<int, string> tbDict = new Dictionary<int, string>();
        public settingsColumnsJournal()
        {
            InitializeComponent();
        }

        private void settingsColumnsJournal_Load(object sender, EventArgs e)
        {
            int endPosition = 80;
            
            tbDict = swift.JournalForm.getColumns();
            foreach(var tb in tbDict) {
                CheckBox newColumn = new CheckBox();
                newColumn.Name = tb.Value;
                newColumn.Text = tb.Value;
                newColumn.Width = 200;
                newColumn.Left = 15;//new Point(1, 1);
                newColumn.Top = endPosition;
                this.Controls.Add(newColumn);
                endPosition += 40;
                this.Height = endPosition + 50;
            }
        }

        private void btn_alignment_Click(object sender, EventArgs e)
        {
            char alig = 'r';
            if (this.rb_c.Checked == true)
            {
                alig = 'c';
            }
            else if (rb_l.Checked == true)
            {
                alig = 'l';
            }
            foreach (var tb in tbDict)
            {
                CheckBox control = (CheckBox)Controls[tb.Value];
                if (control.Checked == true)
                {
                    string columnName = control.Name;
                    //MessageBox.Show(columnName);
                    reestr.setParam("\\columnAlignment", columnName, alig.ToString());
                }
            }
        }
    }
}
