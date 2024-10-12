using NullLibrary;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace DirectoryLibrary;

public class DirectoryMethods
{
    /*
        * It enables or disables the showing of the window shell or not. 
        * If true, a command-prompt-looking window comes up. 
        * If not, it runs w/o a window unless one is created by the process (winforms, wpf, etc)
    */

    public void OpenWebPage([NotNullWhen(true)] StringBuilder? filepath)
    {
        NullChecks.IsFileExist(filepath);

        Process.Start(new ProcessStartInfo(filepath.ToString()) { UseShellExecute = true });    
    }

    public DirectoryInfo GetParentDirectory([NotNullWhen(true)] DirectoryInfo? childDirectory)
    {
        NullChecks.IsDirectoryExist(childDirectory);

        DirectoryInfo parentDirectory;

        try
        {
            parentDirectory = Directory.GetParent(childDirectory.ToString());

            return parentDirectory;

        } catch (Exception ex)
        {
            if (ex is FileNotFoundException ||
                ex is DirectoryNotFoundException ||
                ex is ArgumentNullException ||
                ex is ArgumentException)
            {
                Environment.Exit(1);
            }
            throw;
        }
    }

    public DirectoryInfo CurrentDirectory()
    {
        try
        {
            return new DirectoryInfo(Environment.CurrentDirectory);
        }
        catch (Exception ex)
        {
            if (ex is FileNotFoundException ||
                ex is DirectoryNotFoundException ||
                ex is ArgumentNullException ||
                ex is ArgumentException)
            {
                Environment.Exit(1);
            }
            throw;
        }
    }

    // create the data directory if not exists
    public void CreateDirectoryIfNotExists([NotNullWhen(true)] DirectoryInfo directoryPath)
    {
        NullChecks.IsDirectoryExist(directoryPath);

        string directoryPathString = directoryPath.ToString();
        try
        {
            if (!Directory.Exists(directoryPathString)) Directory.CreateDirectory(directoryPathString);

        } catch (Exception)
            {
                throw;
            }
    }

    // fetches the latest location path of the Assembly installed in your system pc
    public StringBuilder FetchAssemblyPath([NotNullWhen(true)]string assemblyName)
    {
        NullChecks.CheckNull(assemblyName);

        Assembly assembly = Assembly.Load(assemblyName);

        return new StringBuilder(assembly.Location);
    }
    
}

