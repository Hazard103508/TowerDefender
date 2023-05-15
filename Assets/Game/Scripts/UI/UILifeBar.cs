using TowerDefender.Commons;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefender.Game.UI
{
    public class UILifeBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public float CurrentHP
        {
            get => _slider.value;
            set => _slider.value = value;
        }
        public float MaxHP
        {
            get => _slider.maxValue;
            set => _slider.maxValue = value;
        }
    }
}