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
            var players = _context.Players.Where(e => e.Name == player.Name).FirstOrDefault();
            if (players != null)
                return null;
            _context.Players.Add(player);
            _context.SaveChangesAsync();
            return player;
        }

        public int correctPlaersCount()
        {
            var query = _context.Players.Where(p => p.isCorrect); // Filter players with IsCorrect = true

            return query.Count(); // Get total count before pagination
        }
        public PlayersWithPagination CorrectAnswerdPlayer(int pageNumber, int pageSize)
        {
            var count = _context.Players.Where(p => p.isCorrect).Count();
            var result = _context.Players
                .Where(p => p.isCorrect) // Filter by IsCorrect = true
                .OrderBy(p => p.DateTime) // Sort by oldest date first
                .Skip((pageNumber - 1) * pageSize) // Skip based on the page number
                .Take(pageSize) // Take only the requested number of records
                .ToList();


            return new PlayersWithPagination { players = result, total = count };
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

        public List<Players> GetTopTenPlayers()
        {
            return _context.Players
                .Where(p => p.isCorrect) // Filter players where IsCorrect is true
                .OrderBy(p => p.DateTime) // Order by DateTime (oldest first)
                .Take(10) // Get the top 10 results
                .ToList();
        }

        public PlayersWithPagination InCorrectAnswerdPlayer(int pageNumber, int pageSize)
        {
            var count = _context.Players.Where(p => p.isCorrect == false).Count();
            var result = _context.Players
                .Where(p => p.isCorrect == false) // Filter by IsCorrect = true
                .OrderBy(p => p.DateTime) // Sort by oldest date first
                .Skip((pageNumber - 1) * pageSize) // Skip based on the page number
                .Take(pageSize) // Take only the requested number of records
                .ToList();


            return new PlayersWithPagination { players = result, total = count };
        }

        public int IncorrectPlaersCount()
        {
            var query = _context.Players.Where(p => p.isCorrect == false); // Filter players with IsCorrect = true

            return query.Count(); // Get total count before pagination
        }
    }
}
