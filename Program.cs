using System;
using System.Collections.Generic;

namespace lab11
{
    class Program
    {
        static void Main()
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };//определение массива
            Months.PrintMonths(months);//вызов метода

            List<Set> list = new List<Set>//инициализация коллекции
            {
            new Set(626, 315, -2, 220),
            new Set(555),
            new Set(7882, -46),
            new Set(1111, 525, 10, 60),
            new Set(1, 1, 1),
            new Set(1, 2, 3, 4, 300)
             };

            Months.Vectors(list);//вызов метода
        }
    }
}
