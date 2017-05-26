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
        public settings obj = new settings();
        public string connectionString; //= @"Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" +  + @"\swift.mdb";

        OleDbDataReader initConnect(string strQuery)
        {
            connectionString = @"Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + obj.dbPath + obj.dbName;
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
                while (myOleDbDataReader.Read())
                { }
                myOleDbDataReader.Close();
            }
            catch(Exception e)
            {
                logs.outStr(e.Message, true, null);
                logs.outStr(e.StackTrace, true, null);
            }
        }
        public OleDbDataReader initConnectRet(string strQuery)
        {
            //propertyDB connectionStringProp = new propertyDB();
            //System.Windows.Forms.MessageBox.Show("test");
            //проблемы при запуске через терминал
            //string connectionString = @"Provider=SQLOLEDB;Data Source=" + connectionStringProp.ServerDB + ";Password=curr;User ID=" + connectionStringProp.UserDB + ";Initial Catalog=" + connectionStringProp.NameDB;
            string connectionString = @"Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + obj.dbPath + obj.dbName;
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
            myOleDbCommand.CommandText = strQuery;
            myOleDbConnection.Open();
            OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader();
            return myOleDbDataReader;
        }
    }
}
