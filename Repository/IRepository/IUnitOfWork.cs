namespace App_Dev_1670.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategory Category { get; }
        IBook Book { get; }
<<<<<<< HEAD
        ISeller Seller { get; }
=======
>>>>>>> a8f2e274b68d90f2bfb690a815c8ca6508ac7621

        //ICompanyRepository Company { get; }
        //IShoppingCartRepository ShoppingCart { get; }
        //IApplicationUserRepository ApplicationUser { get; }
        //IOrderDetailRepository OrderDetail { get; }
        //IOrderHeaderRepository OrderHeader { get; }
        //IProductImageRepository ProductImage { get; }

        void Save();
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> a8f2e274b68d90f2bfb690a815c8ca6508ac7621
