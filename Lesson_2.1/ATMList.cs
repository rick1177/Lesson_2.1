using System;
using System.Collections.Generic;

namespace Lesson_2._1
{
    public class ATMList
    {
        private readonly List<ATM> _ATMs;
        private static ATMList _instance;

        private ATMList()
        {
            _ATMs = new List<ATM>();
        }

        public static ATMList GetInstance()
        {
            if (_instance == null) _instance = new ATMList();
            return _instance;
        }

        public void AddATM(ATM _ATM)
        {
            GetInstance()._ATMs.Add(_ATM);
        }

        public void RemoveATM(string ATM_id)
        {
            foreach (var _ATM in GetInstance()._ATMs)
                if (_ATM.ATM_id == ATM_id)
                {
                    GetInstance()._ATMs.Remove(_ATM);
                    break;
                }
        }

        public ATM GetATMByATMId(string ATM_id)
        {
            foreach (var _ATM_item in GetInstance()._ATMs)
                if (_ATM_item.ATM_id == ATM_id)
                    return _ATM_item;
            return null;
        }

        public List<ATM> GetAllATMs()
        {
            return GetInstance()._ATMs;
        }

        public static List<string> GetAllATMsByIds()
        {
            var ids = new List<string>();
            foreach (var ATM_item in GetInstance()._ATMs) ids.Add(ATM_item.ATM_id);
            return ids;
        }
    }
}