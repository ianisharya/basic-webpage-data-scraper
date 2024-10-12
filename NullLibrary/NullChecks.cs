using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace NullLibrary;

public static class NullChecks
{
    public static void IsDirectoryExist([NotNullWhen(true)] DirectoryInfo? path)
    {
        CheckNull(path);

        if (!Directory.Exists(path.ToString()))
        {
            throw new DirectoryNotFoundException("Invalid Directory Path!");
        }
    }

    public static void IsFileExist([NotNullWhen(true)] StringBuilder? path)
    {
        CheckNull(path);

        if (!File.Exists(path.ToString()))
        {
            throw new FileNotFoundException("Invalid File Path!");
        }
    }

    public static void CheckNull([NotNullWhen(true)] object? any)
    {
        _ = any ?? throw new ArgumentNullException(nameof(any));
    }

    public static void CheckUrl([NotNullWhen(true)] StringBuilder url)
    {
        CheckNull(url);

        string urlPattern = getUrlPattern();

        Regex reg = new(urlPattern);
        
        if (!reg.IsMatch(url.ToString())){
            throw new ArgumentException("Invalid URL!");
        }
    }

    //Utility functions

    internal static string getUrlPattern()
    {
        return @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
    }
}

