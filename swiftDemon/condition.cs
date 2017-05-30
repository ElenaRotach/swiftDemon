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
            cb_conditions.DataSource = thesaurus.conditions;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cb_columnsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cb_columnsName.SelectedValue.ToString());
            string type = thesaurus.getType(cb_columnsName.SelectedValue.ToString());
            //MessageBox.Show(type);
            Control elemFoRemove = null;
            foreach(Control control in Controls)
            {
                if (control.Name == "tb_value")
                {
                    elemFoRemove = control;
                    break;
                }
            }
            if(elemFoRemove != null)
            {
                this.Controls.Remove(elemFoRemove);
                //Label testControl = new Label();
                //testControl.Text = "Это тест!!!!!!!!!!!!!!!!!!!";
                //testControl.Location = new Point(644, 51);
                //TextBox test = new TextBox();
                //this.Controls.Add(testControl);
                Control el = new Control();
                switch(type){
                    case "string":
                    case "int":
                    case "double":
                        TextBox el1 = new TextBox();
                        el = el1;
                        break;
                    case "date":
                        DateTimePicker el2 = new DateTimePicker();
                        el = el2;
                        break;
                }
                el.Name = "tb_value";
                el.Width = 150;
                el.Location = new Point(644, 51);
                this.Controls.Add(el);
            }
        }
    }
}
