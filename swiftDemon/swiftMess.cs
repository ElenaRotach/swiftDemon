using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swiftDemon
{
    class swiftMess
    {
        public string transactionReferenceNumber_20 = "";
        public DateTime valueDate_30V = new DateTime();
        public DateTime date_32 = new DateTime();
        public string currency_32 = "";
        public double amount_32 = 0;
        public string currency_33B = "";
        public double amount_33B = 0;
        public string orderingCustomer_50 = "";
        public string orderingInstitution_52 = "";
        public string senderCorrespondent_53 = "";
        public string receiverCorrespondent_54 = "";
        public string intermediaryInstitution_56 = "";
        public string accountWithInstitution_57 = "";
        public string beneficiaryInstitution_58 = "";
        public string beneficiaryCustomer_59 = "";
        public string processingCharacteristic = "";
        public bool mess_direction = false;
        public string comment = "";
        public DateTime dateTime_mess = new DateTime();
        public string referenceMess = "";
        public string fin = "";
        public string swiftNumberBankKontragent = "";
        public string naimBankKontragent = "";
        public string thread = "";
        public string fileName = "";
        public string direction = "";
        public swiftMess(string strMess, string fn, string direction)
        {
            this.direction = direction;
            if (strMess.Length>0)
            {
                fileName = fn;
                thread = strMess.Replace("'", "\'\'").Replace(@"\", @"\\");
                parse(strMess);
            }
        }
        private void parse(string str)
        {
            //thread = @str;
            str = str.Replace("\n", "").Replace("\t", "");
            String[] workArr = str.Split('\r');
            dateTime_mess = DateTime.Parse((workArr[3].Split(' ')[0]).Replace("-", " "));
            referenceMess = workArr[3].Split(' ')[12].Replace("MPALLout-", "");
            for (int ind = 0; ind < workArr.Length; ind++)
            {
                if (workArr[ind].IndexOf("Swift Output                  : FIN") != -1)
                {
                    char[] test = workArr[ind].Where(x => Char.IsDigit(x)).ToArray();
                    fin = new string(test);
                }
                if (workArr[ind].IndexOf("Sender   : ") != -1)
                {
                    swiftNumberBankKontragent = workArr[ind].Split(':')[1];
                    naimBankKontragent = workArr[ind + 1] + " " + workArr[ind + 2];
                }
                if (workArr[ind].IndexOf("20: Sender's Reference") != -1)
                {
                    transactionReferenceNumber_20 = workArr[ind + 1];
                }
                if (workArr[ind].IndexOf("30V: Value Date") != -1)
                {
                    valueDate_30V = new DateTime(Convert.ToInt32(workArr[ind + 1].Replace(" ", "").Substring(0, 4)), Convert.ToInt32(workArr[ind + 1].Replace(" ", "").Substring(4, 2)), Convert.ToInt32(workArr[ind + 1].Replace(" ", "").Substring(6, 2)));
                }
                if (workArr[ind].IndexOf("32B: Currency and Principal Amount") != -1)
                {
                    currency_32 = workArr[ind + 1].Split(':')[1].Split('(')[0];
                    amount_32 = Convert.ToDouble(workArr[ind + 2].Split('#')[1]);
                }

            }
        }
    }
}
