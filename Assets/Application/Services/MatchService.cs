using TowerDefender.Application.Interfaces;
using TowerDefender.Game.ScriptableObjects;
using UnityEngine.Events;

namespace TowerDefender.Application.Services
{
    public class MatchService : IMatchService
    {
        private MatchState _matchState;
        private int _timer;


        public MatchProfile DefaultMatchProfile { get; private set; }
        public MatchState MatchState
        {
            get => _matchState;
            set
            {
                _matchState = value;
                OnMatchStateChanged.Invoke();
            }
        }
        public int Timer
        {
            get => _timer;
            set
            {
                _timer = value;
                OnTimerChanged.Invoke();
            }
        }

        public UnityEvent OnMatchStateChanged { get; set; }
        public UnityEvent OnTimerChanged { get; set; }

        public MatchService(MatchProfile matchProfile)
        {
            DefaultMatchProfile = matchProfile;
            OnMatchStateChanged = new UnityEvent();
            OnTimerChanged = new UnityEvent();
        }
    }
    public enum MatchState
    {
        CoolDown,
        WaveBegan,
        WaveEnded,
        Win,
        Lose,
    }
}