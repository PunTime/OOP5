using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    /*Клас, що представляє дроби*/
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        /*чисельник*/
        public BigInteger nom;
        /*знаменник*/
        public BigInteger denom;
        /*Конструктор з BigInteger*/
        public MyFrac(BigInteger n, BigInteger d)
        {
            /*перевірка ділення на нуль*/
            if (d == 0) throw new DivideByZeroException("Denominator = 0");
            nom = n;
            denom = d;
            Normalize();
        }
        /*Конструктор з int, перенаправляє до BigInteger*/
        public MyFrac(int n, int d) : this(new BigInteger(n), new BigInteger(d)) { }
        /*Конструктор з рядка формату чисельник/знаменник*/
        public MyFrac(string s)
        {
            if (!s.Contains("/"))
                throw new ArgumentException("Invalid fraction format");

            var parts = s.Split('/');
            nom = BigInteger.Parse(parts[0]);
            denom = BigInteger.Parse(parts[1]);
            if (denom == 0) throw new DivideByZeroException();
            Normalize();
        }
        /*Метод нормалізації дробу: скорочення та приведення знаменника до додатного*/
        void Normalize()
        {
            /*знаходить НСД*/
            BigInteger g = BigInteger.GreatestCommonDivisor(nom, denom);
            nom /= g;
            denom /= g;
            if (denom < 0)
            {
                nom = -nom;
                denom = -denom;
            }
        }
        /*Додавання дробів*/
        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(nom * that.denom + that.nom * denom,
                              denom * that.denom);
        }
        /*Віднімання дробів*/
        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(nom * that.denom - that.nom * denom,
                              denom * that.denom);
        }
        /*Множення дробів*/
        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(nom * that.nom, denom * that.denom);
        }
        /*Ділення дробів*/
        public MyFrac Divide(MyFrac that)
        {
            if (that.nom == 0) throw new DivideByZeroException();
            return new MyFrac(nom * that.denom, denom * that.nom);
        }
        /*Перевизначення ToString() для зручного виводу*/
        public override string ToString()
        {
            return $"{nom}/{denom}";
        }
        /*Метод порівняння дробів*/
        public int CompareTo(MyFrac other)
        {
            /*Порівнюємо дроби без приведення до спільного знаменника в int*/
            BigInteger left = this.nom * other.denom;
            BigInteger right = other.nom * this.denom;
            return left.CompareTo(right);
        }
    }
}
