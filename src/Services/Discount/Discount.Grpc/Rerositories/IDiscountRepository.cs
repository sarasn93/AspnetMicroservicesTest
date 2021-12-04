using Discount.Grpc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Rerositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string prodoctName);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string prodoctName);
    }
}
