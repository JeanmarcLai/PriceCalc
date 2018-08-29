using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalc.Domain
{
    public class OfferManager
    {        
        public List<Func<IEnumerable<Product>, Offer>> Offers { get; private set; }

        private void BreadOffer()
        {
            Offers.Add(
            (products) => {

                var bread = products.Where(_ => _.Id == 3);
                if (bread == null) return null;

                return new Offer
                {
                    Id = 4,
                    Name = "Buy 2 Butter and get a Bread at 50% off",
                    Price = -1 * bread.First().Price / 2M *
                    Math.Min(
                        products.Count(_ => _.Id == 1) / 2,
                        products.Count(_ => _.Id == 3)
                    )
                };
            });
        }

        private void MilkOffer()
        {
            Offers.Add(
            (products) =>
            {

                var milk = products.Where(_ => _.Id == 2);
                if (milk == null) return null;

                return new Offer
                {
                    Id = 4,
                    Name = "Buy 3 Milk and get the 4th milk for free",
                    Price = -1 * milk.First().Price * milk.Count() / 4
                };
            });
        }
    }
}
