using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace transliter_RUENGRU
{
    public static class translite
    {
        static Dictionary<int, string> ru = new Dictionary<int, string>() {
            { 1072, "A"}, {1040, "A"}, { 1073, "B" }, {1041, "B" }, {1074, "V" }, { 1042, "V" }, {1075, "G" }, {1043, "G" }, {1076, "D" }, { 1044, "D" }, { 1077, "E" }, { 1045, "E" },
            { 1105, "o" }, { 1025, "o" }, { 1078, "J" }, { 1046, "J" }, { 1079, "Z" }, { 1047, "Z" }, { 1080, "I" }, { 1048, "I" }, { 1081, "i" }, { 1049, "i" }, { 1082, "K" }, { 1050, "K" },
            { 1083, "L" }, { 1051, "L" }, { 1084, "M" }, { 1052, "M" }, { 1085, "N" }, { 1053, "N" }, { 1086, "O" }, { 1054, "O" }, { 1087, "P" }, { 1055, "P" }, { 1088, "R" }, { 1056, "R" },
            { 1089, "S" }, { 1057, "S" }, { 1090, "T" }, { 1058, "T" }, { 1091, "U" }, { 1059, "U" }, { 1092, "F" }, { 1060, "F" }, { 1093, "H" }, { 1061, "H" }, { 1094, "C" }, { 1062, "C" },
            { 1095, "c" }, { 1063, "c" }, { 1096, "Q" }, { 1064, "Q" }, { 1097, "q" }, { 1065, "q" }, { 1098, "x" }, { 1066, "x" }, { 1099, "Y" }, { 1067, "Y" }, { 1100, "X" }, { 1068, "X" },
            { 1101, "e" }, { 1069, "e" }, { 1102, "u" }, { 1070, "u" }, { 1103, "a" }, { 1071, "a" }, { 39, "j" }, { 8217, "j" }, { 8216, "j" }, { 96, "j" }, { 48, "0" }, { 49, "1" },
            { 50, "2" }, { 51, "3" }, { 52, "4" }, { 53, "5" }, { 54, "6" }, { 55, "7" }, { 56, "8" }, { 57, "9" }, { 40, "(" }, { 41, ")" }, { 63, "?" }, { 43, "+" }, { 8470, "n" }, { 35, "n" },
            { 37, "p" }, { 38, "d" }, { 44, "," }, { 10, "\r" }, { 13, "\n" }, { 47, "/" }, { 45, "-" }, { 46, "." }, { 58, ":" }, { 32, " " }, { 33, "b" }, { 36, "s" }, { 59, "v" }, { 92, "/" },
            {124, "/" }, { 95, "z" }, { 61, "r" }, { 60, "(" }, { 62, ")" }, { 91, "(" }, { 93, ")" }, {123, "(" }, { 125, ")" }, { 8221, "m" }, { 8220, "m" }, { 171, "m" }, { 187, "m" },
            { 42, "*" }, { 64, "*" }, { 94, "*" }, { 126, "f" }
        }; /*key - код кириллицы, value - транслит англ.симв.*/
        static Dictionary<int, string> eng = new Dictionary<int, string>() {
            { 90, "З" }, { 88, "Ь" }, { 67, "Ц" }, { 86, "В" }, { 66, "Б" }, { 78, "Н" }, { 77, "М" }, { 65, "А" }, { 83, "С" }, { 68, "Д" }, { 70, "Ф" }, { 71, "Г" }, {72, "Х" }, { 74, "Ж" },
            { 75, "К" }, { 76, "Л" }, { 81, "Ш" }, { 69, "Е" }, { 82, "Р" }, { 84, "Т" }, { 89, "Ы" }, { 85, "У" }, { 73, "И" }, { 79, "О" }, { 80, "П" }, { 111, "Ё" }, { 105, "Й" }, { 99, "Ч" },
            { 113, "Щ" }, { 120, "Ъ" }, { 101, "Э" }, { 117, "Ю" }, { 97, "Я" }, { 106, "'" }, { 48, "0" }, { 49, "1" }, {50, "2" }, { 51, "3" }, { 52, "4" }, { 53, "5" }, { 54, "6" }, { 55, "7" },
            { 56, "8" }, { 57, "9" }, { 40, "(" }, { 41, ")" }, { 63, "?" }, { 43, "+" }, { 110, "№" }, { 112, "%" }, { 100, "&" }, { 44, "," }, { 47, "/" }, { 45, "-" }, { 46, "." }, { 58, ":" },
            { 98, "!" }, { 115, "$" }, { 118, ";" }, { 122, "_" }, { 114, "=" }, {109, "\"" }, { 102, "*" }, { 32, " " }, { 10, "\r" }, { 13, "\n" }
        }; /*key - код англ.симв., value - транслит кириллицы*/ 
        public static string go(string str)
        {
            string strOut = "";
            bool f1 = false;
            try
            {
                string[] mass = str.Split(' ');
                for(int z=0;z<mass.Length;z++)
                {
                    string el = mass[z];
                    string elNew = "";//необходимо преобразование
                    string rez = "";
                    if (el == "") { strOut += ' '; }
                    else {
                        if (translite.ru.TryGetValue((int)el[0], out rez) && f1)
                        {
                            strOut += "\'";
                            f1 = false;
                        }
                        if (patternCheck(el, ref f1, out elNew)) { rez = elNew; }
                        else { rez = transf(el, ref f1); }

                        if (strOut.Length == 0) { strOut = rez; }
                        else { strOut += (" " + rez); }
                    }

                }

               // Clipboard.SetText(strOut);
            }
            catch(Exception e) {
                System.Windows.Forms.MessageBox.Show("Ошибка при транслитерации символа - " + e.Message);
            }
            
            return (strOut);
        }
        public static void init()
        {
            //ru.Add(1072, "A"); ru.Add(1040, "A"); ru.Add(1073, "B"); ru.Add(1041, "B"); ru.Add(1074, "V"); ru.Add(1042, "V");
            //ru.Add(1075, "G"); ru.Add(1043, "G"); ru.Add(1076, "D"); ru.Add(1044, "D"); ru.Add(1077, "E"); ru.Add(1045, "E");
            //ru.Add(1105, "o"); ru.Add(1025, "o"); ru.Add(1078, "J"); ru.Add(1046, "J"); ru.Add(1079, "Z"); ru.Add(1047, "Z");
            //ru.Add(1080, "I"); ru.Add(1048, "I"); ru.Add(1081, "i"); ru.Add(1049, "i"); ru.Add(1082, "K"); ru.Add(1050, "K");
            //ru.Add(1083, "L"); ru.Add(1051, "L"); ru.Add(1084, "M"); ru.Add(1052, "M"); ru.Add(1085, "N"); ru.Add(1053, "N");
            //ru.Add(1086, "O"); ru.Add(1054, "O"); ru.Add(1087, "P"); ru.Add(1055, "P"); ru.Add(1088, "R"); ru.Add(1056, "R");
            //ru.Add(1089, "S"); ru.Add(1057, "S"); ru.Add(1090, "T"); ru.Add(1058, "T"); ru.Add(1091, "U"); ru.Add(1059, "U");
            //ru.Add(1092, "F"); ru.Add(1060, "F"); ru.Add(1093, "H"); ru.Add(1061, "H"); ru.Add(1094, "C"); ru.Add(1062, "C");
            //ru.Add(1095, "c"); ru.Add(1063, "c"); ru.Add(1096, "Q"); ru.Add(1064, "Q"); ru.Add(1097, "q"); ru.Add(1065, "q");
            //ru.Add(1098, "x"); ru.Add(1066, "x"); ru.Add(1099, "Y"); ru.Add(1067, "Y"); ru.Add(1100, "X"); ru.Add(1068, "X");
            //ru.Add(1101, "e"); ru.Add(1069, "e"); ru.Add(1102, "u"); ru.Add(1070, "u"); ru.Add(1103, "a"); ru.Add(1071, "a");
            //ru.Add(39, "j"); ru.Add(8217, "j"); ru.Add(8216, "j"); ru.Add(96, "j"); ru.Add(48, "0"); ru.Add(49, "1");
            //ru.Add(50, "2"); ru.Add(51, "3"); ru.Add(52, "4"); ru.Add(53, "5"); ru.Add(54, "6"); ru.Add(55, "7"); ru.Add(56, "8");
            //ru.Add(57, "9"); ru.Add(40, "("); ru.Add(41, ")"); ru.Add(63, "?"); ru.Add(43, "+"); ru.Add(8470, "n"); ru.Add(35, "n");
            //ru.Add(37, "p"); ru.Add(38, "d"); ru.Add(44, ","); ru.Add(10, "\r"); ru.Add(13, "\n"); ru.Add(47, "/"); ru.Add(45, "-");
            //ru.Add(46, "."); ru.Add(58, ":"); ru.Add(32, " "); ru.Add(33, "b"); ru.Add(36, "s"); ru.Add(59, "v"); ru.Add(92, "/");
            //ru.Add(124, "/"); ru.Add(95, "z"); ru.Add(61, "r"); ru.Add(60, "("); ru.Add(62, ")"); ru.Add(91, "("); ru.Add(93, ")");
            //ru.Add(123, "("); ru.Add(125, ")"); ru.Add(8221, "m"); ru.Add(8220, "m"); ru.Add(171, "m"); ru.Add(187, "m");
            //ru.Add(42, "*"); ru.Add(64, "*"); ru.Add(94, "*"); ru.Add(126, "f");//ru.Add(32, "    ");

            //eng.Add(90, "З"); eng.Add(88, "Ь"); eng.Add(67, "Ц"); eng.Add(86, "В"); eng.Add(66, "Б"); eng.Add(78, "Н");
            //eng.Add(77, "М"); eng.Add(65, "А"); eng.Add(83, "С"); eng.Add(68, "Д"); eng.Add(70, "Ф"); eng.Add(71, "Г");
            //eng.Add(72, "Х"); eng.Add(74, "Ж"); eng.Add(75, "К"); eng.Add(76, "Л"); eng.Add(81, "Ш"); eng.Add(69, "Е");
            //eng.Add(82, "Р"); eng.Add(84, "Т"); eng.Add(89, "Ы"); eng.Add(85, "У"); eng.Add(73, "И"); eng.Add(79, "О");
            //eng.Add(80, "П"); eng.Add(111, "Ё"); eng.Add(105, "Й"); eng.Add(99, "Ч"); eng.Add(113, "Щ"); eng.Add(120, "Ъ");
            //eng.Add(101, "Э"); eng.Add(117, "Ю"); eng.Add(97, "Я"); eng.Add(106, "'"); eng.Add(48, "0"); eng.Add(49, "1");
            //eng.Add(50, "2"); eng.Add(51, "3"); eng.Add(52, "4"); eng.Add(53, "5"); eng.Add(54, "6"); eng.Add(55, "7"); eng.Add(56, "8");
            //eng.Add(57, "9"); eng.Add(40, "("); eng.Add(41, ")"); eng.Add(63, "?"); eng.Add(43, "+"); eng.Add(110, "№");
            //eng.Add(112, "%"); eng.Add(100, "&"); eng.Add(44, ","); eng.Add(47, "/"); eng.Add(45, "-"); eng.Add(46, ".");
            //eng.Add(58, ":"); eng.Add(98, "!"); eng.Add(115, "$"); eng.Add(118, ";"); eng.Add(122, "_"); eng.Add(114, "=");
            //eng.Add(109, "\""); eng.Add(102, "*"); eng.Add(32, " "); eng.Add(10, "\r"); eng.Add(13, "\n");
        }
        private static string transf(string strTransf, ref bool f1Transf)
        {
            string result = "";
            for (int i = 0; i < strTransf.Length; i++)
            {
                char elTransf = strTransf[i];
                string valueTransf = "";

               // if()
                    if (!translite.ru.TryGetValue((int)elTransf, out valueTransf))
                    {
                        if (!f1Transf)
                        {
                            valueTransf = @"'" + elTransf;
                            f1Transf = true; //произошла смена на англ.яз.
                        }
                        else
                        {
                            valueTransf = elTransf.ToString();
                        }
                    }
                    else
                    {
                    if (f1Transf && Char.IsLetter(elTransf))
                    {
                        valueTransf = "'" + valueTransf;
                        f1Transf = false;
                    }
                    //else
                    //{
                    //    if (f1Transf)
                    //    {
                    //            valueTransf = "'" + valueTransf + "'";
                    //    }
                    //}
                    
                    }
                if (valueTransf == "j") { valueTransf = "'j'"; }
                result += valueTransf;
            }
            return result;
        }
        private static bool patternCheck(string patternStr,ref bool patternF1, out string patternResult)
        {
            bool patternTru = false;
//            string pattern = @"({[^а-яА-Я]})";
            patternResult = "";
            
            if (patternStr[0] == '{' && patternStr[patternStr.Length - 1] == '}' && !patternF1)
            {
                patternTru = true;
                //нет кириллицы
                patternResult = "\'" + ((patternStr.Replace("\'", "\'j\'")).Replace("{", "(")).Replace("}", ")") + "\'";
            }
            return patternTru;
        }
        public static string goEng(string str)
        {
            string strOut = "";
            bool f1 = false;
            try
            {
                string[] mass = str.Split(' ');
                for (int z = 0; z < mass.Length; z++)
                {
                    string el = mass[z];
                    string elNew = "";//необходимо преобразование
                    string rez = "";
                    if (el == "") { strOut += " "; }
                    else
                    {
                        rez = transfEng(el, ref f1);
                        if (strOut.Length == 0) {
                            if (rez.IndexOf("\n\r")>=0)
                            {
                                rez = rez.Replace("\n\r", "\r\n");
                            }
                            strOut = rez;
                        }
                        else {
                            if (rez.IndexOf("\n\r")>=0)
                            {
                                rez = rez.Replace("\n\r", "\r\n");//"\r\n";
                            }
                            strOut += (" " + rez);
                        }
                    }

                }

                //Clipboard.SetText(strOut, TextDataFormat.Text);
                //Clipboard.SetText(strOut);
            }
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show("Ошибка при транслитерации символа - " + e.Message);
            }

            return (strOut);
        }
        private static string transfEng(string strTransf, ref bool f1Transf)
        {
            //if (strTransf.IndexOf("VIaH:") >=0) {
            //    int asd = 1;
            //}

                string result = "";
            #region test
                int repet = 0;
                for (int q = 0; q < strTransf.Length; q++)
                {
                    if (strTransf[q] == 'j') { repet++; }
                }
            if (repet != 2 && repet != 0 && strTransf.IndexOf('\'')==-1)
            {
                if (f1Transf)
                {
                    string[] str = strTransf.Split('j');
                    result = str[0] + "'";
                    for (int z = 0; z < str[1].Length; z++)
                    {

                        string rez = "";
                        if (translite.eng.TryGetValue((int)(str[1])[z], out rez)) { result += rez; }
                    }
                    f1Transf = !f1Transf;
                }
                else
                {
                    string[] str = strTransf.Split('j');
                    for (int z = 0; z < str[0].Length; z++)
                    {

                        string rez = "";
                        if (translite.eng.TryGetValue((int)(str[0])[z], out rez)) { result += rez; }
                    }
                    result += ("'" + str[1]);
                    f1Transf = !f1Transf;
                }
            }
            else
            {
                if (f1Transf && strTransf.IndexOf('\'')==-1)
                {
                    result = strTransf;
                }
                #endregion test
                else
                {
                    #region 1
                    if (strTransf.ToString()[0] == '\'' && strTransf.ToString()[strTransf.ToString().Length - 1] == '\'')
                    {
                        #region if1
                        if (strTransf.ToString()[1] == '(' && strTransf.ToString()[strTransf.ToString().Length - 2] == ')')
                        {
                            result = "{";
                            #region for1
                            for (int q = 2; q < strTransf.ToString().Length - 2; q++)
                            {
                                result += strTransf.ToString()[q];
                            }
                            result += "}";
                            #endregion for1
                        }
                        else
                        {
                            result = strTransf.ToString().Replace("'", "");
                        }
                        #endregion if1
                    }
                    else
                    {
                        if (strTransf.ToString()[0] == 'j' && strTransf.ToString()[strTransf.ToString().Length - 1] == 'j')
                        { result = strTransf.Replace('j', '\''); }
                        else
                        {
                            #region for2
                            for (int i = 0; i < strTransf.Length; i++)
                            {
                                #region if6
                                char elTransf = strTransf[i];
                                string valueTransf = "";
                                if (elTransf == 'C' && strTransf[i + 1] == 'r' && strTransf[i + 2] == 'L' && strTransf[i + 3] == 'f')
                                {
                                    result += "\r\n";
                                    i += 4;
                                    elTransf = strTransf[i];
                                }
                                #region if5
                                if (elTransf == '\'')
                                {
                                    #region if3
                                    if (i + 2 < strTransf.Length && f1Transf)
                                    {
                                        #region if2
                                        if (elTransf == '\'' && strTransf[i + 1] == 'j' && strTransf[i + 2] == '\'')
                                        {
                                            i += 3;
                                            elTransf = strTransf[i];
                                            valueTransf = "'";
                                        }
                                        else
                                        {
                                            valueTransf = "";
                                            f1Transf = !f1Transf;
                                        }
                                        #endregion if2
                                    }
                                    else
                                    {
                                        f1Transf = !f1Transf;
                                        valueTransf += "";
                                    }
                                    #endregion if3
                                }
                                else
                                {
                                    #region if4
                                    if (f1Transf)
                                    {
                                        valueTransf += elTransf;
                                    }
                                    else
                                    {
                                        string rez = "";
                                        if (translite.eng.TryGetValue((int)elTransf, out rez)) { valueTransf = rez; }
                                    }
                                    #endregion if4
                                }
                                result += valueTransf;
                                #endregion if5
                                #endregion if6
                            }
                        }
                        #endregion for2
                    }
                }
            }
            #endregion 1
            return result;
        }
    }
}
