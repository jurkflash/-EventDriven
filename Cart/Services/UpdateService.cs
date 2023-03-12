using Cart.Domain;
using Cart.Services.Interfaces;
using System.Text.Json;

namespace Cart.Services
{
    public class UpdateService : IUpdateService
    {
        public async Task UpdateAsync(CartDetail cartDetail)
        {
            await Task.Run(() => Console.WriteLine("Cart received: " + JsonSerializer.Serialize(cartDetail).ToString()));

        }
    }
}
