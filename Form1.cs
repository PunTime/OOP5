using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    /*Клас форми Windows Forms*/
    public class Form1 : Form
    {
        /*Вибір типу числа*/
        ComboBox cmbType;
        /*Вибір операції*/
        ComboBox cmbOperation;
        /*Поля для введення чисел*/
        TextBox txtNumber1, txtNumber2;
        /*Кнопка для виконання обчислення*/
        Button btnCalculate;
        /*Мітка для відображення результату*/
        Label lblResult;
        /*Конструктор форми*/
        public Form1()
        {
            /**/
            this.Text = "Задачі? Так задачі!";
            /*Розмір вікна*/
            this.ClientSize = new System.Drawing.Size(400, 250);
            /*Ініціалізація комбобоксів*/
            cmbType = new ComboBox() { Location = new System.Drawing.Point(20, 20), Width = 100 };
            cmbType.Items.AddRange(new object[] { "Fraction", "Complex" });
            /*Встановлюємо перший елемент за замовчуванням*/
            cmbType.SelectedIndex = 0;

            cmbOperation = new ComboBox() { Location = new System.Drawing.Point(150, 20), Width = 100 };
            cmbOperation.Items.AddRange(new object[] { "Add", "Subtract", "Multiply", "Divide" });
            /*Встановлюємо перший елемент за замовчуванням*/
            cmbOperation.SelectedIndex = 0;
            /*Ініціалізація текстових полів*/
            txtNumber1 = new TextBox() { Location = new System.Drawing.Point(20, 60), Width = 100 };
            txtNumber2 = new TextBox() { Location = new System.Drawing.Point(150, 60), Width = 100 };
            /*Ініціалізація кнопки і підписка на подію Click*/
            btnCalculate = new Button() { Location = new System.Drawing.Point(20, 100), Text = "Calculate" };
            btnCalculate.Click += BtnCalculate_Click;
            /*Ініціалізація мітки для результату*/
            lblResult = new Label() { Location = new System.Drawing.Point(20, 140), AutoSize = true };
            /*Додавання елементів на форму*/
            this.Controls.Add(cmbType);
            this.Controls.Add(cmbOperation);
            this.Controls.Add(txtNumber1);
            this.Controls.Add(txtNumber2);
            this.Controls.Add(btnCalculate);
            this.Controls.Add(lblResult);
        }
        /*Обробник натискання кнопки "Calculate"*/
        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                /*Зчитування вибраного типу числа та операції*/
                string type = cmbType.SelectedItem?.ToString() ?? "";
                string operation = cmbOperation.SelectedItem?.ToString() ?? "";
                string num1 = txtNumber1.Text.Trim();
                string num2 = txtNumber2.Text.Trim();
                /*Перевірка на порожній ввід*/
                if (string.IsNullOrEmpty(num1) || string.IsNullOrEmpty(num2))
                {
                    MessageBox.Show("Введіть обидва числа!");
                    return;
                }

                if (type == "Fraction")
                {
                    /*Створення об'єктів дробів*/
                    var a = new MyFrac(num1);
                    var b = new MyFrac(num2);
                    /*Виконання операції залежно від вибору користувача*/
                    MyFrac result = operation switch
                    {
                        "Add" => a.Add(b),
                        "Subtract" => a.Subtract(b),
                        "Multiply" => a.Multiply(b),
                        "Divide" => a.Divide(b),
                        _ => throw new Exception("Невідома операція")
                    };
                    /*Відображення результату*/
                    lblResult.Text = "Result: " + result.ToString();
                }
                else
                {
                    /*Створення об'єктів комплексних чисел*/
                    var a = new MyComplex(num1);
                    var b = new MyComplex(num2);
                    /*Виконання операції залежно від вибору користувача*/
                    MyComplex result = operation switch
                    {
                        "Add" => a.Add(b),
                        "Subtract" => a.Subtract(b),
                        "Multiply" => a.Multiply(b),
                        "Divide" => a.Divide(b),
                        _ => throw new Exception("Невідома операція")
                    };
                    /*Відображення результату*/
                    lblResult.Text = "Result: " + result.ToString();
                }
            }
            catch (Exception ex)
            {
                /*Відображення повідомлення про помилку*/
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}
