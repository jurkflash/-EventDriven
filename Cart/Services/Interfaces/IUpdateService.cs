using Cart.Domain;

namespace Cart.Services.Interfaces
{
    public interface IUpdateService
    {
        Task UpdateAsync(CartDetail cartDetail);
    }
}