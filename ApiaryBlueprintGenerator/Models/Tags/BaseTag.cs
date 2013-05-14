using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiaryBlueprintGenerator.Models.Tags
{
    public abstract class BaseTag : ITag
    {
        public abstract string TagName { get; }
        public string Text { get; set; }
        public Dictionary<string, string> Attributes { get; set; }

        protected BaseTag()
        {
            Attributes = new Dictionary<string, string>();
        }

        public virtual void Load(XElement xElement)
        {
            Text = xElement.Value.Trim();

            foreach (var xAttribute in xElement.Attributes())
            {
                Attributes[xAttribute.Name.ToString().ToLower()] = xAttribute.Value;
            }
        }
    }
}
