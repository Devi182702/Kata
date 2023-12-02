using Kata.Models;

namespace Kata.Interfaces
{
    public interface IOrderService
    {
        Order CreateOrder(int itemId, int quantity);
        void UpdateOrder(Order existingOrder, int itemId, int quantity);
    }
}
