using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ApiaryBlueprintGenerator.Models;
using ApiaryBlueprintGenerator.Models.Tags;

namespace ApiaryBlueprintGenerator
{
    public class Parser
    {
        private readonly string mInputFile;
        private readonly string mNamespacePrefix;
        private readonly string mHost;
        private readonly string mTitle;
        private readonly string mDescription;
        private readonly TagFactory mTagFactory = new TagFactory();

        public Parser(string inputFile, string title, string host, string description, string namespacePrefix)
        {
            mInputFile = inputFile;
            mNamespacePrefix = namespacePrefix;
            mHost = host;
            mTitle = title;
            mDescription = description;
        }

        public DocumentationModel Parse()
        {
            try
            {
                //Load and get assembly name
                var model = new DocumentationModel { Host = mHost, Title = mTitle, Description = mDescription };
                XDocument xDocument = XDocument.Load(mInputFile);
                model.AssemblyName = xDocument.Root.Element("assembly").Element("name").Value;

                //filter all namespaces that don't start with NamespacePrefix
                var elements = xDocument.Root.Element("members").Elements("member").Where(element => //starts with the desired namespace
                    element.Attribute("name").Value.Substring(2).StartsWith(mNamespacePrefix));

                //get methods and types
                var types = elements.Where(element => element.Attribute("name").Value.Substring(0, 1) == "T");
                var methods = elements.Where(element => element.Attribute("name").Value.Substring(0, 1) == "M");

                //Parse types into sections
                foreach (XElement type in types)
                {
                    var section = new SectionModel()
                                      {
                                          SectionName = type.Attribute("name").Value.Substring(2)
                                      };
                    foreach (XElement tagElement in type.Elements())
                    {
                        var tag = mTagFactory.CreateTag(tagElement);
                        if (tag != null)
                        {
                            section.SectionTags.Add(tag);
                        }
                    }
                    model.Sections.Add(section);
                }

                //parse each method and add to relevant section
                foreach (XElement method in methods)
                {
                    var section =
                        model.Sections.FirstOrDefault(
                            sectionModel =>
                            method.Attribute("name").Value.Substring(2).StartsWith(sectionModel.SectionName));

                    if (section != null)
                    {
                        var resource = new ResourceModel();
                        foreach (var tagElement in method.Elements())
                        {
                            var tag = mTagFactory.CreateTag(tagElement);
                            if (tag != null)
                            {
                                resource.Tags.Add(tag);
                            }
                        }
                        section.Resources.Add(resource);
                    }
                }

                return model;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Parser failed: {0}", ex);
                return null;
            }
        }
    }
}
