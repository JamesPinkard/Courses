using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public class ClassGrades
    {
        private List<int> grades;

        public int[] Grades
        {
            get { return grades.ToArray(); }            
        }

        public void LoadGrades(string gradesText)
        {
            grades = new List<int>();
            string[] gradeArray = gradesText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            // In case there is a blank line in the input textfile
            // This code removes it.
            string[] nonemptyArray = gradeArray.Where(x => x != "").ToArray();
            grades = nonemptyArray.Select(x => int.Parse(x)).ToList();
        }

        public int GetBinCount(int TenPlaceInteger)
        {
            int binCount = grades.Count(x=> x / 10 == TenPlaceInteger);
            return binCount;
        }        
    }
}
