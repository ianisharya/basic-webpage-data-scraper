using NullLibrary;

using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Text;

namespace ScrapeLibrary;

public class Scrape
{

    public string ScrapeWebpage([NotNullWhen(true)] StringBuilder? url, [NotNullWhen(true)] StringBuilder? filepath)
    {
        NullChecks.IsFileExist(filepath);
        NullChecks.CheckUrl(url);

        string reply = this.getWebpage(url);

        File.WriteAllText(filepath.ToString(), reply);

        return reply;
    }

    private string getWebpage([NotNullWhen(true)] StringBuilder url)
    {
        NullChecks.CheckUrl(url);

        WebClient client = new();
        try
        {
            return client.DownloadString(url.ToString());
        } catch( Exception ex )
        {
            if (ex is System.Net.WebException) throw new System.Net.WebException("Unable to Fetch Data From URL!\n\n" + nameof(ex));
            throw;
        }

    }

}

