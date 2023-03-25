using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lesson_2._1
{
    public partial class MainForm : Form
    {
        private UserAccauntList _userAccauntList;
        private bool allowTabSwitching = true;

        public MainForm()
        {
            InitializeComponent();
            _userAccauntList = UserAccauntList.GetInstance();
            /*dataGridView_accounts.UserDeletingRow += new DataGridViewRowCancelEventHandler(dataGridView_accounts_UserDeletingRow);*/
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

            UserAccount newUser;
            if (float.TryParse(textBox_StartAccountBalace.Text, out balance))
            {
                if (float.TryParse(textBox_AvailableCreditLimit.Text, out creditlimit))
                {
                    newUser = new UserAccount(pass, accountType, balance, creditlimit);
                    _userAccauntList.AddUserAccaunt(newUser);
                }
                else
                {
                    newUser = new UserAccount(pass, accountType, balance);
                    _userAccauntList.AddUserAccaunt(newUser);
                }
            }
            else
            {
                newUser = new UserAccount(pass, accountType);
                _userAccauntList.AddUserAccaunt(newUser);
            }

            object[] row =
            {
                newUser.Id, newUser.PasswordHash, accountType,
                newUser.AccountBalace.ToString(), newUser.AvailableCreditLimit.ToString(),
                newUser.StateOfAccount
            };
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


            var a = 7;
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
                if (textBox_AvailableCreditLimit.Text != "" &&  useraccount.AccountType==true)
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
    }
}