using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiaryBlueprintGenerator.Models.Tags
{
    public class ReturnsTag : BaseTag
    {
        public const int DEFAULT_STATUS_CODE = 200;

        public override string TagName { get { return "returns"; } }

        public string StatusCode
        {
            get
            {
                return Attributes.ContainsKey("status-code") ? Attributes["status-code"] : DEFAULT_STATUS_CODE.ToString();
            }
        }
    }
}
