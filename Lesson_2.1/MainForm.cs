using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;

namespace Lesson_2._1
{
    public partial class MainForm : Form
    {
        private UserAccauntList _userAccauntList;
        private ATMList _ATMs;
        private bool allowTabSwitching = true;

        private Array values = Enum.GetValues(typeof(ATM.denominations));

        public MainForm()
        {
            InitializeComponent();
            _userAccauntList = UserAccauntList.GetInstance();
            _ATMs = ATMList.GetInstance();
            comboBox_select_operation.Items.Clear();
            string[] items = new string[] { "Пополнение наличными", "Снятие наличных", "Пополнение переводом", "Перевод средств" };
            comboBox_select_operation.Items.AddRange(items);
            foreach (var value in values)
            {
                // Преобразование значения в тип, который может быть добавлен в DataGridView
                var convertedValue = Convert.ChangeType(value, typeof(int));

                // Добавление значения в DataGridView
                dataGridView_q_banknotes.Rows.Add(convertedValue);
                DataGridView_banknotes.Rows.Add(convertedValue);
            }

            DataGridView_banknotes.CurrentCell = DataGridView_banknotes[1, 0];
        }


        public void Refresh_dataGridView_accounts()
        {
            for (int i = dataGridView_accounts.Rows.Count - 1; i >= 0; i--)
            {
                dataGridView_accounts.Rows.RemoveAt(i);
            }

            List<UserAccount> all_users = _userAccauntList.GetAllUserAccaunts();
            
            foreach (UserAccount newUser in all_users)
            {
                object[] row =
                {
                    newUser.Id, newUser.PasswordHash, newUser.AccountType,
                    newUser.AccountBalace.ToString(), newUser.AvailableCreditLimit.ToString(),
                    newUser.StateOfAccount
                };
                dataGridView_accounts.Rows.Add(row);
            }
            
            dataGridView_accounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        
        
        private void textBox_StartAccountBalace_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;

            // Разрешаем ввод цифр и точки
            if (char.IsDigit(ch) || ch == '.')
            {
                var text = textBox_StartAccountBalace.Text;

                // Проверяем, есть ли уже точка или запятая в строке
                if (ch == '.' && (text.Contains('.') || text.Length == 0 || text.EndsWith(".")))
                {
                    e.Handled = true;
                }
                else if (text.Contains('.'))
                {
                    // Проверяем, сколько цифр после точки
                    var parts = text.Split('.');
                    if (parts.Length > 1 && parts[1].Length >= 2) e.Handled = true;
                }
            }
            else if (ch == (char)Keys.Back)
            {
                // Разрешаем удаление символов
                e.Handled = false;
            }
            else
            {
                // Блокируем все остальные символы
                e.Handled = true;
            }
        }


        private void textBox_PAS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            else if (textBox_PAS.Text.Length >= 4 && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void textBox_AvailableCreditLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;

            // Разрешаем ввод цифр и точки
            if (char.IsDigit(ch) || ch == '.')
            {
                var text = textBox_AvailableCreditLimit.Text;

                // Проверяем, есть ли уже точка или запятая в строке
                if (ch == '.' && (text.Contains('.') || text.Length == 0 || text.EndsWith(".")))
                {
                    e.Handled = true;
                }
                else if (text.Contains('.'))
                {
                    // Проверяем, сколько цифр после точки
                    var parts = text.Split('.');
                    if (parts.Length > 1 && parts[1].Length >= 2) e.Handled = true;
                }
            }
            else if (ch == (char)Keys.Back)
            {
                // Разрешаем удаление символов
                e.Handled = false;
            }
            else
            {
                // Блокируем все остальные символы
                e.Handled = true;
            }
        }

