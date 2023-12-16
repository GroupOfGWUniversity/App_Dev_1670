namespace App_Dev_1670.Models.ViewModels
{
    public class CartVM
    {
        public IEnumerable<Cart> ListCart { get; set; }
        public double OrderTotal { get; set; }

    }
}
