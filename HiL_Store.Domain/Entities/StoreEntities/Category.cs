using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.Domain.Entities.StoreEntities
{
    public class Category : DomainObject
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
