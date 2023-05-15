using UnityEngine.Events;

namespace TowerDefender.Application.Interfaces
{
    public interface ILifeService : IGameService
    {
        int HP { get; }
        UnityEvent OnHPChanged { get; set; }
        void Add(int amount);
        void Remove(int amount);
    }
}