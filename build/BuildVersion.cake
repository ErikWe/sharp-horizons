public class BuildVersion
{
    public string Informational { get; }

    public string NuGet { get; }

    public string Milestone { get; }

    private BuildVersion(string informational, string nuget, string milestone)
    {
        Informational = informational;

        NuGet = nuget;

        Milestone = milestone;
    }

    public static BuildVersion ExtractVersion(ICakeContext context)
    {
        var gitVersionSettings = new GitVersionSettings
        {
            NoFetch = true,
            UpdateAssemblyInfo = true
        };

        var gitVersion = context.GitVersion(gitVersionSettings);

        return new(gitVersion.InformationalVersion, gitVersion.NuGetVersion, $"v{gitVersion.MajorMinorPatch}");
    }
}