namespace ASP6.models
{
    public class Order
    {
        public int PepperoniCount { get; set; }
        public int HawaiianCount { get; set; }
        public int ChickenbbqCount { get; set; }
        public int MargheritaCount { get; set; }
        public double Price { get; set; }
        public Order() { }
        public Order(List<int> counts)
        {
            PepperoniCount = counts.ElementAt(0);
            HawaiianCount = counts.ElementAt(1);
            ChickenbbqCount = counts.ElementAt(2);
            MargheritaCount = counts.ElementAt(3);
            Price = 0;
        }
        public Order(List<int> counts, double price)
        {
            PepperoniCount = counts.ElementAt(0);
            HawaiianCount = counts.ElementAt(1);
            ChickenbbqCount = counts.ElementAt(2);
            MargheritaCount = counts.ElementAt(3);
            Price = price;
        }
    }
}
