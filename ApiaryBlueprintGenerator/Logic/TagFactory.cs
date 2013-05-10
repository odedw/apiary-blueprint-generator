using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ApiaryBlueprintGenerator.Models.Tags;

namespace ApiaryBlueprintGenerator
{
    public class TagFactory
    {
        private Dictionary<string, Type> mTags;

        public TagFactory()
        {
            mTags = new Dictionary<string, Type>();

            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterface(typeof(ITag).ToString()) != null)
                {
                    var tag = Activator.CreateInstance(type) as ITag;
                    mTags.Add(tag.TagName.ToLower(), type);
                }
            }
        }

        public ITag CreateTag(XElement xElement)
        {
            string tagName = xElement.Name.ToString().ToLower();
            if (mTags.ContainsKey(tagName))
            {
                var tag = Activator.CreateInstance(mTags[tagName]) as ITag;
                tag.Load(xElement);
                return tag;
            }
            return null;
        }
    }
}
