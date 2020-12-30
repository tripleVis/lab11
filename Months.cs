using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace lab11
{
   static class Months
    {
        public static void PrintMonths(string[] months)
        {
            Console.WriteLine("Введите n");
            if (!int.TryParse(Console.ReadLine(), out int n))//если не удалось преобразовать
            {
                throw new Exception();//генерация исключения
            }
            var nmonths = (from a in months
                           where a.Length == n
                           select a).ToArray();//заполнение nmonths элементами массива months с длиной n
            Console.WriteLine($"\tМесяца с длиной названия {n} символов: ");
            foreach (var item in nmonths)
            {
                Console.Write(item + ' ' + '\t');
            }
            //------
            Console.WriteLine("\n\tСортировка");
            var sorted = months.OrderBy(i => i);//сортировка
            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }
            //------
            Console.WriteLine("\n\tС буквой u и длиной более 4 символов");
            var contain = (from a in months
                          where a.Length  >4
                          where a.Contains("u")
                          select a).ToArray();//заполнение месяцами с длиной 4+ и буквой u
            foreach (var item in contain)
            {
                Console.Write(item +' '+ '\t');
            }
        }

        

        public static void Vectors(List<Set> list)
        {
            var max = list.OrderByDescending(item => item.Data.Sum()).First();//первый вектор с наибольшей суммой
            var min = list.OrderBy(item => item.Data.Sum()).First();//первый вектор с наименьшей суммой
            var negative = from t in list
                           where t.Data.Min() < 0
                           select t;//отрицательные элементы
            //-----------------------------------
            Console.WriteLine("\nВведите значение:");
            if (!int.TryParse(Console.ReadLine(), out int elem))
            {
                throw new Exception();
            }
            else
            {
                var elems = (from z in list where z.Data.Contains(elem) select z).Count();//кол-во векторов, содержащих введенный элемент
                Console.WriteLine(elems);

            }
            var maxvect = list.OrderByDescending(item => item.Data.Count).First();//вектор с наибольшим кол-вом элементов
            //          ---------------------------------
            Console.WriteLine("\nВведите значение:");
            if (!int.TryParse(Console.ReadLine(), out int item))
            {
                throw new Exception();
            }
            else
            {
                var set = list.Where(item => item.Data.Contains(elem)).First();//первый вектор, содержащий введенный элемент

            }
        }
        //-------------------------------------
        // Список с отрицательными значениями
        public static void GetUnderperforming(List<Set> list) {
            var zz=
            from t in list
            where t.Data.Min() < 0
            select t;
        }
           


        public static void  GetMoreThan(List<Set> list) =>
            list.OrderByDescending(item => item.Data.Sum()).Last();//вектор с наименьшей суммой элементов


        public static int Get(List<Set> list) =>
           list.Count;//кол-во векторов

    
        public static List<Set> GetOrdered(List<Set> list) =>
            list.OrderBy(item=>item).ToList();//Сортировка по возрастанию
        
        
        public static List<Set> GetWorst(List<Set> list) =>
            list.OrderByDescending(item => item.Data.Sum()).TakeLast(4).ToList();//4 вектора с наименьшей суммой
        //----------------------------------
        private class Item1
        {
            public string Prop1 { get; private set; }//свойства
            public string Prop2 { get; private set; }
            public Item1(string prop1, string prop2)
            {
                Prop1 = prop1;
                Prop2 = prop2;
            }
        }

        private class Item2
        {
            public string Prop1 { get; private set; }
            public string Prop2 { get; private set; }
            public Item2(string prop1, string prop2)
            {
                Prop1 = prop1;
                Prop2 = prop2;
            }
        }
        static void WithJoin()
        {
            var items1 = new List<Item1> {
                new Item1("123", "qwe"),
                new Item1("345", "asd"),
                new Item1("789", "zxc")
            };
            var items2 = new List<Item2> {
                new Item2("rty", "345"),
                new Item2("fgh", "123"),
                new Item2("vbn", "789")
            };
            var res = items1.Join(items2, k1 => k1.Prop1, k2 => k2.Prop2,//объект k1 из списка items1 соединяется с объектом k2 из списка items2,
                (k1, k2) => new { k1.Prop1, Prop2 = k2.Prop1 });//если значение свойства k1.Prop1 совпадает со значением свойства k2.Prop2
            foreach (var item in res)
                Console.WriteLine($"{item.Prop1} {item.Prop2}");//вывод
        }
    }
}
