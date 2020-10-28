namespace P03._ShoppingCart
{
    using P03._ShoppingCart_Before;
    using P03._ShoppingCart_Before.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Cart
    {
        private readonly List<OrderItem> items;

        private readonly List<IPriceCalculationStrategy> calculationStrategies;

        public Cart()
        {
            this.items = new List<OrderItem>();
            calculationStrategies = new List<IPriceCalculationStrategy>()
            {
                new SpecialCalculationStrategy(),
                new WeightCalculationStrategy(),
            };
        }

        public IEnumerable<OrderItem> Items
        {
            get 
            { 
                return new List<OrderItem>(this.items); 
            }
        }

        public string CustmerEmail { get; set; }

        public void Add(OrderItem orderItem)
        {
            this.items.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0m;

            foreach (var item in this.items)
            {
                foreach (var strategy in calculationStrategies)
                {
                    total += strategy.Calculate(item);
                }

                // more rules are coming!
            }

            return total; 
        }
    }
}
