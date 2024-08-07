using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, GetGlobalConfig());

static IConfig GetGlobalConfig()
{
    return DefaultConfig.Instance.AddJob(Job.Default
        .WithWarmupCount(1)
        .AsDefault());
}