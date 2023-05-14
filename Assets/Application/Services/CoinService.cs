using TowerDefender.Application.Interfaces;
using TowerDefender.Application.Services;
using UnityEngine.Events;

namespace TowerDefender.Application.Services
{
    public class CoinService : ICoinService
    {
        public CoinService()
        {
            OnCoinsChanged = new UnityEvent();
        }

        public UnityEvent OnCoinsChanged { get; set; }

        public void Add()
        {
            AllServices.GameDataService.Coins++;
            OnCoinsChanged.Invoke();
        }
    }
}