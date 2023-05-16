using TowerDefender.Application.Services;
using TowerDefender.Commons.Behaviours;
using UnityEngine;

namespace TowerDefender.Game.UI
{
    public class UIGameOverPanel : MonoBehaviour
    {
        [SerializeField] private PanelHandler _panelWin;
        [SerializeField] private PanelHandler _panelLose;

        private void Awake()
        {
            AllServices.MatchService.OnMatchStateChanged.AddListener(OnMatchStateChanged);
        }
        private void OnDestroy() => AllServices.MatchService.OnMatchStateChanged.RemoveListener(OnMatchStateChanged);

        private void OnMatchStateChanged()
        {
            if (AllServices.MatchService.MatchState == MatchState.Win)
                _panelWin.Show();
            else if (AllServices.MatchService.MatchState == MatchState.Lose)
                _panelLose.Show();
        }
    }
}