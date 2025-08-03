// |====================================================|
// |Copyright©                                          |
// |Nestly API - Home Finder                            |
// |Modern API to discover homes for rent  or purchase  |
// |                                                    | 
// |----------------------------------------------------|
// |                                                    | 
// |All rights reserved, including the right to         |
// |reproduce this work in any form. For permission     |
// |requests, contact [Your Contact Information]        |
// |====================================================|

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV3s;

var githubPipeline = new GithubPipeline
{
    Name = "Nestly Build Pipeline",

    OnEvents = new Events
    {
        PullRequest = new PullRequestEvent
        {
            Branches = new[] { "main" },
        },

        Push = new PushEvent
        {
            Branches = new[] { "main" },
        }
    },

    Jobs = new Dictionary<string, Job>
    {
        ["build"] = new Job
        {
            RunsOn = BuildMachines.Windows2022,

            Steps = new List<GithubTask>
            {
                new CheckoutTaskV4
                {
                    Name = "Checking Out Code"
                },

                new SetupDotNetTaskV3
                {
                    Name = "Setting Up .NET SDK",
                    With = new TargetDotNetVersionV3
                    {
                        DotNetVersion = "8.0.412"
                    }
                },

                new RestoreTask
                {
                    Name = "Restoring NuGet Packages"
                },

                new DotNetBuildTask
                {
                    Name = "Building the Project"
                },

                new TestTask
                {
                    Name = "Running Unit Tests"
                }
            }
        }
    }
};

var client = new ADotNetClient();

client.SerializeAndWriteToFile(adoPipeline: githubPipeline,
    path: "../../../../.github/workflows/dotnet.yml");

Console.WriteLine("GitHub Actions pipeline for Nestly API has been created successfully.");