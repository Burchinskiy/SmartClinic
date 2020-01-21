using System;

namespace SmartClinicServer
{
    public static class Ticket
    {
        public static string[] GetQueueArray()
        {
            var smallTimeOut = 1;

            var queue = SQL.TableToOneString
            (SQL.SelectTransaction
            (SQL.GetQueue(),
            DataBase.ReadConfigFileDB(),
            smallTimeOut));

            queue = queue.Replace("\t\n", "\n");

            var queueArray = queue.Split(new char[] { '\t', '\n' });

            return queueArray;
        }

        public static string GetLastTicket()
        {
            var lastTicket =
                GenerateNextNumber
                (SQL.GetFirstCell
                (SQL.SelectTransaction
                (SQL.GetPenultTicket(),
                DataBase.ReadConfigFileDB())));
            return lastTicket;
        }

        public static string GenerateNextNumber(string previousTicketNumber)
        {
            if (string.Compare(previousTicketNumber, string.Empty) == 0 ||
                string.Compare(previousTicketNumber, "Я99") == 0)
            {
                return "А01";
            }

            string strLitera = previousTicketNumber;

            string strIndex = strLitera.Remove(0, 1);
            strLitera = strLitera.Remove(1, 2);

            int intIndex = Int32.Parse(strIndex);
            char chrLitera = Char.Parse(strLitera);

            if (intIndex == 99)
            {
                if (string.Compare(strLitera, "Е") == 0 ||
                    string.Compare(strLitera, "И") == 0 ||
                    string.Compare(strLitera, "Щ") == 0 ||
                    string.Compare(strLitera, "Ы") == 0)
                {
                    chrLitera = Convert.ToChar(chrLitera + 2);
                }
                else
                {
                    chrLitera = Convert.ToChar(chrLitera + 1);
                }
                intIndex = 1;
            }
            else
            {
                intIndex++;
            }

            strLitera = chrLitera.ToString();
            strIndex = intIndex.ToString("D2");

            return strLitera + strIndex;
        }
    }
}