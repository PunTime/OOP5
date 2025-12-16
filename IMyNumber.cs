using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5
{
    /*Оголошення дженерик-інтерфейсу для арифметичних операцій*/
    public interface IMyNumber<T> where T : IMyNumber<T>
    {
        /*Метод додавання: повертає результат того ж типу*/
        T Add(T b);
        /*Метод віднімання*/
        T Subtract(T b);
        /*Метод множення*/
        T Multiply(T b);
        /*Метод ділення*/
        T Divide(T b);
    }
}
