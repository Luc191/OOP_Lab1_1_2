
namespace Test1
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        [TestCase(0, 0)]
        [TestCase(6, 0)]
        [TestCase(-6, 0)]
        public void TestDenominator(int a, int b)
        {
            Assert.That(() => new RationalNumber(a, b), Throws.Exception);
        }

        [Test]
        [TestCase(1, 3, "1/3")]
        [TestCase(-2, -3, "2/3")]
        [TestCase(4, 4, "1")]
        [TestCase(-3, 5, "-3/5")]
        [TestCase(4, -6, "-2/3")]
        public void TestToString(int a, int b, string result)
        {
            var x = new RationalNumber(a, b);
            Assert.IsTrue(result == x.ToString());
        }

        [Test]
        [TestCase(1, 3, 2, 3, "1")]
        [TestCase(-2, 3, 2, 3, "0")]
        [TestCase(4, 2, 4, 2, "4")]
        [TestCase(-2, 3, -5, 3, "-7/3")]
        [TestCase(10, 3, 5, 4, "55/12")]
        public void TestOperatorPlus(int a, int b, int a1, int b1, string result)
        {
            var x = new RationalNumber(a, b);
            var y = new RationalNumber(a1, b1);
            x = x + y;
            Assert.That((result == x.ToString()), Is.True);
        }

        [Test]
        [TestCase(1, 3, 2, 3, "-1/3")]
        [TestCase(-2, 3, 2, 3, "-4/3")]
        [TestCase(4, 2, 4, 2, "0")]
        [TestCase(-2, 3, -5, 3, "1")]
        [TestCase(10, 3, 5, 4, "25/12")]
        public void TestOperatorMinus(int a, int b, int a1, int b1, string result)
        {
            var x = new RationalNumber(a, b);
            var y = new RationalNumber(a1, b1);
            x = x - y;
            Assert.That((result == x.ToString()), Is.True);
        }

        [Test]
        [TestCase(1, 3, 2, 3, "2/9")]
        [TestCase(-2, 3, 2, 3, "-4/9")]
        [TestCase(4, 2, 4, 2, "4")]
        [TestCase(-2, 3, -5, 3, "10/9")]
        [TestCase(10, 3, 5, 4, "25/6")]
        public void TestOperatorMultiplication(int a, int b, int a1, int b1, string result)
        {
            var x = new RationalNumber(a, b);
            var y = new RationalNumber(a1, b1);
            x = x * y;
            Assert.That((result == x.ToString()), Is.True);
        }

        [Test]
        [TestCase(1, 3, 2, 3, "1/2")]
        [TestCase(-2, 3, 2, 3, "-1")]
        [TestCase(4, 2, 4, 2, "1")]
        [TestCase(-2, 3, -5, 3, "2/5")]
        [TestCase(10, 3, 5, 4, "8/3")]
        public void TestOperatorDivision(int a, int b, int a1, int b1, string result)
        {
            var x = new RationalNumber(a, b);
            var y = new RationalNumber(a1, b1);
            x = x / y;
            Assert.That((result == x.ToString()), Is.True);
        }

        [Test]
        [TestCase(1, 3, 2, 3, false)]
        [TestCase(-2, 3, 2, 3, false)]
        [TestCase(4, 2, 4, 2, false)]
        [TestCase(-2, 3, -5, 3, true)]
        [TestCase(10, 3, 5, 4, true)]
        public void TestOperatorMore(int a, int b, int a1, int b1, bool result)
        {
            var x = new RationalNumber(a, b);
            var y = new RationalNumber(a1, b1);
            Assert.That(result == x > y, Is.True);
        }

        [Test]
        [TestCase(1, 3, 2, 3, false)]
        [TestCase(-2, 3, 2, 3, false)]
        [TestCase(4, 2, 4, 2, true)]
        [TestCase(-2, 3, -5, 3, true)]
        [TestCase(10, 3, 5, 4, true)]
        public void TestOperatorMoreEq(int a, int b, int a1, int b1, bool result)
        {
            var x = new RationalNumber(a, b);
            var y = new RationalNumber(a1, b1);
            Assert.That(result == x >= y, Is.True);
        }

        [Test]
        [TestCase(1, 3, 2, 3, true)]
        [TestCase(-2, 3, 2, 3, true)]
        [TestCase(4, 2, 4, 2, false)]
        [TestCase(-2, 3, -5, 3, false)]
        [TestCase(10, 3, 5, 4, false)]
        public void TestOperatorLess(int a, int b, int a1, int b1, bool result)
        {
            var x = new RationalNumber(a, b);
            var y = new RationalNumber(a1, b1);
            Assert.That(result == x < y, Is.True);
        }

        [Test]
        [TestCase(1, 3, 2, 3, true)]
        [TestCase(-2, 3, 2, 3, true)]
        [TestCase(4, 2, 4, 2, true)]
        [TestCase(-2, 3, -5, 3, false)]
        [TestCase(10, 3, 5, 4, false)]
        public void TestOperatorLessEq(int a, int b, int a1, int b1, bool result)
        {
            var x = new RationalNumber(a, b);
            var y = new RationalNumber(a1, b1);
            Assert.That(result == x <= y, Is.True);
        }


        [Test]
        [TestCase(-2, 3, -2, 3, true)]
        [TestCase(-2, 3, 2, 3, false)]
        [TestCase(4, 2, 4, 2, true)]
        [TestCase(-2, 3, -5, 3, false)]
        [TestCase(10, 3, 5, 4, false)]
        public void TestOperatorEqual(int a, int b, int a1, int b1, bool result)
        {
            var x = new RationalNumber(a, b);
            var y = new RationalNumber(a1, b1);
            Assert.That(result == (x == y), Is.True);
        }

        [Test]
        [TestCase(-2, 3, -2, 3, false)]
        [TestCase(-2, 3, 2, 3, true)]
        [TestCase(4, 2, 4, 2, false)]
        [TestCase(-2, 3, -5, 3, true)]
        [TestCase(10, 3, 5, 4, true)]
        public void TestOperatorNotEqual(int a, int b, int a1, int b1, bool result)
        {
            var x = new RationalNumber(a, b);
            var y = new RationalNumber(a1, b1);
            Assert.That(result == (x != y), Is.True);
        }

        [Test]
        [TestCase(-2, 3, "2/3")]
        [TestCase(-2, -3, "-2/3")]
        [TestCase(4, -3, "4/3")]
        [TestCase(5, 3, "-5/3")]
        public void TestOperatorUnaryMinus(int a, int b, string result)
        {
            var x = new RationalNumber(a, b);
            x = -x;
            Assert.That(x.ToString() == result, Is.True);
        }
    }
}