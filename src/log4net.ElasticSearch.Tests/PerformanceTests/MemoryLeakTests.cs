using System;
using log4net.ElasticSearch.Tests.IntegrationTests;
using NBench;

namespace log4net.ElasticSearch.Tests.PerformanceTests
{
    public class MemoryLeakTests
    {
        [PerfBenchmark(
            Description = "Memory alocated by log4net.ElasticSearch is released even when ElasticSearch doesn't respond",
            NumberOfIterations = 3,
            RunMode = RunMode.Iterations,
            RunTimeMilliseconds = Int32.MaxValue,
            TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 1000*1000)]
        public void There_is_no_memory_leak_when_es_is_down()
        {
            var logger = LogManager.GetLogger(typeof(ElasticSearchAppenderTests));
            for (int i = 0; i < 10000; i++)
            {
                logger.Warn("warning");
            }
        }
    }
}
