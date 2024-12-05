using Lab3.Abstractions;
using Lab3.Data;
using Lab3.Data.Entities;
using Lab3.Helpers;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Services;

public class GameService : IGameService
{
    private readonly GameDbContext _context;
    
    public GameService(GameDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<GameModel>> GetGamesAsync()
    {
        var games = await _context.Games.ToListAsync();
        return games.Select(game => game.ToGameModel());
    }
    
    public async Task<GameModel?> GetGameByIdAsync(int id)
    {
        var game = await _context.Games.FindAsync(id);
        return game?.ToGameModel();
    }
    
    public async Task<GameModel> CreateGameAsync(CreateGameRequest createGameRequest)
    {
        var game = new Game
        {
            Name = createGameRequest.Name
        };
        
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        
        return game.ToGameModel();
    }
    
    public async Task<GameModel?> UpdateGameAsync(UpdateGameRequest updateGameRequest)
    {
        var game = await _context.Games.FindAsync(updateGameRequest.Id);
        if (game == null)
        {
            return null;
        }
        
        game.Name = updateGameRequest.Name;
        await _context.SaveChangesAsync();
        
        return game.ToGameModel();
    }
    
    public async Task<bool> DeleteGameAsync(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null)
        {
            return false;
        }
        
        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
        
        return true;
    }
}