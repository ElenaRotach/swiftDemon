using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swiftDemon
{
    class connectionDB
    {
        public static string connectionString = @"Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + @"\swift.mdb";

        OleDbDataReader initConnect(string strQuery)
        {
            OleDbConnection myOleDbConnection;
            OleDbDataReader myOleDbDataReader = null;
            try
            {
                myOleDbConnection = new OleDbConnection(connectionString);
                OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
                myOleDbCommand.CommandText = strQuery;
                myOleDbConnection.Open();
                myOleDbDataReader = myOleDbCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                logs.outStr(e.Message, true, null);
                logs.outStr(e.StackTrace, true, null);
            }
            return myOleDbDataReader;
        }
        public static void addDB(string str)
        {
            try
            {
                connectionDB newConnect = new connectionDB();
                //string strQuery = @"insert into mess (dateTime_mess, fin, transactionReferenceNumber_20, valueDate_30V, date_32, сurrency_32, amount_32, сurrency_33B, amount_33B, orderingCustomer_50, " +
                //                    @"orderingInstitution_52, senderCorrespondent_53, receiverCorrespondent_54, intermediaryInstitution_56, accountWithInstitution_57, beneficiaryInstitution_58, beneficiaryCustomer_59, " +
                //                    @"processingCharacteristic, mess_direction, comment) values(" + , '1', '1', now(), now(), '1', 100.00, '1', 100.00, '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1')";
                OleDbDataReader myOleDbDataReader = newConnect.initConnect(str);
                myOleDbDataReader.Close();
            }
            catch(Exception e)
            {
                logs.outStr(e.Message, true, null);
                logs.outStr(e.StackTrace, true, null);
            }
        }
    }
}
