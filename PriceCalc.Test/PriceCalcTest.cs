using Xunit;
using Xbehave;
using PriceCalc.Domain;

namespace PriceCalc.Test
{
    public class PriceCalcTest
    {
        OfferManager _offerManager;
        Basket _basket;
        Inventory _inventory;
        decimal _total = 0M;

        public PriceCalcTest()
        {
            _offerManager = new OfferManager();
            _basket = new Basket(_offerManager);
            _inventory = new Inventory();
        }

        [Scenario]
        public void NoOffers()
        {
            "Given the basket has 1 bread, 1 butter and 1 milk".x(() =>
            {
                _basket.Add(_inventory.Search("Bread"));
                _basket.Add(_inventory.Search("Butter"));
                _basket.Add(_inventory.Search("Milk"));

            });
            "When I total the basket".x(() => {
                _total = _basket.Total();
            });
            "Then the total should be £2.95".x(() => {
               Assert.Equal(2.95M, _total);
            });
        }

        [Scenario]
        public void BreadOffer()
        {
            "Given the basket has 2 butter and 2 bread".x(() =>
            {
                _basket.Add(_inventory.Search("Butter"));
                _basket.Add(_inventory.Search("Butter"));
                _basket.Add(_inventory.Search("Bread"));
                _basket.Add(_inventory.Search("Bread"));
            });
            "When I total the basket".x(() => 
            {
                _total = _basket.Total();
            });
            "Then the total should be £3.10".x(() =>
            {
                Assert.Equal(3.1M, _total);
            });
        }

        [Scenario]
        public void MilkOffer()
        {
            "Given the basket has 4 milk".x(() =>
            {
                _basket.Add(_inventory.Search("Milk"));
                _basket.Add(_inventory.Search("Milk"));
                _basket.Add(_inventory.Search("Milk"));
                _basket.Add(_inventory.Search("Milk"));
            });
            "When I total the basket".x(() => 
            {
                _total = _basket.Total();
            });
            "Then the total should be £3.45".x(() => 
            {
                Assert.Equal(3.45M, _total);
            });
        }

        [Scenario]
        public void BreadAndMilkOffer()
        {
            "Given the basket has 2 butter, 1 bread and 8 milk".x(() => 
            {
                _basket.Add(_inventory.Search("Butter"));
                _basket.Add(_inventory.Search("Butter"));
                _basket.Add(_inventory.Search("Bread"));
                _basket.Add(_inventory.Search("Milk"));
                _basket.Add(_inventory.Search("Milk"));
                _basket.Add(_inventory.Search("Milk"));
                _basket.Add(_inventory.Search("Milk"));
                _basket.Add(_inventory.Search("Milk"));
                _basket.Add(_inventory.Search("Milk"));
                _basket.Add(_inventory.Search("Milk"));
                _basket.Add(_inventory.Search("Milk"));
            });
            "When I total the basket".x(() => 
            {
                _total = _basket.Total();
            });
            "Then the total should be £9.00".x(() => 
            {
                Assert.Equal(9M, _total);
            });
        }
    }
}
