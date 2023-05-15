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
            ServiceLocator.Current.Register<ICoinService>(new CoinService());
            AllServices.Load();
        }
    }
}