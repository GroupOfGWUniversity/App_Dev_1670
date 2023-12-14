<<<<<<< HEAD
﻿using App_Dev_1670.Data;
using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;

namespace App_Dev_1670.Repository
{
    public class SellerRepository : Repository<Seller>, ISeller

    {
        private ApplicationDatabase _db;
        public SellerRepository(ApplicationDatabase db) : base(db)
        {
            _db = db;
        }
        public void Update(Seller seller)
        {
            _db.Update(seller);
        }
    }
}
=======
﻿//using App_Dev_1670.Data;
//using App_Dev_1670.Models;
//using App_Dev_1670.Repository.IRepository;

//namespace App_Dev_1670.Repository
//{
//    public class SellerRepository : Repository<Seller>, ISeller

//    {
//        private ApplicationDatabase _db;
//        public SellerRepository(ApplicationDatabase db) : base(db)
//        {
//            _db = db;
//        }
//        public void Update(Seller seller)
//        {
//            _db.Update(seller);
//        }
//    }
//}
>>>>>>> a8f2e274b68d90f2bfb690a815c8ca6508ac7621
