using System;
using System.IO;

namespace AOTSampleUnpackaged;

public static class TAppInfo
{
    public static string GetExeNameViaCommandLine()
    {
        var args = Environment.GetCommandLineArgs();
        if (args.Length == 0 || String.IsNullOrEmpty(args[0]))
            return null;
        return Path.GetFileName(args[0]);
    }

}
