using IMS.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities
{
    public class Area : BaseEntity
    {
        public string AreaCode { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public bool IsActive { get; set; }

        public Area() { }

        public Area(string areaCode, string name)
        {
            AreaCode = areaCode;
            Name = name;
            IsActive = true;
        }


    }
}
