using TowerDefender.Application.Services;
using TowerDefender.Game.Environment;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TowerDefender.Game.UI
{
    [RequireComponent(typeof(Button))]
    public class UITurretButton : MonoBehaviour
    {
        [SerializeField] private TurretSpawner turretSpawner;
        [SerializeField] private Image _icon;
        [SerializeField] private Text _label;
        [SerializeField] private Button _button;
        private Turret _turret;

        private void Awake()
        {
            AllServices.CoinService.OnCoinsChanged.AddListener(OnCoinsChanged);
        }
        private void OnDestroy() => AllServices.CoinService.OnCoinsChanged.RemoveListener(OnCoinsChanged);
        public void Initialize(Turret turret)
        {
            _turret = turret;
            _icon.sprite = turret.TurretProfile.icon;
            _label.text = turret.TurretProfile.BuildCost.ToString();

            _button.onClick.AddListener(OnButtonClick);
        }
        private void OnButtonClick()
        {
            if (AllServices.MatchService.IsGameOver)
                return;

            turretSpawner.Show(_turret);
            EventSystem.current.SetSelectedGameObject(null);
        }
        private void OnCoinsChanged() => _button.interactable = AllServices.CoinService.Coins >= _turret.TurretProfile.BuildCost;
    }
}