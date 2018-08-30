using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalc.Domain
{
    public class Inventory
    {
        private List<Product> _inventory = new List<Product>();

        public Inventory()
        {
            _inventory.Add(new Product { Id = 1, Name = "Butter", Price = 0.8M });
            _inventory.Add(new Product { Id = 2, Name = "Milk", Price = 1.15M });
            _inventory.Add(new Product { Id = 3, Name = "Bread", Price = 1M });
        }

        public Product Search(string name)
        {
            try
            {
                return _inventory.Single(_ => _.Name == name);
            }
            catch(Exception ex)
            {
                throw new Exception($"No product found with name {name}", ex);
            }
        }
    }
}
