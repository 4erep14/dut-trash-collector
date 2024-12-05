using Lab3.Data.Entities;
using Lab3.Models;

namespace Lab3.Helpers;

public static class GameMapperExtensions
{
    public static GameModel ToGameModel(this Game game)
    {
        return new GameModel
        {
            Id = game.Id,
            Name = game.Name
        };
    }
}