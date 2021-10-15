using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Career : BaseEntity
    {
        public string Name {get; set;}
        public string NameAcronym {get; set;}
    }
}