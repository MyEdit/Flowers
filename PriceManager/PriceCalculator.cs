namespace PriceManager
{
    public class PriceCalculator
    {
        static public double getPriceWithDiscount(double price, double discount)
        {
            return price - (price * discount);
        }
    }
}
