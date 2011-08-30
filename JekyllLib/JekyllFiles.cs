using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using QiHe.Yaml.Grammar;
using Yaml;
using Mapping = QiHe.Yaml.Grammar.Mapping;

//using Yaml;

namespace JekyllLib
{
    public class JekyllFiles:IJekyllFiles
    {
        public string GenerateFileName()
        {
            throw new NotImplementedException();
        }

        public string GenerateFileOutput()
        {
            throw new NotImplementedException();
        }

        public string GenerateCategoryFiles()
        {
            throw new NotImplementedException();
        }

        public string GetFormattedYaml()
        {
            return string.Empty;

        }


        public string SetYaml(MetaBlog.PostInfo post, List<MappingEntry> sampleYaml)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the sample yaml.
        /// </summary>
        /// <returns></returns>
        public List<MappingEntry> GetSampleYaml()
        {
            //Node node = Node.FromFile("Sample.txt");
            //Console.WriteLine(node.Write());

            YamlParser parser = new YamlParser();
            TextInput input = new TextInput(File.ReadAllText("sample.txt"));
            bool success;
            YamlStream yamlStream = parser.ParseYamlStream(input, out success);
            if (success)
            {
                foreach (YamlDocument doc in yamlStream.Documents)
                {
                    Mapping mapping = doc.Root as Mapping;

                    return mapping.Enties;
                    

                    // access DataItem by doc.Root
                }
            }
            else
            {
                Console.WriteLine(parser.GetEorrorMessages());
            }

            return null;
        }
    }
}
