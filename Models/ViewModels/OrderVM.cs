namespace App_Dev_1670.Models.ViewModels
{
    public class OrderVM
    {
        public Order Order { get; set; }
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
