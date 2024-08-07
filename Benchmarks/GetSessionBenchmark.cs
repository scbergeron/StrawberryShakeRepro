using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShakeRepro.GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

public class GetSessionBenchmark
{
    private ServiceProvider _services;

    [GlobalSetup]
    public void Setup()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddConferenceClient()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://workshop.chillicream.com/graphql"));

        _services = serviceCollection.BuildServiceProvider();
    }

    [Benchmark]
    public async Task Get()
    {
        IConferenceClient client = _services.GetRequiredService<IConferenceClient>();
        var result = await client.GetSessions.ExecuteAsync();
    }
}

