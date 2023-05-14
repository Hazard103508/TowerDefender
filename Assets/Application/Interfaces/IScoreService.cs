using UnityEngine;
using UnityEngine.Events;

namespace TowerDefender.Application.Interfaces
{
    public interface IScoreService : IGameService
    {
        UnityEvent OnScoreChanged { get; set; }
        void Add(int points);
    }
}