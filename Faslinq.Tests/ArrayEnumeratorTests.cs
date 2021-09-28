namespace Faslinq.Tests
{
    [TestClass()]
    public class ArrayEnumeratorTests
    {
        [TestMethod()]
        public void GetArrayEnumeratorTest()
        {
            var array = new[] { 1, 2, 3, 4, 5, };
            var enumerator = new ArrayEnumerator<int>(array);

            enumerator.Should().NotBeNull();

            enumerator.Current.Should().Be(default(int));
        }

        [TestMethod()]
        public void MoveNextTest()
        {
            var array = new[] { 1, 2, 5, };
            var enumerator = new ArrayEnumerator<int>(array);

            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(1);

            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(2);

            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(5);
        }

        [TestMethod()]
        public void ResetTest()
        {
            var array = new[] { 1, 2, 5, };
            var enumerator = new ArrayEnumerator<int>(array);

            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(1);

            enumerator.Reset();
            enumerator.Current.Should().Be(default(int));

            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(1);
        }
    }
}