using TowerDefender.Application.Services;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefender.Game.UI
{
    public class UICoin : MonoBehaviour
    {
        [SerializeField] private Text _label;

        private void Awake()
        {
            AllServices.CoinService.OnCoinsChanged.AddListener(OnCoinsChanged);
            AllServices.CoinService.Add(AllServices.MatchService.DefaultMatchProfile.Coins);
        }
        private void OnDestroy() => AllServices.CoinService.OnCoinsChanged.RemoveListener(OnCoinsChanged);

        private void OnCoinsChanged() => _label.text = AllServices.CoinService.Coins.ToString();
    }
}