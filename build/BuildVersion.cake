public class BuildVersion
{
    public string SemanticVersion { get; }
    public string NuGet { get; }

    public string MajorMinorPatch { get; }

    private BuildVersion(string semanticVersion, string nuget, string majorMinorPatch)
    {
        SemanticVersion = semanticVersion;

        NuGet = nuget;

        MajorMinorPatch = majorMinorPatch;
    }

    public static BuildVersion ExtractVersion(ICakeContext context)
    {
        var gitVersionSettings = new GitVersionSettings
        {
            NoFetch = true,
            UpdateAssemblyInfo = true
        };

        var gitVersion = context.GitVersion(gitVersionSettings);

        return new(gitVersion.SemVer, gitVersion.NuGetVersionV2, gitVersion.MajorMinorPatch);
    }
}