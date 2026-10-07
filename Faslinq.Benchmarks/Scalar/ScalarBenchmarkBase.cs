namespace Faslinq.Benchmarks.Scalar;

public abstract class ScalarBenchmarkBase : BenchmarkBase
{
    /// <summary>
    /// The record the concrete benchmarks pass to <see cref="BenchmarkBase.ProcessScalar"/>.
    /// </summary>
    protected abstract TestValueTuple SelectTarget(IReadOnlyList<TestValueTuple> records);

    /// <summary>
    /// The System.Linq result the benchmark's Faslinq path must match.
    /// </summary>
    protected abstract TestValueTuple LinqControl(IEnumerable<TestValueTuple> records, TestValueTuple target);

    public void Test(object[] item, Tests test)
    {
        var records = item[0]
            .As<IEnumerable<TestValueTuple>>()
            .ToArray();

        records.Should()
            .NotBeEmpty();

        var target = SelectTarget(records);

        // Hand ProcessScalar the shape the test names; a plain IEnumerable takes the Linq path.
        object source = test switch
        {
            Tests.List => records.ToList(),
            Tests.Array => records,
            _ => Enumerable.Select(records, record => record),
        };

        var result = ProcessScalar(source, target);
        var expected = LinqControl(records, target);

        result.Should()
            .Be(expected);
    }
}
