using System.Collections.Generic;

namespace PriceCalc.Domain
{
    public class Basket
    {
        private List<Product> _basket = new List<Product>();
        private OfferManager _offerManager;

        public Basket(OfferManager offerManager)
        {
            _offerManager = offerManager;
        }

        public void Add(Product product)
        {
            _basket.Add(product);
        }

        private void ApplyOffers()
        {
            var offers = new List<Offer>();
            _basket.RemoveAll(_ => _.GetType() == typeof(Offer));
            _offerManager.Offers.ForEach(_ => offers.Add(_.Invoke(_basket)));
            _basket.AddRange(offers);
        }

        public decimal Total()
        {
            ApplyOffers();
            decimal total = 0;
            _basket.ForEach(_ => total += _.Price);
            return total;
        }
    }
}
