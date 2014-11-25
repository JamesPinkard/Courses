using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Abstraction;

namespace Abstraction_Tests
{
    [TestFixture]
    public class HomeworkOne_Tests
    {
        [Test]
        public void PerfectNumbers_SixIsPerfect()
        {
            int six = 6;

            bool result = Program.IsPerfect(six);

            Assert.That(result, Is.True);
        }

        [Test]
        public void PerfectNumbers_ThreeIsNotPerfect()
        {
            int three = 3;

            bool result = Program.IsPerfect(three);

            Assert.That(result, Is.False);
        }

        [Test]
        public void PerfectNumbers_TwentyEightIsPerfect()
        {
            int testInt = 28;

            bool result = Program.IsPerfect(testInt);

            Assert.That(result, Is.True);
        }
    }

    [TestFixture]
    public class Problem4_Soundex_Tests
    {
        [Test]
        public void Soundex_GetCode_KeepFirstLetterOfSurname()
        {
            string testName = "Vaska";
            Soundex mySound = new Soundex();

            string result = mySound.GetCode(testName);

            Assert.That(result[0], Is.EqualTo(testName[0]));
        }

        [Test]
        public void Soundex_GetCode_ConvertTheseLettersToZeroCode()
        {
            string testName = "AEIOUHWY";
            Soundex mySound = new Soundex();

            string result = mySound.GetCode(testName);

            Assert.That(result, Is.EqualTo("A000")); 
        }

        [Test]
        public void Soundex_GetCode_ZelinskiReturnsZ542()
        {
            string testName = "Zelinski";
            Soundex mySound = new Soundex();

            string result = mySound.GetCode(testName);

            Assert.That(result, Is.EqualTo("Z542"));
        }

        [Test]
        public void Soundex_GetCode_DupSoundsAreRemoved()
        {
            string testName = "Focakemon";
            Soundex mySound = new Soundex();

            string result = mySound.GetCode(testName);

            Assert.That(result, Is.EqualTo("F240"));
        }
    }

    [TestFixture]
    public class Problem5_ClassGrades_Tests
    {
        // Assemby is System.Reflection Namespace
        
        Assembly assembly = Assembly.GetExecutingAssembly();
        string resourceName = "Abstraction_Tests.Resources.grades.txt";
        string result;
        
        private ClassGrades SetupClassGrades()
        {
            ClassGrades grades = new ClassGrades();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            grades.LoadGrades(result);
            return grades;
        }

        [Test]
        public void ResourceFile_Exists()
        {            
            Console.WriteLine("The assembly name is {0}", assembly.FullName);
            string[] names = assembly.GetManifestResourceNames();
            foreach (var n in names)
            {
                Console.WriteLine("Resource Name is {0}",n);
            }
                        
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))            
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            Console.WriteLine(result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void LoadGrades_GradesReturnsArrayOfGrades()
        {
            ClassGrades grades = SetupClassGrades();

            grades.LoadGrades(result);

            Assert.That(grades.Grades.Length, Is.EqualTo(12));
        }
        
        [Test]
        public void GetGradeBinCount_ReturnsCountOfTensPlaceInGrades()
        {
            ClassGrades grades = SetupClassGrades();       

            int count = grades.GetBinCount(7);

            Assert.That(count, Is.EqualTo(3));
        }
    }
}
