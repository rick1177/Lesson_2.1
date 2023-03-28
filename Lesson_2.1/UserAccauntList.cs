using System;
using System.Collections.Generic;

namespace Lesson_2._1
{
    public class UserAccauntList
    {
        private readonly List<UserAccount> _userAccaunts;
        private static UserAccauntList _instance;

        private UserAccauntList()
        {
            _userAccaunts = new List<UserAccount>();
        }

        public static UserAccauntList GetInstance()
        {
            if (_instance == null) _instance = new UserAccauntList();
            return _instance;
        }

        public void AddUserAccaunt(UserAccount userAccount)
        {
            GetInstance()._userAccaunts.Add(userAccount);
        }

        public void RemoveUserAccaunt(string id)
        {
            foreach (var userAccaunt in GetInstance()._userAccaunts)
                if (userAccaunt.Id == id)
                {
                    GetInstance()._userAccaunts.Remove(userAccaunt);
                    break;
                }
        }

        public UserAccount GetUserAccauntById(string id)
        {
            foreach (var userAccaunt in GetInstance()._userAccaunts)
                if (userAccaunt.Id == id)
                    return userAccaunt;
            return null;
        }

        public List<UserAccount> GetAllUserAccaunts()
        {
            return GetInstance()._userAccaunts;
        }

        public static List<string> GetAllUserAccauntIds()
        {
            var ids = new List<string>();
            foreach (var userAccaunt in GetInstance()._userAccaunts) ids.Add(userAccaunt.Id);
            return ids;
        }
        public List<string> GetAllUserAccauntIds_fm()
        {
            var ids = new List<string>();
            foreach (var userAccaunt in GetInstance()._userAccaunts) ids.Add(userAccaunt.Id);
            return ids;
        }
    }
}