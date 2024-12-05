using Lab3.Models;

namespace Lab3.Abstractions;

public interface IGameService
{
    Task<IEnumerable<GameModel>> GetGamesAsync();
    Task<GameModel?> GetGameByIdAsync(int id);
    Task<GameModel> CreateGameAsync(CreateGameRequest createGameRequest);
    Task<GameModel?> UpdateGameAsync(UpdateGameRequest updateGameRequest);
    Task<bool> DeleteGameAsync(int id);
}