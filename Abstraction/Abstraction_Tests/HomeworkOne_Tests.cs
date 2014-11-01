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
    }
}
