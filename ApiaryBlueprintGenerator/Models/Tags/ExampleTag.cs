using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiaryBlueprintGenerator.Models.Tags
{
    public class ExampleTag : BaseTag
    {
        public override string TagName { get { return "example"; } }
        public string InputExample { get; set; }
        public string OutputExample { get; set; }

        public override void Load(XElement xElement)
        {
            base.Load(xElement);

            foreach (var codeElement in xElement.Elements("code"))
            {
                XAttribute attr = codeElement.Attribute("type");
                if (attr != null)
                {
                    if (attr.Value == "input")
                    {
                        InputExample = codeElement.Value.Trim();
                    }
                    else if (attr.Value == "output")
                    {
                        OutputExample = codeElement.Value.Trim();
                    }
                }
            }
        }
    }
}
