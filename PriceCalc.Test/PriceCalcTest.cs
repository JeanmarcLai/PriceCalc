using Xbehave;

namespace PriceCalc.Test
{
    public class PriceCalcTest
    {
        [Scenario]
        public void NoOffers()
        {
            "Given the basket has 1 bread, 1 butter and 1 milk".x(() => {});
            "When I total the basket".x(() => {});
            "Then the total should be £2.95".x(() => {});
        }

        [Scenario]
        public void BreadOffer()
        {
            "Given the basket has 2 butter and 2 bread".x(() => { });
            "When I total the basket".x(() => { });
            "Then the total should be £3.10".x(() => { });
        }

        [Scenario]
        public void MilkOffer()
        {
            "Given the basket has 4 milk".x(() => { });
            "When I total the basket".x(() => { });
            "Then the total should be £3.45".x(() => { });
        }

        [Scenario]
        public void BreadAndMilkOffer()
        {
            "Given the basket has 2 butter, 1 bread and 8 milk".x(() => { });
            "When I total the basket".x(() => { });
            "Then the total should be £9.00".x(() => { });
        }
    }
}
