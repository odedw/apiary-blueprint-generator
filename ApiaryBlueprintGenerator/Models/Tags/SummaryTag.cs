using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiaryBlueprintGenerator.Models.Tags
{
    public class SummaryTag : ITag
    {
        public string TagName { get { return "summary"; } }
        public string Text { get; set; }

        public void Load(XElement xElement)
        {
            Text = xElement.Value.Trim();
        }
    }
}
