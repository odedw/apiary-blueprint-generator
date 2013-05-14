using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiaryBlueprintGenerator.Models.Tags;

namespace ApiaryBlueprintGenerator.Models
{
    public class DocumentationModel
    {
        public string AssemblyName { get; set; }
        public string Host { get; set; }
        public string Title { get; set; }
        public List<SectionModel> Sections { get; set; }

        public DocumentationModel()
        {
            Sections = new List<SectionModel>();
        }
    }

    public class SectionModel
    {
        public string SectionName { get; set; }
        public List<ITag> TypeTags { get; set; }
        public List<ResourceModel> Resources { get; set; }

        public SectionModel()
        {
            TypeTags = new List<ITag>();
            Resources = new List<ResourceModel>();
        }
    }

    public class ResourceModel
    {
        public List<ITag> Tags { get; set; }

        public ResourceModel()
        {
            Tags = new List<ITag>();
        }
    }
}
