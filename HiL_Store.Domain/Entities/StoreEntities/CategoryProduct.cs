using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HiL_Store.Domain.Entities.StoreEntities
{
    public class CategoryProduct : DomainObject
    {
        public int? CategoryID { get; set; }

        [ForeignKey(nameof(CategoryID))]
        public Category Category { get; set; }

        public int? ProductID { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }


        public override string ToString()
        {
            return "Name Product: " + Product.Name + "\nPrice: " + Product.Price;
        }
    }
}
