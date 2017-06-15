using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using swift;

namespace swiftDemon
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        private static bool ConsoleVisible = false;
        private const int HIDE = 0;
        private const int SHOW = 9;
        private const int MF_BYCOMMAND = 0;
        private const int SC_CLOSE = 0xF060;
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ConsoleWindow = GetConsoleWindow();

        private static System.Timers.Timer TrayTimer;
        private static NotifyIcon TrayIcon;

        private static bool Enabled = true;
        private static bool Error = false;
        public static bool firstStart = true;
        private static Thread jurnalThread;
        private Thread jurnalStart;

        static void Main(string[] args)
        {
            #region new
            try
            {
                // убрать стандартную кнопку Close
                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
                // скрываем окно в начале работы
                ToggleWindow(false);
                // создаем контекстное меню
                ContextMenu TrayMenu = new ContextMenu();
                //TrayMenu.MenuItems.Add("Изменить период обработки", InputParams);
                TrayMenu.MenuItems.Add("Показать / спрятать", TrayToggle);
                TrayMenu.MenuItems.Add("Журнал", Jurnal);
                TrayMenu.MenuItems.Add("Настройки", Settings);
                TrayMenu.MenuItems.Add("Выход", OnExit);
                // регисртируем иконку для отображения в области уведомлений; файл *.ico должен быть рядом с *.exe
                TrayIcon = new NotifyIcon();
                TrayIcon.ContextMenu = TrayMenu; // регистрируем контекстное меню (появляется по правой кнопке мыши)
                TrayIcon.Icon = new Icon("ico.ico");
                TrayIcon.Text = "регистрация swift"; // всплывающая подсказка
                TrayIcon.MouseDoubleClick += new MouseEventHandler(TrayClick); // показать/скрыть конслоль по двойному щелчку
                TrayIcon.Visible = true;
                // обработчик событий по таймеру
                TrayTimer = new System.Timers.Timer();
                TrayTimer.Interval = 290000;//290000;
                TrayTimer.Enabled = true;
                TrayTimer.Elapsed += new System.Timers.ElapsedEventHandler(MainFunction); // основная функция консоли
                                                                                          // запуск обработчика событий
                Console.WindowHeight = Console.LargestWindowHeight-50;
                Console.WindowWidth = Console.LargestWindowWidth-50;
                jurnalThread = new Thread(JurnalStart) { };
                Application.Run();
            }
            catch (Exception e)
            {
                ToggleWindow(true);
                logs.outStr(e.Message, true, null);
                logs.outStr(e.StackTrace, true, null);
            }
            #endregion
        }

        private static void Jurnal(object sender, EventArgs e)
        {
            ////if (jurnalThread.IsAlive)
            ////{
            //    jurnalThread.Abort();
            //Thread.Sleep(1000);
            ////}
            jurnalThread = new Thread(JurnalStart) { };
            jurnalThread.Start();
            // throw new NotImplementedException();
            //Application.Run(new fMain());
        }
        private static void JurnalStart()
        {
            try
            {
                fMain jurnal = new fMain();
                try
                {
                    jurnal.ShowDialog();
                }
                catch { }
            }
            catch(ApplicationException e) {
                MessageBox.Show(e.Message);
            }
        }
        private static void Settings(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //Form settingsForm = new Form();
            try
            {
                settingsForm settingF = new settingsForm();
                settingF.Show();
            }
            catch { }
        }

        private static Dictionary<string, string> newSwiftFiles(bool firstStart, bool outFil)
        {
            Dictionary<string, string> filesDictionary = new Dictionary<string, string>();
            try
            {
                settings settingsVal = new settings();
                string[] dirs;// = Directory.GetFiles(settingsVal.outMess, "*");
                if (outFil) { dirs = Directory.GetFiles(settingsVal.outMess, "*"); }
                else { dirs = Directory.GetFiles(settingsVal.inMess, "*"); }
                int key = 0;
                for (int i = 0; i < dirs.Length; i++)
                {
                    if (Path.GetExtension(dirs[i]) == ".trn" && dirs[i].IndexOf("FIN-082") == -1 && dirs[i].IndexOf("FIN-081") == -1 && dirs[i].IndexOf("APC-081") == -1)
                    {
                        //if (firstStart)
                        //{
                        //    DateTime workDate = DateTime.Now.AddDays(-1);
                        //    string pattern = "dd.MM.yyyy H:mm:ff";
                        //    DateTime parsedDate;
                        //    DateTime.TryParseExact(workDate.ToString(), pattern, null, DateTimeStyles.None, out parsedDate);
                        //    string newDate = string.Format("{0:d}", parsedDate);
                        //    newDate += " 17:30:00";
                        //    if ((DateTime.Now - File.GetLastWriteTime(dirs[i])).TotalMinutes < (int)(DateTime.Now - DateTime.Parse(newDate)).TotalMinutes)
                        //    {
                        //        filesDictionary.Add(key.ToString(), dirs[i]);
                        //        key++;
                        //    }
                        //}
                        //else
                        //{
                        //    if ((int)(DateTime.Now - File.GetLastWriteTime(dirs[i])).TotalMinutes < 5)
                        //    {
                                filesDictionary.Add(key.ToString(), dirs[i]);
                                key++;
                        //    }
                        //}
                    }
                }
            }
            catch (ApplicationException e) {
                logs.outStr(e.Message, true, null);
                logs.outStr(e.StackTrace, true, null);
                MessageBox.Show(e.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
            return filesDictionary;
        }
        static void ToggleWindow(bool visible)
        {
            try
            {
                ConsoleVisible = visible;
                ShowWindow(ConsoleWindow, visible ? SHOW : HIDE);
            }
            catch (ApplicationException e)
            {
                logs.outStr(e.Message, true, null);
                logs.outStr(e.StackTrace, true, null);
                MessageBox.Show(e.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }

        static void TrayClick(object Sender, EventArgs e)
        {
            try
            {
                // по двойному щелчку
                ToggleWindow(!ConsoleVisible);
            }
            catch (ApplicationException ex)
            {
                logs.outStr(ex.Message, true, null);
                logs.outStr(ex.StackTrace, true, null);
                MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }

        static void TrayToggle(object Sender, EventArgs e)
        {
            try
            {
                // по выбору из меню
                ToggleWindow(!ConsoleVisible);
            }
            catch (ApplicationException exe)
            {
                logs.outStr(exe.Message, true, null);
                logs.outStr(exe.StackTrace, true, null);
                MessageBox.Show(exe.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }

        static void OnExit(object Sender, EventArgs e)
        {
            try
            {
                TrayIcon.Visible = false; // спрятать значок перед завершением
                                          // …
                                          // и другие завершающие действия по выходу из программы
            }
            catch (ApplicationException exep)
            {
                logs.outStr(exep.Message, true, null);
                logs.outStr(exep.StackTrace, true, null);
                MessageBox.Show(exep.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
            Application.Exit();
        }
        
        static void MainFunction(object Sender, EventArgs e) // имитатор главного обработчика событий
        {
            try
            {
                int i = 0;
                logs.outStr("Start verification " + DateTime.Now + " " + Environment.UserDomainName + " " + Environment.UserName + " " + Environment.MachineName + "\n", false, null);
                work(true);
                work(false);
            }
            catch (ApplicationException exept)
            {
                logs.outStr(exept.Message, true, null);
                logs.outStr(exept.StackTrace, true, null);
            }
        }

        public static void work(bool outMess)
        {
            Dictionary<string, string> files = new Dictionary<string, string>();
            settings setting = new settings();
            /*получаем папку для переноса файлов по принципу:
             1. Формируем родительскую папку если исходящии setting.outArhiv, иначе setting.inArhiv
             2. Формируем имя папки формат "YYYY_MM_DD"
             3. Если папку не существует - создаем
             */
            string direction = "";
            string path = "";

            if (outMess)
            {
                direction = "OUT";
                path = setting.outArhiv;
            }
            else
            {
                direction = "IN";
                path = setting.inArhiv;
            }

            DateTime workDate = DateTime.Now;
            string pattern = "dd.MM.yyyy H:mm:ff";
            DateTime parsedDate;
            DateTime.TryParseExact(workDate.ToString(), pattern, null, DateTimeStyles.None, out parsedDate);
            string newDate = string.Format("{0:d}", parsedDate);

            string pathName = newDate;
            if (!Directory.Exists(path + pathName))
            {
                Directory.CreateDirectory(path + pathName);
            }
            files = newSwiftFiles(firstStart, outMess);
            firstStart = false;
            if (files.Count > 0)
            {
                string mess = "Получены новые файлы: \n";
                for (int z = 0; z < files.Count; z++)
                {
                    swiftMess messObj = new swiftMess(File.ReadAllText(files[z.ToString()]), files[z.ToString()], direction);
                    logs.outStr("Новый файл " + files[z.ToString()] + "\t" + File.GetLastAccessTime(files[z.ToString()]), false, messObj);
                    string[] filName = files[z.ToString()].Split('\\');
                    mess += filName[filName.Length - 1] + '\n';
                    File.Move(files[z.ToString()], path + pathName + "\\" + filName[filName.Length - 1]);
                }
                if (outMess)
                {
                    MessageBox.Show(mess, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
                //пока просто переносим обработанные, без архивирования, архивирование логично запускать для предыдущего дня при утреннем старте

                //string startPath = @"c:\example\start";
                //string zipPath = @"c:\example\result.zip";
                //ZipFile.CreateFromDirectory(startPath, zipPath);


            }
        }
    }
}
