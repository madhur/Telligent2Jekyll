using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MetaBlog;
using QiHe.Yaml.Grammar;
//using Yaml;
using Mapping = QiHe.Yaml.Grammar.Mapping;
using System.Reflection;

//using Yaml;

namespace JekyllLib
{
    public class JekyllFiles:IJekyllFiles
    {
        /// <summary>
        /// Generates the name of the file.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <returns></returns>
        public string GenerateFileName(PostInfo post)
        {
            DateTime postDate = post.dateCreated;
            string filename = string.Format("{0}-{1}-{2}-{3}", postDate.Year, postDate.Month, postDate.Day,
                                            post.title);
            filename = filename.Replace("\"", "-");
            filename = filename.Replace("/", "-");
            filename = filename.Replace(".", "-");
            filename = filename.Replace(":", "-");
            filename = filename + ".markdown";
            return filename;
        }

        /// <summary>
        /// Generates the file output.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="yaml">The yaml.</param>
        /// <param name="contentField">The content field.</param>
        /// <returns></returns>
        public string GenerateFileOutput(PostInfo post, string filename, List<MappingEntry> yaml, string contentField)
        {
            StringBuilder sb=new StringBuilder();
            sb.Append(CreateYamlStringFromObject(yaml));
            sb.Append(post.description);

            using (StreamWriter outfile=new StreamWriter(filename))
            {
                outfile.Write(sb.ToString());
            }

            return filename;
        }

        public string GenerateCategoryFiles()
        {
            throw new NotImplementedException();
        }

       


        /// <summary>
        /// Sets the yaml.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <param name="sampleYaml">The sample yaml.</param>
        /// <returns></returns>
        public List<MappingEntry> SetYaml(MetaBlog.PostInfo post, List<MappingEntry> sampleYaml)
        {
            FieldInfo[] fields = post.GetType().GetFields();

            foreach(FieldInfo fldInfo in fields)
            {
                string ignoredValues = System.Configuration.ConfigurationSettings.AppSettings["ignored"];
                string []ignoredArray=
                ignoredValues.Split(new char[]{';'});

                // Ignore the ignoredValues
                if(ignoredArray.Contains(fldInfo.Name))
                {
                    continue;
                }

                MappingEntry mappingEntry= sampleYaml.Find(
                    delegate(MappingEntry meEntry)
                        {

                            if (string.Compare(fldInfo.Name, meEntry.Key.ToString(), StringComparison.OrdinalIgnoreCase) == 0)
                                return true;

                            return CheckMapping(fldInfo.Name, meEntry.Key.ToString());

                           // return false;
                        }
                    );

                Sequence vals;
                if(mappingEntry!=null)
                {
                    sampleYaml.Remove(mappingEntry);
                    Scalar val = new Scalar {Text = GetValueFromPost(post, fldInfo, out vals)};
                    mappingEntry.Value = val;
                    sampleYaml.Add(mappingEntry);
                }
                else
                {
                    MappingEntry me=new MappingEntry();
                    Scalar key=new Scalar();
                    Scalar val=new Scalar();
                    
                    // Assign Key
                    me.Key = key;
                    key.Text = fldInfo.Name;
                  
                    // Get Value
                    val.Text=GetValueFromPost(post, fldInfo, out vals);
                    
                    
                    
                    // It was a multi valued assignment
                    if(vals!=null)
                    {
                        me.Value = vals;
                    }
                    else
                    {
                        // Don't add if there is no value
                        if (string.IsNullOrEmpty(val.Text))
                            continue;

                        me.Value = val;
                    }

                    sampleYaml.Add(me);
                }
                
            }

            return sampleYaml;
        }


        /// <summary>
        /// Gets the value from post.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <param name="fldInfo">The FLD info.</param>
        /// <returns></returns>
        private string GetValueFromPost(PostInfo post, FieldInfo fldInfo, out Sequence vals)
        {
            string value=string.Empty;
            vals = null;
            // vals will be null initially, 

              switch(fldInfo.FieldType.Name)
                    {
                        case "DateTime":
                            DateTime d=DateTime.Parse(fldInfo.GetValue(post).ToString());
                            value= d.ToString();
                            break;

                        case "String":
                            value = fldInfo.GetValue(post) as string;
                            break;

                      // vals will be updated in this case
                        case "String[]":
                            string []values = fldInfo.GetValue(post) as string[];
                            if(values==null)
                            {
                                return string.Empty;
                            }

                            vals=new Sequence();
                            
                            foreach(string val in values)
                            {
                                Scalar ss = new Scalar {Text = val};
                                vals.Enties.Add(ss);
                            }

                            break;

                    }
            
            return value;
        }


        /// <summary>
        /// Checks the mapping.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="yamlName">Name of the yaml.</param>
        /// <returns></returns>
        private bool CheckMapping(string fieldName, string yamlName)
        {
            string possibleYaml = System.Configuration.ConfigurationSettings.AppSettings[fieldName];

            if(!string.IsNullOrEmpty(possibleYaml))
            {
                string []possibleValues=possibleYaml.Split(new char[';'], StringSplitOptions.RemoveEmptyEntries);

                if (possibleValues.Contains(yamlName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the sample yaml.
        /// </summary>
        /// <returns></returns>
        public List<MappingEntry> GetSampleYaml()
        {

            YamlParser parser = new YamlParser();
            TextInput input = new TextInput(File.ReadAllText("sample.txt"));
            bool success;
            YamlStream yamlStream = parser.ParseYamlStream(input, out success);
            if (success)
            {
                    
                    Mapping mapping = yamlStream.Documents[0].Root as Mapping;

                    return mapping.Enties;
            }
            else
            {
                Console.WriteLine(parser.GetEorrorMessages());
            }

            return null;
        }


        /// <summary>
        /// Creates the yaml string from object.
        /// </summary>
        /// <param name="newYaml">The new yaml.</param>
        /// <returns></returns>
        private string CreateYamlStringFromObject(List<MappingEntry> newYaml )
        {
            StringBuilder sb=new StringBuilder();
            
            // Add YAML Header
            sb.Append("---");
            sb.Append(Environment.NewLine);

            foreach(MappingEntry me in newYaml)
            {
                
                if (me.Value is Scalar)
                {
                    sb.Append(string.Format("{0}: {1}", me.Key, me.Value));
                    sb.Append(Environment.NewLine);
                }
                else if (me.Value is Sequence)
                {
                    sb.Append(string.Format("{0}:", me.Key));
                    sb.Append(Environment.NewLine);

                    Sequence seq = me.Value as Sequence;
                    foreach(Scalar sc in seq.Enties)
                    {
                        sb.Append(string.Format("- {0}", sc.Text));
                        sb.Append(Environment.NewLine);
                    }
                }
           }

            // Add YAML Footer
            sb.Append("---");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
