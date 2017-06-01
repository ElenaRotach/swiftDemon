using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swiftDemon
{
    public static class thesaurus
    {
        public static List<string> conditions = new List<string>(new[] {">", ">=", "<", "<=", "=", "<>", "LIKE"});
        public static Dictionary<string, string> columnsType = new Dictionary<string, string> {
            { "transactionReferenceNumber_20", "string"},
            {"valueDate_30V", "date" },
            {"date_32", "date" },
            {"currency_32", "string" },
            {"amount_32", "double" },
            {"currency_33B", "string" },
            {"amount_33B", "double" },
            {"orderingCustomer_50", "string" },
            {"orderingInstitution_52", "string" },
            {"senderCorrespondent_53", "string" },
            {"receiverCorrespondent_54", "string" },
            {"intermediaryInstitution_56", "string" },
            {"accountWithInstitution_57", "string" },
            {"beneficiaryInstitution_58", "string" },
            {"beneficiaryCustomer_59", "string" },
            {"processingCharacteristic", "string" },
            {"mess_direction", "bool" },
            {"comment", "string" },
            {"dateTime_mess", "string" },
            {"referenceMess", "string" },
            {"fin", "string" },
            {"swiftNumberBankKontragent", "string" },
            {"naimBankKontragent", "string" },
            {"thread", "string" },
            {"fileName", "string" },
            {"direction", "string" },
            {"id", "int" }
        };

        public static string getType(string name)
        {
            string value = "string";
            if (columnsType.ContainsKey(name))
            {
                columnsType.TryGetValue(name, out value);
            }
            return value;
        }
        public static int mount(string name)
        {
            Dictionary<string, int> mount = new Dictionary<string, int>();
            mount.Add("January", 1);
            mount.Add("February", 2);
            mount.Add("March", 3);
            mount.Add("April", 4);
            mount.Add("May", 5);
            mount.Add("June", 6);
            mount.Add("July", 7);
            mount.Add("August", 8);
            mount.Add("September", 9);
            mount.Add("October", 10);
            mount.Add("November", 11);
            mount.Add("December", 12);
            return mount[name];
        }
    }
}
