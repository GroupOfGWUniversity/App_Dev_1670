using App_Dev_1670.Models;
using Microsoft.AspNetCore.Mvc;

namespace App_Dev_1670.Repository.IRepository
{
    public interface IOrder : IRepository<Order>
    {
        void Update(Order order);
        void UpdateStatus (int id, string status, string? paymentStatus= null);
        void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);
    }
}