using TowerDefender.Application.Services;
using TowerDefender.Game.ScriptableObjects;
using UnityEngine.Events;

namespace TowerDefender.Application.Interfaces
{
    public interface IMatchService : IGameService
    {
        MatchProfile DefaultMatchProfile { get; }
        MatchState MatchState { get; set; }
        bool IsGameOver { get; }
        int Timer { get; set; }

        UnityEvent OnMatchStateChanged { get; set; }
        UnityEvent OnTimerChanged { get; set; }
    }
}