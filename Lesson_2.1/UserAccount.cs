using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Lesson_2._1
{
    public class UserAccount
    {
        private string _propId;

        private string _propPasswordHash;

        // True - кредитная, False - дебетовая
        private bool _propAccountType;
        private float _propAccountBalace;

        private float _propAvailableCreditLimit;

        // если True, до доступен, False - не доступен
        private bool _propStateOfAccount;

        public static float StaticStartBalace = 0;
        public static float StaticAvailableCreditLimit = 0;

        public UserAccount(string pass, bool accountType)
        {
            string temp_str = "";
            temp_str = GenerateRandomString(20);
            List<string> existingUserAccounts = UserAccauntList.GetAllUserAccauntIds();
            while (existingUserAccounts.Contains(temp_str))
            {
                temp_str = GenerateRandomString(20);
            }

            Id = temp_str;

            var hash = "";
            var success = GenerateMd5Hash(pass, ref hash);
            if (!success) throw new ArgumentException("Пин долже состоять из 4-х цифр");
            PasswordHash = hash;
            AccountType = accountType;
            AccountBalace = StaticStartBalace;
            AvailableCreditLimit = StaticAvailableCreditLimit;
            StateOfAccount = true;
        }

        public UserAccount(string pass, bool accountType, float accountBalace)
        {
            string temp_str = "";
            temp_str = GenerateRandomString(20);
            List<string> existingUserAccounts = UserAccauntList.GetAllUserAccauntIds();
            while (existingUserAccounts.Contains(temp_str))
            {
                temp_str = GenerateRandomString(20);
            }

            Id = temp_str;
            var hash = "";
            var success = GenerateMd5Hash(pass, ref hash);
            if (!success) throw new ArgumentException("Пин долже состоять из 4-х цифр");
            PasswordHash = hash;
            AccountType = accountType;
            AccountBalace = accountBalace;
            AvailableCreditLimit = StaticAvailableCreditLimit;
            StateOfAccount = false;
        }

        public UserAccount(string pass,
            bool accountType, float accountBalace, float availableCreditLimit)
        {
            string temp_str = "";
            temp_str = GenerateRandomString(20);
            List<string> existingUserAccounts = UserAccauntList.GetAllUserAccauntIds();
            while (existingUserAccounts.Contains(temp_str))
            {
                temp_str = GenerateRandomString(20);
            }

            Id = temp_str;
            var hash = "";
            var success = GenerateMd5Hash(pass, ref hash);
            if (!success) throw new ArgumentException("Пин долже состоять из 4-х цифр");
            PasswordHash = hash;
            AccountType = accountType;
            AccountBalace = accountBalace;
            AvailableCreditLimit = AccountType == true ? availableCreditLimit : StaticAvailableCreditLimit;
            StateOfAccount = false;
        }


        public string Id
        {
            get => _propId;
            set => _propId = value;
        }

        public string PasswordHash
        {
            get => _propPasswordHash;
            set => _propPasswordHash = value;
        }

        public bool AccountType
        {
            get => _propAccountType;
            set => _propAccountType = value;
        }

        public float AccountBalace
        {
            get => _propAccountBalace;
            set => _propAccountBalace = value;
        }

        public float AvailableCreditLimit
        {
            get => _propAvailableCreditLimit;
            set => _propAvailableCreditLimit = value;
        }

        public bool StateOfAccount
        {
            get => _propStateOfAccount;
            set => _propStateOfAccount = value;
        }

        public float GetFundsAvailable()
        {
            var sum = AccountBalace + AvailableCreditLimit;
            return sum;
        }

        public bool TopOnCard(float value, out float balance, out string report, bool get_report = false)
        {
            balance = 0;
            report = "";
            if (get_report == true) report = GetReport() + "\n";
            var dateTimeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            report += dateTimeString + ": " + "Пополнение баланса на сумму: " + value.ToString() + "\n";
            balance = AccountBalace + value;
            AccountBalace = balance;
            if (get_report == true) report = GetReport();

            return true;
        }

        public bool TopOffCard(float value, out float balance, out string report, bool get_report = false)
        {
            balance = 0;
            report = "";
            if (get_report == true) report = GetReport() + "\n";
            var dateTimeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (GetFundsAvailable() > 0)
            {
                report += dateTimeString + ": " + "Пополнение баланса на сумму: " + value.ToString() + "\n";
                balance = AccountBalace - value;
                AccountBalace = balance;
                if (get_report == true) report = GetReport();
                return true;
            }
            else
            {
                if (get_report == true)
                    report += dateTimeString + ": превышен доступный лимит. \n" +
                              "Доступный лимит: " + GetFundsAvailable().ToString();
                if (get_report == true) report += GetReport();
                return false;
            }
        }

        public string GetReport()
        {
            var dateTimeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var temp_str = dateTimeString + ": \n Баланс: " + AccountBalace.ToString() +
                           "Кредитный лимит: " + AvailableCreditLimit.ToString() +
                           "Доступная сумма: " + GetFundsAvailable().ToString();
            return temp_str;
        }

        public static string GenerateRandomString(int length)
        {
            var random = new Random();
            var sb = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                if (i > 0 && i % 4 == 0) sb.Append("-");
                sb.Append(random.Next(0, 10));
            }

            return sb.ToString();
        }

        public static bool GenerateMd5Hash(string input, ref string hash)
        {
            hash = "";
            // Проверяем, что введены только цифры от 0 до 9
            if (!Regex.IsMatch(input, @"^\d{4}$")) return false;

            // Вычисляем хеш-строку MD5
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = MD5.Create().ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach (var b in hashBytes) sb.Append(b.ToString("x2"));

            hash = sb.ToString();
            return true;
        }
    }
}