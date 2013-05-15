using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiaryBlueprintGenerator.Models.Tags
{
    public class HeadersTag : BaseTag
    {
        public override string TagName { get { return "headers"; } }
        public Dictionary<string, string> Request { get; set; }
        public Dictionary<string, string> Response { get; set; }

        public override void Load(System.Xml.Linq.XElement xElement)
        {
            base.Load(xElement);

            Request = new Dictionary<string, string>();
            Response = new Dictionary<string, string>();
            foreach (var element in xElement.Elements("request"))
            {
                Request[element.Attribute("name").Value] = element.Value;
            }

            foreach (var element in xElement.Elements("response"))
            {
                Response[element.Attribute("name").Value] = element.Value;
            }
        }
    }
}
