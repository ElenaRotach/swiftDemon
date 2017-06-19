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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swift
{
    public partial class JournalForm : Form
    {
        ContextMenuStrip contextMenuStripJournal = new ContextMenuStrip();
        delegate void rowsClear();
        delegate void rowsAdd(string count);
        bool repet = true;
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
            //tabMess.CellMouseClick += TabMess_CellMouseClick;
            //tabMess.CellContextMenuStripNeeded += TabMess_CellContextMenuStripNeeded;
            tabMess.ColumnWidthChanged += TabMess_ColumnWidthChanged;
            tabMess.ColumnDisplayIndexChanged += TabMess_ColumnDisplayIndexChanged;
            logs.onCount += reshouBtbClick;
        }

        private void TabMess_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //throw new NotImplementedException();
            int ind = e.Column.Index;
            string columnName = tabMess.Columns[ind].HeaderCell.FormattedValue.ToString().Split(' ')[1];
            //MessageBox.Show(columnName);
            reestr.setParam("\\columnIndex", columnName, e.Column.DisplayIndex.ToString());
        }

        private void TabMess_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int ind = e.Column.Index;
            string columnName = tabMess.Columns[ind].HeaderCell.FormattedValue.ToString().Split(' ')[1];
            //MessageBox.Show(columnName);
            reestr.setParam("\\columnWidth", columnName, e.Column.Width.ToString());
            //throw new NotImplementedException();
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int index = tabMess.CurrentRow.Index;
            int id = thesaurus.columnIndex(tabMess.Columns, "id");
            int mess_direction = thesaurus.columnIndex(tabMess.Columns, "mess_direction");
            tabMess.Rows[index].Selected = true;
            //swiftMess_str msg = new swiftMess_str(tabMess.Rows[index].Cells[0].Value.ToString(), tabMess.Rows[index].Cells[1].Value.ToString(), tabMess.Rows[index].Cells[2].Value.ToString(), tabMess.Rows[index].Cells[3].Value.ToString(), tabMess.Rows[index].Cells[4].Value.ToString(), tabMess.Rows[index].Cells[5].Value.ToString(), tabMess.Rows[index].Cells[6].Value.ToString(), tabMess.Rows[index].Cells[7].Value.ToString(), tabMess.Rows[index].Cells[8].Value.ToString(), tabMess.Rows[index].Cells[9].Value.ToString(), tabMess.Rows[index].Cells[10].Value.ToString(), tabMess.Rows[index].Cells[11].Value.ToString(), tabMess.Rows[index].Cells[12].Value.ToString(), tabMess.Rows[index].Cells[13].Value.ToString(), tabMess.Rows[index].Cells[14].Value.ToString(), tabMess.Rows[index].Cells[15].Value.ToString(), tabMess.Rows[index].Cells[16].Value.ToString(), tabMess.Rows[index].Cells[17].Value.ToString(), tabMess.Rows[index].Cells[18].Value.ToString(), tabMess.Rows[index].Cells[19].Value.ToString(), tabMess.Rows[index].Cells[20].Value.ToString(), tabMess.Rows[index].Cells[21].Value.ToString(), tabMess.Rows[index].Cells[22].Value.ToString(), tabMess.Rows[index].Cells[23].Value.ToString(), tabMess.Rows[index].Cells[24].Value.ToString(), tabMess.Rows[index].Cells[25].Value.ToString(), tabMess.Rows[index].Cells[26].Value.ToString());
            editProps editPropWindow = new editProps(this, index, tabMess.CurrentCell.ColumnIndex);
            editPropWindow.Show();
        }

        //private void TabMess_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        tabMess.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        //        //tabMess.CellContextMenuStripNeeded();
        //    }
        //}

        //private void TabMess_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        //{
        //    if (e.ColumnIndex != -1 && e.RowIndex != -1)
        //    {
        //        contextMenuStripJournal.Show(Cursor.Position);
        //    }
        //}

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
                sw.WriteLine(tabMess.Rows[index].Cells[23].Value);
                sw.Close();
            }
            Process.Start("C:\\Windows\\System32\\notepad.exe", curFile.Trim());
        }

        private void JournalForm_Load(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
            List<swiftMess_str> allMess = new List<swiftMess_str>();
            allMess = getDataJournal("");
            //int indColumn = 0;
            string[] columnsName = { "20 transactionReferenceNumber_20", "30 valueDate_30V" , "32 date_32" , "32 currency_32", "32 amount_32", "33 currency_33B", "33 amount_33B", "50 orderingCustomer_50",
                                   "52 orderingInstitution_52", "53 senderCorrespondent_53", "54 receiverCorrespondent_54", "56 intermediaryInstitution_56", "57 accountWithInstitution_57",
                                   "58 beneficiaryInstitution_58", "59 beneficiaryCustomer_59", "00 processingCharacteristic", "00 mess_direction", "00 comment", "00 dateTime_mess", "00 referenceMess",
                                   "00 fin", "00 swiftNumberBankKontragent", "00 naimBankKontragent", "00 thread", "00 fileName", "00 direction", "00 id" };
            for(int i=0; i<columnsName.Length; i++)
            {
                int indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", columnsName[i].Split(' ')[1]));
                tabMess.Columns.Add(indColumn.ToString(), columnsName[i]);
                //string columnWidth = reestr.getParam("\\columnWidth", columnName);
            }
                /*tabMess.Columns.Add("0", "20 transactionReferenceNumber_20");
                tabMess.Columns.Add("1", "30 valueDate_30V");
                tabMess.Columns.Add("2", "32 date_32");
                tabMess.Columns.Add("3", "32 currency_32");
                tabMess.Columns.Add("4", "32 amount_32");
                tabMess.Columns.Add("5", "33 currency_33B");
                tabMess.Columns.Add("6", "33 amount_33B");
                tabMess.Columns.Add("7", "50 orderingCustomer_50");
                tabMess.Columns.Add("8", "52 orderingInstitution_52");
                tabMess.Columns.Add("9", "53 senderCorrespondent_53");
                tabMess.Columns.Add("10", "54 receiverCorrespondent_54");
                tabMess.Columns.Add("11", "56 intermediaryInstitution_56");
                tabMess.Columns.Add("12", "57 accountWithInstitution_57");
                tabMess.Columns.Add("13", "58 beneficiaryInstitution_58");
                tabMess.Columns.Add("14", "59 beneficiaryCustomer_59");
                tabMess.Columns.Add("15", "00 processingCharacteristic");
                tabMess.Columns.Add("16", "00 mess_direction");
                tabMess.Columns.Add("17", "00 comment");
                tabMess.Columns.Add("18", "00 dateTime_mess");
                tabMess.Columns.Add("19", "00 referenceMess");
                tabMess.Columns.Add("20", "00 fin");
                tabMess.Columns.Add("21", "00 swiftNumberBankKontragent");
                tabMess.Columns.Add("22", "00 naimBankKontragent");
                tabMess.Columns.Add("23", "00 thread");
                tabMess.Columns.Add("24", "00 fileName");
                tabMess.Columns.Add("25", "00 direction");
                tabMess.Columns.Add("26", "00 id");*/

            for (int i = 0; i < tabMess.Columns.Count; i++)
            {
                string columnName = tabMess.Columns[i].HeaderCell.FormattedValue.ToString().Split(' ')[1];
                //MessageBox.Show(columnName);
                string columnWidth = reestr.getParam("\\columnWidth", columnName);
                //MessageBox.Show(columnWidth);
                tabMess.Columns[i].Width = Convert.ToInt32(columnWidth);
                tabMess.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                tabMess.Columns[i].ReadOnly = true;
            }
            tabMess.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;   
            tabMess.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;   
            //MessageBox.Show(tabMess.Columns[0].HeaderCell.FormattedValue.ToString());
            showRows(allMess);
        }

        private void export_Click(object sender, EventArgs e)
        {
            dynamic excel = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            excel.Visible = true;
            dynamic workbook = excel.Workbooks.Add();
            dynamic worksheet = workbook.ActiveSheet; //.Worksheets.Add();
            worksheet.Application.Worksheets.Add(); //добавить лист
            //worksheet.Application.Worksheets.Add(); 
            int totalSheets = worksheet.Application.ActiveWorkbook.Sheets.Count;
            (worksheet.Application.ActiveSheet).Move(worksheet.Application.Worksheets[totalSheets]);
            (worksheet.Application.ActiveWorkbook.Sheets[1]).Activate();
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "export";
            excel.Columns("A:AA").ColumnWidth = 50;
            int str = 1;
            for(int z=0; z<23; z++)
            {
                worksheet.Cells[1, z+1] = tabMess.Columns[z].HeaderCell.FormattedValue.ToString().Split(' ')[1];
            }
            while (str < tabMess.RowCount)
            {
                for (int st = 0; st < 23; st++)
                {
                    string value = "";
                    if (tabMess.Rows[str].Cells[st].Value == null)
                    {
                        value = "";
                    }
                    else
                    {
                        value = tabMess.Rows[str].Cells[st].Value.ToString();
                    }
                    worksheet.Cells[str + 1, st + 1] = value;
                }
                str++;
            }
        }

        private void reshow_Click(object sender, EventArgs e)
        {
            reshouBtbClick();
        }
        private List<swiftMess_str> getDataJournal(string condition)
        {
            List<swiftMess_str> allMess = new List<swiftMess_str>();
            string sql = @"SELECT * FROM mess";
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

        private void showRows(List<swiftMess_str> allMess)
        {
            l_strAll.Text = allMess.Count.ToString();
            if (allMess.Count > 0)
            {
                //dgLogGrid.Invoke((MethodInvoker)(() => dgLogGrid.Rows.Add(myArray)));
                tabMess.Invoke((MethodInvoker)(() => tabMess.Rows.Add(allMess.Count + 1)));
                //tabMess.Invoke(new rowsAdd((s) => tabMess.Rows.Add(s), allMess.Count));
                //tabMess.Rows.Add(allMess.Count);
                //int i = 0;
                for (int i = 0; i < allMess.Count; i++)
                {
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[0].Value = s), allMess[i].transactionReferenceNumber_20);
                    //tabMess.Rows[i].Cells[0].Value = allMess[i].transactionReferenceNumber_20;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[1].Value = s), allMess[i].valueDate_30V);
                    //tabMess.Rows[i].Cells[1].Value = allMess[i].valueDate_30V;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[2].Value = s), allMess[i].date_32);
                    //tabMess.Rows[i].Cells[2].Value = allMess[i].date_32;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[3].Value = s), allMess[i].currency_32);
                    //tabMess.Rows[i].Cells[3].Value = allMess[i].currency_32;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[4].Value = s), allMess[i].amount_32);
                    //tabMess.Rows[i].Cells[4].Value = allMess[i].amount_32;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[5].Value = s), allMess[i].currency_33B);
                    //                    tabMess.Rows[i].Cells[5].Value = allMess[i].currency_33B;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[6].Value = s), allMess[i].amount_33B);
                    //                    tabMess.Rows[i].Cells[6].Value = allMess[i].amount_33B;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[7].Value = s), allMess[i].orderingCustomer_50);
                    //                    tabMess.Rows[i].Cells[7].Value = allMess[i].orderingCustomer_50;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[8].Value = s), allMess[i].orderingInstitution_52);
                    //                    tabMess.Rows[i].Cells[8].Value = allMess[i].orderingInstitution_52;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[9].Value = s), allMess[i].senderCorrespondent_53);
                    //                    tabMess.Rows[i].Cells[9].Value = allMess[i].senderCorrespondent_53;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[10].Value = s), allMess[i].receiverCorrespondent_54);
                    //                    tabMess.Rows[i].Cells[10].Value = allMess[i].receiverCorrespondent_54;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[11].Value = s), allMess[i].intermediaryInstitution_56);
                    //                    tabMess.Rows[i].Cells[11].Value = allMess[i].intermediaryInstitution_56;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[12].Value = s), allMess[i].accountWithInstitution_57);
                    //                    tabMess.Rows[i].Cells[12].Value = allMess[i].accountWithInstitution_57;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[13].Value = s), allMess[i].beneficiaryInstitution_58);
                    //                    tabMess.Rows[i].Cells[13].Value = allMess[i].beneficiaryInstitution_58;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[14].Value = s), allMess[i].beneficiaryCustomer_59);
                    //                    tabMess.Rows[i].Cells[14].Value = allMess[i].beneficiaryCustomer_59;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[15].Value = s), allMess[i].processingCharacteristic);
                    //                    tabMess.Rows[i].Cells[15].Value = allMess[i].processingCharacteristic;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[16].Value = s), allMess[i].mess_direction);
                    //                    tabMess.Rows[i].Cells[16].Value = allMess[i].mess_direction;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[17].Value = s), allMess[i].comment);
                    //                    tabMess.Rows[i].Cells[17].Value = allMess[i].comment;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[18].Value = s), allMess[i].dateTime_mess);
                    //                    tabMess.Rows[i].Cells[18].Value = allMess[i].dateTime_mess;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[19].Value = s), allMess[i].referenceMess);
                    //                    tabMess.Rows[i].Cells[19].Value = allMess[i].referenceMess;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[20].Value = s), allMess[i].fin);
                    //                    tabMess.Rows[i].Cells[20].Value = allMess[i].fin;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[21].Value = s), allMess[i].swiftNumberBankKontragent);
                    //                    tabMess.Rows[i].Cells[21].Value = allMess[i].swiftNumberBankKontragent;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[22].Value = s), allMess[i].naimBankKontragent);
                    //                    tabMess.Rows[i].Cells[22].Value = allMess[i].naimBankKontragent;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[23].Value = s), allMess[i].thread);
                    //                    tabMess.Rows[i].Cells[23].Value = allMess[i].thread;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[24].Value = s), allMess[i].fileName);
                    //                    tabMess.Rows[i].Cells[24].Value = allMess[i].fileName;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[25].Value = s), allMess[i].direction);
                    //                    tabMess.Rows[i].Cells[25].Value = allMess[i].direction;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[26].Value = s), allMess[i].id);
                    //                    tabMess.Rows[i].Cells[26].Value = allMess[i].id;
                    //                    i++;
                }
                paintCells();
                tabMess.Sort(tabMess.Columns[26], ListSortDirection.Descending);
                columnIndex();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //tabMess.Columns.Add
        }

        private void btn_condition_Click(object sender, EventArgs e)
        {
            condition conditionForm = new condition(this, "");
            conditionForm.Show();
        }
        public void reshouBtbClick(bool sss=false)
        {
            tabMess.Invoke(new rowsClear(() => tabMess.Rows.Clear()));
                List<swiftMess_str> newData = new List<swiftMess_str>();
                newData = getDataJournal(tb_condition.Text);
                this.showRows(newData);
            if (this.repet)
            {
                repet = false;
                //MessageBox.Show("Test");
                //reshouBtbClick();
                //reshow.PerformClick();
                //reshow.Invoke((MethodInvoker)(() => reshow.PerformClick()));

            }
            repet = true;
        }
        private void paintCells()
        {
            for (int j = 0; j < tabMess.Rows.Count - 2; j++)
            {
                if (tabMess.Rows[j].Cells[16].Value.ToString() == "False")
                {
                    for (int cellNum = 0; cellNum < 27; cellNum++)
                    {
                        tabMess.Rows[j].Cells[cellNum].Style.BackColor = System.Drawing.Color.CadetBlue;
                    }

                }
            }
        }
        private void columnIndex()
        {
            for (int i = 0; i < tabMess.Columns.Count; i++)
            {
                string columnName = tabMess.Columns[i].HeaderCell.FormattedValue.ToString().Split(' ')[1];
                //MessageBox.Show(columnName);
                string columnInd = reestr.getParam("\\columnIndex", columnName);
                //MessageBox.Show(columnWidth);
                tabMess.Columns[i].DisplayIndex = Convert.ToInt32(columnInd);
            }
        }
    }
}
