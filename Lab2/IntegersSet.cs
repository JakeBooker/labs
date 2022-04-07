using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaboratoryWork2
{
    public class IntegersSet : IEnumerable<int>
    {
        private readonly List<int> _set;

        public IntegersSet(params int[] nums)
        {
            _set = new List<int>();
            foreach (var num in nums)
            {
                _set.Add(num);
            }
        }

        public void AddElement(int number)
        {
            if (_set.Contains(number))
            {
                Console.WriteLine("Нельзя добавлять числа, которые уже содержатся в множестве.");
                return;
            }
            _set.Add(number);
        }

        public void RemoveElement(int number)
        {
            foreach(var num in _set)
            {
                if (num == number)
                {
                    _set.Remove(num);
                    return;
                }
            }
            Console.WriteLine("Такого числа в множестве нет.");
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach(int num in _set)
            {
                yield return num;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static bool operator ==(IntegersSet set1, IntegersSet set2)
        {
            return set1.GetHashCode() == set2.GetHashCode(); 
        }

        public static bool operator !=(IntegersSet set1, IntegersSet set2)
        {
            return !(set1 == set2);
        }

        public override int GetHashCode()
        {
            return _set.Sum();
        }

        public override bool Equals(Object o)
        {
            return o as IntegersSet == this;
        }

        public static IntegersSet operator -(IntegersSet set1, IntegersSet set2)
        {
            var newIntSet = new IntegersSet();

            if (set1.GetHashCode() == set2.GetHashCode())
                return newIntSet;

            foreach(var num in set1)
            {
                var flag = true;
                foreach(var num2 in set2)
                {
                    if (num2 == num)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    newIntSet.AddElement(num);
            }

            return newIntSet;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append("Всего элементов в множестве - " + _set.Count + "\n");
            foreach (var num in _set)
            {
                str.Append(num + " ");
            }

            return str.ToString();
        }
    }
}