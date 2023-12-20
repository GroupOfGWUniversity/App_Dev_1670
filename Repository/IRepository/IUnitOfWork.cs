using App_Dev_1670.Repository.IRepository;

namespace App_Dev_1670.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategory Category { get; }
        ICart Cart { get; }
        IApplicationUser ApplicationUser { get; }
        IBook Book { get; }
        IRequest Request { get; }
        //IOrderDetai OrderDetai { get; set; }
        //IOrderHeader OrderHeader { get; set; }
        //IOrder Order { get; }
        //IOrderDetails OrderDetails { get; }
        //ICompanyRepository Company { get; }
        //IShoppingCartRepository ShoppingCart { get; }
        //IApplicationUserRepository ApplicationUser { get; }
        //IOrderDetailRepository OrderDetail { get; }
        //IOrderHeaderRepository OrderHeader { get; }
        //IProductImageRepository ProductImage { get; }

        void Save();
    }
}