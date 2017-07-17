using System;
using System.Collections.Generic;
using System.Globalization;
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
            referenceMess = workArr[3].Split(' ')[12].Replace("MPALLout-", "").Replace("MpALLack-", "");
            if(referenceMess=="")
            {
                referenceMess = workArr[3].Split(' ')[16].Replace("MpALLack-", "");
                referenceMess = referenceMess.Replace("'", "''");
            }
            for (int ind = 0; ind < workArr.Length; ind++)
            {
                if (workArr[ind].IndexOf("Sender   : ") != -1)
                {
                    swiftNumberBankKontragent = workArr[ind].Split(':')[1];
                    swiftNumberBankKontragent = swiftNumberBankKontragent.Replace("'", "''");
                    naimBankKontragent = workArr[ind + 1] + " " + workArr[ind + 2];
                    naimBankKontragent = naimBankKontragent.Replace("'", "''");
                }

                if (workArr[ind].IndexOf("20: Sender's Reference") != -1 || workArr[ind].IndexOf("20: Transaction Reference Number") != -1)
                {
                    transactionReferenceNumber_20 = workArr[ind + 1];
                    transactionReferenceNumber_20 = transactionReferenceNumber_20.Replace("'", "''");
                }
                if (workArr[ind].IndexOf("30V: Value Date") != -1)
                {
                    string dateStr = workArr[ind + 1].Replace(" ", "");
                    valueDate_30V = new DateTime(Convert.ToInt32(dateStr.Substring(0, 4)), Convert.ToInt32(dateStr.Substring(4, 2)), Convert.ToInt32(dateStr.Substring(6, 2)));
                }

                if (workArr[ind].IndexOf("32A:") != -1 || workArr[ind].IndexOf("32D:") != -1)
                {
                    if (fin == "192" || fin == "195" || fin == "196") {
                        /*170609CNY31724,33*/
                        string workStr = workArr[ind].Replace(" ", "");
                        date_32 = new DateTime(Convert.ToInt32(workStr.Substring(5, 2)), Convert.ToInt32(workStr.Substring(7, 2)), Convert.ToInt32(workStr.Substring(9,2)));
                        currency_32 = new string(workStr.Substring(5, workStr.Length-5).Where(Char.IsLetter).ToArray());
                        amount_32 = Convert.ToDouble(workStr.Substring(workStr.IndexOf(currency_32)+currency_32.Length));
                    }
                    else
                    {
                        string[] dateStr = (workArr[ind + 1].Split(':')[1]).Split(' ');
                        date_32 = new DateTime(Convert.ToInt32(dateStr[3]), thesaurus.mount(dateStr[2]), Convert.ToInt32(dateStr[1]));
                        currency_32 = workArr[ind + 2].Split(':')[1].Split('(')[0];
                        amount_32 = Convert.ToDouble(workArr[ind + 3].Split('#')[1]);
                    }
                }

                if (workArr[ind].IndexOf("32B:") != -1)
                {
                    currency_32 = workArr[ind + 1].Split(':')[1].Split('(')[0];
                    amount_32 = Convert.ToDouble(workArr[ind + 2].Split('#')[1]);
                }
                if (workArr[ind].IndexOf("33B: Currency, Amount") != -1)
                {
                    currency_33B = workArr[ind + 1].Split(':')[1].Split('(')[0];
                    amount_33B = Convert.ToDouble(workArr[ind + 2].Split('#')[1]);
                }
                if (workArr[ind].IndexOf("50K:") != -1)
                {
                    orderingCustomer_50 = workArr[ind + 1] + ' ' + workArr[ind + 2];
                    orderingCustomer_50 = orderingCustomer_50.Replace("'", "''");
                }
                if (workArr[ind].IndexOf("52D:") != -1 || workArr[ind].IndexOf("52A:") != -1)
                {
                    this.orderingInstitution_52 = workArr[ind + 1];
                    orderingInstitution_52 = orderingInstitution_52.Replace("'", "''");
                }
                if (workArr[ind].IndexOf("53B:") != -1)
                {
                    senderCorrespondent_53 = workArr[ind + 1];
                    senderCorrespondent_53 = senderCorrespondent_53.Replace("'", "''");
                }
                if (workArr[ind].IndexOf("57A:") != -1 || workArr[ind].IndexOf("57D:") != -1)
                {
                    if (fin != "320")
                    {
                        accountWithInstitution_57 += workArr[ind + 1] + ' ' + workArr[ind + 2] + ' ' + workArr[ind + 3];
                        accountWithInstitution_57 = accountWithInstitution_57.Replace("'", "''");
                    }
                }
                if (workArr[ind].IndexOf("58A:") != -1)
                {
                    beneficiaryInstitution_58 = workArr[ind + 1] + ' ' + workArr[ind + 2] + ' ' + workArr[ind + 3];
                    beneficiaryInstitution_58 = beneficiaryInstitution_58.Replace("'", "''");
                }
                if (workArr[ind].IndexOf("59: Beneficiary Customer-Name & Addr") != -1)
                {
                    //MessageBox.Show(ind.ToString());
                    beneficiaryCustomer_59 = workArr[ind + 1] + ' ' + workArr[ind + 2];
                    beneficiaryCustomer_59 = beneficiaryCustomer_59.Replace("'", "''");
                }
            }
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

        /*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
       /* public static string transactionReferenceNumber_20_n = "transactionReferenceNumber_20";
        public static string valueDate_30V_n = "valueDate_30V";
        public static string date_32_n = "date_32";
        public static string currency_32_n = "currency_32";
        public static string amount_32_n = "amount_32";
        public static string currency_33B_n = "currency_33B";
        public static string amount_33B_n = "amount_33B";
        public static string orderingCustomer_50_n = "orderingCustomer_50";
        public static string orderingInstitution_52_n = "orderingInstitution_52";
        public static string senderCorrespondent_53_n = "senderCorrespondent_53";
        public static string receiverCorrespondent_54_n = "receiverCorrespondent_54";
        public static string intermediaryInstitution_56_n = "intermediaryInstitution_56";
        public static string accountWithInstitution_57_n = "accountWithInstitution_57";
        public static string beneficiaryInstitution_58_n = "beneficiaryInstitution_58";
        public static string beneficiaryCustomer_59_n = "beneficiaryCustomer_59";
        public static string processingCharacteristic_n = "processingCharacteristic";
        public static string mess_direction_n = "mess_direction";
        public static string comment_n = "comment";
        public static string dateTime_mess_n = "dateTime_mess";
        public static string referenceMess_n = "referenceMess";
        public static string fin_n = "fin";
        public static string swiftNumberBankKontragent_n = "swiftNumberBankKontragent";
        public static string naimBankKontragent_n = "naimBankKontragent";
        public static string thread_n = "thread";
        public static string fileName_n = "fileName";
        public static string direction_n = "direction";
        public static string id_n = "id";*/
        /*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
        public swiftMess_str(string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10, string p11, string p12, string p13, string p14, string p15, string p16,
            string p17, string p18, string p19, string p20, string p21, string p22, string p23, string p24, string p25, string p26, string p27)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = " ";

            transactionReferenceNumber_20 = p1;
            if (p2 != "" && p2 != "01.01.2001 0:00:00")
            {
                valueDate_30V = p2.Substring(0,10);
            }
            if (p3 != "" && p3 != "01.01.2001 0:00:00")
            {
                date_32 = p3.Substring(0, 10);
            }
            currency_32 = p4;
            amount_32 = Convert.ToDouble(p5).ToString("N", nfi); //(Convert.ToUInt32(p5)).ToString("N", nfi);
            currency_33B = p6;

            amount_33B = Convert.ToDouble(p7).ToString("N", nfi); //(Convert.ToUInt32(p7)).ToString("N", nfi);
            orderingCustomer_50 = p8;
            orderingInstitution_52 = p9;
            senderCorrespondent_53 = p10;
            receiverCorrespondent_54 = p11;
            intermediaryInstitution_56 = p12;
            accountWithInstitution_57 = p13;
            beneficiaryInstitution_58 = p14;
            beneficiaryCustomer_59 = p15;
            processingCharacteristic = p16;
            if(p17 == "")
            {
                p17 = "False";
            }
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
            while(id.Length<7)
            {
                id = '0' + id;
            }
        }
    }
}
