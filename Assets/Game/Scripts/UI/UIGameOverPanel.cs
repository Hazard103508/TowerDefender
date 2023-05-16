using TowerDefender.Application.Services;
using UnityEngine;
using UnityEngine.UI;
using UnityShared.Behaviours.Handlers;

namespace TowerDefender.Game.UI
{
    public class UIGameOverPanel : MonoBehaviour
    {
        [SerializeField] private PanelHandler _panelWin;
        [SerializeField] private PanelHandler _panelLose;

        private void Start() // TODO - AWAKE
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