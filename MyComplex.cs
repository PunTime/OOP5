using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    /*Реалізує інтерфейс IMyNumber<MyComplex>, тобто забезпечує арифметичні операції над власним типом*/
    public class MyComplex : IMyNumber<MyComplex>
    {
        /*Дійсна частина комплексного числа*/
        public double re;
        /*Уявна частина комплексного числа*/
        public double im;
        /*Конструктор за двома числовими значеннями*/
        public MyComplex(double r, double i)
        {
            re = r; im = i;
        }
        /*Конструктор із рядка, наприклад "3 +  4i" або "5 - 2i"*/
        public MyComplex(string s)
        {
            /*прибираємо 'i' та пробіли*/
            s = s.Replace("i", "").Replace(" ", "");
            double a = 0, b = 0;
            /*Шукаємо позиції '+' та '-' (після першого символу, щоб не сплутати з знаком числа)*/
            int plus = s.IndexOf('+', 1);
            int minus = s.IndexOf('-', 1);
            /*Якщо знайдено '+', розділяємо рядок на дійсну і уявну частини*/
            if (plus >= 0)
            {
                a = double.Parse(s.Substring(0, plus));
                b = double.Parse(s.Substring(plus + 1));
            }
            /*Якщо знайдено '-', розділяємо рядок на дійсну і уявну частини*/
            else if (minus >= 0)
            {
                a = double.Parse(s.Substring(0, minus));
                b = double.Parse(s.Substring(minus));
            }
            else
            {
                /*Якщо немає '+' або '-', це може бути чисто дійсне або уявне число*/
                if (s.EndsWith("i")) b = double.Parse(s.Replace("i", ""));
                else a = double.Parse(s);
            }

            re = a;
            im = b;
        }
        /*Додавання комплексних чисел*/
        public MyComplex Add(MyComplex that)
            => new MyComplex(this.re + that.re, this.im + that.im);
        /*Віднімання комплексних чисел*/
        public MyComplex Subtract(MyComplex that)
            => new MyComplex(this.re - that.re, this.im - that.im);
        /*Множення комплексних чисел*/
        public MyComplex Multiply(MyComplex that)
        {
            double real = re * that.re - im * that.im;
            double imag = re * that.im + im * that.re;
            return new MyComplex(real, imag);
        }
        /*Ділення комплексних чисел*/
        public MyComplex Divide(MyComplex that)
        {
            /*квадрат модуля дільника*/
            double r2 = that.re * that.re + that.im * that.im;
            /*перевірка ділення на нуль*/
            if (r2 == 0) throw new DivideByZeroException();

            double real = (re * that.re + im * that.im) / r2;
            double imag = (im * that.re - re * that.im) / r2;

            return new MyComplex(real, imag);
        }
        /*Перевизначення методу ToString для зручного виводу*/
        public override string ToString()
        {
            /*виводимо у стандартному вигляді "a+bi"*/
            return $"{re}+{im}i";
        }
    }
}
