using swiftDemon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swift
{    
    public partial class JournalForm : Form
    {
        private class RowComparer : System.Collections.IComparer
        {
            private static int sortOrderModifier = 1;
            private string head;
            public RowComparer(SortOrder sortOrder, string Header)
            {
                head = Header;
                if (sortOrder == SortOrder.Descending)
                {
                    sortOrderModifier = -1;
                }
                else if (sortOrder == SortOrder.Ascending)
                {
                    sortOrderModifier = 1;
                }
            }

            public int Compare(object x, object y)
            {
                DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
                DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;

                int indColumnSort = Convert.ToInt32(reestr.getParam("\\columnIndex", head.Split(' ')[1]));
                int indColumnId = Convert.ToInt32(reestr.getParam("\\columnIndex", "id"));
                int CompareResult = 0;
                //forInt
                string type = thesaurus.getType(head.Split(' ')[1]);
                if (type == "double" || type == "int")
                {
                    double chx = 0;
                    double chy = 0;
                    if (DataGridViewRow1.Cells[indColumnSort].Value.ToString() != "")
                    {
                        chx = Convert.ToDouble(DataGridViewRow1.Cells[indColumnSort].Value.ToString().Replace(".", ","));
                    }
                    if (DataGridViewRow2.Cells[indColumnSort].Value.ToString() != "")
                    {
                        chy = Convert.ToDouble(DataGridViewRow2.Cells[indColumnSort].Value.ToString().Replace(".", ","));
                    }
                    CompareResult = (int)(chx - chy);//0;
                    if (chx > chy) { CompareResult = 1; }
                    if (CompareResult == 0)
                    {
                        CompareResult = Convert.ToInt32(DataGridViewRow1.Cells[indColumnId].Value.ToString()) - Convert.ToInt32(DataGridViewRow2.Cells[indColumnId].Value.ToString());
                    }
                }
                //forDate
                else if (type == "date" || head == "00 dateTime_mess")
                {
                    DateTime chx = new DateTime();
                    DateTime chy = new DateTime();
                    if (DataGridViewRow1.Cells[indColumnSort].Value.ToString() != "")
                    {
                        chx = Convert.ToDateTime(DataGridViewRow1.Cells[indColumnSort].Value.ToString());
                    }
                    if (DataGridViewRow2.Cells[indColumnSort].Value.ToString() != "")
                    {
                        chy = Convert.ToDateTime(DataGridViewRow2.Cells[indColumnSort].Value.ToString());
                    }

                    CompareResult = chx.CompareTo(chy);
                    if (chx > chy) { CompareResult = 1; }
                    if (CompareResult == 0)
                    {
                        CompareResult = Convert.ToInt32(DataGridViewRow1.Cells[indColumnId].Value.ToString()) - Convert.ToInt32(DataGridViewRow2.Cells[indColumnId].Value.ToString());
                    }
                }
                else {
                    CompareResult = DataGridViewRow1.Cells[indColumnSort].Value.ToString().CompareTo(DataGridViewRow2.Cells[indColumnSort].Value.ToString());
                    if (CompareResult == 0)
                    {
                        CompareResult = Convert.ToInt32(DataGridViewRow1.Cells[indColumnId].Value.ToString()) - Convert.ToInt32(DataGridViewRow2.Cells[indColumnId].Value.ToString());
                    }
                }
                return CompareResult * sortOrderModifier;
            }
        }
        ContextMenuStrip contextMenuStripJournal = new ContextMenuStrip();
        delegate void rowsClear();
        delegate void rowsAdd(string count);
        bool repet = true;
        //string[] columnsName = { "20 transactionReferenceNumber_20", "30 valueDate_30V" , "32 date_32" , "32 currency_32", "32 amount_32", "33 currency_33B", "33 amount_33B", "50 orderingCustomer_50",
        //                           "52 orderingInstitution_52", "53 senderCorrespondent_53", "54 receiverCorrespondent_54", "56 intermediaryInstitution_56", "57 accountWithInstitution_57",
        //                           "58 beneficiaryInstitution_58", "59 beneficiaryCustomer_59", "00 processingCharacteristic", "00 mess_direction", "00 comment", "00 dateTime_mess", "00 referenceMess",
        //                           "00 fin", "00 swiftNumberBankKontragent", "00 naimBankKontragent", "00 thread", "00 fileName", "00 direction", "00 id" };
        public JournalForm()
        {
            InitializeComponent();
            tabMess.AllowUserToOrderColumns = true;
            // создаем элементы меню
            ToolStripMenuItem printMenuItem = new ToolStripMenuItem("Печать");
            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Изменить");
            // добавляем элементы в меню
            contextMenuStripJournal.Items.AddRange(new[] { printMenuItem, editMenuItem });
            // ассоциируем контекстное меню с текстовым полем
            tabMess.ContextMenuStrip = contextMenuStripJournal;
            // устанавливаем обработчики событий для меню
            printMenuItem.Click += printMenuItem_Click;
            editMenuItem.Click += EditMenuItem_Click;
            tabMess.ColumnWidthChanged += TabMess_ColumnWidthChanged;
            tabMess.ColumnDisplayIndexChanged += TabMess_ColumnDisplayIndexChanged;
            tabMess.ColumnHeaderMouseClick += TabMess_ColumnHeaderMouseClickP;

        }

        private void TabMess_ColumnHeaderMouseClickP(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (tabMess.Columns[e.ColumnIndex].HeaderText == "32 amount_32" || tabMess.Columns[e.ColumnIndex].HeaderText == "33 amount_33B" || tabMess.Columns[e.ColumnIndex].HeaderText == "00 id" || tabMess.Columns[e.ColumnIndex].HeaderText == "20 transactionReferenceNumber_20")
            {
                tabMess.Sort(new RowComparer(SortOrder.Descending, tabMess.Columns[e.ColumnIndex].HeaderText));
                tabMess.ColumnHeaderMouseClick -= TabMess_ColumnHeaderMouseClickP;
                tabMess.ColumnHeaderMouseClick += TabMess_ColumnHeaderMouseClickM;
            }
        }

        private void TabMess_ColumnHeaderMouseClickM(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (tabMess.Columns[e.ColumnIndex].HeaderText == "32 amount_32" || tabMess.Columns[e.ColumnIndex].HeaderText == "33 amount_33B" || tabMess.Columns[e.ColumnIndex].HeaderText == "00 id" || tabMess.Columns[e.ColumnIndex].HeaderText == "20 transactionReferenceNumber_20")
            {
                tabMess.Sort(new RowComparer(SortOrder.Ascending, tabMess.Columns[e.ColumnIndex].HeaderText));
                tabMess.ColumnHeaderMouseClick -= TabMess_ColumnHeaderMouseClickM;
                tabMess.ColumnHeaderMouseClick += TabMess_ColumnHeaderMouseClickP;
            }
        }
        private void show(string sql)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
            tabMess.Columns.Clear();
            Dictionary<int, string> columns = getColumns();
            addColumns(tabMess, columns);
            List<swiftMess_str> allMess = getDataJournal(tb_condition.Text);
            addLines(tabMess, allMess);
            paintCells();
        }
        public static Dictionary<int, string> getColumns()
        {
            Dictionary<int, string> columns = new Dictionary<int, string>();
            string str = @"Software\swift" + "\\columnIndex\\";
            //Microsoft.Win32.RegistryKey
            string[] keys = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(str).GetValueNames();
            //System.Windows.Forms.MessageBox.Show(rk.GetValue(name).ToString());
            foreach(var key in keys)
            {
                Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(str);
                //System.Windows.Forms.MessageBox.Show(rk.GetValue(name).ToString());
                string valueColumns = key;
                int keyColumns = Convert.ToInt32(rk.GetValue(valueColumns).ToString());
                /*получить ключ по значению*/
                columns.Add(keyColumns, valueColumns);
            }
            //return rk.GetValue(name).ToString();
            return columns;
        }
        private void addColumns(DataGridView tab, Dictionary<int, string> columns)
        {
            try
            {
                SortedDictionary<int, string> newColumns = new SortedDictionary<int, string>();
                foreach (var column in columns)
                {
                    newColumns.Add(column.Key, column.Value);
                }
                foreach (var column in newColumns)
                {
                    tabMess.Columns.Add(column.Key.ToString(), reestr.getParam("\\columnName", column.Value));
                    string columnWidth = reestr.getParam("\\columnWidth", column.Value);
                    try
                    {
                        tabMess.Columns[column.Key.ToString()].Width = Convert.ToInt32(columnWidth);
                    }
                    catch (Exception ex) { }
                    //tabMess.Columns[column.Key.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    tabMess.Columns[column.Key.ToString()].ReadOnly = true;
                }
            }
            catch (Exception e) { }

        }
        private void addLines(DataGridView tab, List<swiftMess_str> allMess)
        {
            l_strAll.Text = allMess.Count.ToString();
            int index = 0;
            if (allMess.Count > 0)
            {
                tabMess.Invoke((MethodInvoker)(() => tabMess.Rows.Add(allMess.Count)));
                foreach (var line in allMess)
                {

                    Dictionary<string, string> propertys = getObjProperty(line);
                    foreach (var prop in propertys)
                    {
                        int indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", prop.Key));
                        tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[index].Cells[indColumn].Value = s), prop.Value);
                    }
                    index++;
                }
            }

        }
        private Dictionary<string, string> getObjProperty(swiftMess_str obj)
        {
            Dictionary<string, string> property = new Dictionary<string, string>();
            /* перебор свойств объекта с получением значений через рефлексию*/
            Type t = typeof (swiftMess_str);
            FieldInfo[] Propertys = t.GetFields();
            foreach (FieldInfo Property in Propertys)
            {
                swiftMess_str ob = obj;
                FieldInfo prop = obj.GetType().GetField(Property.Name);
                property.Add(Property.Name, prop.GetValue(obj).ToString());
            }
            return property;
        }
        private void TabMess_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int ind = e.Column.Index;
            string columnName = tabMess.Columns[ind].HeaderCell.FormattedValue.ToString().Split(' ')[1];
            reestr.setParam("\\columnIndex", columnName, e.Column.DisplayIndex.ToString());
        }

        private void TabMess_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int ind = e.Column.Index;
            string columnName = tabMess.Columns[ind].HeaderCell.FormattedValue.ToString().Split(' ')[1];
            reestr.setParam("\\columnWidth", columnName, e.Column.Width.ToString());
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            int index = tabMess.CurrentRow.Index;
            int id = thesaurus.columnIndex(tabMess.Columns, "id");
            int mess_direction = thesaurus.columnIndex(tabMess.Columns, "mess_direction");
            tabMess.Rows[index].Selected = true;
            editProps editPropWindow = new editProps(this, index, tabMess.CurrentCell.ColumnIndex);
            editPropWindow.Show();
        }

        private void printMenuItem_Click(object sender, EventArgs e)
        {
            int index = tabMess.CurrentRow.Index;
            int id = thesaurus.columnIndex(tabMess.Columns, "id");
            int mess_direction = thesaurus.columnIndex(tabMess.Columns, "mess_direction");
            logs.saveParam(tabMess.Rows[index].Cells[id].Value.ToString());   //TODO
            tabMess.Rows[index].Cells[mess_direction].Value = "True";   //TODO
            for (int cellNum = 0; cellNum < 27; cellNum++)
            {
                tabMess.Rows[index].Cells[cellNum].Style.BackColor = System.Drawing.Color.White;
            }

            tabMess.Rows[index].Selected = true;
            File.Delete(Environment.CurrentDirectory + @"\tmp.txt");
            string curFile = Environment.CurrentDirectory + @"\tmp.txt";
            using (StreamWriter sw = File.AppendText(curFile))
            {
                sw.WriteLine(tabMess.Rows[index].Cells[Convert.ToInt32(reestr.getParam("\\columnIndex", "thread"))].Value);
                sw.Close();
            }
            Process.Start("C:\\Windows\\System32\\notepad.exe", curFile.Trim());
        }

       private void JournalForm_Load(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
            show("");
        }

        private void export_Click(object sender, EventArgs e)
        {
            dynamic excel = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            excel.Visible = true;
            dynamic workbook = excel.Workbooks.Add();
            dynamic worksheet = workbook.ActiveSheet; //.Worksheets.Add();
            worksheet.Application.Worksheets.Add(); //добавить лист
            int totalSheets = worksheet.Application.ActiveWorkbook.Sheets.Count;
            (worksheet.Application.ActiveSheet).Move(worksheet.Application.Worksheets[totalSheets]);
            (worksheet.Application.ActiveWorkbook.Sheets[1]).Activate();
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "export";
            excel.Columns("A:AA").ColumnWidth = 50;
            int str = 0;
            for(int z=0; z< tabMess.Columns.Count; z++)
            {
                worksheet.Cells[1, z+1] = tabMess.Columns[z].HeaderCell.FormattedValue.ToString().Split(' ')[1];
            }
            while (str < tabMess.RowCount)
            {
                for (int st = 0; st < tabMess.Columns.Count; st++)
                {
                    if (tabMess.Columns[st].HeaderCell.FormattedValue.ToString().Split(' ')[1] != "thread") {
                        string value = "";
                        if (tabMess.Rows[str].Cells[st].Value == null)
                        {
                            value = "";
                        }
                        else
                        {
                            value = tabMess.Rows[str].Cells[st].Value.ToString();
                        }
                        worksheet.Cells[str + 2, st + 1] = value;
                    }

                }
                str++;
            }
        }

        private void reshow_Click(object sender, EventArgs e)
        {
            show(tb_condition.Text);
        }
        private List<swiftMess_str> getDataJournal(string condition)
        {
            List<swiftMess_str> allMess = new List<swiftMess_str>();
            DateTime firstDay = (DateTime.Now.AddDays(-6));
            string sql = @"SELECT * FROM mess WHERE ((mess.[dateTime_mess])>#" + firstDay.Month + "/" + firstDay.Day + "/" + firstDay.Year + "#)";
            if (condition != "")
            {
                sql = @"SELECT * FROM [mess] WHERE " + condition;
            }
            settings obj = new settings();
            string connectionString = @"Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + obj.dbPath + obj.dbName;
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
            myOleDbCommand.CommandText = sql;
            myOleDbConnection.Open();
            OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader();

            while (myOleDbDataReader.Read())
            {

                allMess.Add(new swiftMess_str(myOleDbDataReader.GetValue(0).ToString(), myOleDbDataReader.GetValue(1).ToString(), myOleDbDataReader.GetValue(2).ToString(),
                    myOleDbDataReader.GetValue(3).ToString(),
                    myOleDbDataReader.GetValue(4).ToString(), myOleDbDataReader.GetValue(5).ToString(), myOleDbDataReader.GetValue(6).ToString(), myOleDbDataReader.GetValue(7).ToString(),
                    myOleDbDataReader.GetValue(8).ToString(), myOleDbDataReader.GetValue(9).ToString(), myOleDbDataReader.GetValue(10).ToString(), myOleDbDataReader.GetValue(11).ToString(),
                    myOleDbDataReader.GetValue(12).ToString(), myOleDbDataReader.GetValue(13).ToString(), myOleDbDataReader.GetValue(14).ToString(), myOleDbDataReader.GetValue(15).ToString(),
                    myOleDbDataReader.GetValue(16).ToString(), myOleDbDataReader.GetValue(17).ToString(), myOleDbDataReader.GetValue(18).ToString(), myOleDbDataReader.GetValue(19).ToString(),
                    myOleDbDataReader.GetValue(20).ToString(), myOleDbDataReader.GetValue(21).ToString(), myOleDbDataReader.GetValue(22).ToString(), myOleDbDataReader.GetValue(23).ToString(),
                    myOleDbDataReader.GetValue(24).ToString(), myOleDbDataReader.GetValue(25).ToString(), myOleDbDataReader.GetValue(26).ToString()));
            }
            return allMess;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btn_condition_Click(object sender, EventArgs e)
        {
            condition conditionForm = new condition(this);
            conditionForm.FilterAdded += ConditionForm_FilterAdded;
            conditionForm.Show();
        }

        private void ConditionForm_FilterAdded(string newTbCondition)
        {
            tb_condition.Text += newTbCondition;
        }

        public void reshouBtbClick(bool sss=false)
        {
            tabMess.Invoke(new rowsClear(() => tabMess.Rows.Clear()));
                this.show(tb_condition.Text);
            if (this.repet)
            {
                repet = false;
            }
            repet = true;
        }
        private void paintCells()
        {
            for(int j = 0; j < tabMess.Columns.Count; j++)
            {
                string columnAlignment = reestr.getParam("\\columnAlignment", tabMess.Columns[j].HeaderText.Split(' ')[1]);
                switch (columnAlignment){
                    case "r":
                        tabMess.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
                        break;
                    case "l":
                        tabMess.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;//16
                        break;
                    case "c":
                        tabMess.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//32
                        break;
                }
            }
            for (int j = 0; j < tabMess.Rows.Count - 2; j++)
            {
                int indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "mess_direction"));
                if (tabMess.Rows[j].Cells[indColumn].Value != null && tabMess.Rows[j].Cells[indColumn].Value.ToString() == "False")
                {
                    for (int cellNum = 0; cellNum < tabMess.Columns.Count; cellNum++)
                    {
                        tabMess.Rows[j].Cells[cellNum].Style.BackColor = System.Drawing.Color.CadetBlue;
                    }

                }
                indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                if (tabMess.Rows[j].Cells[indColumn].Value != null && tabMess.Rows[j].Cells[indColumn].Value.ToString() == "IN")
                {
                    for (int cellNum = 0; cellNum < tabMess.Columns.Count; cellNum++)
                    {
                        tabMess.Rows[j].Cells[cellNum].Style.Font = new Font(tabMess.DefaultCellStyle.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabMess.Sort(new RowComparer(SortOrder.Descending, ""));
        }
    }
}
