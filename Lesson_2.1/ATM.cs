using System.Collections.Generic;

namespace Lesson_2._1
{
    public class ATM
    {
        private string prop_ATM_id;
        private Dictionary<int, int> prop_banknotes = new Dictionary<int, int>();


        public string ATM_id
        {
            get => prop_ATM_id;
            set => prop_ATM_id = value;
        }

        public Dictionary<int, int> Banknotes
        {
            get => prop_banknotes;
            set => prop_banknotes = value;
        }
    }
}