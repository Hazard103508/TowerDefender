using UnityEngine.Events;

namespace TowerDefender.Application.Interfaces
{
    public interface ICoinService : IGameService
    {
        UnityEvent OnCoinsChanged { get; set; }
        void Add(int amount);
        void Remove(int amount);
    }
}