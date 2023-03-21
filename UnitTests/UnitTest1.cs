using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SF2022User_NN_Lib;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_actualIsStringArray_true()
        {
            TimeSpan[] st = new TimeSpan[5];
            int[] d = new int[] { 60, 30, 10, 10, 40 };
            st[0] = new TimeSpan(10, 0, 0);
            st[1] = new TimeSpan(11, 0, 0);
            st[2] = new TimeSpan(15, 0, 0);
            st[3] = new TimeSpan(15, 30, 0);
            st[4] = new TimeSpan(16, 50, 0);
            TimeSpan begin = new TimeSpan(8, 0, 0), end = new TimeSpan(18, 0, 0);
            int cons = 30;

            string[] actual = Calculations.AvailablePeriods(st, d, begin, end, cons);

            Assert.IsInstanceOfType(actual, typeof(string[]));
        }

        [TestMethod]
        public void TestMethod_isBeginLessEnd_true()
        {
            TimeSpan[] st = new TimeSpan[5];
            int[] d = new int[] { 60, 30, 10, 10, 40 };
            st[0] = new TimeSpan(10, 0, 0);
            st[1] = new TimeSpan(11, 0, 0);
            st[2] = new TimeSpan(15, 0, 0);
            st[3] = new TimeSpan(15, 30, 0);
            st[4] = new TimeSpan(16, 50, 0);
            TimeSpan begin = new TimeSpan(8, 0, 0), end = new TimeSpan(18, 0, 0);
            int cons = 30;

            string[] actual = Calculations.AvailablePeriods(st, d, begin, end, cons);

            Assert.IsTrue(begin < end);
        }

        [TestMethod]
        public void TestMethod_actualIsNull_true()
        {
            TimeSpan[] st = new TimeSpan[] { };
            int[] d = null;
            TimeSpan begin = new TimeSpan(), end = new TimeSpan(18, 0, 0);
            int cons = 30;

            string[] actual = Calculations.AvailablePeriods(st, d, begin, end, cons);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void TestMethod_actualIsNotEqualExpected_false()
        {
            string[] expected = new string[] { "08:00-08:30", "08:30-09:00", "09:00-09:30", "09:30-10:00", "11:30-12:00", "12:00-12:30", "12:30-13:00", "13:00-13:30", "13:30-14:00", "14:00-14:30", "14:30-15:00", "15:40-16:10", "16:10-16:40", "17:30-18:00" };
            TimeSpan[] st = new TimeSpan[6];
            int[] d = new int[] { 120, 90, 60, 20, 30, 30 };
            st[0] = new TimeSpan(8, 0, 0);
            st[1] = new TimeSpan(11, 0, 0);
            st[2] = new TimeSpan(15, 0, 0);
            st[3] = new TimeSpan(16, 40, 0);
            st[4] = new TimeSpan(18, 0, 0);
            st[5] = new TimeSpan(19, 30, 0);
            TimeSpan begin = new TimeSpan(8, 0, 0), end = new TimeSpan(20, 0, 0);
            int cons = 30;

            string[] actual = Calculations.AvailablePeriods(st, d, begin, end, cons);

            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void TestMethod_actualIsNotNull_false()
        {
            TimeSpan[] st = new TimeSpan[5];
            int[] d = new int[] { 60, 30, 10, 10, 40 };
            st[0] = new TimeSpan(10, 0, 0);
            st[1] = new TimeSpan(11, 0, 0);
            st[2] = new TimeSpan(15, 0, 0);
            st[3] = new TimeSpan(15, 30, 0);
            st[4] = new TimeSpan(16, 50, 0);
            TimeSpan begin = new TimeSpan(8, 0, 0), end = new TimeSpan(18, 0, 0);
            int cons = 100;

            string[] actual = Calculations.AvailablePeriods(st, d, begin, end, cons);

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void TestMethod_isNullStartTimesThrowsException_true()
        {
            TimeSpan[] st = null;
            int[] d = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan begin = new TimeSpan(8, 0, 0), end = new TimeSpan(18, 0, 0);
            int cons = 100;

            string[] actual = Calculations.AvailablePeriods(st, d, begin, end, cons);

            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => Calculations.AvailablePeriods(st, d, begin, end, cons)));
        }

        [TestMethod]
        public void TestMethod_isDifferentArrayLengthThrowsException_true()
        {
            TimeSpan[] st = new TimeSpan[5];
            int[] d = new int[] { 60, 30, 10, 10, 40, 40 };
            st[0] = new TimeSpan(10, 0, 0);
            st[1] = new TimeSpan(11, 0, 0);
            st[2] = new TimeSpan(15, 0, 0);
            st[3] = new TimeSpan(15, 30, 0);
            st[4] = new TimeSpan(16, 50, 0);
            TimeSpan begin = new TimeSpan(8, 0, 0), end = new TimeSpan(18, 0, 0);
            int cons = 100;

            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<IndexOutOfRangeException>(() => Calculations.AvailablePeriods(st, d, begin, end, cons)));
        }

        [TestMethod]
        public void TestMethod_isNullValuesThrowsException_true()
        {
            TimeSpan[] st = null;
            int[] d = null;
            TimeSpan begin = new TimeSpan(), end = new TimeSpan();
            int cons = 0;

            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<IndexOutOfRangeException>(() => Calculations.AvailablePeriods(st, d, begin, end, cons)));
        }

        [TestMethod]
        public void TestMethod_isActualNotNullWithNegativeValues_false()
        {
            TimeSpan[] st = new TimeSpan[5];
            int[] d = new int[] { -60, -30, -10, -10, -40 };
            st[0] = new TimeSpan(-10, 0, 0);
            st[1] = new TimeSpan(-11, 0, 0);
            st[2] = new TimeSpan(-15, 0, 0);
            st[3] = new TimeSpan(-15, 30, 0);
            st[4] = new TimeSpan(-16, 50, 0);
            TimeSpan begin = new TimeSpan(-8, 0, 0), end = new TimeSpan(-18, 0, 0);
            int cons = -100;

            string[] actual = Calculations.AvailablePeriods(st, d, begin, end, cons);

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void TestMethod_isBoundaryConditionsThrowsException_true()
        {
            TimeSpan[] st = new TimeSpan[5];
            int[] d = new int[] { 60, 30, 10, 10, 40 };
            st[0] = new TimeSpan(9, 0, 0);
            st[1] = new TimeSpan(1, 0, 0);
            st[2] = new TimeSpan(15, 0, 0);
            st[3] = new TimeSpan(15, 30, 0);
            st[4] = new TimeSpan(16, 50, 0);
            TimeSpan begin = new TimeSpan(8, 0, 0), end = new TimeSpan(18, 0, 0);
            int cons = int.MaxValue;

            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<ArgumentOutOfRangeException>(() => Calculations.AvailablePeriods(st, d, begin, end, cons)));
        }
    }
}
