using TowerDefender.Application.Interfaces;
using TowerDefender.Application.Services;
using UnityEditor;
using UnityEngine;

namespace TowerDefender.Application
{
    [InitializeOnLoad]
    public class Installer : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.Initiailze();
            ServiceLocator.Current.Register<IGameDataService>(new GameDataService());
            ServiceLocator.Current.Register<ICoinService>(new CoinService());
            ServiceLocator.Current.Register<IScoreService>(new ScoreService());

            AllServices.Load();

            AllServices.GameDataService.Coins = 10; // temporal
        }
    }
}