        private void button_add_accaunt_Click(object sender, EventArgs e)
        {
            var accountType = false;
            string pass;
            float balance;
            float creditlimit;
            if (comboBox_choose_account_type.SelectedIndex == -1) return;
            if (textBox_PAS.Text == "" || textBox_PAS.Text.Length < 4) return;

            if (comboBox_choose_account_type.Text == "Дебетовый") accountType = false;
            if (comboBox_choose_account_type.Text == "Кредитный") accountType = true;
            pass = textBox_PAS.Text;

            UserAccount newUser=null;
            if (float.TryParse(textBox_StartAccountBalace.Text, out balance))
            {
                if (float.TryParse(textBox_AvailableCreditLimit.Text, out creditlimit))
                {
                    newUser = new UserAccount(pass, accountType, balance, creditlimit);
                }
                else
                {
                    newUser = new UserAccount(pass, accountType, balance);
                }
            }
            else
            {
                newUser = new UserAccount(pass, accountType); ;
            }
            
            _userAccauntList.AddUserAccaunt(newUser);

            object[] row =
            {
                newUser.Id, newUser.PasswordHash, accountType,
                newUser.AccountBalace.ToString(), newUser.AvailableCreditLimit.ToString(),
                newUser.StateOfAccount
            };
            List<UserAccount> all_accaunts = _userAccauntList.GetAllUserAccaunts();
            dataGridView_accounts.Rows.Add(row);
            dataGridView_accounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button_change_status_Click(object sender, EventArgs e)
        {
            if (dataGridView_accounts.CurrentRow == null) return;
            var rowData = new string[dataGridView_accounts.Columns.Count];
            for (var i = 0; i < dataGridView_accounts.Columns.Count; i++)
                rowData[i] = dataGridView_accounts.SelectedRows[0].Cells[i].Value.ToString();

            var useraccount = _userAccauntList.GetUserAccauntById(rowData[0]);

            useraccount.StateOfAccount = useraccount.StateOfAccount == true ? false : true;

            dataGridView_accounts.SelectedRows[0].Cells[5].Value = useraccount.StateOfAccount;
        }

        private void button_delete_account_Click(object sender, EventArgs e)
        {
            if (dataGridView_accounts.CurrentRow == null) return;

            var result = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var rowData = new string[dataGridView_accounts.Columns.Count];
                for (var i = 0; i < dataGridView_accounts.Columns.Count; i++)
                    rowData[i] = dataGridView_accounts.SelectedRows[0].Cells[i].Value.ToString();
                var useraccount = _userAccauntList.GetUserAccauntById(rowData[0]);

                _userAccauntList.RemoveUserAccaunt(rowData[0]);

                if (dataGridView_accounts.Rows.Count > 0)
                    dataGridView_accounts.Rows.RemoveAt(dataGridView_accounts.SelectedRows[0].Index);
            }
        }

        private void dataGridView_accounts_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                var rowData = new string[dataGridView_accounts.Columns.Count];
                for (var i = 0; i < dataGridView_accounts.Columns.Count; i++)
                    rowData[i] = dataGridView_accounts.SelectedRows[0].Cells[i].Value.ToString();
                var useraccount = _userAccauntList.GetUserAccauntById(rowData[0]);

