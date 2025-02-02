using API.Data;
using API.Models;

namespace API.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly AppDbContext _context;

        public PlayersService(AppDbContext context)
        {
            _context = context;
        }
        public Players AddPlayers(Players player)
        {
            _context.Players.Add(player);
            _context.SaveChangesAsync();
            return player;
        }

        public bool DeleteAllPlayers()
        {
            var players = _context.Players.ToList();
            _context.Players.RemoveRange(players);
            return _context.SaveChanges() > 0;
        }

        public List<Players> GetPlayers()
        {
            var players = _context.Players.ToList();
            return players;
        }
    }
}
