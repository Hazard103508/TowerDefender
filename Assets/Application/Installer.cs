using TowerDefender.Application.Interfaces;
using TowerDefender.Application.Services;
using TowerDefender.Game.ScriptableObjects;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefender.Application
{
    [InitializeOnLoad]
    public class Installer : MonoBehaviour
    {
        [SerializeField] private MatchProfile matchProfile;

        private void Awake()
        {
            ServiceLocator.Initiailze();
            ServiceLocator.Current.Register<IMatchService>(new MatchService(matchProfile));
            ServiceLocator.Current.Register<ICoinService>(new CoinService());
            AllServices.Load();

            SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
        }
    }
}