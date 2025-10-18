using System.Runtime.InteropServices;

namespace NAPS2.App.Tests.Targets;

public class WindowsAppTestTarget : IAppTestTarget
{
    private static readonly string PlatformArch =
        RuntimeInformation.ProcessArchitecture == Architecture.Arm64 ? "win-arm64" : "win-x64";

    public AppTestExe Console => GetAppTestExe("NAPS2.App.Console", "NAPS2.Console.exe", PlatformArch);
    public AppTestExe Gui => GetAppTestExe("NAPS2.App.WinForms", "NAPS2.exe", PlatformArch);
    public AppTestExe Worker => GetAppTestExe("NAPS2.App.Worker", "NAPS2.Worker.exe", "win-x86", null, "lib");
    public AppTestExe Server => GetAppTestExe("NAPS2.App.WinForms", "NAPS2.exe", PlatformArch, "server");
    public bool IsWindows => true;

    private AppTestExe GetAppTestExe(string project, string exeName, string arch, string argPrefix = null,
        string testRootSubPath = null)
    {
        return new AppTestExe(
            Path.Combine(AppTestHelper.SolutionRoot, project, "bin", "Debug", "net10.0-windows", arch),
            exeName,
            argPrefix,
            testRootSubPath);
    }

    public override string ToString() => "Windows";
}