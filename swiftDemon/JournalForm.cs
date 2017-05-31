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
        }

        private void TabMess_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int ind = e.Column.Index;
            string columnName = tabMess.Columns[ind].HeaderCell.FormattedValue.ToString();
            //MessageBox.Show(columnName);
            reestr.setParam("\\columnWidth", columnName, e.Column.Width.ToString());
            //throw new NotImplementedException();
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int index = tabMess.CurrentRow.Index;
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
                tabMess.Columns.Add("0", "transactionReferenceNumber_20");
                tabMess.Columns.Add("1", "valueDate_30V");
                tabMess.Columns.Add("2", "date_32");
                tabMess.Columns.Add("3", "currency_32");
                tabMess.Columns.Add("4", "amount_32");
                tabMess.Columns.Add("5", "currency_33B");
                tabMess.Columns.Add("6", "amount_33B");
                tabMess.Columns.Add("7", "orderingCustomer_50");
                tabMess.Columns.Add("8", "orderingInstitution_52");
                tabMess.Columns.Add("9", "senderCorrespondent_53");
                tabMess.Columns.Add("10", "receiverCorrespondent_54");
                tabMess.Columns.Add("11", "intermediaryInstitution_56");
                tabMess.Columns.Add("12", "accountWithInstitution_57");
                tabMess.Columns.Add("13", "beneficiaryInstitution_58");
                tabMess.Columns.Add("14", "beneficiaryCustomer_59");
                tabMess.Columns.Add("15", "processingCharacteristic");
                tabMess.Columns.Add("16", "mess_direction");
                tabMess.Columns.Add("17", "comment");
                tabMess.Columns.Add("18", "dateTime_mess");
                tabMess.Columns.Add("19", "referenceMess");
                tabMess.Columns.Add("20", "fin");
                tabMess.Columns.Add("21", "swiftNumberBankKontragent");
                tabMess.Columns.Add("22", "naimBankKontragent");
                tabMess.Columns.Add("23", "thread");
                tabMess.Columns.Add("24", "fileName");
                tabMess.Columns.Add("25", "direction");
                tabMess.Columns.Add("26", "id");

            for(int i=0; i < tabMess.Columns.Count; i++)
            {
                string columnName = tabMess.Columns[i].HeaderCell.FormattedValue.ToString();
                //MessageBox.Show(columnName);
                string columnWidth = reestr.getParam("\\columnWidth", columnName);
                //MessageBox.Show(columnWidth);
                tabMess.Columns[i].Width = Convert.ToInt32(columnWidth);
                tabMess.Columns[i].ReadOnly = true;
            }
            
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
                worksheet.Cells[1, z+1] = tabMess.Columns[z].HeaderCell.FormattedValue.ToString();
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
            tabMess.Rows.Clear();
            List<swiftMess_str> newData = new List<swiftMess_str>();
            newData = getDataJournal(tb_condition.Text);
            showRows(newData);
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
                    myOleDbDataReader.GetValue(16).ToString(), myOleDbDataReader.GetValue(17).ToString(), myOleDbDataReader.GetValue(19).ToString(), myOleDbDataReader.GetValue(19).ToString(),
                    myOleDbDataReader.GetValue(20).ToString(), myOleDbDataReader.GetValue(21).ToString(), myOleDbDataReader.GetValue(22).ToString(), myOleDbDataReader.GetValue(23).ToString(),
                    myOleDbDataReader.GetValue(24).ToString(), myOleDbDataReader.GetValue(25).ToString(), myOleDbDataReader.GetValue(26).ToString()));
            }
            return allMess;
        }

        private void showRows(List<swiftMess_str> allMess)
        {
            if (allMess.Count > 0)
            {
                tabMess.Rows.Add(allMess.Count);
                int i = 0;
                foreach (swiftMess_str msg in allMess)
                {
                    tabMess.Rows[i].Cells[0].Value = msg.transactionReferenceNumber_20;
                    tabMess.Rows[i].Cells[1].Value = msg.valueDate_30V;
                    tabMess.Rows[i].Cells[2].Value = msg.date_32;
                    tabMess.Rows[i].Cells[3].Value = msg.currency_32;
                    tabMess.Rows[i].Cells[4].Value = msg.amount_32;
                    tabMess.Rows[i].Cells[5].Value = msg.currency_33B;
                    tabMess.Rows[i].Cells[6].Value = msg.amount_33B;
                    tabMess.Rows[i].Cells[7].Value = msg.orderingCustomer_50;
                    tabMess.Rows[i].Cells[8].Value = msg.orderingInstitution_52;
                    tabMess.Rows[i].Cells[9].Value = msg.senderCorrespondent_53;
                    tabMess.Rows[i].Cells[10].Value = msg.receiverCorrespondent_54;
                    tabMess.Rows[i].Cells[11].Value = msg.intermediaryInstitution_56;
                    tabMess.Rows[i].Cells[12].Value = msg.accountWithInstitution_57;
                    tabMess.Rows[i].Cells[13].Value = msg.beneficiaryInstitution_58;
                    tabMess.Rows[i].Cells[14].Value = msg.beneficiaryCustomer_59;
                    tabMess.Rows[i].Cells[15].Value = msg.processingCharacteristic;
                    tabMess.Rows[i].Cells[16].Value = msg.mess_direction;
                    tabMess.Rows[i].Cells[17].Value = msg.comment;
                    tabMess.Rows[i].Cells[18].Value = msg.dateTime_mess;
                    tabMess.Rows[i].Cells[19].Value = msg.referenceMess;
                    tabMess.Rows[i].Cells[20].Value = msg.fin;
                    tabMess.Rows[i].Cells[21].Value = msg.swiftNumberBankKontragent;
                    tabMess.Rows[i].Cells[22].Value = msg.naimBankKontragent;
                    tabMess.Rows[i].Cells[23].Value = msg.thread;
                    tabMess.Rows[i].Cells[24].Value = msg.fileName;
                    tabMess.Rows[i].Cells[25].Value = msg.direction;
                    tabMess.Rows[i].Cells[26].Value = msg.id;
                    i++;
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_condition_Click(object sender, EventArgs e)
        {
            condition conditionForm = new condition(this);
            conditionForm.Show();
        }
    }
}
