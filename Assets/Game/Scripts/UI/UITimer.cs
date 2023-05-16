using TowerDefender.Application.Services;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefender.Game.UI
{
    public class UITimer : MonoBehaviour
    {
        [SerializeField] private Text _label;

        private void Awake()
        {
            AllServices.MatchService.OnTimerChanged.AddListener(OnTimerChanged);
        }
        private void OnDestroy() => AllServices.MatchService.OnTimerChanged.RemoveListener(OnTimerChanged);

        private void OnTimerChanged() => _label.text = AllServices.MatchService.Timer == 0 ? string.Empty : AllServices.MatchService.Timer.ToString();
    }
}