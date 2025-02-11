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
        [HttpGet("CorrectAnswerdCount")]
        public IActionResult CorrectAnswerdCount()
        {
            var result = _playersService.correctPlaersCount();
            return Ok(result);
        }
        [HttpGet("InCorrectAnswerdCount")]
        public IActionResult InCorrectAnswerdCount()
        {
            var result = _playersService.IncorrectPlaersCount();
            return Ok(result);
        }
        [HttpGet("CorrectAnswerdPlayer")]
        public IActionResult CorrectAnswerdPlayer([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = _playersService.CorrectAnswerdPlayer(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet("InCorrectAnswerdPlayer")]
        public IActionResult InCorrectAnswerdPlayer([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = _playersService.InCorrectAnswerdPlayer(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddPlayer(Players player)
        {
            var result = _playersService.AddPlayers(player);
            if (result == null)
                return Unauthorized();
            return Ok(player);
        }
        [HttpGet("TopTen")]
        public IActionResult GetTopTenPlayer()
        {
            var result = _playersService.GetTopTenPlayers();
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeletePlayer()
        {
            _playersService.DeleteAllPlayers();
            return Ok("Player deleted");
        }
    }
}
