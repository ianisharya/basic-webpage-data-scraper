using ScrapeLibrary;
using DirectoryLibrary;

using System;
using System.Text;
//using System.Reflection; // used to find the location of the assembly

namespace ScrapeClient;

class Program
{
    static void Main(string[] args)
    {
        Scrape scrape = new();
        DirectoryMethods dir = new();

        DirectoryInfo projectDirectory = dir.CurrentDirectory();

        // get the project folder
        for (int i = 1; i <= 3; ++i)
        {
            projectDirectory = dir.GetParentDirectory(projectDirectory);
        }
        
        StringBuilder dataDirPath = new StringBuilder(projectDirectory.ToString()).Append(new StringBuilder("/data"));


        dir.CreateDirectoryIfNotExists(new DirectoryInfo(dataDirPath.ToString()));

        StringBuilder filepath = dataDirPath.Append("/reply.html");
        StringBuilder url = new StringBuilder("https://www.google.com/search?q=deepmind");

        scrape.ScrapeWebpage(url, filepath);

        // open the scraped file
        dir.OpenWebPage(filepath);

    }

    

}