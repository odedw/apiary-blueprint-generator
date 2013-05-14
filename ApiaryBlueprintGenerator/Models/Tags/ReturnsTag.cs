using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiaryBlueprintGenerator.Models.Tags
{
    public class ReturnsTag : BaseTag
    {
        private const int DEFAULT_STATUS_CODE = 200;
        private const string DEFAULT_CONTENT_TYPE = "application/json";

        public override string TagName { get { return "returns"; } }
    }
}
