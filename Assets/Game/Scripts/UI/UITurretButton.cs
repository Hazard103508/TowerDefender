using TowerDefender.Application.Services;
using TowerDefender.Game.ScriptableObjects;
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
        private Button _button;
        private TurretProfile _turretProfile;

        private void Awake()
        {
            _button = GetComponent<Button>();
            
        }
        private void Start() => AllServices.CoinService.OnCoinsChanged.AddListener(OnCoinsChanged);
        private void OnDestroy() => AllServices.CoinService.OnCoinsChanged.RemoveListener(OnCoinsChanged);
        public void Initialize(TurretProfile turretProfile)
        {
            _turretProfile = turretProfile;
            _icon.sprite = turretProfile.icon;
            _label.text = turretProfile.BuildCost.ToString();

            _button.onClick.AddListener(OnButtonClick);
        }
        private void OnButtonClick()
        {
            turretSpawner.Show(_turretProfile);
            EventSystem.current.SetSelectedGameObject(null);
        }
        private void OnCoinsChanged() => _button.interactable = AllServices.GameDataService.Coins >= _turretProfile.BuildCost;
    }
}