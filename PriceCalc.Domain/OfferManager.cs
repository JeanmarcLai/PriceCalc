using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalc.Domain
{
    public class OfferManager
    {        
        public List<Func<IEnumerable<Product>, Offer>> Offers { get; private set; }

        public OfferManager()
        {
            Offers = new List<Func<IEnumerable<Product>, Offer>>();
            BreadOffer();
            MilkOffer();
        }

        private void BreadOffer()
        {
            Offers.Add(
            (products) => {

                var butters = products.Where(_ => _.Id == 1);
                var breads = products.Where(_ => _.Id == 3);
                if (butters == null || butters.Count() < 2) return null;
                if (breads == null || breads.Count() < 1) return null;

                return new Offer
                {
                    Id = 4,
                    Name = "Buy 2 Butter and get a Bread at 50% off",
                    Price = -1 * breads.First().Price / 2M *
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

                var milks = products.Where(_ => _.Id == 2);
                if (milks == null || milks.Count() < 4) return null;

                return new Offer
                {
                    Id = 4,
                    Name = "Buy 3 Milk and get the 4th milk for free",
                    Price = -1 * milks.First().Price * milks.Count() / 4
                };
            });
        }
    }
}
