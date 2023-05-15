using TowerDefender.Application.Interfaces;
using UnityEngine.Events;

namespace TowerDefender.Application.Services
{
    public class LifeService : ILifeService
    {
        private int _hp;

        public LifeService()
        {
            _hp = 500; // TEMPORAL..
            OnHPChanged = new UnityEvent();
        }

        public int HP
        {
            get => _hp;
            private set
            {
                _hp = value;
                OnHPChanged.Invoke();
            }
        }

        public UnityEvent OnHPChanged { get; set; }


        public void Add(int amount) => this.HP += amount;
        public void Remove(int amount) => this.HP -= amount;
    }
}