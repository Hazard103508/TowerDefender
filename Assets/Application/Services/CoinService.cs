using System.IO.Compression;
using TowerDefender.Application.Interfaces;
using UnityEngine.Events;

namespace TowerDefender.Application.Services
{
    public class CoinService : ICoinService
    {
        private int _coins;

        public CoinService()
        {
            _coins = 30; // TEMPORAL..
            OnCoinsChanged = new UnityEvent();
        }

        public int Coins
        {
            get => _coins;
            private set
            {
                _coins = value;
                OnCoinsChanged.Invoke();
            }
        }

        public UnityEvent OnCoinsChanged { get; set; }

        public void Add(int amount) => this.Coins += amount;
        public void Remove(int amount) => this.Coins -= amount;
    }
}