using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JekyllLib;
using MetaBlog;
using BlogManager.ObjectModel;
using QiHe.Yaml.Grammar;

namespace TelligentToJekyll
{
    class Program
    {
        static void Main(string[] args)
        {

            IBlogger proxy = MetaBlogAPIFactory.Create();
            PostInfo[] posts = proxy.getRecentPosts("mahuja", "mahuja@microsoft.com ", "Cricket567", 1000);

            IJekyllFiles jekyllFiles = new JekyllFiles();

            foreach (PostInfo post in posts)
            {
                List<MappingEntry> sampleYaml=jekyllFiles.GetSampleYaml();

                List<MappingEntry> newYaml = jekyllFiles.SetYaml(post, sampleYaml);

                string filename = jekyllFiles.GenerateFileName(post);

                jekyllFiles.GenerateFileOutput(post, filename, newYaml, "description");

                Console.WriteLine("{0} written successfully", filename);
            }

            Console.ReadLine();


        }
    }
}
