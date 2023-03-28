using System;
using System.Windows.Forms;

namespace Lesson_2._1
{
    public partial class Enter_pin : Form
    {
        public string Result { get; set; } 
        public Enter_pin()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            else if (textBox_PIN.Text.Length >= 4 && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result = textBox_PIN.Text; // сохраняем введенное значение в свойство Result
            if (Result.Length == 4)
            {
                DialogResult = DialogResult.OK; // устанавливаем результат диалога как OK
                Close(); // закрываем дочернюю форму   
            }
        }
    }
}