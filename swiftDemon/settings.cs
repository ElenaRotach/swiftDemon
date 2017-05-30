using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swiftDemon
{
    class settings
    {
        private string _dbName;
        private string _dbPath;
        private string _inMess;
        private string _outMess;
        private string _inArhiv;
        private string _outArhiv;
        public settings()
        {
            _dbName = reestr.getParam("dbName");
            _dbPath = reestr.getParam("dbPath");
            _inMess = reestr.getParam("inMess");
            _outMess = reestr.getParam("outMess");
            _inArhiv = reestr.getParam("inArhiv");
            _outArhiv = reestr.getParam("outArhiv");
        }
        public string dbName
        {
            get { return _dbName; }
            set
            {
                if (value != "")
                {
                    reestr param = new reestr("dbName", value);
                }
            }
        }
        public string dbPath
        {
            get { return _dbPath; }
            set
            {
                if (value != "")
                {
                    reestr param = new reestr("dbPath", value);
                }
            }
        }
        public string inMess
        {
            get { return _inMess; }
            set
            {
                if (value != "")
                {
                    reestr param = new reestr("inMess", value);
                }
            }
        }
        public string outMess
        {
            get { return _outMess; }
            set
            {
                if (value != "")
                {
                    reestr param = new reestr("outMess", value);
                }
            }
        }
        public string inArhiv
        {
            get { return _inArhiv; }
            set
            {
                if(value!="")
                {
                    reestr param = new reestr("inArhiv", value);
                }
            }
        }
        public string outArhiv
        {
            get { return _outArhiv; }
            set
            {
                if(value!="")
                {
                    reestr param = new reestr("outArhiv", value);
                }
            }
        }
    }
    class reestr
    {
        public static string path = @"Software\swift";
        private string _nameParam;
        private string _valueParam;
        public reestr(string paramName, string val)
        {
            //path = @".DEFAULT\Software\swift";
            nameParam = paramName;
            valueParam = val;
        }
       /* public static string path
        {
            get
            {
                if (_path != "") return _path;
                else
                {
                    path = @"\Software\swift";
                    return path;
                }
            }
            set
            {
                if (value != "")
                {
                    Microsoft.Win32.RegistryKey key;
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"\Software\" + path);
                    //key = Microsoft.Win32.Registry.Users.CreateSubKey(@".DEFAULT\Software\md5HeshTest"); ///.LocalMachine.CreateSubKey(@"SOFTWARE\md5");
                    _path = value;
                }

                else
                {
                    //throw new Exception(@"ошибка доступа к ветке реестра .DEFAULT\Software\md5HeshTest");
                    Microsoft.Win32.RegistryKey key;
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"\Software\swift");
                    _path = "swift";
                }
            }
        }*/
        public string nameParam
        {
            get { return _nameParam; }
            set
            {
                if (value != "")
                {
                    _nameParam = value;
                }
                else
                {
                    throw new ApplicationException("Не задан тип параметра");
                }
            }
        }

        public string valueParam
        {
            get { return _valueParam; }
            set
            {
                if (value != "")
                {

                    Microsoft.Win32.RegistryKey key;
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(path);
                    _valueParam = value;
                    key.SetValue(nameParam, _valueParam);
                    key.Close();

                }
                else
                    throw new ApplicationException("Не задано значение параметра");
            }
        }
        public static string getParam(string name)
        {
            string str = "HKEY_CURRENT_USER" + path + name;
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(path);
            return rk.GetValue(name).ToString();
        }

        public static string getParam(string prefix, string name)
        {
            string str = "HKEY_CURRENT_USER" + path + prefix + name;
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(path + prefix);
            System.Windows.Forms.MessageBox.Show(rk.GetValue(name).ToString());
            return rk.GetValue(name).ToString();
        }
        public static void setParam(string prefix, string name, string value)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(path + prefix);
            key.SetValue(name, value);
            key.Close();
        }
    }
}