                _userAccauntList.RemoveUserAccaunt(rowData[0]);
            }
        }

        private void button_change_accaunt_Click(object sender, EventArgs e)
        {
            if (dataGridView_accounts.CurrentRow == null) return;

            var rowData = new string[dataGridView_accounts.Columns.Count];
            for (var i = 0; i < dataGridView_accounts.Columns.Count; i++)
                rowData[i] = dataGridView_accounts.SelectedRows[0].Cells[i].Value.ToString();
            var useraccount = _userAccauntList.GetUserAccauntById(rowData[0]);

            if (button_change_accaunt.Text == "Изменить счёт")
            {
                button_change_accaunt.Text = "O.K.";
                comboBox_choose_account_type.SelectedItem = rowData[2] == "False" ? "Дебетовый" : "Кредитный";
                textBox_StartAccountBalace.Text = rowData[3];
                textBox_AvailableCreditLimit.Text = rowData[4];

                textBox_PAS.Text = "";

                dataGridView_accounts.Enabled = false;
                button_add_accaunt.Enabled = false;
                button_change_status.Enabled = false;
                button_delete_account.Enabled = false;
                allowTabSwitching = !allowTabSwitching;
            }
            else
            {
                button_change_accaunt.Text = "Изменить счёт";

                if (comboBox_choose_account_type.Text == "Дебетовый")
                {
                    rowData[2] = "False";
                    useraccount.AccountType = false;
                }
                else
                {
                    rowData[2] = "True";
                    useraccount.AccountType = true;
                }

                float balance;
                float creditlimit;
                if (textBox_StartAccountBalace.Text != "")
                {
                    rowData[3] = textBox_StartAccountBalace.Text;
                    if (float.TryParse(textBox_StartAccountBalace.Text, out balance))
                    {
                        useraccount.AccountBalace = balance;
                    }
                }

                if (textBox_AvailableCreditLimit.Text != "" && useraccount.AccountType == true)
                {
                    rowData[4] = textBox_AvailableCreditLimit.Text;
                    if (float.TryParse(textBox_AvailableCreditLimit.Text, out creditlimit))
                    {
                        useraccount.AvailableCreditLimit = creditlimit;
                    }
                }

                if (textBox_PAS.Text.Length == 4)
                {
                    string hash = "";
                    var success = UserAccount.GenerateMd5Hash(textBox_PAS.Text, ref hash);
                    useraccount.PasswordHash = hash;
                    rowData[1] = hash;
                }


                int b = dataGridView_accounts.CurrentRow.Index;

                dataGridView_accounts.Rows[b].SetValues(rowData);

                dataGridView_accounts.Enabled = true;
                button_add_accaunt.Enabled = true;
                button_change_status.Enabled = true;
                button_delete_account.Enabled = true;
                allowTabSwitching = !allowTabSwitching;
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!allowTabSwitching && e.Action == TabControlAction.Selecting)
            {
                e.Cancel = true;
            }
        }

        private void DataGridView_banknotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewCell cell in DataGridView_banknotes.SelectedCells)
                {
                    if (DataGridView_banknotes.CurrentCell.ColumnIndex == 1)
                    {
                        cell.Value = null;
                    }
                }

                e.Handled = true;
            }
        }

        private void DataGridView_banknotes_EditingControlShowing(object sender,
            DataGridViewEditingControlShowingEventArgs e)
        {
            if (DataGridView_banknotes.CurrentCell.ColumnIndex ==
                1) // проверяем, что текущая ячейка находится во втором столбце
            {
                e.Control.KeyPress += new KeyPressEventHandler(DataGridView_banknotes_KeyPress);
            }
        }


        private void DataGridView_banknotes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // блокируем ввод, если нажатая клавиша не является цифрой или управляющим символом
            }
        }

        private void DataGridView_banknotes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0) // проверяем индекс столбца
            {
                e.CellStyle.BackColor = Color.Silver; // задаем зеленый цвет для ячейки
            }
        }

        private void button_add_ATM_Click(object sender, EventArgs e)
        {
            int columnIndex = 1;
            int rowCount = DataGridView_banknotes.Rows.Count;
            int[] columnData = new int[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                DataGridViewCell cell = DataGridView_banknotes[columnIndex, i];
                if (cell.Value != null)
                {
                    columnData[i] = int.Parse(cell.Value.ToString());
                }
            }

            int count = 0;
            foreach (int element in columnData)
            {
                if (element != 0)
                {
                    count++;
                }
            }

            var prop_banknotes = new Dictionary<ATM.denominations, int>();
            var values = Enum.GetValues(typeof(ATM.denominations)).Cast<ATM.denominations>().ToArray();

            if (count > 0)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (columnData[i] > 0)
                    {
                        prop_banknotes.Add(values[i], columnData[i]);
                    }
                }
            }

            ATM _ATM;
            if (prop_banknotes.Count > 0)
            {
                _ATM = new ATM(prop_banknotes);
            }
            else
            {
                _ATM = new ATM();
            }

            _ATMs.AddATM(_ATM);

            dataGridView_ATMs.Rows.Add(_ATM.ATM_id, _ATM.GetBanknotesDenominationsString(),
                _ATM.GetBanknotesVaulesString(), _ATM.GetBlockedCardsString());
            for (int i = 0; i < _ATM.Banknotes.Count; i++)
            {
                DataGridView_banknotes.Rows[i].Cells[1].Value = null;
            }


            /*dataGridView_ATMs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;*/

        }

        private void button_chamge_banknotes_Click(object sender, EventArgs e)
        {
            if (dataGridView_ATMs.CurrentRow == null) return;
            var rowData = new string[dataGridView_ATMs.Columns.Count];
            for (var i = 0; i < dataGridView_ATMs.Columns.Count; i++)
                rowData[i] = dataGridView_ATMs.SelectedRows[0].Cells[i].Value.ToString();
            var _ATM = _ATMs.GetATMByATMId(rowData[0]);

            if (button_chamge_banknotes.Text == "Изменить наполненность банкомата")
            {
                int[] values = _ATM.Banknotes.Values.ToArray();
                for (int i = 0; i < _ATM.Banknotes.Count; i++)
                {
                    DataGridView_banknotes.Rows[i].Cells[1].Value = values[i].ToString();
                }

                button_chamge_banknotes.Text = "O.K.";
                button_add_ATM.Enabled = false;
                button_delete_ATM.Enabled = false;
                button_extract_cards.Enabled = false;
                allowTabSwitching = !allowTabSwitching;

            }

            else
            {

                int rowCount = DataGridView_banknotes.Rows.Count;
                int[] columnData = new int[rowCount];
                for (int i = 0; i < rowCount; i++)
                {
                    DataGridViewCell cell = DataGridView_banknotes[1, i];
                    if (cell.Value != null)
                    {
                        columnData[i] = int.Parse(cell.Value.ToString());
                    }
                }

                int count = 0;
                foreach (int element in columnData)
                {
                    count++;
                }

                var prop_banknotes = new Dictionary<ATM.denominations, int>();
                var values = Enum.GetValues(typeof(ATM.denominations)).Cast<ATM.denominations>().ToArray();

                if (count > 0)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        prop_banknotes.Add(values[i], columnData[i]);
                    }
                }

                _ATM.Banknotes = prop_banknotes;

                int b = dataGridView_ATMs.CurrentRow.Index;

                dataGridView_ATMs.Rows[b].SetValues(_ATM.ATM_id, _ATM.GetBanknotesDenominationsString(),
                    _ATM.GetBanknotesVaulesString(), _ATM.GetBlockedCardsString());

                for (int i = 0; i < _ATM.Banknotes.Count; i++)
                {
                    DataGridView_banknotes.Rows[i].Cells[1].Value = null;
                }

                button_chamge_banknotes.Text = "Изменить наполненность банкомата";
                button_add_ATM.Enabled = true;
                button_delete_ATM.Enabled = true;
                button_extract_cards.Enabled = true;
                allowTabSwitching = !allowTabSwitching;
            }

            var a = 7;

        }

        private void button_delete_ATM_Click(object sender, EventArgs e)
        {
            if (dataGridView_ATMs.CurrentRow == null) return;

            var result = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var rowData = new string[dataGridView_ATMs.Columns.Count];
                for (var i = 0; i < dataGridView_ATMs.Columns.Count; i++)
                    rowData[i] = dataGridView_ATMs.SelectedRows[0].Cells[i].Value.ToString();
                var _ATM = _ATMs.GetATMByATMId(rowData[0]);

                _ATMs.RemoveATM(rowData[0]);

                // TODO: требуется прописать проверку наличия заблокированных карт и при удалении разблокировать их

                if (dataGridView_ATMs.Rows.Count > 0)
                    dataGridView_ATMs.Rows.RemoveAt(dataGridView_ATMs.SelectedRows[0].Index);
            }

        }

        private void dataGridView_ATMs_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridView_ATMs.CurrentRow == null) return;

            var result = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                var rowData = new string[dataGridView_ATMs.Columns.Count];
                for (var i = 0; i < dataGridView_ATMs.Columns.Count; i++)
                    rowData[i] = dataGridView_ATMs.SelectedRows[0].Cells[i].Value.ToString();
                var _ATM = _ATMs.GetATMByATMId(rowData[0]);

                _ATMs.RemoveATM(rowData[0]);

                // TODO: требуется прописать проверку наличия заблокированных карт и при удалении разблокировать их

            }
        }

        private void comboBox_select_ATM_DropDown(object sender, EventArgs e)
        {
            comboBox_select_ATM.Items.Clear();
            List<string> _AtmList = _ATMs.GetAllATMsByIds_fm();
            string[] _AtmList_array = _AtmList.ToArray();
            if (_AtmList.Count <= 0) return;
            else
            {
                comboBox_select_ATM.Items.AddRange(_AtmList_array);
            }
        }

        private void comboBox_select_card_DropDown(object sender, EventArgs e)
        {
            comboBox_select_card.Items.Clear();
            List<string> _cardList = _userAccauntList.GetAllUserAccauntIds_fm();
            string[] _cardList_array = _cardList.ToArray();
            if (_cardList.Count <= 0) return;
            else
            {
                comboBox_select_card.Items.AddRange(_cardList_array);
            }
        }

        private void button_enter_card_Click(object sender, EventArgs e)
        {
            List<object> button_tag_list_Objects = new List<object>();
            string ATM_from_comboBox = comboBox_select_ATM.Text;
            string card_from_comboBox = comboBox_select_card.Text;
            if (ATM_from_comboBox=="" || ATM_from_comboBox==null) return;
            if (card_from_comboBox=="" || card_from_comboBox==null) return;
            ATM _ATM = _ATMs.GetATMByATMId(ATM_from_comboBox);
            UserAccount card = _userAccauntList.GetUserAccauntById(card_from_comboBox);
            List<UserAccount> all_accaunts = _userAccauntList.GetAllUserAccaunts();
            int jha=7;
            if (_ATM==null || card ==null) return;

            string result = "";
            bool validInput = false;
            int attempts = 0;
            var hash = "";
            
            while (validInput == false && attempts < 3)
            {
                this.Tag = null;
                Enter_pin childForm = new Enter_pin(); // создаем экземпляр дочерней формы
                if (childForm.ShowDialog() == DialogResult.OK) // отображаем дочернюю форму как диалоговое окно
                {
                    result = childForm
                        .Result; // получаем результат из дочерней формы и устанавливаем его в поле ввода на главной форме
                }
                var success = UserAccount.GenerateMd5Hash(result, ref hash);
                
                if (success)
                {
                    if (card.PasswordHash == hash)
                    {
                        validInput = true;
                        button_tag_list_Objects.Add(_ATM);
                        button_tag_list_Objects.Add(card);
                        this.button_enter_card.Tag = button_tag_list_Objects;
                        button_enter_card.Enabled = false;
                        panel6.Visible = true;
                        label5.Enabled = false;
                        label6.Enabled = false;
                        comboBox_select_ATM.Enabled = false;
                        comboBox_select_card.Enabled = false;
                        allowTabSwitching = !allowTabSwitching;
                        break;
                    }
                    else
                    {
                        attempts++;
                        continue;
                    }
                }
                else
                {
                    attempts++;
                    continue;
                }
            }

            if (attempts >= 3)
            {
                
                // TODO: прописать блокировку карты
                
                int b = 7;
            }
            

            int a = 7;

        }

        private void button_check_account_information_Click(object sender, EventArgs e)
        {
            List<object> previous_button_tag_list_Objects = button_enter_card.Tag as List<object>;
            int b = 7;
            if (previous_button_tag_list_Objects == null) return;
            ATM _ATM = previous_button_tag_list_Objects[0] as ATM;
            UserAccount card = previous_button_tag_list_Objects[1] as UserAccount;
            
            MessageBox.Show(card.GetReport());

        }

        private void button_finish_work_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            label5.Enabled = true;
            label6.Enabled = true;
            button_enter_card.Enabled = true;
            comboBox_select_ATM.Enabled = true;
            comboBox_select_card.Enabled = true;
            allowTabSwitching = !allowTabSwitching;
        }

        private void button_extract_cards_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void textBox_transaction_summ_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;

            // Разрешаем ввод цифр и точки
            if (char.IsDigit(ch) || ch == '.')
            {
                var text = textBox_transaction_summ.Text;

                // Проверяем, есть ли уже точка или запятая в строке
                if (ch == '.' && (text.Contains('.') || text.Length == 0 || text.EndsWith(".")))
                {
                    e.Handled = true;
                }
                else if (text.Contains('.'))
                {
                    // Проверяем, сколько цифр после точки
                    var parts = text.Split('.');
                    if (parts.Length > 1 && parts[1].Length >= 2) e.Handled = true;
                }
            }
            else if (ch == (char)Keys.Back)
            {
                // Разрешаем удаление символов
                e.Handled = false;
            }
            else
            {
                // Блокируем все остальные символы
                e.Handled = true;
            }
        }

        private void comboBox_select_card_to_DropDown(object sender, EventArgs e)
        {
            comboBox_select_card_to.Items.Clear();
            List<string> _cardList = _userAccauntList.GetAllUserAccauntIds_fm();
            string[] _cardList_array = _cardList.ToArray();
            if (_cardList.Count <= 0) return;
            else
            {
                comboBox_select_card_to.Items.AddRange(_cardList_array);
            }
        }

        private void comboBox_select_operation_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox_select_operation.SelectedItem as string;

            // Выполняем нужное действие в зависимости от выбранного элемента
            switch (selectedItem)
            {
                case "Пополнение наличными":
                    label8.Enabled = false;
                    label9.Enabled = true;
                    for (int i = 0; i < dataGridView_q_banknotes.Rows.Count; i++)
                    {
                        dataGridView_q_banknotes.Rows[i].Cells[1].Value = null;
                    }
                    comboBox_select_card_to.Enabled = false;
                    dataGridView_q_banknotes.Visible = true;
                    textBox_transaction_summ.Visible = false;
                    button_q_banknotes_random.Visible = true;
                    button_q_banknotes_clear.Visible = true;
                    comboBox_select_card_to.Items.Clear();
                    textBox_transaction_summ.Text = null;
                    
                    break;

                case "Снятие наличных":
                    label8.Enabled = false;
                    label9.Enabled = true;
                    for (int i = 0; i < dataGridView_q_banknotes.Rows.Count; i++)
                    {
                        dataGridView_q_banknotes.Rows[i].Cells[1].Value = null;
                    }
                    comboBox_select_card_to.Enabled = false;
                    dataGridView_q_banknotes.Visible = true;
                    textBox_transaction_summ.Visible = false;
                    button_q_banknotes_random.Visible = true;
                    button_q_banknotes_clear.Visible = true;
                    comboBox_select_card_to.Items.Clear();
                    textBox_transaction_summ.Text = null;
                    break;
                
                case "Пополнение переводом":
                    label8.Enabled = true;
                    label9.Enabled = true;
                    for (int i = 0; i < dataGridView_q_banknotes.Rows.Count; i++)
                    {
                        dataGridView_q_banknotes.Rows[i].Cells[1].Value = null;
                    }
                    comboBox_select_card_to.Enabled = true;
                    dataGridView_q_banknotes.Visible = false;
                    textBox_transaction_summ.Visible = true;
                    button_q_banknotes_random.Visible = false;
                    button_q_banknotes_clear.Visible = false;
                    comboBox_select_card_to.Items.Clear();
                    textBox_transaction_summ.Text = null;
                    break;
                
                case "Перевод средств":
                    label8.Enabled = true;
                    label9.Enabled = true;
                    for (int i = 0; i < dataGridView_q_banknotes.Rows.Count; i++)
                    {
                        dataGridView_q_banknotes.Rows[i].Cells[1].Value = null;
                    }
                    comboBox_select_card_to.Enabled = true;
                    dataGridView_q_banknotes.Visible = false;
                    textBox_transaction_summ.Visible = true;
                    button_q_banknotes_random.Visible = false;
                    button_q_banknotes_clear.Visible = false;
                    comboBox_select_card_to.Items.Clear();
                    textBox_transaction_summ.Text = null;
                    break;

            }
        }

        private void button_start_operation_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox_select_operation.SelectedItem as string;
            
            float newbalance = 0f;
            string report = "";
            UserAccount crd = null;
            
            List<object> previous_button_tag_list_Objects = button_enter_card.Tag as List<object>;
            int b = 7;
            if (previous_button_tag_list_Objects == null) return;
            ATM _ATM = previous_button_tag_list_Objects[0] as ATM;
            UserAccount card = previous_button_tag_list_Objects[1] as UserAccount;
            //TODO: прописать действия на случай заблокированной карты
            
            //TODO: обработать ошибку пустого поля
            float summ = float.Parse(textBox_transaction_summ.Text);
            UserAccount card_to = null;

            string card_to_string = comboBox_select_card_to.Text;
            if (card_to_string != "" && card_to_string != null)
            {
                card_to = _userAccauntList.GetUserAccauntById(card_to_string);
            }
            

            // чтение таблицы с номиналами купюр
            int rowCount = dataGridView_q_banknotes.Rows.Count;
            int[] columnData = new int[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                DataGridViewCell cell = dataGridView_q_banknotes[1, i];
                if (cell.Value != null)
                {
                    columnData[i] = int.Parse(cell.Value.ToString());
                }
            }

            int count = 0;
            foreach (int element in columnData)
            {
                if (element != 0)
                {
                    count++;
                }
            }

            var prop_banknotes = new Dictionary<ATM.denominations, int>();
            var values = Enum.GetValues(typeof(ATM.denominations)).Cast<ATM.denominations>().ToArray();

            if (count > 0)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (columnData[i] > 0)
                    {
                        prop_banknotes.Add(values[i], columnData[i]);
                    }
                }
            }
            
            
            
            switch (selectedItem)
            {
                case "Пополнение наличными":

                    break;

                case "Снятие наличных":

                    break;

                case "Пополнение переводом":
                    // TODO: прописать действия на случай заблокированной карты
                    
                    break;

                case "Перевод средств":
                    // TODO: прописать действия на случай заблокированной карты
                    
                    if (card_to != null && card.GetFundsAvailable() > summ)
                    {
                        var success = card.TopOnCard(summ, out newbalance, out report, false);
                        card_to.AccountBalace_pbl = newbalance;
                        success = card.TopOnCard(-1*summ, out newbalance, out report, false);
                        card.AccountBalace_pbl = newbalance;
                        Refresh_dataGridView_accounts();
                    }
                    break;


                    

                    /*if (comboBox_select_operation.Text == "Пополнение")
                    {
                        float ask = summ % 10;
                        if (ask == 0f)
                        {
                            var success = card.TopOnCard(summ, out newbalance, out report, false);
                            card.AccountBalace_pbl = newbalance;
                            Refresh_dataGridView_accounts();
                            MessageBox.Show("Отработало");
                        }
                        else
                        {
                            MessageBox.Show("Можно вводить сумму кратную 10");
                            textBox_transaction_summ.Text = null;
                        }

                    }*/
            }
        }

        private void button_DataGridView_banknotes_update_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (var i = 0; i < DataGridView_banknotes.Rows.Count; i++)
            {
                int value = random.Next(0, 1000);
                DataGridView_banknotes.Rows[i].Cells[1].Value = value.ToString();
                
            }
                
        }

        private void button_DataGridView_banknotes_clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DataGridView_banknotes.Rows.Count; i++)
            {
                DataGridView_banknotes.Rows[i].Cells[1].Value = null;
            }
        }

        private void button_q_banknotes_random_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (var i = 0; i < dataGridView_q_banknotes.Rows.Count; i++)
            {
                int value = random.Next(0, 1000);
                dataGridView_q_banknotes.Rows[i].Cells[1].Value = value.ToString();
                
            }
        }

        private void button_q_banknotes_clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_q_banknotes.Rows.Count; i++)
            {
                dataGridView_q_banknotes.Rows[i].Cells[1].Value = null;
            }
        }
    }
}
