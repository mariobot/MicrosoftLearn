using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Plugins.Core;

namespace MyApi.Services;

public class ChatServices(IConfiguration configuration)
{
    private readonly OpenAIPromptExecutionSettings executionSettings = new OpenAIPromptExecutionSettings()
    {
        ChatSystemPrompt = "You are a helpful assistant.",
        MaxTokens = 300,
        Temperature = 0.5,
        FunctionChoiceBehavior = FunctionChoiceBehavior.Auto(),
    }; 
    private Kernel CreateKernel()
    {
        var deploymentName = "gpt-4o";
        var endpointName = "";
        var apiKey = "";
        var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(deploymentName, endpointName, apiKey);

        builder.Plugins.AddFromType<TextPlugin>();
        builder.Plugins.AddFromType<TimePlugin>();
        builder.Plugins.AddFromType<ProcessPlugin>();

        var kernel = builder.Build();
        return kernel;
    }

    public async Task<string> Send(string prompt)
    {
        var kernel = CreateKernel();
        var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

        var result = await chatCompletionService.GetChatMessageContentAsync(prompt, executionSettings, kernel: kernel);
        
        return result.Content;
    }
}

public class ProcessPlugin
{
    [KernelFunction("execute_calc")]
    [Description("Execute the calculator")]
    public void OpenCalculator(string input)
    {
        ProcessStartInfo processStartInfo = new ProcessStartInfo()
        {
            FileName = "calc.exe",
            UseShellExecute = true,
        };

        Process.Start(processStartInfo);
    }

    [KernelFunction("get_eventlog_entries")]
    [Description("Get the registers from the event log system")]
    [return: Description("The last registers from the event log system")]
    public List<MyCustomEntry> GetEventLogEntries(string input)
    {
        var eventEntries = new List<MyCustomEntry>();
        try
        {
            string query = "*[System/Level <= 5]";

            var logQuery = new EventLogQuery("System", PathType.LogName, query)
            {
                ReverseDirection = true
            };

            EventLogReader logReader = new EventLogReader(logQuery);

            int count = 0;

            for (EventRecord eventRecord = logReader.ReadEvent(); eventRecord != null && count < 100; eventRecord = logReader.ReadEvent())
            { 
                var entry = new MyCustomEntry(eventRecord.TimeCreated, eventRecord.LevelDisplayName, eventRecord.FormatDescription());
                eventEntries.Add(entry);
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
        }

        return eventEntries;
    }
}


public record MyCustomEntry(DateTime? timeCreated, string Level, string Message);