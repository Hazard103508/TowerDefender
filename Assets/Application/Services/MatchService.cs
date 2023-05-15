using TowerDefender.Application.Interfaces;
using TowerDefender.Game.ScriptableObjects;
using UnityEngine.Events;

namespace TowerDefender.Application.Services
{
    public class MatchService : IMatchService
    {
        public MatchProfile DefaultMatchProfile { get; private set; }

        public MatchService(MatchProfile matchProfile)
        {
            DefaultMatchProfile = matchProfile;
        }
    }
}