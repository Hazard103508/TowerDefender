using TowerDefender.Application.Interfaces;
using TowerDefender.Application.Services;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefender.Application.Services
{
    public class ScoreService : IScoreService
    {
        public ScoreService()
        {
            OnScoreChanged = new UnityEvent();
        }

        public UnityEvent OnScoreChanged { get; set; }

        public void Add(int points)
        {
            AllServices.GameDataService.Score += points;
            OnScoreChanged.Invoke();
        }
      }
}