using TowerDefender.Game.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefender.Game.UI
{
    public class UITurretButton : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Text _label;
        private TurretProfile _turretProfile;

        public void Initialize(TurretProfile turretProfile)
        { 
            _turretProfile = turretProfile;
            _icon.sprite = turretProfile.icon;
            _label.text = turretProfile.BuildCost.ToString();
        }
    }
}