using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiaryBlueprintGenerator.Models.Tags
{
    public interface ITag
    {
        //Properties
        string TagName { get; }

        //Methods
        void Load(XElement xElement);
    }
}
