using TowerDefender.Application.Interfaces;
using TowerDefender.Application.Services;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefender.Game.UI
{
    public class UICoin : MonoBehaviour
    {
        [SerializeField] private Text _label;

        private void Start()
        {
            OnCoinsChanged();
        }
        private void OnEnable() => AllServices.CoinService.OnCoinsChanged.AddListener(OnCoinsChanged);
        private void OnDisable() => AllServices.CoinService.OnCoinsChanged.RemoveListener(OnCoinsChanged);
        private void OnCoinsChanged() => _label.text = AllServices.GameDataService.Coins.ToString();
    }
}