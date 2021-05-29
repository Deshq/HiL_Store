using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.Domain.Entities.StoreEntities
{
    public class Product : DomainObject
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public override string ToString()
        {
            return "Name Product: " + Name + "\nPrice: " + Price;
        }
    }
}
