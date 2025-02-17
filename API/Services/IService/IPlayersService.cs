
using API.Models;

namespace API.Services
{
    public interface IPlayersService
    {
        public Players AddPlayers(Players player);
        public bool DeleteAllPlayers();
        public List<Players> GetPlayers();
        public List<Players> GetTopTenPlayers();
        public PlayersWithPagination CorrectAnswerdPlayer(int pageNumber,int pageSize, bool insider);
        public PlayersWithPagination InCorrectAnswerdPlayer(int pageNumber,int pageSize,bool insider);
        public int correctPlaersCount(bool insider);
        public int IncorrectPlaersCount(bool insider);

    }
}
