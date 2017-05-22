using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;

namespace swiftDemon
{
    interface ILogs
    {
        //public metod проверка существования файла лога
        //bool existenceOfTheFile();
        //public metod создание файла лога
        //bool fileCreation();
        //public metod запись в лог
        void logEntry(string mess);
    }
    static class logs 
    {
        static string curFile = Environment.CurrentDirectory + @"\log.txt";
        //private bool existenceOfTheFile()
        //{
        //    bool end = false;
        //    if (File.Exists(curFile)) { end = true; }
        //    return end;
        //}
        //private bool fileCreation()
        //{
        //    try
        //    {
        //        if (existenceOfTheFile()) { return true; }
        //        else
        //        {
        //            File.Create(curFile);
        //            return true;
        //        }
        //    }
        //    catch { return false; }
        //}
        private static void logEntry(string mess)
        {
            //if (fileCreation())
            //{
                using (StreamWriter sw = File.AppendText(curFile))
                {
                    sw.WriteLine(mess);
                    sw.Close();
                }
            //}
        }
        public static void outStr(string str, bool err, swiftMess obj)
        {
            if (err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(str + '\n');
                Console.ResetColor();
                MessageBox.Show(str, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
            else
            {
                Console.WriteLine(str + '\n');
                if (obj != null)
                {
                    string sql = @"insert into mess (accountWithInstitution_57, amount_32, amount_33B, beneficiaryCustomer_59, beneficiaryInstitution_58, comment, сurrency_32" +
                        ",  сurrency_33B, dateTime_mess, date_32, fin, intermediaryInstitution_56, mess_direction, naimBankKontragent, orderingCustomer_50, orderingInstitution_52" +
                        ", processingCharacteristic, receiverCorrespondent_54, referenceMess, senderCorrespondent_53, swiftNumberBankKontragent, transactionReferenceNumber_20, valueDate_30V" +
                        ", fileName, thread) values('" + 
                        obj.accountWithInstitution_57 + "', '" + obj.amount_32 + "', '" + obj.amount_33B + "', '" + obj.beneficiaryCustomer_59 + "', '" + obj.beneficiaryInstitution_58 + "', '" +
                        obj.comment + "', '" + obj.currency_32 + "', '" + obj.currency_33B + "', '" + obj.dateTime_mess + "', '" + obj.date_32 + "', '" + obj.fin + "', '" + obj.intermediaryInstitution_56 + "', '" +
                        obj.mess_direction + "', '" + obj.naimBankKontragent + "', '" + obj.orderingCustomer_50 + "', '" + obj.orderingInstitution_52 + "', '" + obj.processingCharacteristic + "', '" +
                        obj.receiverCorrespondent_54 + "', '" + obj.referenceMess + "', '" + obj.senderCorrespondent_53 + "', '" + obj.swiftNumberBankKontragent + "', '" + obj.transactionReferenceNumber_20 + "', '" +
                        obj.valueDate_30V + "', '" + obj.fileName + "', '" + obj.thread + "')";
                    connectionDB.addDB(sql);
                }
                
            }
            //logs log = new logs();
            logs.logEntry(str + '\n');
        }
    }
}

