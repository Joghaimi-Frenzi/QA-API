using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersService _playersService;
        public PlayersController(IPlayersService playersService)
        {
            _playersService = playersService;
        }
        [HttpGet]
        public IActionResult GetPlayers()
        {
            var result = _playersService.GetPlayers();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddPlayer(Players player)
        {
            var result = _playersService.AddPlayers(player);
            return Ok(player);
        }
       
        [HttpDelete]
        public IActionResult DeletePlayer()
        {
            return Ok("Player deleted");
        }
    }
}
