using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr6
{
    public class Frunction
    {
        public int numerator;              // Числитель
        public int denominator;            // Знаменатель
        public int sign;                   // Знак
        public Frunction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("В знаменателе не может быть нуля");
            
            this.numerator = Math.Abs(numerator);
            this.denominator = Math.Abs(denominator);

            if (numerator * denominator < 0)//определение знака дроби
            {
                this.sign = -1;
            }
            else
            {
                this.sign = 1;
            }
        }
        // Вызов первого конструктора со знаменателем равным единице
        public Frunction(int number) : this(number, 1) { }
        // Возвращает наибольший общий делитель (Алгоритм Евклида)
        private static int getGreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        // Возвращает наименьшее общее кратное
        private static int getLeastCommonMultiple(int a, int b)
        {
            return a * b / getGreatestCommonDivisor(a, b);
        }
        private static Frunction performOperation(Frunction a, Frunction b, Func<int, int, int> operation)
        {
            // Наименьшее общее кратное знаменателей
            int leastCommonMultiple = getLeastCommonMultiple(a.denominator, b.denominator);
            // Дополнительный множитель к первой дроби
            int additionalMultiplierFirst = leastCommonMultiple / a.denominator;
            // Дополнительный множитель ко второй дроби
            int additionalMultiplierSecond = leastCommonMultiple / b.denominator;
            // Результат операции
            int operationResult = operation(a.numerator * additionalMultiplierFirst * a.sign,
            b.numerator * additionalMultiplierSecond * b.sign);
            return new Frunction(operationResult, a.denominator * additionalMultiplierFirst);
        }
        // Перегрузка оператора "+" для случая сложения двух дробей
        public static Frunction operator +(Frunction a, Frunction b)
        {
            return performOperation(a, b, (int x, int y) => x + y);
        }
        // Перегрузка оператора "-" для случая вычитания двух дробей
        public static Frunction operator -(Frunction a, Frunction b)
        {
            return performOperation(a, b, (int x, int y) => x - y);
        }
        
        // Возвращает дробь с противоположным знаком
       /* private Frunction GetWithChangedSign()
        {
            return new Frunction(-this.numerator * this.sign, this.denominator);
        }*/
        // Возвращает сокращенную дробь
        /*public Frunction Reduce()
        {
            Frunction result = this;
            int greatestCommonDivisor = getGreatestCommonDivisor(this.numerator, this.denominator);
            result.numerator /= greatestCommonDivisor;
            result.denominator /= greatestCommonDivisor;
            return result;
        }*/
    }
    class NewFrunction : Frunction
    { 
        public NewFrunction(int a, int b) : base(a, b) {}
        public static NewFrunction operator *(NewFrunction a, NewFrunction b)
        {
            return new NewFrunction(a.numerator * a.sign * b.numerator * b.sign, a.denominator * b.denominator);
        }
        // Перегрузка оператора "/" для случая деления двух дробей
        public static NewFrunction operator /(NewFrunction a, NewFrunction b)
        {
            return a * b.GetReverse();
        }
        //Возвращает дробь, обратную данной
        private NewFrunction GetReverse()
        {
            return new NewFrunction(this.denominator * this.sign, this.numerator);
        }
    }
}
