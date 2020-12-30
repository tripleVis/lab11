using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace lab11
{
    partial class Set
    {
        public const double PI = 3.141;//константа
        public List<int> Data { get; private set; }

        public static int Counter { get; private set; }

        public Set(int item)
        {
            {
                Data = new List<int>();//инициализация списка
                Data.Add(item);//добавление элемента
                Counter++;//увеличение счётчика
            }
        }

        public Set(params int[] arr)
        {
            Data = new List<int>(arr);//инициализация списка
            Counter++;
        }

        public void Add(int item)
        {
            Data.Add(item);//добавление элемента
        }

        public void Add(params int[] items)
        {
            foreach (var item in items)
            {
                Data.Add(item);//добавление элемента
            }
        }

        public bool Remove(int item)
        {
            if (Data.Contains(item))
            {
                Data.RemoveAll(elem => elem == item);//удаление
                return true;
            }
            return false;
        }

        public int Count(out int counter)//подсчёт
        {
            var list = new List<int>();
            counter = 0;
            foreach (var item in Data)
            {
                if (list.Contains(item))//если есть такой элемент
                    continue;
                else
                {
                    list.Add(item);//если нет, то добавить
                    counter++;
                }
            }
            return counter;
        }

        public static ((Set, int) Min, (Set, int) Max) MinMax(ref List<Set> sets)//поиск множеств с наибольшей и наименьшей суммой элементов
        {
            (Set set, int sum) min = (null, int.MaxValue);
            (Set set, int sum) max = (null, int.MinValue);
            foreach (var set in sets)
            {
                int sum = set.Data.Sum();
                if (sum < min.sum)
                {
                    min.set = set;
                    min.sum = sum;
                }
                if (sum > max.sum)
                {
                    max.set = set;
                    max.sum = sum;
                }
            }
            return (min, max);
        }

        public static List<Set> NegativeSets(List<Set> sets)//отрицатательные элементы
        {
            var list = new List<Set>();
            foreach (var set in sets)
            {
                foreach (var item in set.Data)
                {
                    if (item < 0)
                    {
                        list.Add(set);
                        break;
                    }
                }
            }
            return list;
        }
    }
}
