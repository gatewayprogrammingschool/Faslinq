global using TestValueTuple = System.ValueTuple<int, string, double>;

global using System;
global using System.Collections.Generic;
global using System.Collections.Immutable;
global using System.Diagnostics;
global using System.Globalization;
global using System.Linq;
global using System.Text;
global using System.Threading;
global using System.Threading.Tasks;
//global using System.Threading.Tasks.Dataflow;
global using System.Security.Cryptography;

global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.VisualStudio.TestTools.UnitTesting;

global using Faslinq;

global using FluentAssertions;

global using GPS.RandomDataGenerator;
global using GPS.RandomDataGenerator.Generators;


global using BenchmarkDotNet.Attributes;
global using BenchmarkDotNet.Jobs;
global using BenchmarkDotNet.Running;

global using BenchmarkDotNet.Analysers;
global using BenchmarkDotNet.Columns;
global using BenchmarkDotNet.Configs;
global using BenchmarkDotNet.Exporters.Csv;
global using BenchmarkDotNet.Exporters;
global using BenchmarkDotNet.Filters;
global using BenchmarkDotNet.Loggers;
global using BenchmarkDotNet.Environments;
global using BenchmarkDotNet.Validators;
global using BenchmarkDotNet.Order;
global using BenchmarkDotNet.Reports;

global using Perfolizer.Horology;
