using System.ComponentModel;

namespace Lesson_2._1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab_ATMs = new System.Windows.Forms.TabPage();
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tab_card_accounts = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView_accounts = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PasswordHash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountBalace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableCreditLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateOfAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_delete_account = new System.Windows.Forms.Button();
            this.button_change_status = new System.Windows.Forms.Button();
            this.textBox_PAS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_change_accaunt = new System.Windows.Forms.Button();
            this.button_add_accaunt = new System.Windows.Forms.Button();
            this.textBox_AvailableCreditLimit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_StartAccountBalace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_choose_account_type = new System.Windows.Forms.ComboBox();
            this.tab_ATM_transactions = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.miniToolStrip.SuspendLayout();
            this.tab_card_accounts.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_accounts)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_ATMs
            // 
            this.tab_ATMs.Location = new System.Drawing.Point(4, 25);
            this.tab_ATMs.Name = "tab_ATMs";
            this.tab_ATMs.Size = new System.Drawing.Size(775, 544);
            this.tab_ATMs.TabIndex = 2;
            this.tab_ATMs.Text = "Управление Банкоматами";
            this.tab_ATMs.UseVisualStyleBackColor = true;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.менюToolStripMenuItem });
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.miniToolStrip.Size = new System.Drawing.Size(783, 32);
            this.miniToolStrip.TabIndex = 0;
            this.miniToolStrip.TabStop = true;
            this.miniToolStrip.Text = "miniToolStrip";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(63, 28);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // tab_card_accounts
            // 
            this.tab_card_accounts.Controls.Add(this.panel2);
            this.tab_card_accounts.Location = new System.Drawing.Point(4, 25);
            this.tab_card_accounts.Name = "tab_card_accounts";
            this.tab_card_accounts.Padding = new System.Windows.Forms.Padding(3);
            this.tab_card_accounts.Size = new System.Drawing.Size(775, 544);
            this.tab_card_accounts.TabIndex = 1;
            this.tab_card_accounts.Text = "Управление счетами";
            this.tab_card_accounts.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 538);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView_accounts);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(769, 399);
            this.panel3.TabIndex = 4;
            // 
            // dataGridView_accounts
            // 
            this.dataGridView_accounts.AllowUserToAddRows = false;
            this.dataGridView_accounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_accounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_accounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Id, this.PasswordHash, this.AccountType, this.AccountBalace, this.AvailableCreditLimit, this.StateOfAccount });
            this.dataGridView_accounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_accounts.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_accounts.MultiSelect = false;
            this.dataGridView_accounts.Name = "dataGridView_accounts";
            this.dataGridView_accounts.RowTemplate.Height = 24;
            this.dataGridView_accounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_accounts.Size = new System.Drawing.Size(769, 399);
            this.dataGridView_accounts.TabIndex = 3;
            this.dataGridView_accounts.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_accounts_UserDeletingRow);
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // PasswordHash
            // 
            this.PasswordHash.HeaderText = "Хеш пароля";
            this.PasswordHash.Name = "PasswordHash";
            this.PasswordHash.ReadOnly = true;
            // 
            // AccountType
            // 
            this.AccountType.HeaderText = "Тип счёта";
            this.AccountType.Name = "AccountType";
            this.AccountType.ReadOnly = true;
            // 
            // AccountBalace
            // 
            this.AccountBalace.HeaderText = "Баланс счёта";
            this.AccountBalace.Name = "AccountBalace";
            this.AccountBalace.ReadOnly = true;
            // 
            // AvailableCreditLimit
            // 
            this.AvailableCreditLimit.HeaderText = "Кредитный лимит";
            this.AvailableCreditLimit.Name = "AvailableCreditLimit";
            this.AvailableCreditLimit.ReadOnly = true;
            // 
            // StateOfAccount
            // 
            this.StateOfAccount.HeaderText = "Статус счёта";
            this.StateOfAccount.Name = "StateOfAccount";
            this.StateOfAccount.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_delete_account);
            this.panel1.Controls.Add(this.button_change_status);
            this.panel1.Controls.Add(this.textBox_PAS);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button_change_accaunt);
            this.panel1.Controls.Add(this.button_add_accaunt);
            this.panel1.Controls.Add(this.textBox_AvailableCreditLimit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox_StartAccountBalace);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox_choose_account_type);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 399);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 139);
            this.panel1.TabIndex = 2;
            // 
            // button_delete_account
            // 
            this.button_delete_account.Location = new System.Drawing.Point(606, 82);
            this.button_delete_account.Name = "button_delete_account";
            this.button_delete_account.Size = new System.Drawing.Size(156, 38);
            this.button_delete_account.TabIndex = 11;
            this.button_delete_account.Text = "Удалить счёт";
            this.button_delete_account.UseVisualStyleBackColor = true;
            this.button_delete_account.Click += new System.EventHandler(this.button_delete_account_Click);
            // 
            // button_change_status
            // 
            this.button_change_status.Location = new System.Drawing.Point(606, 23);
            this.button_change_status.Name = "button_change_status";
            this.button_change_status.Size = new System.Drawing.Size(156, 38);
            this.button_change_status.TabIndex = 10;
            this.button_change_status.Text = "Сменить статус";
            this.button_change_status.UseVisualStyleBackColor = true;
            this.button_change_status.Click += new System.EventHandler(this.button_change_status_Click);
            // 
            // textBox_PAS
            // 
            this.textBox_PAS.Location = new System.Drawing.Point(224, 39);
            this.textBox_PAS.Name = "textBox_PAS";
            this.textBox_PAS.Size = new System.Drawing.Size(198, 22);
            this.textBox_PAS.TabIndex = 9;
            this.textBox_PAS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_PAS_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(224, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Пароль:";
            // 
            // button_change_accaunt
            // 
            this.button_change_accaunt.Location = new System.Drawing.Point(444, 82);
            this.button_change_accaunt.Name = "button_change_accaunt";
            this.button_change_accaunt.Size = new System.Drawing.Size(156, 38);
            this.button_change_accaunt.TabIndex = 7;
            this.button_change_accaunt.Text = "Изменить счёт";
            this.button_change_accaunt.UseVisualStyleBackColor = true;
            this.button_change_accaunt.Click += new System.EventHandler(this.button_change_accaunt_Click);
            // 
            // button_add_accaunt
            // 
            this.button_add_accaunt.Location = new System.Drawing.Point(444, 23);
            this.button_add_accaunt.Name = "button_add_accaunt";
            this.button_add_accaunt.Size = new System.Drawing.Size(156, 38);
            this.button_add_accaunt.TabIndex = 6;
            this.button_add_accaunt.Text = "Добавить счёт";
            this.button_add_accaunt.UseVisualStyleBackColor = true;
            this.button_add_accaunt.Click += new System.EventHandler(this.button_add_accaunt_Click);
            // 
            // textBox_AvailableCreditLimit
            // 
            this.textBox_AvailableCreditLimit.Location = new System.Drawing.Point(224, 98);
            this.textBox_AvailableCreditLimit.Name = "textBox_AvailableCreditLimit";
            this.textBox_AvailableCreditLimit.Size = new System.Drawing.Size(198, 22);
            this.textBox_AvailableCreditLimit.TabIndex = 5;
            this.textBox_AvailableCreditLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_AvailableCreditLimit_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(224, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Кредитный лимит:";
            // 
            // textBox_StartAccountBalace
            // 
            this.textBox_StartAccountBalace.Location = new System.Drawing.Point(5, 96);
            this.textBox_StartAccountBalace.Name = "textBox_StartAccountBalace";
            this.textBox_StartAccountBalace.Size = new System.Drawing.Size(198, 22);
            this.textBox_StartAccountBalace.TabIndex = 3;
            this.textBox_StartAccountBalace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_StartAccountBalace_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Начальный баланс:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тип счёта:";
            // 
            // comboBox_choose_account_type
            // 
            this.comboBox_choose_account_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_choose_account_type.FormattingEnabled = true;
            this.comboBox_choose_account_type.Items.AddRange(new object[] { "Дебетовый", "Кредитный" });
            this.comboBox_choose_account_type.Location = new System.Drawing.Point(5, 37);
            this.comboBox_choose_account_type.Name = "comboBox_choose_account_type";
            this.comboBox_choose_account_type.Size = new System.Drawing.Size(198, 24);
            this.comboBox_choose_account_type.TabIndex = 0;
            // 
            // tab_ATM_transactions
            // 
            this.tab_ATM_transactions.Location = new System.Drawing.Point(4, 25);
            this.tab_ATM_transactions.Name = "tab_ATM_transactions";
            this.tab_ATM_transactions.Padding = new System.Windows.Forms.Padding(3);
            this.tab_ATM_transactions.Size = new System.Drawing.Size(775, 544);
            this.tab_ATM_transactions.TabIndex = 0;
            this.tab_ATM_transactions.Text = "Провести транзакцию";
            this.tab_ATM_transactions.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_ATM_transactions);
            this.tabControl1.Controls.Add(this.tab_card_accounts);
            this.tabControl1.Controls.Add(this.tab_ATMs);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(783, 573);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(783, 605);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.miniToolStrip);
            this.Location = new System.Drawing.Point(15, 15);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.miniToolStrip.ResumeLayout(false);
            this.miniToolStrip.PerformLayout();
            this.tab_card_accounts.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_accounts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabPage tab_ATMs;

        private System.Windows.Forms.Button button_delete_account;
        private System.Windows.Forms.Button button_change_status;

        private System.Windows.Forms.TextBox textBox_PAS;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.DataGridViewTextBoxColumn StateOfAccount;

        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableCreditLimit;

        private System.Windows.Forms.DataGridViewTextBoxColumn AccountBalace;

        private System.Windows.Forms.DataGridViewTextBoxColumn AccountType;

        private System.Windows.Forms.DataGridViewTextBoxColumn PasswordHash;

        private System.Windows.Forms.DataGridViewTextBoxColumn Id;

        private System.Windows.Forms.Panel panel3;

        private System.Windows.Forms.DataGridView dataGridView_accounts;

        private System.Windows.Forms.TextBox textBox_StartAccountBalace;

        private System.Windows.Forms.ComboBox comboBox_choose_account_type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_AvailableCreditLimit;
        private System.Windows.Forms.Button button_add_accaunt;
        private System.Windows.Forms.Button button_change_accaunt;
        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;

        private System.Windows.Forms.TabPage tab_card_accounts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tab_ATM_transactions;
        private System.Windows.Forms.TabControl tabControl1;

        private System.Windows.Forms.MenuStrip miniToolStrip;

        #endregion
    }
}