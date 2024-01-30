using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Лр1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double myFunction(double x)//Вычисление точной суммы ряда вынесено в отдельную функцию. 
        {//Чтобы не менять основной код программы
            return Math.Log(2 - 2 * x + x * x);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "0")//Защита от пустого ввода
            {
                textBox2.Clear();
                double eps = Convert.ToDouble(textBox1.Text); //Читаем данные из интерфейса
                var bigwatch = Stopwatch.StartNew();
                string resul = "";
                for (double x = 0.5; x < 0.76; x += 0.05) //Внешний цикл
                {
                    double func = myFunction(x); //Рассчитываем точную сумму ряда
                    resul += ("X = " + Convert.ToDouble(x) + Environment.NewLine +
                        "Точно: " + Convert.ToString(func) + Environment.NewLine);

                    int k = 2; //счётчик членов ряда
                    double elem = (x - 1) * (x - 1); //Первый член ряда считается вручную, есть в условии
                    double summ = elem; //К сумме сразу добавляем первый член ряда
                    double koeff = 0; //Коэффициент для рекуррентной формулы. Он позволяет избавиться от факториала
                    double curr_eps = Math.Abs(summ - func); //Погрешность вычислений на текущем этапе

                    resul += ("Шаг 1" + //Вывод результатов первго шага
                         ": S = " + Convert.ToString(summ) +
                         "; Eps = " + Convert.ToString(curr_eps) +
                         Environment.NewLine);

                    while (curr_eps > eps)
                    {//Пока модуль разницы между точным и приближенным значением суммы больше введенной погрешности...
                        koeff = -1 * (((x - 1) * (x - 1) * (k - 1)) / (k)); //Коэффициент рекурсивной формулы

                        elem *= koeff; //Умножаем предыдущий член ряда на коэффициент, чтобы получить текущий член ряда
                        summ += elem; // Добавляем то, что получилось, к сумме

                        curr_eps = Math.Abs(summ - func); //Заново вычисляем погрешность

                        resul += ("Шаг " + Convert.ToString(k) + //Вывод результатов
                             ": S = " + Convert.ToString(summ) +
                             "; Eps = " + Convert.ToString(curr_eps) +
                             Environment.NewLine);

                        if (curr_eps == 0 || k >= 1000)//Защита от бесконечного цикла 
                        {
                            resul += ("Введено столько нулей, что double кончился!" + Environment.NewLine);
                            break;
                        }

                        k++; //Не забываем вручную увеличивать счетчик, т.к. цикл у нас по условию.
                    }
                }
                bigwatch.Stop();
                textBox2.Text = resul;
                textBox2.AppendText("Всего затрачено времени: " + Convert.ToString(bigwatch.ElapsedMilliseconds) + " мс. (" +
                    Convert.ToString(bigwatch.ElapsedTicks) + " тиков)" + Environment.NewLine);
            }
            else
            {
                MessageBox.Show("Пустой ввод и ввод нуля запрещен.");
            }

        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox senderTextBox = sender as TextBox;
            char number = e.KeyChar; //Нажатая кнопка. Без неё никак
            if ( //Здесь все условия инверсные. Если введена не цифра, не backspace, не запятая (правильно поставленная) и не минус...
                !Char.IsDigit(number) // Условие ввода цифры
                && number != 8 // Условие ввода backspace
                && !(number == 44 && !senderTextBox.Text.Contains(",") && senderTextBox.Text != "") //Обработка ввода запятой: символ = запятая, в тексте нет запятых и 
                                                                                                    //&& !(number == 45 && !senderTextBox.Text.Contains("-") && senderTextBox.Text == "") //Обработка минуса: он может быть только один и стоит исключительно в начале строки
                )
            {
                e.Handled = true; // Ввод отменяется
                senderTextBox.BackColor = Color.Red; //Красим текстбокс в красный. Можно без этого.
                label1.Text = "Ошибка, введите рациональное число!";
            }
            else//Если ввод нормальный
            {
                senderTextBox.BackColor = Color.White; //Красим текстбокс в белый. Можно без этого.
                label1.Text = "Отлично, нажмите Выполнить!";
            }
        }
    }
}
