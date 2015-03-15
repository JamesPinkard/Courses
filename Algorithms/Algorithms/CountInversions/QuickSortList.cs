using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountInversions
{
    class QuickSortList
    {
        public List<int> Numbers = new List<int>();
        public Int64 ScanCount { get; set; }

        public int this[int index]
        {
            get { return (int)Numbers[index]; }
            set { Numbers[index] = value; }
        }

        public QuickSortList()
        {
            ScanCount = 0;
        }
        public QuickSortList(List<int> numbers)
        {
            Numbers = numbers;
            ScanCount = 0;
        }

        public InversionList GetFirstHalf()
        {
            int count = Numbers.Count;
            InversionList firstHalf = new InversionList(Numbers.GetRange(0, count / 2));
            return firstHalf;
        }

        public InversionList GetSecondHalf()
        {
            int count = Numbers.Count;
            InversionList secondHalf = new InversionList(Numbers.GetRange(count / 2, count - (count / 2)));
            return secondHalf;
        }

        public override string ToString()
        {
            string print="";

            foreach (var item in Numbers)
            {
                print += string.Format("{0}, ", item);
            }
            return print;
        }

        public int NumCount()
        {
            return Numbers.Count();
        }

        internal void Add(int p)
        {
            Numbers.Add(p);
        }
    }
}
