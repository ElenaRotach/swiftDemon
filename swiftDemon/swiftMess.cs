using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public string id = "";

        public swiftMess(string strMess, string fn, string direction)
        {
            this.direction = direction;
            if (strMess.Length>0)
            {
                fileName = fn;
                thread = strMess.Replace("'", "\'\'").Replace(@"\", @"\\");
                //parse(strMess);
                int ind = strMess.IndexOf("FIN");
                if(ind != -1)
                {
                    //получаем fin
                    fin = strMess.Substring(ind + 4, 3);
                    //System.Windows.Forms.MessageBox.Show(fin);
                    //Application.Exit();
                    switch (fin)
                    {
                        case "103":
                            parse103(strMess);
                            break;
                        case "202":
                            parse202(strMess);
                            break;
                        case "299":
                            parse299(strMess);
                            break;
                        case "300":
                            parse300(strMess);
                            break;
                        case "320":
                            parse320(strMess);
                            break;
                        case "900":
                            parse900(strMess);
                            break;
                        case "910":
                            parse910(strMess);
                            break;
                        default:
                            parse(strMess);
                            break;
                    }
                }
                else
                {
                    parse(strMess);
                }
            }
        }
        public swiftMess(string strMess, string fn)
        {
            if (strMess.Length > 0)
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
                if (workArr[ind].IndexOf("Sender   : ") != -1)
                {
                    swiftNumberBankKontragent = workArr[ind].Split(':')[1];
                    naimBankKontragent = workArr[ind + 1] + " " + workArr[ind + 2];
                }
                if (workArr[ind].IndexOf("20: Sender's Reference") != -1)
                {
                    transactionReferenceNumber_20 = workArr[ind + 1];
                }
                if (workArr[ind].IndexOf("32A: Val Dte/Curr/Interbnk Settld Amt ") != -1)
                {
                    string[] dateStr = (workArr[ind + 1].Split(':')[1]).Split(' ');
                    date_32 = new DateTime(Convert.ToInt32(dateStr[2]), thesaurus.mount(dateStr[1]), Convert.ToInt32(dateStr[0]));
                    currency_32 = workArr[ind + 2].Split(':')[1].Split('(')[0];
                    amount_32 = Convert.ToDouble(workArr[ind + 3].Split('#')[1]);
                }
                if (workArr[ind].IndexOf("50K: Ordering Customer-Name & Address") != -1)
                {
                    orderingCustomer_50 = workArr[ind + 1] + ' ' + workArr[ind + 2];
                }
                if (workArr[ind].IndexOf("57A: Account With Institution - FI BIC") != -1)
                {
                    accountWithInstitution_57 = workArr[ind + 1] + ' ' + workArr[ind + 2] + ' ' + workArr[ind + 3];
                }
                if (workArr[ind].IndexOf("59: Beneficiary Customer-Name & Addr") != -1)
                {
                    beneficiaryCustomer_59 = workArr[ind + 1] + ' ' + workArr[ind + 2];
                }
                if (workArr[ind].IndexOf("32B: Currency and Principal Amount") != -1)
                {
                    currency_32 = workArr[ind + 1].Split(':')[1].Split('(')[0];
                    amount_32 = Convert.ToDouble(workArr[ind + 2].Split('#')[1]);
                }
            }
        }
        private void parse103(string str)
        {
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
                
                if (workArr[ind].IndexOf("32A: Val Dte/Curr/Interbnk Settld Amt ") != -1)
                {
                    string[] dateStr = (workArr[ind + 1].Split(':')[1]).Split(' ');
                    date_32 = new DateTime(Convert.ToInt32(dateStr[3]), thesaurus.mount(dateStr[2]), Convert.ToInt32(dateStr[1]));
                    currency_32 = workArr[ind + 2].Split(':')[1].Split('(')[0];
                    amount_32 = Convert.ToDouble(workArr[ind + 3].Split('#')[1]);
                }
                if (workArr[ind].IndexOf("50K: Ordering Customer-Name & Address") != -1)
                {
                    orderingCustomer_50 = workArr[ind + 1] + ' ' + workArr[ind + 2];
                }
                if (workArr[ind].IndexOf("57A: Account With Institution - FI BIC") != -1)
                {
                    accountWithInstitution_57 = workArr[ind + 1] + ' ' + workArr[ind + 2] + ' ' + workArr[ind + 3];
                }
                if (workArr[ind].IndexOf("59: Beneficiary Customer-Name & Addr") != -1)
                {
                    beneficiaryCustomer_59 = workArr[ind + 1] + ' ' + workArr[ind + 2];
                }
            }
            MessageBox.Show("103");
        }
        private void parse202(string str)
        {
            MessageBox.Show("202");
        }
        private void parse299(string str)
        {
            MessageBox.Show("299");
        }
        private void parse300(string str)
        {
            MessageBox.Show("300");
        }
        private void parse320(string str)
        {
            MessageBox.Show("320");
        }
        private void parse900(string str)
        {
            MessageBox.Show("900");
        }
        private void parse910(string str)
        {
            MessageBox.Show("910");
        }
    }
    public class swiftMess_str
    {
        public string transactionReferenceNumber_20 = "";
        public string valueDate_30V = "";
        public string date_32 = "";
        public string currency_32 = "";
        public string amount_32 = "";
        public string currency_33B = "";
        public string amount_33B = "";
        public string orderingCustomer_50 = "";
        public string orderingInstitution_52 = "";
        public string senderCorrespondent_53 = "";
        public string receiverCorrespondent_54 = "";
        public string intermediaryInstitution_56 = "";
        public string accountWithInstitution_57 = "";
        public string beneficiaryInstitution_58 = "";
        public string beneficiaryCustomer_59 = "";
        public string processingCharacteristic = "";
        public string mess_direction = "";
        public string comment = "";
        public string dateTime_mess = "";
        public string referenceMess = "";
        public string fin = "";
        public string swiftNumberBankKontragent = "";
        public string naimBankKontragent = "";
        public string thread = "";
        public string fileName = "";
        public string direction = "";
        public string id = "";
        public swiftMess_str(string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10, string p11, string p12, string p13, string p14, string p15, string p16,
            string p17, string p18, string p19, string p20, string p21, string p22, string p23, string p24, string p25, string p26, string p27)
        {
            transactionReferenceNumber_20 = p1;
            if (p2 != "" && p2 != "01.01.2001 0:00:00")
            {
                valueDate_30V = p2;
            }
            if (p3 != "" && p3 != "01.01.2001 0:00:00")
            {
                date_32 = p3;
            }
            currency_32 = p4;
            if (p5 != "" && p5 != "01.01.2001 0:00:00")
            {
                amount_32 = p5;
            }
            if (p6 != "" && p6 != "01.01.2001 0:00:00")
            {
                currency_33B = p6;
            }
            amount_33B = p7;
            orderingCustomer_50 = p8;
            orderingInstitution_52 = p9;
            senderCorrespondent_53 = p10;
            receiverCorrespondent_54 = p11;
            intermediaryInstitution_56 = p12;
            accountWithInstitution_57 = p13;
            beneficiaryInstitution_58 = p14;
            beneficiaryCustomer_59 = p15;
            processingCharacteristic = p16;
            mess_direction = p17;
            comment = p18;
            dateTime_mess = p19;
            referenceMess = p20;
            fin = p21;
            swiftNumberBankKontragent = p22;
            naimBankKontragent = p23;
            thread = p24;
            fileName = p25;
            direction = p26;
            id = p27;
        }
    }
}
