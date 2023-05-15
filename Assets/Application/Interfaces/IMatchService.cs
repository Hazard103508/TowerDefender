using TowerDefender.Game.ScriptableObjects;

namespace TowerDefender.Application.Interfaces
{
    public interface IMatchService : IGameService
    {
        MatchProfile DefaultMatchProfile { get; }
    }
}