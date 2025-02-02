
using API.Models;

namespace API.Services
{
    public interface IPlayersService
    {
        public Players AddPlayers(Players player);
        public bool DeleteAllPlayers();
        public List<Players> GetPlayers();
    }
}
