using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetaBlog;
using QiHe.Yaml.Grammar;

namespace JekyllLib
{
    /// <summary>
    /// Interface for IJekyllFiles
    /// </summary>
    public interface IJekyllFiles
    {

        /// <summary>
        /// Generates the name of the file.
        /// </summary>
        /// <returns></returns>
        string GenerateFileName(PostInfo post);

        /// <summary>
        /// Generates the file output.
        /// </summary>
        /// <returns></returns>
        string GenerateFileOutput(PostInfo post, string filename, List<MappingEntry> yaml, string contentField);

        /// <summary>
        /// Generates the category files.
        /// </summary>
        /// <returns></returns>
        string GenerateCategoryFiles();

        /// <summary>
        /// Sets the yaml.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <param name="sampleYaml">The sample yaml.</param>
        /// <returns></returns>
        List<MappingEntry> SetYaml(MetaBlog.PostInfo post, List<MappingEntry> sampleYaml);

        /// <summary>
        /// Gets the sample yaml.
        /// </summary>
        /// <returns></returns>
        List<MappingEntry> GetSampleYaml();

       
    }
}
