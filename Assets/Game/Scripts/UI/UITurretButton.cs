using TowerDefender.Application.Services;
using TowerDefender.Game.Environment;
using TowerDefender.Game.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

namespace TowerDefender.Game.UI
{
    [RequireComponent(typeof(Button))]
    public class UITurretButton : MonoBehaviour
    {
        [SerializeField] private TurretSpawner turretSpawner;
        [SerializeField] private Image _icon;
        [SerializeField] private Text _label;
        private Button _button;
        private Turret _turret;

        private void Awake()
        {
            _button = GetComponent<Button>();
            
        }
        private void Start() => AllServices.CoinService.OnCoinsChanged.AddListener(OnCoinsChanged);
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
            turretSpawner.Show(_turret);
            EventSystem.current.SetSelectedGameObject(null);
        }
        private void OnCoinsChanged() => _button.interactable = AllServices.CoinService.Coins >= _turret.TurretProfile.BuildCost;
    }
}