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
        private string outCondition;
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
                        el = new TextBox();
                        break;
                    case "int":
                        el = new TextBox();
                        el.Text = "0";
                        break;
                    case "double":
                        el = new TextBox();
                        el.Text = "0.00";
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

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool validSaveCondition(out string msg)
        {
            bool rez = true;
            msg = "";
            string type = thesaurus.getType(cb_columnsName.SelectedValue.ToString());
            switch (type)
            {
                case "string":
                    if(cb_conditions.Text == ">" || cb_conditions.Text == ">=" || cb_conditions.Text == "<" || cb_conditions.Text == "<=")
                    {
                        msg = "Сравнение строк не может быть произведено при помощи >, >=, <, <=";
                        rez = false;
                    }
                    if (cb_conditions.Text == "LIKE")
                    {
                        outCondition = "[" + cb_columnsName.SelectedValue.ToString() + "] " + cb_conditions.Text + " '%" + ((TextBox)Controls["tb_value"]).Text + "%'";
                    }
                    else
                    {
                        outCondition = "[" + cb_columnsName.SelectedValue.ToString() + "] " + cb_conditions.Text + " '" + ((TextBox)Controls["tb_value"]).Text + "'";
                    }
                    break;
                case "int":
                    if (cb_conditions.Text == "LIKE") {
                        msg = "Сравнение не может быть произведено при помощи 'содержит'";
                        rez = false;
                    }
                    if(((TextBox)Controls["tb_value"]).Text == "")
                    {
                        msg = "Не заполнено значение для сравнения";
                        rez = false;
                    }
                    int strInt = 0;
                    if (!Int32.TryParse(((TextBox)Controls["tb_value"]).Text, out strInt))
                    {
                        msg = "Сравнение производится только с целыми положительными числами";
                        rez = false;
                    }
                    outCondition = cb_columnsName.SelectedValue.ToString() + ' ' + cb_conditions.Text + ' ' + ((TextBox)Controls["tb_value"]).Text;
                    break;
                case "double":
                    if (cb_conditions.Text == "LIKE")
                    {
                        msg = "Сравнение не может быть произведено при помощи 'содержит'";
                        rez = false;
                    }
                    if (((TextBox)Controls["tb_value"]).Text == "")
                    {
                        msg = "Не заполнено значение для сравнения";
                        rez = false;
                    }
                    outCondition = cb_columnsName.SelectedValue.ToString() + ' ' + cb_conditions.Text + ' ' + ((TextBox)Controls["tb_value"]).Text;
                    double strDbl = 0.00;
                    string test = ((TextBox)Controls["tb_value"]).Text;
                    if (!Double.TryParse(test.Replace(".", ","), out strDbl))
                    {
                        msg = "Сравнение производится только с числами двойной точности";
                        rez = false;
                    }
                    outCondition = cb_columnsName.SelectedValue.ToString() + ' ' + cb_conditions.Text + ' ' + ((TextBox)Controls["tb_value"]).Text;
                    break;
                case "date":
                    if (cb_conditions.Text == "LIKE")
                    {
                        msg = "Сравнение не может быть произведено при помощи 'содержит'";
                        rez = false;
                    }
                    if (((DateTimePicker)Controls["tb_value"]).Value.ToString() == "")
                    {
                        msg = "Не заполнено значение для сравнения";
                        rez = false;
                    }
                    DateTime strDate;
                    //MessageBox.Show(Controls["tb_value"].Value);
                    if (!DateTime.TryParse(((DateTimePicker)Controls["tb_value"]).Value.ToString(), out strDate))
                    {
                        msg = "Сравнение производится только с датами";
                        rez = false;
                    }
                    outCondition = cb_columnsName.SelectedValue.ToString() + ' ' + cb_conditions.Text + " '" + ((DateTimePicker)Controls["tb_value"]).Value.ToString().Substring(0, 10) + "'";
                    break;
            }
            return rez;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string msg;
            if (validSaveCondition(out msg)) {
                parent.tb_condition.Text = outCondition;
            }
            else
            {
                MessageBox.Show(msg);
            }
        }
    }
}
