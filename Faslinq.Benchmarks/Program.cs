using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using BenchmarkDotNet.Extensions;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

using FastSerialization;

using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace Faslinq.Benchmarks;

public class Program
{
    public static void Main(string[] args)
    {
        args = args.ToList()
            .SelectMany(ab => ab.Split(' '))
            .ToArray();

        Console.WriteLine($"{args.Length}");
        Console.WriteLine($"{string.Join(", ", args)}");
        Console.WriteLine("---\n");

        List<string> aa = new(args);

        var filters = ProcessFilters(aa);

        var config =
                new FaslinqConfig()
                    .KeepBenchmarkFiles()
                    .WithOrderer(new FaslinqConfig.FaslinqOrderer())
                    .WithOptions(ConfigOptions.DisableOptimizationsValidator)
            ;

        var counter = 1;
        foreach (var filter in filters)
        {
            if (!aa.Any(a => a.Equals("--filter", StringComparison.CurrentCultureIgnoreCase)))
            {
                aa.Insert(0, "--filter");
            }

            if (counter < aa.Count)
            {
                aa.Insert(counter++, $"*{filter}*");
            }
            else
            {
                aa.Add($"*{filter}*");
            }
        }

        var join = aa.FirstOrDefault(a => a.Equals("-Join", StringComparison.CurrentCultureIgnoreCase));
        if (join is not (null or ""))
        {
            aa.Remove(join);
            aa.Add("--join");
        }

#if DEBUG
        if (aa.All(a => !a.Equals("--runonceperiteration", StringComparison.CurrentCultureIgnoreCase)))
        {
            aa.Add("--runOncePerIteration");
        }
#endif

        Console.WriteLine("--------");
        aa.ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine("--------\n");

        BenchmarkSwitcher
            .FromAssembly(typeof(Program).Assembly)
            .Run(aa.ToArray(), config);
    }

