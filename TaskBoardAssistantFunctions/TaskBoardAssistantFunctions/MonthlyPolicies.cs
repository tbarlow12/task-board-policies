using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using TaskBoardAssistant;
using Microsoft.Extensions.Configuration;

namespace TaskBoardPolicies
{
    public static class MonthlyPolicies
    {
        /// <summary>
        /// </summary>
        /// <param name="myTimer"></param>
        /// <param name="log"></param>
        /// <param name="context"></param>
        [FunctionName("MonthlyPolicies")]
        public static void Run([TimerTrigger("0 15 0 1 * *")]TimerInfo myTimer, ILogger log, ExecutionContext context)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var result = Assistant.ExecuteFromGitHub("tbarlow12", "task-board-assistant-policies", "monthly.json");
            log.LogInformation($"C# Timer trigger function finished at: {DateTime.Now}");
        }
    }
}
