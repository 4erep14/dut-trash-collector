using Lab3.Abstractions;
using Lab3.Data.Entities;
using Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers;

[Route("api/game")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;
    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetGames()
    {
        var games = await _gameService.GetGamesAsync();
        return Ok(games);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGame(int id)
    {
        var game = await _gameService.GetGameByIdAsync(id);
        if (game == null)
        {
            return NotFound();
        }
        return Ok(game);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateGame([FromBody] CreateGameRequest createGameRequest)
    {
        var game = await _gameService.CreateGameAsync(createGameRequest);
        return Ok(game);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGame([FromBody] UpdateGameRequest updateGameRequest)
    {
        var game = await _gameService.UpdateGameAsync(updateGameRequest);
        if (game == null)
        {
            return NotFound();
        }
        return Ok(game);
    }
        
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteGame(int id)
    {
        var result = await _gameService.DeleteGameAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}