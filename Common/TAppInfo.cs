using System;
using System.IO;

namespace Common;

public static class TAppInfo
{
    public static string GetExeNameViaCommandLine()
    {
        var args = Environment.GetCommandLineArgs();
        if (args.Length == 0 || String.IsNullOrEmpty(args[0]))
        {
            throw new Exception("ExeName should not be null");
        }
        else
        {
            return Path.GetFileName(args[0]);
        }
    }

}
