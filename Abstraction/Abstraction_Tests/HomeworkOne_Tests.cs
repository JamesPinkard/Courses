using System;
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
}
