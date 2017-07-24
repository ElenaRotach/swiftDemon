﻿using swiftDemon;
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
{/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace _Visual_C_Sharp__Сортировка_DataGrid
{
    public partial class Form1 : Form
    {
        private static Random r = new Random();
 
        private DataGridView MainDataTable = new DataGridView();
 
        public Form1()
        {
            InitializeComponent();
            //Настройка формы
            {
                this.Text = "(Visual C#) Программная сортировка таблицу";
                this.Size = new Size(800, 400);
                this.MaximumSize = this.Size;
                this.MinimumSize = this.Size;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.BackColor = Color.White;
            }
            //Добавление таблицы на форму
            {
                this.Controls.Add(this.MainDataTable);
                {
                    //Добавление столбцов и строк
                    this.MainDataTable.Columns.Add("Column_01", "Дата и время");
                    this.MainDataTable.Columns.Add("Column_02", "Число");
                    this.MainDataTable.Columns.Add("Column_03", "Строка");
                    this.MainDataTable.Columns.Add("Column_04", "Логика");
                    //Указываем тип данных
                    this.MainDataTable.Columns[0].DefaultCellStyle.Format = "dd.mm.yyyy";//Указываем тип данных по умолчанию для 1го столбца, как дата и время в формате ДД.ММ.ГГГГ(Дата.Месяц.Год)
                    this.MainDataTable.Columns[1].DefaultCellStyle.Format = "##.0";//Указываем тип данных по умолчанию для 2го столбца, как числовой
                    //Как задать строковый тип - не в курсе...
                    //Как задать логический тип - не в курсе...
                    //Добавляем случайные строки
                    {
                        for (int i = 0; i < 15; i++) this.MainDataTable.Rows.Add(
                                                                                   new DateTime(r.Next(1990, DateTime.Now.Year + 1), r.Next(1, 13), r.Next(1, 29)).ToShortDateString(),
                                                                                   r.Next(1, 101).ToString(),
                                                                                   r.Next(1000, 10000).ToString(),
                                                                                   (r.Next(1, 3) % 2 == 0).ToString()
                                                                                );
                    }
                    this.MainDataTable.Size = this.ClientSize;
                    this.MainDataTable.AllowUserToAddRows = false;
                    this.MainDataTable.AllowUserToDeleteRows = false;
                    this.MainDataTable.AllowUserToOrderColumns = false;
                    this.MainDataTable.AllowUserToResizeColumns = false;
                    this.MainDataTable.AllowUserToResizeRows = false;
                    this.MainDataTable.ReadOnly = true;
                    this.MainDataTable.RowHeadersVisible = false;
                    this.MainDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //Указываем тип данных
                    this.MainDataTable.Columns[0].DefaultCellStyle.Format = "dd.mm.yyyy";//Указываем тип данных по умолчанию для 1го столбца, как дата и время в формате ДД.ММ.ГГГГ(Дата.Месяц.Год)
                    this.MainDataTable.Columns[1].DefaultCellStyle.Format = "##.0";//Указываем тип данных по умолчанию для 2го столбца, как числовой
                }
                //Теперь, добавляем событие при отображении таблицы/формы
                this.Shown += this.OnFormShow;
            }
        }
 
        private void OnFormShow(Object Sender, EventArgs E)
        {
            //Сортировка при помощи метода Sort
                //Первым входным параметром является столбец(можно указать сам столбец, либо его индификатор/имя), а вторым параметром будет метод сортировки(по возрастанию Ascending или по убыванию Descending)...
            MessageBox.Show("Сейчас будет выполнена сортировка таблицы стандартным методом Sort по первому столбцу...\nСортируем по возростанию\n\nДля выполнгения сортировки нажмите ОК.", "Сообщение");
            this.MainDataTable.Sort(this.MainDataTable.Columns[0], ListSortDirection.Ascending);
            MessageBox.Show("Сейчас будет выполнена сортировка таблицы стандартным методом Sort по первому столбцу...\nСортируем по убыванию\n\nДля выполнгения сортировки нажмите ОК.", "Сообщение");
            this.MainDataTable.Sort(this.MainDataTable.Columns[0], ListSortDirection.Descending);
            MessageBox.Show("Сейчас будет выполнена сортировка таблицы стандартным методом Sort по второму столбцу...\nСортируем по возрастанию\n\nДля выполнгения сортировки нажмите ОК.", "Сообщение");
            this.MainDataTable.Sort(this.MainDataTable.Columns[1], ListSortDirection.Ascending);
            MessageBox.Show("Сейчас будет выполнена сортировка таблицы стандартным методом Sort по второму столбцу...\nСортируем по убыванию\n\nДля выполнгения сортировки нажмите ОК.", "Сообщение");
            this.MainDataTable.Sort(this.MainDataTable.Columns[1], ListSortDirection.Descending);
            MessageBox.Show("Сейчас будет выполнена сортировка таблицы стандартным методом Sort по третему столбцу...\nСортируем по возрастанию\n\nДля выполнгения сортировки нажмите ОК.", "Сообщение");
            this.MainDataTable.Sort(this.MainDataTable.Columns[2], ListSortDirection.Ascending);
            MessageBox.Show("Сейчас будет выполнена сортировка таблицы стандартным методом Sort по третему столбцу...\nСортируем по убыванию\n\nДля выполнгения сортировки нажмите ОК.", "Сообщение");
            this.MainDataTable.Sort(this.MainDataTable.Columns[2], ListSortDirection.Descending);
            MessageBox.Show("Сейчас будет выполнена сортировка таблицы стандартным методом Sort по четвёртому столбцу...\nСортируем по возрастанию\n\nДля выполнгения сортировки нажмите ОК.", "Сообщение");
            this.MainDataTable.Sort(this.MainDataTable.Columns[3], ListSortDirection.Ascending);
            MessageBox.Show("Сейчас будет выполнена сортировка таблицы стандартным методом Sort по четвёртому столбцу...\nСортируем по убыванию\n\nДля выполнгения сортировки нажмите ОК.", "Сообщение");
            this.MainDataTable.Sort(this.MainDataTable.Columns[3], ListSortDirection.Descending);
            //Пытаемся отсортировать при помощи DataSource
                //Сортируем по первому столбцу по возрастанию(это уже чисто для примера)
            {
                DataTable DT = new DataTable();//Создаём новый "временный" DataTable/Таблицу данных
                DT.Columns.AddRange(new DataColumn[]{//Указываем добавление сразу нескольких столбцов
                                                        new DataColumn("Column_01", typeof(DateTime)),//Каждому новому столбцу указываем наименование/имя и тип данных
                                                        new DataColumn("Column_02", typeof(Int32)),
                                                        new DataColumn("Column_03", typeof(String)),
                                                        new DataColumn("Column_04", typeof(Boolean))
                                                    });
                List<String> ListOfHeaderTextColumns = new List<String>();//Создаём "временный" список, в котором будут наименования столбцов
                for (int i = 0; i < this.MainDataTable.ColumnCount; i++)//Объявляем цикл прохода по всем столбцам
                {
                    ListOfHeaderTextColumns.Add(this.MainDataTable.Columns[i].HeaderText);//Добавляем в список наименования столбцов(это нам понадобится несколько позже
                }
                for (int i = 0; i < this.MainDataTable.RowCount; i++)//Выполняем цикл прохода по всем строкам
                {
                    DataRow NewRow = DT.NewRow();//Создаём новую строку такого же типажа, как строка из DT
                    NewRow.ItemArray = new object[] { Convert.ToDateTime(this.MainDataTable[0, i].Value), Convert.ToInt32(this.MainDataTable[1, i].Value), Convert.ToString(this.MainDataTable[2, i].Value), Convert.ToBoolean(this.MainDataTable[3, i].Value) };//Заносим новые данные в строку
                    DT.Rows.Add(NewRow);//Добавляем новую строку в DT
                }
                this.MainDataTable.Columns.Clear();//Очищение стролбцов в исходной таблице
                this.MainDataTable.Rows.Clear();//Очищаем строки в исходной таблице
                this.MainDataTable.DataSource = null;//Сбрасываем источник данных
                MessageBox.Show("А вот сейчас будет выполнена сортировка через DataTable//DataSource...\nСортировка по возростанию\n\nНажмите ОК для продолжения...", "Сообщение");
                DT = DT.AsEnumerable().OrderBy(row => row.Field<DateTime>("Column_01")).CopyToDataTable();//Выполняем саму сортировку по возростанию
                //Для того, чтобы отсортировать по убыванию, необходимо использовать OrderByDescending
                this.MainDataTable.DataSource = DT;//Указываем источник данных, как новый DataTable(отсортированная таблица)
                for (int i=0; i<ListOfHeaderTextColumns.Count; i++)//Задаём цикл по всем столбцам в новой таблице(ну, по сути, в новой)
                {
                    this.MainDataTable.Columns[i].HeaderText = ListOfHeaderTextColumns[i];//Тут мы через цикл восстанавливаем заголовок столбцов
                }
            }
        }
    }
}*/
    public partial class JournalForm : Form
    {
        ContextMenuStrip contextMenuStripJournal = new ContextMenuStrip();
        delegate void rowsClear();
        delegate void rowsAdd(string count);
        bool repet = true;
        string[] columnsName = { "20 transactionReferenceNumber_20", "30 valueDate_30V" , "32 date_32" , "32 currency_32", "32 amount_32", "33 currency_33B", "33 amount_33B", "50 orderingCustomer_50",
                                   "52 orderingInstitution_52", "53 senderCorrespondent_53", "54 receiverCorrespondent_54", "56 intermediaryInstitution_56", "57 accountWithInstitution_57",
                                   "58 beneficiaryInstitution_58", "59 beneficiaryCustomer_59", "00 processingCharacteristic", "00 mess_direction", "00 comment", "00 dateTime_mess", "00 referenceMess",
                                   "00 fin", "00 swiftNumberBankKontragent", "00 naimBankKontragent", "00 thread", "00 fileName", "00 direction", "00 id" };
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
            //logs.onCount += reshouBtbClick;
            //tabMess.Sort(System.Collections.)
            
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
            foreach (var line in allMess)
            {
                tabMess.Invoke((MethodInvoker)(() => tabMess.Rows.Add(allMess.Count + 1)));
                Dictionary<string, string> propertys = getObjProperty(line);
                foreach(var prop in propertys)
                {
                    int indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", prop.Key));
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[index].Cells[indColumn].Value = s), prop.Value); 
                }
                index++;
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
            //tabMess.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            show("");
            /*List<swiftMess_str> allMess = new List<swiftMess_str>();
           allMess = getDataJournal("");
           //int indColumn = 0;

           for(int i=0; i<columnsName.Length; i++)
           {
               int indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", columnsName[i].Split(' ')[1]));
               tabMess.Columns.Add(indColumn.ToString(), columnsName[i]);
           }

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
           showRows(allMess);*/
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
            show(tb_condition.Text);
            //reshouBtbClick();
        }
        private List<swiftMess_str> getDataJournal(string condition)
        {
            List<swiftMess_str> allMess = new List<swiftMess_str>();
            //condition = dateTime_mess
            //DateTime.Now.GetDateTimeFormats()[0]; WHERE ((mess.[dateTime_mess])>#6/29/2017#)
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

       /* private void showRows(List<swiftMess_str> allMess)
        {

            l_strAll.Text = allMess.Count.ToString();
            if (allMess.Count > 0)
            {
                tabMess.Invoke((MethodInvoker)(() => tabMess.Rows.Add(allMess.Count + 1)));
                for (int i = 0; i < allMess.Count; i++)
                {
                    int indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "transactionReferenceNumber_20"));
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[0].Value = s), allMess[i].transactionReferenceNumber_20);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "valueDate_30V"));
                    //tabMess.Rows[i].Cells[0].Value = allMess[i].transactionReferenceNumber_20;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[1].Value = s), allMess[i].valueDate_30V);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "date_32"));
                    //tabMess.Rows[i].Cells[1].Value = allMess[i].valueDate_30V;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[2].Value = s), allMess[i].date_32);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "currency_32"));
                    //tabMess.Rows[i].Cells[2].Value = allMess[i].date_32;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[3].Value = s), allMess[i].currency_32);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "amount_32"));
                    //tabMess.Rows[i].Cells[3].Value = allMess[i].currency_32;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[4].Value = s), allMess[i].amount_32);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //tabMess.Rows[i].Cells[4].Value = allMess[i].amount_32;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[5].Value = s), allMess[i].currency_33B);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[5].Value = allMess[i].currency_33B;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[6].Value = s), allMess[i].amount_33B);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[6].Value = allMess[i].amount_33B;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[7].Value = s), allMess[i].orderingCustomer_50);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[7].Value = allMess[i].orderingCustomer_50;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[8].Value = s), allMess[i].orderingInstitution_52);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[8].Value = allMess[i].orderingInstitution_52;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[9].Value = s), allMess[i].senderCorrespondent_53);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[9].Value = allMess[i].senderCorrespondent_53;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[10].Value = s), allMess[i].receiverCorrespondent_54);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[10].Value = allMess[i].receiverCorrespondent_54;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[11].Value = s), allMess[i].intermediaryInstitution_56);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[11].Value = allMess[i].intermediaryInstitution_56;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[12].Value = s), allMess[i].accountWithInstitution_57);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[12].Value = allMess[i].accountWithInstitution_57;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[13].Value = s), allMess[i].beneficiaryInstitution_58);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[13].Value = allMess[i].beneficiaryInstitution_58;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[14].Value = s), allMess[i].beneficiaryCustomer_59);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[14].Value = allMess[i].beneficiaryCustomer_59;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[15].Value = s), allMess[i].processingCharacteristic);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[15].Value = allMess[i].processingCharacteristic;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[16].Value = s), allMess[i].mess_direction);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[16].Value = allMess[i].mess_direction;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[17].Value = s), allMess[i].comment);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[17].Value = allMess[i].comment;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[18].Value = s), allMess[i].dateTime_mess);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[18].Value = allMess[i].dateTime_mess;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[19].Value = s), allMess[i].referenceMess);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[19].Value = allMess[i].referenceMess;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[20].Value = s), allMess[i].fin);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[20].Value = allMess[i].fin;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[21].Value = s), allMess[i].swiftNumberBankKontragent);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[21].Value = allMess[i].swiftNumberBankKontragent;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[22].Value = s), allMess[i].naimBankKontragent);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[22].Value = allMess[i].naimBankKontragent;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[23].Value = s), allMess[i].thread);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[23].Value = allMess[i].thread;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[24].Value = s), allMess[i].fileName);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[24].Value = allMess[i].fileName;
                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[25].Value = s), allMess[i].direction);
                    indColumn = Convert.ToInt32(reestr.getParam("\\columnIndex", "direction"));
                    //                    tabMess.Rows[i].Cells[25].Value = allMess[i].direction;

                    tabMess.Invoke(new rowsAdd((s) => tabMess.Rows[i].Cells[26].Value = s), allMess[i].id);
                    //                    tabMess.Rows[i].Cells[26].Value = allMess[i].id;
                    //                    i++;
                }
                paintCells();
                tabMess.Sort(tabMess.Columns[26], ListSortDirection.Descending);
                //columnIndex();
            }
        }*/
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
                /*List<swiftMess_str> newData = new List<swiftMess_str>();
                newData = getDataJournal(tb_condition.Text);*/
                this.show(tb_condition.Text);
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
            //tabMess.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            for(int j = 0; j < tabMess.Columns.Count; j++)
            {
                string columnAlignment = reestr.getParam("\\columnAlignment", tabMess.Columns[j].HeaderText.Split(' ')[1]);
                //var Alignment;
                switch (columnAlignment){
                    case "r":
                        tabMess.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
                        //Alignment = DataGridViewContentAlignment.MiddleRight;//64
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
                    //dataGridView1.Rows[1].Cells[1].Style.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
            }
        }
        //private void columnIndex()
        //{
        //    for (int i = 0; i < tabMess.Columns.Count; i++)
        //    {
        //        string columnName = tabMess.Columns[i].HeaderCell.FormattedValue.ToString().Split(' ')[1];
        //        //MessageBox.Show(columnName);
        //        string columnInd = reestr.getParam("\\columnIndex", columnName);
        //        //MessageBox.Show(columnWidth);
        //        tabMess.Columns[i].DisplayIndex = Convert.ToInt32(columnInd);
        //    }
        //}
    }
}
