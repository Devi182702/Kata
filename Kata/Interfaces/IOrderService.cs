using Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kata.Interfaces
{
    public interface IOrderService
    {
        Order CreateOrder(int itemId, int quantity);
        void UpdateOrder(Order existingOrder, int itemId, int quantity);
    }
}