    private static List<string> ProcessFilters(List<string> args)
    {
        var Where = args.Any(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase));
        var Select = args.Any(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase));
        var Take = args.Any(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase));
        var TakeLast = args.Any(a => a.Equals("-takelast", StringComparison.OrdinalIgnoreCase));
        var First = args.Any(a => a.Equals("-first", StringComparison.OrdinalIgnoreCase));
        var FirstWhere = args.Any(a => a.Equals("-firstwhere", StringComparison.OrdinalIgnoreCase));
        var Last = args.Any(a => a.Equals("-last", StringComparison.OrdinalIgnoreCase));
        var LastWhere = args.Any(a => a.Equals("-lastwhere", StringComparison.OrdinalIgnoreCase));

        List<string> filters = new();
        List<string> f = new();

        var match = (Where, Select, Take || TakeLast, FirstWhere || First || LastWhere || Last);

        switch (match)
        {
            case (true, true, true, _):
                {
                    if (Take)
                    {
                        var take = args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? ""
                        );
                        args.RemoveAt(take);

                        f.Add("WhereSelectTake");
                        f.Add("WhereTake");
                        f.Add("SelectTake");
                        f.Add("Take");
                    }

                    if (TakeLast)
                    {
                        var takeLast =
                            args.IndexOf(
                                args.FirstOrDefault(
                                    a =>
                                        a.Equals("-takelast", StringComparison.OrdinalIgnoreCase)
                                )
                                ?? ""
                            );
                        args.RemoveAt(takeLast);

                        f.Add("WhereSelectTakeLast");
                        f.Add("WhereTakeLast");
                        f.Add("SelectTakeLast");
                        f.Add("TakeLast");
                    }

                    f.Add("WhereSelect");
                    f.Add("Where");
                    f.Add("Select");

                    var where = args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? ""
                    );
                    args.RemoveAt(where);

                    var select =
                        args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? ""
                        );
                    args.RemoveAt(select);
                    break;
                }
            case (true, false, true, _):
                {
                    if (Take)
                    {
                        var take = args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? ""
                        );
                        args.RemoveAt(take);

                        f.Add("WhereTake");
                        f.Add("Take");
                    }

                    if (TakeLast)
                    {
                        var takeLast =
                            args.IndexOf(
                                args.FirstOrDefault(
                                    a =>
                                        a.Equals("-takelast", StringComparison.OrdinalIgnoreCase)
                                )
                                ?? ""
                            );
                        args.RemoveAt(takeLast);

                        f.Add("WhereTakeLast");
                        f.Add("TakeLast");
                    }

                    f.Add("Where");

                    var where = args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? ""
                    );
                    args.RemoveAt(where);
                    break;
                }
            case (false, true, true, _):
                {
                    if (Take)
                    {
                        var take = args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? ""
                        );
                        args.RemoveAt(take);

                        f.Add("SelectTake");
                        f.Add("Take");
                    }

                    if (TakeLast)
                    {
                        var takeLastArg = args.FirstOrDefault(
                            a =>
                                a.Equals("-takelast", StringComparison.InvariantCultureIgnoreCase)
                        );
                        var takeLast = args.IndexOf(takeLastArg ?? "");
                        args.RemoveAt(takeLast);

                        f.Add("SelectTakeLast");
                        f.Add("TakeLast");
                    }

                    f.Add("Select");

                    var select =
                        args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? ""
                        );
                    args.RemoveAt(select);
                    break;
                }
            case (false, false, true, _):
                {
                    if (Take)
                    {
                        var take = args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? ""
                        );
                        args.RemoveAt(take);

                        f.Add("Take");
                    }

                    if (TakeLast)
                    {
                        var takeLast =
                            args.IndexOf(
                                args.FirstOrDefault(
                                    a =>
                                        a.Equals("-takelast", StringComparison.OrdinalIgnoreCase)
                                )
                                ?? ""
                            );
                        args.RemoveAt(takeLast);

                        f.Add("TakeLast");
                    }

                    break;
                }

            case (true, true, false, _):
                {
                    var where = args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? ""
                    );
                    args.RemoveAt(where);

                    var select =
                        args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? ""
                        );
                    args.RemoveAt(select);

                    f.Add("WhereSelect");
                    f.Add("Where");
                    f.Add("Select");

                    break;
                }

            case (true, false, false, _):
                {
                    var where = args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? ""
                    );
                    args.RemoveAt(where);

                    f.Add("Where");
                    break;
                }

            case (false, true, false, _):
                {
                    var select =
                        args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? ""
                        );
                    args.RemoveAt(select);

                    f.Add("Select");
                    break;
                }
        }

        switch (match)
        {
            case (_, _, _, true):
                {
                    if (FirstWhere)
                    {
                        var firstWhere =
                            args.IndexOf(
                                args.FirstOrDefault(
                                    a =>
                                        a.Equals("-firstwhere", StringComparison.OrdinalIgnoreCase)
                                )
                                ?? ""
                            );
                        args.RemoveAt(firstWhere);

                        f.Add("FirstWhere");
                    }

                    if (First)
                    {
                        var first = args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-first", StringComparison.OrdinalIgnoreCase)) ?? ""
                        );
                        args.RemoveAt(first);

                        f.Add("First");
                    }

                    if (LastWhere)
                    {
                        var lastWhere =
                            args.IndexOf(
                                args.FirstOrDefault(a => a.Equals("-lastwhere", StringComparison.OrdinalIgnoreCase)) ?? ""
                            );
                        args.RemoveAt(lastWhere);

                        f.Add("LastWhere");
                    }

                    if (Last)
                    {
                        var last = args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-last", StringComparison.OrdinalIgnoreCase)) ?? ""
                        );
                        args.RemoveAt(last);

                        f.Add("Last");
                    }

                    break;
                }
        }

        if (f.Count == 0)
        {
            return filters;
        }

        foreach (var fil in f)
        {
            filters.Add($".{fil}_");
        }

        return filters;
    }

}