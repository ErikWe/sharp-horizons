public class PublishData
{
    public string NuGetSource { get; } = "https://api.nuget.org/v3/index.json";
    public string GitHubPackagesSource { get; } = "https://nuget.pkg.github.com/ErikWe/index.json";

    public bool ShouldPublish { get; }

    public string NuGetKey { get; }
    public string GitHubKey { get; }

    private PublishData(bool shouldPublish, string nugetKey, string githubKey)
    {
        ShouldPublish = shouldPublish;

        NuGetKey = nugetKey;
        GitHubKey = githubKey;
    }

    public static PublishData ExtractPublishData(ICakeContext context)
    {
        var buildSystem = context.BuildSystem();

        var isRunningOnGitHubActions = buildSystem.GitHubActions.IsRunningOnGitHubActions;
        var isNotPullRequest = buildSystem.GitHubActions.Environment.PullRequest.IsPullRequest is false;

        var isCorrectRepository = StringComparer.OrdinalIgnoreCase.Equals("ErikWe/SharpHorizons", buildSystem.GitHubActions.Environment.Workflow.Repository);
        var isMainBranch = isCorrectRepository && StringComparer.OrdinalIgnoreCase.Equals("main", buildSystem.GitHubActions.Environment.Workflow.BaseRef);

        var shouldPublish = isRunningOnGitHubActions && isNotPullRequest && isMainBranch;

        var nugetKey = context.EnvironmentVariable("NUGET_API_KEY");
        var githubKey = context.EnvironmentVariable("GITHUB_TOKEN");

        if (string.IsNullOrEmpty(nugetKey))
        {
            throw new InvalidOperationException("Could not resolve NuGet API key.");
        }

        if (string.IsNullOrEmpty(githubKey))
        {
            throw new InvalidOperationException("Could not resolve GitHub token.");
        }

        return new(shouldPublish, nugetKey, githubKey);
    }
}