using System;
using System.Text;

namespace PowerUtils.BuildingBlocks.Domain.Benchmarks.EntityBaseBenchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class GetHashCodeBenchmarks
{
    private static readonly Guid _id = Guid.NewGuid();
    [Benchmark]
    public void GetHashCode_HashCodeCombine()
    {
        var obj = new object();

        _ = HashCode.Combine(obj.GetType(), _id);
    }

    [Benchmark]
    public void GetHashCode_StringBuilder()
    {
        var obj = new object();

        var stringBuild = new StringBuilder();
        stringBuild.Append(obj.GetType());
        stringBuild.Append(_id);
        _ = stringBuild.ToString().GetHashCode();
    }

    [Benchmark]
    public void GetHashCode_StringFormat()
    {
        var obj = new object();

        _ = string.Format("{0}{1}", obj.GetType(), _id).GetHashCode();
    }

    [Benchmark]
    public void GetHashCode_StringJoin()
    {
        var obj = new object();

        _ = string.Join("", obj.GetType(), _id).GetHashCode();
    }

    [Benchmark]
    public void GetHashCode_InlineConcat()
    {
        var obj = new object();

        _ = (obj.GetType().ToString() + _id).GetHashCode();
    }

    [Benchmark]
    public void GetHashCode_InlineConcat_WithoutToString()
    {
        var obj = new object();

        _ = (obj.GetType() + "" + _id).GetHashCode();
    }

    [Benchmark]
    public void GetHashCode_Decomposed()
    {
        var obj = new object();

        var type = obj.GetType().ToString();
        var aux = type + _id;
        _ = aux.GetHashCode();
    }

    [Benchmark(Baseline = true)]
    public void GetHashCode_InterpolationString()
    {
        var obj = new object();

        _ = $"{obj.GetType()}{_id}".GetHashCode();
    }
}
