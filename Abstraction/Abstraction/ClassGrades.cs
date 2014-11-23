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

        public void LoadGrades(string file)
        {
            
        }
    }
}
