using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_2._1
{
    public class ATM
    {
        public enum denominations
        {
            Ten = 10,
            Fifty = 50,
            One_hundred = 100,
            Two_hundred = 200,
            Five_hundred = 500,
            Thousand = 1000,
            Two_thousand = 2000,
            Five_thousand = 5000
        }

        private string prop_ATM_id;
        private Dictionary<denominations, int> prop_banknotes = new Dictionary<denominations, int>();
        private List<string> blocked_account = new List<string>();

        public ATM()
        {
            string temp_str = "";
            temp_str = UserAccount.GenerateRandomString(4);
            List<string> existingATMs = ATMList.GetAllATMsByIds();
            while (existingATMs.Contains(temp_str))
            {
                temp_str = UserAccount.GenerateRandomString(4);
            }

            ATM_id = temp_str;
            blocked_account.AddRange(new[] { "foo", "bar", "baz" });
            foreach (denominations d in Enum.GetValues(typeof(denominations)))
            {
                prop_banknotes[d] = 0;
            }
            /*Banknotes = new Dictionary<denominations, int>(); 
            blocked_account = new List<string>();#1#*/
        }

        public ATM(Dictionary<denominations, int> banknotes)
        {
            var temp_str = "";
            temp_str = UserAccount.GenerateRandomString(4);
            var existingATMs = ATMList.GetAllATMsByIds();
            while (existingATMs.Contains(temp_str))
            {
                temp_str = UserAccount.GenerateRandomString(4);
            }

            ATM_id = temp_str;
            var prop_banknotes_here = new Dictionary<denominations, int>();
            foreach (denominations d in Enum.GetValues(typeof(denominations)))
            {
                prop_banknotes_here[d] = 0;
            }

            foreach (var kvp in banknotes)
            {
                // Проверяем, что ключ является допустимым значением перечисления denominations
                if (!denominations.IsDefined(typeof(denominations), kvp.Key))
                {
                    throw new ArgumentException($"Invalid denomination: {kvp.Key}");
                }

                if (kvp.Value < 0)
                {
                    throw new ArgumentException($"Invalid banknote count: {kvp.Value}");
                }

                // Записываем значения в словарь prop_banknotes
                prop_banknotes_here[kvp.Key] = kvp.Value;
            }

            prop_banknotes = prop_banknotes_here;
            blocked_account.AddRange(new[] { "foo", "bar", "baz" });
            /*prop_banknotes = new Dictionary<denominations, int>(); */
            /*blocked_account = new List<string>();*/
        }

        public string ATM_id
        {
            get => prop_ATM_id;
            set => prop_ATM_id = value;
        }

        public Dictionary<denominations, int> Banknotes
        {
            get => prop_banknotes;
            set => prop_banknotes = value;
        }

        public List<string> BlockedAccount
        {
            get => blocked_account;
            set => blocked_account = value;
        }

        public void AddBlockedAccount(string accountId)
        {
            BlockedAccount.Add(accountId);
        }

        public void RemoveBlockedAccount(int index)
        {
            BlockedAccount.RemoveAt(index);
        }

        public bool RemoveBlockedAccount(string accountId)
        {
            return BlockedAccount.Remove(accountId);
        }

        public void AddBlockedAccounts(List<string> accountIds)
        {
            BlockedAccount.AddRange(accountIds);
        }

        public void RemoveBlockedAccounts(List<string> accountIds)
        {
            BlockedAccount.RemoveAll(accountId => accountIds.Contains(accountId));
        }
        
        public string GetBanknotesString()
        {
            Dictionary<int, int> prop_banknotes_here = new Dictionary<int, int>();
            StringBuilder sb = new StringBuilder();
            foreach (denominations d in Enum.GetValues(typeof(denominations)))
            {
                prop_banknotes_here[(int)d] = 0;
            }
            foreach (var kvp in prop_banknotes)
            {
                denominations d = (denominations)kvp.Key;
                prop_banknotes_here[(int)d] = kvp.Value;
            }
            /*prop_banknotes_here = prop_banknotes;*/
            foreach (KeyValuePair<int, int> kvp in prop_banknotes_here)
            {
                sb.Append(kvp.Key.ToString() + "\t:\t " + kvp.Value.ToString() + "\n");
            }
            if (sb.Length > 0)
            {
                sb.Length--; // удалить последний символ - лишний символ новой строки
            }
            return sb.ToString();
        }
        
        public string GetBanknotesDenominationsString()
        {
            Dictionary<int, int> prop_banknotes_here = new Dictionary<int, int>();
            StringBuilder sb = new StringBuilder();
            foreach (denominations d in Enum.GetValues(typeof(denominations)))
            {
                prop_banknotes_here[(int)d] = 0;
            }
            foreach (var kvp in prop_banknotes)
            {
                denominations d = (denominations)kvp.Key;
                prop_banknotes_here[(int)d] = kvp.Value;
            }
            /*prop_banknotes_here = prop_banknotes;*/
            foreach (KeyValuePair<int, int> kvp in prop_banknotes_here)
            {
                sb.Append(kvp.Key.ToString() + "\n");
            }
            if (sb.Length > 0)
            {
                sb.Length--; // удалить последний символ - лишний символ новой строки
            }
            return sb.ToString();
        }
        public string GetBanknotesVaulesString()
        {
            Dictionary<int, int> prop_banknotes_here = new Dictionary<int, int>();
            StringBuilder sb = new StringBuilder();
            foreach (denominations d in Enum.GetValues(typeof(denominations)))
            {
                prop_banknotes_here[(int)d] = 0;
            }
            foreach (var kvp in prop_banknotes)
            {
                denominations d = (denominations)kvp.Key;
                prop_banknotes_here[(int)d] = kvp.Value;
            }
            /*prop_banknotes_here = prop_banknotes;*/
            foreach (KeyValuePair<int, int> kvp in prop_banknotes_here)
            {
                sb.Append(kvp.Value.ToString() + "\n");
            }
            if (sb.Length > 0)
            {
                sb.Length--; // удалить последний символ - лишний символ новой строки
            }
            return sb.ToString();
        }

        public string GetBlockedCardsString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in blocked_account)
            {
                sb.Append(item + "\n");
            }
            return sb.ToString();
        }
        
    }
}