#load "./BuildVersion.cake"
#load "./BuildPaths.cake"
#load "./PublishData.cake"

public class BuildParameters
{
    public string Target { get; }
    public string Configuration { get; }
    public string Framework { get; } = "net7.0";

    public string SolutionPath { get; } = "./";

    public BuildVersion Version { get; }
    public BuildPaths Paths { get; }

    public PublishData Publish { get; }

    public BuildParameters(ISetupContext context)
    {
        Target = context.TargetTask.Name;
        Configuration = context.Argument("configuration", "Release");

        Version = BuildVersion.ExtractVersion(context);
        Paths = BuildPaths.ExtractPaths(context);
        Publish = PublishData.ExtractPublishData(context);
    }
}