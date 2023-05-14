using TowerDefender.Game.ScriptableObjects;
using UnityEngine;
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
        public void Initialize(TurretProfile turretProfile)
        {
            _turretProfile = turretProfile;
            _icon.sprite = turretProfile.icon;
            _label.text = turretProfile.BuildCost.ToString();

            _button.onClick.AddListener(OnButtonClick);
        }
        private void OnButtonClick() => turretSpawner.Show(_turretProfile);
    }
}