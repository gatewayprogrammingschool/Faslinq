namespace Faslinq.Benchmarks.Scalar;

public abstract class ScalarBenchmarkBase : BenchmarkBase
{
    protected abstract TData LinqControl<TData>(object item)
        where TData : struct;
}
