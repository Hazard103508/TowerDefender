using TowerDefender.Application.Services;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefender.Game.UI
{
    public class UIMatchState : MonoBehaviour
    {
        [SerializeField] private Text _label;

        private void Awake()
        {
            AllServices.MatchService.OnMatchStateChanged.AddListener(OnMatchStateChanged);
        }
        private void OnDestroy() => AllServices.MatchService.OnMatchStateChanged.RemoveListener(OnMatchStateChanged);

        private void OnMatchStateChanged() => _label.text = AllServices.MatchService.IsGameOver ? string.Empty : AllServices.MatchService.MatchState.ToString();
    }
}